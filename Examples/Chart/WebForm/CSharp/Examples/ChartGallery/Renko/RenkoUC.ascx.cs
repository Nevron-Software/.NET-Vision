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
    public partial class RenkoUC : NExampleUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                WebExamplesUtilities.FillComboWithColorNames(UpColorDropDownList, KnownColor.White);
                WebExamplesUtilities.FillComboWithColorNames(DownColorDropDownList, KnownColor.Black);
                BoxSizeDropDownList.Items.AddRange(new ListItem[] 
                { 
                    new ListItem("0.5"), 
                    new ListItem("1"), 
                    new ListItem("2"), 
                    new ListItem("2%"), 
                    new ListItem("5%"), 
                    new ListItem("10%") 
                });
                BoxSizeDropDownList.SelectedIndex = 1;
                BoxWidthDropDownList.Items.AddRange(new ListItem[] 
                {
                    new ListItem("50%"), 
                    new ListItem("75%"), 
                    new ListItem("100%")
                });
                BoxWidthDropDownList.SelectedIndex = 2;
            }

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Renko Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
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

            NRenkoSeries renko = (NRenkoSeries)chart.Series.Add(SeriesType.Renko);
            renko.UseXValues = true;
            renko.UpFillStyle = new NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(UpColorDropDownList));
            renko.DownFillStyle = new NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(DownColorDropDownList));

			switch (BoxSizeDropDownList.SelectedIndex)
            {
                case 0:
                    renko.BoxSize = 0.5;
                    renko.BoxSizeInPercents = false;
                    break;

                case 1:
                    renko.BoxSize = 1;
                    renko.BoxSizeInPercents = false;
                    break;

                case 2:
                    renko.BoxSize = 2;
                    renko.BoxSizeInPercents = false;
                    break;

                case 3:
                    renko.BoxSize = 2;
                    renko.BoxSizeInPercents = true;
                    break;

                case 4:
                    renko.BoxSize = 5;
                    renko.BoxSizeInPercents = true;
                    break;

                case 5:
                    renko.BoxSize = 10;
                    renko.BoxSizeInPercents = true;
                    break;
			}

			switch (BoxWidthDropDownList.SelectedIndex)
			{
				case 0:
					renko.BoxWidthPercent = 50;
					break;

				case 1:
					renko.BoxWidthPercent = 75;
					break;

				case 2:
					renko.BoxWidthPercent = 100;
					break;
			}

			GenerateData(renko);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
        }

        private void GenerateData(NRenkoSeries renko)
        {
            NStockDataGenerator dataGenerator = new NStockDataGenerator(new NRange1DD(50, 350), 0.02, 10);
            dataGenerator.Reset();

            DateTime dt = new DateTime(2007, 1, 1);

            for (int i = 0; i < 20; i++)
            {
                renko.Values.Add(dataGenerator.GetNextValue());
                renko.XValues.Add(dt);

                dt = dt.AddDays(1);
            }
        }
    }
}
