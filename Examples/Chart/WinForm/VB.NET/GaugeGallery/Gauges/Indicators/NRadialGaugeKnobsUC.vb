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
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NRadialGaugeKnobsUC
		Inherits NExampleBaseUC

		Private m_Updating As Boolean
		Private m_RadialGauge As NRadialGaugePanel
		Private WithEvents MarkerShapeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label5 As Label
		Private WithEvents OuterRimPatternComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As Label
		Private label2 As Label
		Private WithEvents OuterRimPatternRepeatCountUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents OuterRimRadiusOffsetUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label3 As Label
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents InnerRimRadiusOffsetUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label4 As Label
		Private WithEvents InnerRimPatternRepeatCountUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label6 As Label
		Private WithEvents InnerRimPatternComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label7 As Label
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents MarkerOffsetUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label8 As Label
		Private WithEvents MarkerPaintOrderComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label9 As Label
		Private m_NumericDisplay As NNumericDisplayPanel

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

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
			Me.MarkerShapeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.OuterRimPatternComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.OuterRimPatternRepeatCountUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.OuterRimRadiusOffsetUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label3 = New System.Windows.Forms.Label()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.InnerRimRadiusOffsetUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label4 = New System.Windows.Forms.Label()
			Me.InnerRimPatternRepeatCountUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label6 = New System.Windows.Forms.Label()
			Me.InnerRimPatternComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label7 = New System.Windows.Forms.Label()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.MarkerPaintOrderComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label9 = New System.Windows.Forms.Label()
			Me.MarkerOffsetUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label8 = New System.Windows.Forms.Label()
			DirectCast(Me.OuterRimPatternRepeatCountUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.OuterRimRadiusOffsetUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox2.SuspendLayout()
			Me.nGroupBox1.SuspendLayout()
			DirectCast(Me.InnerRimRadiusOffsetUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.InnerRimPatternRepeatCountUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nGroupBox2.SuspendLayout()
			DirectCast(Me.MarkerOffsetUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' MarkerShapeComboBox
			' 
			Me.MarkerShapeComboBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.MarkerShapeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.MarkerShapeComboBox.ListProperties.DataSource = Nothing
			Me.MarkerShapeComboBox.ListProperties.DisplayMember = ""
			Me.MarkerShapeComboBox.Location = New System.Drawing.Point(3, 36)
			Me.MarkerShapeComboBox.Name = "MarkerShapeComboBox"
			Me.MarkerShapeComboBox.Size = New System.Drawing.Size(174, 21)
			Me.MarkerShapeComboBox.TabIndex = 5
			Me.MarkerShapeComboBox.Text = "KnobStyleComboBox"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MarkerShapeComboBox.SelectedIndexChanged += new System.EventHandler(this.MarkerShapeComboBox_SelectedIndexChanged);
			' 
			' label5
			' 
			Me.label5.Dock = System.Windows.Forms.DockStyle.Top
			Me.label5.Location = New System.Drawing.Point(3, 16)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(174, 20)
			Me.label5.TabIndex = 4
			Me.label5.Text = "Shape:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' OuterRimPatternComboBox
			' 
			Me.OuterRimPatternComboBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.OuterRimPatternComboBox.ListProperties.CheckBoxDataMember = ""
			Me.OuterRimPatternComboBox.ListProperties.DataSource = Nothing
			Me.OuterRimPatternComboBox.ListProperties.DisplayMember = ""
			Me.OuterRimPatternComboBox.Location = New System.Drawing.Point(3, 39)
			Me.OuterRimPatternComboBox.Name = "OuterRimPatternComboBox"
			Me.OuterRimPatternComboBox.Size = New System.Drawing.Size(174, 21)
			Me.OuterRimPatternComboBox.TabIndex = 7
			Me.OuterRimPatternComboBox.Text = "KnobStyleComboBox"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OuterRimPatternComboBox.SelectedIndexChanged += new System.EventHandler(this.OuterRimPatternComboBox_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Dock = System.Windows.Forms.DockStyle.Top
			Me.label1.Location = New System.Drawing.Point(3, 16)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(174, 23)
			Me.label1.TabIndex = 6
			Me.label1.Text = "Pattern:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' label2
			' 
			Me.label2.Dock = System.Windows.Forms.DockStyle.Top
			Me.label2.Location = New System.Drawing.Point(3, 60)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(174, 23)
			Me.label2.TabIndex = 8
			Me.label2.Text = "Repeat Count:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' OuterRimPatternRepeatCountUpDown
			' 
			Me.OuterRimPatternRepeatCountUpDown.Dock = System.Windows.Forms.DockStyle.Top
			Me.OuterRimPatternRepeatCountUpDown.Location = New System.Drawing.Point(3, 83)
			Me.OuterRimPatternRepeatCountUpDown.Name = "OuterRimPatternRepeatCountUpDown"
			Me.OuterRimPatternRepeatCountUpDown.Size = New System.Drawing.Size(174, 20)
			Me.OuterRimPatternRepeatCountUpDown.TabIndex = 9
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OuterRimPatternRepeatCountUpDown.ValueChanged += new System.EventHandler(this.OuterRimPatternRepeatCountUpDown_ValueChanged);
			' 
			' OuterRimRadiusOffsetUpDown
			' 
			Me.OuterRimRadiusOffsetUpDown.Dock = System.Windows.Forms.DockStyle.Top
			Me.OuterRimRadiusOffsetUpDown.Location = New System.Drawing.Point(3, 126)
			Me.OuterRimRadiusOffsetUpDown.Name = "OuterRimRadiusOffsetUpDown"
			Me.OuterRimRadiusOffsetUpDown.Size = New System.Drawing.Size(174, 20)
			Me.OuterRimRadiusOffsetUpDown.TabIndex = 11
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OuterRimRadiusOffsetUpDown.ValueChanged += new System.EventHandler(this.OuterRimRadiusOffsetUpDown_ValueChanged);
			' 
			' label3
			' 
			Me.label3.Dock = System.Windows.Forms.DockStyle.Top
			Me.label3.Location = New System.Drawing.Point(3, 103)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(174, 23)
			Me.label3.TabIndex = 10
			Me.label3.Text = "Radius Offset:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.OuterRimRadiusOffsetUpDown)
			Me.groupBox2.Controls.Add(Me.label3)
			Me.groupBox2.Controls.Add(Me.OuterRimPatternRepeatCountUpDown)
			Me.groupBox2.Controls.Add(Me.label2)
			Me.groupBox2.Controls.Add(Me.OuterRimPatternComboBox)
			Me.groupBox2.Controls.Add(Me.label1)
			Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox2.ImageIndex = 0
			Me.groupBox2.Location = New System.Drawing.Point(0, 154)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(180, 163)
			Me.groupBox2.TabIndex = 12
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Outer Rim:"
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.InnerRimRadiusOffsetUpDown)
			Me.nGroupBox1.Controls.Add(Me.label4)
			Me.nGroupBox1.Controls.Add(Me.InnerRimPatternRepeatCountUpDown)
			Me.nGroupBox1.Controls.Add(Me.label6)
			Me.nGroupBox1.Controls.Add(Me.InnerRimPatternComboBox)
			Me.nGroupBox1.Controls.Add(Me.label7)
			Me.nGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(0, 317)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(180, 163)
			Me.nGroupBox1.TabIndex = 13
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Inner Rim:"
			' 
			' InnerRimRadiusOffsetUpDown
			' 
			Me.InnerRimRadiusOffsetUpDown.Dock = System.Windows.Forms.DockStyle.Top
			Me.InnerRimRadiusOffsetUpDown.Location = New System.Drawing.Point(3, 126)
			Me.InnerRimRadiusOffsetUpDown.Name = "InnerRimRadiusOffsetUpDown"
			Me.InnerRimRadiusOffsetUpDown.Size = New System.Drawing.Size(174, 20)
			Me.InnerRimRadiusOffsetUpDown.TabIndex = 11
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InnerRimRadiusOffsetUpDown.ValueChanged += new System.EventHandler(this.InnerRimRadiusOffsetUpDown_ValueChanged);
			' 
			' label4
			' 
			Me.label4.Dock = System.Windows.Forms.DockStyle.Top
			Me.label4.Location = New System.Drawing.Point(3, 103)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(174, 23)
			Me.label4.TabIndex = 10
			Me.label4.Text = "Radius Offset:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' InnerRimPatternRepeatCountUpDown
			' 
			Me.InnerRimPatternRepeatCountUpDown.Dock = System.Windows.Forms.DockStyle.Top
			Me.InnerRimPatternRepeatCountUpDown.Location = New System.Drawing.Point(3, 83)
			Me.InnerRimPatternRepeatCountUpDown.Name = "InnerRimPatternRepeatCountUpDown"
			Me.InnerRimPatternRepeatCountUpDown.Size = New System.Drawing.Size(174, 20)
			Me.InnerRimPatternRepeatCountUpDown.TabIndex = 9
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InnerRimPatternRepeatCountUpDown.ValueChanged += new System.EventHandler(this.InnerRimPatternRepeatCountUpDown_ValueChanged);
			' 
			' label6
			' 
			Me.label6.Dock = System.Windows.Forms.DockStyle.Top
			Me.label6.Location = New System.Drawing.Point(3, 60)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(174, 23)
			Me.label6.TabIndex = 8
			Me.label6.Text = "Repeat Count:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' InnerRimPatternComboBox
			' 
			Me.InnerRimPatternComboBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.InnerRimPatternComboBox.ListProperties.CheckBoxDataMember = ""
			Me.InnerRimPatternComboBox.ListProperties.DataSource = Nothing
			Me.InnerRimPatternComboBox.ListProperties.DisplayMember = ""
			Me.InnerRimPatternComboBox.Location = New System.Drawing.Point(3, 39)
			Me.InnerRimPatternComboBox.Name = "InnerRimPatternComboBox"
			Me.InnerRimPatternComboBox.Size = New System.Drawing.Size(174, 21)
			Me.InnerRimPatternComboBox.TabIndex = 7
			Me.InnerRimPatternComboBox.Text = "InnerRimPatternComboBox"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InnerRimPatternComboBox.SelectedIndexChanged += new System.EventHandler(this.InnerRimPatternComboBox_SelectedIndexChanged);
			' 
			' label7
			' 
			Me.label7.Dock = System.Windows.Forms.DockStyle.Top
			Me.label7.Location = New System.Drawing.Point(3, 16)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(174, 23)
			Me.label7.TabIndex = 6
			Me.label7.Text = "Pattern:"
			Me.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Controls.Add(Me.MarkerPaintOrderComboBox)
			Me.nGroupBox2.Controls.Add(Me.label9)
			Me.nGroupBox2.Controls.Add(Me.MarkerOffsetUpDown)
			Me.nGroupBox2.Controls.Add(Me.label8)
			Me.nGroupBox2.Controls.Add(Me.MarkerShapeComboBox)
			Me.nGroupBox2.Controls.Add(Me.label5)
			Me.nGroupBox2.Dock = System.Windows.Forms.DockStyle.Top
			Me.nGroupBox2.ImageIndex = 0
			Me.nGroupBox2.Location = New System.Drawing.Point(0, 0)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(180, 154)
			Me.nGroupBox2.TabIndex = 14
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "Marker:"
			' 
			' MarkerPaintOrderComboBox
			' 
			Me.MarkerPaintOrderComboBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.MarkerPaintOrderComboBox.ListProperties.CheckBoxDataMember = ""
			Me.MarkerPaintOrderComboBox.ListProperties.DataSource = Nothing
			Me.MarkerPaintOrderComboBox.ListProperties.DisplayMember = ""
			Me.MarkerPaintOrderComboBox.Location = New System.Drawing.Point(3, 120)
			Me.MarkerPaintOrderComboBox.Name = "MarkerPaintOrderComboBox"
			Me.MarkerPaintOrderComboBox.Size = New System.Drawing.Size(174, 21)
			Me.MarkerPaintOrderComboBox.TabIndex = 14
			Me.MarkerPaintOrderComboBox.Text = "KnobStyleComboBox"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MarkerPaintOrderComboBox.SelectedIndexChanged += new System.EventHandler(this.MarkerPaintOrderComboBox_SelectedIndexChanged);
			' 
			' label9
			' 
			Me.label9.Dock = System.Windows.Forms.DockStyle.Top
			Me.label9.Location = New System.Drawing.Point(3, 100)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(174, 20)
			Me.label9.TabIndex = 13
			Me.label9.Text = "Paint Order:"
			Me.label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' MarkerOffsetUpDown
			' 
			Me.MarkerOffsetUpDown.Dock = System.Windows.Forms.DockStyle.Top
			Me.MarkerOffsetUpDown.Location = New System.Drawing.Point(3, 80)
			Me.MarkerOffsetUpDown.Minimum = New Decimal(New Integer() { 100, 0, 0, -2147483648})
			Me.MarkerOffsetUpDown.Name = "MarkerOffsetUpDown"
			Me.MarkerOffsetUpDown.Size = New System.Drawing.Size(174, 20)
			Me.MarkerOffsetUpDown.TabIndex = 12
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MarkerOffsetUpDown.ValueChanged += new System.EventHandler(this.MarkerOffsetUpDown_ValueChanged);
			' 
			' label8
			' 
			Me.label8.Dock = System.Windows.Forms.DockStyle.Top
			Me.label8.Location = New System.Drawing.Point(3, 57)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(174, 23)
			Me.label8.TabIndex = 6
			Me.label8.Text = "Offset:"
			Me.label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' NRadialGaugeKnobsUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.nGroupBox1)
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.nGroupBox2)
			Me.Name = "NRadialGaugeKnobsUC"
			Me.Size = New System.Drawing.Size(180, 598)
			DirectCast(Me.OuterRimPatternRepeatCountUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.OuterRimRadiusOffsetUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox2.ResumeLayout(False)
			Me.nGroupBox1.ResumeLayout(False)
			DirectCast(Me.InnerRimRadiusOffsetUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.InnerRimPatternRepeatCountUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nGroupBox2.ResumeLayout(False)
			DirectCast(Me.MarkerOffsetUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As New NLabel("Radial Gauge Knob Indicators")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			header.ContentAlignment = ContentAlignment.BottomRight
			header.DockMode = PanelDockMode.Top
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
			header.Margins = New NMarginsL(5, 5, 5, 5)

			nChartControl1.Panels.Add(header)

			Dim panelContainer As New NDockPanel()
			panelContainer.DockMode = PanelDockMode.Fill

			' create the knob indicator
			Dim knobIndicator As New NKnobIndicator()
			knobIndicator.OffsetFromScale = New NLength(-3)

			' apply fill style to the marker
			Dim advancedGradientFill As New NAdvancedGradientFillStyle()
			advancedGradientFill.BackgroundColor = Color.Red
			advancedGradientFill.Points.Add(New NAdvancedGradientPoint(Color.White, 20, 20, 0, 100, AGPointShape.Circle))
			knobIndicator.MarkerShape.FillStyle = advancedGradientFill
			AddHandler knobIndicator.ValueChanged, AddressOf knobIndicator_ValueChanged

			m_RadialGauge = CreateRadialGauge(knobIndicator)
			m_NumericDisplay = CreateNumericDisplay()

			panelContainer.ChildPanels.Add(m_NumericDisplay)
			panelContainer.ChildPanels.Add(m_RadialGauge)

			panelContainer.Margins = New NMarginsL(10, 10, 10, 10)
			nChartControl1.Panels.Add(panelContainer)

			nChartControl1.Controller.Tools.Add(New NSelectorTool())
			nChartControl1.Controller.Tools.Add(New NIndicatorDragTool())

			m_Updating = True

			' Init form controls 
			MarkerShapeComboBox.FillFromEnum(GetType(SmartShape2D))
			MarkerShapeComboBox.SelectedIndex = CInt(SmartShape2D.Ellipse)
			MarkerOffsetUpDown.Value = CDec(knobIndicator.OffsetFromScale.Value)
			MarkerPaintOrderComboBox.FillFromEnum(GetType(KnobMarkerPaintOrder))
			MarkerPaintOrderComboBox.SelectedIndex = CInt(knobIndicator.MarkerPaintOrder)

			' outer rim
			OuterRimPatternComboBox.FillFromEnum(GetType(CircularRimPattern))
			OuterRimPatternComboBox.SelectedIndex = CInt(knobIndicator.OuterRimStyle.Pattern)
			OuterRimPatternRepeatCountUpDown.Value = CDec(knobIndicator.OuterRimStyle.PatternRepeatCount)
			OuterRimRadiusOffsetUpDown.Value = CDec(knobIndicator.OuterRimStyle.Offset.Value)

			' inner rim
			InnerRimPatternComboBox.FillFromEnum(GetType(CircularRimPattern))
			InnerRimPatternComboBox.SelectedIndex = CInt(knobIndicator.InnerRimStyle.Pattern)
			InnerRimPatternRepeatCountUpDown.Value = CDec(knobIndicator.InnerRimStyle.PatternRepeatCount)
			InnerRimRadiusOffsetUpDown.Value = CDec(knobIndicator.InnerRimStyle.Offset.Value)

			m_Updating = False

			OuterRimPatternRepeatCountUpDown.Value = 6
		End Sub

		Private Function CreateRadialGauge(ByVal knobIndicator As NKnobIndicator) As NRadialGaugePanel
			' create the radial gauge
			Dim radialGauge As New NRadialGaugePanel()

			radialGauge.Size = New NSizeL(New NLength(0), New NLength(50, NRelativeUnit.ParentPercentage))
			radialGauge.ContentAlignment = ContentAlignment.MiddleCenter
			radialGauge.DockMode = PanelDockMode.Fill
			radialGauge.SweepAngle = 270
			radialGauge.BeginAngle = -225
			radialGauge.CapStyle.Visible = False

			radialGauge.Indicators.Add(knobIndicator)

			' configure scale
			Dim axis As NGaugeAxis = DirectCast(radialGauge.Axes(0), NGaugeAxis)
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)

			scale_Renamed.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke)
			scale_Renamed.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 12, FontStyle.Italic)
			scale_Renamed.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.Black)
			scale_Renamed.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0)
			scale_Renamed.MinorTickCount = 4
			scale_Renamed.RulerStyle.BorderStyle.Width = New NLength(0)
			scale_Renamed.RulerStyle.FillStyle = New NColorFillStyle(Color.DarkGray)

			Return radialGauge
		End Function

		Private Sub knobIndicator_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
			If m_RadialGauge Is Nothing Then
				Return
			End If

			m_NumericDisplay.Value = DirectCast(m_RadialGauge.Indicators(0), NIndicator).Value
		End Sub

		Private Function CreateNumericDisplay() As NNumericDisplayPanel
			Dim numericDisplay As New NNumericDisplayPanel()
			numericDisplay.Size = New NSizeL(New NLength(0), New NLength(50, NRelativeUnit.ParentPercentage))
			numericDisplay.DockMode = PanelDockMode.Bottom
			numericDisplay.BoundsMode = BoundsMode.Fit
			numericDisplay.Margins = New NMarginsL(10, 10, 10, 10)
			numericDisplay.ContentAlignment = ContentAlignment.MiddleCenter

			Return numericDisplay
		End Function

		Private Sub UpdateKnob()
			If m_Updating Then
				Return
			End If

			Dim knob As NKnobIndicator = TryCast(m_RadialGauge.Indicators(0), NKnobIndicator)

			' update the knob marker shape
			Dim factory As New N2DSmartShapeFactory(knob.MarkerShape.FillStyle, knob.MarkerShape.StrokeStyle, knob.MarkerShape.ShadowStyle)
			knob.MarkerShape = factory.CreateShape(CType(MarkerShapeComboBox.SelectedIndex, SmartShape2D))
			knob.OffsetFromScale = New NLength(CSng(MarkerOffsetUpDown.Value), NGraphicsUnit.Point)
			knob.MarkerPaintOrder = CType(MarkerPaintOrderComboBox.SelectedIndex, KnobMarkerPaintOrder)

			' update the outer rim style
			knob.OuterRimStyle.Pattern = CType(OuterRimPatternComboBox.SelectedIndex, CircularRimPattern)
			knob.OuterRimStyle.PatternRepeatCount = CInt(Math.Truncate(OuterRimPatternRepeatCountUpDown.Value))
			knob.OuterRimStyle.Offset = New NLength(CSng(OuterRimRadiusOffsetUpDown.Value), NGraphicsUnit.Point)

			' update the inner rim style
			knob.InnerRimStyle.Pattern = CType(InnerRimPatternComboBox.SelectedIndex, CircularRimPattern)
			knob.InnerRimStyle.PatternRepeatCount = CInt(Math.Truncate(InnerRimPatternRepeatCountUpDown.Value))
			knob.InnerRimStyle.Offset = New NLength(CSng(InnerRimRadiusOffsetUpDown.Value), NGraphicsUnit.Point)

			nChartControl1.Refresh()
		End Sub

		Private Sub MarkerShapeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MarkerShapeComboBox.SelectedIndexChanged
			UpdateKnob()
		End Sub

		Private Sub InnerRimPatternComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles InnerRimPatternComboBox.SelectedIndexChanged
			UpdateKnob()
		End Sub

		Private Sub InnerRimPatternRepeatCountUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles InnerRimPatternRepeatCountUpDown.ValueChanged
			UpdateKnob()
		End Sub

		Private Sub InnerRimRadiusOffsetUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles InnerRimRadiusOffsetUpDown.ValueChanged
			UpdateKnob()
		End Sub

		Private Sub OuterRimPatternComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles OuterRimPatternComboBox.SelectedIndexChanged
			UpdateKnob()
		End Sub

		Private Sub OuterRimPatternRepeatCountUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles OuterRimPatternRepeatCountUpDown.ValueChanged
			UpdateKnob()
		End Sub

		Private Sub OuterRimRadiusOffsetUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles OuterRimRadiusOffsetUpDown.ValueChanged
			UpdateKnob()
		End Sub

		Private Sub MarkerOffsetUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MarkerOffsetUpDown.ValueChanged
			UpdateKnob()
		End Sub

		Private Sub MarkerPaintOrderComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MarkerPaintOrderComboBox.SelectedIndexChanged
			UpdateKnob()
		End Sub
	End Class
End Namespace
