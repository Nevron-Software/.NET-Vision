using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NCustomLabelsUC : NExampleUC
	{
		private NNeedleValueIndicator m_HoursArrow;
		private NNeedleValueIndicator m_MinituesArrow;
		private NNeedleValueIndicator m_SecondsArrow;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Gauge Custom Labels");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.Location = new NPointL(new NLength(3, NRelativeUnit.ParentPercentage),
                                            new NLength(2, NRelativeUnit.ParentPercentage));
            nChartControl1.Panels.Add(header);


			// create the radial gauge
			NRadialGaugePanel radialGauge = new NRadialGaugePanel();
            radialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
            radialGauge.PaintEffect = new NGlassEffectStyle();
			radialGauge.ContentAlignment = ContentAlignment.MiddleCenter;
			radialGauge.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(52, NRelativeUnit.ParentPercentage));
			radialGauge.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(85, NRelativeUnit.ParentPercentage));
			radialGauge.SweepAngle = 360;
			radialGauge.BeginAngle = -90;
            NAdvancedGradientFillStyle advGradient = new NAdvancedGradientFillStyle();
            advGradient.BackgroundColor = Color.Black;
            advGradient.Points.Add(new NAdvancedGradientPoint(Color.White, 10, 10, 0, 100, AGPointShape.Circle));
            radialGauge.BackgroundFillStyle = advGradient;
			nChartControl1.Panels.Add(radialGauge);

			NGaugeAxis axis = (NGaugeAxis)radialGauge.Axes[0];
			axis.Range = new NRange1DD(0, 60);
			axis.Anchor.RulerOrientation = RulerOrientation.Right;
			axis.Anchor = new NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, true, RulerOrientation.Right, 0, 100);
			NLinearScaleConfigurator scale = (NLinearScaleConfigurator)axis.ScaleConfigurator;

			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.FromArgb(20, Color.LightGray)), null, true, 0, 0, 1, 1);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.Interlaced = true;
			scale.StripStyles.Add(stripStyle);
			scale.MinorTickCount = 4;
			scale.MajorTickMode = MajorTickMode.CustomStep;
			scale.CustomStep = 5.0f;
			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.Watch);
			scale.OuterMajorTickStyle.FillStyle = new NGradientFillStyle(Color.White, Color.Beige);
			scale.OuterMajorTickStyle.LineStyle = new NStrokeStyle(Color.DarkGray);
			scale.OuterMajorTickStyle.Length = new NLength(14);
			scale.RulerStyle.FillStyle = new NColorFillStyle(Color.FromArgb(50, Color.Silver));
			scale.RulerStyle.BorderStyle = new NStrokeStyle(Color.Beige);

			axis.UpdateScale();
			axis.SynchronizeScaleWithConfigurator = false;
			
			NTextStyle textStyle1 = new NTextStyle();
			textStyle1.FillStyle = new NColorFillStyle(Color.White);
			textStyle1.BorderStyle = new NStrokeStyle(1, Color.Beige);
			textStyle1.FontStyle.Style = FontStyle.Bold;
			textStyle1.FontStyle.EmSize = new NLength(22);
			NScaleLabelAngle angle = new NScaleLabelAngle(ScaleLabelAngleMode.View, 0);

			NTextStyle textStyle2 = new NTextStyle();
			textStyle2.FillStyle = new NColorFillStyle(Color.White);
			textStyle2.BorderStyle = new NStrokeStyle(1, Color.Beige);
			textStyle2.FontStyle.Style = FontStyle.Bold;
			textStyle2.FontStyle.EmSize = new NLength(12);

			NCustomScaleDecorator customDecorator = new NCustomScaleDecorator();

			for (int i = 12; i > 0; i--)
			{
				string text = NSystem.IntToRoman(i);
				NValueScaleLabel hourLabel;

				NValueScaleLabelStyle valueLabelStyle = new NValueScaleLabelStyle();
				valueLabelStyle.ContentAlignment = ContentAlignment.MiddleCenter;
				valueLabelStyle.Angle = angle;

				if (i % 3 == 0)
				{
					valueLabelStyle.TextStyle = (NTextStyle)textStyle1.Clone();
					hourLabel = new NValueScaleLabel(new NScaleValueDecorationAnchor(i * 5), text, valueLabelStyle);
				}
				else
				{
					valueLabelStyle.TextStyle = (NTextStyle)textStyle2.Clone();
					hourLabel = new NValueScaleLabel(new NScaleValueDecorationAnchor(i * 5), text, valueLabelStyle);
				}

				customDecorator.Decorations.Add(hourLabel);
			}

			NScaleLevel textLevel = (NScaleLevel)axis.Scale.Levels[1];
			textLevel.Decorators.Clear();
			textLevel.Decorators.Add(customDecorator);

			m_HoursArrow = new NNeedleValueIndicator();
			m_HoursArrow.Value = 79;
			m_HoursArrow.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
			m_HoursArrow.Shape.StrokeStyle.Color = Color.Red;
			m_HoursArrow.OffsetFromScale = new NLength(10);
			m_HoursArrow.Width = new NLength(8);
			radialGauge.Indicators.Add(m_HoursArrow);

			m_MinituesArrow = new NNeedleValueIndicator();
			m_MinituesArrow.Value = 79;
			m_MinituesArrow.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
			m_MinituesArrow.Shape.StrokeStyle.Color = Color.Red;
			m_MinituesArrow.OffsetFromScale = new NLength(5);
			m_MinituesArrow.Width = new NLength(5);
			radialGauge.Indicators.Add(m_MinituesArrow);

			m_SecondsArrow = new NNeedleValueIndicator();
			m_SecondsArrow.Value = 79;
			m_SecondsArrow.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
			m_SecondsArrow.Shape.StrokeStyle.Color = Color.Red;
			m_SecondsArrow.OffsetFromScale = new NLength(0);
			m_SecondsArrow.Width = new NLength(1);
			radialGauge.Indicators.Add(m_SecondsArrow);

			SynchronizeWithTime();
		}

		private void SynchronizeWithTime()
		{
			DateTime now = DateTime.Now;		
			m_SecondsArrow.Value = now.Second;
			m_MinituesArrow.Value = now.Minute;
			m_HoursArrow.Value = now.Hour * 5.0f + now.Minute / 12.0f;
		}
	}
}
