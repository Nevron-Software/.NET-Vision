using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// Interaction logic for NGaugeCustomLabelsUC.xaml
	/// </summary>
	public partial class NGaugeCustomLabelsUC : NExampleBaseUC
	{
		private NNeedleValueIndicator m_SecondsArrow;
		private NNeedleValueIndicator m_MinituesArrow;
		private NNeedleValueIndicator m_HoursArrow;

		private DispatcherTimer m_Timer;	

		public NGaugeCustomLabelsUC()
		{
			InitializeComponent();
		}

		public override string Title
		{
			get
			{
				return "Custom Labels";
			}
		}

		public override string Description
		{
			get
			{
				return "This example demonstrates how to add custom labels to the gauge axis.\r\n" +
						"Additional features demonstrated in the example are scale strip styles and andvanced gradients used to give the background of the gauge panel a more fashionable outlook.";
			}
		}

		public override void Create()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Gauge Custom Labels");
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			header.ContentAlignment = ContentAlignment.BottomRight;
			header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			nChartControl1.Panels.Add(header);

			// create the radial gauge
			NRadialGaugePanel radialGauge = new NRadialGaugePanel();
			radialGauge.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(12, NRelativeUnit.ParentPercentage));
			radialGauge.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
			radialGauge.PaintEffect = new NGlassEffectStyle();
			radialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);

			NAdvancedGradientFillStyle advGradient = new NAdvancedGradientFillStyle();
			advGradient.BackgroundColor = Color.Black;
			advGradient.Points.Add(new NAdvancedGradientPoint(Color.White, 10, 10, 0, 100, AGPointShape.Circle));
			radialGauge.BackgroundFillStyle = advGradient;

			radialGauge.SweepAngle = 360;
			radialGauge.BeginAngle = -90;
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
			textStyle1.FontStyle.Style = System.Drawing.FontStyle.Bold;
			textStyle1.FontStyle.EmSize = new NLength(22);
			NScaleLabelAngle angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);

			NTextStyle textStyle2 = new NTextStyle();
			textStyle2.FillStyle = new NColorFillStyle(Color.White);
			textStyle2.BorderStyle = new NStrokeStyle(1, Color.Beige);
			textStyle2.FontStyle.Style = System.Drawing.FontStyle.Bold;
			textStyle2.FontStyle.EmSize = new NLength(12);

			NCustomScaleDecorator customDecorator = new NCustomScaleDecorator();

			NValueScaleLabelStyle style1 = new NValueScaleLabelStyle(textStyle1, ContentAlignment.MiddleCenter, angle, new NLength(0));
			NValueScaleLabelStyle style2 = new NValueScaleLabelStyle(textStyle2, ContentAlignment.MiddleCenter, angle, new NLength(0));

			for (int i = 12; i > 0; i--)
			{
				string text = NSystem.IntToRoman(i);
				NValueScaleLabel hourLabel;

				if (i % 3 == 0)
				{
					hourLabel = new NValueScaleLabel(new NScaleValueDecorationAnchor(i * 5), text, (NValueScaleLabelStyle)style1.Clone());
				}
				else
				{
					hourLabel = new NValueScaleLabel(new NScaleValueDecorationAnchor(i * 5), text, (NValueScaleLabelStyle)style2.Clone());
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
			m_HoursArrow.OffsetOriginMode = IndicatorOffsetOriginMode.ScaleEnd;
			m_HoursArrow.OffsetFromScale = new NLength(30);
			m_HoursArrow.Width = new NLength(8);
			radialGauge.Indicators.Add(m_HoursArrow);

			m_MinituesArrow = new NNeedleValueIndicator();
			m_MinituesArrow.Value = 79;
			m_MinituesArrow.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
			m_MinituesArrow.Shape.StrokeStyle.Color = Color.Red;
			m_MinituesArrow.OffsetOriginMode = IndicatorOffsetOriginMode.ScaleEnd;
			m_MinituesArrow.OffsetFromScale = new NLength(30);
			m_MinituesArrow.Width = new NLength(5);
			radialGauge.Indicators.Add(m_MinituesArrow);

			m_SecondsArrow = new NNeedleValueIndicator();
			m_SecondsArrow.Value = 79;
			m_SecondsArrow.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
			m_MinituesArrow.OffsetOriginMode = IndicatorOffsetOriginMode.ScaleEnd;
			m_SecondsArrow.Shape.StrokeStyle.Color = Color.Red;
			m_SecondsArrow.OffsetFromScale = new NLength(10);
			m_SecondsArrow.Width = new NLength(1);
			radialGauge.Indicators.Add(m_SecondsArrow);

			//nChartControl1.AutoRefresh = true;
			SynchronizeWithTime();

			m_Timer = new DispatcherTimer();
			m_Timer.Interval = new TimeSpan(1000);
			m_Timer.Tick += m_Timer_Tick;
			m_Timer.IsEnabled = true;
			m_Timer.Start();
		}

		public override void Destroy()
		{
			if (m_Timer != null)
			{
				m_Timer.Stop();
				m_Timer.Tick -= m_Timer_Tick;
				m_Timer = null;
			}
			
			base.Destroy();
		}

		void m_Timer_Tick(object sender, EventArgs e)
		{
			SynchronizeWithTime();
		}

		private void SynchronizeWithTime()
		{
			DateTime now = DateTime.Now;
			m_SecondsArrow.Value = now.Second;
			m_MinituesArrow.Value = now.Minute;
			m_HoursArrow.Value = now.Hour * 5.0f + now.Minute / 12.0f;
			nChartControl1.Refresh();
		}
	}
}
