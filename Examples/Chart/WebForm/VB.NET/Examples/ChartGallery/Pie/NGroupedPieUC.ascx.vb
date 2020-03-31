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
	Public Partial Class NGroupedPieUC
		Inherits NExampleUC
		Private Shared ReadOnly arrLabels As String() = New String() { "Cars", "Trains", "Airplanes", "Buses", "Bikes", "Motorcycles", "Shuttles", "Rollers", "Ski", "Surf" }

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithColorNames(GroupedPieColorDropDownList)
				GroupedPieColorDropDownList.SelectedIndex = 20

				' init form controls
				ThresholdValueTextBox.Text = "34"
				GroupedPieLabelTextBox.Text = "Other"
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Grouped Pie Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.ContentAlignment = ContentAlignment.BottomRight
			title.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup legend
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.OuterBottomBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.OuterLeftBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.OuterRightBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.OuterTopBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.FillStyle.SetTransparencyPercent(70)
			legend.HorizontalBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.VerticalBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)

			' by default the control contains a Cartesian chart -> remove it and create a Pie chart
			Dim chart As NChart = New NPieChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(chart)

			chart.Enable3D = True
			chart.DisplayOnLegend = nChartControl1.Legends(0)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated)
			chart.BoundsMode = BoundsMode.Fit
			chart.Location = New NPointL(New NLength(20, NRelativeUnit.ParentPercentage), New NLength(20, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(60, NRelativeUnit.ParentPercentage), New NLength(60, NRelativeUnit.ParentPercentage))

			' setup pie series
			Dim pie As NPieSeries = CType(chart.Series.Add(SeriesType.Pie), NPieSeries)
			pie.Legend.Mode = SeriesLegendMode.None
			pie.PieStyle = PieStyle.SmoothEdgePie

			Dim count As Integer = 10
			pie.Values.FillRandomRange(Random, count, 1, 100)

			Dim i As Integer = 0
			Do While i < count
				pie.Detachments.Add(0)
				pie.Labels.Add(arrLabels(i))
				pie.FillStyles(i) = arrCustomColors2(i Mod arrCustomColors2.Length)
				i += 1
			Loop

			If GroupPiesCheckBox.Checked = True Then
				Try
					Dim groupColor As Color = WebExamplesUtilities.ColorFromDropDownList(GroupedPieColorDropDownList)
					Dim dGroupValue As Double = Int32.Parse(ThresholdValueTextBox.Text)

					' get a subset containing the pies which are smaller than the specified value
					Dim smallerThanValue As NDataSeriesSubset = pie.Values.Filter(Nevron.Chart.CompareMethod.Less, dGroupValue)

					' determine the sum of the filtered pies
					Dim dOtherSliceValue As Double = pie.Values.Evaluate("SUM", smallerThanValue)

					' remove the data points contained in the 
					For i = pie.GetDataPointCount() To 0 Step -1
						If smallerThanValue.Contains(i) Then
							pie.RemoveDataPointAt(i)
						End If
					Next i

					' add a detached pie with the specified group label and color
					Dim dp As NDataPoint = New NDataPoint(dOtherSliceValue, GroupedPieLabelTextBox.Text)
					dp(DataPointValue.PieDetachment) = 1.0
					dp(DataPointValue.FillStyle) = New NColorFillStyle(groupColor)
					dp(DataPointValue.StrokeStyle) = New NStrokeStyle(1, groupColor)
					pie.AddDataPoint(dp)
				Catch
				End Try
			Else
			End If
		End Sub
	End Class
End Namespace
