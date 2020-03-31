Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Text
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Globalization
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.Chart.Functions
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NPowerCumulativeExpAverageUC
		Inherits NExampleUC
		Private nChart As NChart
		Private nFuncCalculator As NFunctionCalculator
		Private nBar As NBarSeries
		Private nLine As NLineSeries

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				' form controls
				FunctionDropDownList.Items.Add("Power")
				FunctionDropDownList.Items.Add("Cumulative")
				FunctionDropDownList.Items.Add("Exponential Average")
				FunctionDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithFloatValues(PowerDropDownList, -3, 3, 0.5f)
				PowerDropDownList.SelectedIndex = 10

				WebExamplesUtilities.FillComboWithFloatValues(ExponentialWeightDropDownList, 0, 1, 0.1f)
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' add header
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Functions")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' align the legend
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.Location = New NPointL(legend.Location.X, New NLength(15, NRelativeUnit.ParentPercentage))
			legend.Data.MarkSize = New NSizeL(5, 5)

			nFuncCalculator = New NFunctionCalculator()

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
			nLine.DataLabelStyle.Format = "<value>"
			nLine.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(7, NGraphicsUnit.Point)
			nLine.MarkerStyle.Visible = True
			nLine.MarkerStyle.Width = New NLength(0.08f, NRelativeUnit.ParentPercentage)
			nLine.MarkerStyle.Height = New NLength(0.08f, NRelativeUnit.ParentPercentage)
			nLine.MarkerStyle.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			nLine.MarkerStyle.FillStyle = New NColorFillStyle(Color.Crimson)
			nLine.BorderStyle.Color = Color.Red
			nLine.BorderStyle.Width = New NLength(2, NGraphicsUnit.Pixel)
			nLine.Legend.Mode = SeriesLegendMode.None
			nLine.Legend.TextStyle = New NTextStyle(New NFontStyle("Arial", 7))
			nLine.Values.ValueFormatter = New NNumericValueFormatter("0.00")

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
			nBar.FillStyle = New NColorFillStyle(Color.CornflowerBlue)
			nBar.Values.FillRandomRange(Random, 10, 0, 10)
			nBar.Legend.TextStyle = New NTextStyle(New NFontStyle("Arial", 7))

			nFuncCalculator.Arguments.Add(nBar.Values)
			nBar.Values.FillRandomRange(Random, 10, 0, 10)


			BuildExpression()
			CalculateFunction()
		End Sub

		Private Sub BuildExpression()
			Dim sb As StringBuilder = New StringBuilder()

			Select Case FunctionDropDownList.SelectedIndex
				Case 0
					PowerDropDownList.Enabled = True
					ExponentialWeightDropDownList.Enabled = False
					sb.AppendFormat(CultureInfo.InvariantCulture, "POW(values; {0})", -3 + (CDbl(PowerDropDownList.SelectedIndex) * 0.5f))
				Case 1
					PowerDropDownList.Enabled = False
					ExponentialWeightDropDownList.Enabled = False
					sb.Append("CUMSUM(values)")
				Case 2
					PowerDropDownList.Enabled = False
					ExponentialWeightDropDownList.Enabled = True
					sb.AppendFormat(CultureInfo.InvariantCulture, "EXPAVG(values; {0})", (CDbl(ExponentialWeightDropDownList.SelectedIndex)) / 10)
			End Select

			nFuncCalculator.Expression = sb.ToString()
			ExpressionTextBox.Text = nFuncCalculator.Expression
		End Sub

		Private Sub CalculateFunction()
			nLine.Values = nFuncCalculator.Calculate()
			nLine.Values.ValueFormatter = New NNumericValueFormatter("0.00")
		End Sub
	End Class
End Namespace
