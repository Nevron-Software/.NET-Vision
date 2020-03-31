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
	public partial class NOverlappedLineUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
            nChartControl1.Settings.JitterMode = JitterMode.Enabled;

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Overlapped Line");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
            chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
            chart.Axis(StandardAxis.Depth).Visible = false;

			NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScaleConfigurator.MajorGridStyle.LineStyle.Color = Color.LightGray;

            // add interlace stripe
            NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScaleConfigurator.StripStyles.Add(stripStyle);

			linearScaleConfigurator = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleConfigurator;

			// setup series
			NLineSeries line1 = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line1.Name = "Line 1";
			line1.MultiLineMode = MultiLineMode.Series;
            line1.LineSegmentShape = LineSegmentShape.Tape;
			line1.DataLabelStyle.Visible = false;

			NLineSeries line2 = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line2.Name = "Line 2";
			line2.MultiLineMode = MultiLineMode.Overlapped;
            line2.LineSegmentShape = LineSegmentShape.Tape;
			line2.DataLabelStyle.Visible = false;

			NLineSeries line3 = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line3.Name = "Line 3";
			line3.MultiLineMode = MultiLineMode.Overlapped;
            line3.LineSegmentShape = LineSegmentShape.Tape;
			line3.DataLabelStyle.Visible = false;

			for(int i = 0; i < 50; i++)
			{
				double x = (i / 6.0);
				line1.Values.Add(0.5 + Math.Sin(x) / 2.0);
				line2.Values.Add(0.5 + Math.Cos(x) / 4.0);
				line3.Values.Add(Math.Cos(x) * Math.Sin(x) / 5.0  + Random.NextDouble() / 8.0);
			}

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);
		}
	}
}
