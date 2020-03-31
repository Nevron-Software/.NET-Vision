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
using Nevron.Diagram;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.WebForm;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///		Summary description for NAccountingProcessFlowChartUC.
	/// </summary>
	public partial class NAccountingProcessFlowChartUC : NDiagramExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			base.DefaultGridOrigin = new NPointF(30, 30);
			base.DefaultGridCellSize = new NSizeF(100, 50);
			base.DefaultGridSpacing = new NSizeF(50, 40);

			// begin view init
			NDrawingView1.ViewLayout = CanvasLayout.Normal;
			NDrawingView1.ScaleX = 0.8f;
			NDrawingView1.ScaleY = 0.8f;

			// init document
			NDrawingView1.Document.BeginInit();
			InitDocument();
			NDrawingView1.Document.EndInit();
            
            NDrawingView1.SizeToContent(NSizeF.Empty, new Nevron.Diagram.NMargins(0));
		}

		#region Implementation

		private void InitDocument()
		{
            // get the drawing view document
            NDrawingDocument document = NDrawingView1.Document;

			document.GraphicsSettings.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
			document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			document.GraphicsSettings.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            document.Style.FillStyle = new NColorFillStyle(Color.Linen);
			//document.BackgroundStyle.FrameStyle.Visible = false;

			// modify the connectors style sheet
			NStyleSheet styleSheet = (document.StyleSheets.GetChildByName(NDR.NameConnectorsStyleSheet, -1) as NStyleSheet); 

			NTextStyle textStyle = new NTextStyle();
			textStyle.BackplaneStyle.Visible = true;
			textStyle.BackplaneStyle.StandardFrameStyle.InnerBorderWidth = new NLength(0); 
			styleSheet.Style.TextStyle = textStyle;

			styleSheet.Style.StrokeStyle = new NStrokeStyle(1, Color.Black);
			styleSheet.Style.StartArrowheadStyle.StrokeStyle = new NStrokeStyle(1, Color.Black);
			styleSheet.Style.EndArrowheadStyle.StrokeStyle = new NStrokeStyle(1, Color.Black);

			// create a stylesheet for the CPA shapes
			styleSheet = new NStyleSheet("CPA");
			styleSheet.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(102, 204, 255), Color.FromArgb(0, 128, 128));
			document.StyleSheets.AddChild(styleSheet);

			// create a stylesheet for the CLIENT shapes
			styleSheet = new NStyleSheet("CLIENT");
			styleSheet.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(255, 102, 0), Color.FromArgb(255, 204, 0));
			document.StyleSheets.AddChild(styleSheet);

			// create a stylesheet for the stripes
			styleSheet = new NStyleSheet("STRIPE");
			styleSheet.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.FromArgb(221, 221, 221));  
			styleSheet.Style.StrokeStyle = new NStrokeStyle(0, Color.White);
			document.StyleSheets.AddChild(styleSheet);

			// create a stylesheet for the ABC texts
			styleSheet = new NStyleSheet("ABC");
			styleSheet.Style.TextStyle = new NTextStyle(new Font("Ariel", 12), Color.FromArgb(150, 150, 150));
			document.StyleSheets.AddChild(styleSheet);
		
			float abcWidth = 150;

			// configure the document
			base.DefaultGridCellSize = new NSizeF(100, 70);
			base.DefaultGridSpacing = new NSizeF(30, 30); 
			base.DefaultGridOrigin = new NPointF(60, 30);

			document.Bounds = new NRectangleF(0, 0, 1000, (6 * base.DefaultGridCellSize.Height) + (7 * base.DefaultGridSpacing.Height));
			document.ShadowsZOrder = ShadowsZOrder.BehindLayer; 

			// create the stripes
			NRectanglePath rect = new NRectanglePath(0, 0, document.Width, document.Height / 3);
			rect.StyleSheetName = "STRIPE";
			document.ActiveLayer.AddChild(rect);

			rect = new NRectanglePath(0, document.Height / 3, document.Width, document.Height / 3);
			rect.StyleSheetName = "STRIPE";
			document.ActiveLayer.AddChild(rect);

			rect = new NRectanglePath(0, 2 * document.Height / 3, document.Width, document.Height / 3);
			rect.StyleSheetName = "STRIPE";
			document.ActiveLayer.AddChild(rect);

			// create A,B,C texts
			NTextPrimitive text = new NTextPrimitive("A", document.Width - abcWidth, 0, abcWidth, document.Height / 3);
			text.Mode = BoxTextMode.Stretch;
			rect.StyleSheetName = "ABC";
			document.ActiveLayer.AddChild(text);

			text = new NTextPrimitive("B", document.Width - abcWidth, document.Height / 3, abcWidth, document.Height / 3);
			text.Mode = BoxTextMode.Stretch;
			rect.StyleSheetName = "ABC";
			document.ActiveLayer.AddChild(text);

			text = new NTextPrimitive("C", document.Width - abcWidth, 2 * document.Height / 3, abcWidth, document.Height / 3);
			text.Mode = BoxTextMode.Stretch;
			rect.StyleSheetName = "ABC";
			document.ActiveLayer.AddChild(text);

			// add stripe texts
			text = new NTextPrimitive("Sing up client", document.Width - abcWidth, document.Height / 3 - 50, abcWidth, 50);
			document.ActiveLayer.AddChild(text);

			text = new NTextPrimitive("Monthly Accounting Services", document.Width - abcWidth, 2 * document.Height / 3 - 50, abcWidth, 50);
			document.ActiveLayer.AddChild(text);

			text = new NTextPrimitive("Additional Services", document.Width - abcWidth, 3 * document.Height / 3 - 50, abcWidth, 50);
			document.ActiveLayer.AddChild(text);

			// create a layer for the foreground shapes
			NLayer layer = new NLayer();
			document.Layers.AddChild(layer); 
			document.ActiveLayerUniqueId = layer.UniqueId;

			// all shapes in the foreground layer have a shadow
			layer.Style.ShadowStyle = new NShadowStyle(ShadowType.GaussianBlur, Color.Gray, new NPointL(5, 5), 1, new NLength(10));

			// shapes in row 1
			NShape newClient = base.CreateFlowChartingShape(document, FlowChartingShapes.Decision, base.GetGridCell(0, 0), "New Client", "CPA");
			NShape register = base.CreateFlowChartingShape(document, FlowChartingShapes.Process, base.GetGridCell(0, 1), "Register", "CPA");
			NShape clientAccountInfo = base.CreateFlowChartingShape(document, FlowChartingShapes.Data, base.GetGridCell(0, 2), "Client account info", "CPA");
			NShape explainDataEntryProcedures = base.CreateFlowChartingShape(document, FlowChartingShapes.Process, base.GetGridCell(0, 3), "Explain data entry procedures", "CPA");

			// shapes in row 2
			NShape dataEntry = base.CreateFlowChartingShape(document, FlowChartingShapes.ManualInput, base.GetGridCell(2, 0), "Data Entry", "CLIENT");
			NShape emailCompleted = base.CreateFlowChartingShape(document, FlowChartingShapes.Document, base.GetGridCell(2, 1), "E-mail Completed", "CLIENT");
			NShape review = base.CreateFlowChartingShape(document, FlowChartingShapes.Process, base.GetGridCell(2, 2), "Review", "CPA");
			NShape needsRevising = base.CreateFlowChartingShape(document, FlowChartingShapes.Decision, base.GetGridCell(2, 3), "Needs revising", "CPA");
			NShape emailRevisions = base.CreateFlowChartingShape(document, FlowChartingShapes.Process, base.GetGridCell(2, 4), "E-mail revisions", "CPA");
			NShape evaluateRevisions = base.CreateFlowChartingShape(document, FlowChartingShapes.Process, base.GetGridCell(2, 5), "Evaluate revisions", "CLIENT"); 

			// shapes in row 3
			NShape emailApprovedRevisions = base.CreateFlowChartingShape(document, FlowChartingShapes.Document, base.GetGridCell(3, 2), "E-mail Approved Revisions", "CLIENT");
			NShape evaluateRevisions2 = base.CreateFlowChartingShape(document, FlowChartingShapes.Process, base.GetGridCell(3, 4), "Evaluate Revisions", "CLIENT");
			NShape answerClientEmail = base.CreateFlowChartingShape(document, FlowChartingShapes.Process, base.GetGridCell(3, 5), "Answer Client E-mail", "CPA"); 

			// shapes in row 4
			NShape paywoll = base.CreateFlowChartingShape(document, FlowChartingShapes.Document, base.GetGridCell(5, 2), "Payroll", "CLIENT");
			NShape taxes = base.CreateFlowChartingShape(document, FlowChartingShapes.Process, base.GetGridCell(5, 3), "Taxes", "CLIENT");
			NShape controller = base.CreateFlowChartingShape(document, FlowChartingShapes.Process, base.GetGridCell(5, 4), "Controller", "CPA");

			// some shapes need to have extra ports
			NRotatedBoundsPort port = new NRotatedBoundsPort(evaluateRevisions.UniqueId, new NContentAlignment(-25, 50));
			port.Name = "BottomLeft";
			evaluateRevisions.Ports.AddChild(port);
			
			port = new NRotatedBoundsPort(evaluateRevisions.UniqueId, new NContentAlignment(+25, 50));
			port.Name = "BottomRight";
			evaluateRevisions.Ports.AddChild(port);

			port = new NRotatedBoundsPort(answerClientEmail.UniqueId, new NContentAlignment(-25, -50));
			port.Name = "TopLeft";
			answerClientEmail.Ports.AddChild(port);
			
			port = new NRotatedBoundsPort(answerClientEmail.UniqueId, new NContentAlignment(+25, -50));
			port.Name = "TopRight";
			answerClientEmail.Ports.AddChild(port);

			// connect shapes in levels
			base.CreateConnector(document, newClient, "Center", register, "Center", ConnectorType.Line, "YES");
			base.CreateConnector(document, register, "Center", clientAccountInfo, "Center", ConnectorType.Line, ""); 
			base.CreateConnector(document, clientAccountInfo, "Center", explainDataEntryProcedures, "Center", ConnectorType.Line, ""); 
			base.CreateConnector(document, dataEntry, "Center", emailCompleted, "Center", ConnectorType.Line, ""); 
			base.CreateConnector(document, emailCompleted, "Center", review, "Center", ConnectorType.Line, ""); 
			base.CreateConnector(document, review, "Center", needsRevising, "Center", ConnectorType.Line, ""); 
			base.CreateConnector(document, needsRevising, "Center", emailRevisions, "Center", ConnectorType.Line, "YES");
			base.CreateConnector(document, emailRevisions, "Center", evaluateRevisions, "Center", ConnectorType.Line, "");
			base.CreateConnector(document, evaluateRevisions2, "Center", emailApprovedRevisions, "Center", ConnectorType.Line, ""); 

			// connect accross levels
			NStep3Connector connector = (base.CreateConnector(document, newClient, "Center", dataEntry, "Center", ConnectorType.SideToSide, "NO") as NStep3Connector);  
			connector.UseMiddleControlPointPercent = false;
			connector.MiddleControlPointOffset = -55;

			base.CreateConnector(document, explainDataEntryProcedures, "Center", dataEntry , "Center", ConnectorType.TopToBottom, "");
			base.CreateConnector(document, emailApprovedRevisions, "Center", review, "Center", ConnectorType.Line, ""); 
			base.CreateConnector(document, emailRevisions, "Center", evaluateRevisions2, "Center", ConnectorType.Line, ""); 
			base.CreateConnector(document, evaluateRevisions, "BottomLeft", answerClientEmail, "TopLeft", ConnectorType.Line, ""); 
			base.CreateConnector(document, answerClientEmail, "TopRight", evaluateRevisions, "BottomRight", ConnectorType.Line, ""); 

			connector = (base.CreateConnector(document, needsRevising, "Center", paywoll, "Center", ConnectorType.TopToBottom, "") as NStep3Connector);  
			connector.MiddleControlPointPercent = 66;

			connector = (base.CreateConnector(document, needsRevising, "Center", taxes, "Center", ConnectorType.TopToBottom, "") as NStep3Connector);  
			connector.MiddleControlPointPercent = 66;

			connector = (base.CreateConnector(document, needsRevising, "Center", controller, "Center", ConnectorType.TopToBottom, "") as NStep3Connector);  
			connector.MiddleControlPointPercent = 66;

			// create the legend as a group
			NGroup legend = new NGroup();
						
			NRectangleShape legendBackground = new NRectangleShape(0, 0, 1, 3);
			legendBackground.Style.FillStyle = new NColorFillStyle(Color.White);
			legend.Shapes.AddChild(legendBackground);

			NRectangleF bounds = new NRectangleF(0, 1, 1, 1);
			bounds.Inflate(-0.2f, -0.2f); 

			NRectangleShape cpaItem = new NRectangleShape(bounds);
			cpaItem.Text = "CPA";
			cpaItem.StyleSheetName = "CPA";
			legend.Shapes.AddChild(cpaItem);

			bounds = new NRectangleF(0, 2, 1, 1);
			bounds.Inflate(-0.2f, -0.2f);

			NRectangleShape clientItem = new NRectangleShape(bounds);
			clientItem.Text = "Client";
			clientItem.StyleSheetName = "CLIENT";
			legend.Shapes.AddChild(clientItem);

			legend.UpdateModelBounds();
			legend.Bounds = base.GetGridCell(4, 0, 1, 1);

			document.ActiveLayer.AddChild(legend);
            document.SizeToContent();
		}

		#endregion
	}
}
