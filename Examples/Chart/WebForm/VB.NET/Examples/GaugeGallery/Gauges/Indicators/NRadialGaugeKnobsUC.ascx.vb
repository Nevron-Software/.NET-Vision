Imports Microsoft.VisualBasic
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore
Imports Nevron.SmartShapes

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NRadialGaugeKnobsUC
		Inherits NExampleUC
		Protected m_RadialGauge As NRadialGaugePanel
		Protected m_Indicator1 As NRangeIndicator
		Protected m_Indicator2 As NNeedleValueIndicator
		Protected m_NumericDisplay As NNumericDisplayPanel

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As NLabel = New NLabel("Radial Gauge Knob Indicators")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.DockMode = PanelDockMode.Top
			header.Location = New NPointL(New NLength(3, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
			nChartControl1.Panels.Add(header)

			' create the radial gauge
			Dim radialGauge As NRadialGaugePanel = New NRadialGaugePanel()
			nChartControl1.Panels.Add(radialGauge)
			radialGauge.DockMode = PanelDockMode.Fill
			radialGauge.ContentAlignment = ContentAlignment.MiddleCenter
			radialGauge.SweepAngle = 270
			radialGauge.BeginAngle = -225
			radialGauge.CapStyle.Visible = False

			' configure the gauge scale
			Dim axis As NGaugeAxis = CType(radialGauge.Axes(0), NGaugeAxis)
			Dim scale As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)

			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke)
			scale.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 12, FontStyle.Italic)
			scale.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.Black)
			scale.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0)
			scale.MinorTickCount = 4
			scale.RulerStyle.BorderStyle.Width = New NLength(0)
			scale.RulerStyle.FillStyle = New NColorFillStyle(Color.DarkGray)

			' create the knob indicator
			Dim knobIndicator As NKnobIndicator = New NKnobIndicator()
			knobIndicator.OffsetFromScale = New NLength(-3)

			' apply fill style to the marker
			Dim advancedGradientFill As NAdvancedGradientFillStyle = New NAdvancedGradientFillStyle()
			advancedGradientFill.BackgroundColor = Color.Red
			advancedGradientFill.Points.Add(New NAdvancedGradientPoint(Color.White, 20, 20, 0, 100, AGPointShape.Circle))
			knobIndicator.MarkerShape.FillStyle = advancedGradientFill

			' add the knob indicator to the indicators collection of the gauge
			radialGauge.Indicators.Add(knobIndicator)

			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumValues(MarkerShapeDropDownList, GetType(SmartShape2D))
				MarkerShapeDropDownList.SelectedIndex = CInt(Fix(SmartShape2D.Ellipse))

				WebExamplesUtilities.FillComboWithEnumValues(OuterRimPatternDropDownList, GetType(CircularRimPattern))
				OuterRimPatternDropDownList.SelectedIndex = CInt(Fix(CircularRimPattern.RoundHandle))

				WebExamplesUtilities.FillComboWithEnumValues(InnerRimPatternDropDownList, GetType(CircularRimPattern))
				InnerRimPatternDropDownList.SelectedIndex = CInt(Fix(CircularRimPattern.Circle))
			End If

			' update the knob marker shape
			Dim factory As N2DSmartShapeFactory = New N2DSmartShapeFactory(knobIndicator.MarkerShape.FillStyle, knobIndicator.MarkerShape.StrokeStyle, knobIndicator.MarkerShape.ShadowStyle)
			knobIndicator.MarkerShape = factory.CreateShape(CType(MarkerShapeDropDownList.SelectedIndex, SmartShape2D))

			' update the outer rim style
			knobIndicator.OuterRimStyle.Pattern = CType(OuterRimPatternDropDownList.SelectedIndex, CircularRimPattern)

			' update the inner rim style
			knobIndicator.InnerRimStyle.Pattern = CType(InnerRimPatternDropDownList.SelectedIndex, CircularRimPattern)
		End Sub
	End Class
End Namespace
