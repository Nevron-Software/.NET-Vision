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
	public partial class NMeshSurfaceLargeSurfaceUC : NExampleBaseUC
	{
		public NMeshSurfaceLargeSurfaceUC()
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
				return "Large Mesh Surface";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "The Mesh Surface is optimized for rendering of large surfaces.Using hardware acceleration, the chart can display interactively surfaces with more than a million data points on lower - end graphics processors and way more on higher - end GPUs.\r\n" +
						"This example demonstrates how to configure the chart for best performance when rendering large mesh surfaces.Two exemplary surfaces are used, with sizes respectively 500x500(250'000 data points) and 1024 (1'048'576 data points).";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.HighSpeed;
			nChartControl1.Settings.RenderSurface = RenderSurface.Window;

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Mesh Surface with 1000000 Data Points");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 50.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);

			// setup axes
			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY.MajorTickMode = MajorTickMode.AutoMaxCount;
			scaleY.MaxTickCount = 5;

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
			surface.SyncPaletteWithAxisScale = false;
			surface.PaletteSteps = 8;
			surface.ValueFormatter.FormatSpecifier = "0.00";
			surface.CellTriangulationMode = SurfaceCellTriangulationMode.Diagonal1;
			surface.FrameMode = SurfaceFrameMode.None;
			surface.FillMode = SurfaceFillMode.ZoneTexture;
			surface.ShadingMode = ShadingMode.Smooth;
			surface.SmoothPalette = true;

			surface.Data.SetGridSize(1000, 1000);

			FillData(surface);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			UseHardwareAccelerationCheckBox.IsChecked = true;
		}
		private void FillData(NMeshSurfaceSeries surface)
		{
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			double x, y, z;
			double dAngle = 0;
			double dRadius = 100.0;
			double dElevation = 0;

			for (int j = 0; j < nCountZ; j++)
			{
				for (int i = 0; i < nCountX; i++)
				{
					x = dRadius * Math.Cos(dAngle) * (1 + i);
					z = dRadius * Math.Sin(dAngle) * (1 + i);
					y = dElevation + Math.Sin(i * 0.1) + Math.Sin(i * 0.004) * 5;

					surface.Data.SetValue(i, j, y, x, z);
				}

				if (j < 700)
					dRadius -= 0.1;
				else
					dRadius += 0.1;

				dElevation += 0.2;
				dAngle += 0.008 * Math.PI;
			}
		}

		private void UseHardwareAccelerationCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			if (UseHardwareAccelerationCheckBox.IsChecked.Value)
			{
				nChartControl1.Settings.RenderSurface = RenderSurface.Window;
			}
			else
			{
				nChartControl1.Settings.RenderSurface = RenderSurface.Bitmap;
			}
		}
	}
}
