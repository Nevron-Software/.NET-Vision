using Nevron.Chart;
using Nevron.GraphicsCore;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NTimeSpanScaleUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddHeader("Date Time Scale");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

            // add a strip line style
            NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
            NScaleStripStyle stripStyle = new NScaleStripStyle();
            stripStyle.FillStyle = new NColorFillStyle(Color.Beige);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            linearScale.StripStyles.Add(stripStyle);
            chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;

			// create line serie and dispay them on vertical axis
			NLineSeries line = new NLineSeries();
			chart.Series.Add(line);

			line.UseXValues = true;
			line.Name = "Line";
			line.DataLabelStyle.Visible = false;
			line.InflateMargins = true;

			NTimeSpanScaleConfigurator timeSpanScale = new NTimeSpanScaleConfigurator();
			timeSpanScale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.View, 90);
			timeSpanScale.LabelStyle.ContentAlignment = ContentAlignment.MiddleLeft; 
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = timeSpanScale;

			chart.BoundsMode = BoundsMode.Stretch;
			chart.Location = new NPointL(
				new NLength(5, NRelativeUnit.ParentPercentage),
				new NLength(15, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(85, NRelativeUnit.ParentPercentage),
				new NLength(80, NRelativeUnit.ParentPercentage));

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);
			
			if(!IsPostBack)
			{
				SampleTimeRangeDropDownList.Items.Add("Milliseconds");
				SampleTimeRangeDropDownList.Items.Add("Seconds");
				SampleTimeRangeDropDownList.Items.Add("Minutes");
				SampleTimeRangeDropDownList.Items.Add("Hours");
				SampleTimeRangeDropDownList.Items.Add("Days");
				SampleTimeRangeDropDownList.Items.Add("Weeks");
				SampleTimeRangeDropDownList.SelectedIndex = 2; // minutes
				EnableUnitSensitiveFormattingCheckBox.Checked = true;
			}

			UpdateTimeSpanScale(timeSpanScale);
			FillDummyData(line);
		}

		private void UpdateTimeSpanScale(NTimeSpanScaleConfigurator timeSpanScale)
		{
			List<NTimeUnit> timeUnits = new List<NTimeUnit>();

			if (MillisecondCheckBox.Checked)
			{
				timeUnits.Add(NTimeUnit.Millisecond);
			}

			if (SecondCheckBox.Checked)
			{
				timeUnits.Add(NTimeUnit.Second);
			}

			if (MinuteCheckBox.Checked)
			{
				timeUnits.Add(NTimeUnit.Minute);
			}

			if (HourCheckBox.Checked)
			{
				timeUnits.Add(NTimeUnit.Hour);
			}

			if (DayCheckBox.Checked)
			{
				timeUnits.Add(NTimeUnit.Day);
			}

			if (WeekCheckBox.Checked)
			{
				timeUnits.Add(NTimeUnit.Week);
			}

			timeSpanScale.EnableUnitSensitiveFormatting = EnableUnitSensitiveFormattingCheckBox.Checked;
			timeSpanScale.AutoDateTimeUnits = timeUnits.ToArray();
		}


		private void FillDummyData(NLineSeries line)
		{
			NTimeUnit timeUnit;

			switch (SampleTimeRangeDropDownList.SelectedIndex)
			{
				case 0:// Milliseconds
					timeUnit = NTimeUnit.Millisecond;
					break;
				case 1:// Seconds
					timeUnit = NTimeUnit.Second;
					break;
				case 2:// Minutes
					timeUnit = NTimeUnit.Minute;
					break;
				case 3:// Hours
					timeUnit = NTimeUnit.Hour;
					break;
				case 4:// Days
					timeUnit = NTimeUnit.Day;
					break;
				case 5:// Weeks
					timeUnit = NTimeUnit.Week;
					break;
				default:
					timeUnit = NTimeUnit.Day;
					break;
			}

			Random random = new Random();

			int spanCount = 50 + random.Next(200);
			TimeSpan begin = new TimeSpan(0);
			TimeSpan end = timeUnit.Add(begin, spanCount);

			TimeSpan current = begin;

			while (current <= end)
			{
				line.Values.Add(random.Next(100) + 30);
				line.XValues.Add(current);
				current = timeUnit.Add(current, 1);
			}
		}
	}
}
