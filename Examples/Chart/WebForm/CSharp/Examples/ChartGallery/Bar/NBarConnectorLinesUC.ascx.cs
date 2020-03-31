using Nevron.Chart;
using Nevron.GraphicsCore;
using System;
using System.Drawing;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NBarConnectorLinesUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Bar Connector Lines");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

            // configure chart
            NChart chart = (NCartesianChart)nChartControl1.Charts[0];
            chart.Axis(StandardAxis.Depth).Visible = false;
            chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

            // add interlace stripe
            NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

            // add bar and change bar color
			NBarSeries barSeries = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            barSeries.Name = "Bar Series";
			barSeries.DataLabelStyle.Visible = false;

			// add some data to the bar series
			barSeries.Values.Add(18);
			barSeries.Values.Add(15);
			barSeries.Values.Add(21);
			barSeries.Values.Add(23);
			barSeries.Values.Add(28);
			barSeries.Values.Add(29);

			barSeries.ShowConnectorLines = ShowConnectorLinesCheckBox.Checked;

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);
		}
	}
}
