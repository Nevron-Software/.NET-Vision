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
	public partial class NAutoLabelsRadarUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				EnableInitialPositioningCheckBox.Checked = true;
				EnableLabelAdjustmentCheckBox.Checked = true;
				StackRadarAreasCheckBox.Checked = false;

				HiddenField1.Value = Random.Next().ToString();
			}

            nChartControl1.Settings.JitterMode = JitterMode.Enabled;
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Radar Area Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomRight;
			title.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// configure the chart
			NRadarChart chart = new NRadarChart();
			chart.Location = new NPointL(new NLength(5, NRelativeUnit.ParentPercentage), new NLength(5, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(new NLength(90, NRelativeUnit.ParentPercentage), new NLength(90, NRelativeUnit.ParentPercentage));
			nChartControl1.Charts.Add(chart);

			AddRadarAxis(chart, "Category A");
			AddRadarAxis(chart, "Category B");
			AddRadarAxis(chart, "Category C");
			AddRadarAxis(chart, "Category D");
			AddRadarAxis(chart, "Category E");
			AddRadarAxis(chart, "Category F");
			AddRadarAxis(chart, "Category G");

			// radar area series 1
			NRadarAreaSeries series1 = (NRadarAreaSeries)chart.Series.Add(SeriesType.RadarArea);
			series1.FillStyle = new NColorFillStyle(DarkOrange);
			series1.BorderStyle.Color = DarkOrange;
			series1.DataLabelStyle.Visible = true;
			series1.DataLabelStyle.VertAlign = VertAlign.Top;
			series1.DataLabelStyle.ArrowStrokeStyle.Color = DarkOrange;
			series1.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = DarkOrange;
			series1.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(8);

			// radar area series 2
			NRadarAreaSeries series2 = (NRadarAreaSeries)chart.Series.Add(SeriesType.RadarArea);
			series2.FillStyle = new NColorFillStyle(Red);
			series2.BorderStyle.Color = Red;
			series2.BorderStyle.Width = new NLength(0);
			series2.DataLabelStyle.Visible = true;
			series2.DataLabelStyle.VertAlign = VertAlign.Top;
			series2.DataLabelStyle.ArrowStrokeStyle.Color = Red;
			series2.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = Red;
			series2.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(8);

			// stack / unstack the second radar area series
			if (StackRadarAreasCheckBox.Checked)
			{
				series2.MultiAreaMode = MultiAreaMode.Stacked;
			}
			else
			{
				series2.MultiAreaMode = MultiAreaMode.Series;
			}

			// label layout settings
			chart.LabelLayout.EnableInitialPositioning = EnableInitialPositioningCheckBox.Checked;
			chart.LabelLayout.EnableLabelAdjustment = EnableLabelAdjustmentCheckBox.Checked;

			NSizeL safeguardSize = new NSizeL(
				new NLength(1.3f, NRelativeUnit.ParentPercentage),
				new NLength(1.3f, NRelativeUnit.ParentPercentage));

			series1.LabelLayout.EnableDataPointSafeguard = true;
			series1.LabelLayout.UseLabelLocations = true;
			series1.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds;
			series1.LabelLayout.InvertLocationsIfIgnored = false;
			series1.LabelLayout.DataPointSafeguardSize = safeguardSize;

			series2.LabelLayout.EnableDataPointSafeguard = true;
			series2.LabelLayout.UseLabelLocations = true;
			series2.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds;
			series2.LabelLayout.InvertLocationsIfIgnored = false;
			series2.LabelLayout.DataPointSafeguardSize = safeguardSize;

			// fill with random data
			GenerateData(series1, series2);
		}

		private void AddRadarAxis(NRadarChart chart, string title)
		{
			NRadarAxis axis = new NRadarAxis();

			// set title
			axis.Title = title;

			// the axis scale should start from 0
			axis.View = new NRangeAxisView(new NRange1DD(0, 0), true, false);

			// setup scale
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)axis.ScaleConfigurator;
			linearScale.RulerStyle.BorderStyle.Color = Color.Silver;
			linearScale.InnerMajorTickStyle.LineStyle.Color = Color.Silver;
			linearScale.OuterMajorTickStyle.LineStyle.Color = Color.Silver;
			linearScale.InnerMajorTickStyle.Length = new NLength(2, NGraphicsUnit.Point);
			linearScale.OuterMajorTickStyle.Length = new NLength(2, NGraphicsUnit.Point);

			if (chart.Axes.Count == 0)
			{
				// if the first axis then configure grid style and stripes
				linearScale.MajorGridStyle.LineStyle.Color = Color.Gainsboro;
				linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
				linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Radar, true);

				// add interlaced stripe
				NScaleStripStyle strip = new NScaleStripStyle();
				strip.FillStyle = new NColorFillStyle(Color.FromArgb(64, 200, 200, 200));
				strip.Interlaced = true;
				strip.SetShowAtWall(ChartWallType.Radar, true);
				linearScale.StripStyles.Add(strip);
			}
			else
			{
				// hide labels
				linearScale.AutoLabels = false;
			}

			chart.Axes.Add(axis);
		}

		private void GenerateData(NSeries series0, NSeries series1)
		{
			int randSeed = int.Parse(HiddenField1.Value);
			Random rand = new Random(randSeed);

			series0.Values.FillRandomRange(rand, 7, 30.0, 80.0);
			series1.Values.FillRandomRange(rand, 7, 20.0, 60.0);
		}

	}
}
