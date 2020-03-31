using System;
using System.Collections.Generic;
using System.Drawing;

using Nevron.Diagram;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.Templates;
using Nevron.Diagram.ThinWeb;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///	Summary description for NOrthogonalGraphLayoutUC.
	/// </summary>
	public partial class NOrthogonalGraphLayoutUC : NDiagramExampleUC
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
            document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

            // Set up visual formatting
            document.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133));
            document.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));

            NStyleSheet sheet = new NStyleSheet("edges");
            sheet.Style.StartArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);
            sheet.Style.EndArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);
            document.StyleSheets.AddChild(sheet);

            // Create a tree
			CreateTestDiagram(document);

			// Apply the layout
			DiagramRenderer renderer = new DiagramRenderer();
			renderer.ApplyLayout(document, null);

			// Resize document to fit all shapes
			document.SizeToContent();
		}
		private void CreateTestDiagram(NDrawingDocument document)
		{
			const int width = 100, height = 100, distance = 200;
			NBasicShapesFactory f = new NBasicShapesFactory(document);
			NRoutableConnector edge;
			int[] from = new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 4, 4, 4, 5, 5, 6 };
			int[] to = new int[] { 2, 3, 4, 4, 5, 8, 6, 7, 5, 8, 10, 8, 9, 10 };
			NShape[] shapes = new NShape[10];
			int vertexCount = shapes.Length;
			int edgeCount = from.Length;
			int count = vertexCount + edgeCount;

			for (int i = 0; i < count; i++)
			{
				if (i < vertexCount)
				{
					int j = vertexCount % 2 == 0 ? i : i + 1;
					shapes[i] = f.CreateShape((int)BasicShapes.Rectangle);

					if (vertexCount % 2 != 0 && i == 0)
					{
						shapes[i].Bounds = new NRectangleF((int)(width + (distance * 1.5)) / 2,
							distance + (j / 2) * (int)(distance * 1.5), width, height);
					}
					else
					{
						shapes[i].Bounds = new NRectangleF(width / 2 + (j % 2) * (int)(distance * 1.5),
							height + (j / 2) * (int)(distance * 1.5), width, height);
					}

					document.ActiveLayer.AddChild(shapes[i]);
				}
				else
				{
					edge = new NRoutableConnector();
					edge.ConnectorType = RoutableConnectorType.DynamicPolyline;
					edge.StyleSheetName = "edges";
					document.ActiveLayer.AddChild(edge);
					edge.FromShape = shapes[from[i - vertexCount] - 1];
					edge.ToShape = shapes[to[i - vertexCount] - 1];
				}
			}
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
					case "RandomGraph10":
						renderer.CreateGraph(document, 10, 15);
						break;
					case "RandomGraph20":
						renderer.CreateGraph(document, 20, 25);
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
			public void CreateGraph(NDrawingDocument document, int vertexCount, int edgeCount)
			{
				// Clear the document
				document.ActiveLayer.RemoveAllChildren();

				// Create a graph
				NRandomGraphTemplate randomGraph = new NRandomGraphTemplate();
				randomGraph.EdgesStyleSheetName = "edges";
				randomGraph.VertexCount = vertexCount;
				randomGraph.EdgeCount = edgeCount;
				randomGraph.Create(document);
			}
			public void ApplyLayout(NDrawingDocument document, Dictionary<string, string> settings)
			{
				// Create the layout
				NOrthogonalGraphLayout layout = new NOrthogonalGraphLayout();

				// Configure the layout
				if (settings != null)
				{
					NDrawingDocumentHelper helper = new NDrawingDocumentHelper(document);
					helper.ConfigureLayout(layout, settings);
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