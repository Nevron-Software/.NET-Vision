Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.Functions
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NCountStdDevRmsUC
		Inherits NExampleUC
		Private nChart As NChart
		Private nFuncCalculator As NFunctionCalculator
		Private nBar As NBarSeries

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				' form controls
				FunctionDropDownList.Items.Add("Count")
				FunctionDropDownList.Items.Add("Standard Deviation")
				FunctionDropDownList.Items.Add("Root Mean Square")
				FunctionDropDownList.SelectedIndex = 0
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

			' add a constline to diplay the function result
			Dim cl As NAxisConstLine = nChart.Axis(StandardAxis.PrimaryY).ConstLines.Add()
			cl.StrokeStyle.Width = New NLength(2, NGraphicsUnit.Pixel)
			cl.StrokeStyle.Color = Color.Red
			cl.Value = 0

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
			nBar.FillStyle = New NColorFillStyle(Color.DarkSeaGreen)
			nBar.Values.FillRandomRange(Random, 10, 0, 20)
			nBar.Legend.TextStyle = New NTextStyle(New NFontStyle("Arial", 7))

			' add argument
			nFuncCalculator.Arguments.Add(nBar.Values)
			nBar.Values.FillRandomRange(Random, 10, 0, 20)


			BuildExpression()
			CalculateFunction()
		End Sub

		Private Sub BuildExpression()
			Select Case FunctionDropDownList.SelectedIndex
				Case 0
					nFuncCalculator.Expression = "COUNT(values)"
				Case 1
					nFuncCalculator.Expression = "STDDEV(values)"
				Case 2
					nFuncCalculator.Expression = "POW(AVERAGE(POW(values; 2)); 0.5)"
			End Select

			ExpressionTextBox.Text = nFuncCalculator.Expression
		End Sub

		Private Sub CalculateFunction()
			Dim cl As NAxisConstLine = nChart.Axis(StandardAxis.PrimaryY).ConstLines(0)

			Dim ds As NDataSeriesDouble = nFuncCalculator.Calculate()

			cl.Value = CDbl(ds.GetValueForIndex(0))

			ResultTextBox.Text = cl.Value.ToString()
		End Sub
	End Class
End Namespace
