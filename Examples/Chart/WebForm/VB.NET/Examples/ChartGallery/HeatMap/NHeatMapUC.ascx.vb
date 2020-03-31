Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Web.UI
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NHeatMapUC
		Inherits NExampleUC
		Private Const m_SizeX As Integer = 200
		Private Const m_SizeY As Integer = 200

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = New NLabel("Heat Map")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
			title.DockMode = PanelDockMode.Top
			title.Margins = New NMarginsL(0, 5, 0, 0)
			nChartControl1.Panels.Add(title)

			Dim legend As NLegend = New NLegend()
			legend.DockMode = PanelDockMode.Right
			legend.Margins = New NMarginsL(0, 5, 5, 0)
			legend.FitAlignment = ContentAlignment.TopCenter
			nChartControl1.Panels.Add(legend)

			Dim chart As NCartesianChart = New NCartesianChart()
			nChartControl1.Panels.Add(chart)

			chart.DisplayOnLegend = legend
			chart.DockMode = PanelDockMode.Fill
			chart.BoundsMode = BoundsMode.Stretch
			chart.Margins = New NMarginsL(5)

			' create the heat map (will be updated on timer tick)
			Dim heatMap As NHeatMapSeries = New NHeatMapSeries()
			heatMap.Data.SetGridSize(m_SizeX, m_SizeY)
			heatMap.Data.SetValues(Double.NaN)
			heatMap.Legend.Mode = SeriesLegendMode.SeriesLogic ' used to display palette information
			heatMap.Legend.PaletteLegendMode = PaletteLegendMode.GradientAxis
			heatMap.Legend.PaletteScaleStepMode = PaletteScaleStepMode.SynchronizeWithScaleConfigurator
			heatMap.Legend.PaletteLength = New NLength(170)

			Dim numericScale As NNumericScaleConfigurator = TryCast(heatMap.Legend.PaletteScaleConfigurator, NNumericScaleConfigurator)
			numericScale.MajorTickMode = MajorTickMode.CustomStep
			numericScale.CustomStep = 10

			heatMap.Palette.Mode = PaletteMode.AutoMinMaxColor
			heatMap.Palette.PositiveColor = Color.FromArgb(125, Color.Red)
			heatMap.Palette.ZeroColor = Color.FromArgb(125, Color.Blue)
			heatMap.Palette.SmoothPalette = True

			chart.Series.Add(heatMap)

			' add background image
			Dim range As NRangeSeries = New NRangeSeries()
			range.UseXValues = True
			range.DataLabelStyle.Visible = False
			range.Legend.Mode = SeriesLegendMode.None

			range.Values.Add(0)
			range.Y2Values.Add(m_SizeY)

			range.XValues.Add(0)
			range.X2Values.Add(m_SizeX)

			Dim bitmap As Bitmap = New Bitmap(Me.MapPathSecure(Me.TemplateSourceDirectory & "/USMap.png"))
			range.FillStyle = New NImageFillStyle(bitmap)
			chart.Series.Add(range)

			' then create some dummy data
			CreateDymmyData(heatMap)
		End Sub

		Private Sub CreateDymmyData(ByVal heatMap As NHeatMapSeries)
			Dim rand As Random = New Random()
			Dim heatZones As List(Of NHeatZone) = New List(Of NHeatZone)()
			Dim maxTemperature As Double = 70

			Do While heatZones.Count < 50
				Dim x As Integer = 0
				Dim y As Integer = 0
				Select Case rand.Next(4)
					Case 0
						' left
						x = - CInt(Fix(maxTemperature)) / 2 + 1
						y = rand.Next(m_SizeY)
					Case 1
						' top
						x = rand.Next(m_SizeX)
						y = -CInt(Fix(maxTemperature)) / 2 + 1
					Case 2
						' right
						x = m_SizeX - CInt(Fix(maxTemperature)) / 2 - 1
						y = rand.Next(m_SizeY)
					Case 3
						' bottom
						x = rand.Next(m_SizeX)
						y = +CInt(Fix(maxTemperature)) / 2 - 1
				End Select

				' if no more heat zones -> create new ones
				Dim heatZone As NHeatZone = New NHeatZone(x, y, maxTemperature)

				Do
					heatZone.m_DX = rand.Next(4) - 2
					heatZone.m_DY = rand.Next(4) - 2
				Loop While heatZone.m_DX = 0 AndAlso heatZone.m_DY = 0

				heatZones.Add(heatZone)
			Loop

			' gets the values
			heatMap.Data.SetValues(Double.NaN)
			Dim values As Double() = heatMap.Data.Values

			For i As Integer = heatZones.Count - 1 To 0 Step -1
				Dim heatZone As NHeatZone = heatZones(i)

				Dim radius As Integer = heatZone.m_Radius

				' move the heat zone
				heatZone.m_X += heatZone.m_DX
				heatZone.m_Y += heatZone.m_DY

				Dim removeZone As Boolean = False

				If heatZone.m_X < -radius Then
					removeZone = True
				ElseIf heatZone.m_X >= m_SizeX + radius Then
					removeZone = True
				End If

				If heatZone.m_Y < -radius Then
					removeZone = True
				ElseIf heatZone.m_Y >= m_SizeX + radius Then
					removeZone = True
				End If

				If removeZone Then
					heatZones.RemoveAt(i)
				Else
					Dim centerX As Integer = heatZone.m_X
					Dim centerY As Integer = heatZone.m_Y

					Dim startX As Integer = Math.Max(0, centerX - radius)
					Dim startY As Integer = Math.Max(0, centerY - radius)

					Dim endX As Integer = Math.Min(m_SizeX - 1, centerX + radius)
					Dim endY As Integer = Math.Min(m_SizeY - 1, centerY + radius)

					Dim x As Integer = startX
					Do While x <= endX
						Dim y As Integer = startY
						Do While y <= endY
							Dim value As Double = heatZone.m_Temperature - 2 * Math.Sqrt(Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2))

							If value >= 0 Then
								Dim index As Integer = y * m_SizeX + x
								Dim curValue As Double = values(index)

								If Double.IsNaN(curValue) Then
									values(index) = value
								Else
									curValue += value

									If curValue > maxTemperature Then
										curValue = maxTemperature
									End If

									values(index) = curValue
								End If
							End If
							y += 1
						Loop
						x += 1
					Loop
				End If
			Next i

			heatMap.Data.OnDataChanged()
		End Sub

		Private Class NHeatZone
			#Region "Constructors"

			''' <summary>
			''' Initializer constructor
			''' </summary>
			''' <param name="x"></param>
			''' <param name="y"></param>
			''' <param name="temperature"></param>
			Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal temperature As Double)
				m_X = x
				m_Y = y
				m_Temperature = temperature
				m_Radius = CInt(Fix(Math.Max(1, m_Temperature / 2)))
			End Sub

			#End Region

			#Region "Fields"

			Public m_Temperature As Double
			Public m_Radius As Integer
			Public m_X As Integer
			Public m_Y As Integer

			Public m_DX As Integer
			Public m_DY As Integer

			#End Region
		End Class
	End Class
End Namespace