using Nevron.Chart;
using Nevron.GraphicsCore;
using System.Drawing;
using System;
using Nevron.Dom;
using System.Collections.Generic;
using Nevron.Chart.Windows;
using Nevron.Chart.Functions;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NRealTimeStockUC : NRealTimeExampleBaseUC
	{
		/// <summary>
		/// Default constructor
		/// </summary>
		public NRealTimeStockUC()
		{
			InitializeComponent();

			m_Random = new Random();
		}


		/// <summary>
		/// Gets the title of this example
		/// </summary>
		public override string Title
		{
			get
			{
				return "Real Time Stock";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "The example demonstrates how to create realtime stock charts with hardware acceleration.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = new NLabel("Real Time Stock");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			nChartControl1.Panels.Add(title);

			m_Chart = (NCartesianChart)nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;

			// add interlace stripes
			NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			linearScale.StripStyles.Add(stripStyle);

			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NRangeTimelineScaleConfigurator();

			// enable range selection
			NRangeSelection rangeSelection = new NRangeSelection();
			rangeSelection.VerticalValueSnapper = new NAxisRulerMinMaxSnapper();
			m_Chart.RangeSelections.Add(rangeSelection);

			// enable zooming and scrolling
			m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = true;
			m_Chart.Axis(StandardAxis.PrimaryX).PagingView = new NDateTimeAxisPagingView();

			m_LineSMA = new NLineSeries();

			// create a line series for the simple moving average			
			m_Chart.Series.Add(m_LineSMA);

			m_LineSMA.Name = "SMA(20)";
			m_LineSMA.DataLabelStyle.Visible = false;
			m_LineSMA.BorderStyle.Color = Color.DarkOrange;
			m_LineSMA.UseXValues = true;

			// create the stock series
			m_Stock = new NStockSeries();
			m_Chart.Series.Add(m_Stock);
			m_Stock.DisplayOnAxis(StandardAxis.PrimaryX, true);

			m_Stock.Name = "Stock Data";
			m_Stock.Legend.Mode = SeriesLegendMode.None;
			m_Stock.DataLabelStyle.Visible = false;
			m_Stock.CandleStyle = CandleStyle.Bar;
			m_Stock.CandleWidth = new NLength(0.8f, NRelativeUnit.ParentPercentage);
			m_Stock.InflateMargins = true;
			m_Stock.UseXValues = true;
			m_Stock.UpFillStyle = new NColorFillStyle(LightGreen);
			m_Stock.UpStrokeStyle.Color = Color.Black;
			m_Stock.DownFillStyle = new NColorFillStyle(Red);
			m_Stock.DownStrokeStyle.Color = Color.Black;
			m_Stock.OpenValues.Name = "open";
			m_Stock.CloseValues.Name = "close";
			m_Stock.HighValues.Name = "high";
			m_Stock.LowValues.Name = "low";

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NAxisScrollTool());
			nChartControl1.Controller.Tools.Add(new NDataZoomTool());
			nChartControl1.Controller.Tools.Add(new NDataPanTool());

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);

			NumberOfDataPointsComboBox.Items.Add("1000");
			NumberOfDataPointsComboBox.Items.Add("5000");
			NumberOfDataPointsComboBox.Items.Add("10000");
			NumberOfDataPointsComboBox.SelectedIndex = 1;

			AddData();

			UseHardwareAccelerationCheckBox.IsChecked = true;
			nChartControl1.Settings.RenderSurface = RenderSurface.Window;
			StartTimer();
		}

		private void AddData()
		{
			int nCount = 200;
			NStockSeries s = m_Stock;
			double open, high, low, close;

			if (m_OpenValues == null || m_OpenValues.Length < nCount)
			{
				m_OpenValues = new double[nCount];
				m_HighValues = new double[nCount];
				m_LowValues = new double[nCount];
				m_CloseValues = new double[nCount];
				m_XValues = new double[nCount];
			}

			for (int index = 0; index < nCount; index++)
			{
				open = m_PrevClose;

				if (m_PrevClose < 25 || m_Random.NextDouble() > 0.5)
				{
					// upward price change
					close = open + (2 + (m_Random.NextDouble() * 20));
					high = close + (m_Random.NextDouble() * 10);
					low = open - (m_Random.NextDouble() * 10);
				}
				else
				{
					// downward price change
					close = open - (2 + (m_Random.NextDouble() * 20));
					high = open + (m_Random.NextDouble() * 10);
					low = close - (m_Random.NextDouble() * 10);
				}

				if (low < 1)
				{
					low = 1;
				}

				m_PrevClose = close;

				m_OpenValues[index] = open;
				m_HighValues[index] = high;
				m_LowValues[index] = low;
				m_CloseValues[index] = close;
				m_XValues[index] = m_Start.ToOADate();

				// advance to next working day
				m_Start = m_Start.AddDays(1);
			}

			s.OpenValues.AddRange(m_OpenValues, 0, nCount);
			s.HighValues.AddRange(m_HighValues, 0, nCount);
			s.LowValues.AddRange(m_LowValues, 0, nCount);
			s.CloseValues.AddRange(m_CloseValues, 0, nCount);
			s.XValues.AddRange(m_XValues, 0, nCount);

			int period = 20;

			// create a function calculator
			NFunctionCalculator fc = new NFunctionCalculator();
			fc.Arguments.Add(m_Stock.CloseValues);

			// calculate the simple moving average
			fc.Expression = "SMA(close; " + period.ToString() + ")";
			m_LineSMA.Values = fc.Calculate();
			m_LineSMA.XValues.AddRange(m_XValues, 0, nCount);

			int numberOfDataPoints = 1000;

			switch (NumberOfDataPointsComboBox.SelectedIndex)
			{
				case 0:
					numberOfDataPoints = 1000;
					break;
				case 1:
					numberOfDataPoints = 5000;
					break;
				case 2:
					numberOfDataPoints = 10000;
					break;
			}

			if (s.Values.Count > numberOfDataPoints)
			{
				s.OpenValues.RemoveRange(0, nCount);
				s.HighValues.RemoveRange(0, nCount);
				s.LowValues.RemoveRange(0, nCount);
				s.CloseValues.RemoveRange(0, nCount);
				s.XValues.RemoveRange(0, nCount);

				m_LineSMA.Values.RemoveRange(0, nCount);
				m_LineSMA.XValues.RemoveRange(0, nCount);
			}
		}

		protected override void UpdateTitle(bool working, float cpuUsage)
		{
			string title = "Real Time Stock";

			if (working)
			{
				title += " [CPU Usage - " + cpuUsage.ToString("0.") + "%]";
			}

			nChartControl1.Labels[0].Text = title;
		}

		private void ResetButton_Click(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_PrevClose = 300;
			m_Start = DateTime.Now;

			m_Stock.OpenValues.Clear();
			m_Stock.HighValues.Clear();
			m_Stock.LowValues.Clear();
			m_Stock.CloseValues.Clear();
			m_Stock.XValues.Clear();

			m_LineSMA.Values.Clear();
			m_LineSMA.XValues.Clear();
		}

		protected override void OnTimerTick(object sender, EventArgs e)
		{
			base.OnTimerTick(sender, e);

			AddData();

			nChartControl1.Refresh();
		}


		NLineSeries m_LineSMA;
		NCartesianChart m_Chart;
		NStockSeries m_Stock;
		double m_PrevClose = 300.0;
		DateTime m_Start = DateTime.Now;

		double[] m_OpenValues;
		double[] m_HighValues;
		double[] m_LowValues;
		double[] m_CloseValues;
		double[] m_XValues;
		Random m_Random;

		private void UseHardwareAccelerationCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			nChartControl1.Settings.RenderSurface = (bool)UseHardwareAccelerationCheckBox.IsChecked ? RenderSurface.Window : RenderSurface.Bitmap;
		}

		private void StartStopTimerButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			ToggleTimer();

			if (IsTimerRunning())
			{
				StartStopTimerButton.Content = "Stop Timer";
			}
			else
			{
				StartStopTimerButton.Content = "Start Timer";
			}
		}

		private void NumberOfDataPointsComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			ResetButton_Click(null, null);
		}
	}
}
