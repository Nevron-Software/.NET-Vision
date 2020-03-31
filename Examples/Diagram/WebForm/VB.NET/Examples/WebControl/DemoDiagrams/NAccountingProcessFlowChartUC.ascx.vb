Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports Nevron.GraphicsCore
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.WebForm

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''		Summary description for NAccountingProcessFlowChartUC.
	''' </summary>
	Public Partial Class NAccountingProcessFlowChartUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			MyBase.DefaultGridOrigin = New NPointF(30, 30)
			MyBase.DefaultGridCellSize = New NSizeF(100, 50)
			MyBase.DefaultGridSpacing = New NSizeF(50, 40)

			' begin view init
			NDrawingView1.ViewLayout = CanvasLayout.Normal
			NDrawingView1.ScaleX = 0.8f
			NDrawingView1.ScaleY = 0.8f

			' init document
			NDrawingView1.Document.BeginInit()
			InitDocument()
			NDrawingView1.Document.EndInit()

			NDrawingView1.SizeToContent(NSizeF.Empty, New Nevron.Diagram.NMargins(0))
		End Sub

		#Region "Implementation"

		Private Sub InitDocument()
			' get the drawing view document
			Dim document As NDrawingDocument = NDrawingView1.Document

			document.GraphicsSettings.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit
			document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
			document.GraphicsSettings.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality

			document.Style.FillStyle = New NColorFillStyle(Color.Linen)
			'document.BackgroundStyle.FrameStyle.Visible = false;

			' modify the connectors style sheet
			Dim styleSheet As NStyleSheet = (TryCast(document.StyleSheets.GetChildByName(NDR.NameConnectorsStyleSheet, -1), NStyleSheet))

			Dim textStyle As NTextStyle = New NTextStyle()
			textStyle.BackplaneStyle.Visible = True
			textStyle.BackplaneStyle.StandardFrameStyle.InnerBorderWidth = New NLength(0)
			styleSheet.Style.TextStyle = textStyle

			styleSheet.Style.StrokeStyle = New NStrokeStyle(1, Color.Black)
			styleSheet.Style.StartArrowheadStyle.StrokeStyle = New NStrokeStyle(1, Color.Black)
			styleSheet.Style.EndArrowheadStyle.StrokeStyle = New NStrokeStyle(1, Color.Black)

			' create a stylesheet for the CPA shapes
			styleSheet = New NStyleSheet("CPA")
			styleSheet.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(102, 204, 255), Color.FromArgb(0, 128, 128))
			document.StyleSheets.AddChild(styleSheet)

			' create a stylesheet for the CLIENT shapes
			styleSheet = New NStyleSheet("CLIENT")
			styleSheet.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(255, 102, 0), Color.FromArgb(255, 204, 0))
			document.StyleSheets.AddChild(styleSheet)

			' create a stylesheet for the stripes
			styleSheet = New NStyleSheet("STRIPE")
			styleSheet.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.FromArgb(221, 221, 221))
			styleSheet.Style.StrokeStyle = New NStrokeStyle(0, Color.White)
			document.StyleSheets.AddChild(styleSheet)

			' create a stylesheet for the ABC texts
			styleSheet = New NStyleSheet("ABC")
			styleSheet.Style.TextStyle = New NTextStyle(New Font("Ariel", 12), Color.FromArgb(150, 150, 150))
			document.StyleSheets.AddChild(styleSheet)

			Dim abcWidth As Single = 150

			' configure the document
			MyBase.DefaultGridCellSize = New NSizeF(100, 70)
			MyBase.DefaultGridSpacing = New NSizeF(30, 30)
			MyBase.DefaultGridOrigin = New NPointF(60, 30)

			document.Bounds = New NRectangleF(0, 0, 1000, (6 * MyBase.DefaultGridCellSize.Height) + (7 * MyBase.DefaultGridSpacing.Height))
			document.ShadowsZOrder = ShadowsZOrder.BehindLayer

			' create the stripes
			Dim rect As NRectanglePath = New NRectanglePath(0, 0, document.Width, document.Height / 3)
			rect.StyleSheetName = "STRIPE"
			document.ActiveLayer.AddChild(rect)

			rect = New NRectanglePath(0, document.Height / 3, document.Width, document.Height / 3)
			rect.StyleSheetName = "STRIPE"
			document.ActiveLayer.AddChild(rect)

			rect = New NRectanglePath(0, 2 * document.Height / 3, document.Width, document.Height / 3)
			rect.StyleSheetName = "STRIPE"
			document.ActiveLayer.AddChild(rect)

			' create A,B,C texts
			Dim text As NTextPrimitive = New NTextPrimitive("A", document.Width - abcWidth, 0, abcWidth, document.Height / 3)
			text.Mode = BoxTextMode.Stretch
			rect.StyleSheetName = "ABC"
			document.ActiveLayer.AddChild(text)

			text = New NTextPrimitive("B", document.Width - abcWidth, document.Height / 3, abcWidth, document.Height / 3)
			text.Mode = BoxTextMode.Stretch
			rect.StyleSheetName = "ABC"
			document.ActiveLayer.AddChild(text)

			text = New NTextPrimitive("C", document.Width - abcWidth, 2 * document.Height / 3, abcWidth, document.Height / 3)
			text.Mode = BoxTextMode.Stretch
			rect.StyleSheetName = "ABC"
			document.ActiveLayer.AddChild(text)

			' add stripe texts
			text = New NTextPrimitive("Sing up client", document.Width - abcWidth, document.Height / 3 - 50, abcWidth, 50)
			document.ActiveLayer.AddChild(text)

			text = New NTextPrimitive("Monthly Accounting Services", document.Width - abcWidth, 2 * document.Height / 3 - 50, abcWidth, 50)
			document.ActiveLayer.AddChild(text)

			text = New NTextPrimitive("Additional Services", document.Width - abcWidth, 3 * document.Height / 3 - 50, abcWidth, 50)
			document.ActiveLayer.AddChild(text)

			' create a layer for the foreground shapes
			Dim layer As NLayer = New NLayer()
			document.Layers.AddChild(layer)
			document.ActiveLayerUniqueId = layer.UniqueId

			' all shapes in the foreground layer have a shadow
			layer.Style.ShadowStyle = New NShadowStyle(ShadowType.GaussianBlur, Color.Gray, New NPointL(5, 5), 1, New NLength(10))

			' shapes in row 1
			Dim newClient As NShape = MyBase.CreateFlowChartingShape(document, FlowChartingShapes.Decision, MyBase.GetGridCell(0, 0), "New Client", "CPA")
			Dim register As NShape = MyBase.CreateFlowChartingShape(document, FlowChartingShapes.Process, MyBase.GetGridCell(0, 1), "Register", "CPA")
			Dim clientAccountInfo As NShape = MyBase.CreateFlowChartingShape(document, FlowChartingShapes.Data, MyBase.GetGridCell(0, 2), "Client account info", "CPA")
			Dim explainDataEntryProcedures As NShape = MyBase.CreateFlowChartingShape(document, FlowChartingShapes.Process, MyBase.GetGridCell(0, 3), "Explain data entry procedures", "CPA")

			' shapes in row 2
			Dim dataEntry As NShape = MyBase.CreateFlowChartingShape(document, FlowChartingShapes.ManualInput, MyBase.GetGridCell(2, 0), "Data Entry", "CLIENT")
			Dim emailCompleted As NShape = MyBase.CreateFlowChartingShape(document, FlowChartingShapes.Document, MyBase.GetGridCell(2, 1), "E-mail Completed", "CLIENT")
			Dim review As NShape = MyBase.CreateFlowChartingShape(document, FlowChartingShapes.Process, MyBase.GetGridCell(2, 2), "Review", "CPA")
			Dim needsRevising As NShape = MyBase.CreateFlowChartingShape(document, FlowChartingShapes.Decision, MyBase.GetGridCell(2, 3), "Needs revising", "CPA")
			Dim emailRevisions As NShape = MyBase.CreateFlowChartingShape(document, FlowChartingShapes.Process, MyBase.GetGridCell(2, 4), "E-mail revisions", "CPA")
			Dim evaluateRevisions As NShape = MyBase.CreateFlowChartingShape(document, FlowChartingShapes.Process, MyBase.GetGridCell(2, 5), "Evaluate revisions", "CLIENT")

			' shapes in row 3
			Dim emailApprovedRevisions As NShape = MyBase.CreateFlowChartingShape(document, FlowChartingShapes.Document, MyBase.GetGridCell(3, 2), "E-mail Approved Revisions", "CLIENT")
			Dim evaluateRevisions2 As NShape = MyBase.CreateFlowChartingShape(document, FlowChartingShapes.Process, MyBase.GetGridCell(3, 4), "Evaluate Revisions", "CLIENT")
			Dim answerClientEmail As NShape = MyBase.CreateFlowChartingShape(document, FlowChartingShapes.Process, MyBase.GetGridCell(3, 5), "Answer Client E-mail", "CPA")

			' shapes in row 4
			Dim paywoll As NShape = MyBase.CreateFlowChartingShape(document, FlowChartingShapes.Document, MyBase.GetGridCell(5, 2), "Payroll", "CLIENT")
			Dim taxes As NShape = MyBase.CreateFlowChartingShape(document, FlowChartingShapes.Process, MyBase.GetGridCell(5, 3), "Taxes", "CLIENT")
			Dim controller As NShape = MyBase.CreateFlowChartingShape(document, FlowChartingShapes.Process, MyBase.GetGridCell(5, 4), "Controller", "CPA")

			' some shapes need to have extra ports
			Dim port As NRotatedBoundsPort = New NRotatedBoundsPort(evaluateRevisions.UniqueId, New NContentAlignment(-25, 50))
			port.Name = "BottomLeft"
			evaluateRevisions.Ports.AddChild(port)

			port = New NRotatedBoundsPort(evaluateRevisions.UniqueId, New NContentAlignment(+25, 50))
			port.Name = "BottomRight"
			evaluateRevisions.Ports.AddChild(port)

			port = New NRotatedBoundsPort(answerClientEmail.UniqueId, New NContentAlignment(-25, -50))
			port.Name = "TopLeft"
			answerClientEmail.Ports.AddChild(port)

			port = New NRotatedBoundsPort(answerClientEmail.UniqueId, New NContentAlignment(+25, -50))
			port.Name = "TopRight"
			answerClientEmail.Ports.AddChild(port)

			' connect shapes in levels
			MyBase.CreateConnector(document, newClient, "Center", register, "Center", ConnectorType.Line, "YES")
			MyBase.CreateConnector(document, register, "Center", clientAccountInfo, "Center", ConnectorType.Line, "")
			MyBase.CreateConnector(document, clientAccountInfo, "Center", explainDataEntryProcedures, "Center", ConnectorType.Line, "")
			MyBase.CreateConnector(document, dataEntry, "Center", emailCompleted, "Center", ConnectorType.Line, "")
			MyBase.CreateConnector(document, emailCompleted, "Center", review, "Center", ConnectorType.Line, "")
			MyBase.CreateConnector(document, review, "Center", needsRevising, "Center", ConnectorType.Line, "")
			MyBase.CreateConnector(document, needsRevising, "Center", emailRevisions, "Center", ConnectorType.Line, "YES")
			MyBase.CreateConnector(document, emailRevisions, "Center", evaluateRevisions, "Center", ConnectorType.Line, "")
			MyBase.CreateConnector(document, evaluateRevisions2, "Center", emailApprovedRevisions, "Center", ConnectorType.Line, "")

			' connect accross levels
			Dim connector As NStep3Connector = (TryCast(MyBase.CreateConnector(document, newClient, "Center", dataEntry, "Center", ConnectorType.SideToSide, "NO"), NStep3Connector))
			connector.UseMiddleControlPointPercent = False
			connector.MiddleControlPointOffset = -55

			MyBase.CreateConnector(document, explainDataEntryProcedures, "Center", dataEntry, "Center", ConnectorType.TopToBottom, "")
			MyBase.CreateConnector(document, emailApprovedRevisions, "Center", review, "Center", ConnectorType.Line, "")
			MyBase.CreateConnector(document, emailRevisions, "Center", evaluateRevisions2, "Center", ConnectorType.Line, "")
			MyBase.CreateConnector(document, evaluateRevisions, "BottomLeft", answerClientEmail, "TopLeft", ConnectorType.Line, "")
			MyBase.CreateConnector(document, answerClientEmail, "TopRight", evaluateRevisions, "BottomRight", ConnectorType.Line, "")

			connector = (TryCast(MyBase.CreateConnector(document, needsRevising, "Center", paywoll, "Center", ConnectorType.TopToBottom, ""), NStep3Connector))
			connector.MiddleControlPointPercent = 66

			connector = (TryCast(MyBase.CreateConnector(document, needsRevising, "Center", taxes, "Center", ConnectorType.TopToBottom, ""), NStep3Connector))
			connector.MiddleControlPointPercent = 66

			connector = (TryCast(MyBase.CreateConnector(document, needsRevising, "Center", controller, "Center", ConnectorType.TopToBottom, ""), NStep3Connector))
			connector.MiddleControlPointPercent = 66

			' create the legend as a group
			Dim legend As NGroup = New NGroup()

			Dim legendBackground As NRectangleShape = New NRectangleShape(0, 0, 1, 3)
			legendBackground.Style.FillStyle = New NColorFillStyle(Color.White)
			legend.Shapes.AddChild(legendBackground)

			Dim bounds As NRectangleF = New NRectangleF(0, 1, 1, 1)
			bounds.Inflate(-0.2f, -0.2f)

			Dim cpaItem As NRectangleShape = New NRectangleShape(bounds)
			cpaItem.Text = "CPA"
			cpaItem.StyleSheetName = "CPA"
			legend.Shapes.AddChild(cpaItem)

			bounds = New NRectangleF(0, 2, 1, 1)
			bounds.Inflate(-0.2f, -0.2f)

			Dim clientItem As NRectangleShape = New NRectangleShape(bounds)
			clientItem.Text = "Client"
			clientItem.StyleSheetName = "CLIENT"
			legend.Shapes.AddChild(clientItem)

			legend.UpdateModelBounds()
			legend.Bounds = MyBase.GetGridCell(4, 0, 1, 1)

			document.ActiveLayer.AddChild(legend)
			document.SizeToContent()
		End Sub

		#End Region
	End Class
End Namespace
