using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NCarDashboardUC : NExampleUC
	{
		NNeedleValueIndicator m_SpeedIndicator;
		NNeedleValueIndicator m_RotationIndicator;
 
		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Car Dashboard");
			header.ContentAlignment = ContentAlignment.MiddleCenter;
			header.TextStyle.FontStyle.Name = "Palatino Linotype";
			header.TextStyle.FontStyle.Style = FontStyle.Italic;
			header.TextStyle.FillStyle = new NGradientFillStyle(Color.Black, Color.White);
			header.TextStyle.BorderStyle = new NStrokeStyle(Color.Gray);
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			header.TextStyle.FontStyle.EmSize = new NLength(22);
			header.TextStyle.FontStyle.Style = FontStyle.Bold;
			header.BoundsMode = BoundsMode.None;
			header.UseAutomaticSize = false;
			header.Size = new NSizeL(
				new NLength(60, NRelativeUnit.ParentPercentage),
				new NLength(10, NRelativeUnit.ParentPercentage));
			header.Location = new NPointL(
				new NLength(50, NRelativeUnit.ParentPercentage),
				new NLength(6, NRelativeUnit.ParentPercentage));
			nChartControl1.Panels.Add(header);

			CreateSpeedGauge();
			CreateRPMGauge();
		}

        private void CreateSpeedGauge()
        {
            // create the radial gauge
            NRadialGaugePanel radialGauge = new NRadialGaugePanel();


            radialGauge.BackgroundFillStyle = CreateAdvancedGradient();
            radialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
            radialGauge.PaintEffect = new NGlassEffectStyle();
            radialGauge.ContentAlignment = ContentAlignment.BottomRight;
            radialGauge.Location = new NPointL(new NLength(5, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
            radialGauge.Size = new NSizeL(new NLength(45, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));

            NLabel label = new NLabel("km/h");
            label.ContentAlignment = ContentAlignment.BottomCenter;
            label.TextStyle.FontStyle = new NFontStyle("Times New Roman", 20, FontStyle.Italic);
            label.TextStyle.FontStyle.Style = FontStyle.Italic;
            label.TextStyle.FillStyle = new NColorFillStyle(Color.White);
            label.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            label.BoundsMode = BoundsMode.Fit;
            label.UseAutomaticSize = false;
            label.Size = new NSizeL(
                new NLength(60, NRelativeUnit.ParentPercentage),
                new NLength(7, NRelativeUnit.ParentPercentage));
            label.Location = new NPointL(
                new NLength(50, NRelativeUnit.ParentPercentage),
                new NLength(55, NRelativeUnit.ParentPercentage));
            label.Cache = true;

            radialGauge.ChildPanels.Add(label);
            nChartControl1.Panels.Add(radialGauge);

            NGaugeAxis axis = (NGaugeAxis)radialGauge.Axes[0];
            axis.Range = new NRange1DD(0, 250);

            NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;
            ConfigureScale(scale, new NRange1DD(220, 260));
            radialGauge.Indicators.Add(CreateRangeIndicator(220));

            NMarkerValueIndicator indicator3 = new NMarkerValueIndicator();
            indicator3.Value = 90;
            radialGauge.Indicators.Add(indicator3);

            m_SpeedIndicator = new NNeedleValueIndicator();
            m_SpeedIndicator.Value = 0;
            m_SpeedIndicator.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
            m_SpeedIndicator.Shape.StrokeStyle.Color = Color.Red;
            radialGauge.Indicators.Add(m_SpeedIndicator);

            radialGauge.BeginAngle = -240;
            radialGauge.SweepAngle = 300;
        }

        private NFillStyle CreateAdvancedGradient()
        {
            NAdvancedGradientFillStyle agfs = new NAdvancedGradientFillStyle();

            agfs.BackgroundColor = Color.FromArgb(234, 234, 234);

            NAdvancedGradientPoint point1 = new NAdvancedGradientPoint();
            point1.X = 50;
            point1.Y = 50;
            point1.Color = Color.FromArgb(51, 51, 51);
            point1.Intensity = 70;
            agfs.Points.Add(point1);

            NAdvancedGradientPoint point2 = new NAdvancedGradientPoint();
            point2.X = 50;
            point2.Y = 50;
            point2.Color = Color.FromArgb(41, 41, 41);
            point2.Intensity = 50;
            agfs.Points.Add(point2);

            return agfs;
        }

        private void CreateRPMGauge()
        {
            // create the radial gauge
            NRadialGaugePanel radialGauge = new NRadialGaugePanel();

            radialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
            radialGauge.PaintEffect = new NGlassEffectStyle();
            radialGauge.BackgroundFillStyle = CreateAdvancedGradient();
            radialGauge.ContentAlignment = ContentAlignment.BottomRight;
            radialGauge.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
            radialGauge.Size = new NSizeL(new NLength(45, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));

            NLabel label = new NLabel("RPM");
            label.ContentAlignment = ContentAlignment.BottomCenter;
            label.TextStyle.FontStyle.Name = "Palatino Linotype";
            label.TextStyle.FontStyle.Style = FontStyle.Italic;
            label.TextStyle.FillStyle = new NColorFillStyle(Color.White);
            label.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            label.BoundsMode = BoundsMode.Fit;
            label.UseAutomaticSize = false;
            label.Size = new NSizeL(
                new NLength(60, NRelativeUnit.ParentPercentage),
                new NLength(7, NRelativeUnit.ParentPercentage));
            label.Location = new NPointL(
                new NLength(50, NRelativeUnit.ParentPercentage),
                new NLength(55, NRelativeUnit.ParentPercentage));
            label.Cache = true;

            radialGauge.ChildPanels.Add(label);
            nChartControl1.Panels.Add(radialGauge);

            NGaugeAxis axis = (NGaugeAxis)radialGauge.Axes[0];
            axis.Range = new NRange1DD(0, 7000);

            NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;
            ConfigureScale(scale, new NRange1DD(6000, 7000));

            radialGauge.Indicators.Add(CreateRangeIndicator(6000));

            m_RotationIndicator = new NNeedleValueIndicator();
            m_RotationIndicator.Value = 79;
            m_RotationIndicator.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
            m_RotationIndicator.Shape.StrokeStyle.Color = Color.Red;
            radialGauge.Indicators.Add(m_RotationIndicator);

            radialGauge.BeginAngle = -240;
            radialGauge.SweepAngle = 300;
        }

        private void ConfigureScale(NStandardScaleConfigurator scale, NRange1DD redRange)
        {
            scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke);
            scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 9, FontStyle.Bold);
            scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);
            scale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);
            scale.MinorTickCount = 1;
            scale.RulerStyle.BorderStyle.Width = new NLength(0);
            scale.RulerStyle.FillStyle = new NColorFillStyle(Color.FromArgb(125, Color.SlateGray));

            NScaleSectionStyle scaleSection = new NScaleSectionStyle();
            scaleSection.Range = redRange;
            scaleSection.MajorTickFillStyle = new NColorFillStyle(Color.Red);
            scaleSection.MinorTickFillStyle = new NColorFillStyle(Color.Red);

            NTextStyle labelStyle = new NTextStyle();
            labelStyle.FillStyle = new NGradientFillStyle(Color.Red, Color.DarkRed);
            labelStyle.FontStyle = new NFontStyle("Arial", 9, FontStyle.Bold);
            scaleSection.LabelTextStyle = labelStyle;

            scale.Sections.Add(scaleSection);
        }

        private NRangeIndicator CreateRangeIndicator(double minValue)
        {
            NRangeIndicator rangeIndicator = new NRangeIndicator();

            rangeIndicator.Value = minValue;
            rangeIndicator.OriginMode = OriginMode.ScaleMax;
            rangeIndicator.FillStyle = new NColorFillStyle(Color.Red);
            rangeIndicator.StrokeStyle.Width = new NLength(0);
            rangeIndicator.BeginWidth = new NLength(2);
            rangeIndicator.EndWidth = new NLength(10);

            return rangeIndicator;
        }
	}
}
