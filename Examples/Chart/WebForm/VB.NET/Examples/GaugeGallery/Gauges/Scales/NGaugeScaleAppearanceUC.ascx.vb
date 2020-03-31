Imports Microsoft.VisualBasic
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NGaugeScaleAppearanceUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As NLabel = New NLabel("Gauge Axis Scale Appearance")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.Location = New NPointL(New NLength(3, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
			nChartControl1.Panels.Add(header)

			' create the radial gauge
			Dim radialGauge As NRadialGaugePanel = New NRadialGaugePanel()
			radialGauge.ContentAlignment = ContentAlignment.MiddleCenter
			radialGauge.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(52, NRelativeUnit.ParentPercentage))
			radialGauge.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(85, NRelativeUnit.ParentPercentage))
			radialGauge.BackgroundFillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Gray)
			radialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)
			radialGauge.PaintEffect = New NGlassEffectStyle()

			nChartControl1.Panels.Add(radialGauge)

			Dim axis As NGaugeAxis = CType(radialGauge.Axes(0), NGaugeAxis)
			Dim scale As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)
			scale.MinorTickCount = 3

			Dim indicator1 As NRangeIndicator = New NRangeIndicator()
			indicator1.Value = 80
			indicator1.OriginMode = OriginMode.ScaleMax
			indicator1.FillStyle = New NColorFillStyle(Color.Red)
			indicator1.StrokeStyle.Color = Color.DarkRed
			radialGauge.Indicators.Add(indicator1)

			Dim indicator2 As NNeedleValueIndicator = New NNeedleValueIndicator()
			indicator2.Value = 79
			indicator2.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red)
			indicator2.Shape.StrokeStyle.Color = Color.Red
			radialGauge.Indicators.Add(indicator2)
			radialGauge.SweepAngle = 270

			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumValues(ScaleStyleDropDownList, GetType(PredefinedScaleStyle))
				ScaleStyleDropDownList.SelectedIndex = 0
			End If

			Dim scaleStyle As PredefinedScaleStyle = CType(ScaleStyleDropDownList.SelectedIndex, PredefinedScaleStyle)
			scale.SetPredefinedScaleStyle(scaleStyle)
			Select Case scaleStyle
				Case PredefinedScaleStyle.Standard, PredefinedScaleStyle.Scientific
				Case PredefinedScaleStyle.Presentation
					scale.RulerStyle.FillStyle = New NGradientFillStyle(Color.White, Color.CadetBlue)
					scale.OuterMajorTickStyle.FillStyle = New NGradientFillStyle(Color.White, Color.Green)
					scale.OuterMajorTickStyle.LineStyle.Color = Color.DarkGreen
				Case PredefinedScaleStyle.PresentationNoStroke
					scale.RulerStyle.FillStyle = New NGradientFillStyle(Color.White, Color.CadetBlue)
					scale.OuterMajorTickStyle.FillStyle = New NGradientFillStyle(Color.White, Color.Green)
				Case PredefinedScaleStyle.Watch
					scale.OuterMajorTickStyle.FillStyle = New NGradientFillStyle(Color.White, Color.Green)
					scale.OuterMajorTickStyle.LineStyle.Color = Color.DarkGreen
				Case PredefinedScaleStyle.Ruler
			End Select
		End Sub
	End Class
End Namespace
