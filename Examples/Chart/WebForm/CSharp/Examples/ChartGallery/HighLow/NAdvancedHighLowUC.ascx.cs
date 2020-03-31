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
	public partial class NAdvancedHighLowUC : NExampleUC
	{
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				HighLabelTextBox.Text = "High";
				LowLabelTextBox.Text = "Low";
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("XY High-Low");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// configure chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			// setup X axis
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// setup Y axis
			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// add interlace stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Back, ChartWallType.Left };
			scaleY.StripStyles.Add(stripStyle);

			// create the series
			NHighLowSeries highLow = (NHighLowSeries)chart.Series.Add(SeriesType.HighLow);
			highLow.Name = "High-Low Series";
			highLow.DataLabelStyle.Format = "<high_label><low_label>";
			highLow.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(7);
			highLow.HighFillStyle = new NColorFillStyle(Color.LightSlateGray);
            highLow.LowFillStyle = new NColorFillStyle(Color.DarkOrange);
			highLow.ShadowStyle.Type = ShadowType.GaussianBlur;
			highLow.UseXValues = true;

			highLow.HighLabel = HighLabelTextBox.Text;
			highLow.LowLabel = LowLabelTextBox.Text;

			// fill values
			GenerateValuesY(highLow, 8);
			GenerateValuesX(highLow, 8);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}

		private void GenerateValuesY(NHighLowSeries highLow, int nCount)
		{
			double dPhase1 = Random.Next(5);
			double dPhase2 = dPhase1 + 1;

			highLow.HighValues.Clear();
			highLow.LowValues.Clear();

			for (int i = 0; i < nCount; i++)
			{
				double d1 = 10 + Math.Sin(dPhase1 + 0.8 * i) + 0.5 * Random.NextDouble();
				double d2 = 10 + Math.Cos(dPhase2 + 0.8 * i) + 0.5 * Random.NextDouble();

				highLow.HighValues.Add(d1);
				highLow.LowValues.Add(d2);
			}
		}
		private void GenerateValuesX(NHighLowSeries highLow, int nCount)
		{
			highLow.XValues.Clear();

			double dValue = (double)Random.Next(100);

			for (int i = 0; i < nCount; i++)
			{
				highLow.XValues.Add(dValue);

				dValue = dValue + Random.Next(5, 10);
			}
		}

	}
}
