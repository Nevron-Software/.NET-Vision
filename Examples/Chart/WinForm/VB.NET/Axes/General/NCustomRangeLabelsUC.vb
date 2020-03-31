Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NCustomRangeLabelsUC
		Inherits NExampleBaseUC

		Private m_Bar1 As NBarSeries
		Private m_Bar2 As NBarSeries
		Private WithEvents LabelTickModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As Label
		Private label2 As Label
		Private WithEvents LabelAngleNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents NorthAmericaCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents EuropeCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents AsiaCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents SouthAmericaCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private label3 As Label
		Private WithEvents LabelVisibilityModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents TextPaddingNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label4 As Label
		Private WithEvents TextOffsetNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label5 As Label
		Private label6 As Label
		Private WithEvents TickPaddingNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents TickOffsetNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label7 As Label
		Private label8 As Label
		Private WithEvents LabelFitModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox3 As Nevron.UI.WinForm.Controls.NGroupBox
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		Public Sub New()
			InitializeComponent()
		End Sub

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
			Me.LabelTickModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.LabelAngleNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.NorthAmericaCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.EuropeCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.AsiaCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SouthAmericaCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.LabelVisibilityModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.TextPaddingNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label4 = New System.Windows.Forms.Label()
			Me.TextOffsetNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.TickPaddingNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.TickOffsetNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label7 = New System.Windows.Forms.Label()
			Me.label8 = New System.Windows.Forms.Label()
			Me.LabelFitModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nGroupBox3 = New Nevron.UI.WinForm.Controls.NGroupBox()
			DirectCast(Me.LabelAngleNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.TextPaddingNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.TextOffsetNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.TickPaddingNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.TickOffsetNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nGroupBox2.SuspendLayout()
			Me.nGroupBox1.SuspendLayout()
			Me.nGroupBox3.SuspendLayout()
			Me.SuspendLayout()
			' 
			' LabelTickModeComboBox
			' 
			Me.LabelTickModeComboBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.LabelTickModeComboBox.Location = New System.Drawing.Point(3, 81)
			Me.LabelTickModeComboBox.Name = "LabelTickModeComboBox"
			Me.LabelTickModeComboBox.Size = New System.Drawing.Size(173, 21)
			Me.LabelTickModeComboBox.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LabelTickModeComboBox.SelectedIndexChanged += new System.EventHandler(this.LabelTickModeComboBox_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Dock = System.Windows.Forms.DockStyle.Top
			Me.label1.Location = New System.Drawing.Point(3, 59)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(173, 22)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Label Tick Mode:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' label2
			' 
			Me.label2.Dock = System.Windows.Forms.DockStyle.Top
			Me.label2.Location = New System.Drawing.Point(3, 16)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(173, 22)
			Me.label2.TabIndex = 5
			Me.label2.Text = "Angle: "
			Me.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' LabelAngleNumericUpDown
			' 
			Me.LabelAngleNumericUpDown.Dock = System.Windows.Forms.DockStyle.Top
			Me.LabelAngleNumericUpDown.Location = New System.Drawing.Point(3, 38)
			Me.LabelAngleNumericUpDown.Maximum = New Decimal(New Integer() { 360, 0, 0, 0})
			Me.LabelAngleNumericUpDown.Minimum = New Decimal(New Integer() { 360, 0, 0, -2147483648})
			Me.LabelAngleNumericUpDown.Name = "LabelAngleNumericUpDown"
			Me.LabelAngleNumericUpDown.Size = New System.Drawing.Size(173, 20)
			Me.LabelAngleNumericUpDown.TabIndex = 6
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LabelAngleNumericUpDown.ValueChanged += new System.EventHandler(this.LabelAngleNumericUpDown_ValueChanged);
			' 
			' NorthAmericaCheckBox
			' 
			Me.NorthAmericaCheckBox.AutoSize = True
			Me.NorthAmericaCheckBox.ButtonProperties.BorderOffset = 2
			Me.NorthAmericaCheckBox.Location = New System.Drawing.Point(3, 425)
			Me.NorthAmericaCheckBox.Name = "NorthAmericaCheckBox"
			Me.NorthAmericaCheckBox.Size = New System.Drawing.Size(93, 17)
			Me.NorthAmericaCheckBox.TabIndex = 15
			Me.NorthAmericaCheckBox.Text = "North America"
			Me.NorthAmericaCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.NorthAmericaCheckBox.CheckedChanged += new System.EventHandler(this.NorthAmericaCheckBox_CheckedChanged);
			' 
			' EuropeCheckBox
			' 
			Me.EuropeCheckBox.AutoSize = True
			Me.EuropeCheckBox.ButtonProperties.BorderOffset = 2
			Me.EuropeCheckBox.Location = New System.Drawing.Point(3, 448)
			Me.EuropeCheckBox.Name = "EuropeCheckBox"
			Me.EuropeCheckBox.Size = New System.Drawing.Size(60, 17)
			Me.EuropeCheckBox.TabIndex = 16
			Me.EuropeCheckBox.Text = "Europe"
			Me.EuropeCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EuropeCheckBox.CheckedChanged += new System.EventHandler(this.EuropeCheckBox_CheckedChanged);
			' 
			' AsiaCheckBox
			' 
			Me.AsiaCheckBox.AutoSize = True
			Me.AsiaCheckBox.ButtonProperties.BorderOffset = 2
			Me.AsiaCheckBox.Location = New System.Drawing.Point(3, 471)
			Me.AsiaCheckBox.Name = "AsiaCheckBox"
			Me.AsiaCheckBox.Size = New System.Drawing.Size(46, 17)
			Me.AsiaCheckBox.TabIndex = 17
			Me.AsiaCheckBox.Text = "Asia"
			Me.AsiaCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AsiaCheckBox.CheckedChanged += new System.EventHandler(this.AsiaCheckBox_CheckedChanged);
			' 
			' SouthAmericaCheckBox
			' 
			Me.SouthAmericaCheckBox.AutoSize = True
			Me.SouthAmericaCheckBox.ButtonProperties.BorderOffset = 2
			Me.SouthAmericaCheckBox.Location = New System.Drawing.Point(3, 493)
			Me.SouthAmericaCheckBox.Name = "SouthAmericaCheckBox"
			Me.SouthAmericaCheckBox.Size = New System.Drawing.Size(95, 17)
			Me.SouthAmericaCheckBox.TabIndex = 18
			Me.SouthAmericaCheckBox.Text = "South America"
			Me.SouthAmericaCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SouthAmericaCheckBox.CheckedChanged += new System.EventHandler(this.SouthAmericaCheckBox_CheckedChanged);
			' 
			' label3
			' 
			Me.label3.Dock = System.Windows.Forms.DockStyle.Top
			Me.label3.Location = New System.Drawing.Point(3, 16)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(173, 22)
			Me.label3.TabIndex = 0
			Me.label3.Text = "Label Visibility Mode:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' LabelVisibilityModeComboBox
			' 
			Me.LabelVisibilityModeComboBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.LabelVisibilityModeComboBox.Location = New System.Drawing.Point(3, 38)
			Me.LabelVisibilityModeComboBox.Name = "LabelVisibilityModeComboBox"
			Me.LabelVisibilityModeComboBox.Size = New System.Drawing.Size(173, 21)
			Me.LabelVisibilityModeComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LabelVisibilityModeComboBox.SelectedIndexChanged += new System.EventHandler(this.LabelVisibilityModeComboBox_SelectedIndexChanged);
			' 
			' TextPaddingNumericUpDown
			' 
			Me.TextPaddingNumericUpDown.Dock = System.Windows.Forms.DockStyle.Top
			Me.TextPaddingNumericUpDown.Location = New System.Drawing.Point(3, 122)
			Me.TextPaddingNumericUpDown.Name = "TextPaddingNumericUpDown"
			Me.TextPaddingNumericUpDown.Size = New System.Drawing.Size(173, 20)
			Me.TextPaddingNumericUpDown.TabIndex = 14
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TextPaddingNumericUpDown.ValueChanged += new System.EventHandler(this.TextPaddingNumericUpDown_ValueChanged);
			' 
			' label4
			' 
			Me.label4.Dock = System.Windows.Forms.DockStyle.Top
			Me.label4.Location = New System.Drawing.Point(3, 100)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(173, 22)
			Me.label4.TabIndex = 13
			Me.label4.Text = "Text Padding: "
			Me.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' TextOffsetNumericUpDown
			' 
			Me.TextOffsetNumericUpDown.Dock = System.Windows.Forms.DockStyle.Top
			Me.TextOffsetNumericUpDown.Location = New System.Drawing.Point(3, 80)
			Me.TextOffsetNumericUpDown.Name = "TextOffsetNumericUpDown"
			Me.TextOffsetNumericUpDown.Size = New System.Drawing.Size(173, 20)
			Me.TextOffsetNumericUpDown.TabIndex = 10
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TextOffsetNumericUpDown.ValueChanged += new System.EventHandler(this.TextOffsetNumericUpDown_ValueChanged);
			' 
			' label5
			' 
			Me.label5.Dock = System.Windows.Forms.DockStyle.Top
			Me.label5.Location = New System.Drawing.Point(3, 58)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(173, 22)
			Me.label5.TabIndex = 9
			Me.label5.Text = "Text Offset: "
			Me.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' label6
			' 
			Me.label6.Dock = System.Windows.Forms.DockStyle.Top
			Me.label6.Location = New System.Drawing.Point(3, 58)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(173, 22)
			Me.label6.TabIndex = 11
			Me.label6.Text = "Tick Padding:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' TickPaddingNumericUpDown
			' 
			Me.TickPaddingNumericUpDown.Dock = System.Windows.Forms.DockStyle.Top
			Me.TickPaddingNumericUpDown.Location = New System.Drawing.Point(3, 80)
			Me.TickPaddingNumericUpDown.Name = "TickPaddingNumericUpDown"
			Me.TickPaddingNumericUpDown.Size = New System.Drawing.Size(173, 20)
			Me.TickPaddingNumericUpDown.TabIndex = 12
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TickPaddingNumericUpDown.ValueChanged += new System.EventHandler(this.TickPaddingNumericUpDown_ValueChanged);
			' 
			' TickOffsetNumericUpDown
			' 
			Me.TickOffsetNumericUpDown.Dock = System.Windows.Forms.DockStyle.Top
			Me.TickOffsetNumericUpDown.Location = New System.Drawing.Point(3, 38)
			Me.TickOffsetNumericUpDown.Name = "TickOffsetNumericUpDown"
			Me.TickOffsetNumericUpDown.Size = New System.Drawing.Size(173, 20)
			Me.TickOffsetNumericUpDown.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TickOffsetNumericUpDown.ValueChanged += new System.EventHandler(this.TickOffsetNumericUpDown_ValueChanged);
			' 
			' label7
			' 
			Me.label7.Dock = System.Windows.Forms.DockStyle.Top
			Me.label7.Location = New System.Drawing.Point(3, 16)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(173, 22)
			Me.label7.TabIndex = 7
			Me.label7.Text = "Tick Offset:"
			Me.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' label8
			' 
			Me.label8.Dock = System.Windows.Forms.DockStyle.Top
			Me.label8.Location = New System.Drawing.Point(3, 102)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(173, 22)
			Me.label8.TabIndex = 19
			Me.label8.Text = "Label Fit Mode:"
			Me.label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' LabelFitModeComboBox
			' 
			Me.LabelFitModeComboBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.LabelFitModeComboBox.Location = New System.Drawing.Point(3, 124)
			Me.LabelFitModeComboBox.Name = "LabelFitModeComboBox"
			Me.LabelFitModeComboBox.Size = New System.Drawing.Size(173, 21)
			Me.LabelFitModeComboBox.TabIndex = 20
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LabelFitModeComboBox.SelectedIndexChanged += new System.EventHandler(this.LabelFitModeComboBox_SelectedIndexChanged);
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Controls.Add(Me.LabelFitModeComboBox)
			Me.nGroupBox2.Controls.Add(Me.label8)
			Me.nGroupBox2.Controls.Add(Me.LabelTickModeComboBox)
			Me.nGroupBox2.Controls.Add(Me.label1)
			Me.nGroupBox2.Controls.Add(Me.LabelVisibilityModeComboBox)
			Me.nGroupBox2.Controls.Add(Me.label3)
			Me.nGroupBox2.Dock = System.Windows.Forms.DockStyle.Top
			Me.nGroupBox2.ImageIndex = 0
			Me.nGroupBox2.Location = New System.Drawing.Point(0, 0)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(179, 152)
			Me.nGroupBox2.TabIndex = 24
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "Label Modes"
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.TextPaddingNumericUpDown)
			Me.nGroupBox1.Controls.Add(Me.label4)
			Me.nGroupBox1.Controls.Add(Me.TextOffsetNumericUpDown)
			Me.nGroupBox1.Controls.Add(Me.label5)
			Me.nGroupBox1.Controls.Add(Me.LabelAngleNumericUpDown)
			Me.nGroupBox1.Controls.Add(Me.label2)
			Me.nGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(0, 152)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(179, 152)
			Me.nGroupBox1.TabIndex = 25
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Label Text"
			' 
			' nGroupBox3
			' 
			Me.nGroupBox3.Controls.Add(Me.TickPaddingNumericUpDown)
			Me.nGroupBox3.Controls.Add(Me.label6)
			Me.nGroupBox3.Controls.Add(Me.TickOffsetNumericUpDown)
			Me.nGroupBox3.Controls.Add(Me.label7)
			Me.nGroupBox3.Dock = System.Windows.Forms.DockStyle.Top
			Me.nGroupBox3.ImageIndex = 0
			Me.nGroupBox3.Location = New System.Drawing.Point(0, 304)
			Me.nGroupBox3.Name = "nGroupBox3"
			Me.nGroupBox3.Size = New System.Drawing.Size(179, 115)
			Me.nGroupBox3.TabIndex = 26
			Me.nGroupBox3.TabStop = False
			Me.nGroupBox3.Text = "Label Ticks"
			' 
			' NCustomRangeLabelsUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.nGroupBox3)
			Me.Controls.Add(Me.nGroupBox1)
			Me.Controls.Add(Me.nGroupBox2)
			Me.Controls.Add(Me.SouthAmericaCheckBox)
			Me.Controls.Add(Me.AsiaCheckBox)
			Me.Controls.Add(Me.EuropeCheckBox)
			Me.Controls.Add(Me.NorthAmericaCheckBox)
			Me.Name = "NCustomRangeLabelsUC"
			Me.Size = New System.Drawing.Size(179, 666)
			DirectCast(Me.LabelAngleNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.TextPaddingNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.TextOffsetNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.TickPaddingNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.TickOffsetNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nGroupBox2.ResumeLayout(False)
			Me.nGroupBox1.ResumeLayout(False)
			Me.nGroupBox3.ResumeLayout(False)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As New NLabel("Company Sales by Region<br/><font size = '9pt'>Demonstrates how to use custom range labels to denote ranges on a scale</font>")
			header.DockMode = PanelDockMode.Top
			header.Margins = New NMarginsL(0, 10, 0, 10)
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			header.TextStyle.TextFormat = TextFormat.XML
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
			nChartControl1.Panels.Add(header)

			Dim legend As New NLegend()
			legend.Margins = New NMarginsL(10, 0, 10, 0)
			legend.DockMode = PanelDockMode.Right
			legend.FitAlignment = ContentAlignment.TopCenter
			nChartControl1.Panels.Add(legend)

			Dim chart As New NCartesianChart()
			nChartControl1.Panels.Add(chart)

			chart.DisplayOnLegend = legend
			chart.DockMode = PanelDockMode.Fill
			chart.BoundsMode = BoundsMode.Stretch
			chart.Margins = New NMarginsL(10, 0, 0, 10)
			chart.Axis(StandardAxis.Depth).Visible = False

			' add range selection
			Dim rangeSelection As New NRangeSelection()
			rangeSelection.VerticalValueSnapper = New NAxisRulerMinMaxSnapper()
			chart.RangeSelections.Add(rangeSelection)

			' add the first bar
			m_Bar1 = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar1.Name = "Coca Cola"
			m_Bar1.MultiBarMode = MultiBarMode.Series
			m_Bar1.DataLabelStyle.Format = "<value>"

			' add the second bar
			m_Bar2 = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar2.Name = "Pepsi"
			m_Bar2.MultiBarMode = MultiBarMode.Clustered
			m_Bar2.DataLabelStyle.Format = "<value>"

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' add custom labels to the X axis
			Dim xAxis As NAxis = chart.Axis(StandardAxis.PrimaryX)
			xAxis.ScrollBar.Visible = True
			Dim ordinalScale As NOrdinalScaleConfigurator = TryCast(xAxis.ScaleConfigurator, NOrdinalScaleConfigurator)

			ordinalScale.AutoLabels = False
			ordinalScale.OuterMajorTickStyle.Visible = False
			ordinalScale.InnerMajorTickStyle.Visible = False

			' add custom labels to the Y axis
			chart.Axis(StandardAxis.PrimaryY).View = New NRangeAxisView(New NRange1DD(0, 320))
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.RoundToTickMax = False
			Dim rangeLabel As New NCustomRangeLabel(New NRange1DD(240, 320), "Target Volume")
			rangeLabel.Style.TickMode = RangeLabelTickMode.Center
			rangeLabel.Style.WrapText = True
			rangeLabel.Style.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0)
			linearScale.CustomLabels.Add(rangeLabel)

			' add interlace stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' configure interactivity
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NAxisScrollTool())
			nChartControl1.Controller.Tools.Add(New NDataZoomTool())

			' init form controls
			LabelTickModeComboBox.FillFromEnum(GetType(RangeLabelTickMode))
			LabelVisibilityModeComboBox.FillFromEnum(GetType(ScaleLabelVisibilityMode))
			LabelFitModeComboBox.FillFromEnum(GetType(RangeLabelFitMode))

			Dim defaultStyle As New NRangeScaleLabelStyle()

			LabelTickModeComboBox.SelectedIndex = CInt(defaultStyle.TickMode)
			LabelVisibilityModeComboBox.SelectedIndex = CInt(defaultStyle.VisibilityMode)
			LabelFitModeComboBox.SelectedIndex = CInt(defaultStyle.FitMode)
			LabelAngleNumericUpDown.Value = CDec(defaultStyle.Angle.CustomAngle)
			TickPaddingNumericUpDown.Value = CDec(defaultStyle.TickPadding.Value)
			TickOffsetNumericUpDown.Value = CDec(defaultStyle.TickOffset.Value)
			TextOffsetNumericUpDown.Value = CDec(defaultStyle.Offset.Value)
			TextPaddingNumericUpDown.Value = CDec(defaultStyle.TextPadding.Value)

			' add some data
			NorthAmericaCheckBox.Checked = True
			EuropeCheckBox.Checked = True
			AsiaCheckBox.Checked = True
			SouthAmericaCheckBox.Checked = True
		End Sub

		Private Sub ChangeDataButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			' fill with random data
			m_Bar1.Values.FillRandomRange(Random, 6, 10, 200)
			m_Bar2.Values.FillRandomRange(Random, 6, 10, 300)
