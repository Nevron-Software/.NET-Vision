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
	public partial class NFiveSetVennUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Five Set Venn");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			NVennChart chart = new NVennChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(chart);

			NVennSeries venn = (NVennSeries)chart.Series.Add(SeriesType.Venn);

			FiveSetVenn(venn);
			FiveSetVennLabels(venn);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}

		void FiveSetVenn(NVennSeries venn)
		{
			const int nSetCount = 5;
			const float fStartAngle = -((float)Math.PI / 2);
			const float fScale = 7;
			const float fCenterX = 0;
			const float fCenterY = 0;
			float fIncrementAngle = (float)(2 * Math.PI / nSetCount);

			venn.ClearContours();

			for(int i = 0; i < nSetCount; i++)
			{
				float fAngle = fStartAngle + i * fIncrementAngle;
				float x = (float)Math.Round(fCenterX + Math.Cos(fAngle) * fScale, 1);
				float y = (float)Math.Round(fCenterY + Math.Sin(fAngle) * fScale, 1);

				float fVennAngle = Rad2Degree(fAngle - 2 * fIncrementAngle);
				venn.AddVennContour(VennShape.Ellipse, new NPointF(x, y), new NSizeF(70, 35), fVennAngle, i);
			}
		}

		void FiveSetVennLabels(NVennSeries venn)
		{
			const int nCount = 5;
			string[] s1 = new string[]{ "A", "B", "C", "D", "E" };
			string[] s2 = new string[]{ "AC", "BD", "CE", "DA", "EB" };
			string[] s3 = new string[]{ "ABCD", "BCDE", "CDEA", "DEAB", "EABC" };

			venn.ClearLabels();
			venn.LabelsTextStyle.FontStyle = new NFontStyle("Verdana", 8);

			// add the center label
			venn.AddLabel("ABCDE", new NPointF(0, 0));

			// add layer 1 labels, angle in radians
			NPointF[] points = CalculateLabelPositions(nCount, 35, -1.1f);
			for(int i = 0; i < nCount; i++)
			{
				venn.AddLabel(s1[i], points[i]);
			}

			// add layer 2 labels, angle in radians
			points = CalculateLabelPositions(nCount, 25, -1.3f);
			for(int i = 0; i < nCount; i++)
			{
				venn.AddLabel(s2[i], points[i]);
			}

			// add layer 4 labels, angle in radians
			points = CalculateLabelPositions(nCount, 17.5f, -0.5f);
			for(int i = 0; i < nCount; i++)
			{
				venn.AddLabel(s3[i], points[i]);
			}
		}

		NPointF[] CalculateLabelPositions(int nSetCount, float fRadius, float fStartAngleInRadians)
		{
			float fIncrementAngle = (float)(2 * Math.PI / nSetCount);
			float fCenterX = 0;
			float fCenterY = 0;

			NPointF[] points = new NPointF[nSetCount];

			for(int i = 0; i < nSetCount; i++)
			{
				float fAngle = fStartAngleInRadians + i * fIncrementAngle;
				float x = (float)Math.Round(fCenterX + Math.Cos(fAngle) * fRadius, 1);
				float y = (float)Math.Round(fCenterY + Math.Sin(fAngle) * fRadius, 1);

				points[i] = new NPointF(x, y);
			}

			return points;
		}

		float Rad2Degree(float fRadians)
		{
			return (float)(((fRadians) * 180.0f) / (3.1415926535f));
		}

	}
}
