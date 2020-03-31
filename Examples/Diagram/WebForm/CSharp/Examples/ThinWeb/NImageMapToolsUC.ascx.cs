using System.Drawing;
using Nevron.Diagram;
using Nevron.Diagram.Shapes;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	/// 
	/// </summary>
    public partial class NImageMapToolsUC : NDiagramExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// begin view init
			base.DefaultGridOrigin = new NPointF(30, 30);
			base.DefaultGridCellSize = new NSizeF(100, 50);
			base.DefaultGridSpacing = new NSizeF(50, 40);

            NDrawingDocument document = NThinDiagramControl1.Document;

            if (!NThinDiagramControl1.Initialized)
            {
                NThinDiagramControl1.View.Layout = CanvasLayout.Fit;
                // add the client mouse event tool
                NThinDiagramControl1.Controller.Tools.Add(new NPostbackTool());

                document.BeginInit();

                document.BackgroundStyle.FrameStyle.Visible = false;
                document.AutoBoundsPadding = new Nevron.Diagram.NMargins(10f, 10f, 10f, 10f);
                document.Style.FillStyle = new NColorFillStyle(Color.White);

                NBasicShapesFactory factory = new NBasicShapesFactory(document);

                NShape outerCircle = factory.CreateShape(BasicShapes.Circle);
                outerCircle.Bounds = new NRectangleF(0f, 0f, 200f, 200f);
                document.ActiveLayer.AddChild(outerCircle);

                NShape rect = factory.CreateShape(BasicShapes.Rectangle);
                rect.Bounds = new NRectangleF(42f, 42f, 50f, 50f);
                rect.Style.FillStyle = new NColorFillStyle(Color.LightBlue);
                rect.Style.InteractivityStyle = CreateInteractivityStyle("Rectangle", @"http://en.wikipedia.org/wiki/Rectangle");
                rect.Tag = true;
                document.ActiveLayer.AddChild(rect);

                NShape triangle = factory.CreateShape(BasicShapes.Triangle);
                triangle.Bounds = new NRectangleF(121f, 57f, 60f, 55f);
                triangle.Style.FillStyle = new NColorFillStyle(Color.LightBlue);
                triangle.Style.InteractivityStyle = CreateInteractivityStyle("Triangle", @"http://en.wikipedia.org/wiki/Triangle");
                triangle.Tag = true;
                document.ActiveLayer.AddChild(triangle);

                NShape pentagon = factory.CreateShape(BasicShapes.Pentagon);
                pentagon.Bounds = new NRectangleF(60f, 120f, 54f, 50f);
                pentagon.Style.FillStyle = new NColorFillStyle(Color.LightBlue);
                pentagon.Style.InteractivityStyle = CreateInteractivityStyle("Pentagon", @"http://en.wikipedia.org/wiki/Pentagon");
                pentagon.Tag = true;
                document.ActiveLayer.AddChild(pentagon);

                document.SizeToContent();
                document.EndInit();

				// add tooltip, browser redirect and cursor tools
				NTooltipTool tooltipTool = new NTooltipTool();
				NThinDiagramControl1.Controller.Tools.Add(tooltipTool);

				NBrowserRedirectTool browserRedirectTool = new NBrowserRedirectTool();
				NThinDiagramControl1.Controller.Tools.Add(browserRedirectTool);

				NCursorTool cursorTool = new NCursorTool();
				NThinDiagramControl1.Controller.Tools.Add(cursorTool);

				// configure the toolbar
				NThinDiagramControl1.Toolbar.Items.Add(new NToolbarButton(new NToggleTooltipToolAction()));
				NThinDiagramControl1.Toolbar.Items.Add(new NToolbarButton(new NToggleBrowserRedirectToolAction()));
				NThinDiagramControl1.Toolbar.Items.Add(new NToolbarButton(new NToggleCursorToolAction()));
            }
        }

        private NInteractivityStyle CreateInteractivityStyle(string shapeName, string url)
        {
            NInteractivityStyle interactivityStyle = new NInteractivityStyle();

            interactivityStyle.Tooltip.Text = shapeName;
            interactivityStyle.UrlLink.Url = url;
            interactivityStyle.Cursor.Type = CursorType.Hand;

            return interactivityStyle;
		}
	}
}