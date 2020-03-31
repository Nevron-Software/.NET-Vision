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
	Public Partial Class NFloatBarPaletteUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				SmoothPaletteCheckBox.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			nChartControl1.Legends(0).Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Float Bar Palette")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHalf)
			chart.Axis(StandardAxis.Depth).Visible = False

			' add interlace stripe
			Dim yAxis As NAxis = chart.Axis(StandardAxis.PrimaryY)
			Dim linearScale As NLinearScaleConfigurator = TryCast(yAxis.ScaleConfigurator, NLinearScaleConfigurator)
			Dim strip As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			strip.Interlaced = True
			strip.SetShowAtWall(ChartWallType.Back, True)
			linearScale.StripStyles.Add(strip)

			' create the float bar series
			Dim floatBar As NFloatBarSeries = CType(chart.Series.Add(SeriesType.FloatBar), NFloatBarSeries)
			floatBar.DataLabelStyle.Visible = False
			floatBar.DataLabelStyle.VertAlign = VertAlign.Center
			floatBar.DataLabelStyle.Format = "<begin> - <end>"

			' add bars
			floatBar.AddDataPoint(New NFloatBarDataPoint(2, 10))
			floatBar.AddDataPoint(New NFloatBarDataPoint(5, 16))
			floatBar.AddDataPoint(New NFloatBarDataPoint(9, 17))
			floatBar.AddDataPoint(New NFloatBarDataPoint(12, 21))
			floatBar.AddDataPoint(New NFloatBarDataPoint(8, 18))
			floatBar.AddDataPoint(New NFloatBarDataPoint(7, 18))
			floatBar.AddDataPoint(New NFloatBarDataPoint(3, 11))
			floatBar.AddDataPoint(New NFloatBarDataPoint(5, 12))
			floatBar.AddDataPoint(New NFloatBarDataPoint(8, 17))
			floatBar.AddDataPoint(New NFloatBarDataPoint(6, 15))
			floatBar.AddDataPoint(New NFloatBarDataPoint(3, 10))
			floatBar.AddDataPoint(New NFloatBarDataPoint(1, 7))

			Dim palette As NPalette = New NPalette()
			palette.Clear()
			palette.Mode = PaletteMode.Custom
			palette.Add(0, Color.Green)
			palette.Add(10, Color.Yellow)
			palette.Add(20, Color.Red)

			floatBar.Palette = palette

			floatBar.Palette.SmoothPalette = SmoothPaletteCheckBox.Checked

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))
		End Sub
	End Class
End Namespace
