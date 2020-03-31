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
	public partial class NFourSetVennUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Four Set Venn");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			NVennChart chart = new NVennChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(chart);

			NVennSeries venn = (NVennSeries)chart.Series.Add(SeriesType.Venn);

			FourSetVenn(venn);
			FourSetVennLabels(venn);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}

		void FourSetVenn(NVennSeries venn)
		{
			venn.ClearContours();

			venn.AddVennContour(VennShape.Ellipse, new NPointF(-12.5f, -10f), new NSizeF(60, 35), 135, 0);
			venn.AddVennContour(VennShape.Ellipse, new NPointF(12.5f, -10f), new NSizeF(60, 35), 45, 1);
			venn.AddVennContour(VennShape.Ellipse, new NPointF(-2.5f, 5), new NSizeF(60, 35), 135, 2);
			venn.AddVennContour(VennShape.Ellipse, new NPointF(2.5f, 5), new NSizeF(60, 35), 45, 3);
		}

		void FourSetVennLabels(NVennSeries venn)
		{
			string centreLabel = "ABCD";
			string[] s1 = new string[]{ "A", "B", "C", "D" };
			string[] s2 = new string[]{ "AC", "CD", "BD", "AD", "AB", "BC" };
			string[] s3 = new string[]{ "ACD", "BCD", "ABD", "ABC"};

			venn.ClearLabels();
			venn.LabelsTextStyle.FontStyle = new NFontStyle("Verdana", 8);

			// add centre label
			venn.AddLabel(centreLabel, new NPointF(0, -8));

			// add layer 1 labels
			venn.AddLabel(s1[0], new NPointF(-12.5f - 15f, -10f + 10f));
			venn.AddLabel(s1[1], new NPointF(12.5f + 15f, -10f + 10f));
			venn.AddLabel(s1[2], new NPointF(-2.5f - 15f, 5f + 16f));
			venn.AddLabel(s1[3], new NPointF(2.5f + 15f, 5f + 16f));

			// add layer 2 labels
			venn.AddLabel(s2[0], new NPointF(-12.5f - 9f, -10f + 19f));
			venn.AddLabel(s2[1], new NPointF(0, -10f + 24f));
			venn.AddLabel(s2[2], new NPointF(12.5f + 9f, -10f + 19f));
			venn.AddLabel(s2[3], new NPointF(2.5f - 18f, 5f - 18f));
			venn.AddLabel(s2[4], new NPointF(0, -10f - 16f));
			venn.AddLabel(s2[5], new NPointF(-2.5f + 18f, 5f - 18f));

			// add layer 3 labels
			venn.AddLabel(s3[0], new NPointF(-12.5f + 1f, -10f + 10f));
			venn.AddLabel(s3[1], new NPointF(12.5f - 1f, -10f + 10f));
			venn.AddLabel(s3[2], new NPointF(2.5f - 10f, 5f - 21.5f));
			venn.AddLabel(s3[3], new NPointF(-2.5f + 10f, 5f - 21.5f));
		}
	}
}
