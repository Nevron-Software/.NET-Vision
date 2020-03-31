using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.UI.WebForm.Controls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NSVGAndBrowserRedirectionUC : NExampleUC
	{
	
		protected void Page_Load(object sender, EventArgs e)
		{
			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			NChart chart;
			NBarSeries bar;

			nChartControl1.Legends[0].SetPredefinedLegendStyle(PredefinedLegendStyle.Bottom);

			chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Fit;
			chart.Location = new NPointL(new NLength(20, NRelativeUnit.ParentPercentage),
										new NLength(20, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(new NLength(60, NRelativeUnit.ParentPercentage),
									new NLength(60, NRelativeUnit.ParentPercentage));

			chart.Depth = 20;
			bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);

			bar.AddDataPoint(new NDataPoint(100 + Random.Next(100), "Toyota", new NColorFillStyle(Color.Red)));
			bar.AddDataPoint(new NDataPoint(100 + Random.Next(100), "Volkswagen", new NColorFillStyle(Color.Gold)));
			bar.AddDataPoint(new NDataPoint(100 + Random.Next(100), "Ford", new NColorFillStyle(Color.Chocolate)));
			bar.AddDataPoint(new NDataPoint(100 + Random.Next(100), "Mazda", new NColorFillStyle(Color.LimeGreen)));

			bar.Legend.Mode = SeriesLegendMode.DataPoints;
			bar.Legend.Format = "<label>";

			// add urls to redirect to

			NInteractivityStyle interactivityStyle = new NInteractivityStyle("Click here to jump to Toyota home page", CursorType.Hand);
			interactivityStyle.UrlLink.Url = "http://www.toyota.com";
			interactivityStyle.UrlLink.OpenInNewWindow = OpenLinkInNewWindowCheckBox.Checked;
			bar.InteractivityStyles.Add(0, interactivityStyle);

			interactivityStyle = new NInteractivityStyle("Click here to jump to VW home page", CursorType.Hand);
			interactivityStyle.UrlLink.Url = "http://www.vw.com";
			interactivityStyle.UrlLink.OpenInNewWindow = OpenLinkInNewWindowCheckBox.Checked;
			bar.InteractivityStyles.Add(1, interactivityStyle);
			
			interactivityStyle = new NInteractivityStyle("Click here to jump to Ford home page", CursorType.Hand);
			interactivityStyle.UrlLink.Url = "http://www.ford.com";
			interactivityStyle.UrlLink.OpenInNewWindow = OpenLinkInNewWindowCheckBox.Checked;
			bar.InteractivityStyles.Add(2, interactivityStyle);

			interactivityStyle = new NInteractivityStyle("Click here to jump to Mazda home page", CursorType.Hand);
			interactivityStyle.UrlLink.Url = "http://www.mazda.com";
			interactivityStyle.UrlLink.OpenInNewWindow = OpenLinkInNewWindowCheckBox.Checked;
			bar.InteractivityStyles.Add(3, interactivityStyle);

			for (int i = 0; i < bar.Values.Count; i++)
			{
				bar.FillStyles[i] = new NColorFillStyle(WebExamplesUtilities.RandomColor());
			}

			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights);
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);

			// add header
			NLabel header = nChartControl1.Labels.AddHeader("Car Sales per Company<br/><font size = '10'>Demonstrates anchor SVG tags</font>");
			header.TextStyle.BackplaneStyle.Visible = false;
			header.TextStyle.TextFormat = TextFormat.XML;
			header.TextStyle.FillStyle = new NColorFillStyle(Color.Black);
			header.ContentAlignment = ContentAlignment.BottomRight;
			header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage),
											new NLength(2, NRelativeUnit.ParentPercentage));

			NImageResponse imageResponse = new NImageResponse();
			NSvgImageFormat	svgImageFormat = new NSvgImageFormat();
			
			svgImageFormat.EnableInteractivity = true;
			svgImageFormat.CustomScript = "";

			imageResponse.ImageFormat = svgImageFormat;

			nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = imageResponse;
		}
	}
}
