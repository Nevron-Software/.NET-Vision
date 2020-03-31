Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web
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
	'''		Summary description for NEventQueueingUC.
	''' </summary>
	Public Partial Class NEventQueueingUC
		Inherits NDiagramExampleUC
		#Region "Event Handlers"

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			NDrawingView1.HttpHandlerCallback = New CustomHttpHandlerCallback()

			If NDrawingView1.RequiresInitialization Then
				' begin view init
				NDrawingView1.ViewLayout = CanvasLayout.Fit
				NDrawingView1.DocumentPadding = New Nevron.Diagram.NMargins(10)

				' init document
				NDrawingView1.Document.BeginInit()
				InitDocument()
				NDrawingView1.Document.EndInit()
			End If
		End Sub

		Protected Sub NDrawingView1_QueryAjaxTools(ByVal sender As Object, ByVal e As EventArgs)
			'	configure the client side tools
			NDrawingView1.AjaxTools.Add(New NAjaxMouseClickCallbackTool(True))
			NDrawingView1.AjaxTools.Add(New NAjaxMouseDoubleClickCallbackTool(True))
			NDrawingView1.AjaxTools.Add(New NAjaxMouseMoveCallbackTool(True))
			NDrawingView1.AjaxTools.Add(New NAjaxMouseDownCallbackTool(False))
			NDrawingView1.AjaxTools.Add(New NAjaxMouseUpCallbackTool(False))
		End Sub

		Protected Sub addResponseDelayCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			'	select the default enabled state of the mouse tools
			NDrawingView1.AjaxTools.GetToolByType(GetType(NAjaxMouseClickCallbackTool)).DefaultEnabled = (Not Request("mouseClickCheckbox") Is Nothing)
			NDrawingView1.AjaxTools.GetToolByType(GetType(NAjaxMouseDoubleClickCallbackTool)).DefaultEnabled = (Not Request("mouseDoubleClickCheckbox") Is Nothing)
			NDrawingView1.AjaxTools.GetToolByType(GetType(NAjaxMouseMoveCallbackTool)).DefaultEnabled = (Not Request("mouseMoveCheckbox") Is Nothing)
			NDrawingView1.AjaxTools.GetToolByType(GetType(NAjaxMouseDownCallbackTool)).DefaultEnabled = (Not Request("mouseDownCheckbox") Is Nothing)
			NDrawingView1.AjaxTools.GetToolByType(GetType(NAjaxMouseUpCallbackTool)).DefaultEnabled = (Not Request("mouseUpCheckbox") Is Nothing)

			'	select the default enabled state of client side services
			NDrawingView1.AsyncAutoRefreshEnabled = (Not Request("autoRefreshCheckbox") Is Nothing)
			NDrawingView1.AsyncRequestWaitCursorEnabled = (Not Request("waitCursorCheckbox") Is Nothing)

			Dim val As Integer

			If Integer.TryParse(Request("autoRefreshIntervalCombo"), val) Then
				NDrawingView1.AsyncRefreshInterval = val
			End If

			If Integer.TryParse(Request("mouseClickPriorityCombo"), val) Then
				NDrawingView1.AsyncClickEventPriority = val
			End If

			If Integer.TryParse(Request("mouseClickQueueLengthCombo"), val) Then
				NDrawingView1.AsyncClickEventQueueLength = val
			End If

			If Integer.TryParse(Request("mouseDoubleClickPriorityCombo"), val) Then
				NDrawingView1.AsyncDoubleClickEventPriority = val
			End If

			If Integer.TryParse(Request("mouseDoubleClickQueueLengthCombo"), val) Then
				NDrawingView1.AsyncDoubleClickEventQueueLength = val
			End If

			If Integer.TryParse(Request("mouseMovePriorityCombo"), val) Then
				NDrawingView1.AsyncMouseMoveEventPriority = val
			End If

			If Integer.TryParse(Request("mouseMoveQueueLengthCombo"), val) Then
				NDrawingView1.AsyncMouseMoveEventQueueLength = val
			End If

			If Integer.TryParse(Request("mouseDownPriorityCombo"), val) Then
				NDrawingView1.AsyncMouseDownEventPriority = val
			End If

			If Integer.TryParse(Request("mouseDownQueueLengthCombo"), val) Then
				NDrawingView1.AsyncMouseDownEventQueueLength = val
			End If

			If Integer.TryParse(Request("mouseUpPriorityCombo"), val) Then
				NDrawingView1.AsyncMouseUpEventPriority = val
			End If

			If Integer.TryParse(Request("mouseUpQueueLengthCombo"), val) Then
				NDrawingView1.AsyncMouseUpEventQueueLength = val
			End If

			If Integer.TryParse(Request("refreshPriorityCombo"), val) Then
				NDrawingView1.AsyncRefreshPriority = val
			End If

			If Integer.TryParse(Request("refreshQueueLengthCombo"), val) Then
				NDrawingView1.AsyncRefreshQueueLength = val
			End If

			Dim httpHandlerCallback As CustomHttpHandlerCallback = TryCast(NDrawingView1.HttpHandlerCallback, CustomHttpHandlerCallback)
			httpHandlerCallback.SimulateResponseDelay = addResponseDelayCheckBox.Checked
		End Sub

		#End Region

		#Region "Nested Classes"

		<Serializable> _
		Public Class CustomHttpHandlerCallback
			Inherits NHttpHandlerCallback
			#Region "INHttpHandlerCallback Members"

			Public Overrides Sub OnAsyncClick(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				DoSimulateResponseDelay()
				ChangeCurrentShapeColor(webControlId, context, state, args, Color.YellowGreen)
			End Sub

			Public Overrides Sub OnAsyncDoubleClick(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				DoSimulateResponseDelay()
				ChangeCurrentShapeColor(webControlId, context, state, args, Color.Red)
			End Sub

			Public Overrides Sub OnAsyncMouseDown(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				DoSimulateResponseDelay()
				ChangeCurrentShapeColor(webControlId, context, state, args, Color.Yellow)
			End Sub

			Public Overrides Sub OnAsyncMouseUp(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				DoSimulateResponseDelay()
				ChangeCurrentShapeColor(webControlId, context, state, args, Color.BlueViolet)
			End Sub

			Public Overrides Sub OnAsyncMouseMove(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				DoSimulateResponseDelay()
				ChangeCurrentShapeShadow(webControlId, context, state, args)
			End Sub

			Public Overrides Sub OnAsyncRefresh(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As EventArgs)
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
			End Sub

			#End Region

			#Region "Implementation"

			Protected Sub DoSimulateResponseDelay()
				If (Not SimulateResponseDelay) Then
					Return
				End If

				System.Threading.Thread.Sleep(600)
			End Sub

			Protected Sub ChangeCurrentShapeColor(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As EventArgs, ByVal c As Color)
				Dim diagramState As NDiagramSessionStateObject = TryCast(state, NDiagramSessionStateObject)

				Dim allShapes As NNodeList = diagramState.Document.ActiveLayer.Children(Nevron.Diagram.Filters.NFilters.Shape2D)

				Dim affectedNodes As NNodeList = diagramState.HitTest(TryCast(args, NCallbackMouseEventArgs))
				Dim affectedShapes As NNodeList = affectedNodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D)

				Dim length As Integer
				Dim shape As NShape

				length = allShapes.Count
				Dim i As Integer = 0
				Do While i < length
					shape = TryCast(allShapes(i), NShape)
					If Not shape.Tag Is Nothing Then
						shape.Style.FillStyle = TryCast(shape.Tag, NAdvancedGradientFillStyle)
					End If
					i += 1
				Loop

				If affectedShapes.Count = 0 Then
					Return
				End If

				shape = TryCast(affectedShapes(affectedShapes.Count - 1), NShape)
				Dim fs As NAdvancedGradientFillStyle = TryCast(shape.Style.FillStyle, NAdvancedGradientFillStyle)
				If Not fs Is Nothing Then
					shape.Tag = fs
					shape.Style.FillStyle = New NColorFillStyle(c)
				End If
			End Sub

			Protected Sub ChangeCurrentShapeShadow(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As EventArgs)
				Dim diagramState As NDiagramSessionStateObject = TryCast(state, NDiagramSessionStateObject)

				Dim allShapes As NNodeList = diagramState.Document.ActiveLayer.Children(Nevron.Diagram.Filters.NFilters.Shape2D)

				Dim affectedNodes As NNodeList = diagramState.HitTest(TryCast(args, NCallbackMouseEventArgs))
				Dim affectedShapes As NNodeList = affectedNodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D)

				Dim length As Integer
				Dim shape As NShape

				length = allShapes.Count
				Dim i As Integer = 0
				Do While i < length
					shape = TryCast(allShapes(i), NShape)
					shape.Style.ShadowStyle = Nothing
					i += 1
				Loop

				If affectedShapes.Count = 0 Then
					Return
				End If

				shape = TryCast(affectedShapes(affectedShapes.Count - 1), NShape)
				If shape.Style.StrokeStyle Is Nothing Then
					shape.Style.ShadowStyle = New NShadowStyle(ShadowType.GaussianBlur, Color.FromArgb(96, Color.Black), New NPointL(3, 3), 1, New NLength(10))
				End If
			End Sub

			#End Region

			#Region "Fields"

			Public SimulateResponseDelay As Boolean = False

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
			NDrawingView1.Document.Style.StrokeStyle = New NStrokeStyle(Color.FromArgb(0, Color.White))

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
			ag1.BackgroundColor = Color.Navy
			ag1.Points.Add(New NAdvancedGradientPoint(Color.SkyBlue, 50, 50, 0, 79, AGPointShape.Circle))

			Dim ag2 As NAdvancedGradientFillStyle = New NAdvancedGradientFillStyle()
			ag2.BackgroundColor = Color.DarkRed
			ag2.Points.Add(New NAdvancedGradientPoint(Color.Red, 50, 50, 0, 71, AGPointShape.Circle))

			Dim ag3 As NAdvancedGradientFillStyle = New NAdvancedGradientFillStyle()
			ag3.BackgroundColor = Color.Orange
			ag3.Points.Add(New NAdvancedGradientPoint(Color.Yellow, 50, 50, 0, 50, AGPointShape.Circle))

			'	shapes
			Dim factory As NBasicShapesFactory = New NBasicShapesFactory(NDrawingView1.Document)

			Dim centerEllipse As NEllipseShape = TryCast(factory.CreateShape(CInt(Fix(BasicShapes.Ellipse))), NEllipseShape)
			centerEllipse.Name = "CenterEllipse"
			centerEllipse.Width = 50f
			centerEllipse.Height = 50f
			centerEllipse.Center = New NPointF(210, 160)
			centerEllipse.Style.StrokeStyle = Nothing
			centerEllipse.Style.FillStyle = ag3
			centerEllipse.Style.InteractivityStyle = New NInteractivityStyle(True, centerEllipse.Name)

			Dim rotatingEllipse As NEllipseShape = TryCast(factory.CreateShape(CInt(Fix(BasicShapes.Ellipse))), NEllipseShape)
			rotatingEllipse.Name = "RotatingEllipse"
			rotatingEllipse.Width = 35f
			rotatingEllipse.Height = 35f
			rotatingEllipse.Center = New NPointF(centerEllipse.Bounds.X - 100, centerEllipse.Center.Y)
			rotatingEllipse.Style.StrokeStyle = Nothing
			rotatingEllipse.Style.FillStyle = ag1
			rotatingEllipse.PinPoint = New NPointF(centerEllipse.Center.X, centerEllipse.Center.Y)
			rotatingEllipse.Style.InteractivityStyle = New NInteractivityStyle(True, rotatingEllipse.Name)

			Dim rotatingEllipse2 As NEllipseShape = TryCast(factory.CreateShape(CInt(Fix(BasicShapes.Ellipse))), NEllipseShape)
			rotatingEllipse2.Name = "RotatingEllipse2"
			rotatingEllipse2.Width = 15f
			rotatingEllipse2.Height = 15f
			rotatingEllipse2.Center = New NPointF(centerEllipse.Bounds.Right + 30, centerEllipse.Center.Y)
			rotatingEllipse2.Style.StrokeStyle = Nothing
			rotatingEllipse2.Style.FillStyle = ag2
			rotatingEllipse2.PinPoint = New NPointF(centerEllipse.Center.X, centerEllipse.Center.Y)
			rotatingEllipse2.Style.InteractivityStyle = New NInteractivityStyle(True, rotatingEllipse2.Name)

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
			Dim connector As NShape = MyBase.CreateConnector(NDrawingView1.Document, centerEllipse, "MiddleCenter", rotatingEllipse, "MiddleCenter", ConnectorType.Line, "Radius")
			Dim istyle As NInteractivityStyle = connector.ComposeInteractivityStyle()
		End Sub

		#End Region
	End Class
End Namespace
