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
	'''		Summary description for NReliabilityUC.
	''' </summary>
	Public Partial Class NReliabilityUC
		Inherits NDiagramExampleUC
		#Region "Event Handlers"

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			'	decrease the session timeout to the lowest value to allow quick simulation
			'	of an expired session state
			Me.Session.Timeout = 1

			If NevronInstantCallbackMode Then
				'	initialize the Nevron Instant Callback mode
				NDrawingView1.HttpHandlerCallback = New CustomHttpHandlerCallback()
			End If

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
		End Sub

		Protected Sub NDrawingView1_QueryAjaxTools(ByVal sender As Object, ByVal e As EventArgs)
			'	configure the client side tools
			NDrawingView1.AjaxTools.Add(New NAjaxMouseMoveCallbackTool(True))
		End Sub

		Protected Sub ajaxModeRadioButtonList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			'	select the default enabled state of the mouse tools
			NDrawingView1.AjaxTools.GetToolByType(GetType(NAjaxMouseMoveCallbackTool)).DefaultEnabled = (Not Request("mouseMoveCheckbox") Is Nothing)

			'	select the default enabled state of client side services
			NDrawingView1.AsyncAutoRefreshEnabled = (Not Request("autoRefreshCheckbox") Is Nothing)

			NevronInstantCallbackMode = (ajaxModeRadioButtonList.SelectedValue <> "microsoftAJAXCallback")
		End Sub

		Protected Sub NDrawingView1_AsyncCustomCommand(ByVal sender As Object, ByVal e As EventArgs)
			'	this method is called when the web control operates in the standard Microsoft AJAX mode
			Dim args As NCallbackCustomCommandArgs = TryCast(e, NCallbackCustomCommandArgs)
			Select Case args.Command.Name
				Case "restartApplication"
					Try
						System.Web.HttpRuntime.UnloadAppDomain()
					Catch ex As Exception
						System.Diagnostics.Debug.WriteLine("NDrawingView1_AsyncCustomCommand, restartApplication: " & ex.Message)
					End Try
				Case "enforceResponseDelay"
					Try
						SimulateResponseDelay = True
					Catch ex As Exception
						System.Diagnostics.Debug.WriteLine("NDrawingView1_AsyncCustomCommand, changeResponseDelay: " & ex.Message)
					End Try
			End Select
		End Sub

		Protected Sub NDrawingView1_AsyncMouseMove(ByVal sender As Object, ByVal e As EventArgs)
			'	this method is called when the web control operates in the standard Microsoft AJAX mode
			DoSimulateResponseDelay()

			Dim args As NCallbackMouseEventArgs = TryCast(e, NCallbackMouseEventArgs)
			Dim rotatingEllipse As NEllipseShape = TryCast(NDrawingView1.Document.ActiveLayer.GetChildByName("RotatingEllipse", 0), NEllipseShape)
			If rotatingEllipse Is Nothing Then
				Return
			End If
			Dim rotatingEllipse2 As NEllipseShape = TryCast(NDrawingView1.Document.ActiveLayer.GetChildByName("RotatingEllipse2", 0), NEllipseShape)
			If rotatingEllipse2 Is Nothing Then
				Return
			End If
			Dim centerEllipse As NEllipseShape = TryCast(NDrawingView1.Document.ActiveLayer.GetChildByName("CenterEllipse", 0), NEllipseShape)
			If centerEllipse Is Nothing Then
				Return
			End If

			rotatingEllipse.Style.StrokeStyle = Nothing
			rotatingEllipse2.Style.StrokeStyle = Nothing
			centerEllipse.Style.StrokeStyle = Nothing

			Dim ellipse As NEllipseShape = HitTestEllipse(args)
			If ellipse Is Nothing Then
				Return
			End If

			ellipse.Style.StrokeStyle = New NStrokeStyle(2f, Color.Snow)

			NDrawingView1.Document.RefreshAllViews()
		End Sub

		Protected Sub NDrawingView1_AsyncRefresh(ByVal sender As Object, ByVal e As EventArgs)
			'	this method is called when the web control operates in the standard Microsoft AJAX mode
			DoSimulateResponseDelay()

			Dim rotatingEllipse As NEllipseShape = TryCast(NDrawingView1.Document.ActiveLayer.GetChildByName("RotatingEllipse", 0), NEllipseShape)
			If rotatingEllipse Is Nothing Then
				Return
			End If
			Dim rotatingEllipse2 As NEllipseShape = TryCast(NDrawingView1.Document.ActiveLayer.GetChildByName("RotatingEllipse2", 0), NEllipseShape)
			If rotatingEllipse2 Is Nothing Then
				Return
			End If

			rotatingEllipse.Rotate(CoordinateSystem.Scene, 7, rotatingEllipse.PinPoint)
			rotatingEllipse2.Rotate(CoordinateSystem.Scene, -4, rotatingEllipse2.PinPoint)

			NDrawingView1.Document.RefreshAllViews()
		End Sub

		#End Region

		#Region "Nested Classes"

		<Serializable> _
		Public Class CustomHttpHandlerCallback
			Inherits NHttpHandlerCallback
			#Region "INHttpHandlerCallback Members"

			Public Overrides Sub OnAsyncCustomCommand(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackCustomCommandArgs)
				'	this method is called when the web control operates in the Nevron Instant Callback mode
				Select Case args.Command.Name
					Case "restartApplication"
						Try
							System.Web.HttpRuntime.UnloadAppDomain()
						Catch ex As Exception
							System.Diagnostics.Debug.WriteLine("OnAsyncCustomCommand, restartApplication: " & ex.Message)
						End Try
					Case "enforceResponseDelay"
						Try
							SimulateResponseDelay = True
						Catch ex As Exception
							System.Diagnostics.Debug.WriteLine("OnAsyncCustomCommand, changeResponseDelay: " & ex.Message)
						End Try
				End Select
			End Sub

			Public Overrides Sub OnAsyncMouseMove(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				'	this method is called when the web control operates in the Nevron Instant Callback mode
				DoSimulateResponseDelay()

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
				'	this method is called when the web control operates in the Nevron Instant Callback mode
				DoSimulateResponseDelay()

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

			Private Sub DoSimulateResponseDelay()
				If (Not SimulateResponseDelay) Then
					Return
				End If

				SimulateResponseDelay = False
				System.Threading.Thread.Sleep(6000)
			End Sub

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

			#Region "Properties"

			Public Property SimulateResponseDelay() As Boolean
				Get
					If Not System.Web.HttpContext.Current.Session("SimulateResponseDelay") Is Nothing Then
						Return CBool(System.Web.HttpContext.Current.Session("SimulateResponseDelay"))
					End If
					Return False
				End Get
				Set
					System.Web.HttpContext.Current.Session("SimulateResponseDelay") = Value
				End Set
			End Property

			#End Region
		End Class

		#End Region

		#Region "Implementation"

		Private Sub DoSimulateResponseDelay()
			If (Not SimulateResponseDelay) Then
				Return
			End If

			SimulateResponseDelay = False
			System.Threading.Thread.Sleep(6000)
		End Sub

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

		#Region "Properties"

		Public Property SimulateResponseDelay() As Boolean
			Get
				If Not Session("SimulateResponseDelay") Is Nothing Then
					Return CBool(Session("SimulateResponseDelay"))
				End If
				Return False
			End Get
			Set
				Session("SimulateResponseDelay") = Value
			End Set
		End Property

		Public Property NevronInstantCallbackMode() As Boolean
			Get
				If Not Session("NevronInstantCallbackMode") Is Nothing Then
					Return CBool(Session("NevronInstantCallbackMode"))
				End If
				Return True
			End Get
			Set
				Session("NevronInstantCallbackMode") = Value
			End Set
		End Property

		#End Region
	End Class
End Namespace
