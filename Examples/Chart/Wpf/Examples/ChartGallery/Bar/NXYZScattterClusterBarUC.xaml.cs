using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.Dom;
using Nevron.GraphicsCore;
using System.Drawing;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NXYZScattterClusterBarUC : NExampleBaseUC
	{
		private const int nItemsCount = 5;

		public NXYZScattterClusterBarUC()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Gets the title of this example
		/// </summary>
		public override string Title
		{
			get
			{
				return "XYZ Scatter Cluster Bar";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a 3D cluster - stack combination chart with custom X and Z positions for each cluster.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;

			nChartControl1.Controller.Selection.Add(chart);
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XYZ Cluster Bar");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// set predefined projection and lighting
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight);
			chart.Width = 50;
			chart.Height = 35;
			chart.Depth = 50;

			// configure the axes
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);

			linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

			// add interlace stripes to the Y axis
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			stripStyle.Interlaced = true;
			linearScale.StripStyles.Add(stripStyle);

			linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);

			// add some data
			AddBarSeries(chart, MultiBarMode.Series);
			AddBarSeries(chart, MultiBarMode.Clustered);
			AddBarSeries(chart, MultiBarMode.Stacked);
			AddBarSeries(chart, MultiBarMode.Clustered);
			AddBarSeries(chart, MultiBarMode.Stacked);

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			GenerateData();
			nChartControl1.Refresh();
		}

		private void AddBarSeries(NChart chart, MultiBarMode mode)
		{
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.MultiBarMode = mode;
			bar.UseXValues = true;
			bar.UseZValues = true;
			bar.GapPercent = 30;
			bar.DataLabelStyle.Visible = false;
			bar.InflateMargins = true;
		}

		private void GenerateData()
		{
			NChart chart = nChartControl1.Charts[0];

			for (int i = 0; i < chart.Series.Count; i++)
			{
				NBarSeries bar = (NBarSeries)chart.Series[i];

				if (i == 0)
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

			for (int i = 0; i < nItemsCount; i++)
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

			for (int i = 0; i < nItemsCount; i++)
			{
				bar.Values.Add(Random.NextDouble());
			}
		}

		private void NewData_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			GenerateData();
			nChartControl1.Refresh();
		}
	}
}
