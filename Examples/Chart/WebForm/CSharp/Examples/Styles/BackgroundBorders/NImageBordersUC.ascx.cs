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
	public partial class NImageBordersUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				ImageBorderDropDownList.Items.Add("Common");
				ImageBorderDropDownList.Items.Add("Embed");
				ImageBorderDropDownList.Items.Add("Emboss");
				ImageBorderDropDownList.Items.Add("Rounded");
				ImageBorderDropDownList.Items.Add("RoundedBorder");
				ImageBorderDropDownList.Items.Add("Rectangular");
				ImageBorderDropDownList.Items.Add("Thin");
				ImageBorderDropDownList.Items.Add("Thick");
				ImageBorderDropDownList.Items.Add("OuterRounded");
				ImageBorderDropDownList.Items.Add("OpenLeft");
				ImageBorderDropDownList.Items.Add("OpenRight");

				WebExamplesUtilities.FillComboWithColorNames(BorderColorDropDownList, KnownColor.LightSteelBlue);
				WebExamplesUtilities.FillComboWithColorNames(FillingColorDropDownList, KnownColor.Snow);
				WebExamplesUtilities.FillComboWithColorNames(PageBackgroundColorDropDownList, KnownColor.White);
				HasShadowCheckBox.Checked = true;

				ImageBorderDropDownList.SelectedIndex = 6;
			}

			// set an image frame
			NImageFrameStyle imageFrameStyle = new NImageFrameStyle();

			imageFrameStyle.SetPredefinedFrameStyle((PredefinedImageFrame)(ImageBorderDropDownList.SelectedIndex));
			imageFrameStyle.FillStyle = new NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(FillingColorDropDownList));
			imageFrameStyle.BorderStyle.Width = new NLength(1, NGraphicsUnit.Pixel);
			imageFrameStyle.BorderStyle.Color = WebExamplesUtilities.ColorFromDropDownList(BorderColorDropDownList);
			imageFrameStyle.BackgroundColor = WebExamplesUtilities.ColorFromDropDownList(PageBackgroundColorDropDownList);
			imageFrameStyle.ShadowStyle.Type = HasShadowCheckBox.Checked ? ShadowType.LinearBlur : ShadowType.None;

			nChartControl1.BackgroundStyle.FrameStyle = imageFrameStyle;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Image Border");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			NChart chart = nChartControl1.Charts[0];

			// add the first bar
			NBarSeries bar1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar1.MultiBarMode = MultiBarMode.Series;
			bar1.DataLabelStyle.Visible = false;
			bar1.Values.FillRandomRange(Random, 5, 10, 40);

			// add the second bar
			NBarSeries bar2 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar2.MultiBarMode = MultiBarMode.Stacked;
			bar2.DataLabelStyle.Visible = false;
			bar2.Values.FillRandomRange(Random, 5, 10, 40);

			// add the third bar
			NBarSeries bar3 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar3.MultiBarMode = MultiBarMode.Stacked;
			bar3.DataLabelStyle.Visible = false;
			bar3.Values.FillRandomRange(Random, 5, 10, 40);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}
	}
}