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
	public partial class NBarPaletteUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
                WebExamplesUtilities.FillComboWithEnumNames(PaletteModeDropDownList, typeof(PaletteColorMode));
                PaletteModeDropDownList.SelectedIndex = (int)PaletteColorMode.Spread;
                SmoothPaletteCheckBox.Checked = true;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            nChartControl1.Legends[0].Visible = false;

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Bar Palette");
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
            NBarSeries bar = new NBarSeries();
            bar.Name = "Bar Series";
            bar.InflateMargins = true;
            bar.UseXValues = false;
            bar.DataLabelStyle.Visible = false;

            NPalette palette = new NPalette();
            palette.Clear();
            palette.Add(0, Color.Green);
            palette.Add(60, Color.Yellow);
            palette.Add(120, Color.Red);

            bar.Palette = palette;

            chart.Series.Add(bar);

            int indicatorCount = 10;

            // add some data to the bar series
            for (int i = 0; i < indicatorCount; i++)
            {
                bar.Values.Add(i * 15);
            }

            bar.PaletteColorMode = (PaletteColorMode)PaletteModeDropDownList.SelectedIndex;
            bar.Palette.SmoothPalette = SmoothPaletteCheckBox.Checked;

            // apply layout
            ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);
		}
	}
}
