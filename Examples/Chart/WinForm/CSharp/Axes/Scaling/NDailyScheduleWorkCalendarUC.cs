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
	public class NDailyScheduleWorkCalendarUC : NExampleBaseUC
	{
		public NDailyScheduleWorkCalendarUC()
		{
			InitializeComponent();
		}

        private UI.WinForm.Controls.NCheckBox EnableWorkCalendar;

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
            this.EnableWorkCalendar = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.SuspendLayout();
            // 
            // EnableWorkCalendar
            // 
            this.EnableWorkCalendar.ButtonProperties.BorderOffset = 2;
            this.EnableWorkCalendar.Location = new System.Drawing.Point(14, 17);
            this.EnableWorkCalendar.Name = "EnableWorkCalendar";
            this.EnableWorkCalendar.Size = new System.Drawing.Size(200, 24);
            this.EnableWorkCalendar.TabIndex = 2;
            this.EnableWorkCalendar.Text = "Enable Work Calendar";
            this.EnableWorkCalendar.CheckedChanged += new System.EventHandler(this.EnableWorkCalendar_CheckedChanged);
            // 
            // NDailyScheduleWorkCalendarUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EnableWorkCalendar);
            this.Name = "NDailyScheduleWorkCalendarUC";
            this.Size = new System.Drawing.Size(231, 457);
            this.ResumeLayout(false);

		}

		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = new NLabel("Daily Workload in Percents<br/><font size = '9pt'>Demonstrates how to skip hours in the working days, per day using the daily schedule object</font>");
			title.TextStyle.TextFormat = TextFormat.XML;
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			nChartControl1.Panels.Add(title);

            NCartesianChart chart = (NCartesianChart)nChartControl1.Charts[0];
            chart.BoundsMode = BoundsMode.Stretch;

            NRangeSelection rangeSelection = new NRangeSelection();
            rangeSelection.VerticalValueSnapper = new NAxisRulerMinMaxSnapper();
            chart.RangeSelections.Add(rangeSelection);
            chart.BoundsMode = BoundsMode.Stretch;

            NRangeSeries ranges = new NRangeSeries();
            ranges.DataLabelStyle.Visible = false;
            ranges.UseXValues = true;

            DateTime dt = new DateTime(2014, 4, 14);
            Random rand = new Random();

            NRangeTimelineScaleConfigurator rangeTimeline = new NRangeTimelineScaleConfigurator();
            rangeTimeline.EnableCalendar = true;
            chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = rangeTimeline;
            chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = true;

            chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.Title.Text = "Daily Workload in %";
            chart.Axis(StandardAxis.PrimaryY).View = new NRangeAxisView(new NRange1DD(0, 100), true, true);

            NWorkCalendar workCalendar = rangeTimeline.Calendar;
            NDateTimeRangeRule dateTimeRangeRule = null;

            for (int i = 0; i < 120; i++)
            {
                int hourOfTheDay = i % 24;
                if (hourOfTheDay < 8 || hourOfTheDay > 18)
                {
                    DateTime curDate = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);

                    if (dateTimeRangeRule != null)
                    {
                        if (dateTimeRangeRule.Range.Begin != curDate)
                        {
                            dateTimeRangeRule = null;
                        }
                    }

                    if (dateTimeRangeRule == null)
                    {
                        dateTimeRangeRule = new NDateTimeRangeRule(new NDateTimeRange(curDate, curDate + new TimeSpan(24, 0, 0)), true);
                        workCalendar.Rules.Add(dateTimeRangeRule);
                    }

                    dateTimeRangeRule.Schedule.SetHourRange(dt.Hour, dt.Hour + 1, true);
                }
                else
                {
                    ranges.Values.Add(0);
                    ranges.Y2Values.Add(rand.NextDouble() * 70 + 30.0d);
                    ranges.XValues.Add((dt + new TimeSpan(1, 0, 0)).ToOADate());
                    ranges.X2Values.Add(dt.ToOADate());
                }

                dt += new TimeSpan(1, 0, 0);
            }

            chart.Series.Add(ranges);

            // apply layout
            ConfigureStandardLayout(chart, title, null);

            nChartControl1.Controller.Tools.Add(new NSelectorTool());
            nChartControl1.Controller.Tools.Add(new NAxisScrollTool());
            nChartControl1.Controller.Tools.Add(new NDataZoomTool());
            nChartControl1.Controller.Tools.Add(new NDataPanTool());

            // init form controls
            EnableWorkCalendar.Checked = true;
		}

        private void EnableWorkCalendar_CheckedChanged(object sender, EventArgs e)
        {
            NRangeTimelineScaleConfigurator scaleX = nChartControl1.Charts[0].Axis(StandardAxis.PrimaryX).ScaleConfigurator as NRangeTimelineScaleConfigurator;

            if (scaleX != null)
            {
                scaleX.EnableCalendar = EnableWorkCalendar.Checked;
                nChartControl1.Refresh();
            }
        }
	}
}
