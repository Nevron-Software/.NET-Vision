Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NParetoUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumValues(BarShapeDropDownList, GetType(BarShape))
				BarShapeDropDownList.SelectedIndex = 0
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Pareto Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' setup the X axis
			Dim axisX As NAxis = chart.Axis(StandardAxis.PrimaryX)
			Dim scaleX As NOrdinalScaleConfigurator = CType(axisX.ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX.InnerMajorTickStyle.Visible = False

			' setup the primary Y axis
			Dim axisY1 As NAxis = chart.Axis(StandardAxis.PrimaryY)
			Dim scaleY1 As NLinearScaleConfigurator = CType(axisY1.ScaleConfigurator, NLinearScaleConfigurator)
			scaleY1.InnerMajorTickStyle.Visible = False
			scaleY1.Title.Text = "Number of Occurences"

			' add interlaced stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			scaleY1.StripStyles.Add(stripStyle)

			' setup the secondary Y axis
			Dim scaleY2 As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleY2.LabelValueFormatter = New NNumericValueFormatter("0%")
			scaleY2.InnerMajorTickStyle.Visible = False
			scaleY2.Title.Text = "Cumulative Percent"
			Dim axisY2 As NAxis = chart.Axis(StandardAxis.SecondaryY)
			axisY2.Visible = True
			axisY2.ScaleConfigurator = scaleY2
			axisY2.View = New NRangeAxisView(New NRange1DD(0, 1), True, True)

			' add a line series for the cumulative value
			Dim line As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line.Name = "Cumulative"
			line.MarkerStyle.Visible = True
			line.MarkerStyle.PointShape = PointShape.Cylinder
			line.DataLabelStyle.Visible = False
			line.DisplayOnAxis(StandardAxis.PrimaryY, False)
			line.DisplayOnAxis(StandardAxis.SecondaryY, True)

			' add a bar series
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Bar Series"
			bar.DataLabelStyle.Visible = False
			bar.InflateMargins = True
			bar.BarShape = CType(BarShapeDropDownList.SelectedIndex, BarShape)

			' fill with random data and sort in descending order
			bar.Values.FillRandom(Random, 10)
			bar.Values.Sort(DataSeriesSortOrder.Descending)

			' calculate cumulative sum of the bar values
			Dim count As Integer = bar.Values.Count
			Dim cs As Double = 0
			Dim arrCumulative As Double() = New Double(count - 1){}

			Dim i As Integer = 0
			Do While i < count
				cs += bar.Values.GetDoubleValue(i)
				arrCumulative(i) = cs
				i += 1
			Loop

			If cs > 0 Then
				i = 0
				Do While i < count
					arrCumulative(i) /= cs
					i += 1
				Loop

				line.Values.AddRange(arrCumulative)
			End If

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub
	End Class
End Namespace
