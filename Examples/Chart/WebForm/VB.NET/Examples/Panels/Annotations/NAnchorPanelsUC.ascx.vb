Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NAnchorPanelsUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				MiniChartTypeDropDownList.Items.Add("Pie")
				MiniChartTypeDropDownList.Items.Add("Doughnut")
				MiniChartTypeDropDownList.Items.Add("Bar")
				MiniChartTypeDropDownList.Items.Add("Area")
				MiniChartTypeDropDownList.SelectedIndex = 0
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Anchor panels")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' configure chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			Dim linearScaleConfigurator As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleConfigurator
			chart.Axis(StandardAxis.Depth).Visible = False

			UpdateMiniCharts(chart)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Sub UpdateMiniCharts(ByVal chart As NChart)
			chart.RemoveDescendantsOfType(GetType(NAnchorPanel))
			chart.Series.Clear()

			' add a master point series
			Dim pointSeries As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			pointSeries.UseXValues = True
			pointSeries.InflateMargins = True
			pointSeries.DataLabelStyle.Visible = False
			pointSeries.Size = New NLength(12, NRelativeUnit.ParentPercentage)
			pointSeries.FillStyle = New NColorFillStyle(Color.Gainsboro)

			' fill the point series with data
			For i As Integer = 0 To 4
				pointSeries.Values.Add(2 + Random.NextDouble() * 10)
				pointSeries.XValues.Add(2 + Random.NextDouble() * 10)
			Next i

			' create anchor panels attached to the point series data points
			Dim pointIndex As Integer = 0
			Do While pointIndex < pointSeries.Values.Count
				Dim anchorPanel As NAnchorPanel = New NAnchorPanel()
				chart.ChildPanels.Add(anchorPanel)

				anchorPanel.Size = New NSizeL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))

				anchorPanel.Anchor = New NDataPointAnchor(pointSeries, pointIndex, ContentAlignment.MiddleCenter, StringAlignment.Near)
				anchorPanel.ContentAlignment = ContentAlignment.MiddleCenter
				anchorPanel.ChildPanels.Add(CreateAnchorPanelChart())
				pointIndex += 1
			Loop
		End Sub

		Private Function CreateAnchorPanelChart() As NChart
			Dim chart As NChart = Nothing
			Dim series As NSeries = Nothing
			Dim linearScale As NLinearScaleConfigurator

			Select Case MiniChartTypeDropDownList.SelectedIndex
				Case 0 ' Pie
					chart = New NPieChart()
					series = CType(chart.Series.Add(SeriesType.Pie), NSeries)
					SetDataPointColors(series)

				Case 1 ' Doughnut
					chart = New NPieChart()
					Dim pie As NPieSeries = CType(chart.Series.Add(SeriesType.Pie), NPieSeries)
					pie.PieStyle = PieStyle.Ring
					CType(chart, NPieChart).InnerRadius = New NLength(25, NRelativeUnit.ParentPercentage)
					series = pie
					SetDataPointColors(series)

				Case 2 ' Bar
					chart = New NCartesianChart()

					chart.Wall(ChartWallType.Back).Visible = False
					chart.Axis(StandardAxis.PrimaryX).Visible = False
					chart.Axis(StandardAxis.PrimaryY).Visible = False
					chart.Axis(StandardAxis.Depth).Visible = False

					linearScale = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
					linearScale.MajorGridStyle.LineStyle.Width = New NLength(0)

					series = CType(chart.Series.Add(SeriesType.Bar), NSeries)
					SetDataPointColors(series)

				Case 3 ' Area
					chart = New NCartesianChart()

					chart.Wall(ChartWallType.Back).Visible = False
					chart.Axis(StandardAxis.PrimaryX).Visible = False
					chart.Axis(StandardAxis.PrimaryY).Visible = False
					chart.Axis(StandardAxis.Depth).Visible = False

					linearScale = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
					linearScale.MajorGridStyle.LineStyle.Width = New NLength(0)

					series = CType(chart.Series.Add(SeriesType.Area), NSeries)
					series.FillStyle = New NColorFillStyle(DarkOrange)
			End Select

			chart.BoundsMode = BoundsMode.Fit
			chart.DockMode = PanelDockMode.Fill

			series.DataLabelStyle.Visible = False

			For i As Integer = 0 To 4
				series.Values.Add(5 + Random.Next(10))
			Next i

			Return chart
		End Function

		Private Sub SetDataPointColors(ByVal series As NSeries)
			Dim palette As NChartPalette = New NChartPalette(ChartPredefinedPalette.Fresh)

			For i As Integer = 0 To 4
				series.FillStyles(i) = New NColorFillStyle(palette.SeriesColors(i))
			Next i
		End Sub
	End Class
End Namespace
