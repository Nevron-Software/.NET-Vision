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
    public partial class NFloatBarPaletteUC : NExampleUC
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

            // create the float bar series
            NFloatBarSeries floatBar = (NFloatBarSeries)chart.Series.Add(SeriesType.FloatBar);
            floatBar.DataLabelStyle.Visible = false;
            floatBar.DataLabelStyle.VertAlign = VertAlign.Center;
            floatBar.DataLabelStyle.Format = "<begin> - <end>";

            // add bars
            floatBar.AddDataPoint(new NFloatBarDataPoint(2, 10));
            floatBar.AddDataPoint(new NFloatBarDataPoint(5, 16));
            floatBar.AddDataPoint(new NFloatBarDataPoint(9, 17));
            floatBar.AddDataPoint(new NFloatBarDataPoint(12, 21));
            floatBar.AddDataPoint(new NFloatBarDataPoint(8, 18));
            floatBar.AddDataPoint(new NFloatBarDataPoint(7, 18));
            floatBar.AddDataPoint(new NFloatBarDataPoint(3, 11));
            floatBar.AddDataPoint(new NFloatBarDataPoint(5, 12));
            floatBar.AddDataPoint(new NFloatBarDataPoint(8, 17));
            floatBar.AddDataPoint(new NFloatBarDataPoint(6, 15));
            floatBar.AddDataPoint(new NFloatBarDataPoint(3, 10));
            floatBar.AddDataPoint(new NFloatBarDataPoint(1, 7));

            NPalette palette = new NPalette();
            palette.Clear();
            palette.Mode = PaletteMode.Custom;
            palette.Add(0, Color.Green);
            palette.Add(10, Color.Yellow);
            palette.Add(20, Color.Red);

            floatBar.Palette = palette;
            
            floatBar.Palette.SmoothPalette = SmoothPaletteCheckBox.Checked;

            // apply layout
            ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);
		}
	}
}
