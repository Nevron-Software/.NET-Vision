using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.ThinWeb;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NDataZoomToolUC : NExampleUC
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!NThinChartControl1.Initialized)
            {
                NThinChartControl1.BackgroundStyle.FrameStyle.Visible = false;

				// set a chart title
				NLabel title = NThinChartControl1.Labels.AddHeader("Data Zoom Tool");
                title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
                title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

                NThinChartControl1.ServerSettings.JQuery.SourceType = JQuerySourceType.Url;

                // no legend
                NThinChartControl1.Legends.Clear();

                // setup chart
                NChart chart = NThinChartControl1.Charts[0];
                chart.BoundsMode = BoundsMode.Stretch;

                // setup Y axis
                NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
                scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

                // add interlace stripe
                NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
                stripStyle.Interlaced = true;
                stripStyle.SetShowAtWall(ChartWallType.Back, true);
                stripStyle.SetShowAtWall(ChartWallType.Left, true);
				scaleY.StripStyles.Add(stripStyle);

                // setup X axis
                NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
                scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Floor, ChartWallType.Back };
                scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

                chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

                // setup point series
                NPointSeries point = (NPointSeries)chart.Series.Add(SeriesType.Point);
                point.Name = "Point1";
                point.DataLabelStyle.Visible = false;
                point.FillStyle = new NColorFillStyle(Color.FromArgb(160, DarkOrange));
                point.BorderStyle.Width = new NLength(0);
                point.Size = new NLength(2, NRelativeUnit.ParentPercentage);
                point.PointShape = PointShape.Ellipse;

                // instruct the point series to use custom X values
                point.UseXValues = true;

                // generate some random X values
                GenerateXYData(point);

                // apply layout
                ApplyLayoutTemplate(0, NThinChartControl1, chart, title, null);

                NThinChartControl1.Controller.SetActivePanel(chart);
			
                NThinChartControl1.Controller.Tools.Add(new NDataZoomTool());
                NThinChartControl1.Controller.Tools.Add(new NTooltipTool());
			}

            // configure the scrollbars and tiling
            NThinChartControl1.ServerSettings.EnableTiledZoom = UseTilingCheckBox.Checked;
            NThinChartControl1.ServerSettings.TileCacheSize = 3000;
            NChart chart1 = NThinChartControl1.Charts[0];

            NDataZoomTool dzt = (NDataZoomTool)NThinChartControl1.Controller.Tools.FindToolOfType(typeof(NDataZoomTool));
            dzt.ZoomOutResetsAxes = ZoomOutResetsAxesCheckBox.Checked;

            chart1.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = ShowScrollbarsCheckBox.Checked;
            chart1.Axis(StandardAxis.PrimaryY).ScrollBar.Visible = ShowScrollbarsCheckBox.Checked;
        }
			
        private void GenerateXYData(NPointSeries series)
        {
            for (int i = 0; i < 200; i++)
            {
                double u1 = Random.NextDouble();
                double u2 = Random.NextDouble();

                if (u1 == 0)
                    u1 += 0.0001;

                if (u2 == 0)
                    u2 += 0.0001;

                double z0 = 100 * Math.Sqrt(-2 * Math.Log(u1)) * Math.Cos(2 * Math.PI * u2);
                double z1 = 100 * Math.Sqrt(-2 * Math.Log(u1)) * Math.Sin(2 * Math.PI * u2);

                series.XValues.Add(z0);
                series.Values.Add(z1);
                series.InteractivityStyles.Add(i, new NInteractivityStyle("X: " + z0.ToString("0.00") + ", Y:" + z1.ToString("0.00")));
            }
        }
    }
}
