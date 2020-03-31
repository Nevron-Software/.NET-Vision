Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.Chart.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NEventQueueingUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.HttpHandlerCallback = New CustomHttpHandlerCallback()

			If nChartControl1.RequiresInitialization Then
				nChartControl1.BackgroundStyle.FrameStyle.Visible = False
				nChartControl1.Settings.JitterMode = JitterMode.Enabled
				nChartControl1.Charts.Clear()

				Dim chart As NPieChart = New NPieChart()
				nChartControl1.Panels.Add(chart)

				chart.Enable3D = True
				chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated)
				chart.Projection.Elevation = 312
				chart.BoundsMode = BoundsMode.Fit
				chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
				chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

				chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights)
				chart.LightModel.LightSources(0).Specular = Color.FromArgb(64, 64, 64)
				chart.LightModel.LightSources(1).Specular = Color.FromArgb(64, 64, 64)
				chart.LightModel.LightSources(2).Specular = Color.FromArgb(64, 64, 64)
				chart.Radius = New NLength(48, NRelativeUnit.ParentPercentage)
				chart.InnerRadius = New NLength(31, NRelativeUnit.ParentPercentage)

				Dim pie As NPieSeries = CType(chart.Series.Add(SeriesType.Pie), NPieSeries)
				pie.BorderStyle = New NStrokeStyle(New NLength(5), Color.White)
				pie.PieStyle = PieStyle.Torus

				Dim arrLabels As String() = New String() { "Cars", "Trains", "Airplanes", "Buses", "Bikes", "Motorcycles", "Shuttles", "Rollers", "Ski", "Surf" }

				Dim arrData As Double() = New Double(9) { 98, 80, 57, 98, 96, 84, 54, 73, 40, 53 }

				Dim i As Integer = 0
				Do While i < arrCustomColors2.Length
					pie.Values.Add(arrData(i))
					pie.Labels.Add(arrLabels(i))
					pie.FillStyles(i) = New NColorFillStyle(arrCustomColors2(i))
					pie.BorderStyles(i) = New NStrokeStyle(1, arrCustomColors2(i))

					If i = 5 Then
						pie.Detachments.Add(5)
					Else
						pie.Detachments.Add(0)
					End If
					i += 1
				Loop
			End If
		End Sub

		Protected Sub nChartControl1_QueryAjaxTools(ByVal sender As Object, ByVal e As EventArgs)
			'	configure the client side tools
			nChartControl1.AjaxTools.Add(New NAjaxMouseClickCallbackTool(True))
			nChartControl1.AjaxTools.Add(New NAjaxMouseDoubleClickCallbackTool(True))
			nChartControl1.AjaxTools.Add(New NAjaxMouseMoveCallbackTool(True))
			nChartControl1.AjaxTools.Add(New NAjaxMouseDownCallbackTool(True))
			nChartControl1.AjaxTools.Add(New NAjaxMouseUpCallbackTool(True))
		End Sub

		Protected Sub addResponseDelayCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			'	select the default enabled state of the mouse tools
			nChartControl1.AjaxTools.GetToolByType(GetType(NAjaxMouseClickCallbackTool)).DefaultEnabled = (Not Request("mouseClickCheckbox") Is Nothing)
			nChartControl1.AjaxTools.GetToolByType(GetType(NAjaxMouseDoubleClickCallbackTool)).DefaultEnabled = (Not Request("mouseDoubleClickCheckbox") Is Nothing)
			nChartControl1.AjaxTools.GetToolByType(GetType(NAjaxMouseMoveCallbackTool)).DefaultEnabled = (Not Request("mouseMoveCheckbox") Is Nothing)
			nChartControl1.AjaxTools.GetToolByType(GetType(NAjaxMouseDownCallbackTool)).DefaultEnabled = (Not Request("mouseDownCheckbox") Is Nothing)
			nChartControl1.AjaxTools.GetToolByType(GetType(NAjaxMouseUpCallbackTool)).DefaultEnabled = (Not Request("mouseUpCheckbox") Is Nothing)

			'	select the default enabled state of client side services
			nChartControl1.AsyncAutoRefreshEnabled = (Not Request("autoRefreshCheckbox") Is Nothing)
			nChartControl1.AsyncRequestWaitCursorEnabled = (Not Request("waitCursorCheckbox") Is Nothing)

			Dim val As Integer

			If Integer.TryParse(Request("autoRefreshIntervalCombo"), val) Then
				nChartControl1.AsyncRefreshInterval = val
			End If

			If Integer.TryParse(Request("mouseClickPriorityCombo"), val) Then
				nChartControl1.AsyncClickEventPriority = val
			End If

			If Integer.TryParse(Request("mouseClickQueueLengthCombo"), val) Then
				nChartControl1.AsyncClickEventQueueLength = val
			End If

			If Integer.TryParse(Request("mouseDoubleClickPriorityCombo"), val) Then
				nChartControl1.AsyncDoubleClickEventPriority = val
			End If

			If Integer.TryParse(Request("mouseDoubleClickQueueLengthCombo"), val) Then
				nChartControl1.AsyncDoubleClickEventQueueLength = val
			End If

			If Integer.TryParse(Request("mouseMovePriorityCombo"), val) Then
				nChartControl1.AsyncMouseMoveEventPriority = val
			End If

			If Integer.TryParse(Request("mouseMoveQueueLengthCombo"), val) Then
				nChartControl1.AsyncMouseMoveEventQueueLength = val
			End If

			If Integer.TryParse(Request("mouseDownPriorityCombo"), val) Then
				nChartControl1.AsyncMouseDownEventPriority = val
			End If

			If Integer.TryParse(Request("mouseDownQueueLengthCombo"), val) Then
				nChartControl1.AsyncMouseDownEventQueueLength = val
			End If

			If Integer.TryParse(Request("mouseUpPriorityCombo"), val) Then
				nChartControl1.AsyncMouseUpEventPriority = val
			End If

			If Integer.TryParse(Request("mouseUpQueueLengthCombo"), val) Then
				nChartControl1.AsyncMouseUpEventQueueLength = val
			End If

			If Integer.TryParse(Request("refreshPriorityCombo"), val) Then
				nChartControl1.AsyncRefreshPriority = val
			End If

			If Integer.TryParse(Request("refreshQueueLengthCombo"), val) Then
				nChartControl1.AsyncRefreshQueueLength = val
			End If

			Dim httpHandlerCallback As CustomHttpHandlerCallback = TryCast(nChartControl1.HttpHandlerCallback, CustomHttpHandlerCallback)
			httpHandlerCallback.SimulateResponseDelay = addResponseDelayCheckBox.Checked
		End Sub

		#Region "Nested Classes"

		<Serializable> _
		Public Class CustomHttpHandlerCallback
			Inherits NHttpHandlerCallback
			#Region "INHttpHandlerCallback Members"

			Public Overrides Sub OnAsyncClick(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				DoSimulateResponseDelay()
				ColorPieSegment(state, args, Color.White)
			End Sub

			Public Overrides Sub OnAsyncDoubleClick(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				DoSimulateResponseDelay()
				ExplodePieSegment(state, args, -10)
			End Sub

			Public Overrides Sub OnAsyncMouseDown(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				DoSimulateResponseDelay()
				ColorPieSegment(state, args, Color.Violet)
			End Sub

			Public Overrides Sub OnAsyncMouseMove(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				DoSimulateResponseDelay()
				ExplodePieSegment(state, args, 5)
			End Sub

			Public Overrides Sub OnAsyncMouseUp(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				DoSimulateResponseDelay()
				ColorPieSegment(state, args, Color.Pink)
			End Sub

			Public Overrides Sub OnAsyncRefresh(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As EventArgs)
				DoSimulateResponseDelay()
				Dim chartState As NChartSessionStateObject = TryCast(state, NChartSessionStateObject)
				Dim rootPanel As NRootPanel = chartState.Document.RootPanel
				Dim pieChart As NPieChart = TryCast(rootPanel.Charts(0), NPieChart)
				pieChart.BeginAngle += 1
				If pieChart.BeginAngle >= 360 Then
					pieChart.BeginAngle = 0
				End If
			End Sub

			#End Region

			#Region "Implementation"

			Private Sub ExplodePieSegment(ByVal state As NStateObject, ByVal e As EventArgs, ByVal offset As Integer)
				Dim args As NCallbackMouseEventArgs = TryCast(e, NCallbackMouseEventArgs)
				Dim chartState As NChartSessionStateObject = TryCast(state, NChartSessionStateObject)
				Dim result As NHitTestResult = chartState.HitTest(args)

				If result.ChartElement = ChartElement.DataPoint Then
					Dim pieSeries As NPieSeries = TryCast(result.Series, NPieSeries)
					pieSeries.Detachments.Clear()
					Dim i As Integer = 0
					Do While i < pieSeries.Values.Count
						If i = result.DataPointIndex Then
							pieSeries.Detachments.Add(offset)
						Else
							pieSeries.Detachments.Add(0)
						End If
						i += 1
					Loop
				End If
			End Sub

			Private Sub ColorPieSegment(ByVal state As NStateObject, ByVal e As EventArgs, ByVal c As Color)
				Dim args As NCallbackMouseEventArgs = TryCast(e, NCallbackMouseEventArgs)
				Dim chartState As NChartSessionStateObject = TryCast(state, NChartSessionStateObject)
				Dim result As NHitTestResult = chartState.HitTest(args)
				Dim rootPanel As NRootPanel = chartState.Document.RootPanel

				If result.ChartElement = ChartElement.DataPoint Then
					Dim pieSeries As NPieSeries = TryCast(result.Series, NPieSeries)
					Dim i As Integer = 0
					Do While i < pieSeries.Values.Count
						If i = result.DataPointIndex Then
							pieSeries.FillStyles(i) = New NColorFillStyle(c)
							pieSeries.BorderStyles(i) = New NStrokeStyle(1, Color.White)
						Else
							Dim colorIndex As Integer = i Mod NExampleUC.arrCustomColors2.Length
							Dim color As Color = NExampleUC.arrCustomColors2(colorIndex)

							pieSeries.FillStyles(i) = New NColorFillStyle(color)
							pieSeries.BorderStyles(i) = New NStrokeStyle(1, color)
						End If
						i += 1
					Loop
				End If
			End Sub

			Private Sub DoSimulateResponseDelay()
				If (Not SimulateResponseDelay) Then
					Return
				End If

				System.Threading.Thread.Sleep(600)
			End Sub

			#End Region

			#Region "Fields"

			Public SimulateResponseDelay As Boolean = False

			#End Region
		End Class

		#End Region
	End Class
End Namespace
