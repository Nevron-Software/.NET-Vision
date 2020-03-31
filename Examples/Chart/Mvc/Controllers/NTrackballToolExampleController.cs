using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.ThinWeb;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Mvc
{
    public class NTrackballToolExampleController : NChartExampleController
    {
        public NTrackballToolExampleController()
        {
        }

        public override void Initialize(NThinChartControl control)
        {
            // enable jittering (full scene antialiasing)
            control.Settings.JitterMode = JitterMode.Enabled;
            control.Panels.Clear();

            // apply background image border
            NImageFrameStyle frame = new NImageFrameStyle();
            frame.Type = ImageFrameType.Raised;
            frame.BackgroundColor = Color.White;
            frame.BorderStyle.Color = Color.Gainsboro;
            control.BackgroundStyle.FrameStyle = frame;
            control.BackgroundStyle.FillStyle = new NGradientFillStyle(Color.White, Color.GhostWhite);

            // set a chart title
            NLabel title = new NLabel("Trackball Tool");
            control.Panels.Add(title);
            title.DockMode = PanelDockMode.Top;
            title.Padding = new NMarginsL(4, 6, 4, 6);
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

            // configure the legend
            NLegend legend = new NLegend();
            control.Panels.Add(legend);
            legend.DockMode = PanelDockMode.Right;
            legend.Padding = new NMarginsL(1, 1, 3, 3);
            legend.FillStyle.SetTransparencyPercent(50);
            legend.OuterBottomBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
            legend.OuterLeftBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
            legend.OuterRightBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
            legend.OuterTopBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
            legend.HorizontalBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
            legend.VerticalBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);

            // configure the chart
            NCartesianChart chart = new NCartesianChart();
            control.Panels.Add(chart);
            chart.Enable3D = true;
            chart.Fit3DAxisContent = true;
            chart.DisplayOnLegend = legend;
            chart.BoundsMode = BoundsMode.Fit;
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
            chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
            chart.DockMode = PanelDockMode.Fill;
            chart.Padding = new NMarginsL(
                new NLength(3, NRelativeUnit.ParentPercentage),
                new NLength(3, NRelativeUnit.ParentPercentage),
                new NLength(3, NRelativeUnit.ParentPercentage),
                new NLength(3, NRelativeUnit.ParentPercentage));

            // setup the X axis
            NAxis axisX = chart.Axis(StandardAxis.PrimaryX);
            NOrdinalScaleConfigurator scaleX = (NOrdinalScaleConfigurator)axisX.ScaleConfigurator;
            scaleX.MajorTickMode = MajorTickMode.AutoMaxCount;

            // add interlaced stripe for the Y axis
            NAxis axisY = chart.Axis(StandardAxis.PrimaryY);
            NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)axisY.ScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };
            scaleY.StripStyles.Add(stripStyle);

            // hide the depth axis
            chart.Axis(StandardAxis.Depth).Visible = false;

            // add a bar series and fill it with data
            NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            bar.Name = "Simple Bar Chart";
            bar.BarShape = BarShape.SmoothEdgeBar;
            bar.Legend.Mode = SeriesLegendMode.DataPoints;
            bar.Legend.TextStyle.FontStyle.EmSize = new NLength(8, NGraphicsUnit.Point);
            bar.DataLabelStyle.Visible = false;

            bar.AddDataPoint(new NDataPoint(16, "Spain"));
            bar.AddDataPoint(new NDataPoint(42, "France"));
            bar.AddDataPoint(new NDataPoint(56, "Germany"));
            bar.AddDataPoint(new NDataPoint(23, "Italy"));
            bar.AddDataPoint(new NDataPoint(47, "UK"));
            bar.AddDataPoint(new NDataPoint(38, "Sweden"));

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.NevronMultiColor);
            styleSheet.Apply(bar);

            //control.Controller.EnableAutoUpdate = true;
            NTrackballTool tbt = new NTrackballTool();
            tbt.Exclusive = true;
            tbt.Enabled = true;

            control.Controller.SetActivePanel(chart);
            control.Controller.Tools.Add(tbt);
        }
    }
}