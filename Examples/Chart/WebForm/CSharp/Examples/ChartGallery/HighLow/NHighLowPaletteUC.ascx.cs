using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
    public partial class NHighLowPaletteUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
                SmoothPaletteCheckBox.Checked = true;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            nChartControl1.Legends[0].Visible = false;

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Float Bar Palette");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

            // configure the chart
            NChart chart = nChartControl1.Charts[0];
            chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHalf);
            chart.Axis(StandardAxis.Depth).Visible = false;

            // add interlace stripe
            NAxis yAxis = chart.Axis(StandardAxis.PrimaryY);
            NLinearScaleConfigurator linearScale = yAxis.ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle strip = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            strip.Interlaced = true;
            strip.SetShowAtWall(ChartWallType.Back, true);
            linearScale.StripStyles.Add(strip);

            // add a High-Low series
            NHighLowSeries highLow = (NHighLowSeries)chart.Series.Add(SeriesType.HighLow);
            highLow.Legend.Mode = SeriesLegendMode.None;
            highLow.DataLabelStyle.Visible = false;

            highLow.ClearDataPoints();

            for (int i = 0; i < 20; i++)
            {
                double d1 = Math.Log(i + 1) + 0.1 * Random.NextDouble();
                double d2 = d1 + Math.Cos(0.33 * i) + 0.1 * Random.NextDouble();

                highLow.HighValues.Add(d1);
                highLow.LowValues.Add(d2);
            }

            NPalette palette = new NPalette();
            palette.Clear();
            palette.Mode = PaletteMode.Custom;
            palette.Add(0, Color.Green);
            palette.Add(1.5, Color.Yellow);
            palette.Add(3, Color.Red);

            highLow.Palette = palette;

            highLow.Palette.SmoothPalette = SmoothPaletteCheckBox.Checked;

            // apply layout
            ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);
		}
	}
}
