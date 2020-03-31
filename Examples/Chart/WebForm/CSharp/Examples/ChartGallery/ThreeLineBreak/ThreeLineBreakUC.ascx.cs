using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WebForm
{
    public partial class ThreeLineBreakUC : NExampleUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                WebExamplesUtilities.FillComboWithColorNames(UpColorDropDownList, KnownColor.White);
                WebExamplesUtilities.FillComboWithColorNames(DownColorDropDownList, KnownColor.Black);
                BoxWidthDropDownList.Items.AddRange(new ListItem[] 
                {
                    new ListItem("50%"), 
                    new ListItem("75%"), 
                    new ListItem("100%")
                });
                BoxWidthDropDownList.SelectedIndex = 2;
                WebExamplesUtilities.FillComboWithValues(NumberOfLinesDropDownList, 1, 4, 1);
            }

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Three Line Break");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
            NChart chart = nChartControl1.Charts[0];
            chart.BoundsMode = BoundsMode.Stretch;

            // add interlaced stripe
            NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScaleConfigurator.StripStyles.Add(stripStyle);

            // setup X axis
            NPriceScaleConfigurator priceConfigurator = new NPriceScaleConfigurator();
            priceConfigurator.InnerMajorTickStyle.LineStyle.Width = new NLength(0);
            priceConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
            chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = priceConfigurator;

            // setup line break series
            NThreeLineBreakSeries threeLineBreak = (NThreeLineBreakSeries)chart.Series.Add(SeriesType.ThreeLineBreak);
            threeLineBreak.UseXValues = true;

            threeLineBreak.UpFillStyle = new NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(UpColorDropDownList));
            threeLineBreak.DownFillStyle = new NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(DownColorDropDownList));
            threeLineBreak.NumberOfLinesToBreak = Convert.ToInt32(NumberOfLinesDropDownList.SelectedValue);

            switch (BoxWidthDropDownList.SelectedIndex)
            {
                case 0:
                    threeLineBreak.BoxWidthPercent = 50;
                    break;

                case 1:
                    threeLineBreak.BoxWidthPercent = 75;
                    break;

                case 2:
                    threeLineBreak.BoxWidthPercent = 100;
                    break;
            }

            GenerateData(threeLineBreak);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
        }

        private void GenerateData(NThreeLineBreakSeries threeLineBreak)
        {
            NStockDataGenerator dataGenerator = new NStockDataGenerator(new NRange1DD(50, 350), 0.002, 2);
            dataGenerator.Reset();

            DateTime dt = new DateTime(2007, 1, 1);

            for (int i = 0; i < 100; i++)
            {
                threeLineBreak.Values.Add(dataGenerator.GetNextValue());
                threeLineBreak.XValues.Add(dt);

                dt = dt.AddDays(1);
            }
        }
    }
}