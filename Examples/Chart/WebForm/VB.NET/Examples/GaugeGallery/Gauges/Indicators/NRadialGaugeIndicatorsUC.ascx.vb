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
	Public Partial Class NRadialGaugeIndicatorsUC
		Inherits NExampleUC
		Protected m_RadialGauge As NRadialGaugePanel
		Protected m_Indicator1 As NRangeIndicator
		Protected m_Indicator2 As NNeedleValueIndicator
		Protected m_NumericDisplay As NNumericDisplayPanel

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As NLabel = New NLabel("Radial Gauge Indicators")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(3, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
			nChartControl1.Panels.Add(header)

			' create the radial gauge
			m_RadialGauge = New NRadialGaugePanel()
			m_RadialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)
			m_RadialGauge.PaintEffect = New NGlassEffectStyle()
			m_RadialGauge.ContentAlignment = ContentAlignment.MiddleCenter
			m_RadialGauge.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(52, NRelativeUnit.ParentPercentage))
			m_RadialGauge.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(85, NRelativeUnit.ParentPercentage))
			m_RadialGauge.BackgroundFillStyle = New NGradientFillStyle(Color.DarkGray, Color.Black)

			' configure scale
			Dim axis As NGaugeAxis = CType(m_RadialGauge.Axes(0), NGaugeAxis)
			Dim scale As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)

			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.Presentation)
			scale.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 10, FontStyle.Bold)
			scale.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.White)
			scale.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0)
			scale.MinorTickCount = 4
			scale.RulerStyle.BorderStyle.Width = New NLength(0)
			scale.RulerStyle.FillStyle = New NColorFillStyle(Color.DarkGray)

			' add radial gauge indicators
			m_Indicator1 = New NRangeIndicator()
			m_Indicator1.Value = 20
			m_Indicator1.FillStyle = New NGradientFillStyle(Color.Yellow, Color.Red)
			m_Indicator1.StrokeStyle.Color = Color.DarkBlue
			m_Indicator1.EndWidth = New NLength(20)
			m_RadialGauge.Indicators.Add(m_Indicator1)

			m_Indicator2 = New NNeedleValueIndicator()
			m_Indicator2.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red)
			m_Indicator2.Shape.StrokeStyle.Color = Color.Red
			m_RadialGauge.Indicators.Add(m_Indicator2)
			m_RadialGauge.SweepAngle = 270

			' add radial gauge
			nChartControl1.Panels.Add(m_RadialGauge)

			' create and configure a numeric display attached to the radial gauge
			m_NumericDisplay = New NNumericDisplayPanel()
			m_NumericDisplay.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage))
			m_NumericDisplay.ContentAlignment = ContentAlignment.TopCenter
			m_NumericDisplay.DisplayStyle = DisplayStyle.SevenSegmentRounded
			m_NumericDisplay.SegmentWidth = New NLength(2, NGraphicsUnit.Point)
			m_NumericDisplay.SegmentGap = New NLength(1, NGraphicsUnit.Point)
			m_NumericDisplay.CellSize = New NSizeL(New NLength(10, NGraphicsUnit.Point), New NLength(20, NGraphicsUnit.Point))
			m_NumericDisplay.DecimalCellSize = New NSizeL(New NLength(7, NGraphicsUnit.Point), New NLength(15, NGraphicsUnit.Point))
			m_NumericDisplay.ShowDecimalSeparator = False
			m_NumericDisplay.CellAlignment = VertAlign.Top
			m_NumericDisplay.BackgroundFillStyle = New NColorFillStyle(Color.DimGray)
			m_NumericDisplay.LitFillStyle = New NGradientFillStyle(Color.Lime, Color.Green)
			m_NumericDisplay.CellCountMode = DisplayCellCountMode.Fixed
			m_NumericDisplay.CellCount = 6
			m_NumericDisplay.Padding = New NMarginsL(3, 2, 3, 2)
			m_RadialGauge.ChildPanels.Add(m_NumericDisplay)

			' create a sunken border around the display
			Dim borderStyle As NEdgeBorderStyle = New NEdgeBorderStyle(BorderShape.RoundedRect)
			borderStyle.OuterBevelWidth = New NLength(0)
			borderStyle.MiddleBevelWidth = New NLength(0)
			m_NumericDisplay.BorderStyle = borderStyle

			' init form controls
			If (Not Page.IsPostBack) Then
				WebExamplesUtilities.FillComboWithValues(ValueIndicatorDropDownList, 0, 100, 10)
				WebExamplesUtilities.FillComboWithValues(RangeIndicatorValueDropDownList, 0, 100, 10)
				WebExamplesUtilities.FillComboWithValues(RangeIndicatorOriginDropDownList, 0, 100, 10)

				WebExamplesUtilities.FillComboWithValues(SweepAngleDropDownList, -360, 360, 45)
				WebExamplesUtilities.FillComboWithValues(BeginAngleDropDownList, -360, 360, 45)

				SweepAngleDropDownList.SelectedValue = m_RadialGauge.SweepAngle.ToString()
				BeginAngleDropDownList.SelectedValue = m_RadialGauge.BeginAngle.ToString()

				WebExamplesUtilities.FillComboWithEnumValues(ValueIndicatorShapeDropDownList, GetType(SmartShape1D))
				ValueIndicatorShapeDropDownList.SelectedIndex = CInt(Fix(SmartShape1D.Triangle))

				ValueIndicatorDropDownList.SelectedValue = "20"
				RangeIndicatorValueDropDownList.SelectedValue = m_Indicator1.Value.ToString()

				WebExamplesUtilities.FillComboWithEnumValues(RangeIndicatorOriginModeDropDownList, GetType(OriginMode))
				RangeIndicatorOriginModeDropDownList.SelectedIndex = 0
				RangeIndicatorOriginDropDownList.SelectedIndex = 0
			End If

			m_Indicator1.Value = Convert.ToDouble(RangeIndicatorValueDropDownList.SelectedValue)
			m_Indicator1.Origin = Convert.ToDouble(RangeIndicatorOriginDropDownList.SelectedValue)
			m_Indicator1.OriginMode = CType(RangeIndicatorOriginModeDropDownList.SelectedIndex, OriginMode)
			m_RadialGauge.BeginAngle = CSng(Convert.ToDecimal(BeginAngleDropDownList.SelectedValue))
			m_RadialGauge.SweepAngle = CSng(Convert.ToDecimal(SweepAngleDropDownList.SelectedValue))

			Dim factory As N1DSmartShapeFactory = New N1DSmartShapeFactory(m_Indicator2.Shape.FillStyle, m_Indicator2.Shape.StrokeStyle, m_Indicator2.Shape.ShadowStyle)
			m_Indicator2.Shape = factory.CreateShape(CType(ValueIndicatorShapeDropDownList.SelectedIndex, SmartShape1D))
			m_Indicator2.Value = Convert.ToDouble(ValueIndicatorDropDownList.SelectedValue)
			m_NumericDisplay.Value = m_Indicator2.Value

			If m_Indicator1.OriginMode <> OriginMode.Custom Then
				RangeIndicatorOriginDropDownList.Enabled = False
			Else
				RangeIndicatorOriginDropDownList.Enabled = True
			End If
		End Sub
	End Class
End Namespace
