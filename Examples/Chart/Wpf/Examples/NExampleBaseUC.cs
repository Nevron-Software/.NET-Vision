
using System.Windows.Controls;
using Nevron.Chart.Wpf;
using Nevron.Chart;
using Nevron.GraphicsCore;
using System.Drawing;
using System;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// Interaction logic for NExampleBaseUC.xaml
	/// </summary>
	public class NExampleBaseUC : UserControl
	{
		/// <summary>
		/// Initializer constructor
		/// </summary>
		public NExampleBaseUC()
		{
			
			this.Loaded += new System.Windows.RoutedEventHandler(NExampleBaseUC_Loaded);
		}

		void NExampleBaseUC_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
			try
			{
				this.Create();

				// make sure we refresh the control
				nChartControl1.Refresh();
			}
			catch 
			{
			}
		}
						  
		/// <summary>
		/// Gets the title of this example
		/// </summary>
		public virtual string Title
		{
			get
			{
				return "";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public virtual string Description
		{
			get
			{
				return "";
			}
		}

	   	/// <summary>
		/// Called to create the example
		/// </summary>
		/// <param name="chartControl"></param>
		public virtual void Create()
		{
		}

		/// <summary>
		/// Called to destroy the example
		/// </summary>
		public virtual void Destroy()
		{

		}
		/// <summary>
		/// Called to configure standard chart control layout
		/// </summary>
		/// <param name="chart"></param>
		/// <param name="title"></param>
		/// <param name="legend"></param>
		internal void ConfigureStandardLayout(NChart chart, NLabel title, NLegend legend)
		{
			nChartControl1.Panels.Clear();

			if (title != null)
			{
				nChartControl1.Panels.Add(title);

				title.DockMode = PanelDockMode.Top;
				title.Padding = new NMarginsL(5, 8, 5, 4);
			}

			if (legend != null)
			{
				nChartControl1.Panels.Add(legend);

				legend.DockMode = PanelDockMode.Right;
				legend.Padding = new NMarginsL(1, 1, 5, 5);
			}

			if (chart != null)
			{
				nChartControl1.Panels.Add(chart);

				float topPad = (title == null) ? 11 : 8;
				float rightPad = (legend == null) ? 11 : 4;

				if (chart.BoundsMode == BoundsMode.None)
				{
					if (chart.Enable3D || !(chart is NCartesianChart))
					{
						chart.BoundsMode = BoundsMode.Fit;
					}
					else
					{
						chart.BoundsMode = BoundsMode.Stretch;
					}
				}

				chart.DockMode = PanelDockMode.Fill;
				chart.Padding = new NMarginsL(
					new NLength(11, NRelativeUnit.ParentPercentage),
					new NLength(topPad, NRelativeUnit.ParentPercentage),
					new NLength(rightPad, NRelativeUnit.ParentPercentage),
					new NLength(11, NRelativeUnit.ParentPercentage));
			}
		}

		internal void GenerateOHLCData(NStockSeries s, double dPrevClose, int nCount, NRange1DD range)
		{
			double open, high, low, close;

			s.ClearDataPoints();

			for (int nIndex = 0; nIndex < nCount; nIndex++)
			{
				open = dPrevClose;
				bool upward = false;

				if (range.Begin > dPrevClose)
				{
					upward = true;
				}
				else if (range.End < dPrevClose)
				{
					upward = false;
				}
				else
				{
					upward = Random.NextDouble() > 0.5;
				}

				if (upward)
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

				if (low < 1)
				{
					low = 1;
				}

				dPrevClose = close;

				s.OpenValues.Add(open);
				s.HighValues.Add(high);
				s.LowValues.Add(low);
				s.CloseValues.Add(close);
			}
		}
		internal void GenerateOHLCData(NStockSeries s, double dPrevClose, int nCount)
		{
			double open, high, low, close;

			s.ClearDataPoints();

			for (int nIndex = 0; nIndex < nCount; nIndex++)
			{
				open = dPrevClose;

				if (dPrevClose < 25 || Random.NextDouble() > 0.5)
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

				if (low < 1)
				{
					low = 1;
				}

				dPrevClose = close;

				s.OpenValues.Add(open);
				s.HighValues.Add(high);
				s.LowValues.Add(low);
				s.CloseValues.Add(close);
			}
		}
		internal void FillStockDates(NStockSeries stock, int count)
		{
			FillStockDates(stock, count, new DateTime(2009, 1, 5));
		}
		internal void FillStockDates(NStockSeries stock, int count, DateTime startDate)
		{
			stock.XValues.Clear();

			DateTime dt = startDate;

			for (int i = 0; i < count; )
			{
				if (dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday)
				{
					stock.XValues.Add(dt.ToOADate());
					i++;
				}

				dt = dt.AddDays(1);
			}
		}


		/// <summary>
		/// Reference to the chart control
		/// </summary>
		public NChartControl nChartControl1;

		internal static double[] monthValues = new double[] { 16, 19, 16, 15, 18, 19, 24, 21, 22, 17, 19, 15 };
		internal static string[] monthLetters = new string[] { "J", "F", "M", "A", "M", "J", "J", "A", "S", "O", "N", "D" };
		internal static string[] weekDays = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

		internal static Color DarkOrange = Color.FromArgb(238, 66, 14);
		internal static Color LightOrange = Color.FromArgb(254, 181, 25);
		internal static Color LightGreen = Color.FromArgb(126, 190, 58);
		internal static Color Turqoise = Color.FromArgb(2, 138, 122);
		internal static Color Blue = Color.FromArgb(2, 90, 156);
		internal static Color Purple = Color.FromArgb(78, 46, 134);
		internal static Color BeautifulRed = Color.FromArgb(170, 30, 96);
		internal static Color Red = Color.FromArgb(225, 7, 24);
		internal static Color Gold = Color.FromArgb(253, 202, 25);
		internal static Color LimeGreen = Color.FromArgb(206, 222, 62);
		internal static Color Green = Color.FromArgb(1, 157, 96);
		internal static Color SeaBlue = Color.FromArgb(2, 117, 137);
		internal static Color LightPurple = Color.FromArgb(69, 72, 165);
		internal static Color DarkFuchsia = Color.FromArgb(123, 22, 98);
		internal static Color GreyBlue = Color.FromArgb(68, 90, 108);

		public static Random Random = new Random();
	}

	internal class NStockDataGenerator
	{
		private Random m_Rand;
		private NRange1DD m_Range;
		private int m_nDirection;
		private int m_nStepsInCurrentTrend;
		private double m_dValue;
		private double m_dReversalPorbability;
		private double m_dReversalFactor;
		private double m_dValueScale;

		internal NStockDataGenerator(NRange1DD range, double reversalFactor, double valueScale)
		{
			m_Rand = new Random();
			m_Range = range;
			m_nDirection = 1;
			m_nStepsInCurrentTrend = 0;
			m_dValue = 0;
			m_dReversalPorbability = 0;
			m_dReversalFactor = reversalFactor;
			m_dValueScale = valueScale;
		}

		internal void Reset()
		{
			m_nDirection = 1;
			m_nStepsInCurrentTrend = 0;
			m_dValue = (m_Range.Begin + m_Range.End) / 2;
			m_dReversalPorbability = 0;
		}

		internal double GetNextValue()
		{
			int nNewValueDirection = 0;

			if (m_dValue <= m_Range.Begin)
			{
				if (m_nDirection == -1)
				{
					m_dReversalPorbability = 1.0;
				}
				else
				{
					m_dReversalPorbability = 0.0;
				}

				nNewValueDirection = 1;
			}
			else if (m_dValue >= m_Range.End)
			{
				if (m_nDirection == 1)
				{
					m_dReversalPorbability = 1.0;
				}
				else
				{
					m_dReversalPorbability = 0.0;
				}

				nNewValueDirection = -1;
			}
			else
			{
				if (m_Rand.NextDouble() < 0.80)
				{
					nNewValueDirection = m_nDirection;
				}
				else
				{
					nNewValueDirection = -m_nDirection;
				}

				m_dReversalPorbability += m_nStepsInCurrentTrend * m_dReversalFactor;
			}

			if (m_Rand.NextDouble() < m_dReversalPorbability)
			{
				m_nDirection = -m_nDirection;
				m_dReversalPorbability = 0;
				m_nStepsInCurrentTrend = 0;
			}
			else
			{
				m_nStepsInCurrentTrend++;
			}

			m_dValue += nNewValueDirection * m_Rand.NextDouble() * m_dValueScale;

			return m_dValue;
		}
	}

}
