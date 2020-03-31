Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NGaugeGelAndGlassEffectsUC
		Inherits NExampleBaseUC

		Private WithEvents SweepAngleScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents BeginAngleScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private label4 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label

		Private m_RadialGauge As NRadialGaugePanel
		Private m_LinearGauge As NLinearGaugePanel
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label5 As Label
		Private WithEvents LinearGaugeOrientationComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents PaintEffectComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As Label
		Private label2 As Label
		Private GlassEffectGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private label6 As Label
		Private WithEvents SpreadUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents DirectionUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents PaintEffectShapeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label7 As Label
		Private GelEffectGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents LeftMarginUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label8 As Label
		Private WithEvents TopMarginUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label9 As Label
		Private WithEvents RightMarginUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label10 As Label
		Private WithEvents BottomMarginUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label11 As Label

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
			Me.SweepAngleScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.BeginAngleScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.LinearGaugeOrientationComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.PaintEffectComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.GlassEffectGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.SpreadUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.DirectionUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label6 = New System.Windows.Forms.Label()
			Me.PaintEffectShapeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label7 = New System.Windows.Forms.Label()
			Me.GelEffectGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.BottomMarginUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label11 = New System.Windows.Forms.Label()
			Me.RightMarginUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label10 = New System.Windows.Forms.Label()
			Me.TopMarginUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label9 = New System.Windows.Forms.Label()
			Me.LeftMarginUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label8 = New System.Windows.Forms.Label()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.GlassEffectGroupBox.SuspendLayout()
			DirectCast(Me.SpreadUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.DirectionUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.GelEffectGroupBox.SuspendLayout()
			DirectCast(Me.BottomMarginUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.RightMarginUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.TopMarginUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.LeftMarginUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' SweepAngleScrollBar
			' 
			Me.SweepAngleScrollBar.Location = New System.Drawing.Point(10, 83)
			Me.SweepAngleScrollBar.Maximum = 350
			Me.SweepAngleScrollBar.Minimum = -350
			Me.SweepAngleScrollBar.MinimumSize = New System.Drawing.Size(32, 16)
			Me.SweepAngleScrollBar.Name = "SweepAngleScrollBar"
			Me.SweepAngleScrollBar.Size = New System.Drawing.Size(147, 16)
			Me.SweepAngleScrollBar.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SweepAngleScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.SweepAngleScrollBar_ValueChanged);
			' 
			' BeginAngleScrollBar
			' 
			Me.BeginAngleScrollBar.Location = New System.Drawing.Point(10, 37)
			Me.BeginAngleScrollBar.Maximum = 360
			Me.BeginAngleScrollBar.Minimum = -360
			Me.BeginAngleScrollBar.MinimumSize = New System.Drawing.Size(32, 16)
			Me.BeginAngleScrollBar.Name = "BeginAngleScrollBar"
			Me.BeginAngleScrollBar.Size = New System.Drawing.Size(147, 16)
			Me.BeginAngleScrollBar.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BeginAngleScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BeginAngleScrollBar_ValueChanged);
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(10, 65)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(73, 13)
			Me.label4.TabIndex = 2
			Me.label4.Text = "Sweep Angle:"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(10, 19)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(67, 13)
			Me.label3.TabIndex = 0
			Me.label3.Text = "Begin Angle:"
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.BeginAngleScrollBar)
			Me.groupBox1.Controls.Add(Me.SweepAngleScrollBar)
			Me.groupBox1.Controls.Add(Me.label3)
			Me.groupBox1.Controls.Add(Me.label4)
			Me.groupBox1.Location = New System.Drawing.Point(9, 358)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(183, 113)
			Me.groupBox1.TabIndex = 6
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Radial Gauge"
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.LinearGaugeOrientationComboBox)
			Me.groupBox2.Controls.Add(Me.label5)
			Me.groupBox2.Location = New System.Drawing.Point(9, 477)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(183, 72)
			Me.groupBox2.TabIndex = 7
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Linear Gauge"
			' 
			' LinearGaugeOrientationComboBox
			' 
			Me.LinearGaugeOrientationComboBox.ListProperties.CheckBoxDataMember = ""
			Me.LinearGaugeOrientationComboBox.ListProperties.DataSource = Nothing
			Me.LinearGaugeOrientationComboBox.ListProperties.DisplayMember = ""
			Me.LinearGaugeOrientationComboBox.Location = New System.Drawing.Point(13, 38)
			Me.LinearGaugeOrientationComboBox.Name = "LinearGaugeOrientationComboBox"
			Me.LinearGaugeOrientationComboBox.Size = New System.Drawing.Size(144, 21)
			Me.LinearGaugeOrientationComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LinearGaugeOrientationComboBox.SelectedIndexChanged += new System.EventHandler(this.LinearGaugeOrientationComboBox_SelectedIndexChanged);
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Location = New System.Drawing.Point(10, 19)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(61, 13)
			Me.label5.TabIndex = 0
			Me.label5.Text = "Orientation:"
			' 
			' PaintEffectComboBox
			' 
			Me.PaintEffectComboBox.ListProperties.CheckBoxDataMember = ""
			Me.PaintEffectComboBox.ListProperties.DataSource = Nothing
			Me.PaintEffectComboBox.ListProperties.DisplayMember = ""
			Me.PaintEffectComboBox.Location = New System.Drawing.Point(9, 27)
			Me.PaintEffectComboBox.Name = "PaintEffectComboBox"
			Me.PaintEffectComboBox.Size = New System.Drawing.Size(157, 21)
			Me.PaintEffectComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PaintEffectComboBox.SelectedIndexChanged += new System.EventHandler(this.PaintEffectComboBox_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(9, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(65, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Paint Effect:"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(10, 23)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(78, 13)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Light Direction:"
			' 
			' GlassEffectGroupBox
			' 
			Me.GlassEffectGroupBox.Controls.Add(Me.SpreadUpDown)
			Me.GlassEffectGroupBox.Controls.Add(Me.DirectionUpDown)
			Me.GlassEffectGroupBox.Controls.Add(Me.label6)
			Me.GlassEffectGroupBox.Controls.Add(Me.label2)
			Me.GlassEffectGroupBox.Location = New System.Drawing.Point(9, 109)
			Me.GlassEffectGroupBox.Name = "GlassEffectGroupBox"
			Me.GlassEffectGroupBox.Size = New System.Drawing.Size(183, 82)
			Me.GlassEffectGroupBox.TabIndex = 4
			Me.GlassEffectGroupBox.TabStop = False
			Me.GlassEffectGroupBox.Text = "Glass Effect"
			' 
			' SpreadUpDown
			' 
			Me.SpreadUpDown.Location = New System.Drawing.Point(105, 42)
			Me.SpreadUpDown.Maximum = New Decimal(New Integer() { 180, 0, 0, 0})
			Me.SpreadUpDown.Name = "SpreadUpDown"
			Me.SpreadUpDown.Size = New System.Drawing.Size(52, 20)
			Me.SpreadUpDown.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SpreadUpDown.ValueChanged += new System.EventHandler(this.SpreadUpDown_ValueChanged);
			' 
			' DirectionUpDown
			' 
			Me.DirectionUpDown.Location = New System.Drawing.Point(105, 16)
			Me.DirectionUpDown.Maximum = New Decimal(New Integer() { 360, 0, 0, 0})
			Me.DirectionUpDown.Minimum = New Decimal(New Integer() { 360, 0, 0, -2147483648})
			Me.DirectionUpDown.Name = "DirectionUpDown"
			Me.DirectionUpDown.Size = New System.Drawing.Size(52, 20)
			Me.DirectionUpDown.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DirectionUpDown.ValueChanged += new System.EventHandler(this.DirectionUpDown_ValueChanged);
			' 
			' label6
			' 
			Me.label6.AutoSize = True
			Me.label6.Location = New System.Drawing.Point(10, 49)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(70, 13)
			Me.label6.TabIndex = 2
			Me.label6.Text = "Light Spread:"
			' 
			' PaintEffectShapeComboBox
			' 
			Me.PaintEffectShapeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.PaintEffectShapeComboBox.ListProperties.DataSource = Nothing
			Me.PaintEffectShapeComboBox.ListProperties.DisplayMember = ""
			Me.PaintEffectShapeComboBox.Location = New System.Drawing.Point(9, 73)
			Me.PaintEffectShapeComboBox.Name = "PaintEffectShapeComboBox"
			Me.PaintEffectShapeComboBox.Size = New System.Drawing.Size(157, 21)
			Me.PaintEffectShapeComboBox.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PaintEffectShapeComboBox.SelectedIndexChanged += new System.EventHandler(this.PaintEffectShapeComboBox_SelectedIndexChanged);
			' 
			' label7
			' 
			Me.label7.AutoSize = True
			Me.label7.Location = New System.Drawing.Point(9, 56)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(99, 13)
			Me.label7.TabIndex = 2
			Me.label7.Text = "Paint Effect Shape:"
			' 
			' GelEffectGroupBox
			' 
			Me.GelEffectGroupBox.Controls.Add(Me.BottomMarginUpDown)
			Me.GelEffectGroupBox.Controls.Add(Me.label11)
			Me.GelEffectGroupBox.Controls.Add(Me.RightMarginUpDown)
			Me.GelEffectGroupBox.Controls.Add(Me.label10)
			Me.GelEffectGroupBox.Controls.Add(Me.TopMarginUpDown)
			Me.GelEffectGroupBox.Controls.Add(Me.label9)
			Me.GelEffectGroupBox.Controls.Add(Me.LeftMarginUpDown)
			Me.GelEffectGroupBox.Controls.Add(Me.label8)
			Me.GelEffectGroupBox.Location = New System.Drawing.Point(9, 197)
			Me.GelEffectGroupBox.Name = "GelEffectGroupBox"
			Me.GelEffectGroupBox.Size = New System.Drawing.Size(183, 155)
			Me.GelEffectGroupBox.TabIndex = 5
			Me.GelEffectGroupBox.TabStop = False
			Me.GelEffectGroupBox.Text = "Gel Effect"
			' 
			' BottomMarginUpDown
			' 
			Me.BottomMarginUpDown.Location = New System.Drawing.Point(105, 97)
			Me.BottomMarginUpDown.Name = "BottomMarginUpDown"
			Me.BottomMarginUpDown.Size = New System.Drawing.Size(52, 20)
			Me.BottomMarginUpDown.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomMarginUpDown.ValueChanged += new System.EventHandler(this.BottomMarginUpDown_ValueChanged);
			' 
			' label11
			' 
			Me.label11.AutoSize = True
			Me.label11.Location = New System.Drawing.Point(10, 104)
			Me.label11.Name = "label11"
			Me.label11.Size = New System.Drawing.Size(78, 13)
			Me.label11.TabIndex = 6
			Me.label11.Text = "Bottom Margin:"
			' 
			' RightMarginUpDown
			' 
			Me.RightMarginUpDown.Location = New System.Drawing.Point(105, 71)
			Me.RightMarginUpDown.Name = "RightMarginUpDown"
			Me.RightMarginUpDown.Size = New System.Drawing.Size(52, 20)
			Me.RightMarginUpDown.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RightMarginUpDown.ValueChanged += new System.EventHandler(this.RightMarginUpDown_ValueChanged);
			' 
			' label10
			' 
			Me.label10.AutoSize = True
			Me.label10.Location = New System.Drawing.Point(10, 78)
			Me.label10.Name = "label10"
			Me.label10.Size = New System.Drawing.Size(70, 13)
			Me.label10.TabIndex = 4
			Me.label10.Text = "Right Margin:"
			' 
			' TopMarginUpDown
			' 
			Me.TopMarginUpDown.Location = New System.Drawing.Point(105, 45)
			Me.TopMarginUpDown.Name = "TopMarginUpDown"
			Me.TopMarginUpDown.Size = New System.Drawing.Size(52, 20)
			Me.TopMarginUpDown.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TopMarginUpDown.ValueChanged += new System.EventHandler(this.TopMarginUpDown_ValueChanged);
			' 
			' label9
			' 
			Me.label9.AutoSize = True
			Me.label9.Location = New System.Drawing.Point(10, 52)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(64, 13)
			Me.label9.TabIndex = 2
			Me.label9.Text = "Top Margin:"
			' 
			' LeftMarginUpDown
			' 
			Me.LeftMarginUpDown.Location = New System.Drawing.Point(105, 19)
			Me.LeftMarginUpDown.Name = "LeftMarginUpDown"
			Me.LeftMarginUpDown.Size = New System.Drawing.Size(52, 20)
			Me.LeftMarginUpDown.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftMarginUpDown.ValueChanged += new System.EventHandler(this.LeftMarginUpDown_ValueChanged);
			' 
			' label8
			' 
			Me.label8.AutoSize = True
			Me.label8.Location = New System.Drawing.Point(10, 26)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(63, 13)
			Me.label8.TabIndex = 0
			Me.label8.Text = "Left Margin:"
			' 
			' NGaugeGelAndGlassEffectsUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.GelEffectGroupBox)
			Me.Controls.Add(Me.GlassEffectGroupBox)
			Me.Controls.Add(Me.PaintEffectShapeComboBox)
			Me.Controls.Add(Me.PaintEffectComboBox)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Name = "NGaugeGelAndGlassEffectsUC"
			Me.Size = New System.Drawing.Size(180, 554)
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox1.PerformLayout()
			Me.groupBox2.ResumeLayout(False)
			Me.groupBox2.PerformLayout()
			Me.GlassEffectGroupBox.ResumeLayout(False)
			Me.GlassEffectGroupBox.PerformLayout()
			DirectCast(Me.SpreadUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.DirectionUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.GelEffectGroupBox.ResumeLayout(False)
			Me.GelEffectGroupBox.PerformLayout()
			DirectCast(Me.BottomMarginUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.RightMarginUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.TopMarginUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.LeftMarginUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Gauge Glass and Gel Effects")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' create the radial gauge
			CreateRadialGauge()

			' create the linear gauge
			CreateLinearGauge()

			' update form controls
			PaintEffectComboBox.Items.Add("None")
			PaintEffectComboBox.Items.Add("Gel")
			PaintEffectComboBox.Items.Add("Glass")
			PaintEffectComboBox.SelectedIndex = 1 ' gel

			PaintEffectShapeComboBox.Items.Add("Region")
			PaintEffectShapeComboBox.Items.Add("Rectangle")
			PaintEffectShapeComboBox.Items.Add("Ellipse")
			PaintEffectShapeComboBox.Items.Add("RoundedRect")
			PaintEffectShapeComboBox.SelectedIndex = 2 ' ellipse

			BeginAngleScrollBar.Value = CInt(Math.Truncate(m_RadialGauge.BeginAngle))
			SweepAngleScrollBar.Value = CInt(Math.Truncate(m_RadialGauge.SweepAngle))

			DirectionUpDown.Value = 45
			SpreadUpDown.Value = 60

			LeftMarginUpDown.Value = 3
			TopMarginUpDown.Value = 3
			RightMarginUpDown.Value = 3
			BottomMarginUpDown.Value = 80

			LinearGaugeOrientationComboBox.Items.Add("Horizontal")
			LinearGaugeOrientationComboBox.Items.Add("Vertical")
			LinearGaugeOrientationComboBox.SelectedIndex = 1
		End Sub

		Private Sub ApplyScaleSectionToAxis(ByVal scale As NLinearScaleConfigurator)
			Dim scaleSection As New NScaleSectionStyle()

			scaleSection.Range = New NRange1DD(70, 100)
			scaleSection.LabelTextStyle = New NTextStyle()
			scaleSection.LabelTextStyle.FillStyle = New NColorFillStyle(KnownArgbColorValue.DarkRed)
			scaleSection.LabelTextStyle.FontStyle = New NFontStyle("Arial", 12, FontStyle.Bold)
			scaleSection.MajorTickStrokeStyle = New NStrokeStyle(Color.DarkRed)

			scale.Sections.Add(scaleSection)
		End Sub

		Private Sub CreateLinearGauge()
			m_LinearGauge = New NLinearGaugePanel()
			nChartControl1.Panels.Add(m_LinearGauge)

			' create the background panel
			m_LinearGauge.BackgroundFillStyle = New NColorFillStyle(Color.Black)
			m_LinearGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.RoundedRect)

			Dim axis As NGaugeAxis = DirectCast(m_LinearGauge.Axes(0), NGaugeAxis)
			axis.Anchor = New NModelGaugeAxisAnchor(New NLength(10, NGraphicsUnit.Point), VertAlign.Center, RulerOrientation.Left)
			ConfigureScale(CType(axis.ScaleConfigurator, NLinearScaleConfigurator))

			' add some indicators
			AddRangeIndicatorToGauge(m_LinearGauge)
			m_LinearGauge.Indicators.Add(New NMarkerValueIndicator(60))
		End Sub

		Private Sub UpdateEffects()
			If m_LinearGauge Is Nothing OrElse m_RadialGauge Is Nothing Then
				Return
			End If

			Dim paintEffect As NPaintEffectStyle = Nothing

			Select Case PaintEffectComboBox.SelectedIndex
				Case 0 ' None
					GlassEffectGroupBox.Enabled = False
					GelEffectGroupBox.Enabled = False
					PaintEffectShapeComboBox.Enabled = False

				Case 1 ' Gel
					GlassEffectGroupBox.Enabled = False
					GelEffectGroupBox.Enabled = True
					PaintEffectShapeComboBox.Enabled = True

					Dim gelEffect As New NGelEffectStyle()
					gelEffect.Shape = CType(PaintEffectShapeComboBox.SelectedIndex, PaintEffectShape)
					gelEffect.Margins = New NMarginsL(CSng(LeftMarginUpDown.Value), CSng(TopMarginUpDown.Value), CSng(RightMarginUpDown.Value), CSng(BottomMarginUpDown.Value))

					paintEffect = gelEffect
				Case 2 ' Glass
					GlassEffectGroupBox.Enabled = True
					GelEffectGroupBox.Enabled = False
					PaintEffectShapeComboBox.Enabled = True

					Dim glassEffect As New NGlassEffectStyle()
					glassEffect.Shape = CType(PaintEffectShapeComboBox.SelectedIndex, PaintEffectShape)
					glassEffect.LightSpread = CSng(SpreadUpDown.Value)
					glassEffect.LightDirection = CSng(DirectionUpDown.Value)
					glassEffect.LightColor = Color.FromArgb(200, Color.White)
					glassEffect.DarkColor = Color.FromArgb(200, Color.Gray)

					paintEffect = glassEffect
			End Select

			If paintEffect Is Nothing Then
				m_LinearGauge.PaintEffect = Nothing
				m_RadialGauge.PaintEffect = Nothing
			Else
				m_LinearGauge.PaintEffect = paintEffect
				m_RadialGauge.PaintEffect = DirectCast(paintEffect.Clone(), NPaintEffectStyle)
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub CreateRadialGauge()
			' create the radial gauge
			m_RadialGauge = New NRadialGaugePanel()
			nChartControl1.Panels.Add(m_RadialGauge)

			' create the radial gauge
			m_RadialGauge.SweepAngle = 270
			m_RadialGauge.BeginAngle = -90

			' set some background
			m_RadialGauge.BackgroundFillStyle = New NColorFillStyle(Color.Black)
			m_RadialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)

			' configure the axis
			Dim axis As NGaugeAxis = DirectCast(m_RadialGauge.Axes(0), NGaugeAxis)
			axis.Range = New NRange1DD(0, 100)
			axis.Anchor.RulerOrientation = RulerOrientation.Right
			axis.Anchor = New NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, True, RulerOrientation.Right, 0, 100)

			ConfigureScale(CType(axis.ScaleConfigurator, NLinearScaleConfigurator))

			' add some indicators
			AddRangeIndicatorToGauge(m_RadialGauge)

			Dim needle As New NNeedleValueIndicator(60)
			needle.OffsetFromScale = New NLength(15)
			m_RadialGauge.Indicators.Add(needle)
		End Sub

		Private Sub AddRangeIndicatorToGauge(ByVal gauge As NGaugePanel)
			' add some indicators
			Dim rangeIndicator As New NRangeIndicator(New NRange1DD(75, 100))
			rangeIndicator.FillStyle = New NColorFillStyle(Color.Red)
			rangeIndicator.StrokeStyle.Width = New NLength(0)
			rangeIndicator.OffsetFromScale = New NLength(11)
			rangeIndicator.BeginWidth = New NLength(5)
			rangeIndicator.EndWidth = New NLength(10)
			rangeIndicator.OffsetFromScale = New NLength(15)
			rangeIndicator.PaintOrder = IndicatorPaintOrder.BeforeScale

			gauge.Indicators.Add(rangeIndicator)
		End Sub

		Private Sub ConfigureScale(ByVal scale As NLinearScaleConfigurator)
			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke)
			scale.LabelFitModes = New LabelFitMode(){}
			scale.MinorTickCount = 3
			scale.RulerStyle.FillStyle = New NColorFillStyle(Color.FromArgb(40, Color.White))
			scale.OuterMajorTickStyle.FillStyle = New NColorFillStyle(Color.Orange)
			scale.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 12, FontStyle.Bold)
			scale.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.White)
		End Sub

		Private Sub BeginAngleScrollBar_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles BeginAngleScrollBar.ValueChanged
			m_RadialGauge.BeginAngle = BeginAngleScrollBar.Value
			nChartControl1.Refresh()
		End Sub

		Private Sub SweepAngleScrollBar_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles SweepAngleScrollBar.ValueChanged
			m_RadialGauge.SweepAngle = SweepAngleScrollBar.Value
			nChartControl1.Refresh()
		End Sub

		Private Sub LinearGaugeOrientationComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LinearGaugeOrientationComboBox.SelectedIndexChanged
			m_LinearGauge.Orientation = CType(LinearGaugeOrientationComboBox.SelectedIndex, LinearGaugeOrientation)

			If m_LinearGauge.Orientation = LinearGaugeOrientation.Horizontal Then
				m_RadialGauge.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
				m_RadialGauge.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(55, NRelativeUnit.ParentPercentage))
				m_RadialGauge.ContentAlignment = ContentAlignment.BottomCenter

				m_LinearGauge.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage))
				m_LinearGauge.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(80, NGraphicsUnit.Point))
				m_LinearGauge.Padding = New NMarginsL(13, 0, 13, 0)
			Else
				m_RadialGauge.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
				m_RadialGauge.Size = New NSizeL(New NLength(45, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))
				m_RadialGauge.ContentAlignment = ContentAlignment.BottomRight

				m_LinearGauge.Location = New NPointL(New NLength(60, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
				m_LinearGauge.Size = New NSizeL(New NLength(80, NGraphicsUnit.Point), New NLength(80, NRelativeUnit.ParentPercentage))
				m_LinearGauge.Padding = New NMarginsL(0, 13, 0, 13)
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub PaintEffectComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles PaintEffectComboBox.SelectedIndexChanged
			UpdateEffects()
		End Sub

		Private Sub PaintEffectShapeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles PaintEffectShapeComboBox.SelectedIndexChanged
			UpdateEffects()
		End Sub

		Private Sub DirectionUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DirectionUpDown.ValueChanged
			UpdateEffects()
		End Sub

		Private Sub SpreadUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SpreadUpDown.ValueChanged
			UpdateEffects()
		End Sub

		Private Sub LeftMarginUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LeftMarginUpDown.ValueChanged
			UpdateEffects()
		End Sub

		Private Sub TopMarginUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TopMarginUpDown.ValueChanged
			UpdateEffects()
		End Sub

		Private Sub RightMarginUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RightMarginUpDown.ValueChanged
			UpdateEffects()
		End Sub

		Private Sub BottomMarginUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BottomMarginUpDown.ValueChanged
			UpdateEffects()
		End Sub
	End Class
End Namespace
