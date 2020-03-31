Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms
Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NDraggingIndicatorsUC
		Inherits NExampleBaseUC

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Private m_RadialIndicator1 As NRangeIndicator
		Private m_RadialIndicator2 As NNeedleValueIndicator
		Private m_RadialIndicator3 As NMarkerValueIndicator

		Private m_HorzLinearIndicator1 As NRangeIndicator
		Private m_HorzLinearIndicator2 As NMarkerValueIndicator

		Private m_VertLinearIndicator1 As NRangeIndicator
		Private m_VertLinearIndicator2 As NMarkerValueIndicator
		Private label1 As System.Windows.Forms.Label
		Private WithEvents IndicatorsSnapModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private WithEvents OriginNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents StepNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents AllowDragRangeIndicatorsCheckBox As Nevron.UI.WinForm.Controls.NCheckBox

		Public Sub New()
			' This call is required by the Windows.Forms Form Designer.
			InitializeComponent()
		End Sub

		Public Overrides Sub Initialize()
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As New NLabel("Dragging Gauge Indicators")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			nChartControl1.Panels.Add(header)

			nChartControl1.Panels.Add(CreateHorizontalLinearGauge())
			nChartControl1.Panels.Add(CreateVerticalLinearGauge())
			nChartControl1.Panels.Add(CreateRadialGauge())

			nChartControl1.Controller.Tools.Add(New NSelectorTool())
			nChartControl1.Controller.Tools.Add(New NIndicatorDragTool())

			' Init form controls
			IndicatorsSnapModeComboBox.Items.Add("None")
			IndicatorsSnapModeComboBox.Items.Add("Ruler")
			IndicatorsSnapModeComboBox.Items.Add("Major ticks")
			IndicatorsSnapModeComboBox.Items.Add("Minor ticks")
			IndicatorsSnapModeComboBox.Items.Add("Ruler Min/Max")
			IndicatorsSnapModeComboBox.Items.Add("Numeric")

			IndicatorsSnapModeComboBox.SelectedIndex = 0
			AllowDragRangeIndicatorsCheckBox_CheckedChanged(Nothing, Nothing)
		End Sub

		Private Function CreateRadialGauge() As NRadialGaugePanel
			' create the radial gauge
			Dim radialGauge As New NRadialGaugePanel()

			radialGauge.Location = New NPointL(New NLength(32, NRelativeUnit.ParentPercentage), New NLength(40, NRelativeUnit.ParentPercentage))
			radialGauge.Size = New NSizeL(New NLength(58, NRelativeUnit.ParentPercentage), New NLength(50, NRelativeUnit.ParentPercentage))
			radialGauge.BackgroundFillStyle = New NGradientFillStyle(Color.DarkGray, Color.Black)
			radialGauge.PaintEffect = New NGlassEffectStyle()
			radialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)

			' configure the axis
			Dim axis As NGaugeAxis = DirectCast(radialGauge.Axes(0), NGaugeAxis)
			ConfigureAxis(axis)

			' add some indicators
			m_RadialIndicator1 = New NRangeIndicator()
			m_RadialIndicator1.Value = 50
			m_RadialIndicator1.FillStyle = New NGradientFillStyle(Color.LightBlue, Color.DarkBlue)
			m_RadialIndicator1.StrokeStyle.Color = Color.DarkBlue
			m_RadialIndicator1.EndWidth = New NLength(20)
			radialGauge.Indicators.Add(m_RadialIndicator1)

			m_RadialIndicator2 = New NNeedleValueIndicator()
			m_RadialIndicator2.Value = 79
			m_RadialIndicator2.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red)
			m_RadialIndicator2.Shape.StrokeStyle.Color = Color.Red
			radialGauge.Indicators.Add(m_RadialIndicator2)
			radialGauge.SweepAngle = 270

			m_RadialIndicator3 = New NMarkerValueIndicator()
			m_RadialIndicator3.Value = 90
			radialGauge.Indicators.Add(m_RadialIndicator3)

			Return radialGauge
		End Function

		Private Function CreateHorizontalLinearGauge() As NLinearGaugePanel
			Dim linearGauge As New NLinearGaugePanel()

			linearGauge.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(20, NRelativeUnit.ParentPercentage))
			linearGauge.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(60, NGraphicsUnit.Point))

			linearGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.RoundedRect)
			linearGauge.BackgroundFillStyle = New NGradientFillStyle(Color.DarkGray, Color.Black)

			' add indicators
			m_HorzLinearIndicator1 = New NRangeIndicator()
			m_HorzLinearIndicator1.FillStyle = New NGradientFillStyle(Color.LightBlue, Color.DarkBlue)
			m_HorzLinearIndicator1.StrokeStyle.Color = Color.DarkBlue
			m_HorzLinearIndicator1.Value = 10
			linearGauge.Indicators.Add(m_HorzLinearIndicator1)

			m_HorzLinearIndicator2 = New NMarkerValueIndicator()
			m_HorzLinearIndicator2.Value = 50
			linearGauge.Indicators.Add(m_HorzLinearIndicator2)

			Dim axis As NGaugeAxis = DirectCast(linearGauge.Axes(0), NGaugeAxis)
			axis.Anchor = New NModelGaugeAxisAnchor()
			axis.Range = New NRange1DD(-100, 100)
			ConfigureAxis(axis)

			Return linearGauge
		End Function

		Private Function CreateVerticalLinearGauge() As NLinearGaugePanel
			Dim linearGauge As New NLinearGaugePanel()
			linearGauge.Orientation = LinearGaugeOrientation.Vertical

			linearGauge.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(40, NRelativeUnit.ParentPercentage))
			linearGauge.Size = New NSizeL(New NLength(60, NGraphicsUnit.Point), New NLength(50, NRelativeUnit.ParentPercentage))
			linearGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.RoundedRect)
			linearGauge.BackgroundFillStyle = New NGradientFillStyle(Color.DarkGray, Color.Black)

			' add indicators
			m_VertLinearIndicator1 = New NRangeIndicator()
			m_VertLinearIndicator1.Value = 10
			m_VertLinearIndicator1.FillStyle = New NGradientFillStyle(Color.LightBlue, Color.DarkBlue)
			m_VertLinearIndicator1.StrokeStyle.Color = Color.DarkBlue
			linearGauge.Indicators.Add(m_VertLinearIndicator1)

			m_VertLinearIndicator2 = New NMarkerValueIndicator()
			m_VertLinearIndicator2.Value = 50
			linearGauge.Indicators.Add(m_VertLinearIndicator2)

			Dim axis As NGaugeAxis = DirectCast(linearGauge.Axes(0), NGaugeAxis)
			axis.Anchor = New NModelGaugeAxisAnchor()

			ConfigureAxis(axis)

			Return linearGauge
		End Function

		Private Sub ConfigureAxis(ByVal axis As NGaugeAxis)
			Dim configurator As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)
			configurator.SetPredefinedScaleStyle(PredefinedScaleStyle.Scientific)
			configurator.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.White)
			configurator.LabelStyle.TextStyle.FontStyle = New NFontStyle("Times New Roman", 10, FontStyle.Italic Or FontStyle.Bold)
			configurator.OuterMajorTickStyle.LineStyle.Color = Color.White
			configurator.OuterMinorTickStyle.LineStyle.Color = Color.White
			configurator.RulerStyle.BorderStyle.Color = Color.White
			configurator.MinorTickCount = 4
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

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.IndicatorsSnapModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.AllowDragRangeIndicatorsCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.OriginNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.StepNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label3 = New System.Windows.Forms.Label()
			DirectCast(Me.OriginNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.StepNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' IndicatorsSnapModeComboBox
			' 
			Me.IndicatorsSnapModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.IndicatorsSnapModeComboBox.ListProperties.DataSource = Nothing
			Me.IndicatorsSnapModeComboBox.ListProperties.DisplayMember = ""
			Me.IndicatorsSnapModeComboBox.Location = New System.Drawing.Point(8, 48)
			Me.IndicatorsSnapModeComboBox.Name = "IndicatorsSnapModeComboBox"
			Me.IndicatorsSnapModeComboBox.Size = New System.Drawing.Size(163, 21)
			Me.IndicatorsSnapModeComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.IndicatorsSnapModeComboBox.SelectedIndexChanged += new System.EventHandler(this.IndicatorsSnapModeComboBox_SelectedIndexChanged);
			' 
			' AllowDragRangeIndicatorsCheckBox
			' 
			Me.AllowDragRangeIndicatorsCheckBox.ButtonProperties.BorderOffset = 2
			Me.AllowDragRangeIndicatorsCheckBox.Location = New System.Drawing.Point(8, 184)
			Me.AllowDragRangeIndicatorsCheckBox.Name = "AllowDragRangeIndicatorsCheckBox"
			Me.AllowDragRangeIndicatorsCheckBox.Size = New System.Drawing.Size(155, 24)
			Me.AllowDragRangeIndicatorsCheckBox.TabIndex = 6
			Me.AllowDragRangeIndicatorsCheckBox.Text = "Allow Range Dragging"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AllowDragRangeIndicatorsCheckBox.CheckedChanged += new System.EventHandler(this.AllowDragRangeIndicatorsCheckBox_CheckedChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 16)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(139, 23)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Indicators Snap Mode:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 88)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(111, 16)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Origin:"
			' 
			' OriginNumericUpDown
			' 
			Me.OriginNumericUpDown.Location = New System.Drawing.Point(8, 104)
			Me.OriginNumericUpDown.Name = "OriginNumericUpDown"
			Me.OriginNumericUpDown.Size = New System.Drawing.Size(163, 20)
			Me.OriginNumericUpDown.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OriginNumericUpDown.ValueChanged += new System.EventHandler(this.OriginNumericUpDown_ValueChanged);
			' 
			' StepNumericUpDown
			' 
			Me.StepNumericUpDown.Location = New System.Drawing.Point(8, 144)
			Me.StepNumericUpDown.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.StepNumericUpDown.Name = "StepNumericUpDown"
			Me.StepNumericUpDown.Size = New System.Drawing.Size(163, 20)
			Me.StepNumericUpDown.TabIndex = 5
			Me.StepNumericUpDown.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StepNumericUpDown.ValueChanged += new System.EventHandler(this.StepNumericUpDown_ValueChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 128)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(111, 16)
			Me.label3.TabIndex = 4
			Me.label3.Text = "Step:"
			' 
			' NDraggingIndicatorsUC
			' 
			Me.Controls.Add(Me.StepNumericUpDown)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.OriginNumericUpDown)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.AllowDragRangeIndicatorsCheckBox)
			Me.Controls.Add(Me.IndicatorsSnapModeComboBox)
			Me.Name = "NDraggingIndicatorsUC"
			Me.Size = New System.Drawing.Size(180, 264)
			DirectCast(Me.OriginNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.StepNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Private Sub AllowDragRangeIndicatorsCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AllowDragRangeIndicatorsCheckBox.CheckedChanged
			If m_RadialIndicator1 IsNot Nothing Then
				Dim allowDrag As Boolean = AllowDragRangeIndicatorsCheckBox.Checked

				m_RadialIndicator1.AllowDragging = allowDrag
				m_HorzLinearIndicator1.AllowDragging = allowDrag
				m_VertLinearIndicator1.AllowDragging = allowDrag
			End If
		End Sub

		Private Function GetAxisValueSnapper() As NValueSnapper
			Dim index As Integer = IndicatorsSnapModeComboBox.SelectedIndex

			Select Case index
				Case 0 'None, snapping is disabled
					Return Nothing
				Case 1 ' Ruler, values are constrained to the ruler begin and end values.
					Return New NAxisRulerClampSnapper()
				Case 2 ' Major ticks, values are snapped to axis major ticks
					Return New NAxisMajorTickSnapper()
				Case 3 ' Minor ticks, values are snapped to axis minor ticks
					Return New NAxisMinorTickSnapper()
				Case 4 ' Ruler Min Max, values are snapped to the ruler min and max values
					Return New NAxisRulerMinMaxSnapper()
				Case 5
					Return New NNumericValueSnapper(CDbl(OriginNumericUpDown.Value), CDbl(StepNumericUpDown.Value))
			End Select

			Return Nothing
		End Function

		Public Sub UpdateValueSnapper()
			If m_RadialIndicator1 IsNot Nothing Then
				m_RadialIndicator1.ValueSnapper = GetAxisValueSnapper()
				m_RadialIndicator2.ValueSnapper = GetAxisValueSnapper()
				m_RadialIndicator3.ValueSnapper = GetAxisValueSnapper()
				m_HorzLinearIndicator1.ValueSnapper = GetAxisValueSnapper()
				m_HorzLinearIndicator2.ValueSnapper = GetAxisValueSnapper()
				m_VertLinearIndicator1.ValueSnapper = GetAxisValueSnapper()
				m_VertLinearIndicator2.ValueSnapper = GetAxisValueSnapper()

				Dim enableNumericControls As Boolean = IndicatorsSnapModeComboBox.SelectedIndex = 5

				OriginNumericUpDown.Enabled = enableNumericControls
				StepNumericUpDown.Enabled = enableNumericControls
			End If
		End Sub

		Private Sub IndicatorsSnapModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles IndicatorsSnapModeComboBox.SelectedIndexChanged
			UpdateValueSnapper()
		End Sub

		Private Sub OriginNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OriginNumericUpDown.ValueChanged
			UpdateValueSnapper()
		End Sub

		Private Sub StepNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles StepNumericUpDown.ValueChanged
			UpdateValueSnapper()
		End Sub
	End Class
End Namespace
