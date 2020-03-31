using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NSimpleFlash2DUC : NExampleUC
	{
		NRadialGaugePanel m_RadialGauge;
		NLinearGaugePanel m_LinearGauge;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				// init form controls
				WebExamplesUtilities.FillComboWithEnumValues(AnimationThemeTypeCombo, typeof(AnimationThemeType));
				AnimationThemeTypeCombo.SelectedIndex = (int)AnimationThemeType.ScaleAndFade;

				WebExamplesUtilities.FillComboWithValues(AxesAnimationDurationCombo, 1, 10, 1);
				AxesAnimationDurationCombo.SelectedIndex = 2;
				WebExamplesUtilities.FillComboWithValues(IndicatorsAnimationDurationCombo, 1, 10, 1);
				IndicatorsAnimationDurationCombo.SelectedIndex = 2;
			}

			nChartControl1.Panels.Clear();
			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddHeader("Animation Themes");
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			header.TextStyle.TextFormat = TextFormat.XML;
			header.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left;
			header.ContentAlignment = ContentAlignment.BottomRight;
			header.Location = new NPointL(new NLength(3, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// create the radial gauge
			CreateRadialGauge();

			// create the linear gauge
			CreateLinearGauge();

			m_RadialGauge.Location = new NPointL(new NLength(0, NRelativeUnit.ParentPercentage), new NLength(20, NRelativeUnit.ParentPercentage));
			m_RadialGauge.Size = new NSizeL(new NLength(60, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
			m_RadialGauge.ContentAlignment = ContentAlignment.BottomRight;

			m_LinearGauge.Location = new NPointL(new NLength(70, NRelativeUnit.ParentPercentage), new NLength(20, NRelativeUnit.ParentPercentage));
			m_LinearGauge.Size = new NSizeL(new NLength(80, NGraphicsUnit.Point), new NLength(80, NRelativeUnit.ParentPercentage));
			m_LinearGauge.Padding = new NMarginsL(0, 13, 0, 13);
			m_LinearGauge.Orientation = LinearGaugeOrientation.Vertical;

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// apply animation theme             
			NAnimationTheme animationTheme = new NAnimationTheme();

			animationTheme.AxesAnimationDuration = (float)(AxesAnimationDurationCombo.SelectedIndex + 1);
			animationTheme.IndicatorsAnimationDuration = (float)(IndicatorsAnimationDurationCombo.SelectedIndex + 1);

			animationTheme.AnimatePanelsSequentially = SequentialPanels.Checked;
			animationTheme.AnimateGaugesSequentially = SequentialGauges.Checked;
			animationTheme.AnimateIndicatorsSequentially = SequentialIndicators.Checked;

			animationTheme.AnimationThemeType = (AnimationThemeType)AnimationThemeTypeCombo.SelectedIndex;
			animationTheme.Apply(nChartControl1.Document);

			NImageResponse swfResponse = new NImageResponse();
			swfResponse.ImageFormat = new NSwfImageFormat();

			nChartControl1.ImageAcquisitionMode = ClientSideImageAcquisitionMode.TempFile;
			nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = swfResponse;
		}

		private void CreateLinearGauge()
		{
			m_LinearGauge = new NLinearGaugePanel();
			nChartControl1.Panels.Add(m_LinearGauge);

			// create the background panel
			NAdvancedGradientFillStyle advGradient = new NAdvancedGradientFillStyle();
			advGradient.BackgroundColor = Color.Black;
			advGradient.Points.Add(new NAdvancedGradientPoint(Color.LightGray, 10, 10, 0, 100, AGPointShape.Circle));
			m_LinearGauge.BackgroundFillStyle = advGradient;
			m_LinearGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.RoundedRect);

			NGaugeAxis axis = (NGaugeAxis)m_LinearGauge.Axes[0];
			axis.Anchor = new NModelGaugeAxisAnchor(new NLength(20, NGraphicsUnit.Point), VertAlign.Center, RulerOrientation.Left);
			ConfigureScale((NLinearScaleConfigurator)axis.ScaleConfigurator);

			// add some indicators
			m_LinearGauge.Indicators.Add(new NMarkerValueIndicator(20));
			m_LinearGauge.Indicators.Add(new NMarkerValueIndicator(60));
		}

		private void CreateRadialGauge()
		{
			// create the radial gauge
			m_RadialGauge = new NRadialGaugePanel();
			m_RadialGauge.PaintEffect = new NGlassEffectStyle();
			m_RadialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
			nChartControl1.Panels.Add(m_RadialGauge);

			// create the radial gauge
			m_RadialGauge.SweepAngle = 270;
			m_RadialGauge.BeginAngle = -90;

			// set some background
			NAdvancedGradientFillStyle advGradient = new NAdvancedGradientFillStyle();
			advGradient.BackgroundColor = Color.Black;
			advGradient.Points.Add(new NAdvancedGradientPoint(Color.LightGray, 10, 10, 0, 100, AGPointShape.Circle));
			m_RadialGauge.BackgroundFillStyle = advGradient;

			// configure the axis
			NGaugeAxis axis = (NGaugeAxis)m_RadialGauge.Axes[0];
			axis.Range = new NRange1DD(0, 100);
			axis.Anchor.RulerOrientation = RulerOrientation.Right;
			axis.Anchor = new NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, true, RulerOrientation.Right, 0, 100);

			ConfigureScale((NLinearScaleConfigurator)axis.ScaleConfigurator);

			// add some indicators
			NNeedleValueIndicator needle = new NNeedleValueIndicator(20);
			needle.OffsetFromScale = new NLength(0);
			needle = new NNeedleValueIndicator(60);
			needle.OffsetFromScale = new NLength(0);
			m_RadialGauge.Indicators.Add(needle);
		}

		private void ConfigureScale(NLinearScaleConfigurator scale)
		{
			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke);
			scale.LabelFitModes = new LabelFitMode[0];
			scale.MinorTickCount = 3;
			scale.RulerStyle.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.White));
			scale.OuterMajorTickStyle.FillStyle = new NColorFillStyle(Color.Orange);
			scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 10, FontStyle.Bold);
			scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);
		}
	}
}
