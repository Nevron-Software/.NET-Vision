using Nevron.Chart;
using Nevron.GraphicsCore;
using System;
using System.Drawing;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NRange2DUC : NExampleBaseUC
	{
		public NRange2DUC()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Gets the title of this example
		/// </summary>
		public override string Title
		{
			get
			{
				return "Range 2D";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a 2D Histogram implemented with the Range Series.\r\n" + 
						"The Range Series lets you easily define 2D data points by four values, forming two ranges: [Begin X - End X], [Begin Y - End Y].";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = new NLabel("2D Range Series");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			// setup X axis
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.InnerMajorTickStyle.Visible = false;

			// setup Y axis
			linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.InnerMajorTickStyle.Visible = false;

			// add interlaced stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			stripStyle.Interlaced = true;
			linearScale.StripStyles.Add(stripStyle);

			// setup shape series
			NRangeSeries rangeSeries = (NRangeSeries)chart.Series.Add(SeriesType.Range);
			rangeSeries.DataLabelStyle.Visible = false;
			rangeSeries.UseXValues = true;
			rangeSeries.FillStyle = new NColorFillStyle(DarkOrange);
			rangeSeries.BorderStyle.Color = Color.DarkRed;

			// fill data
			FillData(rangeSeries);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

		}

		private static void FillData(NRangeSeries rangeSeries)
		{
			double[] arrIntervals = new double[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 15, 30, 60 };
			double[] arrValues = new double[] { 4180, 13687, 18618, 19634, 17981, 7190, 16369, 3212, 4122, 9200, 6461, 3435 };

			int count = Math.Min(arrIntervals.Length, arrValues.Length);
			double x = 0;

			for (int i = 0; i < count; i++)
			{
				double dInterval = arrIntervals[i];
				double dValue = arrValues[i];

				rangeSeries.Values.Add(0);
				rangeSeries.XValues.Add(x);

				x += dInterval;

				rangeSeries.Y2Values.Add(dValue / dInterval);
				rangeSeries.X2Values.Add(x);
			}
		}

	}
}
