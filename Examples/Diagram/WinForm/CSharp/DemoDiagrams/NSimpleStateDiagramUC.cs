using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Diagram;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NSimpleStateDiagramUC.
	/// </summary>
	public class NSimpleStateDiagramUC : NDiagramExampleUC
	{
		#region Constructor

		public NSimpleStateDiagramUC(NMainForm form) : base(form)
		{
			InitializeComponent();
		}

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// commonControlsPanel
			// 
			this.commonControlsPanel.Location = new System.Drawing.Point(0, 304);
			this.commonControlsPanel.Name = "commonControlsPanel";
			this.commonControlsPanel.Size = new System.Drawing.Size(248, 80);
			// 
			// NSimpleStateDiagramUC
			// 
			this.Name = "NSimpleStateDiagramUC";
			this.Size = new System.Drawing.Size(248, 384);
			this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// begin view init
			view.BeginInit();
			view.GlobalVisibility.ShowPorts = false;
			view.Grid.Visible = false;
			view.ViewLayout = ViewLayout.Fit;
			view.DocumentPadding = new Nevron.Diagram.NMargins(10);

			// init document
            document.BeginInit();
			InitDocument();
			document.EndInit();

			// end view init
			view.EndInit();
		}

		#endregion

		#region Implementation

		private void InitDocument()
		{
			// create the flowcharting shapes factory
			NFlowChartingShapesFactory factory = new NFlowChartingShapesFactory(document);

			// modify the connectors style sheet
			NStyleSheet styleSheet = (document.StyleSheets.GetChildByName(NDR.NameConnectorsStyleSheet, -1) as NStyleSheet); 

			NTextStyle textStyle = new NTextStyle();
			textStyle.BackplaneStyle.Visible = true;
			textStyle.BackplaneStyle.StandardFrameStyle.InnerBorderWidth = new NLength(0); 
			styleSheet.Style.TextStyle = textStyle;

			styleSheet.Style.StrokeStyle = new NStrokeStyle(1, Color.Black);
			styleSheet.Style.StartArrowheadStyle.StrokeStyle = new NStrokeStyle(1, Color.Black);
			styleSheet.Style.EndArrowheadStyle.StrokeStyle = new NStrokeStyle(1, Color.Black);

			// create the begin shape 
			NShape begin = factory.CreateShape((int)FlowChartingShapes.Termination);
			begin.Bounds = new NRectangleF(100, 100, 100, 100);
			begin.Text = "BEGIN";
			document.ActiveLayer.AddChild(begin);

			// create the step1 shape
			NShape step1 = factory.CreateShape((int)FlowChartingShapes.Process);
			step1.Bounds = new NRectangleF(100, 400, 100, 100);
			step1.Text = "STEP1";
			document.ActiveLayer.AddChild(step1);

			// connect begin and step1 with bezier link
			NBezierCurveShape bezier = new NBezierCurveShape();
			bezier.StyleSheetName = NDR.NameConnectorsStyleSheet;
			bezier.Text = "BEZIER";
			bezier.FirstControlPoint = new NPointF(100, 300);
			bezier.SecondControlPoint = new NPointF(200, 300);
			document.ActiveLayer.AddChild(bezier);
            bezier.FromShape = begin;
			bezier.ToShape = step1;
			
			// create question1 shape
			NShape question1 = factory.CreateShape((int)FlowChartingShapes.Decision);
			question1.Bounds = new NRectangleF(300, 400, 100, 100);
			question1.Text = "QUESTION1";
			document.ActiveLayer.AddChild(question1);

			// connect step1 and question1 with line link
			NLineShape line = new NLineShape();
			line.StyleSheetName = NDR.NameConnectorsStyleSheet;
			line.Text = "LINE";
			document.ActiveLayer.AddChild(line);
			line.FromShape = step1;
			line.ToShape = question1;

			// create the step2 shape
			NShape step2 = factory.CreateShape((int)FlowChartingShapes.Process);
			step2.Bounds = new NRectangleF(500, 100, 100, 100);
			step2.Text = "STEP2";
			document.ActiveLayer.AddChild(step2);

			// connect step2 and question1 with HV link
			NStep2Connector hv1 = new NStep2Connector(false); 
			hv1.StyleSheetName = NDR.NameConnectorsStyleSheet;
			hv1.Text = "HV1";
			document.ActiveLayer.AddChild(hv1);
			hv1.FromShape = step2;
			hv1.ToShape = question1;

			// connect question1 and step2 and with HV link
			NStep2Connector hv2 = new NStep2Connector(false); 
			hv2.StyleSheetName = NDR.NameConnectorsStyleSheet;
			hv2.Text = "HV2";
			document.ActiveLayer.AddChild(hv2);
			hv2.FromShape = question1;
			hv2.ToShape = step2;

			// create a self loof as bezier on step2
			NBezierCurveShape selfLoop = new NBezierCurveShape();
			selfLoop.StyleSheetName = NDR.NameConnectorsStyleSheet;
			selfLoop.Text = "SELF LOOP";
			document.ActiveLayer.AddChild(selfLoop);
			selfLoop.FromShape = step2;
			selfLoop.ToShape = step2;
			selfLoop.Reflex(); 

			// create step3 shape
			NShape step3 = factory.CreateShape((int)FlowChartingShapes.Process);
			step3.Bounds = new NRectangleF(700, 600, 100, 100);
			step3.Text = "STEP3";
			document.ActiveLayer.AddChild(step3);

			// connect question1 and step3 with an HVH link
			NStep3Connector hvh1 = new NStep3Connector(false, 50, 0, true); 
			hvh1.StyleSheetName = NDR.NameConnectorsStyleSheet;
			hvh1.Text = "HVH1";
			document.ActiveLayer.AddChild(hvh1);
			hvh1.FromShape = question1;
			hvh1.ToShape = step3;

			// create end shape
			NShape end = factory.CreateShape((int)FlowChartingShapes.Termination);
			end.Bounds = new NRectangleF(300, 700, 100, 100);
			end.Text = "END";
			document.ActiveLayer.AddChild(end);

			// connect step3 and end with VH link
			NStep2Connector vh1 = new NStep2Connector(true); 
			vh1.StyleSheetName = NDR.NameConnectorsStyleSheet;
			vh1.Text = "VH1";
			document.ActiveLayer.AddChild(vh1);
			vh1.FromShape = step3;
			vh1.ToShape = end;

			// connect question1 and end with curve link (uses explicit ports)
			NRoutableConnector curve = new NRoutableConnector(RoutableConnectorType.DynamicCurve);
			curve.StyleSheetName = NDR.NameConnectorsStyleSheet;
			curve.Text = "CURVE";
			document.ActiveLayer.AddChild(curve);
			curve.StartPlug.Connect(question1.Ports.GetChildAt(3) as NPort);
			curve.EndPlug.Connect(end.Ports.GetChildAt(1) as NPort);
			curve.InsertPoint(1, new NPointF(500, 600));

			// set a shadow to the document. Since styles are inheritable all objects will reuse this shadow
			document.Style.ShadowStyle = new NShadowStyle(
				ShadowType.GaussianBlur,
				Color.Gray,
				new NPointL(5, 5),
				1,
				new NLength(3));

			// shadows must be displayed behind document content
			document.ShadowsZOrder = ShadowsZOrder.BehindDocument; 
		}

		#endregion

		#region Designer Fields
		
		private System.ComponentModel.Container components = null;

		#endregion
	}
}