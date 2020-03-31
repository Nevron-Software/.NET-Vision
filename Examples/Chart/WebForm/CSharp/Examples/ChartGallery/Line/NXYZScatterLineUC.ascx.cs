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
	public partial class NXYZScatterLineUC : NExampleUC
	{
	
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XYZ Scatter Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 50;
			chart.Height = 50;
			chart.Depth = 50;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			// setup Y axis
			NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScaleConfigurator.StripStyles.Add(stripStyle);

			// setup X axis
			linearScaleConfigurator = new NLinearScaleConfigurator();
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Back, ChartWallType.Floor };
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleConfigurator;

			// setup Z axis
			linearScaleConfigurator = new NLinearScaleConfigurator();
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Left, ChartWallType.Floor };
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScaleConfigurator;

			// add the line
			NLineSeries line = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line.LineSegmentShape = LineSegmentShape.Line;
			line.DataLabelStyle.Visible = false;
			line.BorderStyle.Color = DarkOrange;
			line.InflateMargins = true;
			line.MarkerStyle.Visible = true;
			line.MarkerStyle.FillStyle = new NColorFillStyle(Red);
			line.MarkerStyle.BorderStyle = new NStrokeStyle(DarkOrange);
			line.Name = "Line Series";
			line.Legend.Mode = SeriesLegendMode.None;

			// add xy values
			line.Values.Add(10);
			line.Values.Add(23);
			line.Values.Add(12);
			line.Values.Add(24);
			line.Values.Add(16);

			// instruct the chart to use them
			line.UseXValues = true;
			line.UseZValues = true;

			line.XValues.Add((double)Random.Next(10));
			for (int i = 1; i < line.Values.Count; i++)
			{
				line.XValues.Add((double)line.XValues[i - 1] + Random.Next(1,10));
			}

			line.ZValues.Add((double)Random.Next(10));
			for (int i = 1; i < line.Values.Count; i++)
			{
				line.ZValues.Add((double)line.ZValues[i - 1] + Random.Next(1,10));
			}

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}
	}
}
