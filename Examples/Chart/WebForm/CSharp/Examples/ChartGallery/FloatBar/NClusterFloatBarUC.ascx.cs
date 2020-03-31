using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm.ChartGallery.FloatBar
{
	public partial class NClusterFloatBarUC : NExampleUC
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Clustered Float Bar");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			// setup X axis
			NOrdinalScaleConfigurator scaleX = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount;

			// add interlace stripe
			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Back, ChartWallType.Left };
			scaleY.StripStyles.Add(stripStyle);

			// setup the bar series
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Name = "Bar";
			bar.DataLabelStyle.Visible = false;
			bar.Values.FillRandomRange(Random, 8, 7, 15);

			// setup the floatbar series
			NFloatBarSeries floatbar = (NFloatBarSeries)chart.Series.Add(SeriesType.FloatBar);
			floatbar.MultiFloatBarMode = MultiFloatBarMode.Clustered;
			floatbar.Name = "Floatbar";
			floatbar.DataLabelStyle.Visible = false;

			floatbar.AddDataPoint(new NFloatBarDataPoint(3.1, 5.2));
			floatbar.AddDataPoint(new NFloatBarDataPoint(4.0, 6.1));
			floatbar.AddDataPoint(new NFloatBarDataPoint(2.0, 6.4));
			floatbar.AddDataPoint(new NFloatBarDataPoint(5.3, 7.3));
			floatbar.AddDataPoint(new NFloatBarDataPoint(3.8, 8.4));
			floatbar.AddDataPoint(new NFloatBarDataPoint(4.0, 7.7));
			floatbar.AddDataPoint(new NFloatBarDataPoint(2.9, 4.1));
			floatbar.AddDataPoint(new NFloatBarDataPoint(5.0, 7.2));

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);
		}
	}
}
