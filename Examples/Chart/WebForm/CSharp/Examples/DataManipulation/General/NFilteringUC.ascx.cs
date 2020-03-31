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
	public partial class NFilteringUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				FilterDropDownList.Items.Add("More");
				FilterDropDownList.Items.Add("Less");
				FilterDropDownList.Items.Add("Equal");
				FilterDropDownList.Items.Add("More Or Equal");
				FilterDropDownList.Items.Add("Less Or Equal");
				FilterDropDownList.Items.Add("Not Equal");
				FilterDropDownList.SelectedIndex = 0;

				ValueTextBox.Text = "50";
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// add header
			NLabel header = nChartControl1.Labels.AddHeader("Filtering Data");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.TextStyle.FillStyle = new NColorFillStyle(Color.FromArgb(60, 90, 108));
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));			

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Location = new NPointL(
				new NLength(5, NRelativeUnit.ParentPercentage),
				new NLength(15, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(85, NRelativeUnit.ParentPercentage),
				new NLength(75, NRelativeUnit.ParentPercentage));

            Random rnd = new Random(0);

            NBarSeries nBar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            nBar.DataLabelStyle.Format = "<value>";
            nBar.Values.FillRandom(rnd, 10);

			// configure the legend
			NLegend legend = nChartControl1.Legends[0];
			legend.Mode = LegendMode.Manual;
			legend.Data.ExpandMode = LegendExpandMode.ColsOnly;

			NLegendItemCellData item = new NLegendItemCellData("Filtered Data Points",
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

			Filter(nBar);
		}

		private void Filter(NBarSeries bar)
		{
			NDataSeriesSubset subsetAll = new NDataSeriesSubset();
			NDataSeriesSubset subsetFilter = new NDataSeriesSubset();

			subsetAll.AddRange(0, bar.Values.Count - 1);

			try
			{
				double dValue = Double.Parse(ValueTextBox.Text);		

				Nevron.Chart.CompareMethod method = (Nevron.Chart.CompareMethod)FilterDropDownList.SelectedIndex;

				subsetFilter = bar.Values.Filter(method, dValue);

				// apply red color only to the bars in the filter subset
				foreach (int index in subsetFilter)
				{
					bar.FillStyles[index] = new NColorFillStyle(Color.Red);
				}
			}
			catch
			{
			}
		}
	}
}
