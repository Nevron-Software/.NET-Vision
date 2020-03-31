Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NGaugeAxisRulerSizeUC
		Inherits NExampleBaseUC

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Private m_RadialGauge As NRadialGaugePanel
		Private label1 As System.Windows.Forms.Label
		Private RedAxisTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents RedAxisPercentScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar

		Public Sub New()
			' This call is required by the Windows.Forms Form Designer.
			InitializeComponent()

		End Sub

		Public Overrides Sub Initialize()
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As New NLabel("Gauge Axis Ruler Size")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			nChartControl1.Panels.Add(header)

			' create the radial gauge
			m_RadialGauge = New NRadialGaugePanel()
			m_RadialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)
			m_RadialGauge.ContentAlignment = ContentAlignment.MiddleCenter
			m_RadialGauge.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(50, NRelativeUnit.ParentPercentage))
			m_RadialGauge.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage))
			m_RadialGauge.BackgroundFillStyle = New NGradientFillStyle(Color.DarkGray, Color.Black)
			Dim gelEffect As New NGelEffectStyle(PaintEffectShape.Ellipse)
			gelEffect.Margins = New NMarginsL(New NLength(0), New NLength(0), New NLength(0), New NLength(50, NRelativeUnit.ParentPercentage))

			m_RadialGauge.PaintEffect = gelEffect
			nChartControl1.Panels.Add(m_RadialGauge)

			m_RadialGauge.Axes.Clear()

			' create the first axis
			Dim axis1 As New NGaugeAxis()
			axis1.Anchor = New NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, True, 0, 70)
			Dim scale1 As NStandardScaleConfigurator = CType(axis1.ScaleConfigurator, NStandardScaleConfigurator)
			scale1.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke)
			scale1.MinorTickCount = 3
			scale1.RulerStyle.FillStyle = New NColorFillStyle(Color.FromArgb(40, Color.White))
			scale1.OuterMajorTickStyle.FillStyle = New NColorFillStyle(Color.Orange)
			scale1.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 12, FontStyle.Bold)
			scale1.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.White)
			scale1.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0)

			m_RadialGauge.Axes.Add(axis1)

			' create the second axis
			Dim axis2 As New NGaugeAxis()
			axis2.Anchor = New NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, False, 75, 95)
			Dim scale2 As NStandardScaleConfigurator = CType(axis2.ScaleConfigurator, NStandardScaleConfigurator)
			scale2.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke)
			scale2.MinorTickCount = 3
			scale2.RulerStyle.FillStyle = New NColorFillStyle(Color.FromArgb(40, Color.White))
			scale2.OuterMajorTickStyle.FillStyle = New NColorFillStyle(Color.Blue)
			scale2.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 12, FontStyle.Bold)
			scale2.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.White)
			scale2.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0)

			m_RadialGauge.Axes.Add(axis2)

			' add indicators
			Dim rangeIndicator As New NRangeIndicator()
			rangeIndicator.Value = 50
			rangeIndicator.FillStyle = New NGradientFillStyle(Color.Orange, Color.Red)
			rangeIndicator.StrokeStyle.Width = New NLength(0)
			rangeIndicator.OffsetFromScale = New NLength(3)
			rangeIndicator.BeginWidth = New NLength(6)
			rangeIndicator.EndWidth = New NLength(12)
			m_RadialGauge.Indicators.Add(rangeIndicator)

			Dim needleValueIndicator1 As New NNeedleValueIndicator()
			needleValueIndicator1.Value = 79
			needleValueIndicator1.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant2, Color.White, Color.Red)
			needleValueIndicator1.Shape.StrokeStyle.Color = Color.Red
			needleValueIndicator1.Axis = axis1
			needleValueIndicator1.OffsetFromScale = New NLength(2)
			m_RadialGauge.Indicators.Add(needleValueIndicator1)
			m_RadialGauge.SweepAngle = 360

			Dim needleValueIndicator2 As New NNeedleValueIndicator()
			needleValueIndicator2.Value = 79
			needleValueIndicator2.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant2, Color.White, Color.Blue)
			needleValueIndicator2.Shape.StrokeStyle.Color = Color.Blue
			needleValueIndicator2.Axis = axis2
			needleValueIndicator2.OffsetFromScale = New NLength(2)
			m_RadialGauge.Indicators.Add(needleValueIndicator2)

			RedAxisPercentScrollBar.Value = 70
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
			Me.RedAxisPercentScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label1 = New System.Windows.Forms.Label()
			Me.RedAxisTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.SuspendLayout()
			' 
			' RedAxisPercentScrollBar
			' 
			Me.RedAxisPercentScrollBar.Location = New System.Drawing.Point(3, 38)
			Me.RedAxisPercentScrollBar.Maximum = 80
			Me.RedAxisPercentScrollBar.Minimum = 10
			Me.RedAxisPercentScrollBar.MinimumSize = New System.Drawing.Size(32, 16)
			Me.RedAxisPercentScrollBar.Name = "RedAxisPercentScrollBar"
			Me.RedAxisPercentScrollBar.Size = New System.Drawing.Size(123, 16)
			Me.RedAxisPercentScrollBar.TabIndex = 0
			Me.RedAxisPercentScrollBar.Value = 10
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RedAxisPercentScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.RedAxisPercentScrollBar_ValueChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(3, 14)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(100, 23)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Red Axis Percent:"
			' 
			' RedAxisTextBox
			' 
			Me.RedAxisTextBox.Enabled = False
			Me.RedAxisTextBox.Location = New System.Drawing.Point(129, 36)
			Me.RedAxisTextBox.Name = "RedAxisTextBox"
			Me.RedAxisTextBox.Size = New System.Drawing.Size(48, 18)
			Me.RedAxisTextBox.TabIndex = 2
			' 
			' NGaugeAxisRulerSizeUC
			' 
			Me.Controls.Add(Me.RedAxisTextBox)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.RedAxisPercentScrollBar)
			Me.Name = "NGaugeAxisRulerSizeUC"
			Me.Size = New System.Drawing.Size(180, 216)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Private Sub RedAxisPercentScrollBar_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles RedAxisPercentScrollBar.ValueChanged
			Dim axis1 As NGaugeAxis = DirectCast(m_RadialGauge.Axes(0), NGaugeAxis)
			Dim axis2 As NGaugeAxis = DirectCast(m_RadialGauge.Axes(1), NGaugeAxis)

			axis1.Anchor = New NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, True, 0, RedAxisPercentScrollBar.Value - 5)
			axis2.Anchor = New NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, False, RedAxisPercentScrollBar.Value, 95)
			RedAxisTextBox.Text = RedAxisPercentScrollBar.Value.ToString()

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
