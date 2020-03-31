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
	public partial class NPieDataPointAnchorUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            nChartControl1.Panels.Clear();

            // Create title label
			NLabel title = new NLabel("Pie Data Point Anchor");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            nChartControl1.Panels.Add(title);

			// Create a pie chart
			NPieChart chart = new NPieChart();
            nChartControl1.Panels.Add(chart);
			chart.Enable3D = false;

			// Create a pie series with 6 data points
			NPieSeries pieSeries = new NPieSeries();
			chart.Series.Add(pieSeries);
			pieSeries.DataLabelStyle.Visible = true;
			pieSeries.LabelMode = PieLabelMode.SpiderNoOverlap;
            pieSeries.Values.FillRandomRange(new Random(), 6, 1, 5);

			// Create a rounded rect callout
			NRoundedRectangularCallout callout = new NRoundedRectangularCallout();
			callout.ArrowLength = new NLength(20, NGraphicsUnit.Point);
			callout.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(125, Color.White), Color.FromArgb(125, Color.LightGreen));
			callout.UseAutomaticSize = true;
			callout.Orientation = 80;
			callout.ContentAlignment = ContentAlignment.TopLeft;
			callout.Text = "Annotation";
			callout.TextStyle.FontStyle.EmSize = new NLength(8);

			// Anchor the callout to pie data point #0
			NPieDataPointAnchor anchor = new NPieDataPointAnchor(pieSeries, 0, 0.8f, StringAlignment.Near);
			callout.Anchor = anchor;
            
			// add the annotation panel
			nChartControl1.Panels.Add(callout);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.BrightMultiColor);
            styleSheet.Apply(nChartControl1.Document);
		}
	}
}
