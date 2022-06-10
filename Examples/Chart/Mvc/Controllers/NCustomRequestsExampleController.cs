using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.ThinWeb;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;
using Nevron.Chart.Functions;

namespace Nevron.Examples.Chart.Mvc
{
    public class NCustomRequestsExampleController : NChartExampleController
    {
        public NCustomRequestsExampleController()
        {
        }

        public override void Initialize(NThinChartControl control)
        {
            control.BackgroundStyle.FrameStyle.Visible = false;
            control.Panels.Clear();

            // Set manual ID so that it can be referenced in JavaScript
            control.StateId = "Chart1";

            // set a chart title
            NLabel header = new NLabel("Custom Requests");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.DockMode = PanelDockMode.Top;
            header.Location = new NPointL(new NLength(3, NRelativeUnit.ParentPercentage),
                                            new NLength(2, NRelativeUnit.ParentPercentage));
            control.Panels.Add(header);

            NCartesianChart chart = new NCartesianChart();
            InitChart(control, chart);

            // register a custom request callback
            control.CustomRequestCallback = new CustomRequestCallback();

            control.ServerSettings.EnableTiledZoom = true;

            // configure toolbar
            control.Toolbar.Visible = true;
            control.Controller.SetActivePanel(chart);

            // add a data zoom tool
            NDataZoomTool dataZoomTool = new NDataZoomTool();
            dataZoomTool.Exclusive = true;
            dataZoomTool.Enabled = false;
            dataZoomTool.AllowYAxisZoom = false;
            control.Controller.Tools.Add(dataZoomTool);

            // add a data pan tool
            NDataPanTool dataPanTool = new NDataPanTool();
            dataPanTool.Exclusive = true;
            dataPanTool.Enabled = true;
            control.Controller.Tools.Add(dataPanTool);

            // add a tooltip tool
            control.Controller.Tools.Add(new NTooltipTool());
            // add a cursor change tool
            control.Controller.Tools.Add(new NCursorTool());

            control.Toolbar.Visible = true;
            control.Toolbar.Items.Add(new NToolbarButton(new NSaveImageAction("Save as PNG", new NPngImageFormat(), true, new NSize(0, 0), 96)));
            control.Toolbar.Items.Add(new NToolbarSeparator());

            control.Toolbar.Items.Add(new NToolbarButton(new NToggleDataZoomToolAction()));
            control.Toolbar.Items.Add(new NToolbarButton(new NToggleDataPanToolAction()));
        }

        [Serializable]
        public class CustomRequestCallback : INCustomRequestCallback
        {
            #region INCustomRequestCallback Members

            void INCustomRequestCallback.OnCustomRequestCallback(NAspNetThinWebControl control, NRequestContext context, string argument)
            {
                NThinChartControl chartControl = (NThinChartControl)control;

                // make sure chart is recalculated
                chartControl.RecalcLayout();

                NChart chart = chartControl.Charts[0];
                NStockSeries stock = (NStockSeries)chart.Series[0];
                switch (argument)
                {
                    case "LastWeek":
                        {
                            DateTime dt = DateTime.FromOADate((double)stock.XValues[stock.XValues.Count - 1]);
                            chart.Axis(StandardAxis.PrimaryX).PagingView.ZoomIn(new NRange1DD(dt.AddDays(-7).ToOADate(), dt.ToOADate()), 0.00001);
                        }
                        break;
                    case "LastMonth":
                        {
                            DateTime dt = DateTime.FromOADate((double)stock.XValues[stock.XValues.Count - 1]);
                            chart.Axis(StandardAxis.PrimaryX).PagingView.ZoomIn(new NRange1DD(dt.AddMonths(-1).ToOADate(), dt.ToOADate()), 0.00001);
                        }
                        break;
                    case "LastYear":
                        chart.Axis(StandardAxis.PrimaryX).PagingView.Enabled = false;
                        break;
                }

                chartControl.Update();
            }

            #endregion
        }

