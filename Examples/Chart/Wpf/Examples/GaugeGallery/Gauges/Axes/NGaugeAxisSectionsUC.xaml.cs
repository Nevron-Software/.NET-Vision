using System;
using System.Collections.Generic;
using System.Drawing;
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
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// Interaction logic for NGaugeAxisSectionsUC.xaml
	/// </summary>
	public partial class NGaugeAxisSectionsUC : NExampleBaseUC
	{
		private float m_FirstIndicatorAngle = 0;
		private float m_SecondIndicatorAngle = 0;
		private DispatcherTimer m_Timer;
		
		public NGaugeAxisSectionsUC()
		{
			InitializeComponent();
		}

		public override string Title
		{
			get
			{
				return "Axis Sections";
			}
		}

		public override string Description
		{
			get
			{
				return "The example demonstrates the Axis Sections feature of the gauge axes. Axis sections allow you to modify the style of major and minor grid lines and ticks as well as the style of the automatically generated labels when they fall in a certain range (defined by the section). This allows you to visually highlight important ranges of data on the gauge axis. ";
			}
		}

		public override void Create()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Gauge Axis Sections");
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			header.ContentAlignment = ContentAlignment.BottomRight;
			header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			nChartControl1.Panels.Add(header);

			NExampleHelpers.BindComboToItemSource(BlueSectionBeginComboBox, 0, 100, 5);
			BlueSectionBeginComboBox.SelectedItem = 0;
			
			NExampleHelpers.BindComboToItemSource(BlueSectionEndComboBox, 0, 100, 5);
			BlueSectionEndComboBox.SelectedItem = 20;

			NExampleHelpers.BindComboToItemSource(RedSectionBeginComboBox, 0, 100, 5);
			RedSectionBeginComboBox.SelectedItem = 80;

			NExampleHelpers.BindComboToItemSource(RedSectionEndComboBox, 0, 100, 5);
			RedSectionEndComboBox.SelectedItem = 100;

			// init form controls
			InitLinearGauge();
			InitRadialGauge();
			m_Timer = new DispatcherTimer();
			m_Timer.Tick += m_Timer_Tick;
			m_Timer.Interval = new TimeSpan(100);
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

		private void InitSections(NGaugePanel gaugePanel)
		{
			NGaugeAxis axis = (NGaugeAxis)gaugePanel.Axes[0];
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;

			// init text style for regular labels
			scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);
			scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 10, System.Drawing.FontStyle.Bold);

			// init ticks
			scale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			scale.MinTickDistance = new NLength(20);
			scale.MinorTickCount = 1;
			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.Scientific);

			// create sections
			NScaleSectionStyle blueSection = new NScaleSectionStyle();
			blueSection.Range = new NRange1DD(0, 20);
			blueSection.SetShowAtWall(ChartWallType.Back, true);
			blueSection.RangeFillStyle = new NColorFillStyle(Color.FromArgb(50, Color.Blue));
			blueSection.MajorGridStrokeStyle = new NStrokeStyle(Color.Blue);
			blueSection.MajorTickStrokeStyle = new NStrokeStyle(Color.DarkBlue);
			blueSection.MinorTickStrokeStyle = new NStrokeStyle(1, Color.Blue, LinePattern.Dot, 0, 2);

			NTextStyle labelStyle = new NTextStyle();
			labelStyle.FillStyle = new NColorFillStyle(Color.Blue);
			labelStyle.FontStyle = new NFontStyle("Arial", 10, System.Drawing.FontStyle.Bold);
			blueSection.LabelTextStyle = labelStyle;

			scale.Sections.Add(blueSection);

			NScaleSectionStyle redSection = new NScaleSectionStyle();
			redSection.Range = new NRange1DD(80, 100);

			redSection.SetShowAtWall(ChartWallType.Back, true);
			redSection.RangeFillStyle = new NColorFillStyle(Color.FromArgb(50, Color.Red));
			redSection.MajorGridStrokeStyle = new NStrokeStyle(Color.Red);
			redSection.MajorTickStrokeStyle = new NStrokeStyle(Color.DarkRed);
			redSection.MinorTickStrokeStyle = new NStrokeStyle(1, Color.Red, LinePattern.Dot, 0, 2);

			labelStyle = new NTextStyle();
			labelStyle.FillStyle = new NColorFillStyle(Color.Red);
			labelStyle.FontStyle = new NFontStyle("Arial", 10, System.Drawing.FontStyle.Bold);
			redSection.LabelTextStyle = labelStyle;

			scale.Sections.Add(redSection);
		}

		private void InitLinearGauge()
		{
			NLinearGaugePanel linearGauge = new NLinearGaugePanel();
			linearGauge.ContentAlignment = ContentAlignment.TopRight;
			linearGauge.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(40, NRelativeUnit.ParentPercentage));
			linearGauge.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(55, NGraphicsUnit.Point));
			linearGauge.BackgroundFillStyle = new NGradientFillStyle(Color.DarkGray, Color.Black);
			linearGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.RoundedRect);
			linearGauge.PaintEffect = new NGelEffectStyle();

			nChartControl1.Panels.Add(linearGauge);

			NMarkerValueIndicator indicator1 = new NMarkerValueIndicator();
			linearGauge.Indicators.Add(indicator1);

			InitSections(linearGauge);
		}

		private void InitRadialGauge()
		{
			// create the radial gauge
			NRadialGaugePanel radialGauge = new NRadialGaugePanel();
			radialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
			radialGauge.ContentAlignment = ContentAlignment.BottomRight;
			radialGauge.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(50, NRelativeUnit.ParentPercentage));
			radialGauge.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(45, NRelativeUnit.ParentPercentage));
			radialGauge.InnerRadius = new NLength(10, NGraphicsUnit.Point);
			radialGauge.BackgroundFillStyle = new NGradientFillStyle(Color.DarkGray, Color.Black);
			radialGauge.BoundsMode = BoundsMode.Fit;
			radialGauge.AutoBorder = RadialGaugeAutoBorder.RoundedOutline;

			NGlassEffectStyle glassEffect = new NGlassEffectStyle();
			glassEffect.LightDirection = 130;
			glassEffect.EdgeOffset = new NLength(0);
			glassEffect.EdgeDepth = new NLength(30, NRelativeUnit.ParentPercentage);
			radialGauge.PaintEffect = glassEffect;

			nChartControl1.Panels.Add(radialGauge);

			NNeedleValueIndicator indicator1 = new NNeedleValueIndicator();
			radialGauge.Indicators.Add(indicator1);
			radialGauge.SweepAngle = 180;

			InitSections(radialGauge);
		}

		private void UpdateSections()
		{
			for (int i = 0; i < nChartControl1.Panels.Count; i++)
			{
				NGaugePanel panel = nChartControl1.Panels[i] as NGaugePanel;

				if (panel != null)
				{
					NGaugeAxis axis = (NGaugeAxis)panel.Axes[0];
					NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;

					if (scale.Sections.Count == 2)
					{
						NScaleSectionStyle blueSection = (NScaleSectionStyle)scale.Sections[0];
						blueSection.Range = new NRange1DD((int)BlueSectionBeginComboBox.SelectedItem, (int)BlueSectionEndComboBox.SelectedItem);

						NScaleSectionStyle redSection = (NScaleSectionStyle)scale.Sections[1];
						redSection.Range = new NRange1DD((int)RedSectionBeginComboBox.SelectedItem, (int)RedSectionEndComboBox.SelectedItem);
					}
				}
			}

			nChartControl1.Refresh();
		}

		void m_Timer_Tick(object sender, EventArgs e)
		{
			if (nChartControl1.Panels.Count < 3)
				return;

			// update linear gauge
			NGaugePanel panel = nChartControl1.Panels[1] as NGaugePanel;
			if (panel != null)
			{
				NValueIndicator valueIndicator = (NValueIndicator)panel.Indicators[0];
				NStandardScaleConfigurator scale = (NStandardScaleConfigurator)((NGaugeAxis)panel.Axes[0]).ScaleConfigurator;
				NScaleSectionStyle blueSection = (NScaleSectionStyle)scale.Sections[0];
				NScaleSectionStyle redSection = (NScaleSectionStyle)scale.Sections[1];

				m_FirstIndicatorAngle += 0.02f;
				valueIndicator.Value = 50 - Math.Cos(m_FirstIndicatorAngle) * 50;

				if (blueSection.Range.Contains(valueIndicator.Value))
				{
					valueIndicator.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Blue);
					valueIndicator.Shape.StrokeStyle = new NStrokeStyle(Color.Blue);
				}
				else if (redSection.Range.Contains(valueIndicator.Value))
				{
					valueIndicator.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
					valueIndicator.Shape.StrokeStyle = new NStrokeStyle(Color.Red);
				}
				else
				{
					valueIndicator.Shape.FillStyle = new NColorFillStyle(Color.LightGreen);
					valueIndicator.Shape.StrokeStyle = new NStrokeStyle(Color.DarkGreen);
				}
			}

			// update radial gauge
			panel = nChartControl1.Panels[2] as NGaugePanel;
			if (panel != null)
			{
				NStandardScaleConfigurator scale = (NStandardScaleConfigurator)((NGaugeAxis)panel.Axes[0]).ScaleConfigurator;
				NValueIndicator valueIndicator = (NValueIndicator)panel.Indicators[0];
				NScaleSectionStyle blueSection = (NScaleSectionStyle)scale.Sections[0];
				NScaleSectionStyle redSection = (NScaleSectionStyle)scale.Sections[1];

				m_SecondIndicatorAngle += 0.02f;
				valueIndicator.Value = 50 - Math.Cos(m_SecondIndicatorAngle) * 50;

				if (blueSection.Range.Contains(valueIndicator.Value))
				{
					valueIndicator.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Blue);
					valueIndicator.Shape.StrokeStyle = new NStrokeStyle(Color.DarkBlue);
				}
				else if (redSection.Range.Contains(valueIndicator.Value))
				{
					valueIndicator.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
					valueIndicator.Shape.StrokeStyle = new NStrokeStyle(Color.DarkRed);
				}
				else
				{
					valueIndicator.Shape.FillStyle = new NColorFillStyle(Color.LightGreen);
					valueIndicator.Shape.StrokeStyle = new NStrokeStyle(Color.DarkGreen);
				}

				valueIndicator.Shape.StrokeStyle = new NStrokeStyle(Color.White);
			}

			nChartControl1.Refresh();
		}

		private void BlueSectionBeginComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateSections();
		}

		private void BlueSectionEndComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateSections();
		}

		private void RedSectionEndComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateSections();
		}

		private void RedSectionBeginComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateSections();
		}

		private void StopStartTimerButton_Click(object sender, RoutedEventArgs e)
		{
			if (m_Timer.IsEnabled)
			{
				m_Timer.IsEnabled = false;
				StopStartTimerButton.Content = "Start Timer";
			}
			else
			{
				m_Timer.IsEnabled = true;
				StopStartTimerButton.Content = "Stop Timer";
			}
		}
	}
}
