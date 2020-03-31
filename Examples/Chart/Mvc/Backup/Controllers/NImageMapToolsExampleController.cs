using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.ThinWeb;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Chart.Mvc
{
    public class NImageMapToolsExampleController : NChartExampleController
    {
        public NImageMapToolsExampleController()
        {
        }

        public override void Initialize(NThinChartControl control)
        {
            // enable jittering (full scene antialiasing)
            control.BackgroundStyle.FrameStyle.Visible = false;
            control.Settings.JitterMode = JitterMode.Enabled;

            // set a chart title
            NLabel title = control.Labels.AddHeader("Interactivity Tools<br/>Tooltip, Browser Redirect, Cursor Change");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            title.TextStyle.TextFormat = TextFormat.XML;

            // setup the chart
            NChart chart = control.Charts[0];
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
            ApplyLayoutTemplate(0, control, chart, title, control.Legends[0]);

            // add interactivity styles with the urls to redirect to and the corresponding cursors and tooltips

            NInteractivityStyle interactivityStyle = new NInteractivityStyle("Click here to jump to Chart Gallery", CursorType.Hand);
            interactivityStyle.UrlLink.OpenInNewWindow = true;
            interactivityStyle.UrlLink.Url = "http://www.nevron.com/Gallery.ChartFor.NET.ChartTypes.BarChartGallery.aspx";
            bar.InteractivityStyles[0] = interactivityStyle;

            interactivityStyle = new NInteractivityStyle("Click here to jump to Diagram Gallery", CursorType.Hand);
            interactivityStyle.UrlLink.OpenInNewWindow = true;
            interactivityStyle.UrlLink.Url = "http://www.nevron.com/Gallery.DiagramFor.NET.FlowAndOrganizationCharts.Flowcharts.aspx";
            bar.InteractivityStyles[1] = interactivityStyle;

            interactivityStyle = new NInteractivityStyle("Click here to jump to Gauge Gallery", CursorType.Hand);
            interactivityStyle.UrlLink.OpenInNewWindow = true;
            interactivityStyle.UrlLink.Url = "http://www.nevron.com/Gallery.ChartFor.NET.Gauges.RadialGaugeGallery.aspx";
            bar.InteractivityStyles[2] = interactivityStyle;

            interactivityStyle = new NInteractivityStyle("Click here to jump to Maps Gallery", CursorType.Hand);
            interactivityStyle.UrlLink.OpenInNewWindow = true;
            interactivityStyle.UrlLink.Url = "http://www.nevron.com/Gallery.DiagramFor.NET.Maps.MapProjections.aspx";
            bar.InteractivityStyles[3] = interactivityStyle;

            control.Controller.Tools.Add(new NTooltipTool());
            control.Controller.Tools.Add(new NBrowserRedirectTool());
            control.Controller.Tools.Add(new NCursorTool());

            control.Controller.Tools.Clear();

            // add browser redirect tool
            control.Controller.Tools.Add(new NBrowserRedirectTool());

            // add tooltip tool that follows the mouse
            NTooltipTool tooltipTool = new NTooltipTool();
            tooltipTool.FollowMouse = true;
            control.Controller.Tools.Add(tooltipTool);

            // add a cursor change tool
            control.Controller.Tools.Add(new NCursorTool());
        }
    }
}