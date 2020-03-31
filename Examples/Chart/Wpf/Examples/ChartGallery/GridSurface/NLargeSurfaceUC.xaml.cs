using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using Nevron.UI;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NLargeSurfaceUC : NExampleBaseUC
	{
		public NLargeSurfaceUC()
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
				return "Large Surface";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "The Grid Surface is optimized for rendering of large surfaces. Using hardware acceleration, the chart can display interactively surfaces with more than a million data points on lower-end graphics processors and way more on higher-end GPUs.\r\n" +
						"This example demonstrates how to configure the chart for best performance when rendering large surfaces. Two exemplary surfaces are used, with sizes respectively 500x500 (250'000 data points) and 1024 (1'048'576 data points).";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None;

			// add a trackball tool so that the user can rotate the chart
			nChartControl1.Controller.Tools.Clear();
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Surface");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			title.Cache = true;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 55.0f;
			chart.Depth = 55.0f;
			chart.Height = 4.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);

			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY.AutoLabels = false;
			scaleY.MajorTickMode = MajorTickMode.AutoMaxCount;
			scaleY.MaxTickCount = 5;

			NOrdinalScaleConfigurator ordinalScale = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			ordinalScale.DisplayDataPointsBetweenTicks = false;

			ordinalScale = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.Depth).ScaleConfigurator;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			ordinalScale.DisplayDataPointsBetweenTicks = false;

			// add the surface series
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series.Add(SeriesType.GridSurface);
			surface.Name = "Surface";
			surface.FrameMode = SurfaceFrameMode.None;
			surface.ShadingMode = ShadingMode.Smooth;
			surface.AutomaticPalette = true;
			surface.SyncPaletteWithAxisScale = false;

			// NOTE: Cell triangulation mode is important for performance. Use Diagonal1 or Diagonal2 for faster rendering.
			surface.CellTriangulationMode = SurfaceCellTriangulationMode.Diagonal1;

			NColorFillStyle fill = new NColorFillStyle();
			fill.MaterialStyle.Ambient = Color.FromArgb(122, 125, 110);
			fill.MaterialStyle.Diffuse = Color.FromArgb(122, 125, 110);
			fill.MaterialStyle.Specular = Color.DimGray;
			surface.FillStyle = fill;

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			SurfaceSizeComboBox.Items.Add("500 x 500");
			SurfaceSizeComboBox.Items.Add("1024 x 1024");

			FillModeComboBox.Items.Add("Uniform");
			FillModeComboBox.Items.Add("Zone Texture");
			FillModeComboBox.Items.Add("Zone Texture - Smooth");

			// init form controls
			UseHardwareAccelerationCheckBox.IsChecked = true;
			SurfaceSizeComboBox.SelectedIndex = 0;
			FillModeComboBox.SelectedIndex = 1;
		}

		private void UseHardwareAccelerationCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			if ((bool)UseHardwareAccelerationCheckBox.IsChecked)
			{
				nChartControl1.Settings.RenderSurface = RenderSurface.Window;
			}
			else
			{
				nChartControl1.Settings.RenderSurface = RenderSurface.Bitmap;
			}
		}

		private void SurfaceSizeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NGridSurfaceSeries surface = (NGridSurfaceSeries)nChartControl1.Charts[0].Series[0];

			string heightMapName = "";

			switch (SurfaceSizeComboBox.SelectedIndex)
			{
				case 0:
					heightMapName = "HeightMap0500.png";
					break;

				case 1:
					heightMapName = "HeightMap1024.png";
					break;

				default:
					return;
			}

			using (Bitmap bitmap = NResourceHelper.BitmapFromResource(this.GetType(), heightMapName, "Nevron.Examples.Chart.Wpf.Resources.Images"))
			{
				surface.Data.InitFromBitmap(bitmap);
			}

			nChartControl1.Refresh();
		}

		private void FillModeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NGridSurfaceSeries surface = (NGridSurfaceSeries)nChartControl1.Charts[0].Series[0];

			switch (FillModeComboBox.SelectedIndex)
			{
				case 0:
					surface.FillMode = SurfaceFillMode.Uniform;
					break;

				case 1:
					surface.FillMode = SurfaceFillMode.ZoneTexture;
					surface.SmoothPalette = false;
					surface.PaletteSteps = 8;
					break;

				case 2:
					surface.FillMode = SurfaceFillMode.ZoneTexture;
					surface.SmoothPalette = true;
					surface.PaletteSteps = 7;
					break;
			}

			nChartControl1.Refresh();
		}

	}
}
