using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
    public partial class NTriangulatedHeatMapUC : NExampleUC
    {
		const int m_SizeX = 200;
		const int m_SizeY = 200;

        protected void Page_Load(object sender, EventArgs e)
        {
			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = new NLabel("Triangulated Heat Map");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			title.DockMode = PanelDockMode.Top;
			title.Margins = new NMarginsL(0, 5, 0, 0);
			nChartControl1.Panels.Add(title);

			NCartesianChart chart = new NCartesianChart();
			nChartControl1.Panels.Add(chart);

			chart.DockMode = PanelDockMode.Fill;
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Margins = new NMarginsL(5);

			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.RoundToTickMin = false;
			scaleX.RoundToTickMax = false;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.RoundToTickMin = false;
			scaleY.RoundToTickMax = false;
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

			// create a point series (used to show the incoming points XY values)
			NPointSeries point = new NPointSeries();
			chart.Series.Add(point);
			point.UseXValues = true;
			point.BorderStyle.Width = new NLength(0);
			point.FillStyle = new NColorFillStyle(Color.Black);
			point.Size = new NLength(2);
			point.DataLabelStyle.Visible = false;

			// create the heat map 
			NTriangulatedHeatMapSeries heatMap = new NTriangulatedHeatMapSeries();
			chart.Series.Add(heatMap);

			heatMap.Palette.Add(0.0, Color.Purple);
			heatMap.Palette.Add(1.5, Color.MediumSlateBlue);
			heatMap.Palette.Add(3.0, Color.CornflowerBlue);
			heatMap.Palette.Add(4.5, Color.LimeGreen);
			heatMap.Palette.Add(6.0, Color.LightGreen);
			heatMap.Palette.Add(7.5, Color.Yellow);
			heatMap.Palette.Add(9.0, Color.Orange);
			heatMap.Palette.Add(10.5, Color.Red);

			heatMap.ContourDisplayMode = ContourDisplayMode.Contour;
			heatMap.Legend.Mode = SeriesLegendMode.SeriesLogic;
			heatMap.Legend.Format = "<zone_value>";

			GenerateData(point, heatMap);
		}
		/// <summary>
		/// Generates random data
		/// </summary>
		/// <param name="pointSeries"></param>
		/// <param name="heatMapSeries"></param>
		private void GenerateData(NPointSeries pointSeries, NTriangulatedHeatMapSeries heatMapSeries)
		{
			NPointD[] points = new NPointD[] { new NPointD(0.1, 0.1), new NPointD(1.5, 1.0), new NPointD(2.5, 5), new NPointD(4, 0), new NPointD(2.5, 3.4), new NPointD(1.3, 5) };
			double[] pointsIntensity = new double[] { 30, 10, 30, 20, 40, 20 };

			Random rand = new Random();

			for (double x = 0.0; x <= 5; x += 0.5)
			{
				for (double y = 0.0; y <= 5; y += 0.5)
				{
					double pointX;
					double pointY;

					if (x == 0 || y == 0 || x == 5 || y == 5)
					{
						pointX = x;
						pointY = y;
					}
					else
					{
						pointX = x + rand.NextDouble() * 0.2;
						pointY = y + rand.NextDouble() * 0.2;
					}

					double intensity = 0;
					for (int i = 0; i < points.Length; i++)
					{
						double dx = points[i].X - pointX;
						double dy = points[i].Y - pointY;

						double distance = Math.Sqrt(dx * dx + dy * dy);
						intensity += pointsIntensity[i] / (1 + distance * distance);
					}

					heatMapSeries.Values.Add(intensity);
					heatMapSeries.XValues.Add(pointX);
					heatMapSeries.YValues.Add(pointY);
				}
			}

			pointSeries.Values.AddRange(heatMapSeries.YValues);
			pointSeries.XValues.AddRange(heatMapSeries.XValues);
		}
	}
}