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
	public partial class NFindingUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			// set a chart title
			if (!IsPostBack)
			{
				SearchForDropDownList.Items.Add("Max value");
				SearchForDropDownList.Items.Add("Min value");
				SearchForDropDownList.Items.Add("Custom value");
				SearchForDropDownList.Items.Add("Custom string");
				SearchForDropDownList.SelectedIndex = 0;

				CustomValueTextBox.Text = "20";
				CustomStringTextBox.Text = "Bar 5";
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// add header
			NLabel header = nChartControl1.Labels.AddHeader("Finding Data");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.TextStyle.FillStyle = new NColorFillStyle(Color.FromArgb(60, 90, 108));
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));			

			// configure the chart
			NChart nChart = nChartControl1.Charts[0];
			nChart.BoundsMode = BoundsMode.Stretch;
			nChart.Axis(StandardAxis.Depth).Visible = false;
			nChart.Location = new NPointL(
				new NLength(5, NRelativeUnit.ParentPercentage),
				new NLength(15, NRelativeUnit.ParentPercentage));
			nChart.Size = new NSizeL(
				new NLength(85, NRelativeUnit.ParentPercentage),
				new NLength(75, NRelativeUnit.ParentPercentage));

			NBarSeries nBar = (NBarSeries)nChart.Series.Add(SeriesType.Bar);
            nBar.DataLabelStyle.Format = "<label>";

            nBar.Values.Add(10);
            nBar.Values.Add(20);
            nBar.Values.Add(15);
            nBar.Values.Add(44);
            nBar.Values.Add(87);
            nBar.Values.Add(33);
            nBar.Values.Add(56);

            for (int i = 0; i < 7; i++)
            {
                nBar.Labels.Add("Bar " + (i+1));
            }

			FindAndHighlightDataPoints(nBar);

			// configure the legend
			NLegend legend = nChartControl1.Legends[0];
			legend.Mode = LegendMode.Manual;
			legend.Data.ExpandMode = LegendExpandMode.ColsOnly;

			NLegendItemCellData item = new NLegendItemCellData("Found Data Point", 
				LegendMarkShape.Rectangle,
				new NStrokeStyle(1, Color.Black),
				new NColorFillStyle(Color.Red),
				new NShadowStyle(),
				new NTextStyle());
			legend.Data.Items.Add(item);

			item = new NLegendItemCellData("Series Data Points",
				LegendMarkShape.Rectangle,
				new NStrokeStyle(1, Color.Black),
				(NFillStyle)nBar.FillStyle.Clone(),
				new NShadowStyle(),
				new NTextStyle());
			legend.Data.Items.Add(item);
		}

		private void DisplayString(String sMessage)
		{
			NLabel label = nChartControl1.Labels.AddHeader(sMessage);
			label.Location = new NPointL(
				new NLength(30, NRelativeUnit.ParentPercentage),
				new NLength(90, NRelativeUnit.ParentPercentage));
			label.TextStyle.FontStyle = new NFontStyle("Arial", 9);
			label.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left;
			label.TextStyle.StringFormatStyle.VertAlign = VertAlign.Top;
			label.TextStyle.FillStyle = new NColorFillStyle(Color.Red);
			label.TextStyle.BackplaneStyle.Visible = false;
		}

		private void FindAndHighlightDataPoints(NSeries bar)
		{
			switch (SearchForDropDownList.SelectedIndex)
			{
				case 0:
				{
					int index = bar.Values.FindMaxValue();
					bar.FillStyles[index] = new NColorFillStyle(Color.Red);
					break;
				}

				case 1:
				{
					int index = bar.Values.FindMinValue();
					bar.FillStyles[index] = new NColorFillStyle(Color.Red);
					break;
				}

				case 2:
				{
					try
					{
						double dValue = Double.Parse(CustomValueTextBox.Text);

						int index = bar.Values.FindValue(dValue);
						if (index == -1)
						{
							DisplayString("The specified value was not found \n in the bar Values series");
						}
						else
						{
							bar.FillStyles[index] = new NColorFillStyle(Color.Red);
						}
					}
					catch
					{
					}

					break;
				}

				case 3:
				{
					int index = bar.Labels.FindString(CustomStringTextBox.Text);
					if (index == -1)
					{
						DisplayString("The specified string was not found \n in the bar Labels series");
					}
					else
					{
						bar.FillStyles[index] = new NColorFillStyle(Color.Red);
					}

					break;
				}
			}
		}
	}
}
