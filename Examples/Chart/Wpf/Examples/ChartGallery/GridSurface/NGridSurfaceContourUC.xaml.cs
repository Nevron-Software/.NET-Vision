using Nevron.Chart;
using Nevron.Dom;
using Nevron.GraphicsCore;
using System;
using System.Drawing;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NGridSurfaceContourUC : NExampleBaseUC
	{
		public NGridSurfaceContourUC()
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
				return "Grid Surface Contours";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a contour chart displayed with the Grid Surface Series.The chart uses orthogonal projection with camera elevation of 90 degrees, the lighting is disabled and the surface is rendered in flat mode.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.HighSpeed;

			// set a chart title
			NLabel title = new NLabel("Contour Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 70.0f;
			chart.Depth = 70.0f;
			chart.Height = 0.1f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalTop);
			chart.LightModel.EnableLighting = false;

			// hide chart walls
			chart.Wall(ChartWallType.Back).Visible = false;
			chart.Wall(ChartWallType.Left).Visible = false;
			chart.Wall(ChartWallType.Floor).Visible = false;

			// setup Y axis
			chart.Axis(StandardAxis.PrimaryY).Visible = false;

			// setup X axis
			NAxis axisX = chart.Axis(StandardAxis.PrimaryX);
			axisX.Anchor = new NDockAxisAnchor(AxisDockZone.FrontTop);
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.InnerMajorTickStyle.Visible = false;
			scaleX.RoundToTickMin = false;
			scaleX.RoundToTickMax = false;
			axisX.ScaleConfigurator = scaleX;

			// setup Z axis
			NAxis axisZ = chart.Axis(StandardAxis.Depth);
			axisZ.Anchor = new NDockAxisAnchor(AxisDockZone.TopRight);
			NLinearScaleConfigurator scaleZ = new NLinearScaleConfigurator();
			scaleZ.InnerMajorTickStyle.Visible = false;
			scaleZ.MajorGridStyle.ShowAtWalls = new ChartWallType[0];
			scaleZ.RoundToTickMin = false;
			scaleZ.RoundToTickMax = false;
			axisZ.ScaleConfigurator = scaleZ;

			// add a surface series
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series.Add(SeriesType.GridSurface);
			surface.Name = "Contour";
			surface.Legend.Mode = SeriesLegendMode.SeriesLogic;
			surface.ValueFormatter = new NNumericValueFormatter("0.0");
			surface.FillMode = SurfaceFillMode.Zone;
			surface.FrameMode = SurfaceFrameMode.Contour;
			surface.ShadingMode = ShadingMode.Flat;
			surface.DrawFlat = true;
			surface.Data.SetGridSize(31, 31);

			// setup a custom palette
			surface.AutomaticPalette = false;
			surface.Palette.Clear();

			surface.Palette.Add(0.0, Color.Purple);
			surface.Palette.Add(1.5, Color.MediumSlateBlue);
			surface.Palette.Add(3.0, Color.CornflowerBlue);
			surface.Palette.Add(4.5, Color.LimeGreen);
			surface.Palette.Add(6.0, Color.LightGreen);
			surface.Palette.Add(7.5, Color.Yellow);
			surface.Palette.Add(9.0, Color.Orange);
			surface.Palette.Add(10.5, Color.Red);
			surface.Palette.Add(100, Color.Red);

			// fill the surface with data
			FillData(surface);

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			// setup form controls
			ShowFillingCheckBox.IsChecked = true;
			ShowFrameCheckBox.IsChecked = true;
			PaletteFrameCheckBox.IsChecked = true;
			SmoothPaletteCheckBox.IsChecked = true;
			DrawContourBorderCheckBox.IsChecked = true;

			UpdateChart();
		}

		private void UpdateChart()
		{
			NGridSurfaceSeries surface = (NGridSurfaceSeries)nChartControl1.Charts[0].Series[0];

			if (PaletteFrameCheckBox.IsChecked.Value)
			{
				surface.FrameColorMode = SurfaceFrameColorMode.Zone;
			}
			else
			{
				surface.FrameColorMode = SurfaceFrameColorMode.Uniform;
			}

			if (SmoothPaletteCheckBox.IsChecked.Value)
			{
				surface.SmoothPalette = true;
				surface.Legend.Format = "<zone_value>";
			}
			else
			{
				surface.SmoothPalette = false;
				surface.Legend.Format = "<zone_begin> - <zone_end>";
			}

			if (ShowFillingCheckBox.IsChecked.Value)
			{
				surface.FillMode = SurfaceFillMode.Zone;
			}
			else
			{
				surface.FillMode = SurfaceFillMode.None;
			}

			if (ShowFrameCheckBox.IsChecked.Value)
			{
				surface.FrameMode = SurfaceFrameMode.Contour;
				PaletteFrameCheckBox.IsEnabled = true;
				DrawContourBorderCheckBox.IsEnabled = true;
			}
			else
			{
				surface.FrameMode = SurfaceFrameMode.None;
				PaletteFrameCheckBox.IsEnabled = false;
				DrawContourBorderCheckBox.IsEnabled = false;
			}

			surface.DrawContourBorder = DrawContourBorderCheckBox.IsChecked.Value;

			nChartControl1.Refresh();
		}

		private void FillData(NGridSurfaceSeries surface)
		{
			double y, x, z;
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			const double dIntervalX = 10.0;
			const double dIntervalZ = 10.0;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			z = -(dIntervalZ / 2);

			for (int j = 0; j < nCountZ; j++, z += dIncrementZ)
			{
				x = -(dIntervalX / 2);

				for (int i = 0; i < nCountX; i++, x += dIncrementX)
				{
					y = 10 - Math.Sqrt((x * x) + (z * z) + 2);
					y += 3.0 * Math.Sin(x) * Math.Cos(z);

					surface.Data.SetValue(i, j, y);
				}
			}
		}

		private void ShowFillingCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			UpdateChart();
		}

		private void ShowFrameCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			UpdateChart();
		}

		private void PaletteFrameCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			UpdateChart();
		}

		private void SmoothPaletteCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			UpdateChart();
		}

		private void DrawContourBorderCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			UpdateChart();
		}
	}
}
