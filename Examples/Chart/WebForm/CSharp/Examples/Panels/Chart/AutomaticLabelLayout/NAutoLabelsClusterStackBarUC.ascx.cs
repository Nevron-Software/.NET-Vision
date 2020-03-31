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
	public partial class NAutoLabelsClusterStackBarUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				EnableInitialPositioningCheckBox.Checked = true;
				EnableLabelAdjustmentCheckBox.Checked = true;

				HiddenField1.Value = Random.Next().ToString();
			}

            nChartControl1.Settings.JitterMode = JitterMode.Enabled;
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Cluster Stack Bar Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);

			// configure the chart
			NChart chart = nChartControl1.Charts[0];

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

			NSizeL dataPointSafeguardSize = new NSizeL(
				new NLength(1.3f, NRelativeUnit.ParentPercentage),
				new NLength(1.3f, NRelativeUnit.ParentPercentage));

			// series 1
			NBarSeries series1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			series1.Name = "Bar 1";
			series1.FillStyle = new NColorFillStyle(DarkOrange);
			series1.DataLabelStyle.Visible = true;
			series1.DataLabelStyle.VertAlign = VertAlign.Center;
			series1.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(8);

			// series 2
			NBarSeries series2 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			series2.Name = "Bar 2";
			series2.MultiBarMode = MultiBarMode.Stacked;
			series2.FillStyle = new NColorFillStyle(Green);
			series2.DataLabelStyle.Visible = true;
			series2.DataLabelStyle.VertAlign = VertAlign.Center;
			series2.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(8);

			// series 3
			NBarSeries series3 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			series3.Name = "Bar 3";
			series3.MultiBarMode = MultiBarMode.Clustered;
			series3.FillStyle = new NColorFillStyle(Red);
			series3.DataLabelStyle.Visible = true;
			series3.DataLabelStyle.VertAlign = VertAlign.Top;
			series3.DataLabelStyle.ArrowLength = new NLength(10);
			series3.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(8);

			// generate random data
			GenerateData(chart);

			// enable initial labels positioning
			chart.LabelLayout.EnableInitialPositioning = EnableInitialPositioningCheckBox.Checked;

			// enable label adjustment
			chart.LabelLayout.EnableLabelAdjustment = EnableLabelAdjustmentCheckBox.Checked;

			// series 1 data points must not be overlapped
			series1.LabelLayout.EnableDataPointSafeguard = true;
			series1.LabelLayout.DataPointSafeguardSize = dataPointSafeguardSize;

			// do not use label location proposals for series 1
			series1.LabelLayout.UseLabelLocations = false;

			// series 2 data points must not be overlapped
			series2.LabelLayout.EnableDataPointSafeguard = true;
			series2.LabelLayout.DataPointSafeguardSize = dataPointSafeguardSize;

			// do not use label location proposals for series 2
			series2.LabelLayout.UseLabelLocations = false;

			// series 3 data points must not be overlapped
			series3.LabelLayout.EnableDataPointSafeguard = true;
			series3.LabelLayout.DataPointSafeguardSize = dataPointSafeguardSize;

			// series 3 data labels can be placed above and below the origin point
			series3.LabelLayout.UseLabelLocations = true;
			series3.LabelLayout.LabelLocations = new LabelLocation[] { LabelLocation.Top, LabelLocation.Bottom };
			series3.LabelLayout.InvertLocationsIfIgnored = false;
			series3.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds;

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);

		}

		void GenerateData(NChart chart)
		{
			int randSeed = int.Parse(HiddenField1.Value);
			Random rand = new Random(randSeed);

			int count = 7;

			((NSeries)chart.Series[0]).Values.FillRandomRange(rand, count, 5.0, 20.0);
			((NSeries)chart.Series[1]).Values.FillRandomRange(rand, count, 5.0, 20.0);
			((NSeries)chart.Series[2]).Values.FillRandomRange(rand, count, 10.0, 20.0);
		}


	}
}
