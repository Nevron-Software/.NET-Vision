Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NRulesSizeUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Axis View Range")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.Margins = New NMarginsL(10, 10, 10, 10)
			title.DockMode = PanelDockMode.Top

			' turn off the legend
			nChartControl1.Legends(0).Mode = LegendMode.Disabled

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.DockMode = PanelDockMode.Fill
			chart.Margins = New NMarginsL(10, 0, 10, 10)

			' apply predefined lighting and projection
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' setup a bar series
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Bar Series"
			bar.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			bar.ShadowStyle.Type = ShadowType.GaussianBlur
			bar.ShadowStyle.Offset = New NPointL(2, 2)
			bar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0)
			bar.ShadowStyle.FadeLength = New NLength(5)
			bar.HasBottomEdge = False

			' add some data to the bar series
			bar.AddDataPoint(New NDataPoint(18, "Silverlight"))
			bar.AddDataPoint(New NDataPoint(15, "Ajax"))
			bar.AddDataPoint(New NDataPoint(21, "JackBe"))
			bar.AddDataPoint(New NDataPoint(23, "Laszlo"))
			bar.AddDataPoint(New NDataPoint(28, "Java FX"))
			bar.AddDataPoint(New NDataPoint(29, "Flex"))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.BrightMultiColor)
			styleSheet.Apply(nChartControl1.Document.Charts(0))

			If CustomViewRangeCheckBox.Checked Then
				' specify custom view range
				chart.Axis(StandardAxis.PrimaryY).View = New NRangeAxisView(New NRange1DD(14, 30), True, True)
			Else
				chart.Axis(StandardAxis.PrimaryY).View = New NContentAxisView()
			End If
		End Sub
	End Class
End Namespace
