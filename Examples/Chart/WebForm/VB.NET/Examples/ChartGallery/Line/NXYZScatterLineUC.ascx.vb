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
	Public Partial Class NXYZScatterLineUC
		Inherits NExampleUC

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XYZ Scatter Line Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 50
			chart.Height = 50
			chart.Depth = 50
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' setup Y axis
			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add interlace stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScaleConfigurator.StripStyles.Add(stripStyle)

			' setup X axis
			linearScaleConfigurator = New NLinearScaleConfigurator()
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Back, ChartWallType.Floor }
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleConfigurator

			' setup Z axis
			linearScaleConfigurator = New NLinearScaleConfigurator()
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Left, ChartWallType.Floor }
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScaleConfigurator

			' add the line
			Dim line As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line.LineSegmentShape = LineSegmentShape.Line
			line.DataLabelStyle.Visible = False
			line.BorderStyle.Color = DarkOrange
			line.InflateMargins = True
			line.MarkerStyle.Visible = True
			line.MarkerStyle.FillStyle = New NColorFillStyle(Red)
			line.MarkerStyle.BorderStyle = New NStrokeStyle(DarkOrange)
			line.Name = "Line Series"
			line.Legend.Mode = SeriesLegendMode.None

			' add xy values
			line.Values.Add(10)
			line.Values.Add(23)
			line.Values.Add(12)
			line.Values.Add(24)
			line.Values.Add(16)

			' instruct the chart to use them
			line.UseXValues = True
			line.UseZValues = True

			line.XValues.Add(CDbl(Random.Next(10)))
			Dim i As Integer = 1
			Do While i < line.Values.Count
				line.XValues.Add(CDbl(line.XValues(i - 1)) + Random.Next(1,10))
				i += 1
			Loop

			line.ZValues.Add(CDbl(Random.Next(10)))
			i = 1
			Do While i < line.Values.Count
				line.ZValues.Add(CDbl(line.ZValues(i - 1)) + Random.Next(1,10))
				i += 1
			Loop

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub
	End Class
End Namespace
