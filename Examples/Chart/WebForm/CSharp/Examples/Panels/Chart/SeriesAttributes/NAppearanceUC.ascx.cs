using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NAppearanceUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				FillModeDropDownList.Items.Add("Uniform");
				FillModeDropDownList.Items.Add("Individual");
				FillModeDropDownList.SelectedIndex = 1;

				WebExamplesUtilities.FillComboWithColorNames(BarColorDropDownList, KnownColor.DarkOrange);

				WebExamplesUtilities.FillComboWithValues(CycleCountDropDownList, 2, 6, 1);
				CycleCountDropDownList.SelectedIndex = 4;

				WebExamplesUtilities.FillComboWithValues(BarCountDropDownList, 3, 20, 1);
				BarCountDropDownList.SelectedIndex = 3;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Series Appearance");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			chart.Axis(StandardAxis.Depth).Visible = false;

			// add interlaced stripe
			NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScaleConfigurator.StripStyles.Add(stripStyle);

			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Name = "Bar Series";
			bar.DataLabelStyle.Visible = false;
			bar.Values.FillRandom(Random, BarCountDropDownList.SelectedIndex + 3);

			switch (FillModeDropDownList.SelectedIndex)
			{
                case 0: // Uniform
                    BarColorDropDownList.Enabled = true;
                    CycleCountDropDownList.Enabled = false;

                    bar.FillStyle = new NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(BarColorDropDownList));
                    break;

				case 1: // Individual
                    BarColorDropDownList.Enabled = false;
                    CycleCountDropDownList.Enabled = true;

                    bar.FillStyles.Clear();

                    NChartPalette palette = new NChartPalette();
                    palette.SetPredefinedPalette(ChartPredefinedPalette.Nevron);

                    int cycleCount = CycleCountDropDownList.SelectedIndex + 1;
                    int currentColor = 0;

                    for (int i = 0; i < bar.Values.Count; i++)
                    {
                        bar.FillStyles[i] = new NColorFillStyle(palette.SeriesColors[currentColor]);
                        currentColor++;

                        if (currentColor > cycleCount)
                        {
                            currentColor = 0;
                        }
                    }
                    break;
			}

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}
	}
}
