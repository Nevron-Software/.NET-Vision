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
	<ToolboxItem(False)>
	Public Class NMeshSurfaceUC
		Inherits NExampleBaseUC

		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox3 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox4 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents customValueScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents positionModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents drawFlatCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents smoothShadingCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents fillModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents smoothPaletteCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents frameColorModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents frameModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			fillModeCombo.Items.Add("None")
			fillModeCombo.Items.Add("Uniform")
			fillModeCombo.Items.Add("Zone")
			fillModeCombo.Items.Add("Zone Texture")

			frameModeCombo.Items.Add("None")
			frameModeCombo.Items.Add("Mesh")
			frameModeCombo.Items.Add("Contour")
			frameModeCombo.Items.Add("Mesh-Contour")
			frameModeCombo.Items.Add("Dots")

			frameColorModeCombo.Items.Add("Uniform")
			frameColorModeCombo.Items.Add("Zone")

			positionModeCombo.Items.Add("Axis Begin")
			positionModeCombo.Items.Add("Axis End")
			positionModeCombo.Items.Add("Custom Value")
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
			Me.nGroupBox4 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.customValueScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label1 = New System.Windows.Forms.Label()
			Me.positionModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.drawFlatCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.smoothShadingCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.fillModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nGroupBox3 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.smoothPaletteCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.frameColorModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.frameModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nGroupBox4.SuspendLayout()
			Me.nGroupBox2.SuspendLayout()
			Me.nGroupBox3.SuspendLayout()
			Me.nGroupBox1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nGroupBox4
			' 
			Me.nGroupBox4.Controls.Add(Me.label3)
			Me.nGroupBox4.Controls.Add(Me.customValueScroll)
			Me.nGroupBox4.Controls.Add(Me.label1)
			Me.nGroupBox4.Controls.Add(Me.positionModeCombo)
			Me.nGroupBox4.Controls.Add(Me.drawFlatCheck)
			Me.nGroupBox4.ImageIndex = 0
			Me.nGroupBox4.Location = New System.Drawing.Point(3, 336)
			Me.nGroupBox4.Name = "nGroupBox4"
			Me.nGroupBox4.Size = New System.Drawing.Size(174, 136)
			Me.nGroupBox4.TabIndex = 3
			Me.nGroupBox4.TabStop = False
			Me.nGroupBox4.Text = "Flat Mode"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(11, 93)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(129, 15)
			Me.label3.TabIndex = 3
			Me.label3.Text = "Custom Value:"
			' 
			' customValueScroll
			' 
			Me.customValueScroll.Enabled = False
			Me.customValueScroll.LargeChange = 1
			Me.customValueScroll.Location = New System.Drawing.Point(11, 109)
			Me.customValueScroll.Maximum = 20
			Me.customValueScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.customValueScroll.Name = "customValueScroll"
			Me.customValueScroll.Size = New System.Drawing.Size(151, 17)
			Me.customValueScroll.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.customValueScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.CustomValueScroll_ValueChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(11, 45)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(129, 16)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Position Mode:"
			' 
			' positionModeCombo
			' 
			Me.positionModeCombo.Enabled = False
			Me.positionModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.positionModeCombo.ListProperties.DataSource = Nothing
			Me.positionModeCombo.ListProperties.DisplayMember = ""
			Me.positionModeCombo.Location = New System.Drawing.Point(11, 61)
			Me.positionModeCombo.Name = "positionModeCombo"
			Me.positionModeCombo.Size = New System.Drawing.Size(151, 21)
			Me.positionModeCombo.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.positionModeCombo.SelectedIndexChanged += new System.EventHandler(this.PositionModeCombo_SelectedIndexChanged);
			' 
			' drawFlatCheck
			' 
			Me.drawFlatCheck.ButtonProperties.BorderOffset = 2
			Me.drawFlatCheck.Location = New System.Drawing.Point(11, 21)
			Me.drawFlatCheck.Name = "drawFlatCheck"
			Me.drawFlatCheck.Size = New System.Drawing.Size(129, 20)
			Me.drawFlatCheck.TabIndex = 0
			Me.drawFlatCheck.Text = "Draw Flat"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.drawFlatCheck.CheckedChanged += new System.EventHandler(this.DrawFlatCheck_CheckedChanged);
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Controls.Add(Me.smoothShadingCheck)
			Me.nGroupBox2.Controls.Add(Me.label4)
			Me.nGroupBox2.Controls.Add(Me.fillModeCombo)
			Me.nGroupBox2.ImageIndex = 0
			Me.nGroupBox2.Location = New System.Drawing.Point(3, 8)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(174, 96)
			Me.nGroupBox2.TabIndex = 0
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "Surface Filling"
			' 
			' smoothShadingCheck
			' 
			Me.smoothShadingCheck.ButtonProperties.BorderOffset = 2
			Me.smoothShadingCheck.Location = New System.Drawing.Point(11, 69)
			Me.smoothShadingCheck.Name = "smoothShadingCheck"
			Me.smoothShadingCheck.Size = New System.Drawing.Size(135, 20)
			Me.smoothShadingCheck.TabIndex = 2
			Me.smoothShadingCheck.Text = "Smooth Shading"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.smoothShadingCheck.CheckedChanged += new System.EventHandler(this.SmoothShadingCheck_CheckedChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(11, 21)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(135, 14)
			Me.label4.TabIndex = 0
			Me.label4.Text = "Fill Mode:"
			' 
			' fillModeCombo
			' 
			Me.fillModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.fillModeCombo.ListProperties.DataSource = Nothing
			Me.fillModeCombo.ListProperties.DisplayMember = ""
			Me.fillModeCombo.Location = New System.Drawing.Point(11, 37)
			Me.fillModeCombo.Name = "fillModeCombo"
			Me.fillModeCombo.Size = New System.Drawing.Size(151, 21)
			Me.fillModeCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.fillModeCombo.SelectedIndexChanged += new System.EventHandler(this.FillModeCombo_SelectedIndexChanged);
			' 
			' nGroupBox3
			' 
			Me.nGroupBox3.Controls.Add(Me.smoothPaletteCheck)
			Me.nGroupBox3.ImageIndex = 0
			Me.nGroupBox3.Location = New System.Drawing.Point(3, 256)
			Me.nGroupBox3.Name = "nGroupBox3"
			Me.nGroupBox3.Size = New System.Drawing.Size(174, 64)
			Me.nGroupBox3.TabIndex = 2
			Me.nGroupBox3.TabStop = False
			Me.nGroupBox3.Text = "Palette"
			' 
			' smoothPaletteCheck
			' 
			Me.smoothPaletteCheck.ButtonProperties.BorderOffset = 2
			Me.smoothPaletteCheck.Location = New System.Drawing.Point(11, 29)
			Me.smoothPaletteCheck.Name = "smoothPaletteCheck"
			Me.smoothPaletteCheck.Size = New System.Drawing.Size(119, 21)
			Me.smoothPaletteCheck.TabIndex = 0
			Me.smoothPaletteCheck.Text = "Smooth Palette"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.smoothPaletteCheck.CheckedChanged += new System.EventHandler(this.SmoothPaletteCheck_CheckedChanged);
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.label5)
			Me.nGroupBox1.Controls.Add(Me.frameColorModeCombo)
			Me.nGroupBox1.Controls.Add(Me.label2)
			Me.nGroupBox1.Controls.Add(Me.frameModeCombo)
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(3, 120)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(174, 120)
			Me.nGroupBox1.TabIndex = 1
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Surface Frame"
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(11, 69)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(150, 14)
			Me.label5.TabIndex = 2
			Me.label5.Text = "Frame Color Mode:"
			' 
			' frameColorModeCombo
			' 
			Me.frameColorModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.frameColorModeCombo.ListProperties.DataSource = Nothing
			Me.frameColorModeCombo.ListProperties.DisplayMember = ""
			Me.frameColorModeCombo.Location = New System.Drawing.Point(11, 85)
			Me.frameColorModeCombo.Name = "frameColorModeCombo"
			Me.frameColorModeCombo.Size = New System.Drawing.Size(150, 21)
			Me.frameColorModeCombo.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.frameColorModeCombo.SelectedIndexChanged += new System.EventHandler(this.FrameColorModeCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(11, 21)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(150, 14)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Frame Mode:"
			' 
			' frameModeCombo
			' 
			Me.frameModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.frameModeCombo.ListProperties.DataSource = Nothing
			Me.frameModeCombo.ListProperties.DisplayMember = ""
			Me.frameModeCombo.Location = New System.Drawing.Point(11, 37)
			Me.frameModeCombo.Name = "frameModeCombo"
			Me.frameModeCombo.Size = New System.Drawing.Size(150, 21)
			Me.frameModeCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.frameModeCombo.SelectedIndexChanged += new System.EventHandler(this.FrameModeCombo_SelectedIndexChanged);
			' 
			' NMeshSurfaceUC
			' 
			Me.Controls.Add(Me.nGroupBox4)
			Me.Controls.Add(Me.nGroupBox2)
			Me.Controls.Add(Me.nGroupBox3)
			Me.Controls.Add(Me.nGroupBox1)
			Me.Name = "NMeshSurfaceUC"
			Me.Size = New System.Drawing.Size(180, 487)
			Me.nGroupBox4.ResumeLayout(False)
			Me.nGroupBox2.ResumeLayout(False)
			Me.nGroupBox3.ResumeLayout(False)
			Me.nGroupBox1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None
			nChartControl1.Controller.Tools.Add(New NSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Mesh Surface Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 60.0F
			chart.Depth = 60.0F
			chart.Height = 25.0F
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)

			' setup axes
			Dim linearScale As New NLinearScaleConfigurator()
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.RoundToTickMax = False
			linearScale.RoundToTickMin = False
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale

			linearScale = New NLinearScaleConfigurator()
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.RoundToTickMax = False
			linearScale.RoundToTickMin = False
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale

			' setup surface series
			Dim surface As NMeshSurfaceSeries = CType(chart.Series.Add(SeriesType.MeshSurface), NMeshSurfaceSeries)
			surface.Name = "Surface"
			surface.Legend.Mode = SeriesLegendMode.SeriesLogic
			surface.FillMode = SurfaceFillMode.Zone
			surface.PositionValue = 0.5
			surface.Data.SetGridSize(20, 20)
			surface.SyncPaletteWithAxisScale = False
			surface.PaletteSteps = 8
			surface.ValueFormatter.FormatSpecifier = "0.00"
			surface.FillStyle = New NColorFillStyle(Color.YellowGreen)

			FillData(surface)

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			' form controls
			fillModeCombo.SelectedIndex = 2
			smoothShadingCheck.Checked = True
			frameModeCombo.SelectedIndex = 2
			frameColorModeCombo.SelectedIndex = 0
			smoothPaletteCheck.Checked = False
			positionModeCombo.SelectedIndex = 0
			customValueScroll.Value = 10
		End Sub

		Private Sub FillData(ByVal surface As NMeshSurfaceSeries)
			Dim x, y, z As Double
			Dim nCountX As Integer = surface.Data.GridSizeX
			Dim nCountZ As Integer = surface.Data.GridSizeZ

			For j As Integer = 0 To nCountZ - 1
				For i As Integer = 0 To nCountX - 1
					x = 2 + i + Math.Sin(j / 4.0) * 2
					z = 1 + j + Math.Cos(i / 4.0)

					y = Math.Sin(i / 3.0) * Math.Sin(j / 3.0)

					If y < 0 Then
						y = Math.Abs(y / 2.0)
					End If

					surface.Data.SetValue(i, j, y, x, z)
				Next i
			Next j
		End Sub

		Private Sub SmoothShadingCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles smoothShadingCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NMeshSurfaceSeries = CType(chart.Series(0), NMeshSurfaceSeries)

			If smoothShadingCheck.Checked Then
				surface.ShadingMode = ShadingMode.Smooth
			Else
				surface.ShadingMode = ShadingMode.Flat
			End If

			nChartControl1.Refresh()
		End Sub
		Private Sub FillModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fillModeCombo.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NMeshSurfaceSeries = CType(chart.Series(0), NMeshSurfaceSeries)

			Select Case fillModeCombo.SelectedIndex
				Case 0
					surface.FillMode = SurfaceFillMode.None
					smoothShadingCheck.Enabled = False

				Case 1
					surface.FillMode = SurfaceFillMode.Uniform
					smoothShadingCheck.Enabled = True

				Case 2
					surface.FillMode = SurfaceFillMode.Zone
					smoothShadingCheck.Enabled = True

				Case 3
					surface.FillMode = SurfaceFillMode.ZoneTexture
					smoothShadingCheck.Enabled = True
			End Select

			nChartControl1.Refresh()
		End Sub
		Private Sub FrameModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles frameModeCombo.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NMeshSurfaceSeries = CType(chart.Series(0), NMeshSurfaceSeries)

			surface.FrameMode = CType(frameModeCombo.SelectedIndex, SurfaceFrameMode)
			nChartControl1.Refresh()

			' form controls
			frameColorModeCombo.Enabled = (surface.FrameMode <> SurfaceFrameMode.None)
		End Sub
		Private Sub FrameColorModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles frameColorModeCombo.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NMeshSurfaceSeries = CType(chart.Series(0), NMeshSurfaceSeries)

			Select Case frameColorModeCombo.SelectedIndex
				Case 0
					surface.FrameColorMode = SurfaceFrameColorMode.Uniform

				Case 1
					surface.FrameColorMode = SurfaceFrameColorMode.Zone
			End Select

			nChartControl1.Refresh()
		End Sub
		Private Sub SmoothPaletteCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles smoothPaletteCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NMeshSurfaceSeries = CType(chart.Series(0), NMeshSurfaceSeries)

			If smoothPaletteCheck.Checked Then
				surface.SmoothPalette = True
				surface.PaletteSteps = 7
				surface.Legend.Format = "<zone_value>"
			Else
				surface.SmoothPalette = False
				surface.PaletteSteps = 8
				surface.Legend.Format = "<zone_begin> - <zone_end>"
			End If

			nChartControl1.Refresh()
		End Sub
		Private Sub DrawFlatCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drawFlatCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NMeshSurfaceSeries = CType(chart.Series(0), NMeshSurfaceSeries)

			surface.DrawFlat = drawFlatCheck.Checked
			nChartControl1.Refresh()

			' form controls
			positionModeCombo.Enabled = drawFlatCheck.Checked
			customValueScroll.Enabled = drawFlatCheck.Checked
		End Sub
		Private Sub PositionModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles positionModeCombo.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NMeshSurfaceSeries = CType(chart.Series(0), NMeshSurfaceSeries)

			surface.PositionMode = CType(positionModeCombo.SelectedIndex, SurfacePositionMode)
			nChartControl1.Refresh()
		End Sub
		Private Sub CustomValueScroll_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles customValueScroll.ValueChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NMeshSurfaceSeries = CType(chart.Series(0), NMeshSurfaceSeries)

			surface.PositionValue = customValueScroll.Value / 20.0F
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace