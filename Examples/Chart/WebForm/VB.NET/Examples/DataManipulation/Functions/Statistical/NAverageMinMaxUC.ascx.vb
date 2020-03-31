Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Text
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.Functions
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NAverageMinMaxUC
		Inherits NExampleUC
		Protected nBar As NBarSeries
		Protected nLine As NLineSeries
		Private nFuncCalculator As NFunctionCalculator
		Protected nChart As NChart

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				FunctionDropDownList.Items.Add("Average")
				FunctionDropDownList.Items.Add("Min")
				FunctionDropDownList.Items.Add("Max")
				FunctionDropDownList.SelectedIndex = 0

				GroupingDropDownList.Items.Add("Do not group")
				GroupingDropDownList.Items.Add("Group by every 2 values")
				GroupingDropDownList.Items.Add("Group by every 3 values")
				GroupingDropDownList.Items.Add("Group by every 4 values")
				GroupingDropDownList.SelectedIndex = 0

				DataDropDownList.Items.Add("Positive")
				DataDropDownList.Items.Add("Positive and Negative")
				DataDropDownList.SelectedIndex = 0
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' add header
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Average, Min, Max")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			nFuncCalculator = New NFunctionCalculator()

			' setup legend
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.Location = New NPointL(legend.Location.X, New NLength(15, NRelativeUnit.ParentPercentage))
			legend.Data.MarkSize = New NSizeL(5,5)

			' setup chart
			nChart = nChartControl1.Charts(0)
			nChart.Enable3D = True
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
			nLine.Legend.Mode = SeriesLegendMode.None
			nLine.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			nLine.DisplayOnAxis(StandardAxis.PrimaryX, False)
			nLine.DisplayOnAxis(StandardAxis.SecondaryX, True)
			nLine.Legend.TextStyle = New NTextStyle(New NFontStyle("Arial", 7))

			' add the bar series
			nBar = CType(nChart.Series.Add(SeriesType.Bar), NBarSeries)
			nBar.Name = "Bar1"
			nBar.Values.Name = "values"
			nBar.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			nBar.MultiBarMode = MultiBarMode.Series
			nBar.DataLabelStyle.Visible = False
			nBar.Legend.Mode = SeriesLegendMode.DataPoints
			nBar.BarShape = BarShape.Cylinder
			nBar.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			nBar.FillStyle = New NColorFillStyle(Color.DarkSalmon)
			nBar.Values.FillRandomRange(Random, 12, 0, 50)
			nBar.Legend.TextStyle = New NTextStyle(New NFontStyle("Arial", 7))

			If DataDropDownList.SelectedIndex = 0 Then
				nBar.Values.FillRandomRange(Random, 12, 0, 50)
			Else
				nBar.Values.FillRandomRange(Random, 12, -25, 25)
			End If

			BuildExpression()
			CalcFunction()
		End Sub

		Private Sub BuildExpression()
			Dim expr As StringBuilder = New StringBuilder()

			' set the beginning of the expression according to the selected function
			Select Case FunctionDropDownList.SelectedIndex
				Case 0
					expr.Append("AVERAGE(")
				Case 1
					expr.Append("MIN(")
				Case 2
					expr.Append("MAX(")
			End Select

			' append the first parameter
			expr.Append(nBar.Values.Name)

			' append the second parameter if needed
			Select Case GroupingDropDownList.SelectedIndex
				Case 0
					expr.Append(")")
				Case 1
					expr.Append("; 2)")
				Case 2
					expr.Append("; 3)")
				Case 3
					expr.Append("; 4)")
			End Select

			ExpressionTextBox.Text = expr.ToString()

			' update the function calculator
			nFuncCalculator.Arguments.Clear()
			nFuncCalculator.Arguments.Add(nBar.Values)
			nFuncCalculator.Expression = ExpressionTextBox.Text
		End Sub

		Private Sub CalcFunction()
			Dim ds As NDataSeriesDouble = nFuncCalculator.Calculate()

			If ds Is Nothing Then
				Return
			End If

			nChart.Axis(StandardAxis.PrimaryY).ConstLines.Clear()
			nLine.Visible = False

			If GroupingDropDownList.SelectedIndex = 0 Then
				' add a constline if there is no grouping
				Dim cl As NAxisConstLine = nChart.Axis(StandardAxis.PrimaryY).ConstLines.Add()
				cl.StrokeStyle.Width = New NLength(2, NGraphicsUnit.Pixel)
				cl.StrokeStyle.Color = Color.Red
				cl.Value = CDbl(ds.GetValueForIndex(0))
			Else
				nLine.Visible = True
				nLine.Values = ds
				nLine.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			End If
		End Sub
	End Class
End Namespace
