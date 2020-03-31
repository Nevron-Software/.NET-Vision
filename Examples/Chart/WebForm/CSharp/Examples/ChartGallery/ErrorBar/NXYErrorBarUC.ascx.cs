using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NXYErrorBarUC : NExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XY Error Bar");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			// setup Y axis
			NAxis axisY = chart.Axis(StandardAxis.PrimaryY);
			NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)axisY.ScaleConfigurator;
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

            // add interlaced stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScaleConfigurator.StripStyles.Add(stripStyle);

			// setup X axis
			linearScaleConfigurator = new NLinearScaleConfigurator();
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleConfigurator;

			// setup error bar series
			NErrorBarSeries series = (NErrorBarSeries)chart.Series.Add(SeriesType.ErrorBar);
			series.DataLabelStyle.Visible = false;
			series.BorderStyle = new NStrokeStyle(GreyBlue);
			series.MarkerStyle.Visible = true;
			series.MarkerStyle.AutoDepth = false;
			series.MarkerStyle.FillStyle = new NColorFillStyle(DarkOrange);
			series.MarkerStyle.BorderStyle = new NStrokeStyle(GreyBlue);
			series.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			series.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			series.MarkerStyle.Depth = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			series.UseXValues = true;

			GenerateData(series);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);

			if (!IsPostBack)
			{
				ShowUpperYErrorCheck.Checked = series.ShowUpperErrorY;
				ShowLowerYErrorCheck.Checked = series.ShowLowerErrorY;
				ShowUpperXErrorCheck.Checked = series.ShowUpperErrorX;
				ShowLowerXErrorCheck.Checked = series.ShowLowerErrorX;
				InflateMarginsCheck.Checked = series.InflateMargins;
				RoundToTickCheck.Checked = true;
			}
			else
			{
				series.ShowUpperErrorY = ShowUpperYErrorCheck.Checked;
				series.ShowLowerErrorY = ShowLowerYErrorCheck.Checked;
				series.ShowUpperErrorX = ShowUpperXErrorCheck.Checked;
				series.ShowLowerErrorX = ShowLowerXErrorCheck.Checked;
				series.InflateMargins = InflateMarginsCheck.Checked;

				NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)axisY.ScaleConfigurator;
				linearScale.RoundToTickMin = RoundToTickCheck.Checked;
				linearScale.RoundToTickMax = RoundToTickCheck.Checked;
			}
		}

		private void GenerateData(NErrorBarSeries series)
		{
			series.ClearDataPoints();

			double y;
			double x = 50.0;
			Random random = new Random();

			for(int i = 0; i < 15; i++)
			{
				y = 20 + random.NextDouble() * 30;
				x += 2.0 + random.NextDouble() * 2;

				series.Values.Add(y);
				series.LowerErrorsY.Add(1 + random.NextDouble());
				series.UpperErrorsY.Add(1 + random.NextDouble());

				series.XValues.Add(x);
				series.LowerErrorsX.Add(1 + random.NextDouble());
				series.UpperErrorsX.Add(1 + random.NextDouble());
			}
		}
	}
}
