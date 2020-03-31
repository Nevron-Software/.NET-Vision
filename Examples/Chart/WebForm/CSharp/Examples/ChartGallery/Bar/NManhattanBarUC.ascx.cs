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
	public partial class NManhattanBarUC : NExampleUC
	{
		protected NChart nChart;
		protected NBarSeries nBar1;
		protected NBarSeries nBar2;
		protected NBarSeries nBar3;

		protected void Page_Load(object sender, EventArgs e)
		{
			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Manhattan Bar Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			nChart = nChartControl1.Charts[0];
			nChart.Enable3D = true;
			nChart.Width = 70;
			nChart.Height = 40;
			nChart.Depth = 50;
			nChart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			nChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			// setup Y axis
			NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)nChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// add interlaced stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };
			linearScaleConfigurator.StripStyles.Add(stripStyle);

			// setup X axis
			NOrdinalScaleConfigurator ordinalScaleConfigurator = (NOrdinalScaleConfigurator)nChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			ordinalScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			ordinalScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Back, ChartWallType.Floor };

			// setup Z axis
			ordinalScaleConfigurator = (NOrdinalScaleConfigurator)nChart.Axis(StandardAxis.Depth).ScaleConfigurator;
			ordinalScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			ordinalScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Left, ChartWallType.Floor };
			ordinalScaleConfigurator.MajorTickMode = MajorTickMode.AutoMaxCount; 

			// add the first bar
			nBar1 = (NBarSeries)nChart.Series.Add(SeriesType.Bar);
			nBar1.MultiBarMode = MultiBarMode.Series;
			nBar1.Name = "Bar1";
			nBar1.DataLabelStyle.Visible = false;
			nBar1.Legend.TextStyle.FontStyle.EmSize = new NLength(8);

			// add the second bar
			nBar2 = (NBarSeries)nChart.Series.Add(SeriesType.Bar);
			nBar2.MultiBarMode = MultiBarMode.Series;
			nBar2.Name = "Bar2";
			nBar2.DataLabelStyle.Visible = false;
			nBar2.Legend.TextStyle.FontStyle.EmSize = new NLength(8);

			// add the third bar
			nBar3 = (NBarSeries)nChart.Series.Add(SeriesType.Bar);
			nBar3.MultiBarMode = MultiBarMode.Series;
			nBar3.Name = "Bar3";
			nBar3.DataLabelStyle.Visible = false;
			nBar3.Legend.TextStyle.FontStyle.EmSize = new NLength(8);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, nChart, title, nChartControl1.Legends[0]);

			if (IsPostBack)
			{
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
				PositiveDataButton_Click(null, null);
			}

			this.PositiveDataButton.Click += new EventHandler(this.PositiveDataButton_Click);
			this.PositiveAndNegativeDataButton.Click += new EventHandler(this.PositiveAndNegativeDataButton_Click);
		}

		private void PositiveDataButton_Click(object sender, EventArgs e)
		{
			nBar1.Values.FillRandomRange(Random, 5, 10, 40);
			nBar2.Values.FillRandomRange(Random, 5, 30, 60);
			nBar3.Values.FillRandomRange(Random, 5, 50, 80);
			PositiveDataCheckBox.Checked = true;
		}

		private void PositiveAndNegativeDataButton_Click(object sender, EventArgs e)
		{
			nBar1.Values.FillRandomRange(Random, 5, -30, 30);
			nBar2.Values.FillRandomRange(Random, 5, -50, 50);
			nBar3.Values.FillRandomRange(Random, 5, -70, 70);
			PositiveDataCheckBox.Checked = false;
		}
	}
}