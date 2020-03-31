Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NLegendInterlacedUC
		Inherits NExampleBaseUC

		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private LayoutGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents ExpandModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label4 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private WithEvents RowCountUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label5 As System.Windows.Forms.Label
		Private WithEvents ColCountUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label1 As System.Windows.Forms.Label
		Private WithEvents RowInterlacingInfiniteCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private WithEvents RowInterlacingLengthNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label7 As System.Windows.Forms.Label
		Private WithEvents RowInterlacingIntervalNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label8 As System.Windows.Forms.Label
		Private label9 As System.Windows.Forms.Label
		Private label10 As System.Windows.Forms.Label
		Private WithEvents ColumnInterlacingBeginNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label11 As System.Windows.Forms.Label
		Private WithEvents ColumnInterlacingFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ColumnInterlacingEnabledCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ColumnInterlacingIntervalNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents ColumnInterlacingLengthNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents ColumnInterlacingEndNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents ColumnInterlacingInfiniteCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents RowInterlacingBeginNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents RowInterlacingEndNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents RowInterlacingEnabledCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private m_RowInterlaceStyle As NLegendInterlaceStyle
		Private m_ColInterlaceStyle As NLegendInterlaceStyle
		Private WithEvents RowInterlacingFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private m_bUpdate As Boolean

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
			Me.RowInterlacingIntervalNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label7 = New System.Windows.Forms.Label()
			Me.RowInterlacingLengthNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label3 = New System.Windows.Forms.Label()
			Me.RowInterlacingEndNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			Me.RowInterlacingInfiniteCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.RowInterlacingBeginNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label1 = New System.Windows.Forms.Label()
			Me.RowInterlacingFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.RowInterlacingEnabledCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.LayoutGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.ExpandModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.RowCountUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label5 = New System.Windows.Forms.Label()
			Me.ColCountUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.ColumnInterlacingIntervalNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label8 = New System.Windows.Forms.Label()
			Me.ColumnInterlacingLengthNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label9 = New System.Windows.Forms.Label()
			Me.ColumnInterlacingEndNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label10 = New System.Windows.Forms.Label()
			Me.ColumnInterlacingInfiniteCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ColumnInterlacingBeginNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label11 = New System.Windows.Forms.Label()
			Me.ColumnInterlacingFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ColumnInterlacingEnabledCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.groupBox1.SuspendLayout()
			DirectCast(Me.RowInterlacingIntervalNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.RowInterlacingLengthNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.RowInterlacingEndNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.RowInterlacingBeginNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.LayoutGroupBox.SuspendLayout()
			DirectCast(Me.RowCountUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.ColCountUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox2.SuspendLayout()
			DirectCast(Me.ColumnInterlacingIntervalNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.ColumnInterlacingLengthNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.ColumnInterlacingEndNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.ColumnInterlacingBeginNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.RowInterlacingIntervalNumericUpDown)
			Me.groupBox1.Controls.Add(Me.label7)
			Me.groupBox1.Controls.Add(Me.RowInterlacingLengthNumericUpDown)
			Me.groupBox1.Controls.Add(Me.label3)
			Me.groupBox1.Controls.Add(Me.RowInterlacingEndNumericUpDown)
			Me.groupBox1.Controls.Add(Me.label2)
			Me.groupBox1.Controls.Add(Me.RowInterlacingInfiniteCheckBox)
			Me.groupBox1.Controls.Add(Me.RowInterlacingBeginNumericUpDown)
			Me.groupBox1.Controls.Add(Me.label1)
			Me.groupBox1.Controls.Add(Me.RowInterlacingFillStyleButton)
			Me.groupBox1.Controls.Add(Me.RowInterlacingEnabledCheckBox)
			Me.groupBox1.ImageIndex = 0
			Me.groupBox1.Location = New System.Drawing.Point(8, 232)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(168, 232)
			Me.groupBox1.TabIndex = 0
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Horizontal interlacing"
			' 
			' RowInterlacingIntervalNumericUpDown
			' 
			Me.RowInterlacingIntervalNumericUpDown.Location = New System.Drawing.Point(80, 200)
			Me.RowInterlacingIntervalNumericUpDown.Name = "RowInterlacingIntervalNumericUpDown"
			Me.RowInterlacingIntervalNumericUpDown.Size = New System.Drawing.Size(72, 20)
			Me.RowInterlacingIntervalNumericUpDown.TabIndex = 10
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RowInterlacingIntervalNumericUpDown.ValueChanged += new System.EventHandler(this.RowInterlacingIntervalNumericUpDown_ValueChanged);
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(8, 200)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(48, 20)
			Me.label7.TabIndex = 9
			Me.label7.Text = "Interval:"
			Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' RowInterlacingLengthNumericUpDown
			' 
			Me.RowInterlacingLengthNumericUpDown.Location = New System.Drawing.Point(80, 168)
			Me.RowInterlacingLengthNumericUpDown.Name = "RowInterlacingLengthNumericUpDown"
			Me.RowInterlacingLengthNumericUpDown.Size = New System.Drawing.Size(72, 20)
			Me.RowInterlacingLengthNumericUpDown.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RowInterlacingLengthNumericUpDown.ValueChanged += new System.EventHandler(this.RowInterlacingLengthNumericUpDown_ValueChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 168)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(48, 20)
			Me.label3.TabIndex = 7
			Me.label3.Text = "Length:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' RowInterlacingEndNumericUpDown
			' 
			Me.RowInterlacingEndNumericUpDown.Location = New System.Drawing.Point(80, 112)
			Me.RowInterlacingEndNumericUpDown.Name = "RowInterlacingEndNumericUpDown"
			Me.RowInterlacingEndNumericUpDown.Size = New System.Drawing.Size(72, 20)
			Me.RowInterlacingEndNumericUpDown.TabIndex = 6
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RowInterlacingEndNumericUpDown.ValueChanged += new System.EventHandler(this.RowInterlacingEndNumericUpDown_ValueChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 112)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(48, 20)
			Me.label2.TabIndex = 5
			Me.label2.Text = "End:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' RowInterlacingInfiniteCheckBox
			' 
			Me.RowInterlacingInfiniteCheckBox.ButtonProperties.BorderOffset = 2
			Me.RowInterlacingInfiniteCheckBox.Location = New System.Drawing.Point(80, 136)
			Me.RowInterlacingInfiniteCheckBox.Name = "RowInterlacingInfiniteCheckBox"
			Me.RowInterlacingInfiniteCheckBox.Size = New System.Drawing.Size(72, 20)
			Me.RowInterlacingInfiniteCheckBox.TabIndex = 4
			Me.RowInterlacingInfiniteCheckBox.Text = "Infinite"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RowInterlacingInfiniteCheckBox.CheckedChanged += new System.EventHandler(this.RowInterlacingInfiniteCheckBox_CheckedChanged);
			' 
			' RowInterlacingBeginNumericUpDown
			' 
			Me.RowInterlacingBeginNumericUpDown.Location = New System.Drawing.Point(80, 80)
			Me.RowInterlacingBeginNumericUpDown.Name = "RowInterlacingBeginNumericUpDown"
			Me.RowInterlacingBeginNumericUpDown.Size = New System.Drawing.Size(72, 20)
			Me.RowInterlacingBeginNumericUpDown.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RowInterlacingBeginNumericUpDown.ValueChanged += new System.EventHandler(this.RowInterlacingBeginNumericUpDown_ValueChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 80)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(48, 20)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Begin:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' RowInterlacingFillStyleButton
			' 
			Me.RowInterlacingFillStyleButton.Location = New System.Drawing.Point(8, 48)
			Me.RowInterlacingFillStyleButton.Name = "RowInterlacingFillStyleButton"
			Me.RowInterlacingFillStyleButton.Size = New System.Drawing.Size(152, 24)
			Me.RowInterlacingFillStyleButton.TabIndex = 1
			Me.RowInterlacingFillStyleButton.Text = "Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RowInterlacingFillStyleButton.Click += new System.EventHandler(this.RowInterlacingFillStyleButton_Click);
			' 
			' RowInterlacingEnabledCheckBox
			' 
			Me.RowInterlacingEnabledCheckBox.ButtonProperties.BorderOffset = 2
			Me.RowInterlacingEnabledCheckBox.Location = New System.Drawing.Point(8, 16)
			Me.RowInterlacingEnabledCheckBox.Name = "RowInterlacingEnabledCheckBox"
			Me.RowInterlacingEnabledCheckBox.Size = New System.Drawing.Size(152, 24)
			Me.RowInterlacingEnabledCheckBox.TabIndex = 0
			Me.RowInterlacingEnabledCheckBox.Text = "Enable"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RowInterlacingEnabledCheckBox.CheckedChanged += new System.EventHandler(this.RowInterlacingEnabledCheckBox_CheckedChanged);
			' 
			' LayoutGroupBox
			' 
			Me.LayoutGroupBox.Controls.Add(Me.ExpandModeComboBox)
			Me.LayoutGroupBox.Controls.Add(Me.label4)
			Me.LayoutGroupBox.Controls.Add(Me.label6)
			Me.LayoutGroupBox.Controls.Add(Me.RowCountUpDown)
			Me.LayoutGroupBox.Controls.Add(Me.label5)
			Me.LayoutGroupBox.Controls.Add(Me.ColCountUpDown)
			Me.LayoutGroupBox.ImageIndex = 0
			Me.LayoutGroupBox.Location = New System.Drawing.Point(8, 464)
			Me.LayoutGroupBox.Name = "LayoutGroupBox"
			Me.LayoutGroupBox.Size = New System.Drawing.Size(168, 168)
			Me.LayoutGroupBox.TabIndex = 57
			Me.LayoutGroupBox.TabStop = False
			Me.LayoutGroupBox.Text = "Layout"
			' 
			' ExpandModeComboBox
			' 
			Me.ExpandModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.ExpandModeComboBox.ListProperties.DataSource = Nothing
			Me.ExpandModeComboBox.ListProperties.DisplayMember = ""
			Me.ExpandModeComboBox.Location = New System.Drawing.Point(12, 42)
			Me.ExpandModeComboBox.Name = "ExpandModeComboBox"
			Me.ExpandModeComboBox.Size = New System.Drawing.Size(145, 21)
			Me.ExpandModeComboBox.TabIndex = 45
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ExpandModeComboBox.SelectedIndexChanged += new System.EventHandler(this.ExpandModeComboBox_SelectedIndexChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(12, 22)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(145, 15)
			Me.label4.TabIndex = 46
			Me.label4.Text = "Expand mode:"
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(12, 68)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(145, 15)
			Me.label6.TabIndex = 51
			Me.label6.Text = "Row count:"
			' 
			' RowCountUpDown
			' 
			Me.RowCountUpDown.Location = New System.Drawing.Point(12, 88)
			Me.RowCountUpDown.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.RowCountUpDown.Name = "RowCountUpDown"
			Me.RowCountUpDown.Size = New System.Drawing.Size(145, 20)
			Me.RowCountUpDown.TabIndex = 47
			Me.RowCountUpDown.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RowCountUpDown.ValueChanged += new System.EventHandler(this.RowCountUpDown_ValueChanged);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(12, 113)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(145, 15)
			Me.label5.TabIndex = 50
			Me.label5.Text = "Col count:"
			' 
			' ColCountUpDown
			' 
			Me.ColCountUpDown.Location = New System.Drawing.Point(12, 133)
			Me.ColCountUpDown.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.ColCountUpDown.Name = "ColCountUpDown"
			Me.ColCountUpDown.Size = New System.Drawing.Size(145, 20)
			Me.ColCountUpDown.TabIndex = 48
			Me.ColCountUpDown.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ColCountUpDown.ValueChanged += new System.EventHandler(this.ColCountUpDown_ValueChanged);
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.ColumnInterlacingIntervalNumericUpDown)
			Me.groupBox2.Controls.Add(Me.label8)
			Me.groupBox2.Controls.Add(Me.ColumnInterlacingLengthNumericUpDown)
			Me.groupBox2.Controls.Add(Me.label9)
			Me.groupBox2.Controls.Add(Me.ColumnInterlacingEndNumericUpDown)
			Me.groupBox2.Controls.Add(Me.label10)
			Me.groupBox2.Controls.Add(Me.ColumnInterlacingInfiniteCheckBox)
			Me.groupBox2.Controls.Add(Me.ColumnInterlacingBeginNumericUpDown)
			Me.groupBox2.Controls.Add(Me.label11)
			Me.groupBox2.Controls.Add(Me.ColumnInterlacingFillStyleButton)
			Me.groupBox2.Controls.Add(Me.ColumnInterlacingEnabledCheckBox)
			Me.groupBox2.ImageIndex = 0
			Me.groupBox2.Location = New System.Drawing.Point(8, 0)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(168, 232)
			Me.groupBox2.TabIndex = 11
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Vertical interlacing"
			' 
			' ColumnInterlacingIntervalNumericUpDown
			' 
			Me.ColumnInterlacingIntervalNumericUpDown.Location = New System.Drawing.Point(80, 200)
			Me.ColumnInterlacingIntervalNumericUpDown.Name = "ColumnInterlacingIntervalNumericUpDown"
			Me.ColumnInterlacingIntervalNumericUpDown.Size = New System.Drawing.Size(72, 20)
			Me.ColumnInterlacingIntervalNumericUpDown.TabIndex = 10
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ColumnInterlacingIntervalNumericUpDown.ValueChanged += new System.EventHandler(this.ColumnInterlacingIntervalNumericUpDown_ValueChanged);
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(8, 200)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(48, 20)
			Me.label8.TabIndex = 9
			Me.label8.Text = "Interval:"
			Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' ColumnInterlacingLengthNumericUpDown
			' 
			Me.ColumnInterlacingLengthNumericUpDown.Location = New System.Drawing.Point(80, 168)
			Me.ColumnInterlacingLengthNumericUpDown.Name = "ColumnInterlacingLengthNumericUpDown"
			Me.ColumnInterlacingLengthNumericUpDown.Size = New System.Drawing.Size(72, 20)
			Me.ColumnInterlacingLengthNumericUpDown.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ColumnInterlacingLengthNumericUpDown.ValueChanged += new System.EventHandler(this.ColumnInterlacingLengthNumericUpDown_ValueChanged);
			' 
			' label9
			' 
			Me.label9.Location = New System.Drawing.Point(8, 168)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(48, 20)
			Me.label9.TabIndex = 7
			Me.label9.Text = "Length:"
			Me.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' ColumnInterlacingEndNumericUpDown
			' 
			Me.ColumnInterlacingEndNumericUpDown.Location = New System.Drawing.Point(80, 112)
			Me.ColumnInterlacingEndNumericUpDown.Name = "ColumnInterlacingEndNumericUpDown"
			Me.ColumnInterlacingEndNumericUpDown.Size = New System.Drawing.Size(72, 20)
			Me.ColumnInterlacingEndNumericUpDown.TabIndex = 6
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ColumnInterlacingEndNumericUpDown.ValueChanged += new System.EventHandler(this.ColumnInterlacingEndNumericUpDown_ValueChanged);
			' 
			' label10
			' 
			Me.label10.Location = New System.Drawing.Point(8, 112)
			Me.label10.Name = "label10"
			Me.label10.Size = New System.Drawing.Size(48, 20)
			Me.label10.TabIndex = 5
			Me.label10.Text = "End:"
			Me.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' ColumnInterlacingInfiniteCheckBox
			' 
			Me.ColumnInterlacingInfiniteCheckBox.ButtonProperties.BorderOffset = 2
			Me.ColumnInterlacingInfiniteCheckBox.Location = New System.Drawing.Point(80, 136)
			Me.ColumnInterlacingInfiniteCheckBox.Name = "ColumnInterlacingInfiniteCheckBox"
			Me.ColumnInterlacingInfiniteCheckBox.Size = New System.Drawing.Size(72, 20)
			Me.ColumnInterlacingInfiniteCheckBox.TabIndex = 4
			Me.ColumnInterlacingInfiniteCheckBox.Text = "Infinite"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ColumnInterlacingInfiniteCheckBox.CheckedChanged += new System.EventHandler(this.ColumnInterlacingInfiniteCheckBox_CheckedChanged);
			' 
			' ColumnInterlacingBeginNumericUpDown
			' 
			Me.ColumnInterlacingBeginNumericUpDown.Location = New System.Drawing.Point(80, 80)
			Me.ColumnInterlacingBeginNumericUpDown.Name = "ColumnInterlacingBeginNumericUpDown"
			Me.ColumnInterlacingBeginNumericUpDown.Size = New System.Drawing.Size(72, 20)
			Me.ColumnInterlacingBeginNumericUpDown.TabIndex = 3
			Me.ColumnInterlacingBeginNumericUpDown.Value = New Decimal(New Integer() { 2, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ColumnInterlacingBeginNumericUpDown.ValueChanged += new System.EventHandler(this.ColumnInterlacingBeginNumericUpDown_ValueChanged);
			' 
			' label11
			' 
			Me.label11.Location = New System.Drawing.Point(8, 80)
			Me.label11.Name = "label11"
			Me.label11.Size = New System.Drawing.Size(48, 20)
			Me.label11.TabIndex = 2
			Me.label11.Text = "Begin:"
			Me.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' ColumnInterlacingFillStyleButton
			' 
			Me.ColumnInterlacingFillStyleButton.Location = New System.Drawing.Point(8, 48)
			Me.ColumnInterlacingFillStyleButton.Name = "ColumnInterlacingFillStyleButton"
			Me.ColumnInterlacingFillStyleButton.Size = New System.Drawing.Size(152, 24)
			Me.ColumnInterlacingFillStyleButton.TabIndex = 1
			Me.ColumnInterlacingFillStyleButton.Text = "Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ColumnInterlacingFillStyleButton.Click += new System.EventHandler(this.ColumnInterlacingFillStyleButton_Click);
			' 
			' ColumnInterlacingEnabledCheckBox
			' 
			Me.ColumnInterlacingEnabledCheckBox.ButtonProperties.BorderOffset = 2
			Me.ColumnInterlacingEnabledCheckBox.Location = New System.Drawing.Point(8, 16)
			Me.ColumnInterlacingEnabledCheckBox.Name = "ColumnInterlacingEnabledCheckBox"
			Me.ColumnInterlacingEnabledCheckBox.Size = New System.Drawing.Size(152, 24)
			Me.ColumnInterlacingEnabledCheckBox.TabIndex = 0
			Me.ColumnInterlacingEnabledCheckBox.Text = "Enable"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ColumnInterlacingEnabledCheckBox.CheckedChanged += new System.EventHandler(this.ColumnInterlacingEnabledCheckBox_CheckedChanged);
			' 
			' NLegendInterlacedUC
			' 
			Me.Controls.Add(Me.LayoutGroupBox)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.groupBox2)
			Me.Name = "NLegendInterlacedUC"
			Me.Size = New System.Drawing.Size(180, 672)
			Me.groupBox1.ResumeLayout(False)
			DirectCast(Me.RowInterlacingIntervalNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.RowInterlacingLengthNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.RowInterlacingEndNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.RowInterlacingBeginNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.LayoutGroupBox.ResumeLayout(False)
			DirectCast(Me.RowCountUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.ColCountUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox2.ResumeLayout(False)
			DirectCast(Me.ColumnInterlacingIntervalNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.ColumnInterlacingLengthNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.ColumnInterlacingEndNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.ColumnInterlacingBeginNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As New NLabel("Legend Row and Column Interlacing")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
			header.DockMode = PanelDockMode.Top
			header.Margins = New NMarginsL(10, 10, 10, 10)
			nChartControl1.Panels.Add(header)

			m_bUpdate = False

			' configure the legend
			Dim legend As New NLegend()
			legend.UseAutomaticSize = True
			legend.Margins = New NMarginsL(10, 10, 10, 10)
			nChartControl1.Panels.Add(legend)

			legend.Mode = LegendMode.Automatic
			legend.Location = New NPointL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			legend.Data.ExpandMode = LegendExpandMode.RowsFixed
			legend.Data.RowCount = 12
			legend.FillStyle.SetTransparencyPercent(100)
			legend.OuterLeftBorderStyle.Width = New NLength(0)
			legend.OuterTopBorderStyle.Width = New NLength(0)
			legend.OuterRightBorderStyle.Width = New NLength(0)
			legend.OuterBottomBorderStyle.Width = New NLength(0)
			legend.HorizontalBorderStyle.Width = New NLength(0)
			legend.VerticalBorderStyle.Width = New NLength(0)

			legend.DockMode = PanelDockMode.Right

			m_RowInterlaceStyle = New NLegendInterlaceStyle()
			m_RowInterlaceStyle.Type = LegendInterlaceStyleType.Row
			m_RowInterlaceStyle.FillStyle = New NColorFillStyle(Color.FromArgb(125, Color.DimGray))
			legend.InterlaceStyles.Add(m_RowInterlaceStyle)

			m_ColInterlaceStyle = New NLegendInterlaceStyle()
			m_ColInterlaceStyle.Type = LegendInterlaceStyleType.Col
			m_ColInterlaceStyle.FillStyle = New NColorFillStyle(Color.FromArgb(125, Color.Gainsboro))
			legend.InterlaceStyles.Add(m_ColInterlaceStyle)

			' init form controls depending on control style
			' configure layout
			ExpandModeComboBox.Items.Add("Rows only")
			ExpandModeComboBox.Items.Add("Cols only")
			ExpandModeComboBox.Items.Add("Rows fixed")
			ExpandModeComboBox.Items.Add("Cols fixed")
			ExpandModeComboBox.SelectedIndex = CInt(legend.Data.ExpandMode)
			RowCountUpDown.Value = CDec(legend.Data.RowCount)
			ColCountUpDown.Value = CDec(legend.Data.ColCount)

			' configure horizontal interlacing
			legend.InterlaceStyles.Clear()

			' configure the chart
			Dim chart As NChart = New NCartesianChart()
			nChartControl1.Panels.Add(chart)
			chart.DisplayOnLegend = legend
			chart.BoundsMode = BoundsMode.Fit
			chart.DockMode = PanelDockMode.Fill
			chart.Margins = New NMarginsL(10, 10, 10, 10)

			For i As Integer = 0 To 3
				' create bar series
				Dim series As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
				series.Name = "Series " & i.ToString()
				series.Values.FillRandomRange(Random, 6, 50, 90)
				series.Legend.Format = series.Name & " <value>"
				series.Legend.Mode = SeriesLegendMode.DataPoints
				series.MultiBarMode = MultiBarMode.Stacked
				series.DataLabelStyle.Visible = False
			Next i

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			RowInterlacingEnabledCheckBox.Checked = True
			RowInterlacingBeginNumericUpDown.Value = CDec(m_RowInterlaceStyle.Begin)
			RowInterlacingEndNumericUpDown.Value = CDec(m_RowInterlaceStyle.End)
			RowInterlacingInfiniteCheckBox.Checked = m_RowInterlaceStyle.Infinite
			RowInterlacingLengthNumericUpDown.Value = CDec(m_RowInterlaceStyle.Length)
			RowInterlacingIntervalNumericUpDown.Value = CDec(m_RowInterlaceStyle.Interval)

			' configure vertical interlacing
			ColumnInterlacingEnabledCheckBox.Checked = True
			ColumnInterlacingBeginNumericUpDown.Value = CDec(m_ColInterlaceStyle.Begin)
			ColumnInterlacingEndNumericUpDown.Value = CDec(m_ColInterlaceStyle.End)
			ColumnInterlacingInfiniteCheckBox.Checked = m_ColInterlaceStyle.Infinite
			ColumnInterlacingLengthNumericUpDown.Value = CDec(m_ColInterlaceStyle.Length)
			ColumnInterlacingIntervalNumericUpDown.Value = CDec(m_ColInterlaceStyle.Interval)

			m_bUpdate = True

			ConfigureLegend()
		End Sub


		Private Sub ConfigureLegend()
			If m_bUpdate = False Then
				Return
			End If

			m_bUpdate = False

			Dim legend As NLegend = nChartControl1.Legends(0)

			' configure layout
			legend.Data.ExpandMode = CType(ExpandModeComboBox.SelectedIndex, LegendExpandMode)
			legend.Data.RowCount = CInt(Math.Truncate(RowCountUpDown.Value))
			legend.Data.ColCount = CInt(Math.Truncate(ColCountUpDown.Value))

			legend.InterlaceStyles.Clear()

			' configure horizontal interlacing
			m_RowInterlaceStyle.Begin = CInt(Math.Truncate(RowInterlacingBeginNumericUpDown.Value))
			m_RowInterlaceStyle.End = CInt(Math.Truncate(RowInterlacingEndNumericUpDown.Value))
			m_RowInterlaceStyle.Infinite = RowInterlacingInfiniteCheckBox.Checked
			m_RowInterlaceStyle.Length = CInt(Math.Truncate(RowInterlacingLengthNumericUpDown.Value))
			m_RowInterlaceStyle.Interval = CInt(Math.Truncate(RowInterlacingIntervalNumericUpDown.Value))

			If RowInterlacingEnabledCheckBox.Checked Then
				legend.InterlaceStyles.Add(m_RowInterlaceStyle)
			End If

			' configure vertical interlacing
			m_ColInterlaceStyle.Begin = CInt(Math.Truncate(ColumnInterlacingBeginNumericUpDown.Value))
			m_ColInterlaceStyle.End = CInt(Math.Truncate(ColumnInterlacingEndNumericUpDown.Value))
			m_ColInterlaceStyle.Infinite = ColumnInterlacingInfiniteCheckBox.Checked
			m_ColInterlaceStyle.Length = CInt(Math.Truncate(ColumnInterlacingLengthNumericUpDown.Value))
			m_ColInterlaceStyle.Interval = CInt(Math.Truncate(ColumnInterlacingIntervalNumericUpDown.Value))

			If ColumnInterlacingEnabledCheckBox.Checked Then
				legend.InterlaceStyles.Add(m_ColInterlaceStyle)
			End If

			Dim bEnableControl As Boolean = RowInterlacingEnabledCheckBox.Checked

			RowInterlacingFillStyleButton.Enabled = bEnableControl
			RowInterlacingBeginNumericUpDown.Enabled = bEnableControl
			RowInterlacingEndNumericUpDown.Enabled = bEnableControl AndAlso (Not RowInterlacingInfiniteCheckBox.Checked)
			RowInterlacingInfiniteCheckBox.Enabled = bEnableControl
			RowInterlacingLengthNumericUpDown.Enabled = bEnableControl
			RowInterlacingIntervalNumericUpDown.Enabled = bEnableControl

			bEnableControl = ColumnInterlacingEnabledCheckBox.Checked

			ColumnInterlacingFillStyleButton.Enabled = bEnableControl
			ColumnInterlacingBeginNumericUpDown.Enabled = bEnableControl
			ColumnInterlacingEndNumericUpDown.Enabled = bEnableControl AndAlso (Not ColumnInterlacingInfiniteCheckBox.Checked)
			ColumnInterlacingInfiniteCheckBox.Enabled = bEnableControl
			ColumnInterlacingLengthNumericUpDown.Enabled = bEnableControl
			ColumnInterlacingIntervalNumericUpDown.Enabled = bEnableControl

			m_bUpdate = True

			nChartControl1.Refresh()
		End Sub

		Private Sub RowInterlacingEnabledCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RowInterlacingEnabledCheckBox.CheckedChanged
			ConfigureLegend()
		End Sub

		Private Sub RowInterlacingFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RowInterlacingFillStyleButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_RowInterlaceStyle.FillStyle, fillStyleResult) Then
				m_RowInterlaceStyle.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub RowInterlacingBeginNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RowInterlacingBeginNumericUpDown.ValueChanged
			ConfigureLegend()
		End Sub

		Private Sub RowInterlacingEndNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RowInterlacingEndNumericUpDown.ValueChanged
			ConfigureLegend()
		End Sub

		Private Sub RowInterlacingInfiniteCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RowInterlacingInfiniteCheckBox.CheckedChanged
			ConfigureLegend()
		End Sub

		Private Sub RowInterlacingLengthNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RowInterlacingLengthNumericUpDown.ValueChanged
			ConfigureLegend()
		End Sub

		Private Sub RowInterlacingIntervalNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RowInterlacingIntervalNumericUpDown.ValueChanged
			ConfigureLegend()
		End Sub

		Private Sub ColumnInterlacingEnabledCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ColumnInterlacingEnabledCheckBox.CheckedChanged
			ConfigureLegend()
		End Sub

		Private Sub ColumnInterlacingFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ColumnInterlacingFillStyleButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_ColInterlaceStyle.FillStyle, fillStyleResult) Then
				m_ColInterlaceStyle.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub ColumnInterlacingBeginNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ColumnInterlacingBeginNumericUpDown.ValueChanged
			ConfigureLegend()
		End Sub

		Private Sub ColumnInterlacingEndNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ColumnInterlacingEndNumericUpDown.ValueChanged
			ConfigureLegend()
		End Sub

		Private Sub ColumnInterlacingInfiniteCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ColumnInterlacingInfiniteCheckBox.CheckedChanged
			ConfigureLegend()
		End Sub

		Private Sub ColumnInterlacingLengthNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ColumnInterlacingLengthNumericUpDown.ValueChanged
			ConfigureLegend()
		End Sub

		Private Sub ColumnInterlacingIntervalNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ColumnInterlacingIntervalNumericUpDown.ValueChanged
			ConfigureLegend()
		End Sub

		Private Sub ExpandModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExpandModeComboBox.SelectedIndexChanged
			ConfigureLegend()
		End Sub

		Private Sub RowCountUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RowCountUpDown.ValueChanged
			ConfigureLegend()
		End Sub

		Private Sub ColCountUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ColCountUpDown.ValueChanged
			ConfigureLegend()
		End Sub
	End Class
End Namespace
