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
	Public Partial Class NAutoLabelsClusterStackBarUC
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
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Cluster Stack Bar Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)

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

			Dim dataPointSafeguardSize As NSizeL = New NSizeL(New NLength(1.3f, NRelativeUnit.ParentPercentage), New NLength(1.3f, NRelativeUnit.ParentPercentage))

			' series 1
			Dim series1 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			series1.Name = "Bar 1"
			series1.FillStyle = New NColorFillStyle(DarkOrange)
			series1.DataLabelStyle.Visible = True
			series1.DataLabelStyle.VertAlign = VertAlign.Center
			series1.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(8)

			' series 2
			Dim series2 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			series2.Name = "Bar 2"
			series2.MultiBarMode = MultiBarMode.Stacked
			series2.FillStyle = New NColorFillStyle(Green)
			series2.DataLabelStyle.Visible = True
			series2.DataLabelStyle.VertAlign = VertAlign.Center
			series2.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(8)

			' series 3
			Dim series3 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			series3.Name = "Bar 3"
			series3.MultiBarMode = MultiBarMode.Clustered
			series3.FillStyle = New NColorFillStyle(Red)
			series3.DataLabelStyle.Visible = True
			series3.DataLabelStyle.VertAlign = VertAlign.Top
			series3.DataLabelStyle.ArrowLength = New NLength(10)
			series3.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(8)

			' generate random data
			GenerateData(chart)

			' enable initial labels positioning
			chart.LabelLayout.EnableInitialPositioning = EnableInitialPositioningCheckBox.Checked

			' enable label adjustment
			chart.LabelLayout.EnableLabelAdjustment = EnableLabelAdjustmentCheckBox.Checked

			' series 1 data points must not be overlapped
			series1.LabelLayout.EnableDataPointSafeguard = True
			series1.LabelLayout.DataPointSafeguardSize = dataPointSafeguardSize

			' do not use label location proposals for series 1
			series1.LabelLayout.UseLabelLocations = False

			' series 2 data points must not be overlapped
			series2.LabelLayout.EnableDataPointSafeguard = True
			series2.LabelLayout.DataPointSafeguardSize = dataPointSafeguardSize

			' do not use label location proposals for series 2
			series2.LabelLayout.UseLabelLocations = False

			' series 3 data points must not be overlapped
			series3.LabelLayout.EnableDataPointSafeguard = True
			series3.LabelLayout.DataPointSafeguardSize = dataPointSafeguardSize

			' series 3 data labels can be placed above and below the origin point
			series3.LabelLayout.UseLabelLocations = True
			series3.LabelLayout.LabelLocations = New LabelLocation() { LabelLocation.Top, LabelLocation.Bottom }
			series3.LabelLayout.InvertLocationsIfIgnored = False
			series3.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)

		End Sub

		Private Sub GenerateData(ByVal chart As NChart)
			Dim randSeed As Integer = Integer.Parse(HiddenField1.Value)
			Dim rand As Random = New Random(randSeed)

			Dim count As Integer = 7

			CType(chart.Series(0), NSeries).Values.FillRandomRange(rand, count, 5.0, 20.0)
			CType(chart.Series(1), NSeries).Values.FillRandomRange(rand, count, 5.0, 20.0)
			CType(chart.Series(2), NSeries).Values.FillRandomRange(rand, count, 10.0, 20.0)
		End Sub


	End Class
End Namespace
