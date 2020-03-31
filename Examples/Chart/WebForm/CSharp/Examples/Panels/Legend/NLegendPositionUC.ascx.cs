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
	public partial class NLegendPositionUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithPercents(HorizontalMarginDropDownList, 10);
				HorizontalMarginDropDownList.SelectedIndex = 0;

				ContentAlignmentDropDownList.Items.Add("BottomCenter");
				ContentAlignmentDropDownList.Items.Add("BottomLeft");
				ContentAlignmentDropDownList.Items.Add("BottomRight");
				ContentAlignmentDropDownList.Items.Add("MiddleCenter");
				ContentAlignmentDropDownList.Items.Add("MiddleLeft");
				ContentAlignmentDropDownList.Items.Add("MiddleRight");
				ContentAlignmentDropDownList.Items.Add("TopCenter");
				ContentAlignmentDropDownList.Items.Add("TopLeft");
				ContentAlignmentDropDownList.Items.Add("TopRight");
				ContentAlignmentDropDownList.SelectedIndex = 2;

				WebExamplesUtilities.FillComboWithPercents(VerticalMarginDropDownList, 10);
				VerticalMarginDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithFontNames(DataFontDropDownList, "Arial");
				WebExamplesUtilities.FillComboWithValues(DataFontSizeDropDownList, 9, 30, 1);

				HasShadowCheckBox.Checked = true;
				ShowLegendGridCheckBox.Checked = true;

				WebExamplesUtilities.FillComboWithPercents(BackplaneTransparencyDropDownList, 10);
				BackplaneTransparencyDropDownList.SelectedIndex = 0;
			}

			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// add panels
			nChartControl1.Panels.Clear();

			NLabel title = new NLabel("Legend Position");
			nChartControl1.Panels.Add(title);

			NPieChart chart = new NPieChart();
			nChartControl1.Panels.Add(chart);

			NLegend legend = new NLegend();
			nChartControl1.Panels.Add(legend);

			// setup the chart title
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(
				new NLength(50, NRelativeUnit.ParentPercentage),
				new NLength(2, NRelativeUnit.ParentPercentage));

			// setup the legend
			legend.ShadowStyle.Type = HasShadowCheckBox.Checked ? ShadowType.GaussianBlur : ShadowType.None;
			legend.ShadowStyle.Offset = new NPointL(2, 2);
			legend.ShadowStyle.Color = Color.FromArgb(64, 64, 64, 64);
			legend.FillStyle = new NColorFillStyle(Color.FromArgb(255 - (int)(BackplaneTransparencyDropDownList.SelectedIndex * 255 / 10.0f), 255, 255, 255));
			legend.ContentAlignment = (ContentAlignment)Enum.Parse(typeof(ContentAlignment), ContentAlignmentDropDownList.SelectedItem.Text);
			legend.Location = new NPointL(
				new NLength(HorizontalMarginDropDownList.SelectedIndex * 10, NRelativeUnit.ParentPercentage),
				new NLength(VerticalMarginDropDownList.SelectedIndex * 10, NRelativeUnit.ParentPercentage));

			if (ShowLegendGridCheckBox.Checked == true)
			{
				legend.HorizontalBorderStyle.Width = new NLength(1, NGraphicsUnit.Pixel);
				legend.VerticalBorderStyle.Width = new NLength(1, NGraphicsUnit.Pixel);
			}
			else
			{
				legend.HorizontalBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
				legend.VerticalBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			}

			// setup the pie chart
			chart.DisplayOnLegend = legend;
			chart.BoundsMode = BoundsMode.Fit;
			chart.Location = new NPointL(
				new NLength(10, NRelativeUnit.ParentPercentage),
				new NLength(20, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(80, NRelativeUnit.ParentPercentage),
				new NLength(60, NRelativeUnit.ParentPercentage));

			NPieSeries pie = (NPieSeries)chart.Series.Add(SeriesType.Pie);
			pie.DataLabelStyle.Visible = false;
			pie.Legend.Mode = SeriesLegendMode.DataPoints;
			pie.Legend.Format = "<label> <percent>";
			pie.Legend.TextStyle.FontStyle.Name = DataFontDropDownList.SelectedItem.Text;
			pie.Legend.TextStyle.FontStyle.EmSize = new NLength(DataFontSizeDropDownList.SelectedIndex + 9, NGraphicsUnit.Point);

			for (int i = 0; i < 6; i++)
			{
				pie.Values.Add(10 + Random.NextDouble() * 30);
				pie.Labels.Add("Item " + i.ToString());
			}

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.PaleMultiColor);
			styleSheet.Apply(chart);
		}
	}
}
