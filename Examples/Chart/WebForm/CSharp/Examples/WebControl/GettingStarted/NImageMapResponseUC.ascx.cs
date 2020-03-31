using System;
using System.Drawing;
using System.Web.UI;
using Nevron.Examples.Framework.WebForm;
using Nevron.UI.WebForm.Controls;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NImageMapResponseUC : NExampleUC
	{

		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;

            NHtmlImageMapResponse imageMapResponse = new NHtmlImageMapResponse();
            nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = imageMapResponse;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("HTML Image Map");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
            chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			chart.Axis(StandardAxis.Depth).Visible = false;

			// add a bar series
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.DataLabelStyle.Visible = false;
			bar.Legend.Mode = SeriesLegendMode.DataPoints;
			bar.Legend.Format = "<label> <percent>";

			bar.AddDataPoint(new NDataPoint(12, "Cars"));
			bar.AddDataPoint(new NDataPoint(42, "Trains"));
			bar.AddDataPoint(new NDataPoint(56, "Buses"));
			bar.AddDataPoint(new NDataPoint(23, "Ships"));

			// modify the axis labels
			NOrdinalScaleConfigurator ordinalScale = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			ordinalScale.AutoLabels = false;

			for (int i = 0; i < bar.Labels.Count; i++)
			{
				ordinalScale.Labels.Add((string)bar.Labels[i]);
			}

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.PaleMultiColor);
			styleSheet.Apply(chart);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);

			// add interactivity styles with the urls to redirect to and the corresponding cursors and tooltips

			NInteractivityStyle interactivityStyle = new NInteractivityStyle("Click here to jump to Cars sales page", CursorType.Hand);
			interactivityStyle.UrlLink.OpenInNewWindow = true;
			interactivityStyle.UrlLink.Url = "../Examples/GettingStarted/NCarSalesPage.aspx";
			bar.InteractivityStyles[0] = interactivityStyle;

			interactivityStyle = new NInteractivityStyle("Click here to jump to Trains sales page", CursorType.Hand);
			interactivityStyle.UrlLink.OpenInNewWindow = true;
            interactivityStyle.UrlLink.Url = "../Examples/GettingStarted/NTrainSalesPage.aspx";
			bar.InteractivityStyles[1] = interactivityStyle;

			interactivityStyle = new NInteractivityStyle("Click here to jump to Bus sales page", CursorType.Hand);
			interactivityStyle.UrlLink.OpenInNewWindow = true;
            interactivityStyle.UrlLink.Url = "../Examples/GettingStarted/NBusSalesPage.aspx";
			bar.InteractivityStyles[2] = interactivityStyle;

			interactivityStyle = new NInteractivityStyle("Click here to jump to Ship sales page", CursorType.Hand);
			interactivityStyle.UrlLink.OpenInNewWindow = true;
            interactivityStyle.UrlLink.Url = "../Examples/GettingStarted/NShipSalesPage.aspx";
			bar.InteractivityStyles[3] = interactivityStyle;
		}
	}
}
