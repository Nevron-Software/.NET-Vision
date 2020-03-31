Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.Chart.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NReliabilityUC
		Inherits NExampleUC
		#Region "Event Handlers"

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			'	decrease the session timeout to the lowest value to allow quick simulation
			'	of an expired session state
			Me.Session.Timeout = 1

			If NevronInstantCallbackMode Then
				'	initialize the Nevron Instant Callback mode
				nChartControl1.HttpHandlerCallback = New CustomHttpHandlerCallback()
			End If

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
				Do While i < arrCustomColors3.Length
					pie.Values.Add(arrData(i))
					pie.Labels.Add(arrLabels(i))
					pie.FillStyles(i) = New NColorFillStyle(arrCustomColors3(i))
					pie.BorderStyles(i) = New NStrokeStyle(1, arrCustomColors3(i))

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
			nChartControl1.AjaxTools.Add(New NAjaxMouseMoveCallbackTool(True))
		End Sub

		Protected Sub ajaxModeRadioButtonList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			'	apply the client side controls state to the chart control at server side

			'	select the default enabled state of the mouse move tool
			nChartControl1.AjaxTools.GetToolByType(GetType(NAjaxMouseMoveCallbackTool)).DefaultEnabled = (Not Request("mouseMoveCheckbox") Is Nothing)

			'	select the default enabled state of the auto refresh service
			nChartControl1.AsyncAutoRefreshEnabled = (Not Request("autoRefreshCheckbox") Is Nothing)

			NevronInstantCallbackMode = (ajaxModeRadioButtonList.SelectedValue <> "microsoftAJAXCallback")
		End Sub

		Protected Sub nChartControl1_AsyncCustomCommand(ByVal sender As Object, ByVal e As EventArgs)
			'	this method is called when the web control operates in the standard Microsoft AJAX mode
			Dim args As NCallbackCustomCommandArgs = TryCast(e, NCallbackCustomCommandArgs)
			Select Case args.Command.Name
				Case "restartApplication"
					Try
						System.Web.HttpRuntime.UnloadAppDomain()
					Catch ex As Exception
						System.Diagnostics.Debug.WriteLine("nChartControl1_AsyncCustomCommand, restartApplication: " & ex.Message)
					End Try
				Case "enforceResponseDelay"
					Try
						SimulateResponseDelay = True
					Catch ex As Exception
						System.Diagnostics.Debug.WriteLine("nChartControl1_AsyncCustomCommand, changeResponseDelay: " & ex.Message)
					End Try
			End Select
		End Sub

		Protected Sub nChartControl1_AsyncMouseMove(ByVal sender As Object, ByVal e As EventArgs)
			'	this method is called when the web control operates in the standard Microsoft AJAX mode
			DoSimulateResponseDelay()

			Dim args As NCallbackMouseEventArgs = TryCast(e, NCallbackMouseEventArgs)
			ExplodePieSegment(args, 5)
		End Sub

		Protected Sub nChartControl1_AsyncRefresh(ByVal sender As Object, ByVal e As EventArgs)
			'	this method is called when the web control operates in the standard Microsoft AJAX mode
			DoSimulateResponseDelay()

			Dim rootPanel As NRootPanel = nChartControl1.Document.RootPanel
			Dim pieChart As NPieChart = TryCast(nChartControl1.Charts(0), NPieChart)
			pieChart.BeginAngle += 1
			If pieChart.BeginAngle >= 360 Then
				pieChart.BeginAngle = 0
			End If
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

				ExplodePieSegment(state, args, 5)
			End Sub

			Public Overrides Sub OnAsyncRefresh(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As EventArgs)
				'	this method is called when the web control operates in the Nevron Instant Callback mode
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
				'	this method is called when the web control operates in the Nevron Instant Callback mode
				Dim args As NCallbackMouseEventArgs = TryCast(e, NCallbackMouseEventArgs)
				Dim chartState As NChartSessionStateObject = TryCast(state, NChartSessionStateObject)
				Dim result As NHitTestResult = chartState.HitTest(args)
				Dim rootPanel As NRootPanel = chartState.Document.RootPanel

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

			Private Sub DoSimulateResponseDelay()
				If (Not SimulateResponseDelay) Then
					Return
				End If

				SimulateResponseDelay = False
				System.Threading.Thread.Sleep(6000)
			End Sub

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

		Private Sub ExplodePieSegment(ByVal e As EventArgs, ByVal offset As Integer)
			'	this method is called when the web control operates in the standard Microsoft AJAX mode
			Dim args As NCallbackMouseEventArgs = TryCast(e, NCallbackMouseEventArgs)
			Dim result As NHitTestResult = nChartControl1.HitTest(args)
			Dim rootPanel As NRootPanel = nChartControl1.Document.RootPanel

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

		Private Sub DoSimulateResponseDelay()
			If (Not SimulateResponseDelay) Then
				Return
			End If

			SimulateResponseDelay = False
			System.Threading.Thread.Sleep(6000)
		End Sub

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
