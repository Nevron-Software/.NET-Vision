Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.SmartShapes

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NLinearGaugeIndicatorsUC
		Inherits NExampleBaseUC

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label

		Private m_LinearGauge As NLinearGaugePanel
		Private m_Indicator2 As NMarkerValueIndicator
		Private label6 As System.Windows.Forms.Label
		Private WithEvents GaugeOrientationCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents RangeIndicatorValueUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents RangeIndicatorOriginUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents ValueIndicatorUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents RangeIndicatorOriginModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents ValueIndicatorShapeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label7 As System.Windows.Forms.Label
		Private label8 As System.Windows.Forms.Label
		Private WithEvents MarkerWidthUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents ShowMarkerEditorButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents MarkerHeightUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private m_Indicator1 As NRangeIndicator

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

		Public Shared Function FarenheitToCelsius(ByVal farenheit As Double) As Double
			Return (farenheit - 32.0) * 5.0 / 9.0
		End Function

		Public Shared Function CelsiusToFarenheit(ByVal celsius As Double) As Double
			Return (celsius * 9.0) / 5.0 + 32.0F
		End Function

		Public Overrides Sub Initialize()
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As New NLabel("Linear Gauge Indicators")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			nChartControl1.Panels.Add(header)

			' create a linear gauge
			m_LinearGauge = New NLinearGaugePanel()
			nChartControl1.Panels.Add(m_LinearGauge)
			m_LinearGauge.ContentAlignment = ContentAlignment.MiddleCenter
			m_LinearGauge.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(50, NRelativeUnit.ParentPercentage))
			m_LinearGauge.PaintEffect = New NGelEffectStyle()
			m_LinearGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.RoundedRect)
			m_LinearGauge.BackgroundFillStyle = New NGradientFillStyle(Color.Gray, Color.Black)

			m_LinearGauge.Axes.Clear()

			Dim celsiusRange As New NRange1DD(-40, 60)

			' add celsius and farenheit axes
			Dim celsiusAxis As New NGaugeAxis()
			celsiusAxis.Range = celsiusRange
			celsiusAxis.Anchor = New NModelGaugeAxisAnchor(New NLength(-5), VertAlign.Center, RulerOrientation.Left, 0, 100)
			m_LinearGauge.Axes.Add(celsiusAxis)

			Dim farenheitAxis As New NGaugeAxis()
			farenheitAxis.Range = New NRange1DD(CelsiusToFarenheit(celsiusRange.Begin), CelsiusToFarenheit(celsiusRange.End))
			farenheitAxis.Anchor = New NModelGaugeAxisAnchor(New NLength(5), VertAlign.Center, RulerOrientation.Right, 0, 100)
			m_LinearGauge.Axes.Add(farenheitAxis)

			' configure the scales
			Dim celsiusScale As NLinearScaleConfigurator = CType(celsiusAxis.ScaleConfigurator, NLinearScaleConfigurator)
			ConfigureScale(celsiusScale, "�C")
			celsiusScale.Sections.Add(CreateSection(Color.Red, Color.Red, New NRange1DD(40, 60)))
			celsiusScale.Sections.Add(CreateSection(Color.Blue, Color.SkyBlue, New NRange1DD(-40, -20)))

			Dim farenheitScale As NLinearScaleConfigurator = CType(farenheitAxis.ScaleConfigurator, NLinearScaleConfigurator)
			ConfigureScale(farenheitScale, "�F")

			farenheitScale.Sections.Add(CreateSection(Color.Red, Color.Red, New NRange1DD(CelsiusToFarenheit(40), CelsiusToFarenheit(60))))
			farenheitScale.Sections.Add(CreateSection(Color.Blue, Color.SkyBlue, New NRange1DD(CelsiusToFarenheit(-40), CelsiusToFarenheit(-20))))

			' now add two indicators
			m_Indicator1 = New NRangeIndicator()
			m_Indicator1.Value = 10
			m_Indicator1.StrokeStyle.Color = Color.DarkBlue
			m_Indicator1.FillStyle = New NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant1, Color.LightBlue, Color.Blue)
			m_LinearGauge.Indicators.Add(m_Indicator1)

			m_Indicator2 = New NMarkerValueIndicator()
			m_Indicator2.Value = 33
			m_Indicator2.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red)
			m_Indicator2.Shape.StrokeStyle.Color = Color.DarkRed
			m_LinearGauge.Indicators.Add(m_Indicator2)

			' init form controls
			RangeIndicatorValueUpDown.Value = CDec(m_Indicator1.Value)
			ValueIndicatorUpDown.Value = CDec(m_Indicator2.Value)

			RangeIndicatorOriginModeComboBox.FillFromEnum(GetType(OriginMode))
			RangeIndicatorOriginModeComboBox.SelectedIndex = 0

			ValueIndicatorShapeComboBox.FillFromEnum(GetType(SmartShape2D))
			ValueIndicatorShapeComboBox.SelectedIndex = CInt(SmartShape2D.Triangle)

			GaugeOrientationCombo.FillFromEnum(GetType(LinearGaugeOrientation))
			GaugeOrientationCombo.SelectedIndex = 0

			MarkerWidthUpDown.Value = CDec(m_Indicator2.Width.Value)
			MarkerHeightUpDown.Value = CDec(m_Indicator2.Height.Value)
		End Sub

		Private Function CreateSection(ByVal tickColor As Color, ByVal labelColor As Color, ByVal range As NRange1DD) As NScaleSectionStyle
			Dim scaleSection As New NScaleSectionStyle()
			scaleSection.Range = range
			scaleSection.LabelTextStyle = New NTextStyle(New NFontStyle(), tickColor)
			scaleSection.MajorTickFillStyle = New NColorFillStyle(tickColor)

			Dim labelStyle As New NTextStyle()
			labelStyle.FillStyle = New NColorFillStyle(labelColor)
			labelStyle.FontStyle = New NFontStyle("Arial", 12, FontStyle.Bold)
			scaleSection.LabelTextStyle = labelStyle

			Return scaleSection
		End Function

		Private Sub ConfigureScale(ByVal scale As NLinearScaleConfigurator, ByVal text As String)
			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke)
			scale.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 12, FontStyle.Bold)
			scale.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.White)
			scale.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 90)
			scale.MinorTickCount = 4
			scale.RulerStyle.BorderStyle.Width = New NLength(0)
			scale.RulerStyle.FillStyle = New NColorFillStyle(Color.FromArgb(40, Color.DarkGray))

			scale.Title.RulerAlignment = HorzAlign.Left
			scale.Title.Text = text
			scale.Title.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.View, 0)
			scale.Title.TextStyle.FontStyle.EmSize = New NLength(16)
			scale.Title.TextStyle.FontStyle.Style = FontStyle.Bold
			scale.Title.TextStyle.FillStyle = New NGradientFillStyle(Color.White, Color.LightBlue)
			scale.Title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			scale.RoundToTickMax = False
			scale.RoundToTickMin = False
		End Sub

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.ShowMarkerEditorButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.MarkerHeightUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label8 = New System.Windows.Forms.Label()
			Me.MarkerWidthUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label7 = New System.Windows.Forms.Label()
			Me.ValueIndicatorUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.ValueIndicatorShapeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.RangeIndicatorOriginModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.RangeIndicatorOriginUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.RangeIndicatorValueUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label6 = New System.Windows.Forms.Label()
			Me.GaugeOrientationCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.groupBox1.SuspendLayout()
			DirectCast(Me.MarkerHeightUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.MarkerWidthUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.ValueIndicatorUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox2.SuspendLayout()
			DirectCast(Me.RangeIndicatorOriginUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.RangeIndicatorValueUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.ShowMarkerEditorButton)
			Me.groupBox1.Controls.Add(Me.MarkerHeightUpDown)
			Me.groupBox1.Controls.Add(Me.label8)
			Me.groupBox1.Controls.Add(Me.MarkerWidthUpDown)
			Me.groupBox1.Controls.Add(Me.label7)
			Me.groupBox1.Controls.Add(Me.ValueIndicatorUpDown)
			Me.groupBox1.Controls.Add(Me.ValueIndicatorShapeComboBox)
			Me.groupBox1.Controls.Add(Me.label5)
			Me.groupBox1.Controls.Add(Me.label4)
			Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox1.ImageIndex = 0
			Me.groupBox1.Location = New System.Drawing.Point(0, 0)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(180, 208)
			Me.groupBox1.TabIndex = 0
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Value Indicator"
			' 
			' ShowMarkerEditorButton
			' 
			Me.ShowMarkerEditorButton.Location = New System.Drawing.Point(8, 96)
			Me.ShowMarkerEditorButton.Name = "ShowMarkerEditorButton"
			Me.ShowMarkerEditorButton.Size = New System.Drawing.Size(166, 23)
			Me.ShowMarkerEditorButton.TabIndex = 8
			Me.ShowMarkerEditorButton.Text = "Show Editor..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowMarkerEditorButton.Click += new System.EventHandler(this.ShowMarkerEditorButton_Click);
			' 
			' MarkerHeightUpDown
			' 
			Me.MarkerHeightUpDown.Location = New System.Drawing.Point(96, 176)
			Me.MarkerHeightUpDown.Maximum = New Decimal(New Integer() { 60, 0, 0, 0})
			Me.MarkerHeightUpDown.Minimum = New Decimal(New Integer() { 20, 0, 0, -2147483648})
			Me.MarkerHeightUpDown.Name = "MarkerHeightUpDown"
			Me.MarkerHeightUpDown.Size = New System.Drawing.Size(78, 20)
			Me.MarkerHeightUpDown.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MarkerHeightUpDown.ValueChanged += new System.EventHandler(this.MarkerHeightUpDown_ValueChanged);
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(8, 176)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(48, 23)
			Me.label8.TabIndex = 6
			Me.label8.Text = "Height: "
			Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' MarkerWidthUpDown
			' 
			Me.MarkerWidthUpDown.Location = New System.Drawing.Point(96, 144)
			Me.MarkerWidthUpDown.Maximum = New Decimal(New Integer() { 60, 0, 0, 0})
			Me.MarkerWidthUpDown.Minimum = New Decimal(New Integer() { 20, 0, 0, -2147483648})
			Me.MarkerWidthUpDown.Name = "MarkerWidthUpDown"
			Me.MarkerWidthUpDown.Size = New System.Drawing.Size(78, 20)
			Me.MarkerWidthUpDown.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MarkerWidthUpDown.ValueChanged += new System.EventHandler(this.MarkerWidthUpDown_ValueChanged);
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(8, 144)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(48, 23)
			Me.label7.TabIndex = 4
			Me.label7.Text = "Width: "
			Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' ValueIndicatorUpDown
			' 
			Me.ValueIndicatorUpDown.Location = New System.Drawing.Point(96, 32)
			Me.ValueIndicatorUpDown.Maximum = New Decimal(New Integer() { 60, 0, 0, 0})
			Me.ValueIndicatorUpDown.Minimum = New Decimal(New Integer() { 20, 0, 0, -2147483648})
			Me.ValueIndicatorUpDown.Name = "ValueIndicatorUpDown"
			Me.ValueIndicatorUpDown.Size = New System.Drawing.Size(78, 20)
			Me.ValueIndicatorUpDown.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ValueIndicatorUpDown.ValueChanged += new System.EventHandler(this.ValueIndicatorUpDown_ValueChanged);
			' 
			' ValueIndicatorShapeComboBox
			' 
			Me.ValueIndicatorShapeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.ValueIndicatorShapeComboBox.ListProperties.DataSource = Nothing
			Me.ValueIndicatorShapeComboBox.ListProperties.DisplayMember = ""
			Me.ValueIndicatorShapeComboBox.Location = New System.Drawing.Point(96, 64)
			Me.ValueIndicatorShapeComboBox.Name = "ValueIndicatorShapeComboBox"
			Me.ValueIndicatorShapeComboBox.Size = New System.Drawing.Size(78, 21)
			Me.ValueIndicatorShapeComboBox.TabIndex = 3
			Me.ValueIndicatorShapeComboBox.Text = "comboBox1"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ValueIndicatorShapeComboBox.SelectedIndexChanged += new System.EventHandler(this.ValueIndicatorShapeComboBox_SelectedIndexChanged);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(8, 62)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(48, 23)
			Me.label5.TabIndex = 2
			Me.label5.Text = "Shape:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 29)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(40, 23)
			Me.label4.TabIndex = 0
			Me.label4.Text = "Value:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.RangeIndicatorOriginModeComboBox)
			Me.groupBox2.Controls.Add(Me.RangeIndicatorOriginUpDown)
			Me.groupBox2.Controls.Add(Me.label3)
			Me.groupBox2.Controls.Add(Me.label2)
			Me.groupBox2.Controls.Add(Me.label1)
			Me.groupBox2.Controls.Add(Me.RangeIndicatorValueUpDown)
			Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox2.ImageIndex = 0
			Me.groupBox2.Location = New System.Drawing.Point(0, 208)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(180, 128)
			Me.groupBox2.TabIndex = 1
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Range Indicator"
			' 
			' RangeIndicatorOriginModeComboBox
			' 
			Me.RangeIndicatorOriginModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.RangeIndicatorOriginModeComboBox.ListProperties.DataSource = Nothing
			Me.RangeIndicatorOriginModeComboBox.ListProperties.DisplayMember = ""
			Me.RangeIndicatorOriginModeComboBox.Location = New System.Drawing.Point(95, 56)
			Me.RangeIndicatorOriginModeComboBox.Name = "RangeIndicatorOriginModeComboBox"
			Me.RangeIndicatorOriginModeComboBox.Size = New System.Drawing.Size(79, 21)
			Me.RangeIndicatorOriginModeComboBox.TabIndex = 3
			Me.RangeIndicatorOriginModeComboBox.Text = "RangeIndicatorOriginModeComboBox"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RangeIndicatorOriginModeComboBox.SelectedIndexChanged += new System.EventHandler(this.RangeIndicatorOriginModeComboBox_SelectedIndexChanged);
			' 
			' RangeIndicatorOriginUpDown
			' 
			Me.RangeIndicatorOriginUpDown.Location = New System.Drawing.Point(96, 96)
			Me.RangeIndicatorOriginUpDown.Maximum = New Decimal(New Integer() { 60, 0, 0, 0})
			Me.RangeIndicatorOriginUpDown.Minimum = New Decimal(New Integer() { 20, 0, 0, -2147483648})
			Me.RangeIndicatorOriginUpDown.Name = "RangeIndicatorOriginUpDown"
			Me.RangeIndicatorOriginUpDown.Size = New System.Drawing.Size(78, 20)
			Me.RangeIndicatorOriginUpDown.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RangeIndicatorOriginUpDown.ValueChanged += new System.EventHandler(this.RangeIndicatorOriginUpDown_ValueChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 100)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(40, 16)
			Me.label3.TabIndex = 4
			Me.label3.Text = "Origin:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 54)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(72, 23)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Origin Mode:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 20)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(40, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Value:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' RangeIndicatorValueUpDown
			' 
			Me.RangeIndicatorValueUpDown.Location = New System.Drawing.Point(96, 16)
			Me.RangeIndicatorValueUpDown.Maximum = New Decimal(New Integer() { 60, 0, 0, 0})
			Me.RangeIndicatorValueUpDown.Minimum = New Decimal(New Integer() { 20, 0, 0, -2147483648})
			Me.RangeIndicatorValueUpDown.Name = "RangeIndicatorValueUpDown"
			Me.RangeIndicatorValueUpDown.Size = New System.Drawing.Size(78, 20)
			Me.RangeIndicatorValueUpDown.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RangeIndicatorValueUpDown.ValueChanged += new System.EventHandler(this.RangeIndicatorValueUpDown_ValueChanged);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(8, 352)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(64, 23)
			Me.label6.TabIndex = 2
			Me.label6.Text = "Orientation:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' GaugeOrientationCombo
			' 
			Me.GaugeOrientationCombo.ListProperties.CheckBoxDataMember = ""
			Me.GaugeOrientationCombo.ListProperties.DataSource = Nothing
			Me.GaugeOrientationCombo.ListProperties.DisplayMember = ""
			Me.GaugeOrientationCombo.Location = New System.Drawing.Point(96, 352)
			Me.GaugeOrientationCombo.Name = "GaugeOrientationCombo"
			Me.GaugeOrientationCombo.Size = New System.Drawing.Size(79, 21)
			Me.GaugeOrientationCombo.TabIndex = 3
			Me.GaugeOrientationCombo.Text = "GaugeOrientationCombo"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GaugeOrientationCombo.SelectedIndexChanged += new System.EventHandler(this.GaugeOrientationCombo_SelectedIndexChanged);
			' 
			' NLinearGaugeIndicatorsUC
			' 
			Me.Controls.Add(Me.GaugeOrientationCombo)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Name = "NLinearGaugeIndicatorsUC"
			Me.Size = New System.Drawing.Size(180, 416)
			Me.groupBox1.ResumeLayout(False)
			DirectCast(Me.MarkerHeightUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.MarkerWidthUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.ValueIndicatorUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox2.ResumeLayout(False)
			DirectCast(Me.RangeIndicatorOriginUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.RangeIndicatorValueUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Private Sub RangeIndicatorOriginModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RangeIndicatorOriginModeComboBox.SelectedIndexChanged
			m_Indicator1.OriginMode = CType(RangeIndicatorOriginModeComboBox.SelectedIndex, OriginMode)
			If m_Indicator1.OriginMode <> OriginMode.Custom Then
				RangeIndicatorOriginUpDown.Enabled = False
			Else
				RangeIndicatorOriginUpDown.Enabled = True
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub GaugeOrientationCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GaugeOrientationCombo.SelectedIndexChanged
			m_LinearGauge.Orientation = CType(GaugeOrientationCombo.SelectedIndex, LinearGaugeOrientation)

			If m_LinearGauge.Orientation = LinearGaugeOrientation.Horizontal Then
				m_LinearGauge.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(130, NGraphicsUnit.Point))
				m_LinearGauge.Padding = New NMarginsL(20, 0, 10, 0)
			Else
				m_LinearGauge.Size = New NSizeL(New NLength(130, NGraphicsUnit.Point), New NLength(80, NRelativeUnit.ParentPercentage))
				m_LinearGauge.Padding = New NMarginsL(0, 10, 0, 20)
			End If
			nChartControl1.Refresh()
		End Sub

		Private Sub ValueIndicatorUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ValueIndicatorUpDown.ValueChanged
			m_Indicator2.Value = CDbl(ValueIndicatorUpDown.Value)
			nChartControl1.Refresh()
		End Sub

		Private Sub RangeIndicatorValueUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RangeIndicatorValueUpDown.ValueChanged
			m_Indicator1.Value = CDbl(RangeIndicatorValueUpDown.Value)
			nChartControl1.Refresh()
		End Sub

		Private Sub RangeIndicatorOriginUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RangeIndicatorOriginUpDown.ValueChanged
			m_Indicator1.Origin = CDbl(RangeIndicatorOriginUpDown.Value)
			nChartControl1.Refresh()
		End Sub

		Private Sub ValueIndicatorShapeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ValueIndicatorShapeComboBox.SelectedIndexChanged
			Dim factory As New N2DSmartShapeFactory(m_Indicator2.Shape.FillStyle, m_Indicator2.Shape.StrokeStyle, m_Indicator2.Shape.ShadowStyle)
			m_Indicator2.Shape = factory.CreateShape(CType(ValueIndicatorShapeComboBox.SelectedIndex, SmartShape2D))
			nChartControl1.Refresh()
		End Sub

		Private Sub ShowMarkerEditorButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowMarkerEditorButton.Click
			Dim editor2 As New NSmartShapeEditorUC()

			Dim cat As New NSmartShapesCategory("Marker Shapes")
			Dim factory As New N2DSmartShapeFactory(m_Indicator2.Shape.FillStyle, m_Indicator2.Shape.StrokeStyle, m_Indicator2.Shape.ShadowStyle)

			Dim shapes() As NSmartShape = factory.CreateShapes()

			For i As Integer = 0 To shapes.Length - 1
				cat.Add(shapes(i))
			Next i

			editor2.PredefinedShapes = New NSmartShapesCategory(){cat}
			editor2.Shape = DirectCast(DirectCast(m_Indicator2.Shape, ICloneable).Clone(), NSmartShape)

			If editor2.ShowInHostForm() = DialogResult.OK Then
				m_Indicator2.Shape = editor2.Shape
				nChartControl1.Refresh()
			End If

			editor2.Dispose()
		End Sub

		Private Sub MarkerWidthUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MarkerWidthUpDown.ValueChanged
			m_Indicator2.Width = New NLength(CSng(MarkerWidthUpDown.Value))
			nChartControl1.Refresh()
		End Sub

		Private Sub MarkerHeightUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MarkerHeightUpDown.ValueChanged
			m_Indicator2.Height = New NLength(CSng(MarkerHeightUpDown.Value))
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
