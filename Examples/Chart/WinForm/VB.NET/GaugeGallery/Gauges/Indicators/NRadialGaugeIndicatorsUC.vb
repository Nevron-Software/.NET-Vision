Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Editors
Imports Nevron.SmartShapes
Imports Nevron.GraphicsCore
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NRadialGaugeIndicatorsUC
		Inherits NExampleBaseUC

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents RangeIndicatorOriginModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents RangeIndicatorOriginUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label3 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label1 As System.Windows.Forms.Label
		Private WithEvents RangeIndicatorValueUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents ValueIndicatorUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label5 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private WithEvents ValueIndicatorShapeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label6 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private WithEvents BeginAngleUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents SweepAngleUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown

		Private m_RadialGauge As NRadialGaugePanel
		Private m_Indicator1 As NRangeIndicator
		Private m_Indicator2 As NNeedleValueIndicator
		Private label8 As System.Windows.Forms.Label
		Private WithEvents ShowNeedleEditorButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents NeedleWidthUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private m_NumericDisplay As NNumericDisplayPanel

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
			Dim header As New NLabel("Radial Gauge Indicators")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			nChartControl1.Panels.Add(header)

			' create the radial gauge
			m_RadialGauge = New NRadialGaugePanel()
			m_RadialGauge.PaintEffect = New NGlassEffectStyle()
			m_RadialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)
			m_RadialGauge.ContentAlignment = ContentAlignment.MiddleCenter
			m_RadialGauge.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(55, NRelativeUnit.ParentPercentage))
			m_RadialGauge.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))
			m_RadialGauge.BackgroundFillStyle = New NGradientFillStyle(Color.DarkGray, Color.Black)

			' configure scale
			Dim axis As NGaugeAxis = DirectCast(m_RadialGauge.Axes(0), NGaugeAxis)
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)

			scale_Renamed.SetPredefinedScaleStyle(PredefinedScaleStyle.Presentation)
			scale_Renamed.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 12, FontStyle.Bold)
			scale_Renamed.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.White)
			scale_Renamed.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 90)
			scale_Renamed.MinorTickCount = 4
			scale_Renamed.RulerStyle.BorderStyle.Width = New NLength(0)
			scale_Renamed.RulerStyle.FillStyle = New NColorFillStyle(Color.DarkGray)

			' add radial gauge indicators
			m_Indicator1 = New NRangeIndicator()
			m_Indicator1.Value = 20
			m_Indicator1.FillStyle = New NGradientFillStyle(GradientStyle.StartToEnd, GradientVariant.Variant1, Color.Yellow, Color.Red)
			m_Indicator1.StrokeStyle.Color = Color.DarkBlue
			m_Indicator1.EndWidth = New NLength(20)
			m_RadialGauge.Indicators.Add(m_Indicator1)

			m_Indicator2 = New NNeedleValueIndicator()
			m_Indicator2.Value = 79
			m_Indicator2.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red)
			m_Indicator2.Shape.StrokeStyle.Color = Color.Red
			m_RadialGauge.Indicators.Add(m_Indicator2)
			m_RadialGauge.SweepAngle = 270

			' add radial gauge
			nChartControl1.Panels.Add(m_RadialGauge)

			' create and configure a numeric display attached to the radial gauge
			m_NumericDisplay = New NNumericDisplayPanel()
			m_NumericDisplay.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage))
			m_NumericDisplay.ContentAlignment = ContentAlignment.TopCenter
			m_NumericDisplay.SegmentWidth = New NLength(2, NGraphicsUnit.Point)
			m_NumericDisplay.SegmentGap = New NLength(1, NGraphicsUnit.Point)
			m_NumericDisplay.CellSize = New NSizeL(New NLength(15, NGraphicsUnit.Point), New NLength(30, NGraphicsUnit.Point))
			m_NumericDisplay.DecimalCellSize = New NSizeL(New NLength(10, NGraphicsUnit.Point), New NLength(20, NGraphicsUnit.Point))
			m_NumericDisplay.ShowDecimalSeparator = False
			m_NumericDisplay.CellAlignment = VertAlign.Top
			m_NumericDisplay.BackgroundFillStyle = New NColorFillStyle(Color.DimGray)
			m_NumericDisplay.LitFillStyle = New NGradientFillStyle(Color.Lime, Color.Green)
			m_NumericDisplay.CellCountMode = DisplayCellCountMode.Fixed
			m_NumericDisplay.CellCount = 6
			m_NumericDisplay.Padding = New NMarginsL(6, 3, 6, 3)
			m_RadialGauge.ChildPanels.Add(m_NumericDisplay)

			' create a sunken border around the display
