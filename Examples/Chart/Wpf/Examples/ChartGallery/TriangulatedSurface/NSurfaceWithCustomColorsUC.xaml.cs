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
	public partial class NSurfaceWithCustomColorsUC : NExampleBaseUC
	{
		public NSurfaceWithCustomColorsUC()
		{
			InitializeComponent();

			fillModeCombo.Items.Add("None");
			fillModeCombo.Items.Add("Uniform");
			fillModeCombo.Items.Add("Custom Colors");

			frameModeCombo.Items.Add("None");
			frameModeCombo.Items.Add("Mesh");
			frameModeCombo.Items.Add("Contour");
			frameModeCombo.Items.Add("Mesh-Contour");
			frameModeCombo.Items.Add("Dots");

			frameColorModeCombo.Items.Add("Uniform");
			frameColorModeCombo.Items.Add("Custom Colors");
		}

		/// <summary>
		/// Gets the title of this example
		/// </summary>
		public override string Title
		{
			get
			{
				return "Trangulated Surface";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "With the Triangulated Surface you can assign a custom color for each data point. Custom Colors can be used both for the surface filling and for the frame.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None;
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Surface with Custom Colors");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// remove legends
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 10.0f;
			chart.BoundsMode = BoundsMode.Fit;
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
			surface.SyncPaletteWithAxisScale = false;
			surface.ValueFormatter.FormatSpecifier = "0.00";
			surface.FillStyle = new NColorFillStyle(Color.YellowGreen);
			surface.PaletteSteps = 8;

			surface.FillMode = SurfaceFillMode.CustomColors;
			surface.FrameMode = SurfaceFrameMode.None;
			surface.FrameColorMode = SurfaceFrameColorMode.CustomColors;
			surface.ShadingMode = ShadingMode.Smooth;

			FillData();

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// form controls
			smoothShadingCheck.IsChecked = true;
			fillModeCombo.SelectedIndex = 2;
			frameModeCombo.SelectedIndex = 0;
			frameColorModeCombo.SelectedIndex = 0;
		}

		private void FillData()
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

			Stream stream = null;
			BinaryReader reader = null;

			try
			{
				// fill the XYZ data from a binary resource
				stream = NResourceHelper.GetResourceStream(GetType().Assembly, "DataXYZ.bin", "Nevron.Examples.Chart.Wpf.Resources");
				reader = new BinaryReader(stream);

				int nDataPointsCount = (int)stream.Length / 12;

				NTriangulatedSurfaceData surfaceData = surface.Data;
				surfaceData.SetCount(nDataPointsCount);
				surfaceData.UseColors = true;

				// fill Y values and colors
				for (int i = 0; i < nDataPointsCount; i++)
				{
					float y = 300 - reader.ReadSingle();

					surfaceData.SetYValue(i, y);
					surfaceData.SetColor(i, GetColorFromValue(y));
				}

				// fill X values
				for (int i = 0; i < nDataPointsCount; i++)
				{
					surfaceData.SetXValue(i, reader.ReadSingle());
				}

				// fill Z values
				for (int i = 0; i < nDataPointsCount; i++)
				{
					surfaceData.SetZValue(i, reader.ReadSingle());
				}
			}
			finally
			{
				if (reader != null)
					reader.Close();

				if (stream != null)
					stream.Close();
			}
		}

		private Color GetColorFromValue(float y)
		{
			Color color = Color.Black;

			if (y < 100)
			{
				color = Color.FromArgb(20, 30, 180);
			}
			else if (y < 150)
			{
				color = Color.FromArgb(20, 100, 100);
			}
			else if (y < 200)
			{
				color = Color.FromArgb(20, 140, 80);
			}
			else if (y < 250)
			{
				color = Color.FromArgb(80, 140, 60);
			}
			else if (y < 300)
			{
				color = Color.FromArgb(140, 140, 40);
			}

			return Color.FromArgb(
				color.R + (int)(Random.NextDouble() * 50),
				color.G + (int)(Random.NextDouble() * 50),
				color.B + (int)(Random.NextDouble() * 50));
		}

		private void SmoothShadingCheck_Clicked(object sender, System.Windows.RoutedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

			if ((bool)smoothShadingCheck.IsChecked)
			{
				surface.ShadingMode = ShadingMode.Smooth;
			}
			else
			{
				surface.ShadingMode = ShadingMode.Flat;
			}

			nChartControl1.Refresh();
		}
		private void FillModeCombo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

			switch (fillModeCombo.SelectedIndex)
			{
				case 0:
					surface.FillMode = SurfaceFillMode.None;
					smoothShadingCheck.IsEnabled = false;
					break;

				case 1:
					surface.FillMode = SurfaceFillMode.Uniform;
					smoothShadingCheck.IsEnabled = true;
					break;

				case 2:
					surface.FillMode = SurfaceFillMode.CustomColors;
					smoothShadingCheck.IsEnabled = true;
					break;
			}

			nChartControl1.Refresh();
		}
		private void FrameModeCombo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

			surface.FrameMode = (SurfaceFrameMode)frameModeCombo.SelectedIndex;
			nChartControl1.Refresh();

			// form controls
			frameColorModeCombo.IsEnabled = (surface.FrameMode != SurfaceFrameMode.None);
		}
		private void FrameColorModeCombo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

			switch (frameColorModeCombo.SelectedIndex)
			{
				case 0:
					surface.FrameColorMode = SurfaceFrameColorMode.Uniform;
					break;

				case 1:
					surface.FrameColorMode = SurfaceFrameColorMode.CustomColors;
					break;
			}

			nChartControl1.Refresh();
		}
	}
}
