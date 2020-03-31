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
	public partial class NRadarAreaUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithEnumValues(MarkerShapeDropDownList, typeof(PointShape));
				MarkerShapeDropDownList.SelectedIndex = 1;

				WebExamplesUtilities.FillComboWithColorNames(RadarColor1DropDownList, KnownColor.SlateBlue);
				WebExamplesUtilities.FillComboWithColorNames(RadarColor2DropDownList, KnownColor.Crimson);

				ShowMarkersCheckBox.Checked = true;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Radar Area");
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

			// set some axis labels
			AddAxis(radarChart, "Vitamin A");
			AddAxis(radarChart, "Vitamin B1");
			AddAxis(radarChart, "Vitamin B2");
			AddAxis(radarChart, "Vitamin B6");
			AddAxis(radarChart, "Vitamin B12");
			AddAxis(radarChart, "Vitamin C");
			AddAxis(radarChart, "Vitamin D");
			AddAxis(radarChart, "Vitamin E");

			Color color1 = WebExamplesUtilities.ColorFromDropDownList(RadarColor1DropDownList);
			Color color2 = WebExamplesUtilities.ColorFromDropDownList(RadarColor2DropDownList);

			// setup radar series 1
			NRadarAreaSeries radarArea1 = (NRadarAreaSeries)radarChart.Series.Add(SeriesType.RadarArea);
			radarArea1.Name = "Series 1";
			radarArea1.DataLabelStyle.Visible = ShowDataLabelsCheckBox.Checked;
			radarArea1.DataLabelStyle.Format = "<value>";
			radarArea1.BorderStyle.Color = color1;
			radarArea1.FillStyle = new NColorFillStyle(Color.FromArgb(125, color1));
			radarArea1.MarkerStyle.Visible = ShowMarkersCheckBox.Checked;
			radarArea1.MarkerStyle.PointShape = (PointShape)MarkerShapeDropDownList.SelectedIndex;
			radarArea1.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			radarArea1.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			radarArea1.MarkerStyle.FillStyle = new NColorFillStyle(color1);
			radarArea1.MarkerStyle.BorderStyle.Color = color1;
			radarArea1.Values.FillRandomRange(Random, 8, 0, 100);

			// setup radar series 2
			NRadarAreaSeries radarArea2 = (NRadarAreaSeries)radarChart.Series.Add(SeriesType.RadarArea);
			radarArea2.Name = "Series 2";
			radarArea2.DataLabelStyle.Visible = ShowDataLabelsCheckBox.Checked;
			radarArea2.DataLabelStyle.Format = "<value>";
			radarArea2.BorderStyle.Color = color2;
			radarArea2.FillStyle = new NColorFillStyle(Color.FromArgb(125, color2));
			radarArea2.MarkerStyle.Visible = ShowMarkersCheckBox.Checked;
			radarArea2.MarkerStyle.PointShape = (PointShape)MarkerShapeDropDownList.SelectedIndex;
			radarArea2.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			radarArea2.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			radarArea2.MarkerStyle.FillStyle = new NColorFillStyle(color2);
			radarArea2.MarkerStyle.BorderStyle.Color = color2;
			radarArea2.Values.FillRandomRange(Random, 8, 0, 100);
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