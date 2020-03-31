using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
    public partial class NHeatMapContourUC : NExampleUC
    {
		const int m_SizeX = 200;
		const int m_SizeY = 200;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WebExamplesUtilities.FillComboWithEnumNames(ContourDisplayModeDropDownList, typeof(ContourDisplayMode));
                WebExamplesUtilities.FillComboWithEnumNames(ContourColorModeDropDownList, typeof(ContourColorMode));

                ShowFillCheckBox.Checked = true;
                SmoothPaletteCheckBox.Checked = true;
                ContourDisplayModeDropDownList.SelectedIndex = (int)ContourDisplayMode.Contour;
            }

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
            nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = new NLabel("Heat Map - Contour");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			title.DockMode = PanelDockMode.Top;
			title.Margins = new NMarginsL(0, 5, 0, 0);
			nChartControl1.Panels.Add(title);

			NLegend legend = new NLegend();
			legend.DockMode = PanelDockMode.Right;
			legend.Margins = new NMarginsL(0, 5, 5, 0);
			legend.FitAlignment = ContentAlignment.TopCenter;
			nChartControl1.Panels.Add(legend);

			NCartesianChart chart = new NCartesianChart();
			nChartControl1.Panels.Add(chart);

			chart.DisplayOnLegend = legend;
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

			// create the heat map 
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

			heatMap.ContourDisplayMode = ContourDisplayMode.Contour;
            heatMap.Legend.Mode = SeriesLegendMode.SeriesLogic;
            heatMap.Legend.Format = "<zone_value>";

            GenerateData(heatMap);

            // update chart control from form controls
            heatMap.ContourDisplayMode = (ContourDisplayMode)ContourDisplayModeDropDownList.SelectedIndex;
            heatMap.ContourColorMode = (ContourColorMode)ContourColorModeDropDownList.SelectedIndex;
            heatMap.ShowFill = ShowFillCheckBox.Checked;
            heatMap.Palette.SmoothPalette = SmoothPaletteCheckBox.Checked;

            if (heatMap.Palette.SmoothPalette)
            {
                heatMap.Legend.Format = "<zone_value>";
            }
            else
            {
                heatMap.Legend.Format = "<zone_begin> - <zone_end>";
            }
		}


		private void GenerateData(NTriangulatedHeatMapSeries heatMap)
		{
			NPointD[] points = new NPointD[] { new NPointD(3.1, 0.1), new NPointD(1.5, 2.0), new NPointD(1.5, 0.5), new NPointD(2, 0), new NPointD(1.5, 3.4), new NPointD(1.3, 3) };
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

					heatMap.Values.Add(intensity);
					heatMap.XValues.Add(pointX);
					heatMap.YValues.Add(pointY);
				}
			}
		}
	}
}