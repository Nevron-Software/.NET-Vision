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
	''' Summary description for NSimpleStateDiagramUC.
	''' </summary>
	Public Class NSimpleStateDiagramUC
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
			' NSimpleStateDiagramUC
			' 
			Me.Name = "NSimpleStateDiagramUC"
			Me.Size = New System.Drawing.Size(248, 384)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()
			view.GlobalVisibility.ShowPorts = False
			view.Grid.Visible = False
			view.ViewLayout = ViewLayout.Fit
			view.DocumentPadding = New Nevron.Diagram.NMargins(10)

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
			' create the flowcharting shapes factory
			Dim factory As NFlowChartingShapesFactory = New NFlowChartingShapesFactory(document)

			' modify the connectors style sheet
			Dim styleSheet As NStyleSheet = (TryCast(document.StyleSheets.GetChildByName(NDR.NameConnectorsStyleSheet, -1), NStyleSheet))

			Dim textStyle As NTextStyle = New NTextStyle()
			textStyle.BackplaneStyle.Visible = True
			textStyle.BackplaneStyle.StandardFrameStyle.InnerBorderWidth = New NLength(0)
			styleSheet.Style.TextStyle = textStyle

			styleSheet.Style.StrokeStyle = New NStrokeStyle(1, Color.Black)
			styleSheet.Style.StartArrowheadStyle.StrokeStyle = New NStrokeStyle(1, Color.Black)
			styleSheet.Style.EndArrowheadStyle.StrokeStyle = New NStrokeStyle(1, Color.Black)

			' create the begin shape 
			Dim begin As NShape = factory.CreateShape(CInt(Fix(FlowChartingShapes.Termination)))
			begin.Bounds = New NRectangleF(100, 100, 100, 100)
			begin.Text = "BEGIN"
			document.ActiveLayer.AddChild(begin)

			' create the step1 shape
			Dim step1 As NShape = factory.CreateShape(CInt(Fix(FlowChartingShapes.Process)))
			step1.Bounds = New NRectangleF(100, 400, 100, 100)
			step1.Text = "STEP1"
			document.ActiveLayer.AddChild(step1)

			' connect begin and step1 with bezier link
			Dim bezier As NBezierCurveShape = New NBezierCurveShape()
			bezier.StyleSheetName = NDR.NameConnectorsStyleSheet
			bezier.Text = "BEZIER"
			bezier.FirstControlPoint = New NPointF(100, 300)
			bezier.SecondControlPoint = New NPointF(200, 300)
			document.ActiveLayer.AddChild(bezier)
			bezier.FromShape = begin
			bezier.ToShape = step1

			' create question1 shape
			Dim question1 As NShape = factory.CreateShape(CInt(Fix(FlowChartingShapes.Decision)))
			question1.Bounds = New NRectangleF(300, 400, 100, 100)
			question1.Text = "QUESTION1"
			document.ActiveLayer.AddChild(question1)

			' connect step1 and question1 with line link
			Dim line As NLineShape = New NLineShape()
			line.StyleSheetName = NDR.NameConnectorsStyleSheet
			line.Text = "LINE"
			document.ActiveLayer.AddChild(line)
			line.FromShape = step1
			line.ToShape = question1

			' create the step2 shape
			Dim step2 As NShape = factory.CreateShape(CInt(Fix(FlowChartingShapes.Process)))
			step2.Bounds = New NRectangleF(500, 100, 100, 100)
			step2.Text = "STEP2"
			document.ActiveLayer.AddChild(step2)

			' connect step2 and question1 with HV link
			Dim hv1 As NStep2Connector = New NStep2Connector(False)
			hv1.StyleSheetName = NDR.NameConnectorsStyleSheet
			hv1.Text = "HV1"
			document.ActiveLayer.AddChild(hv1)
			hv1.FromShape = step2
			hv1.ToShape = question1

			' connect question1 and step2 and with HV link
			Dim hv2 As NStep2Connector = New NStep2Connector(False)
			hv2.StyleSheetName = NDR.NameConnectorsStyleSheet
			hv2.Text = "HV2"
			document.ActiveLayer.AddChild(hv2)
			hv2.FromShape = question1
			hv2.ToShape = step2

			' create a self loof as bezier on step2
			Dim selfLoop As NBezierCurveShape = New NBezierCurveShape()
			selfLoop.StyleSheetName = NDR.NameConnectorsStyleSheet
			selfLoop.Text = "SELF LOOP"
			document.ActiveLayer.AddChild(selfLoop)
			selfLoop.FromShape = step2
			selfLoop.ToShape = step2
			selfLoop.Reflex()

			' create step3 shape
			Dim step3 As NShape = factory.CreateShape(CInt(Fix(FlowChartingShapes.Process)))
			step3.Bounds = New NRectangleF(700, 600, 100, 100)
			step3.Text = "STEP3"
			document.ActiveLayer.AddChild(step3)

			' connect question1 and step3 with an HVH link
			Dim hvh1 As NStep3Connector = New NStep3Connector(False, 50, 0, True)
			hvh1.StyleSheetName = NDR.NameConnectorsStyleSheet
			hvh1.Text = "HVH1"
			document.ActiveLayer.AddChild(hvh1)
			hvh1.FromShape = question1
			hvh1.ToShape = step3

			' create end shape
			Dim [end] As NShape = factory.CreateShape(CInt(Fix(FlowChartingShapes.Termination)))
			[end].Bounds = New NRectangleF(300, 700, 100, 100)
			[end].Text = "END"
			document.ActiveLayer.AddChild([end])

			' connect step3 and end with VH link
			Dim vh1 As NStep2Connector = New NStep2Connector(True)
			vh1.StyleSheetName = NDR.NameConnectorsStyleSheet
			vh1.Text = "VH1"
			document.ActiveLayer.AddChild(vh1)
			vh1.FromShape = step3
			vh1.ToShape = [end]

			' connect question1 and end with curve link (uses explicit ports)
			Dim curve As NRoutableConnector = New NRoutableConnector(RoutableConnectorType.DynamicCurve)
			curve.StyleSheetName = NDR.NameConnectorsStyleSheet
			curve.Text = "CURVE"
			document.ActiveLayer.AddChild(curve)
			curve.StartPlug.Connect(TryCast(question1.Ports.GetChildAt(3), NPort))
			curve.EndPlug.Connect(TryCast([end].Ports.GetChildAt(1), NPort))
			curve.InsertPoint(1, New NPointF(500, 600))

			' set a shadow to the document. Since styles are inheritable all objects will reuse this shadow
			document.Style.ShadowStyle = New NShadowStyle(ShadowType.GaussianBlur, Color.Gray, New NPointL(5, 5), 1, New NLength(3))

			' shadows must be displayed behind document content
			document.ShadowsZOrder = ShadowsZOrder.BehindDocument
		End Sub

		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace