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
	Public Partial Class NManhattanBarUC
		Inherits NExampleUC
		Protected nChart As NChart
		Protected nBar1 As NBarSeries
		Protected nBar2 As NBarSeries
		Protected nBar3 As NBarSeries

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Manhattan Bar Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			nChart = nChartControl1.Charts(0)
			nChart.Enable3D = True
			nChart.Width = 70
			nChart.Height = 40
			nChart.Depth = 50
			nChart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			nChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' setup Y axis
			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(nChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add interlaced stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left }
			linearScaleConfigurator.StripStyles.Add(stripStyle)

			' setup X axis
			Dim ordinalScaleConfigurator As NOrdinalScaleConfigurator = CType(nChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			ordinalScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Back, ChartWallType.Floor }

			' setup Z axis
			ordinalScaleConfigurator = CType(nChart.Axis(StandardAxis.Depth).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			ordinalScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Left, ChartWallType.Floor }
			ordinalScaleConfigurator.MajorTickMode = MajorTickMode.AutoMaxCount

			' add the first bar
			nBar1 = CType(nChart.Series.Add(SeriesType.Bar), NBarSeries)
			nBar1.MultiBarMode = MultiBarMode.Series
			nBar1.Name = "Bar1"
			nBar1.DataLabelStyle.Visible = False
			nBar1.Legend.TextStyle.FontStyle.EmSize = New NLength(8)

			' add the second bar
			nBar2 = CType(nChart.Series.Add(SeriesType.Bar), NBarSeries)
			nBar2.MultiBarMode = MultiBarMode.Series
			nBar2.Name = "Bar2"
			nBar2.DataLabelStyle.Visible = False
			nBar2.Legend.TextStyle.FontStyle.EmSize = New NLength(8)

			' add the third bar
			nBar3 = CType(nChart.Series.Add(SeriesType.Bar), NBarSeries)
			nBar3.MultiBarMode = MultiBarMode.Series
			nBar3.Name = "Bar3"
			nBar3.DataLabelStyle.Visible = False
			nBar3.Legend.TextStyle.FontStyle.EmSize = New NLength(8)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, nChart, title, nChartControl1.Legends(0))

			If IsPostBack Then
				If PositiveDataCheckBox.Checked = True Then
					PositiveDataButton_Click(Nothing, Nothing)
				Else
					PositiveAndNegativeDataButton_Click(Nothing, Nothing)
				End If
			Else
				PositiveDataButton_Click(Nothing, Nothing)
			End If

			AddHandler PositiveDataButton.Click, AddressOf PositiveDataButton_Click
			AddHandler PositiveAndNegativeDataButton.Click, AddressOf PositiveAndNegativeDataButton_Click
		End Sub

		Private Sub PositiveDataButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			nBar1.Values.FillRandomRange(Random, 5, 10, 40)
			nBar2.Values.FillRandomRange(Random, 5, 30, 60)
			nBar3.Values.FillRandomRange(Random, 5, 50, 80)
			PositiveDataCheckBox.Checked = True
		End Sub

		Private Sub PositiveAndNegativeDataButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			nBar1.Values.FillRandomRange(Random, 5, -30, 30)
			nBar2.Values.FillRandomRange(Random, 5, -50, 50)
			nBar3.Values.FillRandomRange(Random, 5, -70, 70)
			PositiveDataCheckBox.Checked = False
		End Sub
	End Class
End Namespace