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
	Public Partial Class NBubblePaletteUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Bubble Palette")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = False

			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add interlace stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			Dim ordinalScale As NOrdinalScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			' add a bubble series
			Dim bubble As NBubbleSeries = CType(chart.Series.Add(SeriesType.Bubble), NBubbleSeries)
			bubble.DataLabelStyle.VertAlign = VertAlign.Center
			bubble.DataLabelStyle.Visible = False
			bubble.Legend.Mode = SeriesLegendMode.DataPoints
			bubble.Legend.Format = "<size>"
			bubble.MinSize = New NLength(7.0f, NRelativeUnit.ParentPercentage)
			bubble.MaxSize = New NLength(16.0f, NRelativeUnit.ParentPercentage)

			For i As Integer = 0 To 9
				bubble.Values.Add(i)
				bubble.Sizes.Add(i * 10 + 10)
			Next i

			bubble.InflateMargins = True

			Dim palette As NPalette = New NPalette()
			palette.SmoothPalette = True
			palette.Clear()
			palette.Add(0, Color.Green)
			palette.Add(60, Color.Yellow)
			palette.Add(120, Color.Red)

			bubble.Palette = palette

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))
		End Sub
	End Class
End Namespace

