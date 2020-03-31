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
		Protected m_LinearGauge As NLinearGaugePanel

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			' first clear all gauges
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Gauge Glass and Gel Effects")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.FillStyle = New NColorFillStyle(Color.FromArgb(60, 90, 108))
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' create the radial gauge
			CreateRadialGauge()

			' create the linear gauge
			CreateLinearGauge()

			m_RadialGauge.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
			m_RadialGauge.Size = New NSizeL(New NLength(45, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))
			m_RadialGauge.ContentAlignment = ContentAlignment.BottomRight

			m_LinearGauge.Location = New NPointL(New NLength(60, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
			m_LinearGauge.Size = New NSizeL(New NLength(80, NGraphicsUnit.Point), New NLength(80, NRelativeUnit.ParentPercentage))
			m_LinearGauge.Padding = New NMarginsL(0, 13, 0, 13)

			If (Not IsPostBack) Then
				ShowGlassOnRadialGauge.Checked = True
				ShowGelOnLinearGauge.Checked = True
			End If

			' apply paint effects to the gauges
			If ShowGlassOnRadialGauge.Checked Then
				m_RadialGauge.PaintEffect = New NGlassEffectStyle()
			End If

			If ShowGelOnLinearGauge.Checked Then
				m_LinearGauge.PaintEffect = New NGelEffectStyle()
			End If
		End Sub

		Private Sub ApplyScaleSectionToAxis(ByVal scale As NLinearScaleConfigurator)
			Dim scaleSection As NScaleSectionStyle = New NScaleSectionStyle()

			scaleSection.Range = New NRange1DD(70, 100)
			scaleSection.LabelTextStyle = New NTextStyle()
			scaleSection.LabelTextStyle.FillStyle = New NColorFillStyle(KnownArgbColorValue.DarkRed)
			scaleSection.LabelTextStyle.FontStyle = New NFontStyle("Arial", 8, FontStyle.Bold)
			scaleSection.MajorTickStrokeStyle = New NStrokeStyle(Color.DarkRed)

			scale.Sections.Add(scaleSection)
		End Sub

		Private Sub CreateLinearGauge()
			m_LinearGauge = New NLinearGaugePanel()
			m_LinearGauge.Orientation = LinearGaugeOrientation.Vertical
			nChartControl1.Panels.Add(m_LinearGauge)

			' create the background panel
			m_LinearGauge.BackgroundFillStyle = New NColorFillStyle(Color.Black)
			m_LinearGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.RoundedRect)

			Dim axis As NGaugeAxis = CType(m_LinearGauge.Axes(0), NGaugeAxis)
			axis.Anchor = New NModelGaugeAxisAnchor(New NLength(10, NGraphicsUnit.Point), VertAlign.Center, RulerOrientation.Left)
			ConfigureScale(CType(axis.ScaleConfigurator, NLinearScaleConfigurator))

			' add some indicators
			AddRangeIndicatorToGauge(m_LinearGauge)
			m_LinearGauge.Indicators.Add(New NMarkerValueIndicator(60))
		End Sub

		Private Sub CreateRadialGauge()
			' create the radial gauge
			m_RadialGauge = New NRadialGaugePanel()
			m_RadialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)
			nChartControl1.Panels.Add(m_RadialGauge)

			' create the radial gauge
			m_RadialGauge.SweepAngle = 270
			m_RadialGauge.BeginAngle = -90

			' set some background
			m_RadialGauge.BackgroundFillStyle = New NColorFillStyle(Color.Black)


			' configure the axis
			Dim axis As NGaugeAxis = CType(m_RadialGauge.Axes(0), NGaugeAxis)
			axis.Range = New NRange1DD(0, 100)
			axis.Anchor.RulerOrientation = RulerOrientation.Right
			axis.Anchor = New NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, True, RulerOrientation.Right, 0, 100)

			ConfigureScale(CType(axis.ScaleConfigurator, NLinearScaleConfigurator))

			' add some indicators
			AddRangeIndicatorToGauge(m_RadialGauge)

			Dim needle As NNeedleValueIndicator = New NNeedleValueIndicator(60)
			needle.OffsetOriginMode = IndicatorOffsetOriginMode.ScaleMiddle
			m_RadialGauge.Indicators.Add(needle)
		End Sub

		Private Sub AddRangeIndicatorToGauge(ByVal gauge As NGaugePanel)
			' add some indicators
			Dim rangeIndicator As NRangeIndicator = New NRangeIndicator(New NRange1DD(75, 100))
			rangeIndicator.FillStyle = New NColorFillStyle(Color.Red)
			rangeIndicator.StrokeStyle.Width = New NLength(0)
			rangeIndicator.BeginWidth = New NLength(5)
			rangeIndicator.EndWidth = New NLength(10)
			rangeIndicator.OffsetFromScale = New NLength(-10)
			rangeIndicator.PaintOrder = IndicatorPaintOrder.BeforeScale

			gauge.Indicators.Add(rangeIndicator)
		End Sub

		Private Sub ConfigureScale(ByVal scale As NLinearScaleConfigurator)
			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke)
			scale.LabelFitModes = New LabelFitMode(){}
			scale.MinorTickCount = 3
			scale.RulerStyle.FillStyle = New NColorFillStyle(Color.FromArgb(40, Color.White))
			scale.OuterMajorTickStyle.FillStyle = New NColorFillStyle(Color.Orange)
			scale.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 8, FontStyle.Bold)
			scale.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.White)
		End Sub
	End Class
End Namespace
