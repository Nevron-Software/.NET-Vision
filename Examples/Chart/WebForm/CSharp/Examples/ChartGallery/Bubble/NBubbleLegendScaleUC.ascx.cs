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
    public partial class NBubbleLegendScaleUC : NExampleUC
    {
        protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Bubble Legend Scale");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// add interlace stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			NOrdinalScaleConfigurator ordinalScale = chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			ordinalScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

			// add a bubble series
			NBubbleSeries bubble = (NBubbleSeries)chart.Series.Add(SeriesType.Bubble);
			bubble.DataLabelStyle.VertAlign = VertAlign.Center;
			bubble.DataLabelStyle.Visible = false;
			bubble.MinSize = new NLength(7.0f, NRelativeUnit.ParentPercentage);
			bubble.MaxSize = new NLength(16.0f, NRelativeUnit.ParentPercentage);

			for (int i = 0; i < 10; i++)
			{
				bubble.Values.Add(i);
				bubble.Sizes.Add(i * 10 + 10);
			}
			bubble.InflateMargins = true;

			NPalette palette = new NPalette();
			palette.SmoothPalette = true;
			palette.Clear();
			palette.Add(0, Color.Green);
			palette.Add(60, Color.Yellow);
			palette.Add(120, Color.Red);

			bubble.Palette = palette;

			nChartControl1.Legends[0].Header.Text = "Bubble Size";

			bubble.Legend.Mode = SeriesLegendMode.SeriesLogic;
			bubble.BubbleSizeScale.TextOffset = new NLength(0);
			bubble.BubbleSizeScale.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Center;
			bubble.BubbleSizeScale.Mode = BubbleSizeScaleMode.ConcentricDown;

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);
		}
	}
}

