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
	Public Partial Class NMultiSeriesAreaUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Multi Series Area Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 70
			chart.Height = 30
			chart.Depth = 50
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' setup Y axis
			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left }
			linearScaleConfigurator.StripStyles.Add(stripStyle)

			' setup X axis
			Dim ordinalScaleConfigurator As NOrdinalScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScaleConfigurator.DisplayDataPointsBetweenTicks = False
			ordinalScaleConfigurator.MajorTickMode = MajorTickMode.AutoMaxCount
			ordinalScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			ordinalScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Back, ChartWallType.Floor }

			' setup Z axis
			ordinalScaleConfigurator = CType(chart.Axis(StandardAxis.Depth).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			ordinalScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Left, ChartWallType.Floor }

			' add the first Area
			Dim area1 As NAreaSeries = CType(chart.Series.Add(SeriesType.Area), NAreaSeries)
			area1.Name = "Area 1"
			area1.MultiAreaMode = MultiAreaMode.Series
			area1.DataLabelStyle.Visible = False
			area1.Legend.TextStyle.FontStyle.EmSize = New NLength(8)

			' add the second Area
			Dim area2 As NAreaSeries = CType(chart.Series.Add(SeriesType.Area), NAreaSeries)
			area2.Name = "Area 2"
			area2.MultiAreaMode = MultiAreaMode.Series
			area2.DataLabelStyle.Visible = False
			area2.Legend.TextStyle.FontStyle.EmSize = New NLength(8)

			' add the third Area
			Dim area3 As NAreaSeries = CType(chart.Series.Add(SeriesType.Area), NAreaSeries)
			area3.Name = "Area 3"
			area3.MultiAreaMode = MultiAreaMode.Series
			area3.DataLabelStyle.Visible = False
			area3.Legend.TextStyle.FontStyle.EmSize = New NLength(8)

			' fill with random data
			area1.Values.FillRandomRange(Random, 10, 10, 40)
			area2.Values.FillRandomRange(Random, 10, 30, 60)
			area3.Values.FillRandomRange(Random, 10, 50, 80)

			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithPercents(AreaDepthDropDownList, 10)

				AreaDepthDropDownList.SelectedIndex = 5
			End If

			' modify the depth percent
			area1.DepthPercent = WebExamplesUtilities.GetPercentFromCombo(AreaDepthDropDownList, 10)
			area2.DepthPercent = WebExamplesUtilities.GetPercentFromCombo(AreaDepthDropDownList, 10)
			area3.DepthPercent = WebExamplesUtilities.GetPercentFromCombo(AreaDepthDropDownList, 10)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))
		End Sub
	End Class
End Namespace

