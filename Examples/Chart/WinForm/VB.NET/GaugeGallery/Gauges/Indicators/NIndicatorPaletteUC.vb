Imports System.ComponentModel
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NIndicatorPaletteUC
		Inherits NExampleBaseUC

		Private m_Angle As Double
		Private rand As New Random()
		Private m_RadialGauge As NRadialGaugePanel
		Private m_RangeIndicator As NRangeIndicator
		Private WithEvents PaletteColorModeComboBox As UI.WinForm.Controls.NComboBox
		Private label2 As Label
		Private WithEvents EnableIndicatorPaletteCheckBox As UI.WinForm.Controls.NCheckBox
		Private m_NeedleIndicator As NNeedleValueIndicator
		Private label1 As Label
		Private WithEvents IndicatorsValueUpDown As UI.WinForm.Controls.NNumericUpDown
		Private m_Palette As NPalette

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
			Me.PaletteColorModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.EnableIndicatorPaletteCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.IndicatorsValueUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			CType(Me.IndicatorsValueUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			'
			'PaletteColorModeComboBox
			'
			Me.PaletteColorModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.PaletteColorModeComboBox.ListProperties.DataSource = Nothing
			Me.PaletteColorModeComboBox.ListProperties.DisplayMember = ""
			Me.PaletteColorModeComboBox.Location = New System.Drawing.Point(20, 102)
			Me.PaletteColorModeComboBox.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
			Me.PaletteColorModeComboBox.Name = "PaletteColorModeComboBox"
			Me.PaletteColorModeComboBox.Size = New System.Drawing.Size(302, 40)
			Me.PaletteColorModeComboBox.TabIndex = 5
			Me.PaletteColorModeComboBox.Text = "RangeIndicatorOriginModeComboBox"
			'
			'label2
			'
			Me.label2.Location = New System.Drawing.Point(20, 52)
			Me.label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(340, 44)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Palette Spread Mode:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'EnableIndicatorPaletteCheckBox
			'
			Me.EnableIndicatorPaletteCheckBox.ButtonProperties.BorderOffset = 2
			Me.EnableIndicatorPaletteCheckBox.Location = New System.Drawing.Point(20, 0)
			Me.EnableIndicatorPaletteCheckBox.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
			Me.EnableIndicatorPaletteCheckBox.Name = "EnableIndicatorPaletteCheckBox"
			Me.EnableIndicatorPaletteCheckBox.Size = New System.Drawing.Size(302, 44)
			Me.EnableIndicatorPaletteCheckBox.TabIndex = 36
			Me.EnableIndicatorPaletteCheckBox.Text = "Enable Indicator Palette"
			'
			'label1
			'
			Me.label1.Location = New System.Drawing.Point(14, 173)
			Me.label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(340, 44)
			Me.label1.TabIndex = 37
			Me.label1.Text = "Indicators Value:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'IndicatorsValueUpDown
			'
			Me.IndicatorsValueUpDown.Location = New System.Drawing.Point(26, 223)
			Me.IndicatorsValueUpDown.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
			Me.IndicatorsValueUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
			Me.IndicatorsValueUpDown.Name = "IndicatorsValueUpDown"
			Me.IndicatorsValueUpDown.Size = New System.Drawing.Size(296, 30)
			Me.IndicatorsValueUpDown.TabIndex = 38
			Me.IndicatorsValueUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
			'
			'NIndicatorPaletteUC
			'
			Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.IndicatorsValueUpDown)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.EnableIndicatorPaletteCheckBox)
			Me.Controls.Add(Me.PaletteColorModeComboBox)
			Me.Controls.Add(Me.label2)
			Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
			Me.Name = "NIndicatorPaletteUC"
			Me.Size = New System.Drawing.Size(360, 483)
			CType(Me.IndicatorsValueUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

#End Region

		Public Overrides Sub Initialize()
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As New NLabel("Gauge Indicator Palette")
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
			m_RangeIndicator = New NRangeIndicator()
			m_RangeIndicator.Value = 20
			m_RangeIndicator.FillStyle = New NGradientFillStyle(Color.Yellow, Color.Red)
			m_RangeIndicator.StrokeStyle.Color = Color.DarkBlue
			m_RangeIndicator.EndWidth = New NLength(20)
			m_RadialGauge.Indicators.Add(m_RangeIndicator)

			m_NeedleIndicator = New NNeedleValueIndicator()
			m_NeedleIndicator.Value = 79
			m_NeedleIndicator.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red)
			m_NeedleIndicator.Shape.StrokeStyle.Color = Color.Red
			m_RadialGauge.Indicators.Add(m_NeedleIndicator)
			m_RadialGauge.SweepAngle = 270

			' add radial gauge
			nChartControl1.Panels.Add(m_RadialGauge)

			m_Palette = New NPalette()
			m_Palette.SmoothPalette = True
			m_Palette.PositiveColor = Color.Green
			m_Palette.NegativeColor = Color.Red

			' Init form controls
			PaletteColorModeComboBox.FillFromEnum(GetType(PaletteColorMode))
			PaletteColorModeComboBox.SelectedIndex = CInt(PaletteColorMode.Spread)
			IndicatorsValueUpDown.Value = 50
			EnableIndicatorPaletteCheckBox.Checked = True
		End Sub

        Private Sub EnableIndicatorPaletteCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles EnableIndicatorPaletteCheckBox.CheckedChanged
            If m_NeedleIndicator Is Nothing Or m_RangeIndicator Is Nothing Then
                Return
            End If
            m_NeedleIndicator.Palette = DirectCast(m_Palette.Clone(), NPalette)
            m_RangeIndicator.Palette = DirectCast(m_Palette.Clone(), NPalette)
            nChartControl1.Refresh()
        End Sub

        Private Sub PaletteColorModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles PaletteColorModeComboBox.SelectedIndexChanged
            If m_RangeIndicator Is Nothing Then
                Return
            End If

            m_RangeIndicator.PaletteColorMode = CType(PaletteColorModeComboBox.SelectedIndex, PaletteColorMode)
            nChartControl1.Refresh()
        End Sub

        Private Sub IndicatorsValueUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles IndicatorsValueUpDown.ValueChanged
            If m_NeedleIndicator Is Nothing Or m_RangeIndicator Is Nothing Then
                Return
            End If

            m_NeedleIndicator.Value = CDbl(IndicatorsValueUpDown.Value)
            m_RangeIndicator.Value = CDbl(IndicatorsValueUpDown.Value)
            nChartControl1.Refresh()
        End Sub
	End Class
End Namespace
