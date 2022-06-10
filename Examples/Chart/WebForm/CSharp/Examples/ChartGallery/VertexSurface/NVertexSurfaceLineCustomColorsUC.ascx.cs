using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using Nevron.Examples.Framework.WebForm;
using Nevron.UI;
using Nevron.UI.WebForm.Controls;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.ThinWeb;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NVertexSurfaceLineCustomColorsUC : NExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!nChartControl1.Initialized)
            {
				nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

                // set a chart title
                NLabel title = nChartControl1.Labels.AddHeader("Vertex Surface Line Custom Colors");
				title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
				title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

				// setup chart
				NChart chart = nChartControl1.Charts[0];
                chart.Enable3D = true;
                chart.Width = 60.0f;
                chart.Depth = 60.0f;
                chart.Height = 50.0f;
                chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
                chart.LightModel.EnableLighting = false;

                // setup axes
                NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
                scaleY.MajorTickMode = MajorTickMode.AutoMaxCount;
                scaleY.MaxTickCount = 5;

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

				// apply layout
				ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
			}

            FillData();
        }

		private void FillData()
		{
			int dataPointCount = 10000;
			int lineCount = 5;

			NChart chart = nChartControl1.Charts[0];
			chart.Series.Clear();
			Random random = new Random();

			NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Fresh);

			for (int lineIndex = 0; lineIndex < lineCount; lineIndex++)
			{
				// setup surface series
				NVertexSurfaceSeries surface = new NVertexSurfaceSeries();
				chart.Series.Add(surface);

				surface.Name = "Surface";
				surface.SyncPaletteWithAxisScale = false;
				surface.PaletteSteps = 8;
				surface.ValueFormatter.FormatSpecifier = "0.00";
				surface.FillMode = SurfaceFillMode.CustomColors;
				surface.FrameMode = SurfaceFrameMode.Dots;
				surface.FrameColorMode = SurfaceFrameColorMode.CustomColors;
				surface.VertexPrimitive = VertexPrimitive.LineStrip;
				surface.Data.UseColors = true;
				surface.Data.SetCapacity(dataPointCount);

				double x = 0.1;
				double y = 0;
				double z = 0;
				double a = 10.0;
				double b = 18 + lineIndex; // 28.0 - ;
				double c = (lineIndex + 3) / 3.0; //8.0
				double t = lineIndex * (0.01 / lineCount) + 0.01;

				Color color1 = palette.SeriesColors[lineIndex % palette.SeriesColors.Count];
				Color color2 = palette.SeriesColors[(lineIndex + 1) % palette.SeriesColors.Count];

				for (int dataPointIndex = 0; dataPointIndex < dataPointCount; dataPointIndex++)
				{
					float xt = (float)(x + t * a * (y - x));
					float yt = (float)(y + t * (x * (b - z) - y));
					float zt = (float)(z + t * (x * y - c * z));

					surface.Data.AddValueColor(xt, yt, zt, InterpolateColors(color1, color2, (float)((yt + 40.0) / 80.0)));

					x = xt;
					y = yt;
					z = zt;
				}
			}
		}
		/// <summary>
		/// Returns a color between begin and end color. The coff parameter must be in the range [0, 1].
		/// </summary>
		/// <param name="begin"></param>
		/// <param name="end"></param>
		/// <param name="coeff"></param>
		/// <returns></returns>
		public static Color InterpolateColors(Color color1, Color color2, float coeff)
		{
			if (coeff > 1.0f)
				coeff = 1.0f;

			int num1 = ((int)color1.R);
			int num2 = ((int)color1.G);
			int num3 = ((int)color1.B);

			int num4 = ((int)color2.R);
			int num5 = ((int)color2.G);
			int num6 = ((int)color2.B);

			byte num7 = (byte)((((float)num1) + (((float)(num4 - num1)) * coeff)));
			byte num8 = (byte)((((float)num2) + (((float)(num5 - num2)) * coeff)));
			byte num9 = (byte)((((float)num3) + (((float)(num6 - num3)) * coeff)));

			return Color.FromArgb(num7, num8, num9);
		}
	}
}
