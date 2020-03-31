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
	public partial class NAutoLabelsStepLineUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				EnableInitialPositioningCheckBox.Checked = true;
				EnableLabelAdjustmentCheckBox.Checked = true;
				InvertForDownwardDPCheckBox.Checked = true;
				InvertIfOutOfBoundsCheckBox.Checked = true;

				LocationProposalsDropDownList.Items.Clear();
				LocationProposalsDropDownList.Items.Add("Top");
				LocationProposalsDropDownList.Items.Add("Top - Bottom");
				LocationProposalsDropDownList.Items.Add("Top - Bottom - Left - Right");
				LocationProposalsDropDownList.SelectedIndex = 1;

				HiddenField1.Value = Random.Next().ToString();
			}

            nChartControl1.Settings.JitterMode = JitterMode.Enabled;
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Step Line Chart");
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

			// step line series
			NStepLineSeries series1 = (NStepLineSeries)chart.Series.Add(SeriesType.StepLine);
			series1.InflateMargins = true;
			series1.BorderStyle = new NStrokeStyle(new NLength(1.2f, NGraphicsUnit.Point), GreyBlue);

			series1.DataLabelStyle.Visible = true;
			series1.DataLabelStyle.VertAlign = VertAlign.Top;
			series1.DataLabelStyle.ArrowLength = new NLength(12);
			series1.DataLabelStyle.ArrowStrokeStyle.Color = DarkOrange;
			series1.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = DarkOrange;
			series1.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(8);

			// label layout settings
			chart.LabelLayout.EnableInitialPositioning = EnableInitialPositioningCheckBox.Checked;
			chart.LabelLayout.EnableLabelAdjustment = EnableLabelAdjustmentCheckBox.Checked;

			series1.LabelLayout.UseLabelLocations = true;
			series1.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds;
			series1.LabelLayout.InvertLocationsForInvertedDataPoints = InvertForDownwardDPCheckBox.Checked;
			series1.LabelLayout.InvertLocationsIfIgnored = InvertIfOutOfBoundsCheckBox.Checked;

			switch (LocationProposalsDropDownList.SelectedIndex)
			{
				case 0:
					series1.LabelLayout.LabelLocations = new LabelLocation[] { LabelLocation.Top };
					break;

				case 1:
					series1.LabelLayout.LabelLocations = new LabelLocation[] { LabelLocation.Top, LabelLocation.Bottom };
					break;

				case 2:
					series1.LabelLayout.LabelLocations = new LabelLocation[] { LabelLocation.Top, LabelLocation.Bottom, LabelLocation.Left, LabelLocation.Right };
					break;
			}

			series1.LabelLayout.EnableDataPointSafeguard = true;
			series1.LabelLayout.DataPointSafeguardSize = new NSizeL(
				new NLength(1.3f, NRelativeUnit.ParentPercentage),
				new NLength(1.3f, NRelativeUnit.ParentPercentage));

			// fill with random data 
			GenerateData(series1);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);

		}

		void GenerateData(NSeries series)
		{
			int randSeed = int.Parse(HiddenField1.Value);
			Random rand = new Random(randSeed);

			series.Values.Clear();

			for (int i = 0; i < 18; i++)
			{
				double value = Math.Sin(i * 0.2) * 10 + rand.NextDouble() * 2;
				series.Values.Add(value);
			}
		}

	}
}
