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
	Public Partial Class NAutoLabelsBarUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				EnableInitialPositioningCheckBox.Checked = True
				RemoveOverlappedLabelsCheckBox.Checked = False
				EnableLabelAdjustmentCheckBox.Checked = True
				LocationProposalsDropDownList.Items.Clear()
				LocationProposalsDropDownList.Items.Add("Top")
				LocationProposalsDropDownList.Items.Add("Top - Bottom")
				LocationProposalsDropDownList.SelectedIndex = 0

				HiddenField1.Value = Random.Next().ToString()
			End If

			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Bar Chart")
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

			' bar series
			Dim series1 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			series1.FillStyle = New NColorFillStyle(DarkOrange)
			series1.DataLabelStyle.Visible = True
			series1.DataLabelStyle.VertAlign = VertAlign.Top
			series1.DataLabelStyle.ArrowLength = New NLength(10)
			series1.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(8)

			' enable / disable initial labels positioning
			chart.LabelLayout.EnableInitialPositioning = EnableInitialPositioningCheckBox.Checked

			' enable / disable removal of overlapped labels after initial positioning
			chart.LabelLayout.RemoveOverlappedLabels = RemoveOverlappedLabelsCheckBox.Checked

			' enable / disable label adjustment
			chart.LabelLayout.EnableLabelAdjustment = EnableLabelAdjustmentCheckBox.Checked

			' use only "top" location for the labels
			series1.LabelLayout.UseLabelLocations = True

			Select Case LocationProposalsDropDownList.SelectedIndex
				Case 0
					series1.LabelLayout.LabelLocations = New LabelLocation() { LabelLocation.Top }

				Case 1
					series1.LabelLayout.LabelLocations = New LabelLocation() { LabelLocation.Top, LabelLocation.Bottom }
			End Select

			series1.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds
			series1.LabelLayout.InvertLocationsIfIgnored = True

			' protect data points from being overlapped
			series1.LabelLayout.EnableDataPointSafeguard = True
			series1.LabelLayout.DataPointSafeguardSize = New NSizeL(New NLength(1.3f, NRelativeUnit.ParentPercentage), New NLength(1.3f, NRelativeUnit.ParentPercentage))

			' fill with random data
			GenerateData(series1)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)

		End Sub

		Private Sub GenerateData(ByVal series As NSeries)
			Dim randSeed As Integer = Integer.Parse(HiddenField1.Value)
			Dim rand As Random = New Random(randSeed)

			series.Values.Clear()

			For i As Integer = 0 To 14
				Dim value As Double = Math.Sin(i * 0.4) * 10 + rand.NextDouble() * 4
				series.Values.Add(value)
			Next i
		End Sub
	End Class
End Namespace
