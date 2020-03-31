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
	public partial class NEvaluatingUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				FunctionDropDownList.Items.Add("MIN");
				FunctionDropDownList.Items.Add("MAX");
				FunctionDropDownList.Items.Add("AVE");
				FunctionDropDownList.Items.Add("SUM");
				FunctionDropDownList.Items.Add("ABSSUM");
				FunctionDropDownList.Items.Add("FIRST");
				FunctionDropDownList.Items.Add("LAST");
				FunctionDropDownList.SelectedIndex = 0;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// add header
			NLabel header = nChartControl1.Labels.AddHeader("Evaluating Data");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.TextStyle.FillStyle = new NColorFillStyle(Color.FromArgb(60, 90, 108));
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));			

			// configure the legend
			nChartControl1.Legends.Clear();

			// setup the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Location = new NPointL(
				new NLength(5, NRelativeUnit.ParentPercentage),
				new NLength(15, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(90, NRelativeUnit.ParentPercentage),
				new NLength(80, NRelativeUnit.ParentPercentage));

			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Values.FillRandom(Random, 10);

			NDataSeriesSubset subset = new NDataSeriesSubset();
			subset.AddRange(0, 9);

			string function = FunctionDropDownList.SelectedItem.Text;
			double result = bar.Values.Evaluate(function, subset);

			ResultTextBox.Text = result.ToString();
		}
	}
}
