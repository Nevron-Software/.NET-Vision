Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.Chart
Imports Nevron.GraphicsCore
Imports Nevron.UI
Imports Nevron.Editors

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Partial Public Class NHeatMapContourUC
		Inherits NExampleBaseUC

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		Private m_HeatMap As NHeatMapSeries

		Private WithEvents OriginXUpDown As UI.WinForm.Controls.NNumericUpDown
		Private label9 As Label
		Private WithEvents OriginYUpDown As UI.WinForm.Controls.NNumericUpDown
		Private label1 As Label
		Private WithEvents StepXUpDown As UI.WinForm.Controls.NNumericUpDown
		Private label2 As Label
		Private WithEvents StepYUpDown As UI.WinForm.Controls.NNumericUpDown
		Private label3 As Label
		Private WithEvents ContourDisplayModeCombo As UI.WinForm.Controls.NComboBox
		Private label4 As Label
		Private WithEvents ContourColorModeCombo As UI.WinForm.Controls.NComboBox
		Private label5 As Label
		Private WithEvents ShowFillCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents SmoothPaletteCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents InterpolateImageCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents GridDisplayModeComboBox As UI.WinForm.Controls.NComboBox
		Private label6 As Label
		Private WithEvents ContourStrokeStyleButton As UI.WinForm.Controls.NButton
		Private WithEvents ContourDotSizeNumericUpDown As UI.WinForm.Controls.NNumericUpDown
		Private label7 As Label
		Private WithEvents GridDotSizeNumericUpDown As UI.WinForm.Controls.NNumericUpDown
		Private label8 As Label
		Private WithEvents GridStrokeStyleButton As UI.WinForm.Controls.NButton
		Private groupBox1 As GroupBox
		Private groupBox2 As GroupBox
		Private groupBox3 As GroupBox

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

		Private Sub InitializeComponent()
			Me.OriginXUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label9 = New System.Windows.Forms.Label()
			Me.OriginYUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label1 = New System.Windows.Forms.Label()
			Me.StepXUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			Me.StepYUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label3 = New System.Windows.Forms.Label()
			Me.ContourDisplayModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.ContourColorModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.ShowFillCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SmoothPaletteCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.InterpolateImageCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.GridDisplayModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.ContourStrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ContourDotSizeNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label7 = New System.Windows.Forms.Label()
			Me.GridDotSizeNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label8 = New System.Windows.Forms.Label()
			Me.GridStrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.groupBox1 = New System.Windows.Forms.GroupBox()
			Me.groupBox2 = New System.Windows.Forms.GroupBox()
			Me.groupBox3 = New System.Windows.Forms.GroupBox()
			DirectCast(Me.OriginXUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.OriginYUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.StepXUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.StepYUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.ContourDotSizeNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.GridDotSizeNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.groupBox3.SuspendLayout()
			Me.SuspendLayout()
			' 
			' OriginXUpDown
			' 
			Me.OriginXUpDown.Location = New System.Drawing.Point(93, 16)
			Me.OriginXUpDown.Name = "OriginXUpDown"
			Me.OriginXUpDown.Size = New System.Drawing.Size(72, 20)
			Me.OriginXUpDown.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OriginXUpDown.ValueChanged += new System.EventHandler(this.OriginXUpDown_ValueChanged);
			' 
			' label9
			' 
			Me.label9.Location = New System.Drawing.Point(6, 16)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(48, 20)
			Me.label9.TabIndex = 0
			Me.label9.Text = "Origin X:"
			Me.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' OriginYUpDown
			' 
			Me.OriginYUpDown.Location = New System.Drawing.Point(93, 42)
			Me.OriginYUpDown.Name = "OriginYUpDown"
			Me.OriginYUpDown.Size = New System.Drawing.Size(72, 20)
			Me.OriginYUpDown.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OriginYUpDown.ValueChanged += new System.EventHandler(this.OriginYUpDown_ValueChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(6, 42)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(48, 20)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Origin Y:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' StepXUpDown
			' 
			Me.StepXUpDown.Location = New System.Drawing.Point(93, 68)
			Me.StepXUpDown.Name = "StepXUpDown"
			Me.StepXUpDown.Size = New System.Drawing.Size(72, 20)
			Me.StepXUpDown.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StepXUpDown.ValueChanged += new System.EventHandler(this.StepXUpDown_ValueChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(6, 68)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(48, 20)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Step X:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' StepYUpDown
			' 
			Me.StepYUpDown.Location = New System.Drawing.Point(93, 94)
			Me.StepYUpDown.Name = "StepYUpDown"
			Me.StepYUpDown.Size = New System.Drawing.Size(72, 20)
			Me.StepYUpDown.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StepYUpDown.ValueChanged += new System.EventHandler(this.StepYUpDown_ValueChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(6, 94)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(48, 20)
			Me.label3.TabIndex = 6
			Me.label3.Text = "Step Y:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' ContourDisplayModeCombo
			' 
			Me.ContourDisplayModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.ContourDisplayModeCombo.ListProperties.DataSource = Nothing
			Me.ContourDisplayModeCombo.ListProperties.DisplayMember = ""
			Me.ContourDisplayModeCombo.Location = New System.Drawing.Point(6, 32)
			Me.ContourDisplayModeCombo.Name = "ContourDisplayModeCombo"
			Me.ContourDisplayModeCombo.Size = New System.Drawing.Size(159, 21)
			Me.ContourDisplayModeCombo.TabIndex = 9
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ContourDisplayModeCombo.SelectedIndexChanged += new System.EventHandler(this.ContourDisplayModeCombo_SelectedIndexChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(6, 16)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(159, 21)
			Me.label4.TabIndex = 8
			Me.label4.Text = "Contour Display Mode:"
			' 
			' ContourColorModeCombo
			' 
			Me.ContourColorModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.ContourColorModeCombo.ListProperties.DataSource = Nothing
			Me.ContourColorModeCombo.ListProperties.DisplayMember = ""
			Me.ContourColorModeCombo.Location = New System.Drawing.Point(6, 70)
			Me.ContourColorModeCombo.Name = "ContourColorModeCombo"
			Me.ContourColorModeCombo.Size = New System.Drawing.Size(159, 21)
			Me.ContourColorModeCombo.TabIndex = 11
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ContourColorModeCombo.SelectedIndexChanged += new System.EventHandler(this.ContourColorModeCombo_SelectedIndexChanged);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(6, 56)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(159, 21)
			Me.label5.TabIndex = 10
			Me.label5.Text = "Contour Color Mode:"
			' 
			' ShowFillCheckBox
			' 
			Me.ShowFillCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowFillCheckBox.Location = New System.Drawing.Point(6, 437)
			Me.ShowFillCheckBox.Name = "ShowFillCheckBox"
			Me.ShowFillCheckBox.Size = New System.Drawing.Size(150, 24)
			Me.ShowFillCheckBox.TabIndex = 12
			Me.ShowFillCheckBox.Text = "Show Fill"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowFillCheckBox.CheckedChanged += new System.EventHandler(this.ShowFillCheckBox_CheckedChanged);
			' 
			' SmoothPaletteCheckBox
			' 
			Me.SmoothPaletteCheckBox.ButtonProperties.BorderOffset = 2
			Me.SmoothPaletteCheckBox.Location = New System.Drawing.Point(6, 458)
			Me.SmoothPaletteCheckBox.Name = "SmoothPaletteCheckBox"
			Me.SmoothPaletteCheckBox.Size = New System.Drawing.Size(150, 24)
			Me.SmoothPaletteCheckBox.TabIndex = 13
			Me.SmoothPaletteCheckBox.Text = "Smooth Palette"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SmoothPaletteCheckBox.CheckedChanged += new System.EventHandler(this.SmoothPaletteCheckBox_CheckedChanged);
			' 
			' InterpolateImageCheckBox
			' 
			Me.InterpolateImageCheckBox.ButtonProperties.BorderOffset = 2
			Me.InterpolateImageCheckBox.Location = New System.Drawing.Point(6, 479)
			Me.InterpolateImageCheckBox.Name = "InterpolateImageCheckBox"
			Me.InterpolateImageCheckBox.Size = New System.Drawing.Size(150, 24)
			Me.InterpolateImageCheckBox.TabIndex = 14
			Me.InterpolateImageCheckBox.Text = "Interpolate Image"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InterpolateImageCheckBox.CheckedChanged += new System.EventHandler(this.InterpolateImageCheckBox_CheckedChanged);
			' 
			' GridDisplayModeComboBox
			' 
			Me.GridDisplayModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.GridDisplayModeComboBox.ListProperties.DataSource = Nothing
			Me.GridDisplayModeComboBox.ListProperties.DisplayMember = ""
			Me.GridDisplayModeComboBox.Location = New System.Drawing.Point(6, 32)
			Me.GridDisplayModeComboBox.Name = "GridDisplayModeComboBox"
			Me.GridDisplayModeComboBox.Size = New System.Drawing.Size(162, 21)
			Me.GridDisplayModeComboBox.TabIndex = 16
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GridDisplayModeComboBox.SelectedIndexChanged += new System.EventHandler(this.GridDisplayModeComboBox_SelectedIndexChanged);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(6, 16)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(159, 21)
			Me.label6.TabIndex = 15
			Me.label6.Text = "Grid Display Mode:"
			' 
			' ContourStrokeStyleButton
			' 
			Me.ContourStrokeStyleButton.Location = New System.Drawing.Point(6, 109)
			Me.ContourStrokeStyleButton.Name = "ContourStrokeStyleButton"
			Me.ContourStrokeStyleButton.Size = New System.Drawing.Size(159, 24)
			Me.ContourStrokeStyleButton.TabIndex = 17
			Me.ContourStrokeStyleButton.Text = "Contour Stroke Style ..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ContourStrokeStyleButton.Click += new System.EventHandler(this.ContourStrokeStyleButton_Click);
			' 
			' ContourDotSizeNumericUpDown
			' 
			Me.ContourDotSizeNumericUpDown.Location = New System.Drawing.Point(106, 139)
			Me.ContourDotSizeNumericUpDown.Name = "ContourDotSizeNumericUpDown"
			Me.ContourDotSizeNumericUpDown.Size = New System.Drawing.Size(59, 20)
			Me.ContourDotSizeNumericUpDown.TabIndex = 19
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ContourDotSizeNumericUpDown.ValueChanged += new System.EventHandler(this.ContourDotSizeNumericUpDown_ValueChanged);
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(6, 139)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(94, 20)
			Me.label7.TabIndex = 18
			Me.label7.Text = "Contour Dot Size:"
			Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' GridDotSizeNumericUpDown
			' 
			Me.GridDotSizeNumericUpDown.Location = New System.Drawing.Point(109, 89)
			Me.GridDotSizeNumericUpDown.Name = "GridDotSizeNumericUpDown"
			Me.GridDotSizeNumericUpDown.Size = New System.Drawing.Size(59, 20)
			Me.GridDotSizeNumericUpDown.TabIndex = 22
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GridDotSizeNumericUpDown.ValueChanged += new System.EventHandler(this.GridDotSizeNumericUpDown_ValueChanged);
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(6, 89)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(94, 20)
			Me.label8.TabIndex = 21
			Me.label8.Text = "Grid Dot Size:"
			Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' GridStrokeStyleButton
			' 
			Me.GridStrokeStyleButton.Location = New System.Drawing.Point(6, 59)
			Me.GridStrokeStyleButton.Name = "GridStrokeStyleButton"
			Me.GridStrokeStyleButton.Size = New System.Drawing.Size(162, 24)
			Me.GridStrokeStyleButton.TabIndex = 20
			Me.GridStrokeStyleButton.Text = "Grid Stroke Style ..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GridStrokeStyleButton.Click += new System.EventHandler(this.GridStrokeStyleButton_Click);
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.label9)
			Me.groupBox1.Controls.Add(Me.OriginXUpDown)
			Me.groupBox1.Controls.Add(Me.label1)
			Me.groupBox1.Controls.Add(Me.OriginYUpDown)
			Me.groupBox1.Controls.Add(Me.label2)
			Me.groupBox1.Controls.Add(Me.StepXUpDown)
			Me.groupBox1.Controls.Add(Me.label3)
			Me.groupBox1.Controls.Add(Me.StepYUpDown)
			Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox1.Location = New System.Drawing.Point(0, 0)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(179, 124)
			Me.groupBox1.TabIndex = 23
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Position"
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.ContourDisplayModeCombo)
			Me.groupBox2.Controls.Add(Me.ContourColorModeCombo)
			Me.groupBox2.Controls.Add(Me.label4)
			Me.groupBox2.Controls.Add(Me.label5)
			Me.groupBox2.Controls.Add(Me.ContourStrokeStyleButton)
			Me.groupBox2.Controls.Add(Me.ContourDotSizeNumericUpDown)
			Me.groupBox2.Controls.Add(Me.label7)
			Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox2.Location = New System.Drawing.Point(0, 124)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(179, 182)
			Me.groupBox2.TabIndex = 24
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Contour"
			' 
			' groupBox3
			' 
			Me.groupBox3.Controls.Add(Me.GridDisplayModeComboBox)
			Me.groupBox3.Controls.Add(Me.label6)
			Me.groupBox3.Controls.Add(Me.GridStrokeStyleButton)
			Me.groupBox3.Controls.Add(Me.GridDotSizeNumericUpDown)
			Me.groupBox3.Controls.Add(Me.label8)
			Me.groupBox3.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox3.Location = New System.Drawing.Point(0, 306)
			Me.groupBox3.Name = "groupBox3"
			Me.groupBox3.Size = New System.Drawing.Size(179, 124)
			Me.groupBox3.TabIndex = 25
			Me.groupBox3.TabStop = False
			Me.groupBox3.Text = "Grid"
			' 
			' NHeatMapContourUC
			' 
			Me.Controls.Add(Me.groupBox3)
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.InterpolateImageCheckBox)
			Me.Controls.Add(Me.SmoothPaletteCheckBox)
			Me.Controls.Add(Me.ShowFillCheckBox)
			Me.Name = "NHeatMapContourUC"
			Me.Size = New System.Drawing.Size(179, 516)
			DirectCast(Me.OriginXUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.OriginYUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.StepXUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.StepYUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.ContourDotSizeNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.GridDotSizeNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox2.ResumeLayout(False)
			Me.groupBox3.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("Heat Map Contour")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			Dim chart As NChart = nChartControl1.Charts(0)

			chart.BoundsMode = BoundsMode.Stretch
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()

			' create the heat map 
			m_HeatMap = New NHeatMapSeries()
			chart.Series.Add(m_HeatMap)

			m_HeatMap.Palette.Add(0.0, Color.Purple)
			m_HeatMap.Palette.Add(1.5, Color.MediumSlateBlue)
			m_HeatMap.Palette.Add(3.0, Color.CornflowerBlue)
			m_HeatMap.Palette.Add(4.5, Color.LimeGreen)
			m_HeatMap.Palette.Add(6.0, Color.LightGreen)
			m_HeatMap.Palette.Add(7.5, Color.Yellow)
			m_HeatMap.Palette.Add(9.0, Color.Orange)
			m_HeatMap.Palette.Add(10.5, Color.Red)
			m_HeatMap.XValuesMode = HeatMapValuesMode.OriginAndStep
			m_HeatMap.YValuesMode = HeatMapValuesMode.OriginAndStep

			m_HeatMap.ContourDisplayMode = ContourDisplayMode.Contour
			m_HeatMap.Legend.Mode = SeriesLegendMode.SeriesLogic
			m_HeatMap.Legend.Format = "<zone_value>"

			GenerateData()

			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			' init form controls
			OriginXUpDown.Value = 0
			OriginYUpDown.Value = 0
			StepXUpDown.Value = 1
			StepYUpDown.Value = 1

			ContourDisplayModeCombo.FillFromEnum(GetType(ContourDisplayMode))
			ContourColorModeCombo.FillFromEnum(GetType(ContourColorMode))
			GridDisplayModeComboBox.FillFromEnum(GetType(HeatMapGridDisplayMode))

			ContourDisplayModeCombo.SelectedIndex = CInt(ContourDisplayMode.Contour)
			GridDisplayModeComboBox.SelectedIndex = CInt(HeatMapGridDisplayMode.None)
			GridDotSizeNumericUpDown.Value = CDec(2)
			ContourColorModeCombo.SelectedIndex = CInt(ContourColorMode.Uniform)
			ContourDotSizeNumericUpDown.Value = CDec(2)

			ShowFillCheckBox.Checked = True
			SmoothPaletteCheckBox.Checked = True
		End Sub

		Private Sub GenerateData()
			Dim data As NHeatMapData = m_HeatMap.Data

			Dim GridStepX As Integer = 60
			Dim GridStepY As Integer = 60
			data.SetGridSize(GridStepX, GridStepY)

			Const dIntervalX As Double = 10.0
			Const dIntervalZ As Double = 10.0
			Dim dIncrementX As Double = (dIntervalX / GridStepX)
			Dim dIncrementZ As Double = (dIntervalZ / GridStepY)

			Dim y, x, z As Double

			z = -(dIntervalZ / 2)

			Dim col As Integer = 0
			Do While col < GridStepX
				x = -(dIntervalX / 2)

				Dim row As Integer = 0
				Do While row < GridStepY
					y = 10 - Math.Sqrt((x * x) + (z * z) + 2)
					y += 3.0 * Math.Sin(x) * Math.Cos(z)

					Dim value As Double = y

					data.SetValue(row, col, value)
					row += 1
					x += dIncrementX
				Loop
				col += 1
				z += dIncrementZ
			Loop
		End Sub

		Private Sub UpdateHeatMapSeries()
			' position
			m_HeatMap.OriginX = CDbl(OriginXUpDown.Value)
			m_HeatMap.OriginY = CDbl(OriginYUpDown.Value)
			m_HeatMap.StepX = CDbl(StepXUpDown.Value)
			m_HeatMap.StepY = CDbl(StepYUpDown.Value)

			' contour
			m_HeatMap.ContourDisplayMode = CType(ContourDisplayModeCombo.SelectedIndex, ContourDisplayMode)
			m_HeatMap.ContourColorMode = CType(ContourColorModeCombo.SelectedIndex, ContourColorMode)
			m_HeatMap.ContourDotSize = New NSizeL(CSng(ContourDotSizeNumericUpDown.Value), CSng(ContourDotSizeNumericUpDown.Value))

			' grid
			m_HeatMap.GridDisplayMode = CType(GridDisplayModeComboBox.SelectedIndex, HeatMapGridDisplayMode)
			m_HeatMap.GridDotSize = New NSizeL(CSng(GridDotSizeNumericUpDown.Value), CSng(GridDotSizeNumericUpDown.Value))

			m_HeatMap.ShowFill = ShowFillCheckBox.Checked
			m_HeatMap.Palette.SmoothPalette = SmoothPaletteCheckBox.Checked
			m_HeatMap.InterpolateImage = InterpolateImageCheckBox.Checked

			If m_HeatMap.Palette.SmoothPalette Then
				m_HeatMap.Legend.Format = "<zone_value>"
			Else
				m_HeatMap.Legend.Format = "<zone_begin> - <zone_end>"
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub OriginXUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles OriginXUpDown.ValueChanged
			UpdateHeatMapSeries()
		End Sub

		Private Sub OriginYUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles OriginYUpDown.ValueChanged
			UpdateHeatMapSeries()
		End Sub

		Private Sub StepXUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles StepXUpDown.ValueChanged
			UpdateHeatMapSeries()
		End Sub

		Private Sub StepYUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles StepYUpDown.ValueChanged
			UpdateHeatMapSeries()
		End Sub

		Private Sub ContourDisplayModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ContourDisplayModeCombo.SelectedIndexChanged
			UpdateHeatMapSeries()
		End Sub

		Private Sub ContourColorModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ContourColorModeCombo.SelectedIndexChanged
			UpdateHeatMapSeries()
		End Sub

		Private Sub ShowFillCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowFillCheckBox.CheckedChanged
			UpdateHeatMapSeries()
		End Sub

		Private Sub SmoothPaletteCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SmoothPaletteCheckBox.CheckedChanged
			UpdateHeatMapSeries()
		End Sub

		Private Sub InterpolateImageCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles InterpolateImageCheckBox.CheckedChanged
			UpdateHeatMapSeries()
		End Sub

		Private Sub ContourDotSizeNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ContourDotSizeNumericUpDown.ValueChanged
			UpdateHeatMapSeries()
		End Sub

		Private Sub GridDisplayModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridDisplayModeComboBox.SelectedIndexChanged
			UpdateHeatMapSeries()
		End Sub

		Private Sub GridDotSizeNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridDotSizeNumericUpDown.ValueChanged
			UpdateHeatMapSeries()
		End Sub

		Private Sub ContourStrokeStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ContourStrokeStyleButton.Click
			If m_HeatMap IsNot Nothing Then
				Dim strokeStyleResult As NStrokeStyle = Nothing

				If NStrokeStyleTypeEditor.Edit(m_HeatMap.ContourStrokeStyle, strokeStyleResult) Then
					m_HeatMap.ContourStrokeStyle = strokeStyleResult
					nChartControl1.Refresh()
				End If
			End If
		End Sub

		Private Sub GridStrokeStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles GridStrokeStyleButton.Click
			If m_HeatMap IsNot Nothing Then
				Dim strokeStyleResult As NStrokeStyle = Nothing

				If NStrokeStyleTypeEditor.Edit(m_HeatMap.GridStrokeStyle, strokeStyleResult) Then
					m_HeatMap.GridStrokeStyle = strokeStyleResult
					nChartControl1.Refresh()
				End If
			End If

		End Sub
	End Class
End Namespace
