using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using Nevron.Dom;
using Nevron.UI;
using System.IO;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NGridSurfaceProjectedContourUC : NExampleBaseUC
	{
		public NGridSurfaceProjectedContourUC()
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
				return "Grid Surface Projected Contour";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a contour chart displayed with the Grid Surface Series. The chart uses orthogonal projection with camera elevation of 90 degrees, the lighting is disabled and the surface is rendered in flat mode.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.HighSpeed;
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Contour Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			NCartesianChart chart = (NCartesianChart)nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 55.0f;
			chart.Depth = 55.0f;
			chart.Height = 45.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyCameraLight);

			SetupAxisAnchorsAndWalls(chart);

			// setup Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.RoundToTickMax = false;
			NAxis axisY = chart.Axis(StandardAxis.PrimaryY);
			axisY.View = new NRangeAxisView(new NRange1DD(0, 100), true, false);
			axisY.ScaleConfigurator = scaleY;

			// setup X axis
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.RoundToTickMin = false;
			scaleX.RoundToTickMax = false;
			NAxis axisX = chart.Axis(StandardAxis.PrimaryX);
			axisX.ScaleConfigurator = scaleX;

			// setup Z axis
			NLinearScaleConfigurator scaleZ = new NLinearScaleConfigurator();
			scaleZ.MajorGridStyle.ShowAtWalls = new ChartWallType[0];
			scaleZ.RoundToTickMin = false;
			scaleZ.RoundToTickMax = false;
			NAxis axisZ = chart.Axis(StandardAxis.Depth);
			axisZ.ScaleConfigurator = scaleZ;

			// add a surface series
			NGridSurfaceSeries surface = new NGridSurfaceSeries();
			chart.Series.Add(surface);
			surface.Name = "Surface";
			surface.Legend.Mode = SeriesLegendMode.None;
			surface.FillStyle = new NColorFillStyle(Color.FromArgb(160, 170, 212));
			surface.FillMode = SurfaceFillMode.Uniform;
			surface.FrameMode = SurfaceFrameMode.None;
			surface.DrawFlat = false;
			surface.ShadingMode = ShadingMode.Smooth;
			SetupCommonSurfaceProperties(surface);

			// add a surface series
			NGridSurfaceSeries contour = new NGridSurfaceSeries();
			chart.Series.Add(contour);
			contour.Name = "Contour";
			contour.Legend.Mode = SeriesLegendMode.SeriesLogic;
			contour.FillMode = SurfaceFillMode.Zone;
			contour.FrameMode = SurfaceFrameMode.Contour;
			contour.DrawFlat = true;
			contour.ShadingMode = ShadingMode.Flat;
			SetupCommonSurfaceProperties(contour);

			contour.AutomaticPalette = false;
			contour.Palette.Clear();
			contour.Palette.Add(250, Color.FromArgb(112, 211, 162));
			contour.Palette.Add(311, Color.FromArgb(113, 197, 212));
			contour.Palette.Add(328, Color.FromArgb(114, 162, 212));
			contour.Palette.Add(344, Color.FromArgb(196, 185, 206));
			contour.Palette.Add(358, Color.FromArgb(161, 130, 191));
			contour.Palette.Add(370, Color.FromArgb(198, 170, 165));
			contour.Palette.Add(400, Color.FromArgb(255, 0, 0));

			// fill both surfaces with the same data
			FillData(surface, contour);

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);
		}

		private void FillData(NGridSurfaceSeries surface, NGridSurfaceSeries contour)
		{
			Stream stream = null;
			BinaryReader reader = null;

			try
			{
				// fill the XYZ data from a binary resource
				stream = NResourceHelper.GetResourceStream(GetType().Assembly, "DataY.bin", "Nevron.Examples.Chart.Wpf.Resources");
				reader = new BinaryReader(stream);

				int dataPointsCount = (int)(stream.Length / 4);
				int sizeX = (int)Math.Sqrt(dataPointsCount);
				int sizeZ = sizeX;

				surface.Data.SetGridSize(sizeX, sizeZ);
				contour.Data.SetGridSize(sizeX, sizeZ);

				for (int z = 0; z < sizeZ; z++)
				{
					for (int x = 0; x < sizeX; x++)
					{
						double value = 300 + 0.3 * (double)reader.ReadSingle();
						surface.Data.SetValue(x, z, value);
						contour.Data.SetValue(x, z, value);
					}
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
		private void SetupCommonSurfaceProperties(NGridSurfaceSeries surface)
		{
			surface.SyncPaletteWithAxisScale = false;
			surface.PaletteSteps = 6;
			surface.UseCustomXOriginAndStep = true;
			surface.OriginX = -150;
			surface.StepX = 10;
			surface.UseCustomZOriginAndStep = true;
			surface.OriginZ = -150;
			surface.StepZ = 10;
		}

		private void SetupAxisAnchorsAndWalls(NCartesianChart chart)
		{
			foreach (NAxis axis in chart.Axes)
			{
				AxisOrientation orientation = axis.AxisOrientation;
				axis.Anchor = new NBestVisibilityAxisAnchor(orientation);
			}

			foreach (NChartWall wall in chart.Walls)
			{
				wall.VisibilityMode = WallVisibilityMode.Auto;
			}
		}
	}
}
