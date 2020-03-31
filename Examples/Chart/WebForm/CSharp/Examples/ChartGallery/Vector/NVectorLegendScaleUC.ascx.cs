using System;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Nevron.GraphicsCore;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NVectorLegendScaleUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = new NLabel("Vector Legend Scale");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Width = 55.0f;
			chart.Height = 55.0f;

			chart.Width = 55.0f;
			chart.Height = 55.0f;

			// setup X axis
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.RoundToTickMin = false;
			linearScale.RoundToTickMax = false;
			linearScale.MajorGridStyle.ShowAtWalls = new ChartWallType[] { };
			linearScale.InnerMajorTickStyle.Visible = false;

			// setup Y axis
			linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			linearScale.RoundToTickMin = false;
			linearScale.RoundToTickMax = false;
			linearScale.MajorGridStyle.ShowAtWalls = new ChartWallType[] { };
			linearScale.InnerMajorTickStyle.Visible = false;

			// setup shape series
			NVectorSeries vector = (NVectorSeries)chart.Series.Add(SeriesType.Vector);
			vector.FillStyle = new NColorFillStyle(Color.Red);
			vector.BorderStyle.Color = Color.DarkRed;
			vector.DataLabelStyle.Visible = false;
			vector.InflateMargins = true;
			vector.UseXValues = true;
			vector.MinArrowHeadSize = new NSizeL(2, 3);
			vector.MaxArrowHeadSize = new NSizeL(4, 6);
			vector.MinVectorLength = new NLength(8);
			vector.MaxVectorLength = new NLength(30);
			vector.Mode = VectorSeriesMode.Direction;
			vector.Legend.Mode = SeriesLegendMode.SeriesLogic;

			// fill data
			FillData(vector);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);
		}

		private void FillData(NVectorSeries vectorSeries)
		{
			double x = 0, y = 0;
			int k = 0;

			for (int i = 0; i < 10; i++)
			{
				x = 1;
				y += 1;

				for (int j = 0; j < 10; j++)
				{
					x += 1;

					double dx = Math.Sin(x / 3.0) * Math.Cos((x - y) / 4.0);
					double dy = Math.Cos(y / 8.0) * Math.Cos(y / 4.0);

					vectorSeries.XValues.Add(x);
					vectorSeries.Values.Add(y);
					vectorSeries.X2Values.Add(dx);
					vectorSeries.Y2Values.Add(dy);

					vectorSeries.ZValues.Add(y);
					vectorSeries.Z2Values.Add(dy);

					vectorSeries.BorderStyles[k] = new NStrokeStyle(1, ColorFromVector(dx, dy));
					k++;
				}
			}
		}

		private Color ColorFromVector(double dx, double dy)
		{
			double length = Math.Sqrt(dx * dx + dy * dy);

			double sq2 = Math.Sqrt(2);

			int r = (int)((255 / sq2) * length);
			int g = 20;
			int b = (int)((255 / sq2) * (sq2 - length));

			return Color.FromArgb(r, g, b);
		}

	}
}