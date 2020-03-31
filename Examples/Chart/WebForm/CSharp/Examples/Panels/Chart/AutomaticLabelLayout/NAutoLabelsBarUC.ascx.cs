using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NAutoLabelsBarUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				EnableInitialPositioningCheckBox.Checked = true;
				RemoveOverlappedLabelsCheckBox.Checked = false;
				EnableLabelAdjustmentCheckBox.Checked = true;
				LocationProposalsDropDownList.Items.Clear();
				LocationProposalsDropDownList.Items.Add("Top");
				LocationProposalsDropDownList.Items.Add("Top - Bottom");
				LocationProposalsDropDownList.SelectedIndex = 0;

				HiddenField1.Value = Random.Next().ToString();
			}

			nChartControl1.Settings.JitterMode = JitterMode.Enabled;
			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Bar Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);

			// configure the chart
			NChart chart = nChartControl1.Charts[0];

			// configure X axis
			NOrdinalScaleConfigurator scaleX = new NOrdinalScaleConfigurator();
			scaleX.DisplayDataPointsBetweenTicks = false;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// configure Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

			// add interlaced stripe for Y axis
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.StripStyles.Add(stripStyle);

			// bar series
			NBarSeries series1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			series1.FillStyle = new NColorFillStyle(DarkOrange);
			series1.DataLabelStyle.Visible = true;
			series1.DataLabelStyle.VertAlign = VertAlign.Top;
			series1.DataLabelStyle.ArrowLength = new NLength(10);
			series1.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(8);

			// enable / disable initial labels positioning
			chart.LabelLayout.EnableInitialPositioning = EnableInitialPositioningCheckBox.Checked;

			// enable / disable removal of overlapped labels after initial positioning
			chart.LabelLayout.RemoveOverlappedLabels = RemoveOverlappedLabelsCheckBox.Checked;

			// enable / disable label adjustment
			chart.LabelLayout.EnableLabelAdjustment = EnableLabelAdjustmentCheckBox.Checked;

			// use only "top" location for the labels
			series1.LabelLayout.UseLabelLocations = true;

			switch (LocationProposalsDropDownList.SelectedIndex)
			{
				case 0:
					series1.LabelLayout.LabelLocations = new LabelLocation[] { LabelLocation.Top };
					break;

				case 1:
					series1.LabelLayout.LabelLocations = new LabelLocation[] { LabelLocation.Top, LabelLocation.Bottom };
					break;
			}

			series1.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds;
			series1.LabelLayout.InvertLocationsIfIgnored = true;

			// protect data points from being overlapped
			series1.LabelLayout.EnableDataPointSafeguard = true;
			series1.LabelLayout.DataPointSafeguardSize = new NSizeL(
				new NLength(1.3f, NRelativeUnit.ParentPercentage),
				new NLength(1.3f, NRelativeUnit.ParentPercentage));

			// fill with random data
			GenerateData(series1);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);

		}

		private void GenerateData(NSeries series)
		{
			int randSeed = int.Parse(HiddenField1.Value);
			Random rand = new Random(randSeed);

			series.Values.Clear();

			for (int i = 0; i < 15; i++)
			{
				double value = Math.Sin(i * 0.4) * 10 + rand.NextDouble() * 4;
				series.Values.Add(value);
			}
		}
	}
}
