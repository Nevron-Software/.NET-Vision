Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Diagnostics
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NWavesUC
		Inherits NExampleBaseUC
		Private m_Oscillators As List(Of Oscillator) = New List(Of Oscillator)()
		Private WithEvents m_Timer As System.Windows.Forms.Timer
		Private WithEvents AddWaveButton As Nevron.UI.WinForm.Controls.NButton
		Private IndicatorLabel As System.Windows.Forms.Label
		Private WithEvents RenderToWindowCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents SemiTransparentCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents smoothShadingCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private components As System.ComponentModel.IContainer = Nothing

		Public Class Oscillator
			Public m_nFrame As Integer
			Public m_dCenterX As Double
			Public m_dCenterZ As Double

			Public m_dTime As Double
			Public m_dAmplitude As Double
		End Class

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub


		#Region "Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.m_Timer = New System.Windows.Forms.Timer(Me.components)
			Me.AddWaveButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.IndicatorLabel = New System.Windows.Forms.Label()
			Me.RenderToWindowCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SemiTransparentCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.smoothShadingCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' timer1
			' 
'			Me.m_Timer.Tick += New System.EventHandler(Me.timer1_Tick);
			' 
			' AddWaveButton
			' 
			Me.AddWaveButton.Location = New System.Drawing.Point(7, 7)
			Me.AddWaveButton.Name = "AddWaveButton"
			Me.AddWaveButton.Size = New System.Drawing.Size(122, 23)
			Me.AddWaveButton.TabIndex = 0
			Me.AddWaveButton.Text = "Add Wave"
'			Me.AddWaveButton.Click += New System.EventHandler(Me.AddWaveButton_Click);
			' 
			' IndicatorLabel
			' 
			Me.IndicatorLabel.BackColor = System.Drawing.Color.Green
			Me.IndicatorLabel.Location = New System.Drawing.Point(135, 7)
			Me.IndicatorLabel.Name = "IndicatorLabel"
			Me.IndicatorLabel.Size = New System.Drawing.Size(23, 23)
			Me.IndicatorLabel.TabIndex = 1
			' 
			' RenderToWindowCheck
			' 
			Me.RenderToWindowCheck.ButtonProperties.BorderOffset = 2
			Me.RenderToWindowCheck.Location = New System.Drawing.Point(7, 68)
			Me.RenderToWindowCheck.Name = "RenderToWindowCheck"
			Me.RenderToWindowCheck.Size = New System.Drawing.Size(149, 20)
			Me.RenderToWindowCheck.TabIndex = 3
			Me.RenderToWindowCheck.Text = "Render to window"
'			Me.RenderToWindowCheck.CheckedChanged += New System.EventHandler(Me.RenderToWindowCheck_CheckedChanged);
			' 
			' SemiTransparentCheck
			' 
			Me.SemiTransparentCheck.ButtonProperties.BorderOffset = 2
			Me.SemiTransparentCheck.Location = New System.Drawing.Point(7, 96)
			Me.SemiTransparentCheck.Name = "SemiTransparentCheck"
			Me.SemiTransparentCheck.Size = New System.Drawing.Size(175, 20)
			Me.SemiTransparentCheck.TabIndex = 4
			Me.SemiTransparentCheck.Text = "Semi transparent surface"
'			Me.SemiTransparentCheck.CheckedChanged += New System.EventHandler(Me.SemiTransparentCheck_CheckedChanged);
			' 
			' smoothShadingCheck
			' 
			Me.smoothShadingCheck.ButtonProperties.BorderOffset = 2
			Me.smoothShadingCheck.Location = New System.Drawing.Point(7, 39)
			Me.smoothShadingCheck.Name = "smoothShadingCheck"
			Me.smoothShadingCheck.Size = New System.Drawing.Size(152, 20)
			Me.smoothShadingCheck.TabIndex = 2
			Me.smoothShadingCheck.Text = "Smooth Shading"
