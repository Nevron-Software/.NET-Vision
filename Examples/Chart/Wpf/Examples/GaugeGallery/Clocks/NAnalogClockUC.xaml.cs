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

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// Interaction logic for NAnalogClockUC.xaml
	/// </summary>
	public partial class NAnalogClockUC : NExampleBaseUC
	{
		private NStockSeries m_Stock;
		private NDockPanel m_LondonClock;
		private NDockPanel m_TokyoClock;
		private Timer m_Timer;
		private NDockPanel m_NewYorkClock;

		public NAnalogClockUC()
		{
			InitializeComponent();
		}

		public override string Title
		{
			get
			{
				return "Analog Clock";
			}
		}
		public override string Description
		{
			get
			{
				return "This example demonstrates the functionality of the NAnalogClockPanel panel working in UTC time mode in different time zones. ";
			}
		}

		public override void Create()
		{
			nChartControl1.Panels.Clear();
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Financial Dashboard");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup Stock chart
			NCartesianChart stockChart = new NCartesianChart();
			SetupStockChart(stockChart);

			stockChart.Size = new NSizeL(new NLength(96, NRelativeUnit.ParentPercentage), new NLength(55, NRelativeUnit.ParentPercentage));
			stockChart.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(10, NRelativeUnit.ParentPercentage));
			nChartControl1.Panels.Add(stockChart);

			// create London clock
			NDockPanel londonPanel = new NDockPanel();
			londonPanel.Size = new NSizeL(new NLength(30, NRelativeUnit.ParentPercentage), new NLength(30, NRelativeUnit.ParentPercentage));
			londonPanel.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(66, NRelativeUnit.ParentPercentage));

			m_LondonClock = CreateClockPanel(1);
			londonPanel.ChildPanels.Add(CreateClockLabel("London"));
			londonPanel.ChildPanels.Add(m_LondonClock);
			nChartControl1.Panels.Add(londonPanel);

			// create Tokyo clock
			NDockPanel tokyoPanel = new NDockPanel();
			tokyoPanel.Size = new NSizeL(new NLength(30, NRelativeUnit.ParentPercentage), new NLength(30, NRelativeUnit.ParentPercentage));
			tokyoPanel.Location = new NPointL(new NLength(35, NRelativeUnit.ParentPercentage), new NLength(66, NRelativeUnit.ParentPercentage));
			m_TokyoClock = CreateClockPanel(10);
			tokyoPanel.ChildPanels.Add(CreateClockLabel("Tokyo"));
			tokyoPanel.ChildPanels.Add(m_TokyoClock);
			nChartControl1.Panels.Add(tokyoPanel);

			// create New York clock
			NDockPanel newYorkPanel = new NDockPanel();
			newYorkPanel.Size = new NSizeL(new NLength(30, NRelativeUnit.ParentPercentage), new NLength(30, NRelativeUnit.ParentPercentage));
			newYorkPanel.Location = new NPointL(new NLength(68, NRelativeUnit.ParentPercentage), new NLength(66, NRelativeUnit.ParentPercentage));
			m_NewYorkClock = CreateClockPanel(-4);
			newYorkPanel.ChildPanels.Add(CreateClockLabel("New York"));
			newYorkPanel.ChildPanels.Add(m_NewYorkClock);
			nChartControl1.Panels.Add(newYorkPanel);

			GenerateOHLCData(m_Stock, 100, 200, new NRange1DD(50, 350));
			nChartControl1.Refresh();
			m_Timer = new Timer();
			m_Timer.Elapsed += m_Timer_Elapsed;
			m_Timer.Interval = 4000;
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

		private NLabel CreateClockLabel(string text)
		{
			NLabel label = new NLabel(text);

			label.TextStyle.FillStyle = new NColorFillStyle(Color.DarkBlue);
			label.DockMode = PanelDockMode.Bottom;
			label.ContentAlignment = ContentAlignment.MiddleCenter;
			label.BoundsMode = BoundsMode.Fit;

			return label;
		}

		private NNeedleValueIndicator CreateIndicator()
		{
			NNeedleValueIndicator indicator = new NNeedleValueIndicator();

			indicator.Shape.FillStyle = new NGradientFillStyle(Color.White, Color.Red);

			return indicator;
		}

		private NDockPanel CreateClockPanel(int timeZone)
		{
			// create the radial gauge
			NAnalogClockPanel clock = new NAnalogClockPanel();
			clock.ContentAlignment = ContentAlignment.MiddleCenter;
			clock.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(50, NRelativeUnit.ParentPercentage));
			clock.Size = new NSizeL(new NLength(100, NRelativeUnit.ParentPercentage), new NLength(100, NRelativeUnit.ParentPercentage));
			clock.ClockDisplayMode = ClockDisplayMode.HourMinute;
			clock.ClockTimeMode = ClockTimeMode.UTC;
			clock.TimeZone = timeZone;
			clock.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
			clock.Margins = new NMarginsL(5, 5, 5, 5);
			clock.DockMode = PanelDockMode.Fill;

			return clock;
		}

		private NBackgroundDecoratorPanel CreateBackgroundPanel()
		{
			NBackgroundStyle backroundStyle = new NBackgroundStyle();
			backroundStyle.FillStyle = new NGradientFillStyle(Color.White, Color.LightGray);

			NBackgroundDecoratorPanel backgroundPanel = new NBackgroundDecoratorPanel();
			backgroundPanel.DockMargins = new NMarginsL(new NLength(5, NGraphicsUnit.Point), new NLength(5, NGraphicsUnit.Point), new NLength(5, NGraphicsUnit.Point), new NLength(5, NGraphicsUnit.Point));
			backgroundPanel.BackgroundStyle = (NBackgroundStyle)backroundStyle.Clone();

			return backgroundPanel;
		}

		private void SetupStockChart(NCartesianChart chart)
		{
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			chart.LightModel.EnableLighting = false;
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.Wall(ChartWallType.Floor).Visible = false;
			chart.Wall(ChartWallType.Left).Visible = false;
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Location = new NPointL(
				new NLength(5, NRelativeUnit.ParentPercentage),
				new NLength(10, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(90, NRelativeUnit.ParentPercentage),
				new NLength(50, NRelativeUnit.ParentPercentage));

			// setup X axis
			NAxis axis = chart.Axis(StandardAxis.PrimaryX);
			NOrdinalScaleConfigurator ordinalScale = (NOrdinalScaleConfigurator)axis.ScaleConfigurator;
			ordinalScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, false);
			ordinalScale.InnerMajorTickStyle.Length = new NLength(0);

			// setup Y axis
			axis = chart.Axis(StandardAxis.PrimaryY);
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)axis.ScaleConfigurator;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, false);
			linearScale.InnerMajorTickStyle.Length = new NLength(0);

			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.StripStyles.Add(stripStyle);

			// setup the stock series
			m_Stock = (NStockSeries)chart.Series.Add(SeriesType.Stock);
			m_Stock.Name = "Price";
			m_Stock.Legend.Mode = SeriesLegendMode.None;
			m_Stock.DataLabelStyle.Visible = false;
			m_Stock.CandleStyle = CandleStyle.Stick;
			m_Stock.UpStrokeStyle.Color = Color.RoyalBlue;
			m_Stock.OpenValues.Name = "open";
			m_Stock.HighValues.Name = "high";
			m_Stock.LowValues.Name = "low";
			m_Stock.CloseValues.Name = "close";
			m_Stock.CandleWidth = new NLength(0.5f, NRelativeUnit.ParentPercentage);
		}

		void m_Timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			GenerateOHLCData(m_Stock, 100, 200, new NRange1DD(50, 350));
			nChartControl1.Refresh();
		}
	}
}
