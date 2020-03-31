using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
    public partial class NHeatMapContourLabelsUC : NExampleUC
    {
		const int m_SizeX = 200;
		const int m_SizeY = 200;

        protected void Page_Load(object sender, EventArgs e)
        {
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

			NCartesianChart chart = new NCartesianChart();
			nChartControl1.Panels.Add(chart);

			chart.DockMode = PanelDockMode.Fill;
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Margins = new NMarginsL(5);

            // create the heat map 
            NHeatMapSeries heatMap = new NHeatMapSeries();
            chart.Series.Add(heatMap);

            heatMap.Palette.Add(0.0, Color.Purple);
            heatMap.Palette.Add(1.5, Color.MediumSlateBlue);
            heatMap.Palette.Add(3.0, Color.CornflowerBlue);
            heatMap.Palette.Add(4.5, Color.LimeGreen);
            heatMap.Palette.Add(6.0, Color.LightGreen);
            heatMap.Palette.Add(7.5, Color.Yellow);
            heatMap.Palette.Add(9.0, Color.Orange);
            heatMap.Palette.Add(10.5, Color.Red);
            heatMap.XValuesMode = HeatMapValuesMode.OriginAndStep;
            heatMap.YValuesMode = HeatMapValuesMode.OriginAndStep;

            heatMap.ContourDisplayMode = ContourDisplayMode.Contour;
            heatMap.Legend.Mode = SeriesLegendMode.SeriesLogic;
            heatMap.Legend.Format = "<zone_value>";

            GenerateData(heatMap);

			// update chart control from form controls
			heatMap.ContourLabelStyle.Visible = ShowContourLabelsCheckBox.Checked;
			heatMap.ContourLabelStyle.AllowLabelToFlip = AllowLabelsToFlipCheckBox.Checked;
			heatMap.ContourLabelStyle.TextStyle.BackplaneStyle.Visible = ShowLabelBackgroundCheckBox.Checked;
			heatMap.ContourLabelStyle.ClipContour = ClipContourCheckBox.Checked;
		}

        private void GenerateData(NHeatMapSeries heatMap)
        {
            NHeatMapData data = heatMap.Data;

            int GridStepX = 300;
            int GridStepY = 300;
            data.SetGridSize(GridStepX, GridStepY);

            const double dIntervalX = 10.0;
            const double dIntervalZ = 10.0;
            double dIncrementX = (dIntervalX / GridStepX);
            double dIncrementZ = (dIntervalZ / GridStepY);

            double y, x, z;

            z = -(dIntervalZ / 2);

            for (int col = 0; col < GridStepX; col++, z += dIncrementZ)
            {
                x = -(dIntervalX / 2);

                for (int row = 0; row < GridStepY; row++, x += dIncrementX)
                {
                    y = 10 - Math.Sqrt((x * x) + (z * z) + 2);
                    y += 3.0 * Math.Sin(x) * Math.Cos(z);

                    double value = y;

                    data.SetValue(row, col, value);
                }
            }
        }
    }
}