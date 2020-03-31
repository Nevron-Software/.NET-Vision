using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.ThinWeb;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Mvc
{
    public class NDataPanToolExampleController : NChartExampleController
    {
        public NDataPanToolExampleController()
        {

        }

        public override void Initialize(NThinChartControl control)
        {
            control.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
            NLabel title = control.Labels.AddHeader("Data Pan Tool");
            title.TextStyle.TextFormat = GraphicsCore.TextFormat.XML;
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

            // no legend
            control.Legends.Clear();

            // setup chart
            NChart chart = control.Charts[0];
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
            scaleY.RoundToTickMax = false;
            scaleY.RoundToTickMin = false;

            // setup X axis
            NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
            scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Floor, ChartWallType.Back };
            scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
            scaleX.RoundToTickMax = false;
            scaleX.RoundToTickMin = false;

            chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

            // setup point series
            NPointSeries point = (NPointSeries)chart.Series.Add(SeriesType.Point);
            point.Name = "Point1";
            point.DataLabelStyle.Visible = false;
            point.FillStyle = new NColorFillStyle(Color.FromArgb(160, NevronColor1));
            point.BorderStyle.Width = new NLength(0);
            point.Size = new NLength(2, NRelativeUnit.ParentPercentage);
            point.PointShape = PointShape.Ellipse;

            // instruct the point series to use custom X values
            point.UseXValues = true;

            // generate some random X values
            GenerateXYData(point);

            control.RecalcLayout();
            chart.Axis(StandardAxis.PrimaryX).PagingView.ZoomIn(new NRange1DD(-0.5, 0.5), 0.0001);
            chart.Axis(StandardAxis.PrimaryY).PagingView.ZoomIn(new NRange1DD(-0.5, 0.5), 0.0001);

            // apply layout
            ApplyLayoutTemplate(0, control, chart, title, null);

            control.Controller.SetActivePanel(chart);
      
            control.ServerSettings.EnableTiledZoom = true;
            chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = true;
            chart.Axis(StandardAxis.PrimaryY).ScrollBar.Visible = true;

            NDataPanTool dataPanTool = new NDataPanTool();

            control.Controller.Tools.Clear();
            control.Controller.Tools.Add(dataPanTool);
        }

        private void GenerateXYData(NPointSeries series)
        {
            Random rand = new Random();
            for (int i = 0; i < 200; i++)
            {
                double u1 = rand.NextDouble();
                double u2 = rand.NextDouble();

                if (u1 == 0)
                    u1 += 0.0001;

                if (u2 == 0)
                    u2 += 0.0001;

                double z0 = Math.Sqrt(-2 * Math.Log(u1)) * Math.Cos(2 * Math.PI * u2);
                double z1 = Math.Sqrt(-2 * Math.Log(u1)) * Math.Sin(2 * Math.PI * u2);

                series.XValues.Add(z0);
                series.Values.Add(z1);
            }
        }
    }
}