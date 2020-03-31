Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NXYZScatterBubbleUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XYZ Scatter Bubble Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.Width = 60
			chart.Height = 60
			chart.Depth = 60

			' setup Y axis
			Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			scaleY.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 8)

			' add interlace stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			scaleY.StripStyles.Add(stripStyle)

			' setup X axis
			Dim scaleX As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			scaleX.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 8)
			scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Floor }
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' setup Z axis
			Dim scaleZ As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleZ.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			scaleZ.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 8)
			scaleZ.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Left, ChartWallType.Floor }
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ

			' setup bubble series
			Dim bubble As NBubbleSeries = CType(chart.Series.Add(SeriesType.Bubble), NBubbleSeries)
			bubble.InflateMargins = True
			bubble.DataLabelStyle.Visible = False
			bubble.Legend.Mode = SeriesLegendMode.DataPoints
			bubble.Legend.Format = "<label>"
			bubble.BubbleShape = PointShape.Sphere
			bubble.UseXValues = True
			bubble.UseZValues = True

			GenerateData()

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))
		End Sub

		Private Sub GenerateData()
			Dim bubble As NBubbleSeries = CType(nChartControl1.Charts(0).Series(0), NBubbleSeries)

			bubble.Values.Clear()
			bubble.XValues.Clear()
			bubble.ZValues.Clear()
			bubble.Sizes.Clear()
			bubble.Labels.Clear()

			For i As Integer = 0 To 3
				bubble.Values.Add(Random.NextDouble() * 5)
				bubble.XValues.Add(Random.NextDouble() * 5)
				bubble.ZValues.Add(Random.NextDouble() * 5)
				bubble.Sizes.Add(Random.NextDouble())
				bubble.Labels.Add("Item " & (i + 1).ToString())
			Next i
		End Sub
	End Class
End Namespace
