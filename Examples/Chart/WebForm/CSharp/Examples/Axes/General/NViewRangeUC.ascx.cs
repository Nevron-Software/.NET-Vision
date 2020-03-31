using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NRulesSizeUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Axis View Range");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            title.Margins = new NMarginsL(10, 10, 10, 10);
            title.DockMode = PanelDockMode.Top;

            // turn off the legend
            nChartControl1.Legends[0].Mode = LegendMode.Disabled;

            // configure the chart
            NChart chart = nChartControl1.Charts[0];
            chart.Enable3D = true;
            chart.DockMode = PanelDockMode.Fill;
            chart.Margins = new NMarginsL(10, 0, 10, 10);

            // apply predefined lighting and projection
            chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

            // add interlace stripe
            NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

            // setup a bar series
            NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            bar.Name = "Bar Series";
            bar.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
            bar.ShadowStyle.Type = ShadowType.GaussianBlur;
            bar.ShadowStyle.Offset = new NPointL(2, 2);
            bar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0);
            bar.ShadowStyle.FadeLength = new NLength(5);
            bar.HasBottomEdge = false;

            // add some data to the bar series
            bar.AddDataPoint(new NDataPoint(18, "Silverlight"));
            bar.AddDataPoint(new NDataPoint(15, "Ajax"));
            bar.AddDataPoint(new NDataPoint(21, "JackBe"));
            bar.AddDataPoint(new NDataPoint(23, "Laszlo"));
            bar.AddDataPoint(new NDataPoint(28, "Java FX"));
            bar.AddDataPoint(new NDataPoint(29, "Flex"));

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.BrightMultiColor);
            styleSheet.Apply(nChartControl1.Document.Charts[0]);

            if (CustomViewRangeCheckBox.Checked)
            {
                // specify custom view range
                chart.Axis(StandardAxis.PrimaryY).View = new NRangeAxisView(new NRange1DD(14, 30), true, true);
            }
            else
            {
                chart.Axis(StandardAxis.PrimaryY).View = new NContentAxisView();
            }
        }
	}
}