'			m_Bar2.Values[3] = 299.0;

			nChartControl1.Refresh()
		End Sub

		Private Sub UpdateRegions()
			m_Bar1.Values.Clear()
			m_Bar2.Values.Clear()

			' add custom labels to the X axis
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim ordinalScale As NOrdinalScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.Labels.Clear()
			ordinalScale.CustomLabels.Clear()

			If NorthAmericaCheckBox.Checked Then
				ordinalScale.Labels.Add("USA")
				ordinalScale.Labels.Add("Canada")
				ordinalScale.Labels.Add("Mexico")

				Dim rangeLabel As New NCustomRangeLabel()
				rangeLabel.Text = "Sales for North America"
				rangeLabel.Range = New NRange1DD(0, 2)
				ordinalScale.CustomLabels.Add(rangeLabel)

				m_Bar1.Values.Add(Random.Next(10, 300))
				m_Bar1.Values.Add(Random.Next(10, 300))
				m_Bar1.Values.Add(Random.Next(10, 300))

				m_Bar2.Values.Add(Random.Next(10, 300))
				m_Bar2.Values.Add(Random.Next(10, 300))
				m_Bar2.Values.Add(Random.Next(10, 300))
			End If

			If EuropeCheckBox.Checked Then
				ordinalScale.Labels.Add("Germany")
				ordinalScale.Labels.Add("UK")
				ordinalScale.Labels.Add("France")

				Dim rangeLabel As New NCustomRangeLabel()
				rangeLabel.Text = "Sales for Europe"
				rangeLabel.Range = New NRange1DD(m_Bar1.Values.Count, m_Bar1.Values.Count + 2)
				ordinalScale.CustomLabels.Add(rangeLabel)

				m_Bar1.Values.Add(Random.Next(10, 300))
				m_Bar1.Values.Add(Random.Next(10, 300))
				m_Bar1.Values.Add(Random.Next(10, 300))

				m_Bar2.Values.Add(Random.Next(10, 300))
				m_Bar2.Values.Add(Random.Next(10, 300))
				m_Bar2.Values.Add(Random.Next(10, 300))

			End If

			If AsiaCheckBox.Checked Then
				ordinalScale.Labels.Add("Japan")
				ordinalScale.Labels.Add("China")
				ordinalScale.Labels.Add("South Korea")

				Dim rangeLabel As New NCustomRangeLabel()
				rangeLabel.Text = "Sales for Asia"
				rangeLabel.Range = New NRange1DD(m_Bar1.Values.Count, m_Bar1.Values.Count + 2)
				ordinalScale.CustomLabels.Add(rangeLabel)

				m_Bar1.Values.Add(Random.Next(10, 300))
				m_Bar1.Values.Add(Random.Next(10, 300))
				m_Bar1.Values.Add(Random.Next(10, 300))

				m_Bar2.Values.Add(Random.Next(10, 300))
				m_Bar2.Values.Add(Random.Next(10, 300))
				m_Bar2.Values.Add(Random.Next(10, 300))
			End If

			If SouthAmericaCheckBox.Checked Then
				ordinalScale.Labels.Add("Brazil")
				ordinalScale.Labels.Add("Argentina")
				ordinalScale.Labels.Add("Venezuela")

				Dim rangeLabel As New NCustomRangeLabel()
				rangeLabel.Text = "Sales for South America"
				rangeLabel.Range = New NRange1DD(m_Bar1.Values.Count, m_Bar1.Values.Count + 2)
				ordinalScale.CustomLabels.Add(rangeLabel)

				m_Bar1.Values.Add(Random.Next(10, 300))
				m_Bar1.Values.Add(Random.Next(10, 300))
				m_Bar1.Values.Add(Random.Next(10, 300))

				m_Bar2.Values.Add(Random.Next(10, 300))
				m_Bar2.Values.Add(Random.Next(10, 300))
				m_Bar2.Values.Add(Random.Next(10, 300))
			End If

			UpdateLabels()
			nChartControl1.Refresh()
		End Sub

		Private Sub UpdateLabels()
			' add custom labels to the Y axis
			Dim chart As NChart = nChartControl1.Charts(0)
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NOrdinalScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)

			For i As Integer = 0 To scale_Renamed.CustomLabels.Count - 1
				Dim rangeLabel As NCustomRangeLabel = DirectCast(scale_Renamed.CustomLabels(i), NCustomRangeLabel)

				rangeLabel.Style.TickMode = CType(LabelTickModeComboBox.SelectedIndex, RangeLabelTickMode)
				rangeLabel.Style.VisibilityMode = CType(LabelVisibilityModeComboBox.SelectedIndex, ScaleLabelVisibilityMode)
				rangeLabel.Style.FitMode = FitModeFromIndex(LabelFitModeComboBox.SelectedIndex)
				rangeLabel.Style.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, CSng(LabelAngleNumericUpDown.Value))
				rangeLabel.Style.TickPadding = New NLength(CSng(TickPaddingNumericUpDown.Value), NGraphicsUnit.Point)
				rangeLabel.Style.TickOffset = New NLength(CSng(TickOffsetNumericUpDown.Value), NGraphicsUnit.Point)
				rangeLabel.Style.Offset = New NLength(CSng(TextOffsetNumericUpDown.Value), NGraphicsUnit.Point)
				rangeLabel.Style.TextPadding = New NLength(CSng(TextPaddingNumericUpDown.Value), NGraphicsUnit.Point)
			Next i

			nChartControl1.Refresh()
		End Sub

		Private Function FitModeFromIndex(ByVal index As Integer) As RangeLabelFitMode
			Select Case index
				Case 0 ' None
					Return RangeLabelFitMode.None
				Case 1 ' Wrap
					Return RangeLabelFitMode.Wrap
				Case 2 ' Clip
					Return RangeLabelFitMode.Clip
				Case 3
					Return RangeLabelFitMode.AutoFlip
				Case 4
					Return RangeLabelFitMode.AutoScale
			End Select

			Return RangeLabelFitMode.None
		End Function

		Private Sub NorthAmericaCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles NorthAmericaCheckBox.CheckedChanged
			UpdateRegions()
		End Sub

		Private Sub EuropeCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles EuropeCheckBox.CheckedChanged
			UpdateRegions()
		End Sub

		Private Sub AsiaCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AsiaCheckBox.CheckedChanged
			UpdateRegions()
		End Sub

		Private Sub SouthAmericaCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SouthAmericaCheckBox.CheckedChanged
			UpdateRegions()
		End Sub

		Private Sub LabelVisibilityModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LabelVisibilityModeComboBox.SelectedIndexChanged
			UpdateLabels()
		End Sub

		Private Sub LabelTickModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LabelTickModeComboBox.SelectedIndexChanged
			UpdateLabels()
		End Sub

		Private Sub WrapTextCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			UpdateLabels()
		End Sub

		Private Sub LabelAngleNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LabelAngleNumericUpDown.ValueChanged
			UpdateLabels()
		End Sub

		Private Sub TickOffsetNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TickOffsetNumericUpDown.ValueChanged
			UpdateLabels()
		End Sub

		Private Sub TextOffsetNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextOffsetNumericUpDown.ValueChanged
			UpdateLabels()
		End Sub

		Private Sub TickPaddingNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TickPaddingNumericUpDown.ValueChanged
			UpdateLabels()
		End Sub

		Private Sub TextPaddingNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextPaddingNumericUpDown.ValueChanged
			UpdateLabels()
		End Sub

		Private Sub LabelFitModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LabelFitModeComboBox.SelectedIndexChanged
			UpdateLabels()
		End Sub
	End Class
End Namespace