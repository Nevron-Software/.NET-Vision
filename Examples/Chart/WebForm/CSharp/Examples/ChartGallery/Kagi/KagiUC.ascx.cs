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
    public partial class KagiUC : NExampleUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                WebExamplesUtilities.FillComboWithColorNames(UpColorDropDownList, KnownColor.Black);
				WebExamplesUtilities.FillComboWithColorNames(DownColorDropDownList, KnownColor.Black);
                WebExamplesUtilities.FillComboWithValues(UpStrokeDropDownList, 1, 3, 1);
                UpStrokeDropDownList.SelectedIndex = 1;
                WebExamplesUtilities.FillComboWithValues(DownStrokeDropDownList, 1, 3, 1);
                reversalAmountDropdownlist.Items.AddRange(new ListItem[] 
                { new ListItem("0.5"), 
                    new ListItem("1"), 
                    new ListItem("2"), 
                    new ListItem("1%"), 
                    new ListItem("2%"), 
                    new ListItem("5%") 
                });
            }

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // no legend
            nChartControl1.Legends.Clear();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Kagi Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

            NChart chart = nChartControl1.Charts[0];
            chart.BoundsMode = BoundsMode.Stretch;

            // setup X axis
            NPriceScaleConfigurator priceConfigurator = new NPriceScaleConfigurator();
            priceConfigurator.InnerMajorTickStyle.LineStyle.Width = new NLength(0);
            chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = priceConfigurator;

            // setup Y axis
            NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            linearScale.StripStyles.Add(stripStyle);

            //Setup Kagi series
            NKagiSeries kagi = (NKagiSeries)chart.Series.Add(SeriesType.Kagi);
            kagi.UpStrokeStyle.Color = WebExamplesUtilities.ColorFromDropDownList(UpColorDropDownList);
            kagi.DownStrokeStyle.Color = WebExamplesUtilities.ColorFromDropDownList(DownColorDropDownList);
            kagi.UpStrokeStyle.Width = new NLength(Convert.ToInt32(UpStrokeDropDownList.SelectedValue));
            kagi.DownStrokeStyle.Width = new NLength(Convert.ToInt32(DownStrokeDropDownList.SelectedValue));
            kagi.UseXValues = true;

            switch (reversalAmountDropdownlist.SelectedIndex)
            {
                case 0:
                    kagi.ReversalAmount = 0.5;
                    kagi.ReversalAmountInPercents = false;
                    break;

                case 1:
                    kagi.ReversalAmount = 1;
                    kagi.ReversalAmountInPercents = false;
                    break;

                case 2:
                    kagi.ReversalAmount = 2;
                    kagi.ReversalAmountInPercents = false;
                    break;

                case 3:
                    kagi.ReversalAmount = 1;
                    kagi.ReversalAmountInPercents = true;
                    break;

                case 4:
                    kagi.ReversalAmount = 2;
                    kagi.ReversalAmountInPercents = true;
                    break;

                case 5:
                    kagi.ReversalAmount = 5;
                    kagi.ReversalAmountInPercents = true;
                    break;
            }

            GenerateData(kagi);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
        }

        private void GenerateData(NKagiSeries series)
        {
            NStockDataGenerator dataGenerator = new NStockDataGenerator(new NRange1DD(50, 350), 0.002, 2);
            dataGenerator.Reset();

            DateTime dt = new DateTime(2007, 1, 1);

            for (int i = 0; i < 100; i++)
            {
                series.Values.Add(dataGenerator.GetNextValue());
                series.XValues.Add(dt);

                dt = dt.AddDays(1);
            }
        }
    }
}
