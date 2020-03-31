Imports Microsoft.VisualBasic
Imports Nevron.Chart
Imports Nevron.GraphicsCore
Imports System
Imports System.Drawing

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NTernaryBubbleUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumNames(BubbleShapeDropDownList, GetType(PointShape))
				DifferentColorsCheckBox.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Ternary Bubble Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim ternaryChart As NTernaryChart = New NTernaryChart()
			nChartControl1.Panels.Add(ternaryChart)

			ConfigureAxis(ternaryChart.Axis(StandardAxis.TernaryA))
			ConfigureAxis(ternaryChart.Axis(StandardAxis.TernaryB))
			ConfigureAxis(ternaryChart.Axis(StandardAxis.TernaryC))

			' add a bubble series
			Dim bubbleSeries As NTernaryBubbleSeries = New NTernaryBubbleSeries()
			ternaryChart.Series.Add(bubbleSeries)
			bubbleSeries.DataLabelStyle.VertAlign = VertAlign.Center
			bubbleSeries.DataLabelStyle.Visible = False
			bubbleSeries.Legend.Mode = SeriesLegendMode.DataPoints
			bubbleSeries.MinSize = New NLength(2.0f, NGraphicsUnit.Point)
			bubbleSeries.MaxSize = New NLength(20, NGraphicsUnit.Point)
			bubbleSeries.Legend.Mode = SeriesLegendMode.DataPoints
			bubbleSeries.Legend.Format = "<size>"
			bubbleSeries.Shape = CType(BubbleShapeDropDownList.SelectedIndex, PointShape)

			Dim rand As Random = New Random()
			For i As Integer = 0 To 19
				' will be automatically normalized so that the sum of a, b, c value is 100
				Dim aValue As Double = rand.Next(100)
				Dim bValue As Double = rand.Next(100)
				Dim cValue As Double = rand.Next(100)

				bubbleSeries.AValues.Add(aValue)
				bubbleSeries.BValues.Add(bValue)
				bubbleSeries.CValues.Add(cValue)
				bubbleSeries.Sizes.Add(10 + rand.Next(90))
			Next i


			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, ternaryChart, title, Nothing)

			If DifferentColorsCheckBox.Checked Then
				' apply style sheet
				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
				styleSheet.Apply(nChartControl1.Document)
			Else
				' apply style sheet
				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
				styleSheet.Apply(nChartControl1.Document)
			End If
		End Sub

		Private Sub ConfigureAxis(ByVal axis As NAxis)
			Dim linearScale As NLinearScaleConfigurator = TryCast(axis.ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.FromArgb(25, Color.Beige)), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Ternary, True)
			linearScale.StripStyles.Add(stripStyle)

			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Ternary, True)
		End Sub
	End Class
End Namespace