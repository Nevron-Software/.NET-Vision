using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

using Nevron.Dom;
using Nevron.Diagram;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Batches;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Templates;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.WebForm;
using Nevron.UI.WebForm.Controls;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///	Summary description for NOrthogonalGraphLayoutUC.
	/// </summary>
	public partial class NOrthogonalGraphLayoutUC : NDiagramExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (NDrawingView1.RequiresInitialization)
            {
                // begin view init
                NDrawingView1.ViewLayout = CanvasLayout.Fit;
                NDrawingView1.GlobalVisibility.ShowPorts = false;
                NDrawingView1.GlobalVisibility.ShowArrowheads = false;

                // init document
                NDrawingView1.Document.HistoryService.Stop();
                NDrawingView1.Document.BeginInit();
                InitDocument();
                NDrawingView1.Document.EndInit();
            }
        }

        #region Implementation

        private void InitDocument()
		{
            NDrawingDocument document = NDrawingView1.Document;

            // remove the standard frame
            document.BackgroundStyle.FrameStyle.Visible = false;

            // adjust the graphics quality
            document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

            // set up visual formatting
            document.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133));
            document.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));

            NStyleSheet sheet = new NStyleSheet("edges");
            sheet.Style.StartArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);
            sheet.Style.EndArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);
            document.StyleSheets.AddChild(sheet);

            // create a tree
            CreateDiagram();

            // perform the layout
            PerformLayout(null);
        }
		private void CreateDiagram()
		{
			const int width = 100, height = 100, distance = 200;
			NBasicShapesFactory f = new NBasicShapesFactory(NDrawingView1.Document);
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

					NDrawingView1.Document.ActiveLayer.AddChild(shapes[i]);
				}
				else
				{
					edge = new NRoutableConnector();
					edge.ConnectorType = RoutableConnectorType.DynamicPolyline;
					edge.StyleSheetName = "edges";
					NDrawingView1.Document.ActiveLayer.AddChild(edge);
					edge.FromShape = shapes[from[i - vertexCount] - 1];
					edge.ToShape = shapes[to[i - vertexCount] - 1];
				}
			}
		}
        private void CreateGraph(int vertexCount, int edgeCount)
        {
            NDrawingView1.Document.ActiveLayer.RemoveAllChildren();

            NRandomGraphTemplate randomGraph = new NRandomGraphTemplate();
            randomGraph.EdgesStyleSheetName = "edges";
            randomGraph.VertexCount = vertexCount;
            randomGraph.EdgeCount = edgeCount;
            randomGraph.Create(NDrawingView1.Document);
        }
		private void PerformLayout(Hashtable args)
		{
			// Create the layout
			NOrthogonalGraphLayout layout = new NOrthogonalGraphLayout();

            // Configure the layout
            NLayoutsHelper.ConfigureLayout(layout, args);

            // Get the shapes to layout
            NNodeList shapes = NDrawingView1.Document.ActiveLayer.Children(NFilters.Shape2D);

            // Layout the shapes
			layout.Layout(shapes, new NDrawingLayoutContext(NDrawingView1.Document));

            // Resize document to fit all shapes
            NDrawingView1.Document.SizeToContent();
        }

        #endregion 

        #region Event Handlers

        protected void NDrawingView1_AsyncCustomCommand(object sender, EventArgs e)
        {
            NCallbackCustomCommandArgs args = e as NCallbackCustomCommandArgs;
            switch (args.Command.Name)
            {
                case "btn1":
                    CreateGraph(10, 15);
                    break;

                case "btn2":
                    CreateGraph(20, 25);
                    break;
            }

            PerformLayout(args.Command.Arguments);
            m_bClientSideRedrawRequired = true;
        }
        protected void NDrawingView1_AsyncQueryCommandResult(object sender, EventArgs e)
        {
            NCallbackQueryCommandResultArgs args = e as NCallbackQueryCommandResultArgs;
            NAjaxXmlTransportBuilder resultBuilder = args.ResultBuilder;
            if (m_bClientSideRedrawRequired && !resultBuilder.ContainsRedrawDataSection())
            {
                resultBuilder.AddRedrawDataSection(NDrawingView1);
            }
        }

        #endregion

        #region Fields

        private bool m_bClientSideRedrawRequired = false;

        #endregion
    }
}