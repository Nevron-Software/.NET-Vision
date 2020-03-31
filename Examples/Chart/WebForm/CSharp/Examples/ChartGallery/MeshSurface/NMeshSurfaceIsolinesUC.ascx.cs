using Nevron.Chart;
using Nevron.Dom;
using Nevron.GraphicsCore;
using System;
using System.Drawing;
using System.Web.UI.WebControls;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NMeshSurfaceIsolinesUC : NExampleUC
	{
		protected Label Label3;
		protected CheckBox DrawFlatCheckBoxBox;
		protected CheckBox ShowFillingCheckBox;
		protected CheckBox ShowFrameCheckBox;
	
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Mesh Surface Isolines");
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
			surface.Palette.SmoothPalette = true;
			surface.Legend.Mode = SeriesLegendMode.None;

			// generate data
			GenerateSurfaceData(surface);
			
			// add the isolines
			NSurfaceIsoline redIsoline = new NSurfaceIsoline();
			redIsoline.StrokeStyle = new NStrokeStyle(2.0f, Color.Red);
			redIsoline.Value = 100;
			surface.Isolines.Add(redIsoline);

			NSurfaceIsoline blueIsoline = new NSurfaceIsoline();
			blueIsoline.StrokeStyle = new NStrokeStyle(2.0f, Color.Blue);
			blueIsoline.Value = 50;
			surface.Isolines.Add(blueIsoline);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}
		private void GenerateSurfaceData(NMeshSurfaceSeries surface)
		{
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			const double dIntervalX = 20.0;
			const double dIntervalZ = 20.0;
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
					double y = Math.Sin(px * 0.33) * Math.Sin(pz * 0.33) * 200;

					if (y < 0)
					{
						y = -y * 0.7;
					}

					double tmp = (1 - x * x - z * z);
					y -= tmp * tmp * 0.000001;

					surface.Data.SetValue(i, j, y, x, z);
				}
			}
		}
	}
}
