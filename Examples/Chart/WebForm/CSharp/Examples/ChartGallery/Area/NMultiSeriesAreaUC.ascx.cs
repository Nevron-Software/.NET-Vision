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
	public partial class NMultiSeriesAreaUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Multi Series Area Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 70;
			chart.Height = 30;
			chart.Depth = 50;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			// setup Y axis
			NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };
            linearScaleConfigurator.StripStyles.Add(stripStyle);

			// setup X axis
			NOrdinalScaleConfigurator ordinalScaleConfigurator = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			ordinalScaleConfigurator.DisplayDataPointsBetweenTicks = false;
			ordinalScaleConfigurator.MajorTickMode = MajorTickMode.AutoMaxCount;
			ordinalScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			ordinalScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Back, ChartWallType.Floor };

			// setup Z axis
			ordinalScaleConfigurator = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.Depth).ScaleConfigurator;
			ordinalScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			ordinalScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Left, ChartWallType.Floor };

			// add the first Area
			NAreaSeries area1 = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			area1.Name = "Area 1";
			area1.MultiAreaMode = MultiAreaMode.Series;
			area1.DataLabelStyle.Visible = false;
			area1.Legend.TextStyle.FontStyle.EmSize = new NLength(8);

			// add the second Area
			NAreaSeries area2 = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			area2.Name = "Area 2";
			area2.MultiAreaMode = MultiAreaMode.Series;
			area2.DataLabelStyle.Visible = false;
			area2.Legend.TextStyle.FontStyle.EmSize = new NLength(8);

			// add the third Area
			NAreaSeries area3 = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			area3.Name = "Area 3";
			area3.MultiAreaMode = MultiAreaMode.Series;
			area3.DataLabelStyle.Visible = false;
			area3.Legend.TextStyle.FontStyle.EmSize = new NLength(8);

			// fill with random data
			area1.Values.FillRandomRange(Random, 10, 10, 40);
			area2.Values.FillRandomRange(Random, 10, 30, 60);
			area3.Values.FillRandomRange(Random, 10, 50, 80);

			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithPercents(AreaDepthDropDownList, 10);

				AreaDepthDropDownList.SelectedIndex = 5;
			}

			// modify the depth percent
			area1.DepthPercent = WebExamplesUtilities.GetPercentFromCombo(AreaDepthDropDownList, 10);
			area2.DepthPercent = WebExamplesUtilities.GetPercentFromCombo(AreaDepthDropDownList, 10);
			area3.DepthPercent = WebExamplesUtilities.GetPercentFromCombo(AreaDepthDropDownList, 10);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);
		}
	}
}

