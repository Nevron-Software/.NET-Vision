Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NGaugeScaleLabelsOrientationUC
		Inherits NExampleBaseUC

		Private label1 As System.Windows.Forms.Label
		Private WithEvents AngleModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label2 As System.Windows.Forms.Label
		Private WithEvents CustomAngleNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents AllowTextFlipCheckBox As Nevron.UI.WinForm.Controls.NCheckBox

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
			Me.label1 = New System.Windows.Forms.Label()
			Me.AngleModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.CustomAngleNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.AllowTextFlipCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SweepAngleScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.BeginAngleScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.LinearGaugeOrientationComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label5 = New System.Windows.Forms.Label()
			DirectCast(Me.CustomAngleNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(11, 10)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(67, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Angle Mode:"
			' 
			' AngleModeComboBox
			' 
			Me.AngleModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.AngleModeComboBox.ListProperties.DataSource = Nothing
			Me.AngleModeComboBox.ListProperties.DisplayMember = ""
			Me.AngleModeComboBox.Location = New System.Drawing.Point(11, 26)
			Me.AngleModeComboBox.Name = "AngleModeComboBox"
			Me.AngleModeComboBox.Size = New System.Drawing.Size(155, 21)
			Me.AngleModeComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AngleModeComboBox.SelectedIndexChanged += new System.EventHandler(this.AngleModeComboBox_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(11, 54)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(75, 13)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Custom Angle:"
			' 
			' CustomAngleNumericUpDown
			' 
			Me.CustomAngleNumericUpDown.Increment = New Decimal(New Integer() { 10, 0, 0, 0})
			Me.CustomAngleNumericUpDown.Location = New System.Drawing.Point(11, 71)
			Me.CustomAngleNumericUpDown.Maximum = New Decimal(New Integer() { 360, 0, 0, 0})
			Me.CustomAngleNumericUpDown.Name = "CustomAngleNumericUpDown"
			Me.CustomAngleNumericUpDown.Size = New System.Drawing.Size(155, 20)
			Me.CustomAngleNumericUpDown.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.CustomAngleNumericUpDown.ValueChanged += new System.EventHandler(this.CustomAngleNumericUpDown_ValueChanged);
			' 
			' AllowTextFlipCheckBox
			' 
			Me.AllowTextFlipCheckBox.AutoSize = True
			Me.AllowTextFlipCheckBox.ButtonProperties.BorderOffset = 2
			Me.AllowTextFlipCheckBox.Location = New System.Drawing.Point(11, 108)
			Me.AllowTextFlipCheckBox.Name = "AllowTextFlipCheckBox"
			Me.AllowTextFlipCheckBox.Size = New System.Drawing.Size(109, 17)
			Me.AllowTextFlipCheckBox.TabIndex = 4
			Me.AllowTextFlipCheckBox.Text = "Allow labels to flip"
			Me.AllowTextFlipCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AllowTextFlipCheckBox.CheckedChanged += new System.EventHandler(this.AllowTextFlipCheckBox_CheckedChanged);
			' 
			' SweepAngleScrollBar
			' 
			Me.SweepAngleScrollBar.Location = New System.Drawing.Point(10, 83)
			Me.SweepAngleScrollBar.Maximum = 350
			Me.SweepAngleScrollBar.Minimum = -350
			Me.SweepAngleScrollBar.MinimumSize = New System.Drawing.Size(32, 16)
			Me.SweepAngleScrollBar.Name = "SweepAngleScrollBar"
			Me.SweepAngleScrollBar.Size = New System.Drawing.Size(136, 16)
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
			Me.BeginAngleScrollBar.Size = New System.Drawing.Size(136, 16)
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
			Me.groupBox1.Location = New System.Drawing.Point(11, 149)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(155, 113)
			Me.groupBox1.TabIndex = 5
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Radial Gauge"
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.LinearGaugeOrientationComboBox)
			Me.groupBox2.Controls.Add(Me.label5)
			Me.groupBox2.Location = New System.Drawing.Point(11, 268)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(155, 72)
			Me.groupBox2.TabIndex = 6
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
			Me.LinearGaugeOrientationComboBox.Size = New System.Drawing.Size(133, 21)
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
			' NGaugeScaleLabelsOrientationUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.AllowTextFlipCheckBox)
			Me.Controls.Add(Me.CustomAngleNumericUpDown)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.AngleModeComboBox)
			Me.Controls.Add(Me.label1)
			Me.Name = "NGaugeScaleLabelsOrientationUC"
			Me.Size = New System.Drawing.Size(180, 433)
			DirectCast(Me.CustomAngleNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox1.PerformLayout()
			Me.groupBox2.ResumeLayout(False)
			Me.groupBox2.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Gauge Labels Orientation")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' create the radial gauge
			CreateRadialGauge()

			' create the linear gauge
			CreateLinearGauge()

			' update form controls
			AngleModeComboBox.FillFromEnum(GetType(ScaleLabelAngleMode))
			AngleModeComboBox.SelectedIndex = CInt(ScaleLabelAngleMode.View)

			BeginAngleScrollBar.Value = CInt(Math.Truncate(m_RadialGauge.BeginAngle))
			SweepAngleScrollBar.Value = CInt(Math.Truncate(m_RadialGauge.SweepAngle))

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
			Dim advGradient As New NAdvancedGradientFillStyle()
			advGradient.BackgroundColor = Color.Black
			advGradient.Points.Add(New NAdvancedGradientPoint(Color.White, 10, 10, 0, 100, AGPointShape.Circle))
			m_LinearGauge.BackgroundFillStyle = advGradient
			m_LinearGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.RoundedRect)

			Dim axis As NGaugeAxis = DirectCast(m_LinearGauge.Axes(0), NGaugeAxis)
			axis.Anchor = New NModelGaugeAxisAnchor(New NLength(10, NGraphicsUnit.Point), VertAlign.Center, RulerOrientation.Left)
			ConfigureScale(CType(axis.ScaleConfigurator, NLinearScaleConfigurator))

			' add some indicators
			AddRangeIndicatorToGauge(m_LinearGauge)
			m_LinearGauge.Indicators.Add(New NMarkerValueIndicator(60))
		End Sub

		Private Sub CreateRadialGauge()
			' create the radial gauge
			m_RadialGauge = New NRadialGaugePanel()
			m_RadialGauge.PaintEffect = New NGlassEffectStyle()
			m_RadialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)
			nChartControl1.Panels.Add(m_RadialGauge)

			' create the radial gauge
			m_RadialGauge.SweepAngle = 270
			m_RadialGauge.BeginAngle = -90

			' set some background
			Dim advGradient As New NAdvancedGradientFillStyle()
			advGradient.BackgroundColor = Color.Black
			advGradient.Points.Add(New NAdvancedGradientPoint(Color.White, 10, 10, 0, 100, AGPointShape.Circle))
			m_RadialGauge.BackgroundFillStyle = advGradient

			' configure the axis
			Dim axis As NGaugeAxis = DirectCast(m_RadialGauge.Axes(0), NGaugeAxis)
			axis.Range = New NRange1DD(0, 100)
			axis.Anchor.RulerOrientation = RulerOrientation.Right
			axis.Anchor = New NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, True, RulerOrientation.Right, 0, 100)

			ConfigureScale(CType(axis.ScaleConfigurator, NLinearScaleConfigurator))

			' add some indicators
			AddRangeIndicatorToGauge(m_RadialGauge)

			Dim needle As New NNeedleValueIndicator(60)
			needle.OffsetOriginMode = IndicatorOffsetOriginMode.ScaleMiddle
			needle.OffsetFromScale = New NLength(15)
			m_RadialGauge.Indicators.Add(needle)
		End Sub

		Private Sub AddRangeIndicatorToGauge(ByVal gauge As NGaugePanel)
			' add some indicators
			Dim rangeIndicator As New NRangeIndicator(New NRange1DD(75, 100))
			rangeIndicator.FillStyle = New NColorFillStyle(Color.Red)
			rangeIndicator.StrokeStyle.Width = New NLength(0)
			rangeIndicator.BeginWidth = New NLength(5)
			rangeIndicator.EndWidth = New NLength(10)
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

		Private Sub UpdateScaleLabelAngle()
			Dim angle As New NScaleLabelAngle(CType(AngleModeComboBox.SelectedIndex, ScaleLabelAngleMode), CSng(CustomAngleNumericUpDown.Value), AllowTextFlipCheckBox.Checked)

			' apply angle to radial gauge axis
			Dim axis As NGaugeAxis = DirectCast(m_RadialGauge.Axes(0), NGaugeAxis)
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NLinearScaleConfigurator = CType(axis.ScaleConfigurator, NLinearScaleConfigurator)
			scale_Renamed.LabelStyle.Angle = angle

			' apply angle to linear gauge axis
			axis = DirectCast(m_LinearGauge.Axes(0), NGaugeAxis)
			scale_Renamed = CType(axis.ScaleConfigurator, NLinearScaleConfigurator)
			scale_Renamed.LabelStyle.Angle = angle

			nChartControl1.Refresh()
		End Sub

		Private Sub AngleModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AngleModeComboBox.SelectedIndexChanged
			UpdateScaleLabelAngle()
		End Sub

		Private Sub CustomAngleNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CustomAngleNumericUpDown.ValueChanged
			UpdateScaleLabelAngle()
		End Sub

		Private Sub AllowTextFlipCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AllowTextFlipCheckBox.CheckedChanged
			UpdateScaleLabelAngle()
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
	End Class
End Namespace
