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
	Public Partial Class NOverlappedLineUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Overlapped Line")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.Axis(StandardAxis.Depth).Visible = False

			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScaleConfigurator.MajorGridStyle.LineStyle.Color = Color.LightGray

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScaleConfigurator.StripStyles.Add(stripStyle)

			linearScaleConfigurator = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleConfigurator

			' setup series
			Dim line1 As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line1.Name = "Line 1"
			line1.MultiLineMode = MultiLineMode.Series
			line1.LineSegmentShape = LineSegmentShape.Tape
			line1.DataLabelStyle.Visible = False

			Dim line2 As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line2.Name = "Line 2"
			line2.MultiLineMode = MultiLineMode.Overlapped
			line2.LineSegmentShape = LineSegmentShape.Tape
			line2.DataLabelStyle.Visible = False

			Dim line3 As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line3.Name = "Line 3"
			line3.MultiLineMode = MultiLineMode.Overlapped
			line3.LineSegmentShape = LineSegmentShape.Tape
			line3.DataLabelStyle.Visible = False

			For i As Integer = 0 To 49
				Dim x As Double = (i / 6.0)
				line1.Values.Add(0.5 + Math.Sin(x) / 2.0)
				line2.Values.Add(0.5 + Math.Cos(x) / 4.0)
				line3.Values.Add(Math.Cos(x) * Math.Sin(x) / 5.0 + Random.NextDouble() / 8.0)
			Next i

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))
		End Sub
	End Class
End Namespace
