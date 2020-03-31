using System;
using System.Drawing;
using Nevron.ThinWeb;
using Nevron.Chart;
using Nevron.Chart.ThinWeb;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NDataPanToolUC : NExampleUC
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!NThinChartControl1.Initialized)
            {
                NThinChartControl1.BackgroundStyle.FrameStyle.Visible = false;
                NThinChartControl1.BackgroundStyle.FillStyle = new NColorFillStyle(Color.FromArgb(244, 244, 244));

				// set a chart title
				NLabel title = NThinChartControl1.Labels.AddHeader("CSS Customization");
                title.TextStyle.TextFormat = GraphicsCore.TextFormat.XML;
                title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
                title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

                // no legend
                NThinChartControl1.Legends.Clear();

                // setup chart
                NChart chart = NThinChartControl1.Charts[0];
                chart.BoundsMode = BoundsMode.Stretch;

                chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = true;
                chart.Axis(StandardAxis.PrimaryY).ScrollBar.Visible = true;

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
                point.FillStyle = new NColorFillStyle(Color.FromArgb(160, DarkOrange));
                point.BorderStyle.Width = new NLength(0);
                point.Size = new NLength(2, NRelativeUnit.ParentPercentage);
                point.PointShape = PointShape.Ellipse;

                // instruct the point series to use custom X values
                point.UseXValues = true;

                // generate some random X values
                GenerateXYData(point);

                NThinChartControl1.RecalcLayout();
                chart.Axis(StandardAxis.PrimaryX).PagingView.ZoomIn(new NRange1DD(-0.5, 0.5), 0.0001);
                chart.Axis(StandardAxis.PrimaryY).PagingView.ZoomIn(new NRange1DD(-0.5, 0.5), 0.0001);

                // apply layout
                ApplyLayoutTemplate(0, NThinChartControl1, chart, title, null);

                NThinChartControl1.ServerSettings.EnableTiledZoom = true;
                NThinChartControl1.Controller.SetActivePanel(chart);

                // configure tools

                NThinChartControl1.Controller.Tools.Clear();
                NDataPanTool dataPanTool = new NDataPanTool();
                dataPanTool.Exclusive = true;
                dataPanTool.Enabled = true;
                NThinChartControl1.Controller.Tools.Add(dataPanTool);

                NDataZoomTool dataZoomTool = new NDataZoomTool();
                dataZoomTool.Exclusive = true;
                dataZoomTool.Enabled = false;
                NThinChartControl1.Controller.Tools.Add(dataZoomTool);

                NThinChartControl1.Controller.Tools.Add(new NTooltipTool());
                NThinChartControl1.Controller.Tools.Add(new NCursorTool());

                NThinChartControl1.Toolbar.Visible = true;

                NThinChartControl1.Toolbar.Items.Add(new NToolbarButton(new NToggleDataZoomToolAction()));
                NThinChartControl1.Toolbar.Items.Add(new NToolbarButton(new NToggleDataPanToolAction()));
                NThinChartControl1.Toolbar.Items.Add(new NToolbarSeparator());

                NThinChartControl1.Toolbar.Items.Add(new NToolbarButton(new NToggleTooltipToolAction()));
                NThinChartControl1.Toolbar.Items.Add(new NToolbarButton(new NToggleCursorToolAction()));

                // show loader images
                NThinChartControl1.ServerSettings.ShowLoaderImagesForAxisTiles = true;
                NThinChartControl1.ServerSettings.ShowLoaderImagesForPlotTiles = true;

                // customize the CSS
                NThinChartControl1.ServerSettings.Css.StatePressed = @"border: 1px solid rgb(255, 0, 0); background: rgb(252, 226, 203);";
                NThinChartControl1.ServerSettings.Css.StateHover = @"border: 1px solid rgb(178, 0, 0); background: rgb(255, 255, 255);";
                NThinChartControl1.ServerSettings.Css.StateDefault = @"margin: 0px; padding: 2px; border : 1px solid rgb(200, 200, 200); background: rgb(255, 255, 255);";
                NThinChartControl1.ServerSettings.Css.ToolbarSeparator = @"width: 10px; height: 22px; font-size : 0px; background-color: rgb(255, 255, 255);";
                NThinChartControl1.ServerSettings.Css.View = @"margin-left: 0px; margin-right: 0px; margin-top: 1px; margin-bottom: 0px; padding: 0px; border : 1px solid rgb(204, 204, 204);";
                NThinChartControl1.ServerSettings.Css.Scrollbar = @"margin : 0px; padding : 0px; border : 1px solid rgb(204, 204, 204); background: rgb(255, 255, 255);";

                // reflects view css margin + padding + border inflate
                NThinChartControl1.ServerSettings.Css.ViewInflate = new NSize(2, 3);

                // switch to JQuery 1.6.1
                NThinChartControl1.ServerSettings.JQuery.SourceType = JQuerySourceType.Url;
                NThinChartControl1.ServerSettings.JQuery.Url = @"http://ajax.googleapis.com/ajax/libs/jquery/1.6.1/jquery.min.js";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xRange"></param>
        /// <param name="yRange"></param>
        /// <returns></returns>
        private static string FormatLabel(NRange1DD xRange, NRange1DD yRange)
        {
            string valueFormat = "0.00";
            return "Data Pan Tool <br/><font size='12pt'>XRange[" + xRange.Begin.ToString(valueFormat) + ", " + xRange.End.ToString(valueFormat) + "], YRange[" + yRange.Begin.ToString(valueFormat) + ", " + yRange.End.ToString(valueFormat) + "]</font>";
        }

        [Serializable]
        public class MyDataPanCallback : INDataPanCallback
        {
			#region INDataPanCallback Members

			void INDataPanCallback.OnDataPan(NThinChartControl control, NCartesianChart chart, NAxis horzAxis, NAxis vertAxis)
			{
				control.RecalcLayout();

				NLabel label = control.Labels[0];
				label.Text = FormatLabel(horzAxis.Scale.RulerRange, vertAxis.Scale.RulerRange);

				control.Update();
			}

			#endregion
		}

        [Serializable]
        public class MyScrollCallback : INScrollbarCallback
        {
  			#region INScrollbarCallback Members

			void INScrollbarCallback.OnScroll(NThinChartControl control, NCartesianChart chart, NAxis axis)
			{
				control.RecalcLayout();

				NAxis horzAxis = chart.Axis(StandardAxis.PrimaryX);
				NAxis vertAxis = chart.Axis(StandardAxis.PrimaryY);

				NLabel label = control.Labels[0];
				label.Text = FormatLabel(horzAxis.Scale.RulerRange, vertAxis.Scale.RulerRange);

				control.Update();
			}

			#endregion
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

                double z0 = Math.Sqrt(-2 * Math.Log(u1)) * Math.Cos(2 * Math.PI * u2);
                double z1 = Math.Sqrt(-2 * Math.Log(u1)) * Math.Sin(2 * Math.PI * u2);

                series.XValues.Add(z0);
                series.Values.Add(z1);
                NInteractivityStyle interactivity = new NInteractivityStyle("X: " + z0.ToString("0.00") + ", Y:" + z1.ToString("0.00"), CursorType.Hand);
                series.InteractivityStyles.Add(i, interactivity);
            }
        }
    }
}
