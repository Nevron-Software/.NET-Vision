Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.Chart.ThinWeb
Imports Nevron.GraphicsCore
Imports Nevron.SmartShapes

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NCustomCommandsUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If (Not nChartControl1.Initialized) Then
				nChartControl1.BackgroundStyle.FrameStyle.Visible = False
				nChartControl1.Panels.Clear()
				nChartControl1.StateId = "Gauge1"

				' set a chart title
				Dim header As NLabel = New NLabel("Custom Commands")
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

				' update the knob marker shape
				Dim factory As N2DSmartShapeFactory = New N2DSmartShapeFactory(knobIndicator.MarkerShape.FillStyle, knobIndicator.MarkerShape.StrokeStyle, knobIndicator.MarkerShape.ShadowStyle)
				knobIndicator.MarkerShape = factory.CreateShape(SmartShape2D.Ellipse)
				' update the outer rim style
				knobIndicator.OuterRimStyle.Pattern = CircularRimPattern.RoundHandleSmall
				' update the inner rim style
				knobIndicator.InnerRimStyle.Pattern = CircularRimPattern.Circle

				Dim indicatorDragTool As NIndicatorDragTool = New NIndicatorDragTool()
				indicatorDragTool.IndicatorDragCallback = New IndicatorDragCallback()
				nChartControl1.Controller.Tools.Add(indicatorDragTool)
			End If
		End Sub

		<Serializable> _
		Public Class IndicatorDragCallback
            Implements INIndicatorDragCallback
			#Region "INIndicatorDragCallback Members"

			Private Sub OnIndicatorValueChanged(ByVal control As NThinChartControl, ByVal gauge As NGaugePanel, ByVal indicator As NIndicator, ByVal oldValue As Double, ByVal newValue As Double) Implements INIndicatorDragCallback.OnIndicatorValueChanged
				control.AddCustomClientCommand(newValue.ToString("00.00"))
			End Sub

			#End Region
		End Class
	End Class
End Namespace
