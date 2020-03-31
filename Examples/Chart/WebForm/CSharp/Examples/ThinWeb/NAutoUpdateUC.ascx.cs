using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.ThinWeb;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Chart.WebForm
{
    public partial class NAutoUpdateUC : NExampleUC
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!NThinChartControl1.Initialized)
            {
                NThinChartControl1.BackgroundStyle.FrameStyle.Visible = false;
                NThinChartControl1.Panels.Clear();
                NStandardFrameStyle frame = NThinChartControl1.BackgroundStyle.FrameStyle as NStandardFrameStyle;
                frame.InnerBorderWidth = new NLength(0);

                // set a chart title
                // set a chart title
                NLabel title = NThinChartControl1.Labels.AddHeader("Auto Update");
                title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
                title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

                // setup Line chart
                NCartesianChart chart = new NCartesianChart();
                NThinChartControl1.Panels.Add(chart);
                NRangeTimelineScaleConfigurator rangeTimeline = new NRangeTimelineScaleConfigurator();
                rangeTimeline.FirstRow.MinTickDistance = new NLength(40);
                chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = rangeTimeline;

                // setup Y axis
                NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
                scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

                // add interlace stripe
                NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
                stripStyle.Interlaced = true;
                stripStyle.SetShowAtWall(ChartWallType.Back, true);
                stripStyle.SetShowAtWall(ChartWallType.Left, true);
                scaleY.StripStyles.Add(stripStyle);

                NLineSeries line = new NLineSeries();
                line.UseXValues = true;
                line.DataLabelStyle.Visible = false;
                line.BorderStyle.Color = Color.DarkOrange;
                line.BorderStyle.Width = new NLength(2);
                chart.Series.Add(line);

                // generate some data
                GenerateNewData();

                NThinChartControl1.AutoUpdateCallback = new NAutoUpdateCallback();
                ApplyLayoutTemplate(0, NThinChartControl1, chart, title, null);

                NThinChartControl1.ServerSettings.EnableTiledZoom = true;
                NThinChartControl1.ServerSettings.AutoUpdateInterval = 200;
                NThinChartControl1.ServerSettings.EnableAutoUpdate = true;
            }

            if (!IsPostBack)
            {
                AutoUpdateIntervalTextBox.Text = NThinChartControl1.ServerSettings.AutoUpdateInterval.ToString();
            }
        }

        [Serializable]
        public class NAutoUpdateCallback : INAutoUpdateCallback
        {
			#region INAutoUpdateCallback Members

			void INAutoUpdateCallback.OnAutoUpdate(NAspNetThinWebControl control)
			{
				NThinChartControl chartControl = (NThinChartControl)control;
				NLineSeries line = (NLineSeries)chartControl.Charts[0].Series[0];

				if (line == null)
					return;

				if (line.Values.Count == 0)
					return;

				double dPrev = (double)line.Values[line.Values.Count - 1];

				double yValue = GenerateDataPoint(dPrev, new NRange1DD(50, 350));

				line.Values.RemoveAt(0);
				line.XValues.RemoveAt(0);

				line.Values.Add(yValue);
				line.XValues.Add(DateTime.Now.ToOADate());

				chartControl.UpdateView();
			}

			void INAutoUpdateCallback.OnAutoUpdateStateChanged(NAspNetThinWebControl control)
			{
				throw new NotImplementedException();
			}

			#endregion
		}
        /// <summary>
        /// Generates new random data
        /// </summary>
        private void GenerateNewData()
        {
            NLineSeries line = (NLineSeries)NThinChartControl1.Charts[0].Series[0];

            int count = 100;
            DateTime dateTime = DateTime.Now.AddMilliseconds(-count * 50);
            double prevValue = 100;
            double value;

            for (int i = 0; i < count; i++)
            {
                value = GenerateDataPoint(prevValue, new NRange1DD(50, 350));
                dateTime = dateTime.AddMilliseconds(50);

                line.Values.Add(value);
                line.XValues.Add(dateTime.ToOADate());

                prevValue = value;
            }
        }
        /// <summary>
        /// Generates a new data point
        /// </summary>
        /// <param name="dPrev"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        protected static double GenerateDataPoint(double dPrev, NRange1DD range)
        {
            double value = dPrev;
            bool upward = false;
            if (dPrev <= range.Begin)
            {
                upward = true;
            }
            else
            {
                if (dPrev >= range.End)
                {
                    upward = false;
                }
                else
                {
                    upward = WebExamplesUtilities.rand.NextDouble() > 0.5;
                }
            }
            if (upward)
            {
                // upward value change
                value = value + (2 + (WebExamplesUtilities.rand.NextDouble() * 10));
            }
            else
            {
                // downward value change
                value = value - (2 + (WebExamplesUtilities.rand.NextDouble() * 10));
            }

            return value;
        }

        protected void ToggleAutoUpdateButton_Click(object sender, EventArgs e)
        {
            if (ToggleAutoUpdateButton.Text.StartsWith("Stop"))
            {
                NThinChartControl1.ServerSettings.EnableAutoUpdate = false;
                ToggleAutoUpdateButton.Text = "Start Auto Update";
            }
            else
            {
                NThinChartControl1.ServerSettings.EnableAutoUpdate = true;
                ToggleAutoUpdateButton.Text = "Stop Auto Update";
            }
        }
        protected void SetAutoUpdateIntervalButton_Click(object sender, EventArgs e)
        {
            try
            {
                int autoUpdateInterval = Int32.Parse(AutoUpdateIntervalTextBox.Text);
                NThinChartControl1.ServerSettings.AutoUpdateInterval = autoUpdateInterval;
            }
            catch (Exception)
            {
            }
        }
    }
}