'INSTANT VB NOTE: The variable borderStyle was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim borderStyle_Renamed As New NEdgeBorderStyle(BorderShape.RoundedRect)
			borderStyle_Renamed.OuterBevelWidth = New NLength(0)
			borderStyle_Renamed.MiddleBevelWidth = New NLength(0)
			m_NumericDisplay.BorderStyle = borderStyle_Renamed

			' init form controls
			SweepAngleUpDown.Value = CDec(m_RadialGauge.SweepAngle)
			BeginAngleUpDown.Value = CDec(m_RadialGauge.BeginAngle)

			ValueIndicatorShapeComboBox.FillFromEnum(GetType(SmartShape1D))
			ValueIndicatorShapeComboBox.SelectedIndex = CInt(SmartShape1D.Arrow2)

			ValueIndicatorUpDown.Value = CDec(m_Indicator2.Value)
			RangeIndicatorValueUpDown.Value = CDec(m_Indicator1.Value)

			RangeIndicatorOriginModeComboBox.FillFromEnum(GetType(OriginMode))
			RangeIndicatorOriginModeComboBox.SelectedIndex = 0

			NeedleWidthUpDown.Value = CDec(m_Indicator2.Width.Value)
		End Sub

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.RangeIndicatorOriginModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.RangeIndicatorOriginUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.RangeIndicatorValueUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.ShowNeedleEditorButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.NeedleWidthUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label8 = New System.Windows.Forms.Label()
			Me.ValueIndicatorUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.ValueIndicatorShapeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.label7 = New System.Windows.Forms.Label()
			Me.BeginAngleUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.SweepAngleUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.groupBox2.SuspendLayout()
			DirectCast(Me.RangeIndicatorOriginUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.RangeIndicatorValueUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox1.SuspendLayout()
			DirectCast(Me.NeedleWidthUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.ValueIndicatorUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.BeginAngleUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.SweepAngleUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
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
			Me.groupBox2.Location = New System.Drawing.Point(0, 168)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(180, 144)
			Me.groupBox2.TabIndex = 5
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
			Me.RangeIndicatorOriginModeComboBox.Size = New System.Drawing.Size(76, 21)
			Me.RangeIndicatorOriginModeComboBox.TabIndex = 3
			Me.RangeIndicatorOriginModeComboBox.Text = "RangeIndicatorOriginModeComboBox"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RangeIndicatorOriginModeComboBox.SelectedIndexChanged += new System.EventHandler(this.RangeIndicatorOriginModeComboBox_SelectedIndexChanged);
			' 
			' RangeIndicatorOriginUpDown
			' 
			Me.RangeIndicatorOriginUpDown.Location = New System.Drawing.Point(96, 96)
			Me.RangeIndicatorOriginUpDown.Name = "RangeIndicatorOriginUpDown"
			Me.RangeIndicatorOriginUpDown.Size = New System.Drawing.Size(75, 20)
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
			Me.RangeIndicatorValueUpDown.Name = "RangeIndicatorValueUpDown"
			Me.RangeIndicatorValueUpDown.Size = New System.Drawing.Size(75, 20)
			Me.RangeIndicatorValueUpDown.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RangeIndicatorValueUpDown.ValueChanged += new System.EventHandler(this.RangeIndicatorValueUpDown_ValueChanged);
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.ShowNeedleEditorButton)
			Me.groupBox1.Controls.Add(Me.NeedleWidthUpDown)
			Me.groupBox1.Controls.Add(Me.label8)
			Me.groupBox1.Controls.Add(Me.ValueIndicatorUpDown)
			Me.groupBox1.Controls.Add(Me.ValueIndicatorShapeComboBox)
			Me.groupBox1.Controls.Add(Me.label5)
			Me.groupBox1.Controls.Add(Me.label4)
			Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox1.ImageIndex = 0
			Me.groupBox1.Location = New System.Drawing.Point(0, 0)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(180, 168)
			Me.groupBox1.TabIndex = 4
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Value Indicator"
			' 
			' ShowNeedleEditorButton
			' 
			Me.ShowNeedleEditorButton.Location = New System.Drawing.Point(12, 96)
			Me.ShowNeedleEditorButton.Name = "ShowNeedleEditorButton"
			Me.ShowNeedleEditorButton.Size = New System.Drawing.Size(159, 23)
			Me.ShowNeedleEditorButton.TabIndex = 11
			Me.ShowNeedleEditorButton.Text = "Show Editor..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowNeedleEditorButton.Click += new System.EventHandler(this.ShowNeedleEditorButton_Click);
			' 
			' NeedleWidthUpDown
			' 
			Me.NeedleWidthUpDown.Location = New System.Drawing.Point(100, 128)
			Me.NeedleWidthUpDown.Maximum = New Decimal(New Integer() { 60, 0, 0, 0})
			Me.NeedleWidthUpDown.Minimum = New Decimal(New Integer() { 20, 0, 0, -2147483648})
			Me.NeedleWidthUpDown.Name = "NeedleWidthUpDown"
			Me.NeedleWidthUpDown.Size = New System.Drawing.Size(75, 20)
			Me.NeedleWidthUpDown.TabIndex = 10
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.NeedleWidthUpDown.ValueChanged += new System.EventHandler(this.NeedleWidthUpDown_ValueChanged);
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(12, 128)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(48, 23)
			Me.label8.TabIndex = 9
			Me.label8.Text = "Width: "
			Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' ValueIndicatorUpDown
			' 
			Me.ValueIndicatorUpDown.Location = New System.Drawing.Point(96, 32)
			Me.ValueIndicatorUpDown.Name = "ValueIndicatorUpDown"
			Me.ValueIndicatorUpDown.Size = New System.Drawing.Size(75, 20)
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
			Me.ValueIndicatorShapeComboBox.Size = New System.Drawing.Size(75, 21)
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
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(8, 328)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(80, 23)
			Me.label6.TabIndex = 6
			Me.label6.Text = "Begin Angle:"
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(8, 360)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(80, 23)
			Me.label7.TabIndex = 7
			Me.label7.Text = "Sweep Angle:"
			' 
			' BeginAngleUpDown
			' 
			Me.BeginAngleUpDown.Location = New System.Drawing.Point(96, 328)
			Me.BeginAngleUpDown.Maximum = New Decimal(New Integer() { 360, 0, 0, 0})
			Me.BeginAngleUpDown.Minimum = New Decimal(New Integer() { 360, 0, 0, -2147483648})
			Me.BeginAngleUpDown.Name = "BeginAngleUpDown"
			Me.BeginAngleUpDown.Size = New System.Drawing.Size(75, 20)
			Me.BeginAngleUpDown.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BeginAngleUpDown.ValueChanged += new System.EventHandler(this.BeginAngleUpDown_ValueChanged);
			' 
			' SweepAngleUpDown
			' 
			Me.SweepAngleUpDown.Location = New System.Drawing.Point(96, 360)
			Me.SweepAngleUpDown.Maximum = New Decimal(New Integer() { 360, 0, 0, 0})
			Me.SweepAngleUpDown.Minimum = New Decimal(New Integer() { 360, 0, 0, -2147483648})
			Me.SweepAngleUpDown.Name = "SweepAngleUpDown"
			Me.SweepAngleUpDown.Size = New System.Drawing.Size(75, 20)
			Me.SweepAngleUpDown.TabIndex = 9
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SweepAngleUpDown.ValueChanged += new System.EventHandler(this.SweepAngleUpDown_ValueChanged);
			' 
			' NRadialGaugeIndicatorsUC
			' 
			Me.Controls.Add(Me.SweepAngleUpDown)
			Me.Controls.Add(Me.BeginAngleUpDown)
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Name = "NRadialGaugeIndicatorsUC"
			Me.Size = New System.Drawing.Size(180, 408)
			Me.groupBox2.ResumeLayout(False)
			DirectCast(Me.RangeIndicatorOriginUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.RangeIndicatorValueUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox1.ResumeLayout(False)
			DirectCast(Me.NeedleWidthUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.ValueIndicatorUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.BeginAngleUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.SweepAngleUpDown, System.ComponentModel.ISupportInitialize).EndInit()
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

		Private Sub ValueIndicatorUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ValueIndicatorUpDown.ValueChanged
			m_Indicator2.Value = CDbl(ValueIndicatorUpDown.Value)
			m_NumericDisplay.Value = m_Indicator2.Value
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

		Private Sub BeginAngleUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BeginAngleUpDown.ValueChanged
			m_RadialGauge.BeginAngle = CSng(BeginAngleUpDown.Value)
			nChartControl1.Refresh()
		End Sub

		Private Sub SweepAngleUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SweepAngleUpDown.ValueChanged
			m_RadialGauge.SweepAngle = CSng(SweepAngleUpDown.Value)
			nChartControl1.Refresh()
		End Sub

		Private Sub ValueIndicatorShapeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ValueIndicatorShapeComboBox.SelectedIndexChanged
			Dim factory As New N1DSmartShapeFactory(m_Indicator2.Shape.FillStyle, m_Indicator2.Shape.StrokeStyle, m_Indicator2.Shape.ShadowStyle)
			m_Indicator2.Shape = factory.CreateShape(CType(ValueIndicatorShapeComboBox.SelectedIndex, SmartShape1D))
			nChartControl1.Refresh()
		End Sub

		Private Sub ShowNeedleEditorButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowNeedleEditorButton.Click
			Dim editor2 As New NSmartShapeEditorUC()

			Dim cat As New NSmartShapesCategory("Needle Shapes")
			Dim factory As New N1DSmartShapeFactory(m_Indicator2.Shape.FillStyle, m_Indicator2.Shape.StrokeStyle, m_Indicator2.Shape.ShadowStyle)

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

		Private Sub NeedleWidthUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NeedleWidthUpDown.ValueChanged
			m_Indicator2.Width = New NLength(CSng(NeedleWidthUpDown.Value))
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
