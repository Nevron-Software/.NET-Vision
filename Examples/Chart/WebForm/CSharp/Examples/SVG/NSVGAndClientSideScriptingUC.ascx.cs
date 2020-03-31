using System;
using System.Collections;
using System.Drawing;
using System.Text;
using Nevron.Chart;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NSVGAndClientSideScriptingUC : NExampleUC
	{
		private void AddWatermark(NDockPanel containerPanel, String sFileName)
		{
			NWatermark watermark = new NWatermark();
			watermark.StandardFrameStyle.InnerBorderWidth = new NLength(0, NGraphicsUnit.Pixel);
			watermark.StandardFrameStyle.OuterBorderWidth = new NLength(0, NGraphicsUnit.Pixel);
			watermark.FillStyle = new NImageFillStyle(this.MapPathSecure(this.TemplateSourceDirectory + "\\" + sFileName));

			watermark.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage),
											new NLength(55, NRelativeUnit.ParentPercentage));

			watermark.ContentAlignment = ContentAlignment.MiddleCenter;
			watermark.UseAutomaticSize = false;
			watermark.Size = new NSizeL(new NLength(100, NGraphicsUnit.Pixel), new NLength(100, NGraphicsUnit.Pixel));

			containerPanel.ChildPanels.Add(watermark);
		}

		private String GetScript()
		{
			StringBuilder script = new StringBuilder();

			script.AppendLine("function ShowWatermark(evt, watermarkID, divId)");
			script.AppendLine("{");
			script.AppendLine("var svgDocument = evt.target.ownerDocument;");
//			script.AppendLine("svgDocument = null;");

			for (int i = 0; i < nChartControl1.Watermarks.Count; i++)
			{
				string watermarkId = new NElementIdentifier(nChartControl1.Watermarks[i].Id).ToString();
				script.AppendLine("svgDocument.getElementById(\"" + watermarkId + "\").setAttribute('style', 'visibility:hidden')");
			}

			script.AppendLine("if (svgDocument.getElementById(watermarkID))");
			script.AppendLine("{");
			script.AppendLine("	svgDocument.getElementById(watermarkID).setAttribute('style', 'visibility:visible')");
			script.AppendLine("}");

			script.AppendLine("parent.ShowDiv(divId);");
			script.AppendLine("}");

			return script.ToString();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			nChartControl1.Panels.Clear();

			// add watermarks

			string[] divIds = new string[] { "toyota",
											"chevrolet",
											"ford",
											"volkswagen",
											"hyundai",
											"nissan",
											"mazda" };

			nChartControl1.BackgroundStyle.FillStyle = new NColorFillStyle(Color.LightGray);
			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// add header
			NLabel header = nChartControl1.Labels.AddHeader("Car Sales by Company");
			header.TextStyle.BackplaneStyle.Visible = false;
			header.TextStyle.TextFormat = TextFormat.XML;
			header.TextStyle.ShadowStyle.Type = ShadowType.GaussianBlur;
			header.TextStyle.FillStyle = new NColorFillStyle(Color.Black);
			header.DockMode = PanelDockMode.Top;
			header.Margins = new NMarginsL(0, 10, 0, 0);

			// by default the chart contains a cartesian chart which cannot display a pie series
			NDockPanel dockPanel = new NDockPanel();

			dockPanel.DockMode = PanelDockMode.Fill;
			dockPanel.PositionChildPanelsInContentBounds = true;
			dockPanel.Margins = new NMarginsL(10, 10, 10, 10);

			nChartControl1.Panels.Add(dockPanel);

			AddWatermark(dockPanel, "ToyotaLogo.png");
			AddWatermark(dockPanel, "ChevroletLogo.png");
			AddWatermark(dockPanel, "FordLogo.png");
			AddWatermark(dockPanel, "VolkswagenLogo.png");
			AddWatermark(dockPanel, "HyundaiLogo.png");
			AddWatermark(dockPanel, "NissanLogo.png");
			AddWatermark(dockPanel, "MazdaLogo.png");

			NPieChart pieChart = new NPieChart();
			dockPanel.ChildPanels.Add(pieChart);

			NPieSeries pieSeries = new NPieSeries();
			pieChart.Series.Add(pieSeries);

			// add some data
			pieSeries.AddDataPoint(new NDataPoint(11.6, "Toyota Corolla"));
			pieSeries.AddDataPoint(new NDataPoint(9.7, "Chevrolet Cruze"));
			pieSeries.AddDataPoint(new NDataPoint(9.3, "Ford Focus"));
			pieSeries.AddDataPoint(new NDataPoint(7.1, "Volkswagen Jetta"));
			pieSeries.AddDataPoint(new NDataPoint(7.0, "Hyundai Elantra"));
			pieSeries.AddDataPoint(new NDataPoint(6.1, "Nissan Versa"));
			pieSeries.AddDataPoint(new NDataPoint(5.9, "Mazda 3"));
			pieSeries.AddDataPoint(new NDataPoint(43.4, "Other"));

			pieSeries.PieStyle = PieStyle.Torus;
			pieSeries.LabelMode = PieLabelMode.Center;

			// configure interactivity for data points
			for (int i = 0; i < pieSeries.Values.Count; i++)
			{
				NInteractivityStyle interactivityStyle = new NInteractivityStyle();

				if (i < nChartControl1.Watermarks.Count)
				{
					string watermarkId = new NElementIdentifier(nChartControl1.Watermarks[i].Id).ToString();
					interactivityStyle.CustomMapAreaAttribute.JScriptAttribute = "onmouseover = 'ShowWatermark(evt, \"" + watermarkId + "\", \"" + divIds[i] + "\")'";
				}
				else
				{
					interactivityStyle.CustomMapAreaAttribute.JScriptAttribute = "onmouseover = 'ShowWatermark(evt, null, null)'";
				}

				pieSeries.InteractivityStyles.Add(i, interactivityStyle);
			}

			nChartControl1.InteractivityStyle.CustomMapAreaAttribute.JScriptAttribute = "onmouseover = 'ShowWatermark(evt, null, null)'";

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.BrightMultiColor);
			styleSheet.Apply(nChartControl1.Document);
			
			// configure the control to generate SVG.
			NImageResponse imageResponse = new NImageResponse();
			NSvgImageFormat svgImageFormat = new NSvgImageFormat();

			svgImageFormat.EnableInteractivity = true;
			svgImageFormat.CustomScript = GetScript();
			svgImageFormat.EmbedImagesInSvg = true;
			svgImageFormat.EmbeddedImageFormat = new NJpegImageFormat();

			Hashtable attributes = new Hashtable();
			attributes["preserveAspectRatio"] = "yMid slice";
//			attributes["onload"] = "Initialize(evt)";
			svgImageFormat.Attributes = attributes;
			imageResponse.ImageFormat = svgImageFormat;

			nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = imageResponse;
		}
	}
}

