using System;
using System.Drawing;

using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm 
{
	public partial class NGaugeScaleLabelsOrientationUC : NExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Gauge Labels Orientation");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.Location = new NPointL(new NLength(3, NRelativeUnit.ParentPercentage),
                                            new NLength(2, NRelativeUnit.ParentPercentage));
            nChartControl1.Panels.Add(header);

			// create the radial gauge
			CreateRadialGauge();

			// update form controls
			if (!IsPostBack)
			{
				angleModeDropDownList.Items.Add("View");
				angleModeDropDownList.Items.Add("Scale");
				angleModeDropDownList.SelectedIndex = 1;

                BeginAngleTextBox.Text = "90";
                SweepAngleTextBox.Text = "270";

				allowFlipCheckBox.Checked = false;
			}

			UpdateScaleLabelAngle();

            // apply begin and sweep angles
            float beginAngle;
            if (!float.TryParse(BeginAngleTextBox.Text, out beginAngle))
            {
                beginAngle = 0f;
                CustomAngleTextBox.Text = beginAngle.ToString();
            }

            m_RadialGauge.BeginAngle = beginAngle;

            float sweepAngle;
            if (!float.TryParse(SweepAngleTextBox.Text, out sweepAngle))
            {
                sweepAngle = 270;
                SweepAngleTextBox.Text = sweepAngle.ToString();
            }

            m_RadialGauge.SweepAngle = sweepAngle;
		}

		protected void UpdateScaleLabelAngle()
		{
			// read the form control values
			float customAngle;
			if (!float.TryParse(CustomAngleTextBox.Text, out customAngle) || customAngle < 0 || customAngle > 360)
			{
				customAngle = 0f;
				CustomAngleTextBox.Text = customAngle.ToString();
			}

			// update scale labels angle
			NScaleLabelAngle angle = new NScaleLabelAngle((ScaleLabelAngleMode)Enum.Parse(typeof(ScaleLabelAngleMode), angleModeDropDownList.SelectedItem.Value),
															   customAngle,
															   allowFlipCheckBox.Checked);

			// apply angle to radial gauge axis
			NGaugeAxis axis = (NGaugeAxis)m_RadialGauge.Axes[0];
			NLinearScaleConfigurator scale = (NLinearScaleConfigurator)axis.ScaleConfigurator;
			scale.LabelStyle.Angle = angle;
		}

		private void CreateRadialGauge()
		{
            // create the radial gauge
            m_RadialGauge = new NRadialGaugePanel();
            m_RadialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
            m_RadialGauge.PaintEffect = new NGlassEffectStyle();
            m_RadialGauge.ContentAlignment = ContentAlignment.MiddleCenter;
            m_RadialGauge.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(52, NRelativeUnit.ParentPercentage));
            m_RadialGauge.Size = new NSizeL(new NLength(90, NRelativeUnit.ParentPercentage), new NLength(85, NRelativeUnit.ParentPercentage));

            nChartControl1.Panels.Add(m_RadialGauge);

            // create the radial gauge
            m_RadialGauge.SweepAngle = 270;
            m_RadialGauge.BeginAngle = -90;

            // set some background
            NAdvancedGradientFillStyle advGradient = new NAdvancedGradientFillStyle();
            advGradient.BackgroundColor = Color.Black;
            advGradient.Points.Add(new NAdvancedGradientPoint(Color.White, 10, 10, 0, 100, AGPointShape.Circle));
            m_RadialGauge.BackgroundFillStyle = advGradient;

            // configure axis
            NGaugeAxis axis = (NGaugeAxis)m_RadialGauge.Axes[0];
            axis.Range = new NRange1DD(0, 100);
            axis.Anchor.RulerOrientation = RulerOrientation.Right;
            axis.Anchor = new NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, true, RulerOrientation.Right, 0, 100);

            ConfigureScale((NLinearScaleConfigurator)axis.ScaleConfigurator);

            // add some indicators
            AddRangeIndicatorToGauge(m_RadialGauge);

            NNeedleValueIndicator needle = new NNeedleValueIndicator(60);
            m_RadialGauge.Indicators.Add(needle);
		}

        private void ConfigureScale(NLinearScaleConfigurator scale)
        {
            scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke);
            scale.LabelFitModes = new LabelFitMode[0];
            scale.MinorTickCount = 3;
            scale.RulerStyle.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.White));
            scale.OuterMajorTickStyle.FillStyle = new NColorFillStyle(Color.Orange);
            scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 12, FontStyle.Bold);
            scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);
        }

        private void AddRangeIndicatorToGauge(NGaugePanel gauge)
        {
            // add some indicators
            NRangeIndicator rangeIndicator = new NRangeIndicator(new NRange1DD(75, 100));
            rangeIndicator.FillStyle = new NColorFillStyle(Color.Red);
            rangeIndicator.StrokeStyle.Width = new NLength(0);
            rangeIndicator.OffsetFromScale = new NLength(2);
            rangeIndicator.BeginWidth = new NLength(5);
            rangeIndicator.EndWidth = new NLength(10);
            rangeIndicator.PaintOrder = IndicatorPaintOrder.BeforeScale;

            gauge.Indicators.Add(rangeIndicator);
        }



		
		private NRadialGaugePanel m_RadialGauge;
	}
}
