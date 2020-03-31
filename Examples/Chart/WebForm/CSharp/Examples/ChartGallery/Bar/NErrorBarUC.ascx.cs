using System;
using System.Collections;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Dom;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NStackedBarUC : NExampleUC
	{
		protected NChart nChart;
		protected NBarSeries nBar1;
		protected NBarSeries nBar2;
		protected NBarSeries nBar3;


		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.Settings.JitterMode = JitterMode.Enabled;
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Error Bar");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Axis(StandardAxis.Depth).Visible = false;
            chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			chart.Axis(StandardAxis.Depth).Visible = false;

			// setup a bar series
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Name = "Bar Series";
			bar.DataLabelStyle.Visible = false;
			bar.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			bar.ShadowStyle.Type = ShadowType.GaussianBlur;
			bar.ShadowStyle.Offset = new NPointL(2, 2);
			bar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0);
			bar.ShadowStyle.FadeLength = new NLength(5);
			bar.HasBottomEdge = false;

			// add some data to the bar series
			bar.Values.Add(15);
			bar.UpperErrors.Add(2);
			bar.LowerErrors.Add(1);

			bar.Values.Add(21);
			bar.UpperErrors.Add(2.4);
			bar.LowerErrors.Add(1.3);

			bar.Values.Add(23);
			bar.UpperErrors.Add(3.2);
			bar.LowerErrors.Add(1.7);

			bar.Values.Add(27);
			bar.UpperErrors.Add(1.4);
			bar.LowerErrors.Add(2.5);

			bar.Values.Add(29);
			bar.UpperErrors.Add(4.0);
			bar.LowerErrors.Add(2.0);

			bar.Values.Add(26);
			bar.UpperErrors.Add(2.1);
			bar.LowerErrors.Add(1.6);


			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);

			bar.ShowUpperError = ShowUpperErrorCheckBox.Checked;
			bar.ShowLowerError = ShowLowerErrorCheckBox.Checked;
			chart.Enable3D = Enable3DCheckBox.Checked;
		}
	}
}
