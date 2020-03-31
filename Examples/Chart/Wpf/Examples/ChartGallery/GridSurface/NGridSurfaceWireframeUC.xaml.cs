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
	public partial class NGridSurfaceWireframeUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NGridSurfaceSeries m_Surface;

		public NGridSurfaceWireframeUC()
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
				return "Grid Surface Wireframe";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates wireframe surface rendering. The surface filling is disabled and the frame style is 'Mesh' - in this way only mesh lines are displayed. Use the form controls to change the appearance of the mesh frame.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Wireframe Surface");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.Width = 60.0f;
			m_Chart.Depth = 60.0f;
			m_Chart.Height = 25.0f;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft);
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// setup axes
			NOrdinalScaleConfigurator ordinalScale = (NOrdinalScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			ordinalScale.DisplayDataPointsBetweenTicks = false;

			ordinalScale = (NOrdinalScaleConfigurator)m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			ordinalScale.DisplayDataPointsBetweenTicks = false;

			// add the surface series
			m_Surface = (NGridSurfaceSeries)m_Chart.Series.Add(SeriesType.GridSurface);
			m_Surface.Name = "Surface";
			m_Surface.FillMode = SurfaceFillMode.None;
			m_Surface.FrameMode = SurfaceFrameMode.Mesh;
			m_Surface.Data.SetGridSize(30, 30);
			m_Surface.SyncPaletteWithAxisScale = false;
			m_Surface.ValueFormatter.FormatSpecifier = "0.00";
			m_Surface.FrameColorMode = SurfaceFrameColorMode.Zone;
			m_Surface.Legend.Mode = SeriesLegendMode.SeriesLogic;
			m_Surface.SmoothPalette = true;
			m_Surface.PaletteSteps = 7;
			m_Surface.Legend.Format = "<zone_value>";

			FillData();

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

			// inti form controls
			SmoothPaletteCheckBox.IsChecked = true;
			PaletteFrameCheckBox.IsChecked = true;
			AntialiasingCheckBox.IsChecked = true;
		}

		private void FillData()
		{
			double y, x, z;
			int nCountX = m_Surface.Data.GridSizeX;
			int nCountZ = m_Surface.Data.GridSizeZ;

			const double dIntervalX = 30.0;
			const double dIntervalZ = 30.0;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			z = -(dIntervalZ / 2);

			for (int j = 0; j < nCountZ; j++, z += dIncrementZ)
			{
				x = -(dIntervalX / 2);

				for (int i = 0; i < nCountX; i++, x += dIncrementX)
				{
					y = (x * x) - (z * z);
					y += 200 * Math.Sin(x / 4.0) * Math.Cos(z / 4.0);

					m_Surface.Data.SetValue(i, j, y);
				}
			}
		}


		private void PaletteFrameCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			if (PaletteFrameCheckBox.IsChecked.Value)
			{
				m_Surface.FrameColorMode = SurfaceFrameColorMode.Zone;
				m_Surface.Legend.Mode = SeriesLegendMode.SeriesLogic;
			}
			else
			{
				m_Surface.FrameColorMode = SurfaceFrameColorMode.Uniform;
				m_Surface.Legend.Mode = SeriesLegendMode.Series;
			}

			nChartControl1.Refresh();

			SmoothPaletteCheckBox.IsEnabled = PaletteFrameCheckBox.IsChecked.Value;
		}

		private void SmoothPaletteCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			if (SmoothPaletteCheckBox.IsChecked.Value)
			{
				m_Surface.SmoothPalette = true;
				m_Surface.PaletteSteps = 7;
				m_Surface.Legend.Format = "<zone_value>";
			}
			else
			{
				m_Surface.SmoothPalette = false;
				m_Surface.PaletteSteps = 8;
				m_Surface.Legend.Format = "<zone_begin> - <zone_end>";
			}

			nChartControl1.Refresh();
		}

		private void AntialiasingCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			nChartControl1.Settings.ShapeRenderingMode = AntialiasingCheckBox.IsChecked.Value ? ShapeRenderingMode.AntiAlias : ShapeRenderingMode.None;
			nChartControl1.Refresh();
		}
	}
}
