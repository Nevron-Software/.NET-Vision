using System.Drawing;
using Nevron.Diagram;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.ThinWeb;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///	Summary description for NThinWebGeneral.
	/// </summary>
	public partial class NPostbackToolUC : NDiagramExampleUC
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
                rect.Style.InteractivityStyle = CreateInteractivityStyle("Rectangle");
                rect.Tag = true;
                document.ActiveLayer.AddChild(rect);

                NShape triangle = factory.CreateShape(BasicShapes.Triangle);
                triangle.Bounds = new NRectangleF(121f, 57f, 60f, 55f);
                triangle.Style.FillStyle = new NColorFillStyle(Color.LightBlue);
                triangle.Style.InteractivityStyle = CreateInteractivityStyle("Triangle");
                triangle.Tag = true;
                document.ActiveLayer.AddChild(triangle);

                NShape pentagon = factory.CreateShape(BasicShapes.Pentagon);
                pentagon.Bounds = new NRectangleF(60f, 120f, 54f, 50f);
                pentagon.Style.FillStyle = new NColorFillStyle(Color.LightBlue);
                pentagon.Style.InteractivityStyle = CreateInteractivityStyle("Pentagon");
                pentagon.Tag = true;
                document.ActiveLayer.AddChild(pentagon);

                document.SizeToContent();
                document.EndInit();
            }

            // Create a few simple shapes with attached client mouse event interactivity
            NThinDiagramControl1.Postback += new NPostbackEventHandler(NThinDiagramControl1_Postback);
            NThinDiagramControl1.Controller.Tools.Clear();

            NTooltipTool tooltipTool = new NTooltipTool();
            NThinDiagramControl1.Controller.Tools.Add(tooltipTool);
            
            NPostbackTool postbackTool = new NPostbackTool();
//          postbackTool.PostbackOnlyOnInteractiveItems = PostbackOnlyOnInteractiveItemsCheckBox.Checked;
            NThinDiagramControl1.Controller.Tools.Add(postbackTool);
        }

        void NThinDiagramControl1_Postback(object sender, ThinWeb.NPostbackEventArgs e)
        {
            NThinDiagramControl diagramControl = (NThinDiagramControl)sender;
            NNodeList allShapes = diagramControl.Document.ActiveLayer.Children(Nevron.Diagram.Filters.NFilters.Shape2D);
            NNodeList hitNodes = diagramControl.HitTest(e.MousePosition.ToNPointF());
            hitNodes = hitNodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D);

            foreach (NShape shape in allShapes)
            {
                if (NSystem.SafeEquals(shape.Tag, true))
                {
                    shape.Style.FillStyle = new NColorFillStyle(Color.LightBlue);
                }
            }

            foreach (NShape shape in hitNodes)
            {
                if (NSystem.SafeEquals(shape.Tag, true))
                {
                    shape.Style.FillStyle = new NColorFillStyle(Color.Red);
                }
            }
        }


        private NInteractivityStyle CreateInteractivityStyle(string shapeName)
        {
            NInteractivityStyle interactivityStyle = new NInteractivityStyle("Click on me to make me Red");
            return interactivityStyle;
		}
	}
}