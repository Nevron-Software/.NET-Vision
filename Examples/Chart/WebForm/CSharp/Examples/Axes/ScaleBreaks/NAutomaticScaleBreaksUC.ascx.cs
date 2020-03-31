using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Nevron.Chart;
using Nevron.Chart.WebForm;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm 
{
	public partial class NAutomaticScaleBreaksUC : NExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddHeader("Automatic Scale Breaks<br/> <font size = '9pt'>Demonstrates how to apply automatic scale breaks to the chart axes</font>");
			header.TextStyle.TextFormat = TextFormat.XML;
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left;
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			// turn off the legend
			NLegend legend = nChartControl1.Legends[0];
			legend.Mode = LegendMode.Disabled;

			NChart chart = nChartControl1.Charts[0];
            chart.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(19, NRelativeUnit.ParentPercentage));
            chart.Size = new NSizeL(new NLength(96, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
            chart.BoundsMode = BoundsMode.Stretch;

			// configure scale
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.RoundToTickMax = true;
			linearScale.RoundToTickMin = true;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MinTickDistance = new NLength(15);

			// add an interlaced strip to the Y axis
			NScaleStripStyle interlacedStrip = new NScaleStripStyle();
			interlacedStrip.SetShowAtWall(ChartWallType.Back, true);
			interlacedStrip.Interlaced = true;
			interlacedStrip.FillStyle = new NColorFillStyle(Color.Beige);
			linearScale.StripStyles.Add(interlacedStrip);

			// update form controls
			if (!IsPostBack)
			{
				enableBreaksCheckBox.Checked = true;

				positionModeDropDownList.Items.Add("Range");
				positionModeDropDownList.Items.Add("Percent");
				positionModeDropDownList.Items.Add("Content");
				positionModeDropDownList.SelectedIndex = 2; // use content mode by default
			}

			// feed some random data
			FeedRandomData();
			UpdateScaleBreaks();
		}

		protected void enableBreaksCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateScaleBreaks();
		}


		protected void FeedRandomData()
		{
			NChart chart = nChartControl1.Charts[0];

			chart.Series.Clear();

			// setup bar series
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.DataLabelStyle.Visible = false;
			bar.BorderStyle.Width = new NLength(1.5f);
			bar.BorderStyle.Color = Color.DarkGreen;

			// fill in some data so that it contains several peaks of data
			Random random = new Random();
			double value = 0;

			for (int i = 0; i < 25; i++)
			{
				if (i < 6)
				{
					value = random.Next(30);
				}
				else if (i < 11)
				{
					value = 200 + random.Next(50);
				}
				else if (i < 16)
				{
					value = 400 + random.Next(50);
				}
				else if (i < 21)
				{
					value = random.Next(30);
				}
				else
				{
					value = 600 + random.Next(50);
				}

				bar.Values.Add(value);
				bar.FillStyles[i] = new NGradientFillStyle(ColorFromValue(value), Color.DarkSlateBlue);
			}
		}

		protected void UpdateScaleBreaks()
		{
			// read the form control values
			float threshold;
			if (!float.TryParse(thresholdTextBox.Text, out threshold) || threshold < 0 || threshold > 1)
			{
				threshold = 0.25f;
				thresholdTextBox.Text = threshold.ToString();
			}

			int maxBreaks;
			if (!int.TryParse(maxBreaksTextBox.Text, out maxBreaks) || maxBreaks < 0 || maxBreaks > 3)
			{
				maxBreaks = 1;
				maxBreaksTextBox.Text = maxBreaks.ToString();
			}

			float length;
			if (!float.TryParse(lengthTextBox.Text, out length) || length < 0 || length > 1000)
			{
				length = 5;
				lengthTextBox.Text = length.ToString();
			}

			int positionPercent;
			if (!int.TryParse(positionPercentTextBox.Text, out positionPercent) || positionPercent < 0 || positionPercent > 1000)
			{
				positionPercent = 50;
				positionPercentTextBox.Text = positionPercent.ToString();
			}

			// recreate scale breaks
			NChart chart = nChartControl1.Charts[0];
			NStandardScaleConfigurator scale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NStandardScaleConfigurator;
			scale.ScaleBreaks.Clear();

			if (enableBreaksCheckBox.Checked)
			{
				NAutoScaleBreak scaleBreak = new NAutoScaleBreak(threshold);
				scaleBreak.Style = new NWaveScaleBreakStyle();
				scaleBreak.Style.Length = new NLength(length, NGraphicsUnit.Point);
				scaleBreak.MaxScaleBreakCount = maxBreaks;

				NScaleBreakPosition scaleBreakPosition = new NRangeScaleBreakPosition();
				switch (positionModeDropDownList.SelectedIndex)
				{
					case 0: // Range
						scaleBreakPosition = new NRangeScaleBreakPosition();
						break;
					case 1: // percent
						scaleBreakPosition = new NPercentScaleBreakPosition((float)positionPercent);
						break;
					case 2: // content
						scaleBreakPosition = new NContentScaleBreakPosition();
						break;
				}

				scaleBreak.Position = scaleBreakPosition;

				scale.ScaleBreaks.Add(scaleBreak);
			}
		}

		protected Color ColorFromValue(double value)
		{
			Color beginColor = Color.LightBlue;
			Color endColor = Color.DarkSlateBlue;

			float factor = (float)(value / 650.0f);
			float oneMinusFactor = 1.0f - factor;

			return Color.FromArgb((byte)((float)beginColor.R * factor + (float)endColor.R * oneMinusFactor),
									(byte)((float)beginColor.G * factor + (float)endColor.G * oneMinusFactor),
									(byte)((float)beginColor.B * factor + (float)endColor.B * oneMinusFactor));
		}
	}
}
