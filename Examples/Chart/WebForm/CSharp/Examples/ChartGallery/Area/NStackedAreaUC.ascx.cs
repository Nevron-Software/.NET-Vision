using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Dom;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NStackedAreaUC : NExampleUC
	{
		const int nCategoriesCount = 6;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				// fill the data labels combos
				FirstAreaDataLabelsCombo.Items.Add("Value");
				FirstAreaDataLabelsCombo.Items.Add("Total");
				FirstAreaDataLabelsCombo.Items.Add("Cumulative");
				FirstAreaDataLabelsCombo.Items.Add("Percent");
				FirstAreaDataLabelsCombo.Items.Add("No Label");
				FirstAreaDataLabelsCombo.SelectedIndex = 0;

				SecondAreaDataLabelsCombo.Items.Add("Value");
				SecondAreaDataLabelsCombo.Items.Add("Total");
				SecondAreaDataLabelsCombo.Items.Add("Cumulative");
				SecondAreaDataLabelsCombo.Items.Add("Percent");
				SecondAreaDataLabelsCombo.Items.Add("No Label");
				SecondAreaDataLabelsCombo.SelectedIndex = 0;

				ThirdAreaDataLabelsCombo.Items.Add("Value");
				ThirdAreaDataLabelsCombo.Items.Add("Total");
				ThirdAreaDataLabelsCombo.Items.Add("Cumulative");
				ThirdAreaDataLabelsCombo.Items.Add("Percent");
				ThirdAreaDataLabelsCombo.Items.Add("No Label");
				ThirdAreaDataLabelsCombo.SelectedIndex = 0;

				StackStyleCombo.Items.Add("Stacked");
				StackStyleCombo.Items.Add("Stacked %");
				StackStyleCombo.SelectedIndex = 0;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Stacked Area Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
            chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			chart.Axis(StandardAxis.Depth).Visible = false;

            // add interlace stripe
			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Back, ChartWallType.Left };
            scaleY.StripStyles.Add(stripStyle);

			// add the first area
			NAreaSeries area1 = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			area1.MultiAreaMode = MultiAreaMode.Series;
			area1.Name = "Area 1";
			area1.DataLabelStyle.Visible = true;
			area1.DataLabelStyle.VertAlign = VertAlign.Center;
			area1.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(7);
			area1.Legend.TextStyle.FontStyle.EmSize = new NLength(8);
			area1.Values.ValueFormatter = new NNumericValueFormatter("0.##");

			// add the second area
			NAreaSeries area2 = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			area2.MultiAreaMode = MultiAreaMode.Stacked;
			area2.Name = "Area 2";
			area2.DataLabelStyle.Visible = true;
			area2.DataLabelStyle.VertAlign = VertAlign.Center;
			area2.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(7);
			area2.Legend.TextStyle.FontStyle.EmSize = new NLength(8);
			area2.Values.ValueFormatter = new NNumericValueFormatter("0.##");

			// add the third area
			NAreaSeries area3 = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			area3.MultiAreaMode = MultiAreaMode.Stacked;
			area3.Name = "Area 3";
			area3.DataLabelStyle.Visible = true;
			area3.DataLabelStyle.VertAlign = VertAlign.Center;
			area3.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(7);
			area3.Legend.TextStyle.FontStyle.EmSize = new NLength(8);
			area3.Values.ValueFormatter = new NNumericValueFormatter("0.##");

			area1.DataLabelStyle.Format = GetDataLabelsFormatString(FirstAreaDataLabelsCombo);
			area2.DataLabelStyle.Format = GetDataLabelsFormatString(SecondAreaDataLabelsCombo);
			area3.DataLabelStyle.Format = GetDataLabelsFormatString(ThirdAreaDataLabelsCombo);

			switch (StackStyleCombo.SelectedIndex)
			{
				case 0:
					area2.MultiAreaMode = MultiAreaMode.Stacked;
					area3.MultiAreaMode = MultiAreaMode.Stacked;
					break;

				case 1:
					area2.MultiAreaMode = MultiAreaMode.StackedPercent;
					area3.MultiAreaMode = MultiAreaMode.StackedPercent;
					scaleY.LabelValueFormatter = new NNumericValueFormatter(NumericValueFormat.Percentage);
					break;
			}

			// fill with random data
			area1.Values.FillRandomRange(Random, nCategoriesCount, 10, 20);
			area2.Values.FillRandomRange(Random, nCategoriesCount, 10, 20);
			area3.Values.FillRandomRange(Random, nCategoriesCount, 10, 20);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);
		}

		string GetDataLabelsFormatString(DropDownList list)
		{
			switch (list.SelectedIndex)
			{
				case 0:
					return "<value>";

				case 1:
					return "<total>";

				case 2:
					return "<cumulative>";

				case 3:
					return "<percent>";
			}

			return "";
		}
	}
}