        public void InitChart(NThinChartControl control, NCartesianChart chart)
        {
            // set layout related properties
            chart.BoundsMode = BoundsMode.Stretch;
            chart.DockMode = PanelDockMode.Fill;
            chart.Margins = new NMarginsL(10, 0, 10, 10);
            control.Panels.Add(chart);

            // add interlace stripes
            NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
            linearScale.StripStyles.Add(stripStyle);

            // show X axis zooming and scrolling
            chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = true;

            // apply work calendar to the X axis
            NWorkCalendar calendar = new NWorkCalendar();
            NWeekDayRule weekDayRule = new NWeekDayRule();
            WeekDayBit weekDays = WeekDayBit.None;
            weekDays |= WeekDayBit.Monday;
            weekDays |= WeekDayBit.Tuesday;
            weekDays |= WeekDayBit.Wednesday;
            weekDays |= WeekDayBit.Thursday;
            weekDays |= WeekDayBit.Friday;
            weekDayRule.WeekDays = weekDays;
            weekDayRule.Schedule.SetHourRange(0, 24, false);
            calendar.Rules.Add(weekDayRule);

            // apply calendar to scale
            NRangeTimelineScaleConfigurator timeline = new NRangeTimelineScaleConfigurator();
            timeline.FirstRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
            timeline.FirstRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(225, 225, 225));
            timeline.FirstRow.UseGridStyle = true;
            timeline.SecondRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
            timeline.SecondRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(215, 215, 215));
            timeline.SecondRow.UseGridStyle = true;
            timeline.ThirdRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
            timeline.ThirdRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(205, 205, 205));
            timeline.ThirdRow.UseGridStyle = true;

            timeline.EnableCalendar = false;
            timeline.Calendar = calendar;
            timeline.ThirdRow.EnableUnitSensitiveFormatting = false;

            chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = timeline;

            // generate data for this calendar
            AddData(chart, calendar);
        }

        private void AddData(NCartesianChart chart, NWorkCalendar calendar)
        {
            const int nNumberOfWeeks = 20;
            const int nWorkDaysInWeek = 5;
            const int nTotalWorkDays = nNumberOfWeeks * nWorkDaysInWeek;
            const int nHistoricalDays = 20;

            NLineSeries lineSMA = new NLineSeries();

            lineSMA.Name = "SMA(20)";
            lineSMA.DataLabelStyle.Visible = false;
            lineSMA.BorderStyle.Color = Color.DarkOrange;
            lineSMA.UseXValues = true;

            // create the stock series
            NStockSeries stock = new NStockSeries();

            chart.Series.Add(stock);
            stock.DisplayOnAxis(StandardAxis.PrimaryX, true);

            stock.Name = "Stock Data";
            stock.Legend.Mode = SeriesLegendMode.None;
            stock.DataLabelStyle.Visible = false;
            stock.CandleStyle = CandleStyle.Bar;
            stock.CandleWidth = new NLength(0.8f, NRelativeUnit.ParentPercentage);
            stock.InflateMargins = true;
            stock.UseXValues = true;
            stock.UpFillStyle = new NColorFillStyle(Color.Green);
            stock.UpStrokeStyle.Color = Color.Black;
            stock.DownFillStyle = new NColorFillStyle(Color.DarkOrange);
            stock.DownStrokeStyle.Color = Color.Black;
            stock.OpenValues.Name = "open";
            stock.CloseValues.Name = "close";
            stock.HighValues.Name = "high";
            stock.LowValues.Name = "low";

            int period = 20;

            // add the bollinger bands as high low area
            NHighLowSeries highLow = new NHighLowSeries();
            chart.Series.Add(highLow);
            highLow.DisplayOnAxis(StandardAxis.SecondaryX, true);

            highLow.Name = "BB(" + period.ToString() + ", 2)";
            highLow.DataLabelStyle.Visible = false;
            highLow.HighFillStyle = new NColorFillStyle(Color.FromArgb(80, 130, 134, 168));
            highLow.HighBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);

            highLow.UseXValues = true;

            // generate some stock data
            GenerateData(stock, calendar, 300, nTotalWorkDays + nHistoricalDays);

            // create a function calculator
            NFunctionCalculator fc = new NFunctionCalculator();
            fc.Arguments.Add(stock.CloseValues);

            // calculate the bollinger bands
            fc.Expression = "BOLLINGER(close;" + period.ToString() + "; 2)";
            highLow.HighValues = fc.Calculate();
            highLow.HighValues.Name = "BollingerUpper";

            fc.Expression = "BOLLINGER(close; " + period.ToString() + "; -2)";
            highLow.LowValues = fc.Calculate();
            highLow.LowValues.Name = "BollingerLower";
            highLow.XValues.InsertRange(0, stock.XValues);

            // calculate the simple moving average
            fc.Expression = "SMA(close; " + period.ToString() + ")";
            lineSMA.Values = fc.Calculate();
            lineSMA.XValues.InsertRange(0, stock.XValues);

            // remove first period from line SMA
            lineSMA.Values.RemoveRange(0, period);
            lineSMA.XValues.RemoveRange(0, period);

            // remove first period from high low
            highLow.XValues.RemoveRange(0, period);
            highLow.HighValues.RemoveRange(0, period);
            highLow.LowValues.RemoveRange(0, period);

            // remove first period from stock
            stock.OpenValues.RemoveRange(0, period);
            stock.HighValues.RemoveRange(0, period);
            stock.LowValues.RemoveRange(0, period);
            stock.CloseValues.RemoveRange(0, period);
            stock.XValues.RemoveRange(0, period);
        }

        private void GenerateData(NStockSeries s, NWorkCalendar calendar, double dPrevClose, int nCount)
        {
            DateTime now = DateTime.Now;
            NTimeline timeline = calendar.CreateTimeline(new NDateTimeRange(now, now + new TimeSpan(730, 0, 0, 0, 0)));
            double open, high, low, close;

            s.ClearDataPoints();

            Random random = new Random();

            for (int nIndex = 0; nIndex < nCount; nIndex++)
            {
                open = dPrevClose;

                if (dPrevClose < 25 || random.NextDouble() > 0.5)
                {
                    // upward price change
                    close = open + (2 + (random.NextDouble() * 20));
                    high = close + (random.NextDouble() * 10);
                    low = open - (random.NextDouble() * 10);
                }
                else
                {
                    // downward price change
                    close = open - (2 + (random.NextDouble() * 20));
                    high = open + (random.NextDouble() * 10);
                    low = close - (random.NextDouble() * 10);
                }

                if (low < 1)
                {
                    low = 1;
                }

                dPrevClose = close;

                s.OpenValues.Add(open);
                s.HighValues.Add(high);
                s.LowValues.Add(low);
                s.CloseValues.Add(close);
                s.XValues.Add(now.ToOADate());

                // advance to next working day
                now = timeline.AddTimeSpan(now, new NDateTimeSpan(1, NDateTimeUnit.Day));
            }
        }
    }
}