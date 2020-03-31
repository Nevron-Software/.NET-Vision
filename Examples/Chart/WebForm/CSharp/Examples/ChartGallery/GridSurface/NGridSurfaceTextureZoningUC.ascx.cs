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
	public partial class NGridSurfaceTextureZoningUC : NExampleUC
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

				// form controls
				PaletteModeDropDownList.SelectedIndex = 0;
				PaletteStepsDropDownList.SelectedIndex = 6;
				SmoothPaletteCheckBox.Checked = false;
			}

			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Disabled;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Grid Surface");
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
			surface.Data.SetGridSize(200, 200);

			// define a custom palette
			surface.Palette.Clear();
			surface.Palette.Add(-3, Color.FromArgb(112, 211, 162));
			surface.Palette.Add(-2.5, Color.FromArgb(113, 197, 212));
			surface.Palette.Add(-1, Color.FromArgb(114, 162, 212));
			surface.Palette.Add(0, Color.FromArgb(196, 185, 206));
			surface.Palette.Add(2, Color.FromArgb(161, 130, 191));
			surface.Palette.Add(3, Color.FromArgb(198, 170, 165));
			surface.Palette.Add(4, Color.FromArgb(160, 130, 80));

			// generate data
			GenerateSurfaceData(surface);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);

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
		}

		private void GenerateSurfaceData(NGridSurfaceSeries surface)
		{
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
					y = (x * z / 64.0) - Math.Sin(z / 2.4) * Math.Cos(x / 2.4);
					y = Math.Abs(y);
					double tmp = (1 - x * x - z * z);
					y -= tmp * tmp * 0.000006;

					surface.Data.SetValue(i, j, y);
				}
			}
		}
	}
}
