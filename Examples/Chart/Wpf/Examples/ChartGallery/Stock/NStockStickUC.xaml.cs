using Nevron.Chart;
using Nevron.GraphicsCore;
using System;
using System.Drawing;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NStockStickUC : NExampleBaseUC
	{
		private NStockSeries m_Stock;

		public NStockStickUC()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Gets the title of this example
		/// </summary>
		public override string Title
		{
			get
			{
				return "Stock Stick";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return	"Stick Stock charts are displayed when the CandleStyle property of the Stock series is set to Stick.\r\n" + 
						"A stick is considered with up orientation if the open value is smaller than the close value - otherwise the stick is considered with down orientation. The Stock series automatically paints the sticks in the appropriate color (defined by its orientation).";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Stick Stock Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];

			// setup X axis
			NValueTimelineScaleConfigurator scaleX = new NValueTimelineScaleConfigurator();
			scaleX.FirstRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.FirstRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(225, 225, 225));
			scaleX.FirstRow.UseGridStyle = true;
			scaleX.FirstRow.InnerTickStyle.Visible = false;
			scaleX.SecondRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.SecondRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(215, 215, 215));
			scaleX.SecondRow.UseGridStyle = true;
			scaleX.SecondRow.InnerTickStyle.Visible = false;
			scaleX.ThirdRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.ThirdRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(205, 205, 205));
			scaleX.ThirdRow.UseGridStyle = true;
			scaleX.ThirdRow.InnerTickStyle.Visible = false;
			// calendar
			NWeekDayRule wdr = new NWeekDayRule(WeekDayBit.All);
			wdr.Saturday = false;
			wdr.Sunday = false;
			scaleX.Calendar.Rules.Add(wdr);
			scaleX.EnableCalendar = true;
			// set configurator
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// setup Y axis
			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY.OuterMajorTickStyle.Length = new NLength(3, NGraphicsUnit.Point);
			scaleY.InnerMajorTickStyle.Visible = false;

			NFillStyle stripFill = new NColorFillStyle(Color.FromArgb(234, 233, 237));
			NScaleStripStyle stripStyle = new NScaleStripStyle(stripFill, null, true, 1, 0, 1, 1);
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			stripStyle.Interlaced = true;
			scaleY.StripStyles.Add(stripStyle);

			// add a stock series
			m_Stock = (NStockSeries)chart.Series.Add(SeriesType.Stock);
			m_Stock.CandleStyle = CandleStyle.Stick;
			m_Stock.DataLabelStyle.Visible = false;
			m_Stock.UpStrokeStyle.Width = new NLength(1, NGraphicsUnit.Point);
			m_Stock.UpStrokeStyle.Color = Color.Black;
			m_Stock.DownStrokeStyle.Width = new NLength(1, NGraphicsUnit.Point);
			m_Stock.DownStrokeStyle.Color = Color.Crimson;
			m_Stock.CandleWidth = new NLength(1.3f, NRelativeUnit.ParentPercentage);
			m_Stock.UseXValues = true;
			m_Stock.InflateMargins = true;

			// add some stock items
			const int count = 50;
			GenerateOHLCData(m_Stock, 100.0, count, new NRange1DD(60, 140));
			FillStockDates(m_Stock, count);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// init form controls
			ShowHighLowCheckBox.IsChecked = true;
			ShowOpenCheckBox.IsChecked = true;
			ShowCloseCheckBox.IsChecked = true;
		}

		private void GenerateStockData(NStockSeries s, int nCount)
		{
			double prevclose = 300;
			double open, high, low, close;

			s.ClearDataPoints();

			for (int nIndex = 0; nIndex < nCount; nIndex++)
			{
				open = prevclose;

				if (prevclose < 25 || Random.NextDouble() > 0.5)
				{
					// upward price change
					close = open + (2 + (Random.NextDouble() * 20));
					high = close + (Random.NextDouble() * 10);
					low = open - (Random.NextDouble() * 10);
				}
				else
				{
					// downward price change
					close = open - (2 + (Random.NextDouble() * 20));
					high = open + (Random.NextDouble() * 10);
					low = close - (Random.NextDouble() * 10);
				}

				if (low < 1) { low = 1; }

				prevclose = close;

				s.OpenValues.Add(open);
				s.HighValues.Add(high);
				s.LowValues.Add(low);
				s.CloseValues.Add(close);
			}
		}

		private void ShowOpenCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			m_Stock.ShowOpen = (bool)ShowOpenCheckBox.IsChecked;
			nChartControl1.Refresh();
		}

		private void ShowCloseCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			m_Stock.ShowClose = (bool)ShowCloseCheckBox.IsChecked;
			nChartControl1.Refresh();
		}

		private void ShowHighLowCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			m_Stock.ShowHighLow = (bool)ShowHighLowCheckBox.IsChecked;
			nChartControl1.Refresh();
		}
	}
}
