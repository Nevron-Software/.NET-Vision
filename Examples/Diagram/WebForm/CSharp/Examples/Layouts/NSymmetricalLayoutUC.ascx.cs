using System;
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
	///	Summary description for NSymmetricalLayoutUC.
	/// </summary>
	public partial class NSymmetricalLayoutUC : NDiagramExampleUC
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
            document.Style.StartArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, String.Empty, NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);
            document.Style.EndArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, String.Empty, NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);

			// Create a tree
			DiagramRenderer renderer = new DiagramRenderer();
			renderer.CreateTree(document, 4, 3);

			// Apply the layout
			renderer.ApplyLayout(document, null);

			// Resize document to fit all shapes
			document.SizeToContent();
        }

        #endregion

		#region Nested Types

		[Serializable]
		private class CustomRequestCallback : INCustomRequestCallback
		{
			void INCustomRequestCallback.OnCustomRequestCallback(NAspNetThinWebControl control, NRequestContext context, string argument)
			{
				NThinDiagramControl diagramControl = (NThinDiagramControl)control;
				NDrawingDocument document = diagramControl.Document;

				NDrawingDocumentHelper helper = new NDrawingDocumentHelper(document);
				Dictionary<string, string> settings = helper.ParseSettings(argument);

				DiagramRenderer renderer = new DiagramRenderer();
				switch (settings["command"])
				{
					case "Tree4Levels":
						renderer.CreateTree(document, 4, 3);
						break;
					case "Tree5Levels":
						renderer.CreateTree(document, 5, 2);
						break;
				}

				// Layout the diagram
				renderer.ApplyLayout(document, settings);

				// Resize document to fit all shapes
				document.SizeToContent();

				// Update the view
				diagramControl.UpdateView();
			}
		}

		private class DiagramRenderer
		{
			public void CreateTree(NDrawingDocument document, int levels, int branchNodes)
			{
				// clean up the active layer
				document.ActiveLayer.RemoveAllChildren();

				// we will be using basic shapes with 40, 40 size
				NBasicShapesFactory basicShapesFactory = new NBasicShapesFactory();
				basicShapesFactory.DefaultSize = new NSizeF(40, 40);

				NShape cur = null;
				NShape edge = null;

				List<NShape> curRowNodes = null;
				List<NShape> prevRowNodes = null;

				int i, level;
				int levelNodesCount;

				for (level = 1; level <= levels; level++)
				{
					curRowNodes = new List<NShape>();

					//Create a balanced tree
					levelNodesCount = (int)Math.Pow(branchNodes, level - 1);
					for (i = 0; i < levelNodesCount; i++)
					{
						// create the cur node
						cur = basicShapesFactory.CreateShape(BasicShapes.Circle);
						((NDynamicPort)cur.Ports.GetChildByName("Center", -1)).GlueMode = DynamicPortGlueMode.GlueToLocation;
						document.ActiveLayer.AddChild(cur);

						// connect with ancestor
						if (level > 1)
						{
							edge = new NLineShape();
							document.ActiveLayer.AddChild(edge);

							int parentIndex = (int)Math.Floor((double)(i / branchNodes));
							edge.FromShape = prevRowNodes[parentIndex];
							edge.ToShape = cur;
						}

						curRowNodes.Add(cur);
					}

					prevRowNodes = curRowNodes;
				}

				// send links to back
				NBatchReorder batchReorder = new NBatchReorder(document);
				batchReorder.Build(document.ActiveLayer.Children(NFilters.Shape1D));
				batchReorder.SendToBack(false);
			}
			public void ApplyLayout(NDrawingDocument document, Dictionary<string, string> settings)
			{
				// create a layout
				NSymmetricalLayout layout = new NSymmetricalLayout();

				// configure the optional forces
				layout.BounceBackForce.Padding = 100f;
				layout.GravityForce.AttractionCoefficient = 0.2f;
				layout.MagneticFieldForce.DistancePower = 0.6f;
				layout.MagneticFieldForce.FieldDirection = MagneticFieldDirection.OrthogonalLeftwardDownward;
				layout.MagneticFieldForce.MagnetizationType = MagnetizationType.Unidirectional;
				layout.MagneticFieldForce.TorsionCoefficient = 2f;

				// configure layout
				if (settings != null)
				{
					layout.BounceBackForce.Enabled = Boolean.Parse(settings["BounceBackForce"]);
					layout.GravityForce.Enabled = Boolean.Parse(settings["GravityForce"]);
					layout.MagneticFieldForce.Enabled = Boolean.Parse(settings["MagneticFieldForce"]);
				}

				// get the shapes to layout
				NNodeList shapes = document.ActiveLayer.Children(NFilters.Shape2D);

				// layout the shapes
				layout.Layout(shapes, new NDrawingLayoutContext(document));
			}
		}

		#endregion
    }
}