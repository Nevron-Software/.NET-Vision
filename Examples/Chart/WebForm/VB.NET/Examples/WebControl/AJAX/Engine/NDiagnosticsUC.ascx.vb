Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI.WebControls
Imports Nevron.Chart
Imports Nevron.Chart.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NDiagnosticsUC
		Inherits NExampleUC
		#Region "Event Handlers"

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			'	initialize the Nevron Instant Callback mode
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
				consoleModeDropDownList.SelectedValue = (CInt(Fix(nChartControl1.AjaxDebugConsoleMode))).ToString()
			End If
		End Sub

		Protected Sub nChartControl1_QueryAjaxTools(ByVal sender As Object, ByVal e As EventArgs)
			'	configure the client side tools
			nChartControl1.AjaxTools.Add(New NAjaxMouseMoveCallbackTool(True))
		End Sub

		Protected Sub consoleModeDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.AjaxDebugConsoleMode = CType(Integer.Parse(consoleModeDropDownList.SelectedValue), AjaxDebugConsoleMode)
			hideConsoleButtonPanel.Visible = (nChartControl1.AjaxDebugConsoleMode = AjaxDebugConsoleMode.Embedded)
		End Sub

		#End Region

		#Region "Nested Classes"

		<Serializable> _
		Public Class CustomHttpHandlerCallback
			Inherits NHttpHandlerCallback
			#Region "INHttpHandlerCallback Members"

			Public Overrides Sub OnAsyncMouseMove(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				ExplodePieSegment(state, args, 5)
			End Sub

			Public Overrides Sub OnAsyncRefresh(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As EventArgs)
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

			#End Region
		End Class

		#End Region
	End Class
End Namespace
