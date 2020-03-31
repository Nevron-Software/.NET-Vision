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
	public partial class NRadarLineUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithEnumValues(MarkerShapeDropDownList, typeof(PointShape));
				MarkerShapeDropDownList.SelectedIndex = 1;

				WebExamplesUtilities.FillComboWithColorNames(RadarAreaColor1DropDownList, KnownColor.Brown);
				WebExamplesUtilities.FillComboWithColorNames(RadarAreaColor2DropDownList, KnownColor.DarkOrange);

				ShowMarkersCheckBox.Checked = true;
			}

			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Radar Line");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.ContentAlignment = ContentAlignment.BottomRight;
			title.Location = new NPointL(
				new NLength(2, NRelativeUnit.ParentPercentage),
				new NLength(2, NRelativeUnit.ParentPercentage));

			// create and configure a radar chart
			NRadarChart radarChart = new NRadarChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(radarChart);
			radarChart.BoundsMode = BoundsMode.Fit;
			radarChart.Location = new NPointL(new NLength(0, NRelativeUnit.ParentPercentage), new NLength(0, NRelativeUnit.ParentPercentage));
			radarChart.Size = new NSizeL(new NLength(100, NRelativeUnit.ParentPercentage), new NLength(100, NRelativeUnit.ParentPercentage));
			radarChart.Padding = new NMarginsL(7, 7, 7, 7);
			radarChart.InnerRadius = new NLength(15);

			// set some axis labels
			AddAxis(radarChart, "Vitamin A");
			AddAxis(radarChart, "Vitamin B1");
			AddAxis(radarChart, "Vitamin B2");
			AddAxis(radarChart, "Vitamin B6");
			AddAxis(radarChart, "Vitamin B12");
			AddAxis(radarChart, "Vitamin C");
			AddAxis(radarChart, "Vitamin D");
			AddAxis(radarChart, "Vitamin E");

			Color color1 = WebExamplesUtilities.ColorFromDropDownList(RadarAreaColor1DropDownList);
			Color color2 = WebExamplesUtilities.ColorFromDropDownList(RadarAreaColor2DropDownList);

			// create the radar series
			NRadarLineSeries radarLine1 = (NRadarLineSeries)radarChart.Series.Add(SeriesType.RadarLine);
			radarLine1.Name = "Series 1";
			radarLine1.DataLabelStyle.Visible = ShowDataLabelsCheckBox.Checked;
			radarLine1.DataLabelStyle.Format = "<value>";
			radarLine1.BorderStyle.Color = color1;
			radarLine1.MarkerStyle.Visible = ShowMarkersCheckBox.Checked;
			radarLine1.MarkerStyle.PointShape = (PointShape)MarkerShapeDropDownList.SelectedIndex;
			radarLine1.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			radarLine1.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			radarLine1.MarkerStyle.FillStyle = new NColorFillStyle(color1);
			radarLine1.MarkerStyle.BorderStyle.Color = color1;
			radarLine1.Values.FillRandomRange(Random, 8, 0, 100);

			NRadarLineSeries radarLine2 = (NRadarLineSeries)radarChart.Series.Add(SeriesType.RadarLine);
			radarLine2.Name = "Series 2";
			radarLine2.DataLabelStyle.Visible = ShowDataLabelsCheckBox.Checked;
			radarLine2.DataLabelStyle.Format = "<value>";
			radarLine2.BorderStyle.Color = color2;
			radarLine2.MarkerStyle.Visible = ShowMarkersCheckBox.Checked;
			radarLine2.MarkerStyle.PointShape = (PointShape)MarkerShapeDropDownList.SelectedIndex;
			radarLine2.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			radarLine2.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			radarLine2.MarkerStyle.FillStyle = new NColorFillStyle(color2);
			radarLine2.MarkerStyle.BorderStyle.Color = color2;
			radarLine2.Values.FillRandomRange(Random, 8, 0, 100);
		}

		private void AddAxis(NRadarChart radarChart, string title)
		{
			NRadarAxis axis = new NRadarAxis();

			// set title
			axis.Title = title;
			axis.TitleAngle = new NScaleLabelAngle(ScaleLabelAngleMode.View, 0);

			// setup scale
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)axis.ScaleConfigurator;

			linearScale.RulerStyle.BorderStyle.Color = Color.Silver;
			linearScale.InnerMajorTickStyle.LineStyle.Color = Color.Silver;
			linearScale.OuterMajorTickStyle.LineStyle.Color = Color.Silver;
			linearScale.InnerMajorTickStyle.Length = new NLength(2, NGraphicsUnit.Point);
			linearScale.OuterMajorTickStyle.Length = new NLength(2, NGraphicsUnit.Point);

			if (radarChart.Axes.Count == 0)
			{
				// if the first axis then configure grid style and stripes
				linearScale.MajorGridStyle.LineStyle.Color = Color.Gainsboro;
				linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
				linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Radar, true);

			}
			else
			{
				// hide labels
				linearScale.AutoLabels = false;
			}

			radarChart.Axes.Add(axis);
		}

	}
}
