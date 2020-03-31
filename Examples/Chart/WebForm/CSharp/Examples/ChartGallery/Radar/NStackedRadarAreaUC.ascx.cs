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
	public partial class NStackedRadarAreaUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				StackModeDropDownList.Items.Clear();
				StackModeDropDownList.Items.Add("Stacked");
				StackModeDropDownList.Items.Add("Stacked %");
				StackModeDropDownList.SelectedIndex = 0;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Stacked Radar Area");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);

			// configure the chart
			NRadarChart radarChart = new NRadarChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(radarChart);
			radarChart.Wall(ChartWallType.Radar).BorderStyle.Color = Color.White;
			radarChart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			radarChart.DisplayOnLegend = nChartControl1.Legends[0];

			AddAxis(radarChart, "Category A");
			AddAxis(radarChart, "Category B");
			AddAxis(radarChart, "Category C");
			AddAxis(radarChart, "Category D");
			AddAxis(radarChart, "Category E");

			// create the radar series
			NRadarAreaSeries radarArea0 = new NRadarAreaSeries();
			radarChart.Series.Add(radarArea0);
			radarArea0.Name = "Series 1";
			radarArea0.Values.FillRandomRange(Random, 5, 50, 90);
			radarArea0.DataLabelStyle.Visible = false;
			radarArea0.DataLabelStyle.Format = "<value>";
			radarArea0.MarkerStyle.AutoDepth = true;
			radarArea0.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			radarArea0.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);

			NRadarAreaSeries radarArea1 = new NRadarAreaSeries();
			radarChart.Series.Add(radarArea1);
			radarArea1.Name = "Series 2";
			radarArea1.Values.FillRandomRange(Random, 5, 0, 100);
			radarArea1.DataLabelStyle.Visible = false;
			radarArea1.DataLabelStyle.Format = "<value>";
			radarArea1.MarkerStyle.AutoDepth = true;
			radarArea1.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			radarArea1.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);

			NRadarAreaSeries radarArea2 = new NRadarAreaSeries();
			radarChart.Series.Add(radarArea2);
			radarArea2.Name = "Series 3";
			radarArea2.Values.FillRandomRange(Random, 5, 0, 100);
			radarArea2.DataLabelStyle.Visible = false;
			radarArea2.DataLabelStyle.Format = "<value>";
			radarArea2.MarkerStyle.AutoDepth = true;
			radarArea2.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			radarArea2.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);

			// set the stack mode
			if (StackModeDropDownList.SelectedIndex == 0)
			{
				radarArea1.MultiAreaMode = MultiAreaMode.Stacked;
				radarArea2.MultiAreaMode = MultiAreaMode.Stacked;
			}
			else
			{
				radarArea1.MultiAreaMode = MultiAreaMode.StackedPercent;
				radarArea2.MultiAreaMode = MultiAreaMode.StackedPercent;
			}

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Bright);
			styleSheet.Apply(nChartControl1.Charts[0].Series);

			radarArea0.FillStyle.SetTransparencyPercent(20);
			radarArea1.FillStyle.SetTransparencyPercent(20);
			radarArea2.FillStyle.SetTransparencyPercent(20);

			// apply layout template
			ApplyLayoutTemplate(0, nChartControl1, radarChart, title, nChartControl1.Legends[0]);
		}

		private void AddAxis(NRadarChart radarChart, string title)
		{
			NRadarAxis axis = new NRadarAxis();

			// set title
			axis.Title = title;

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

				// add interlaced stripe
				NScaleStripStyle strip = new NScaleStripStyle();
				strip.FillStyle = new NColorFillStyle(Color.FromArgb(64, 200, 200, 200));
				strip.Interlaced = true;
				strip.SetShowAtWall(ChartWallType.Radar, true);
				linearScale.StripStyles.Add(strip);
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