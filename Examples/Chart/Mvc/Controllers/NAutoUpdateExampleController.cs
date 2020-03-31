using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.ThinWeb;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Chart.Mvc
{
    public class NAutoUpdateExampleController : NChartExampleController
    {
        public NAutoUpdateExampleController()
        {
        }

        public override void Initialize(NThinChartControl control)
        {
			control.BackgroundStyle.FrameStyle.Visible = false;
            control.Panels.Clear();
			control.Width = 600;
			control.Height = 300;
			NStandardFrameStyle frame = control.BackgroundStyle.FrameStyle as NStandardFrameStyle;
            frame.InnerBorderWidth = new NLength(0);

            // set a chart title
            // set a chart title
            NLabel title = control.Labels.AddHeader("Auto Update");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

            // setup Line chart
            NCartesianChart chart = new NCartesianChart();
            control.Panels.Add(chart);
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
            GenerateNewData(control);

            ApplyLayoutTemplate(0, control, chart, title, null);

            // set auto update Callback
            control.AutoUpdateCallback = new NAutoUpdateCallback();

			// enable auto update
			control.ServerSettings.AutoUpdateInterval = 200;
            control.ServerSettings.EnableAutoUpdate = true;
        }

        [Serializable]
        class NAutoUpdateCallback : INAutoUpdateCallback
        {
            #region INAutoUpdateCallback Members

            public void OnAutoUpdate(NAspNetThinWebControl control)
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

            public void OnAutoUpdateStateChanged(NAspNetThinWebControl control)
            {
            }

            #endregion
        }
        /// <summary>
        /// Generates new random data
        /// </summary>
        /// <param name="control"></param>
        private void GenerateNewData(NThinChartControl control)
        {
            NLineSeries line = (NLineSeries)control.Charts[0].Series[0];

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
                    upward = m_Rand.NextDouble() > 0.5;
                }
            }
            if (upward)
            {
                // upward value change
                value = value + (2 + (m_Rand.NextDouble() * 10));
            }
            else
            {
                // downward value change
                value = value - (2 + (m_Rand.NextDouble() * 10));
            }

            return value;
        }
    }
}