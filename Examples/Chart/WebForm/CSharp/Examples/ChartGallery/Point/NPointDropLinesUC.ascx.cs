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
	public partial class NPointDropLines2DUC : NExampleUC
	{
		protected CheckBox InflateMarginsCheckBoxBox;
		protected CheckBox LeftAxisLeftAxisRoundToTickCheckBoxBox;
		protected CheckBox DifferentColorsCheckBoxBox;
		protected CheckBox ShowDataLabelsCheckBoxCheckBox;

		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Point Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = Enable3DCheckBox.Checked;
			chart.BoundsMode = BoundsMode.Stretch;

			// add interlace stripe
			NLinearScaleConfigurator yScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
			yScale.StripStyles.Add(stripStyle);

			// hide the depth axis
			chart.Axis(StandardAxis.Depth).Visible = false;

			// setup point series
			NPointSeries point = (NPointSeries)chart.Series.Add(SeriesType.Point);
			point.Name = "Point Series";
			point.DataLabelStyle.Visible = false;
			point.InflateMargins = true;

			point.AddDataPoint(new NDataPoint(23, "A"));
			point.AddDataPoint(new NDataPoint(67, "B"));
			point.AddDataPoint(new NDataPoint(47, "C"));
			point.AddDataPoint(new NDataPoint(12, "D"));
			point.AddDataPoint(new NDataPoint(56, "E"));
			point.AddDataPoint(new NDataPoint(78, "F"));

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);

			point.ShowVerticalDropLines = ShowVerticalDropLinesCheckBox.Checked;
			point.ShowHorizontalDropLines = ShowHorizontalDropLinesCheckBox.Checked;
		}
	}
}