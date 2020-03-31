Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing

Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NGaugeScaleLabelsOrientationUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As NLabel = New NLabel("Gauge Labels Orientation")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.Location = New NPointL(New NLength(3, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
			nChartControl1.Panels.Add(header)

			' create the radial gauge
			CreateRadialGauge()

			' update form controls
			If (Not IsPostBack) Then
				angleModeDropDownList.Items.Add("View")
				angleModeDropDownList.Items.Add("Scale")
				angleModeDropDownList.SelectedIndex = 1

				BeginAngleTextBox.Text = "90"
				SweepAngleTextBox.Text = "270"

				allowFlipCheckBox.Checked = False
			End If

			UpdateScaleLabelAngle()

			' apply begin and sweep angles
			Dim beginAngle As Single
			If (Not Single.TryParse(BeginAngleTextBox.Text, beginAngle)) Then
				beginAngle = 0f
				CustomAngleTextBox.Text = beginAngle.ToString()
			End If

			m_RadialGauge.BeginAngle = beginAngle

			Dim sweepAngle As Single
			If (Not Single.TryParse(SweepAngleTextBox.Text, sweepAngle)) Then
				sweepAngle = 270
				SweepAngleTextBox.Text = sweepAngle.ToString()
			End If

			m_RadialGauge.SweepAngle = sweepAngle
		End Sub

		Protected Sub UpdateScaleLabelAngle()
			' read the form control values
			Dim customAngle As Single
			If (Not Single.TryParse(CustomAngleTextBox.Text, customAngle)) OrElse customAngle < 0 OrElse customAngle > 360 Then
				customAngle = 0f
				CustomAngleTextBox.Text = customAngle.ToString()
			End If

			' update scale labels angle
			Dim angle As NScaleLabelAngle = New NScaleLabelAngle(CType(System.Enum.Parse(GetType(ScaleLabelAngleMode), angleModeDropDownList.SelectedItem.Value), ScaleLabelAngleMode), customAngle, allowFlipCheckBox.Checked)

			' apply angle to radial gauge axis
			Dim axis As NGaugeAxis = CType(m_RadialGauge.Axes(0), NGaugeAxis)
			Dim scale As NLinearScaleConfigurator = CType(axis.ScaleConfigurator, NLinearScaleConfigurator)
			scale.LabelStyle.Angle = angle
		End Sub

		Private Sub CreateRadialGauge()
			' create the radial gauge
			m_RadialGauge = New NRadialGaugePanel()
			m_RadialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)
			m_RadialGauge.PaintEffect = New NGlassEffectStyle()
			m_RadialGauge.ContentAlignment = ContentAlignment.MiddleCenter
			m_RadialGauge.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(52, NRelativeUnit.ParentPercentage))
			m_RadialGauge.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(85, NRelativeUnit.ParentPercentage))

			nChartControl1.Panels.Add(m_RadialGauge)

			' create the radial gauge
			m_RadialGauge.SweepAngle = 270
			m_RadialGauge.BeginAngle = -90

			' set some background
			Dim advGradient As NAdvancedGradientFillStyle = New NAdvancedGradientFillStyle()
			advGradient.BackgroundColor = Color.Black
			advGradient.Points.Add(New NAdvancedGradientPoint(Color.White, 10, 10, 0, 100, AGPointShape.Circle))
			m_RadialGauge.BackgroundFillStyle = advGradient

			' configure axis
			Dim axis As NGaugeAxis = CType(m_RadialGauge.Axes(0), NGaugeAxis)
			axis.Range = New NRange1DD(0, 100)
			axis.Anchor.RulerOrientation = RulerOrientation.Right
			axis.Anchor = New NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, True, RulerOrientation.Right, 0, 100)

			ConfigureScale(CType(axis.ScaleConfigurator, NLinearScaleConfigurator))

			' add some indicators
			AddRangeIndicatorToGauge(m_RadialGauge)

			Dim needle As NNeedleValueIndicator = New NNeedleValueIndicator(60)
			m_RadialGauge.Indicators.Add(needle)
		End Sub

		Private Sub ConfigureScale(ByVal scale As NLinearScaleConfigurator)
			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke)
			scale.LabelFitModes = New LabelFitMode(){}
			scale.MinorTickCount = 3
			scale.RulerStyle.FillStyle = New NColorFillStyle(Color.FromArgb(40, Color.White))
			scale.OuterMajorTickStyle.FillStyle = New NColorFillStyle(Color.Orange)
			scale.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 12, FontStyle.Bold)
			scale.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.White)
		End Sub

		Private Sub AddRangeIndicatorToGauge(ByVal gauge As NGaugePanel)
			' add some indicators
			Dim rangeIndicator As NRangeIndicator = New NRangeIndicator(New NRange1DD(75, 100))
			rangeIndicator.FillStyle = New NColorFillStyle(Color.Red)
			rangeIndicator.StrokeStyle.Width = New NLength(0)
			rangeIndicator.OffsetFromScale = New NLength(2)
			rangeIndicator.BeginWidth = New NLength(5)
			rangeIndicator.EndWidth = New NLength(10)
			rangeIndicator.PaintOrder = IndicatorPaintOrder.BeforeScale

			gauge.Indicators.Add(rangeIndicator)
		End Sub




		Private m_RadialGauge As NRadialGaugePanel
	End Class
End Namespace
