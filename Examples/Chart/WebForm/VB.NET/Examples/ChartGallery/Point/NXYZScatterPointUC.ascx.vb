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
	Public Partial Class NXYZScatterPointUC
		Inherits NExampleUC

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			' switch to OpenGL rendering
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XYZ Scatter Point Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 50
			chart.Depth = 50
			chart.Height = 50
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			chart.Projection.Type = ProjectionType.Perspective
			chart.Projection.Elevation = 25
			chart.Projection.Rotation = -18

			' setup Y axis
			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScaleConfigurator.RoundToTickMin = AxesRoundToTickCheckBox.Checked
			linearScaleConfigurator.RoundToTickMax = AxesRoundToTickCheckBox.Checked
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 8)

			' add interlace stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScaleConfigurator.StripStyles.Add(stripStyle)

			' setup X axis
			linearScaleConfigurator = New NLinearScaleConfigurator()
			linearScaleConfigurator.RoundToTickMin = AxesRoundToTickCheckBox.Checked
			linearScaleConfigurator.RoundToTickMax = AxesRoundToTickCheckBox.Checked
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 8)
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Back, ChartWallType.Floor }

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleConfigurator

			' setup Z axis
			linearScaleConfigurator = New NLinearScaleConfigurator()
			linearScaleConfigurator.RoundToTickMin = AxesRoundToTickCheckBox.Checked
			linearScaleConfigurator.RoundToTickMax = AxesRoundToTickCheckBox.Checked
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 8)
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Left, ChartWallType.Floor }
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScaleConfigurator

			' setup point series
			Dim point As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			point.Name = "Point1"
			point.InflateMargins = InflateMarginsCheckBox.Checked
			point.DataLabelStyle.Visible = False
			point.Legend.Mode = SeriesLegendMode.None
			point.PointShape = PointShape.Bar
			point.BorderStyle.Color = Color.AliceBlue
			point.Size = New NLength(3, NRelativeUnit.ParentPercentage)
			point.UseXValues = True
			point.UseZValues = True

			' init the chart with some random values
			point.Values.FillRandomRange(Random, 10, -50, 50)
			point.XValues.FillRandomRange(Random, 10, -50, 50)
			point.ZValues.FillRandomRange(Random, 10, -50, 50)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub
	End Class
End Namespace
