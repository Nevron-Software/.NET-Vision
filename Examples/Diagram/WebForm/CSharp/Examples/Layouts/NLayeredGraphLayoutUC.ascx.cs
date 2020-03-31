using System;
using System.Collections.Generic;
using System.Drawing;

using Nevron.Diagram;
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
	///	Summary description for NLayeredGraphLayoutUC.
	/// </summary>
	public partial class NLayeredGraphLayoutUC : NDiagramExampleUC
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

            document.Style.StartArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);
            document.Style.EndArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);

			// Create a graph
			CreateGraph(document);

			// Create the layout
			NLayeredGraphLayout layout = new NLayeredGraphLayout();

			// Get the shapes to layout
			NNodeList shapes = document.ActiveLayer.Children(NFilters.Shape2D);

			// Layout the shapes
			layout.Layout(shapes, new NDrawingLayoutContext(document));

			// Resize document to fit all shapes
			document.SizeToContent();
		}
        private void CreateGraph(NDrawingDocument document)
        {
            const int width = 40, height = 40, distance = 80;
            NBasicShapesFactory f = new NBasicShapesFactory(document);
            NRoutableConnector edge;
            int[] from = new int[] { 1, 1, 1, 2, 2, 3, 3, 4, 4, 5, 6 };
            int[] to = new int[] { 2, 3, 4, 4, 5, 6, 7, 5, 9, 8, 9 };
            NShape[] shapes = new NShape[9];
            int vertexCount = shapes.Length, edgeCount = from.Length;
            int i, j, count = vertexCount + edgeCount;

            for (i = 0; i < count; i++)
            {
                if (i < vertexCount)
                {
                    j = vertexCount % 2 == 0 ? i : i + 1;
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
                    edge.StyleSheetName = "CustomConnectors";
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

				// Create and configure the layout
				NLayeredGraphLayout layout = new NLayeredGraphLayout();
				helper.ConfigureLayout(layout, settings);

				// Get the shapes to layout
				NNodeList shapes = document.ActiveLayer.Children(NFilters.Shape2D);

				// Layout the shapes
				layout.Layout(shapes, new NDrawingLayoutContext(document));

				// Resize document to fit all shapes
				document.SizeToContent();

				// Update the view
				diagramControl.UpdateView();
			}
		}

		#endregion
	}
}