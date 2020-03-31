using Nevron.Chart;
using Nevron.GraphicsCore;
using System;
using System.Drawing;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NTernaryPointUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithEnumNames(PointShapeDropDownList, typeof(PointShape));
				DifferentColorsCheckBox.Checked = true;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Ternary Point Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			NTernaryChart ternaryChart = new NTernaryChart();
			nChartControl1.Panels.Add(ternaryChart);

			ConfigureAxis(ternaryChart.Axis(StandardAxis.TernaryA));
			ConfigureAxis(ternaryChart.Axis(StandardAxis.TernaryB));
			ConfigureAxis(ternaryChart.Axis(StandardAxis.TernaryC));

			NTernaryPointSeries point = new NTernaryPointSeries();
			ternaryChart.Series.Add(point);

			// setup point series
			point.Name = "Ternary Point Series";
			point.Shape = (PointShape)PointShapeDropDownList.SelectedIndex;

			Random rand = new Random();
			for (int i = 0; i < 20; i++)
			{
				// will be automatically normalized so that the sum of a, b, c value is 100
				double aValue = rand.Next(100);
				double bValue = rand.Next(100);
				double cValue = rand.Next(100);

				point.AValues.Add(aValue);
				point.BValues.Add(bValue);
				point.CValues.Add(cValue);
			}

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, ternaryChart, title, null);

			if (DifferentColorsCheckBox.Checked)
			{
				// apply style sheet
				NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
				styleSheet.Apply(nChartControl1.Document);
			}
			else
			{
				// apply style sheet
				NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
				styleSheet.Apply(nChartControl1.Document);
			}
		}

		private void ConfigureAxis(NAxis axis)
		{
			NLinearScaleConfigurator linearScale = axis.ScaleConfigurator as NLinearScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.FromArgb(25, Color.Beige)), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Ternary, true);
			linearScale.StripStyles.Add(stripStyle);

			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Ternary, true);
		}
	}
}