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
	Public Partial Class NAutoLabelsXYPointUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				EnableInitialPositioningCheckBox.Checked = True
				RemoveOverlappedLabelsCheckBox.Checked = False
				EnableLabelAdjustmentCheckBox.Checked = True
				EnableDataPointSafeguardCheckBox.Checked = True

				WebExamplesUtilities.FillComboWithValues(SafeguardSizeDropDownList, 0, 20, 1)
				SafeguardSizeDropDownList.SelectedIndex = 12

				HiddenField1.Value = Random.Next().ToString()
			End If

			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XY Point Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)

			' configure X axis
			Dim scaleX As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
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

			' point series 1
			Dim series1 As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			series1.Name = "Point 1"
			series1.PointShape = PointShape.Ellipse
			series1.Size = New NLength(1.7f, NRelativeUnit.ParentPercentage)
			series1.UseXValues = True
			series1.InflateMargins = True
			series1.FillStyle = New NColorFillStyle(DarkOrange)
			series1.DataLabelStyle.Visible = True
			series1.DataLabelStyle.VertAlign = VertAlign.Center
			series1.DataLabelStyle.ArrowLength = New NLength(10)
			series1.DataLabelStyle.ArrowStrokeStyle.Color = DarkOrange
			series1.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = DarkOrange
			series1.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(8)

			' point series 2
			Dim series2 As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			series2.Name = "Point 2"
			series2.PointShape = PointShape.Ellipse
			series2.Size = New NLength(1.7f, NRelativeUnit.ParentPercentage)
			series2.UseXValues = True
			series2.InflateMargins = True
			series2.FillStyle = New NColorFillStyle(Green)
			series2.DataLabelStyle.Visible = True
			series2.DataLabelStyle.VertAlign = VertAlign.Center
			series2.DataLabelStyle.ArrowLength = New NLength(10)
			series2.DataLabelStyle.ArrowStrokeStyle.Color = Green
			series2.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = Green
			series2.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(8)

			' label layout settings
			chart.LabelLayout.EnableInitialPositioning = EnableInitialPositioningCheckBox.Checked
			chart.LabelLayout.RemoveOverlappedLabels = RemoveOverlappedLabelsCheckBox.Checked
			chart.LabelLayout.EnableLabelAdjustment = EnableLabelAdjustmentCheckBox.Checked

			series1.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds
			series1.LabelLayout.InvertLocationsIfIgnored = True
			series2.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds
			series2.LabelLayout.InvertLocationsIfIgnored = True

			' enable / disable data point safeguard size for both series
			series1.LabelLayout.EnableDataPointSafeguard = EnableDataPointSafeguardCheckBox.Checked
			series2.LabelLayout.EnableDataPointSafeguard = EnableDataPointSafeguardCheckBox.Checked

			' set data point safeguard size for both series
			Dim sizeValue As Single = CSng(SafeguardSizeDropDownList.SelectedIndex)
			Dim size As NSizeL = New NSizeL(New NLength(sizeValue, NGraphicsUnit.Point), New NLength(sizeValue, NGraphicsUnit.Point))
			series1.LabelLayout.DataPointSafeguardSize = size
			series2.LabelLayout.DataPointSafeguardSize = size

			' fill with random data 
			GenerateData(chart)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)

		End Sub

		Private Sub GenerateData(ByVal chart As NChart)
			Dim randSeed As Integer = Integer.Parse(HiddenField1.Value)
			Dim rand As Random = New Random(randSeed)

			Dim series0 As NPointSeries = CType(chart.Series(0), NPointSeries)
			Dim series1 As NPointSeries = CType(chart.Series(1), NPointSeries)

			Const count As Integer = 12

			series0.Values.FillRandomRange(rand, count, 0, 50)
			series0.XValues.FillRandomRange(rand, count, 0, 50)

			series1.Values.FillRandomRange(rand, count, 25, 75)
			series1.XValues.FillRandomRange(rand, count, 25, 75)
		End Sub

	End Class
End Namespace
