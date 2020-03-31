using System;

using Nevron.Diagram;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.WebForm;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	/// Summary description for NFlashRedirectRenderPage.
	/// </summary>
	public partial class NFlashRedirectRenderPage : NDrawingViewHostPage
    {
        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
		public NFlashRedirectRenderPage()
		{
			DrawingView = new NDrawingView();

            NImageResponse swfResponse = new NImageResponse();
            swfResponse.ImageFormat = new NSwfImageFormat();
            swfResponse.StreamImageToBrowser = true;
            DrawingView.ServerSettings.BrowserResponseSettings.DefaultResponse = swfResponse;

			// init document
			NDrawingDocument document = DrawingView.Document;
			document.BeginInit();
			CreateScene(document);
			document.EndInit();

			DrawingView.SizeToContent();
        }

        #endregion

        #region Private Methods

        private void CreateScene(NDrawingDocument document)
		{
			// Initialize the default document style
			document.BackgroundStyle.FrameStyle.Visible = false;
			document.Style.StartArrowheadStyle.Shape = ArrowheadShape.None;
			document.Style.EndArrowheadStyle.Shape = ArrowheadShape.None;
			document.Style.FillStyle = new NGradientFillStyle(GradientStyle.DiagonalUp, GradientVariant.Variant1,
				new NArgbColor(155, 184, 209), new NArgbColor(83, 138, 179));

			NDrawingDocumentHelper helper = new NDrawingDocumentHelper(document);

			// Create the shapes
			NShape vision = helper.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(0, 0, 100, 50), "Nevron Vision", String.Empty);
			NInteractivityStyle iStyle = new NInteractivityStyle();
			iStyle.UrlLink = new NUrlLinkAttribute("http://www.nevron.com", true);
			NStyle.SetInteractivityStyle(vision, iStyle);

			NShape chart = helper.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(0, 0, 100, 50), "Nevron Chart", String.Empty);
			iStyle = new NInteractivityStyle();
			iStyle.UrlLink = new NUrlLinkAttribute("http://nevron.com/Products.ChartFor.NET.Overview.aspx", true);
			NStyle.SetInteractivityStyle(chart, iStyle);

			NShape diagram = helper.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(0, 0, 100, 50), "Nevron Diagram", String.Empty);
			iStyle = new NInteractivityStyle();
			iStyle.UrlLink = new NUrlLinkAttribute("http://nevron.com/Products.DiagramFor.NET.Overview.aspx", true);
			NStyle.SetInteractivityStyle(diagram, iStyle);

			NShape ui = helper.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(0, 0, 100, 50), "Nevron User Interface", String.Empty);
			iStyle = new NInteractivityStyle();
			iStyle.UrlLink = new NUrlLinkAttribute("http://nevron.com/Products.UserInterfaceFor.NET.Overview.aspx", true);
			NStyle.SetInteractivityStyle(ui, iStyle);

			// Create the connectors
			Connect(vision, chart);
			Connect(vision, diagram);
			Connect(vision, ui);

			// Layout the shapes
			NLayeredGraphLayout layout = new NLayeredGraphLayout();
			layout.Direction = LayoutDirection.LeftToRight;
			NNodeList shapes = document.ActiveLayer.Children(null);
			layout.Layout(shapes, new NDrawingLayoutContext(document));
		}
		private void Connect(NShape shape1, NShape shape2)
		{
			NRoutableConnector connector = new NRoutableConnector();
			DrawingView.Document.ActiveLayer.AddChild(connector);
			connector.StyleSheetName = "Connectors";
			connector.FromShape = shape1;
			connector.ToShape = shape2;
		}

        #endregion
	}
}