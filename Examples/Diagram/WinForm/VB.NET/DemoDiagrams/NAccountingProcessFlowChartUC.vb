Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NAccountingProcessFlowChartUC.
	''' </summary>
	Public Class NAccountingProcessFlowChartUC
		Inherits NDiagramExampleUC
		#Region "Constructor"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			InitializeComponent()
		End Sub

		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.SuspendLayout()
			' 
			' commonControlsPanel
			' 
			Me.commonControlsPanel.Location = New System.Drawing.Point(0, 304)
			Me.commonControlsPanel.Name = "commonControlsPanel"
			Me.commonControlsPanel.Size = New System.Drawing.Size(248, 80)
			' 
			' NAccountingProcessFlowChartUC
			' 
			Me.Name = "NAccountingProcessFlowChartUC"
			Me.Size = New System.Drawing.Size(248, 384)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			MyBase.DefaultGridOrigin = New NPointF(30, 30)
			MyBase.DefaultGridCellSize = New NSizeF(100, 50)
			MyBase.DefaultGridSpacing = New NSizeF(50, 40)

			' begin view init
			view.BeginInit()

			view.GlobalVisibility.ShowPorts = False
			view.Grid.Visible = False
			view.HorizontalRuler.Visible = False
			view.VerticalRuler.Visible = False
			view.ViewLayout = ViewLayout.Fit
			view.DocumentPadding = New Nevron.Diagram.NMargins(10)
			view.DocumentShadow = New NShadowStyle(Color.Gray)
			view.DocumentShadow.Offset = New NPointL(3, 3)

			' init document
			document.BeginInit()
			InitDocument()
			document.EndInit()

			' end view init
			view.EndInit()
		End Sub


		#End Region

		#Region "Implementation"

		Private Sub InitDocument()
			' modify the connectors style sheet
			Dim styleSheet As NStyleSheet = (TryCast(document.StyleSheets.GetChildByName(NDR.NameConnectorsStyleSheet, -1), NStyleSheet))

			styleSheet.Style.StrokeStyle = New NStrokeStyle(1, Color.Black)
			styleSheet.Style.StartArrowheadStyle.Shape = ArrowheadShape.None
			styleSheet.Style.EndArrowheadStyle.StrokeStyle = New NStrokeStyle(1, Color.Black)

			' create a stylesheet for the CPA shapes
			styleSheet = New NStyleSheet("CPA")
			styleSheet.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(68, 90, 108), Color.FromArgb(162, 173, 182))
			document.StyleSheets.AddChild(styleSheet)

			' create a stylesheet for the CLIENT shapes
			styleSheet = New NStyleSheet("CLIENT")
			styleSheet.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(247, 150, 56), Color.FromArgb(251, 203, 156))
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
			Dim newClient As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.Decision, MyBase.GetGridCell(0, 0), "New Client", "CPA")
			Dim register As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.Process, MyBase.GetGridCell(0, 1), "Register", "CPA")
			Dim clientAccountInfo As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.Data, MyBase.GetGridCell(0, 2), "Client account info", "CPA")
			Dim explainDataEntryProcedures As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.Process, MyBase.GetGridCell(0, 3), "Explain data entry procedures", "CPA")

			' shapes in row 2
			Dim dataEntry As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.ManualInput, MyBase.GetGridCell(2, 0), "Data Entry", "CLIENT")
			Dim emailCompleted As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.Document, MyBase.GetGridCell(2, 1), "E-mail Completed", "CLIENT")
			Dim review As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.Process, MyBase.GetGridCell(2, 2), "Review", "CPA")
			Dim needsRevising As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.Decision, MyBase.GetGridCell(2, 3), "Needs revising", "CPA")
			Dim emailRevisions As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.Process, MyBase.GetGridCell(2, 4), "E-mail revisions", "CPA")
			Dim evaluateRevisions As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.Process, MyBase.GetGridCell(2, 5), "Evaluate revisions", "CLIENT")

			' shapes in row 3
			Dim emailApprovedRevisions As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.Document, MyBase.GetGridCell(3, 2), "E-mail Approved Revisions", "CLIENT")
			Dim evaluateRevisions2 As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.Process, MyBase.GetGridCell(3, 4), "Evaluate Revisions", "CLIENT")
			Dim answerClientEmail As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.Process, MyBase.GetGridCell(3, 5), "Answer Client E-mail", "CPA")

			' shapes in row 4
			Dim paywoll As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.Document, MyBase.GetGridCell(5, 2), "Payroll", "CLIENT")
			Dim taxes As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.Process, MyBase.GetGridCell(5, 3), "Taxes", "CLIENT")
			Dim controller As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.Process, MyBase.GetGridCell(5, 4), "Controller", "CPA")

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
			MyBase.CreateConnector(newClient, "Center", register, "Center", ConnectorType.Line, "YES")
			MyBase.CreateConnector(register, "Center", clientAccountInfo, "Center", ConnectorType.Line, "")
			MyBase.CreateConnector(clientAccountInfo, "Center", explainDataEntryProcedures, "Center", ConnectorType.Line, "")

			MyBase.CreateConnector(dataEntry, "Center", emailCompleted, "Center", ConnectorType.Line, "")
			MyBase.CreateConnector(emailCompleted, "Center", review, "Center", ConnectorType.Line, "")
			MyBase.CreateConnector(review, "Center", needsRevising, "Center", ConnectorType.Line, "")
			MyBase.CreateConnector(needsRevising, "Center", emailRevisions, "Center", ConnectorType.Line, "YES")
			MyBase.CreateConnector(emailRevisions, "Center", evaluateRevisions, "Center", ConnectorType.Line, "")

			MyBase.CreateConnector(evaluateRevisions2, "Center", emailApprovedRevisions, "Center", ConnectorType.Line, "")

			' connect accross levels
			Dim connector As NStep3Connector = (TryCast(MyBase.CreateConnector(newClient, "Center", dataEntry, "Center", ConnectorType.SideToSide, "NO"), NStep3Connector))
			connector.UseMiddleControlPointPercent = False
			connector.MiddleControlPointOffset = -55

			MyBase.CreateConnector(explainDataEntryProcedures, "Center", dataEntry, "Center", ConnectorType.TopToBottom, "")

			MyBase.CreateConnector(emailApprovedRevisions, "Center", review, "Center", ConnectorType.Line, "")
			MyBase.CreateConnector(emailRevisions, "Center", evaluateRevisions2, "Center", ConnectorType.Line, "")
			MyBase.CreateConnector(evaluateRevisions, "BottomLeft", answerClientEmail, "TopLeft", ConnectorType.Line, "")
			MyBase.CreateConnector(answerClientEmail, "TopRight", evaluateRevisions, "BottomRight", ConnectorType.Line, "")

			connector = (TryCast(MyBase.CreateConnector(needsRevising, "Center", paywoll, "Center", ConnectorType.TopToBottom, ""), NStep3Connector))
			connector.MiddleControlPointPercent = 66

			connector = (TryCast(MyBase.CreateConnector(needsRevising, "Center", taxes, "Center", ConnectorType.TopToBottom, ""), NStep3Connector))
			connector.MiddleControlPointPercent = 66

			connector = (TryCast(MyBase.CreateConnector(needsRevising, "Center", controller, "Center", ConnectorType.TopToBottom, ""), NStep3Connector))
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
		End Sub

		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace