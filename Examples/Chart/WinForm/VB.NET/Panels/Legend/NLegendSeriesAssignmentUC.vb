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
	Public Class NLegendSeriesAssignmentUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bar1 As NBarSeries
		Private m_Bar2 As NBarSeries
		Private m_Bar3 As NBarSeries
		Private m_bUpdateLegends As Boolean
		Private WithEvents FirstTextStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents SecondTextStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ThirdTextStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents PositiveDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents PositiveAndNegativeDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents FirstDisplayOnLegendComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents SecondDisplayOnLegendComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents ThirdDisplayOnLegendComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents FirstSeriesLegendModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents SecondSeriesLegendModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents ThirdSeriesLegendModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private DataGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private FirstSerieGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private SecondSerieGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private ThirdSerieGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private DataPointsNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents FirstSeriesFormatTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents SecondSeriesFormatTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents ThirdSeriesFormatTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private label8 As System.Windows.Forms.Label
		Private label9 As System.Windows.Forms.Label
		Private label10 As System.Windows.Forms.Label
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
			Me.FirstSerieGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label10 = New System.Windows.Forms.Label()
			Me.FirstDisplayOnLegendComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.FirstSeriesLegendModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.FirstSeriesFormatTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.FirstTextStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SecondSerieGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.label9 = New System.Windows.Forms.Label()
			Me.SecondDisplayOnLegendComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SecondSeriesLegendModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SecondSeriesFormatTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.SecondTextStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ThirdSerieGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label7 = New System.Windows.Forms.Label()
			Me.ThirdDisplayOnLegendComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.ThirdSeriesLegendModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.ThirdSeriesFormatTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.ThirdTextStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.PositiveDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.PositiveAndNegativeDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label8 = New System.Windows.Forms.Label()
			Me.DataPointsNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.DataGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.FirstSerieGroupBox.SuspendLayout()
			Me.SecondSerieGroupBox.SuspendLayout()
			Me.ThirdSerieGroupBox.SuspendLayout()
			DirectCast(Me.DataPointsNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.DataGroupBox.SuspendLayout()
			Me.SuspendLayout()
			' 
			' FirstSerieGroupBox
			' 
			Me.FirstSerieGroupBox.Controls.Add(Me.label3)
			Me.FirstSerieGroupBox.Controls.Add(Me.label5)
			Me.FirstSerieGroupBox.Controls.Add(Me.label10)
			Me.FirstSerieGroupBox.Controls.Add(Me.FirstDisplayOnLegendComboBox)
			Me.FirstSerieGroupBox.Controls.Add(Me.FirstSeriesLegendModeComboBox)
			Me.FirstSerieGroupBox.Controls.Add(Me.FirstSeriesFormatTextBox)
			Me.FirstSerieGroupBox.Controls.Add(Me.FirstTextStyleButton)
			Me.FirstSerieGroupBox.ImageIndex = 0
			Me.FirstSerieGroupBox.Location = New System.Drawing.Point(8, 0)
			Me.FirstSerieGroupBox.Name = "FirstSerieGroupBox"
			Me.FirstSerieGroupBox.Size = New System.Drawing.Size(168, 184)
			Me.FirstSerieGroupBox.TabIndex = 0
			Me.FirstSerieGroupBox.TabStop = False
			Me.FirstSerieGroupBox.Text = "First series"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 16)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(152, 16)
			Me.label3.TabIndex = 4
			Me.label3.Text = "Display on legend:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(8, 63)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(152, 16)
			Me.label5.TabIndex = 4
			Me.label5.Text = "Series legend mode:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label10
			' 
			Me.label10.Location = New System.Drawing.Point(8, 110)
			Me.label10.Name = "label10"
			Me.label10.Size = New System.Drawing.Size(152, 16)
			Me.label10.TabIndex = 6
			Me.label10.Text = "Format:"
			Me.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' FirstDisplayOnLegendComboBox
			' 
			Me.FirstDisplayOnLegendComboBox.ListProperties.CheckBoxDataMember = ""
			Me.FirstDisplayOnLegendComboBox.ListProperties.DataSource = Nothing
			Me.FirstDisplayOnLegendComboBox.ListProperties.DisplayMember = ""
			Me.FirstDisplayOnLegendComboBox.Location = New System.Drawing.Point(8, 37)
			Me.FirstDisplayOnLegendComboBox.Name = "FirstDisplayOnLegendComboBox"
			Me.FirstDisplayOnLegendComboBox.Size = New System.Drawing.Size(152, 21)
			Me.FirstDisplayOnLegendComboBox.TabIndex = 6
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FirstDisplayOnLegendComboBox.SelectedIndexChanged += new System.EventHandler(this.FirstDisplayOnLegendComboBox_SelectedIndexChanged);
			' 
			' FirstSeriesLegendModeComboBox
			' 
			Me.FirstSeriesLegendModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.FirstSeriesLegendModeComboBox.ListProperties.DataSource = Nothing
			Me.FirstSeriesLegendModeComboBox.ListProperties.DisplayMember = ""
			Me.FirstSeriesLegendModeComboBox.Location = New System.Drawing.Point(8, 84)
			Me.FirstSeriesLegendModeComboBox.Name = "FirstSeriesLegendModeComboBox"
			Me.FirstSeriesLegendModeComboBox.Size = New System.Drawing.Size(152, 21)
			Me.FirstSeriesLegendModeComboBox.TabIndex = 6
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FirstSeriesLegendModeComboBox.SelectedIndexChanged += new System.EventHandler(this.FirstSeriesLegendModeComboBox_SelectedIndexChanged);
			' 
			' FirstSeriesFormatTextBox
			' 
			Me.FirstSeriesFormatTextBox.Location = New System.Drawing.Point(8, 131)
			Me.FirstSeriesFormatTextBox.Name = "FirstSeriesFormatTextBox"
			Me.FirstSeriesFormatTextBox.Size = New System.Drawing.Size(152, 18)
			Me.FirstSeriesFormatTextBox.TabIndex = 6
			Me.FirstSeriesFormatTextBox.Text = "FirstSeriesFormatTextBox"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FirstSeriesFormatTextBox.TextChanged += new System.EventHandler(this.FirstSeriesFormatTextBox_TextChanged);
			' 
			' FirstTextStyleButton
			' 
			Me.FirstTextStyleButton.Location = New System.Drawing.Point(8, 156)
			Me.FirstTextStyleButton.Name = "FirstTextStyleButton"
			Me.FirstTextStyleButton.Size = New System.Drawing.Size(152, 23)
			Me.FirstTextStyleButton.TabIndex = 3
			Me.FirstTextStyleButton.Text = "Text Style"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FirstTextStyleButton.Click += new System.EventHandler(this.FirstTextStyleButton_Click);
			' 
			' SecondSerieGroupBox
			' 
			Me.SecondSerieGroupBox.Controls.Add(Me.label1)
			Me.SecondSerieGroupBox.Controls.Add(Me.label6)
			Me.SecondSerieGroupBox.Controls.Add(Me.label9)
			Me.SecondSerieGroupBox.Controls.Add(Me.SecondDisplayOnLegendComboBox)
			Me.SecondSerieGroupBox.Controls.Add(Me.SecondSeriesLegendModeComboBox)
			Me.SecondSerieGroupBox.Controls.Add(Me.SecondSeriesFormatTextBox)
			Me.SecondSerieGroupBox.Controls.Add(Me.SecondTextStyleButton)
			Me.SecondSerieGroupBox.ImageIndex = 0
			Me.SecondSerieGroupBox.Location = New System.Drawing.Point(8, 184)
			Me.SecondSerieGroupBox.Name = "SecondSerieGroupBox"
			Me.SecondSerieGroupBox.Size = New System.Drawing.Size(168, 184)
			Me.SecondSerieGroupBox.TabIndex = 1
			Me.SecondSerieGroupBox.TabStop = False
			Me.SecondSerieGroupBox.Text = "Second series"
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 16)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(152, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Display on legend:"
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(8, 64)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(152, 16)
			Me.label6.TabIndex = 5
			Me.label6.Text = "Series legend mode:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label9
			' 
			Me.label9.Location = New System.Drawing.Point(8, 104)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(152, 16)
			Me.label9.TabIndex = 5
			Me.label9.Text = "Format:"
			Me.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' SecondDisplayOnLegendComboBox
			' 
			Me.SecondDisplayOnLegendComboBox.ListProperties.CheckBoxDataMember = ""
			Me.SecondDisplayOnLegendComboBox.ListProperties.DataSource = Nothing
			Me.SecondDisplayOnLegendComboBox.ListProperties.DisplayMember = ""
			Me.SecondDisplayOnLegendComboBox.Location = New System.Drawing.Point(8, 32)
			Me.SecondDisplayOnLegendComboBox.Name = "SecondDisplayOnLegendComboBox"
			Me.SecondDisplayOnLegendComboBox.Size = New System.Drawing.Size(152, 21)
			Me.SecondDisplayOnLegendComboBox.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SecondDisplayOnLegendComboBox.SelectedIndexChanged += new System.EventHandler(this.SecondDisplayOnLegendComboBox_SelectedIndexChanged);
			' 
			' SecondSeriesLegendModeComboBox
			' 
			Me.SecondSeriesLegendModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.SecondSeriesLegendModeComboBox.ListProperties.DataSource = Nothing
			Me.SecondSeriesLegendModeComboBox.ListProperties.DisplayMember = ""
			Me.SecondSeriesLegendModeComboBox.Location = New System.Drawing.Point(8, 80)
			Me.SecondSeriesLegendModeComboBox.Name = "SecondSeriesLegendModeComboBox"
			Me.SecondSeriesLegendModeComboBox.Size = New System.Drawing.Size(152, 21)
			Me.SecondSeriesLegendModeComboBox.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SecondSeriesLegendModeComboBox.SelectedIndexChanged += new System.EventHandler(this.SecondSeriesLegendModeComboBox_SelectedIndexChanged);
			' 
			' SecondSeriesFormatTextBox
			' 
			Me.SecondSeriesFormatTextBox.Location = New System.Drawing.Point(8, 128)
			Me.SecondSeriesFormatTextBox.Name = "SecondSeriesFormatTextBox"
			Me.SecondSeriesFormatTextBox.Size = New System.Drawing.Size(152, 18)
			Me.SecondSeriesFormatTextBox.TabIndex = 7
			Me.SecondSeriesFormatTextBox.Text = "textBox1"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SecondSeriesFormatTextBox.TextChanged += new System.EventHandler(this.SecondSeriesFormatTextBox_TextChanged);
			' 
			' SecondTextStyleButton
			' 
			Me.SecondTextStyleButton.Location = New System.Drawing.Point(8, 152)
			Me.SecondTextStyleButton.Name = "SecondTextStyleButton"
			Me.SecondTextStyleButton.Size = New System.Drawing.Size(152, 23)
			Me.SecondTextStyleButton.TabIndex = 4
			Me.SecondTextStyleButton.Text = "Text Style"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SecondTextStyleButton.Click += new System.EventHandler(this.SecondTextStyleButton_Click);
			' 
			' ThirdSerieGroupBox
			' 
			Me.ThirdSerieGroupBox.Controls.Add(Me.label2)
			Me.ThirdSerieGroupBox.Controls.Add(Me.label4)
			Me.ThirdSerieGroupBox.Controls.Add(Me.label7)
			Me.ThirdSerieGroupBox.Controls.Add(Me.ThirdDisplayOnLegendComboBox)
			Me.ThirdSerieGroupBox.Controls.Add(Me.ThirdSeriesLegendModeComboBox)
			Me.ThirdSerieGroupBox.Controls.Add(Me.ThirdSeriesFormatTextBox)
			Me.ThirdSerieGroupBox.Controls.Add(Me.ThirdTextStyleButton)
			Me.ThirdSerieGroupBox.ImageIndex = 0
			Me.ThirdSerieGroupBox.Location = New System.Drawing.Point(8, 368)
			Me.ThirdSerieGroupBox.Name = "ThirdSerieGroupBox"
			Me.ThirdSerieGroupBox.Size = New System.Drawing.Size(168, 184)
			Me.ThirdSerieGroupBox.TabIndex = 2
			Me.ThirdSerieGroupBox.TabStop = False
			Me.ThirdSerieGroupBox.Text = "Third series"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 16)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(152, 16)
			Me.label2.TabIndex = 3
			Me.label2.Text = "Display on legend:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 63)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(152, 16)
			Me.label4.TabIndex = 3
			Me.label4.Text = "Series legend mode:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(8, 110)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(152, 16)
			Me.label7.TabIndex = 3
			Me.label7.Text = "Format:"
			Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' ThirdDisplayOnLegendComboBox
			' 
			Me.ThirdDisplayOnLegendComboBox.ListProperties.CheckBoxDataMember = ""
			Me.ThirdDisplayOnLegendComboBox.ListProperties.DataSource = Nothing
			Me.ThirdDisplayOnLegendComboBox.ListProperties.DisplayMember = ""
			Me.ThirdDisplayOnLegendComboBox.Location = New System.Drawing.Point(8, 37)
			Me.ThirdDisplayOnLegendComboBox.Name = "ThirdDisplayOnLegendComboBox"
			Me.ThirdDisplayOnLegendComboBox.Size = New System.Drawing.Size(152, 21)
			Me.ThirdDisplayOnLegendComboBox.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ThirdDisplayOnLegendComboBox.SelectedIndexChanged += new System.EventHandler(this.ThirdDisplayOnLegendComboBox_SelectedIndexChanged);
			' 
			' ThirdSeriesLegendModeComboBox
			' 
			Me.ThirdSeriesLegendModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.ThirdSeriesLegendModeComboBox.ListProperties.DataSource = Nothing
			Me.ThirdSeriesLegendModeComboBox.ListProperties.DisplayMember = ""
			Me.ThirdSeriesLegendModeComboBox.Location = New System.Drawing.Point(8, 84)
			Me.ThirdSeriesLegendModeComboBox.Name = "ThirdSeriesLegendModeComboBox"
			Me.ThirdSeriesLegendModeComboBox.Size = New System.Drawing.Size(152, 21)
			Me.ThirdSeriesLegendModeComboBox.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ThirdSeriesLegendModeComboBox.SelectedIndexChanged += new System.EventHandler(this.ThirdSeriesLegendModeComboBox_SelectedIndexChanged);
			' 
			' ThirdSeriesFormatTextBox
			' 
			Me.ThirdSeriesFormatTextBox.Location = New System.Drawing.Point(8, 131)
			Me.ThirdSeriesFormatTextBox.Name = "ThirdSeriesFormatTextBox"
			Me.ThirdSeriesFormatTextBox.Size = New System.Drawing.Size(152, 18)
			Me.ThirdSeriesFormatTextBox.TabIndex = 8
			Me.ThirdSeriesFormatTextBox.Text = "textBox1"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ThirdSeriesFormatTextBox.TextChanged += new System.EventHandler(this.ThirdSeriesFormatTextBox_TextChanged);
			' 
			' ThirdTextStyleButton
			' 
			Me.ThirdTextStyleButton.Location = New System.Drawing.Point(8, 156)
			Me.ThirdTextStyleButton.Name = "ThirdTextStyleButton"
			Me.ThirdTextStyleButton.Size = New System.Drawing.Size(152, 23)
			Me.ThirdTextStyleButton.TabIndex = 5
			Me.ThirdTextStyleButton.Text = "Text Style"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ThirdTextStyleButton.Click += new System.EventHandler(this.ThirdTextStyleButton_Click);
			' 
			' PositiveDataButton
			' 
			Me.PositiveDataButton.Location = New System.Drawing.Point(8, 64)
			Me.PositiveDataButton.Name = "PositiveDataButton"
			Me.PositiveDataButton.Size = New System.Drawing.Size(152, 23)
			Me.PositiveDataButton.TabIndex = 3
			Me.PositiveDataButton.Text = "Positive data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PositiveDataButton.Click += new System.EventHandler(this.PositiveDataButton_Click);
			' 
			' PositiveAndNegativeDataButton
			' 
			Me.PositiveAndNegativeDataButton.Location = New System.Drawing.Point(8, 88)
			Me.PositiveAndNegativeDataButton.Name = "PositiveAndNegativeDataButton"
			Me.PositiveAndNegativeDataButton.Size = New System.Drawing.Size(152, 23)
			Me.PositiveAndNegativeDataButton.TabIndex = 4
			Me.PositiveAndNegativeDataButton.Text = "Positive and Negative data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PositiveAndNegativeDataButton.Click += new System.EventHandler(this.PositiveAndNegativeDataButton_Click);
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(8, 32)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(72, 20)
			Me.label8.TabIndex = 5
			Me.label8.Text = "Data points:"
			Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' DataPointsNumericUpDown
			' 
			Me.DataPointsNumericUpDown.Location = New System.Drawing.Point(80, 32)
			Me.DataPointsNumericUpDown.Maximum = New Decimal(New Integer() { 15, 0, 0, 0})
			Me.DataPointsNumericUpDown.Name = "DataPointsNumericUpDown"
			Me.DataPointsNumericUpDown.Size = New System.Drawing.Size(80, 20)
			Me.DataPointsNumericUpDown.TabIndex = 0
			Me.DataPointsNumericUpDown.Value = New Decimal(New Integer() { 10, 0, 0, 0})
			' 
			' DataGroupBox
			' 
			Me.DataGroupBox.Controls.Add(Me.label8)
			Me.DataGroupBox.Controls.Add(Me.PositiveAndNegativeDataButton)
			Me.DataGroupBox.Controls.Add(Me.DataPointsNumericUpDown)
			Me.DataGroupBox.Controls.Add(Me.PositiveDataButton)
			Me.DataGroupBox.Location = New System.Drawing.Point(8, 552)
			Me.DataGroupBox.Name = "DataGroupBox"
			Me.DataGroupBox.Size = New System.Drawing.Size(168, 120)
			Me.DataGroupBox.TabIndex = 6
			Me.DataGroupBox.TabStop = False
			Me.DataGroupBox.Text = "Data"
			' 
			' NLegendSeriesAssignmentUC
			' 
			Me.Controls.Add(Me.DataGroupBox)
			Me.Controls.Add(Me.ThirdSerieGroupBox)
			Me.Controls.Add(Me.SecondSerieGroupBox)
			Me.Controls.Add(Me.FirstSerieGroupBox)
			Me.Name = "NLegendSeriesAssignmentUC"
			Me.Size = New System.Drawing.Size(180, 680)
			Me.FirstSerieGroupBox.ResumeLayout(False)
			Me.SecondSerieGroupBox.ResumeLayout(False)
			Me.ThirdSerieGroupBox.ResumeLayout(False)
			DirectCast(Me.DataPointsNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.DataGroupBox.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' confgigure chart
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As New NLabel("Series Legend Assignment")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			header.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
			header.DockMode = PanelDockMode.Top
			header.Margins = New NMarginsL(0, 10, 0, 10)
			nChartControl1.Panels.Add(header)

			' configure the legends
			Dim leftLegend As New NLegend()
			leftLegend.DockMode = PanelDockMode.Left
			leftLegend.Mode = LegendMode.Automatic
			leftLegend.Data.ExpandMode = LegendExpandMode.ColsFixed
			leftLegend.Data.ColCount = 2
			leftLegend.BoundsMode = BoundsMode.Fit
			leftLegend.Margins = New NMarginsL(10, 0, 0, 0)
			nChartControl1.Panels.Add(leftLegend)

			Dim rightLegend As New NLegend()
			rightLegend.DockMode = PanelDockMode.Right
			rightLegend.Data.ExpandMode = LegendExpandMode.ColsFixed
			rightLegend.Data.ColCount = 2
			rightLegend.Mode = LegendMode.Automatic
			rightLegend.BoundsMode = BoundsMode.Fit
			rightLegend.Margins = New NMarginsL(0, 0, 10, 0)
			nChartControl1.Panels.Add(rightLegend)

			' create the chart
			m_Chart = New NCartesianChart()
			m_Chart.Enable3D = True
			m_Chart.DockMode = PanelDockMode.Fill
			m_Chart.BoundsMode = BoundsMode.Fit

			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre)
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			m_Chart.Margins = New NMarginsL(28, 10, 20, 10)

			nChartControl1.Panels.Add(m_Chart)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' add the first bar
			m_Bar1 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar1.Name = "Bar1"
			m_Bar1.MultiBarMode = MultiBarMode.Series

			' add the second bar
			m_Bar2 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar2.Name = "Bar2"
			m_Bar2.MultiBarMode = MultiBarMode.Stacked

			' add the third bar
			m_Bar3 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar3.Name = "Bar3"
			m_Bar3.MultiBarMode = MultiBarMode.Stacked

			' position data labels in the center of the bars
			m_Bar1.DataLabelStyle.Visible = True
			m_Bar1.DataLabelStyle.VertAlign = VertAlign.Center
			m_Bar1.DataLabelStyle.Format = "<value>"

			m_Bar2.DataLabelStyle.Visible = True
			m_Bar2.DataLabelStyle.VertAlign = VertAlign.Center
			m_Bar2.DataLabelStyle.Format = "<value>"

			m_Bar3.DataLabelStyle.Visible = True
			m_Bar3.DataLabelStyle.VertAlign = VertAlign.Center
			m_Bar3.DataLabelStyle.Format = "<value>"

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			m_bUpdateLegends = False

			' first series legend configuration
			FirstDisplayOnLegendComboBox.Items.Add("Left")
			FirstDisplayOnLegendComboBox.Items.Add("Right")
			FirstDisplayOnLegendComboBox.SelectedIndex = 0

			FirstSeriesLegendModeComboBox.Items.Add("None")
			FirstSeriesLegendModeComboBox.Items.Add("Series")
			FirstSeriesLegendModeComboBox.Items.Add("DataPoints")
			FirstSeriesLegendModeComboBox.Items.Add("SeriesLogic")
			FirstSeriesLegendModeComboBox.SelectedIndex = 2

			FirstSeriesFormatTextBox.Text = m_Bar1.Legend.Format

			' second series legend configuration
			SecondDisplayOnLegendComboBox.Items.Add("Left")
			SecondDisplayOnLegendComboBox.Items.Add("Right")
			SecondDisplayOnLegendComboBox.SelectedIndex = 0

			SecondSeriesLegendModeComboBox.Items.Add("None")
			SecondSeriesLegendModeComboBox.Items.Add("Series")
			SecondSeriesLegendModeComboBox.Items.Add("DataPoints")
			SecondSeriesLegendModeComboBox.Items.Add("SeriesLogic")
			SecondSeriesLegendModeComboBox.SelectedIndex = 2

			SecondSeriesFormatTextBox.Text = m_Bar2.Legend.Format

			' third series legend configuration
			ThirdDisplayOnLegendComboBox.Items.Add("Left")
			ThirdDisplayOnLegendComboBox.Items.Add("Right")
			ThirdDisplayOnLegendComboBox.SelectedIndex = 1

			ThirdSeriesLegendModeComboBox.Items.Add("None")
			ThirdSeriesLegendModeComboBox.Items.Add("Series")
			ThirdSeriesLegendModeComboBox.Items.Add("DataPoints")
			ThirdSeriesLegendModeComboBox.Items.Add("SeriesLogic")
			ThirdSeriesLegendModeComboBox.SelectedIndex = 2

			ThirdSeriesFormatTextBox.Text = m_Bar2.Legend.Format

			m_bUpdateLegends = True

			PositiveDataButton_Click(Nothing, Nothing)
			ConfigureLegends()
		End Sub


		Private Sub ConfigureLegends()
			If m_bUpdateLegends = False Then
				Return
			End If

			m_Bar1.Legend.DisplayOnLegend = CType(nChartControl1.Legends(FirstDisplayOnLegendComboBox.SelectedIndex), NLegend)
			m_Bar1.Legend.Mode = CType(FirstSeriesLegendModeComboBox.SelectedIndex, SeriesLegendMode)
			m_Bar1.Legend.Format = FirstSeriesFormatTextBox.Text

			m_Bar2.Legend.DisplayOnLegend = CType(nChartControl1.Legends(SecondDisplayOnLegendComboBox.SelectedIndex), NLegend)
			m_Bar2.Legend.Mode = CType(SecondSeriesLegendModeComboBox.SelectedIndex, SeriesLegendMode)
			m_Bar3.Legend.Format = SecondSeriesFormatTextBox.Text

			m_Bar3.Legend.Mode = CType(ThirdSeriesLegendModeComboBox.SelectedIndex, SeriesLegendMode)
			m_Bar3.Legend.DisplayOnLegend = CType(nChartControl1.Legends(ThirdDisplayOnLegendComboBox.SelectedIndex), NLegend)
			m_Bar3.Legend.Format = ThirdSeriesFormatTextBox.Text

			nChartControl1.Refresh()
		End Sub

		Private Sub FirstDisplayOnLegendComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FirstDisplayOnLegendComboBox.SelectedIndexChanged
			ConfigureLegends()
		End Sub

		Private Sub FirstSeriesLegendModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FirstSeriesLegendModeComboBox.SelectedIndexChanged
			ConfigureLegends()
		End Sub

		Private Sub FirstSeriesFormatTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FirstSeriesFormatTextBox.TextChanged
			ConfigureLegends()
		End Sub

		Private Sub FirstTextStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FirstTextStyleButton.Click
			Dim textStyleResult As NTextStyle = Nothing

			If NTextStyleTypeEditor.Edit(m_Bar1.Legend.TextStyle, textStyleResult) Then
				m_Bar1.Legend.TextStyle = textStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub SecondDisplayOnLegendComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SecondDisplayOnLegendComboBox.SelectedIndexChanged
			ConfigureLegends()
		End Sub

		Private Sub SecondSeriesLegendModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SecondSeriesLegendModeComboBox.SelectedIndexChanged
			ConfigureLegends()
		End Sub

		Private Sub SecondSeriesFormatTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SecondSeriesFormatTextBox.TextChanged
			ConfigureLegends()
		End Sub

		Private Sub SecondTextStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SecondTextStyleButton.Click
			Dim textStyleResult As NTextStyle = Nothing

			If NTextStyleTypeEditor.Edit(m_Bar2.Legend.TextStyle, textStyleResult) Then
				m_Bar2.Legend.TextStyle = textStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub ThirdDisplayOnLegendComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ThirdDisplayOnLegendComboBox.SelectedIndexChanged
			ConfigureLegends()
		End Sub

		Private Sub ThirdSeriesLegendModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ThirdSeriesLegendModeComboBox.SelectedIndexChanged
			ConfigureLegends()
		End Sub

		Private Sub ThirdSeriesFormatTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ThirdSeriesFormatTextBox.TextChanged
			ConfigureLegends()
		End Sub

		Private Sub ThirdTextStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ThirdTextStyleButton.Click
			Dim textStyleResult As NTextStyle = Nothing

			If NTextStyleTypeEditor.Edit(m_Bar3.Legend.TextStyle, textStyleResult) Then
				m_Bar3.Legend.TextStyle = textStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub PositiveDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PositiveDataButton.Click
			Dim nDataPoints As Integer = CInt(Math.Truncate(DataPointsNumericUpDown.Value))
			m_Bar1.Values.FillRandomRange(Random, nDataPoints, 20, 100)
			m_Bar2.Values.FillRandomRange(Random, nDataPoints, 20, 100)
			m_Bar3.Values.FillRandomRange(Random, nDataPoints, 20, 100)
			nChartControl1.Refresh()
		End Sub

		Private Sub PositiveAndNegativeDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PositiveAndNegativeDataButton.Click
			Dim nDataPoints As Integer = CInt(Math.Truncate(DataPointsNumericUpDown.Value))
			m_Bar1.Values.FillRandomRange(Random, nDataPoints, -100, 100)
			m_Bar2.Values.FillRandomRange(Random, nDataPoints, -100, 100)
			m_Bar3.Values.FillRandomRange(Random, nDataPoints, -100, 100)
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
