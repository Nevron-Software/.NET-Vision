using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.UI.WebForm.Controls;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NImageResponseUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				ImageTypeDropDownList.Items.Add("PNG");
				ImageTypeDropDownList.Items.Add("JPEG");
				ImageTypeDropDownList.Items.Add("GIF");
				ImageTypeDropDownList.Items.Add("Bitmap");
				ImageTypeDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithValues(JPEGQualityDropDownList, 10, 100, 10);
				JPEGQualityDropDownList.SelectedIndex = 9;
			}

			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None;

			// override any settings we may have inherited from the web config file
			nChartControl1.ServerSettings.BrowserResponseSettings.BrowserResponsePairs.Clear();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Static Image");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 40.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			// setup axes
			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Left, ChartWallType.Back };

			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] {};
			scaleX.RoundToTickMin = false;
			scaleX.RoundToTickMax = false;

			NLinearScaleConfigurator scaleZ = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ;
			scaleZ.RoundToTickMin = false;
			scaleZ.RoundToTickMax = false;

            // setup series
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series.Add(SeriesType.GridSurface);
			surface.FillMode = SurfaceFillMode.Zone;
			surface.FrameMode = SurfaceFrameMode.None;
			surface.FrameColorMode = SurfaceFrameColorMode.Zone;
			surface.SmoothPalette = true;
			surface.ShadingMode = ShadingMode.Smooth;
			surface.SyncPaletteWithAxisScale = false;
			surface.PaletteSteps = 7;
			surface.Data.SetGridSize(20, 20);
			FillData(surface);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);

			NImageResponse response = new NImageResponse();
			
			JPEGQualityDropDownList.Enabled = false;

			switch(ImageTypeDropDownList.SelectedIndex)
			{
			case 0: // PNG
				response.ImageFormat = new NPngImageFormat();
				break;
			case 1: // JPEG
				NJpegImageFormat jpegImageFormat = new NJpegImageFormat();

				JPEGQualityDropDownList.Enabled = true;
				jpegImageFormat.Quality = JPEGQualityDropDownList.SelectedIndex * 10 + 10;
				response.ImageFormat = jpegImageFormat;
				break;
			case 2: // GIF
				response.ImageFormat = new NGifImageFormat();
				break;
			case 3: // BMP
				response.ImageFormat = new NBitmapImageFormat();
				break;
			}

			nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = response;
		}

		void FillData(NGridSurfaceSeries surface)
		{
			double y, x, z;
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			const double dIntervalX = 20.0;
			const double dIntervalZ = 20.0;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			z = -(dIntervalZ / 2);

			for(int j = 0; j < nCountZ; j++, z += dIncrementZ)
			{
				x = -(dIntervalX / 2);

				for(int i = 0; i < nCountX; i++, x += dIncrementX)
				{
					y = Math.Sqrt((x * x) + (z * z) + 2);
					y -= 0.08 * Math.Sqrt( Math.Abs(Math.Sinh(x)) );

					if(x < 0)
					{
						y += 0.11 * x * x;
					}

					surface.Data.SetValue(i, j, y);
				}
			}
		}

	}
}
