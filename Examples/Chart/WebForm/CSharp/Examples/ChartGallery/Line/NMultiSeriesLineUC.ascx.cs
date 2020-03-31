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
	public partial class NMultiSeriesLineUC : NExampleUC
	{

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithPercents(LineDepthDropDownList, 10);
				LineDepthDropDownList.SelectedIndex = 3;
            }

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;

			// set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Multi Series Line");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 70;
			chart.Height = 30;
			chart.Depth = 50;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

            // add interlace stripe
            NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			// setup X axis
			NOrdinalScaleConfigurator ordinalScaleConfigurator = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			ordinalScaleConfigurator.DisplayDataPointsBetweenTicks = false;
			ordinalScaleConfigurator.MajorTickMode = MajorTickMode.AutoMaxCount;
			ordinalScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			ordinalScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Floor };

			// add the first line
			NLineSeries line1 = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line1.MultiLineMode = MultiLineMode.Series;
			line1.LineSegmentShape = LineSegmentShape.Tape;
			line1.Legend.TextStyle.FontStyle.EmSize = new NLength(8);
			line1.DataLabelStyle.Visible = false;
			line1.Name = "Line1";

			// add the second line
			NLineSeries line2 = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line2.MultiLineMode = MultiLineMode.Series;
			line2.LineSegmentShape = LineSegmentShape.Tape;
			line2.Legend.TextStyle.FontStyle.EmSize = new NLength(8);
			line2.DataLabelStyle.Visible = false;
			line2.Name = "Line2";

			// add the third line
			NLineSeries line3 = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line3.MultiLineMode = MultiLineMode.Series;
			line3.LineSegmentShape = LineSegmentShape.Tape;
			line3.Legend.TextStyle.FontStyle.EmSize = new NLength(8);
			line3.DataLabelStyle.Visible = false;
			line3.Name = "Line3";

			// fill with random data
			line1.Values.FillRandom(Random, 7);
			line2.Values.FillRandom(Random, 7);
			line3.Values.FillRandom(Random, 7);

			line1.DepthPercent = LineDepthDropDownList.SelectedIndex * 10;
			line2.DepthPercent = LineDepthDropDownList.SelectedIndex * 10;		
			line3.DepthPercent = LineDepthDropDownList.SelectedIndex * 10;

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);
		}
	}
}
