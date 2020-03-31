using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.ThinWeb;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Chart.WebForm
{
    public partial class NImageMapToolsUC : NExampleUC
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!NThinChartControl1.Initialized)
            {
                // enable jittering (full scene antialiasing)
                NThinChartControl1.BackgroundStyle.FrameStyle.Visible = false;
                NThinChartControl1.Settings.JitterMode = JitterMode.Enabled;

                // set a chart title
                NLabel title = NThinChartControl1.Labels.AddHeader("Image Map Tools<br/>Tooltip, Browser Redirect, Cursor Change");
                title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
                title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
                title.TextStyle.TextFormat = TextFormat.XML;

                // setup the chart
                NChart chart = NThinChartControl1.Charts[0];
                chart.Enable3D = true;
                chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
                chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
                chart.Axis(StandardAxis.Depth).Visible = false;

                // add a bar series
                NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
                bar.DataLabelStyle.Visible = false;
                bar.Legend.Mode = SeriesLegendMode.DataPoints;
                bar.Legend.Format = "<label> <percent>";

                bar.AddDataPoint(new NDataPoint(42, "Chart"));
                bar.AddDataPoint(new NDataPoint(56, "Diagram"));
                bar.AddDataPoint(new NDataPoint(12, "Gauges"));
                bar.AddDataPoint(new NDataPoint(23, "Maps"));

                // modify the axis labels
                NOrdinalScaleConfigurator ordinalScale = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
                ordinalScale.AutoLabels = false;

                for (int i = 0; i < bar.Labels.Count; i++)
                {
                    ordinalScale.Labels.Add((string)bar.Labels[i]);
                }

                // apply style sheet
                NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.PaleMultiColor);
                styleSheet.Apply(chart);

                // apply layout
                ApplyLayoutTemplate(0, NThinChartControl1, chart, title, NThinChartControl1.Legends[0]);

                // add interactivity styles with the urls to redirect to and the corresponding cursors and tooltips

                NInteractivityStyle interactivityStyle = new NInteractivityStyle("Click here to jump to Chart Gallery", CursorType.Hand);
                interactivityStyle.UrlLink.OpenInNewWindow = true;
                interactivityStyle.UrlLink.Url = "https://www.nevron.com/products-dot-net-chart-gallery-charting-types-bar-chart.aspx";
                bar.InteractivityStyles[0] = interactivityStyle;

                interactivityStyle = new NInteractivityStyle("Click here to jump to Diagram Gallery", CursorType.Hand);
                interactivityStyle.UrlLink.OpenInNewWindow = true;
                interactivityStyle.UrlLink.Url = "https://www.nevron.com/products-dot-net-diagram-gallery-flow-and-organization-charts-flow-charts.aspx";
                bar.InteractivityStyles[1] = interactivityStyle;

                interactivityStyle = new NInteractivityStyle("Click here to jump to Gauge Gallery", CursorType.Hand);
                interactivityStyle.UrlLink.OpenInNewWindow = true;
                interactivityStyle.UrlLink.Url = "https://www.nevron.com/products-dot-net-chart-gallery-gauges-radial-gauge.aspx";
                bar.InteractivityStyles[2] = interactivityStyle;

                interactivityStyle = new NInteractivityStyle("Click here to jump to Maps Gallery", CursorType.Hand);
                interactivityStyle.UrlLink.OpenInNewWindow = true;
                interactivityStyle.UrlLink.Url = "https://www.nevron.com/products-dot-net-diagram-gallery-maps-general-maps.aspx";
                bar.InteractivityStyles[3] = interactivityStyle;
                NThinChartControl1.Controller.SetActivePanel(chart);
            }
            
            NThinChartControl1.Controller.Tools.Clear();

            if (EnableBrowserRedirectCheckBox.Checked)
            {
                NThinChartControl1.Controller.Tools.Add(new NBrowserRedirectTool());
            }

            if (EnableTooltipsCheckBox.Checked)
            {
                NTooltipTool tooltipTool = new NTooltipTool();
                tooltipTool.FollowMouse = true;
                NThinChartControl1.Controller.Tools.Add(tooltipTool);
            }

            if (EnableCursorChangeCheckBox.Checked)
            {
                NThinChartControl1.Controller.Tools.Add(new NCursorTool());
            }

			NThinChartControl1.Controller.Tools.Add(new NTrackballTool());
        }
    }
}
