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
	public partial class NMarkersUC : NExampleUC
	{
		protected System.Web.UI.WebControls.DropDownList MarkerStyleDropDown;
		protected System.Web.UI.WebControls.DropDownList Marker3StyleDropDown;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithEnumValues(MarkerShapeDropDown, typeof(PointShape));
				MarkerShapeDropDown.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithEnumValues(Marker3ShapeDropDown, typeof(PointShape));
				Marker3ShapeDropDown.SelectedIndex = 1;

				WebExamplesUtilities.FillComboWithValues(WidthDropDownList, 0, 5, 1);
				WebExamplesUtilities.FillComboWithValues(HeightDropDownList, 0, 5, 1);
				WebExamplesUtilities.FillComboWithPercents(DepthDropDownList, 10);
				WebExamplesUtilities.FillComboWithPercents(LineDepthDropDownList, 10);
				WebExamplesUtilities.FillComboWithColorNames(MarkerColorDropDown, KnownColor.Tan);
				WebExamplesUtilities.FillComboWithColorNames(Marker3ColorDropDown, KnownColor.Salmon);

                LineDepthDropDownList.SelectedIndex = 3;
				WidthDropDownList.SelectedIndex = 2;
				HeightDropDownList.SelectedIndex = 2;
				AutoDepthCheckBox.Checked = true;
				MarkersVisibleCheckBox.Checked = true;
			}

			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Series Markers");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
            chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			chart.Axis(StandardAxis.Depth).Visible = false;

            // add interlaced stripe
            NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScaleConfigurator.StripStyles.Add(stripStyle);

			NLineSeries line = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line.InflateMargins = true;
			line.Legend.Mode = SeriesLegendMode.DataPoints;
			line.LineSegmentShape = LineSegmentShape.Line;
			line.Values.FillRandom(Random, 5);
			line.DataLabelStyle.Visible = false;
            line.FillStyle = new NColorFillStyle(Color.DarkGray);
            line.BorderStyle.Color = Color.DarkGray;

			DepthDropDownList.Enabled = !AutoDepthCheckBox.Checked;
			line.MarkerStyle.AutoDepth = AutoDepthCheckBox.Checked;

			if (AutoDepthCheckBox.Checked)
			{
				line.MarkerStyle.Depth = new NLength((float)(DepthDropDownList.SelectedIndex * 10), NRelativeUnit.ParentPercentage);	
			}

			line.DepthPercent = LineDepthDropDownList.SelectedIndex * 10;
			line.MarkerStyle.Height = new NLength((float)HeightDropDownList.SelectedIndex, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Width = new NLength((float)WidthDropDownList.SelectedIndex, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Visible = MarkersVisibleCheckBox.Checked;
			line.MarkerStyle.FillStyle = new NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(MarkerColorDropDown));
            line.MarkerStyle.BorderStyle.Color = WebExamplesUtilities.ColorFromDropDownList(MarkerColorDropDown);
			line.MarkerStyle.PointShape = (PointShape)MarkerShapeDropDown.SelectedIndex;

			NMarkerStyle marker = new NMarkerStyle();
			marker.Visible = true;
			marker.FillStyle = new NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(Marker3ColorDropDown));
            marker.BorderStyle.Color = WebExamplesUtilities.ColorFromDropDownList(Marker3ColorDropDown);
			marker.PointShape = (PointShape)Marker3ShapeDropDown.SelectedIndex;
			line.MarkerStyles[3] = marker;

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);
		}
	}
}
