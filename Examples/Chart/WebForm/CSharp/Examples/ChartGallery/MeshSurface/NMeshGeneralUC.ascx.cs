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
	public partial class NMeshGeneralUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.HighSpeed;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Mesh Surface Chart");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup legend
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
			chart.Height = 30.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);

			if (!IsPostBack)
			{
				// form controls
				FrameStyleDropDownList.Items.Add("None");
				FrameStyleDropDownList.Items.Add("Mesh");
				FrameStyleDropDownList.Items.Add("Contour");
				FrameStyleDropDownList.Items.Add("Mesh-Contour");
				FrameStyleDropDownList.Items.Add("Dots");
				FrameStyleDropDownList.SelectedIndex = 2;

				PositionModeDropDownList.Items.Add("Axis Begin");
				PositionModeDropDownList.Items.Add("Axis End");
				PositionModeDropDownList.Items.Add("Custom Value");
				PositionModeDropDownList.SelectedIndex = 0;

				RotationTextBox.Text = chart.Projection.Rotation.ToString();
				ElevationTextBox.Text = chart.Projection.Elevation.ToString();

				WebExamplesUtilities.FillComboWithPercents(TransparencyDropDownList, 10);
				WebExamplesUtilities.FillComboWithFloatValues(CustomValueDropDownList, 0, 1, 0.1f);
				CustomValueDropDownList.SelectedIndex = 5;
			}
			else
			{
				chart.Projection.Rotation = (float) Convert.ToDouble(RotationTextBox.Text);
				chart.Projection.Elevation = (float) Convert.ToDouble(ElevationTextBox.Text);
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
			linearScaleConfigurator = new NLinearScaleConfigurator();
			linearScaleConfigurator.RoundToTickMin = false;
			linearScaleConfigurator.RoundToTickMax = false;
			linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8);
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Floor, ChartWallType.Back };
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleConfigurator;

			// setup Z axis
			linearScaleConfigurator = new NLinearScaleConfigurator();
			linearScaleConfigurator.RoundToTickMin = false;
			linearScaleConfigurator.RoundToTickMax = false;
			linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8);
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Floor, ChartWallType.Left };
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScaleConfigurator;

			// setup mesh surface series
			NMeshSurfaceSeries surface = (NMeshSurfaceSeries) chart.Series.Add(SeriesType.MeshSurface);
			surface.Name = "Surface";
			surface.Legend.Mode = SeriesLegendMode.SeriesLogic;
			surface.Legend.TextStyle.FontStyle.EmSize = new NLength(8, NGraphicsUnit.Point);
			surface.FillMode = SurfaceFillMode.Zone;
			surface.PositionValue = 0.5;
			surface.Data.SetGridSize(20, 20);
			surface.SyncPaletteWithAxisScale = false;
			surface.PaletteSteps = 8;
			surface.ValueFormatter.FormatSpecifier = "0.00";
            surface.ShadingMode = ShadingMode.Smooth;

			FillDataXY(surface);

			if(PaletteFrameCheckBox.Checked)
			{
				surface.FrameColorMode = SurfaceFrameColorMode.Zone;
			}
			else
			{
				surface.FrameColorMode = SurfaceFrameColorMode.Uniform;
			}
			surface.DrawFlat = DrawFlatCheckBox.Checked;
			surface.PositionMode = (SurfacePositionMode) PositionModeDropDownList.SelectedIndex;
			surface.PositionValue = CustomValueDropDownList.SelectedIndex / 10.0;
			surface.FrameMode = (SurfaceFrameMode) FrameStyleDropDownList.SelectedIndex;
			surface.FillStyle.SetTransparencyPercent(TransparencyDropDownList.SelectedIndex * 10);

			if (SmoothPaletteCheckBox.Checked)
			{
				surface.SmoothPalette = true;
				surface.Legend.Format = "<zone_value>";
			}
			else
			{
				surface.SmoothPalette = false;
				surface.Legend.Format = "<zone_begin> - <zone_end>";
			}

			PositionModeDropDownList.Enabled = DrawFlatCheckBox.Checked;
			CustomValueDropDownList.Enabled = DrawFlatCheckBox.Checked;
			PaletteFrameCheckBox.Enabled = (surface.FrameMode != SurfaceFrameMode.None);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, legend);
		}

		private void FillDataXY(NMeshSurfaceSeries surface)
		{
			double x, y, z;
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			for (int j = 0; j < nCountZ; j++)
			{
				for (int i = 0; i < nCountX; i++)
				{
					x = 2 + i + Math.Sin(j / 4.0) * 2;
					z = 1 + j + Math.Cos(i / 4.0);

					y = Math.Sin(i / 3.0) * Math.Sin(j / 3.0);

					if (y < 0)
					{
						y = Math.Abs(y / 2.0);
					}

					surface.Data.SetValue(i, j, y, x, z);
				}
			}
		}
	}
}