using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NGridFillEffectUC : NExampleUC
	{
		protected Label Label3;

		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Surface With Texture");
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
			chart.Projection.Type = ProjectionType.Perspective;
			chart.Projection.Elevation = 28;
			chart.Projection.Rotation = -18;

			if (!IsPostBack)
			{
				SurfaceFillEffectDropDownList.Items.Add("Color");
				SurfaceFillEffectDropDownList.Items.Add("Gradient");
				SurfaceFillEffectDropDownList.Items.Add("Image");
				SurfaceFillEffectDropDownList.Items.Add("Pattern");
				SurfaceFillEffectDropDownList.Items.Add("Advanced gradient");
				SurfaceFillEffectDropDownList.SelectedIndex = 0;

				RotationTextBox.Text = chart.Projection.Rotation.ToString();
				ElevationTextBox.Text = chart.Projection.Elevation.ToString();
				smoothShadingCheck.Checked = true;
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
			surface.FrameMode = SurfaceFrameMode.None;
			surface.FillMode = SurfaceFillMode.Uniform;
			surface.AutomaticPalette = false;
			surface.Data.SetGridSize(60, 60);

			switch (SurfaceFillEffectDropDownList.SelectedIndex)
			{
				case 0: // Color
					surface.FillStyle = new NColorFillStyle(Red);
					break;
				case 1: // Gradient
					surface.FillStyle = new NGradientFillStyle(GradientStyle.FromCenter, GradientVariant.Variant1, Color.WhiteSmoke, Color.Goldenrod);
					break;
				case 2: // Image
					surface.FillStyle = new NImageFillStyle(this.MapPathSecure(this.TemplateSourceDirectory + "\\SurfaceTexture.jpg"));
					break;
				case 3: // Pattern
					surface.FillStyle = new NHatchFillStyle(HatchStyle.HorizontalBrick, Color.Yellow, Color.Orange);
					break;
				case 4:
					surface.FillStyle = new NAdvancedGradientFillStyle(AdvancedGradientScheme.Fire1, 12);
					break;
			}

			if(smoothShadingCheck.Checked)
			{
				surface.ShadingMode = ShadingMode.Smooth;
			}
			else
			{
				surface.ShadingMode = ShadingMode.Flat;
			}

			FillData();

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}

		private void FillData()
		{
			NChart chart = nChartControl1.Charts[0];
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series[0];

			Stream stream = null;
			BinaryReader reader = null;

			try
			{
				// fill the XYZ data from a binary resource
				string path = MapPathSecure(TemplateSourceDirectory) + "\\DataY.bin";
				stream = new FileStream(path, FileMode.Open, FileAccess.Read);
				reader = new BinaryReader(stream);

				int dataPointsCount = (int)(stream.Length / 4);
				int sizeX = (int)Math.Sqrt(dataPointsCount);
				int sizeZ = sizeX;

				surface.Data.SetGridSize(sizeX, sizeZ);

				for(int z = 0; z < sizeZ; z++)
				{
					for(int x = 0; x < sizeX; x++)
					{
						surface.Data.SetValue(x, z, reader.ReadSingle());
					}
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
	}
}
