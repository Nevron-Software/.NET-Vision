using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.UI.WebForm.Controls;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NCapturingMouseEventsUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				CaptureMouseEventDropDownList.Items.Add("OnClick");
				CaptureMouseEventDropDownList.Items.Add("OnDblClick");
				CaptureMouseEventDropDownList.Items.Add("OnMouseOut");
				CaptureMouseEventDropDownList.Items.Add("OnMouseOver");
				CaptureMouseEventDropDownList.Items.Add("OnMouseWheel");
				CaptureMouseEventDropDownList.SelectedIndex = 0;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddHeader("Capturing Mouse Events");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));
			
			// configure the legend
			NLegend legend = nChartControl1.Legends[0];
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Right);
			legend.FillStyle.SetTransparencyPercent(50);
			legend.Location = new NPointL(new NLength(98, NRelativeUnit.ParentPercentage), legend.Location.Y);

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.BoundsMode = BoundsMode.Fit;
			chart.Location = new NPointL(new NLength(5, NRelativeUnit.ParentPercentage),
										new NLength(15, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(new NLength(70, NRelativeUnit.ParentPercentage),
									new NLength(70, NRelativeUnit.ParentPercentage));
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft);

			// create a bar series
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Name = "My Bar Series";
			bar.DataLabelStyle.Format = "<value>";

			bar.AddDataPoint(new NDataPoint(10, "Ford", new NColorFillStyle(WebExamplesUtilities.RandomColor())));
			bar.AddDataPoint(new NDataPoint(20, "Toyota", new NColorFillStyle(WebExamplesUtilities.RandomColor())));
			bar.AddDataPoint(new NDataPoint(30, "VW", new NColorFillStyle(WebExamplesUtilities.RandomColor())));
			bar.AddDataPoint(new NDataPoint(25, "Mitsubishi", new NColorFillStyle(WebExamplesUtilities.RandomColor())));
			bar.AddDataPoint(new NDataPoint(29, "Jaguar", new NColorFillStyle(WebExamplesUtilities.RandomColor())));

			bar.Legend.Mode = SeriesLegendMode.DataPoints;
			bar.BarShape = BarShape.SmoothEdgeBar;
			bar.DataLabelStyle.Visible = false;

			for (int i = 0; i < bar.Values.Count; i++)
			{
				string customAttribute = CaptureMouseEventDropDownList.SelectedItem.Text + " = \"javascript:alert(' Mouse event [" + CaptureMouseEventDropDownList.SelectedItem.Text + "] intercepted for bar [" + i.ToString() + "] ')\" ";
				NInteractivityStyle interactivityStyle = new NInteractivityStyle();

				interactivityStyle.CustomMapAreaAttribute.JScriptAttribute = customAttribute;

				bar.InteractivityStyles[i] = interactivityStyle;
			}

			// change the response type to image map
			NHtmlImageMapResponse imageMapResponse = new NHtmlImageMapResponse();
			nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = imageMapResponse;
		}

		protected void ApplyImageMapAttributesToSerie(NBarSeries bar)
		{
		}
	}
}
