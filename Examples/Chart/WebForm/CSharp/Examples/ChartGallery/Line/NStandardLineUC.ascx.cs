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
	public partial class NStandardLineUC : NExampleUC
	{
		//protected NChart nChart;
		//protected NLineSeries nLine;

		protected CheckBox LightsCheckBoxBox;
		protected CheckBox InflateMarginsCheckBoxBox;
		protected CheckBox LeftAxisRoundToTickCheckBoxBox;
		protected CheckBox ShowMarkersCheckBoxBox;

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
				MarkerShapeDropDownList.SelectedIndex = 1;

				WebExamplesUtilities.FillComboWithPercents(LineDepthDropDownList, 10);
				LineDepthDropDownList.SelectedIndex = 4;

				WebExamplesUtilities.FillComboWithValues(LineWidthDropDownList, 0, 5, 1);
				LineWidthDropDownList.SelectedIndex = 1;

				WebExamplesUtilities.FillComboWithColorNames(LineColorDropDownList, KnownColor.DarkSalmon);
				WebExamplesUtilities.FillComboWithColorNames(LineFillColorDropDownList, KnownColor.LightSalmon);

				WebExamplesUtilities.FillComboWithValues(MarkerSizeDropDownList, 0, 10, 1);
				MarkerSizeDropDownList.SelectedIndex = 2;

				ShowMarkersCheckBox.Checked = true;
				LeftAxisRoundToTickCheckBox.Checked = true;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("3D Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

            NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
            chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective2);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			chart.Axis(StandardAxis.Depth).Visible = false;

			// setup Y axis
			NLinearScaleConfigurator scaleY = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			scaleY.RoundToTickMin = LeftAxisRoundToTickCheckBox.Checked;
			scaleY.RoundToTickMax = LeftAxisRoundToTickCheckBox.Checked;

            // add Y axis interlaced stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
			scaleY.StripStyles.Add(stripStyle);

			// setup X axis
			NOrdinalScaleConfigurator scaleX = chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount;
			scaleX.DisplayDataPointsBetweenTicks = false;

			// setup the line series
            NLineSeries nLine = (NLineSeries)chart.Series.Add(SeriesType.Line);
			nLine.Values.FillRandom(Random, 10);
			nLine.DataLabelStyle.Visible = false;
			nLine.Legend.Mode = SeriesLegendMode.DataPoints;

			nLine.BorderStyle.Width = new NLength(LineWidthDropDownList.SelectedIndex, NGraphicsUnit.Pixel);
			nLine.DepthPercent = LineDepthDropDownList.SelectedIndex * 10;
			nLine.BorderStyle.Color = WebExamplesUtilities.ColorFromDropDownList(LineColorDropDownList);
			nLine.FillStyle = new NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(LineFillColorDropDownList));

			nLine.InflateMargins = InflateMarginsCheckBox.Checked;
			nLine.MarkerStyle.Visible = ShowMarkersCheckBox.Checked;

			bool bSimpleLine = (LineStyleDropDownList.SelectedIndex == 0);

			switch (LineStyleDropDownList.SelectedIndex)
			{
				case 0: // simple line
					nLine.LineSegmentShape = LineSegmentShape.Line; 
					break;

				case 1: // tape
					nLine.LineSegmentShape = LineSegmentShape.Tape;
					break;

				case 2: // tube
					nLine.LineSegmentShape = LineSegmentShape.Tube;
					break;

				case 3: // elipsoid
					nLine.LineSegmentShape = LineSegmentShape.Ellipsoid;
					break;
			}

			LineDepthDropDownList.Enabled = !bSimpleLine;
			LineFillColorDropDownList.Enabled = !bSimpleLine;

			MarkerShapeDropDownList.Enabled = ShowMarkersCheckBox.Checked;
			MarkerSizeDropDownList.Enabled = ShowMarkersCheckBox.Checked;

			if (nLine.MarkerStyle.Visible)
			{
				nLine.MarkerStyle.PointShape = (PointShape)MarkerShapeDropDownList.SelectedIndex;
				nLine.MarkerStyle.Height = new NLength((float)MarkerSizeDropDownList.SelectedIndex, NRelativeUnit.ParentPercentage);
				nLine.MarkerStyle.Width = new NLength((float)MarkerSizeDropDownList.SelectedIndex, NRelativeUnit.ParentPercentage);
                nLine.MarkerStyle.FillStyle = new NColorFillStyle(Red);
				nLine.MarkerStyle.BorderStyle.Color = WebExamplesUtilities.ColorFromDropDownList(LineColorDropDownList);
			}

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);			
		}
	}
}