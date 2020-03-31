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
	Public Class NMeshIntersectedUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Surface1 As NMeshSurfaceSeries
		Private m_Surface2 As NMeshSurfaceSeries
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label4 As System.Windows.Forms.Label
		Private WithEvents transparencyScroll1 As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents showFrameCheck1 As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents showFrameCheck2 As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents smoothPaletteCheck1 As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents smoothPaletteCheck2 As Nevron.UI.WinForm.Controls.NCheckBox
		Private components As System.ComponentModel.Container = Nothing

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


		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.smoothPaletteCheck1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.showFrameCheck1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.transparencyScroll1 = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.smoothPaletteCheck2 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.showFrameCheck2 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.smoothPaletteCheck1)
			Me.groupBox1.Controls.Add(Me.showFrameCheck1)
			Me.groupBox1.Controls.Add(Me.label4)
			Me.groupBox1.Controls.Add(Me.transparencyScroll1)
			Me.groupBox1.Location = New System.Drawing.Point(4, 7)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(170, 123)
			Me.groupBox1.TabIndex = 0
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Surface 1"
			' 
			' smoothPaletteCheck1
			' 
			Me.smoothPaletteCheck1.ButtonProperties.BorderOffset = 2
			Me.smoothPaletteCheck1.Checked = True
			Me.smoothPaletteCheck1.CheckState = System.Windows.Forms.CheckState.Checked
			Me.smoothPaletteCheck1.Location = New System.Drawing.Point(7, 44)
			Me.smoothPaletteCheck1.Name = "smoothPaletteCheck1"
			Me.smoothPaletteCheck1.Size = New System.Drawing.Size(149, 19)
			Me.smoothPaletteCheck1.TabIndex = 1
			Me.smoothPaletteCheck1.Text = "Smooth Palette"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.smoothPaletteCheck1.CheckedChanged += new System.EventHandler(this.smoothPaletteCheck1_CheckedChanged);
			' 
			' showFrameCheck1
			' 
			Me.showFrameCheck1.ButtonProperties.BorderOffset = 2
			Me.showFrameCheck1.Checked = True
			Me.showFrameCheck1.CheckState = System.Windows.Forms.CheckState.Checked
			Me.showFrameCheck1.Location = New System.Drawing.Point(7, 20)
			Me.showFrameCheck1.Name = "showFrameCheck1"
			Me.showFrameCheck1.Size = New System.Drawing.Size(149, 21)
			Me.showFrameCheck1.TabIndex = 0
			Me.showFrameCheck1.Text = "Show Frame"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.showFrameCheck1.CheckedChanged += new System.EventHandler(this.showFrameCheck1_CheckedChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(7, 72)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(149, 17)
			Me.label4.TabIndex = 2
			Me.label4.Text = "Filling Transparency:"
			' 
			' transparencyScroll1
			' 
			Me.transparencyScroll1.LargeChange = 1
			Me.transparencyScroll1.Location = New System.Drawing.Point(7, 92)
			Me.transparencyScroll1.MinimumSize = New System.Drawing.Size(32, 16)
			Me.transparencyScroll1.Name = "transparencyScroll1"
			Me.transparencyScroll1.Size = New System.Drawing.Size(149, 17)
			Me.transparencyScroll1.TabIndex = 3
			Me.transparencyScroll1.Value = 50
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.transparencyScroll1.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.transparencyScroll1_Scroll);
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.smoothPaletteCheck2)
			Me.groupBox2.Controls.Add(Me.showFrameCheck2)
			Me.groupBox2.Location = New System.Drawing.Point(4, 140)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(170, 76)
			Me.groupBox2.TabIndex = 1
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Surface 2"
			' 
			' smoothPaletteCheck2
			' 
			Me.smoothPaletteCheck2.ButtonProperties.BorderOffset = 2
			Me.smoothPaletteCheck2.Checked = True
			Me.smoothPaletteCheck2.CheckState = System.Windows.Forms.CheckState.Checked
			Me.smoothPaletteCheck2.Location = New System.Drawing.Point(7, 42)
			Me.smoothPaletteCheck2.Name = "smoothPaletteCheck2"
			Me.smoothPaletteCheck2.Size = New System.Drawing.Size(149, 19)
			Me.smoothPaletteCheck2.TabIndex = 1
			Me.smoothPaletteCheck2.Text = "Smooth Palette"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.smoothPaletteCheck2.CheckedChanged += new System.EventHandler(this.smoothPaletteCheck2_CheckedChanged);
			' 
			' showFrameCheck2
			' 
			Me.showFrameCheck2.ButtonProperties.BorderOffset = 2
			Me.showFrameCheck2.Checked = True
			Me.showFrameCheck2.CheckState = System.Windows.Forms.CheckState.Checked
			Me.showFrameCheck2.Location = New System.Drawing.Point(7, 19)
			Me.showFrameCheck2.Name = "showFrameCheck2"
			Me.showFrameCheck2.Size = New System.Drawing.Size(149, 21)
			Me.showFrameCheck2.TabIndex = 0
			Me.showFrameCheck2.Text = "Show Frame"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.showFrameCheck2.CheckedChanged += new System.EventHandler(this.showFrameCheck2_CheckedChanged);
			' 
			' NMeshIntersectedUC
			' 
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Name = "NMeshIntersectedUC"
			Me.Size = New System.Drawing.Size(180, 271)
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Intersected Surfaces")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True
			m_Chart.Width = 60.0F
			m_Chart.Depth = 60.0F
			m_Chart.Height = 30.0F
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft)

			Dim axisY As NAxis = m_Chart.Axis(StandardAxis.PrimaryY)
			Dim scaleConfiguratorY As NStandardScaleConfigurator = CType(axisY.ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfiguratorY.MinTickDistance = New NLength(10, NGraphicsUnit.Point)

			' setup axes
			Dim linearScale As New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.RoundToTickMax = False
			linearScale.RoundToTickMin = False

			linearScale = New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.RoundToTickMax = False
			linearScale.RoundToTickMin = False

			' setup surface series 1
			m_Surface1 = CType(m_Chart.Series.Add(SeriesType.MeshSurface), NMeshSurfaceSeries)
			m_Surface1.Name = "Surface 1"
			m_Surface1.FillMode = SurfaceFillMode.Zone
			m_Surface1.FrameMode = SurfaceFrameMode.MeshContour
			m_Surface1.FrameColorMode = SurfaceFrameColorMode.Zone
			m_Surface1.SmoothPalette = True
			m_Surface1.ShadingMode = ShadingMode.Smooth
			m_Surface1.FillStyle.SetTransparencyPercent(50)
			m_Surface1.Data.SetGridSize(20, 20)
			m_Surface1.SyncPaletteWithAxisScale = True
			FillData1()

			' setup surface series 2
			m_Surface2 = CType(m_Chart.Series.Add(SeriesType.MeshSurface), NMeshSurfaceSeries)
			m_Surface2.Name = "Surface 2"
			m_Surface2.FillMode = SurfaceFillMode.Zone
			m_Surface2.FrameMode = SurfaceFrameMode.MeshContour
			m_Surface2.FrameColorMode = SurfaceFrameColorMode.Zone
			m_Surface2.SmoothPalette = True
			m_Surface2.ShadingMode = ShadingMode.Smooth
			m_Surface2.Data.SetGridSize(20, 20)
			m_Surface2.SyncPaletteWithAxisScale = True
			FillData2()

			' apply layout
			ConfigureStandardLayout(m_Chart, title, Nothing)
		End Sub

		Private Sub FillData1()
			Dim y, x, z As Double
			Dim nCountX As Integer = CInt(m_Surface1.Data.GridSizeX)
			Dim nCountZ As Integer = CInt(m_Surface1.Data.GridSizeZ)

			Const dIntervalX As Double = 20.0
			Const dIntervalZ As Double = 20.0
			Dim dIncrementX As Double = (dIntervalX / nCountX)
			Dim dIncrementZ As Double = (dIntervalZ / nCountZ)

			z = -(dIntervalZ / 2)

			Dim j As Integer = 0
			Do While j < nCountZ
				x = -(dIntervalX / 2)

				Dim i As Integer = 0
				Do While i < nCountX
					y = Math.Sqrt((x * x) + (z * z) + 2)
					y -= 0.08 * Math.Sqrt(Math.Abs(Math.Sinh(x)))

					If x < 0 Then
						y += 0.11 * x * x
					End If

					m_Surface1.Data.SetValue(i, j, y, x, z)
					i += 1
					x += dIncrementX
				Loop
				j += 1
				z += dIncrementZ
			Loop
		End Sub

		Private Sub FillData2()
			Dim y, x, z As Double
			Dim nCountX As Integer = CInt(m_Surface2.Data.GridSizeX)
			Dim nCountZ As Integer = CInt(m_Surface2.Data.GridSizeZ)

			Const dIntervalX As Double = 20.0
			Const dIntervalZ As Double = 20.0
			Dim dIncrementX As Double = (dIntervalX / nCountX)
			Dim dIncrementZ As Double = (dIntervalZ / nCountZ)

			z = -(dIntervalZ / 2)

			Dim j As Integer = 0
			Do While j < nCountZ
				x = -(dIntervalX / 2)

				Dim i As Integer = 0
				Do While i < nCountX
					If (x > 0) AndAlso (x < 10) AndAlso (z > -7) AndAlso (z < 7) Then
						y = 15 * Math.Abs(Math.Sin(x / 4) * Math.Cos(z / 4))
					Else
						y = 2 * Math.Sin(x / 2) * Math.Cos(z / 2)
					End If

					m_Surface2.Data.SetValue(i, j, y, x, z)
					i += 1
					x += dIncrementX
				Loop
				j += 1
				z += dIncrementZ
			Loop
		End Sub


		Private Sub showFrameCheck1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles showFrameCheck1.CheckedChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			If showFrameCheck1.Checked Then
				m_Surface1.FrameMode = SurfaceFrameMode.MeshContour
			Else
				m_Surface1.FrameMode = SurfaceFrameMode.None
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub showFrameCheck2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles showFrameCheck2.CheckedChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			If showFrameCheck2.Checked Then
				m_Surface2.FrameMode = SurfaceFrameMode.MeshContour
			Else
				m_Surface2.FrameMode = SurfaceFrameMode.None
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub smoothPaletteCheck1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles smoothPaletteCheck1.CheckedChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			m_Surface1.SmoothPalette = smoothPaletteCheck1.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub smoothPaletteCheck2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles smoothPaletteCheck2.CheckedChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			m_Surface2.SmoothPalette = smoothPaletteCheck2.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub transparencyScroll1_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles transparencyScroll1.ValueChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			m_Surface1.FillStyle.SetTransparencyPercent(transparencyScroll1.Value)
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace