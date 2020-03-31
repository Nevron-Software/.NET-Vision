using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NDateTimeStepLineUC : NExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("DateTime Step Line");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

            // add interlaced stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScaleConfigurator.StripStyles.Add(stripStyle);

            NDateTimeScaleConfigurator timeScaleConfigurator = new NDateTimeScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = timeScaleConfigurator;
			timeScaleConfigurator.LabelGenerationMode = LabelGenerationMode.Stagger2;
			timeScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			timeScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

			// setup step line series
			NStepLineSeries line = (NStepLineSeries)chart.Series.Add(SeriesType.StepLine);
			line.Name = "Step Line Series";
			line.InflateMargins = true;
			line.UseXValues = true;
			line.UseZValues = false;
			line.Legend.Mode = SeriesLegendMode.None;
			line.DataLabelStyle.Visible = false;
			line.BorderStyle.Width = new NLength(2, NGraphicsUnit.Pixel);
			line.BorderStyle.Color = Color.YellowGreen;
			line.FillStyle = new NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant2, Color.Green, Color.BlanchedAlmond);
			line.ShadowStyle.Type = ShadowType.Solid;
			line.ShadowStyle.Color = Color.FromArgb(15, 0, 0, 0);
			line.MarkerStyle.PointShape = PointShape.Cylinder;
			line.MarkerStyle.Width = new NLength(1.2f, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Height = new NLength(1.2f, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.BorderStyle.Width = new NLength(2, NGraphicsUnit.Pixel);
			line.MarkerStyle.BorderStyle.Color = Color.YellowGreen;

			// generate some random data
			Random random = new Random();
			int valuesCount = 10;

			GenreateYValues(valuesCount, random);
			GenreateXValues(valuesCount, random);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}

		private void GenreateYValues(int nCount, Random random)
		{
			NChart chart = nChartControl1.Charts[0];
			NStepLineSeries line = (NStepLineSeries)chart.Series[0];

			line.Values.Clear();

			for(int i = 0; i < nCount; i++)
			{
				line.Values.Add(Random.NextDouble() * 20);
			}
		}

		private void GenreateXValues(int nCount, Random random)
		{
			NChart chart = nChartControl1.Charts[0];
			NStepLineSeries line = (NStepLineSeries)chart.Series[0];

			line.XValues.Clear();

			DateTime dt = new DateTime(2005, 5, 24, 11, 0, 0);

			for(int i = 0; i < nCount; i++)
			{
				dt = dt.AddHours(12 + Random.NextDouble() * 60);

				line.XValues.Add(dt);
			}
		}
	}
}
