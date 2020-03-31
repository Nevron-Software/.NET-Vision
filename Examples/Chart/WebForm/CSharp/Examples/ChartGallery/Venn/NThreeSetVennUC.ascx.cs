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
	public partial class NThreeSetVennUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Three Set Venn");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			NVennChart chart = new NVennChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(chart);

			NVennSeries venn = (NVennSeries)chart.Series.Add(SeriesType.Venn);

			ThreeSetVenn(venn);
			ThreeSetVennLabels(venn);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}

		void ThreeSetVenn(NVennSeries venn)
		{
			const int nSetCount = 3;
			const float fStartAngle = -((float)Math.PI / 2);
			const float fScale = 14;
			const float fCenterX = 0;
			const float fCenterY = 0;
			float fIncrementAngle = (float)(2 * Math.PI / nSetCount);

			venn.ClearContours();

			for(int i = 0; i < nSetCount; i++)
			{
				float fAngle = fStartAngle + i * fIncrementAngle;
				float x = (float)Math.Round(fCenterX + Math.Cos(fAngle) * fScale, 1);
				float y = (float)Math.Round(fCenterY + Math.Sin(fAngle) * fScale, 1);

				venn.AddVennContour(VennShape.Ellipse, new NPointF(x, y), new NSizeF(50, 50), 0, i);
			}
		}

		void ThreeSetVennLabels(NVennSeries venn)
		{
			string[] s1 = new string[]{ "A", "B", "C" };
			string[] s2 = new string[]{ "BC", "AC", "AB" };

			venn.ClearLabels();
			venn.LabelsTextStyle.FontStyle = new NFontStyle("Verdana", 8);

			// add the center label
			venn.AddLabel("ABC", new NPointF(0, 0));

			// add outer labels
			NPointF[] points = CalculateLabelPositions(3, 30, (float)(-Math.PI/2));
			for(int i = 0; i < 3; i++)
			{
				venn.AddLabel(s1[i], points[i]);
			}

			// add middle labels
			points = CalculateLabelPositions(3, 17, (float)Math.PI/2);
			for(int i = 0; i < 3; i++)
			{
				venn.AddLabel(s2[i], points[i]);
			}
		}

		NPointF[] CalculateLabelPositions(int nSetCount, float fRadius, float fStartAngle)
		{
			float fIncrementAngle = (float)(2 * Math.PI / nSetCount);
			float fCenterX = 0;
			float fCenterY = 0;

			NPointF[] points = new NPointF[nSetCount];

			for(int i = 0; i < nSetCount; i++)
			{
				float fAngle = fStartAngle + i * fIncrementAngle;
				float x = (float)Math.Round(fCenterX + Math.Cos(fAngle) * fRadius, 1);
				float y = (float)Math.Round(fCenterY + Math.Sin(fAngle) * fRadius, 1);

				points[i] = new NPointF(x, y);
			}

			return points;
		}
	}
}
