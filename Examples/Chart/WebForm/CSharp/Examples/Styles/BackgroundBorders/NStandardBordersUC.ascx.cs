using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NStandardBordersUC : NExampleUC
	{
		protected HtmlForm ImageBordersGeneral;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				StandardBorderDropDownList.Items.Add("None");
				StandardBorderDropDownList.Items.Add("SingleFixed");
				StandardBorderDropDownList.Items.Add("Sunken");
				StandardBorderDropDownList.Items.Add("Raised");
				StandardBorderDropDownList.Items.Add("SunkenRaised");
				StandardBorderDropDownList.Items.Add("RaisedSunken");
 
				WebExamplesUtilities.FillComboWithColorNames(BorderColorDropDownList, KnownColor.White);
				WebExamplesUtilities.FillComboWithValues(BevelWidthDropDownList, 1, 10, 1);
				WebExamplesUtilities.FillComboWithValues(BorderWidthDownList, 1, 10, 1);

				StandardBorderDropDownList.SelectedIndex = 2;
			}

			nChartControl1.Settings.JitterMode = JitterMode.Enabled;

			// set an image frame
			NStandardFrameStyle standardFrameStyle = new NStandardFrameStyle();

			standardFrameStyle.SetPredefinedFrameStyle((PredefinedStandardFrame)(StandardBorderDropDownList.SelectedIndex));
			standardFrameStyle.InnerBevelWidth = new NLength(BevelWidthDropDownList.SelectedIndex + 1, NGraphicsUnit.Pixel);
			standardFrameStyle.OuterBevelWidth = new NLength(BevelWidthDropDownList.SelectedIndex + 1, NGraphicsUnit.Pixel);
			standardFrameStyle.OuterBorderColor = WebExamplesUtilities.ColorFromDropDownList(BorderColorDropDownList);
			standardFrameStyle.OuterBorderWidth = new NLength(BorderWidthDownList.SelectedIndex + 1, NGraphicsUnit.Pixel);

			nChartControl1.BackgroundStyle.FrameStyle = standardFrameStyle;
			nChartControl1.BackgroundStyle.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.LightSteelBlue, Color.White);

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Standard Border");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Depth = 50;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			NStandardScaleConfigurator scaleX = (NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount;
			
			NStandardScaleConfigurator scaleZ = (NStandardScaleConfigurator)chart.Axis(StandardAxis.Depth).ScaleConfigurator;
			scaleZ.MajorTickMode = MajorTickMode.AutoMaxCount;

			// add the first bar
			NBarSeries bar1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar1.MultiBarMode = MultiBarMode.Series;
			bar1.Name = "Bar1";
			bar1.DataLabelStyle.Visible = false;
			bar1.BorderStyle.Color = Color.Crimson;
			bar1.FillStyle = new NColorFillStyle(Color.Crimson);
			bar1.Values.FillRandomRange(Random, 5, 10, 40);

			// add the second bar
			NBarSeries bar2 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar2.MultiBarMode = MultiBarMode.Series;
			bar2.Name = "Bar2";
			bar2.DataLabelStyle.Visible = false;
			bar2.BorderStyle.Color = Color.PaleGreen;
			bar2.FillStyle = new NColorFillStyle(Color.PaleGreen);
			bar2.Values.FillRandomRange(Random, 5, 30, 60);

			// add the third bar
			NBarSeries bar3 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar3.MultiBarMode = MultiBarMode.Series;
			bar3.Name = "Bar3";
			bar3.DataLabelStyle.Visible = false;
			bar3.BorderStyle.Color = Color.CornflowerBlue;
			bar3.FillStyle = new NColorFillStyle(Color.CornflowerBlue);
			bar3.Values.FillRandomRange(Random, 5, 50, 80);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);
		}
	}
}
