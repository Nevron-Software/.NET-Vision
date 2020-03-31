Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NGaugeBackgroundAdornerUC
		Inherits NExampleBaseUC

		Private m_RadialGauge As NRadialGaugePanel
		Private m_LinearGauge As NLinearGaugePanel
		Private WithEvents AdornerShapeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As Label
		Private GelEffectGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents BottomMarginUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label11 As Label
		Private WithEvents RightMarginUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label10 As Label
		Private WithEvents TopMarginUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label9 As Label
		Private WithEvents LeftMarginUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label8 As Label
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents LinearGaugeOrientationComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label5 As Label

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
			Me.AdornerShapeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.GelEffectGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.BottomMarginUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label11 = New System.Windows.Forms.Label()
			Me.RightMarginUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label10 = New System.Windows.Forms.Label()
			Me.TopMarginUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label9 = New System.Windows.Forms.Label()
			Me.LeftMarginUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label8 = New System.Windows.Forms.Label()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.LinearGaugeOrientationComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.GelEffectGroupBox.SuspendLayout()
			DirectCast(Me.BottomMarginUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.RightMarginUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.TopMarginUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.LeftMarginUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' AdornerShapeComboBox
			' 
			Me.AdornerShapeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.AdornerShapeComboBox.ListProperties.DataSource = Nothing
			Me.AdornerShapeComboBox.ListProperties.DisplayMember = ""
			Me.AdornerShapeComboBox.Location = New System.Drawing.Point(9, 27)
			Me.AdornerShapeComboBox.Name = "AdornerShapeComboBox"
			Me.AdornerShapeComboBox.Size = New System.Drawing.Size(159, 21)
			Me.AdornerShapeComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AdornerShapeComboBox.SelectedIndexChanged += new System.EventHandler(this.PaintEffectComboBox_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(9, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(41, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Shape:"
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
			Me.GelEffectGroupBox.Location = New System.Drawing.Point(9, 64)
			Me.GelEffectGroupBox.Name = "GelEffectGroupBox"
			Me.GelEffectGroupBox.Size = New System.Drawing.Size(183, 155)
			Me.GelEffectGroupBox.TabIndex = 6
			Me.GelEffectGroupBox.TabStop = False
			Me.GelEffectGroupBox.Text = "Margins"
			' 
			' BottomMarginUpDown
			' 
			Me.BottomMarginUpDown.Location = New System.Drawing.Point(107, 97)
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
			Me.RightMarginUpDown.Location = New System.Drawing.Point(107, 71)
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
			Me.TopMarginUpDown.Location = New System.Drawing.Point(107, 45)
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
			Me.LeftMarginUpDown.Location = New System.Drawing.Point(107, 19)
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
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.LinearGaugeOrientationComboBox)
			Me.groupBox2.Controls.Add(Me.label5)
			Me.groupBox2.Location = New System.Drawing.Point(9, 241)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(183, 72)
			Me.groupBox2.TabIndex = 8
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
			Me.LinearGaugeOrientationComboBox.Size = New System.Drawing.Size(146, 21)
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
			' NGaugeBackgroundAdornerUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.GelEffectGroupBox)
			Me.Controls.Add(Me.AdornerShapeComboBox)
			Me.Controls.Add(Me.label1)
			Me.Name = "NGaugeBackgroundAdornerUC"
			Me.Size = New System.Drawing.Size(180, 554)
			Me.GelEffectGroupBox.ResumeLayout(False)
			Me.GelEffectGroupBox.PerformLayout()
			DirectCast(Me.BottomMarginUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.RightMarginUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.TopMarginUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.LeftMarginUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox2.ResumeLayout(False)
			Me.groupBox2.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Gauge Background Adorner")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' create the radial gauge
			CreateRadialGauge()

			' create the linear gauge
			CreateLinearGauge()

			' update form controls
			AdornerShapeComboBox.FillFromEnum(GetType(GaugeBackroundAdornerShape))
			AdornerShapeComboBox.SelectedIndex = 0

			LeftMarginUpDown.Value = 0
			TopMarginUpDown.Value = 55
			RightMarginUpDown.Value = 0
			BottomMarginUpDown.Value = 0

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

		Private Function CreateBackgroundAdorner() As NGaugeBackgroundAdorner
			Dim shape As GaugeBackroundAdornerShape = CType(AdornerShapeComboBox.SelectedIndex, GaugeBackroundAdornerShape)
			Dim margins As New NMarginsL(New NLength(CSng(LeftMarginUpDown.Value), NRelativeUnit.ParentPercentage), New NLength(CSng(TopMarginUpDown.Value), NRelativeUnit.ParentPercentage), New NLength(CSng(RightMarginUpDown.Value), NRelativeUnit.ParentPercentage), New NLength(CSng(BottomMarginUpDown.Value), NRelativeUnit.ParentPercentage))

			Dim adorner As New NGaugeBackgroundAdorner()
			adorner.FillStyle = New NGradientFillStyle(Color.FromArgb(0, Color.Black), Color.FromArgb(120, Color.LightGreen))
			adorner.Shape = shape
			adorner.Margins = margins

			Return adorner
		End Function

		Private Sub UpdateEffects()
			If m_LinearGauge Is Nothing OrElse m_RadialGauge Is Nothing Then
				Return
			End If

			m_LinearGauge.BackgroundAdorner = CreateBackgroundAdorner()
			m_RadialGauge.BackgroundAdorner = CreateBackgroundAdorner()

			nChartControl1.Refresh()
		End Sub

		Private Sub CreateRadialGauge()
			' create the radial gauge
			m_RadialGauge = New NRadialGaugePanel()
			nChartControl1.Panels.Add(m_RadialGauge)

			' create the radial gauge
			m_RadialGauge.BeginAngle = -225
			m_RadialGauge.SweepAngle = 270

			' set some background
			m_RadialGauge.BackgroundFillStyle = New NColorFillStyle(Color.Black)
			m_RadialGauge.PaintEffect = New NGlassEffectStyle()
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

			LinearGaugeOrientationComboBox.SelectedIndex = 0
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
			rangeIndicator.PaintOrder = IndicatorPaintOrder.AfterScale

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

		Private Sub PaintEffectComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AdornerShapeComboBox.SelectedIndexChanged
			UpdateEffects()
		End Sub

		Private Sub PaintEffectShapeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			UpdateEffects()
		End Sub

		Private Sub DirectionUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
			UpdateEffects()
		End Sub

		Private Sub SpreadUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
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
