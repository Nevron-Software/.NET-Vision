using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Dom;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;


namespace Nevron.Examples.Chart.WebForm
{
	public partial class NClusterBarUC : NExampleUC
	{
		protected NChart nChart;
		protected NBarSeries nBar1;
		protected NBarSeries nBar2;


		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Cluster Bar Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			nChart = nChartControl1.Charts[0];
			nChart.BoundsMode = BoundsMode.Stretch;

            // add interlace stripe
            NLinearScaleConfigurator linearScale = nChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
            linearScale.StripStyles.Add(stripStyle);

			// add the first bar
			nBar1 = (NBarSeries)nChart.Series.Add(SeriesType.Bar);
			nBar1.Name = "Bar1";
			nBar1.MultiBarMode = MultiBarMode.Series;
			nBar1.Legend.TextStyle.FontStyle.EmSize = new NLength(8);
			nBar1.DataLabelStyle.Format = "<value>";
			nBar1.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(7);
			nBar1.FillStyle = new NColorFillStyle(Color.DarkSeaGreen);
			nBar1.Values.ValueFormatter = new NNumericValueFormatter("0");

			// add the second bar
			nBar2 = (NBarSeries)nChart.Series.Add(SeriesType.Bar);
			nBar2.Name = "Bar2";
			nBar2.MultiBarMode = MultiBarMode.Clustered;
			nBar2.Legend.TextStyle.FontStyle.EmSize = new NLength(8);
			nBar2.DataLabelStyle.Format = "<value>";
			nBar2.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(7);
			nBar2.FillStyle = new NColorFillStyle(Color.MediumSlateBlue);
			nBar2.Values.ValueFormatter = new NNumericValueFormatter("0");

			// fill with random data
			nBar1.Values.FillRandomRange(Random, 5, 10, 100);
			nBar2.Values.FillRandomRange(Random, 5, 10, 500);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, nChart, title, nChartControl1.Legends[0]);

			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithPercents(GapPercentDropDownList, 10);
				WebExamplesUtilities.FillComboWithPercents(WidthPercentDropDownList, 10);

				GapPercentDropDownList.SelectedIndex = 0;
				WidthPercentDropDownList.SelectedIndex = 8;
			}
			else
			{
				nBar1.GapPercent = WebExamplesUtilities.GetPercentFromCombo(GapPercentDropDownList, 10);
				nBar2.GapPercent = WebExamplesUtilities.GetPercentFromCombo(GapPercentDropDownList, 10);

				nBar1.WidthPercent = WebExamplesUtilities.GetPercentFromCombo(WidthPercentDropDownList, 10);
				nBar2.WidthPercent = WebExamplesUtilities.GetPercentFromCombo(WidthPercentDropDownList, 10);

				if (ScaleSecondaryClusterCheckBox.Checked == true)
				{
					nBar2.DisplayOnAxis(StandardAxis.PrimaryY, false);
					nBar2.DisplayOnAxis(StandardAxis.SecondaryY, true);

					nChart.Axis(StandardAxis.SecondaryY).Visible = true;
				}
				else
				{
					nBar2.DisplayOnAxis(StandardAxis.PrimaryY, true);
					nBar2.DisplayOnAxis(StandardAxis.SecondaryY, false);

					nChart.Axis(StandardAxis.SecondaryY).Visible = false;
				}
			}
		}

		protected void PositiveDataButton_Click(object sender, EventArgs e)
		{
			nBar1.Values.FillRandomRange(Random, 5, 10, 100);
			nBar2.Values.FillRandomRange(Random, 5, 10, 500);		
		}

		protected void PositiveAndNegativeDataButton_Click(object sender, EventArgs e)
		{
			nBar1.Values.FillRandomRange(Random, 5, -100, 100);
			nBar2.Values.FillRandomRange(Random, 5, -100, 100);
		}
	}
}
