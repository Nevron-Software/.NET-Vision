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
	Public Partial Class NMultiSeriesLineUC
		Inherits NExampleUC

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithPercents(LineDepthDropDownList, 10)
				LineDepthDropDownList.SelectedIndex = 3
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Multi Series Line")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 70
			chart.Height = 30
			chart.Depth = 50
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' setup X axis
			Dim ordinalScaleConfigurator As NOrdinalScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScaleConfigurator.DisplayDataPointsBetweenTicks = False
			ordinalScaleConfigurator.MajorTickMode = MajorTickMode.AutoMaxCount
			ordinalScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			ordinalScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Floor }

			' add the first line
			Dim line1 As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line1.MultiLineMode = MultiLineMode.Series
			line1.LineSegmentShape = LineSegmentShape.Tape
			line1.Legend.TextStyle.FontStyle.EmSize = New NLength(8)
			line1.DataLabelStyle.Visible = False
			line1.Name = "Line1"

			' add the second line
			Dim line2 As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line2.MultiLineMode = MultiLineMode.Series
			line2.LineSegmentShape = LineSegmentShape.Tape
			line2.Legend.TextStyle.FontStyle.EmSize = New NLength(8)
			line2.DataLabelStyle.Visible = False
			line2.Name = "Line2"

			' add the third line
			Dim line3 As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line3.MultiLineMode = MultiLineMode.Series
			line3.LineSegmentShape = LineSegmentShape.Tape
			line3.Legend.TextStyle.FontStyle.EmSize = New NLength(8)
			line3.DataLabelStyle.Visible = False
			line3.Name = "Line3"

			' fill with random data
			line1.Values.FillRandom(Random, 7)
			line2.Values.FillRandom(Random, 7)
			line3.Values.FillRandom(Random, 7)

			line1.DepthPercent = LineDepthDropDownList.SelectedIndex * 10
			line2.DepthPercent = LineDepthDropDownList.SelectedIndex * 10
			line3.DepthPercent = LineDepthDropDownList.SelectedIndex * 10

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))
		End Sub
	End Class
End Namespace
