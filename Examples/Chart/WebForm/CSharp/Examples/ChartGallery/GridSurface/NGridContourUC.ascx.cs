using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NGridContourUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.HighSpeed;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Contour Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// disable the legend background and some of the gridlines
			NLegend legend = nChartControl1.Legends[0];
			legend.VerticalBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.HorizontalBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.OuterBottomBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.OuterLeftBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.OuterRightBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.OuterTopBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.FillStyle = new NColorFillStyle(Color.Transparent);
			legend.Data.MarkSize = new NSizeL(
				new NLength(8, NGraphicsUnit.Pixel),
				new NLength(8, NGraphicsUnit.Pixel));

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 70.0f;
			chart.Depth = 70.0f;
			chart.Height = 5.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalTop);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.None);

			// setup chart walls
			chart.Wall(ChartWallType.Back).Visible = false;
			chart.Wall(ChartWallType.Left).Visible = false;

			// setup Y axis
			NAxis axisY = chart.Axis(StandardAxis.PrimaryY);
			axisY.Visible = false;

			// setup X axis
			NAxis axisX = chart.Axis(StandardAxis.PrimaryX);
			((NDockAxisAnchor)axisX.Anchor).AxisDockZone = AxisDockZone.FrontTop;
			NOrdinalScaleConfigurator ordinalScaleConfigurator = (NOrdinalScaleConfigurator)axisX.ScaleConfigurator;
			ordinalScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Floor };
			ordinalScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			ordinalScaleConfigurator.DisplayDataPointsBetweenTicks = false;

			// setup Z axis
			NAxis axisZ = chart.Axis(StandardAxis.Depth);
			((NDockAxisAnchor)axisZ.Anchor).AxisDockZone = AxisDockZone.TopRight;
			ordinalScaleConfigurator = (NOrdinalScaleConfigurator)axisZ.ScaleConfigurator;
			ordinalScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Floor };
			ordinalScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			ordinalScaleConfigurator.DisplayDataPointsBetweenTicks = false;

			// add the surface series
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series.Add(SeriesType.GridSurface);
			surface.Name = "Contour";
			surface.Legend.Mode = SeriesLegendMode.SeriesLogic;
			surface.Legend.TextStyle.FontStyle.EmSize = new NLength(8, NGraphicsUnit.Point);
			surface.FillMode = SurfaceFillMode.Zone;
			surface.FrameMode = SurfaceFrameMode.Contour;
			surface.DrawFlat = true;
			surface.Data.SetGridSize(30, 30);

			// setup the custom palette
			surface.AutomaticPalette = false;
			surface.Palette.Clear();
			surface.Palette.Add(0.0, Color.Purple);
			surface.Palette.Add(1.5, Color.MediumSlateBlue);
			surface.Palette.Add(3.0, Color.CornflowerBlue);
			surface.Palette.Add(4.5, Color.LimeGreen);
			surface.Palette.Add(6.0, Color.LightGreen);
			surface.Palette.Add(7.5, Color.Yellow);
			surface.Palette.Add(9.0, Color.Orange);
			surface.Palette.Add(10.5, Color.Red);
			surface.Palette.Add(100, Color.Red);

			if(PaletteFrameCheckBox.Checked)
			{
				surface.FrameColorMode = SurfaceFrameColorMode.Zone;
			}
			else
			{
				surface.FrameColorMode = SurfaceFrameColorMode.Uniform;
			}

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

			if(ShowFillingCheckBox.Checked)
			{
				surface.FillMode = SurfaceFillMode.Zone;
			}
			else
			{
				surface.FillMode = SurfaceFillMode.None;
			}

			if(ShowFrameCheckBox.Checked)
			{
				surface.FrameMode = SurfaceFrameMode.Contour;
				PaletteFrameCheckBox.Enabled = true;
			}
			else
			{
				surface.FrameMode = SurfaceFrameMode.None;
				PaletteFrameCheckBox.Enabled = false;
			}

			// fill with data
			FillData(surface);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, legend);
		}

		private void FillData(NGridSurfaceSeries surface)
		{
			double y, x, z;
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			const double dIntervalX = 10.0;
			const double dIntervalZ = 10.0;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			z = -(dIntervalZ / 2);

			for(int j = 0; j < nCountZ; j++, z += dIncrementZ)
			{
				x = -(dIntervalX / 2);

				for(int i = 0; i < nCountX; i++, x += dIncrementX)
				{
					y = 10 - Math.Sqrt((x * x) + (z * z) + 2);
					y += 3.0 * Math.Sin(x) * Math.Cos(z);

					surface.Data.SetValue(i, j, y);
				}
			}
		}
	}
}
