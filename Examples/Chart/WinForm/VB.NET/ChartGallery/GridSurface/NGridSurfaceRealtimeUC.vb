Imports Nevron.Chart
Imports Nevron.Chart.Windows
Imports Nevron.GraphicsCore
Imports System
Imports System.ComponentModel
Imports System.Drawing

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NGridSurfaceRealtimeUC
		Inherits NExampleBaseUC

		Private WithEvents m_Timer As System.Windows.Forms.Timer
		Private WithEvents StartStopTimerButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents RenderToWindowCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents GridSizeComboBox As UI.WinForm.Controls.NComboBox
		Private WithEvents EnableShaderRenderingCheckBox As UI.WinForm.Controls.NCheckBox
		Private components As System.ComponentModel.IContainer = Nothing

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
			Me.StartStopTimerButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.RenderToWindowCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.GridSizeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.EnableShaderRenderingCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' m_Timer
			' 
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_Timer.Tick += new System.EventHandler(this.timer1_Tick);
			' 
			' StartStopTimerButton
			' 
			Me.StartStopTimerButton.Location = New System.Drawing.Point(6, 123)
			Me.StartStopTimerButton.Name = "StartStopTimerButton"
			Me.StartStopTimerButton.Size = New System.Drawing.Size(160, 23)
			Me.StartStopTimerButton.TabIndex = 1
			Me.StartStopTimerButton.Text = "Stop Timer"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StartStopTimerButton.Click += new System.EventHandler(this.StartStopTimerButton_Click);
			' 
			' RenderToWindowCheck
			' 
			Me.RenderToWindowCheck.ButtonProperties.BorderOffset = 2
			Me.RenderToWindowCheck.Location = New System.Drawing.Point(6, 46)
			Me.RenderToWindowCheck.Name = "RenderToWindowCheck"
			Me.RenderToWindowCheck.Size = New System.Drawing.Size(149, 20)
			Me.RenderToWindowCheck.TabIndex = 0
			Me.RenderToWindowCheck.Text = "Render to window"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RenderToWindowCheck.CheckedChanged += new System.EventHandler(this.RenderToWindowCheck_CheckedChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(6, 5)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(168, 13)
			Me.label1.TabIndex = 7
			Me.label1.Text = "Grid Size:"
			' 
			' GridSizeComboBox
			' 
			Me.GridSizeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.GridSizeComboBox.ListProperties.DataSource = Nothing
			Me.GridSizeComboBox.ListProperties.DisplayMember = ""
			Me.GridSizeComboBox.Location = New System.Drawing.Point(6, 22)
			Me.GridSizeComboBox.Name = "GridSizeComboBox"
			Me.GridSizeComboBox.Size = New System.Drawing.Size(156, 21)
			Me.GridSizeComboBox.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GridSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.GridSizeComboBox_SelectedIndexChanged);
			' 
			' EnableShaderRenderingCheckBox
			' 
			Me.EnableShaderRenderingCheckBox.ButtonProperties.BorderOffset = 2
			Me.EnableShaderRenderingCheckBox.Location = New System.Drawing.Point(6, 72)
			Me.EnableShaderRenderingCheckBox.Name = "EnableShaderRenderingCheckBox"
			Me.EnableShaderRenderingCheckBox.Size = New System.Drawing.Size(149, 20)
			Me.EnableShaderRenderingCheckBox.TabIndex = 9
			Me.EnableShaderRenderingCheckBox.Text = "Enable Shader Rendering"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableShaderRenderingCheckBox.CheckedChanged += new System.EventHandler(this.EnableGPURenderingCheckBox_CheckedChanged);
			' 
			' NGridSurfaceRealtimeUC
			' 
			Me.Controls.Add(Me.EnableShaderRenderingCheckBox)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.GridSizeComboBox)
			Me.Controls.Add(Me.RenderToWindowCheck)
			Me.Controls.Add(Me.StartStopTimerButton)
			Me.Name = "NGridSurfaceRealtimeUC"
			Me.Size = New System.Drawing.Size(174, 216)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' Enable GPU acceleration
			nChartControl1.Settings.RenderSurface = RenderSurface.Window

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Realtime Grid Surface")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
			title.Cache = True

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 55.0F
			chart.Depth = 55.0F
			chart.Height = 20.0F
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' setup axes
			chart.Axis(StandardAxis.PrimaryY).View = New NRangeAxisView(New NRange1DD(-3, 3), True, True)

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
			surface.FillStyle = New NColorFillStyle(Color.FromArgb(0, 0, 240))
			surface.CellTriangulationMode = SurfaceCellTriangulationMode.Diagonal1
			surface.Data.SetGridSize(500, 500)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			RenderToWindowCheck.Checked = True
			EnableShaderRenderingCheckBox.Checked = True
			m_Timer.Enabled = True

			GridSizeComboBox.Items.Add("250x250")
			GridSizeComboBox.Items.Add("500x500")
			GridSizeComboBox.Items.Add("1000x1000")
			GridSizeComboBox.SelectedIndex = 1
		End Sub

		Private phase As Double = 0
		Private random As New Random()

		Private Sub GenerateWaves()
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NGridSurfaceSeries = CType(chart.Series(0), NGridSurfaceSeries)
			Dim data As NGridSurfaceData = surface.Data

			Dim nCountX As Integer = surface.Data.GridSizeX
			Dim nCountZ As Integer = surface.Data.GridSizeZ

			Dim phaseStep As Double = Math.PI * 10 / nCountX
			Dim randomAmplitude As Double = Math.Sin(phase) * 2 + random.NextDouble()

			For z As Integer = 0 To nCountZ - 1
				For x As Integer = 0 To nCountX - 1
					data.SetValue(z, x, randomAmplitude * Math.Sin(phase + x * phaseStep) * Math.Cos(phase + z * phaseStep))
				Next x
			Next z

			phase += 3 * phaseStep
			nChartControl1.Refresh()
		End Sub

		Private Sub timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_Timer.Tick
			GenerateWaves()
			nChartControl1.Refresh()
		End Sub

		Private Sub RenderToWindowCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RenderToWindowCheck.CheckedChanged
			If RenderToWindowCheck.Checked Then
				nChartControl1.Settings.RenderSurface = RenderSurface.Window
				EnableShaderRenderingCheckBox.Enabled = True
			Else
				nChartControl1.Settings.RenderSurface = RenderSurface.Bitmap
				EnableShaderRenderingCheckBox.Enabled = False
			End If
		End Sub

		Private Sub StartStopTimerButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StartStopTimerButton.Click
			m_Timer.Enabled = Not m_Timer.Enabled

			If Me.m_Timer.Enabled Then
				StartStopTimerButton.Text = "Stop Timer"
			Else
				StartStopTimerButton.Text = "Start Timer"
			End If
		End Sub

		Private Sub EnableGPURenderingCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles EnableShaderRenderingCheckBox.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NGridSurfaceSeries = CType(chart.Series(0), NGridSurfaceSeries)

			surface.EnableShaderRendering = EnableShaderRenderingCheckBox.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub GridSizeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridSizeComboBox.SelectedIndexChanged
			Dim gridSize As Integer = 0
			Select Case GridSizeComboBox.SelectedIndex
				Case 0
					gridSize = 250
				Case 1
					gridSize = 500
				Case 2
					gridSize = 1000
			End Select

			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NGridSurfaceSeries = CType(chart.Series(0), NGridSurfaceSeries)

			surface.Data.SetSize(gridSize, gridSize)
			GenerateWaves()
		End Sub
	End Class
End Namespace

