using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NGaugeScaleAppearanceUC : NExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Gauge Axis Scale Appearance");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.Location = new NPointL(new NLength(3, NRelativeUnit.ParentPercentage),
                                            new NLength(2, NRelativeUnit.ParentPercentage));
            nChartControl1.Panels.Add(header);

			// create the radial gauge
			NRadialGaugePanel radialGauge = new NRadialGaugePanel();
			radialGauge.ContentAlignment = ContentAlignment.MiddleCenter;
			radialGauge.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(52, NRelativeUnit.ParentPercentage));
			radialGauge.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(85, NRelativeUnit.ParentPercentage));
            radialGauge.BackgroundFillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Gray);
            radialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
            radialGauge.PaintEffect = new NGlassEffectStyle();

            nChartControl1.Panels.Add(radialGauge);
            
			NGaugeAxis axis = (NGaugeAxis)radialGauge.Axes[0];
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;
			scale.MinorTickCount = 3;

			NRangeIndicator indicator1 = new NRangeIndicator();
			indicator1.Value = 80;
			indicator1.OriginMode = OriginMode.ScaleMax;
			indicator1.FillStyle = new NColorFillStyle(Color.Red);
			indicator1.StrokeStyle.Color = Color.DarkRed;
			radialGauge.Indicators.Add(indicator1);

			NNeedleValueIndicator indicator2 = new NNeedleValueIndicator();
			indicator2.Value = 79;
			indicator2.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
			indicator2.Shape.StrokeStyle.Color = Color.Red;
			radialGauge.Indicators.Add(indicator2);
			radialGauge.SweepAngle = 270;

			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithEnumValues(ScaleStyleDropDownList, typeof(PredefinedScaleStyle));
				ScaleStyleDropDownList.SelectedIndex = 0;
			}

			PredefinedScaleStyle scaleStyle = (PredefinedScaleStyle)ScaleStyleDropDownList.SelectedIndex;
			scale.SetPredefinedScaleStyle(scaleStyle);
			switch (scaleStyle)
			{
				case PredefinedScaleStyle.Standard:
				case PredefinedScaleStyle.Scientific:
					break;
				case PredefinedScaleStyle.Presentation:
					scale.RulerStyle.FillStyle = new NGradientFillStyle(Color.White, Color.CadetBlue);
					scale.OuterMajorTickStyle.FillStyle = new NGradientFillStyle(Color.White, Color.Green);
					scale.OuterMajorTickStyle.LineStyle.Color = Color.DarkGreen;
					break;
				case PredefinedScaleStyle.PresentationNoStroke:
					scale.RulerStyle.FillStyle = new NGradientFillStyle(Color.White, Color.CadetBlue);
					scale.OuterMajorTickStyle.FillStyle = new NGradientFillStyle(Color.White, Color.Green);
					break;
				case PredefinedScaleStyle.Watch:
					scale.OuterMajorTickStyle.FillStyle = new NGradientFillStyle(Color.White, Color.Green);
					scale.OuterMajorTickStyle.LineStyle.Color = Color.DarkGreen;
					break;
				case PredefinedScaleStyle.Ruler:
					break;
			}
		}
	}
}
