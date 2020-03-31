using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm 
{
	public partial class NBackgroundDecoratorUC : NExampleUC
	{

		protected void Page_Load(object sender, EventArgs e)
		{
			// Clear the chart panels
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            NStandardFrameStyle controlFrameStyle = new NStandardFrameStyle();
            controlFrameStyle.OuterBorderWidth = new NLength(0);
            controlFrameStyle.InnerBorderWidth = new NLength(0);
            nChartControl1.BackgroundStyle.FrameStyle = controlFrameStyle;
			nChartControl1.Panels.Clear();

			// Create a background style to assign to the new panels
			NBackgroundStyle backroundStyle = new NBackgroundStyle();
			backroundStyle.FillStyle = new NColorFillStyle(Color.Transparent);
			NImageFrameStyle frameStyle = new NImageFrameStyle();
            frameStyle.BorderStyle = new NStrokeStyle(0, Color.White);
			//frameStyle.BorderStyle.Color = Color.Gray;
			frameStyle.BackgroundColor = Color.Transparent;
			frameStyle.Type = ImageFrameType.Raised;
			backroundStyle.FrameStyle = frameStyle;

            //Create a shadow style to assign to some items
            NShadowStyle shadowStyle = new NShadowStyle();
            shadowStyle.Type = ShadowType.LinearBlur;
            shadowStyle.Color = Color.FromArgb(80, 0, 0, 0);
            shadowStyle.FadeLength = new NLength(1);
            shadowStyle.Offset = new NPointL(2, 2);

			// Create the label background panel
			NBackgroundDecoratorPanel labelBackgroundPanel = new NBackgroundDecoratorPanel();
			labelBackgroundPanel.Size = new NSizeL(new NLength(0, NGraphicsUnit.Pixel), new NLength(15, NRelativeUnit.ParentPercentage));
			labelBackgroundPanel.DockMode = PanelDockMode.Top;
			labelBackgroundPanel.DockMargins = new NMarginsL(new NLength(3, NGraphicsUnit.Point), new NLength(3, NGraphicsUnit.Point), new NLength(3, NGraphicsUnit.Point), new NLength(3, NGraphicsUnit.Point));
			labelBackgroundPanel.BackgroundStyle = (NBackgroundStyle)backroundStyle.Clone();
			nChartControl1.Panels.Add(labelBackgroundPanel);

			// Create the legend background panel
			NBackgroundDecoratorPanel legendBackgroundPanel = new NBackgroundDecoratorPanel();
			legendBackgroundPanel.Size = new NSizeL(new NLength(30, NRelativeUnit.ParentPercentage), new NLength(0, NGraphicsUnit.Pixel));
			legendBackgroundPanel.DockMode = PanelDockMode.Right;
			legendBackgroundPanel.BackgroundStyle = (NBackgroundStyle)backroundStyle.Clone();
            legendBackgroundPanel.DockMargins = new NMarginsL(new NLength(3, NGraphicsUnit.Point), new NLength(3, NGraphicsUnit.Point), new NLength(3, NGraphicsUnit.Point), new NLength(3, NGraphicsUnit.Point));
			nChartControl1.Panels.Add(legendBackgroundPanel);

			// Create the chart background panel
			NBackgroundDecoratorPanel chartBackgroundPanel = new NBackgroundDecoratorPanel();
			chartBackgroundPanel.BackgroundStyle = (NBackgroundStyle)backroundStyle.Clone();
			chartBackgroundPanel.DockMode = PanelDockMode.Fill;
            chartBackgroundPanel.DockMargins = new NMarginsL(new NLength(3, NGraphicsUnit.Point), new NLength(3, NGraphicsUnit.Point), new NLength(3, NGraphicsUnit.Point), new NLength(3, NGraphicsUnit.Point));
			nChartControl1.Panels.Add(chartBackgroundPanel);

			// Create the header label and host it in the label background panel
			NLabel header = new NLabel("Background Decorator Panel");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle = (NShadowStyle)shadowStyle.Clone();
            header.TextStyle.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.LightBlue, Color.DarkSlateBlue);
			header.ContentAlignment = ContentAlignment.MiddleCenter;
			header.DockMode = PanelDockMode.Fill;
			header.BoundsMode = BoundsMode.Fit;
			header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
			header.DockMargins = new NMarginsL(frameStyle.LightEffectSize, frameStyle.LightEffectSize, frameStyle.LightEffectSize, frameStyle.LightEffectSize);
			labelBackgroundPanel.ChildPanels.Add(header);

			// Create the legend and host it in the legend background panel
			NLegend legend = new NLegend();
			legend.DockMode = PanelDockMode.Fill;
			legend.ContentAlignment = ContentAlignment.MiddleCenter;
			legend.DockMargins = new NMarginsL(frameStyle.LightEffectSize, frameStyle.LightEffectSize, frameStyle.LightEffectSize, frameStyle.LightEffectSize);
            legend.FillStyle = new NColorFillStyle(new NArgbColor(0, Color.White));
            NStrokeStyle borderStyle = new NStrokeStyle(0, Color.White);
            legend.HorizontalBorderStyle = borderStyle;
            legend.VerticalBorderStyle = borderStyle;
            legend.OuterBottomBorderStyle = borderStyle;
            legend.OuterLeftBorderStyle = borderStyle;
            legend.OuterRightBorderStyle = borderStyle;
            legend.OuterTopBorderStyle = borderStyle;
			legendBackgroundPanel.ChildPanels.Add(legend);

			// Create a cartesian chart and host it in the chart background panel
			NChart chart = new NCartesianChart();
			chartBackgroundPanel.ChildPanels.Add(chart);

			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.DisplayOnLegend = legend;
			chart.BoundsMode = BoundsMode.Stretch;
            chart.DockMode = PanelDockMode.Fill;
            chart.Margins = new NMarginsL(2, 10, 2, 2);

			// add bar and change bar color
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Name = "Bar Series";
			bar.FillStyle = new NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant2, Color.DarkRed, Color.Red);
			bar.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
            bar.ShadowStyle = (NShadowStyle)shadowStyle.Clone();
            bar.DataLabelStyle.Visible = false;
            
			bar.AddDataPoint(new NDataPoint(10, "Electronics", new NColorFillStyle(Color.Tomato)));
			bar.AddDataPoint(new NDataPoint(20, "Medical", new NColorFillStyle(Color.Orange)));
			bar.AddDataPoint(new NDataPoint(30, "Clothing", new NColorFillStyle(Color.Yellow)));
            bar.AddDataPoint(new NDataPoint(25, "Energy", new NColorFillStyle(Color.YellowGreen)));
			bar.AddDataPoint(new NDataPoint(29, "Financial", new NColorFillStyle(Color.ForestGreen)));
			bar.Legend.Mode = SeriesLegendMode.DataPoints;
            bar.Legend.TextStyle.ShadowStyle = (NShadowStyle)shadowStyle.Clone();

			// init form controls
			if (!IsPostBack)
			{
				DockTitleDropDownList.Items.Add("Top");
				DockTitleDropDownList.Items.Add("Bottom");
				DockTitleDropDownList.SelectedIndex = 0;

				DockLegendDropDownList.Items.Add("Left");
				DockLegendDropDownList.Items.Add("Right");
				DockLegendDropDownList.SelectedIndex = 1;
			}
			else
			{
				if (DockTitleDropDownList.SelectedIndex == 0)
				{
					labelBackgroundPanel.DockMode = PanelDockMode.Top;
				}
				else
				{
					labelBackgroundPanel.DockMode = PanelDockMode.Bottom;
				}

				if (DockLegendDropDownList.SelectedIndex == 0)
				{
					legendBackgroundPanel.DockMode = PanelDockMode.Left;
				}
				else
				{
					legendBackgroundPanel.DockMode = PanelDockMode.Right;
				}
			}
		}
	}
}
