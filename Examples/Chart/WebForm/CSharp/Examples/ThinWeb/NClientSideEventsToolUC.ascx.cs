using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NClientSideEventsToolUC : NExampleUC
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CaptureMouseEventDropDownList.Items.Add("OnClick");
                CaptureMouseEventDropDownList.Items.Add("OnDblClick");
                CaptureMouseEventDropDownList.Items.Add("OnMouseEnter");
                CaptureMouseEventDropDownList.Items.Add("OnMouseLeave");
                CaptureMouseEventDropDownList.Items.Add("Postback");
                CaptureMouseEventDropDownList.SelectedIndex = 0;
            }

            NBarSeries bar;

            if (!NThinChartControl1.Initialized)
            {
                NThinChartControl1.BackgroundStyle.FrameStyle.Visible = false;

                // set a chart title
                NLabel header = NThinChartControl1.Labels.AddHeader("Client Side Events Tool");
                header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
                header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
                header.ContentAlignment = ContentAlignment.BottomRight;
                header.Location = new NPointL(
                    new NLength(2, NRelativeUnit.ParentPercentage),
                    new NLength(2, NRelativeUnit.ParentPercentage));

                // configure the legend
                NLegend legend = NThinChartControl1.Legends[0];
                legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Right);
                legend.FillStyle.SetTransparencyPercent(50);
                legend.Location = new NPointL(new NLength(98, NRelativeUnit.ParentPercentage), legend.Location.Y);

                // configure the chart
                NChart chart = NThinChartControl1.Charts[0];
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

                bar.AddDataPoint(new NDataPoint(10, "Ford", new NColorFillStyle(WebExamplesUtilities.RandomColor())));
                bar.AddDataPoint(new NDataPoint(20, "Toyota", new NColorFillStyle(WebExamplesUtilities.RandomColor())));
                bar.AddDataPoint(new NDataPoint(30, "VW", new NColorFillStyle(WebExamplesUtilities.RandomColor())));
                bar.AddDataPoint(new NDataPoint(25, "Mitsubishi", new NColorFillStyle(WebExamplesUtilities.RandomColor())));
                bar.AddDataPoint(new NDataPoint(29, "Jaguar", new NColorFillStyle(WebExamplesUtilities.RandomColor())));

                bar.Legend.Mode = SeriesLegendMode.DataPoints;
                bar.BarShape = BarShape.SmoothEdgeBar;
                bar.DataLabelStyle.Visible = false;

                NThinChartControl1.Controller.Tools.Add(new NClientMouseEventTool());
            }
            else
            {
                bar = (NBarSeries)(NThinChartControl1.Charts[0].Series[0]);
            }

            bar.InteractivityStyles.Clear();
            for (int i = 0; i < bar.Values.Count; i++)
            {
                NInteractivityStyle interactivityStyle = new NInteractivityStyle();

                string script = "alert(\"Mouse Event [" + CaptureMouseEventDropDownList.SelectedValue.ToString() + "]. Captured for bar [" + i.ToString() + "])\");";

                switch (CaptureMouseEventDropDownList.SelectedIndex)
                {
                    case 0: // OnClick
                        interactivityStyle.ClientMouseEventAttribute.Click = script;
                        break;
                    case 1: // OnDblClick
                        interactivityStyle.ClientMouseEventAttribute.DoubleClick = script;
                        break;
                    case 2: // OnMouseEnter
                        interactivityStyle.ClientMouseEventAttribute.MouseEnter = script;
                        break;
                    case 3: // OnMouseLeave
                        interactivityStyle.ClientMouseEventAttribute.MouseLeave = script;
                        break;
                    case 4:
                        interactivityStyle.ClientMouseEventAttribute.Click = "_doPostback()";
                        break;
                }

                bar.InteractivityStyles[i] = interactivityStyle;
            }
        }
    }
}
