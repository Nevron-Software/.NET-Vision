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
	Public Partial Class NAutoLabelsLineUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				EnableInitialPositioningCheckBox.Checked = True
				EnableLabelAdjustmentCheckBox.Checked = True

				HiddenField1.Value = Random.Next().ToString()
			End If

			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Line Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)

			' configure X axis
			Dim scaleX As NOrdinalScaleConfigurator = New NOrdinalScaleConfigurator()
			scaleX.DisplayDataPointsBetweenTicks = False
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' configure Y axis
			Dim scaleY As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY

			' add interlaced stripe for Y axis
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.StripStyles.Add(stripStyle)

			' line series
			Dim series1 As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			series1.InflateMargins = True
			series1.MarkerStyle.Visible = True
			series1.MarkerStyle.FillStyle = New NColorFillStyle(DarkOrange)
			series1.MarkerStyle.PointShape = PointShape.Ellipse
			series1.MarkerStyle.Width = New NLength(1.0f, NRelativeUnit.ParentPercentage)
			series1.MarkerStyle.Height = New NLength(1.0f, NRelativeUnit.ParentPercentage)

			series1.DataLabelStyle.Visible = True
			series1.DataLabelStyle.VertAlign = VertAlign.Top
			series1.DataLabelStyle.ArrowLength = New NLength(10)
			series1.DataLabelStyle.ArrowStrokeStyle.Color = DarkOrange
			series1.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = DarkOrange
			series1.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(8)

			chart.LabelLayout.EnableInitialPositioning = EnableInitialPositioningCheckBox.Checked
			chart.LabelLayout.EnableLabelAdjustment = EnableLabelAdjustmentCheckBox.Checked

			series1.LabelLayout.EnableDataPointSafeguard = True
			series1.LabelLayout.DataPointSafeguardSize = New NSizeL(New NLength(1.6f, NRelativeUnit.ParentPercentage), New NLength(1.6f, NRelativeUnit.ParentPercentage))
			series1.LabelLayout.UseLabelLocations = True
			series1.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds
			series1.LabelLayout.InvertLocationsIfIgnored = True

			' fill with random data
			GenerateData(series1)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)

		End Sub

		Private Sub GenerateData(ByVal series As NSeries)
			Dim randSeed As Integer = Integer.Parse(HiddenField1.Value)
			Dim rand As Random = New Random(randSeed)

			series.Values.Clear()

			For i As Integer = 0 To 19
				Dim value As Double = Math.Sin(i * 0.3) * 10 + rand.NextDouble() * 2
				series.Values.Add(value)
			Next i
		End Sub

	End Class
End Namespace
