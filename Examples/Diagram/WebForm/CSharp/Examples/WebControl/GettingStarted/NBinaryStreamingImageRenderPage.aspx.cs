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
	/// Summary description for NBinaryStreamingImageRenderPage.
	/// </summary>
	public partial class NBinaryStreamingImageRenderPage : NDrawingViewHostPage
	{
		public NBinaryStreamingImageRenderPage()
		{
			this.DrawingView = new NDrawingView();
			this.DrawingView.ViewLayout = CanvasLayout.Stretch;

			NDrawingDocument document = this.DrawingView.Document;

			// init document
			document.BeginInit();
			CreateScene(document);
			document.EndInit();

			this.DrawingView.SizeToContent();
		}

		private void CreateScene(NDrawingDocument document)
		{
			document.BackgroundStyle.FrameStyle.Visible = false;

			NFillStyle cpaFillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(102, 204, 255), Color.FromArgb(0, 128, 128));  
			NFillStyle clientFillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(255, 102, 0), Color.FromArgb(255, 204, 0));  
			NFillStyle stripeFillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.FromArgb(221, 221, 221));  
			NTextStyle abcTextStyle = new NTextStyle(new Font("Arial", 12), Color.FromArgb(150, 150, 150));
			float abcWidth = 150;

			NDrawingDocumentHelper helper = new NDrawingDocumentHelper(document);

			// configure the document
			helper.DefaultGridCellSize = new NSizeF(100, 70);
			helper.DefaultGridSpacing = new NSizeF(30, 30); 
			helper.DefaultGridOrigin = new NPointF(60, 30);
		
			document.Bounds = new NRectangleF(0, 0, 1000, (6 * helper.DefaultGridCellSize.Height) + (7 * helper.DefaultGridSpacing.Height));
			document.ShadowsZOrder = ShadowsZOrder.BehindLayer; 

			// create the stripes
			NRectangleShape rect = new NRectangleShape(0, 0, document.Width, document.Height / 3);
			rect.Style.FillStyle = (NFillStyle)stripeFillStyle.Clone(); 
			rect.Style.StrokeStyle = new NStrokeStyle(0, Color.White);
			document.ActiveLayer.AddChild(rect);

			rect = new NRectangleShape(0, document.Height / 3, document.Width, document.Height / 3);
			rect.Style.FillStyle  = (NFillStyle)stripeFillStyle.Clone(); 
			rect.Style.StrokeStyle = new NStrokeStyle(0, Color.White);
			document.ActiveLayer.AddChild(rect);

			rect = new NRectangleShape(0, 2 * document.Height / 3, document.Width, document.Height / 3);
			rect.Style.FillStyle  = (NFillStyle)stripeFillStyle.Clone(); 
			rect.Style.StrokeStyle = new NStrokeStyle(0, Color.White);
			document.ActiveLayer.AddChild(rect);

			// create A,B,C texts
			NTextShape text = new NTextShape("A", document.Width - abcWidth, 0, abcWidth, document.Height / 3);
			text.Mode = BoxTextMode.Stretch;
			text.Style.TextStyle = (abcTextStyle.Clone() as NTextStyle); 
			document.ActiveLayer.AddChild(text);

			text = new NTextShape("B", document.Width - abcWidth, document.Height / 3, abcWidth, document.Height / 3);
			text.Mode = BoxTextMode.Stretch;
			text.Style.TextStyle = (abcTextStyle.Clone() as NTextStyle); 
			document.ActiveLayer.AddChild(text);

			text = new NTextShape("C", document.Width - abcWidth, 2 * document.Height / 3, abcWidth, document.Height / 3);
			text.Mode = BoxTextMode.Stretch;
			text.Style.TextStyle = (abcTextStyle.Clone() as NTextStyle); 
			document.ActiveLayer.AddChild(text);

			// add stripe texts
			text = new NTextShape("Sing up client", document.Width - abcWidth, document.Height / 3 - 50, abcWidth, 50);
			document.ActiveLayer.AddChild(text);

			text = new NTextShape("Monthly Accounting Services", document.Width - abcWidth, 2 * document.Height / 3 - 50, abcWidth, 50);
			document.ActiveLayer.AddChild(text);

			text = new NTextShape("Additional Services", document.Width - abcWidth, 3 * document.Height / 3 - 50, abcWidth, 50);
			document.ActiveLayer.AddChild(text);

			// create a layer for the forground shapes
			NLayer layer = new NLayer();
			document.Layers.AddChild(layer); 
			document.ActiveLayerUniqueId = layer.UniqueId;
			layer.Style.ShadowStyle = new NShadowStyle(ShadowType.GaussianBlur, 
				Color.Gray, 
				new Nevron.GraphicsCore.NPointL(5, 5), 
				1,
				new NLength(10));

			// shapes in row 1
			NShape newClient = helper.CreateBasicShape(BasicShapes.Diamond, helper.GetGridCell(0, 0), "New Client", cpaFillStyle); 
			NShape register = helper.CreateBasicShape(BasicShapes.Rectangle, helper.GetGridCell(0, 1), "Register", cpaFillStyle); 
			NShape clientAccountInfo = helper.CreateFlowChartingShape(FlowChartingShapes.Data, helper.GetGridCell(0, 2), "Client account info", cpaFillStyle); 
			NShape explainDataEntryProcedures = helper.CreateBasicShape(BasicShapes.Rectangle, helper.GetGridCell(0, 3), "Explain data entry procedures", cpaFillStyle);

			// shapes in row 2
			NShape dataEntry = helper.CreateFlowChartingShape(FlowChartingShapes.ManualInput, helper.GetGridCell(2, 0), "Data Entry", clientFillStyle); 
			NShape emailCompleted = helper.CreateFlowChartingShape(FlowChartingShapes.Document, helper.GetGridCell(2, 1), "E-mail Completed", clientFillStyle); 
			NShape review = helper.CreateBasicShape(BasicShapes.Rectangle, helper.GetGridCell(2, 2), "Review", cpaFillStyle); 
			NShape needsRevising = helper.CreateBasicShape(BasicShapes.Diamond, helper.GetGridCell(2, 3), "Needs revising", cpaFillStyle); 
			NShape emailRevisions = helper.CreateBasicShape(BasicShapes.Rectangle, helper.GetGridCell(2, 4), "E-mail revisions", cpaFillStyle); 
			NShape evaluateRevisions = helper.CreateBasicShape(BasicShapes.Rectangle, helper.GetGridCell(2, 5), "Evaluate revisions", clientFillStyle); 

			// shapes in row 3
			NShape emailApprovedRevisions = helper.CreateFlowChartingShape(FlowChartingShapes.Document, helper.GetGridCell(3, 2), "E-mail Approved Revisions", clientFillStyle); 
			NShape evaluateRevisions2 = helper.CreateBasicShape(BasicShapes.Rectangle, helper.GetGridCell(3, 4), "Evaluate Revisions", clientFillStyle); 
			NShape answerClientEmail = helper.CreateBasicShape(BasicShapes.Rectangle, helper.GetGridCell(3, 5), "Answer Client E-mail", cpaFillStyle); 

			// shapes in row 4
			NShape paywoll = helper.CreateFlowChartingShape(FlowChartingShapes.Document, helper.GetGridCell(5, 2), "Payroll", clientFillStyle); 
			NShape taxes = helper.CreateBasicShape(BasicShapes.Rectangle, helper.GetGridCell(5, 3), "Taxes", clientFillStyle); 
			NShape controller = helper.CreateBasicShape(BasicShapes.Rectangle, helper.GetGridCell(5, 4), "Controller", cpaFillStyle);

			// create the optional ports of the shape
			evaluateRevisions.CreateShapeElements(ShapeElementsMask.Ports);

			// some shapes need to have extra ports
			NRotatedBoundsPort port = new NRotatedBoundsPort(evaluateRevisions.UniqueId, new NContentAlignment(-25, 50));
			port.Name = "BottomLeft";
			evaluateRevisions.Ports.AddChild(port);
		
			port = new NRotatedBoundsPort(evaluateRevisions.UniqueId, new NContentAlignment(+25, 50));
			port.Name = "BottomRight";
			evaluateRevisions.Ports.AddChild(port);

			// create the optional ports of the shape
			answerClientEmail.CreateShapeElements(ShapeElementsMask.Ports);

			port = new NRotatedBoundsPort(answerClientEmail.UniqueId, new NContentAlignment(-25, -50));
			port.Name = "TopLeft";
			answerClientEmail.Ports.AddChild(port);
		
			port = new NRotatedBoundsPort(answerClientEmail.UniqueId, new NContentAlignment(+25, -50));
			port.Name = "TopRight";
			answerClientEmail.Ports.AddChild(port);

			// connect shapes in levels
			helper.CreateConnector(newClient, "Center", register, "Center", ConnectorType.Line, "YES");
			helper.CreateConnector(register, "Center", clientAccountInfo, "Center", ConnectorType.Line, ""); 
			helper.CreateConnector(clientAccountInfo, "Center", explainDataEntryProcedures, "Center", ConnectorType.Line, ""); 

			helper.CreateConnector(dataEntry, "Center", emailCompleted, "Center", ConnectorType.Line, ""); 
			helper.CreateConnector(emailCompleted, "Center", review, "Center", ConnectorType.Line, ""); 
			helper.CreateConnector(review, "Center", needsRevising, "Center", ConnectorType.Line, ""); 
			helper.CreateConnector(needsRevising, "Center", emailRevisions, "Center", ConnectorType.Line, "YES");
			helper.CreateConnector(emailRevisions, "Center", evaluateRevisions, "Center", ConnectorType.Line, "");

			helper.CreateConnector(evaluateRevisions2, "Center", emailApprovedRevisions, "Center", ConnectorType.Line, ""); 

			// connect accross levels
			NStep3Connector connector = (helper.CreateConnector(newClient, "Center", dataEntry, "Center", ConnectorType.SideToSide, "NO") as NStep3Connector);  
			connector.UseMiddleControlPointPercent = false;
			connector.MiddleControlPointOffset = -50;

			helper.CreateConnector(explainDataEntryProcedures, "Center", dataEntry , "Center", ConnectorType.TopToBottom, ""); 
		
			helper.CreateConnector(emailApprovedRevisions, "Center", review, "Center", ConnectorType.Line, ""); 
			helper.CreateConnector(emailRevisions, "Center", evaluateRevisions2, "Center", ConnectorType.Line, ""); 
			helper.CreateConnector(evaluateRevisions, "BottomLeft", answerClientEmail, "TopLeft", ConnectorType.Line, ""); 
			helper.CreateConnector(answerClientEmail, "TopRight", evaluateRevisions, "BottomRight", ConnectorType.Line, ""); 

			connector = (helper.CreateConnector(needsRevising, "Center", paywoll, "Center", ConnectorType.TopToBottom, "") as NStep3Connector);  
			connector.MiddleControlPointPercent = 66;
			connector = (helper.CreateConnector(needsRevising, "Center", taxes, "Center", ConnectorType.TopToBottom, "") as NStep3Connector);  
			connector.MiddleControlPointPercent = 66;
			connector = (helper.CreateConnector(needsRevising, "Center", controller, "Center", ConnectorType.TopToBottom, "") as NStep3Connector);  
			connector.MiddleControlPointPercent = 66;

			// create the legend
			NGroup legend = new NGroup();
					
			NRectangleShape ledendBackground = new NRectangleShape(0, 0, 1, 3);
			ledendBackground.Style.FillStyle = new NColorFillStyle(Color.White);
			legend.Shapes.AddChild(ledendBackground);

			NTextShape legendTitle = new NTextShape("Legend", 0, 0, 1, 1);
			legend.Shapes.AddChild(legendTitle);

			NRectangleF bounds = new NRectangleF(0, 1, 1, 1);
			bounds.Inflate(-0.2f, -0.2f); 

			NShape shape = helper.CreateBasicShape(BasicShapes.Rectangle, bounds, "CPA", (NFillStyle)cpaFillStyle.Clone(), false);
			legend.Shapes.AddChild(shape);

			bounds = new NRectangleF(0, 2, 1, 1);
			bounds.Inflate(-0.2f, -0.2f);

			shape = helper.CreateBasicShape(BasicShapes.Rectangle, bounds, "Client", (NFillStyle)clientFillStyle.Clone(), false);
			legend.Shapes.AddChild(shape);

			legend.UpdateModelBounds();
			legend.Bounds = helper.GetGridCell(4, 0, 1, 1);

			document.ActiveLayer.AddChild(legend);
		}
	}
}
