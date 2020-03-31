using System;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Nevron.GraphicsCore;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NRange3DUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithEnumValues(ShapeDropDownList, typeof(BarShape));
				ShapeDropDownList.SelectedIndex = 0;
			}

			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;

			// set a chart title
			NLabel title = new NLabel("3D Range Series");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			chart.Projection.Type = ProjectionType.Perspective;
			chart.Projection.Rotation = -18;
			chart.Projection.Elevation = 13;
			chart.Depth = 55.0f;
			chart.Width = 55.0f;
			chart.Height = 55.0f;

			// setup X axis
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			chart.Axis(StandardAxis.PrimaryX).View = new NRangeAxisView(new NRange1DD(0, 20), true, true);

			// setup Y axis
			linearScale = new NLinearScaleConfigurator();
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			chart.Axis(StandardAxis.PrimaryY).View = new NRangeAxisView(new NRange1DD(0, 20), true, true);

			// add interlaced stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			stripStyle.Interlaced = true;
			linearScale.StripStyles.Add(stripStyle);

			// setup Depth axis
			linearScale = new NLinearScaleConfigurator();
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale;
			chart.Axis(StandardAxis.Depth).View = new NRangeAxisView(new NRange1DD(0, 20), true, true);

			// setup shape series
			NRangeSeries rangeSeries = (NRangeSeries)chart.Series.Add(SeriesType.Range);
			rangeSeries.FillStyle = new NColorFillStyle(Color.Red);
			rangeSeries.BorderStyle.Color = Color.DarkRed;
			rangeSeries.Legend.Mode = SeriesLegendMode.None;
			rangeSeries.DataLabelStyle.Visible = false;
			rangeSeries.UseXValues = true;
			rangeSeries.UseZValues = true;
			rangeSeries.Shape = (BarShape)ShapeDropDownList.SelectedIndex;

			// add data
			AddDataPoint(rangeSeries, 1, 5, 11, 17, 5, 9);
			AddDataPoint(rangeSeries, 4, 7, 15, 19, 16, 19);
			AddDataPoint(rangeSeries, 5, 15, 6, 11, 12, 18);
			AddDataPoint(rangeSeries, 9, 14, 2, 5, 3, 5);
			AddDataPoint(rangeSeries, 15, 19, 2, 5, 3, 5);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
			styleSheet.Apply(nChartControl1.Document);
		}

		private void AddDataPoint(NRangeSeries series, double x1, double x2, double y1, double y2, double z1, double z2)
		{
			series.XValues.Add(x1);
			series.X2Values.Add(x2);
			series.Values.Add(y1);
			series.Y2Values.Add(y2);
			series.ZValues.Add(z1);
			series.Z2Values.Add(z2);
		}

		private void ShapeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
//			NRangeSeries rangeSeries = (NRangeSeries)nChartControl1.Charts[0].Series[0];
//			rangeSeries.Shape = (BarShape)ShapeCombo.SelectedIndex;
//			nChartControl1.Refresh();
		}
	}
}