Imports Microsoft.VisualBasic
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NCarDashboardUC
		Inherits NExampleUC
		Private m_SpeedIndicator As NNeedleValueIndicator
		Private m_RotationIndicator As NNeedleValueIndicator

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As NLabel = New NLabel("Car Dashboard")
			header.ContentAlignment = ContentAlignment.MiddleCenter
			header.TextStyle.FontStyle.Name = "Palatino Linotype"
			header.TextStyle.FontStyle.Style = FontStyle.Italic
			header.TextStyle.FillStyle = New NGradientFillStyle(Color.Black, Color.White)
			header.TextStyle.BorderStyle = New NStrokeStyle(Color.Gray)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.TextStyle.FontStyle.EmSize = New NLength(22)
			header.TextStyle.FontStyle.Style = FontStyle.Bold
			header.BoundsMode = BoundsMode.None
			header.UseAutomaticSize = False
			header.Size = New NSizeL(New NLength(60, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
			header.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(6, NRelativeUnit.ParentPercentage))
			nChartControl1.Panels.Add(header)

			CreateSpeedGauge()
			CreateRPMGauge()
		End Sub

		Private Sub CreateSpeedGauge()
			' create the radial gauge
			Dim radialGauge As NRadialGaugePanel = New NRadialGaugePanel()


			radialGauge.BackgroundFillStyle = CreateAdvancedGradient()
			radialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)
			radialGauge.PaintEffect = New NGlassEffectStyle()
			radialGauge.ContentAlignment = ContentAlignment.BottomRight
			radialGauge.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			radialGauge.Size = New NSizeL(New NLength(45, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

			Dim label As NLabel = New NLabel("km/h")
			label.ContentAlignment = ContentAlignment.BottomCenter
			label.TextStyle.FontStyle = New NFontStyle("Times New Roman", 20, FontStyle.Italic)
			label.TextStyle.FontStyle.Style = FontStyle.Italic
			label.TextStyle.FillStyle = New NColorFillStyle(Color.White)
			label.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			label.BoundsMode = BoundsMode.Fit
			label.UseAutomaticSize = False
			label.Size = New NSizeL(New NLength(60, NRelativeUnit.ParentPercentage), New NLength(7, NRelativeUnit.ParentPercentage))
			label.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(55, NRelativeUnit.ParentPercentage))
			label.Cache = True

			radialGauge.ChildPanels.Add(label)
			nChartControl1.Panels.Add(radialGauge)

			Dim axis As NGaugeAxis = CType(radialGauge.Axes(0), NGaugeAxis)
			axis.Range = New NRange1DD(0, 250)

			Dim scale As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)
			ConfigureScale(scale, New NRange1DD(220, 260))
			radialGauge.Indicators.Add(CreateRangeIndicator(220))

			Dim indicator3 As NMarkerValueIndicator = New NMarkerValueIndicator()
			indicator3.Value = 90
			radialGauge.Indicators.Add(indicator3)

			m_SpeedIndicator = New NNeedleValueIndicator()
			m_SpeedIndicator.Value = 0
			m_SpeedIndicator.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red)
			m_SpeedIndicator.Shape.StrokeStyle.Color = Color.Red
			radialGauge.Indicators.Add(m_SpeedIndicator)

			radialGauge.BeginAngle = -240
			radialGauge.SweepAngle = 300
		End Sub

		Private Function CreateAdvancedGradient() As NFillStyle
			Dim agfs As NAdvancedGradientFillStyle = New NAdvancedGradientFillStyle()

			agfs.BackgroundColor = Color.FromArgb(234, 234, 234)

			Dim point1 As NAdvancedGradientPoint = New NAdvancedGradientPoint()
			point1.X = 50
			point1.Y = 50
			point1.Color = Color.FromArgb(51, 51, 51)
			point1.Intensity = 70
			agfs.Points.Add(point1)

			Dim point2 As NAdvancedGradientPoint = New NAdvancedGradientPoint()
			point2.X = 50
			point2.Y = 50
			point2.Color = Color.FromArgb(41, 41, 41)
			point2.Intensity = 50
			agfs.Points.Add(point2)

			Return agfs
		End Function

		Private Sub CreateRPMGauge()
			' create the radial gauge
			Dim radialGauge As NRadialGaugePanel = New NRadialGaugePanel()

			radialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)
			radialGauge.PaintEffect = New NGlassEffectStyle()
			radialGauge.BackgroundFillStyle = CreateAdvancedGradient()
			radialGauge.ContentAlignment = ContentAlignment.BottomRight
			radialGauge.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			radialGauge.Size = New NSizeL(New NLength(45, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

			Dim label As NLabel = New NLabel("RPM")
			label.ContentAlignment = ContentAlignment.BottomCenter
			label.TextStyle.FontStyle.Name = "Palatino Linotype"
			label.TextStyle.FontStyle.Style = FontStyle.Italic
			label.TextStyle.FillStyle = New NColorFillStyle(Color.White)
			label.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			label.BoundsMode = BoundsMode.Fit
			label.UseAutomaticSize = False
			label.Size = New NSizeL(New NLength(60, NRelativeUnit.ParentPercentage), New NLength(7, NRelativeUnit.ParentPercentage))
			label.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(55, NRelativeUnit.ParentPercentage))
			label.Cache = True

			radialGauge.ChildPanels.Add(label)
			nChartControl1.Panels.Add(radialGauge)

			Dim axis As NGaugeAxis = CType(radialGauge.Axes(0), NGaugeAxis)
			axis.Range = New NRange1DD(0, 7000)

			Dim scale As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)
			ConfigureScale(scale, New NRange1DD(6000, 7000))

			radialGauge.Indicators.Add(CreateRangeIndicator(6000))

			m_RotationIndicator = New NNeedleValueIndicator()
			m_RotationIndicator.Value = 79
			m_RotationIndicator.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red)
			m_RotationIndicator.Shape.StrokeStyle.Color = Color.Red
			radialGauge.Indicators.Add(m_RotationIndicator)

			radialGauge.BeginAngle = -240
			radialGauge.SweepAngle = 300
		End Sub

		Private Sub ConfigureScale(ByVal scale As NStandardScaleConfigurator, ByVal redRange As NRange1DD)
			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke)
			scale.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 9, FontStyle.Bold)
			scale.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.White)
			scale.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0)
			scale.MinorTickCount = 1
			scale.RulerStyle.BorderStyle.Width = New NLength(0)
			scale.RulerStyle.FillStyle = New NColorFillStyle(Color.FromArgb(125, Color.SlateGray))

			Dim scaleSection As NScaleSectionStyle = New NScaleSectionStyle()
			scaleSection.Range = redRange
			scaleSection.MajorTickFillStyle = New NColorFillStyle(Color.Red)
			scaleSection.MinorTickFillStyle = New NColorFillStyle(Color.Red)

			Dim labelStyle As NTextStyle = New NTextStyle()
			labelStyle.FillStyle = New NGradientFillStyle(Color.Red, Color.DarkRed)
			labelStyle.FontStyle = New NFontStyle("Arial", 9, FontStyle.Bold)
			scaleSection.LabelTextStyle = labelStyle

			scale.Sections.Add(scaleSection)
		End Sub

		Private Function CreateRangeIndicator(ByVal minValue As Double) As NRangeIndicator
			Dim rangeIndicator As NRangeIndicator = New NRangeIndicator()

			rangeIndicator.Value = minValue
			rangeIndicator.OriginMode = OriginMode.ScaleMax
			rangeIndicator.FillStyle = New NColorFillStyle(Color.Red)
			rangeIndicator.StrokeStyle.Width = New NLength(0)
			rangeIndicator.BeginWidth = New NLength(2)
			rangeIndicator.EndWidth = New NLength(10)

			Return rangeIndicator
		End Function
	End Class
End Namespace
