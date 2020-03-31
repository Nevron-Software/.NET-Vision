Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NRealTimeSurfaceUC
		Inherits NRealTimeExampleBaseUC

		Private WithEvents smoothPaletteCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents paletteStepsCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents paletteModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label2 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents StartStopTimerButton As UI.WinForm.Controls.NButton
		Private startTime As Date

		Public Sub New()
			InitializeComponent()

			paletteModeCombo.Items.Add("Use Fixed Number of Zones")
			paletteModeCombo.Items.Add("Synchronize Palette Zones with Y Axis")
			paletteModeCombo.Items.Add("Use Custom Palette")

			paletteStepsCombo.Items.Add("2")
			paletteStepsCombo.Items.Add("3")
			paletteStepsCombo.Items.Add("4")
			paletteStepsCombo.Items.Add("5")
			paletteStepsCombo.Items.Add("6")
			paletteStepsCombo.Items.Add("7")
			paletteStepsCombo.Items.Add("8")
		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.smoothPaletteCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.paletteStepsCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.paletteModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.StartStopTimerButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' smoothPaletteCheck
			' 
			Me.smoothPaletteCheck.ButtonProperties.BorderOffset = 2
			Me.smoothPaletteCheck.Location = New System.Drawing.Point(5, 168)
			Me.smoothPaletteCheck.Name = "smoothPaletteCheck"
			Me.smoothPaletteCheck.Size = New System.Drawing.Size(168, 21)
			Me.smoothPaletteCheck.TabIndex = 4
			Me.smoothPaletteCheck.Text = "Smooth Palette"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.smoothPaletteCheck.CheckedChanged += new System.EventHandler(this.SmoothPaletteCheck_CheckedChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(5, 106)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(168, 14)
			Me.label4.TabIndex = 2
			Me.label4.Text = "Palette Steps:"
			' 
			' paletteStepsCombo
			' 
			Me.paletteStepsCombo.ListProperties.CheckBoxDataMember = ""
			Me.paletteStepsCombo.ListProperties.DataSource = Nothing
			Me.paletteStepsCombo.ListProperties.DisplayMember = ""
			Me.paletteStepsCombo.Location = New System.Drawing.Point(5, 122)
			Me.paletteStepsCombo.Name = "paletteStepsCombo"
			Me.paletteStepsCombo.Size = New System.Drawing.Size(168, 21)
			Me.paletteStepsCombo.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.paletteStepsCombo.SelectedIndexChanged += new System.EventHandler(this.PaletteStepsCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(5, 49)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(168, 14)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Palette Mode:"
			' 
			' paletteModeCombo
			' 
			Me.paletteModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.paletteModeCombo.ListProperties.DataSource = Nothing
			Me.paletteModeCombo.ListProperties.DisplayMember = ""
			Me.paletteModeCombo.Location = New System.Drawing.Point(5, 65)
			Me.paletteModeCombo.Name = "paletteModeCombo"
			Me.paletteModeCombo.Size = New System.Drawing.Size(168, 21)
			Me.paletteModeCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.paletteModeCombo.SelectedIndexChanged += new System.EventHandler(this.PaletteModeCombo_SelectedIndexChanged);
			' 
			' StartStopTimerButton
			' 
			Me.StartStopTimerButton.Location = New System.Drawing.Point(5, 11)
			Me.StartStopTimerButton.Name = "StopStartTimerButton"
			Me.StartStopTimerButton.Size = New System.Drawing.Size(168, 23)
			Me.StartStopTimerButton.TabIndex = 5
			Me.StartStopTimerButton.Text = "Stop Timer"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StartStopTimerButton.Click += new System.EventHandler(this.StartStopTimerButton_Click);
			' 
			' NRealTimeSurfaceUC
			' 
			Me.Controls.Add(Me.StartStopTimerButton)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.smoothPaletteCheck)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.paletteStepsCombo)
			Me.Controls.Add(Me.paletteModeCombo)
			Me.Name = "NRealTimeSurfaceUC"
			Me.Size = New System.Drawing.Size(180, 227)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Settings.RenderSurface = RenderSurface.Window
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None
			nChartControl1.Controller.Tools.Clear()
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Real Time Surface")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 60.0F
			chart.Depth = 60.0F
			chart.Height = 5.0F
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre)

			' setup axes
			Dim ordinalScale As NOrdinalScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			ordinalScale.DisplayDataPointsBetweenTicks = False

			ordinalScale = CType(chart.Axis(StandardAxis.Depth).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			ordinalScale.DisplayDataPointsBetweenTicks = False

			' add the surface series
			Dim surface As New NGridSurfaceSeries()
			chart.Series.Add(surface)
			surface.ShadingMode = ShadingMode.Smooth
			surface.FillMode = SurfaceFillMode.ZoneTexture
			surface.FrameMode = SurfaceFrameMode.None
			surface.SmoothPalette = True
			surface.CellTriangulationMode = SurfaceCellTriangulationMode.MaxSum
			surface.Data.SetGridSize(100, 100)

			' define a custom palette
			surface.Palette.Clear()
			surface.Palette.Add(-1, DarkOrange)
			surface.Palette.Add(-0.5, LightOrange)
			surface.Palette.Add(-0.25, LightGreen)
			surface.Palette.Add(0, Turqoise)
			surface.Palette.Add(0.25, Blue)
			surface.Palette.Add(0.5, Purple)
			surface.Palette.Add(1, BeautifulRed)

			' generate initial data
			startTime = Date.Now
			UpdateSurfaceData()

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' form controls
			paletteModeCombo.SelectedIndex = 0
			paletteStepsCombo.SelectedIndex = 6
			smoothPaletteCheck.Checked = True

			StartTimer()
		End Sub

		Protected Overrides Sub OnTimerTick(ByVal sender As Object, ByVal e As EventArgs)
			MyBase.OnTimerTick(sender, e)

			UpdateSurfaceData()

			nChartControl1.Refresh()
		End Sub
		Protected Overrides Sub UpdateTitle(ByVal working As Boolean, ByVal cpuUsage As Single)
			Dim title As String = "Real Time Surface"

			If working Then
				title &= " [CPU Usage - " & cpuUsage.ToString("0.") & "%]"
			End If

			nChartControl1.Labels(0).Text = title
		End Sub

		Private Sub UpdateSurfaceData()
			Dim surface As NGridSurfaceSeries = CType(nChartControl1.Charts(0).Series(0), NGridSurfaceSeries)

			Dim span As TimeSpan = startTime.Subtract(Date.Now)
			Dim t As Double = 0.002 * span.TotalMilliseconds

			Dim y, x, z As Double
			Dim nCountX As Integer = surface.Data.GridSizeX
			Dim nCountZ As Integer = surface.Data.GridSizeZ

			Const dIntervalX As Double = 50.0
			Const dIntervalZ As Double = 50.0
			Dim dIncrementX As Double = (dIntervalX / nCountX)
			Dim dIncrementZ As Double = (dIntervalZ / nCountZ)

			z = -(dIntervalZ / 2)

			Dim j As Integer = 0
			Do While j < nCountZ
				x = -(dIntervalX / 2)

				Dim i As Integer = 0
				Do While i < nCountX
					y = - Math.Sin(t + x * z * 0.04) * Math.Cos(t + x * 0.4)

					surface.Data.SetValue(i, j, y)
					i += 1
					x += dIncrementX
				Loop
				j += 1
				z += dIncrementZ
			Loop
		End Sub
		Private Sub UpdateSurface()
			Dim surface As NGridSurfaceSeries = CType(nChartControl1.Charts(0).Series(0), NGridSurfaceSeries)

			Select Case paletteModeCombo.SelectedIndex
				Case 0
					surface.AutomaticPalette = True
					surface.SyncPaletteWithAxisScale = False
					paletteStepsCombo.Enabled = True

				Case 1
					surface.AutomaticPalette = True
					surface.SyncPaletteWithAxisScale = True
					paletteStepsCombo.Enabled = False

				Case 2
					surface.AutomaticPalette = False
					paletteStepsCombo.Enabled = False
			End Select

			If smoothPaletteCheck.Checked Then
				surface.SmoothPalette = True
				surface.PaletteSteps = paletteStepsCombo.SelectedIndex + 1
			Else
				surface.SmoothPalette = False
				surface.PaletteSteps = paletteStepsCombo.SelectedIndex + 2
			End If
		End Sub

		Private Sub PaletteModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles paletteModeCombo.SelectedIndexChanged
			UpdateSurface()

			nChartControl1.Refresh()
		End Sub
		Private Sub PaletteStepsCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles paletteStepsCombo.SelectedIndexChanged
			UpdateSurface()

			nChartControl1.Refresh()
		End Sub
		Private Sub SmoothPaletteCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles smoothPaletteCheck.CheckedChanged
			UpdateSurface()

			nChartControl1.Refresh()
		End Sub
		Private Sub StartStopTimerButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StartStopTimerButton.Click
			ToggleTimer()

			If IsTimerRunning() Then
				StartStopTimerButton.Text = "Stop Timer"
			Else
				StartStopTimerButton.Text = "Start Timer"
			End If
		End Sub
	End Class
End Namespace