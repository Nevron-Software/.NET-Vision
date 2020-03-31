using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.Dom;
using Nevron.GraphicsCore;
using System;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NMultiSeriesLineUC : NExampleBaseUC
	{
		public NMultiSeriesLineUC()
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
				return "Multi Series Line";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "Multiseries line charts are displayed by several line series each occupying an individual depth space.";
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
			NLabel title = nChartControl1.Labels.AddHeader("Multi Series Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 60;
			chart.Height = 25;
			chart.Depth = 45;
			chart.Projection.Type = ProjectionType.Perspective;
			chart.Projection.Elevation = 28;
			chart.Projection.Rotation = -17;
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			// add interlaced stripe to the Y axis
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(System.Drawing.Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			stripStyle.Interlaced = true;
			((NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator).StripStyles.Add(stripStyle);

			// show the X axis gridlines
			NOrdinalScaleConfigurator ordinalScale = chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);

			// add the first line
			NLineSeries line1 = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line1.MultiLineMode = MultiLineMode.Series;
			line1.LineSegmentShape = LineSegmentShape.Tape;
			line1.DataLabelStyle.Visible = false;
			line1.DepthPercent = 50;
			line1.Name = "Line 1";

			// add the second line
			NLineSeries line2 = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line2.MultiLineMode = MultiLineMode.Series;
			line2.LineSegmentShape = LineSegmentShape.Tape;
			line2.DataLabelStyle.Visible = false;
			line2.DepthPercent = 50;
			line2.Name = "Line 2";

			// add the third line
			NLineSeries line3 = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line3.MultiLineMode = MultiLineMode.Series;
			line3.LineSegmentShape = LineSegmentShape.Tape;
			line3.DataLabelStyle.Visible = false;
			line3.DepthPercent = 50;
			line3.Name = "Line 3";

			line1.Values.FillRandom(Random, 7);
			line2.Values.FillRandom(Random, 7);
			line3.Values.FillRandom(Random, 7);

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);
		}
	}
}
