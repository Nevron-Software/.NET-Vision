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
	Public Partial Class NAdvancedHighLowUC
		Inherits NExampleUC

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				HighLabelTextBox.Text = "High"
				LowLabelTextBox.Text = "Low"
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XY High-Low")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' configure chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' setup X axis
			Dim scaleX As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX
			scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' setup Y axis
			Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add interlace stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Back, ChartWallType.Left }
			scaleY.StripStyles.Add(stripStyle)

			' create the series
			Dim highLow As NHighLowSeries = CType(chart.Series.Add(SeriesType.HighLow), NHighLowSeries)
			highLow.Name = "High-Low Series"
			highLow.DataLabelStyle.Format = "<high_label><low_label>"
			highLow.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(7)
			highLow.HighFillStyle = New NColorFillStyle(Color.LightSlateGray)
			highLow.LowFillStyle = New NColorFillStyle(Color.DarkOrange)
			highLow.ShadowStyle.Type = ShadowType.GaussianBlur
			highLow.UseXValues = True

			highLow.HighLabel = HighLabelTextBox.Text
			highLow.LowLabel = LowLabelTextBox.Text

			' fill values
			GenerateValuesY(highLow, 8)
			GenerateValuesX(highLow, 8)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Sub GenerateValuesY(ByVal highLow As NHighLowSeries, ByVal nCount As Integer)
			Dim dPhase1 As Double = Random.Next(5)
			Dim dPhase2 As Double = dPhase1 + 1

			highLow.HighValues.Clear()
			highLow.LowValues.Clear()

			Dim i As Integer = 0
			Do While i < nCount
				Dim d1 As Double = 10 + Math.Sin(dPhase1 + 0.8 * i) + 0.5 * Random.NextDouble()
				Dim d2 As Double = 10 + Math.Cos(dPhase2 + 0.8 * i) + 0.5 * Random.NextDouble()

				highLow.HighValues.Add(d1)
				highLow.LowValues.Add(d2)
				i += 1
			Loop
		End Sub
		Private Sub GenerateValuesX(ByVal highLow As NHighLowSeries, ByVal nCount As Integer)
			highLow.XValues.Clear()

			Dim dValue As Double = CDbl(Random.Next(100))

			Dim i As Integer = 0
			Do While i < nCount
				highLow.XValues.Add(dValue)

				dValue = dValue + Random.Next(5, 10)
				i += 1
			Loop
		End Sub

	End Class
End Namespace
