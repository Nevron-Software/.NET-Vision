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
	public partial class NAnchorPanelsUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				MiniChartTypeDropDownList.Items.Add("Pie");
				MiniChartTypeDropDownList.Items.Add("Doughnut");
				MiniChartTypeDropDownList.Items.Add("Bar");
				MiniChartTypeDropDownList.Items.Add("Area");
				MiniChartTypeDropDownList.SelectedIndex = 0;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Anchor panels");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// configure chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			NLinearScaleConfigurator linearScaleConfigurator = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleConfigurator;
			chart.Axis(StandardAxis.Depth).Visible = false;  

			UpdateMiniCharts(chart);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}

		private void UpdateMiniCharts(NChart chart)
		{
			chart.RemoveDescendantsOfType(typeof(NAnchorPanel));
			chart.Series.Clear();

			// add a master point series
			NPointSeries pointSeries = (NPointSeries)chart.Series.Add(SeriesType.Point);
			pointSeries.UseXValues = true;
			pointSeries.InflateMargins = true;
			pointSeries.DataLabelStyle.Visible = false;
			pointSeries.Size = new NLength(12, NRelativeUnit.ParentPercentage);
			pointSeries.FillStyle = new NColorFillStyle(Color.Gainsboro);

			// fill the point series with data
			for (int i = 0; i < 5; i++)
			{
				pointSeries.Values.Add(2 + Random.NextDouble() * 10);
				pointSeries.XValues.Add(2 + Random.NextDouble() * 10);
			}

			// create anchor panels attached to the point series data points
			for (int pointIndex = 0; pointIndex < pointSeries.Values.Count; pointIndex++)
			{
				NAnchorPanel anchorPanel = new NAnchorPanel();
				chart.ChildPanels.Add(anchorPanel);

				anchorPanel.Size = new NSizeL(
					new NLength(10, NRelativeUnit.ParentPercentage),
					new NLength(10, NRelativeUnit.ParentPercentage));

				anchorPanel.Anchor = new NDataPointAnchor(pointSeries, pointIndex, ContentAlignment.MiddleCenter, StringAlignment.Near);
				anchorPanel.ContentAlignment = ContentAlignment.MiddleCenter;
				anchorPanel.ChildPanels.Add(CreateAnchorPanelChart());
			}
		}

		private NChart CreateAnchorPanelChart()
		{
			NChart chart = null;
			NSeries series = null;
            NLinearScaleConfigurator linearScale;

			switch (MiniChartTypeDropDownList.SelectedIndex)
			{
				case 0: // Pie
					chart = new NPieChart();
					series = (NSeries)chart.Series.Add(SeriesType.Pie);
					SetDataPointColors(series);
					break;

				case 1: // Doughnut
					chart = new NPieChart();
					NPieSeries pie = (NPieSeries)chart.Series.Add(SeriesType.Pie);
					pie.PieStyle = PieStyle.Ring;
					((NPieChart)chart).InnerRadius = new NLength(25, NRelativeUnit.ParentPercentage);
					series = pie;
					SetDataPointColors(series);
					break;

                case 2: // Bar
					chart = new NCartesianChart();

					chart.Wall(ChartWallType.Back).Visible = false;
					chart.Axis(StandardAxis.PrimaryX).Visible = false;
					chart.Axis(StandardAxis.PrimaryY).Visible = false;
					chart.Axis(StandardAxis.Depth).Visible = false;

					linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
					linearScale.MajorGridStyle.LineStyle.Width = new NLength(0);

					series = (NSeries)chart.Series.Add(SeriesType.Bar);
					SetDataPointColors(series);
					break;

                case 3: // Area
					chart = new NCartesianChart();

					chart.Wall(ChartWallType.Back).Visible = false;
					chart.Axis(StandardAxis.PrimaryX).Visible = false;
					chart.Axis(StandardAxis.PrimaryY).Visible = false;
					chart.Axis(StandardAxis.Depth).Visible = false;

					linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
					linearScale.MajorGridStyle.LineStyle.Width = new NLength(0);

					series = (NSeries)chart.Series.Add(SeriesType.Area);
					series.FillStyle = new NColorFillStyle(DarkOrange);
					break;
			}

			chart.BoundsMode = BoundsMode.Fit;
			chart.DockMode = PanelDockMode.Fill;

			series.DataLabelStyle.Visible = false;

			for(int i = 0; i < 5; i++)
			{
				series.Values.Add(5 + Random.Next(10));
			}

			return chart;
		}

		void SetDataPointColors(NSeries series)
		{
            NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Fresh);

            for (int i = 0; i < 5; i++)
            {
			    series.FillStyles[i] = new NColorFillStyle(palette.SeriesColors[i]);
            }
		}
	}
}
