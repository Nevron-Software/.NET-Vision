using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.ThinWeb;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NMeshIntersectedUC : NExampleUC
	{
		protected Label Label3;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!nChartControl1.Initialized)
			{
				nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
				nChartControl1.Settings.JitterMode = JitterMode.Enabled;

				// set a chart title
				NLabel title = nChartControl1.Labels.AddHeader("Intersected Surfaces");
				title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
				title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

				// no legend
				nChartControl1.Legends.Clear();

				// setup chart
				NChart chart = nChartControl1.Charts[0];
				chart.Enable3D = true;
				chart.Width = 65.0f;
				chart.Depth = 65.0f;
				chart.Height = 30.0f;
				chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
				chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

				// setup Y axis
				NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
				linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8);

				// add interlace stripe
				NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
				stripStyle.Interlaced = true;
				stripStyle.SetShowAtWall(ChartWallType.Back, true);
				stripStyle.SetShowAtWall(ChartWallType.Left, true);
				linearScaleConfigurator.StripStyles.Add(stripStyle);

				// setup X axis
				linearScaleConfigurator = new NLinearScaleConfigurator();
				linearScaleConfigurator.RoundToTickMin = false;
				linearScaleConfigurator.RoundToTickMax = false;
				linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8);
				linearScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Floor, ChartWallType.Back };
				chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleConfigurator;

				// setup Z axis
				linearScaleConfigurator = new NLinearScaleConfigurator();
				linearScaleConfigurator.RoundToTickMin = false;
				linearScaleConfigurator.RoundToTickMax = false;
				linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8);
				linearScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Floor, ChartWallType.Left };
				chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScaleConfigurator;

				// setup surface series 1
				NMeshSurfaceSeries surface1 = (NMeshSurfaceSeries)chart.Series.Add(SeriesType.MeshSurface);
				surface1.Name = "Surface 1";
				surface1.FillMode = SurfaceFillMode.Zone;
				surface1.FrameMode = SurfaceFrameMode.MeshContour;
				surface1.FrameColorMode = SurfaceFrameColorMode.Zone;
				surface1.SmoothPalette = true;
				surface1.Legend.Mode = SeriesLegendMode.None;
				surface1.FillStyle.SetTransparencyPercent(50);
				surface1.Data.SetGridSize(20, 20);
				surface1.ShadingMode = ShadingMode.Smooth;
				FillData1(surface1);

				// setup surface series 2
				NMeshSurfaceSeries surface2 = (NMeshSurfaceSeries)chart.Series.Add(SeriesType.MeshSurface);
				surface2.Name = "Surface 2";
				surface2.FillMode = SurfaceFillMode.Zone;
				surface2.FrameMode = SurfaceFrameMode.MeshContour;
				surface2.FrameColorMode = SurfaceFrameColorMode.Zone;
				surface2.SmoothPalette = true;
				surface2.Legend.Mode = SeriesLegendMode.None;
				surface2.Data.SetGridSize(20, 20);
				surface2.ShadingMode = ShadingMode.Smooth;
				FillData2(surface2);

				nChartControl1.Controller.SetActivePanel(chart);
				nChartControl1.Controller.Tools.Add(new NTrackballTool());
			}

			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithPercents(TransparencyDropDownList, 10);
				TransparencyDropDownList.SelectedIndex = 5;
			}

			UpdateSurface();
		}

		void UpdateSurface()
		{
			NChart chart = nChartControl1.Charts[0];
			NLabel title = nChartControl1.Labels[0];
			NSurfaceSeriesBase surface1 = (NSurfaceSeriesBase)chart.Series[0];
			NSurfaceSeriesBase surface2 = (NSurfaceSeriesBase)chart.Series[1];

			if (Surface1ShowFrameCheckBox.Checked)
			{
				surface1.FrameMode = SurfaceFrameMode.MeshContour;
			}
			else
			{
				surface1.FrameMode = SurfaceFrameMode.None;
			}

			if (Surface2ShowFrameCheckBox.Checked)
			{
				surface2.FrameMode = SurfaceFrameMode.MeshContour;
			}
			else
			{
				surface2.FrameMode = SurfaceFrameMode.None;
			}

			surface1.FillStyle.SetTransparencyPercent(TransparencyDropDownList.SelectedIndex * 10);
			surface1.SmoothPalette = Surface1SmoothPaletteCheckBox.Checked;
			surface2.SmoothPalette = Surface2SmoothPaletteCheckBox.Checked;

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}

		void FillData1(NMeshSurfaceSeries surface)
		{
			double y, x, z;
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			const double dIntervalX = 20.0;
			const double dIntervalZ = 20.0;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			z = -(dIntervalZ / 2);

			for (int j = 0; j < nCountZ; j++, z += dIncrementZ)
			{
				x = -(dIntervalX / 2);

				for (int i = 0; i < nCountX; i++, x += dIncrementX)
				{
					y = Math.Sqrt((x * x) + (z * z) + 2);
					y -= 0.08 * Math.Sqrt(Math.Abs(Math.Sinh(x)));

					if (x < 0)
					{
						y += 0.11 * x * x;
					}

					surface.Data.SetValue(i, j, y, x, z);
				}
			}
		}

		void FillData2(NMeshSurfaceSeries surface)
		{
			double y, x, z;
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			const double dIntervalX = 20.0;
			const double dIntervalZ = 20.0;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			z = -(dIntervalZ / 2);

			for (int j = 0; j < nCountZ; j++, z += dIncrementZ)
			{
				x = -(dIntervalX / 2);

				for (int i = 0; i < nCountX; i++, x += dIncrementX)
				{
					if ((x > 0) && (x < 10) && (z > -7) && (z < 7))
					{
						y = 15 * Math.Abs(Math.Sin(x / 4) * Math.Cos(z / 4));
					}
					else
					{
						y = 2 * Math.Sin(x / 2) * Math.Cos(z / 2);
					}

					surface.Data.SetValue(i, j, y, x, z);
				}
			}
		}

	}
}