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
	Public Partial Class NSmoothAreaPaletteUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				SmoothPaletteCheckBox.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			nChartControl1.Legends(0).Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Smooth Area Palette")
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

			' setup a bar series
			Dim area As NSmoothAreaSeries = New NSmoothAreaSeries()
			area.Name = "Smooth Area Series"
			area.InflateMargins = True
			area.UseXValues = False
			area.DataLabelStyle.Visible = False

			Dim palette As NPalette = New NPalette()
			palette.Clear()
			palette.Add(0, Color.Green)
			palette.Add(60, Color.Yellow)
			palette.Add(120, Color.Red)

			area.Palette = palette

			chart.Series.Add(area)

			Dim indicatorCount As Integer = 18

			' add some data to the bar series
			Dim rand As Random = New Random()
			Dim i As Integer = 0
			Do While i <= indicatorCount
				area.Values.Add(rand.Next(20, 150))
				i += 1
			Loop

			area.Palette.SmoothPalette = SmoothPaletteCheckBox.Checked

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))
		End Sub
	End Class
End Namespace
