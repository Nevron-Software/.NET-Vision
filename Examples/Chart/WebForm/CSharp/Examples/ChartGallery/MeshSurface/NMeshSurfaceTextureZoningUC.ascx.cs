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
	public partial class NMeshSurfaceTextureZoningUC : NExampleUC
	{
		protected Label Label3;
		protected CheckBox DrawFlatCheckBoxBox;
		protected CheckBox ShowFillingCheckBox;
		protected CheckBox ShowFrameCheckBox;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				PaletteModeDropDownList.Items.Add("Use Fixed Number of Zones");
				PaletteModeDropDownList.Items.Add("Synchronize Palette Zones with Y Axis");
				PaletteModeDropDownList.Items.Add("Use Custom Palette");

				WebExamplesUtilities.FillComboWithValues(PaletteStepsDropDownList, 2, 8, 1);

				// init form controls
				PaletteModeDropDownList.SelectedIndex = 0;
				PaletteStepsDropDownList.SelectedIndex = 6;
				SmoothPaletteCheckBox.Checked = false;
			}

			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Mesh Surface");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 25.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft);

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
			NMeshSurfaceSeries surface = new NMeshSurfaceSeries();
			chart.Series.Add(surface);
			surface.ShadingMode = ShadingMode.Smooth;
			surface.FillMode = SurfaceFillMode.ZoneTexture;
			surface.FrameMode = SurfaceFrameMode.None;
			surface.Data.SetGridSize(100, 100);

			// define a custom palette
			surface.Palette.Clear();
			surface.Palette.Add(-0.8, Color.FromArgb(112, 211, 162));
			surface.Palette.Add(-0.4, Color.FromArgb(113, 197, 212));
			surface.Palette.Add(-0.2, Color.FromArgb(114, 162, 212));
			surface.Palette.Add(0, Color.FromArgb(196, 185, 206));
			surface.Palette.Add(0.4, Color.FromArgb(161, 130, 191));
			surface.Palette.Add(0.8, Color.FromArgb(198, 170, 165));
			surface.Palette.Add(1, Color.FromArgb(160, 130, 80));

			// generate data
			GenerateSurfaceData(surface);


			switch (PaletteModeDropDownList.SelectedIndex)
			{
				case 0:
					surface.AutomaticPalette = true;
					surface.SyncPaletteWithAxisScale = false;
					PaletteStepsDropDownList.Enabled = true;
					break;

				case 1:
					surface.AutomaticPalette = true;
					surface.SyncPaletteWithAxisScale = true;
					PaletteStepsDropDownList.Enabled = false;
					break;

				case 2:
					surface.AutomaticPalette = false;
					PaletteStepsDropDownList.Enabled = false;
					break;
			}

			surface.SmoothPalette = SmoothPaletteCheckBox.Checked;
			surface.PaletteSteps = PaletteStepsDropDownList.SelectedIndex + 2;

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}

		private void GenerateSurfaceData(NMeshSurfaceSeries surface)
		{
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			const double dIntervalX = 40.0;
			const double dIntervalZ = 40.0;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			double pz = -(dIntervalZ / 2);

			for (int j = 0; j < nCountZ; j++, pz += dIncrementZ)
			{
				double px = -(dIntervalX / 2);

				for (int i = 0; i < nCountX; i++, px += dIncrementX)
				{
					double x = px + Math.Sin(pz) * 0.4;
					double z = pz + Math.Cos(px) * 0.4;
					double y = Math.Sin(px * 0.33) * Math.Sin(pz * 0.33);

					if (y < 0)
					{
						y = - y * 0.7;
					}

					double tmp = (1 - x * x - z * z);
					y -= tmp * tmp * 0.000001;

					surface.Data.SetValue(i, j, y, x, z);
				}
			}
		}
	}
}
