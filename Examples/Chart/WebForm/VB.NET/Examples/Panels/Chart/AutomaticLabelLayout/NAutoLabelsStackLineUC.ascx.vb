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
	Public Partial Class NAutoLabelsStackLineUC
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
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Stack Line Chart")
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

			' line series 1
			Dim series1 As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			series1.Name = "Line 1"
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

			' line series 2
			Dim series2 As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			series2.Name = "Line 2"
			series2.InflateMargins = True
			series2.MultiLineMode = MultiLineMode.Stacked
			series2.MarkerStyle.Visible = True
			series2.MarkerStyle.FillStyle = New NColorFillStyle(Green)
			series2.MarkerStyle.PointShape = PointShape.Pyramid
			series2.MarkerStyle.Width = New NLength(1.0f, NRelativeUnit.ParentPercentage)
			series2.MarkerStyle.Height = New NLength(1.0f, NRelativeUnit.ParentPercentage)
			series2.DataLabelStyle.Visible = True
			series2.DataLabelStyle.VertAlign = VertAlign.Top
			series2.DataLabelStyle.ArrowLength = New NLength(10)
			series2.DataLabelStyle.ArrowStrokeStyle.Color = Green
			series2.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = Green
			series2.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(8)

			' label layout settings
			chart.LabelLayout.EnableInitialPositioning = EnableInitialPositioningCheckBox.Checked
			chart.LabelLayout.EnableLabelAdjustment = EnableLabelAdjustmentCheckBox.Checked

			Dim safeguardSize As NSizeL = New NSizeL(New NLength(1.6f, NRelativeUnit.ParentPercentage), New NLength(1.6f, NRelativeUnit.ParentPercentage))

			series1.LabelLayout.UseLabelLocations = True
			series1.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds
			series1.LabelLayout.InvertLocationsIfIgnored = True
			series1.LabelLayout.EnableDataPointSafeguard = True
			series1.LabelLayout.DataPointSafeguardSize = safeguardSize

			series2.LabelLayout.UseLabelLocations = True
			series2.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds
			series2.LabelLayout.InvertLocationsIfIgnored = True
			series2.LabelLayout.EnableDataPointSafeguard = True
			series2.LabelLayout.DataPointSafeguardSize = safeguardSize

			' fill with random data
			GenerateData(chart)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Sub GenerateData(ByVal chart As NChart)
			Dim randSeed As Integer = Integer.Parse(HiddenField1.Value)
			Dim rand As Random = New Random(randSeed)

			Dim series0 As NSeries = CType(chart.Series(0), NSeries)
			Dim series1 As NSeries = CType(chart.Series(1), NSeries)

			series0.Values.Clear()
			series1.Values.Clear()

			For i As Integer = 0 To 15
				Dim value As Double = 10 + Math.Sin(i * 0.2) * 10 + rand.NextDouble() * 5
				series0.Values.Add(value)

				value = 10 + Math.Cos(i * 0.4) * 10 + rand.NextDouble() * 5
				series1.Values.Add(value)
			Next i
		End Sub

	End Class
End Namespace
