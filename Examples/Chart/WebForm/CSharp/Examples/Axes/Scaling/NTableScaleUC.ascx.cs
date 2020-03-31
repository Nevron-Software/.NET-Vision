using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
    public partial class NTableScaleUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
                ShowRowInterlacingCheckBox.Checked = true;
                ShowColumnInterlacingCheckBox.Checked = true;
                ShowRowHeadersCheckBox.Checked = true;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            nChartControl1.Legends[0].Visible = false;

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Table Scale");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

            // configure the chart
            NChart chart = nChartControl1.Charts[0];
            chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHalf);
            chart.Axis(StandardAxis.Depth).Visible = false;

            // add interlace stripe
            NAxis yAxis = chart.Axis(StandardAxis.PrimaryY);
            NLinearScaleConfigurator linearScale = yAxis.ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle strip = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            strip.Interlaced = true;
            strip.SetShowAtWall(ChartWallType.Back, true);
            linearScale.StripStyles.Add(strip);

            // create two series with random data
            Random random = new System.Random();
            NBarSeries alcoholSales = new NBarSeries();
            alcoholSales.Name = "Alcohol";
            alcoholSales.MultiBarMode = MultiBarMode.Stacked;
            alcoholSales.Values.FillRandom(random, 12);
            alcoholSales.DataLabelStyle.Visible = false;
            chart.Series.Add(alcoholSales);

            NBarSeries beveragesSales = new NBarSeries();
            beveragesSales.Name = "Beverages";
            beveragesSales.MultiBarMode = MultiBarMode.Stacked;
            beveragesSales.Values.FillRandom(random, 12);
            beveragesSales.DataLabelStyle.Visible = false;
            chart.Series.Add(beveragesSales);

            // create a table scale
            NTableScaleConfigurator tableScale = new NTableScaleConfigurator();
            chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = tableScale;

            NCustomTableScaleRow customRow = new NCustomTableScaleRow();
            customRow.Items = new object[] { "J", "F", "M", "A", "M", "J", "J", "A", "S", "O", "N", "D" };
            tableScale.Rows.Add(customRow);

            for (int i = 0; i < chart.Series.Count; i++)
            {
                NSeriesTableScaleRow row = new NSeriesTableScaleRow();

                row.Series = chart.Series[i];

                // whether to show row headers
                row.ShowLeftRowHeader = ShowRowHeadersCheckBox.Checked;
                tableScale.Rows.Add(row);
            }

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

            // apply layout
            ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);

            // row interlacing
            if (ShowRowInterlacingCheckBox.Checked)
            {
                NTableInterlaceStyle interlaceStyle = new NTableInterlaceStyle();

                interlaceStyle.Type = TableInterlaceStyleType.Row;
                interlaceStyle.Length = 1;
                interlaceStyle.Interval = 1;
                interlaceStyle.FillStyle = new NColorFillStyle(Color.FromArgb(124, Color.Beige));

                tableScale.InterlaceStyles.Add(interlaceStyle);
            }

            // col interlacing
            if (ShowColumnInterlacingCheckBox.Checked)
            {
                NTableInterlaceStyle interlaceStyle = new NTableInterlaceStyle();

                interlaceStyle.Type = TableInterlaceStyleType.Col;
                interlaceStyle.Length = 1;
                interlaceStyle.Interval = 1;
                interlaceStyle.FillStyle = new NColorFillStyle(Color.FromArgb(124, Color.Red));

                tableScale.InterlaceStyles.Add(interlaceStyle);
            }
		}
	}
}
