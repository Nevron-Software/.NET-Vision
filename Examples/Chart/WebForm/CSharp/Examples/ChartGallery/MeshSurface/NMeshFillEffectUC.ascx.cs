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
	public partial class NMeshFillEffectUC : NExampleUC
	{
		protected Label Label3;

		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Surface Fill Styles");
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
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft);
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);

			if (!IsPostBack)
			{
				RotationTextBox.Text = chart.Projection.Rotation.ToString();
				ElevationTextBox.Text = chart.Projection.Elevation.ToString();
			}
			else
			{
				chart.Projection.Rotation = (float)Convert.ToDouble(RotationTextBox.Text);
				chart.Projection.Elevation = (float)Convert.ToDouble(ElevationTextBox.Text);
			}

			// setup Y axis
			NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
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
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Floor, ChartWallType.Back };
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleConfigurator;

			// setup Z axis
			linearScaleConfigurator = new NLinearScaleConfigurator();
			linearScaleConfigurator.RoundToTickMin = false;
			linearScaleConfigurator.RoundToTickMax = false;
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Floor, ChartWallType.Left };
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScaleConfigurator;

			// setup mesh surface series
			NMeshSurfaceSeries surface = (NMeshSurfaceSeries)chart.Series.Add(SeriesType.MeshSurface);
			surface.Name = "Surface";
			surface.FrameMode = SurfaceFrameMode.None;
			surface.FillMode = SurfaceFillMode.Uniform;
			surface.AutomaticPalette = false;
			surface.Data.SetGridSize(50, 50);
			surface.ShadingMode = ShadingMode.Smooth;

			switch (SurfaceFillEffectDropDownList.SelectedIndex)
			{
				case 0: // Color
					surface.FillStyle = new NColorFillStyle(Red);
					break;
				case 1: // Gradient
					surface.FillStyle = new NGradientFillStyle(GradientStyle.FromCenter, GradientVariant.Variant1, Color.White, DarkOrange);
					break;
				case 2: // Image
					surface.FillStyle = new NImageFillStyle(this.MapPathSecure(this.TemplateSourceDirectory + "\\SurfaceTexture.jpg"));
					break;
				case 3: // Pattern
					surface.FillStyle = new NHatchFillStyle(HatchStyle.HorizontalBrick, Color.White, DarkOrange);
					break;
				case 4:
					surface.FillStyle = new NAdvancedGradientFillStyle(AdvancedGradientScheme.Fire1, 12);
					break;
			}

			FillDataXY(surface);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}

		void FillDataXY(NMeshSurfaceSeries surface)
		{
			double x, y, z;
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			const double dIntervalX = 4.4;
			const double dIntervalZ = 4.4;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			for(int j = 0; j < nCountZ; j++)
			{
				for(int i = 0; i < nCountX; i++)
				{
					x = -(dIntervalX / 2) + (i * dIncrementX);
					z = -(dIntervalZ / 2) + (j * dIncrementZ);

					y = 8 * Math.Cos(x * x) + 5 * Math.Sin(z * z);

					x += Math.Sin(j / 4.0) / 4.0;
					z += Math.Cos(i / 4.0) / 4.0;

					surface.Data.SetValue(i, j, y, x, z);
				}
			}
		}
	}
}
