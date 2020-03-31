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
	public partial class NStandardLine2DUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				// fill the combo
				LineStyleDropDownList.Items.Add("Line");
				LineStyleDropDownList.Items.Add("Tape");
				LineStyleDropDownList.Items.Add("Tube");
				LineStyleDropDownList.Items.Add("Ellipsoid");
				LineStyleDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithEnumValues(MarkerShapeDropDownList, typeof(PointShape));
				MarkerShapeDropDownList.SelectedIndex = 7;

				WebExamplesUtilities.FillComboWithValues(LineWidthDropDownList, 0, 5, 1);
				LineWidthDropDownList.SelectedIndex = 1;

				WebExamplesUtilities.FillComboWithColorNames(LineColorDropDownList);
                LineColorDropDownList.SelectedIndex = 34;

				WebExamplesUtilities.FillComboWithColorNames(LineFillColorDropDownList);
				LineFillColorDropDownList.SelectedIndex = 72;

				WebExamplesUtilities.FillComboWithValues(MarkerSizeDropDownList, 0, 10, 1);
				MarkerSizeDropDownList.SelectedIndex = 2;

				ShowMarkersCheckBox.Checked = true;
				LeftAxisRoundToTickCheckBox.Checked = true;
				InflateMarginsCheckBox.Checked = true;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("2D Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScaleConfigurator.RoundToTickMin = LeftAxisRoundToTickCheckBox.Checked;
			linearScaleConfigurator.RoundToTickMax = LeftAxisRoundToTickCheckBox.Checked;
			chart.Axis(StandardAxis.Depth).Visible = false;

			// setup the line series
			NLineSeries line = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line.Values.FillRandom(Random, 10);
			line.DataLabelStyle.Visible = false;
			line.Legend.Mode = SeriesLegendMode.DataPoints;

			line.BorderStyle.Width = new NLength(LineWidthDropDownList.SelectedIndex, NGraphicsUnit.Pixel);
			line.BorderStyle.Color = WebExamplesUtilities.ColorFromDropDownList(LineColorDropDownList);
			line.FillStyle = new NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(LineFillColorDropDownList));

			line.InflateMargins = InflateMarginsCheckBox.Checked;
			line.MarkerStyle.Visible = ShowMarkersCheckBox.Checked;

			line.ShadowStyle.Type = ShadowType.GaussianBlur;
			line.ShadowStyle.Offset = new NPointL(new NLength(3, NGraphicsUnit.Pixel), new NLength(3, NGraphicsUnit.Pixel));
			line.ShadowStyle.FadeLength = new NLength(5, NGraphicsUnit.Pixel);
			line.ShadowStyle.Color = Color.FromArgb(55, 0, 0, 0);

			bool bSimpleLine = (LineStyleDropDownList.SelectedIndex == 0);

			switch (LineStyleDropDownList.SelectedIndex)
			{
				case 0: // line
					line.LineSegmentShape = LineSegmentShape.Line; 
					break;

				case 1: // tape
					line.LineSegmentShape = LineSegmentShape.Tape;
					break;

				case 2: // tube
					line.LineSegmentShape = LineSegmentShape.Tube;
					break;

				case 3: // elipsoid
					line.LineSegmentShape = LineSegmentShape.Ellipsoid;
					break;
			}

			LineFillColorDropDownList.Enabled = !bSimpleLine;

			MarkerShapeDropDownList.Enabled = ShowMarkersCheckBox.Checked;
			MarkerSizeDropDownList.Enabled = ShowMarkersCheckBox.Checked;

			if (line.MarkerStyle.Visible)
			{
				line.MarkerStyle.PointShape = (PointShape)MarkerShapeDropDownList.SelectedIndex;
				line.MarkerStyle.Height = new NLength((float)MarkerSizeDropDownList.SelectedIndex, NRelativeUnit.ParentPercentage);
				line.MarkerStyle.Width = new NLength((float)MarkerSizeDropDownList.SelectedIndex, NRelativeUnit.ParentPercentage);
				line.MarkerStyle.FillStyle = new NColorFillStyle(Red);
				line.MarkerStyle.BorderStyle.Color = WebExamplesUtilities.ColorFromDropDownList(LineColorDropDownList);
			}

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}
	}
}
