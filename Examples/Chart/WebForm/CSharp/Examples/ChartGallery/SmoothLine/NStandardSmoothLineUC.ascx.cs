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
	public partial class NStandardSmoothLineUC : NExampleUC
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList LineStyleDropDownList;
		private const int nValuesCount = 8;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithEnumValues(MarkerShapeDropDownList, typeof(PointShape));
				MarkerShapeDropDownList.SelectedIndex = 7;

				WebExamplesUtilities.FillComboWithValues(LineWidthDropDownList, 0, 5, 1);
				LineWidthDropDownList.SelectedIndex = 1;

				WebExamplesUtilities.FillComboWithColorNames(LineColorDropDownList, KnownColor.Orange);

				WebExamplesUtilities.FillComboWithValues(MarkerSizeDropDownList, 0, 10, 1);
				MarkerSizeDropDownList.SelectedIndex = 2;

				ShowMarkersCheckBox.Checked = true;
				LeftAxisRoundToTickCheckBox.Checked = true;
				InflateMarginsCheckBox.Checked = true;
			}

			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Smooth Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			// setup Y axis
			NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScaleConfigurator.RoundToTickMin = LeftAxisRoundToTickCheckBox.Checked;
			linearScaleConfigurator.RoundToTickMax = LeftAxisRoundToTickCheckBox.Checked;

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScaleConfigurator.StripStyles.Add(stripStyle);

			// add the line
			NSmoothLineSeries line = (NSmoothLineSeries)chart.Series.Add(SeriesType.SmoothLine);
			line.Name = "Smooth Line";
			line.UseXValues = false;
			line.UseZValues = false;
			line.InflateMargins = InflateMarginsCheckBox.Checked;
			line.DataLabelStyle.Visible = false;
			line.MarkerStyle.Visible = ShowMarkersCheckBox.Checked;
			line.MarkerStyle.AutoDepth = false;
			line.MarkerStyle.PointShape = (PointShape)MarkerShapeDropDownList.SelectedIndex;
			line.MarkerStyle.Height = new NLength((float)MarkerSizeDropDownList.SelectedIndex, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Width = new NLength((float)MarkerSizeDropDownList.SelectedIndex, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Depth = new NLength((float)MarkerSizeDropDownList.SelectedIndex, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.BorderStyle.Color = WebExamplesUtilities.ColorFromDropDownList(LineColorDropDownList);
			line.MarkerStyle.FillStyle = new NColorFillStyle(Red);
			line.BorderStyle.Width = new NLength(LineWidthDropDownList.SelectedIndex, NGraphicsUnit.Pixel);
			line.BorderStyle.Color = WebExamplesUtilities.ColorFromDropDownList(LineColorDropDownList);

            if (ShowMarkersCheckBox.Checked)
            {
                MarkerSizeDropDownList.Enabled = true;
				MarkerShapeDropDownList.Enabled = true;
            }
            else
            {
                MarkerSizeDropDownList.Enabled = false;
				MarkerShapeDropDownList.Enabled = false;
            }

			GenreateYValues(nValuesCount);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}

		private void GenreateYValues(int nCount)
		{
			NChart chart = nChartControl1.Charts[0];
			NSeries series = (NSeries)chart.Series[0];

			series.Values.Clear();

			for(int i = 0; i < nCount; i++)
			{
				series.Values.Add(Random.NextDouble() * 20);
			}
		}
	}
}