'			Me.smoothShadingCheck.CheckedChanged += New System.EventHandler(Me.SmoothShadingCheck_CheckedChanged);
			' 
			' NWavesUC
			' 
			Me.Controls.Add(Me.smoothShadingCheck)
			Me.Controls.Add(Me.SemiTransparentCheck)
			Me.Controls.Add(Me.RenderToWindowCheck)
			Me.Controls.Add(Me.IndicatorLabel)
			Me.Controls.Add(Me.AddWaveButton)
			Me.Name = "NWavesUC"
			Me.Size = New System.Drawing.Size(180, 216)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Waves")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
			title.Cache = True

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 55.0f
			chart.Depth = 55.0f
			chart.Height = 20.0f
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' setup axes
			chart.Axis(StandardAxis.PrimaryY).View = New NRangeAxisView(New NRange1DD(-2, 2), True, True)

			Dim ordinalScale As NOrdinalScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			ordinalScale.DisplayDataPointsBetweenTicks = False

			ordinalScale = CType(chart.Axis(StandardAxis.Depth).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			ordinalScale.DisplayDataPointsBetweenTicks = False

			' add the surface series
			Dim surface As NGridSurfaceSeries = CType(chart.Series.Add(SeriesType.GridSurface), NGridSurfaceSeries)
			surface.Name = "Surface"
			surface.FrameMode = SurfaceFrameMode.None
			surface.FillMode = SurfaceFillMode.Uniform
			surface.FillStyle = New NColorFillStyle(Color.FromArgb(120, 175, 240))
			surface.CellTriangulationMode = SurfaceCellTriangulationMode.Diagonal1
			surface.Data.SetGridSize(60, 60)

			FillSurfaceWithValue(0)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' init form controls
			smoothShadingCheck.Checked = True
			IndicatorLabel.BackColor = Color.Green
		End Sub

		Private Sub FillSurfaceWithValue(ByVal dValue As Double)
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NGridSurfaceSeries = CType(chart.Series(0), NGridSurfaceSeries)

			Dim nCountX As Integer = surface.Data.GridSizeX
			Dim nCountZ As Integer = surface.Data.GridSizeZ

			Dim j As Integer = 0
			Do While j < nCountZ
				Dim i As Integer = 0
				Do While i < nCountX
					surface.Data.SetValue(i, j, 0.0)
					i += 1
				Loop
				j += 1
			Loop
		End Sub

		Private Sub GenerateWaves()
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NGridSurfaceSeries = CType(chart.Series(0), NGridSurfaceSeries)

			Dim y, x, z As Double
			Dim nCountX As Integer = surface.Data.GridSizeX
			Dim nCountZ As Integer = surface.Data.GridSizeZ

			Const dIntervalX As Double = 30.0
			Const dIntervalZ As Double = 30.0
			Dim dIncrementX As Double = (dIntervalX / nCountX)
			Dim dIncrementZ As Double = (dIntervalZ / nCountZ)

			z = -(dIntervalZ / 2)

			Dim j As Integer = 0
			Do While j < nCountZ
				x = -(dIntervalX / 2)

				Dim i As Integer = 0
				Do While i < nCountX
					y = CalulateWavesAtPoint(x, z)

					surface.Data.SetValue(i, j, y)
					i += 1
					x += dIncrementX
				Loop
				j += 1
				z += dIncrementZ
			Loop
		End Sub

		Private Sub GenerateAmplitudes()
			For i As Integer = m_Oscillators.Count - 1 To 0 Step -1
				Dim osc As Oscillator = m_Oscillators(i)

				osc.m_dTime = osc.m_nFrame * 0.5
				osc.m_nFrame += 1

				osc.m_dAmplitude = osc.m_dTime * 0.5

				If osc.m_dAmplitude >= 1 Then
					osc.m_dAmplitude = 1 * Math.Exp(- osc.m_dTime * 0.08)

					If osc.m_dAmplitude <= 0.001 Then
						m_Oscillators.RemoveAt(i)
					End If
				End If
			Next i
		End Sub

		Private Function CalulateWavesAtPoint(ByVal x As Double, ByVal z As Double) As Double
			Dim dValue As Double = 0

			Dim i As Integer = 0
			Do While i < m_Oscillators.Count
				Dim osc As Oscillator = m_Oscillators(i)

				Dim distX As Double = x - osc.m_dCenterX
				Dim distZ As Double = z - osc.m_dCenterZ
				Dim dist As Double = Math.Sqrt(distX * distX + distZ * distZ)

				dValue += osc.m_dAmplitude * Math.Sin(dist - osc.m_dTime) * Math.Exp(-dist * 0.05)
				i += 1
			Loop

			Return dValue
		End Function

		Private Sub AddWaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddWaveButton.Click
			If m_Timer.Enabled = False Then
				Debug.Assert(m_Oscillators.Count = 0)
				m_Timer.Interval = 50
				m_Timer.Start()
				IndicatorLabel.BackColor = Color.Red
			End If

			Dim osc As Oscillator = New Oscillator()
			osc.m_nFrame = 0
			osc.m_dCenterX = 10.0 - Random.NextDouble() * 20
			osc.m_dCenterZ = 10.0 - Random.NextDouble() * 20

			m_Oscillators.Add(osc)
		End Sub

		Private Sub timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_Timer.Tick
			GenerateAmplitudes()

			If m_Oscillators.Count = 0 Then
				m_Timer.Stop()
				IndicatorLabel.BackColor = Color.Green
			Else
				GenerateWaves()
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub RenderToWindowCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RenderToWindowCheck.CheckedChanged
			If RenderToWindowCheck.Checked Then
				nChartControl1.Settings.RenderSurface = RenderSurface.Window
			Else
				nChartControl1.Settings.RenderSurface = RenderSurface.Bitmap
			End If
		End Sub

		Private Sub SemiTransparentCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SemiTransparentCheck.CheckedChanged
			Dim fPercent As Single
			If SemiTransparentCheck.Checked Then
				fPercent = 20
			Else
				fPercent = 0
			End If

			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NGridSurfaceSeries = CType(chart.Series(0), NGridSurfaceSeries)
			surface.FillStyle.SetTransparencyPercent(fPercent)

			If m_Timer.Enabled = False Then
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub SmoothShadingCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles smoothShadingCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NGridSurfaceSeries = CType(chart.Series(0), NGridSurfaceSeries)

			If smoothShadingCheck.Checked Then
				surface.ShadingMode = ShadingMode.Smooth
			Else
				surface.ShadingMode = ShadingMode.Flat
			End If

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace

