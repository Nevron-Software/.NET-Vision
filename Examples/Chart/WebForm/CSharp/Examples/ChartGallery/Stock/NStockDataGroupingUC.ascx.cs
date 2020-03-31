using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.ThinWeb;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NStockDataGroupingUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			NStockSeries stock;

			if (!IsPostBack)
			{
				// set a chart title
				nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

				NLabel title = nChartControl1.Labels.AddHeader("Stock Data Grouping");
				title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
				title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

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
				stock = (NStockSeries)chart.Series.Add(SeriesType.Stock);
				stock.DataLabelStyle.Visible = false;
				stock.UpFillStyle = new NColorFillStyle(Color.White);
				stock.UpStrokeStyle.Color = Color.Black;
				stock.DownFillStyle = new NColorFillStyle(Color.Crimson);
				stock.DownStrokeStyle.Color = Color.Crimson;
				stock.HighLowStrokeStyle.Color = Color.Black;
				stock.CandleWidth = new NLength(1.2f, NRelativeUnit.ParentPercentage);
				stock.UseXValues = true;
				stock.InflateMargins = true;
				stock.DataLabelStyle.Format = "open - <open>\r\nclose - <close>";

				// add some stock items
				const int numDataPoints = 1000;
				WebExamplesUtilities.GenerateOHLCData(stock, 100.0, numDataPoints, new NRange1DD(60, 140));
				FillStockDates(stock, numDataPoints, DateTime.Now - new TimeSpan((int)(numDataPoints * 1.2), 0, 0, 0));

				// apply layout
				ApplyLayoutTemplate(0, nChartControl1, chart, title, null);

				// update form controls
				CustomDateTimeSpanDropDownList.Items.Add("1 Week");
				CustomDateTimeSpanDropDownList.Items.Add("2 Weeks");
				CustomDateTimeSpanDropDownList.Items.Add("1 Month");
				CustomDateTimeSpanDropDownList.Items.Add("3 Months");

				WebExamplesUtilities.FillComboWithEnumNames(GroupingModeDropDownList, typeof(StockGroupingMode));

				CustomDateTimeSpanDropDownList.SelectedIndex = 2;
				GroupingModeDropDownList.SelectedIndex = (int)StockGroupingMode.SynchronizeWithMajorTick;

				WebExamplesUtilities.FillComboWithPercents(GroupPercendWidthDropDownList, 10);
				GroupPercendWidthDropDownList.SelectedIndex = 2;

				WebExamplesUtilities.FillComboWithValues(MinGroupDistanceDropDownList, 2, 20, 2);
				MinGroupDistanceDropDownList.SelectedIndex = 2;
			}
			else
			{
				stock = (NStockSeries)nChartControl1.Charts[0].Series[0];
			}

			MinGroupDistanceDropDownList.Enabled = false;
			CustomDateTimeSpanDropDownList.Enabled = false;
			GroupPercendWidthDropDownList.Enabled = true;

			switch (GroupingModeDropDownList.SelectedIndex)
			{
				case (int)StockGroupingMode.None:
					stock.GroupingMode = StockGroupingMode.None;
					GroupPercendWidthDropDownList.Enabled = false;
					break;
				case (int)StockGroupingMode.AutoDateTimeSpan:
					stock.GroupingMode = StockGroupingMode.AutoDateTimeSpan;
					MinGroupDistanceDropDownList.Enabled = true;
					break;
				case (int)StockGroupingMode.CustomDateTimeSpan:
					stock.GroupingMode = StockGroupingMode.CustomDateTimeSpan;
					CustomDateTimeSpanDropDownList.Enabled = true;
					break;
				case (int)StockGroupingMode.SynchronizeWithMajorTick:
					stock.GroupingMode = StockGroupingMode.SynchronizeWithMajorTick;
					break;
				default:
					break;
			}

			stock.MinAutoGroupLength = new NLength((float)MinGroupDistanceDropDownList.SelectedIndex * 2 + 2, NGraphicsUnit.Point);

			switch (CustomDateTimeSpanDropDownList.SelectedIndex)
			{
				case 0: // 1 Week
					stock.CustomGroupStep = new NDateTimeSpan(1, NDateTimeUnit.Week);
					break;
				case 1: // 2 Weeks
					stock.CustomGroupStep = new NDateTimeSpan(2, NDateTimeUnit.Week);
					break;
				case 2: // 1 Month
					stock.CustomGroupStep = new NDateTimeSpan(1, NDateTimeUnit.Month);
					break;
				case 3: // 3 Months
					stock.CustomGroupStep = new NDateTimeSpan(3, NDateTimeUnit.Month);
					break;
			}

			stock.GroupPercentWidth = (float)GroupPercendWidthDropDownList.SelectedIndex * 10;
		}
	}
}
