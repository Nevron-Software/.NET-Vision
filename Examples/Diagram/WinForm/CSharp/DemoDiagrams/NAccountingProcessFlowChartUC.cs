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
	/// Summary description for NAccountingProcessFlowChartUC.
	/// </summary>
	public class NAccountingProcessFlowChartUC : NDiagramExampleUC
	{
		#region Constructor

		public NAccountingProcessFlowChartUC(NMainForm form) : base(form)
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
			// NAccountingProcessFlowChartUC
			// 
			this.Name = "NAccountingProcessFlowChartUC";
			this.Size = new System.Drawing.Size(248, 384);
			this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			base.DefaultGridOrigin = new NPointF(30, 30);
			base.DefaultGridCellSize = new NSizeF(100, 50);
			base.DefaultGridSpacing = new NSizeF(50, 40);

			// begin view init
			view.BeginInit();
			
			view.GlobalVisibility.ShowPorts = false;
			view.Grid.Visible = false;
            view.HorizontalRuler.Visible = false;
            view.VerticalRuler.Visible = false;
            view.ViewLayout = ViewLayout.Fit; 
			view.DocumentPadding = new Nevron.Diagram.NMargins(10);
			view.DocumentShadow = new NShadowStyle(Color.Gray);
			view.DocumentShadow.Offset = new NPointL(3, 3);

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
			// modify the connectors style sheet
			NStyleSheet styleSheet = (document.StyleSheets.GetChildByName(NDR.NameConnectorsStyleSheet, -1) as NStyleSheet); 

			styleSheet.Style.StrokeStyle = new NStrokeStyle(1, Color.Black);
            styleSheet.Style.StartArrowheadStyle.Shape = ArrowheadShape.None;
			styleSheet.Style.EndArrowheadStyle.StrokeStyle = new NStrokeStyle(1, Color.Black);

			// create a stylesheet for the CPA shapes
			styleSheet = new NStyleSheet("CPA");
			styleSheet.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(68, 90, 108), Color.FromArgb(162, 173, 182));
			document.StyleSheets.AddChild(styleSheet);

			// create a stylesheet for the CLIENT shapes
			styleSheet = new NStyleSheet("CLIENT");
            styleSheet.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(247, 150, 56), Color.FromArgb(251, 203, 156));  
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
			layer.Style.ShadowStyle = new NShadowStyle(
				ShadowType.GaussianBlur, 
				Color.Gray, 
				new NPointL(5, 5), 
				1, 
				new NLength(10));

			// shapes in row 1
			NShape newClient = base.CreateFlowChartingShape(FlowChartingShapes.Decision, base.GetGridCell(0, 0), "New Client", "CPA"); 
			NShape register = base.CreateFlowChartingShape(FlowChartingShapes.Process, base.GetGridCell(0, 1), "Register", "CPA"); 
			NShape clientAccountInfo = base.CreateFlowChartingShape(FlowChartingShapes.Data, base.GetGridCell(0, 2), "Client account info", "CPA"); 
			NShape explainDataEntryProcedures = base.CreateFlowChartingShape(FlowChartingShapes.Process, base.GetGridCell(0, 3), "Explain data entry procedures", "CPA");

			// shapes in row 2
			NShape dataEntry = base.CreateFlowChartingShape(FlowChartingShapes.ManualInput, base.GetGridCell(2, 0), "Data Entry", "CLIENT"); 
			NShape emailCompleted = base.CreateFlowChartingShape(FlowChartingShapes.Document, base.GetGridCell(2, 1), "E-mail Completed", "CLIENT"); 
			NShape review = base.CreateFlowChartingShape(FlowChartingShapes.Process, base.GetGridCell(2, 2), "Review", "CPA"); 
			NShape needsRevising = base.CreateFlowChartingShape(FlowChartingShapes.Decision, base.GetGridCell(2, 3), "Needs revising", "CPA"); 
			NShape emailRevisions = base.CreateFlowChartingShape(FlowChartingShapes.Process, base.GetGridCell(2, 4), "E-mail revisions", "CPA"); 
			NShape evaluateRevisions = base.CreateFlowChartingShape(FlowChartingShapes.Process, base.GetGridCell(2, 5), "Evaluate revisions", "CLIENT"); 

			// shapes in row 3
			NShape emailApprovedRevisions = base.CreateFlowChartingShape(FlowChartingShapes.Document, base.GetGridCell(3, 2), "E-mail Approved Revisions", "CLIENT"); 
			NShape evaluateRevisions2 = base.CreateFlowChartingShape(FlowChartingShapes.Process, base.GetGridCell(3, 4), "Evaluate Revisions", "CLIENT"); 
			NShape answerClientEmail = base.CreateFlowChartingShape(FlowChartingShapes.Process, base.GetGridCell(3, 5), "Answer Client E-mail", "CPA"); 

			// shapes in row 4
			NShape paywoll = base.CreateFlowChartingShape(FlowChartingShapes.Document, base.GetGridCell(5, 2), "Payroll", "CLIENT"); 
			NShape taxes = base.CreateFlowChartingShape(FlowChartingShapes.Process, base.GetGridCell(5, 3), "Taxes", "CLIENT"); 
			NShape controller = base.CreateFlowChartingShape(FlowChartingShapes.Process, base.GetGridCell(5, 4), "Controller", "CPA");

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
			base.CreateConnector(newClient, "Center", register, "Center", ConnectorType.Line, "YES");
			base.CreateConnector(register, "Center", clientAccountInfo, "Center", ConnectorType.Line, ""); 
			base.CreateConnector(clientAccountInfo, "Center", explainDataEntryProcedures, "Center", ConnectorType.Line, ""); 

			base.CreateConnector(dataEntry, "Center", emailCompleted, "Center", ConnectorType.Line, ""); 
			base.CreateConnector(emailCompleted, "Center", review, "Center", ConnectorType.Line, ""); 
			base.CreateConnector(review, "Center", needsRevising, "Center", ConnectorType.Line, ""); 
			base.CreateConnector(needsRevising, "Center", emailRevisions, "Center", ConnectorType.Line, "YES");
			base.CreateConnector(emailRevisions, "Center", evaluateRevisions, "Center", ConnectorType.Line, "");

			base.CreateConnector(evaluateRevisions2, "Center", emailApprovedRevisions, "Center", ConnectorType.Line, ""); 

			// connect accross levels
			NStep3Connector connector = (base.CreateConnector(newClient, "Center", dataEntry, "Center", ConnectorType.SideToSide, "NO") as NStep3Connector);  
			connector.UseMiddleControlPointPercent = false;
			connector.MiddleControlPointOffset = -55;

			base.CreateConnector(explainDataEntryProcedures, "Center", dataEntry , "Center", ConnectorType.TopToBottom, "");

			base.CreateConnector(emailApprovedRevisions, "Center", review, "Center", ConnectorType.Line, ""); 
			base.CreateConnector(emailRevisions, "Center", evaluateRevisions2, "Center", ConnectorType.Line, ""); 
			base.CreateConnector(evaluateRevisions, "BottomLeft", answerClientEmail, "TopLeft", ConnectorType.Line, ""); 
			base.CreateConnector(answerClientEmail, "TopRight", evaluateRevisions, "BottomRight", ConnectorType.Line, ""); 

			connector = (base.CreateConnector(needsRevising, "Center", paywoll, "Center", ConnectorType.TopToBottom, "") as NStep3Connector);  
			connector.MiddleControlPointPercent = 66;

			connector = (base.CreateConnector(needsRevising, "Center", taxes, "Center", ConnectorType.TopToBottom, "") as NStep3Connector);  
			connector.MiddleControlPointPercent = 66;

			connector = (base.CreateConnector(needsRevising, "Center", controller, "Center", ConnectorType.TopToBottom, "") as NStep3Connector);  
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
		}

		#endregion

		#region Designer Fields
		
		private System.ComponentModel.Container components = null;

		#endregion
	}
}