using Nevron.Chart;
using Nevron.Dom;
using Nevron.GraphicsCore;
using System;
using System.Drawing;
using System.IO;
using System.Web.UI.WebControls;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NVertexSurfaceFillCustomColorsUC : NExampleUC
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
			NLabel title = nChartControl1.Labels.AddHeader("Vertex Surface Fill Custom Colors ");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

            // setup chart
            NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.BoundsMode = BoundsMode.Fit;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 40.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.Projection.Elevation = 45;
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft);

			// setup Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.RoundToTickMax = false;
			scaleY.RoundToTickMin = false;
			scaleY.MinTickDistance = new NLength(10, NGraphicsUnit.Point);
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Left, ChartWallType.Back };
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

			// setup X axis
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.RoundToTickMax = false;
			scaleX.RoundToTickMin = false;
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Floor, ChartWallType.Back };
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// setup Z axis
			NLinearScaleConfigurator scaleZ = new NLinearScaleConfigurator();
			scaleZ.RoundToTickMax = false;
			scaleZ.RoundToTickMin = false;
			scaleZ.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Floor, ChartWallType.Left };
			scaleZ.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ;

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		
            // add data
            Random random = new Random();

            // setup surface series
            NVertexSurfaceSeries surface = new NVertexSurfaceSeries();
            chart.Series.Add(surface);

            surface.Name = "Surface";
            surface.SyncPaletteWithAxisScale = false;
            surface.PaletteSteps = 8;
            surface.ValueFormatter.FormatSpecifier = "0.00";
            surface.FillMode = SurfaceFillMode.CustomColors;
            surface.FrameMode = SurfaceFrameMode.None;
            surface.VertexPrimitive = VertexPrimitive.Triangles;
            surface.Data.UseColors = true;
            surface.UseIndices = true;

            int cubeSide = 8;

            int dataPointCount = 8 * (int)Math.Pow(cubeSide, 3);
            Random rand = new Random();

            surface.Data.SetCapacity(dataPointCount);

            uint currentIndex = 0;

            uint[] cubeIndices = new uint[] {   // bottom
                                                0, 1, 3,
                                                0, 3, 2,

                                                // left
                                                2, 0, 4,
                                                2, 4, 6,

                                                // right
                                                1, 3, 5,
                                                3, 7, 5,

                                                // front
                                                0, 1, 4,
                                                1, 5, 4,

                                                // back
                                                2, 6, 3,
                                                3,6, 7,

                                                // top
                                                4, 5, 6,
                                                5, 7, 6 };

            // generate all vertexes and colors
            for (int x = 0; x < cubeSide; x++)
            {
                double x1 = x + 0.1;
                double x2 = x + 1 - 0.1;

                int r1 = (byte)(x1 * 255.0 / cubeSide);
                int r2 = (byte)(x1 * 255.0 / cubeSide);

                for (int y = 0; y < cubeSide; y++)
                {
                    double y1 = y + 0.1;
                    double y2 = y + 1 - 0.1;

                    int g1 = (byte)(y1 * 255.0 / cubeSide);
                    int g2 = (byte)(y1 * 255.0 / cubeSide);

                    for (int z = 0; z < cubeSide; z++)
                    {
                        double z1 = z + 0.1;
                        double z2 = z + 1 - 0.1;

                        int b1 = (byte)(z1 * 255.0 / cubeSide);
                        int b2 = (byte)(z1 * 255.0 / cubeSide);

                        surface.Data.AddValueColor(new NVector3DD(x1, y1, z1), Color.FromArgb(r1, g1, b1));
                        surface.Data.AddValueColor(new NVector3DD(x2, y1, z1), Color.FromArgb(r2, g1, b1));
                        surface.Data.AddValueColor(new NVector3DD(x1, y2, z1), Color.FromArgb(r1, g2, b1));
                        surface.Data.AddValueColor(new NVector3DD(x2, y2, z1), Color.FromArgb(r2, g2, b1));
                        surface.Data.AddValueColor(new NVector3DD(x1, y1, z2), Color.FromArgb(r1, g1, b2));
                        surface.Data.AddValueColor(new NVector3DD(x2, y1, z2), Color.FromArgb(r2, g1, b2));
                        surface.Data.AddValueColor(new NVector3DD(x1, y2, z2), Color.FromArgb(r1, g2, b2));
                        surface.Data.AddValueColor(new NVector3DD(x2, y2, z2), Color.FromArgb(r2, g2, b2));

                        // add indicess
                        for (int i = 0; i < cubeIndices.Length; i++)
                        {
                            surface.Indices.Add(currentIndex + cubeIndices[i]);
                        }

                        currentIndex += 8;
                    }
                }
            }
        }
    }
}
