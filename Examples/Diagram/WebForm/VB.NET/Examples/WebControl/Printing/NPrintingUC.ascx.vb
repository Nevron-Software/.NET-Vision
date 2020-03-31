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

Imports Nevron.Dom
Imports Nevron.Diagram
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.WebForm
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''		Summary description for NPrintingUC.
	''' </summary>
	Partial Public Class NPrintingUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			NDrawingView1.StateManager = New NDiagramBatonSessionStateManager(Context, "Nevron.Examples.Diagram.Webform.NPrintingUC")

			If NDrawingView1.RequiresInitialization Then
				' begin view init
				NDrawingView1.ViewLayout = CanvasLayout.Normal
				NDrawingView1.DocumentPadding = New Nevron.Diagram.NMargins(10)

				' init document
				NDrawingView1.Document.BeginInit()
				InitDocument()
				NDrawingView1.Document.EndInit()

				NDrawingView1.SizeToContent()
			End If
		End Sub

		Private Sub InitDocument()
			' set up visual formatting
			NDrawingView1.Document.Style.FillStyle = New NColorFillStyle(Color.Linen)

			' create the flowcharting shapes factory
			Dim factory As NFlowChartingShapesFactory = New NFlowChartingShapesFactory(NDrawingView1.Document)

			' modify the connectors style sheet
			Dim styleSheet As NStyleSheet = (TryCast(NDrawingView1.Document.StyleSheets.GetChildByName(NDR.NameConnectorsStyleSheet, -1), NStyleSheet))

			Dim textStyle As NTextStyle = New NTextStyle()
			textStyle.BackplaneStyle.Visible = True
			textStyle.BackplaneStyle.StandardFrameStyle.InnerBorderWidth = New NLength(0)
			styleSheet.Style.TextStyle = textStyle

			styleSheet.Style.StrokeStyle = New NStrokeStyle(1, Color.Black)
			styleSheet.Style.StartArrowheadStyle.StrokeStyle = New NStrokeStyle(1, Color.Black)
			styleSheet.Style.EndArrowheadStyle.StrokeStyle = New NStrokeStyle(1, Color.Black)

			' create the begin shape 
			Dim begin As NShape = factory.CreateShape(CInt(Fix(FlowChartingShapes.Termination)))
			begin.Bounds = New NRectangleF(300, 300, 300, 300)
			begin.Text = "BEGIN"
			NDrawingView1.Document.ActiveLayer.AddChild(begin)

			' create the step1 shape
			Dim step1 As NShape = factory.CreateShape(CInt(Fix(FlowChartingShapes.Process)))
			step1.Bounds = New NRectangleF(300, 1200, 300, 300)
			step1.Text = "STEP1"
			NDrawingView1.Document.ActiveLayer.AddChild(step1)

			' connect begin and step1 with bezier link
			Dim bezier As NBezierCurveShape = New NBezierCurveShape()
			bezier.StyleSheetName = NDR.NameConnectorsStyleSheet
			bezier.Text = "BEZIER"
			bezier.SetPointAt(1, New NPointF(300, 900))
			bezier.SetPointAt(2, New NPointF(600, 900))
			NDrawingView1.Document.ActiveLayer.AddChild(bezier)
			bezier.FromShape = begin
			bezier.ToShape = step1

			' create question1 shape
			Dim question1 As NShape = factory.CreateShape(CInt(Fix(FlowChartingShapes.Decision)))
			question1.Bounds = New NRectangleF(900, 1200, 300, 300)
			question1.Text = "QUESTION1"
			NDrawingView1.Document.ActiveLayer.AddChild(question1)

			' connect step1 and question1 with line link
			Dim line As NLineShape = New NLineShape()
			line.StyleSheetName = NDR.NameConnectorsStyleSheet
			line.Text = "LINE"
			NDrawingView1.Document.ActiveLayer.AddChild(line)
			line.FromShape = step1
			line.ToShape = question1

			' create the step2 shape
			Dim step2 As NShape = factory.CreateShape(CInt(Fix(FlowChartingShapes.Process)))
			step2.Bounds = New NRectangleF(1500, 300, 300, 300)
			step2.Text = "STEP2"
			NDrawingView1.Document.ActiveLayer.AddChild(step2)

			' connect step2 and question1 with HV link
			Dim hv1 As NStep2Connector = New NStep2Connector(False)
			hv1.StyleSheetName = NDR.NameConnectorsStyleSheet
			hv1.Text = "HV1"
			NDrawingView1.Document.ActiveLayer.AddChild(hv1)
			hv1.FromShape = step2
			hv1.ToShape = question1

			' connect question1 and step2 and with HV link
			Dim hv2 As NStep2Connector = New NStep2Connector(False)
			hv2.StyleSheetName = NDR.NameConnectorsStyleSheet
			hv2.Text = "HV2"
			NDrawingView1.Document.ActiveLayer.AddChild(hv2)
			hv2.FromShape = question1
			hv2.ToShape = step2

			' create a self loof as bezier on step2
			Dim selfLoop As NBezierCurveShape = New NBezierCurveShape()
			selfLoop.StyleSheetName = NDR.NameConnectorsStyleSheet
			selfLoop.Text = "SELF LOOP"
			NDrawingView1.Document.ActiveLayer.AddChild(selfLoop)
			selfLoop.FromShape = step2
			selfLoop.ToShape = step2
			selfLoop.Reflex()

			' create step3 shape
			Dim step3 As NShape = factory.CreateShape(CInt(Fix(FlowChartingShapes.Process)))
			step3.Bounds = New NRectangleF(2100, 1800, 300, 300)
			step3.Text = "STEP3"
			NDrawingView1.Document.ActiveLayer.AddChild(step3)

			' connect question1 and step3 with an HVH link
			Dim hvh1 As NStep3Connector = New NStep3Connector(False, 50, 0, True)
			hvh1.StyleSheetName = NDR.NameConnectorsStyleSheet
			hvh1.Text = "HVH1"
			NDrawingView1.Document.ActiveLayer.AddChild(hvh1)
			hvh1.FromShape = question1
			hvh1.ToShape = step3

			' create end shape
			Dim [end] As NShape = factory.CreateShape(CInt(Fix(FlowChartingShapes.Termination)))
			[end].Bounds = New NRectangleF(900, 2100, 300, 300)
			[end].Text = "END"
			NDrawingView1.Document.ActiveLayer.AddChild([end])

			' connect step3 and end with VH link
			Dim vh1 As NStep2Connector = New NStep2Connector(True)
			vh1.StyleSheetName = NDR.NameConnectorsStyleSheet
			vh1.Text = "VH1"
			NDrawingView1.Document.ActiveLayer.AddChild(vh1)
			vh1.FromShape = step3
			vh1.ToShape = [end]

			' connect question1 and end with curve link (uses explicit ports)
			Dim curve As NRoutableConnector = New NRoutableConnector(RoutableConnectorType.DynamicCurve)
			curve.StyleSheetName = NDR.NameConnectorsStyleSheet
			curve.Text = "CURVE"
			NDrawingView1.Document.ActiveLayer.AddChild(curve)
			curve.StartPlug.Connect(TryCast(question1.Ports.GetChildAt(3), NPort))
			curve.EndPlug.Connect(TryCast([end].Ports.GetChildAt(1), NPort))
			curve.InsertPoint(1, New NPointF(1500, 1800))

			' set a shadow to the document. Since styles are inheritable all objects will reuse this shadow
			NDrawingView1.Document.Style.ShadowStyle = New NShadowStyle(ShadowType.GaussianBlur, Color.Gray, New NPointL(5, 5), 1, New NLength(3))

			' shadows must be displayed behind document content
			NDrawingView1.Document.ShadowsZOrder = ShadowsZOrder.BehindDocument
		End Sub
	End Class
End Namespace
