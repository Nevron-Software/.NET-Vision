using Nevron.Chart;
using Nevron.GraphicsCore;
using System;
using System.Drawing;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NStockCandleUC : NExampleBaseUC
	{
		private NStockSeries m_Stock;

		public NStockCandleUC()
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
				return "Stock Candle";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "Candle Stock charts are displayed when the CandleStyle property of the Stock series is set to Candle.\r\n" +
				"A candle is considered with up orientation if the open value is smaller than the close value - otherwise the candle is considered with down orientation.\r\n" +
				"The Stock series automatically paints the candles in the appropriate color (defined by its orientation).";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Candle Stock Chart");
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

			// setup stock series
			m_Stock = (NStockSeries)chart.Series.Add(SeriesType.Stock);
			m_Stock.DataLabelStyle.Visible = false;
			m_Stock.UpFillStyle = new NColorFillStyle(Color.White);
			m_Stock.UpStrokeStyle.Color = Color.Black;
			m_Stock.DownFillStyle = new NColorFillStyle(Color.Crimson);
			m_Stock.DownStrokeStyle.Color = Color.Crimson;
			m_Stock.HighLowStrokeStyle.Color = Color.Black;
			m_Stock.CandleWidth = new NLength(1.2f, NRelativeUnit.ParentPercentage);
			m_Stock.UseXValues = true;
			m_Stock.InflateMargins = true;

			// add some stock items
			const int numDataPoints = 50;
			GenerateOHLCData(m_Stock, 100.0, numDataPoints, new NRange1DD(60, 140));
			FillStockDates(m_Stock, numDataPoints);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// init form controls
			ShowHighLowLineCheckBox.IsChecked = true;
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

		private void ShowHighLowLineCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			m_Stock.ShowHighLow = (bool)ShowHighLowLineCheckBox.IsChecked;
			nChartControl1.Refresh();
		}
	}
}
