Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NDynamicImageMapUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If nChartControl1.RequiresInitialization Then
				nChartControl1.BackgroundStyle.FrameStyle.Visible = False
				nChartControl1.Settings.JitterMode = JitterMode.Enabled
				nChartControl1.Charts.Clear()
				nChartControl1.AsyncMouseMoveEventQueueLength = 1

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
					pie.InteractivityStyles.Add(i, New NInteractivityStyle(True, String.Format("{0}: {1}, {2}", i, arrLabels(i), arrData(i))))
					i += 1
				Loop
			End If
		End Sub

		Protected Sub nChartControl1_QueryAjaxTools(ByVal sender As Object, ByVal e As EventArgs)
			'	configure the client side tools
			nChartControl1.AjaxTools.Add(New NAjaxMouseOverCallbackTool(True))
			nChartControl1.AjaxTools.Add(New NAjaxMouseOutCallbackTool(True))
		End Sub

		Protected Sub nChartControl1_AsyncRefresh(ByVal sender As Object, ByVal e As EventArgs)
			Dim rootPanel As NRootPanel = nChartControl1.Document.RootPanel
			Dim pieChart As NPieChart = TryCast(rootPanel.Charts(0), NPieChart)
			pieChart.BeginAngle += 1
			If pieChart.BeginAngle >= 360 Then
				pieChart.BeginAngle = 0
			End If
		End Sub

		Protected Sub nChartControl1_AsyncMouseOver(ByVal sender As Object, ByVal e As EventArgs)
			Dim args As NCallbackMouseEventArgs = TryCast(e, NCallbackMouseEventArgs)
			If args.ItemId Is Nothing Then
				Return
			End If

			Dim id As NElementAtomIdentifier = New NElementAtomIdentifier(args.ItemId)
			Dim dataPoint As NDataPoint = TryCast(id.FindInDocument(nChartControl1.Document), NDataPoint)
			If dataPoint Is Nothing Then
				Return
			End If

			Dim rootPanel As NRootPanel = nChartControl1.Document.RootPanel
			Dim pieSeries As NPieSeries = TryCast(rootPanel.Charts(0).Series(0), NPieSeries)
			pieSeries.FillStyles(dataPoint.IndexInSeries) = New NColorFillStyle(Color.White)
		End Sub

		Protected Sub nChartControl1_AsyncMouseOut(ByVal sender As Object, ByVal e As EventArgs)
			Dim args As NCallbackMouseEventArgs = TryCast(e, NCallbackMouseEventArgs)
			If args.ItemId Is Nothing Then
				Return
			End If

			Dim id As NElementAtomIdentifier = New NElementAtomIdentifier(args.ItemId)
			Dim dataPoint As NDataPoint = TryCast(id.FindInDocument(nChartControl1.Document), NDataPoint)
			If dataPoint Is Nothing Then
				Return
			End If

			Dim rootPanel As NRootPanel = nChartControl1.Document.RootPanel
			Dim pieSeries As NPieSeries = TryCast(rootPanel.Charts(0).Series(0), NPieSeries)

			Dim colorIndex As Integer = dataPoint.IndexInSeries Mod arrCustomColors2.Length

			pieSeries.FillStyles(dataPoint.IndexInSeries) = arrCustomColors2(colorIndex)
		End Sub
	End Class
End Namespace
