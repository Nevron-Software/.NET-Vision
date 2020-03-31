using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NDataLabelsUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				DefaultFormatDropDown.Items.Add("[value] [label]");
				DefaultFormatDropDown.Items.Add("[index] [cumulative]");
				DefaultFormatDropDown.Items.Add("[percent] [total]");
				DefaultFormatDropDown.SelectedIndex = 0;

				DefaultVerticalAlignDropDown.Items.Add("Center");
				DefaultVerticalAlignDropDown.Items.Add("Top");
				DefaultVerticalAlignDropDown.Items.Add("Bottom");
				DefaultVerticalAlignDropDown.SelectedIndex = 1;

				DefaultLabelVisibleCheck.Checked = true;
				DefaultBackplaneVisibleCheck.Checked = true;

				Label3FormatDropDown.Items.Add("Individual");
				Label3FormatDropDown.Items.Add("[value] [label]");
				Label3FormatDropDown.Items.Add("[index] [cumulative]");
				Label3FormatDropDown.Items.Add("[percent] [total]");
				Label3FormatDropDown.SelectedIndex = 0;

				Label3VerticalAlignDropDown.Items.Add("Center");
				Label3VerticalAlignDropDown.Items.Add("Top");
				Label3VerticalAlignDropDown.Items.Add("Bottom");
				Label3VerticalAlignDropDown.SelectedIndex = 1;

				Label3VisibleCheck.Checked = true;
				Backplane3VisibleCheck.Checked = true;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Legends[0].Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Data Labels");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Axis(StandardAxis.Depth).Visible = false;

			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.AddDataPoint(new NDataPoint(10, "Item A"));
			bar.AddDataPoint(new NDataPoint(20, "Item B"));
			bar.AddDataPoint(new NDataPoint(30, "Item C"));
			bar.AddDataPoint(new NDataPoint(25, "Item D"));
			bar.AddDataPoint(new NDataPoint(29, "Item E"));

            // add interlaced stripe
            NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScaleConfigurator.StripStyles.Add(stripStyle);

            // apply style sheet
            NFillStyleSheetConfigurator fillStyleSheet = new NFillStyleSheetConfigurator();
            fillStyleSheet.SeriesFillTemplate = new NGradientFillStyleTemplate(GradientStyle.Horizontal, GradientVariant.Variant1);
            fillStyleSheet.MultiColorSeries = true;
            fillStyleSheet.Palette.SetPredefinedPalette(ChartPredefinedPalette.Nature);
            NStrokeStyleSheetConfigurator strokeStyleSheet = new NStrokeStyleSheetConfigurator();
            strokeStyleSheet.MultiColorSeries = true;
            strokeStyleSheet.ApplyToDataLabels = false;
            strokeStyleSheet.Palette.SetPredefinedPalette(ChartPredefinedPalette.Nature);

            NStyleSheet styleSheet = new NStyleSheet();
            fillStyleSheet.ConfigureSheet(styleSheet);
            strokeStyleSheet.ConfigureSheet(styleSheet);
            styleSheet.Apply(bar);

			// add a different data label for data point 3
			NDataLabelStyle label = new NDataLabelStyle();
			label.TextStyle.FontStyle.Style = FontStyle.Bold;
			label.TextStyle.FillStyle = new NColorFillStyle(Color.Crimson);
			label.TextStyle.BackplaneStyle.Inflate = new NSizeL(3, 3);
			label.TextStyle.BackplaneStyle.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant2, Color.White, Color.Lavender);
			bar.DataLabelStyles[3] = label;

			label.Format = WebExamplesUtilities.GetXmlFormatString(Label3FormatDropDown.SelectedItem.Text);
			label.VertAlign = (VertAlign)Label3VerticalAlignDropDown.SelectedIndex;
			label.Visible = Label3VisibleCheck.Checked;
			label.TextStyle.BackplaneStyle.Visible = Backplane3VisibleCheck.Checked;

			bar.DataLabelStyle.Format = WebExamplesUtilities.GetXmlFormatString(DefaultFormatDropDown.SelectedItem.Text);
			bar.DataLabelStyle.VertAlign = (VertAlign)DefaultVerticalAlignDropDown.SelectedIndex;
			bar.DataLabelStyle.Visible = DefaultLabelVisibleCheck.Checked;
			bar.DataLabelStyle.TextStyle.BackplaneStyle.Visible = DefaultBackplaneVisibleCheck.Checked;

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}
	}
}
