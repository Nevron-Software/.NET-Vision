Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Web.UI
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NHeatMapContourLabelsUC
		Inherits NExampleUC
		Private Const m_SizeX As Integer = 200
		Private Const m_SizeY As Integer = 200

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = New NLabel("Heat Map - Contour")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
			title.DockMode = PanelDockMode.Top
			title.Margins = New NMarginsL(0, 5, 0, 0)
			nChartControl1.Panels.Add(title)

			Dim chart As NCartesianChart = New NCartesianChart()
			nChartControl1.Panels.Add(chart)

			chart.DockMode = PanelDockMode.Fill
			chart.BoundsMode = BoundsMode.Stretch
			chart.Margins = New NMarginsL(5)

			' create the heat map 
			Dim heatMap As NHeatMapSeries = New NHeatMapSeries()
			chart.Series.Add(heatMap)

			heatMap.Palette.Add(0.0, Color.Purple)
			heatMap.Palette.Add(1.5, Color.MediumSlateBlue)
			heatMap.Palette.Add(3.0, Color.CornflowerBlue)
			heatMap.Palette.Add(4.5, Color.LimeGreen)
			heatMap.Palette.Add(6.0, Color.LightGreen)
			heatMap.Palette.Add(7.5, Color.Yellow)
			heatMap.Palette.Add(9.0, Color.Orange)
			heatMap.Palette.Add(10.5, Color.Red)
			heatMap.XValuesMode = HeatMapValuesMode.OriginAndStep
			heatMap.YValuesMode = HeatMapValuesMode.OriginAndStep

			heatMap.ContourDisplayMode = ContourDisplayMode.Contour
			heatMap.Legend.Mode = SeriesLegendMode.SeriesLogic
			heatMap.Legend.Format = "<zone_value>"

			GenerateData(heatMap)

			' update chart control from form controls
			heatMap.ContourLabelStyle.Visible = ShowContourLabelsCheckBox.Checked
			heatMap.ContourLabelStyle.AllowLabelToFlip = AllowLabelsToFlipCheckBox.Checked
			heatMap.ContourLabelStyle.TextStyle.BackplaneStyle.Visible = ShowLabelBackgroundCheckBox.Checked
			heatMap.ContourLabelStyle.ClipContour = ClipContourCheckBox.Checked
		End Sub

		Private Sub GenerateData(ByVal heatMap As NHeatMapSeries)
			Dim data As NHeatMapData = heatMap.Data

			Dim GridStepX As Integer = 300
			Dim GridStepY As Integer = 300
			data.SetGridSize(GridStepX, GridStepY)

			Const dIntervalX As Double = 10.0
			Const dIntervalZ As Double = 10.0
			Dim dIncrementX As Double = (dIntervalX / GridStepX)
			Dim dIncrementZ As Double = (dIntervalZ / GridStepY)

			Dim y, x, z As Double

			z = -(dIntervalZ / 2)

			Dim col As Integer = 0
			Do While col < GridStepX
				x = -(dIntervalX / 2)

				Dim row As Integer = 0
				Do While row < GridStepY
					y = 10 - Math.Sqrt((x * x) + (z * z) + 2)
					y += 3.0 * Math.Sin(x) * Math.Cos(z)

					Dim value As Double = y

					data.SetValue(row, col, value)
					row += 1
					x += dIncrementX
				Loop
				col += 1
				z += dIncrementZ
			Loop
		End Sub
	End Class
End Namespace