Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Diagnostics
Imports System.Text
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NPolarValueAxisPositionUC
		Inherits NExampleBaseUC

		Private m_CustomAxisId As Integer
		Private RedAxisBeginUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents RadianAngleStepComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label2 As Label
		Private label1 As Label
		Private WithEvents RedAxisAngleUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label3 As Label
		Private WithEvents RedEndUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label4 As Label
		Private label5 As Label
		Private label6 As Label
		Private WithEvents GreenAxisAngleUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents RedBeginUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents GreenBeginUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label8 As Label
		Private WithEvents GreenEndUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label7 As Label
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents BeginAngleUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents DockGreenAxisCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents GreenAxisReflectionPaintCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents RedAxisPaintReflectionCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents DockRedAxisCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
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
			Me.RedAxisBeginUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.RadianAngleStepComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.RedAxisAngleUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label3 = New System.Windows.Forms.Label()
			Me.RedEndUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.GreenAxisAngleUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.RedBeginUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.GreenBeginUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label8 = New System.Windows.Forms.Label()
			Me.GreenEndUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label7 = New System.Windows.Forms.Label()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.DockRedAxisCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.RedAxisPaintReflectionCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.GreenAxisReflectionPaintCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.DockGreenAxisCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.BeginAngleUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			DirectCast(Me.RedAxisBeginUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.RedAxisAngleUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.RedEndUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.GreenAxisAngleUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.RedBeginUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.GreenBeginUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.GreenEndUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nGroupBox1.SuspendLayout()
			Me.nGroupBox2.SuspendLayout()
			DirectCast(Me.BeginAngleUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' RedAxisBeginUpDown
			' 
			Me.RedAxisBeginUpDown.Location = New System.Drawing.Point(76, 57)
			Me.RedAxisBeginUpDown.Maximum = New Decimal(New Integer() { 360, 0, 0, 0})
			Me.RedAxisBeginUpDown.Minimum = New Decimal(New Integer() { 360, 0, 0, -2147483648})
			Me.RedAxisBeginUpDown.Name = "RedAxisBeginUpDown"
			Me.RedAxisBeginUpDown.Size = New System.Drawing.Size(85, 20)
			Me.RedAxisBeginUpDown.TabIndex = 37
			' 
			' RadianAngleStepComboBox
			' 
			Me.RadianAngleStepComboBox.ListProperties.CheckBoxDataMember = ""
			Me.RadianAngleStepComboBox.ListProperties.DataSource = Nothing
			Me.RadianAngleStepComboBox.ListProperties.DisplayMember = ""
			Me.RadianAngleStepComboBox.Location = New System.Drawing.Point(10, 77)
			Me.RadianAngleStepComboBox.Name = "RadianAngleStepComboBox"
			Me.RadianAngleStepComboBox.Size = New System.Drawing.Size(165, 21)
			Me.RadianAngleStepComboBox.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RadianAngleStepComboBox.SelectedIndexChanged += new System.EventHandler(this.RadianAngleStepComboBox_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(10, 59)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(162, 16)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Radian Angle Step:"
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(10, 9)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(162, 17)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Begin Angle:"
			' 
			' RedAxisAngleUpDown
			' 
			Me.RedAxisAngleUpDown.Location = New System.Drawing.Point(92, 44)
			Me.RedAxisAngleUpDown.Maximum = New Decimal(New Integer() { 360, 0, 0, 0})
			Me.RedAxisAngleUpDown.Minimum = New Decimal(New Integer() { 360, 0, 0, -2147483648})
			Me.RedAxisAngleUpDown.Name = "RedAxisAngleUpDown"
			Me.RedAxisAngleUpDown.Size = New System.Drawing.Size(73, 20)
			Me.RedAxisAngleUpDown.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RedAxisAngleUpDown.ValueChanged += new System.EventHandler(this.RedAxisAngleUpDown_ValueChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 47)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(71, 17)
			Me.label3.TabIndex = 1
			Me.label3.Text = "Angle:"
			' 
			' RedEndUpDown
			' 
			Me.RedEndUpDown.Location = New System.Drawing.Point(92, 133)
			Me.RedEndUpDown.Name = "RedEndUpDown"
			Me.RedEndUpDown.Size = New System.Drawing.Size(73, 20)
			Me.RedEndUpDown.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RedEndUpDown.ValueChanged += new System.EventHandler(this.RedEndUpDown_ValueChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 112)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(84, 17)
			Me.label4.TabIndex = 4
			Me.label4.Text = "Begin Percent:"
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(8, 136)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(71, 17)
			Me.label5.TabIndex = 6
			Me.label5.Text = "End Percent:"
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(8, 46)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(71, 17)
			Me.label6.TabIndex = 1
			Me.label6.Text = "Angle:"
			' 
			' GreenAxisAngleUpDown
			' 
			Me.GreenAxisAngleUpDown.Location = New System.Drawing.Point(92, 43)
			Me.GreenAxisAngleUpDown.Maximum = New Decimal(New Integer() { 360, 0, 0, 0})
			Me.GreenAxisAngleUpDown.Minimum = New Decimal(New Integer() { 360, 0, 0, -2147483648})
			Me.GreenAxisAngleUpDown.Name = "GreenAxisAngleUpDown"
			Me.GreenAxisAngleUpDown.Size = New System.Drawing.Size(73, 20)
			Me.GreenAxisAngleUpDown.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GreenAxisAngleUpDown.ValueChanged += new System.EventHandler(this.GreenAxisAngleUpDown_ValueChanged);
			' 
			' RedBeginUpDown
			' 
			Me.RedBeginUpDown.Location = New System.Drawing.Point(92, 109)
			Me.RedBeginUpDown.Name = "RedBeginUpDown"
			Me.RedBeginUpDown.Size = New System.Drawing.Size(73, 20)
			Me.RedBeginUpDown.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RedBeginUpDown.ValueChanged += new System.EventHandler(this.RedBeginUpDown_ValueChanged);
			' 
			' GreenBeginUpDown
			' 
			Me.GreenBeginUpDown.Location = New System.Drawing.Point(92, 97)
			Me.GreenBeginUpDown.Name = "GreenBeginUpDown"
			Me.GreenBeginUpDown.Size = New System.Drawing.Size(73, 20)
			Me.GreenBeginUpDown.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GreenBeginUpDown.ValueChanged += new System.EventHandler(this.GreenBeginUpDown_ValueChanged);
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(8, 124)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(71, 17)
			Me.label8.TabIndex = 6
			Me.label8.Text = "End Percent:"
			' 
			' GreenEndUpDown
			' 
			Me.GreenEndUpDown.Location = New System.Drawing.Point(92, 121)
			Me.GreenEndUpDown.Name = "GreenEndUpDown"
			Me.GreenEndUpDown.Size = New System.Drawing.Size(73, 20)
			Me.GreenEndUpDown.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GreenEndUpDown.ValueChanged += new System.EventHandler(this.GreenEndUpDown_ValueChanged);
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(8, 100)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(84, 17)
			Me.label7.TabIndex = 4
			Me.label7.Text = "Begin Percent:"
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.DockRedAxisCheckBox)
			Me.nGroupBox1.Controls.Add(Me.RedAxisPaintReflectionCheckBox)
			Me.nGroupBox1.Controls.Add(Me.RedEndUpDown)
			Me.nGroupBox1.Controls.Add(Me.label3)
			Me.nGroupBox1.Controls.Add(Me.RedAxisAngleUpDown)
			Me.nGroupBox1.Controls.Add(Me.label4)
			Me.nGroupBox1.Controls.Add(Me.label5)
			Me.nGroupBox1.Controls.Add(Me.RedBeginUpDown)
			Me.nGroupBox1.Location = New System.Drawing.Point(10, 116)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(170, 162)
			Me.nGroupBox1.TabIndex = 4
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Red Axis"
			' 
			' DockRedAxisCheckBox
			' 
			Me.DockRedAxisCheckBox.ButtonProperties.BorderOffset = 2
			Me.DockRedAxisCheckBox.Location = New System.Drawing.Point(11, 19)
			Me.DockRedAxisCheckBox.Name = "DockRedAxisCheckBox"
			Me.DockRedAxisCheckBox.Size = New System.Drawing.Size(150, 24)
			Me.DockRedAxisCheckBox.TabIndex = 0
			Me.DockRedAxisCheckBox.Text = "Dock Bottom"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DockRedAxisCheckBox.CheckedChanged += new System.EventHandler(this.DockRedAxisCheckBox_CheckedChanged);
			' 
			' RedAxisPaintReflectionCheckBox
			' 
			Me.RedAxisPaintReflectionCheckBox.ButtonProperties.BorderOffset = 2
			Me.RedAxisPaintReflectionCheckBox.Location = New System.Drawing.Point(11, 79)
			Me.RedAxisPaintReflectionCheckBox.Name = "RedAxisPaintReflectionCheckBox"
			Me.RedAxisPaintReflectionCheckBox.Size = New System.Drawing.Size(150, 24)
			Me.RedAxisPaintReflectionCheckBox.TabIndex = 3
			Me.RedAxisPaintReflectionCheckBox.Text = "Paint Reflection"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RedAxisPaintReflectionCheckBox.CheckedChanged += new System.EventHandler(this.RedAxisPaintReflectionCheckBox_CheckedChanged);
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Controls.Add(Me.GreenAxisReflectionPaintCheckBox)
			Me.nGroupBox2.Controls.Add(Me.DockGreenAxisCheckBox)
			Me.nGroupBox2.Controls.Add(Me.GreenEndUpDown)
			Me.nGroupBox2.Controls.Add(Me.label6)
			Me.nGroupBox2.Controls.Add(Me.GreenAxisAngleUpDown)
			Me.nGroupBox2.Controls.Add(Me.GreenBeginUpDown)
			Me.nGroupBox2.Controls.Add(Me.label7)
			Me.nGroupBox2.Controls.Add(Me.label8)
			Me.nGroupBox2.Location = New System.Drawing.Point(10, 284)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(170, 187)
			Me.nGroupBox2.TabIndex = 5
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "Green Axis"
			' 
			' GreenAxisReflectionPaintCheckBox
			' 
			Me.GreenAxisReflectionPaintCheckBox.ButtonProperties.BorderOffset = 2
			Me.GreenAxisReflectionPaintCheckBox.Location = New System.Drawing.Point(11, 71)
			Me.GreenAxisReflectionPaintCheckBox.Name = "GreenAxisReflectionPaintCheckBox"
			Me.GreenAxisReflectionPaintCheckBox.Size = New System.Drawing.Size(150, 24)
			Me.GreenAxisReflectionPaintCheckBox.TabIndex = 3
			Me.GreenAxisReflectionPaintCheckBox.Text = "Paint Reflection"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GreenAxisReflectionPaintCheckBox.CheckedChanged += new System.EventHandler(this.GreenAxisPaintReflectionCheckBox_CheckedChanged);
			' 
			' DockGreenAxisCheckBox
			' 
			Me.DockGreenAxisCheckBox.ButtonProperties.BorderOffset = 2
			Me.DockGreenAxisCheckBox.Location = New System.Drawing.Point(11, 19)
			Me.DockGreenAxisCheckBox.Name = "DockGreenAxisCheckBox"
			Me.DockGreenAxisCheckBox.Size = New System.Drawing.Size(150, 24)
			Me.DockGreenAxisCheckBox.TabIndex = 0
			Me.DockGreenAxisCheckBox.Text = "Dock Left"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DockGreenAxisCheckBox.CheckedChanged += new System.EventHandler(this.DockBlueAxisCheckBox_CheckedChanged);
			' 
			' BeginAngleUpDown
			' 
			Me.BeginAngleUpDown.Location = New System.Drawing.Point(10, 29)
			Me.BeginAngleUpDown.Maximum = New Decimal(New Integer() { 360, 0, 0, 0})
			Me.BeginAngleUpDown.Minimum = New Decimal(New Integer() { 360, 0, 0, -2147483648})
			Me.BeginAngleUpDown.Name = "BeginAngleUpDown"
			Me.BeginAngleUpDown.Size = New System.Drawing.Size(165, 20)
			Me.BeginAngleUpDown.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BeginAngleUpDown.ValueChanged += new System.EventHandler(this.BeginAngleUpDown_ValueChanged);
			' 
			' NPolarValueAxisPositionUC
			' 
			Me.Controls.Add(Me.BeginAngleUpDown)
			Me.Controls.Add(Me.nGroupBox2)
			Me.Controls.Add(Me.nGroupBox1)
			Me.Controls.Add(Me.RadianAngleStepComboBox)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Name = "NPolarValueAxisPositionUC"
			Me.Size = New System.Drawing.Size(180, 514)
			DirectCast(Me.RedAxisBeginUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.RedAxisAngleUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.RedEndUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.GreenAxisAngleUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.RedBeginUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.GreenBeginUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.GreenEndUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nGroupBox1.ResumeLayout(False)
			Me.nGroupBox2.ResumeLayout(False)
			DirectCast(Me.BeginAngleUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Polar Value Axis Position")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			Dim polar As New NPolarChart()
			polar.InnerRadius = New NLength(20)
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(polar)
			polar.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			polar.DisplayOnLegend = nChartControl1.Legends(0)

			' setup polar axis
			Dim linearScale As NLinearScaleConfigurator = CType(polar.Axis(StandardAxis.Polar).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.RoundToTickMax = True
			linearScale.RoundToTickMin = True
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			' setup polar angle axis
			Dim angularScale As NAngularScaleConfigurator = CType(polar.Axis(StandardAxis.PolarAngle).ScaleConfigurator, NAngularScaleConfigurator)
			angularScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, True)
			angularScale.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0)
			Dim strip As New NScaleStripStyle()
			strip.FillStyle = New NColorFillStyle(Color.FromArgb(125, 192, 192, 192))
			strip.Interlaced = True
			strip.SetShowAtWall(ChartWallType.Polar, True)
			angularScale.StripStyles.Add(strip)

			' add a const line
			Dim line As NAxisConstLine = polar.Axis(StandardAxis.Polar).ConstLines.Add()
			line.Value = 50
			line.StrokeStyle.Color = Color.SlateBlue
			line.StrokeStyle.Width = New NLength(1, NGraphicsUnit.Pixel)

			' create a polar line series
			Dim series1 As New NPolarLineSeries()
			polar.Series.Add(series1)
			series1.Name = "Series 1"
			series1.CloseContour = True
			series1.DataLabelStyle.Visible = False
			series1.MarkerStyle.Visible = False
			series1.MarkerStyle.Width = New NLength(1, NRelativeUnit.ParentPercentage)
			series1.MarkerStyle.Height = New NLength(1, NRelativeUnit.ParentPercentage)
			Curve1(series1, 50)

			' create a polar line series
			Dim series2 As New NPolarLineSeries()
			polar.Series.Add(series2)
			series2.Name = "Series 2"
			series2.CloseContour = True
			series2.DataLabelStyle.Visible = False
			series2.MarkerStyle.Visible = False
			series2.MarkerStyle.Width = New NLength(1, NRelativeUnit.ParentPercentage)
			series2.MarkerStyle.Height = New NLength(1, NRelativeUnit.ParentPercentage)
			Curve2(series2, 100)

			' add a second value axes
			Dim primaryAxis As NPolarAxis = CType(polar.Axis(StandardAxis.Polar), NPolarAxis)
			Dim secondaryAxis As NPolarAxis = CType(polar.Axes, NPolarAxisCollection).AddCustomAxis(PolarAxisOrientation.Value)
			m_CustomAxisId = secondaryAxis.AxisId

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' color code the axes and series after the stylesheet is applied
			ApplyColorToAxis(primaryAxis, Color.Red)
			ApplyColorToAxis(secondaryAxis, Color.Green)

			series1.BorderStyle.Color = Color.DarkRed
			series1.BorderStyle.Width = New NLength(2)

			series2.BorderStyle.Color = Color.DarkGreen
			series2.BorderStyle.Width = New NLength(2)

			series2.DisplayOnAxis(StandardAxis.Polar, False)
			series2.DisplayOnAxis(m_CustomAxisId, True)

			' init form controls
			RadianAngleStepComboBox.Items.Add("15")
			RadianAngleStepComboBox.Items.Add("30")
			RadianAngleStepComboBox.Items.Add("45")
			RadianAngleStepComboBox.Items.Add("90")
			RadianAngleStepComboBox.SelectedIndex = 0

			RedAxisAngleUpDown.Value = CDec(0)
			RedBeginUpDown.Value = CDec(0)
			RedEndUpDown.Value = CDec(100)

			GreenAxisAngleUpDown.Value = CDec(90)
			GreenBeginUpDown.Value = CDec(0)
			GreenEndUpDown.Value = CDec(100)
		End Sub

		Private Sub ApplyColorToAxis(ByVal axis As NAxis, ByVal color As Color)
			Dim linearScale As NLinearScaleConfigurator = CType(axis.ScaleConfigurator, NLinearScaleConfigurator)

			linearScale.RulerStyle.BorderStyle.Color = color
			linearScale.OuterMajorTickStyle.LineStyle.Color = color
			linearScale.OuterMinorTickStyle.LineStyle.Color = color
			linearScale.InnerMajorTickStyle.LineStyle.Color = color
			linearScale.InnerMinorTickStyle.LineStyle.Color = color
			linearScale.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(color)

			axis.InvalidateScale()
		End Sub

		Private Sub UpdateAxes()
			Dim polarChart As NPolarChart = TryCast(nChartControl1.Charts(0), NPolarChart)
			If polarChart Is Nothing Then
				Return
			End If

			Dim angleAxis As NAxis = polarChart.Axis(StandardAxis.PolarAngle)

			' configure the red axis
			Dim redAxis As NAxis = polarChart.Axis(StandardAxis.Polar)
			Dim redAnchor As NPolarAxisAnchor

			RedAxisAngleUpDown.Enabled = Not DockRedAxisCheckBox.Checked

			If DockRedAxisCheckBox.Checked Then
				redAnchor = New NDockPolarAxisAnchor(PolarAxisDockZone.Bottom)
				RedAxisAngleUpDown.Enabled = False
			Else
				Dim crossAnchor As New NCrossPolarAxisAnchor()
				crossAnchor.Crossings.Add(New NValueAxisCrossing(angleAxis, CSng(RedAxisAngleUpDown.Value)))
				redAnchor = crossAnchor
			End If

			redAnchor.PaintReflection = RedAxisPaintReflectionCheckBox.Checked
			redAnchor.BeginPercent = CSng(RedBeginUpDown.Value)
			redAnchor.EndPercent = CSng(RedEndUpDown.Value)

			redAxis.Anchor = redAnchor

			' configure the green axis
			Dim greenAxis As NAxis = polarChart.Axis(m_CustomAxisId)
			Dim greenAnchor As NPolarAxisAnchor

			GreenAxisAngleUpDown.Enabled = Not DockGreenAxisCheckBox.Checked
			If DockGreenAxisCheckBox.Checked Then
				Dim dockAnchor As New NDockPolarAxisAnchor(PolarAxisDockZone.Left)
				greenAnchor = dockAnchor
			Else
				Dim crossAnchor As New NCrossPolarAxisAnchor()
				crossAnchor.Crossings.Add(New NValueAxisCrossing(angleAxis, CSng(GreenAxisAngleUpDown.Value)))
				greenAnchor = crossAnchor
			End If

			greenAnchor.PaintReflection = GreenAxisReflectionPaintCheckBox.Checked
			greenAnchor.BeginPercent = CSng(GreenBeginUpDown.Value)
			greenAnchor.EndPercent = CSng(GreenEndUpDown.Value)
			greenAxis.Anchor = greenAnchor

			nChartControl1.Refresh()
		End Sub

		Friend Shared Sub Curve1(ByVal series As NPolarSeries, ByVal count As Integer)
			series.Values.Clear()
			series.Angles.Clear()

			Dim angleStep As Double = 2 * Math.PI / count

			For i As Integer = 0 To count - 1
				Dim angle As Double = i * angleStep
				Dim radius As Double = 1 + Math.Cos(angle)

				series.Values.Add(radius)
				series.Angles.Add(angle * 180 / Math.PI)
			Next i
		End Sub

		Friend Shared Sub Curve2(ByVal series As NPolarSeries, ByVal count As Integer)
			series.Values.Clear()
			series.Angles.Clear()

			Dim angleStep As Double = 2 * Math.PI / count

			For i As Integer = 0 To count - 1
				Dim angle As Double = i * angleStep
				Dim radius As Double = 0.2 + 1.7 * Math.Sin(2 * angle) + 1.7 * Math.Cos(2 * angle)

				radius = Math.Abs(radius)

				series.Values.Add(radius)
				series.Angles.Add(angle * 180 / Math.PI)
			Next i
		End Sub

		Private Sub BeginAngleUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BeginAngleUpDown.ValueChanged
			Dim polarChart As NPolarChart = TryCast(nChartControl1.Charts(0), NPolarChart)
			If polarChart IsNot Nothing Then
				polarChart.BeginAngle = CSng(BeginAngleUpDown.Value)
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub RadianAngleStepComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadianAngleStepComboBox.SelectedIndexChanged
			Dim polarChart As NPolarChart = TryCast(nChartControl1.Charts(0), NPolarChart)
			If polarChart Is Nothing Then
				Return
			End If

			Dim angleScale As NAngularScaleConfigurator = TryCast(polarChart.Axis(StandardAxis.PolarAngle).ScaleConfigurator, NAngularScaleConfigurator)

			Select Case RadianAngleStepComboBox.SelectedIndex
				Case 0
					angleScale.MajorTickMode = MajorTickMode.CustomStep
					angleScale.CustomStep = New NAngle(15, NAngleUnit.Degree)

				Case 1
					angleScale.MajorTickMode = MajorTickMode.CustomStep
					angleScale.CustomStep = New NAngle(30, NAngleUnit.Degree)

				Case 2
					angleScale.MajorTickMode = MajorTickMode.CustomStep
					angleScale.CustomStep = New NAngle(45, NAngleUnit.Degree)

				Case 3
					angleScale.MajorTickMode = MajorTickMode.CustomStep
					angleScale.CustomStep = New NAngle(90, NAngleUnit.Degree)

				Case Else
					Debug.Assert(False)
			End Select

			nChartControl1.Refresh()
		End Sub

		Private Sub RedAxisAngleUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RedAxisAngleUpDown.ValueChanged
			UpdateAxes()
		End Sub

		Private Sub RedBeginUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RedBeginUpDown.ValueChanged
			UpdateAxes()
		End Sub

		Private Sub RedEndUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RedEndUpDown.ValueChanged
			UpdateAxes()
		End Sub

		Private Sub GreenAxisAngleUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GreenAxisAngleUpDown.ValueChanged
			UpdateAxes()
		End Sub

		Private Sub GreenBeginUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GreenBeginUpDown.ValueChanged
			UpdateAxes()
		End Sub

		Private Sub GreenEndUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GreenEndUpDown.ValueChanged
			UpdateAxes()
		End Sub

		Private Sub DockBlueAxisCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DockGreenAxisCheckBox.CheckedChanged
			UpdateAxes()
		End Sub

		Private Sub DockRedAxisCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DockRedAxisCheckBox.CheckedChanged
			UpdateAxes()
		End Sub

		Private Sub RedAxisPaintReflectionCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RedAxisPaintReflectionCheckBox.CheckedChanged
			UpdateAxes()
		End Sub

		Private Sub GreenAxisPaintReflectionCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GreenAxisReflectionPaintCheckBox.CheckedChanged
			UpdateAxes()
		End Sub
	End Class
End Namespace
