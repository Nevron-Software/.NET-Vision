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
	public partial class NXYZScatterStackUC : NExampleUC
	{
		private const int nItemsCount = 6;
	
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.Settings.JitterMode = JitterMode.Enabled;
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XYZ Scatter Stack");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 50;
			chart.Height = 35;
			chart.Depth = 50;
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

			AddBarSeries(chart, MultiBarMode.Series, "Bar1");
			AddBarSeries(chart, MultiBarMode.Stacked, "Bar2");
			AddBarSeries(chart, MultiBarMode.Stacked, "Bar3");
			AddBarSeries(chart, MultiBarMode.Stacked, "Bar4");

			GenerateData();

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);
		}

		void AddBarSeries(NChart chart, MultiBarMode mode, string name)
		{
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Name = name;
			bar.MultiBarMode = mode;
			bar.UseXValues = true;
			bar.UseZValues = true;
			bar.DataLabelStyle.Visible = false;
			bar.InflateMargins = true;
			bar.Legend.TextStyle.FontStyle.EmSize = new NLength(8, NGraphicsUnit.Point);
		}

		void GenerateData()
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

		void GenerateXYZData(NBarSeries bar)
		{
			bar.Values.Clear();
			bar.XValues.Clear();
			bar.ZValues.Clear();

			for(int i = 0; i < nItemsCount; i++)
			{
				bar.Values.Add(Random.NextDouble());
				bar.XValues.Add(Random.NextDouble() * 5);
				bar.ZValues.Add(Random.NextDouble() * 5);
			}
		}

		void GenerateYData(NBarSeries bar)
		{
			bar.Values.Clear();

			for(int i = 0; i < nItemsCount; i++)
			{
				bar.Values.Add(Random.NextDouble());
			}
		}
	}
}
