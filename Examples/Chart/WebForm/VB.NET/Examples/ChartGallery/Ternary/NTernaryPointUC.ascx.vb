Imports Microsoft.VisualBasic
Imports Nevron.Chart
Imports Nevron.GraphicsCore
Imports System
Imports System.Drawing

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NTernaryPointUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumNames(PointShapeDropDownList, GetType(PointShape))
				DifferentColorsCheckBox.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Ternary Point Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim ternaryChart As NTernaryChart = New NTernaryChart()
			nChartControl1.Panels.Add(ternaryChart)

			ConfigureAxis(ternaryChart.Axis(StandardAxis.TernaryA))
			ConfigureAxis(ternaryChart.Axis(StandardAxis.TernaryB))
			ConfigureAxis(ternaryChart.Axis(StandardAxis.TernaryC))

			Dim point As NTernaryPointSeries = New NTernaryPointSeries()
			ternaryChart.Series.Add(point)

			' setup point series
			point.Name = "Ternary Point Series"
			point.Shape = CType(PointShapeDropDownList.SelectedIndex, PointShape)

			Dim rand As Random = New Random()
			For i As Integer = 0 To 19
				' will be automatically normalized so that the sum of a, b, c value is 100
				Dim aValue As Double = rand.Next(100)
				Dim bValue As Double = rand.Next(100)
				Dim cValue As Double = rand.Next(100)

				point.AValues.Add(aValue)
				point.BValues.Add(bValue)
				point.CValues.Add(cValue)
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