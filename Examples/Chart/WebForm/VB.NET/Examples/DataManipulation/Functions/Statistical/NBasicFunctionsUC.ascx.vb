Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Dom
Imports Nevron.Chart
Imports Nevron.Chart.WebForm
Imports Nevron.Chart.Functions


Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NBasicFunctionsUC
		Inherits NExampleUC
		Private funcCalculator As NFunctionCalculator

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				' form controls
				ExpressionDropDownList.Items.Add("ADD(Green; Blue)")
				ExpressionDropDownList.Items.Add("SUB(Green; Blue)")
				ExpressionDropDownList.Items.Add("MUL(Green; Blue)")
				ExpressionDropDownList.Items.Add("DIV(Green; Blue)")
				ExpressionDropDownList.Items.Add("HIGH(Green; Blue)")
				ExpressionDropDownList.Items.Add("LOW(Green; Blue)")
				ExpressionDropDownList.SelectedIndex = 0
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' add header
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Basic functions")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup legend
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.Location = New NPointL(legend.Location.X, New NLength(15, NRelativeUnit.ParentPercentage))
			legend.Data.MarkSize = New NSizeL(5,5)

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre)
			chart.BoundsMode = BoundsMode.Stretch
			chart.Location = New NPointL(New NLength(8, NRelativeUnit.ParentPercentage), New NLength(17, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(75, NRelativeUnit.ParentPercentage), New NLength(75, NRelativeUnit.ParentPercentage))

			chart.Wall(ChartWallType.Left).Visible = False
			chart.Wall(ChartWallType.Floor).Visible = False
			chart.Axis(StandardAxis.Depth).Visible = False

			' add a line series for the function
			Dim line As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line.Name = "Function"
			line.DataLabelStyle.Format = "<value>"
			line.MarkerStyle.PointShape = PointShape.Sphere
			line.MarkerStyle.Visible = True
			line.MarkerStyle.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			line.MarkerStyle.FillStyle = New NColorFillStyle(Color.Crimson)
			line.Legend.Mode = SeriesLegendMode.None
			line.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			line.Legend.TextStyle = New NTextStyle(New NFontStyle("Arial", 7))

			' add the first bar
			Dim bar1 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar1.Name = "Bar1"
			bar1.Values.Name = "Green"
			bar1.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			bar1.MultiBarMode = MultiBarMode.Series
			bar1.DataLabelStyle.Visible = False
			bar1.Legend.Mode = SeriesLegendMode.DataPoints
			bar1.FillStyle = New NColorFillStyle(Color.SeaGreen)
			bar1.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			bar1.BarShape = BarShape.CutEdgeBar
			bar1.Legend.TextStyle = New NTextStyle(New NFontStyle("Arial", 7))

			' add the second bar
			Dim bar2 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar2.Name = "Bar2"
			bar2.Values.Name = "Blue"
			bar2.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			bar2.MultiBarMode = MultiBarMode.Clustered
			bar2.DataLabelStyle.Visible = False
			bar2.Legend.Mode = SeriesLegendMode.DataPoints
			bar2.FillStyle = New NColorFillStyle(Color.CornflowerBlue)
			bar2.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			bar2.BarShape = BarShape.CutEdgeBar
			bar2.Legend.TextStyle = New NTextStyle(New NFontStyle("Arial", 7))

			' fill with random data
			FillDataSeries(bar1.Values, 5)
			FillDataSeries(bar2.Values, 5)

			funcCalculator = New NFunctionCalculator()
			funcCalculator.Arguments.Clear()
			funcCalculator.Arguments.Add(bar1.Values)
			funcCalculator.Arguments.Add(bar2.Values)
			funcCalculator.Expression = ExpressionDropDownList.SelectedItem.Text

			Dim ds As NDataSeriesDouble = funcCalculator.Calculate()

			If ds Is Nothing Then
				line.Values.Clear()
			Else
				line.Values = ds
				line.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			End If
		End Sub

		Private Sub FillDataSeries(ByVal ds As NDataSeriesDouble, ByVal nCount As Integer)
			ds.Clear()

			Dim i As Integer = 0
			Do While i < nCount
				ds.Add(Random.NextDouble() * 3)
				i += 1
			Loop
		End Sub
	End Class
End Namespace
