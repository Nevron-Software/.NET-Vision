Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Web.UI
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NTriangulatedHeatMapUC
		Inherits NExampleUC
		Private Const m_SizeX As Integer = 200
		Private Const m_SizeY As Integer = 200

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = New NLabel("Triangulated Heat Map")
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

			Dim scaleX As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleX.RoundToTickMin = False
			scaleX.RoundToTickMax = False
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			Dim scaleY As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleY.RoundToTickMin = False
			scaleY.RoundToTickMax = False
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY

			' create a point series (used to show the incoming points XY values)
			Dim point As NPointSeries = New NPointSeries()
			chart.Series.Add(point)
			point.UseXValues = True
			point.BorderStyle.Width = New NLength(0)
			point.FillStyle = New NColorFillStyle(Color.Black)
			point.Size = New NLength(2)
			point.DataLabelStyle.Visible = False

			' create the heat map 
			Dim heatMap As NTriangulatedHeatMapSeries = New NTriangulatedHeatMapSeries()
			chart.Series.Add(heatMap)

			heatMap.Palette.Add(0.0, Color.Purple)
			heatMap.Palette.Add(1.5, Color.MediumSlateBlue)
			heatMap.Palette.Add(3.0, Color.CornflowerBlue)
			heatMap.Palette.Add(4.5, Color.LimeGreen)
			heatMap.Palette.Add(6.0, Color.LightGreen)
			heatMap.Palette.Add(7.5, Color.Yellow)
			heatMap.Palette.Add(9.0, Color.Orange)
			heatMap.Palette.Add(10.5, Color.Red)

			heatMap.ContourDisplayMode = ContourDisplayMode.Contour
			heatMap.Legend.Mode = SeriesLegendMode.SeriesLogic
			heatMap.Legend.Format = "<zone_value>"

			GenerateData(point, heatMap)
		End Sub
		''' <summary>
		''' Generates random data
		''' </summary>
		''' <param name="pointSeries"></param>
		''' <param name="heatMapSeries"></param>
		Private Sub GenerateData(ByVal pointSeries As NPointSeries, ByVal heatMapSeries As NTriangulatedHeatMapSeries)
			Dim points As NPointD() = New NPointD() { New NPointD(0.1, 0.1), New NPointD(1.5, 1.0), New NPointD(2.5, 5), New NPointD(4, 0), New NPointD(2.5, 3.4), New NPointD(1.3, 5) }
			Dim pointsIntensity As Double() = New Double() { 30, 10, 30, 20, 40, 20 }

			Dim rand As Random = New Random()

			For x As Double = 0.0 To 5 Step 0.5
				For y As Double = 0.0 To 5 Step 0.5
					Dim pointX As Double
					Dim pointY As Double

					If x = 0 OrElse y = 0 OrElse x = 5 OrElse y = 5 Then
						pointX = x
						pointY = y
					Else
						pointX = x + rand.NextDouble() * 0.2
						pointY = y + rand.NextDouble() * 0.2
					End If

					Dim intensity As Double = 0
					Dim i As Integer = 0
					Do While i < points.Length
						Dim dx As Double = points(i).X - pointX
						Dim dy As Double = points(i).Y - pointY

						Dim distance As Double = Math.Sqrt(dx * dx + dy * dy)
						intensity += pointsIntensity(i) / (1 + distance * distance)
						i += 1
					Loop

					heatMapSeries.Values.Add(intensity)
					heatMapSeries.XValues.Add(pointX)
					heatMapSeries.YValues.Add(pointY)
				Next y
			Next x

			pointSeries.Values.AddRange(heatMapSeries.YValues)
			pointSeries.XValues.AddRange(heatMapSeries.XValues)
		End Sub
	End Class
End Namespace