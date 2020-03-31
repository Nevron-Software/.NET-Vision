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
	Public Partial Class NXYZScatterStackUC
		Inherits NExampleUC
		Private Const nItemsCount As Integer = 6

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XYZ Scatter Stack")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 50
			chart.Height = 35
			chart.Depth = 50
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.Projection.Elevation += 5

			' setup Y axis
			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add interlaced stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left }
			linearScaleConfigurator.StripStyles.Add(stripStyle)

			' setup X axis
			linearScaleConfigurator = New NLinearScaleConfigurator()
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Back, ChartWallType.Floor }
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleConfigurator

			' setup Z axis
			linearScaleConfigurator = New NLinearScaleConfigurator()
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Left, ChartWallType.Floor }
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScaleConfigurator

			AddBarSeries(chart, MultiBarMode.Series, "Bar1")
			AddBarSeries(chart, MultiBarMode.Stacked, "Bar2")
			AddBarSeries(chart, MultiBarMode.Stacked, "Bar3")
			AddBarSeries(chart, MultiBarMode.Stacked, "Bar4")

			GenerateData()

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))
		End Sub

		Private Sub AddBarSeries(ByVal chart As NChart, ByVal mode As MultiBarMode, ByVal name As String)
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = name
			bar.MultiBarMode = mode
			bar.UseXValues = True
			bar.UseZValues = True
			bar.DataLabelStyle.Visible = False
			bar.InflateMargins = True
			bar.Legend.TextStyle.FontStyle.EmSize = New NLength(8, NGraphicsUnit.Point)
		End Sub

		Private Sub GenerateData()
			Dim chart As NChart = nChartControl1.Charts(0)

			Dim i As Integer = 0
			Do While i < chart.Series.Count
				Dim bar As NBarSeries = CType(chart.Series(i), NBarSeries)

				If i = 0 Then
					' the master series needs Y, X and Z values
					GenerateXYZData(bar)
				Else
					' the other series need only Y values
					GenerateYData(bar)
				End If
				i += 1
			Loop
		End Sub

		Private Sub GenerateXYZData(ByVal bar As NBarSeries)
			bar.Values.Clear()
			bar.XValues.Clear()
			bar.ZValues.Clear()

			For i As Integer = 0 To nItemsCount - 1
				bar.Values.Add(Random.NextDouble())
				bar.XValues.Add(Random.NextDouble() * 5)
				bar.ZValues.Add(Random.NextDouble() * 5)
			Next i
		End Sub

		Private Sub GenerateYData(ByVal bar As NBarSeries)
			bar.Values.Clear()

			For i As Integer = 0 To nItemsCount - 1
				bar.Values.Add(Random.NextDouble())
			Next i
		End Sub
	End Class
End Namespace
