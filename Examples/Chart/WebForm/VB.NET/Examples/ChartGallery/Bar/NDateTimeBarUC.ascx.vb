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
	Public Partial Class NDateTimeBarUC
		Inherits NExampleUC
		Private Const nValuesCount As Integer = 10

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Date Time Bars")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)

			' setup Y axis
			Dim linearScale As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add interlace stripe to the Y axis
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			linearScale.StripStyles.Add(stripStyle)

			' setup X axis
			Dim timeScale As NDateTimeScaleConfigurator = New NDateTimeScaleConfigurator()
			timeScale.MaxTickCount = 5
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = timeScale

			' setup bar series
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Bar Series"
			bar.InflateMargins = True
			bar.UseXValues = True
			bar.UseZValues = False
			bar.DataLabelStyle.Visible = False
			bar.ShadowStyle.Type = ShadowType.Solid
			bar.ShadowStyle.Color = Color.FromArgb(30, 0, 0, 0)

			GenreateYValues(nValuesCount)
			GenreateXValues(nValuesCount)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Sub GenreateYValues(ByVal nCount As Integer)
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim bar As NBarSeries = CType(chart.Series(0), NBarSeries)

			bar.Values.Clear()

			Dim i As Integer = 0
			Do While i < nCount
				bar.Values.Add(Random.NextDouble() * 20)
				i += 1
			Loop
		End Sub

		Private Sub GenreateXValues(ByVal nCount As Integer)
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim bar As NBarSeries = CType(chart.Series(0), NBarSeries)

			bar.XValues.Clear()

			Dim dt As DateTime = New DateTime(2005, 5, 24, 11, 0, 0)

			Dim i As Integer = 0
			Do While i < nCount
				dt = dt.AddHours(12 + Random.NextDouble() * 60)
				bar.XValues.Add(dt)
				i += 1
			Loop
		End Sub
	End Class
End Namespace
