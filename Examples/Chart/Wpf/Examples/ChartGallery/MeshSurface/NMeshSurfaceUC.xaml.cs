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
	public partial class NMeshSurfaceUC : NExampleBaseUC
	{
		public NMeshSurfaceUC()
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
				return "Mesh Surface";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "A general demonstration of the capabilities of the Mesh Surface Series.\r\n" +
						"Use the controls on the right to modify some commonly used properties.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None;
			nChartControl1.Controller.Tools.Add(new NSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Mesh Surface Chart");
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
			surface.FillStyle = new NColorFillStyle(Color.YellowGreen);

			FillData(surface);

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			// form controls
			FillModeComboBox.Items.Add("None");
			FillModeComboBox.Items.Add("Uniform");
			FillModeComboBox.Items.Add("Zone");

			FrameModeComboBox.Items.Add("None");
			FrameModeComboBox.Items.Add("Mesh");
			FrameModeComboBox.Items.Add("Contour");
			FrameModeComboBox.Items.Add("Mesh-Contour");
			FrameModeComboBox.Items.Add("Dots");

			FrameColorModeComboBox.Items.Add("Uniform");
			FrameColorModeComboBox.Items.Add("Zone");

			PositionModeComboBox.Items.Add("Axis Begin");
			PositionModeComboBox.Items.Add("Axis End");
			PositionModeComboBox.Items.Add("Custom Value");

			FillModeComboBox.SelectedIndex = 2;
			SmoothShadingCheckBox.IsChecked = true;
			FrameModeComboBox.SelectedIndex = 2;
			FrameColorModeComboBox.SelectedIndex = 0;
			SmoothPaletteCheckBox.IsChecked = false;
			PositionModeComboBox.SelectedIndex = 0;
			CustomValueScrollBar.Value = 0.1f;

			// form controls
			PositionModeComboBox.IsEnabled = false;
			CustomValueScrollBar.IsEnabled = false;
		}

		private void FillData(NMeshSurfaceSeries surface)
		{
			double x, y, z;
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			for (int j = 0; j < nCountZ; j++)
			{
				for (int i = 0; i < nCountX; i++)
				{
					x = 2 + i + Math.Sin(j / 4.0) * 2;
					z = 1 + j + Math.Cos(i / 4.0);

					y = Math.Sin(i / 3.0) * Math.Sin(j / 3.0);

					if (y < 0)
					{
						y = Math.Abs(y / 2.0);
					}

					surface.Data.SetValue(i, j, y, x, z);
				}
			}
		}

		private void FillModeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NMeshSurfaceSeries surface = (NMeshSurfaceSeries)chart.Series[0];

			switch (FillModeComboBox.SelectedIndex)
			{
				case 0:
					surface.FillMode = SurfaceFillMode.None;
					SmoothShadingCheckBox.IsEnabled = false;
					break;

				case 1:
					surface.FillMode = SurfaceFillMode.Uniform;
					SmoothShadingCheckBox.IsEnabled = true;
					break;

				case 2:
					surface.FillMode = SurfaceFillMode.Zone;
					SmoothShadingCheckBox.IsEnabled = true;
					break;
			}

			nChartControl1.Refresh();
		}

		private void FrameModeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NMeshSurfaceSeries surface = (NMeshSurfaceSeries)chart.Series[0];

			surface.FrameMode = (SurfaceFrameMode)FrameModeComboBox.SelectedIndex;
			nChartControl1.Refresh();

			// form controls
			FrameColorModeComboBox.IsEnabled = (surface.FrameMode != SurfaceFrameMode.None);
		}

		private void FrameColorModeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NMeshSurfaceSeries surface = (NMeshSurfaceSeries)chart.Series[0];

			switch (FrameColorModeComboBox.SelectedIndex)
			{
				case 0:
					surface.FrameColorMode = SurfaceFrameColorMode.Uniform;
					break;

				case 1:
					surface.FrameColorMode = SurfaceFrameColorMode.Zone;
					break;
			}

			nChartControl1.Refresh();
		}

		private void DrawFlatCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NMeshSurfaceSeries surface = (NMeshSurfaceSeries)chart.Series[0];

			surface.DrawFlat = (bool)DrawFlatCheckBox.IsChecked;

			// form controls
			PositionModeComboBox.IsEnabled = (bool)DrawFlatCheckBox.IsChecked;
			CustomValueScrollBar.IsEnabled = (bool)DrawFlatCheckBox.IsChecked;

			nChartControl1.Refresh();
		}

		private void PositionModeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NMeshSurfaceSeries surface = (NMeshSurfaceSeries)chart.Series[0];

			surface.PositionMode = (SurfacePositionMode)PositionModeComboBox.SelectedIndex;
			nChartControl1.Refresh();
		}

		private void CustomValueScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			NChart chart = nChartControl1.Charts[0];
			NMeshSurfaceSeries surface = (NMeshSurfaceSeries)chart.Series[0];

			surface.PositionValue = CustomValueScrollBar.Value * 20.0f;
			nChartControl1.Refresh();
		}

		private void SmoothShadingCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NMeshSurfaceSeries surface = (NMeshSurfaceSeries)chart.Series[0];

			if ((bool)SmoothShadingCheckBox.IsChecked)
			{
				surface.ShadingMode = ShadingMode.Smooth;
			}
			else
			{
				surface.ShadingMode = ShadingMode.Flat;
			}

			nChartControl1.Refresh();
		}

		private void SmoothPaletteCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NMeshSurfaceSeries surface = (NMeshSurfaceSeries)chart.Series[0];

			if ((bool)SmoothPaletteCheckBox.IsChecked)
			{
				surface.SmoothPalette = true;
				surface.PaletteSteps = 7;
				surface.Legend.Format = "<zone_value>";
			}
			else
			{
				surface.SmoothPalette = false;
				surface.PaletteSteps = 8;
				surface.Legend.Format = "<zone_begin> - <zone_end>";
			}

			nChartControl1.Refresh();
		}
	}
}
