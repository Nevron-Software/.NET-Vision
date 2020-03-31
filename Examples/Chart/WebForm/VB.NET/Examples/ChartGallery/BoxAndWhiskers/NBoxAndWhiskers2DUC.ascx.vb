Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports Nevron.Collections
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NBoxAndWhiskers2DUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithValues(BoxWidthDropDownList, 0, 100, 10)
				BoxWidthDropDownList.SelectedIndex = 7

				WebExamplesUtilities.FillComboWithValues(WhiskersWidthDropDownList, 0, 100, 10)
				WhiskersWidthDropDownList.SelectedIndex = 5

				LeftAxisRoundToTickCheckBox.Checked = True
				InflateMarginsCheckBox.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Box and Whiskers")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch
			chart.Axis(StandardAxis.Depth).Visible = False

			' add interlaced stripe
			Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.RoundToTickMin = LeftAxisRoundToTickCheckBox.Checked
			scaleY.RoundToTickMax = LeftAxisRoundToTickCheckBox.Checked

			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.StripStyles.Add(stripStyle)

			' setup series
			Dim series As NBoxAndWhiskersSeries = CType(chart.Series.Add(SeriesType.BoxAndWhiskers), NBoxAndWhiskersSeries)
			series.DataLabelStyle.Visible = False
			series.FillStyle = New NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant4, Red, DarkOrange)
			series.OutliersBorderStyle = New NStrokeStyle(GreyBlue)
			series.OutliersFillStyle = New NColorFillStyle(Red)
			series.OutliersSize = New NLength(1.4f, NRelativeUnit.ParentPercentage)
			series.MedianStrokeStyle = New NStrokeStyle(Color.Indigo)
			series.AverageStrokeStyle = New NStrokeStyle(1, Color.DarkRed, LinePattern.Dot)
			series.BoxWidthPercent = BoxWidthDropDownList.SelectedIndex * 10
			series.WhiskersWidthPercent = WhiskersWidthDropDownList.SelectedIndex * 10
			series.InflateMargins = InflateMarginsCheckBox.Checked

			GenerateData(series, 7)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Sub GenerateData(ByVal series As NBoxAndWhiskersSeries, ByVal nCount As Integer)
			series.ClearDataPoints()
			Dim random As Random = New Random()

			Dim i As Integer = 0
			Do While i < nCount
				Dim boxLower As Double = 1000 + Random.NextDouble() * 200
				Dim boxUpper As Double = boxLower + 200 + Random.NextDouble() * 200
				Dim whiskersLower As Double = boxLower - (20 + Random.NextDouble() * 300)
				Dim whiskersUpper As Double = boxUpper + (20 + Random.NextDouble() * 300)

				Dim IQR As Double = (boxUpper - boxLower)
				Dim median As Double = boxLower + IQR * 0.25 + Random.NextDouble() * IQR * 0.5
				Dim average As Double = boxLower + IQR * 0.25 + Random.NextDouble() * IQR * 0.5

				series.UpperBoxValues.Add(boxUpper)
				series.LowerBoxValues.Add(boxLower)
				series.UpperWhiskerValues.Add(whiskersUpper)
				series.LowerWhiskerValues.Add(whiskersLower)
				series.MedianValues.Add(median)
				series.AverageValues.Add(average)

				Dim outliersCount As Integer = Random.Next(5)

				Dim outliers As NDoubleList = New NDoubleList()

				Dim k As Integer = 0
				Do While k < outliersCount
					Dim dOutlier As Double = 0

					If Random.NextDouble() > 0.5 Then
						dOutlier = boxUpper + IQR * 1.5 + Random.NextDouble() * 100
					Else
						dOutlier = boxLower - IQR * 1.5 - Random.NextDouble() * 100
					End If

					outliers.Add(dOutlier)
					k += 1
				Loop

				series.OutlierValues.Add(outliers)
				i += 1
			Loop
		End Sub
	End Class
End Namespace
