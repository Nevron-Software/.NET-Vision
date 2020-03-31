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
	public partial class NAutoLabelsStackLineUC : NExampleUC
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
			NLabel title = nChartControl1.Labels.AddHeader("Stack Line Chart");
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

			// line series 1
			NLineSeries series1 = (NLineSeries)chart.Series.Add(SeriesType.Line);
			series1.Name = "Line 1";
			series1.InflateMargins = true;
			series1.MarkerStyle.Visible = true;
			series1.MarkerStyle.FillStyle = new NColorFillStyle(DarkOrange);
			series1.MarkerStyle.PointShape = PointShape.Ellipse;
			series1.MarkerStyle.Width = new NLength(1.0f, NRelativeUnit.ParentPercentage);
			series1.MarkerStyle.Height = new NLength(1.0f, NRelativeUnit.ParentPercentage);
			series1.DataLabelStyle.Visible = true;
			series1.DataLabelStyle.VertAlign = VertAlign.Top;
			series1.DataLabelStyle.ArrowLength = new NLength(10);
			series1.DataLabelStyle.ArrowStrokeStyle.Color = DarkOrange;
			series1.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = DarkOrange;
			series1.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(8);

			// line series 2
			NLineSeries series2 = (NLineSeries)chart.Series.Add(SeriesType.Line);
			series2.Name = "Line 2";
			series2.InflateMargins = true;
			series2.MultiLineMode = MultiLineMode.Stacked;
			series2.MarkerStyle.Visible = true;
			series2.MarkerStyle.FillStyle = new NColorFillStyle(Green);
			series2.MarkerStyle.PointShape = PointShape.Pyramid;
			series2.MarkerStyle.Width = new NLength(1.0f, NRelativeUnit.ParentPercentage);
			series2.MarkerStyle.Height = new NLength(1.0f, NRelativeUnit.ParentPercentage);
			series2.DataLabelStyle.Visible = true;
			series2.DataLabelStyle.VertAlign = VertAlign.Top;
			series2.DataLabelStyle.ArrowLength = new NLength(10);
			series2.DataLabelStyle.ArrowStrokeStyle.Color = Green;
			series2.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = Green;
			series2.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(8);

			// label layout settings
			chart.LabelLayout.EnableInitialPositioning = EnableInitialPositioningCheckBox.Checked;
			chart.LabelLayout.EnableLabelAdjustment = EnableLabelAdjustmentCheckBox.Checked;

			NSizeL safeguardSize = new NSizeL(
				new NLength(1.6f, NRelativeUnit.ParentPercentage),
				new NLength(1.6f, NRelativeUnit.ParentPercentage));

			series1.LabelLayout.UseLabelLocations = true;
			series1.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds;
			series1.LabelLayout.InvertLocationsIfIgnored = true;
			series1.LabelLayout.EnableDataPointSafeguard = true;
			series1.LabelLayout.DataPointSafeguardSize = safeguardSize;

			series2.LabelLayout.UseLabelLocations = true;
			series2.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds;
			series2.LabelLayout.InvertLocationsIfIgnored = true;
			series2.LabelLayout.EnableDataPointSafeguard = true;
			series2.LabelLayout.DataPointSafeguardSize = safeguardSize;

			// fill with random data
			GenerateData(chart);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}

		private void GenerateData(NChart chart)
		{
			int randSeed = int.Parse(HiddenField1.Value);
			Random rand = new Random(randSeed);

			NSeries series0 = (NSeries)chart.Series[0];
			NSeries series1 = (NSeries)chart.Series[1];

			series0.Values.Clear();
			series1.Values.Clear();

			for (int i = 0; i < 16; i++)
			{
				double value = 10 + Math.Sin(i * 0.2) * 10 + rand.NextDouble() * 5;
				series0.Values.Add(value);

				value = 10 + Math.Cos(i * 0.4) * 10 + rand.NextDouble() * 5;
				series1.Values.Add(value);
			}
		}

	}
}
