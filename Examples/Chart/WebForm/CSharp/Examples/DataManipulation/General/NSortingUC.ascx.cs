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
	public partial class NSortingUC : NExampleUC
	{

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				SortOrderDropDownList.Items.Add("Ascending");
				SortOrderDropDownList.Items.Add("Descending");
				SortOrderDropDownList.SelectedIndex = 0;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// add header
			NLabel header = nChartControl1.Labels.AddHeader("Sorting Data");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.TextStyle.FillStyle = new NColorFillStyle(Color.FromArgb(60, 90, 108));
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));			

			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.Location = new NPointL(
				new NLength(5, NRelativeUnit.ParentPercentage),
				new NLength(15, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(70, NRelativeUnit.ParentPercentage),
				new NLength(80, NRelativeUnit.ParentPercentage));

			// add a new bar serie
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Values.FillRandom(Random, 6);
			bar.Labels.FillRandom(Random, 6);

			for(int i = 0; i < bar.Values.Count; i++)
			{
				bar.FillStyles[i] = new NColorFillStyle(WebExamplesUtilities.RandomColor());
			}

			bar.Legend.Mode = SeriesLegendMode.DataPoints;
			bar.Values.Sort((DataSeriesSortOrder)SortOrderDropDownList.SelectedIndex);
		}
	}
}
