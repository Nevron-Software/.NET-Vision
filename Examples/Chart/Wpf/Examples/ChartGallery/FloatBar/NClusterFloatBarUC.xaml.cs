using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;
using System;
using Nevron.Dom;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NClusterFloatBarUC : NExampleBaseUC
	{
		public NClusterFloatBarUC()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Gets the title of this example
		/// </summary>
		public override string Title
		{
			get
			{
				return "Cluster Float Bar";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a Float Bar series clustered with a Bar series.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{

			// set a chart title
			NLabel title = new NLabel("Cluster Float Bar");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 65;
			chart.Height = 40;
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			// add interlaced stripe to the Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			stripStyle.Interlaced = true;
			scaleY.StripStyles.Add(stripStyle);

			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

			// setup the bar series
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Name = "Bar series";
			bar.DataLabelStyle.Visible = false;
			bar.Values.FillRandomRange(Random, 8, 7, 15);

			// setup the floatbar series
			NFloatBarSeries floatbar = (NFloatBarSeries)chart.Series.Add(SeriesType.FloatBar);
			floatbar.MultiFloatBarMode = MultiFloatBarMode.Clustered;
			floatbar.Name = "Floatbar series";
			floatbar.DataLabelStyle.Visible = false;

			floatbar.AddDataPoint(new NFloatBarDataPoint(3.1, 5.2));
			floatbar.AddDataPoint(new NFloatBarDataPoint(4.0, 6.1));
			floatbar.AddDataPoint(new NFloatBarDataPoint(2.0, 6.4));
			floatbar.AddDataPoint(new NFloatBarDataPoint(5.3, 7.3));
			floatbar.AddDataPoint(new NFloatBarDataPoint(3.8, 8.4));
			floatbar.AddDataPoint(new NFloatBarDataPoint(4.0, 7.7));
			floatbar.AddDataPoint(new NFloatBarDataPoint(2.9, 4.1));
			floatbar.AddDataPoint(new NFloatBarDataPoint(5.0, 7.2));

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());
		}
	}
}
