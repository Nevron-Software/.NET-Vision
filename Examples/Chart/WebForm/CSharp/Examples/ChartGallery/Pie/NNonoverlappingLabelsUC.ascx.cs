using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NNonoverlappingLabelsUC : NExampleUC
	{
		private NPieSeries m_Pie;

		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.Settings.JitterMode = JitterMode.Enabled;
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Nonoverlapping Pie Labels");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(
                new NLength(50, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NPieChart pieChart = new NPieChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(pieChart);

			pieChart.Enable3D = true;
			pieChart.BoundsMode = BoundsMode.Fit;
			pieChart.Location = new NPointL(
				new NLength(5, NRelativeUnit.ParentPercentage),
				new NLength(10, NRelativeUnit.ParentPercentage));
			pieChart.Size = new NSizeL(
				new NLength(90, NRelativeUnit.ParentPercentage),
				new NLength(87, NRelativeUnit.ParentPercentage));
			pieChart.ClockwiseDirection = clockwiseCheckBox.Checked;
			pieChart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalElevated);
            pieChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);

			// setup pie series
			m_Pie = (NPieSeries)pieChart.Series.Add(SeriesType.Pie);
			m_Pie.LabelMode = PieLabelMode.SpiderNoOverlap;
			m_Pie.DataLabelStyle.Format = "<label>\n<percent>";
			m_Pie.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(8, NGraphicsUnit.Point);
			m_Pie.Values.ValueFormatter = new NNumericValueFormatter("0.##");
			m_Pie.BorderStyle.Color = Color.White;
            m_Pie.PieStyle = PieStyle.SmoothEdgePie;
			

			double[] arrValues = { 4.17, 7.19, 5.62, 7.91, 15.28, 0.97, 1.3, 1.12, 8.54, 9.84 };

			for (int i = 0; i < arrValues.Length; i++)
			{
				m_Pie.Values.Add(arrValues[i]);
			}

			SetTexts();

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.BrightMultiColor);
			styleSheet.Apply(nChartControl1.Document);
		}

		private void GenerateRandomValues(int count)
		{
			m_Pie.Values.Clear();

			for (int i = 0; i < count; i++)
			{
				m_Pie.Values.Add(Random.NextDouble() * 10);
			}
		}

		private void SetTexts()
		{
			string[] arrTexts =
			{
				"Athletics",
				"Basketball",
				"Boxing",
				"Cycling",
				"Football",
				"Golf",
				"Handball",
				"Ice Hockey",
				"Motorsports",
				"Rugby",
			};

			for (int i = 0; i < arrTexts.Length; i++)
			{
				m_Pie.Labels.Add(arrTexts[i]);
			}
		}

		protected void ChangeDataButton_Click(object sender, EventArgs e)
		{
			GenerateRandomValues(10);
		}
	}
}
