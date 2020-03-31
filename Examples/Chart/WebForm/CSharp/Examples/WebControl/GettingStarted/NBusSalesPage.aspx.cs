using System;
using System.Drawing;
using System.Web.UI;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NBusSalesPage : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
            nChartControl1.Settings.JitterMode = JitterMode.Enabled;
            nChartControl1.Settings.JitteringSteps = 4;

			nChartControl1.Panels.Clear();

			NWatermark watermark = new NWatermark();
			nChartControl1.Panels.Add(watermark);

			NLabel title = new NLabel("Bus Sales by Company");
			nChartControl1.Panels.Add(title);

			NLegend legend = new NLegend();
			nChartControl1.Panels.Add(legend);

			NPieChart chart = new NPieChart();
			nChartControl1.Panels.Add(chart);

			// setup the watermark
			watermark.FillStyle = new NImageFillStyle(this.MapPathSecure("~\\Images\\bus.png"));
			watermark.StandardFrameStyle.InnerBorderWidth = new NLength(0);
			watermark.Location = new NPointL(new NLength(5, NRelativeUnit.ParentPercentage), new NLength(5, NRelativeUnit.ParentPercentage));
			watermark.ContentAlignment = ContentAlignment.BottomRight;

			// setup the chart title
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.ContentAlignment = ContentAlignment.BottomRight;
			title.Location = new NPointL(
				new NLength(2, NRelativeUnit.ParentPercentage),
				new NLength(2, NRelativeUnit.ParentPercentage));

			// setup the legend
			legend.ContentAlignment = ContentAlignment.BottomLeft;
			legend.Location = new NPointL(
				new NLength(98, NRelativeUnit.ParentPercentage),
				new NLength(2, NRelativeUnit.ParentPercentage));

			// setup the chart
			chart.DisplayOnLegend = legend;
			chart.Enable3D = true;
			chart.LightModel.EnableLighting = true;
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights);
			chart.BoundsMode = BoundsMode.Fit;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated);
			chart.Location = new NPointL(
				new NLength(27, NRelativeUnit.ParentPercentage),
                new NLength(25, NRelativeUnit.ParentPercentage));
            chart.Size = new NSizeL(
                new NLength(70, NRelativeUnit.ParentPercentage),
                new NLength(70, NRelativeUnit.ParentPercentage));

			// add a pie series
			NPieSeries pie = (NPieSeries)chart.Series.Add(SeriesType.Pie);
			pie.LabelMode = PieLabelMode.Center;
			pie.DataLabelStyle.Format = "<value>";
			pie.DataLabelStyle.TextStyle.BackplaneStyle.Shape = BackplaneShape.SmoothEdgeRectangle;
			pie.DataLabelStyle.TextStyle.BackplaneStyle.FillStyle = new NColorFillStyle(Color.FromArgb(200, 255, 255, 255));
			pie.DataLabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 10, FontStyle.Bold);
			pie.DataLabelStyle.TextStyle.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.LightSeaGreen, Color.Navy);
			pie.Legend.Mode = SeriesLegendMode.DataPoints;
			pie.Legend.Format = "<label> <percent>";
			pie.PieStyle = PieStyle.SmoothEdgePie;

			// add data
			pie.Values.FillRandomRange(new Random(), 3, 10, 30);
			pie.Labels.Add("Mitsubishi");
			pie.Labels.Add("MAN");
			pie.Labels.Add("Daimler - Chrysler");

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.BrightMultiColor);
			styleSheet.Apply(nChartControl1.Charts[0]);
		}
	}
}
