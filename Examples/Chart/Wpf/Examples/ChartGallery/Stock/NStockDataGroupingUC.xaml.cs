using Nevron.Chart;
using Nevron.GraphicsCore;
using System;
using System.Drawing;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NStockDataGroupingUC : NExampleBaseUC
	{
		private NStockSeries m_Stock;

		public NStockDataGroupingUC()
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
				return "Stock Data Grouping";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "The example demonstrate how to apply stock data grouping to stock charts. Stock grouping allows you to visualize stock data by aggregating values that are close together in time in order not to overpopulate the chart. On the right side you can modify the grouping mode and other properties of the stock series.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Stock Data Grouping");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NCartesianChart chart = (NCartesianChart)nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			NRangeSelection rs = new NRangeSelection();
			rs.VerticalValueSnapper = new NAxisRulerMinMaxSnapper();
			chart.RangeSelections.Add(rs);

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
			chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = true;

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
			m_Stock.DataLabelStyle.Format = "open - <open>\r\nclose - <close>";

			// add some stock items
			const int numDataPoints = 10000;
			GenerateOHLCData(m_Stock, 100.0, numDataPoints, new NRange1DD(60, 140));
			FillStockDates(m_Stock, numDataPoints, DateTime.Now - new TimeSpan((int)(numDataPoints * 1.2), 0, 0, 0));

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NAxisScrollTool());
			nChartControl1.Controller.Tools.Add(new NDataZoomTool());

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// update form controls
			CustomDateTimeSpanComboBox.Items.Add("1 Week");
			CustomDateTimeSpanComboBox.Items.Add("2 Weeks");
			CustomDateTimeSpanComboBox.Items.Add("1 Month");
			CustomDateTimeSpanComboBox.Items.Add("3 Months");

			NExampleHelpers.FillComboWithEnumValues(GroupingModeComboBox, typeof(StockGroupingMode));

			CustomDateTimeSpanComboBox.SelectedIndex = 2;
			GroupingModeComboBox.SelectedIndex = (int)StockGroupingMode.AutoDateTimeSpan;
		}

		private void GroupingModeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (m_Stock == null)
				return;

			MinGroupDistanceScrollBar.IsEnabled = false;
			CustomDateTimeSpanComboBox.IsEnabled = false;
			GroupPercentWidthScrollBar.IsEnabled = true;

			switch (GroupingModeComboBox.SelectedIndex)
			{
				case (int)StockGroupingMode.None:
					m_Stock.GroupingMode = StockGroupingMode.None;
					GroupPercentWidthScrollBar.IsEnabled = false;
					break;
				case (int)StockGroupingMode.AutoDateTimeSpan:
					m_Stock.GroupingMode = StockGroupingMode.AutoDateTimeSpan;
					MinGroupDistanceScrollBar.IsEnabled = true;
					break;
				case (int)StockGroupingMode.CustomDateTimeSpan:
					m_Stock.GroupingMode = StockGroupingMode.CustomDateTimeSpan;
					CustomDateTimeSpanComboBox.IsEnabled = true;
					break;
				case (int)StockGroupingMode.SynchronizeWithMajorTick:
					m_Stock.GroupingMode = StockGroupingMode.SynchronizeWithMajorTick;
					break;
				default:
					break;
			}

			nChartControl1.Refresh();
		}

		private void MinGroupDistanceScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			if (m_Stock == null)
				return;

			m_Stock.MinAutoGroupLength = new NLength((float)MinGroupDistanceScrollBar.Value, NGraphicsUnit.Point);
			nChartControl1.Refresh();
		}

		private void CustomDateTimeSpanComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (m_Stock == null)
				return;

			switch (CustomDateTimeSpanComboBox.SelectedIndex)
			{
				case 0: // 1 Week
					m_Stock.CustomGroupStep = new NDateTimeSpan(1, NDateTimeUnit.Week);
					break;
				case 1: // 2 Weeks
					m_Stock.CustomGroupStep = new NDateTimeSpan(2, NDateTimeUnit.Week);
					break;
				case 2: // 1 Month
					m_Stock.CustomGroupStep = new NDateTimeSpan(1, NDateTimeUnit.Month);
					break;
				case 3: // 3 Months
					m_Stock.CustomGroupStep = new NDateTimeSpan(3, NDateTimeUnit.Month);
					break;
			}

			nChartControl1.Refresh();
		}

		private void GroupPercentWidthScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			if (m_Stock == null)
				return;

			m_Stock.GroupPercentWidth = (float)GroupPercentWidthScrollBar.Value;
			nChartControl1.Refresh();
		}

		private void ShowDataLabelsCheckBox_Clicked(object sender, System.Windows.RoutedEventArgs e)
		{
			if (m_Stock == null)
				return;

			m_Stock.DataLabelStyle.Visible = ShowDataLabelsCheckBox.IsChecked.Value;
			nChartControl1.Refresh();
		}	
	}
}
