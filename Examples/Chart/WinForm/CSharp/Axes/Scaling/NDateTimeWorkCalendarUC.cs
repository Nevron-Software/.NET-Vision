using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Globalization;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.Functions;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm 
{
	[ToolboxItem(false)]
	public class NDateTimeWorkCalendarUC : NExampleBaseUC
	{
		private NCartesianChart m_Chart;
		NWorkCalendar m_Calendar;
		private NStockSeries m_Stock;
		private NHighLowSeries m_HighLow;
		private bool m_Updating;
		private Nevron.UI.WinForm.Controls.NGroupBox WorkingDaysGroupBox;
		private Nevron.UI.WinForm.Controls.NCheckBox SaturdayCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox FridayCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox TuesdayCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox MondayCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox ThursdayCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox WednesdayCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox SundayCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox EnableWeekRuleCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox EnableMonthDayRuleCheckBox;
		private Nevron.UI.WinForm.Controls.NNumericUpDown MonthDayUpDown;
		private Label label10;
		private Nevron.UI.WinForm.Controls.NRadioButton RestRadioButton;
		private Nevron.UI.WinForm.Controls.NRadioButton WorkRadioButton;
		private Nevron.UI.WinForm.Controls.NButton ZoomToFirst7DaysButton;
		private Nevron.UI.WinForm.Controls.NButton ZoomToFirst30DaysButton;
		private NLineSeries m_LineSMA;

		public NDateTimeWorkCalendarUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.WorkingDaysGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.SundayCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SaturdayCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.FridayCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.TuesdayCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.MondayCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ThursdayCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.WednesdayCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.EnableWeekRuleCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.EnableMonthDayRuleCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.MonthDayUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label10 = new System.Windows.Forms.Label();
			this.RestRadioButton = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.WorkRadioButton = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.ZoomToFirst7DaysButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ZoomToFirst30DaysButton = new Nevron.UI.WinForm.Controls.NButton();
			this.WorkingDaysGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MonthDayUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// WorkingDaysGroupBox
			// 
			this.WorkingDaysGroupBox.Controls.Add(this.SundayCheckBox);
			this.WorkingDaysGroupBox.Controls.Add(this.SaturdayCheckBox);
			this.WorkingDaysGroupBox.Controls.Add(this.FridayCheckBox);
			this.WorkingDaysGroupBox.Controls.Add(this.TuesdayCheckBox);
			this.WorkingDaysGroupBox.Controls.Add(this.MondayCheckBox);
			this.WorkingDaysGroupBox.Controls.Add(this.ThursdayCheckBox);
			this.WorkingDaysGroupBox.Controls.Add(this.WednesdayCheckBox);
			this.WorkingDaysGroupBox.ImageIndex = 0;
			this.WorkingDaysGroupBox.Location = new System.Drawing.Point(19, 36);
			this.WorkingDaysGroupBox.Name = "WorkingDaysGroupBox";
			this.WorkingDaysGroupBox.Size = new System.Drawing.Size(195, 145);
			this.WorkingDaysGroupBox.TabIndex = 1;
			this.WorkingDaysGroupBox.TabStop = false;
			this.WorkingDaysGroupBox.Text = "Working Days";
			// 
			// SundayCheckBox
			// 
			this.SundayCheckBox.ButtonProperties.BorderOffset = 2;
			this.SundayCheckBox.Location = new System.Drawing.Point(105, 79);
			this.SundayCheckBox.Name = "SundayCheckBox";
			this.SundayCheckBox.Size = new System.Drawing.Size(104, 24);
			this.SundayCheckBox.TabIndex = 6;
			this.SundayCheckBox.Text = "Sunday";
			this.SundayCheckBox.CheckedChanged += new System.EventHandler(this.SundayCheckBox_CheckedChanged);
			// 
			// SaturdayCheckBox
			// 
			this.SaturdayCheckBox.ButtonProperties.BorderOffset = 2;
			this.SaturdayCheckBox.Location = new System.Drawing.Point(105, 49);
			this.SaturdayCheckBox.Name = "SaturdayCheckBox";
			this.SaturdayCheckBox.Size = new System.Drawing.Size(104, 24);
			this.SaturdayCheckBox.TabIndex = 5;
			this.SaturdayCheckBox.Text = "Saturday";
			this.SaturdayCheckBox.CheckedChanged += new System.EventHandler(this.SaturdayCheckBox_CheckedChanged);
			// 
			// FridayCheckBox
			// 
			this.FridayCheckBox.ButtonProperties.BorderOffset = 2;
			this.FridayCheckBox.Location = new System.Drawing.Point(105, 19);
			this.FridayCheckBox.Name = "FridayCheckBox";
			this.FridayCheckBox.Size = new System.Drawing.Size(104, 24);
			this.FridayCheckBox.TabIndex = 4;
			this.FridayCheckBox.Text = "Friday";
			this.FridayCheckBox.CheckedChanged += new System.EventHandler(this.FridayCheckBox_CheckedChanged);
			// 
			// TuesdayCheckBox
			// 
			this.TuesdayCheckBox.ButtonProperties.BorderOffset = 2;
			this.TuesdayCheckBox.Location = new System.Drawing.Point(6, 49);
			this.TuesdayCheckBox.Name = "TuesdayCheckBox";
			this.TuesdayCheckBox.Size = new System.Drawing.Size(104, 24);
			this.TuesdayCheckBox.TabIndex = 1;
			this.TuesdayCheckBox.Text = "Tuesday";
			this.TuesdayCheckBox.CheckedChanged += new System.EventHandler(this.TuesdayCheckBox_CheckedChanged);
			// 
			// MondayCheckBox
			// 
			this.MondayCheckBox.ButtonProperties.BorderOffset = 2;
			this.MondayCheckBox.Location = new System.Drawing.Point(6, 19);
			this.MondayCheckBox.Name = "MondayCheckBox";
			this.MondayCheckBox.Size = new System.Drawing.Size(104, 24);
			this.MondayCheckBox.TabIndex = 0;
			this.MondayCheckBox.Text = "Monday";
			this.MondayCheckBox.CheckedChanged += new System.EventHandler(this.MondayCheckBox_CheckedChanged);
			// 
			// ThursdayCheckBox
			// 
			this.ThursdayCheckBox.ButtonProperties.BorderOffset = 2;
			this.ThursdayCheckBox.Location = new System.Drawing.Point(6, 109);
			this.ThursdayCheckBox.Name = "ThursdayCheckBox";
			this.ThursdayCheckBox.Size = new System.Drawing.Size(104, 24);
			this.ThursdayCheckBox.TabIndex = 3;
			this.ThursdayCheckBox.Text = "Thursday";
			this.ThursdayCheckBox.CheckedChanged += new System.EventHandler(this.ThursdayCheckBox_CheckedChanged);
			// 
			// WednesdayCheckBox
			// 
			this.WednesdayCheckBox.ButtonProperties.BorderOffset = 2;
			this.WednesdayCheckBox.Location = new System.Drawing.Point(6, 79);
			this.WednesdayCheckBox.Name = "WednesdayCheckBox";
			this.WednesdayCheckBox.Size = new System.Drawing.Size(104, 24);
			this.WednesdayCheckBox.TabIndex = 2;
			this.WednesdayCheckBox.Text = "Wednesday";
			this.WednesdayCheckBox.CheckedChanged += new System.EventHandler(this.WednesdayCheckBox_CheckedChanged);
			// 
			// EnableWeekRuleCheckBox
			// 
			this.EnableWeekRuleCheckBox.ButtonProperties.BorderOffset = 2;
			this.EnableWeekRuleCheckBox.Location = new System.Drawing.Point(19, 6);
			this.EnableWeekRuleCheckBox.Name = "EnableWeekRuleCheckBox";
			this.EnableWeekRuleCheckBox.Size = new System.Drawing.Size(187, 24);
			this.EnableWeekRuleCheckBox.TabIndex = 0;
			this.EnableWeekRuleCheckBox.Text = "Enable Week Rule";
			this.EnableWeekRuleCheckBox.CheckedChanged += new System.EventHandler(this.EnableWeekRuleCheckBox_CheckedChanged);
			// 
			// EnableMonthDayRuleCheckBox
			// 
			this.EnableMonthDayRuleCheckBox.ButtonProperties.BorderOffset = 2;
			this.EnableMonthDayRuleCheckBox.Location = new System.Drawing.Point(19, 187);
			this.EnableMonthDayRuleCheckBox.Name = "EnableMonthDayRuleCheckBox";
			this.EnableMonthDayRuleCheckBox.Size = new System.Drawing.Size(187, 24);
			this.EnableMonthDayRuleCheckBox.TabIndex = 2;
			this.EnableMonthDayRuleCheckBox.Text = "Enable Month Day Rule";
			this.EnableMonthDayRuleCheckBox.CheckedChanged += new System.EventHandler(this.EnableMonthDayRuleCheckBox_CheckedChanged);
			// 
			// MonthDayUpDown
			// 
			this.MonthDayUpDown.Location = new System.Drawing.Point(130, 217);
			this.MonthDayUpDown.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
			this.MonthDayUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.MonthDayUpDown.Name = "MonthDayUpDown";
			this.MonthDayUpDown.Size = new System.Drawing.Size(83, 20);
			this.MonthDayUpDown.TabIndex = 4;
			this.MonthDayUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.MonthDayUpDown.ValueChanged += new System.EventHandler(this.MonthDayUpDown_ValueChanged);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(19, 221);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(94, 16);
			this.label10.TabIndex = 3;
			this.label10.Text = "Each Month Day:";
			// 
			// RestRadioButton
			// 
			this.RestRadioButton.ButtonProperties.BorderOffset = 2;
			this.RestRadioButton.Location = new System.Drawing.Point(19, 271);
			this.RestRadioButton.Name = "RestRadioButton";
			this.RestRadioButton.Size = new System.Drawing.Size(135, 24);
			this.RestRadioButton.TabIndex = 6;
			this.RestRadioButton.Text = "Rest";
			this.RestRadioButton.CheckedChanged += new System.EventHandler(this.RestRadioButton_CheckedChanged);
			// 
			// WorkRadioButton
			// 
			this.WorkRadioButton.ButtonProperties.BorderOffset = 2;
			this.WorkRadioButton.Location = new System.Drawing.Point(19, 251);
			this.WorkRadioButton.Name = "WorkRadioButton";
			this.WorkRadioButton.Size = new System.Drawing.Size(104, 24);
			this.WorkRadioButton.TabIndex = 5;
			this.WorkRadioButton.Text = "Work";
			this.WorkRadioButton.CheckedChanged += new System.EventHandler(this.WorkRadioButton_CheckedChanged);
			// 
			// ZoomToFirst7DaysButton
			// 
			this.ZoomToFirst7DaysButton.Location = new System.Drawing.Point(18, 301);
			this.ZoomToFirst7DaysButton.Name = "ZoomToFirst7DaysButton";
			this.ZoomToFirst7DaysButton.Size = new System.Drawing.Size(195, 23);
			this.ZoomToFirst7DaysButton.TabIndex = 8;
			this.ZoomToFirst7DaysButton.Text = "Zoom To First 7 Days";
			this.ZoomToFirst7DaysButton.UseVisualStyleBackColor = true;
			this.ZoomToFirst7DaysButton.Click += new System.EventHandler(this.ZoomToFirst7DaysButton_Click);
			// 
			// ZoomToFirst30DaysButton
			// 
			this.ZoomToFirst30DaysButton.Location = new System.Drawing.Point(19, 330);
			this.ZoomToFirst30DaysButton.Name = "ZoomToFirst30DaysButton";
			this.ZoomToFirst30DaysButton.Size = new System.Drawing.Size(195, 23);
			this.ZoomToFirst30DaysButton.TabIndex = 7;
			this.ZoomToFirst30DaysButton.Text = "Zoom to First 30 Days";
			this.ZoomToFirst30DaysButton.UseVisualStyleBackColor = true;
			this.ZoomToFirst30DaysButton.Click += new System.EventHandler(this.ZoomToFirst30DaysButton_Click);
			// 
			// NDateTimeWorkCalendarUC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ZoomToFirst7DaysButton);
			this.Controls.Add(this.ZoomToFirst30DaysButton);
			this.Controls.Add(this.RestRadioButton);
			this.Controls.Add(this.WorkRadioButton);
			this.Controls.Add(this.MonthDayUpDown);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.EnableMonthDayRuleCheckBox);
			this.Controls.Add(this.EnableWeekRuleCheckBox);
			this.Controls.Add(this.WorkingDaysGroupBox);
			this.Name = "NDateTimeWorkCalendarUC";
			this.Size = new System.Drawing.Size(231, 457);
			this.WorkingDaysGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.MonthDayUpDown)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = new NLabel("Date Time Work Calendar<br/><font size = '9pt'>Demonstrates how to skip date time ranges using Week and Month rules</font>");
			title.TextStyle.TextFormat = TextFormat.XML;
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			nChartControl1.Panels.Add(title);

			m_Chart = (NCartesianChart)nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;

			// add interlace stripes
			NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			linearScale.StripStyles.Add(stripStyle);

			// enable range selection
			NRangeSelection rangeSelection = new NRangeSelection();
			rangeSelection.VerticalValueSnapper = new NAxisRulerMinMaxSnapper();
			m_Chart.RangeSelections.Add(rangeSelection);

			// enable zooming and scrolling
			m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = true;
			m_Chart.Axis(StandardAxis.PrimaryX).PagingView = new NDateTimeAxisPagingView();

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NAxisScrollTool());
			nChartControl1.Controller.Tools.Add(new NDataZoomTool());
			nChartControl1.Controller.Tools.Add(new NDataPanTool());

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);

			// update form controls
			m_Updating = true;
			EnableWeekRuleCheckBox.Checked = true;

			MondayCheckBox.Checked = true;
			TuesdayCheckBox.Checked = true;
			WednesdayCheckBox.Checked = true;
			ThursdayCheckBox.Checked = true;
			FridayCheckBox.Checked = true;
			
			EnableMonthDayRuleCheckBox.Checked = true;
			MonthDayUpDown.Value = 1;
			WorkRadioButton.Checked = true;
			m_Updating = false;

			CreateWorkCalendar();
		}

		private void CreateWorkCalendar()
		{
			if (m_Updating)
				return;

            if (m_Chart != null)
            {
                m_Chart.Axis(StandardAxis.PrimaryX).PagingView.Enabled = false;
                m_Chart.Axis(StandardAxis.PrimaryY).PagingView.Enabled = false;
            }

			// create calendar
			m_Calendar = new NWorkCalendar();

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

				if (weekDays == WeekDayBit.None)
				{
					// cannot select all week days as non working as this leads to a scale with no
					// working days...
					MessageBox.Show("You cannot select all weekdays as non working.");
					return;
				}

				weekDayRule.WeekDays = weekDays;
				weekDayRule.Schedule.SetHourRange(0, 24, false);
				m_Calendar.Rules.Add(weekDayRule);
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

				monthDayRule.Day = (int)MonthDayUpDown.Value;
				monthDayRule.Working = WorkRadioButton.Checked;
				m_Calendar.Rules.Add(monthDayRule);
			}

			// apply calendar to scale
			NRangeTimelineScaleConfigurator timeline = new NRangeTimelineScaleConfigurator();
			timeline.FirstRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			timeline.FirstRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(225, 225, 225));
			timeline.FirstRow.UseGridStyle = true;
			timeline.SecondRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			timeline.SecondRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(215, 215, 215));
			timeline.SecondRow.UseGridStyle = true;
			timeline.ThirdRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			timeline.ThirdRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(205, 205, 205));
			timeline.ThirdRow.UseGridStyle = true;

			timeline.EnableCalendar = true;
			timeline.Calendar = m_Calendar;
			timeline.ThirdRow.EnableUnitSensitiveFormatting = false;

            if (m_Chart != null)
            {
                m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = timeline;
            }

			// generate data for this calendar
			AddData();

            if (nChartControl1 != null)
            {
                nChartControl1.Refresh();
            }
		}

		private void AddData()
		{
			const int nNumberOfWeeks = 20;
			const int nWorkDaysInWeek = 5;
			const int nTotalWorkDays = nNumberOfWeeks * nWorkDaysInWeek;
			const int nHistoricalDays = 20;

            m_LineSMA = new NLineSeries();

            if (m_Chart != null)
            {
                // first clear all series
                m_Chart.Series.Clear();
                // create a line series for the simple moving average			
                m_Chart.Series.Add(m_LineSMA);
            }
			m_LineSMA.Name = "SMA(20)";
			m_LineSMA.DataLabelStyle.Visible = false;
			m_LineSMA.BorderStyle.Color = Color.DarkOrange;
			m_LineSMA.UseXValues = true;

            // create the stock series
            m_Stock = new NStockSeries();

            if (m_Chart != null)
            {
                m_Chart.Series.Add(m_Stock);
                m_Stock.DisplayOnAxis(StandardAxis.PrimaryX, true);
            }            

			m_Stock.Name = "Stock Data";
			m_Stock.Legend.Mode = SeriesLegendMode.None;
			m_Stock.DataLabelStyle.Visible = false;
			m_Stock.CandleStyle = CandleStyle.Bar;
			m_Stock.CandleWidth = new NLength(0.8f, NRelativeUnit.ParentPercentage);
			m_Stock.InflateMargins = true;
			m_Stock.UseXValues = true;
			m_Stock.UpFillStyle = new NColorFillStyle(Green);
			m_Stock.UpStrokeStyle.Color = Color.Black;
			m_Stock.DownFillStyle = new NColorFillStyle(Red);
			m_Stock.DownStrokeStyle.Color = Color.Black;
			m_Stock.OpenValues.Name = "open";
			m_Stock.CloseValues.Name = "close";
			m_Stock.HighValues.Name = "high";
			m_Stock.LowValues.Name = "low";
			
			int period = 20;

			// add the bollinger bands as high low area
			m_HighLow = new NHighLowSeries();
            if (m_Chart != null)
            {
                m_Chart.Series.Add(m_HighLow);
                m_HighLow.DisplayOnAxis(StandardAxis.SecondaryX, true);
            }
			m_HighLow.Name = "BB(" + period.ToString() + ", 2)";
			m_HighLow.DataLabelStyle.Visible = false;
			m_HighLow.HighFillStyle = new NColorFillStyle(Color.FromArgb(80, 130, 134, 168));
			m_HighLow.HighBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			
			m_HighLow.UseXValues = true;

			// generate some stock data
			GenerateData(m_Stock, 300, nTotalWorkDays + nHistoricalDays);

			// create a function calculator
			NFunctionCalculator fc = new NFunctionCalculator();
			fc.Arguments.Add(m_Stock.CloseValues);

			// calculate the bollinger bands
			fc.Expression = "BOLLINGER(close;" + period.ToString() + "; 2)";
			m_HighLow.HighValues = fc.Calculate();
			m_HighLow.HighValues.Name = "BollingerUpper";

			fc.Expression = "BOLLINGER(close; " + period.ToString() + "; -2)";
			m_HighLow.LowValues = fc.Calculate();
			m_HighLow.LowValues.Name = "BollingerLower";
			m_HighLow.XValues.InsertRange(0, m_Stock.XValues);

			// calculate the simple moving average
			fc.Expression = "SMA(close; " + period.ToString() + ")";
			m_LineSMA.Values = fc.Calculate();
			m_LineSMA.XValues.InsertRange(0, m_Stock.XValues);

			// remove first period from line SMA
			m_LineSMA.Values.RemoveRange(0, period);
			m_LineSMA.XValues.RemoveRange(0, period);

			// remove first period from high low
			m_HighLow.XValues.RemoveRange(0, period);
			m_HighLow.HighValues.RemoveRange(0, period);
			m_HighLow.LowValues.RemoveRange(0, period);

			// remove first period from stock
			m_Stock.OpenValues.RemoveRange(0, period);
			m_Stock.HighValues.RemoveRange(0, period);
			m_Stock.LowValues.RemoveRange(0, period);
			m_Stock.CloseValues.RemoveRange(0, period);
			m_Stock.XValues.RemoveRange(0, period);
		}

		private void GenerateData(NStockSeries s, double dPrevClose, int nCount)
		{
			DateTime now = DateTime.Now;
			NTimeline timeline = m_Calendar.CreateTimeline(new NDateTimeRange(now, now + new TimeSpan(730, 0, 0, 0, 0)));
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
				s.XValues.Add(now.ToOADate());

				// advance to next working day
				now = timeline.AddTimeSpan(now, new NDateTimeSpan(1, NDateTimeUnit.Day));
			}
		}

		private void MondayCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			CreateWorkCalendar();
		}

		private void TuesdayCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			CreateWorkCalendar();
		}

		private void WednesdayCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			CreateWorkCalendar();
		}

		private void ThursdayCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			CreateWorkCalendar();
		}

		private void FridayCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			CreateWorkCalendar();
		}

		private void SaturdayCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			CreateWorkCalendar();
		}

		private void SundayCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			CreateWorkCalendar();
		}

		private void EnableWeekRuleCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			CreateWorkCalendar();
			WorkingDaysGroupBox.Enabled = EnableWeekRuleCheckBox.Checked;
		}

		private void MonthDayUpDown_ValueChanged(object sender, EventArgs e)
		{
			CreateWorkCalendar();
		}

		private void EnableMonthDayRuleCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			CreateWorkCalendar();
			MonthDayUpDown.Enabled = EnableMonthDayRuleCheckBox.Checked;
			WorkRadioButton.Enabled = EnableMonthDayRuleCheckBox.Checked;
			RestRadioButton.Enabled = EnableMonthDayRuleCheckBox.Checked;
		}

		private void WorkRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			CreateWorkCalendar();
		}

		private void RestRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			CreateWorkCalendar();
		}

		private void ZoomToFirst7DaysButton_Click(object sender, EventArgs e)
		{
			DateTime dt = DateTime.FromOADate((double)m_Stock.XValues[0]);
			m_Chart.Axis(StandardAxis.PrimaryX).PagingView.ZoomIn(new NRange1DD(dt.ToOADate(), (dt + new TimeSpan(7, 0, 0, 0)).ToOADate()), 0.00001);
			nChartControl1.Refresh();
		}

		private void ZoomToFirst30DaysButton_Click(object sender, EventArgs e)
		{
			DateTime dt = DateTime.FromOADate((double)m_Stock.XValues[0]);
			m_Chart.Axis(StandardAxis.PrimaryX).PagingView.ZoomIn(new NRange1DD(dt.ToOADate(), (dt + new TimeSpan(30, 0, 0, 0)).ToOADate()), 0.00001);
			nChartControl1.Refresh();
		}
	}
}
