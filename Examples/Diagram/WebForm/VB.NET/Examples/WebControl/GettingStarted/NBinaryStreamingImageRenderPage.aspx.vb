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
	''' Summary description for NBinaryStreamingImageRenderPage.
	''' </summary>
	Public Partial Class NBinaryStreamingImageRenderPage
		Inherits NDrawingViewHostPage
		Public Sub New()
			Me.DrawingView = New NDrawingView()
			Me.DrawingView.ViewLayout = CanvasLayout.Stretch

			Dim document As NDrawingDocument = Me.DrawingView.Document

			' init document
			document.BeginInit()
			CreateScene(document)
			document.EndInit()

			Me.DrawingView.SizeToContent()
		End Sub

		Private Sub CreateScene(ByVal document As NDrawingDocument)
			document.BackgroundStyle.FrameStyle.Visible = False

			Dim cpaFillStyle As NFillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(102, 204, 255), Color.FromArgb(0, 128, 128))
			Dim clientFillStyle As NFillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(255, 102, 0), Color.FromArgb(255, 204, 0))
			Dim stripeFillStyle As NFillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.FromArgb(221, 221, 221))
			Dim abcTextStyle As NTextStyle = New NTextStyle(New Font("Arial", 12), Color.FromArgb(150, 150, 150))
			Dim abcWidth As Single = 150

			Dim helper As NDrawingDocumentHelper = New NDrawingDocumentHelper(document)

			' configure the document
			helper.DefaultGridCellSize = New NSizeF(100, 70)
			helper.DefaultGridSpacing = New NSizeF(30, 30)
			helper.DefaultGridOrigin = New NPointF(60, 30)

			document.Bounds = New NRectangleF(0, 0, 1000, (6 * helper.DefaultGridCellSize.Height) + (7 * helper.DefaultGridSpacing.Height))
			document.ShadowsZOrder = ShadowsZOrder.BehindLayer

			' create the stripes
			Dim rect As NRectangleShape = New NRectangleShape(0, 0, document.Width, document.Height / 3)
			rect.Style.FillStyle = CType(stripeFillStyle.Clone(), NFillStyle)
			rect.Style.StrokeStyle = New NStrokeStyle(0, Color.White)
			document.ActiveLayer.AddChild(rect)

			rect = New NRectangleShape(0, document.Height / 3, document.Width, document.Height / 3)
			rect.Style.FillStyle = CType(stripeFillStyle.Clone(), NFillStyle)
			rect.Style.StrokeStyle = New NStrokeStyle(0, Color.White)
			document.ActiveLayer.AddChild(rect)

			rect = New NRectangleShape(0, 2 * document.Height / 3, document.Width, document.Height / 3)
			rect.Style.FillStyle = CType(stripeFillStyle.Clone(), NFillStyle)
			rect.Style.StrokeStyle = New NStrokeStyle(0, Color.White)
			document.ActiveLayer.AddChild(rect)

			' create A,B,C texts
			Dim text As NTextShape = New NTextShape("A", document.Width - abcWidth, 0, abcWidth, document.Height / 3)
			text.Mode = BoxTextMode.Stretch
			text.Style.TextStyle = (TryCast(abcTextStyle.Clone(), NTextStyle))
			document.ActiveLayer.AddChild(text)

			text = New NTextShape("B", document.Width - abcWidth, document.Height / 3, abcWidth, document.Height / 3)
			text.Mode = BoxTextMode.Stretch
			text.Style.TextStyle = (TryCast(abcTextStyle.Clone(), NTextStyle))
			document.ActiveLayer.AddChild(text)

			text = New NTextShape("C", document.Width - abcWidth, 2 * document.Height / 3, abcWidth, document.Height / 3)
			text.Mode = BoxTextMode.Stretch
			text.Style.TextStyle = (TryCast(abcTextStyle.Clone(), NTextStyle))
			document.ActiveLayer.AddChild(text)

			' add stripe texts
			text = New NTextShape("Sing up client", document.Width - abcWidth, document.Height / 3 - 50, abcWidth, 50)
			document.ActiveLayer.AddChild(text)

			text = New NTextShape("Monthly Accounting Services", document.Width - abcWidth, 2 * document.Height / 3 - 50, abcWidth, 50)
			document.ActiveLayer.AddChild(text)

			text = New NTextShape("Additional Services", document.Width - abcWidth, 3 * document.Height / 3 - 50, abcWidth, 50)
			document.ActiveLayer.AddChild(text)

			' create a layer for the forground shapes
			Dim layer As NLayer = New NLayer()
			document.Layers.AddChild(layer)
			document.ActiveLayerUniqueId = layer.UniqueId
			layer.Style.ShadowStyle = New NShadowStyle(ShadowType.GaussianBlur, Color.Gray, New Nevron.GraphicsCore.NPointL(5, 5), 1, New NLength(10))

			' shapes in row 1
			Dim newClient As NShape = helper.CreateBasicShape(BasicShapes.Diamond, helper.GetGridCell(0, 0), "New Client", cpaFillStyle)
			Dim register As NShape = helper.CreateBasicShape(BasicShapes.Rectangle, helper.GetGridCell(0, 1), "Register", cpaFillStyle)
			Dim clientAccountInfo As NShape = helper.CreateFlowChartingShape(FlowChartingShapes.Data, helper.GetGridCell(0, 2), "Client account info", cpaFillStyle)
			Dim explainDataEntryProcedures As NShape = helper.CreateBasicShape(BasicShapes.Rectangle, helper.GetGridCell(0, 3), "Explain data entry procedures", cpaFillStyle)

			' shapes in row 2
			Dim dataEntry As NShape = helper.CreateFlowChartingShape(FlowChartingShapes.ManualInput, helper.GetGridCell(2, 0), "Data Entry", clientFillStyle)
			Dim emailCompleted As NShape = helper.CreateFlowChartingShape(FlowChartingShapes.Document, helper.GetGridCell(2, 1), "E-mail Completed", clientFillStyle)
			Dim review As NShape = helper.CreateBasicShape(BasicShapes.Rectangle, helper.GetGridCell(2, 2), "Review", cpaFillStyle)
			Dim needsRevising As NShape = helper.CreateBasicShape(BasicShapes.Diamond, helper.GetGridCell(2, 3), "Needs revising", cpaFillStyle)
			Dim emailRevisions As NShape = helper.CreateBasicShape(BasicShapes.Rectangle, helper.GetGridCell(2, 4), "E-mail revisions", cpaFillStyle)
			Dim evaluateRevisions As NShape = helper.CreateBasicShape(BasicShapes.Rectangle, helper.GetGridCell(2, 5), "Evaluate revisions", clientFillStyle)

			' shapes in row 3
			Dim emailApprovedRevisions As NShape = helper.CreateFlowChartingShape(FlowChartingShapes.Document, helper.GetGridCell(3, 2), "E-mail Approved Revisions", clientFillStyle)
			Dim evaluateRevisions2 As NShape = helper.CreateBasicShape(BasicShapes.Rectangle, helper.GetGridCell(3, 4), "Evaluate Revisions", clientFillStyle)
			Dim answerClientEmail As NShape = helper.CreateBasicShape(BasicShapes.Rectangle, helper.GetGridCell(3, 5), "Answer Client E-mail", cpaFillStyle)

			' shapes in row 4
			Dim paywoll As NShape = helper.CreateFlowChartingShape(FlowChartingShapes.Document, helper.GetGridCell(5, 2), "Payroll", clientFillStyle)
			Dim taxes As NShape = helper.CreateBasicShape(BasicShapes.Rectangle, helper.GetGridCell(5, 3), "Taxes", clientFillStyle)
			Dim controller As NShape = helper.CreateBasicShape(BasicShapes.Rectangle, helper.GetGridCell(5, 4), "Controller", cpaFillStyle)

			' create the optional ports of the shape
			evaluateRevisions.CreateShapeElements(ShapeElementsMask.Ports)

			' some shapes need to have extra ports
			Dim port As NRotatedBoundsPort = New NRotatedBoundsPort(evaluateRevisions.UniqueId, New NContentAlignment(-25, 50))
			port.Name = "BottomLeft"
			evaluateRevisions.Ports.AddChild(port)

			port = New NRotatedBoundsPort(evaluateRevisions.UniqueId, New NContentAlignment(+25, 50))
			port.Name = "BottomRight"
			evaluateRevisions.Ports.AddChild(port)

			' create the optional ports of the shape
			answerClientEmail.CreateShapeElements(ShapeElementsMask.Ports)

			port = New NRotatedBoundsPort(answerClientEmail.UniqueId, New NContentAlignment(-25, -50))
			port.Name = "TopLeft"
			answerClientEmail.Ports.AddChild(port)

			port = New NRotatedBoundsPort(answerClientEmail.UniqueId, New NContentAlignment(+25, -50))
			port.Name = "TopRight"
			answerClientEmail.Ports.AddChild(port)

			' connect shapes in levels
			helper.CreateConnector(newClient, "Center", register, "Center", ConnectorType.Line, "YES")
			helper.CreateConnector(register, "Center", clientAccountInfo, "Center", ConnectorType.Line, "")
			helper.CreateConnector(clientAccountInfo, "Center", explainDataEntryProcedures, "Center", ConnectorType.Line, "")

			helper.CreateConnector(dataEntry, "Center", emailCompleted, "Center", ConnectorType.Line, "")
			helper.CreateConnector(emailCompleted, "Center", review, "Center", ConnectorType.Line, "")
			helper.CreateConnector(review, "Center", needsRevising, "Center", ConnectorType.Line, "")
			helper.CreateConnector(needsRevising, "Center", emailRevisions, "Center", ConnectorType.Line, "YES")
			helper.CreateConnector(emailRevisions, "Center", evaluateRevisions, "Center", ConnectorType.Line, "")

			helper.CreateConnector(evaluateRevisions2, "Center", emailApprovedRevisions, "Center", ConnectorType.Line, "")

			' connect accross levels
			Dim connector As NStep3Connector = (TryCast(helper.CreateConnector(newClient, "Center", dataEntry, "Center", ConnectorType.SideToSide, "NO"), NStep3Connector))
			connector.UseMiddleControlPointPercent = False
			connector.MiddleControlPointOffset = -50

			helper.CreateConnector(explainDataEntryProcedures, "Center", dataEntry, "Center", ConnectorType.TopToBottom, "")

			helper.CreateConnector(emailApprovedRevisions, "Center", review, "Center", ConnectorType.Line, "")
			helper.CreateConnector(emailRevisions, "Center", evaluateRevisions2, "Center", ConnectorType.Line, "")
			helper.CreateConnector(evaluateRevisions, "BottomLeft", answerClientEmail, "TopLeft", ConnectorType.Line, "")
			helper.CreateConnector(answerClientEmail, "TopRight", evaluateRevisions, "BottomRight", ConnectorType.Line, "")

			connector = (TryCast(helper.CreateConnector(needsRevising, "Center", paywoll, "Center", ConnectorType.TopToBottom, ""), NStep3Connector))
			connector.MiddleControlPointPercent = 66
			connector = (TryCast(helper.CreateConnector(needsRevising, "Center", taxes, "Center", ConnectorType.TopToBottom, ""), NStep3Connector))
			connector.MiddleControlPointPercent = 66
			connector = (TryCast(helper.CreateConnector(needsRevising, "Center", controller, "Center", ConnectorType.TopToBottom, ""), NStep3Connector))
			connector.MiddleControlPointPercent = 66

			' create the legend
			Dim legend As NGroup = New NGroup()

			Dim ledendBackground As NRectangleShape = New NRectangleShape(0, 0, 1, 3)
			ledendBackground.Style.FillStyle = New NColorFillStyle(Color.White)
			legend.Shapes.AddChild(ledendBackground)

			Dim legendTitle As NTextShape = New NTextShape("Legend", 0, 0, 1, 1)
			legend.Shapes.AddChild(legendTitle)

			Dim bounds As NRectangleF = New NRectangleF(0, 1, 1, 1)
			bounds.Inflate(-0.2f, -0.2f)

			Dim shape As NShape = helper.CreateBasicShape(BasicShapes.Rectangle, bounds, "CPA", CType(cpaFillStyle.Clone(), NFillStyle), False)
			legend.Shapes.AddChild(shape)

			bounds = New NRectangleF(0, 2, 1, 1)
			bounds.Inflate(-0.2f, -0.2f)

			shape = helper.CreateBasicShape(BasicShapes.Rectangle, bounds, "Client", CType(clientFillStyle.Clone(), NFillStyle), False)
			legend.Shapes.AddChild(shape)

			legend.UpdateModelBounds()
			legend.Bounds = helper.GetGridCell(4, 0, 1, 1)

			document.ActiveLayer.AddChild(legend)
		End Sub
	End Class
End Namespace
