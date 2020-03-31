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
	Public Class NIndicatorValueDampeningUC
		Inherits NExampleBaseUC

		Private m_Angle As Double
		Private rand As New Random()
		Private m_RadialGauge As NRadialGaugePanel
		Private m_NumericDisplay As NNumericDisplayPanel
		Private m_Indicator1 As NRangeIndicator
		Private m_Indicator2 As NNeedleValueIndicator
		Private WithEvents m_Timer As System.Windows.Forms.Timer
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private WithEvents DampeningIntervalUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents DampeningStepsUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents StartStopTimerButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents EnableValueDampeningCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private nNumericUpDown1 As Nevron.UI.WinForm.Controls.NNumericUpDown

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
			Me.components = New System.ComponentModel.Container()
			Me.m_Timer = New System.Windows.Forms.Timer(Me.components)
			Me.DampeningIntervalUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label3 = New System.Windows.Forms.Label()
			Me.DampeningStepsUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label1 = New System.Windows.Forms.Label()
			Me.StartStopTimerButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.EnableValueDampeningCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nNumericUpDown1 = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			DirectCast(Me.DampeningIntervalUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.DampeningStepsUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.nNumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' timer1
			' 
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_Timer.Tick += new System.EventHandler(this.timer1_Tick);
			' 
			' DampeningIntervalUpDown
			' 
			Me.DampeningIntervalUpDown.Location = New System.Drawing.Point(115, 38)
			Me.DampeningIntervalUpDown.Maximum = New Decimal(New Integer() { 1000, 0, 0, 0})
			Me.DampeningIntervalUpDown.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.DampeningIntervalUpDown.Name = "DampeningIntervalUpDown"
			Me.DampeningIntervalUpDown.Size = New System.Drawing.Size(57, 20)
			Me.DampeningIntervalUpDown.TabIndex = 31
			Me.DampeningIntervalUpDown.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DampeningIntervalUpDown.ValueChanged += new System.EventHandler(this.DampeningIntervalUpDown_ValueChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 42)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(55, 16)
			Me.label3.TabIndex = 30
			Me.label3.Text = "Interval:"
			' 
			' DampeningStepsUpDown
			' 
			Me.DampeningStepsUpDown.Location = New System.Drawing.Point(115, 64)
			Me.DampeningStepsUpDown.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.DampeningStepsUpDown.Name = "DampeningStepsUpDown"
			Me.DampeningStepsUpDown.Size = New System.Drawing.Size(57, 20)
			Me.DampeningStepsUpDown.TabIndex = 33
			Me.DampeningStepsUpDown.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DampeningStepsUpDown.ValueChanged += new System.EventHandler(this.DampeningStepsUpDown_ValueChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 68)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(55, 16)
			Me.label1.TabIndex = 32
			Me.label1.Text = "Steps:"
			' 
			' StartStopTimerButton
			' 
			Me.StartStopTimerButton.Location = New System.Drawing.Point(11, 141)
			Me.StartStopTimerButton.Name = "StartStopTimerButton"
			Me.StartStopTimerButton.Size = New System.Drawing.Size(161, 23)
			Me.StartStopTimerButton.TabIndex = 34
			Me.StartStopTimerButton.Text = "Stop Timer"
			Me.StartStopTimerButton.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StartStopTimerButton.Click += new System.EventHandler(this.StartStopTimerButton_Click);
			' 
			' EnableValueDampeningCheckBox
			' 
			Me.EnableValueDampeningCheckBox.ButtonProperties.BorderOffset = 2
			Me.EnableValueDampeningCheckBox.Location = New System.Drawing.Point(8, 10)
			Me.EnableValueDampeningCheckBox.Name = "EnableValueDampeningCheckBox"
			Me.EnableValueDampeningCheckBox.Size = New System.Drawing.Size(151, 23)
			Me.EnableValueDampeningCheckBox.TabIndex = 35
			Me.EnableValueDampeningCheckBox.Text = "Enable Value Dampening"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableValueDampeningCheckBox.CheckedChanged += new System.EventHandler(this.EnableValueDampeningCheckBox_CheckedChanged);
			' 
			' nNumericUpDown1
			' 
			Me.nNumericUpDown1.Location = New System.Drawing.Point(116, 115)
			Me.nNumericUpDown1.Maximum = New Decimal(New Integer() { 1000, 0, 0, 0})
			Me.nNumericUpDown1.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.nNumericUpDown1.Name = "nNumericUpDown1"
			Me.nNumericUpDown1.Size = New System.Drawing.Size(57, 20)
			Me.nNumericUpDown1.TabIndex = 37
			Me.nNumericUpDown1.Value = New Decimal(New Integer() { 1, 0, 0, 0})
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(9, 119)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(88, 16)
			Me.label2.TabIndex = 36
			Me.label2.Text = "Timer Interval:"
			' 
			' NIndicatorValueDampeningUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.nNumericUpDown1)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.EnableValueDampeningCheckBox)
			Me.Controls.Add(Me.StartStopTimerButton)
			Me.Controls.Add(Me.DampeningStepsUpDown)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.DampeningIntervalUpDown)
			Me.Controls.Add(Me.label3)
			Me.Name = "NIndicatorValueDampeningUC"
			Me.Size = New System.Drawing.Size(180, 251)
			DirectCast(Me.DampeningIntervalUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.DampeningStepsUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.nNumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As New NLabel("Gauge Indicator Value Dampening")
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
			scale_Renamed.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0)
			scale_Renamed.MinorTickCount = 4
			scale_Renamed.RulerStyle.BorderStyle.Width = New NLength(0)
			scale_Renamed.RulerStyle.FillStyle = New NColorFillStyle(Color.DarkGray)

			' add radial gauge indicators
			m_Indicator1 = New NRangeIndicator()
			m_Indicator1.Value = 20
			m_Indicator1.FillStyle = New NGradientFillStyle(Color.Yellow, Color.Red)
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
			EnableValueDampeningCheckBox.Checked = True
			DampeningIntervalUpDown.Value = 50
			DampeningStepsUpDown.Value = 10


			m_Timer.Interval = 200
			m_Timer.Start()
		End Sub

		Private Sub UpdateIndicators()
			If m_Indicator1 IsNot Nothing Then
				m_Indicator1.EnableDampening = EnableValueDampeningCheckBox.Checked
				m_Indicator1.DampeningInterval = CInt(Math.Truncate(DampeningIntervalUpDown.Value))
				m_Indicator1.DampeningSteps = CInt(Math.Truncate(DampeningStepsUpDown.Value))
			End If

			If m_Indicator2 IsNot Nothing Then
				m_Indicator2.EnableDampening = EnableValueDampeningCheckBox.Checked
				m_Indicator2.DampeningInterval = CInt(Math.Truncate(DampeningIntervalUpDown.Value))
				m_Indicator2.DampeningSteps = CInt(Math.Truncate(DampeningStepsUpDown.Value))
				m_Indicator2.Value = 20 + Math.Sin(m_Angle) + rand.Next(40)
			End If
		End Sub

		Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles m_Timer.Tick
			m_Angle += Math.PI / 180.0

			m_Indicator1.Value = 50 + Math.Sin(m_Angle) * (20 + rand.Next(30))
			m_NumericDisplay.Value = m_Indicator1.Value
			m_Indicator2.Value = 50 + Math.Sin(m_Angle) * (30 + rand.Next(20))

			nChartControl1.Refresh()
		End Sub

		Private Sub StartStopTimerButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StartStopTimerButton.Click
			If m_Timer.Enabled Then
				StartStopTimerButton.Text = "Start Timer"
				m_Timer.Stop()
			Else
				StartStopTimerButton.Text = "Stop Timer"
				m_Timer.Start()
			End If
		End Sub

		Private Sub DampeningIntervalUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DampeningIntervalUpDown.ValueChanged
			UpdateIndicators()
		End Sub

		Private Sub DampeningStepsUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DampeningStepsUpDown.ValueChanged
			UpdateIndicators()
		End Sub

		Private Sub EnableValueDampeningCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles EnableValueDampeningCheckBox.CheckedChanged
			UpdateIndicators()
		End Sub
	End Class
End Namespace
