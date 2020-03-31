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
	Public Partial Class NAutoLabelsPolarUC
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

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Polar Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomRight
			title.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' configure the chart
			Dim chart As NPolarChart = New NPolarChart()
			chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(5, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(90, NRelativeUnit.ParentPercentage))
			nChartControl1.Charts.Add(chart)

			' setup polar value axis
			Dim linearScale As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.Polar).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.RoundToTickMax = True
			linearScale.RoundToTickMin = True
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, True)

			' setup polar angle axis
			Dim angularScale As NAngularScaleConfigurator = CType(chart.Axis(StandardAxis.PolarAngle).ScaleConfigurator, NAngularScaleConfigurator)
			angularScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, True)

			' polar point series
			Dim series1 As NPolarPointSeries = CType(chart.Series.Add(SeriesType.PolarPoint), NPolarPointSeries)
			series1.PointShape = PointShape.Ellipse
			series1.Size = New NLength(2.0f, NRelativeUnit.ParentPercentage)
			series1.InflateMargins = True
			series1.FillStyle = New NColorFillStyle(DarkOrange)

			series1.DataLabelStyle.Visible = True
			series1.DataLabelStyle.VertAlign = VertAlign.Center
			series1.DataLabelStyle.ArrowLength = New NLength(12)
			series1.DataLabelStyle.ArrowStrokeStyle.Color = DarkOrange
			series1.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = DarkOrange
			series1.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(8)

			chart.LabelLayout.EnableInitialPositioning = EnableInitialPositioningCheckBox.Checked
			chart.LabelLayout.RemoveOverlappedLabels = RemoveOverlappedLabelsCheckBox.Checked
			chart.LabelLayout.EnableLabelAdjustment = EnableLabelAdjustmentCheckBox.Checked

			series1.LabelLayout.EnableDataPointSafeguard = EnableDataPointSafeguardCheckBox.Checked

			Dim safeguardSize As Single = CSng(SafeguardSizeDropDownList.SelectedIndex)
			Dim sz As NLength = New NLength(safeguardSize, NGraphicsUnit.Point)
			series1.LabelLayout.DataPointSafeguardSize = New NSizeL(sz, sz)

			series1.LabelLayout.UseLabelLocations = True
			series1.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds
			series1.LabelLayout.InvertLocationsIfIgnored = True

			' fill with random data
			GenerateData(series1)
		End Sub

		Private Sub GenerateData(ByVal series As NPolarPointSeries)
			Dim randSeed As Integer = Integer.Parse(HiddenField1.Value)
			Dim rand As Random = New Random(randSeed)

			series.Values.FillRandomRange(rand, 10, 0.0, 100.0)
			series.Angles.FillRandomRange(rand, 10, 0.0, 360.0)
		End Sub

	End Class
End Namespace
