Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.ThinWeb
Imports Nevron.Chart
Imports Nevron.Chart.ThinWeb
Imports Nevron.GraphicsCore
Imports Nevron.Dom

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NIndicatorDragToolUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not NThinChartControl1.Initialized) Then
				NThinChartControl1.BackgroundStyle.FrameStyle.Visible = False
				NThinChartControl1.Panels.Clear()

				' set a chart title
				Dim header As NLabel = New NLabel("Indicator Drag Tool")
				header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
				header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
				header.ContentAlignment = ContentAlignment.BottomRight
				header.Location = New NPointL(New NLength(3, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
				NThinChartControl1.Panels.Add(header)

				' create the radial gauge
				Dim m_RadialGauge As NRadialGaugePanel = New NRadialGaugePanel()
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
				Dim rangeIndicator As NRangeIndicator = New NRangeIndicator()
				rangeIndicator.Value = 20
				rangeIndicator.FillStyle = New NGradientFillStyle(Color.Yellow, Color.Red)
				rangeIndicator.StrokeStyle.Color = Color.DarkBlue
				rangeIndicator.EndWidth = New NLength(20)

				Dim interactivityStyle1 As NInteractivityStyle = New NInteractivityStyle()
				interactivityStyle1.Tooltip.Text = "Drag Me"
'              interactivityStyle1.ClientMouseEventAttribute.Tag = "Indicator[" + m_Indicator1.UniqueId.ToString() + "]";

				rangeIndicator.InteractivityStyle = interactivityStyle1

				m_RadialGauge.Indicators.Add(rangeIndicator)

				Dim needleIndicator As NNeedleValueIndicator = New NNeedleValueIndicator()
				needleIndicator.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red)
				needleIndicator.Shape.StrokeStyle.Color = Color.Red
				m_RadialGauge.Indicators.Add(needleIndicator)
				m_RadialGauge.SweepAngle = 270

				' add radial gauge
				NThinChartControl1.Panels.Add(m_RadialGauge)

				' create and config ure a numeric display attached to the radial gauge
				Dim numericDisplay As NNumericDisplayPanel = New NNumericDisplayPanel()
				numericDisplay.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage))
				numericDisplay.ContentAlignment = ContentAlignment.TopCenter
				numericDisplay.DisplayStyle = DisplayStyle.SevenSegmentRounded
				numericDisplay.SegmentWidth = New NLength(2, NGraphicsUnit.Point)
				numericDisplay.SegmentGap = New NLength(1, NGraphicsUnit.Point)
				numericDisplay.CellSize = New NSizeL(New NLength(9, NGraphicsUnit.Point), New NLength(19, NGraphicsUnit.Point))
				numericDisplay.ShowDecimalSeparator = True
				numericDisplay.ShowLeadingZeros = True
				numericDisplay.EnableDecimalFormatting = False
				numericDisplay.CellCountMode = DisplayCellCountMode.Auto
				numericDisplay.CellCount = 6
				numericDisplay.ValueFormatter = New NNumericValueFormatter("00.00")

				numericDisplay.CellAlignment = VertAlign.Top
				numericDisplay.BackgroundFillStyle = New NColorFillStyle(Color.DimGray)
				numericDisplay.LitFillStyle = New NGradientFillStyle(Color.Lime, Color.Green)
				numericDisplay.CellCountMode = DisplayCellCountMode.Fixed
				numericDisplay.CellCount = 6
				numericDisplay.Padding = New NMarginsL(3, 2, 3, 2)
				m_RadialGauge.ChildPanels.Add(numericDisplay)

				' create a sunken border around the display
				Dim borderStyle As NEdgeBorderStyle = New NEdgeBorderStyle(BorderShape.RoundedRect)
				borderStyle.OuterBevelWidth = New NLength(0)
				borderStyle.MiddleBevelWidth = New NLength(0)
				numericDisplay.BorderStyle = borderStyle

				Dim indicatorDragTool As NIndicatorDragTool = New NIndicatorDragTool()
				indicatorDragTool.IndicatorDragCallback = New IndicatorDragCallback()
				NThinChartControl1.Controller.Tools.Add(indicatorDragTool)
				NThinChartControl1.Controller.Tools.Add(New NTooltipTool())
			End If

			Dim range As NRangeIndicator = CType(NThinChartControl1.Gauges(0).Indicators(0), NRangeIndicator)
			range.AllowDragging = EnableRangeIndicatorDraggingCheckBox.Checked

			If range.AllowDragging Then
				range.InteractivityStyle.Tooltip.Text = "Drag Me"
			Else
				range.InteractivityStyle.Tooltip.Text = range.Range.End.ToString()
			End If

			Dim needle As NNeedleValueIndicator = CType(NThinChartControl1.Gauges(0).Indicators(1), NNeedleValueIndicator)
			needle.AllowDragging = EnableNeedleIndicatorDraggingCheckBox.Checked

			If needle.AllowDragging Then
				needle.InteractivityStyle.Tooltip.Text = "Drag Me"
			Else
				needle.InteractivityStyle.Tooltip.Text = needle.Value.ToString()
			End If


		End Sub

		<Serializable> _
		Public Class IndicatorDragCallback
            Implements INIndicatorDragCallback
			#Region "INIndicatorDragCallback Members"

			Private Sub OnIndicatorValueChanged(ByVal control As NThinChartControl, ByVal gauge As NGaugePanel, ByVal indicator As NIndicator, ByVal oldValue As Double, ByVal newValue As Double) Implements INIndicatorDragCallback.OnIndicatorValueChanged
				control.NumericDisplays(0).Value = indicator.Value
			End Sub

			#End Region
		End Class
	End Class
End Namespace
