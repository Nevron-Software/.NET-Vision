Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NEmptyDataPointsUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				' init form controls
				WebExamplesUtilities.FillComboWithEnumValues(MarkerShapeDropDownList, GetType(PointShape))
				MarkerShapeDropDownList.SelectedIndex = 0

				ChartTypeDropDownList.Items.Add("Bar")
				ChartTypeDropDownList.Items.Add("Line")
				ChartTypeDropDownList.Items.Add("Area")
				ChartTypeDropDownList.Items.Add("SmoothLine")
				ChartTypeDropDownList.Items.Add("Point")

				EmptyDataPointsValueModeDropDownList.Items.Add("Skip")
				EmptyDataPointsValueModeDropDownList.Items.Add("Average")
				EmptyDataPointsValueModeDropDownList.Items.Add("CustomValue")
				EmptyDataPointsValueModeDropDownList.SelectedIndex = 0

				EmptyDataPointsAppearanceDropDownList.Items.Add("None")
				EmptyDataPointsAppearanceDropDownList.Items.Add("Normal")
				EmptyDataPointsAppearanceDropDownList.Items.Add("Special")
				EmptyDataPointsAppearanceDropDownList.SelectedIndex = 0

				EmptyDataPointsMarkerModeDropDown.Items.Add("Normal Marker")
				EmptyDataPointsMarkerModeDropDown.Items.Add("Special Marker")

				WebExamplesUtilities.FillComboWithColorNames(EmptyDataPointsColorDropDownList, KnownColor.OrangeRed)
				WebExamplesUtilities.FillComboWithColorNames(MarkerColorDropDownList, KnownColor.OrangeRed)

				ShowMarkersCheckBox.Checked = False
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' add header
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Empty Data Points")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 80.0f
			chart.Height = 70.0f
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.BoundsMode = BoundsMode.Stretch
			chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(75, NRelativeUnit.ParentPercentage))

			' configure the legend
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.FillStyle = New NColorFillStyle(Color.FromArgb(125, 255, 255, 255))

			' turn off legend grid lines
			legend.OuterBottomBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.OuterLeftBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.OuterRightBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.OuterTopBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.VerticalBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.ContentAlignment = ContentAlignment.TopCenter
			legend.Location = New NPointL(New NLength(88, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage))

			UpdateSeriesType()

			Dim series As NSeries = CType(chart.Series(0), NSeries)
			series.MarkerStyle.Visible = ShowMarkersCheckBox.Checked

			' update EDP value mode
			series.Values.EmptyDataPoints.ValueMode = CType(EmptyDataPointsValueModeDropDownList.SelectedIndex, EmptyDataPointsValueMode)
			series.Values.EmptyDataPoints.CustomValue = 0

			' update EDP appearance mode
			series.EmptyDataPointsAppearance.AppearanceMode = CType(EmptyDataPointsAppearanceDropDownList.SelectedIndex, EmptyDataPointsAppearanceMode)

			' update EDP marker mode
			series.EmptyDataPointsAppearance.MarkerMode = CType(EmptyDataPointsMarkerModeDropDown.SelectedIndex, EmptyDataPointsMarkerMode)

			series.EmptyDataPointsAppearance.FillStyle = New NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(EmptyDataPointsColorDropDownList))
			series.EmptyDataPointsAppearance.MarkerStyle.Visible = True
			series.EmptyDataPointsAppearance.MarkerStyle.PointShape = CType(MarkerShapeDropDownList.SelectedIndex, PointShape)
			series.EmptyDataPointsAppearance.MarkerStyle.FillStyle = New NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(MarkerColorDropDownList))
			series.EmptyDataPointsAppearance.MarkerStyle.Width = New NLength(2f, NRelativeUnit.ParentPercentage)
			series.EmptyDataPointsAppearance.MarkerStyle.Depth = New NLength(2f, NRelativeUnit.ParentPercentage)
			series.EmptyDataPointsAppearance.MarkerStyle.Height = New NLength(2f, NRelativeUnit.ParentPercentage)
			series.EmptyDataPointsAppearance.MarkerStyle.AutoDepth = True
		End Sub

		Private Sub UpdateSeriesType()
			Dim seriesType As SeriesType = SeriesType.Bar

			Select Case ChartTypeDropDownList.SelectedIndex
				Case 0
					seriesType = SeriesType.Bar
				Case 1
					seriesType = SeriesType.Line
				Case 2
					seriesType = SeriesType.Area
				Case 3
					seriesType = SeriesType.SmoothLine
				Case 4
					seriesType = SeriesType.Point
			End Select

			Dim chart As NChart = nChartControl1.Charts(0)

			chart.Series.Clear()

			Dim series As NSeries = CType(chart.Series.Add(seriesType), NSeries)
			series.Values.ValueFormatter = New NNumericValueFormatter("0.0")
			series.Legend.Mode = SeriesLegendMode.DataPoints

			GenerateData(series, 10, 3)
		End Sub

		Private Sub GenerateData(ByVal series As NSeries, ByVal nTotalCount As Integer, ByVal nMaxEmptyCount As Integer)
			Dim arrEmptyIndices As SortedList = New SortedList()

			Dim i As Integer = 0
			Do While i < nMaxEmptyCount
				Dim nEmptyIndex As Integer = Random.Next(0, nTotalCount)
				arrEmptyIndices(nEmptyIndex) = Nothing
				i += 1
			Loop

			Dim k As Integer = 0
			Do While k < nTotalCount
				If arrEmptyIndices.ContainsKey(k) Then
					series.Values.Add(DBNull.Value)
				Else
					series.Values.Add(Random.NextDouble() * 10)
				End If
				k += 1
			Loop
		End Sub
	End Class
End Namespace
