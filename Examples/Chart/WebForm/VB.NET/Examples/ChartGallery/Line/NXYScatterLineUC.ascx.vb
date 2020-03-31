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
	Public Partial Class NXYScatterLineUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XY Scatter Line Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' setup Y axis
			Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' setup X axis
			Dim scaleX As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Floor }
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add interlace stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			scaleX.StripStyles.Add(stripStyle)

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' add the line
			Dim line As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line.Name = "Line Series"
			line.LineSegmentShape = LineSegmentShape.Line
			line.InflateMargins = True
			line.DataLabelStyle.Visible = False
			line.MarkerStyle.Visible = True
			line.MarkerStyle.PointShape = PointShape.Cylinder
			line.Legend.Mode = SeriesLegendMode.None
			' instruct the series to use X values
			line.UseXValues = True

			' add XY data points
			Dim random As Random = New Random()
			line.AddDataPoint(New NDataPoint(15 + random.Next(10), 10))
			line.AddDataPoint(New NDataPoint(25 + random.Next(10), 23))
			line.AddDataPoint(New NDataPoint(45 + random.Next(10), 12))
			line.AddDataPoint(New NDataPoint(55 + random.Next(10), 21))
			line.AddDataPoint(New NDataPoint(61 + random.Next(10), 16))
			line.AddDataPoint(New NDataPoint(67 + random.Next(10), 19))
			line.AddDataPoint(New NDataPoint(72 + random.Next(10), 11))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub
	End Class
End Namespace
