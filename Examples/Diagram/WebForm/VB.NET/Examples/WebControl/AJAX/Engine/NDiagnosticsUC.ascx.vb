Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Windows.Forms

Imports Nevron.Dom
Imports Nevron.Diagram
Imports Nevron.Diagram.Batches
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.WebForm
Imports Nevron.UI.WebForm.Controls
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''		Summary description for NDiagnosticsUC.
	''' </summary>
	Public Partial Class NDiagnosticsUC
		Inherits NDiagramExampleUC
		#Region "Event Handlers"

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			'	initialize the Nevron Instant Callback mode
			NDrawingView1.HttpHandlerCallback = New CustomHttpHandlerCallback()

			If NDrawingView1.RequiresInitialization Then
				' begin view init
				NDrawingView1.ViewLayout = CanvasLayout.Normal
				NDrawingView1.ScaleX = 1
				NDrawingView1.ScaleY = 1
				NDrawingView1.ViewportOrigin = New NPointF()

				' init document
				NDrawingView1.Document.HistoryService.Stop()
				NDrawingView1.Document.BeginInit()
				InitDocument()
				NDrawingView1.Document.EndInit()
			End If

			If (Not IsPostBack) Then
				Dim length As Integer
				Dim names As String()
				Dim values As Integer()

				consoleModeDropDownList.Items.Clear()
				names = System.Enum.GetNames(GetType(AjaxDebugConsoleMode))
				values = CType(System.Enum.GetValues(GetType(AjaxDebugConsoleMode)), Integer())

				length = names.Length
				Dim i As Integer = 0
				Do While i < length
					consoleModeDropDownList.Items.Add(New ListItem(names(i), values(i).ToString()))
					i += 1
				Loop
				consoleModeDropDownList.SelectedValue = (CInt(Fix(NDrawingView1.AjaxDebugConsoleMode))).ToString()
			End If
		End Sub

		Protected Sub NDrawingView1_QueryAjaxTools(ByVal sender As Object, ByVal e As EventArgs)
			'configure the client side tools
			NDrawingView1.AjaxTools.Add(New NAjaxMouseMoveCallbackTool(True))
		End Sub

		Protected Sub consoleModeDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			NDrawingView1.AjaxDebugConsoleMode = CType(Integer.Parse(consoleModeDropDownList.SelectedValue), AjaxDebugConsoleMode)
			hideConsoleButtonPanel.Visible = (NDrawingView1.AjaxDebugConsoleMode = AjaxDebugConsoleMode.Embedded)
		End Sub

		#End Region

		#Region "Nested Classes"

		<Serializable> _
		Public Class CustomHttpHandlerCallback
			Inherits NHttpHandlerCallback
			#Region "INHttpHandlerCallback Members"

			Public Overrides Sub OnAsyncMouseMove(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				Dim diagramState As NDiagramSessionStateObject = TryCast(state, NDiagramSessionStateObject)
				Dim rotatingEllipse As NEllipseShape = TryCast(diagramState.Document.ActiveLayer.GetChildByName("RotatingEllipse", 0), NEllipseShape)
				If rotatingEllipse Is Nothing Then
					Return
				End If
				Dim rotatingEllipse2 As NEllipseShape = TryCast(diagramState.Document.ActiveLayer.GetChildByName("RotatingEllipse2", 0), NEllipseShape)
				If rotatingEllipse2 Is Nothing Then
					Return
				End If
				Dim centerEllipse As NEllipseShape = TryCast(diagramState.Document.ActiveLayer.GetChildByName("CenterEllipse", 0), NEllipseShape)
				If centerEllipse Is Nothing Then
					Return
				End If

				rotatingEllipse.Style.StrokeStyle = Nothing
				rotatingEllipse2.Style.StrokeStyle = Nothing
				centerEllipse.Style.StrokeStyle = Nothing

				Dim ellipse As NEllipseShape = HitTestEllipse(state, args)
				If ellipse Is Nothing Then
					Return
				End If

				ellipse.Style.StrokeStyle = New NStrokeStyle(2f, Color.Snow)

				diagramState.Document.RefreshAllViews()
			End Sub

			Public Overrides Sub OnAsyncRefresh(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As EventArgs)
				Dim diagramState As NDiagramSessionStateObject = TryCast(state, NDiagramSessionStateObject)
				Dim rotatingEllipse As NEllipseShape = TryCast(diagramState.Document.ActiveLayer.GetChildByName("RotatingEllipse", 0), NEllipseShape)
				If rotatingEllipse Is Nothing Then
					Return
				End If
				Dim rotatingEllipse2 As NEllipseShape = TryCast(diagramState.Document.ActiveLayer.GetChildByName("RotatingEllipse2", 0), NEllipseShape)
				If rotatingEllipse2 Is Nothing Then
					Return
				End If

				rotatingEllipse.Rotate(CoordinateSystem.Scene, 7, rotatingEllipse.PinPoint)
				rotatingEllipse2.Rotate(CoordinateSystem.Scene, -4, rotatingEllipse2.PinPoint)

				diagramState.Document.RefreshAllViews()
			End Sub

			#End Region

			#Region "Implementation"

			Protected Function HitTestEllipse(ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs) As NEllipseShape
				Dim diagramState As NDiagramSessionStateObject = TryCast(state, NDiagramSessionStateObject)
				Dim nodes As NNodeList = diagramState.HitTest(args)
				Dim shapes As NNodeList = nodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D)
				For Each node As NShape In shapes
					If Not(TypeOf node Is NEllipseShape) Then
						Continue For
					End If
					If (Not node.Name.Contains("Ellipse")) Then
						Continue For
					End If
					Return TryCast(node, NEllipseShape)
				Next node

				Return Nothing
			End Function

			#End Region
		End Class

		#End Region

		#Region "Implementation"

		Private Sub InitDocument()
			' modify the connectors style sheet
			Dim styleSheet As NStyleSheet = (TryCast(NDrawingView1.Document.StyleSheets.GetChildByName(NDR.NameConnectorsStyleSheet, -1), NStyleSheet))

			Dim textStyle As NTextStyle = New NTextStyle()
			textStyle.BackplaneStyle.Visible = True
			textStyle.BackplaneStyle.StandardFrameStyle.InnerBorderWidth = New NLength(0)
			textStyle.BackplaneStyle.FillStyle = New NColorFillStyle(Color.FromArgb(200, Color.White))
			styleSheet.Style.TextStyle = textStyle

			styleSheet.Style.StrokeStyle = New NStrokeStyle(1, Color.Black)
			styleSheet.Style.StartArrowheadStyle.StrokeStyle = New NStrokeStyle(Color.FromArgb(0, Color.Black))
			styleSheet.Style.StartArrowheadStyle.FillStyle = New NColorFillStyle(Color.FromArgb(0, Color.White))
			styleSheet.Style.EndArrowheadStyle.StrokeStyle = New NStrokeStyle(1, Color.Black)

			' modify default stroke style
			NDrawingView1.Document.Style.StrokeStyle = New NStrokeStyle(Color.FromArgb(0, Color.Black))

			' configure the document
			NDrawingView1.Document.Bounds = New NRectangleF(0, 0, 420, 320)
			NDrawingView1.Document.GraphicsSettings.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias
			NDrawingView1.Document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
			NDrawingView1.Document.GraphicsSettings.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality
			NDrawingView1.Document.MeasurementUnit = NGraphicsUnit.Pixel
			NDrawingView1.Document.DrawingScaleMode = DrawingScaleMode.NoScale

			NDrawingView1.Document.BackgroundStyle.FrameStyle.Visible = False

			'	predefined styles
			Dim ag1 As NAdvancedGradientFillStyle = New NAdvancedGradientFillStyle()
			ag1.BackgroundColor = Color.Silver
			ag1.Points.Add(New NAdvancedGradientPoint(Color.AliceBlue, 50, 50, 0, 79, AGPointShape.Circle))

			Dim ag2 As NAdvancedGradientFillStyle = New NAdvancedGradientFillStyle()
			ag2.BackgroundColor = Color.Goldenrod
			ag2.Points.Add(New NAdvancedGradientPoint(Color.WhiteSmoke, 50, 50, 0, 71, AGPointShape.Circle))

			Dim ag3 As NAdvancedGradientFillStyle = New NAdvancedGradientFillStyle()
			ag3.BackgroundColor = Color.Navy
			ag3.Points.Add(New NAdvancedGradientPoint(Color.Azure, 50, 50, 0, 50, AGPointShape.Circle))

			'	shapes
			Dim factory As NBasicShapesFactory = New NBasicShapesFactory(NDrawingView1.Document)

			Dim centerEllipse As NEllipseShape = TryCast(factory.CreateShape(CInt(Fix(BasicShapes.Ellipse))), NEllipseShape)
			centerEllipse.Name = "CenterEllipse"
			centerEllipse.Width = 50f
			centerEllipse.Height = 50f
			centerEllipse.Center = New NPointF(210, 160)
			centerEllipse.Style.StrokeStyle = Nothing
			centerEllipse.Style.FillStyle = ag3

			Dim rotatingEllipse As NEllipseShape = TryCast(factory.CreateShape(CInt(Fix(BasicShapes.Ellipse))), NEllipseShape)
			rotatingEllipse.Name = "RotatingEllipse"
			rotatingEllipse.Width = 35f
			rotatingEllipse.Height = 35f
			rotatingEllipse.Center = New NPointF(centerEllipse.Bounds.X - 100, centerEllipse.Center.Y)
			rotatingEllipse.Style.StrokeStyle = Nothing
			rotatingEllipse.Style.FillStyle = ag1
			rotatingEllipse.PinPoint = New NPointF(centerEllipse.Center.X, centerEllipse.Center.Y)

			Dim rotatingEllipse2 As NEllipseShape = TryCast(factory.CreateShape(CInt(Fix(BasicShapes.Ellipse))), NEllipseShape)
			rotatingEllipse2.Name = "RotatingEllipse2"
			rotatingEllipse2.Width = 15f
			rotatingEllipse2.Height = 15f
			rotatingEllipse2.Center = New NPointF(centerEllipse.Bounds.Right + 30, centerEllipse.Center.Y)
			rotatingEllipse2.Style.StrokeStyle = Nothing
			rotatingEllipse2.Style.FillStyle = ag2
			rotatingEllipse2.PinPoint = New NPointF(centerEllipse.Center.X, centerEllipse.Center.Y)

			Dim orbit1 As NEllipseShape = TryCast(factory.CreateShape(CInt(Fix(BasicShapes.Ellipse))), NEllipseShape)
			orbit1.Name = "orbit1"
			orbit1.Width = 2 * (centerEllipse.Center.X - rotatingEllipse.Center.X)
			orbit1.Height = orbit1.Width
			orbit1.Center = New NPointF(centerEllipse.Center.X, centerEllipse.Center.Y)
			orbit1.Style.StrokeStyle = New NStrokeStyle(Color.Black)
			orbit1.Style.StrokeStyle.Pattern = LinePattern.Dot
			orbit1.Style.StrokeStyle.Factor = 2
			orbit1.Style.FillStyle = New NColorFillStyle(Color.FromArgb(0, Color.White))

			Dim orbit2 As NEllipseShape = TryCast(factory.CreateShape(CInt(Fix(BasicShapes.Ellipse))), NEllipseShape)
			orbit2.Name = "orbit2"
			orbit2.Width = 2 * (centerEllipse.Center.X - rotatingEllipse2.Center.X)
			orbit2.Height = orbit2.Width
			orbit2.Center = New NPointF(centerEllipse.Center.X, centerEllipse.Center.Y)
			orbit2.Style.StrokeStyle = New NStrokeStyle(Color.Black)
			orbit2.Style.StrokeStyle.Pattern = LinePattern.Dot
			orbit2.Style.StrokeStyle.Factor = 2
			orbit2.Style.FillStyle = New NColorFillStyle(Color.FromArgb(0, Color.White))

			NDrawingView1.Document.ActiveLayer.AddChild(orbit1)
			NDrawingView1.Document.ActiveLayer.AddChild(orbit2)
			NDrawingView1.Document.ActiveLayer.AddChild(centerEllipse)
			NDrawingView1.Document.ActiveLayer.AddChild(rotatingEllipse)
			NDrawingView1.Document.ActiveLayer.AddChild(rotatingEllipse2)

			' some shapes need to have extra ports
			Dim port As NRotatedBoundsPort = New NRotatedBoundsPort(centerEllipse.UniqueId, ContentAlignment.MiddleCenter)
			port.Name = "MiddleCenter"
			centerEllipse.Ports.AddChild(port)

			port = New NRotatedBoundsPort(rotatingEllipse.UniqueId, ContentAlignment.MiddleCenter)
			port.Name = "MiddleCenter"
			rotatingEllipse.Ports.AddChild(port)

			' connect shapes in levels
			MyBase.CreateConnector(NDrawingView1.Document, centerEllipse, "MiddleCenter", rotatingEllipse, "MiddleCenter", ConnectorType.Line, "Radius")
		End Sub

		Protected Function HitTestEllipse(ByVal args As NCallbackMouseEventArgs) As NEllipseShape
			Dim nodes As NNodeList = NDrawingView1.HitTest(args)
			Dim shapes As NNodeList = nodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D)
			For Each node As NShape In shapes
				If Not(TypeOf node Is NEllipseShape) Then
					Continue For
				End If
				If (Not node.Name.Contains("Ellipse")) Then
					Continue For
				End If
				Return TryCast(node, NEllipseShape)
			Next node

			Return Nothing
		End Function

		#End Region
	End Class
End Namespace
