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
	public partial class NAreaPaletteUC : NExampleUC
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
            NLabel title = nChartControl1.Labels.AddHeader("Area Palette");
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

            // setup a bar series
            NAreaSeries area = new NAreaSeries();
            area.Name = "Area Series";
            area.InflateMargins = true;
            area.UseXValues = false;
            area.DataLabelStyle.Visible = false;

            NPalette palette = new NPalette();
            palette.Clear();
            palette.Add(0, Color.Green);
            palette.Add(60, Color.Yellow);
            palette.Add(120, Color.Red);

            area.Palette = palette;

            chart.Series.Add(area);

            int indicatorCount = 18;

            // add some data to the bar series
            float degree2Rad = (float)(Math.PI / 180);
            for (int i = 0; i <= indicatorCount; i++)
            {
                area.Values.Add(Math.Sin(degree2Rad * i * 10) * 150.0);
            }

            area.Palette.SmoothPalette = SmoothPaletteCheckBox.Checked;

            // apply layout
            ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);
		}
	}
}
