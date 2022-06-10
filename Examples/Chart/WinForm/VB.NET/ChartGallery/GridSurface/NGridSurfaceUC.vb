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
	Public Class NGridSurfaceUC
		Inherits NExampleBaseUC

		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox3 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents smoothPaletteCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents smoothShadingCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents fillModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents frameColorModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents frameModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents customValueScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents positionModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents drawFlatCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private nGroupBox4 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents PaletteLegendModeComboBox As UI.WinForm.Controls.NComboBox
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			fillModeCombo.Items.Add("None")
			fillModeCombo.Items.Add("Uniform")
			fillModeCombo.Items.Add("Zone")

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

			PaletteLegendModeComboBox.FillFromEnum(GetType(PaletteLegendMode))
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
			Me.nGroupBox3 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.smoothPaletteCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.smoothShadingCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.fillModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.frameColorModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.frameModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nGroupBox4 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.customValueScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label1 = New System.Windows.Forms.Label()
			Me.positionModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.drawFlatCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.PaletteLegendModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nGroupBox3.SuspendLayout()
			Me.nGroupBox2.SuspendLayout()
			Me.nGroupBox1.SuspendLayout()
			Me.nGroupBox4.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nGroupBox3
			' 
			Me.nGroupBox3.Controls.Add(Me.PaletteLegendModeComboBox)
			Me.nGroupBox3.Controls.Add(Me.smoothPaletteCheck)
			Me.nGroupBox3.ImageIndex = 0
			Me.nGroupBox3.Location = New System.Drawing.Point(1, 253)
			Me.nGroupBox3.Name = "nGroupBox3"
			Me.nGroupBox3.Size = New System.Drawing.Size(171, 98)
			Me.nGroupBox3.TabIndex = 6
			Me.nGroupBox3.TabStop = False
			Me.nGroupBox3.Text = "Palette"
			' 
			' smoothPaletteCheck
			' 
			Me.smoothPaletteCheck.ButtonProperties.BorderOffset = 2
			Me.smoothPaletteCheck.Location = New System.Drawing.Point(17, 29)
			Me.smoothPaletteCheck.Name = "smoothPaletteCheck"
			Me.smoothPaletteCheck.Size = New System.Drawing.Size(142, 21)
			Me.smoothPaletteCheck.TabIndex = 0
			Me.smoothPaletteCheck.Text = "Smooth Palette"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.smoothPaletteCheck.CheckedChanged += new System.EventHandler(this.SmoothPaletteCheck_CheckedChanged);
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Controls.Add(Me.smoothShadingCheck)
			Me.nGroupBox2.Controls.Add(Me.label4)
			Me.nGroupBox2.Controls.Add(Me.fillModeCombo)
			Me.nGroupBox2.ImageIndex = 0
			Me.nGroupBox2.Location = New System.Drawing.Point(1, 5)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(174, 96)
			Me.nGroupBox2.TabIndex = 4
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "Surface Filling"
			' 
			' smoothShadingCheck
			' 
			Me.smoothShadingCheck.ButtonProperties.BorderOffset = 2
			Me.smoothShadingCheck.Location = New System.Drawing.Point(17, 69)
			Me.smoothShadingCheck.Name = "smoothShadingCheck"
			Me.smoothShadingCheck.Size = New System.Drawing.Size(158, 20)
			Me.smoothShadingCheck.TabIndex = 2
			Me.smoothShadingCheck.Text = "Smooth Shading"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.smoothShadingCheck.CheckedChanged += new System.EventHandler(this.SmoothShadingCheck_CheckedChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(17, 21)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(142, 14)
			Me.label4.TabIndex = 0
			Me.label4.Text = "Fill Mode:"
			' 
			' fillModeCombo
			' 
			Me.fillModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.fillModeCombo.ListProperties.DataSource = Nothing
			Me.fillModeCombo.ListProperties.DisplayMember = ""
			Me.fillModeCombo.Location = New System.Drawing.Point(17, 37)
			Me.fillModeCombo.Name = "fillModeCombo"
			Me.fillModeCombo.Size = New System.Drawing.Size(142, 21)
			Me.fillModeCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.fillModeCombo.SelectedIndexChanged += new System.EventHandler(this.FillModeCombo_SelectedIndexChanged);
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.label5)
			Me.nGroupBox1.Controls.Add(Me.frameColorModeCombo)
			Me.nGroupBox1.Controls.Add(Me.label2)
			Me.nGroupBox1.Controls.Add(Me.frameModeCombo)
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(1, 117)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(174, 120)
			Me.nGroupBox1.TabIndex = 5
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Surface Frame"
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(17, 69)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(142, 14)
			Me.label5.TabIndex = 2
			Me.label5.Text = "Frame Color Mode:"
			' 
			' frameColorModeCombo
			' 
			Me.frameColorModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.frameColorModeCombo.ListProperties.DataSource = Nothing
			Me.frameColorModeCombo.ListProperties.DisplayMember = ""
			Me.frameColorModeCombo.Location = New System.Drawing.Point(17, 85)
			Me.frameColorModeCombo.Name = "frameColorModeCombo"
			Me.frameColorModeCombo.Size = New System.Drawing.Size(142, 21)
			Me.frameColorModeCombo.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.frameColorModeCombo.SelectedIndexChanged += new System.EventHandler(this.FrameColorModeCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(17, 21)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(142, 14)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Frame Mode:"
			' 
			' frameModeCombo
			' 
			Me.frameModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.frameModeCombo.ListProperties.DataSource = Nothing
			Me.frameModeCombo.ListProperties.DisplayMember = ""
			Me.frameModeCombo.Location = New System.Drawing.Point(17, 37)
			Me.frameModeCombo.Name = "frameModeCombo"
			Me.frameModeCombo.Size = New System.Drawing.Size(142, 21)
			Me.frameModeCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.frameModeCombo.SelectedIndexChanged += new System.EventHandler(this.FrameModeCombo_SelectedIndexChanged);
			' 
			' nGroupBox4
			' 
			Me.nGroupBox4.Controls.Add(Me.label3)
			Me.nGroupBox4.Controls.Add(Me.customValueScroll)
			Me.nGroupBox4.Controls.Add(Me.label1)
			Me.nGroupBox4.Controls.Add(Me.positionModeCombo)
			Me.nGroupBox4.Controls.Add(Me.drawFlatCheck)
			Me.nGroupBox4.ImageIndex = 0
			Me.nGroupBox4.Location = New System.Drawing.Point(1, 357)
			Me.nGroupBox4.Name = "nGroupBox4"
			Me.nGroupBox4.Size = New System.Drawing.Size(174, 136)
			Me.nGroupBox4.TabIndex = 7
			Me.nGroupBox4.TabStop = False
			Me.nGroupBox4.Text = "Flat Mode"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(17, 93)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(152, 15)
			Me.label3.TabIndex = 3
			Me.label3.Text = "Custom Value:"
			' 
			' customValueScroll
			' 
			Me.customValueScroll.Enabled = False
			Me.customValueScroll.LargeChange = 1
			Me.customValueScroll.Location = New System.Drawing.Point(17, 109)
			Me.customValueScroll.Maximum = 20
			Me.customValueScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.customValueScroll.Name = "customValueScroll"
			Me.customValueScroll.Size = New System.Drawing.Size(142, 17)
			Me.customValueScroll.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.customValueScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.CustomValueScroll_ValueChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(17, 45)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(152, 16)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Position Mode:"
			' 
			' positionModeCombo
			' 
			Me.positionModeCombo.Enabled = False
			Me.positionModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.positionModeCombo.ListProperties.DataSource = Nothing
			Me.positionModeCombo.ListProperties.DisplayMember = ""
			Me.positionModeCombo.Location = New System.Drawing.Point(17, 61)
			Me.positionModeCombo.Name = "positionModeCombo"
			Me.positionModeCombo.Size = New System.Drawing.Size(142, 21)
			Me.positionModeCombo.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.positionModeCombo.SelectedIndexChanged += new System.EventHandler(this.PositionModeCombo_SelectedIndexChanged);
			' 
			' drawFlatCheck
			' 
			Me.drawFlatCheck.ButtonProperties.BorderOffset = 2
			Me.drawFlatCheck.Location = New System.Drawing.Point(17, 21)
			Me.drawFlatCheck.Name = "drawFlatCheck"
			Me.drawFlatCheck.Size = New System.Drawing.Size(152, 20)
			Me.drawFlatCheck.TabIndex = 0
			Me.drawFlatCheck.Text = "Draw Flat"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.drawFlatCheck.CheckedChanged += new System.EventHandler(this.DrawFlatCheck_CheckedChanged);
			' 
			' PaletteLegendModeComboBox
			' 
			Me.PaletteLegendModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.PaletteLegendModeComboBox.ListProperties.DataSource = Nothing
			Me.PaletteLegendModeComboBox.ListProperties.DisplayMember = ""
			Me.PaletteLegendModeComboBox.Location = New System.Drawing.Point(17, 56)
			Me.PaletteLegendModeComboBox.Name = "PaletteLegendModeComboBox"
			Me.PaletteLegendModeComboBox.Size = New System.Drawing.Size(142, 21)
			Me.PaletteLegendModeComboBox.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PaletteLegendModeComboBox.SelectedIndexChanged += new System.EventHandler(this.PaletteLegendModeComboBox_SelectedIndexChanged);
			' 
			' NGridSurfaceUC
			' 
			Me.Controls.Add(Me.nGroupBox3)
			Me.Controls.Add(Me.nGroupBox2)
			Me.Controls.Add(Me.nGroupBox1)
			Me.Controls.Add(Me.nGroupBox4)
			Me.Name = "NGridSurfaceUC"
			Me.Size = New System.Drawing.Size(180, 496)
			Me.nGroupBox3.ResumeLayout(False)
			Me.nGroupBox2.ResumeLayout(False)
			Me.nGroupBox1.ResumeLayout(False)
			Me.nGroupBox4.ResumeLayout(False)
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
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Surface Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 60.0F
			chart.Depth = 60.0F
			chart.Height = 25.0F
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft)

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
			Dim surface As NGridSurfaceSeries = CType(chart.Series.Add(SeriesType.GridSurface), NGridSurfaceSeries)
			surface.Name = "Surface"
			surface.Legend.Mode = SeriesLegendMode.SeriesLogic
			surface.PositionValue = 10.0
			surface.Data.SetGridSize(100, 100)
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
			PaletteLegendModeComboBox.SelectedIndex = CInt(PaletteLegendMode.GradientAxis)
		End Sub

		Private Sub FillData(ByVal surface As NGridSurfaceSeries)
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
					y = (x * z / 64.0) - Math.Sin(z / 2.4) * Math.Cos(x / 2.4)
					y = 10 * Math.Sqrt(Math.Abs(y))

					If y <= 0 Then
						y = 1 + Math.Cos(x / 2.4)
					End If

					surface.Data.SetValue(i, j, y)
					i += 1
					x += dIncrementX
				Loop
				j += 1
				z += dIncrementZ
			Loop
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

		Private Sub FillModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fillModeCombo.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NGridSurfaceSeries = CType(chart.Series(0), NGridSurfaceSeries)

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
			End Select

			nChartControl1.Refresh()
		End Sub
		Private Sub FrameModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles frameModeCombo.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NGridSurfaceSeries = CType(chart.Series(0), NGridSurfaceSeries)

			surface.FrameMode = CType(frameModeCombo.SelectedIndex, SurfaceFrameMode)
			nChartControl1.Refresh()

			' form controls
			frameColorModeCombo.Enabled = (surface.FrameMode <> SurfaceFrameMode.None)
		End Sub
		Private Sub FrameColorModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles frameColorModeCombo.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NGridSurfaceSeries = CType(chart.Series(0), NGridSurfaceSeries)

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
			Dim surface As NGridSurfaceSeries = CType(chart.Series(0), NGridSurfaceSeries)

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
			Dim surface As NGridSurfaceSeries = CType(chart.Series(0), NGridSurfaceSeries)

			surface.DrawFlat = drawFlatCheck.Checked
			nChartControl1.Refresh()

			' form controls
			positionModeCombo.Enabled = drawFlatCheck.Checked
			customValueScroll.Enabled = drawFlatCheck.Checked
		End Sub
		Private Sub PositionModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles positionModeCombo.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NGridSurfaceSeries = CType(chart.Series(0), NGridSurfaceSeries)

			surface.PositionMode = CType(positionModeCombo.SelectedIndex, SurfacePositionMode)
			nChartControl1.Refresh()
		End Sub
		Private Sub CustomValueScroll_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles customValueScroll.ValueChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NGridSurfaceSeries = CType(chart.Series(0), NGridSurfaceSeries)

			surface.PositionValue = customValueScroll.Value
			nChartControl1.Refresh()
		End Sub

		Private Sub PaletteLegendModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles PaletteLegendModeComboBox.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NGridSurfaceSeries = CType(chart.Series(0), NGridSurfaceSeries)

			surface.Legend.PaletteLegendMode = CType(PaletteLegendModeComboBox.SelectedIndex, PaletteLegendMode)
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace