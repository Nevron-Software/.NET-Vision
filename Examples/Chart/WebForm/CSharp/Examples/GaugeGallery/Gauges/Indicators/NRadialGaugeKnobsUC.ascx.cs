using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.SmartShapes;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NRadialGaugeKnobsUC : NExampleUC
	{
		protected NRadialGaugePanel m_RadialGauge;
		protected NRangeIndicator m_Indicator1;
		protected NNeedleValueIndicator m_Indicator2;
		protected NNumericDisplayPanel m_NumericDisplay;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Panels.Clear();

			// set a chart title
            NLabel header = new NLabel("Radial Gauge Knob Indicators");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
			header.DockMode = PanelDockMode.Top;
            header.Location = new NPointL(new NLength(3, NRelativeUnit.ParentPercentage),
                                            new NLength(2, NRelativeUnit.ParentPercentage));
            nChartControl1.Panels.Add(header);

			// create the radial gauge
			NRadialGaugePanel radialGauge = new NRadialGaugePanel();
			nChartControl1.Panels.Add(radialGauge);
			radialGauge.DockMode = PanelDockMode.Fill;
			radialGauge.ContentAlignment = ContentAlignment.MiddleCenter;
			radialGauge.SweepAngle = 270;
			radialGauge.BeginAngle = -225;
			radialGauge.CapStyle.Visible = false;

			// configure the gauge scale
			NGaugeAxis axis = (NGaugeAxis)radialGauge.Axes[0];
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;

			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke);
			scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 12, FontStyle.Italic);
			scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.Black);
			scale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);
			scale.MinorTickCount = 4;
			scale.RulerStyle.BorderStyle.Width = new NLength(0);
			scale.RulerStyle.FillStyle = new NColorFillStyle(Color.DarkGray);

			// create the knob indicator
			NKnobIndicator knobIndicator = new NKnobIndicator();
			knobIndicator.OffsetFromScale = new NLength(-3);

			// apply fill style to the marker
			NAdvancedGradientFillStyle advancedGradientFill = new NAdvancedGradientFillStyle();
			advancedGradientFill.BackgroundColor = Color.Red;
			advancedGradientFill.Points.Add(new NAdvancedGradientPoint(Color.White, 20, 20, 0, 100, AGPointShape.Circle));
			knobIndicator.MarkerShape.FillStyle = advancedGradientFill;

			// add the knob indicator to the indicators collection of the gauge
			radialGauge.Indicators.Add(knobIndicator);

			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithEnumValues(MarkerShapeDropDownList, typeof(SmartShape2D));
				MarkerShapeDropDownList.SelectedIndex = (int)SmartShape2D.Ellipse;

				WebExamplesUtilities.FillComboWithEnumValues(OuterRimPatternDropDownList, typeof(CircularRimPattern));
				OuterRimPatternDropDownList.SelectedIndex = (int)CircularRimPattern.RoundHandle;

				WebExamplesUtilities.FillComboWithEnumValues(InnerRimPatternDropDownList, typeof(CircularRimPattern));
				InnerRimPatternDropDownList.SelectedIndex = (int)CircularRimPattern.Circle;
			}

			// update the knob marker shape
			N2DSmartShapeFactory factory = new N2DSmartShapeFactory(knobIndicator.MarkerShape.FillStyle, knobIndicator.MarkerShape.StrokeStyle, knobIndicator.MarkerShape.ShadowStyle);
			knobIndicator.MarkerShape = factory.CreateShape((SmartShape2D)MarkerShapeDropDownList.SelectedIndex);

			// update the outer rim style
			knobIndicator.OuterRimStyle.Pattern = (CircularRimPattern)OuterRimPatternDropDownList.SelectedIndex;

			// update the inner rim style
			knobIndicator.InnerRimStyle.Pattern = (CircularRimPattern)InnerRimPatternDropDownList.SelectedIndex;
		}
	}
}
