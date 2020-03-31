using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;
using System.Windows.Threading;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// Interaction logic for NIndicatorValueDampeningUC.xaml
	/// </summary>
	public partial class NIndicatorValueDampeningUC : NExampleBaseUC
	{
		private double m_Angle;
		private Random rand = new Random();
		private NRadialGaugePanel m_RadialGauge;
		private NNumericDisplayPanel m_NumericDisplay;
		private NRangeIndicator m_Indicator1;
		private NNeedleValueIndicator m_Indicator2;
		private DispatcherTimer m_Timer;

		public NIndicatorValueDampeningUC()
		{
			InitializeComponent();
		}

		public override string Title
		{
			get
			{
				return "Value Dampening";
			}
		}

		public override string Description
		{
			get
			{
				return "This example demonstrates how to enable the value dampening feature of the gauge indicators. When enabled the value dampening will smooths the transition of indicators when their value changes.\r\n" +
						"Use the controls on the right side to modify various parameters of the dampening effect. ";
			}
		}

		public override void Create()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Gauge Indicator Value Dampening");
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			header.ContentAlignment = ContentAlignment.BottomRight;
			header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			nChartControl1.Panels.Add(header);

			// create the radial gauge
			m_RadialGauge = new NRadialGaugePanel();
			m_RadialGauge.PaintEffect = new NGlassEffectStyle();
			m_RadialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
			m_RadialGauge.ContentAlignment = ContentAlignment.MiddleCenter;
			m_RadialGauge.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(55, NRelativeUnit.ParentPercentage));
			m_RadialGauge.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
			m_RadialGauge.BackgroundFillStyle = new NGradientFillStyle(Color.DarkGray, Color.Black);

			// configure scale
			NGaugeAxis axis = (NGaugeAxis)m_RadialGauge.Axes[0];
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;

			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.Presentation);
			scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 12, System.Drawing.FontStyle.Bold);
			scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);
			scale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);
			scale.MinorTickCount = 4;
			scale.RulerStyle.BorderStyle.Width = new NLength(0);
			scale.RulerStyle.FillStyle = new NColorFillStyle(Color.DarkGray);

			// add radial gauge indicators
			m_Indicator1 = new NRangeIndicator();
			m_Indicator1.Value = 20;
			m_Indicator1.FillStyle = new NGradientFillStyle(Color.Yellow, Color.Red);
			m_Indicator1.StrokeStyle.Color = Color.DarkBlue;
			m_Indicator1.EndWidth = new NLength(20);
			m_RadialGauge.Indicators.Add(m_Indicator1);

			m_Indicator2 = new NNeedleValueIndicator();
			m_Indicator2.Value = 79;
			m_Indicator2.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
			m_Indicator2.Shape.StrokeStyle.Color = Color.Red;
			m_RadialGauge.Indicators.Add(m_Indicator2);
			m_RadialGauge.SweepAngle = 270;

			// add radial gauge
			nChartControl1.Panels.Add(m_RadialGauge);

			// create and configure a numeric display attached to the radial gauge
			m_NumericDisplay = new NNumericDisplayPanel();
			m_NumericDisplay.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(70, NRelativeUnit.ParentPercentage));
			m_NumericDisplay.ContentAlignment = ContentAlignment.TopCenter;
			m_NumericDisplay.SegmentWidth = new NLength(2, NGraphicsUnit.Point);
			m_NumericDisplay.SegmentGap = new NLength(1, NGraphicsUnit.Point);
			m_NumericDisplay.CellSize = new NSizeL(new NLength(15, NGraphicsUnit.Point), new NLength(30, NGraphicsUnit.Point));
			m_NumericDisplay.DecimalCellSize = new NSizeL(new NLength(10, NGraphicsUnit.Point), new NLength(20, NGraphicsUnit.Point));
			m_NumericDisplay.ShowDecimalSeparator = false;
			m_NumericDisplay.CellAlignment = VertAlign.Top;
			m_NumericDisplay.BackgroundFillStyle = new NColorFillStyle(Color.DimGray);
			m_NumericDisplay.LitFillStyle = new NGradientFillStyle(Color.Lime, Color.Green);
			m_NumericDisplay.CellCountMode = DisplayCellCountMode.Fixed;
			m_NumericDisplay.CellCount = 6;
			m_NumericDisplay.Padding = new NMarginsL(6, 3, 6, 3);
			m_RadialGauge.ChildPanels.Add(m_NumericDisplay);

			// create a sunken border around the display
			NEdgeBorderStyle borderStyle = new NEdgeBorderStyle(BorderShape.RoundedRect);
			borderStyle.OuterBevelWidth = new NLength(0);
			borderStyle.MiddleBevelWidth = new NLength(0);
			m_NumericDisplay.BorderStyle = borderStyle;

			// init form controls
			EnableValueDampeningCheckBox.IsChecked = true;
			m_Indicator1.DampeningInterval = 50;
			m_Indicator1.DampeningSteps = 10;

			m_Indicator2.DampeningInterval = 50;
			m_Indicator2.DampeningSteps = 10;

			NExampleHelpers.BindComboToItemSource(DampeningIntervalComboBox, 10, 1000, 10);
			NExampleHelpers.BindComboToItemSource(DampeningStepsComboBox, 5, 100, 5);
			DampeningIntervalComboBox.SelectedItem = (int)m_Indicator1.DampeningInterval;			
			DampeningStepsComboBox.SelectedItem = (int)m_Indicator1.DampeningSteps;

			m_Timer = new DispatcherTimer();
			m_Timer.Tick += m_Timer_Tick;
			m_Timer.Interval = new TimeSpan(200);
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
			m_Angle += Math.PI / 180.0;

			m_Indicator1.Value = 50 + Math.Sin(m_Angle) * (20 + rand.Next(30));
			m_NumericDisplay.Value = m_Indicator1.Value;
			m_Indicator2.Value = 50 + Math.Sin(m_Angle) * (30 + rand.Next(20));

			nChartControl1.Refresh();
		}

		private void UpdateIndicators()
		{
			if (m_Indicator1 != null)
			{
				m_Indicator1.EnableDampening = EnableValueDampeningCheckBox.IsChecked.Value;
				if (DampeningIntervalComboBox.SelectedItem != null)
				{
					m_Indicator1.DampeningInterval = (int)DampeningIntervalComboBox.SelectedItem;
				}
				if (DampeningStepsComboBox.SelectedItem != null)
				{
					m_Indicator1.DampeningSteps = (int)DampeningStepsComboBox.SelectedItem;
				}
			}

			if (m_Indicator2 != null)
			{
				m_Indicator2.EnableDampening = EnableValueDampeningCheckBox.IsChecked.Value;
				if (DampeningIntervalComboBox.SelectedItem != null)
				{
					m_Indicator2.DampeningInterval = (int)DampeningIntervalComboBox.SelectedItem;
				}
				if (DampeningStepsComboBox.SelectedItem != null)
				{
					m_Indicator2.DampeningSteps = (int)DampeningStepsComboBox.SelectedItem;
				}
				m_Indicator2.Value = 20 + Math.Sin(m_Angle) + rand.Next(40);
			}
		}

		private void IntervalComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateIndicators();
		}

		private void StepsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateIndicators();
		}

		private void DampeningIntervalComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateIndicators();
		}

		private void DampeningStepsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateIndicators();
		}

		private void StartStopTimerButton_Click(object sender, RoutedEventArgs e)
		{
			if (m_Timer.IsEnabled)
			{
				StartStopTimerButton.Content = "Start Timer";
				m_Timer.Stop();
			}
			else
			{
				StartStopTimerButton.Content = "Stop Timer";
				m_Timer.Start();
			}
		}

		private void EnableValueDampeningCheckBox_Checked(object sender, RoutedEventArgs e)
		{
			UpdateIndicators();
		}
	}
}
