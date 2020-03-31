using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.UI.WebForm.Controls;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NBinaryStreamingImageWithImageMapUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			NChartControl nChartControl1 = new NChartControl();
			nChartControl1.Width = 420;
			nChartControl1.Height = 320;
			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("HTML Image Map and Binary Streaming");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(
				new NLength(50, NRelativeUnit.ParentPercentage),
				new NLength(2, NRelativeUnit.ParentPercentage));

			// setup the legend
			NLegend legend = nChartControl1.Legends[0];
			legend.Mode = LegendMode.Disabled;
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Bottom);

			// setup a pie chart
			NPieChart chart = new NPieChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(chart);
			chart.DisplayOnLegend = legend;
			chart.Location = new NPointL(
				new NLength(10, NRelativeUnit.ParentPercentage),
				new NLength(17, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(80, NRelativeUnit.ParentPercentage),
				new NLength(66, NRelativeUnit.ParentPercentage));
			chart.InnerRadius = new NLength(20, NRelativeUnit.ParentPercentage);

			// add a pie series
			NPieSeries pieSeries = (NPieSeries)chart.Series.Add(SeriesType.Pie);
			pieSeries.PieStyle = PieStyle.Torus;
			pieSeries.LabelMode = PieLabelMode.Rim;
			pieSeries.DataLabelStyle.Format = "<label> <percent>";
			pieSeries.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(8, NGraphicsUnit.Point);
			pieSeries.Legend.Mode = SeriesLegendMode.DataPoints;
			pieSeries.Legend.Format = "<label> <value>";
			pieSeries.Legend.TextStyle.FontStyle.EmSize = new NLength(8, NGraphicsUnit.Point);

			pieSeries.AddDataPoint(new NDataPoint(12, "Metals"));
			pieSeries.AddDataPoint(new NDataPoint(42, "Glass"));
			pieSeries.AddDataPoint(new NDataPoint(23, "Plastics"));
			pieSeries.AddDataPoint(new NDataPoint(56, "Paper"));
			pieSeries.AddDataPoint(new NDataPoint(23, "Other"));

			// add urls to redirect to
			pieSeries.InteractivityStyles.Add(0, new NInteractivityStyle("Metals"));
			pieSeries.InteractivityStyles.Add(1, new NInteractivityStyle("Glass"));
			pieSeries.InteractivityStyles.Add(2, new NInteractivityStyle("Plastics"));
			pieSeries.InteractivityStyles.Add(3, new NInteractivityStyle("Paper"));
			pieSeries.InteractivityStyles.Add(4, new NInteractivityStyle("Other"));

			pieSeries.PieStyle = PieStyle.Torus;
			pieSeries.LabelMode = PieLabelMode.Spider;

			NHtmlImageMapResponse imageMapResponse = new NHtmlImageMapResponse();
			imageMapResponse.CreateImageFile = false;
			imageMapResponse.ImageFileName = "NChartImageMap";
			imageMapResponse.ImageMapName = "MAP_NChartImageMap";
			nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = imageMapResponse;

			this.Controls.Add(nChartControl1);
		}
	}
}
