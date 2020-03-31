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
	public partial class NGridSurfaceCustomColorsUC : NExampleBaseUC
	{
		public NGridSurfaceCustomColorsUC()
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
				return "Grid Surface Custom Colors";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "The example demonstrates the ability of the Grid Surface Series to assign custom color per each individual surface vertex.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			//nChartControl1.Settings.RenderSurface = RenderSurface.Window;
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None;
			nChartControl1.Controller.Tools.Clear();
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Grid Surface with Custom Colors");
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
			NOrdinalScaleConfigurator ordinalScale = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			ordinalScale.DisplayDataPointsBetweenTicks = false;

			ordinalScale = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.Depth).ScaleConfigurator;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			ordinalScale.DisplayDataPointsBetweenTicks = false;

			// add the surface series
			NGridSurfaceSeries surface = new NGridSurfaceSeries();
			chart.Series.Add(surface);
			surface.ShadingMode = ShadingMode.Smooth;
			surface.FillMode = SurfaceFillMode.CustomColors;
			surface.FrameMode = SurfaceFrameMode.None;
			surface.FrameColorMode = SurfaceFrameColorMode.CustomColors;
			surface.FrameStrokeStyle.Color = Color.Red;
			surface.FrameStrokeStyle.Width = new NLength(4);

            surface.Data.UseColors = true;
			surface.Data.SetGridSize(50, 50);

			// define a custom palette
			surface.Palette.Clear();
			surface.Palette.Add(-3, DarkOrange);
			surface.Palette.Add(-2.5, LightOrange);
			surface.Palette.Add(-1, LightGreen);
			surface.Palette.Add(0, Turqoise);
			surface.Palette.Add(2, Blue);
			surface.Palette.Add(3, Purple);
			surface.Palette.Add(4, BeautifulRed);

			// generate data
			GenerateSurfaceData(surface);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			HasFillingCheckBox.IsChecked = true;

			FrameModeComboBox.Items.Add("None");
			FrameModeComboBox.Items.Add("Mesh");
			FrameModeComboBox.Items.Add("Dots");
			FrameModeComboBox.SelectedIndex = 0;
			SmoothShadingCheckBox.IsChecked = true;
		}

		private void GenerateSurfaceData(NGridSurfaceSeries surface)
		{
			double y, x, z;
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			const double dIntervalX = 50.0;
			const double dIntervalZ = 50.0;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			z = -(dIntervalZ / 2);

			float semiWidth = (float)Math.Min(nCountX / 2, nCountZ / 2);
			Color startColor = Color.Red;
			Color endColor = Color.Green;

			int centerX = nCountX / 2;
			int centerZ = nCountZ / 2;

			for (int j = 0; j < nCountZ; j++, z += dIncrementZ)
			{
				x = -(dIntervalX / 2);

				for (int i = 0; i < nCountX; i++, x += dIncrementX)
				{
					y = (x * z / 64.0) - Math.Sin(z / 2.4) * Math.Cos(x / 2.4);
					y = Math.Abs(y);
					double tmp = (1 - x * x - z * z);
					y -= tmp * tmp * 0.000006;

					surface.Data.SetValue(i, j, y);

					int dx = centerX - i;
					int dz = centerZ - j;
					float distance = (float)Math.Sqrt(dx * dx + dz * dz);
					surface.Data.SetColor(i, j, InterpolateColors(startColor, endColor, distance / semiWidth));
				}
			}
		}

		public static Color InterpolateColors(Color color1, Color color2, float factor)
		{
			if (factor > 1.0f)
				factor = 1.0f;

			int num1 = ((int)color1.R);
			int num2 = ((int)color1.G);
			int num3 = ((int)color1.B);

			int num4 = ((int)color2.R);
			int num5 = ((int)color2.G);
			int num6 = ((int)color2.B);

			byte num7 = (byte)((((float)num1) + (((float)(num4 - num1)) * factor)));
			byte num8 = (byte)((((float)num2) + (((float)(num5 - num2)) * factor)));
			byte num9 = (byte)((((float)num3) + (((float)(num6 - num3)) * factor)));

			return Color.FromArgb(num7, num8, num9);
		}

		private void SmoothShadingCheckBox_Clicked(object sender, System.Windows.RoutedEventArgs e)
		{
			NGridSurfaceSeries gridSurface = (NGridSurfaceSeries)nChartControl1.Charts[0].Series[0];

			gridSurface.ShadingMode = SmoothShadingCheckBox.IsChecked.Value ? ShadingMode.Smooth : ShadingMode.Flat;
			nChartControl1.Refresh();
		}

		private void HasFillingCheckBox_Clicked(object sender, System.Windows.RoutedEventArgs e)
		{
			NGridSurfaceSeries gridSurface = (NGridSurfaceSeries)nChartControl1.Charts[0].Series[0];

			gridSurface.FillMode = HasFillingCheckBox.IsChecked.Value ? SurfaceFillMode.CustomColors : SurfaceFillMode.None;
			nChartControl1.Refresh();
		}

		private void FillModeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NGridSurfaceSeries gridSurface = (NGridSurfaceSeries)nChartControl1.Charts[0].Series[0];

			switch (FrameModeComboBox.SelectedIndex)
			{
				case 0: // none
					gridSurface.FrameMode = SurfaceFrameMode.None;
					break;
				case 1:	// mesh
					gridSurface.FrameMode = SurfaceFrameMode.Mesh;
					break;
				case 2: // dots
					gridSurface.FrameMode = SurfaceFrameMode.Dots;
					break;
			}

			nChartControl1.Refresh();
		}
	}
}
