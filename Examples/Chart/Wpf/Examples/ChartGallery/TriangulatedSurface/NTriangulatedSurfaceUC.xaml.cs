using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using Nevron.UI;
using System.Drawing;
using System.IO;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NTriangulatedSurfaceUC : NExampleBaseUC
	{
		public NTriangulatedSurfaceUC()
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
				return	"This example demonstrates some of the capabilities of the Triangulated Surface Series. This charting type can display a set of points with X, Y and Z coordinates as a 3D surface. In contrast to the Mesh Surface chart, the Triangulated Surface doesn't require the points to be ordered in a network. The control creates a triangular network automatically.\r\n"+
						"The Triangulated Surface supports common surface features like zone palette filling, mesh lines, contour lines, flat mode, smooth shading, texture mapping  etc.";
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
			NLabel title = nChartControl1.Labels.AddHeader("Surface Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.BoundsMode = BoundsMode.Fit;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 10.0f;
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
			surface.Legend.Mode = SeriesLegendMode.SeriesLogic;
			surface.SyncPaletteWithAxisScale = false;
			surface.ValueFormatter.FormatSpecifier = "0.00";
			surface.FillStyle = new NColorFillStyle(Color.YellowGreen);

			FillData();

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

			SmoothShadingCheckBox.IsChecked = true;
			SmoothPaletteCheckBox.IsChecked = false;
			FillModeComboBox.SelectedIndex = 2;
			FrameModeComboBox.SelectedIndex = 2;
			FrameColorModeComboBox.SelectedIndex = 0;
			PositionModeComboBox.SelectedIndex = 0;
			CustomValueScrollBar.Value = 0.1f;

			PositionModeComboBox.IsEnabled = false;
			CustomValueScrollBar.IsEnabled = false;

			DrawFlatCheckBox_Checked(null, null);
			SmoothShadingCheckBox_Checked(null, null);
			SmoothPaletteCheckBox_Checked(null, null);
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

				//surface.Data.SetCapacity(nDataPointsCount);
				NVector3DF[] data = new NVector3DF[nDataPointsCount];

				// fill Y values
				for (int i = 0; i < nDataPointsCount; i++)
				{
					data[i].Y = reader.ReadSingle();
				}

				// fill X values
				for (int i = 0; i < nDataPointsCount; i++)
				{
					data[i].X = reader.ReadSingle();
				}

				// fill Z values
				for (int i = 0; i < nDataPointsCount; i++)
				{
					data[i].Z = reader.ReadSingle();
				}

				for (int i = 0; i < nDataPointsCount; i++)
				{
					surface.Data.AddValue(data[i]);
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

		private void FillModeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

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
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

			surface.FrameMode = (SurfaceFrameMode)FrameModeComboBox.SelectedIndex;
			nChartControl1.Refresh();

			// form controls
			FrameColorModeComboBox.IsEnabled = (surface.FrameMode != SurfaceFrameMode.None);
		}
		private void FrameColorModeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

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
		private void PositionModeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

			surface.PositionMode = (SurfacePositionMode)PositionModeComboBox.SelectedIndex;
			nChartControl1.Refresh();
		}
		private void CustomValueScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

			surface.PositionValue = CustomValueScrollBar.Value * 250.0f;
			nChartControl1.Refresh();
		}
		private void DrawFlatCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

			surface.DrawFlat = (bool)DrawFlatCheckBox.IsChecked;

			// form controls
			PositionModeComboBox.IsEnabled = (bool)DrawFlatCheckBox.IsChecked;
			CustomValueScrollBar.IsEnabled = (bool)DrawFlatCheckBox.IsChecked;

			nChartControl1.Refresh();
		}
		private void SmoothShadingCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

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
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

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
