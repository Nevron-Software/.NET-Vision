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
	public partial class NXYScatterPointUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XY Scatter Point Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			// setup Y axis
			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY.RoundToTickMin = AxesRoundToTickCheckBox.Checked;
			scaleY.RoundToTickMax = AxesRoundToTickCheckBox.Checked;
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// add interlace stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			scaleY.StripStyles.Add(stripStyle);

			// setup X axis
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.RoundToTickMin = AxesRoundToTickCheckBox.Checked;
			scaleX.RoundToTickMax = AxesRoundToTickCheckBox.Checked;
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Floor, ChartWallType.Back };
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// setup point series
			NPointSeries point = (NPointSeries)chart.Series.Add(SeriesType.Point);
			point.Name = "Point1";
			point.InflateMargins = InflateMarginsCheckBox.Checked;
			point.DataLabelStyle.Visible = false;
			point.FillStyle = new NColorFillStyle(Color.FromArgb(160, DarkOrange));
			point.BorderStyle.Width = new NLength(0);
			point.Size = new NLength(2, NRelativeUnit.ParentPercentage);
			point.PointShape = PointShape.Ellipse;

			// instruct the point series to use custom X values
			point.UseXValues = true;

			// generate some random X values
			GenerateXYData(point);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}

		private void GenerateXYData(NPointSeries series)
		{
			series.ClearDataPoints();

			for (int i = 0; i < 200; i++)
			{
				double u1 = Random.NextDouble();
				double u2 = Random.NextDouble();

				if (u1 == 0)
					u1 += 0.0001;

				if (u2 == 0)
					u2 += 0.0001;

				double z0 = Math.Sqrt(-2 * Math.Log(u1)) * Math.Cos(2 * Math.PI * u2);
				double z1 = Math.Sqrt(-2 * Math.Log(u1)) * Math.Sin(2 * Math.PI * u2);

				series.XValues.Add(z0);
				series.Values.Add(z1);
			}
		}
	}
}
