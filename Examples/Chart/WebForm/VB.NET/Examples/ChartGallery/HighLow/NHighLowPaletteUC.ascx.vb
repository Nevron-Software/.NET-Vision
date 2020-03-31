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
	Public Partial Class NHighLowPaletteUC
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

			' add a High-Low series
			Dim highLow As NHighLowSeries = CType(chart.Series.Add(SeriesType.HighLow), NHighLowSeries)
			highLow.Legend.Mode = SeriesLegendMode.None
			highLow.DataLabelStyle.Visible = False

			highLow.ClearDataPoints()

			For i As Integer = 0 To 19
				Dim d1 As Double = Math.Log(i + 1) + 0.1 * Random.NextDouble()
				Dim d2 As Double = d1 + Math.Cos(0.33 * i) + 0.1 * Random.NextDouble()

				highLow.HighValues.Add(d1)
				highLow.LowValues.Add(d2)
			Next i

			Dim palette As NPalette = New NPalette()
			palette.Clear()
			palette.Mode = PaletteMode.Custom
			palette.Add(0, Color.Green)
			palette.Add(1.5, Color.Yellow)
			palette.Add(3, Color.Red)

			highLow.Palette = palette

			highLow.Palette.SmoothPalette = SmoothPaletteCheckBox.Checked

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))
		End Sub
	End Class
End Namespace
