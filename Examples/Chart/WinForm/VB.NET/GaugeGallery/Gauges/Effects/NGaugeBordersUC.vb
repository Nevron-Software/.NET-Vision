Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NGaugeBordersUC
		Inherits NExampleBaseUC

		Private label1 As System.Windows.Forms.Label

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
		Private WithEvents BorderTypeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label2 As Label
		Private WithEvents RoundRectRoundingUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents RadialGaugeAutoBorderTypeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label6 As Label
		Private WithEvents CenterRoundingNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label7 As Label
		Private WithEvents EdgeRoundingNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label8 As Label

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
			Me.SweepAngleScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.BeginAngleScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.LinearGaugeOrientationComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.BorderTypeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.RoundRectRoundingUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.RadialGaugeAutoBorderTypeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.CenterRoundingNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label7 = New System.Windows.Forms.Label()
			Me.EdgeRoundingNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label8 = New System.Windows.Forms.Label()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			DirectCast(Me.RoundRectRoundingUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.CenterRoundingNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.EdgeRoundingNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(14, 10)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(68, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Border Type:"
			' 
			' SweepAngleScrollBar
			' 
			Me.SweepAngleScrollBar.Location = New System.Drawing.Point(10, 81)
			Me.SweepAngleScrollBar.Maximum = 350
			Me.SweepAngleScrollBar.Minimum = -350
			Me.SweepAngleScrollBar.MinimumSize = New System.Drawing.Size(32, 16)
			Me.SweepAngleScrollBar.Name = "SweepAngleScrollBar"
			Me.SweepAngleScrollBar.Size = New System.Drawing.Size(153, 16)
			Me.SweepAngleScrollBar.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SweepAngleScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.SweepAngleScrollBar_ValueChanged);
			' 
			' BeginAngleScrollBar
			' 
			Me.BeginAngleScrollBar.Location = New System.Drawing.Point(10, 35)
			Me.BeginAngleScrollBar.Maximum = 360
			Me.BeginAngleScrollBar.Minimum = -360
			Me.BeginAngleScrollBar.MinimumSize = New System.Drawing.Size(32, 16)
			Me.BeginAngleScrollBar.Name = "BeginAngleScrollBar"
			Me.BeginAngleScrollBar.Size = New System.Drawing.Size(153, 16)
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
			Me.groupBox1.Location = New System.Drawing.Point(3, 231)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(195, 116)
			Me.groupBox1.TabIndex = 10
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Radial Gauge"
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.LinearGaugeOrientationComboBox)
			Me.groupBox2.Controls.Add(Me.label5)
			Me.groupBox2.Location = New System.Drawing.Point(0, 353)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(198, 72)
			Me.groupBox2.TabIndex = 11
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Linear Gauge"
			' 
			' LinearGaugeOrientationComboBox
			' 
			Me.LinearGaugeOrientationComboBox.ListProperties.CheckBoxDataMember = ""
			Me.LinearGaugeOrientationComboBox.ListProperties.DataSource = Nothing
			Me.LinearGaugeOrientationComboBox.ListProperties.DisplayMember = ""
			Me.LinearGaugeOrientationComboBox.Location = New System.Drawing.Point(14, 38)
			Me.LinearGaugeOrientationComboBox.Name = "LinearGaugeOrientationComboBox"
			Me.LinearGaugeOrientationComboBox.Size = New System.Drawing.Size(152, 21)
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
			' BorderTypeComboBox
			' 
			Me.BorderTypeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.BorderTypeComboBox.ListProperties.DataSource = Nothing
			Me.BorderTypeComboBox.ListProperties.DisplayMember = ""
			Me.BorderTypeComboBox.Location = New System.Drawing.Point(17, 27)
			Me.BorderTypeComboBox.Name = "BorderTypeComboBox"
			Me.BorderTypeComboBox.Size = New System.Drawing.Size(149, 21)
			Me.BorderTypeComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BorderTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.BorderTypeComboBox_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(14, 63)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(90, 13)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Corner Rounding:"
			' 
			' RoundRectRoundingUpDown
			' 
			Me.RoundRectRoundingUpDown.Location = New System.Drawing.Point(113, 54)
			Me.RoundRectRoundingUpDown.Name = "RoundRectRoundingUpDown"
			Me.RoundRectRoundingUpDown.Size = New System.Drawing.Size(52, 20)
			Me.RoundRectRoundingUpDown.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RoundRectRoundingUpDown.ValueChanged += new System.EventHandler(this.RoundRectRoundingUpDown_ValueChanged);
			' 
			' RadialGaugeAutoBorderTypeComboBox
			' 
			Me.RadialGaugeAutoBorderTypeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.RadialGaugeAutoBorderTypeComboBox.ListProperties.DataSource = Nothing
			Me.RadialGaugeAutoBorderTypeComboBox.ListProperties.DisplayMember = ""
			Me.RadialGaugeAutoBorderTypeComboBox.Location = New System.Drawing.Point(14, 125)
			Me.RadialGaugeAutoBorderTypeComboBox.Name = "RadialGaugeAutoBorderTypeComboBox"
			Me.RadialGaugeAutoBorderTypeComboBox.Size = New System.Drawing.Size(152, 21)
			Me.RadialGaugeAutoBorderTypeComboBox.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RadialGaugeAutoBorderTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.RadialGaugeAutoBorderTypeComboBox_SelectedIndexChanged);
			' 
			' label6
			' 
			Me.label6.AutoSize = True
			Me.label6.Location = New System.Drawing.Point(14, 109)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(134, 13)
			Me.label6.TabIndex = 4
			Me.label6.Text = "Radial Gauge Auto Border:"
			' 
			' CenterRoundingNumericUpDown
			' 
			Me.CenterRoundingNumericUpDown.Location = New System.Drawing.Point(113, 162)
			Me.CenterRoundingNumericUpDown.Name = "CenterRoundingNumericUpDown"
			Me.CenterRoundingNumericUpDown.Size = New System.Drawing.Size(53, 20)
			Me.CenterRoundingNumericUpDown.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.CenterRoundingNumericUpDown.ValueChanged += new System.EventHandler(this.CenterRoundingNumericUpDown_ValueChanged);
			' 
			' label7
			' 
			Me.label7.AutoSize = True
			Me.label7.Location = New System.Drawing.Point(11, 169)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(90, 13)
			Me.label7.TabIndex = 6
			Me.label7.Text = "Center Rounding:"
			' 
			' EdgeRoundingNumericUpDown
			' 
			Me.EdgeRoundingNumericUpDown.Location = New System.Drawing.Point(113, 188)
			Me.EdgeRoundingNumericUpDown.Name = "EdgeRoundingNumericUpDown"
			Me.EdgeRoundingNumericUpDown.Size = New System.Drawing.Size(53, 20)
			Me.EdgeRoundingNumericUpDown.TabIndex = 9
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EdgeRoundingNumericUpDown.ValueChanged += new System.EventHandler(this.EdgeRoundingNumericUpDown_ValueChanged);
			' 
			' label8
			' 
			Me.label8.AutoSize = True
			Me.label8.Location = New System.Drawing.Point(11, 195)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(84, 13)
			Me.label8.TabIndex = 8
			Me.label8.Text = "Edge Rounding:"
			' 
			' NGaugeBordersUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.EdgeRoundingNumericUpDown)
			Me.Controls.Add(Me.label8)
			Me.Controls.Add(Me.CenterRoundingNumericUpDown)
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.RadialGaugeAutoBorderTypeComboBox)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.RoundRectRoundingUpDown)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.BorderTypeComboBox)
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.label1)
			Me.Name = "NGaugeBordersUC"
			Me.Size = New System.Drawing.Size(180, 433)
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox1.PerformLayout()
			Me.groupBox2.ResumeLayout(False)
			Me.groupBox2.PerformLayout()
			DirectCast(Me.RoundRectRoundingUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.CenterRoundingNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.EdgeRoundingNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			nChartControl1.Panels.Clear()
			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Gauge Borders")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' create the radial gauge
			CreateRadialGauge()

			' create the linear gauge
			CreateLinearGauge()

			BeginAngleScrollBar.Value = CInt(Math.Truncate(m_RadialGauge.BeginAngle))
			SweepAngleScrollBar.Value = CInt(Math.Truncate(m_RadialGauge.SweepAngle))
			CenterRoundingNumericUpDown.Value = 17
			EdgeRoundingNumericUpDown.Value = 10
			RoundRectRoundingUpDown.Value = 10

			LinearGaugeOrientationComboBox.Items.Add("Horizontal")
			LinearGaugeOrientationComboBox.Items.Add("Vertical")
			LinearGaugeOrientationComboBox.SelectedIndex = 1

			BorderTypeComboBox.Items.Add("Rectangular")
			BorderTypeComboBox.Items.Add("Rounded Rectangular")
			BorderTypeComboBox.Items.Add("Auto")
			BorderTypeComboBox.SelectedIndex = 2

			RadialGaugeAutoBorderTypeComboBox.Items.Add("Circle")
			RadialGaugeAutoBorderTypeComboBox.Items.Add("Cut Circle")
			RadialGaugeAutoBorderTypeComboBox.Items.Add("Rounded Outline")
			RadialGaugeAutoBorderTypeComboBox.SelectedIndex = 0
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

			' configure its axis
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

		Private Sub UpdateGaugeBorders()
			If m_RadialGauge Is Nothing OrElse m_LinearGauge Is Nothing Then
				Return
			End If

			Dim enableRoundRelatedControls As Boolean = False
			Dim enableAutoRelatedControls As Boolean = False
			Select Case BorderTypeComboBox.SelectedIndex
				Case 0 ' rect
					m_RadialGauge.BorderStyle.Shape = BorderShape.Rectangle
					m_LinearGauge.BorderStyle.Shape = BorderShape.Rectangle
				Case 1 ' rounded rect
					m_RadialGauge.BorderStyle.Shape = BorderShape.RoundedRect
					m_RadialGauge.BorderStyle.CornerRounding = New NLength(CSng(RoundRectRoundingUpDown.Value), NGraphicsUnit.Point)
					m_LinearGauge.BorderStyle.Shape = BorderShape.RoundedRect
					m_LinearGauge.BorderStyle.CornerRounding = New NLength(CSng(RoundRectRoundingUpDown.Value), NGraphicsUnit.Point)

				Case 2 ' auto
					enableAutoRelatedControls = True
					m_RadialGauge.BorderStyle.Shape = BorderShape.Auto
					m_LinearGauge.BorderStyle.Shape = BorderShape.Auto
			End Select

			If m_RadialGauge.BorderStyle.Shape = BorderShape.Auto Then
				' also apply auto settings

				Select Case RadialGaugeAutoBorderTypeComboBox.SelectedIndex
					Case 0 ' circle
						m_RadialGauge.AutoBorder = RadialGaugeAutoBorder.Circle
					Case 1 ' cut circle
						enableRoundRelatedControls = True
						m_RadialGauge.AutoBorder = RadialGaugeAutoBorder.CutCircle
						m_RadialGauge.CenterBorderRounding = New NLength(CSng(CenterRoundingNumericUpDown.Value), NGraphicsUnit.Point)
						m_RadialGauge.EdgeBorderRounding = New NLength(CSng(EdgeRoundingNumericUpDown.Value), NGraphicsUnit.Point)
					Case 2 ' rounded outline
						enableRoundRelatedControls = True
						m_RadialGauge.AutoBorder = RadialGaugeAutoBorder.RoundedOutline
						m_RadialGauge.CenterBorderRounding = New NLength(CSng(CenterRoundingNumericUpDown.Value), NGraphicsUnit.Point)
						m_RadialGauge.EdgeBorderRounding = New NLength(CSng(EdgeRoundingNumericUpDown.Value), NGraphicsUnit.Point)
				End Select
			End If

			RadialGaugeAutoBorderTypeComboBox.Enabled = enableAutoRelatedControls
			CenterRoundingNumericUpDown.Enabled = enableRoundRelatedControls
			EdgeRoundingNumericUpDown.Enabled = enableRoundRelatedControls

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

		Private Sub BorderTypeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BorderTypeComboBox.SelectedIndexChanged
			UpdateGaugeBorders()
		End Sub

		Private Sub RadialGaugeAutoBorderTypeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadialGaugeAutoBorderTypeComboBox.SelectedIndexChanged
			UpdateGaugeBorders()
		End Sub

		Private Sub RoundRectRoundingUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RoundRectRoundingUpDown.ValueChanged
			UpdateGaugeBorders()
		End Sub

		Private Sub CenterRoundingNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CenterRoundingNumericUpDown.ValueChanged
			UpdateGaugeBorders()
		End Sub

		Private Sub EdgeRoundingNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles EdgeRoundingNumericUpDown.ValueChanged
			UpdateGaugeBorders()
		End Sub
	End Class
End Namespace
