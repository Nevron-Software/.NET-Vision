using System.Drawing;
using Nevron.Diagram;
using Nevron.Diagram.Shapes;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///	Summary description for NThinWebGeneral.
	/// </summary>
	public partial class NClientSideEventsToolUC : NDiagramExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (!IsPostBack)
            {
                CaptureMouseEventDropDownList.Items.Add("Mouse Down");
                CaptureMouseEventDropDownList.Items.Add("Mouse Up");
                CaptureMouseEventDropDownList.Items.Add("Click");
                CaptureMouseEventDropDownList.Items.Add("Double Click");
                CaptureMouseEventDropDownList.Items.Add("Mouse Enter");
                CaptureMouseEventDropDownList.Items.Add("Mouse Leave");
                CaptureMouseEventDropDownList.SelectedIndex = 0;
            }

			// begin view init
			base.DefaultGridOrigin = new NPointF(30, 30);
			base.DefaultGridCellSize = new NSizeF(100, 50);
			base.DefaultGridSpacing = new NSizeF(50, 40);

            NDrawingDocument document = NThinDiagramControl1.Document;

            if (!NThinDiagramControl1.Initialized)
            {
                NThinDiagramControl1.View.Layout = CanvasLayout.Fit;
                // add the client mouse event tool
                NThinDiagramControl1.Controller.Tools.Add(new NClientMouseEventTool());
            }

            // Create a few simple shapes with attached client mouse event interactivity
            document.Reset();
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
            rect.Style.FillStyle = new NColorFillStyle(Color.Orange);
            rect.Style.InteractivityStyle = CreateInteractivityStyle("Rectangle");
            document.ActiveLayer.AddChild(rect);

            NShape triangle = factory.CreateShape(BasicShapes.Triangle);
            triangle.Bounds = new NRectangleF(121f, 57f, 60f, 55f);
            triangle.Style.FillStyle = new NColorFillStyle(Color.LightGray);
            triangle.Style.InteractivityStyle = CreateInteractivityStyle("Triangle");
            document.ActiveLayer.AddChild(triangle);

            NShape pentagon = factory.CreateShape(BasicShapes.Pentagon);
            pentagon.Bounds = new NRectangleF(60f, 120f, 54f, 50f);
            pentagon.Style.FillStyle = new NColorFillStyle(Color.WhiteSmoke);
            pentagon.Style.InteractivityStyle = CreateInteractivityStyle("Pentagon");
            document.ActiveLayer.AddChild(pentagon);

            document.SizeToContent();
            document.EndInit();
        }

        private NInteractivityStyle CreateInteractivityStyle(string shapeName)
        {
            NInteractivityStyle interactivityStyle = new NInteractivityStyle();
            string script = "alert(\"Mouse Event [" + CaptureMouseEventDropDownList.SelectedValue.ToString() + "]. Captured for bar [" + shapeName + "])\");";

            switch (CaptureMouseEventDropDownList.SelectedIndex)
            {
                case 0: // Mouse down
                    interactivityStyle.ClientMouseEventAttribute.MouseDown = script;
                    break;
                case 1: // Mouse up
                    interactivityStyle.ClientMouseEventAttribute.MouseUp = script;
                    break;
                case 2: // Click
                    interactivityStyle.ClientMouseEventAttribute.Click = script;
                    break;
                case 3: // Double clicks
                    interactivityStyle.ClientMouseEventAttribute.DoubleClick = script;
                    break;
                case 4: // MouseEnter
                    interactivityStyle.ClientMouseEventAttribute.MouseEnter = script;
                    break;
                case 5: // MouseLeave
                    interactivityStyle.ClientMouseEventAttribute.MouseLeave = script;
                    break;
            }

            return interactivityStyle;
		}
	}
}