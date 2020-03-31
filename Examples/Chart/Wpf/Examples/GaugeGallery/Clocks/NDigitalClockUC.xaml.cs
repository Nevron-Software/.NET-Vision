using System;
using System.Drawing;
using System.Timers;
using System.Windows.Threading;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// Interaction logic for NDigitalClockUC.xaml
	/// </summary>
	public partial class NDigitalClockUC : NExampleBaseUC
	{
		private NRangeIndicator m_Indicator1;
		private NRangeIndicator m_Indicator2;
		private Random m_Random;
		private NRangeIndicator m_Indicator3;
		private Timer m_Timer;

		public NDigitalClockUC()
		{
			InitializeComponent();
		}

		public override string Title
		{
			get
			{
				return "Digital Clock";
			}
		}

		public override string Description
		{
			get
			{
				return "The example demonstrates the functionality of the NDigitalClockPanel combined with several linear gauge panels.";
			}
		}

		public override void Create()
		{
			m_Random = new Random();
			nChartControl1.Panels.Clear();

			NDigitalClockPanel digitalClock = new NDigitalClockPanel();
			digitalClock.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(5, NRelativeUnit.ParentPercentage));

			nChartControl1.Panels.Add(digitalClock);

			m_Indicator1 = new NRangeIndicator(30);
			m_Indicator2 = new NRangeIndicator(40);
			m_Indicator3 = new NRangeIndicator(50);

			NPanel meter1 = CreateStatusMeterPanel("Battery Meter 1",
													new NPointL(new NLength(10, NRelativeUnit.ParentPercentage),
															   new NLength(20, NRelativeUnit.ParentPercentage)),
															   m_Indicator1);

			NPanel meter2 = CreateStatusMeterPanel("Battery Meter 2",
														new NPointL(new NLength(10, NRelativeUnit.ParentPercentage),
																new NLength(45, NRelativeUnit.ParentPercentage)),
																m_Indicator2);

			NPanel meter3 = CreateStatusMeterPanel("Battery Meter 3",
													new NPointL(new NLength(10, NRelativeUnit.ParentPercentage),
																	new NLength(70, NRelativeUnit.ParentPercentage)),
																	m_Indicator3);

			nChartControl1.Panels.Add(meter1);
			nChartControl1.Panels.Add(meter2);
			nChartControl1.Panels.Add(meter3);

			m_Timer = new Timer();
			m_Timer.Interval = 1000;
			m_Timer.Elapsed += m_Timer_Elapsed;  //+= m_Timer_Tick;			
			m_Timer.Start();
		}

		
		
		public override void Destroy()
		{
			if (m_Timer != null)
			{
				m_Timer.Stop();
				m_Timer.Elapsed -= m_Timer_Elapsed;
				m_Timer = null;
			}
			base.Destroy();
		}

		private NBackgroundDecoratorPanel CreateStatusMeterPanel(string labelText, NPointL location, NRangeIndicator rangeIndicator)
		{
			NBackgroundDecoratorPanel backgroundPanel = new NBackgroundDecoratorPanel();

			backgroundPanel.Location = location;
			backgroundPanel.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage),
												new NLength(20, NRelativeUnit.ParentPercentage));

			NImageFrameStyle imageFrameStyle = new NImageFrameStyle(PredefinedImageFrame.Embed);
			imageFrameStyle.BackgroundColor = Color.Transparent;
			imageFrameStyle.ShadowStyle.Type = ShadowType.None;
			imageFrameStyle.FillStyle = new NColorFillStyle(Color.Transparent);
			backgroundPanel.BackgroundStyle.FillStyle = new NColorFillStyle(Color.White);
			backgroundPanel.BackgroundStyle.FrameStyle = imageFrameStyle;

			NDockPanel contentPanel = new NDockPanel();
			contentPanel.DockMargins = new NMarginsL(new NLength(15), new NLength(3), new NLength(15), new NLength(3));
			contentPanel.DockMode = PanelDockMode.Fill;
			backgroundPanel.ChildPanels.Add(contentPanel);

			NLabel label = new NLabel();
			label.DockMode = PanelDockMode.Bottom;
			label.Text = labelText;
			label.ContentAlignment = ContentAlignment.MiddleLeft;
			label.DockMargins = new NMarginsL(new NLength(0), new NLength(0), new NLength(0), new NLength(0));
			label.BoundsMode = BoundsMode.Fit;
			contentPanel.ChildPanels.Add(label);

			NLinearGaugePanel linearGauge = new NLinearGaugePanel();
			linearGauge.Indicators.Add(rangeIndicator);
			linearGauge.DockMode = PanelDockMode.Fill;
			linearGauge.DockMargins = new NMarginsL(new NLength(15), new NLength(0), new NLength(15), new NLength(0));

			NGaugeAxis axis = (NGaugeAxis)linearGauge.Axes[0];
			axis.Anchor = new NModelGaugeAxisAnchor();
			NStandardScaleConfigurator configurator = (NStandardScaleConfigurator)axis.ScaleConfigurator;
			configurator.SetPredefinedScaleStyle(PredefinedScaleStyle.Scientific);
			contentPanel.ChildPanels.Add(linearGauge);

			return backgroundPanel;
		}

		private void GenerateRandomValue(NRangeIndicator indicator)
		{
			double factor = indicator.Value > 50 ? 6 : 4;
			double value = indicator.Value + m_Random.Next(10) - factor;

			if (value < 0)
				value = 0;
			else if (value > 100)
				value = 100;

			indicator.Value = value;
		}

		void m_Timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			GenerateRandomValue(m_Indicator1);
			GenerateRandomValue(m_Indicator2);
			GenerateRandomValue(m_Indicator3);

			nChartControl1.Refresh();
		}
	}
}
