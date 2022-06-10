using Nevron.Chart;
using Nevron.GraphicsCore;
using System;
using System.Drawing;
using System.IO;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NSurfaceWithCustomColorsUC : NExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
                //Setup dropdown lists and check boxes states.
				fillModeDropDownList.Items.Add("None");
				fillModeDropDownList.Items.Add("Uniform");
				fillModeDropDownList.Items.Add("Custom Colors");
				fillModeDropDownList.SelectedIndex = 2;

				frameModeDropDownList.Items.Add("None");
				frameModeDropDownList.Items.Add("Mesh");
				frameModeDropDownList.Items.Add("Contour");
				frameModeDropDownList.Items.Add("Mesh-Contour");
				frameModeDropDownList.Items.Add("Dots");
				frameModeDropDownList.SelectedIndex = 0;

				frameColorModeDropDownList.Items.Add("Uniform");
				frameColorModeDropDownList.Items.Add("Custom Colors");
				frameColorModeDropDownList.SelectedIndex = 0;

				smoothShadingCheck.Checked = true;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Triangulated Surface with Custom Colors");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// remove legends
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 10.0f;
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft);
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.Projection.Elevation = 45;

			// setup Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.RoundToTickMax = false;
			scaleY.RoundToTickMin = false;
			scaleY.MinTickDistance = new NLength(10, NGraphicsUnit.Point);
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Left, ChartWallType.Back };
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

			// setup X axis
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.RoundToTickMax = false;
			scaleX.RoundToTickMin = false;
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Floor, ChartWallType.Back };
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// setup Z axis
			NLinearScaleConfigurator scaleZ = new NLinearScaleConfigurator();
			scaleZ.RoundToTickMax = false;
			scaleZ.RoundToTickMin = false;
			scaleZ.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Floor, ChartWallType.Left };
			scaleZ.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ;

			// add the surface series
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series.Add(SeriesType.TriangulatedSurface);
			surface.Name = "Surface";
			surface.SyncPaletteWithAxisScale = false;
			surface.ValueFormatter.FormatSpecifier = "0.00";
			surface.FillStyle = new NColorFillStyle(Color.YellowGreen);
			surface.PaletteSteps = 8;

			surface.FillMode = SurfaceFillMode.CustomColors;
			surface.FrameMode = SurfaceFrameMode.None;
			surface.FrameColorMode = SurfaceFrameColorMode.CustomColors;
			surface.ShadingMode = ShadingMode.Smooth;

			FillData();

			if(smoothShadingCheck.Checked)
			{
				surface.ShadingMode = ShadingMode.Smooth;
			}
			else
			{
				surface.ShadingMode = ShadingMode.Flat;
			}

			switch(fillModeDropDownList.SelectedIndex)
			{
				case 0:
					surface.FillMode = SurfaceFillMode.None;
					smoothShadingCheck.Enabled = false;
					break;

				case 1:
					surface.FillMode = SurfaceFillMode.Uniform;
					smoothShadingCheck.Enabled = true;
					break;

				case 2:
					surface.FillMode = SurfaceFillMode.CustomColors;
					smoothShadingCheck.Enabled = true;
					break;
			}

			surface.FrameMode = (SurfaceFrameMode)frameModeDropDownList.SelectedIndex;
			frameColorModeDropDownList.Enabled = (surface.FrameMode != SurfaceFrameMode.None);

			switch(frameColorModeDropDownList.SelectedIndex)
			{
				case 0:
					surface.FrameColorMode = SurfaceFrameColorMode.Uniform;
					break;

				case 1:
					surface.FrameColorMode = SurfaceFrameColorMode.CustomColors;
					break;
			}

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
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
				string path = MapPathSecure(TemplateSourceDirectory) + "\\DataXYZ.bin";
				stream = new FileStream(path, FileMode.Open, FileAccess.Read);
				reader = new BinaryReader(stream);

				int nDataPointsCount = (int)stream.Length / 12;

				NTriangulatedSurfaceData surfaceData = surface.Data;
				surfaceData.SetCount(nDataPointsCount);
				surfaceData.UseColors = true;

				// fill Y values and colors
				for (int i = 0; i < nDataPointsCount; i++)
				{
					float y = 300 - reader.ReadSingle();

					surfaceData.SetYValue(i, y);
					surfaceData.SetColor(i, GetColorFromValue(y));
				}

				// fill X values
				for (int i = 0; i < nDataPointsCount; i++)
				{
					surfaceData.SetXValue(i, reader.ReadSingle());
				}

				// fill Z values
				for (int i = 0; i < nDataPointsCount; i++)
				{
					surfaceData.SetZValue(i, reader.ReadSingle());
				}
			}
			finally
			{
				if(reader != null)
					reader.Close();

				if(stream != null)
					stream.Close();
			}
		}

		private Color GetColorFromValue(float y)
		{
			Color color = Color.Black;

			if(y < 100)
			{
				color = Color.FromArgb(20, 30, 180);
			}
			else if(y < 150)
			{
				color = Color.FromArgb(20, 100, 100);
			}
			else if(y < 200)
			{
				color = Color.FromArgb(20, 140, 80);
			}
			else if(y < 250)
			{
				color = Color.FromArgb(80, 140, 60);
			}
			else if(y < 300)
			{
				color = Color.FromArgb(140, 140, 40);
			}

			return Color.FromArgb(
				color.R + (int)(Random.NextDouble() * 50),
				color.G + (int)(Random.NextDouble() * 50),
				color.B + (int)(Random.NextDouble() * 50));
		}
	}
}
