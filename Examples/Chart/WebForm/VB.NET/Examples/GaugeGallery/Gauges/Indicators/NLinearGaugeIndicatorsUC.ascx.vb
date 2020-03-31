Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Imports Nevron.Examples.Framework.WebForm
Imports Nevron.UI
Imports Nevron.UI.WebForm.Controls
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm
Imports Nevron.SmartShapes

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NLinearGaugeIndicatorsUC
		Inherits NExampleUC
		Protected m_LinearGauge As NLinearGaugePanel
		Protected m_Indicator2 As NMarkerValueIndicator
		Protected m_Indicator1 As NRangeIndicator

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As NLabel = New NLabel("Linear Gauge Indicators")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(3, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
			nChartControl1.Panels.Add(header)

			' create a linear gauge
			m_LinearGauge = New NLinearGaugePanel()
			nChartControl1.Panels.Add(m_LinearGauge)
			m_LinearGauge.ContentAlignment = ContentAlignment.MiddleCenter
			m_LinearGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.RoundedRect)
			m_LinearGauge.PaintEffect = New NGelEffectStyle()
			m_LinearGauge.BackgroundFillStyle = New NGradientFillStyle(Color.Gray, Color.Black)

			m_LinearGauge.Axes.Clear()

			Dim celsiusRange As NRange1DD = New NRange1DD(-40, 60)

			' add celsius and farenheit axes
			Dim celsiusAxis As NGaugeAxis = New NGaugeAxis()
			celsiusAxis.Range = celsiusRange
			celsiusAxis.Anchor = New NModelGaugeAxisAnchor(New NLength(-5), VertAlign.Center, RulerOrientation.Left, 0, 100)
			m_LinearGauge.Axes.Add(celsiusAxis)

			Dim farenheitAxis As NGaugeAxis = New NGaugeAxis()
			farenheitAxis.Range = New NRange1DD(CelsiusToFarenheit(celsiusRange.Begin), CelsiusToFarenheit(celsiusRange.End))
			farenheitAxis.Anchor = New NModelGaugeAxisAnchor(New NLength(5), VertAlign.Center, RulerOrientation.Right, 0, 100)
			m_LinearGauge.Axes.Add(farenheitAxis)

			' configure the scales
			Dim celsiusScale As NLinearScaleConfigurator = CType(celsiusAxis.ScaleConfigurator, NLinearScaleConfigurator)
			ConfigureScale(celsiusScale, "°C")
			celsiusScale.Sections.Add(CreateSection(Color.Red, Color.Red, New NRange1DD(40, 60)))
			celsiusScale.Sections.Add(CreateSection(Color.Blue, Color.SkyBlue, New NRange1DD(-40, -20)))

			Dim farenheitScale As NLinearScaleConfigurator = CType(farenheitAxis.ScaleConfigurator, NLinearScaleConfigurator)
			ConfigureScale(farenheitScale, "°F")

			farenheitScale.Sections.Add(CreateSection(Color.Red, Color.Red, New NRange1DD(CelsiusToFarenheit(40), CelsiusToFarenheit(60))))
			farenheitScale.Sections.Add(CreateSection(Color.Blue, Color.SkyBlue, New NRange1DD(CelsiusToFarenheit(-40), CelsiusToFarenheit(-20))))

			' now add two indicators
			m_Indicator1 = New NRangeIndicator()
			m_Indicator1.Value = 10
			m_Indicator1.StrokeStyle.Color = Color.DarkBlue
			m_Indicator1.FillStyle = New NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant1, Color.LightBlue, Color.Blue)
			m_LinearGauge.Indicators.Add(m_Indicator1)

			m_Indicator2 = New NMarkerValueIndicator()
			m_Indicator2.Value = 33
			m_Indicator2.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red)
			m_Indicator2.Shape.StrokeStyle.Color = Color.DarkRed
			m_LinearGauge.Indicators.Add(m_Indicator2)

			' init form controls
			If (Not Page.IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumValues(RangeIndicatorOriginModeDropDownList, GetType(OriginMode))
				RangeIndicatorOriginModeDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithEnumValues(ValueIndicatorShapeDropDownList, GetType(SmartShape2D))
				ValueIndicatorShapeDropDownList.SelectedIndex = CInt(Fix(SmartShape2D.Triangle))

				WebExamplesUtilities.FillComboWithEnumValues(GaugeOrientationDropDownList, GetType(LinearGaugeOrientation))
				GaugeOrientationDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithValues(ValueIndicatorDropDownList, -20, 60, 10)
				WebExamplesUtilities.FillComboWithValues(RangeIndicatorValueDropDownList, -20, 60, 10)
				WebExamplesUtilities.FillComboWithValues(RangeIndicatorOriginDropDownList, -20, 60, 10)
				RangeIndicatorOriginDropDownList.SelectedIndex = 5

				RangeIndicatorValueDropDownList.SelectedValue = m_Indicator1.Value.ToString()
				ValueIndicatorDropDownList.SelectedValue = m_Indicator2.Value.ToString()
			End If

			m_LinearGauge.Orientation = CType(GaugeOrientationDropDownList.SelectedIndex, LinearGaugeOrientation)

			If m_LinearGauge.Orientation = LinearGaugeOrientation.Horizontal Then
				m_LinearGauge.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(50, NRelativeUnit.ParentPercentage))
				m_LinearGauge.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(55, NRelativeUnit.ParentPercentage))
			Else
				m_LinearGauge.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(54, NRelativeUnit.ParentPercentage))
				m_LinearGauge.Size = New NSizeL(New NLength(37, NRelativeUnit.ParentPercentage), New NLength(85, NRelativeUnit.ParentPercentage))
			End If
			m_Indicator1.OriginMode = CType(RangeIndicatorOriginModeDropDownList.SelectedIndex, OriginMode)
			m_Indicator1.Origin = Convert.ToDouble(RangeIndicatorOriginDropDownList.SelectedValue)
			m_Indicator1.Value = Convert.ToDouble(RangeIndicatorValueDropDownList.SelectedValue)

			Dim factory As N2DSmartShapeFactory = New N2DSmartShapeFactory(m_Indicator2.Shape.FillStyle, m_Indicator2.Shape.StrokeStyle, m_Indicator2.Shape.ShadowStyle)
			m_Indicator2.Shape = factory.CreateShape(CType(ValueIndicatorShapeDropDownList.SelectedIndex, SmartShape2D))
			m_Indicator2.Value = Convert.ToDouble(ValueIndicatorDropDownList.SelectedValue)

			If m_Indicator1.OriginMode <> OriginMode.Custom Then
				RangeIndicatorOriginDropDownList.Enabled = False
			Else
				RangeIndicatorOriginDropDownList.Enabled = True
			End If
		End Sub

		Public Shared Function FarenheitToCelsius(ByVal farenheit As Double) As Double
			Return (farenheit - 32.0) * 5.0 / 9.0
		End Function

		Public Shared Function CelsiusToFarenheit(ByVal celsius As Double) As Double
			Return (celsius * 9.0) / 5.0 + 32.0f
		End Function

		Private Function CreateSection(ByVal tickColor As Color, ByVal labelColor As Color, ByVal range As NRange1DD) As NScaleSectionStyle
			Dim scaleSection As NScaleSectionStyle = New NScaleSectionStyle()
			scaleSection.Range = range
			scaleSection.LabelTextStyle = New NTextStyle(New NFontStyle(), tickColor)
			scaleSection.MajorTickFillStyle = New NColorFillStyle(tickColor)

			Dim labelStyle As NTextStyle = New NTextStyle()
			labelStyle.FillStyle = New NColorFillStyle(labelColor)
			labelStyle.FontStyle = New NFontStyle("Arial", 10, FontStyle.Bold)
			scaleSection.LabelTextStyle = labelStyle

			Return scaleSection
		End Function

		Private Sub ConfigureScale(ByVal scale As NLinearScaleConfigurator, ByVal text As String)
			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke)
			scale.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 10, FontStyle.Bold)
			scale.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.White)
			scale.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 90)
			scale.MinorTickCount = 4
			scale.RulerStyle.BorderStyle.Width = New NLength(0)
			scale.RulerStyle.FillStyle = New NColorFillStyle(Color.FromArgb(40, Color.DarkGray))

			scale.Title.RulerAlignment = HorzAlign.Left
			scale.Title.Text = text
			scale.Title.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.View, 0)
			scale.Title.TextStyle.FontStyle.EmSize = New NLength(12)
			scale.Title.TextStyle.FontStyle.Style = FontStyle.Bold
			scale.Title.TextStyle.FillStyle = New NGradientFillStyle(Color.White, Color.LightBlue)
			scale.Title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			scale.RoundToTickMax = False
			scale.RoundToTickMin = False
		End Sub
	End Class
End Namespace
