Imports Microsoft.VisualBasic
Imports Nevron.Chart
Imports Nevron.GraphicsCore
Imports System
Imports System.Drawing

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NBarConnectorLinesUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Bar Connector Lines")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' configure chart
			Dim chart As NChart = CType(nChartControl1.Charts(0), NCartesianChart)
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' add bar and change bar color
			Dim barSeries As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			barSeries.Name = "Bar Series"
			barSeries.DataLabelStyle.Visible = False

			' add some data to the bar series
			barSeries.Values.Add(18)
			barSeries.Values.Add(15)
			barSeries.Values.Add(21)
			barSeries.Values.Add(23)
			barSeries.Values.Add(28)
			barSeries.Values.Add(29)

			barSeries.ShowConnectorLines = ShowConnectorLinesCheckBox.Checked

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))
		End Sub
	End Class
End Namespace
