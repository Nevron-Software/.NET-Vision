using Nevron.Chart;
using Nevron.GraphicsCore;
using System.Drawing;
using System;
using Nevron.Dom;
using System.Collections.Generic;
using Nevron.Chart.Windows;
using Nevron.Chart.Functions;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NRealTimeSurfaceUC : NRealTimeExampleBaseUC
	{
		DateTime startTime;

		/// <summary>
		/// Default constructor
		/// </summary>
		public NRealTimeSurfaceUC()
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
				return "Real Time Surface";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "The example demonstrates a GPU accelerated realtime surface chart with texture zoning.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			nChartControl1.Settings.RenderSurface = RenderSurface.Window;
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None;
			nChartControl1.Controller.Tools.Clear();
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Real Time Surface");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 5.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);

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
			surface.FillMode = SurfaceFillMode.ZoneTexture;
			surface.FrameMode = SurfaceFrameMode.None;
			surface.SmoothPalette = true;
			surface.CellTriangulationMode = SurfaceCellTriangulationMode.MaxSum;
			surface.Data.SetGridSize(100, 100);

			// define a custom palette
			surface.Palette.Clear();
			surface.Palette.Add(-1, DarkOrange);
			surface.Palette.Add(-0.5, LightOrange);
			surface.Palette.Add(-0.25, LightGreen);
			surface.Palette.Add(0, Turqoise);
			surface.Palette.Add(0.25, Blue);
			surface.Palette.Add(0.5, Purple);
			surface.Palette.Add(1, BeautifulRed);

			// generate initial data
			startTime = DateTime.Now;
			UpdateSurfaceData();

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// form controls
			smoothPaletteCheck.IsChecked = true;
			paletteModeCombo.SelectedIndex = 0;
			paletteStepsCombo.SelectedIndex = 6;			

			StartTimer();
		}

		protected override void OnTimerTick(object sender, EventArgs e)
		{
			base.OnTimerTick(sender, e);

			UpdateSurfaceData();

			nChartControl1.Refresh();
		}
		protected override void UpdateTitle(bool working, float cpuUsage)
		{
			string title = "Real Time Surface";

			if (working)
			{
				title += " [CPU Usage - " + cpuUsage.ToString("0.") + "%]";
			}

			nChartControl1.Labels[0].Text = title;
		}

		private void UpdateSurfaceData()
		{
			NGridSurfaceSeries surface = (NGridSurfaceSeries)nChartControl1.Charts[0].Series[0];

			TimeSpan span = startTime - DateTime.Now;
			double t = 0.002 * span.TotalMilliseconds;

			double y, x, z;
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			const double dIntervalX = 50.0;
			const double dIntervalZ = 50.0;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			z = -(dIntervalZ / 2);

			for (int j = 0; j < nCountZ; j++, z += dIncrementZ)
			{
				x = -(dIntervalX / 2);

				for (int i = 0; i < nCountX; i++, x += dIncrementX)
				{
					y = -Math.Sin(t + x * z * 0.04) * Math.Cos(t + x * 0.4);

					surface.Data.SetValue(i, j, y);
				}
			}
		}
		private void UpdateSurface()
		{
			NGridSurfaceSeries surface = (NGridSurfaceSeries)nChartControl1.Charts[0].Series[0];

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

		private void PaletteModeCombo_SelectionChanged(object sender, EventArgs e)
		{
			UpdateSurface();

			nChartControl1.Refresh();
		}
		private void PaletteStepsCombo_SelectionChanged(object sender, EventArgs e)
		{
			UpdateSurface();

			nChartControl1.Refresh();
		}
		private void StartStopTimerButton_Click(object sender, EventArgs e)
		{
			ToggleTimer();

			if (IsTimerRunning())
			{
				StartStopTimerButton.Content = "Stop Timer";
			}
			else
			{
				StartStopTimerButton.Content = "Start Timer";
			}
		}
		private void SmoothPaletteCheck_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			UpdateSurface();

			nChartControl1.Refresh();
		}
	}
}
