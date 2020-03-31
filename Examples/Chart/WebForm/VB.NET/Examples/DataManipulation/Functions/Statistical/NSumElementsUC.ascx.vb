Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Text
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Chart.Functions
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NSumElementsUC
		Inherits NExampleUC

		Private nChart As NChart
		Private nFuncCalculator As NFunctionCalculator
		Private nBar As NBarSeries
		Private nLine As NLineSeries

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' add header
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Sum of Data Points")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup legend
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.Location = New NPointL(legend.Location.X, New NLength(15, NRelativeUnit.ParentPercentage))
			legend.Data.MarkSize = New NSizeL(5, 5)

			nChart = nChartControl1.Charts(0)
			nChart.Enable3D = True
			nFuncCalculator = New NFunctionCalculator()

			If (Not IsPostBack) Then
				' form controls
				GroupingDropDownList.Items.Add("Do not group")
				GroupingDropDownList.Items.Add("Group by every 2 values")
				GroupingDropDownList.Items.Add("Group by every 3 values")
				GroupingDropDownList.Items.Add("Group by every 4 values")
				GroupingDropDownList.SelectedIndex = 0

				DataDropDownList.Items.Add("Positive")
				DataDropDownList.Items.Add("Positive and Negative")
				DataDropDownList.SelectedIndex = 0
			End If


			' setup chart
			nChart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			nChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre)
			nChart.BoundsMode = BoundsMode.Stretch
			nChart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			nChart.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(75, NRelativeUnit.ParentPercentage))

			nChart.Axis(StandardAxis.Depth).Visible = False
			nChart.Wall(ChartWallType.Left).Visible = False
			nChart.Wall(ChartWallType.Floor).Visible = False

			' setup X axis
			Dim ordinalScale As NOrdinalScaleConfigurator = CType(nChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.DisplayDataPointsBetweenTicks = False

			' add a line series for the function
			nLine = CType(nChart.Series.Add(SeriesType.Line), NLineSeries)
			nLine.MarkerStyle.Visible = True
			nLine.MarkerStyle.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			nLine.MarkerStyle.FillStyle = New NColorFillStyle(Color.Crimson)
			nLine.BorderStyle.Color = Color.Red
			nLine.BorderStyle.Width = New NLength(2, NGraphicsUnit.Pixel)
			nLine.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			nLine.DisplayOnAxis(StandardAxis.PrimaryX, False)
			nLine.DisplayOnAxis(StandardAxis.SecondaryX, True)
			nLine.Legend.Mode = SeriesLegendMode.None
			nLine.Legend.TextStyle = New NTextStyle(New NFontStyle("Arial", 7))

			' add the bar series
			nBar = CType(nChart.Series.Add(SeriesType.Bar), NBarSeries)
			nBar.Name = "Bar1"
			nBar.Values.Name = "values"
			nBar.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			nBar.MultiBarMode = MultiBarMode.Series
			nBar.DataLabelStyle.Visible = False
			nBar.Legend.Mode = SeriesLegendMode.DataPoints
			nBar.BarShape = BarShape.SmoothEdgeBar
			nBar.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			nBar.FillStyle = New NColorFillStyle(Color.Orange)
			nBar.Legend.TextStyle = New NTextStyle(New NFontStyle("Arial", 7))

			If DataDropDownList.SelectedIndex = 0 Then
				nBar.Values.FillRandomRange(Random, 12, 0, 50)
			Else
				nBar.Values.FillRandomRange(Random, 12, -25, 25)
			End If


			' set the function argument
			nFuncCalculator.Arguments.Add(nBar.Values)
			CalcFunction()
		End Sub

		Private Sub CalcFunction()
			Dim sb As StringBuilder = New StringBuilder("SUM(values")

			Select Case GroupingDropDownList.SelectedIndex
				Case 0
					sb.Append(")")
				Case 1
					sb.Append("; 2)")
				Case 2
					sb.Append("; 3)")
				Case 3
					sb.Append("; 4)")
			End Select

			nFuncCalculator.Expression = sb.ToString()
			ExpressionTextBox.Text = nFuncCalculator.Expression

			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(nChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			If GroupingDropDownList.SelectedIndex = 0 Then
				' draw a constline if there is no grouping
				SetConstline()
			Else
				' otherwise use the line series
				nChart.Axis(StandardAxis.PrimaryY).ConstLines.Clear()

				nLine.Values = nFuncCalculator.Calculate()
				nLine.Values.ValueFormatter = New NNumericValueFormatter("0.00")
				nLine.Visible = True

				SumTextBox.Text = ""
			End If
		End Sub

		Private Sub SetConstline()
			Dim axis As NAxis = nChart.Axis(StandardAxis.PrimaryY)

			' add a constline if necessary
			If axis.ConstLines.Count = 0 Then
				axis.ConstLines.Add()
			End If

			' the line series won't be used
			nLine.Visible = False

			' calc the sum of the elements
			Dim ds As NDataSeriesDouble = nFuncCalculator.Calculate()

			' add a new constline
			Dim cl As NAxisConstLine = axis.ConstLines(0)
			cl.StrokeStyle.Width = New NLength(2, NGraphicsUnit.Pixel)
			cl.StrokeStyle.Color = Color.Red
			cl.Value = CDbl(ds.GetValueForIndex(0))

			SumTextBox.Text = cl.Value.ToString()

			' set proper range for the axis, so that it includes the constline
			If cl.Value >= 0 Then
				' if the sum is positive - compare it to the largest value
				nFuncCalculator.Expression = "MAX(values)"
				ds = nFuncCalculator.Calculate()

				Dim dMax As Double = CDbl(ds.GetValueForIndex(0))

				If cl.Value > dMax Then
					dMax = cl.Value
				End If

				axis.View = New NRangeAxisView(New NRange1DD(0, dMax), False, True)
			Else
				' if the sum is negative - compare it to the smallest value
				nFuncCalculator.Expression = "MIN(values)"
				ds = nFuncCalculator.Calculate()

				Dim dMin As Double = CDbl(ds.GetValueForIndex(0))

				If cl.Value < dMin Then
					dMin = cl.Value
				End If

				axis.View = New NRangeAxisView(New NRange1DD(dMin, 0), True, False)
			End If
		End Sub
	End Class
End Namespace
