using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NScatterAreaUC : NExampleUC
	{

		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XY Area");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Axis(StandardAxis.Depth).Visible = false; 

			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
            chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;

			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
            linearScale.StripStyles.Add(stripStyle);

			// add an area series
			NAreaSeries area = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			area.UseXValues = true;
			area.DataLabelStyle.Visible = false;
			area.MarkerStyle.Visible = true;
			area.MarkerStyle.Width = new NLength(1.6f, NRelativeUnit.ParentPercentage);
			area.MarkerStyle.Height = new NLength(1.6f, NRelativeUnit.ParentPercentage);
			area.MarkerStyle.PointShape = PointShape.Cylinder;
			area.MarkerStyle.BorderStyle.Color = DarkOrange;
			area.MarkerStyle.FillStyle = new NColorFillStyle(DarkOrange);
			area.FillStyle = new NColorFillStyle(Red);
			area.BorderStyle.Color = DarkOrange;
			area.DropLines = DropLinesCheckBox.Checked;

			// add random values
			double currentX = Random.NextDouble() * 10;

			for (int i = 0; i < 10; i++)
			{
				area.Values.Add(0.6 + Random.NextDouble());
				area.XValues.Add(currentX);

				currentX += 2.0 + Random.NextDouble() * 10;
			}

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}
	}
}
