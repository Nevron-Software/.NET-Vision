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
	public partial class NSeriesLegendUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				// init form controls
				FormatDropDownList.Items.Add("[value] [label]");
				FormatDropDownList.Items.Add("[index] [cumulative]");
				FormatDropDownList.Items.Add("[percent] [total]");
				FormatDropDownList.SelectedIndex = 0;

				ModeDropDownList.Items.Add("Disabled");
				ModeDropDownList.Items.Add("Series");
				ModeDropDownList.Items.Add("DataPoints");
				ModeDropDownList.Items.Add("SeriesCustom");
				ModeDropDownList.SelectedIndex = 2;

				WebExamplesUtilities.FillComboWithEnumValues(PointShapeDropDownList, typeof(PointShape));
				PointShapeDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithColorNames(ColorDropDownList, KnownColor.DarkOrange);

                DifferentColorsCheckBox.Checked = true;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = new NLabel("Series Legend");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			nChartControl1.Panels.Add(title);
            
			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Axis(StandardAxis.Depth).Visible = false;

            // add interlaced stripe
            NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScaleConfigurator.StripStyles.Add(stripStyle);

			NPointSeries point = (NPointSeries)chart.Series.Add(SeriesType.Point);
			point.DataLabelStyle.Visible = false;
			point.InflateMargins = true;
			point.PointShape = (PointShape)PointShapeDropDownList.SelectedIndex;
			point.Legend.Mode = (SeriesLegendMode)ModeDropDownList.SelectedIndex;

			point.AddDataPoint(new NDataPoint(16, "Agriculture"));
			point.AddDataPoint(new NDataPoint(42, "Construction"));
			point.AddDataPoint(new NDataPoint(56, "Manufacturing"));
			point.AddDataPoint(new NDataPoint(23, "Services"));
			point.AddDataPoint(new NDataPoint(47, "Healthcare"));
			point.AddDataPoint(new NDataPoint(38, "Finance"));

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);

			if (DifferentColorsCheckBox.Checked)
			{
                NChartPalette palette = new NChartPalette();
                palette.SetPredefinedPalette(ChartPredefinedPalette.Nevron);

				for (int i = 0; i < point.Values.Count; i++)
				{
					point.FillStyles[i] = new NColorFillStyle(palette.SeriesColors[i % palette.SeriesColors.Count]);
				}
				ColorDropDownList.Enabled = false;
			}
			else
			{
				point.FillStyle = new NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(ColorDropDownList));
				ColorDropDownList.Enabled = true;
			}

            if (ModeDropDownList.SelectedIndex == 2)
            {
                FormatDropDownList.Enabled = true;
                point.Legend.Format = WebExamplesUtilities.GetXmlFormatString(FormatDropDownList.SelectedItem.Text);
            }
            else
            {
                FormatDropDownList.Enabled = false;
            }
		}
	}
}
