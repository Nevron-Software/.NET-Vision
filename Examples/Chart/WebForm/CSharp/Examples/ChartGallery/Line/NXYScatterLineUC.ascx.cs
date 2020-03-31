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
	public partial class NXYScatterLineUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XY Scatter Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			// setup Y axis
			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// setup X axis
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Floor };
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// add interlace stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			scaleX.StripStyles.Add(stripStyle);

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// add the line
			NLineSeries line = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line.Name = "Line Series";
			line.LineSegmentShape = LineSegmentShape.Line;
			line.InflateMargins = true;
			line.DataLabelStyle.Visible = false;
			line.MarkerStyle.Visible = true;
			line.MarkerStyle.PointShape = PointShape.Cylinder;
			line.Legend.Mode = SeriesLegendMode.None;
			// instruct the series to use X values
			line.UseXValues = true;

			// add XY data points
			Random random = new Random();
			line.AddDataPoint(new NDataPoint(15 + random.Next(10), 10));
			line.AddDataPoint(new NDataPoint(25 + random.Next(10), 23));
			line.AddDataPoint(new NDataPoint(45 + random.Next(10), 12));
			line.AddDataPoint(new NDataPoint(55 + random.Next(10), 21));
			line.AddDataPoint(new NDataPoint(61 + random.Next(10), 16));
			line.AddDataPoint(new NDataPoint(67 + random.Next(10), 19));
			line.AddDataPoint(new NDataPoint(72 + random.Next(10), 11));

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}
	}
}
