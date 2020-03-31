Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NCustomLabelsUC
		Inherits NExampleUC
		Private m_HoursArrow As NNeedleValueIndicator
		Private m_MinituesArrow As NNeedleValueIndicator
		Private m_SecondsArrow As NNeedleValueIndicator

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As NLabel = New NLabel("Gauge Custom Labels")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.Location = New NPointL(New NLength(3, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
			nChartControl1.Panels.Add(header)


			' create the radial gauge
			Dim radialGauge As NRadialGaugePanel = New NRadialGaugePanel()
			radialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)
			radialGauge.PaintEffect = New NGlassEffectStyle()
			radialGauge.ContentAlignment = ContentAlignment.MiddleCenter
			radialGauge.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(52, NRelativeUnit.ParentPercentage))
			radialGauge.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(85, NRelativeUnit.ParentPercentage))
			radialGauge.SweepAngle = 360
			radialGauge.BeginAngle = -90
			Dim advGradient As NAdvancedGradientFillStyle = New NAdvancedGradientFillStyle()
			advGradient.BackgroundColor = Color.Black
			advGradient.Points.Add(New NAdvancedGradientPoint(Color.White, 10, 10, 0, 100, AGPointShape.Circle))
			radialGauge.BackgroundFillStyle = advGradient
			nChartControl1.Panels.Add(radialGauge)

			Dim axis As NGaugeAxis = CType(radialGauge.Axes(0), NGaugeAxis)
			axis.Range = New NRange1DD(0, 60)
			axis.Anchor.RulerOrientation = RulerOrientation.Right
			axis.Anchor = New NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, True, RulerOrientation.Right, 0, 100)
			Dim scale As NLinearScaleConfigurator = CType(axis.ScaleConfigurator, NLinearScaleConfigurator)

			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.FromArgb(20, Color.LightGray)), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.Interlaced = True
			scale.StripStyles.Add(stripStyle)
			scale.MinorTickCount = 4
			scale.MajorTickMode = MajorTickMode.CustomStep
			scale.CustomStep = 5.0f
			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.Watch)
			scale.OuterMajorTickStyle.FillStyle = New NGradientFillStyle(Color.White, Color.Beige)
			scale.OuterMajorTickStyle.LineStyle = New NStrokeStyle(Color.DarkGray)
			scale.OuterMajorTickStyle.Length = New NLength(14)
			scale.RulerStyle.FillStyle = New NColorFillStyle(Color.FromArgb(50, Color.Silver))
			scale.RulerStyle.BorderStyle = New NStrokeStyle(Color.Beige)

			axis.UpdateScale()
			axis.SynchronizeScaleWithConfigurator = False

			Dim textStyle1 As NTextStyle = New NTextStyle()
			textStyle1.FillStyle = New NColorFillStyle(Color.White)
			textStyle1.BorderStyle = New NStrokeStyle(1, Color.Beige)
			textStyle1.FontStyle.Style = FontStyle.Bold
			textStyle1.FontStyle.EmSize = New NLength(22)
			Dim angle As NScaleLabelAngle = New NScaleLabelAngle(ScaleLabelAngleMode.View, 0)

			Dim textStyle2 As NTextStyle = New NTextStyle()
			textStyle2.FillStyle = New NColorFillStyle(Color.White)
			textStyle2.BorderStyle = New NStrokeStyle(1, Color.Beige)
			textStyle2.FontStyle.Style = FontStyle.Bold
			textStyle2.FontStyle.EmSize = New NLength(12)

			Dim customDecorator As NCustomScaleDecorator = New NCustomScaleDecorator()

			For i As Integer = 12 To 1 Step -1
				Dim text As String = NSystem.IntToRoman(i)
				Dim hourLabel As NValueScaleLabel

				Dim valueLabelStyle As NValueScaleLabelStyle = New NValueScaleLabelStyle()
				valueLabelStyle.ContentAlignment = ContentAlignment.MiddleCenter
				valueLabelStyle.Angle = angle

				If i Mod 3 = 0 Then
					valueLabelStyle.TextStyle = CType(textStyle1.Clone(), NTextStyle)
					hourLabel = New NValueScaleLabel(New NScaleValueDecorationAnchor(i * 5), text, valueLabelStyle)
				Else
					valueLabelStyle.TextStyle = CType(textStyle2.Clone(), NTextStyle)
					hourLabel = New NValueScaleLabel(New NScaleValueDecorationAnchor(i * 5), text, valueLabelStyle)
				End If

				customDecorator.Decorations.Add(hourLabel)
			Next i

			Dim textLevel As NScaleLevel = CType(axis.Scale.Levels(1), NScaleLevel)
			textLevel.Decorators.Clear()
			textLevel.Decorators.Add(customDecorator)

			m_HoursArrow = New NNeedleValueIndicator()
			m_HoursArrow.Value = 79
			m_HoursArrow.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red)
			m_HoursArrow.Shape.StrokeStyle.Color = Color.Red
			m_HoursArrow.OffsetFromScale = New NLength(10)
			m_HoursArrow.Width = New NLength(8)
			radialGauge.Indicators.Add(m_HoursArrow)

			m_MinituesArrow = New NNeedleValueIndicator()
			m_MinituesArrow.Value = 79
			m_MinituesArrow.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red)
			m_MinituesArrow.Shape.StrokeStyle.Color = Color.Red
			m_MinituesArrow.OffsetFromScale = New NLength(5)
			m_MinituesArrow.Width = New NLength(5)
			radialGauge.Indicators.Add(m_MinituesArrow)

			m_SecondsArrow = New NNeedleValueIndicator()
			m_SecondsArrow.Value = 79
			m_SecondsArrow.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red)
			m_SecondsArrow.Shape.StrokeStyle.Color = Color.Red
			m_SecondsArrow.OffsetFromScale = New NLength(0)
			m_SecondsArrow.Width = New NLength(1)
			radialGauge.Indicators.Add(m_SecondsArrow)

			SynchronizeWithTime()
		End Sub

		Private Sub SynchronizeWithTime()
			Dim now As DateTime = DateTime.Now
			m_SecondsArrow.Value = now.Second
			m_MinituesArrow.Value = now.Minute
			m_HoursArrow.Value = now.Hour * 5.0f + now.Minute / 12.0f
		End Sub
	End Class
End Namespace
