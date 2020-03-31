Imports Microsoft.VisualBasic
Imports System

Imports System.Drawing

Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NGaugeCustomRangeLabelsUC
		Inherits NExampleUC
		Private m_LinearGauge As NLinearGaugePanel
		Private m_RadialGauge As NRadialGaugePanel

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.Panels.Clear()
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			If (Not IsPostBack) Then
				' init form default values
				ShowMinRangeCheckBox.Checked = True
				ShowMaxRangeCheckBox.Checked = True
			End If

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Gauge Custom Range Labels<br/><font size = '9pt'>Demonstrates how to use custom range labels to denote ranges on a scale</font>")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.TextStyle.TextFormat = TextFormat.XML
			header.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(3, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' create the radial gauge
			CreateRadialGauge()

			' create the linear gauge
			CreateLinearGauge()

			m_RadialGauge.Location = New NPointL(New NLength(0, NRelativeUnit.ParentPercentage), New NLength(20, NRelativeUnit.ParentPercentage))
			m_RadialGauge.Size = New NSizeL(New NLength(60, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))
			m_RadialGauge.ContentAlignment = ContentAlignment.BottomRight

			m_LinearGauge.Location = New NPointL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(20, NRelativeUnit.ParentPercentage))
			m_LinearGauge.Size = New NSizeL(New NLength(80, NGraphicsUnit.Point), New NLength(80, NRelativeUnit.ParentPercentage))
			m_LinearGauge.Padding = New NMarginsL(0, 13, 0, 13)
			m_LinearGauge.Orientation = LinearGaugeOrientation.Vertical
		End Sub

		Private Sub CreateLinearGauge()
			m_LinearGauge = New NLinearGaugePanel()
			nChartControl1.Panels.Add(m_LinearGauge)

			' create the background panel
			Dim advGradient As NAdvancedGradientFillStyle = New NAdvancedGradientFillStyle()
			advGradient.BackgroundColor = Color.Black
			advGradient.Points.Add(New NAdvancedGradientPoint(Color.LightGray, 10, 10, 0, 100, AGPointShape.Circle))
			m_LinearGauge.BackgroundFillStyle = advGradient
			m_LinearGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.RoundedRect)

			Dim axis As NGaugeAxis = CType(m_LinearGauge.Axes(0), NGaugeAxis)
			axis.Anchor = New NModelGaugeAxisAnchor(New NLength(20, NGraphicsUnit.Point), VertAlign.Center, RulerOrientation.Left)
			ConfigureScale(CType(axis.ScaleConfigurator, NLinearScaleConfigurator))

			' add some indicators
			m_LinearGauge.Indicators.Add(New NMarkerValueIndicator(60))
		End Sub

		Private Sub CreateRadialGauge()
			' create the radial gauge
			m_RadialGauge = New NRadialGaugePanel()
			m_RadialGauge.PaintEffect = New NGlassEffectStyle()
			m_RadialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)
			nChartControl1.Panels.Add(m_RadialGauge)

			' create the radial gauge
			m_RadialGauge.SweepAngle = 270
			m_RadialGauge.BeginAngle = -90

			' set some background
			Dim advGradient As NAdvancedGradientFillStyle = New NAdvancedGradientFillStyle()
			advGradient.BackgroundColor = Color.Black
			advGradient.Points.Add(New NAdvancedGradientPoint(Color.LightGray, 10, 10, 0, 100, AGPointShape.Circle))
			m_RadialGauge.BackgroundFillStyle = advGradient

			' configure the axis
			Dim axis As NGaugeAxis = CType(m_RadialGauge.Axes(0), NGaugeAxis)
			axis.Range = New NRange1DD(0, 100)
			axis.Anchor.RulerOrientation = RulerOrientation.Right
			axis.Anchor = New NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, True, RulerOrientation.Right, 0, 100)

			ConfigureScale(CType(axis.ScaleConfigurator, NLinearScaleConfigurator))

			' add some indicators
			Dim needle As NNeedleValueIndicator = New NNeedleValueIndicator(60)
			needle.OffsetFromScale = New NLength(0)
			m_RadialGauge.Indicators.Add(needle)
		End Sub

		Private Sub ConfigureScale(ByVal scale As NLinearScaleConfigurator)
			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke)
			scale.LabelFitModes = New LabelFitMode(){}
			scale.MinorTickCount = 3
			scale.RulerStyle.FillStyle = New NColorFillStyle(Color.FromArgb(40, Color.White))
			scale.OuterMajorTickStyle.FillStyle = New NColorFillStyle(Color.Orange)
			scale.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 10, FontStyle.Bold)
			scale.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.White)

			If ShowMinRangeCheckBox.Checked Then
				ApplyScaleSectionToAxis(scale, "Min", New NRange1DD(0, 20), Color.LightBlue)
			End If

			If ShowMaxRangeCheckBox.Checked Then
				ApplyScaleSectionToAxis(scale, "Max", New NRange1DD(80, 100), Color.Red)
			End If
		End Sub

		Private Sub ApplyScaleSectionToAxis(ByVal scale As NLinearScaleConfigurator, ByVal text As String, ByVal range As NRange1DD, ByVal color As Color)
			Dim scaleSection As NScaleSectionStyle = New NScaleSectionStyle()

			scaleSection.Range = range
			scaleSection.LabelTextStyle = New NTextStyle()
			scaleSection.LabelTextStyle.FillStyle = New NColorFillStyle(color)
			scaleSection.LabelTextStyle.FontStyle = New NFontStyle("Arial", 10, FontStyle.Bold Or FontStyle.Italic)
			scaleSection.MajorTickStrokeStyle = New NStrokeStyle(color)

			scale.Sections.Add(scaleSection)

			Dim rangeLabel As NCustomRangeLabel = New NCustomRangeLabel(range, text)
			rangeLabel.Style.WrapText = False
			rangeLabel.Style.KeepInsideRuler = False
			rangeLabel.Style.StrokeStyle.Color = color
			rangeLabel.Style.TextStyle.FillStyle = New NColorFillStyle(Color.White)
			rangeLabel.Style.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0)
			rangeLabel.Style.TickMode = RangeLabelTickMode.Center
			scale.CustomLabels.Add(rangeLabel)
		End Sub
	End Class
End Namespace
