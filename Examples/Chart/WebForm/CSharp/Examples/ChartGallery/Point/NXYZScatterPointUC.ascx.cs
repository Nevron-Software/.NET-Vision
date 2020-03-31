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
	public partial class NXYZScatterPointUC : NExampleUC
	{
			
		protected void Page_Load(object sender, EventArgs e)
		{
			// switch to OpenGL rendering
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XYZ Scatter Point Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 50;
			chart.Depth = 50;
			chart.Height = 50;
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			chart.Projection.Type = ProjectionType.Perspective;
			chart.Projection.Elevation = 25;
			chart.Projection.Rotation = -18;

			// setup Y axis
			NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScaleConfigurator.RoundToTickMin = AxesRoundToTickCheckBox.Checked;
			linearScaleConfigurator.RoundToTickMax = AxesRoundToTickCheckBox.Checked;
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8);

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScaleConfigurator.StripStyles.Add(stripStyle);

			// setup X axis
			linearScaleConfigurator = new NLinearScaleConfigurator();
			linearScaleConfigurator.RoundToTickMin = AxesRoundToTickCheckBox.Checked;
			linearScaleConfigurator.RoundToTickMax = AxesRoundToTickCheckBox.Checked;
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8);
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Back, ChartWallType.Floor };

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleConfigurator;

			// setup Z axis
			linearScaleConfigurator = new NLinearScaleConfigurator();
			linearScaleConfigurator.RoundToTickMin = AxesRoundToTickCheckBox.Checked;
			linearScaleConfigurator.RoundToTickMax = AxesRoundToTickCheckBox.Checked;
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8);
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Left, ChartWallType.Floor };
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScaleConfigurator;

			// setup point series
			NPointSeries point = (NPointSeries)chart.Series.Add(SeriesType.Point);
			point.Name = "Point1";
			point.InflateMargins = InflateMarginsCheckBox.Checked;
			point.DataLabelStyle.Visible = false;
			point.Legend.Mode = SeriesLegendMode.None;
			point.PointShape = PointShape.Bar;
			point.BorderStyle.Color = Color.AliceBlue;
			point.Size = new NLength(3, NRelativeUnit.ParentPercentage);
			point.UseXValues = true;
			point.UseZValues = true;

			// init the chart with some random values
			point.Values.FillRandomRange(Random, 10, -50, 50);
			point.XValues.FillRandomRange(Random, 10, -50, 50);
			point.ZValues.FillRandomRange(Random, 10, -50, 50);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}
	}
}
