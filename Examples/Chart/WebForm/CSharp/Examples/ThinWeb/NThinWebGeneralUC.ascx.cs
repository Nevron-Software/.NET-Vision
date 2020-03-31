using System;
using System.Drawing;
using System.Text;
using Nevron.Chart;
using Nevron.Chart.Functions;
using Nevron.Chart.ThinWeb;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NThinWebGeneralUC : NExampleUC
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!NThinChartControl1.Initialized)
            {
                // enable jittering (full scene antialiasing)
                NThinChartControl1.Settings.JitterMode = JitterMode.Enabled;

                NThinChartControl1.BackgroundStyle.FrameStyle.Visible = false;
                NThinChartControl1.Panels.Clear();

                // add header
                NLabel header = NThinChartControl1.Labels.AddHeader("General Thin Web Functionality");
                header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
                header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
                header.Margins = new NMarginsL(10, 10, 10, 10);
                header.DockMode = PanelDockMode.Top;

                NChart chart = new NCartesianChart();
                NThinChartControl1.Panels.Add(chart);
                chart.BoundsMode = BoundsMode.Stretch;
                chart.DockMode = PanelDockMode.Fill;
                chart.Margins = new NMarginsL(10, 0, 10, 10);

                // setup X axis
                NRangeTimelineScaleConfigurator scaleX = new NRangeTimelineScaleConfigurator();
                // set configurator
                chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

                // enable the scrollbar
                chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = true; 

                // setup primary Y axis
                NAxis axis = chart.Axis(StandardAxis.PrimaryY);
                NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)axis.ScaleConfigurator;

                // add interlace stripe
                NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
                stripStyle.Interlaced = true;
                stripStyle.SetShowAtWall(ChartWallType.Back, true);
                stripStyle.SetShowAtWall(ChartWallType.Left, true);
                scaleY.StripStyles.Add(stripStyle);

                // line series for the function
                NLineSeries line = (NLineSeries)chart.Series.Add(SeriesType.Line);
                line.DataLabelStyle.Visible = false;
                line.BorderStyle.Color = Color.Red;
                line.BorderStyle.Width = new NLength(2, NGraphicsUnit.Pixel);
                line.UseXValues = true;

                Color customColor = Color.FromArgb(100, 100, 150);

                // setup the stock series
                NStockSeries stock = (NStockSeries)chart.Series.Add(SeriesType.Stock);
                stock.DataLabelStyle.Visible = false;
                stock.CandleStyle = CandleStyle.Bar;
                stock.CandleWidth = new NLength(1, NRelativeUnit.ParentPercentage);
                stock.HighLowStrokeStyle.Color = customColor;
                stock.UpStrokeStyle.Color = customColor;
                stock.DownStrokeStyle.Color = customColor;
                stock.UpFillStyle = new NColorFillStyle(Color.White);
                stock.DownFillStyle = new NColorFillStyle(customColor);
                stock.OpenValues.Name = "open";
                stock.HighValues.Name = "high";
                stock.LowValues.Name = "low";
                stock.CloseValues.Name = "close";
                stock.UseXValues = true;

                GenerateData(stock);
                NFunctionCalculator functionCalculator = new NFunctionCalculator();
                BuildExpression(functionCalculator, stock, line);

                line.XValues = (NDataSeriesDouble)stock.XValues.Clone();
                line.Values = functionCalculator.Calculate();

                NThinChartControl1.ServerSettings.EnableTiledZoom = true;

                // configure toolbar
                NThinChartControl1.Toolbar.Visible = true;
                NThinChartControl1.Controller.SetActivePanel(chart);

                // add a data zoom tool
                NDataZoomTool dataZoomTool = new NDataZoomTool();
                dataZoomTool.Exclusive = true;
                dataZoomTool.Enabled = true;
                dataZoomTool.AllowYAxisZoom = false;
                NThinChartControl1.Controller.Tools.Add(dataZoomTool);

                // add a data pan tool
                NDataPanTool dataPanTool = new NDataPanTool();
                dataPanTool.Exclusive = true;
                dataPanTool.Enabled = false;
                NThinChartControl1.Controller.Tools.Add(dataPanTool);

                // add a tooltip tool
                NThinChartControl1.Controller.Tools.Add(new NTooltipTool());
                // add a cursor change tool
                NThinChartControl1.Controller.Tools.Add(new NCursorTool());
                
                NThinChartControl1.Toolbar.Visible = true;
                NThinChartControl1.Toolbar.Items.Add(new NToolbarButton(new NSaveImageAction("Save as PNG", new NPngImageFormat(), true, new NSize(0, 0), 96)));
                NThinChartControl1.Toolbar.Items.Add(new NToolbarSeparator());

                NThinChartControl1.Toolbar.Items.Add(new NToolbarButton(new NToggleDataZoomToolAction()));
                NThinChartControl1.Toolbar.Items.Add(new NToolbarButton(new NToggleDataPanToolAction()));
            }
        }

        private void GenerateData(NStockSeries stock)
		{
			const double initialPrice = 100;
			const int numDataPoints = 200;

			WebExamplesUtilities.GenerateOHLCData(stock, initialPrice, numDataPoints);
			FillStockDates(stock, numDataPoints, new DateTime(2010, 1, 11));
		}


		private void BuildExpression(NFunctionCalculator nFunction, NStockSeries stock, NSeries line)
		{
            NDataSeriesDouble arg;
			StringBuilder sb = new StringBuilder();
			int nPeriod = 10;

			arg = stock.OpenValues;
            arg = stock.OpenValues;

				sb.AppendFormat("SMA({0}; {1})", arg.Name, nPeriod);
					line.Name = "Simple Moving Average";

			nFunction.Arguments.Clear();
			nFunction.Arguments.Add(arg);
			nFunction.Expression = sb.ToString();
    	}
    }
}
