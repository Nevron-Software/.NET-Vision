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
	public partial class NTriangulatedSurfaceSimplificationUC : NExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!nChartControl1.Initialized)
            {
                nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
                nChartControl1.Settings.JitterMode = JitterMode.Enabled;

                // set a chart title
                NLabel title = nChartControl1.Labels.AddHeader("Triangulated Surface Chart");
                title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
                title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

                // hide the legend
                NLegend legend = nChartControl1.Legends[0];
                legend.Visible = false;

                // setup chart
                NChart chart = nChartControl1.Charts[0];
                chart.Enable3D = true;
                chart.Width = 60.0f;
                chart.Depth = 60.0f;
                chart.Height = 30.0f;
                chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft);
                chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
                chart.Projection.Elevation = 30;

                nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None;
                nChartControl1.Settings.EnableJittering = false;
                nChartControl1.Controller.SetActivePanel(chart);
                nChartControl1.Controller.Tools.Add(new NTrackballTool());

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

                // add the surface series
                NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series.Add(SeriesType.TriangulatedSurface);
                surface.Name = "Surface";
                surface.Legend.Mode = SeriesLegendMode.SeriesLogic;
                surface.SyncPaletteWithAxisScale = false;
                surface.PaletteSteps = 10;
                surface.ValueFormatter.FormatSpecifier = "0.00";
                surface.FillStyle = new NColorFillStyle(Color.YellowGreen);
                surface.UsePreciseGeometry = true;

                // set clustering parameters
                surface.ClusterMode = ClusterMode.Enabled;
                surface.ClusterDistanceFactor = 0.01;

                FillData();
            }

            NChart chart1 = nChartControl1.Charts[0];
            NTriangulatedSurfaceSeries surface1 = (NTriangulatedSurfaceSeries)chart1.Series[0];

			if (SimplifySurfaceCheckBox.Checked)
            {
                surface1.ClusterMode = ClusterMode.Enabled;
            }
            else
            {
                surface1.ClusterMode = ClusterMode.Disabled;
            }
        }

        private void FillData()
        {
            NChart chart = nChartControl1.Charts[0];
            NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

            Random rand = new Random();

            const int countX = 100;
            const int countZ = 100;

            NRange1DD rangeX = new NRange1DD(-10, 10);
            NRange1DD rangeZ = new NRange1DD(-10, 10);

            double stepX = rangeX.GetLength() / (countX - 1);
            double stepZ = rangeZ.GetLength() / (countZ - 1);

            double cx = -3.0;
            double cz = -5.0;

            for (int n = 0; n < countZ; n++)
            {
                double z = rangeZ.Begin + n * stepZ;

                for (int m = 0; m < countX; m++)
                {
                    double x = rangeX.Begin + m * stepX;
                    double dx = cx - x;
                    double dz = cz - z;
                    double distance = Math.Sqrt(dx * dx + dz * dz);

                    surface.Values.Add(Math.Sin(distance) * Math.Exp(-distance * 0.1));
                    surface.XValues.Add(x);
                    surface.ZValues.Add(z);
                }
            }
        }
	}
}
