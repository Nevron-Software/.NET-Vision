using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.ThinWeb;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Chart.Mvc
{
    public class NClientSideEventsToolExampleController : NChartExampleController
    {
        public NClientSideEventsToolExampleController()
        {
        }

        public override void Initialize(NThinChartControl control)
        {
            NBarSeries bar;

            control.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
            NLabel header = control.Labels.AddHeader("Capturing Mouse Events");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

            // configure the legend
            NLegend legend = control.Legends[0];
            legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Right);
            legend.FillStyle.SetTransparencyPercent(50);
            legend.Location = new NPointL(new NLength(98, NRelativeUnit.ParentPercentage), legend.Location.Y);

            // configure the chart
            NChart chart = control.Charts[0];
            chart.Axis(StandardAxis.Depth).Visible = false;
            chart.BoundsMode = BoundsMode.Fit;
            chart.Location = new NPointL(new NLength(5, NRelativeUnit.ParentPercentage),
                                        new NLength(15, NRelativeUnit.ParentPercentage));
            chart.Size = new NSizeL(new NLength(70, NRelativeUnit.ParentPercentage),
                                    new NLength(70, NRelativeUnit.ParentPercentage));
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft);

            // create a bar series
            bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            bar.Name = "My Bar Series";
            bar.DataLabelStyle.Format = "<value>";

            bar.AddDataPoint(new NDataPoint(10, "Ford", new NColorFillStyle(RandomColor())));
            bar.AddDataPoint(new NDataPoint(20, "Toyota", new NColorFillStyle(RandomColor())));
            bar.AddDataPoint(new NDataPoint(30, "VW", new NColorFillStyle(RandomColor())));
            bar.AddDataPoint(new NDataPoint(25, "Mitsubishi", new NColorFillStyle(RandomColor())));
            bar.AddDataPoint(new NDataPoint(29, "Jaguar", new NColorFillStyle(RandomColor())));

            bar.Legend.Mode = SeriesLegendMode.DataPoints;
            bar.BarShape = BarShape.SmoothEdgeBar;
            bar.DataLabelStyle.Visible = false;

            control.Controller.Tools.Add(new NClientMouseEventTool());

            bar.InteractivityStyles.Clear();

            for (int i = 0; i < bar.Values.Count; i++)
            {
                NInteractivityStyle interactivityStyle = new NInteractivityStyle();

                string script = "alert(\"Mouse Event [Mouse Click]. Captured for bar [" + i.ToString() + "])\");";
                interactivityStyle.ClientMouseEventAttribute.Click = script;
                bar.InteractivityStyles[i] = interactivityStyle;
            }
        }
    }
}