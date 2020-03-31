using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.Dom;
using Nevron.GraphicsCore;
using System;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NMultiSeriesAreaUC : NExampleBaseUC
	{
		public NMultiSeriesAreaUC()
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
				return "Multi Series Area";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
                return "Multiseries area charts are displayed by several area series each occupying an individual depth space.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Multi Series Area Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// apply predefined projection and lighting
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			chart.Width = 65.0f;
			chart.Height = 40.0f;
			chart.Depth = 40.0f;

			// add interlace stripe
			NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			// add the first area
			NAreaSeries area1 = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			area1.MultiAreaMode = MultiAreaMode.Series;
			area1.DataLabelStyle.Visible = false;
			area1.Name = "Area 1";
			area1.Values.FillRandomRange(Random, 15, 10, 40);

			// add the second area
			NAreaSeries area2 = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			area2.MultiAreaMode = MultiAreaMode.Series;
			area2.DataLabelStyle.Visible = false;
			area2.Name = "Area 2";
			area2.Values.FillRandomRange(Random, 15, 30, 60);

			// add the third area
			NAreaSeries area3 = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			area3.MultiAreaMode = MultiAreaMode.Series;
			area3.DataLabelStyle.Visible = false;
			area3.Name = "Area 3";
			area3.Values.FillRandomRange(Random, 15, 50, 80);

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);
		}
	}
}
