using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;
using Nevron.SmartShapes;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NMarkersUC : NExampleUC
	{
		protected System.Web.UI.WebControls.DropDownList MarkerStyleDropDown;
		protected System.Web.UI.WebControls.DropDownList Marker3StyleDropDown;

		protected void Page_Load(object sender, EventArgs e)
		{
			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Series Markers");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			// add interlaced stripe to the Y axis
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			stripStyle.Interlaced = true;
			((NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator).StripStyles.Add(stripStyle);

			chart.Axis(StandardAxis.Depth).Visible = false;

			NLineSeries line = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line.LineSegmentShape = LineSegmentShape.Tape;
			line.InflateMargins = true;
			line.DepthPercent = 50;
			line.Legend.Mode = SeriesLegendMode.DataPoints;
			line.Name = "Line Series";
			line.Values.FillRandom(Random, 6);
			line.DataLabelStyle.Visible = false;
			line.ShadowStyle.Type = ShadowType.GaussianBlur;
			line.ShadowStyle.Offset = new NPointL(2, 2);
			line.ShadowStyle.Color = Color.FromArgb(88, 0, 0, 0);
			line.ShadowStyle.FadeLength = new NLength(5);
			line.MarkerStyle.Visible = true;

			NMarkerStyle marker = new NMarkerStyle();
			marker.FillStyle = new NColorFillStyle(Color.Red);
			marker.PointShape = PointShape.Custom;

			// Create a custom shape for this marker
			N2DSmartShapeFactory factory = new N2DSmartShapeFactory(new NColorFillStyle(Color.Red), new NStrokeStyle(1.0f, Color.Black), null);
			marker.CustomShape = factory.CreateShape(SmartShape2D.Trapezoid);
			marker.Visible = true;
			line.MarkerStyles[3] = marker;

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);
		}
	}
}
