Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NGaugeCustomRangeLabelsUC
		Inherits NExampleBaseUC

		Private m_LinearGauge As NLinearGaugePanel
		Private m_RadialGauge As NRadialGaugePanel
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents LinearGaugeOrientationComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label5 As Label
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents BeginAngleScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents SweepAngleScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private label3 As Label
		Private label4 As Label
		Private WithEvents ShowMinRangeCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowMaxRangeCheckBox As Nevron.UI.WinForm.Controls.NCheckBox

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
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.LinearGaugeOrientationComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.BeginAngleScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.SweepAngleScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.ShowMinRangeCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowMaxRangeCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.groupBox2.SuspendLayout()
			Me.groupBox1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.LinearGaugeOrientationComboBox)
			Me.groupBox2.Controls.Add(Me.label5)
			Me.groupBox2.Location = New System.Drawing.Point(3, 196)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(173, 72)
			Me.groupBox2.TabIndex = 3
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Linear Gauge"
			' 
			' LinearGaugeOrientationComboBox
			' 
			Me.LinearGaugeOrientationComboBox.ListProperties.CheckBoxDataMember = ""
			Me.LinearGaugeOrientationComboBox.ListProperties.DataSource = Nothing
			Me.LinearGaugeOrientationComboBox.ListProperties.DisplayMember = ""
			Me.LinearGaugeOrientationComboBox.Location = New System.Drawing.Point(3, 31)
			Me.LinearGaugeOrientationComboBox.Name = "LinearGaugeOrientationComboBox"
			Me.LinearGaugeOrientationComboBox.Size = New System.Drawing.Size(151, 21)
			Me.LinearGaugeOrientationComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LinearGaugeOrientationComboBox.SelectedIndexChanged += new System.EventHandler(this.LinearGaugeOrientationComboBox_SelectedIndexChanged);
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Location = New System.Drawing.Point(3, 12)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(61, 13)
			Me.label5.TabIndex = 0
			Me.label5.Text = "Orientation:"
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.BeginAngleScrollBar)
			Me.groupBox1.Controls.Add(Me.SweepAngleScrollBar)
			Me.groupBox1.Controls.Add(Me.label3)
			Me.groupBox1.Controls.Add(Me.label4)
			Me.groupBox1.Location = New System.Drawing.Point(3, 77)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(173, 113)
			Me.groupBox1.TabIndex = 2
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Radial Gauge"
			' 
			' BeginAngleScrollBar
			' 
			Me.BeginAngleScrollBar.Location = New System.Drawing.Point(3, 30)
			Me.BeginAngleScrollBar.Maximum = 360
			Me.BeginAngleScrollBar.Minimum = -360
			Me.BeginAngleScrollBar.MinimumSize = New System.Drawing.Size(32, 16)
			Me.BeginAngleScrollBar.Name = "BeginAngleScrollBar"
			Me.BeginAngleScrollBar.Size = New System.Drawing.Size(154, 16)
			Me.BeginAngleScrollBar.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BeginAngleScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BeginAngleScrollBar_ValueChanged);
			' 
			' SweepAngleScrollBar
			' 
			Me.SweepAngleScrollBar.Location = New System.Drawing.Point(3, 76)
			Me.SweepAngleScrollBar.Maximum = 350
			Me.SweepAngleScrollBar.Minimum = -350
			Me.SweepAngleScrollBar.MinimumSize = New System.Drawing.Size(32, 16)
			Me.SweepAngleScrollBar.Name = "SweepAngleScrollBar"
			Me.SweepAngleScrollBar.Size = New System.Drawing.Size(154, 16)
			Me.SweepAngleScrollBar.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SweepAngleScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.SweepAngleScrollBar_ValueChanged);
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(3, 12)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(67, 13)
			Me.label3.TabIndex = 0
			Me.label3.Text = "Begin Angle:"
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(3, 58)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(73, 13)
			Me.label4.TabIndex = 2
			Me.label4.Text = "Sweep Angle:"
			' 
			' ShowMinRangeCheckBox
			' 
			Me.ShowMinRangeCheckBox.AutoSize = True
			Me.ShowMinRangeCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowMinRangeCheckBox.Location = New System.Drawing.Point(12, 14)
			Me.ShowMinRangeCheckBox.Name = "ShowMinRangeCheckBox"
			Me.ShowMinRangeCheckBox.Size = New System.Drawing.Size(108, 17)
			Me.ShowMinRangeCheckBox.TabIndex = 0
			Me.ShowMinRangeCheckBox.Text = "Show Min Range"
			Me.ShowMinRangeCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowMinRangeCheckBox.CheckedChanged += new System.EventHandler(this.ShowMinRangeCheckBox_CheckedChanged);
			' 
			' ShowMaxRangeCheckBox
			' 
			Me.ShowMaxRangeCheckBox.AutoSize = True
			Me.ShowMaxRangeCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowMaxRangeCheckBox.Location = New System.Drawing.Point(12, 37)
			Me.ShowMaxRangeCheckBox.Name = "ShowMaxRangeCheckBox"
			Me.ShowMaxRangeCheckBox.Size = New System.Drawing.Size(111, 17)
			Me.ShowMaxRangeCheckBox.TabIndex = 1
			Me.ShowMaxRangeCheckBox.Text = "Show Max Range"
			Me.ShowMaxRangeCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowMaxRangeCheckBox.CheckedChanged += new System.EventHandler(this.ShowMaxRangeCheckBox_CheckedChanged);
			' 
			' NGaugeCustomRangeLabelsUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.ShowMaxRangeCheckBox)
			Me.Controls.Add(Me.ShowMinRangeCheckBox)
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Name = "NGaugeCustomRangeLabelsUC"
			Me.Size = New System.Drawing.Size(180, 454)
			Me.groupBox2.ResumeLayout(False)
			Me.groupBox2.PerformLayout()
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox1.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Gauge Custom Range Labels<br/><font size = '9pt'>Demonstrates how to use custom range labels to denote ranges on a scale</font>")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.TextFormat = TextFormat.XML
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' create the radial gauge
			CreateRadialGauge()

			' create the linear gauge
			CreateLinearGauge()

			' init form controls
			BeginAngleScrollBar.Value = CInt(Math.Truncate(m_RadialGauge.BeginAngle))
			SweepAngleScrollBar.Value = CInt(Math.Truncate(m_RadialGauge.SweepAngle))

			LinearGaugeOrientationComboBox.Items.Add("Horizontal")
			LinearGaugeOrientationComboBox.Items.Add("Vertical")
			LinearGaugeOrientationComboBox.SelectedIndex = 1

			ShowMinRangeCheckBox.Checked = True
			ShowMaxRangeCheckBox.Checked = True
		End Sub

		Private Sub CreateLinearGauge()
			m_LinearGauge = New NLinearGaugePanel()
			nChartControl1.Panels.Add(m_LinearGauge)

			' create the background panel
			Dim advGradient As New NAdvancedGradientFillStyle()
			advGradient.BackgroundColor = Color.Black
			advGradient.Points.Add(New NAdvancedGradientPoint(Color.LightGray, 10, 10, 0, 100, AGPointShape.Circle))
			m_LinearGauge.BackgroundFillStyle = advGradient
			m_LinearGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.RoundedRect)

			Dim axis As NGaugeAxis = DirectCast(m_LinearGauge.Axes(0), NGaugeAxis)
			axis.Anchor = New NModelGaugeAxisAnchor(New NLength(20, NGraphicsUnit.Point), VertAlign.Center, RulerOrientation.Left)
			ConfigureScale(CType(axis.ScaleConfigurator, NLinearScaleConfigurator))

			' add some indicators
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
			advGradient.Points.Add(New NAdvancedGradientPoint(Color.LightGray, 10, 10, 0, 100, AGPointShape.Circle))
			m_RadialGauge.BackgroundFillStyle = advGradient

			' configure the axis
			Dim axis As NGaugeAxis = DirectCast(m_RadialGauge.Axes(0), NGaugeAxis)
			axis.Range = New NRange1DD(0, 100)
			axis.Anchor.RulerOrientation = RulerOrientation.Right
			axis.Anchor = New NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, True, RulerOrientation.Right, 0, 100)

			ConfigureScale(CType(axis.ScaleConfigurator, NLinearScaleConfigurator))

			' add some indicators
			Dim needle As New NNeedleValueIndicator(60)
			needle.OffsetOriginMode = IndicatorOffsetOriginMode.ScaleMiddle
			needle.OffsetFromScale = New NLength(15)
			m_RadialGauge.Indicators.Add(needle)
		End Sub

		Private Sub ConfigureScale(ByVal scale As NLinearScaleConfigurator)
			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke)
			scale.LabelFitModes = New LabelFitMode(){}
			scale.MinorTickCount = 3
			scale.RulerStyle.FillStyle = New NColorFillStyle(Color.FromArgb(40, Color.White))
			scale.OuterMajorTickStyle.FillStyle = New NColorFillStyle(Color.Orange)
			scale.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 10, FontStyle.Bold)
			scale.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.White)
		End Sub

		Private Sub UpdateAxisRanges()
			Dim linearGaugeScale As NLinearScaleConfigurator = TryCast(DirectCast(m_LinearGauge.Axes(0), NGaugeAxis).ScaleConfigurator, NLinearScaleConfigurator)
			Dim radialGaugeScale As NLinearScaleConfigurator = TryCast(DirectCast(m_RadialGauge.Axes(0), NGaugeAxis).ScaleConfigurator, NLinearScaleConfigurator)

			linearGaugeScale.CustomLabels.Clear()
			linearGaugeScale.Sections.Clear()

			radialGaugeScale.CustomLabels.Clear()
			radialGaugeScale.Sections.Clear()

			If ShowMinRangeCheckBox.Checked Then
				ApplyScaleSectionToAxis(linearGaugeScale, "Min", New NRange1DD(0, 20), Color.LightBlue)
				ApplyScaleSectionToAxis(radialGaugeScale, "Min", New NRange1DD(0, 20), Color.LightBlue)
			End If

			If ShowMaxRangeCheckBox.Checked Then
				ApplyScaleSectionToAxis(linearGaugeScale, "Max", New NRange1DD(80, 100), Color.Red)
				ApplyScaleSectionToAxis(radialGaugeScale, "Max", New NRange1DD(80, 100), Color.Red)
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub ApplyScaleSectionToAxis(ByVal scale As NLinearScaleConfigurator, ByVal text As String, ByVal range As NRange1DD, ByVal color As Color)
			Dim scaleSection As New NScaleSectionStyle()

			scaleSection.Range = range
			scaleSection.LabelTextStyle = New NTextStyle()
			scaleSection.LabelTextStyle.FillStyle = New NColorFillStyle(color)
			scaleSection.LabelTextStyle.FontStyle = New NFontStyle("Arial", 10,FontStyle.Bold Or FontStyle.Italic)
			scaleSection.MajorTickStrokeStyle = New NStrokeStyle(color)

			scale.Sections.Add(scaleSection)

			Dim rangeLabel As New NCustomRangeLabel(range, text)
			rangeLabel.Style.WrapText = False
			rangeLabel.Style.KeepInsideRuler = False
			rangeLabel.Style.StrokeStyle.Color = color
			rangeLabel.Style.TextStyle.FillStyle = New NColorFillStyle(System.Drawing.Color.White)
			rangeLabel.Style.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0)
			rangeLabel.Style.TickMode = RangeLabelTickMode.Center

			scale.CustomLabels.Add(rangeLabel)
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

		Private Sub ShowMinRangeCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowMinRangeCheckBox.CheckedChanged
			UpdateAxisRanges()
		End Sub

		Private Sub ShowMaxRangeCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowMaxRangeCheckBox.CheckedChanged
			UpdateAxisRanges()
		End Sub
	End Class
End Namespace
