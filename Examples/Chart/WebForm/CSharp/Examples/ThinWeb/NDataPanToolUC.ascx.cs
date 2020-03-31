using System;
using System.Drawing;
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

                // set a chart title
                NLabel title = NThinChartControl1.Labels.AddHeader("Data Pan Tool");
                title.TextStyle.TextFormat = GraphicsCore.TextFormat.XML;
                title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
                title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

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

                NThinChartControl1.Controller.SetActivePanel(chart);
            }

            // code common for load/postback
            NThinChartControl1.ServerSettings.EnableTiledZoom = UseTilingCheckBox.Checked;
            NChart chart1 = NThinChartControl1.Charts[0];

            chart1.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = ShowScrollbarsCheckBox.Checked;
            chart1.Axis(StandardAxis.PrimaryY).ScrollBar.Visible = ShowScrollbarsCheckBox.Checked;

            NDataPanTool dataPanTool = new NDataPanTool();

            if (UpdateRangeInTitleCheckBox.Checked)
            {
                dataPanTool.DataPanCallback = new MyDataPanCallback();
                NThinChartControl1.ScrollCallback = new MyScrollCallback();

                NThinChartControl1.RecalcLayout();
                NThinChartControl1.Labels[0].Text = FormatLabel(chart1.Axis(StandardAxis.PrimaryX).Scale.RulerRange, chart1.Axis(StandardAxis.PrimaryY).Scale.RulerRange);
            }
            else
            {
                dataPanTool.DataPanCallback = null;
                NThinChartControl1.ScrollCallback = null;
                NThinChartControl1.Labels[0].Text = "Data Pan Tool";
            }

            NThinChartControl1.Controller.Tools.Clear();
            NThinChartControl1.Controller.Tools.Add(dataPanTool);

            if (UpdateRangeInTitleCheckBox.Checked)
            {
                NThinChartControl1.Labels[0].Text = FormatLabel(chart1.Axis(StandardAxis.PrimaryX).Scale.RulerRange, chart1.Axis(StandardAxis.PrimaryY).Scale.RulerRange);
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
		/// <summary>
		/// 
		/// </summary>
		/// <param name="series"></param>
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
			}
		}

        [Serializable]
		public  class MyDataPanCallback : INDataPanCallback
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


    }
}
