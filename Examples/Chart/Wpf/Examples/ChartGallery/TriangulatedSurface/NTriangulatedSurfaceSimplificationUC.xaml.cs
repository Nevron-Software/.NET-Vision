using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using Nevron.UI;
using System;
using System.Drawing;
using System.IO;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NTriangulatedSurfaceSimplificationUC : NExampleBaseUC
	{
		public NTriangulatedSurfaceSimplificationUC()
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
				return "Trangulated Surface Simplification";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates the clustering feature of the Triangulated Surface.With its help the number of rendered points can be decreased by a large amount, while at the same time the surface's visual representation is not changed significantly.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None;
			nChartControl1.Settings.JitterMode = JitterMode.Disabled;
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Triangulated Surface");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.BoundsMode = BoundsMode.Fit;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 10.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.Projection.Elevation = 45;
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft);

			// setup Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.RoundToTickMax = false;
			scaleY.RoundToTickMin = false;
			scaleY.MinTickDistance = new NLength(10, NGraphicsUnit.Point);
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Left, ChartWallType.Back };
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

			// setup X axis
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.RoundToTickMax = false;
			scaleX.RoundToTickMin = false;
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Floor, ChartWallType.Back };
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// setup Z axis
			NLinearScaleConfigurator scaleZ = new NLinearScaleConfigurator();
			scaleZ.RoundToTickMax = false;
			scaleZ.RoundToTickMin = false;
			scaleZ.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Floor, ChartWallType.Left };
			scaleZ.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ;

			// add the surface series
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series.Add(SeriesType.TriangulatedSurface);
			surface.Name = "Surface";
			surface.Legend.Mode = SeriesLegendMode.SeriesLogic;
			surface.SyncPaletteWithAxisScale = false;
			surface.ValueFormatter.FormatSpecifier = "0.00";
			surface.FillStyle = new NColorFillStyle(Color.YellowGreen);

			FillData();
			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			SimplifySurfaceCheckBox.IsChecked = true;
			SimplifySurfaceCheckBox_Click(null, null);
		}
		NVector3DD[] m_SurfaceVectorData;

		private void FillData()
		{
			if (nChartControl1 == null)
				return;

			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];
			NTriangulatedSurfaceData surfaceData = surface.Data;

			if (m_SurfaceVectorData == null)
			{
				Random rand = new Random();

				const int countX = 100;
				const int countZ = 100;

				NRange1DD rangeX = new NRange1DD(-10, 10);
				NRange1DD rangeZ = new NRange1DD(-10, 10);

				double stepX = rangeX.GetLength() / (countX - 1);
				double stepZ = rangeZ.GetLength() / (countZ - 1);

				double cx = -3.0;
				double cz = -5.0;

				NVector3DD[] vectorData = new NVector3DD[countZ * countX];
				int index = 0;

				for (int n = 0; n < countZ; n++)
				{
					double z = rangeZ.Begin + n * stepZ;

					for (int m = 0; m < countX; m++)
					{
						double x = rangeX.Begin + m * stepX;
						double dx = cx - x;
						double dz = cz - z;
						double distance = Math.Sqrt(dx * dx + dz * dz);

						vectorData[index++] = new NVector3DD(x, Math.Sin(distance) * Math.Exp(-distance * 0.1), z);
					}
				}

				m_SurfaceVectorData = vectorData;
			}

			NVector3DD[] newSurfaceVectorData = m_SurfaceVectorData; ;

			if (SimplifySurfaceCheckBox.IsChecked.Value)
			{
				NPointSetSimplifier3D simplifier = new NPointSetSimplifier3D();
				simplifier.DistanceFactor = 0.01;

				newSurfaceVectorData = simplifier.Simplify(newSurfaceVectorData);
			}

			surfaceData.Clear();
			surfaceData.AddValues(newSurfaceVectorData);

			nChartControl1.Refresh();
		}

		private void SimplifySurfaceCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			if (nChartControl1 == null)
				return;

			FillData();

			nChartControl1.Refresh();
		}
	}
}
