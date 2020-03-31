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
	public partial class NStandardPointUC : NExampleUC
	{
		protected CheckBox InflateMarginsCheckBoxBox;
		protected CheckBox LeftAxisLeftAxisRoundToTickCheckBoxBox;
		protected CheckBox DifferentColorsCheckBoxBox;
		protected CheckBox ShowDataLabelsCheckBoxCheckBox;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithEnumValues(PointShapeDropDownList, typeof(PointShape));
				PointShapeDropDownList.SelectedIndex = 0;

				DataLabelFormatDropDownList.Items.Add("Value and Label");
				DataLabelFormatDropDownList.Items.Add("Value");
				DataLabelFormatDropDownList.Items.Add("Label");
				DataLabelFormatDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithValues(PointSizeDropDownList, 0, 10, 1);
				PointSizeDropDownList.SelectedIndex = 4;

				WebExamplesUtilities.FillComboWithColorNames(PointColorDropDownList, KnownColor.Orange);

                DifferentColorsCheckBox.Checked = true;
				LeftAxisRoundToTickCheckBox.Checked = true;
				ShowDataLabelsCheckBox.Checked = true;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Point Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			// setup Y axis
			NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScaleConfigurator.RoundToTickMin = LeftAxisRoundToTickCheckBox.Checked;
			linearScaleConfigurator.RoundToTickMax = LeftAxisRoundToTickCheckBox.Checked;

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScaleConfigurator.StripStyles.Add(stripStyle);

			// hide the depth axis
			chart.Axis(StandardAxis.Depth).Visible = false;

			// setup point series
			NPointSeries point = (NPointSeries)chart.Series.Add(SeriesType.Point);
			point.Name = "Point Series";
			point.Legend.Format = "<label>";
			point.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(7);
			point.PointShape = (PointShape)PointShapeDropDownList.SelectedIndex;
			point.Size = new NLength((float)PointSizeDropDownList.SelectedIndex, NRelativeUnit.ParentPercentage);
			point.InflateMargins = InflateMarginsCheckBox.Checked;

			point.AddDataPoint(new NDataPoint(23, "A"));
			point.AddDataPoint(new NDataPoint(67, "B"));
			point.AddDataPoint(new NDataPoint(47, "C"));
			point.AddDataPoint(new NDataPoint(12, "D"));
			point.AddDataPoint(new NDataPoint(56, "E"));
			point.AddDataPoint(new NDataPoint(78, "F"));

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);

			if (DifferentColorsCheckBox.Checked)
			{
				PointColorDropDownList.Enabled = false;

                NChartPalette palette = new NChartPalette();
                palette.SetPredefinedPalette(ChartPredefinedPalette.Nevron);

				for (int i = 0; i < point.Values.Count; i++)
				{
                    point.FillStyles[i] = new NColorFillStyle(palette.SeriesColors[i % palette.SeriesColors.Count]);
				}

				point.Legend.Mode = SeriesLegendMode.DataPoints;
			}
			else
			{
				PointColorDropDownList.Enabled = true;
				point.FillStyles.Clear();
				point.FillStyle = new NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(PointColorDropDownList));
				point.Legend.Mode = SeriesLegendMode.Series;
			}

			if (ShowDataLabelsCheckBox.Checked)
			{
				point.DataLabelStyle.Visible = true;
				DataLabelFormatDropDownList.Enabled = true;

				switch (DataLabelFormatDropDownList.SelectedIndex)
				{
					case 0:
						point.DataLabelStyle.Format = "<value> <label>";
						break;

					case 1:
						point.DataLabelStyle.Format = "<value>";
						break;

					case 2:
						point.DataLabelStyle.Format = "<label>";
						break;
				}
			}
			else
			{
				point.DataLabelStyle.Visible = false;
				DataLabelFormatDropDownList.Enabled = false;
			}
		}
	}
}