using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NDateTimeBarUC : NExampleUC
	{
		private const int nValuesCount = 10;

		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Date Time Bars");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];

			// setup Y axis
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

            // add interlace stripe to the Y axis
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
            linearScale.StripStyles.Add(stripStyle);

			// setup X axis
			NDateTimeScaleConfigurator timeScale = new NDateTimeScaleConfigurator();
			timeScale.MaxTickCount = 5;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = timeScale;

			// setup bar series
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Name = "Bar Series";
			bar.InflateMargins = true;
			bar.UseXValues = true;
			bar.UseZValues = false;
			bar.DataLabelStyle.Visible = false;
			bar.ShadowStyle.Type = ShadowType.Solid;
			bar.ShadowStyle.Color = Color.FromArgb(30, 0, 0, 0);

			GenreateYValues(nValuesCount);
			GenreateXValues(nValuesCount);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}

		private void GenreateYValues(int nCount)
		{
			NChart chart = nChartControl1.Charts[0];
			NBarSeries bar = (NBarSeries)chart.Series[0];

			bar.Values.Clear();

			for(int i = 0; i < nCount; i++)
			{
				bar.Values.Add(Random.NextDouble() * 20);
			}
		}

		private void GenreateXValues(int nCount)
		{
			NChart chart = nChartControl1.Charts[0];
			NBarSeries bar = (NBarSeries)chart.Series[0];

			bar.XValues.Clear();

			DateTime dt = new DateTime(2005, 5, 24, 11, 0, 0);

			for(int i = 0; i < nCount; i++)
			{
				dt = dt.AddHours(12 + Random.NextDouble() * 60);
				bar.XValues.Add(dt);
			}
		}
	}
}
