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
	public partial class NTwoSetVennUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Two Set Venn");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			NVennChart chart = new NVennChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(chart);

			NVennSeries venn = (NVennSeries)chart.Series.Add(SeriesType.Venn);

			TwoSetVenn(venn);
			TwoSetVennLabels(venn);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}

		void TwoSetVenn(NVennSeries venn)
		{
			venn.ClearContours();

			venn.AddVennContour(VennShape.Ellipse, new NPointF(-15, 0), new NSizeF(50, 50), 0, 0);
			venn.AddVennContour(VennShape.Ellipse, new NPointF(15, 0), new NSizeF(50, 50), 0, 1);
		}

		void TwoSetVennLabels(NVennSeries venn)
		{
			string[] s1 = new string[]{ "A", "AB", "B"};

			venn.ClearLabels();
			venn.LabelsTextStyle.FontStyle = new NFontStyle("Verdana", 8);

			// add labels
			venn.AddLabel(s1[0], new NPointF(-25, 0));
			venn.AddLabel(s1[1], new NPointF(0, 0));
			venn.AddLabel(s1[2], new NPointF(25, 0));
		}
	}
}
