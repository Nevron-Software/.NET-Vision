Imports System.ComponentModel
Imports Nevron.Chart
Imports Nevron.Chart.Windows
Imports Nevron.GraphicsCore


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NTriangulatedSurfaceRealtimeUC
		Inherits NExampleBaseUC

		Private components As IContainer
		Private WithEvents timer1 As System.Windows.Forms.Timer
		Private WithEvents GridSizeComboBox As UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
		Private m_Surface As NTriangulatedSurfaceSeries
		Private WithEvents StartStopTimerButton As UI.WinForm.Controls.NButton
		Private label2 As System.Windows.Forms.Label
		Private WithEvents FrameModeCombo As UI.WinForm.Controls.NComboBox
		Private label3 As System.Windows.Forms.Label
		Private WithEvents FillModeComboBox As UI.WinForm.Controls.NComboBox
		Private m_GridSize As Integer

		Public Sub New()
			InitializeComponent()

			m_Random = New Random()
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
			Me.components = New System.ComponentModel.Container()
			Me.timer1 = New System.Windows.Forms.Timer(Me.components)
			Me.GridSizeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.StartStopTimerButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label2 = New System.Windows.Forms.Label()
			Me.FrameModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.FillModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' timer1
			' 
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			' 
			' GridSizeComboBox
			' 
			Me.GridSizeComboBox.Location = New System.Drawing.Point(19, 29)
			Me.GridSizeComboBox.Name = "GridSizeComboBox"
			Me.GridSizeComboBox.Size = New System.Drawing.Size(144, 21)
			Me.GridSizeComboBox.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GridSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.gridSizeComboBox_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(19, 10)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(50, 13)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Grid size:"
			' 
			' StartStopTimerButton
			' 
			Me.StartStopTimerButton.Location = New System.Drawing.Point(19, 257)
			Me.StartStopTimerButton.Name = "StartStopTimerButton"
			Me.StartStopTimerButton.Size = New System.Drawing.Size(144, 23)
			Me.StartStopTimerButton.TabIndex = 5
			Me.StartStopTimerButton.Text = "Stop Timer"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StartStopTimerButton.Click += new System.EventHandler(this.StartStopTimerButton_Click);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(19, 120)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(131, 14)
			Me.label2.TabIndex = 6
			Me.label2.Text = "Frame Mode:"
			' 
			' FrameModeCombo
			' 
			Me.FrameModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.FrameModeCombo.ListProperties.DataSource = Nothing
			Me.FrameModeCombo.ListProperties.DisplayMember = ""
			Me.FrameModeCombo.Location = New System.Drawing.Point(19, 136)
			Me.FrameModeCombo.Name = "FrameModeCombo"
			Me.FrameModeCombo.Size = New System.Drawing.Size(144, 21)
			Me.FrameModeCombo.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FrameModeCombo.SelectedIndexChanged += new System.EventHandler(this.FrameModeCombo_SelectedIndexChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(19, 80)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(131, 14)
			Me.label3.TabIndex = 8
			Me.label3.Text = "Fill Mode:"
			' 
			' FillModeComboBox
			' 
			Me.FillModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.FillModeComboBox.ListProperties.DataSource = Nothing
			Me.FillModeComboBox.ListProperties.DisplayMember = ""
			Me.FillModeComboBox.Location = New System.Drawing.Point(19, 96)
			Me.FillModeComboBox.Name = "FillModeComboBox"
			Me.FillModeComboBox.Size = New System.Drawing.Size(144, 21)
			Me.FillModeComboBox.TabIndex = 9
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FillModeComboBox.SelectedIndexChanged += new System.EventHandler(this.FillModeComboBox_SelectedIndexChanged);
			' 
			' NTriangulatedSurfaceRealtimeUC
			' 
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.FillModeComboBox)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.FrameModeCombo)
			Me.Controls.Add(Me.StartStopTimerButton)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.GridSizeComboBox)
			Me.Name = "NTriangulatedSurfaceRealtimeUC"
			Me.Size = New System.Drawing.Size(180, 349)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' Enable GPU acceleration
			nChartControl1.Settings.RenderSurface = RenderSurface.Window

			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Realtime Triangulation")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' remove legends
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 50
			chart.Depth = 50
			chart.Height = 30
			chart.BoundsMode = BoundsMode.Fit
			chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalTop)

			For i As Integer = 0 To chart.Walls.Count - 1
				DirectCast(chart.Walls(i), NChartWall).Visible = False
			Next i

			' setup Y axis
			Dim scaleY As New NLinearScaleConfigurator()
			scaleY.RoundToTickMax = False
			scaleY.RoundToTickMin = False
			scaleY.MinTickDistance = New NLength(10, NGraphicsUnit.Point)
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Left, ChartWallType.Back }
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY

			' setup X axis
			Dim scaleX As New NLinearScaleConfigurator()
			scaleX.RoundToTickMax = False
			scaleX.RoundToTickMin = False
			scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Floor, ChartWallType.Back }
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' setup Z axis
			Dim scaleZ As New NLinearScaleConfigurator()
			scaleZ.RoundToTickMax = False
			scaleZ.RoundToTickMin = False
			scaleZ.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Floor, ChartWallType.Left }
			scaleZ.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ

			' add the surface series
			Dim surface As NTriangulatedSurfaceSeries = CType(chart.Series.Add(SeriesType.TriangulatedSurface), NTriangulatedSurfaceSeries)
			m_Surface = surface
			surface.Name = "Surface"
			surface.SyncPaletteWithAxisScale = False
			surface.ValueFormatter.FormatSpecifier = "0.00"
			surface.FillStyle = New NColorFillStyle(Color.YellowGreen)
			surface.PaletteSteps = 8

			surface.FillMode = SurfaceFillMode.Zone
			surface.FrameMode = SurfaceFrameMode.None
			surface.ShadingMode = ShadingMode.Smooth

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			timer1.Start()

			FillModeComboBox.FillFromEnum(GetType(SurfaceFillMode))
			FillModeComboBox.SelectedIndex = CInt(SurfaceFillMode.ZoneTexture)

			FrameModeCombo.FillFromEnum(GetType(SurfaceFrameMode))
			FrameModeCombo.SelectedIndex = CInt(SurfaceFrameMode.Mesh)

			GridSizeComboBox.Items.Add("10x10")
			GridSizeComboBox.Items.Add("100x100")
			GridSizeComboBox.Items.Add("200x200")
			GridSizeComboBox.Items.Add("500x500")
			GridSizeComboBox.SelectedIndex = 0
		End Sub

		Private m_Random As Random
		Private m_Phase(,) As Double
		Private m_Radius(,) As Double

		Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
			If m_GridSize = 0 Then
				Return
			End If

			Const phaseStep As Double = Math.PI / 10
			Dim data As NTriangulatedSurfaceData = m_Surface.Data

			Dim count As Integer = m_Surface.Data.Count
			Dim index As Integer = 0

			For x As Integer = 0 To m_GridSize - 1
				For y As Integer = 0 To m_GridSize - 1

					' The order of the values is x, y, z. In this case we dynamically modify only x and z.
					data.SetXValue(index, CType((x + Math.Cos(m_Phase(x, y)) * m_Radius(x, y)), Single))
					data.SetZValue(index, CType((y + Math.Sin(m_Phase(x, y)) * m_Radius(x, y)), Single))

					m_Phase(x, y) += phaseStep

					index += 1
				Next y
			Next x

			nChartControl1.Refresh()
		End Sub

		Private Sub gridSizeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridSizeComboBox.SelectedIndexChanged
			m_GridSize = 100

			Select Case GridSizeComboBox.SelectedIndex
				Case 0
					m_GridSize = 10
				Case 1
					m_GridSize = 100
				Case 2
					m_GridSize = 200
				Case 3
					m_GridSize = 500
			End Select

			Dim data As NTriangulatedSurfaceData = m_Surface.Data
			data.Clear()

			Const dIntervalX As Single = 1.0F
			Const dIntervalZ As Single = 1.0F

			Dim dIncrementX As Single = (dIntervalX / m_GridSize)
			Dim dIncrementZ As Single = (dIntervalZ / m_GridSize)

			m_Radius = New Double(m_GridSize - 1, m_GridSize - 1){}
			m_Phase = New Double(m_GridSize - 1, m_GridSize - 1){}

			Dim random As New Random()

			Dim gridPhase As Single = CSng(Math.PI * 5 / m_GridSize)

			For x As Integer = 0 To m_GridSize - 1
				Dim zVar As Single= -(dIntervalZ / 2) + x * dIncrementZ

				For y As Integer = 0 To m_GridSize - 1
					Dim xVar As Single = -(dIncrementX / 2) + y * dIncrementX

					m_Radius(x, y) = random.NextDouble()
					m_Phase(x, y) = random.NextDouble() * Math.PI * 2

					Dim yPos As Single = CSng(Math.Sin(y * gridPhase) + Math.Cos(x * gridPhase))
					Dim xPos As Single = CSng(x + Math.Cos(m_Phase(x, y)) * m_Radius(x, y))
					Dim zPos As Single = CSng(y + Math.Sin(m_Phase(x, y)) * m_Radius(x, y))

					data.AddValue(New NVector3DF(xPos, yPos, yPos))
				Next y
			Next x
		End Sub

		Private Sub StartStopTimerButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StartStopTimerButton.Click
			timer1.Enabled = Not timer1.Enabled

			If timer1.Enabled Then
				StartStopTimerButton.Text = "Stop Timer"
			Else
				StartStopTimerButton.Text = "Start Timer"
			End If
		End Sub

		Private Sub FillModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles FillModeComboBox.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NTriangulatedSurfaceSeries = CType(chart.Series(0), NTriangulatedSurfaceSeries)

			surface.FillMode = CType(FillModeComboBox.SelectedIndex, SurfaceFillMode)

			nChartControl1.Refresh()
		End Sub

		Private Sub FrameModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles FrameModeCombo.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NTriangulatedSurfaceSeries = CType(chart.Series(0), NTriangulatedSurfaceSeries)

			surface.FrameMode = CType(FrameModeCombo.SelectedIndex, SurfaceFrameMode)

			If surface.FrameMode = SurfaceFrameMode.Dots Then
				surface.FrameStrokeStyle.Width = New NLength(2)
			Else
				surface.FrameStrokeStyle.Width = New NLength(0.75F)
			End If

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
