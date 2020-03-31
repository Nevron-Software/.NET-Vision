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
	Public Partial Class NAutoLabelsRadarUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				EnableInitialPositioningCheckBox.Checked = True
				EnableLabelAdjustmentCheckBox.Checked = True
				StackRadarAreasCheckBox.Checked = False

				HiddenField1.Value = Random.Next().ToString()
			End If

			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Radar Area Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomRight
			title.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' configure the chart
			Dim chart As NRadarChart = New NRadarChart()
			chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(5, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(90, NRelativeUnit.ParentPercentage))
			nChartControl1.Charts.Add(chart)

			AddRadarAxis(chart, "Category A")
			AddRadarAxis(chart, "Category B")
			AddRadarAxis(chart, "Category C")
			AddRadarAxis(chart, "Category D")
			AddRadarAxis(chart, "Category E")
			AddRadarAxis(chart, "Category F")
			AddRadarAxis(chart, "Category G")

			' radar area series 1
			Dim series1 As NRadarAreaSeries = CType(chart.Series.Add(SeriesType.RadarArea), NRadarAreaSeries)
			series1.FillStyle = New NColorFillStyle(DarkOrange)
			series1.BorderStyle.Color = DarkOrange
			series1.DataLabelStyle.Visible = True
			series1.DataLabelStyle.VertAlign = VertAlign.Top
			series1.DataLabelStyle.ArrowStrokeStyle.Color = DarkOrange
			series1.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = DarkOrange
			series1.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(8)

			' radar area series 2
			Dim series2 As NRadarAreaSeries = CType(chart.Series.Add(SeriesType.RadarArea), NRadarAreaSeries)
			series2.FillStyle = New NColorFillStyle(Red)
			series2.BorderStyle.Color = Red
			series2.BorderStyle.Width = New NLength(0)
			series2.DataLabelStyle.Visible = True
			series2.DataLabelStyle.VertAlign = VertAlign.Top
			series2.DataLabelStyle.ArrowStrokeStyle.Color = Red
			series2.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = Red
			series2.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(8)

			' stack / unstack the second radar area series
			If StackRadarAreasCheckBox.Checked Then
				series2.MultiAreaMode = MultiAreaMode.Stacked
			Else
				series2.MultiAreaMode = MultiAreaMode.Series
			End If

			' label layout settings
			chart.LabelLayout.EnableInitialPositioning = EnableInitialPositioningCheckBox.Checked
			chart.LabelLayout.EnableLabelAdjustment = EnableLabelAdjustmentCheckBox.Checked

			Dim safeguardSize As NSizeL = New NSizeL(New NLength(1.3f, NRelativeUnit.ParentPercentage), New NLength(1.3f, NRelativeUnit.ParentPercentage))

			series1.LabelLayout.EnableDataPointSafeguard = True
			series1.LabelLayout.UseLabelLocations = True
			series1.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds
			series1.LabelLayout.InvertLocationsIfIgnored = False
			series1.LabelLayout.DataPointSafeguardSize = safeguardSize

			series2.LabelLayout.EnableDataPointSafeguard = True
			series2.LabelLayout.UseLabelLocations = True
			series2.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds
			series2.LabelLayout.InvertLocationsIfIgnored = False
			series2.LabelLayout.DataPointSafeguardSize = safeguardSize

			' fill with random data
			GenerateData(series1, series2)
		End Sub

		Private Sub AddRadarAxis(ByVal chart As NRadarChart, ByVal title As String)
			Dim axis As NRadarAxis = New NRadarAxis()

			' set title
			axis.Title = title

			' the axis scale should start from 0
			axis.View = New NRangeAxisView(New NRange1DD(0, 0), True, False)

			' setup scale
			Dim linearScale As NLinearScaleConfigurator = CType(axis.ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.RulerStyle.BorderStyle.Color = Color.Silver
			linearScale.InnerMajorTickStyle.LineStyle.Color = Color.Silver
			linearScale.OuterMajorTickStyle.LineStyle.Color = Color.Silver
			linearScale.InnerMajorTickStyle.Length = New NLength(2, NGraphicsUnit.Point)
			linearScale.OuterMajorTickStyle.Length = New NLength(2, NGraphicsUnit.Point)

			If chart.Axes.Count = 0 Then
				' if the first axis then configure grid style and stripes
				linearScale.MajorGridStyle.LineStyle.Color = Color.Gainsboro
				linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
				linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Radar, True)

				' add interlaced stripe
				Dim strip As NScaleStripStyle = New NScaleStripStyle()
				strip.FillStyle = New NColorFillStyle(Color.FromArgb(64, 200, 200, 200))
				strip.Interlaced = True
				strip.SetShowAtWall(ChartWallType.Radar, True)
				linearScale.StripStyles.Add(strip)
			Else
				' hide labels
				linearScale.AutoLabels = False
			End If

			chart.Axes.Add(axis)
		End Sub

		Private Sub GenerateData(ByVal series0 As NSeries, ByVal series1 As NSeries)
			Dim randSeed As Integer = Integer.Parse(HiddenField1.Value)
			Dim rand As Random = New Random(randSeed)

			series0.Values.FillRandomRange(rand, 7, 30.0, 80.0)
			series1.Values.FillRandomRange(rand, 7, 20.0, 60.0)
		End Sub

	End Class
End Namespace
