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

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NGaugeAxisSectionsUC
		Inherits NExampleBaseUC

		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private WithEvents BlueSectionBeginUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents BlueSectionEndUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents RedSectionBeginUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents RedSectionEndUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents m_Timer As System.Windows.Forms.Timer
		Private WithEvents StopStartTimerButton As Nevron.UI.WinForm.Controls.NButton
		Private components As System.ComponentModel.IContainer
		Private m_FirstIndicatorAngle As Single = 0
		Private m_SecondIndicatorAngle As Single = 0

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
			Dim header As New NLabel("Gauge Axis Sections")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			nChartControl1.Panels.Add(header)

			BlueSectionBeginUpDown.Value = 0
			BlueSectionEndUpDown.Value = 20
			RedSectionBeginUpDown.Value = 80
			RedSectionEndUpDown.Value = 100

			' init form controls
			InitLinearGauge()
			InitRadialGauge()

			m_Timer.Interval = 100
			m_Timer.Start()
		End Sub

		Private Sub InitSections(ByVal gaugePanel As NGaugePanel)
			Dim axis As NGaugeAxis = DirectCast(gaugePanel.Axes(0), NGaugeAxis)
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)

			' init text style for regular labels
			scale_Renamed.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.White)
			scale_Renamed.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 10, FontStyle.Bold)

			' init ticks
			scale_Renamed.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			scale_Renamed.MinTickDistance = New NLength(20)
			scale_Renamed.MinorTickCount = 1
			scale_Renamed.SetPredefinedScaleStyle(PredefinedScaleStyle.Scientific)

			' create sections
			Dim blueSection As New NScaleSectionStyle()
			blueSection.Range = New NRange1DD(0, 20)
			blueSection.SetShowAtWall(ChartWallType.Back, True)
			blueSection.RangeFillStyle = New NColorFillStyle(Color.FromArgb(50, Color.Blue))
			blueSection.MajorGridStrokeStyle = New NStrokeStyle(Color.Blue)
			blueSection.MajorTickStrokeStyle = New NStrokeStyle(Color.DarkBlue)
			blueSection.MinorTickStrokeStyle = New NStrokeStyle(1, Color.Blue, LinePattern.Dot, 0, 2)

			Dim labelStyle As New NTextStyle()
			labelStyle.FillStyle = New NColorFillStyle(Color.Blue)
			labelStyle.FontStyle = New NFontStyle("Arial", 10, FontStyle.Bold)
			blueSection.LabelTextStyle = labelStyle

			scale_Renamed.Sections.Add(blueSection)

			Dim redSection As New NScaleSectionStyle()
			redSection.Range = New NRange1DD(80, 100)

			redSection.SetShowAtWall(ChartWallType.Back, True)
			redSection.RangeFillStyle = New NColorFillStyle(Color.FromArgb(50, Color.Red))
			redSection.MajorGridStrokeStyle = New NStrokeStyle(Color.Red)
			redSection.MajorTickStrokeStyle = New NStrokeStyle(Color.DarkRed)
			redSection.MinorTickStrokeStyle = New NStrokeStyle(1, Color.Red, LinePattern.Dot, 0, 2)

			labelStyle = New NTextStyle()
			labelStyle.FillStyle = New NColorFillStyle(Color.Red)
			labelStyle.FontStyle = New NFontStyle("Arial", 10, FontStyle.Bold)
			redSection.LabelTextStyle = labelStyle

			scale_Renamed.Sections.Add(redSection)
		End Sub

		Private Sub InitLinearGauge()
			Dim linearGauge As New NLinearGaugePanel()
			linearGauge.ContentAlignment = ContentAlignment.TopRight
			linearGauge.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(40, NRelativeUnit.ParentPercentage))
			linearGauge.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(55, NGraphicsUnit.Point))
			linearGauge.BackgroundFillStyle = New NGradientFillStyle(Color.DarkGray, Color.Black)
			linearGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.RoundedRect)
			linearGauge.PaintEffect = New NGelEffectStyle()

			nChartControl1.Panels.Add(linearGauge)

			Dim indicator1 As New NMarkerValueIndicator()
			linearGauge.Indicators.Add(indicator1)

			InitSections(linearGauge)
		End Sub

		Private Sub InitRadialGauge()
			' create the radial gauge
			Dim radialGauge As New NRadialGaugePanel()
			radialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)
			radialGauge.ContentAlignment = ContentAlignment.BottomRight
			radialGauge.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(50, NRelativeUnit.ParentPercentage))
			radialGauge.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(45, NRelativeUnit.ParentPercentage))
			radialGauge.InnerRadius = New NLength(10, NGraphicsUnit.Point)
			radialGauge.BackgroundFillStyle = New NGradientFillStyle(Color.DarkGray, Color.Black)
			radialGauge.BoundsMode = BoundsMode.Fit
			radialGauge.AutoBorder = RadialGaugeAutoBorder.RoundedOutline

			Dim glassEffect As New NGlassEffectStyle()
			glassEffect.LightDirection = 130
			glassEffect.EdgeOffset = New NLength(0)
			glassEffect.EdgeDepth = New NLength(30, NRelativeUnit.ParentPercentage)
			radialGauge.PaintEffect = glassEffect

			nChartControl1.Panels.Add(radialGauge)

			Dim indicator1 As New NNeedleValueIndicator()
			radialGauge.Indicators.Add(indicator1)
			radialGauge.SweepAngle = 180

			InitSections(radialGauge)
		End Sub

		Private Sub UpdateSections()
			For i As Integer = 0 To nChartControl1.Panels.Count - 1
				Dim panel As NGaugePanel = TryCast(nChartControl1.Panels(i), NGaugePanel)

				If panel IsNot Nothing Then
					Dim axis As NGaugeAxis = DirectCast(panel.Axes(0), NGaugeAxis)
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
					Dim scale_Renamed As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)

					If scale_Renamed.Sections.Count = 2 Then
						Dim blueSection As NScaleSectionStyle = DirectCast(scale_Renamed.Sections(0), NScaleSectionStyle)
						blueSection.Range = New NRange1DD(CDbl(BlueSectionBeginUpDown.Value), CDbl(BlueSectionEndUpDown.Value))

						Dim redSection As NScaleSectionStyle = DirectCast(scale_Renamed.Sections(1), NScaleSectionStyle)
						redSection.Range = New NRange1DD(CDbl(RedSectionBeginUpDown.Value), CDbl(RedSectionEndUpDown.Value))
					End If
				End If
			Next i

			nChartControl1.Refresh()
		End Sub

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.BlueSectionEndUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.RedSectionEndUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.RedSectionBeginUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.BlueSectionBeginUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.m_Timer = New System.Windows.Forms.Timer(Me.components)
			Me.StopStartTimerButton = New Nevron.UI.WinForm.Controls.NButton()
			DirectCast(Me.BlueSectionEndUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.RedSectionEndUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.RedSectionBeginUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.BlueSectionBeginUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(16, 16)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(100, 23)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Blue Section:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(16, 44)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(56, 16)
			Me.label2.TabIndex = 1
			Me.label2.Text = "Begin:"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(16, 68)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(56, 16)
			Me.label3.TabIndex = 2
			Me.label3.Text = "End:"
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(16, 156)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(56, 16)
			Me.label4.TabIndex = 5
			Me.label4.Text = "End:"
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(16, 132)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(56, 16)
			Me.label5.TabIndex = 4
			Me.label5.Text = "Begin:"
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(16, 104)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(100, 23)
			Me.label6.TabIndex = 3
			Me.label6.Text = "Red Section:"
			' 
			' BlueSectionEndUpDown
			' 
			Me.BlueSectionEndUpDown.Location = New System.Drawing.Point(80, 64)
			Me.BlueSectionEndUpDown.Name = "BlueSectionEndUpDown"
			Me.BlueSectionEndUpDown.Size = New System.Drawing.Size(80, 20)
			Me.BlueSectionEndUpDown.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BlueSectionEndUpDown.ValueChanged += new System.EventHandler(this.BlueSectionEndUpDown_ValueChanged);
			' 
			' RedSectionEndUpDown
			' 
			Me.RedSectionEndUpDown.Location = New System.Drawing.Point(80, 152)
			Me.RedSectionEndUpDown.Name = "RedSectionEndUpDown"
			Me.RedSectionEndUpDown.Size = New System.Drawing.Size(80, 20)
			Me.RedSectionEndUpDown.TabIndex = 9
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RedSectionEndUpDown.ValueChanged += new System.EventHandler(this.RedSectionEndUpDown_ValueChanged);
			' 
			' RedSectionBeginUpDown
			' 
			Me.RedSectionBeginUpDown.Location = New System.Drawing.Point(80, 128)
			Me.RedSectionBeginUpDown.Name = "RedSectionBeginUpDown"
			Me.RedSectionBeginUpDown.Size = New System.Drawing.Size(80, 20)
			Me.RedSectionBeginUpDown.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RedSectionBeginUpDown.ValueChanged += new System.EventHandler(this.RedSectionBeginUpDown_ValueChanged);
			' 
			' BlueSectionBeginUpDown
			' 
			Me.BlueSectionBeginUpDown.Location = New System.Drawing.Point(80, 40)
			Me.BlueSectionBeginUpDown.Name = "BlueSectionBeginUpDown"
			Me.BlueSectionBeginUpDown.Size = New System.Drawing.Size(80, 20)
			Me.BlueSectionBeginUpDown.TabIndex = 6
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BlueSectionBeginUpDown.ValueChanged += new System.EventHandler(this.BlueSectionBeginUpDown_ValueChanged);
			' 
			' timer1
			' 
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_Timer.Tick += new System.EventHandler(this.timer1_Tick);
			' 
			' StopStartTimerButton
			' 
			Me.StopStartTimerButton.Location = New System.Drawing.Point(16, 192)
			Me.StopStartTimerButton.Name = "StopStartTimerButton"
			Me.StopStartTimerButton.Size = New System.Drawing.Size(144, 23)
			Me.StopStartTimerButton.TabIndex = 10
			Me.StopStartTimerButton.Text = "Stop Timer"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StopStartTimerButton.Click += new System.EventHandler(this.StopStartTimerButton_Click);
			' 
			' NGaugeAxisSectionsUC
			' 
			Me.Controls.Add(Me.StopStartTimerButton)
			Me.Controls.Add(Me.RedSectionEndUpDown)
			Me.Controls.Add(Me.RedSectionBeginUpDown)
			Me.Controls.Add(Me.BlueSectionEndUpDown)
			Me.Controls.Add(Me.BlueSectionBeginUpDown)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Name = "NGaugeAxisSectionsUC"
			Me.Size = New System.Drawing.Size(176, 248)
			DirectCast(Me.BlueSectionEndUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.RedSectionEndUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.RedSectionBeginUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.BlueSectionBeginUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Private Sub BlueSectionBeginUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BlueSectionBeginUpDown.ValueChanged
			UpdateSections()
		End Sub

		Private Sub BlueSectionEndUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BlueSectionEndUpDown.ValueChanged
			UpdateSections()
		End Sub

		Private Sub RedSectionBeginUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RedSectionBeginUpDown.ValueChanged
			UpdateSections()
		End Sub

		Private Sub RedSectionEndUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RedSectionEndUpDown.ValueChanged
			UpdateSections()
		End Sub

		Private Sub timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_Timer.Tick
			If nChartControl1.Panels.Count < 3 Then
				Return
			End If

			' update linear gauge
			Dim panel As NGaugePanel = TryCast(nChartControl1.Panels(1), NGaugePanel)
			If panel IsNot Nothing Then
				Dim valueIndicator As NValueIndicator = DirectCast(panel.Indicators(0), NValueIndicator)
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
				Dim scale_Renamed As NStandardScaleConfigurator = CType(DirectCast(panel.Axes(0), NGaugeAxis).ScaleConfigurator, NStandardScaleConfigurator)
				Dim blueSection As NScaleSectionStyle = DirectCast(scale_Renamed.Sections(0), NScaleSectionStyle)
				Dim redSection As NScaleSectionStyle = DirectCast(scale_Renamed.Sections(1), NScaleSectionStyle)

				m_FirstIndicatorAngle += 0.02F
				valueIndicator.Value = 50 - Math.Cos(m_FirstIndicatorAngle) * 50

				If blueSection.Range.Contains(valueIndicator.Value) Then
					valueIndicator.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Blue)
					valueIndicator.Shape.StrokeStyle = New NStrokeStyle(Color.Blue)
				ElseIf redSection.Range.Contains(valueIndicator.Value) Then
					valueIndicator.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red)
					valueIndicator.Shape.StrokeStyle = New NStrokeStyle(Color.Red)
				Else
					valueIndicator.Shape.FillStyle = New NColorFillStyle(Color.LightGreen)
					valueIndicator.Shape.StrokeStyle = New NStrokeStyle(Color.DarkGreen)
				End If
			End If

			' update radial gauge
			panel = TryCast(nChartControl1.Panels(2), NGaugePanel)
			If panel IsNot Nothing Then
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
				Dim scale_Renamed As NStandardScaleConfigurator = CType(DirectCast(panel.Axes(0), NGaugeAxis).ScaleConfigurator, NStandardScaleConfigurator)
				Dim valueIndicator As NValueIndicator = DirectCast(panel.Indicators(0), NValueIndicator)
				Dim blueSection As NScaleSectionStyle = DirectCast(scale_Renamed.Sections(0), NScaleSectionStyle)
				Dim redSection As NScaleSectionStyle = DirectCast(scale_Renamed.Sections(1), NScaleSectionStyle)

				m_SecondIndicatorAngle += 0.02F
				valueIndicator.Value = 50 - Math.Cos(m_SecondIndicatorAngle) * 50

				If blueSection.Range.Contains(valueIndicator.Value) Then
					valueIndicator.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Blue)
					valueIndicator.Shape.StrokeStyle = New NStrokeStyle(Color.DarkBlue)
				ElseIf redSection.Range.Contains(valueIndicator.Value) Then
					valueIndicator.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red)
					valueIndicator.Shape.StrokeStyle = New NStrokeStyle(Color.DarkRed)
				Else
					valueIndicator.Shape.FillStyle = New NColorFillStyle(Color.LightGreen)
					valueIndicator.Shape.StrokeStyle = New NStrokeStyle(Color.DarkGreen)
				End If

				valueIndicator.Shape.StrokeStyle = New NStrokeStyle(Color.White)
			End If

			nChartControl1.Refresh()
		End Sub


		Private Sub StopStartTimerButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles StopStartTimerButton.Click
			If m_Timer.Enabled Then
				m_Timer.Enabled = False
				StopStartTimerButton.Text = "Start Timer"
			Else
				m_Timer.Enabled = True
				StopStartTimerButton.Text = "Stop Timer"
			End If
		End Sub
	End Class
End Namespace
