Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.Chart
Imports Nevron.GraphicsCore
Imports Nevron.UI

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Partial Public Class NHeatMapUC
		Inherits NExampleBaseUC

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing
		Private WithEvents timer1 As Timer

		Private m_HeatZones As New List(Of NHeatZone)()
		Private m_Rand As New Random()
		Private m_HeatMap As NHeatMapSeries
		Private m_MaxTemperature As Double = 70
		Private m_SizeX As Integer = 200
		Private WithEvents StartStopTimerButton As Nevron.UI.WinForm.Controls.NButton
		Private m_SizeY As Integer = 200

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If

				If timer1 IsNot Nothing Then
					timer1.Stop()
					RemoveHandler timer1.Tick, AddressOf OnTimerTick
					timer1.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.timer1 = New System.Windows.Forms.Timer(Me.components)
			Me.StartStopTimerButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' timer1
			' 
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.timer1.Tick += new System.EventHandler(this.OnTimerTick);
			' 
			' StartStopTimerButton
			' 
			Me.StartStopTimerButton.Location = New System.Drawing.Point(16, 15)
			Me.StartStopTimerButton.Name = "StartStopTimerButton"
			Me.StartStopTimerButton.Size = New System.Drawing.Size(120, 23)
			Me.StartStopTimerButton.TabIndex = 0
			Me.StartStopTimerButton.Text = "Stop Timer"
			Me.StartStopTimerButton.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StartStopTimerButton.Click += new System.EventHandler(this.StartStopTimerButton_Click);
			' 
			' NHeatMapUC
			' 
			Me.Controls.Add(Me.StartStopTimerButton)
			Me.Name = "NHeatMapUC"
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("Heat Map")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			Dim chart As NChart = nChartControl1.Charts(0)

			chart.BoundsMode = BoundsMode.Stretch

			' create the heat map (will be updated on timer tick)
			m_HeatMap = New NHeatMapSeries()
			m_HeatMap.Data.SetGridSize(m_SizeX, m_SizeY)
			m_HeatMap.Data.SetValues(Double.NaN)
			m_HeatMap.Legend.Mode = SeriesLegendMode.SeriesLogic ' used to display palette information
			m_HeatMap.Legend.PaletteLegendMode = PaletteLegendMode.GradientAxis
			m_HeatMap.Legend.PaletteScaleStepMode = PaletteScaleStepMode.SynchronizeWithScaleConfigurator
			m_HeatMap.Legend.PaletteLength = New NLength(400)

			Dim numericScale As NNumericScaleConfigurator = TryCast(m_HeatMap.Legend.PaletteScaleConfigurator, NNumericScaleConfigurator)
			numericScale.MajorTickMode = MajorTickMode.CustomStep
			numericScale.CustomStep = 10

			m_HeatMap.Palette.Mode = PaletteMode.AutoMinMaxColor
			m_HeatMap.Palette.PositiveColor = Color.FromArgb(125, Color.Red)
			m_HeatMap.Palette.ZeroColor = Color.FromArgb(125, Color.Blue)
			m_HeatMap.Palette.SmoothPalette = True

			chart.Series.Add(m_HeatMap)

			' add background image
			Dim range As New NRangeSeries()
			range.UseXValues = True
			range.DataLabelStyle.Visible = False
			range.Legend.Mode = SeriesLegendMode.None

			range.Values.Add(0)
			range.Y2Values.Add(m_SizeY)

			range.XValues.Add(0)
			range.X2Values.Add(m_SizeX)

			Dim bitmap As Bitmap = NResourceHelper.BitmapFromResource(Me.GetType(), "USMap.png", "Nevron.Examples.Chart.WinForm.Resources")
			range.FillStyle = New NImageFillStyle(bitmap)
			chart.Series.Add(range)

			timer1.Interval = 100
			timer1.Start()

			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))
		End Sub

		Private Sub OnTimerTick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
			Do While m_HeatZones.Count < 50
				Dim x As Integer = 0
				Dim y As Integer = 0
				Select Case m_Rand.Next(4)
					Case 0
						' left
						x = -CInt(Math.Truncate(m_MaxTemperature)) \ 2 + 1
						y = m_Rand.Next(m_SizeY)
					Case 1
						' top
						x = m_Rand.Next(m_SizeX)
						y = -CInt(Math.Truncate(m_MaxTemperature)) \ 2 + 1
					Case 2
						' right
						x = m_SizeX - CInt(Math.Truncate(m_MaxTemperature)) \ 2 - 1
						y = m_Rand.Next(m_SizeY)
					Case 3
						' bottom
						x = m_Rand.Next(m_SizeX)
						y = +CInt(Math.Truncate(m_MaxTemperature)) \ 2 - 1
				End Select

				' if no more heat zones -> create new ones
				Dim heatZone As New NHeatZone(x, y, m_MaxTemperature)

				Do
					heatZone.m_DX = m_Rand.Next(4) - 2
					heatZone.m_DY = m_Rand.Next(4) - 2
				Loop While heatZone.m_DX = 0 AndAlso heatZone.m_DY = 0

				m_HeatZones.Add(heatZone)
			Loop

			' gets the values
			m_HeatMap.Data.SetValues(Double.NaN)
			Dim values() As Double = m_HeatMap.Data.Values

			For i As Integer = m_HeatZones.Count - 1 To 0 Step -1
				Dim heatZone As NHeatZone = m_HeatZones(i)

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
					m_HeatZones.RemoveAt(i)
					Continue For
				End If

				Dim centerX As Integer = heatZone.m_X
				Dim centerY As Integer = heatZone.m_Y

				Dim startX As Integer = Math.Max(0, centerX - radius)
				Dim startY As Integer = Math.Max(0, centerY - radius)

				Dim endX As Integer = Math.Min(m_SizeX - 1, centerX + radius)
				Dim endY As Integer = Math.Min(m_SizeY - 1, centerY + radius)

				For x As Integer = startX To endX
					For y As Integer = startY To endY
						Dim value As Double = heatZone.m_Temperature - 2 * Math.Sqrt(Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2))
						If value >= 0 Then
							Dim index As Integer = y * m_SizeX + x
							Dim curValue As Double = values(index)

							If Double.IsNaN(curValue) Then
								values(index) = value
							Else
								curValue += value

								If curValue > m_MaxTemperature Then
									curValue = m_MaxTemperature
								End If

								values(index) = curValue
							End If
						End If
					Next y
				Next x
			Next i

			m_HeatMap.Data.OnDataChanged()

			nChartControl1.Refresh()
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
				m_Radius = CInt(Math.Max(1, m_Temperature / 2))
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

		Private Sub StartStopTimerButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StartStopTimerButton.Click
			If StartStopTimerButton.Text.StartsWith("Start") Then
				StartStopTimerButton.Text = "Stop Timer"
				timer1.Start()
			Else
				StartStopTimerButton.Text = "Start Timer"
				timer1.Stop()
			End If
		End Sub
	End Class
End Namespace
