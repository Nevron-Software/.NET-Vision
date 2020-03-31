Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NTrainSalesPage
		Inherits Page
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.Settings.JitteringSteps = 4

			nChartControl1.Panels.Clear()

			Dim watermark As NWatermark = New NWatermark()
			nChartControl1.Panels.Add(watermark)

			Dim title As NLabel = New NLabel("Train Sales by Company")
			nChartControl1.Panels.Add(title)

			Dim legend As NLegend = New NLegend()
			nChartControl1.Panels.Add(legend)

			Dim chart As NPieChart = New NPieChart()
			nChartControl1.Panels.Add(chart)

			' setup the watermark
			watermark.FillStyle = New NImageFillStyle(Me.MapPathSecure("~\Images\train.png"))
			watermark.StandardFrameStyle.InnerBorderWidth = New NLength(0)
			watermark.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(5, NRelativeUnit.ParentPercentage))
			watermark.ContentAlignment = ContentAlignment.BottomRight

			' setup the chart title
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.ContentAlignment = ContentAlignment.BottomRight
			title.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup the legend
			legend.ContentAlignment = ContentAlignment.BottomLeft
			legend.Location = New NPointL(New NLength(98, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup the chart
			chart.DisplayOnLegend = legend
			chart.Enable3D = True
			chart.LightModel.EnableLighting = True
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights)
			chart.BoundsMode = BoundsMode.Fit
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated)
			chart.Location = New NPointL(New NLength(27, NRelativeUnit.ParentPercentage), New NLength(25, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage))

			' add a pie series
			Dim pie As NPieSeries = CType(chart.Series.Add(SeriesType.Pie), NPieSeries)
			pie.LabelMode = PieLabelMode.Center
			pie.DataLabelStyle.Format = "<value>"
			pie.DataLabelStyle.TextStyle.BackplaneStyle.Shape = BackplaneShape.SmoothEdgeRectangle
			pie.DataLabelStyle.TextStyle.BackplaneStyle.FillStyle = New NColorFillStyle(Color.FromArgb(200, 255, 255, 255))
			pie.DataLabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 10, FontStyle.Bold)
			pie.DataLabelStyle.TextStyle.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.LightSeaGreen, Color.Navy)
			pie.Legend.Mode = SeriesLegendMode.DataPoints
			pie.Legend.Format = "<label> <percent>"
			pie.PieStyle = PieStyle.SmoothEdgePie

			' add data
			pie.Values.FillRandomRange(New Random(), 3, 10, 30)
			pie.Labels.Add("Alstom")
			pie.Labels.Add("Bombardier")
			pie.Labels.Add("Mitsubishi")

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.BrightMultiColor)
			styleSheet.Apply(nChartControl1.Charts(0))
		End Sub
	End Class
End Namespace
