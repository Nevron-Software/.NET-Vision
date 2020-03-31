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
	public partial class NXYZScatterClusterUC : NExampleUC
	{
		private const int nItemsCount = 5;

		protected void Page_Load(object sender, EventArgs e)
		{
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XYZ Scatter Cluster");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup horizontal chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 60;
			chart.Height = 40;
			chart.Depth = 60;
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight);
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.Projection.Elevation += 5;

			// setup Y axis
			NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// add interlaced stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };
			linearScaleConfigurator.StripStyles.Add(stripStyle);

			// setup X axis
			linearScaleConfigurator = new NLinearScaleConfigurator();
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Back, ChartWallType.Floor };
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleConfigurator;

			// setup Z axis
			linearScaleConfigurator = new NLinearScaleConfigurator();
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Left, ChartWallType.Floor };
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScaleConfigurator;

			AddBarSeries(chart, MultiBarMode.Series, "Bar 1");
			AddBarSeries(chart, MultiBarMode.Clustered, "Bar 2");
			AddBarSeries(chart, MultiBarMode.Stacked, "Bar 3");
			AddBarSeries(chart, MultiBarMode.Clustered, "Bar 4");
			AddBarSeries(chart, MultiBarMode.Stacked, "Bar 5");

			GenerateData();

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);
		}

		private void AddBarSeries(NChart chart, MultiBarMode mode, string name)
		{
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            bar.MultiBarMode = mode;
			bar.Name = name;
			bar.UseXValues = true;
			bar.UseZValues = true;
			bar.GapPercent = 30;
			bar.DataLabelStyle.Visible = false;
			bar.InflateMargins = true;
			bar.Legend.TextStyle.FontStyle.EmSize = new NLength(8, NGraphicsUnit.Point);
		}

		private void GenerateData()
		{
			NChart chart = nChartControl1.Charts[0];

			for(int i = 0; i < chart.Series.Count; i++)
			{
				NBarSeries bar = (NBarSeries)chart.Series[i];

				if(i == 0)
				{
					// the master series needs Y, X and Z values
					GenerateXYZData(bar);
				}
				else
				{
					// the other series need only Y values
					GenerateYData(bar);
				}
			}
		}

		private void GenerateXYZData(NBarSeries bar)
		{
			bar.Values.Clear();
			bar.XValues.Clear();
			bar.ZValues.Clear();

			double dValueX = Random.NextDouble() * 5;

			for(int i = 0; i < nItemsCount; i++)
			{
				bar.Values.Add(Random.NextDouble());
				bar.XValues.Add(dValueX);
				bar.ZValues.Add(Random.NextDouble() * 5);

				dValueX += 0.2 + Random.NextDouble();
			}
		}

		private void GenerateYData(NBarSeries bar)
		{
			bar.Values.Clear();

			for(int i = 0; i < nItemsCount; i++)
			{
				bar.Values.Add(Random.NextDouble());
			}
		}
	}
}
