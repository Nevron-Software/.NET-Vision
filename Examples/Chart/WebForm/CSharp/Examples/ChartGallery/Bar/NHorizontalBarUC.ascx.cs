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
	public partial class NHorizontalBarUC : NExampleUC
	{
		protected NChart nChart;
		protected const int categoriesCount = 6;
	
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.Settings.JitterMode = JitterMode.Enabled;
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Horizontal Bar Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			nChart = nChartControl1.Charts[0];
			nChart.Enable3D = true;
			nChart.Height = 70;
			nChart.Width = 55;
			nChart.SetPredefinedChartStyle(PredefinedChartStyle.HorizontalLeft);
			nChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterRight);
			nChart.Axis(StandardAxis.Depth).Visible = false;

            // add interlace stripe to the Y axis
            NLinearScaleConfigurator linearScale = nChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };
            linearScale.StripStyles.Add(stripStyle);

			// add a bar series
			NBarSeries b1 = (NBarSeries)nChart.Series.Add(SeriesType.Bar);
			b1.MultiBarMode = MultiBarMode.Series;
			b1.Name = "Bar 1";
            b1.DataLabelStyle.Format = "<value>";
			b1.Values.AddRange(new double[] { 10, 27, 43, 71, 89, 93 });

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
			styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, nChart, title, null);

			// init form controls
			if (IsPostBack)
			{
				NBarSeries bar = (NBarSeries)nChart.Series[0];
				bar.BarShape = (BarShape)BarShapeDropDownList.SelectedIndex;

				if (PositiveDataCheckBox.Checked == true)
				{
					PositiveDataButton_Click(null, null);
				}
				else
				{
					PositiveAndNegativeDataButton_Click(null, null);
				}
			}
			else
			{
				WebExamplesUtilities.FillComboWithEnumValues(BarShapeDropDownList, typeof(BarShape));
				BarShapeDropDownList.SelectedIndex = 0;
			}
		}

		protected void PositiveDataButton_Click(object sender, EventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChart.Series[0];
			bar.Values.FillRandomRange(Random, categoriesCount, 10, 100);

			PositiveDataCheckBox.Checked = true;
		}

		protected void PositiveAndNegativeDataButton_Click(object sender, EventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChart.Series[0];
			bar.Values.FillRandomRange(Random, categoriesCount, -100, 100);

			PositiveDataCheckBox.Checked = false;
		}
	}
}
