using System;
using System.Drawing;
using System.Web;
using Nevron.Chart;
using Nevron.Chart.ThinWeb;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Chart.WebForm
{
    public partial class NToolbarConfigurationUC : NExampleUC
	{
        protected void Page_Load(object sender, EventArgs e)
        {
			NThinChartControl1.StateId = "Chart1";

			if (!NThinChartControl1.Initialized)
            {
                // enable jittering (full scene antialiasing)
                NThinChartControl1.Settings.JitterMode = JitterMode.Enabled;
                NThinChartControl1.ServerSettings.EnableTiledZoom = true;
                NThinChartControl1.Panels.Clear();

                // apply background image border
                NImageFrameStyle frame = new NImageFrameStyle();
                frame.Type = ImageFrameType.Raised;
                frame.BackgroundColor = Color.White;
                frame.BorderStyle.Color = Color.Gainsboro;
                NThinChartControl1.BackgroundStyle.FrameStyle = frame;
                NThinChartControl1.BackgroundStyle.FillStyle = new NGradientFillStyle(Color.White, Color.GhostWhite);

                // set a chart title
                NLabel title = new NLabel("Toolbar Configuration");
                NThinChartControl1.Panels.Add(title);
                title.DockMode = PanelDockMode.Top;
                title.Padding = new NMarginsL(4, 6, 4, 6);
                title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
                title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

                // configure the legend
                NLegend legend = new NLegend();
                NThinChartControl1.Panels.Add(legend);
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
                NThinChartControl1.Panels.Add(chart);
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
                NThinChartControl1.CustomData = 0;

                // apply style sheet
                NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
                styleSheet.Apply(bar);

                // configure toolbar
                NThinChartControl1.Toolbar.Visible = true;
                NThinChartControl1.Controller.SetActivePanel(chart);                

                NThinChartControl1.AutoUpdateCallback = new NAutoUpdateCallback();

                //NThinChartControl1.Controller.EnableAutoUpdate = true;
                NTrackballTool tbt = new NTrackballTool();
                tbt.Exclusive = true;
                tbt.Enabled = true;
                NThinChartControl1.Controller.Tools.Add(tbt);

                // add a data zoom tool
                NDataZoomTool dataZoomTool = new NDataZoomTool();
                dataZoomTool.Exclusive = true;
                dataZoomTool.Enabled = false;
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
                // add a browser redirect tool
                NThinChartControl1.Controller.Tools.Add(new NBrowserRedirectTool());
                
                NThinChartControl1.Toolbar.Visible = true;
                NThinChartControl1.Toolbar.Items.Add(new NToolbarButton(new NSaveStateAction()));
                NThinChartControl1.Toolbar.Items.Add(new NToolbarButton(new NSaveImageAction("Save as PDF", new NPdfImageFormat(), true, new NSize(), 300)));
				NThinChartControl1.Toolbar.Items.Add(new NToolbarButton(new NSaveImageAction("Save as SVG", new NSvgImageFormat(), true, new NSize(), 96)));
				NThinChartControl1.Toolbar.Items.Add(new NToolbarButton(new NSaveImageAction("Save as XAML", new NXamlImageFormat(), true, new NSize(), 96)));

				NSaveImageAction sia = new NSaveImageAction("Bitmap.bmp", new NBitmapImageFormat(), true, new NSize(), 96);
				sia.Tooltip = "Print or Save as Bitmap";
				NThinChartControl1.Toolbar.Items.Add(new NToolbarButton(sia));
                NThinChartControl1.Toolbar.Items.Add(new NToolbarSeparator());

                NThinChartControl1.Toolbar.Items.Add(new NToolbarButton(new NTogglePanelSelectorToolAction()));
                NThinChartControl1.Toolbar.Items.Add(new NToolbarButton(new NToggleDataZoomToolAction()));
                NThinChartControl1.Toolbar.Items.Add(new NToolbarButton(new NToggleDataPanToolAction()));
                NThinChartControl1.Toolbar.Items.Add(new NToolbarButton(new NToggleTrackballToolAction()));
                NThinChartControl1.Toolbar.Items.Add(new NToolbarSeparator());

                NThinChartControl1.Toolbar.Items.Add(new NToolbarButton(new NToggleAutoUpdateAction()));
                NThinChartControl1.Toolbar.Items.Add(new NToolbarButton(new NToggleChart3DAction()));
                NThinChartControl1.Toolbar.Items.Add(new NToolbarButton(new NToggleChartLightingAction()));
                NThinChartControl1.Toolbar.Items.Add(new NToolbarSeparator());

                NThinChartControl1.Toolbar.Items.Add(new NToolbarButton(new NToggleTooltipToolAction()));
                NThinChartControl1.Toolbar.Items.Add(new NToolbarButton(new NToggleBrowserRedirectToolAction()));
                NThinChartControl1.Toolbar.Items.Add(new NToolbarButton(new NToggleCursorToolAction()));
				NThinChartControl1.Toolbar.Items.Add(new NToolbarSeparator());

				NThinChartControl1.Toolbar.Items.Add(new NToolbarButton(new ShowDataLabelsAction()));
				NThinChartControl1.Toolbar.Items.Add(new NToolbarButton(new HideDataLabelsAction()));

				NThinChartControl1.CustomRequestCallback = new CustomRequestCallback();
            }
        }
		/// <summary>
		/// A simple class showing how to show / hide data labels
		/// </summary>
		[Serializable]
		class ShowDataLabelsAction : NAction
		{
			public ShowDataLabelsAction()
				: base("Show Data Labels (Custom)")
			{
			}

			public override Bitmap GetImage()
			{
				string path = HttpContext.Current.Server.MapPath(@"~\Images\ShowDataLabelsButton.png");
				return (Bitmap)Bitmap.FromFile(path);
			}

			public override string GetScript()
			{
				NThinChartControl control = (NThinChartControl)this.m_Control;
				return "NClientNode.GetFromId(\'" + control.StateId  + "\').ExecuteCustomRequest(\"ShowDataLabels\");";
			}

			public override bool IsEnabled()
			{
				NThinChartControl control = (NThinChartControl)this.m_Control;
				NBarSeries bar = control.Charts[0].Series[0] as NBarSeries;
				return !bar.DataLabelStyle.Visible;
			}
		}
		/// <summary>
		/// A simple class showing how to show / hide data labels
		/// </summary>
		[Serializable]
		class HideDataLabelsAction : NAction
		{
			public HideDataLabelsAction()
				: base("Hide Data Labels (Custom)")
			{
			}

			public override Bitmap GetImage()
			{
				string path = HttpContext.Current.Server.MapPath(@"~\Images\HideDataLabelsButton.png");
				return (Bitmap)Bitmap.FromFile(path);
			}

			public override string GetScript()
			{
				NThinChartControl control = (NThinChartControl)this.m_Control;
				return "NClientNode.GetFromId(\'" + control.StateId + "\').ExecuteCustomRequest(\"HideDataLabels\");";
			}

			public override bool IsEnabled()
			{
				NThinChartControl control = (NThinChartControl)this.m_Control;
				NBarSeries bar = control.Charts[0].Series[0] as NBarSeries;
				return bar.DataLabelStyle.Visible;
			}
		}

		[Serializable]
		public class CustomRequestCallback : INCustomRequestCallback
		{
			#region INCustomRequestCallback Members

			void INCustomRequestCallback.OnCustomRequestCallback(NAspNetThinWebControl control, NRequestContext context, string argument)
			{
				NThinChartControl chartControl = (NThinChartControl)control;

				NChart chart = chartControl.Charts[0];
				NBarSeries bar = (NBarSeries)chart.Series[0];
				bar.DataLabelStyles.Clear();

				switch (argument)
				{
					case "ShowDataLabels":
						{
							bar.DataLabelStyle.Visible = true;
						}
						break;
					case "HideDataLabels":
						{
							bar.DataLabelStyle.Visible = false;
						}
						break;
				}

				// update the control and toolbar
				chartControl.Update();
			}

			#endregion
		}

        [Serializable]
		public class NAutoUpdateCallback : INAutoUpdateCallback
        {
			#region INAutoUpdateCallback Members

			void INAutoUpdateCallback.OnAutoUpdate(NAspNetThinWebControl control)
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

			void INAutoUpdateCallback.OnAutoUpdateStateChanged(NAspNetThinWebControl control)
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

        void AddDataPoint(NOrdinalScaleConfigurator scale, NBarSeries bar, double value, string countryName, string url)
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
