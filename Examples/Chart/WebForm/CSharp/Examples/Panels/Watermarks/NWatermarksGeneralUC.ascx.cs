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
	public partial class NWatermarksGeneralUC : NExampleUC
	{
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				CountryDropDownList.Items.Add("USA");
				CountryDropDownList.Items.Add("CHINA");
				CountryDropDownList.Items.Add("JAPAN");
				CountryDropDownList.Items.Add("GERMANY");
				CountryDropDownList.Items.Add("FRANCE");
				CountryDropDownList.Items.Add("UK");

				CountryDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithPercents(XPositionDropDownList, 10);
				XPositionDropDownList.SelectedIndex = 0;
				WebExamplesUtilities.FillComboWithPercents(YPositionDropDownList, 10);
				YPositionDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithPercents(FlagTransparencyDropDownList, 10);
				FlagTransparencyDropDownList.SelectedIndex = 5;

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
			}

            // enable the antialiasing of the whole scene
            nChartControl1.Settings.JitterMode = JitterMode.Enabled;
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // by default the chart contains a cartesian chart which cannot display a pie series
            nChartControl1.Charts.Clear();

            // create the legend
            NLegend legend = new NLegend();
			legend.HorizontalBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.VerticalBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.FillStyle.SetTransparencyPercent(50);
			legend.OuterBottomBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.OuterLeftBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.OuterRightBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.OuterTopBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
            legend.SetPredefinedLegendStyle(PredefinedLegendStyle.TopRight);

            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Car sales for " + CountryDropDownList.SelectedItem.Text);
			title.ContentAlignment = ContentAlignment.TopRight;
			title.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(98, NRelativeUnit.ParentPercentage));
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

            // create the watermark
            NWatermark watermark = new NWatermark();
            watermark.FillStyle = new NImageFillStyle(this.MapPathSecure(this.TemplateSourceDirectory + "\\" + CountryDropDownList.SelectedItem.Text + ".GIF"));
            watermark.Location = new NPointL(new NLength(XPositionDropDownList.SelectedIndex * 10, NRelativeUnit.ParentPercentage), new NLength(YPositionDropDownList.SelectedIndex * 10, NRelativeUnit.ParentPercentage));
            watermark.UseAutomaticSize = false;
            watermark.Size = new NSizeL(150, 100);
            watermark.ContentAlignment = (ContentAlignment)ContentAlignment.Parse(typeof(ContentAlignment), ContentAlignmentDropDownList.SelectedItem.Text);
            watermark.FillStyle.SetTransparencyPercent(FlagTransparencyDropDownList.SelectedIndex * 10.0f);
            watermark.StandardFrameStyle.Visible = false;

            // create the chart
            NPieChart chart = new NPieChart();
			chart.Enable3D = true;
            chart.Depth = 5;

            if (ShowFlagAboveChartBox.Checked)
            {
                nChartControl1.Panels.Add(chart);
                nChartControl1.Panels.Add(legend);
                nChartControl1.Panels.Add(watermark);
            }
            else
            {
                nChartControl1.Panels.Add(watermark);
                nChartControl1.Panels.Add(chart);
                nChartControl1.Panels.Add(legend);
            }

			chart.DisplayOnLegend = legend;
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);
            chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated);

			NPieSeries pie = (NPieSeries)chart.Series.Add(SeriesType.Pie);
			pie.PieStyle = PieStyle.SmoothEdgePie;
			pie.LabelMode = PieLabelMode.Center;
			pie.Legend.Mode = SeriesLegendMode.DataPoints;
			pie.DataLabelStyle.Visible = false;

			pie.AddDataPoint(new NDataPoint(0, "Toyota"));
			pie.AddDataPoint(new NDataPoint(0, "Honda"));
			pie.AddDataPoint(new NDataPoint(0, "Volkswagen"));
			pie.AddDataPoint(new NDataPoint(0, "Chrysler"));
			pie.AddDataPoint(new NDataPoint(0, "Ford"));
			pie.Values.FillRandom(Random, 5);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(pie);
		}
	}
}
