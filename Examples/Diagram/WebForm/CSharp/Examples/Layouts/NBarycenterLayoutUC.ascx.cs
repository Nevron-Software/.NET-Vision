using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

using Nevron.Diagram;
using Nevron.Diagram.Batches;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.ThinWeb;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///	Summary description for NBarycenterLayoutUC.
	/// </summary>
	public partial class NBarycenterLayoutUC : NDiagramExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (NThinDiagramControl1.Initialized)
				return;

			// Init the diagram control
			NThinDiagramControl1.StateId = "Diagram1";
			NThinDiagramControl1.CustomRequestCallback = new CustomRequestCallback();

			// Init the view
			NThinDiagramControl1.View.Layout = CanvasLayout.Fit;

			// Init the document
			NDrawingDocument document = NThinDiagramControl1.Document;
			document.BeginInit();
			InitDocument(document);
			document.EndInit();
        }

        #region Implementation

        private void InitDocument(NDrawingDocument document)
		{
            // Remove the standard frame
            document.BackgroundStyle.FrameStyle.Visible = false;

            // Adjust the graphics quality
            document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Set up visual formatting
            document.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(251, 203, 156), Color.FromArgb(247, 150, 56));
            document.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));

            NStyleSheet sheet = new NStyleSheet("edges");
            sheet.Style.StartArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);
            sheet.Style.EndArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);
            document.StyleSheets.AddChild(sheet);

			// Create the initial diagram
			DiagramRenderer renderer = new DiagramRenderer();
			renderer.CreateRandomDiagram(document, 15, 15);
			
			// Layout the diagram
			renderer.ApplyLayout(document, null);

			// Resize document to fit all shapes
			document.SizeToContent();
		}

        #endregion

		#region Nested Types

		[Serializable]
		private class CustomRequestCallback : INCustomRequestCallback
		{
			#region INCustomRequestCallback Members

			void INCustomRequestCallback.OnCustomRequestCallback(NAspNetThinWebControl control, NRequestContext context, string argument)
			{
				NThinDiagramControl diagramControl = (NThinDiagramControl)control;
				NDrawingDocument document = diagramControl.Document;

				NDrawingDocumentHelper helper = new NDrawingDocumentHelper(document);
				Dictionary<string, string> settings = helper.ParseSettings(argument);

				DiagramRenderer renderer = new DiagramRenderer();
				switch (settings["command"])
				{
					case "randomGrid1Button":
						renderer.CreateRandomDiagram(document, 10, 10);
						break;
					case "randomGrid2Button":
						renderer.CreateRandomDiagram(document, 15, 15);
						break;
					case "triangularGrid1Button":
						renderer.CreateTriangularGridDiagram(document, 6);
						break;
					case "triangularGrid2Button":
						renderer.CreateTriangularGridDiagram(document, 8);
						break;
				}

				// Layout the diagram
				renderer.ApplyLayout(document, settings);

				// Resize document to fit all shapes
				document.SizeToContent();

				// Update the view
				diagramControl.UpdateView();
			}

			#endregion
		}

		private class DiagramRenderer
		{
			public void CreateRandomDiagram(NDrawingDocument document, int fixedCount, int freeCount)
			{
				if (fixedCount < 3)
					throw new ArgumentException("Needs at least three fixed vertices");

				// clean up the layers
				document.ActiveLayer.RemoveAllChildren();

				// we will be using basic circle shapes with default size of (30, 30)
				NBasicShapesFactory basicShapesFactory = new NBasicShapesFactory();
				basicShapesFactory.DefaultSize = new NSizeF(30, 30);

				// create the fixed vertices
				NShape[] fixedShapes = new NShape[fixedCount];

				for (int i = 0; i < fixedCount; i++)
				{
					fixedShapes[i] = basicShapesFactory.CreateShape(BasicShapes.Circle);
					((NDynamicPort)fixedShapes[i].Ports.GetChildByName("Center", -1)).GlueMode = DynamicPortGlueMode.GlueToLocation;
					fixedShapes[i].Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(251, 203, 156), Color.FromArgb(247, 150, 56));
					fixedShapes[i].Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));

					// setting the ForceXMoveable and ForceYMoveable properties to false
					// specifies that the layout cannot move the shape in both X and Y directions
					fixedShapes[i].LayoutData.ForceXMoveable = false;
					fixedShapes[i].LayoutData.ForceYMoveable = false;

					document.ActiveLayer.AddChild(fixedShapes[i]);
				}

				// create the free vertices
				NShape[] freeShapes = new NShape[freeCount];
				for (int i = 0; i < freeCount; i++)
				{
					freeShapes[i] = basicShapesFactory.CreateShape(BasicShapes.Circle);
					((NDynamicPort)freeShapes[i].Ports.GetChildByName("Center", -1)).GlueMode = DynamicPortGlueMode.GlueToLocation;
					freeShapes[i].Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133));
					freeShapes[i].Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
					document.ActiveLayer.AddChild(freeShapes[i]);
				}

				// link the fixed shapes in a circle
				for (int i = 0; i < fixedCount; i++)
				{
					NLineShape lineShape = new NLineShape();
					document.ActiveLayer.AddChild(lineShape);

					if (i == 0)
					{
						lineShape.FromShape = fixedShapes[fixedCount - 1];
						lineShape.ToShape = fixedShapes[0];
					}
					else
					{
						lineShape.FromShape = fixedShapes[i - 1];
						lineShape.ToShape = fixedShapes[i];
					}
				}

				// link each free shape with two different random fixed shapes
				Random rnd = new Random();
				for (int i = 0; i < freeCount; i++)
				{
					int firstFixed = rnd.Next(fixedCount);
					int secondFixed = (firstFixed + rnd.Next(fixedCount / 3) + 1) % fixedCount;

					// link with first fixed
					NLineShape lineShape = new NLineShape();
					document.ActiveLayer.AddChild(lineShape);

					lineShape.FromShape = freeShapes[i];
					lineShape.ToShape = fixedShapes[firstFixed];

					// link with second fixed
					lineShape = new NLineShape();
					document.ActiveLayer.AddChild(lineShape);

					lineShape.FromShape = freeShapes[i];
					lineShape.ToShape = fixedShapes[secondFixed];
				}

				// link each free shape with another free shape
				for (int i = 1; i < freeCount; i++)
				{
					NLineShape lineShape = new NLineShape();
					document.ActiveLayer.AddChild(lineShape);

					lineShape.FromShape = freeShapes[i - 1];
					lineShape.ToShape = freeShapes[i];
				}

				NBatchReorder batchReorder = new NBatchReorder(document);
				batchReorder.Build(document.ActiveLayer.Children(NFilters.Shape1D));
				batchReorder.SendToBack(false);
			}
			public void CreateTriangularGridDiagram(NDrawingDocument document, int levels)
			{
				// clean up the active layer 
				document.ActiveLayer.RemoveAllChildren();

				// we will be using basic circle shapes with default size of (30, 30)
				NBasicShapesFactory basicShapesFactory = new NBasicShapesFactory();
				basicShapesFactory.DefaultSize = new NSizeF(30, 30);

				NShape cur = null, prev = null;
				NShape edge = null;
				List<NShape> curRowShapes = null;
				List<NShape> prevRowShapes = null;

				for (int level = 1; level < levels; level++)
				{
					curRowShapes = new List<NShape>();

					for (int i = 0; i < level; i++)
					{
						cur = basicShapesFactory.CreateShape(BasicShapes.Circle);
						((NDynamicPort)cur.Ports.GetChildByName("Center", -1)).GlueMode = DynamicPortGlueMode.GlueToLocation;
						cur.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133));
						cur.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
						document.ActiveLayer.AddChild(cur);

						// connect with prev
						if (i > 0)
						{
							edge = new NLineShape();
							document.ActiveLayer.AddChild(edge);

							edge.FromShape = prev;
							edge.ToShape = cur;
						}

						// connect with ancestors
						if (level > 1)
						{
							if (i < prevRowShapes.Count)
							{
								edge = new NLineShape();
								document.ActiveLayer.AddChild(edge);

								edge.FromShape = prevRowShapes[i];
								edge.ToShape = cur;
							}

							if (i > 0)
							{
								edge = new NLineShape();
								document.ActiveLayer.AddChild(edge);

								edge.FromShape = prevRowShapes[i - 1];
								edge.ToShape = cur;
							}
						}

						// fix the three corner vertices
						if (level == 1 || (level == levels - 1 && (i == 0 || i == level - 1)))
						{
							cur.LayoutData.ForceXMoveable = false;
							cur.LayoutData.ForceYMoveable = false;
							cur.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(251, 203, 156), Color.FromArgb(247, 150, 56));
							cur.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
						}

						curRowShapes.Add(cur);
						prev = cur;
					}

					prevRowShapes = curRowShapes;
				}

				NBatchReorder batchReorder = new NBatchReorder(document);
				batchReorder.Build(document.ActiveLayer.Children(NFilters.Shape1D));
				batchReorder.SendToBack(false);
			}
			public void ApplyLayout(NDrawingDocument document, Dictionary<string, string> settings)
			{
				// Create the layout
				NBarycenterLayout layout = new NBarycenterLayout();

				// Configure the optional forces
				layout.BounceBackForce.RepulsionCoefficient = 20f;
				layout.GravityForce.AttractionCoefficient = 0.2f;

				// Free vertices are placed in the fixed vertices barycenter
				layout.FreeVertexPlacement.Mode = FreeVertexPlacementMode.FixedBarycenter;

				// Fixed vertices are placed on the rim of the specified ellipse
				layout.FixedVertexPlacement.Mode = FixedVertexPlacementMode.PredefinedEllipseRim;
				layout.FixedVertexPlacement.PredefinedEllipseBounds = new NRectangleF(0, 0, 700, 700);

				// Configure the layout
				if (settings != null)
				{
					layout.BounceBackForce.Enabled = Boolean.Parse(settings["BounceBackForce"]);
					layout.GravityForce.Enabled = Boolean.Parse(settings["GravityForce"]);
					layout.MinFixedVerticesCount = Int32.Parse(settings["MinFixedVerticesCount"]);
				}

				// Get the shapes to layout
				NNodeList shapes = document.ActiveLayer.Children(NFilters.Shape2D);

				// Layout the shapes
				layout.Layout(shapes, new NDrawingLayoutContext(document));
			}
		}

		#endregion
	}
}