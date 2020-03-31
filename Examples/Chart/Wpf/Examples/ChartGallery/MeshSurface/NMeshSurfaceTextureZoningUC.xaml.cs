using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using System;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NMeshSurfaceTextureZoningUC : NExampleBaseUC
	{
		public NMeshSurfaceTextureZoningUC()
		{
			InitializeComponent();

			paletteModeCombo.Items.Add("Use Fixed Number of Zones");
			paletteModeCombo.Items.Add("Synchronize Palette Zones with Y Axis");
			paletteModeCombo.Items.Add("Use Custom Palette");

			paletteStepsCombo.Items.Add("2");
			paletteStepsCombo.Items.Add("3");
			paletteStepsCombo.Items.Add("4");
			paletteStepsCombo.Items.Add("5");
			paletteStepsCombo.Items.Add("6");
			paletteStepsCombo.Items.Add("7");
			paletteStepsCombo.Items.Add("8");
		}

		/// <summary>
		/// Gets the title of this example
		/// </summary>
		public override string Title
		{
			get
			{
				return "Mesh Surface Texture Zoning";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return	"Texture Zoning is a fast method for surface elevation zoning. It produces the same results as the standard zoning mode, " +
						"but the performance impact is minimal (escpecially when hardware acceleration is enabled). " +
						"The only disadvantage of this zoning mode is that it is not applicable for flat surfaces (i.e. when the DrawFlat property is set to true).";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			nChartControl1.Settings.RenderSurface = RenderSurface.Bitmap;
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None;
			nChartControl1.Controller.Tools.Clear();
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Mesh Surface");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 25.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft);

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
			NMeshSurfaceSeries surface = new NMeshSurfaceSeries();
			chart.Series.Add(surface);
			surface.ShadingMode = ShadingMode.Smooth;
			surface.FillMode = SurfaceFillMode.ZoneTexture;
			surface.FrameMode = SurfaceFrameMode.None;
			surface.Data.SetGridSize(100, 100);

			// define a custom palette
			surface.Palette.Clear();
			surface.Palette.Add(-0.8, DarkOrange);
			surface.Palette.Add(-0.4, LightOrange);
			surface.Palette.Add(-0.2, LightGreen);
			surface.Palette.Add(0, Turqoise);
			surface.Palette.Add(0.4, Blue);
			surface.Palette.Add(0.8, Purple);
			surface.Palette.Add(1, BeautifulRed);

			// generate data
			GenerateSurfaceData(surface);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// form controls
			paletteModeCombo.SelectedIndex = 0;
			paletteStepsCombo.SelectedIndex = 6;
			smoothPaletteCheck.IsChecked = false;
		}

		private void GenerateSurfaceData(NMeshSurfaceSeries surface)
		{
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			const double dIntervalX = 40.0;
			const double dIntervalZ = 40.0;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			double pz = -(dIntervalZ / 2);

			for (int j = 0; j < nCountZ; j++, pz += dIncrementZ)
			{
				double px = -(dIntervalX / 2);

				for (int i = 0; i < nCountX; i++, px += dIncrementX)
				{
					double x = px + Math.Sin(pz) * 0.4;
					double z = pz + Math.Cos(px) * 0.4;
					double y = Math.Sin(px * 0.33) * Math.Sin(pz * 0.33);

					if (y < 0)
					{
						y = -y * 0.7;
					}

					double tmp = (1 - x * x - z * z);
					y -= tmp * tmp * 0.000001;

					surface.Data.SetValue(i, j, y, x, z);
				}
			}
		}
		private void UpdateSurface()
		{
			NMeshSurfaceSeries surface = (NMeshSurfaceSeries)nChartControl1.Charts[0].Series[0];

			switch (paletteModeCombo.SelectedIndex)
			{
				case 0:
					surface.AutomaticPalette = true;
					surface.SyncPaletteWithAxisScale = false;
					paletteStepsCombo.IsEnabled = true;
					break;

				case 1:
					surface.AutomaticPalette = true;
					surface.SyncPaletteWithAxisScale = true;
					paletteStepsCombo.IsEnabled = false;
					break;

				case 2:
					surface.AutomaticPalette = false;
					paletteStepsCombo.IsEnabled = false;
					break;
			}

			if ((bool)smoothPaletteCheck.IsChecked)
			{
				surface.SmoothPalette = true;
				surface.PaletteSteps = paletteStepsCombo.SelectedIndex + 1;
			}
			else
			{
				surface.SmoothPalette = false;
				surface.PaletteSteps = paletteStepsCombo.SelectedIndex + 2;
			}
		}

		private void PaletteModeCombo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			UpdateSurface();

			nChartControl1.Refresh();
		}
		private void PaletteStepsCombo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			UpdateSurface();

			nChartControl1.Refresh();
		}
		private void SmoothPaletteCheck_Clicked(object sender, System.Windows.RoutedEventArgs e)
		{
			UpdateSurface();

			nChartControl1.Refresh();
		}
	}
}
