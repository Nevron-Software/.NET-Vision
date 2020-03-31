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
	public partial class NXYZScatterBubbleUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
            nChartControl1.Settings.JitterMode = JitterMode.Enabled;

            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XYZ Scatter Bubble Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.Width = 60;
			chart.Height = 60;
			chart.Depth = 60;

			// setup Y axis
			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			scaleY.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8);

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
			scaleY.StripStyles.Add(stripStyle);

			// setup X axis
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			scaleX.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8);
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Floor };
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// setup Z axis
			NLinearScaleConfigurator scaleZ = new NLinearScaleConfigurator();
			scaleZ.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			scaleZ.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8);
			scaleZ.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Left, ChartWallType.Floor };
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ;

			// setup bubble series
			NBubbleSeries bubble = (NBubbleSeries)chart.Series.Add(SeriesType.Bubble);
			bubble.InflateMargins = true;
			bubble.DataLabelStyle.Visible = false;
			bubble.Legend.Mode = SeriesLegendMode.DataPoints;
			bubble.Legend.Format = "<label>";
			bubble.BubbleShape = PointShape.Sphere;
			bubble.UseXValues = true;
			bubble.UseZValues = true;

			GenerateData();

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);
		}

		void GenerateData()
		{
			NBubbleSeries bubble = (NBubbleSeries)nChartControl1.Charts[0].Series[0];

			bubble.Values.Clear();
			bubble.XValues.Clear();
			bubble.ZValues.Clear();
			bubble.Sizes.Clear();
			bubble.Labels.Clear();

			for(int i = 0; i < 4; i++)
			{
				bubble.Values.Add(Random.NextDouble() * 5);
				bubble.XValues.Add(Random.NextDouble() * 5);
				bubble.ZValues.Add(Random.NextDouble() * 5);
				bubble.Sizes.Add(Random.NextDouble());
				bubble.Labels.Add("Item " + (i + 1).ToString());
			}
		}
	}
}
