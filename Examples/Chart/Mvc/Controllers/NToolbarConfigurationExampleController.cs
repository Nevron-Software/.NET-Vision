using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.ThinWeb;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Chart.Mvc
{
    public class NToolbarConfigurationExampleController : NChartExampleController
    {
        public NToolbarConfigurationExampleController()
        {
        }

        public override void Initialize(NThinChartControl control)
        {
            // enable jittering (full scene antialiasing)
            control.Settings.JitterMode = JitterMode.Enabled;
            control.ServerSettings.EnableTiledZoom = true;
            control.Panels.Clear();

            // apply background image border
            NImageFrameStyle frame = new NImageFrameStyle();
            frame.Type = ImageFrameType.Raised;
            frame.BackgroundColor = Color.White;
            frame.BorderStyle.Color = Color.Gainsboro;
            control.BackgroundStyle.FrameStyle = frame;
            control.BackgroundStyle.FillStyle = new NGradientFillStyle(Color.White, Color.GhostWhite);

            // set a chart title
            NLabel title = new NLabel("Welcome to Nevron Chart for .NET");
            control.Panels.Add(title);
            title.DockMode = PanelDockMode.Top;
            title.Padding = new NMarginsL(4, 6, 4, 6);
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

            // configure the legend
            NLegend legend = new NLegend();
            control.Panels.Add(legend);
            legend.DockMode = PanelDockMode.Right;
            legend.Padding = new NMarginsL(1, 1, 3, 3);
            legend.FillStyle.SetTransparencyPercent(50);
            legend.OuterBottomBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
            legend.OuterLeftBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
            legend.OuterRightBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
            legend.OuterTopBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
            legend.HorizontalBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
            legend.VerticalBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);

            // configure the chart
            NCartesianChart chart = new NCartesianChart();
            control.Panels.Add(chart);
            chart.Enable3D = true;
            chart.Fit3DAxisContent = true;
            chart.DisplayOnLegend = legend;
            chart.BoundsMode = BoundsMode.Fit;
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
            chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
            chart.DockMode = PanelDockMode.Fill;
            chart.Padding = new NMarginsL(
                new NLength(3, NRelativeUnit.ParentPercentage),
                new NLength(3, NRelativeUnit.ParentPercentage),
                new NLength(3, NRelativeUnit.ParentPercentage),
                new NLength(3, NRelativeUnit.ParentPercentage));
            chart.Wall(ChartWallType.Back).FillStyle = new NGradientFillStyle(Color.White, Color.Gray);

            // setup the X axis
            NAxis axisX = chart.Axis(StandardAxis.PrimaryX);
            axisX.ScrollBar.Visible = true;
            NOrdinalScaleConfigurator scaleX = (NOrdinalScaleConfigurator)axisX.ScaleConfigurator;
            scaleX.MajorTickMode = MajorTickMode.AutoMaxCount;
            scaleX.AutoLabels = false;

            // add interlaced stripe for the Y axis
            NAxis axisY = chart.Axis(StandardAxis.PrimaryY);
            axisY.ScrollBar.Visible = true;
            NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)axisY.ScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };
            scaleY.StripStyles.Add(stripStyle);

            // hide the depth axis
            chart.Axis(StandardAxis.Depth).Visible = false;

            // add a bar series and fill it with data
            NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            bar.Name = "Simple Bar Chart";
            bar.BarShape = BarShape.SmoothEdgeBar;
            bar.Legend.Mode = SeriesLegendMode.DataPoints;
            bar.Legend.TextStyle.FontStyle.EmSize = new NLength(8, NGraphicsUnit.Point);
            bar.DataLabelStyle.Visible = false;

            AddDataPoint(scaleX, bar, 16, "Spain", @"http://en.wikipedia.org/wiki/Spain");
            AddDataPoint(scaleX, bar, 42, "France", @"http://en.wikipedia.org/wiki/France");
            AddDataPoint(scaleX, bar, 56, "Germany", @"http://en.wikipedia.org/wiki/Germany");
            AddDataPoint(scaleX, bar, 23, "Italy", @"http://en.wikipedia.org/wiki/Italy");
            AddDataPoint(scaleX, bar, 47, "UK", @"http://en.wikipedia.org/wiki/UK");
            AddDataPoint(scaleX, bar, 38, "Sweden", @"http://en.wikipedia.org/wiki/Sweden");

            // add the index of the bar to highlight
            control.CustomData = 0;

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.NevronMultiColor);
            styleSheet.Apply(bar);

            // configure toolbar
            control.Toolbar.Visible = true;
            control.Controller.SetActivePanel(chart);

            control.AutoUpdateCallback = new NAutoUpdateCallback();

            //control.Controller.EnableAutoUpdate = true;
            NTrackballTool tbt = new NTrackballTool();
            tbt.Exclusive = true;
            tbt.Enabled = true;
            control.Controller.Tools.Add(tbt);

            // add a data zoom tool
            NDataZoomTool dataZoomTool = new NDataZoomTool();
            dataZoomTool.Exclusive = true;
            dataZoomTool.Enabled = false;
            control.Controller.Tools.Add(dataZoomTool);

            // add a data pan tool
            NDataPanTool dataPanTool = new NDataPanTool();
            dataPanTool.Exclusive = true;
            dataPanTool.Enabled = false;
            control.Controller.Tools.Add(dataPanTool);

            // add a tooltip tool
            control.Controller.Tools.Add(new NTooltipTool());
            // add a cursor change tool
            control.Controller.Tools.Add(new NCursorTool());
            // add a browser redirect tool
            control.Controller.Tools.Add(new NBrowserRedirectTool());

            control.Toolbar.Visible = true;
            control.Toolbar.Items.Add(new NToolbarButton(new NSaveStateAction()));
            control.Toolbar.Items.Add(new NToolbarButton(new NSaveImageAction("CheckPDF", new NPdfImageFormat(), false, new NSize(600, 600), 300)));
            control.Toolbar.Items.Add(new NToolbarButton(new NSaveImageAction("CheckPDF", new NSvgImageFormat(), false, new NSize(600, 600), 300)));
            control.Toolbar.Items.Add(new NToolbarButton(new NSaveImageAction("CheckPDF", new NXamlImageFormat(), false, new NSize(600, 600), 300)));
            control.Toolbar.Items.Add(new NToolbarButton(new NSaveImageAction("CheckPDF", new NBitmapImageFormat(), false, new NSize(600, 600), 300)));
			control.Toolbar.Items.Add(new NToolbarSeparator());

            control.Toolbar.Items.Add(new NToolbarButton(new NTogglePanelSelectorToolAction()));
            control.Toolbar.Items.Add(new NToolbarButton(new NToggleDataZoomToolAction()));
            control.Toolbar.Items.Add(new NToolbarButton(new NToggleDataPanToolAction()));
            control.Toolbar.Items.Add(new NToolbarButton(new NToggleTrackballToolAction()));
			control.Toolbar.Items.Add(new NToolbarSeparator());

            control.Toolbar.Items.Add(new NToolbarButton(new NToggleAutoUpdateAction()));
            control.Toolbar.Items.Add(new NToolbarButton(new NToggleChart3DAction()));
            control.Toolbar.Items.Add(new NToolbarButton(new NToggleChartLightingAction()));
			control.Toolbar.Items.Add(new NToolbarSeparator());

            control.Toolbar.Items.Add(new NToolbarButton(new NToggleTooltipToolAction()));
            control.Toolbar.Items.Add(new NToolbarButton(new NToggleBrowserRedirectToolAction()));
            control.Toolbar.Items.Add(new NToolbarButton(new NToggleCursorToolAction()));
        }

        [Serializable]
        class NAutoUpdateCallback : INAutoUpdateCallback
        {
            #region INAutoUpdateCallback Members

            public void OnAutoUpdate(NAspNetThinWebControl control)
            {
                NThinChartControl chartControl = (NThinChartControl)control;
                NBarSeries bar = (NBarSeries)chartControl.Charts[0].Series[0];

                int index = (int)chartControl.CustomData;

                for (int i = 0; i < bar.FillStyles.Count; i++)
                {
                    NColorFillStyle colorFill = bar.FillStyles[i] as NColorFillStyle;
                    if (i != index)
                    {
                        colorFill.Color = Color.FromArgb(60, colorFill.Color);
                    }
                    else
                    {
                        colorFill.Color = Color.FromArgb(255, colorFill.Color);
                    }
                }

                index++;

                if (index >= bar.FillStyles.Count)
                {
                    index = 0;
                }

                chartControl.CustomData = index;

                chartControl.UpdateView();
            }

            public void OnAutoUpdateStateChanged(NAspNetThinWebControl control)
            {
                // reset colors
                NThinChartControl chartControl = (NThinChartControl)control;
                NBarSeries bar = (NBarSeries)chartControl.Charts[0].Series[0];

                int index = (int)chartControl.CustomData;

                for (int i = 0; i < bar.FillStyles.Count; i++)
                {
                    NColorFillStyle colorFill = bar.FillStyles[i] as NColorFillStyle;
                    colorFill.Color = Color.FromArgb(255, colorFill.Color);
                }

                chartControl.CustomData = 0;
                chartControl.UpdateView();
            }

            #endregion
        }

        private void AddDataPoint(NOrdinalScaleConfigurator scale, NBarSeries bar, double value, string countryName, string url)
        {
            scale.Labels.Add(countryName);

            bar.Values.Add(value);
            bar.Labels.Add(countryName);

            NInteractivityStyle interactivityStyle = new NInteractivityStyle();

            interactivityStyle.Tooltip = new NTooltipAttribute("Click here to jump to [" + countryName + "]");
            interactivityStyle.Cursor = new NCursorAttribute(CursorType.Hand);
            interactivityStyle.UrlLink = new NUrlLinkAttribute(url, true);

            bar.InteractivityStyles.Add(bar.Values.Count - 1, interactivityStyle);
        }
    }
}