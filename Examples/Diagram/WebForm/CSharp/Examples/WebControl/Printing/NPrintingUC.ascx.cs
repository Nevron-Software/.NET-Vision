using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Nevron.GraphicsCore;

using Nevron.Dom;
using Nevron.Diagram;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.WebForm;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///		Summary description for NPrintingUC.
	/// </summary>
	public partial class NPrintingUC : NDiagramExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			NDrawingView1.StateManager = new NDiagramBatonSessionStateManager(Context, "Nevron.Examples.Diagram.Webform.NPrintingUC");

			if (NDrawingView1.RequiresInitialization)
			{
				// begin view init
				NDrawingView1.ViewLayout = CanvasLayout.Normal;
				NDrawingView1.DocumentPadding = new Nevron.Diagram.NMargins(10);

				// init document
				NDrawingView1.Document.BeginInit();
				InitDocument();
				NDrawingView1.Document.EndInit();

				NDrawingView1.SizeToContent();
			}
		}

		void InitDocument()
		{
			// set up visual formatting
			NDrawingView1.Document.Style.FillStyle = new NColorFillStyle(Color.Linen);

			// create the flowcharting shapes factory
			NFlowChartingShapesFactory factory = new NFlowChartingShapesFactory(NDrawingView1.Document);

			// modify the connectors style sheet
			NStyleSheet styleSheet = (NDrawingView1.Document.StyleSheets.GetChildByName(NDR.NameConnectorsStyleSheet, -1) as NStyleSheet);

			NTextStyle textStyle = new NTextStyle();
			textStyle.BackplaneStyle.Visible = true;
			textStyle.BackplaneStyle.StandardFrameStyle.InnerBorderWidth = new NLength(0);
			styleSheet.Style.TextStyle = textStyle;

			styleSheet.Style.StrokeStyle = new NStrokeStyle(1, Color.Black);
			styleSheet.Style.StartArrowheadStyle.StrokeStyle = new NStrokeStyle(1, Color.Black);
			styleSheet.Style.EndArrowheadStyle.StrokeStyle = new NStrokeStyle(1, Color.Black);

			// create the begin shape 
			NShape begin = factory.CreateShape((int)FlowChartingShapes.Termination);
			begin.Bounds = new NRectangleF(300, 300, 300, 300);
			begin.Text = "BEGIN";
			NDrawingView1.Document.ActiveLayer.AddChild(begin);

			// create the step1 shape
			NShape step1 = factory.CreateShape((int)FlowChartingShapes.Process);
			step1.Bounds = new NRectangleF(300, 1200, 300, 300);
			step1.Text = "STEP1";
			NDrawingView1.Document.ActiveLayer.AddChild(step1);

			// connect begin and step1 with bezier link
			NBezierCurveShape bezier = new NBezierCurveShape();
			bezier.StyleSheetName = NDR.NameConnectorsStyleSheet;
			bezier.Text = "BEZIER";
			bezier.SetPointAt(1, new NPointF(300, 900));
			bezier.SetPointAt(2, new NPointF(600, 900));
			NDrawingView1.Document.ActiveLayer.AddChild(bezier);
			bezier.FromShape = begin;
			bezier.ToShape = step1;

			// create question1 shape
			NShape question1 = factory.CreateShape((int)FlowChartingShapes.Decision);
			question1.Bounds = new NRectangleF(900, 1200, 300, 300);
			question1.Text = "QUESTION1";
			NDrawingView1.Document.ActiveLayer.AddChild(question1);

			// connect step1 and question1 with line link
			NLineShape line = new NLineShape();
			line.StyleSheetName = NDR.NameConnectorsStyleSheet;
			line.Text = "LINE";
			NDrawingView1.Document.ActiveLayer.AddChild(line);
			line.FromShape = step1;
			line.ToShape = question1;

			// create the step2 shape
			NShape step2 = factory.CreateShape((int)FlowChartingShapes.Process);
			step2.Bounds = new NRectangleF(1500, 300, 300, 300);
			step2.Text = "STEP2";
			NDrawingView1.Document.ActiveLayer.AddChild(step2);

			// connect step2 and question1 with HV link
			NStep2Connector hv1 = new NStep2Connector(false);
			hv1.StyleSheetName = NDR.NameConnectorsStyleSheet;
			hv1.Text = "HV1";
			NDrawingView1.Document.ActiveLayer.AddChild(hv1);
			hv1.FromShape = step2;
			hv1.ToShape = question1;

			// connect question1 and step2 and with HV link
			NStep2Connector hv2 = new NStep2Connector(false);
			hv2.StyleSheetName = NDR.NameConnectorsStyleSheet;
			hv2.Text = "HV2";
			NDrawingView1.Document.ActiveLayer.AddChild(hv2);
			hv2.FromShape = question1;
			hv2.ToShape = step2;

			// create a self loof as bezier on step2
			NBezierCurveShape selfLoop = new NBezierCurveShape();
			selfLoop.StyleSheetName = NDR.NameConnectorsStyleSheet;
			selfLoop.Text = "SELF LOOP";
			NDrawingView1.Document.ActiveLayer.AddChild(selfLoop);
			selfLoop.FromShape = step2;
			selfLoop.ToShape = step2;
			selfLoop.Reflex();

			// create step3 shape
			NShape step3 = factory.CreateShape((int)FlowChartingShapes.Process);
			step3.Bounds = new NRectangleF(2100, 1800, 300, 300);
			step3.Text = "STEP3";
			NDrawingView1.Document.ActiveLayer.AddChild(step3);

			// connect question1 and step3 with an HVH link
			NStep3Connector hvh1 = new NStep3Connector(false, 50, 0, true);
			hvh1.StyleSheetName = NDR.NameConnectorsStyleSheet;
			hvh1.Text = "HVH1";
			NDrawingView1.Document.ActiveLayer.AddChild(hvh1);
			hvh1.FromShape = question1;
			hvh1.ToShape = step3;

			// create end shape
			NShape end = factory.CreateShape((int)FlowChartingShapes.Termination);
			end.Bounds = new NRectangleF(900, 2100, 300, 300);
			end.Text = "END";
			NDrawingView1.Document.ActiveLayer.AddChild(end);

			// connect step3 and end with VH link
			NStep2Connector vh1 = new NStep2Connector(true);
			vh1.StyleSheetName = NDR.NameConnectorsStyleSheet;
			vh1.Text = "VH1";
			NDrawingView1.Document.ActiveLayer.AddChild(vh1);
			vh1.FromShape = step3;
			vh1.ToShape = end;

			// connect question1 and end with curve link (uses explicit ports)
			NRoutableConnector curve = new NRoutableConnector(RoutableConnectorType.DynamicCurve);
			curve.StyleSheetName = NDR.NameConnectorsStyleSheet;
			curve.Text = "CURVE";
			NDrawingView1.Document.ActiveLayer.AddChild(curve);
			curve.StartPlug.Connect(question1.Ports.GetChildAt(3) as NPort);
			curve.EndPlug.Connect(end.Ports.GetChildAt(1) as NPort);
			curve.InsertPoint(1, new NPointF(1500, 1800));

			// set a shadow to the document. Since styles are inheritable all objects will reuse this shadow
			NDrawingView1.Document.Style.ShadowStyle = new NShadowStyle(
				ShadowType.GaussianBlur,
				Color.Gray,
				new NPointL(5, 5),
				1,
				new NLength(3));

			// shadows must be displayed behind document content
			NDrawingView1.Document.ShadowsZOrder = ShadowsZOrder.BehindDocument;
		}
	}
}
