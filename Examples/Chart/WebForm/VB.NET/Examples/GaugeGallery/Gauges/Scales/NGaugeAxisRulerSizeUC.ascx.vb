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

Namespace Nevron.Examples.Chart.WebForm.Examples.GaugeGallery
	Public Partial Class NGaugeAxisRulerSizeUC
		Inherits NExampleUC
		Protected m_RadialGauge As NRadialGaugePanel

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If (Not Page.IsPostBack) Then
				WebExamplesUtilities.FillComboWithValues(RedAxisPercentDropDownList, 10, 70, 10)
				RedAxisPercentDropDownList.SelectedIndex = 6
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As NLabel = New NLabel("Gauge Axis Ruler Size")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(3, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
			nChartControl1.Panels.Add(header)

			' create the radial gauge
			m_RadialGauge = New NRadialGaugePanel()
			m_RadialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)
			m_RadialGauge.ContentAlignment = ContentAlignment.MiddleCenter
			m_RadialGauge.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(52, NRelativeUnit.ParentPercentage))
			m_RadialGauge.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(85, NRelativeUnit.ParentPercentage))
			m_RadialGauge.BackgroundFillStyle = New NGradientFillStyle(Color.DarkGray, Color.Black)
			Dim gelEffect As NGelEffectStyle = New NGelEffectStyle(PaintEffectShape.Ellipse)
			gelEffect.Margins = New NMarginsL(New NLength(0), New NLength(0), New NLength(0), New NLength(50, NRelativeUnit.ParentPercentage))

			m_RadialGauge.PaintEffect = gelEffect
			nChartControl1.Panels.Add(m_RadialGauge)

			m_RadialGauge.Axes.Clear()

			' create the first axis
			Dim axis1 As NGaugeAxis = New NGaugeAxis()
			axis1.Anchor = New NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, True, 0, 70)
			Dim scale1 As NStandardScaleConfigurator = CType(axis1.ScaleConfigurator, NStandardScaleConfigurator)
			scale1.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke)
			scale1.MinorTickCount = 3
			scale1.RulerStyle.FillStyle = New NColorFillStyle(Color.FromArgb(40, Color.White))
			scale1.OuterMajorTickStyle.FillStyle = New NColorFillStyle(Color.Orange)
			scale1.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 10, FontStyle.Bold)
			scale1.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.White)
			scale1.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0)

			m_RadialGauge.Axes.Add(axis1)

			' create the second axis
			Dim axis2 As NGaugeAxis = New NGaugeAxis()
			axis2.Anchor = New NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, False, 75, 95)
			Dim scale2 As NStandardScaleConfigurator = CType(axis2.ScaleConfigurator, NStandardScaleConfigurator)
			scale2.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke)
			scale2.MinorTickCount = 3
			scale2.RulerStyle.FillStyle = New NColorFillStyle(Color.FromArgb(40, Color.White))
			scale2.OuterMajorTickStyle.FillStyle = New NColorFillStyle(Color.Blue)
			scale2.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 10, FontStyle.Bold)
			scale2.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.White)
			scale2.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0)

			m_RadialGauge.Axes.Add(axis2)

			' add indicators
			Dim rangeIndicator As NRangeIndicator = New NRangeIndicator()
			rangeIndicator.Value = 50
			rangeIndicator.FillStyle = New NGradientFillStyle(Color.Orange, Color.Red)
			rangeIndicator.StrokeStyle.Width = New NLength(0)
			rangeIndicator.OffsetFromScale = New NLength(3)
			rangeIndicator.BeginWidth = New NLength(6)
			rangeIndicator.EndWidth = New NLength(12)
			m_RadialGauge.Indicators.Add(rangeIndicator)

			Dim needleValueIndicator1 As NNeedleValueIndicator = New NNeedleValueIndicator()
			needleValueIndicator1.Value = 79
			needleValueIndicator1.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant2, Color.White, Color.Red)
			needleValueIndicator1.Shape.StrokeStyle.Color = Color.Red
			needleValueIndicator1.Axis = axis1
			needleValueIndicator1.OffsetFromScale = New NLength(2)
			m_RadialGauge.Indicators.Add(needleValueIndicator1)
			m_RadialGauge.SweepAngle = 360

			Dim needleValueIndicator2 As NNeedleValueIndicator = New NNeedleValueIndicator()
			needleValueIndicator2.Value = 79
			needleValueIndicator2.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant2, Color.White, Color.Blue)
			needleValueIndicator2.Shape.StrokeStyle.Color = Color.Blue
			needleValueIndicator2.Axis = axis2
			needleValueIndicator2.OffsetFromScale = New NLength(-2)
			m_RadialGauge.Indicators.Add(needleValueIndicator2)

			axis1.Anchor = New NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, True, 0, CSng(Convert.ToDecimal(RedAxisPercentDropDownList.SelectedValue) - 5))
			axis2.Anchor = New NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, False, CSng(Convert.ToDecimal(RedAxisPercentDropDownList.SelectedValue)), 95)
		End Sub
	End Class
End Namespace
