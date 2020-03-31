Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NScatterAreaUC
		Inherits NExampleUC

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XY Area")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch
			chart.Axis(StandardAxis.Depth).Visible = False

			Dim linearScale As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale

			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add interlace stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			linearScale.StripStyles.Add(stripStyle)

			' add an area series
			Dim area As NAreaSeries = CType(chart.Series.Add(SeriesType.Area), NAreaSeries)
			area.UseXValues = True
			area.DataLabelStyle.Visible = False
			area.MarkerStyle.Visible = True
			area.MarkerStyle.Width = New NLength(1.6f, NRelativeUnit.ParentPercentage)
			area.MarkerStyle.Height = New NLength(1.6f, NRelativeUnit.ParentPercentage)
			area.MarkerStyle.PointShape = PointShape.Cylinder
			area.MarkerStyle.BorderStyle.Color = DarkOrange
			area.MarkerStyle.FillStyle = New NColorFillStyle(DarkOrange)
			area.FillStyle = New NColorFillStyle(Red)
			area.BorderStyle.Color = DarkOrange
			area.DropLines = DropLinesCheckBox.Checked

			' add random values
			Dim currentX As Double = Random.NextDouble() * 10

			For i As Integer = 0 To 9
				area.Values.Add(0.6 + Random.NextDouble())
				area.XValues.Add(currentX)

				currentX += 2.0 + Random.NextDouble() * 10
			Next i

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub
	End Class
End Namespace
