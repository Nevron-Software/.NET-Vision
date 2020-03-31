Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NGaugeCustomLabelsUC
		Inherits NExampleBaseUC

		Private WithEvents m_Timer As System.Timers.Timer
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing
		Private m_SecondsArrow As NNeedleValueIndicator
		Private m_MinituesArrow As NNeedleValueIndicator
		Private m_HoursArrow As NNeedleValueIndicator

		Public Sub New()
			' This call is required by the Windows.Forms Form Designer.
			InitializeComponent()
		End Sub

		Public Overrides Sub Initialize()
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As New NLabel("Gauge Custom Labels")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			nChartControl1.Panels.Add(header)

			' create the radial gauge
			Dim radialGauge As New NRadialGaugePanel()
			radialGauge.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(12, NRelativeUnit.ParentPercentage))
			radialGauge.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))
			radialGauge.PaintEffect = New NGlassEffectStyle()
			radialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)

			Dim advGradient As New NAdvancedGradientFillStyle()
			advGradient.BackgroundColor = Color.Black
			advGradient.Points.Add(New NAdvancedGradientPoint(Color.White, 10, 10, 0, 100, AGPointShape.Circle))
			radialGauge.BackgroundFillStyle = advGradient

			radialGauge.SweepAngle = 360
			radialGauge.BeginAngle = -90
			nChartControl1.Panels.Add(radialGauge)

			Dim axis As NGaugeAxis = DirectCast(radialGauge.Axes(0), NGaugeAxis)
			axis.Range = New NRange1DD(0, 60)
			axis.Anchor.RulerOrientation = RulerOrientation.Right
			axis.Anchor = New NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, True, RulerOrientation.Right, 0, 100)
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NLinearScaleConfigurator = CType(axis.ScaleConfigurator, NLinearScaleConfigurator)

			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.FromArgb(20, Color.LightGray)), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.Interlaced = True
			scale_Renamed.StripStyles.Add(stripStyle)
			scale_Renamed.MinorTickCount = 4
			scale_Renamed.MajorTickMode = MajorTickMode.CustomStep
			scale_Renamed.CustomStep = 5.0F
			scale_Renamed.SetPredefinedScaleStyle(PredefinedScaleStyle.Watch)
			scale_Renamed.OuterMajorTickStyle.FillStyle = New NGradientFillStyle(Color.White, Color.Beige)
			scale_Renamed.OuterMajorTickStyle.LineStyle = New NStrokeStyle(Color.DarkGray)
			scale_Renamed.OuterMajorTickStyle.Length = New NLength(14)
			scale_Renamed.RulerStyle.FillStyle = New NColorFillStyle(Color.FromArgb(50, Color.Silver))
			scale_Renamed.RulerStyle.BorderStyle = New NStrokeStyle(Color.Beige)

			axis.UpdateScale()
			axis.SynchronizeScaleWithConfigurator = False

			Dim textStyle1 As New NTextStyle()
			textStyle1.FillStyle = New NColorFillStyle(Color.White)
			textStyle1.BorderStyle = New NStrokeStyle(1, Color.Beige)
			textStyle1.FontStyle.Style = FontStyle.Bold
			textStyle1.FontStyle.EmSize = New NLength(22)
			Dim angle As New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0)

			Dim textStyle2 As New NTextStyle()
			textStyle2.FillStyle = New NColorFillStyle(Color.White)
			textStyle2.BorderStyle = New NStrokeStyle(1, Color.Beige)
			textStyle2.FontStyle.Style = FontStyle.Bold
			textStyle2.FontStyle.EmSize = New NLength(12)

			Dim customDecorator As New NCustomScaleDecorator()

			Dim style1 As New NValueScaleLabelStyle(textStyle1, ContentAlignment.MiddleCenter, angle, New NLength(0))
			Dim style2 As New NValueScaleLabelStyle(textStyle2, ContentAlignment.MiddleCenter, angle, New NLength(0))

			For i As Integer = 12 To 1 Step -1
'INSTANT VB NOTE: The variable text was renamed since Visual Basic does not handle local variables named the same as class members well:
				Dim text_Renamed As String = NSystem.IntToRoman(i)
				Dim hourLabel As NValueScaleLabel

				If i Mod 3 = 0 Then
					hourLabel = New NValueScaleLabel(New NScaleValueDecorationAnchor(i * 5), text_Renamed, DirectCast(style1.Clone(), NValueScaleLabelStyle))
				Else
					hourLabel = New NValueScaleLabel(New NScaleValueDecorationAnchor(i * 5), text_Renamed, DirectCast(style2.Clone(), NValueScaleLabelStyle))
				End If

				customDecorator.Decorations.Add(hourLabel)
			Next i

			Dim textLevel As NScaleLevel = DirectCast(axis.Scale.Levels(1), NScaleLevel)
			textLevel.Decorators.Clear()
			textLevel.Decorators.Add(customDecorator)

			m_HoursArrow = New NNeedleValueIndicator()
			m_HoursArrow.Value = 79
			m_HoursArrow.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red)
			m_HoursArrow.Shape.StrokeStyle.Color = Color.Red
			m_HoursArrow.OffsetOriginMode = IndicatorOffsetOriginMode.ScaleEnd
			m_HoursArrow.OffsetFromScale = New NLength(30)
			m_HoursArrow.Width = New NLength(8)
			radialGauge.Indicators.Add(m_HoursArrow)

			m_MinituesArrow = New NNeedleValueIndicator()
			m_MinituesArrow.Value = 79
			m_MinituesArrow.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red)
			m_MinituesArrow.Shape.StrokeStyle.Color = Color.Red
			m_MinituesArrow.OffsetOriginMode = IndicatorOffsetOriginMode.ScaleEnd
			m_MinituesArrow.OffsetFromScale = New NLength(30)
			m_MinituesArrow.Width = New NLength(5)
			radialGauge.Indicators.Add(m_MinituesArrow)

			m_SecondsArrow = New NNeedleValueIndicator()
			m_SecondsArrow.Value = 79
			m_SecondsArrow.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red)
			m_MinituesArrow.OffsetOriginMode = IndicatorOffsetOriginMode.ScaleEnd
			m_SecondsArrow.Shape.StrokeStyle.Color = Color.Red
			m_SecondsArrow.OffsetFromScale = New NLength(10)
			m_SecondsArrow.Width = New NLength(1)
			radialGauge.Indicators.Add(m_SecondsArrow)

			nChartControl1.AutoRefresh = True
			SynchronizeWithTime()

			m_Timer.Interval = 1000
			m_Timer.Enabled = True
		End Sub

		Private Sub SynchronizeWithTime()
			Dim now As Date = Date.Now
			m_SecondsArrow.Value = now.Second
			m_MinituesArrow.Value = now.Minute
			m_HoursArrow.Value = now.Hour * 5.0F + now.Minute / 12.0F
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
			Me.m_Timer = New System.Timers.Timer()
			DirectCast(Me.m_Timer, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' timer1
			' 
			Me.m_Timer.Enabled = True
			Me.m_Timer.SynchronizingObject = Me
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_Timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
			' 
			' NGaugeCustomLabelsUC
			' 
			Me.Name = "NGaugeCustomLabelsUC"
			Me.Size = New System.Drawing.Size(180, 150)
			DirectCast(Me.m_Timer, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Private Sub timer1_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles m_Timer.Elapsed
			SynchronizeWithTime()
		End Sub
	End Class
End Namespace
