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
	public partial class NStandardFloatBar2DUC : NExampleUC
	{

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				// init form controls
				WebExamplesUtilities.FillComboWithEnumValues(BarShapeDropDownList, typeof(BarShape));
				BarShapeDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithPercents(WidthPercentDropDownList, 10);
				WidthPercentDropDownList.SelectedIndex = 6;

				WebExamplesUtilities.FillComboWithColorNames(BarColorDropDownList, KnownColor.Orange);
				
				DifferentColorsCheckBox.Checked = true;
				ShadowsCheckBox.Checked = true;
			}

			// setup legend
			nChartControl1.Legends[0].ShadowStyle.Type = ShadowType.GaussianBlur;
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("2D Float Bar");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

            // add interlace stripe
            NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			// setup floatbar series
			NFloatBarSeries floatBar = (NFloatBarSeries)chart.Series.Add(SeriesType.FloatBar);
			floatBar.BarShape = (BarShape)BarShapeDropDownList.SelectedIndex;
			floatBar.WidthPercent = WidthPercentDropDownList.SelectedIndex * 10;
			floatBar.BeginValues.ValueFormatter.FormatSpecifier = "0.00";
			floatBar.EndValues.ValueFormatter.FormatSpecifier = "0.00";

			floatBar.DataLabelStyle.Format = "<label>";
			floatBar.DataLabelStyle.VertAlign = VertAlign.Center;
			floatBar.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(8);

			// show the begin end values in the legend  
			floatBar.Legend.Format = "<begin> - <end>";
			floatBar.Legend.Mode = SeriesLegendMode.DataPoints;
			floatBar.Legend.TextStyle.FontStyle.EmSize = new NLength(8);

			if(ShadowsCheckBox.Checked)
			{
				floatBar.ShadowStyle.Type = ShadowType.LinearBlur;
				floatBar.ShadowStyle.Color = Color.FromArgb(125, 60, 60, 60);
				floatBar.ShadowStyle.Offset = new NPointL(3, 3);
			}

            // fill some data
            floatBar.AddDataPoint(new NFloatBarDataPoint(10, 20, "A"));
            floatBar.AddDataPoint(new NFloatBarDataPoint(20, 50, "B"));
            floatBar.AddDataPoint(new NFloatBarDataPoint(40, 70, "C"));
            floatBar.AddDataPoint(new NFloatBarDataPoint(65, 90, "D"));
            floatBar.AddDataPoint(new NFloatBarDataPoint(40, 60, "E"));
            floatBar.AddDataPoint(new NFloatBarDataPoint(55, 90, "F"));

			// fill styles
			if (DifferentColorsCheckBox.Checked)
			{
				BarColorDropDownList.Enabled = false;

                // apply style sheet
                NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
                styleSheet.Apply(nChartControl1.Document);
			}
			else
			{
				BarColorDropDownList.Enabled = true;

				floatBar.FillStyle = new NColorFillStyle(WebExamplesUtilities.ColorFromString(BarColorDropDownList.SelectedItem.Text));
			}

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);
		}
	}
}
