using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.Functions;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NDateTimeWorkCalendarUC : NExampleUC
	{
		NWorkCalendar m_Calendar;

		protected void Page_Load(object sender, EventArgs e)
		{
			// init form controls
			if (!IsPostBack)
			{
				EnableWeekRuleCheckBox.Checked = true;

				MondayCheckBox.Checked = true;
				TuesdayCheckBox.Checked = true;
				WednesdayCheckBox.Checked = true;
				ThursdayCheckBox.Checked = true;
				FridayCheckBox.Checked = true;

				EnableMonthDayRuleCheckBox.Checked = true;

				WebExamplesUtilities.FillComboWithValues(MonthDayDropDownList, 1, 31, 1);
				MonthDayWorkingCheckBox.Checked = false;

				ZoomModeDropDownList.Items.Add("First 7 Days");
				ZoomModeDropDownList.Items.Add("First 31 Days");
				ZoomModeDropDownList.SelectedIndex = 0;
			}
			else
			{
				bool enableWeekDays = EnableWeekRuleCheckBox.Checked;

				MondayCheckBox.Enabled = enableWeekDays;
				TuesdayCheckBox.Enabled = enableWeekDays;
				WednesdayCheckBox.Enabled = enableWeekDays;
				ThursdayCheckBox.Enabled = enableWeekDays;
				FridayCheckBox.Enabled = enableWeekDays;
				SaturdayCheckBox.Enabled = enableWeekDays;
				SundayCheckBox.Enabled = enableWeekDays;

				bool enableMonthDayRules = EnableMonthDayRuleCheckBox.Checked;

				MonthDayDropDownList.Enabled = enableMonthDayRules;
				MonthDayWorkingCheckBox.Enabled = enableMonthDayRules;
			}

			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = new NLabel("Date Time Work Calendar");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			nChartControl1.Panels.Add(title);

			NCartesianChart chart = (NCartesianChart)nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			// add interlace stripe
			NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			// enable range selection
			NRangeSelection rangeSelection = new NRangeSelection();
			rangeSelection.VerticalValueSnapper = new NAxisRulerMinMaxSnapper();
			chart.RangeSelections.Add(rangeSelection);

			// enable zooming and scrolling
			chart.Axis(StandardAxis.PrimaryX).PagingView = new NDateTimeAxisPagingView();

			// apply calendar to scale
			NRangeTimelineScaleConfigurator timeline = new NRangeTimelineScaleConfigurator();
			timeline.EnableCalendar = true;
			m_Calendar = CreateWorkCalendar();
			timeline.Calendar = m_Calendar;
			timeline.ThirdRow.EnableUnitSensitiveFormatting = false;

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = timeline;

			// generate data for this calendar
			AddData(chart);

			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}

		private NWorkCalendar CreateWorkCalendar()
		{
			// create calendar
			NWorkCalendar m_Calendar = new NWorkCalendar();

			// use week days
			if (EnableWeekRuleCheckBox.Checked)
			{
				NWeekDayRule weekDayRule = new NWeekDayRule();

				WeekDayBit weekDays = WeekDayBit.None;
				if (MondayCheckBox.Checked)
				{
					weekDays |= WeekDayBit.Monday;
				}

				if (TuesdayCheckBox.Checked)
				{
					weekDays |= WeekDayBit.Tuesday;
				}

				if (WednesdayCheckBox.Checked)
				{
					weekDays |= WeekDayBit.Wednesday;
				}

				if (ThursdayCheckBox.Checked)
				{
					weekDays |= WeekDayBit.Thursday;
				}

				if (FridayCheckBox.Checked)
				{
					weekDays |= WeekDayBit.Friday;
				}

				if (SaturdayCheckBox.Checked)
				{
					weekDays |= WeekDayBit.Saturday;
				}

				if (SundayCheckBox.Checked)
				{
					weekDays |= WeekDayBit.Sunday;
				}

				if (!(weekDays.Equals(WeekDayBit.None)))
				{
					// cannot select all week days as non working as this leads to a scale with no
					// working days...
					weekDayRule.WeekDays = weekDays;
					weekDayRule.Schedule.SetHourRange(0, 24, false);
					m_Calendar.Rules.Add(weekDayRule);
				}
			}

			if (EnableMonthDayRuleCheckBox.Checked)
			{
				NMonthDayRule monthDayRule = new NMonthDayRule();

				monthDayRule.Months = MonthBit.January |
								MonthBit.February |
								MonthBit.March |
								MonthBit.April |
								MonthBit.May |
								MonthBit.June |
								MonthBit.July |
								MonthBit.August |
								MonthBit.September |
								MonthBit.October |
								MonthBit.November |
								MonthBit.December;

				monthDayRule.Day = MonthDayDropDownList.SelectedIndex + 1;
				monthDayRule.Working = MonthDayWorkingCheckBox.Checked;
				m_Calendar.Rules.Add(monthDayRule);
			}

			return m_Calendar;
		}

		private void AddData(NCartesianChart chart)
		{
			const int nHistoricalDays = 20;

			// first clear all series
			chart.Series.Clear();
			// create a line series for the simple moving average
			NLineSeries lineSMA = new NLineSeries();
			chart.Series.Add(lineSMA);

			lineSMA.Name = "SMA(20)";
			lineSMA.DataLabelStyle.Visible = false;
			lineSMA.BorderStyle.Color = Color.DarkOrange;
			lineSMA.UseXValues = true;

			// create the stock series
			NStockSeries stock = new NStockSeries();
			chart.Series.Add(stock);
			stock.Name = "Stock Data";
			stock.Legend.Mode = SeriesLegendMode.None;
			stock.DataLabelStyle.Visible = false;
			stock.CandleStyle = CandleStyle.Bar;
			stock.CandleWidth = new NLength(5, NGraphicsUnit.Point);
			stock.InflateMargins = false;
			stock.UpFillStyle = new NColorFillStyle(Green);
			stock.UpStrokeStyle.Color = Color.Black;
			stock.DownFillStyle = new NColorFillStyle(DarkOrange);
			stock.DownStrokeStyle.Color = Color.Black;
			stock.DisplayOnAxis(StandardAxis.PrimaryX, true);
			stock.InflateMargins = true;
			stock.OpenValues.Name = "open";
			stock.CloseValues.Name = "close";
			stock.HighValues.Name = "high";
			stock.LowValues.Name = "low";
			stock.UseXValues = true;

			int period = 20;

			// add the bollinger bands as high low area
			NHighLowSeries highLow = new NHighLowSeries();
			chart.Series.Add(highLow);
			highLow.Name = "BB(" + period.ToString() + ", 2)";
			highLow.DataLabelStyle.Visible = false;
			highLow.HighFillStyle = new NColorFillStyle(Color.FromArgb(80, 130, 134, 168));
			highLow.HighBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			highLow.DisplayOnAxis(StandardAxis.SecondaryX, true);
			highLow.UseXValues = true;

			// generate some stock data
			GenerateOHLCData(stock, 300, nHistoricalDays);

			// create a function calculator
			NFunctionCalculator fc = new NFunctionCalculator();
			fc.Arguments.Add(stock.CloseValues);

			// calculate the bollinger bands
			fc.Expression = "BOLLINGER(close;" + period.ToString() + "; 2)";
			highLow.HighValues = fc.Calculate();
			highLow.HighValues.Name = "BollingerUpper";

			fc.Expression = "BOLLINGER(close; " + period.ToString() + "; -2)";
			highLow.LowValues = fc.Calculate();
			highLow.LowValues.Name = "BollingerLower";
			highLow.XValues.InsertRange(0, stock.XValues);

			// calculate the simple moving average
			fc.Expression = "SMA(close; " + period.ToString() + ")";
			lineSMA.Values = fc.Calculate();
			lineSMA.XValues.InsertRange(0, stock.XValues);

			// remove first period from line SMA
			lineSMA.Values.RemoveRange(0, period);
			lineSMA.XValues.RemoveRange(0, period);

			// remove first period from high low
			highLow.XValues.RemoveRange(0, period);
			highLow.HighValues.RemoveRange(0, period);
			highLow.LowValues.RemoveRange(0, period);

			// remove first period from stock
			stock.OpenValues.RemoveRange(0, period);
			stock.HighValues.RemoveRange(0, period);
			stock.LowValues.RemoveRange(0, period);
			stock.CloseValues.RemoveRange(0, period);
			stock.XValues.RemoveRange(0, period);
		}

		internal void GenerateOHLCData(NStockSeries s, double dPrevClose, int historicalDays)
		{
			DateTime now = DateTime.Now;
			NTimeline timeline = m_Calendar.CreateTimeline(new NDateTimeRange(now, now + new TimeSpan(360, 0, 0, 0, 0)));
			double open, high, low, close;

			s.ClearDataPoints();

			int numberOfWorkingDays = historicalDays;
			if (ZoomModeDropDownList.SelectedIndex == 0)
			{
				numberOfWorkingDays += 7;
			}
			else
			{
				numberOfWorkingDays += 31;
			}

			for (; numberOfWorkingDays > 0; numberOfWorkingDays--)
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
				s.XValues.Add(now.ToOADate());

				// advance to next working day
				now = timeline.AddTimeSpan(now, new NDateTimeSpan(1, NDateTimeUnit.Day));
			}
		}
	}
}
