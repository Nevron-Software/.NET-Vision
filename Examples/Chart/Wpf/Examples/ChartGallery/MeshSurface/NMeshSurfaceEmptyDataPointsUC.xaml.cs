using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NMeshSurfaceEmptyDataPointsUC : NExampleBaseUC
	{
		public NMeshSurfaceEmptyDataPointsUC()
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
				return "Mesh Surface Empty Data Points";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates the mesh surface support for Empty Data Points.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Mesh Surface With Empty Data Points");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 25.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);

			// setup axes
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.RoundToTickMax = false;
			linearScale.RoundToTickMin = false;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;

			linearScale = new NLinearScaleConfigurator();
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.RoundToTickMax = false;
			linearScale.RoundToTickMin = false;
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale;

			// setup surface series
			NMeshSurfaceSeries surface = (NMeshSurfaceSeries)chart.Series.Add(SeriesType.MeshSurface);
			surface.Name = "Surface";
			surface.Legend.Mode = SeriesLegendMode.SeriesLogic;
			surface.FillMode = SurfaceFillMode.Zone;
			surface.PositionValue = 0.5;
			surface.Data.SetGridSize(20, 20);
			surface.SyncPaletteWithAxisScale = false;
			surface.PaletteSteps = 8;
			surface.ValueFormatter.FormatSpecifier = "0.00";

			FillData(surface);

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);
		}

		private void FillData(NMeshSurfaceSeries surface)
		{
			double x, y, z;
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			const double dIntervalX = 8.0;
			const double dIntervalZ = 8.0;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			for (int j = 0; j < nCountZ; j++)
			{
				for (int i = 0; i < nCountX; i++)
				{
					x = -(dIntervalX / 2) + (i * dIncrementX);
					z = -(dIntervalZ / 2) + (j * dIncrementZ);

					y = Math.Log(Math.Abs(x) * Math.Abs(z));

					x += Math.Sin(j / 2.0) / 2.2;
					z += Math.Cos(i / 2.0) / 2.2;

					if (y > -7)
					{
						surface.Data.SetValue(i, j, y, x, z);
					}
					else
					{
						surface.Data.SetValue(i, j, DBNull.Value, DBNull.Value, DBNull.Value);
					}
				}
			}
		}
	}
}
