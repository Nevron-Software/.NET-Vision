Imports System
Imports System.Resources
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.UI.WinForm.Controls
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NValueTimelineScaleAdvancedUC
		Inherits NExampleBaseUC

		Private m_Chart As NCartesianChart
		Private m_Stock As NStockSeries

		Private label2 As System.Windows.Forms.Label
		Private label11 As System.Windows.Forms.Label
		Private label10 As System.Windows.Forms.Label
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents ThirdRowVisibleCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ThirdRowModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label12 As System.Windows.Forms.Label
		Private WithEvents ThirdRowUnitCountUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents ThirdRowUnitComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents SecondRowVisibleCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents SecondRowModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label8 As System.Windows.Forms.Label
		Private WithEvents SecondRowUnitComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label7 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private WithEvents SecondRowUnitCountUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents FirstRowVisibleCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents FirstRowModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents FirstRowUnitComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private WithEvents ThirdRowTextStyleButton As NButton
		Private WithEvents SecondRowTextStyleButton As NButton
		Private WithEvents FirstRowTextStyleButton As NButton
		Private WithEvents FirstRowUnitCountUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label11 = New System.Windows.Forms.Label()
			Me.label10 = New System.Windows.Forms.Label()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.ThirdRowVisibleCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ThirdRowModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label12 = New System.Windows.Forms.Label()
			Me.ThirdRowUnitCountUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.ThirdRowUnitComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.SecondRowVisibleCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SecondRowModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label8 = New System.Windows.Forms.Label()
			Me.SecondRowUnitComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label7 = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.SecondRowUnitCountUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.FirstRowVisibleCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.FirstRowModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.FirstRowUnitComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.FirstRowUnitCountUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.FirstRowTextStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SecondRowTextStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ThirdRowTextStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.nGroupBox2.SuspendLayout()
			DirectCast(Me.ThirdRowUnitCountUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nGroupBox1.SuspendLayout()
			DirectCast(Me.SecondRowUnitCountUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox2.SuspendLayout()
			DirectCast(Me.FirstRowUnitCountUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(6, 48)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(37, 13)
			Me.label2.TabIndex = 1
			Me.label2.Text = "Mode:"
			' 
			' label11
			' 
			Me.label11.AutoSize = True
			Me.label11.Location = New System.Drawing.Point(6, 73)
			Me.label11.Name = "label11"
			Me.label11.Size = New System.Drawing.Size(29, 13)
			Me.label11.TabIndex = 3
			Me.label11.Text = "Unit:"
			' 
			' label10
			' 
			Me.label10.Location = New System.Drawing.Point(6, 95)
			Me.label10.Name = "label10"
			Me.label10.Size = New System.Drawing.Size(37, 16)
			Me.label10.TabIndex = 5
			Me.label10.Text = "Count:"
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Controls.Add(Me.ThirdRowTextStyleButton)
			Me.nGroupBox2.Controls.Add(Me.ThirdRowVisibleCheckBox)
			Me.nGroupBox2.Controls.Add(Me.ThirdRowModeComboBox)
			Me.nGroupBox2.Controls.Add(Me.label12)
			Me.nGroupBox2.Controls.Add(Me.ThirdRowUnitCountUpDown)
			Me.nGroupBox2.Controls.Add(Me.ThirdRowUnitComboBox)
			Me.nGroupBox2.Controls.Add(Me.label10)
			Me.nGroupBox2.Controls.Add(Me.label11)
			Me.nGroupBox2.Dock = System.Windows.Forms.DockStyle.Top
			Me.nGroupBox2.ImageIndex = 0
			Me.nGroupBox2.Location = New System.Drawing.Point(0, 314)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(235, 164)
			Me.nGroupBox2.TabIndex = 13
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "Third Row"
			' 
			' ThirdRowVisibleCheckBox
			' 
			Me.ThirdRowVisibleCheckBox.AutoSize = True
			Me.ThirdRowVisibleCheckBox.ButtonProperties.BorderOffset = 2
			Me.ThirdRowVisibleCheckBox.Location = New System.Drawing.Point(6, 18)
			Me.ThirdRowVisibleCheckBox.Name = "ThirdRowVisibleCheckBox"
			Me.ThirdRowVisibleCheckBox.Size = New System.Drawing.Size(108, 17)
			Me.ThirdRowVisibleCheckBox.TabIndex = 0
			Me.ThirdRowVisibleCheckBox.Text = "Third Row Visible"
			Me.ThirdRowVisibleCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ThirdRowVisibleCheckBox.CheckedChanged += new System.EventHandler(this.ThirdRowVisibleCheckBox_CheckedChanged);
			' 
			' ThirdRowModeComboBox
			' 
			Me.ThirdRowModeComboBox.Location = New System.Drawing.Point(65, 39)
			Me.ThirdRowModeComboBox.Name = "ThirdRowModeComboBox"
			Me.ThirdRowModeComboBox.Size = New System.Drawing.Size(156, 21)
			Me.ThirdRowModeComboBox.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ThirdRowModeComboBox.SelectedIndexChanged += new System.EventHandler(this.ThirdRowModeComboBox_SelectedIndexChanged);
			' 
			' label12
			' 
			Me.label12.AutoSize = True
			Me.label12.Location = New System.Drawing.Point(6, 47)
			Me.label12.Name = "label12"
			Me.label12.Size = New System.Drawing.Size(37, 13)
			Me.label12.TabIndex = 1
			Me.label12.Text = "Mode:"
			' 
			' ThirdRowUnitCountUpDown
			' 
			Me.ThirdRowUnitCountUpDown.Location = New System.Drawing.Point(65, 91)
			Me.ThirdRowUnitCountUpDown.Maximum = New Decimal(New Integer() { 30, 0, 0, 0})
			Me.ThirdRowUnitCountUpDown.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.ThirdRowUnitCountUpDown.Name = "ThirdRowUnitCountUpDown"
			Me.ThirdRowUnitCountUpDown.Size = New System.Drawing.Size(156, 20)
			Me.ThirdRowUnitCountUpDown.TabIndex = 6
			Me.ThirdRowUnitCountUpDown.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ThirdRowUnitCountUpDown.ValueChanged += new System.EventHandler(this.ThirdRowUnitCountUpDown_ValueChanged);
			' 
			' ThirdRowUnitComboBox
			' 
			Me.ThirdRowUnitComboBox.Location = New System.Drawing.Point(65, 65)
			Me.ThirdRowUnitComboBox.Name = "ThirdRowUnitComboBox"
			Me.ThirdRowUnitComboBox.Size = New System.Drawing.Size(156, 21)
			Me.ThirdRowUnitComboBox.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ThirdRowUnitComboBox.SelectedIndexChanged += new System.EventHandler(this.ThirdRowUnitComboBox_SelectedIndexChanged);
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.SecondRowTextStyleButton)
			Me.nGroupBox1.Controls.Add(Me.SecondRowVisibleCheckBox)
			Me.nGroupBox1.Controls.Add(Me.SecondRowModeComboBox)
			Me.nGroupBox1.Controls.Add(Me.label8)
			Me.nGroupBox1.Controls.Add(Me.SecondRowUnitComboBox)
			Me.nGroupBox1.Controls.Add(Me.label7)
			Me.nGroupBox1.Controls.Add(Me.label6)
			Me.nGroupBox1.Controls.Add(Me.SecondRowUnitCountUpDown)
			Me.nGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(0, 149)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(235, 165)
			Me.nGroupBox1.TabIndex = 12
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Second Row"
			' 
			' SecondRowVisibleCheckBox
			' 
			Me.SecondRowVisibleCheckBox.AutoSize = True
			Me.SecondRowVisibleCheckBox.ButtonProperties.BorderOffset = 2
			Me.SecondRowVisibleCheckBox.Location = New System.Drawing.Point(6, 19)
			Me.SecondRowVisibleCheckBox.Name = "SecondRowVisibleCheckBox"
			Me.SecondRowVisibleCheckBox.Size = New System.Drawing.Size(121, 17)
			Me.SecondRowVisibleCheckBox.TabIndex = 0
			Me.SecondRowVisibleCheckBox.Text = "Second Row Visible"
			Me.SecondRowVisibleCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SecondRowVisibleCheckBox.CheckedChanged += new System.EventHandler(this.SecondRowVisibleCheckBox_CheckedChanged);
			' 
			' SecondRowModeComboBox
			' 
			Me.SecondRowModeComboBox.Location = New System.Drawing.Point(65, 40)
			Me.SecondRowModeComboBox.Name = "SecondRowModeComboBox"
			Me.SecondRowModeComboBox.Size = New System.Drawing.Size(156, 21)
			Me.SecondRowModeComboBox.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SecondRowModeComboBox.SelectedIndexChanged += new System.EventHandler(this.SecondRowModeComboBox_SelectedIndexChanged);
			' 
			' label8
			' 
			Me.label8.AutoSize = True
			Me.label8.Location = New System.Drawing.Point(6, 48)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(37, 13)
			Me.label8.TabIndex = 1
			Me.label8.Text = "Mode:"
			' 
			' SecondRowUnitComboBox
			' 
			Me.SecondRowUnitComboBox.Location = New System.Drawing.Point(65, 66)
			Me.SecondRowUnitComboBox.Name = "SecondRowUnitComboBox"
			Me.SecondRowUnitComboBox.Size = New System.Drawing.Size(156, 21)
			Me.SecondRowUnitComboBox.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SecondRowUnitComboBox.SelectedIndexChanged += new System.EventHandler(this.SecondRowUnitComboBox_SelectedIndexChanged);
			' 
			' label7
			' 
			Me.label7.AutoSize = True
			Me.label7.Location = New System.Drawing.Point(6, 74)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(29, 13)
			Me.label7.TabIndex = 3
			Me.label7.Text = "Unit:"
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(6, 96)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(37, 16)
			Me.label6.TabIndex = 5
			Me.label6.Text = "Count:"
			' 
			' SecondRowUnitCountUpDown
			' 
			Me.SecondRowUnitCountUpDown.Location = New System.Drawing.Point(65, 92)
			Me.SecondRowUnitCountUpDown.Maximum = New Decimal(New Integer() { 30, 0, 0, 0})
			Me.SecondRowUnitCountUpDown.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.SecondRowUnitCountUpDown.Name = "SecondRowUnitCountUpDown"
			Me.SecondRowUnitCountUpDown.Size = New System.Drawing.Size(156, 20)
			Me.SecondRowUnitCountUpDown.TabIndex = 6
			Me.SecondRowUnitCountUpDown.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SecondRowUnitCountUpDown.ValueChanged += new System.EventHandler(this.SecondRowUnitCountUpDown_ValueChanged);
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.FirstRowTextStyleButton)
			Me.groupBox2.Controls.Add(Me.FirstRowVisibleCheckBox)
			Me.groupBox2.Controls.Add(Me.FirstRowModeComboBox)
			Me.groupBox2.Controls.Add(Me.label2)
			Me.groupBox2.Controls.Add(Me.FirstRowUnitComboBox)
			Me.groupBox2.Controls.Add(Me.label1)
			Me.groupBox2.Controls.Add(Me.label3)
			Me.groupBox2.Controls.Add(Me.FirstRowUnitCountUpDown)
			Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox2.ImageIndex = 0
			Me.groupBox2.Location = New System.Drawing.Point(0, 0)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(235, 149)
			Me.groupBox2.TabIndex = 11
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "First Row"
			' 
			' FirstRowVisibleCheckBox
			' 
			Me.FirstRowVisibleCheckBox.AutoSize = True
			Me.FirstRowVisibleCheckBox.ButtonProperties.BorderOffset = 2
			Me.FirstRowVisibleCheckBox.Location = New System.Drawing.Point(6, 19)
			Me.FirstRowVisibleCheckBox.Name = "FirstRowVisibleCheckBox"
			Me.FirstRowVisibleCheckBox.Size = New System.Drawing.Size(103, 17)
			Me.FirstRowVisibleCheckBox.TabIndex = 0
			Me.FirstRowVisibleCheckBox.Text = "First Row Visible"
			Me.FirstRowVisibleCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FirstRowVisibleCheckBox.CheckedChanged += new System.EventHandler(this.FirstRowVisibleCheckBox_CheckedChanged);
			' 
			' FirstRowModeComboBox
			' 
			Me.FirstRowModeComboBox.Location = New System.Drawing.Point(65, 40)
			Me.FirstRowModeComboBox.Name = "FirstRowModeComboBox"
			Me.FirstRowModeComboBox.Size = New System.Drawing.Size(156, 21)
			Me.FirstRowModeComboBox.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FirstRowModeComboBox.SelectedIndexChanged += new System.EventHandler(this.FirstRowModeComboBox_SelectedIndexChanged);
			' 
			' FirstRowUnitComboBox
			' 
			Me.FirstRowUnitComboBox.Location = New System.Drawing.Point(65, 66)
			Me.FirstRowUnitComboBox.Name = "FirstRowUnitComboBox"
			Me.FirstRowUnitComboBox.Size = New System.Drawing.Size(156, 21)
			Me.FirstRowUnitComboBox.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FirstRowUnitComboBox.SelectedIndexChanged += new System.EventHandler(this.FirstRowUnitComboBox_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(6, 74)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(29, 13)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Unit:"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(6, 96)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(53, 16)
			Me.label3.TabIndex = 5
			Me.label3.Text = "Count:"
			' 
			' FirstRowUnitCountUpDown
			' 
			Me.FirstRowUnitCountUpDown.Location = New System.Drawing.Point(65, 92)
			Me.FirstRowUnitCountUpDown.Maximum = New Decimal(New Integer() { 30, 0, 0, 0})
			Me.FirstRowUnitCountUpDown.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.FirstRowUnitCountUpDown.Name = "FirstRowUnitCountUpDown"
			Me.FirstRowUnitCountUpDown.Size = New System.Drawing.Size(156, 20)
			Me.FirstRowUnitCountUpDown.TabIndex = 6
			Me.FirstRowUnitCountUpDown.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FirstRowUnitCountUpDown.ValueChanged += new System.EventHandler(this.FirstRowUnitCountUpDown_ValueChanged);
			' 
			' FirstRowTextStyleButton
			' 
			Me.FirstRowTextStyleButton.Location = New System.Drawing.Point(9, 118)
			Me.FirstRowTextStyleButton.Name = "FirstRowTextStyleButton"
			Me.FirstRowTextStyleButton.Size = New System.Drawing.Size(212, 23)
			Me.FirstRowTextStyleButton.TabIndex = 7
			Me.FirstRowTextStyleButton.Text = "First Row Text Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FirstRowTextStyleButton.Click += new System.EventHandler(this.FirstRowTextStyleButton_Click);
			' 
			' SecondRowTextStyleButton
			' 
			Me.SecondRowTextStyleButton.Location = New System.Drawing.Point(6, 118)
			Me.SecondRowTextStyleButton.Name = "SecondRowTextStyleButton"
			Me.SecondRowTextStyleButton.Size = New System.Drawing.Size(215, 23)
			Me.SecondRowTextStyleButton.TabIndex = 8
			Me.SecondRowTextStyleButton.Text = "Second Row Text Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SecondRowTextStyleButton.Click += new System.EventHandler(this.SecondRowTextStyleButton_Click);
			' 
			' ThirdRowTextStyleButton
			' 
			Me.ThirdRowTextStyleButton.Location = New System.Drawing.Point(6, 117)
			Me.ThirdRowTextStyleButton.Name = "ThirdRowTextStyleButton"
			Me.ThirdRowTextStyleButton.Size = New System.Drawing.Size(215, 23)
			Me.ThirdRowTextStyleButton.TabIndex = 9
			Me.ThirdRowTextStyleButton.Text = "Third Row Text Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ThirdRowTextStyleButton.Click += new System.EventHandler(this.ThirdRowTextStyleButton_Click);
			' 
			' NValueTimelineScaleAdvancedUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.nGroupBox2)
			Me.Controls.Add(Me.nGroupBox1)
			Me.Controls.Add(Me.groupBox2)
			Me.Name = "NValueTimelineScaleAdvancedUC"
			Me.Size = New System.Drawing.Size(235, 587)
			Me.nGroupBox2.ResumeLayout(False)
			Me.nGroupBox2.PerformLayout()
			DirectCast(Me.ThirdRowUnitCountUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nGroupBox1.ResumeLayout(False)
			Me.nGroupBox1.PerformLayout()
			DirectCast(Me.SecondRowUnitCountUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox2.ResumeLayout(False)
			Me.groupBox2.PerformLayout()
			DirectCast(Me.FirstRowUnitCountUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As New NLabel("Range Timeline Scale Advanced<br/><font size = '9pt'>Demonstrates how to use a timeline scale to show date/time information on the X axis</font>")
			header.DockMode = PanelDockMode.Top
			header.Margins = New NMarginsL(0, 10, 0, 10)
			header.TextStyle.TextFormat = TextFormat.XML
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
			nChartControl1.Panels.Add(header)

			' setup chart
			m_Chart = New NCartesianChart()
			nChartControl1.Panels.Add(m_Chart)
			m_Chart.DockMode = PanelDockMode.Fill
			m_Chart.Margins = New NMarginsL(10, 0, 10, 10)
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			m_Chart.LightModel.EnableLighting = False
			m_Chart.Axis(StandardAxis.Depth).Visible = False
			m_Chart.Wall(ChartWallType.Floor).Visible = False
			m_Chart.Wall(ChartWallType.Left).Visible = False
			m_Chart.BoundsMode = BoundsMode.Stretch
			m_Chart.Height = 40

			m_Chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(75, NRelativeUnit.ParentPercentage))

			Dim rangeSelection As New NRangeSelection()
			rangeSelection.VerticalValueSnapper = New NAxisRulerMinMaxSnapper()
			m_Chart.RangeSelections.Add(rangeSelection)

			' setup X axis
			Dim axis As NAxis = m_Chart.Axis(StandardAxis.PrimaryX)
			axis.ScrollBar.Visible = True
			Dim timeLineScale As New NValueTimelineScaleConfigurator()
			timeLineScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			timeLineScale.SecondRow.GridStyle.SetShowAtWall(ChartWallType.Back, True)
			timeLineScale.ThirdRow.GridStyle.SetShowAtWall(ChartWallType.Back, True)
			axis.ScaleConfigurator = timeLineScale

			' setup primary Y axis
			axis = m_Chart.Axis(StandardAxis.PrimaryY)
			Dim linearScale As NLinearScaleConfigurator = CType(axis.ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, False)
			linearScale.InnerMajorTickStyle.Length = New NLength(0)

			' add interlaced stripe 
			Dim stripStyle As New NScaleStripStyle()
			stripStyle.FillStyle = New NColorFillStyle(Color.Beige)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)

			' Setup the stock series
			m_Stock = CType(m_Chart.Series.Add(SeriesType.Stock), NStockSeries)
			m_Stock.DataLabelStyle.Visible = False
			m_Stock.CandleStyle = CandleStyle.Stick
			m_Stock.CandleWidth = New NLength(0.5F, NRelativeUnit.ParentPercentage)
			m_Stock.UpStrokeStyle.Color = Color.RoyalBlue
			m_Stock.Legend.Mode = SeriesLegendMode.None
			m_Stock.CloseValues.Name = "close"
			m_Stock.UseXValues = True

			' configure interactivity
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NAxisScrollTool())
			nChartControl1.Controller.Tools.Add(New NDataZoomTool())

			' generate some data
			MonthlyDataButton_Click(Nothing, Nothing)

			' init form controls
			FirstRowModeComboBox.FillFromEnum(GetType(TimelineScaleRowTickMode))
			FirstRowModeComboBox.SelectedIndex = CInt(TimelineScaleRowTickMode.AutoMinDistance)
			FirstRowUnitComboBox.FillFromEnum(GetType(DateTimeUnit))
			FirstRowUnitComboBox.SelectedIndex = 0
			FirstRowUnitCountUpDown.Value = 1
			FirstRowVisibleCheckBox.Checked = True

			SecondRowModeComboBox.FillFromEnum(GetType(TimelineScaleRowTickMode))
			SecondRowModeComboBox.SelectedIndex = CInt(TimelineScaleRowTickMode.AutoMinDistance)
			SecondRowUnitComboBox.FillFromEnum(GetType(DateTimeUnit))
			SecondRowUnitComboBox.SelectedIndex = 0
			SecondRowUnitCountUpDown.Value = 1
			SecondRowVisibleCheckBox.Checked = True

			ThirdRowModeComboBox.FillFromEnum(GetType(TimelineScaleRowTickMode))
			ThirdRowModeComboBox.SelectedIndex = CInt(TimelineScaleRowTickMode.AutoMinDistance)
			ThirdRowUnitComboBox.FillFromEnum(GetType(DateTimeUnit))
			ThirdRowUnitComboBox.SelectedIndex = 0
			ThirdRowUnitCountUpDown.Value = 1
			ThirdRowVisibleCheckBox.Checked = True
		End Sub

		Private Sub UpdateScale()
			If m_Chart Is Nothing Then
				Return
			End If

			ConfigureScaleRow(0, FirstRowVisibleCheckBox, FirstRowModeComboBox, FirstRowUnitComboBox, FirstRowUnitCountUpDown)
			ConfigureScaleRow(1, SecondRowVisibleCheckBox, SecondRowModeComboBox, SecondRowUnitComboBox, SecondRowUnitCountUpDown)
			ConfigureScaleRow(2, ThirdRowVisibleCheckBox, ThirdRowModeComboBox, ThirdRowUnitComboBox, ThirdRowUnitCountUpDown)

			nChartControl1.Refresh()
		End Sub

		Private Sub ConfigureScaleRow(ByVal rowIndex As Integer, ByVal visibleCheckBox As NCheckBox, ByVal rowModeComboBox As NComboBox, ByVal rowUnitComboBox As NComboBox, ByVal rowUnitCountUpDown As NNumericUpDown)
			Dim valueTimelineScale As NValueTimelineScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NValueTimelineScaleConfigurator)
			Dim scaleRow As NTimelineScaleRow

			If rowIndex = 0 Then
				scaleRow = valueTimelineScale.FirstRow
			ElseIf rowIndex = 1 Then
				scaleRow = valueTimelineScale.SecondRow
			Else
				scaleRow = valueTimelineScale.ThirdRow
			End If

			scaleRow.Visible = visibleCheckBox.Checked

			Dim enableUnitControls As Boolean = False
			Select Case CType(rowModeComboBox.SelectedIndex, TimelineScaleRowTickMode)
				Case TimelineScaleRowTickMode.AutoMinDistance
					scaleRow.TickMode = TimelineScaleRowTickMode.AutoMinDistance
				Case TimelineScaleRowTickMode.AutoMaxCount
					scaleRow.TickMode = TimelineScaleRowTickMode.AutoMaxCount
				Case TimelineScaleRowTickMode.Custom
					enableUnitControls = True
					scaleRow.TickMode = TimelineScaleRowTickMode.Custom
					scaleRow.CustomStep = New NDateTimeSpan(CInt(Math.Truncate(rowUnitCountUpDown.Value)), NDateTimeUnit.GetFromEnum(CType(rowUnitComboBox.SelectedIndex, DateTimeUnit)))
			End Select

			rowUnitComboBox.Enabled = enableUnitControls
			rowUnitCountUpDown.Enabled = enableUnitControls
		End Sub

		Private Sub GenerateData(ByVal dtStart As Date, ByVal dtEnd As Date, ByVal span As NDateTimeSpan)
			Dim count As Long = span.GetSpanCountInRange(New NDateTimeRange(dtStart, dtEnd))

			GenerateOHLCData(m_Stock, 100, CInt(count))
			m_Stock.XValues.Clear()

			Dim dtNow As Date = dtStart

			For i As Integer = 0 To m_Stock.Values.Count - 1
				m_Stock.XValues.Add(dtNow.ToOADate())
				dtNow = span.Add(dtNow)
			Next i

			m_Chart.Axis(StandardAxis.PrimaryX).PagingView.Enabled = False

			nChartControl1.Refresh()
		End Sub

		Private Sub DailyDataButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			' generate data for 30 days
			Dim dtNow As Date = Date.Now
			Dim dtEnd As New Date(dtNow.Year, dtNow.Month, dtNow.Day, 17, 0, 0, 0)
			Dim dtStart As New Date(dtNow.Year, dtNow.Month, dtNow.Day, 7, 0, 0, 0)

			GenerateData(dtStart, dtEnd, New NDateTimeSpan(5, NDateTimeUnit.Minute))
		End Sub

		Private Sub WeeklyDataButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			' generate data for 30 weeks
			Dim dtNow As Date = Date.Now
			Dim dtEnd As New Date(dtNow.Year, dtNow.Month, dtNow.Day, 7, 0, 0, 0)
			Dim dtStart As Date = NDateTimeUnit.Week.Add(dtEnd, -30)

			GenerateData(dtStart, dtEnd, New NDateTimeSpan(1, NDateTimeUnit.Day))
		End Sub

		Private Sub MonthlyDataButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			' generate data for 30 months 
			Dim dtNow As Date = Date.Now
			Dim dtEnd As New Date(dtNow.Year, dtNow.Month, dtNow.Day, 7, 0, 0, 0)
			Dim dtStart As Date = NDateTimeUnit.Month.Add(dtEnd, -30)

			GenerateData(dtStart, dtEnd, New NDateTimeSpan(1, NDateTimeUnit.Week))
		End Sub

		Private Sub YearyDataButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			' generate data for 30 years
			Dim dtNow As Date = Date.Now
			Dim dtEnd As New Date(dtNow.Year, dtNow.Month, dtNow.Day, 7, 0, 0, 0)
			Dim dtStart As Date = NDateTimeUnit.Year.Add(dtEnd, -30)

			GenerateData(dtStart, dtEnd, New NDateTimeSpan(1, NDateTimeUnit.Month))
		End Sub

		Private Sub FirstRowVisibleCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles FirstRowVisibleCheckBox.CheckedChanged
			UpdateScale()
		End Sub

		Private Sub FirstRowModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles FirstRowModeComboBox.SelectedIndexChanged
			UpdateScale()
		End Sub

		Private Sub FirstRowUnitComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles FirstRowUnitComboBox.SelectedIndexChanged
			UpdateScale()
		End Sub

		Private Sub FirstRowUnitCountUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles FirstRowUnitCountUpDown.ValueChanged
			UpdateScale()
		End Sub

		Private Sub SecondRowVisibleCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SecondRowVisibleCheckBox.CheckedChanged
			UpdateScale()
		End Sub

		Private Sub SecondRowModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SecondRowModeComboBox.SelectedIndexChanged
			UpdateScale()
		End Sub

		Private Sub SecondRowUnitComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SecondRowUnitComboBox.SelectedIndexChanged
			UpdateScale()
		End Sub

		Private Sub SecondRowUnitCountUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SecondRowUnitCountUpDown.ValueChanged
			UpdateScale()
		End Sub

		Private Sub ThirdRowVisibleCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ThirdRowVisibleCheckBox.CheckedChanged
			UpdateScale()
		End Sub

		Private Sub ThirdRowModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ThirdRowModeComboBox.SelectedIndexChanged
			UpdateScale()
		End Sub

		Private Sub ThirdRowUnitComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ThirdRowUnitComboBox.SelectedIndexChanged
			UpdateScale()
		End Sub

		Private Sub ThirdRowUnitCountUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ThirdRowUnitCountUpDown.ValueChanged
			UpdateScale()
		End Sub

		Private Sub FirstRowTextStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles FirstRowTextStyleButton.Click
			Dim valueTimelineScale As NValueTimelineScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NValueTimelineScaleConfigurator)
			Dim result As NTextStyle = Nothing

			If NTextStyleTypeEditor.Edit(valueTimelineScale.FirstRow.LabelStyle.TextStyle, result) Then
				valueTimelineScale.FirstRow.LabelStyle.TextStyle = result
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub SecondRowTextStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SecondRowTextStyleButton.Click
			Dim valueTimelineScale As NValueTimelineScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NValueTimelineScaleConfigurator)
			Dim result As NTextStyle = Nothing

			If NTextStyleTypeEditor.Edit(valueTimelineScale.SecondRow.LabelStyle.TextStyle, result) Then
				valueTimelineScale.SecondRow.LabelStyle.TextStyle = result
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub ThirdRowTextStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ThirdRowTextStyleButton.Click
			Dim valueTimelineScale As NValueTimelineScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NValueTimelineScaleConfigurator)
			Dim result As NTextStyle = Nothing

			If NTextStyleTypeEditor.Edit(valueTimelineScale.ThirdRow.LabelStyle.TextStyle, result) Then
				valueTimelineScale.ThirdRow.LabelStyle.TextStyle = result
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace
