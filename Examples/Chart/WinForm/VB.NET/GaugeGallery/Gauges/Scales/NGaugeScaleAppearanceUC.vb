Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NGaugeScaleAppearanceUC
		Inherits NExampleBaseUC

		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox3 As Nevron.UI.WinForm.Controls.NGroupBox
		Private panel1 As System.Windows.Forms.Panel
		Private label1 As System.Windows.Forms.Label
		Private WithEvents PredefinedScaleStyleComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents RulerFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private WithEvents RulerStrokeStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents MajorTicksFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents MajorTicksStrokeStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents MinorTicksFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents MinorTicksStrokeStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private label6 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private label8 As System.Windows.Forms.Label
		Private label9 As System.Windows.Forms.Label
		Private WithEvents RulerLengthUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents RulerOffsetUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents MajorTicksOffsetUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents MajorTickLengthUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents MajorTickWidthUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents MinorTickOffsetUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents MinorTickWidthUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents MinorTickLengthUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label10 As System.Windows.Forms.Label
		Private WithEvents MajorTickShapeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents MinorTickShapeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label11 As System.Windows.Forms.Label
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Private m_Axis As NGaugeAxis
		Private m_Updating As Boolean

		Public Sub New()
			' This call is required by the Windows.Forms Form Designer.
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

		Public Overrides Sub Initialize()
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As New NLabel("Gauge Axis Scale Appearance")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			nChartControl1.Panels.Add(header)

			' create the radial gauge
			Dim radialGauge As New NRadialGaugePanel()

			radialGauge.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			radialGauge.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))
			radialGauge.BackgroundFillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Gray)
			radialGauge.PaintEffect = New NGlassEffectStyle()
			radialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)
			radialGauge.PositionChildPanelsInContentBounds = True

			nChartControl1.Panels.Add(radialGauge)

			m_Axis = DirectCast(radialGauge.Axes(0), NGaugeAxis)
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NStandardScaleConfigurator = CType(m_Axis.ScaleConfigurator, NStandardScaleConfigurator)
			scale_Renamed.MinorTickCount = 3

			Dim indicator1 As New NRangeIndicator()
			indicator1.Value = 80
			indicator1.OriginMode = OriginMode.ScaleMax
			indicator1.FillStyle = New NColorFillStyle(Color.Red)
			indicator1.StrokeStyle.Color = Color.DarkRed
			radialGauge.Indicators.Add(indicator1)

			Dim indicator2 As New NNeedleValueIndicator()
			indicator2.Value = 79
			indicator2.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red)
			indicator2.Shape.StrokeStyle.Color = Color.Red
			radialGauge.Indicators.Add(indicator2)
			radialGauge.SweepAngle = 270

			m_Updating = True

			MinorTickShapeComboBox.FillFromEnum(GetType(ScaleTickShape))
			MajorTickShapeComboBox.FillFromEnum(GetType(ScaleTickShape))
			PredefinedScaleStyleComboBox.FillFromEnum(GetType(PredefinedScaleStyle))
			PredefinedScaleStyleComboBox.SelectedIndex = CInt(PredefinedScaleStyle.Standard)

			m_Updating = False

			InitFormControls()
		End Sub

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.RulerLengthUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.RulerOffsetUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.RulerStrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.RulerFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.MajorTickShapeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label10 = New System.Windows.Forms.Label()
			Me.MajorTickWidthUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label8 = New System.Windows.Forms.Label()
			Me.MajorTickLengthUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.MajorTicksOffsetUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.MajorTicksStrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.MajorTicksFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.groupBox3 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.MinorTickShapeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label11 = New System.Windows.Forms.Label()
			Me.MinorTickWidthUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.MinorTickOffsetUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.MinorTicksStrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.MinorTicksFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label6 = New System.Windows.Forms.Label()
			Me.label7 = New System.Windows.Forms.Label()
			Me.label9 = New System.Windows.Forms.Label()
			Me.MinorTickLengthUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.PredefinedScaleStyleComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.groupBox1.SuspendLayout()
			DirectCast(Me.RulerLengthUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.RulerOffsetUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox2.SuspendLayout()
			DirectCast(Me.MajorTickWidthUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.MajorTickLengthUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.MajorTicksOffsetUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox3.SuspendLayout()
			DirectCast(Me.MinorTickWidthUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.MinorTickOffsetUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.MinorTickLengthUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.panel1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.RulerLengthUpDown)
			Me.groupBox1.Controls.Add(Me.RulerOffsetUpDown)
			Me.groupBox1.Controls.Add(Me.RulerStrokeStyleButton)
			Me.groupBox1.Controls.Add(Me.label3)
			Me.groupBox1.Controls.Add(Me.label2)
			Me.groupBox1.Controls.Add(Me.RulerFillStyleButton)
			Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox1.ImageIndex = 0
			Me.groupBox1.Location = New System.Drawing.Point(0, 64)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(180, 144)
			Me.groupBox1.TabIndex = 1
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Ruler"
			' 
			' RulerLengthUpDown
			' 
			Me.RulerLengthUpDown.Location = New System.Drawing.Point(92, 112)
			Me.RulerLengthUpDown.Minimum = New Decimal(New Integer() { 100, 0, 0, -2147483648})
			Me.RulerLengthUpDown.Name = "RulerLengthUpDown"
			Me.RulerLengthUpDown.Size = New System.Drawing.Size(78, 20)
			Me.RulerLengthUpDown.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RulerLengthUpDown.ValueChanged += new System.EventHandler(this.RulerLengthUpDown_ValueChanged);
			' 
			' RulerOffsetUpDown
			' 
			Me.RulerOffsetUpDown.Location = New System.Drawing.Point(92, 88)
			Me.RulerOffsetUpDown.Minimum = New Decimal(New Integer() { 100, 0, 0, -2147483648})
			Me.RulerOffsetUpDown.Name = "RulerOffsetUpDown"
			Me.RulerOffsetUpDown.Size = New System.Drawing.Size(78, 20)
			Me.RulerOffsetUpDown.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RulerOffsetUpDown.ValueChanged += new System.EventHandler(this.RulerOffsetUpDown_ValueChanged);
			' 
			' RulerStrokeStyleButton
			' 
			Me.RulerStrokeStyleButton.Location = New System.Drawing.Point(12, 56)
			Me.RulerStrokeStyleButton.Name = "RulerStrokeStyleButton"
			Me.RulerStrokeStyleButton.Size = New System.Drawing.Size(158, 23)
			Me.RulerStrokeStyleButton.TabIndex = 1
			Me.RulerStrokeStyleButton.Text = "Stroke Style"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RulerStrokeStyleButton.Click += new System.EventHandler(this.RulerStrokeStyleButton_Click);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(12, 112)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(46, 23)
			Me.label3.TabIndex = 4
			Me.label3.Text = "Length:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(12, 88)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(46, 23)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Offset:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' RulerFillStyleButton
			' 
			Me.RulerFillStyleButton.Location = New System.Drawing.Point(12, 24)
			Me.RulerFillStyleButton.Name = "RulerFillStyleButton"
			Me.RulerFillStyleButton.Size = New System.Drawing.Size(158, 23)
			Me.RulerFillStyleButton.TabIndex = 0
			Me.RulerFillStyleButton.Text = "Fill Style"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RulerFillStyleButton.Click += new System.EventHandler(this.RulerFillStyleButton_Click);
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.MajorTickShapeComboBox)
			Me.groupBox2.Controls.Add(Me.label10)
			Me.groupBox2.Controls.Add(Me.MajorTickWidthUpDown)
			Me.groupBox2.Controls.Add(Me.label8)
			Me.groupBox2.Controls.Add(Me.MajorTickLengthUpDown)
			Me.groupBox2.Controls.Add(Me.MajorTicksOffsetUpDown)
			Me.groupBox2.Controls.Add(Me.label5)
			Me.groupBox2.Controls.Add(Me.label4)
			Me.groupBox2.Controls.Add(Me.MajorTicksStrokeStyleButton)
			Me.groupBox2.Controls.Add(Me.MajorTicksFillStyleButton)
			Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox2.ImageIndex = 0
			Me.groupBox2.Location = New System.Drawing.Point(0, 208)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(180, 216)
			Me.groupBox2.TabIndex = 2
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Major Ticks"
			' 
			' MajorTickShapeComboBox
			' 
			Me.MajorTickShapeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.MajorTickShapeComboBox.ListProperties.DataSource = Nothing
			Me.MajorTickShapeComboBox.ListProperties.DisplayMember = ""
			Me.MajorTickShapeComboBox.Location = New System.Drawing.Point(72, 24)
			Me.MajorTickShapeComboBox.Name = "MajorTickShapeComboBox"
			Me.MajorTickShapeComboBox.Size = New System.Drawing.Size(98, 21)
			Me.MajorTickShapeComboBox.TabIndex = 1
			Me.MajorTickShapeComboBox.Text = "comboBox1"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MajorTickShapeComboBox.SelectedIndexChanged += new System.EventHandler(this.MajorTickShapeComboBox_SelectedIndexChanged);
			' 
			' label10
			' 
			Me.label10.Location = New System.Drawing.Point(16, 24)
			Me.label10.Name = "label10"
			Me.label10.Size = New System.Drawing.Size(48, 23)
			Me.label10.TabIndex = 0
			Me.label10.Text = "Shape:"
			Me.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' MajorTickWidthUpDown
			' 
			Me.MajorTickWidthUpDown.Location = New System.Drawing.Point(92, 184)
			Me.MajorTickWidthUpDown.Minimum = New Decimal(New Integer() { 100, 0, 0, -2147483648})
			Me.MajorTickWidthUpDown.Name = "MajorTickWidthUpDown"
			Me.MajorTickWidthUpDown.Size = New System.Drawing.Size(78, 20)
			Me.MajorTickWidthUpDown.TabIndex = 9
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MajorTickWidthUpDown.ValueChanged += new System.EventHandler(this.MajorTickWidthUpDown_ValueChanged);
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(12, 176)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(37, 23)
			Me.label8.TabIndex = 8
			Me.label8.Text = "Width:"
			Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' MajorTickLengthUpDown
			' 
			Me.MajorTickLengthUpDown.Location = New System.Drawing.Point(92, 152)
			Me.MajorTickLengthUpDown.Minimum = New Decimal(New Integer() { 100, 0, 0, -2147483648})
			Me.MajorTickLengthUpDown.Name = "MajorTickLengthUpDown"
			Me.MajorTickLengthUpDown.Size = New System.Drawing.Size(78, 20)
			Me.MajorTickLengthUpDown.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MajorTickLengthUpDown.ValueChanged += new System.EventHandler(this.MajorTickLengthUpDown_ValueChanged);
			' 
			' MajorTicksOffsetUpDown
			' 
			Me.MajorTicksOffsetUpDown.Location = New System.Drawing.Point(92, 120)
			Me.MajorTicksOffsetUpDown.Minimum = New Decimal(New Integer() { 100, 0, 0, -2147483648})
			Me.MajorTicksOffsetUpDown.Name = "MajorTicksOffsetUpDown"
			Me.MajorTicksOffsetUpDown.Size = New System.Drawing.Size(78, 20)
			Me.MajorTicksOffsetUpDown.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MajorTicksOffsetUpDown.ValueChanged += new System.EventHandler(this.MajorTicksOffsetUpDown_ValueChanged);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(12, 120)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(37, 23)
			Me.label5.TabIndex = 4
			Me.label5.Text = "Offset:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(12, 144)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(37, 23)
			Me.label4.TabIndex = 6
			Me.label4.Text = "Length:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' MajorTicksStrokeStyleButton
			' 
			Me.MajorTicksStrokeStyleButton.Location = New System.Drawing.Point(12, 88)
			Me.MajorTicksStrokeStyleButton.Name = "MajorTicksStrokeStyleButton"
			Me.MajorTicksStrokeStyleButton.Size = New System.Drawing.Size(158, 23)
			Me.MajorTicksStrokeStyleButton.TabIndex = 3
			Me.MajorTicksStrokeStyleButton.Text = "Stroke Style"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MajorTicksStrokeStyleButton.Click += new System.EventHandler(this.MajorTicksStrokeStyleButton_Click);
			' 
			' MajorTicksFillStyleButton
			' 
			Me.MajorTicksFillStyleButton.Location = New System.Drawing.Point(12, 56)
			Me.MajorTicksFillStyleButton.Name = "MajorTicksFillStyleButton"
			Me.MajorTicksFillStyleButton.Size = New System.Drawing.Size(158, 23)
			Me.MajorTicksFillStyleButton.TabIndex = 2
			Me.MajorTicksFillStyleButton.Text = "Fill Style"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MajorTicksFillStyleButton.Click += new System.EventHandler(this.MajorTicksFillStyleButton_Click);
			' 
			' groupBox3
			' 
			Me.groupBox3.Controls.Add(Me.MinorTickShapeComboBox)
			Me.groupBox3.Controls.Add(Me.label11)
			Me.groupBox3.Controls.Add(Me.MinorTickWidthUpDown)
			Me.groupBox3.Controls.Add(Me.MinorTickOffsetUpDown)
			Me.groupBox3.Controls.Add(Me.MinorTicksStrokeStyleButton)
			Me.groupBox3.Controls.Add(Me.MinorTicksFillStyleButton)
			Me.groupBox3.Controls.Add(Me.label6)
			Me.groupBox3.Controls.Add(Me.label7)
			Me.groupBox3.Controls.Add(Me.label9)
			Me.groupBox3.Controls.Add(Me.MinorTickLengthUpDown)
			Me.groupBox3.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox3.ImageIndex = 0
			Me.groupBox3.Location = New System.Drawing.Point(0, 424)
			Me.groupBox3.Name = "groupBox3"
			Me.groupBox3.Size = New System.Drawing.Size(180, 216)
			Me.groupBox3.TabIndex = 3
			Me.groupBox3.TabStop = False
			Me.groupBox3.Text = "Minor Ticks"
			' 
			' MinorTickShapeComboBox
			' 
			Me.MinorTickShapeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.MinorTickShapeComboBox.ListProperties.DataSource = Nothing
			Me.MinorTickShapeComboBox.ListProperties.DisplayMember = ""
			Me.MinorTickShapeComboBox.Location = New System.Drawing.Point(72, 24)
			Me.MinorTickShapeComboBox.Name = "MinorTickShapeComboBox"
			Me.MinorTickShapeComboBox.Size = New System.Drawing.Size(98, 21)
			Me.MinorTickShapeComboBox.TabIndex = 1
			Me.MinorTickShapeComboBox.Text = "comboBox1"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MinorTickShapeComboBox.SelectedIndexChanged += new System.EventHandler(this.MinorTickShapeComboBox_SelectedIndexChanged);
			' 
			' label11
			' 
			Me.label11.Location = New System.Drawing.Point(16, 24)
			Me.label11.Name = "label11"
			Me.label11.Size = New System.Drawing.Size(48, 23)
			Me.label11.TabIndex = 0
			Me.label11.Text = "Shape:"
			Me.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' MinorTickWidthUpDown
			' 
			Me.MinorTickWidthUpDown.Location = New System.Drawing.Point(92, 152)
			Me.MinorTickWidthUpDown.Minimum = New Decimal(New Integer() { 100, 0, 0, -2147483648})
			Me.MinorTickWidthUpDown.Name = "MinorTickWidthUpDown"
			Me.MinorTickWidthUpDown.Size = New System.Drawing.Size(78, 20)
			Me.MinorTickWidthUpDown.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MinorTickWidthUpDown.ValueChanged += new System.EventHandler(this.MinorTickWidthUpDown_ValueChanged);
			' 
			' MinorTickOffsetUpDown
			' 
			Me.MinorTickOffsetUpDown.Location = New System.Drawing.Point(92, 120)
			Me.MinorTickOffsetUpDown.Minimum = New Decimal(New Integer() { 100, 0, 0, -2147483648})
			Me.MinorTickOffsetUpDown.Name = "MinorTickOffsetUpDown"
			Me.MinorTickOffsetUpDown.Size = New System.Drawing.Size(78, 20)
			Me.MinorTickOffsetUpDown.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MinorTickOffsetUpDown.ValueChanged += new System.EventHandler(this.MinorTickOffsetUpDown_ValueChanged);
			' 
			' MinorTicksStrokeStyleButton
			' 
			Me.MinorTicksStrokeStyleButton.Location = New System.Drawing.Point(12, 88)
			Me.MinorTicksStrokeStyleButton.Name = "MinorTicksStrokeStyleButton"
			Me.MinorTicksStrokeStyleButton.Size = New System.Drawing.Size(158, 23)
			Me.MinorTicksStrokeStyleButton.TabIndex = 3
			Me.MinorTicksStrokeStyleButton.Text = "Stroke Style"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MinorTicksStrokeStyleButton.Click += new System.EventHandler(this.MinorTicksStrokeStyleButton_Click);
			' 
			' MinorTicksFillStyleButton
			' 
			Me.MinorTicksFillStyleButton.Location = New System.Drawing.Point(12, 56)
			Me.MinorTicksFillStyleButton.Name = "MinorTicksFillStyleButton"
			Me.MinorTicksFillStyleButton.Size = New System.Drawing.Size(158, 23)
			Me.MinorTicksFillStyleButton.TabIndex = 2
			Me.MinorTicksFillStyleButton.Text = "Fill Style"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MinorTicksFillStyleButton.Click += new System.EventHandler(this.MinorTicksFillStyleButton_Click);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(12, 184)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(56, 23)
			Me.label6.TabIndex = 8
			Me.label6.Text = "Length:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(12, 120)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(56, 23)
			Me.label7.TabIndex = 4
			Me.label7.Text = "Offset:"
			Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label9
			' 
			Me.label9.Location = New System.Drawing.Point(12, 152)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(56, 23)
			Me.label9.TabIndex = 6
			Me.label9.Text = "Width:"
			Me.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' MinorTickLengthUpDown
			' 
			Me.MinorTickLengthUpDown.Location = New System.Drawing.Point(92, 184)
			Me.MinorTickLengthUpDown.Minimum = New Decimal(New Integer() { 100, 0, 0, -2147483648})
			Me.MinorTickLengthUpDown.Name = "MinorTickLengthUpDown"
			Me.MinorTickLengthUpDown.Size = New System.Drawing.Size(78, 20)
			Me.MinorTickLengthUpDown.TabIndex = 9
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MinorTickLengthUpDown.ValueChanged += new System.EventHandler(this.MinorTickLengthUpDown_ValueChanged);
			' 
			' panel1
			' 
			Me.panel1.Controls.Add(Me.PredefinedScaleStyleComboBox)
			Me.panel1.Controls.Add(Me.label1)
			Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
			Me.panel1.Location = New System.Drawing.Point(0, 0)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(180, 64)
			Me.panel1.TabIndex = 0
			' 
			' PredefinedScaleStyleComboBox
			' 
			Me.PredefinedScaleStyleComboBox.ListProperties.CheckBoxDataMember = ""
			Me.PredefinedScaleStyleComboBox.ListProperties.DataSource = Nothing
			Me.PredefinedScaleStyleComboBox.ListProperties.DisplayMember = ""
			Me.PredefinedScaleStyleComboBox.Location = New System.Drawing.Point(8, 32)
			Me.PredefinedScaleStyleComboBox.Name = "PredefinedScaleStyleComboBox"
			Me.PredefinedScaleStyleComboBox.Size = New System.Drawing.Size(162, 21)
			Me.PredefinedScaleStyleComboBox.TabIndex = 1
			Me.PredefinedScaleStyleComboBox.Text = "comboBox1"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PredefinedScaleStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.PredefinedScaleStyleComboBox_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(176, 23)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Load Predefined Scale Style:"
			' 
			' NGaugeScaleAppearanceUC
			' 
			Me.Controls.Add(Me.groupBox3)
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.panel1)
			Me.Name = "NGaugeScaleAppearanceUC"
			Me.Size = New System.Drawing.Size(180, 648)
			Me.groupBox1.ResumeLayout(False)
			DirectCast(Me.RulerLengthUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.RulerOffsetUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox2.ResumeLayout(False)
			DirectCast(Me.MajorTickWidthUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.MajorTickLengthUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.MajorTicksOffsetUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox3.ResumeLayout(False)
			DirectCast(Me.MinorTickWidthUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.MinorTickOffsetUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.MinorTickLengthUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.panel1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Private Sub InitFormControls()
			If m_Updating Then
				Return
			End If

			m_Updating = True

'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NStandardScaleConfigurator = CType(m_Axis.ScaleConfigurator, NStandardScaleConfigurator)
			RulerLengthUpDown.Value = CDec(scale_Renamed.RulerStyle.Height.Value)
			RulerOffsetUpDown.Value = CDec(scale_Renamed.RulerStyle.Offset.Value)

			MajorTicksOffsetUpDown.Value = CDec(scale_Renamed.OuterMajorTickStyle.Offset.Value)
			MajorTickLengthUpDown.Value = CDec(scale_Renamed.OuterMajorTickStyle.Length.Value)
			MajorTickWidthUpDown.Value = CDec(scale_Renamed.OuterMajorTickStyle.Width.Value)
			MajorTickShapeComboBox.SelectedIndex = CInt(scale_Renamed.OuterMajorTickStyle.Shape)

			MinorTickOffsetUpDown.Value = CDec(scale_Renamed.OuterMinorTickStyle.Offset.Value)
			MinorTickWidthUpDown.Value = CDec(scale_Renamed.OuterMinorTickStyle.Width.Value)
			MinorTickLengthUpDown.Value = CDec(scale_Renamed.OuterMinorTickStyle.Length.Value)
			MinorTickShapeComboBox.SelectedIndex = CInt(scale_Renamed.OuterMinorTickStyle.Shape)

			m_Updating = False
		End Sub

		Private Sub UpdateScale()
			If m_Updating Then
				Return
			End If

			m_Updating = True

'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NStandardScaleConfigurator = CType(m_Axis.ScaleConfigurator, NStandardScaleConfigurator)
			scale_Renamed.RulerStyle.Height = New NLength(CSng(RulerLengthUpDown.Value))
			scale_Renamed.RulerStyle.Offset = New NLength(CSng(RulerOffsetUpDown.Value))

			scale_Renamed.OuterMajorTickStyle.Offset = New NLength(CSng(MajorTicksOffsetUpDown.Value))
			scale_Renamed.OuterMajorTickStyle.Length = New NLength(CSng(MajorTickLengthUpDown.Value))
			scale_Renamed.OuterMajorTickStyle.Width = New NLength(CSng(MajorTickWidthUpDown.Value))
			scale_Renamed.OuterMajorTickStyle.Shape = CType(MajorTickShapeComboBox.SelectedIndex, ScaleTickShape)

			scale_Renamed.OuterMinorTickStyle.Offset = New NLength(CSng(MinorTickOffsetUpDown.Value))
			scale_Renamed.OuterMinorTickStyle.Width= New NLength(CSng(MinorTickWidthUpDown.Value))
			scale_Renamed.OuterMinorTickStyle.Length = New NLength(CSng(MinorTickLengthUpDown.Value))
			scale_Renamed.OuterMinorTickStyle.Shape = CType(MinorTickShapeComboBox.SelectedIndex, ScaleTickShape)

			m_Updating = False

			nChartControl1.Refresh()
		End Sub

		Private Sub PredefinedScaleStyleComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PredefinedScaleStyleComboBox.SelectedIndexChanged
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NStandardScaleConfigurator = CType(m_Axis.ScaleConfigurator, NStandardScaleConfigurator)
			scale_Renamed.SetPredefinedScaleStyle(CType(PredefinedScaleStyleComboBox.SelectedIndex, PredefinedScaleStyle))
			InitFormControls()

			nChartControl1.Refresh()
		End Sub

		Private Sub RulerFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RulerFillStyleButton.Click
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NStandardScaleConfigurator = CType(m_Axis.ScaleConfigurator, NStandardScaleConfigurator)
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(scale_Renamed.RulerStyle.FillStyle, fillStyleResult) Then
				scale_Renamed.RulerStyle.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub RulerStrokeStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RulerStrokeStyleButton.Click
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NStandardScaleConfigurator = CType(m_Axis.ScaleConfigurator, NStandardScaleConfigurator)
			Dim stokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(scale_Renamed.RulerStyle.BorderStyle, stokeStyleResult) Then
				scale_Renamed.RulerStyle.BorderStyle = stokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub MajorTicksFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MajorTicksFillStyleButton.Click
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NStandardScaleConfigurator = CType(m_Axis.ScaleConfigurator, NStandardScaleConfigurator)
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(scale_Renamed.OuterMajorTickStyle.FillStyle, fillStyleResult) Then
				scale_Renamed.OuterMajorTickStyle.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub MajorTicksStrokeStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MajorTicksStrokeStyleButton.Click
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NStandardScaleConfigurator = CType(m_Axis.ScaleConfigurator, NStandardScaleConfigurator)
			Dim stokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(scale_Renamed.OuterMajorTickStyle.LineStyle, stokeStyleResult) Then
				scale_Renamed.OuterMajorTickStyle.LineStyle = stokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub MinorTicksFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MinorTicksFillStyleButton.Click
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NStandardScaleConfigurator = CType(m_Axis.ScaleConfigurator, NStandardScaleConfigurator)
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(scale_Renamed.OuterMinorTickStyle.FillStyle, fillStyleResult) Then
				scale_Renamed.OuterMinorTickStyle.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub MinorTicksStrokeStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MinorTicksStrokeStyleButton.Click
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NStandardScaleConfigurator = CType(m_Axis.ScaleConfigurator, NStandardScaleConfigurator)
			Dim stokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(scale_Renamed.OuterMinorTickStyle.LineStyle, stokeStyleResult) Then
				scale_Renamed.OuterMinorTickStyle.LineStyle = stokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub RulerOffsetUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RulerOffsetUpDown.ValueChanged
			UpdateScale()
		End Sub

		Private Sub RulerLengthUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RulerLengthUpDown.ValueChanged
			UpdateScale()
		End Sub

		Private Sub MajorTickShapeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MajorTickShapeComboBox.SelectedIndexChanged
			UpdateScale()
		End Sub

		Private Sub MajorTicksOffsetUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MajorTicksOffsetUpDown.ValueChanged
			UpdateScale()
		End Sub

		Private Sub MajorTickLengthUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MajorTickLengthUpDown.ValueChanged
			UpdateScale()
		End Sub

		Private Sub MajorTickWidthUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MajorTickWidthUpDown.ValueChanged
			UpdateScale()
		End Sub

		Private Sub MinorTickShapeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MinorTickShapeComboBox.SelectedIndexChanged
			UpdateScale()
		End Sub

		Private Sub MinorTickOffsetUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MinorTickOffsetUpDown.ValueChanged
			UpdateScale()
		End Sub

		Private Sub MinorTickWidthUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MinorTickWidthUpDown.ValueChanged
			UpdateScale()
		End Sub

		Private Sub MinorTickLengthUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MinorTickLengthUpDown.ValueChanged
			UpdateScale()
		End Sub
	End Class
End Namespace
