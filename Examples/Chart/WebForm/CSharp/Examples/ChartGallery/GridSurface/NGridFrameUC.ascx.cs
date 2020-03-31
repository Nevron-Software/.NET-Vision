using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NGridFrameUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Wireframe Surface");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 70.0f;
			chart.Depth = 70.0f;
			chart.Height = 30.0f;
			chart.Projection.Type = ProjectionType.Perspective;
			chart.Projection.Elevation = 28;
			chart.Projection.Rotation = -18;
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft);

			if (!IsPostBack)
			{
				RotationTextBox.Text = chart.Projection.Rotation.ToString();
				ElevationTextBox.Text = chart.Projection.Elevation.ToString();

				WebExamplesUtilities.FillComboWithColorNames(LineColorDropDownList, KnownColor.Black);
				WebExamplesUtilities.FillComboWithValues(LineWidhtDropDownList, 1, 5, 1);
			}
			else
			{
				chart.Projection.Rotation = (float)Convert.ToDouble(RotationTextBox.Text);
				chart.Projection.Elevation = (float)Convert.ToDouble(ElevationTextBox.Text);
			}

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
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Floor, ChartWallType.Back };
			scaleX.RoundToTickMin = false;
			scaleX.RoundToTickMax = false;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// setup Z axis
			NLinearScaleConfigurator scaleZ = new NLinearScaleConfigurator();
			scaleZ.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Floor, ChartWallType.Left };
			scaleZ.RoundToTickMin = false;
			scaleZ.RoundToTickMax = false;
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ;

			// add the surface series
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series.Add(SeriesType.GridSurface);
			surface.Name = "Surface";
			surface.FillMode = SurfaceFillMode.None;
			surface.FrameMode = SurfaceFrameMode.Mesh;
			surface.Data.SetGridSize(30, 30);
			surface.SyncPaletteWithAxisScale = false;
			surface.PaletteSteps = 8;
			surface.ValueFormatter.FormatSpecifier = "0.0";
			surface.Legend.Mode = SeriesLegendMode.None;

			if(PaletteFrameCheckBox.Checked)
			{
				surface.FrameColorMode = SurfaceFrameColorMode.Zone;
			}
			else
			{
				surface.FrameColorMode = SurfaceFrameColorMode.Uniform;
			}

			SmoothPaletteCheckBox.Enabled = PaletteFrameCheckBox.Checked;

			if(SmoothPaletteCheckBox.Checked)
			{
				surface.SmoothPalette = true;
				surface.Legend.Format = "<zone_value>";
			}
			else
			{
				surface.SmoothPalette = false;
				surface.Legend.Format = "<zone_begin> - <zone_end>";
			}

			surface.FrameStrokeStyle.Color = WebExamplesUtilities.ColorFromDropDownList(LineColorDropDownList);
			surface.FrameStrokeStyle.Width = new NLength(LineWidhtDropDownList.SelectedIndex + 1, NGraphicsUnit.Pixel);

			FillData(surface);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}

		void FillData(NGridSurfaceSeries surface)
		{
			double y, x, z;
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			const double dIntervalX = 30.0;
			const double dIntervalZ = 30.0;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			z = -(dIntervalZ / 2);

			for(int j = 0; j < nCountZ; j++, z += dIncrementZ)
			{
				x = -(dIntervalX / 2);

				for(int i = 0; i < nCountX; i++, x += dIncrementX)
				{
					y = (x * x) - (z * z);
					y += 200 * Math.Sin(x / 4.0) * Math.Cos(z / 4.0);

					surface.Data.SetValue(i, j, y);
				}
			}
		}
	}
}
