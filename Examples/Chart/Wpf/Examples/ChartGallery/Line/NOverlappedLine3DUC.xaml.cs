using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using System;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NOverlappedLine3DUC : NExampleBaseUC
	{
		public NOverlappedLine3DUC()
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
				return "Overlapped Line";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates an overlapped line chart. Overlapped lines occupy the same chart depth space.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Overlapped Line Chart");
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
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(System.Drawing.Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			stripStyle.Interlaced = true;
			((NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator).StripStyles.Add(stripStyle);

			NLineSeries line1 = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line1.Name = "Line 1";
			line1.LineSegmentShape = LineSegmentShape.Tape;
			line1.DataLabelStyle.Visible = false;
			line1.MarkerStyle.PointShape = PointShape.Cylinder;
			line1.MarkerStyle.Visible = true;
			line1.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			line1.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			line1.DepthPercent = 50;
			
			NLineSeries line2 = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line2.Name = "Line 2";
			line2.LineSegmentShape = LineSegmentShape.Tape;
			line2.MultiLineMode = MultiLineMode.Overlapped;
			line2.DataLabelStyle.Visible = false;
			line2.MarkerStyle.PointShape = PointShape.Cylinder;
			line2.MarkerStyle.Visible = true;
			line2.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			line2.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			line2.DepthPercent = 50;

			line1.Values.Clear();
			line2.Values.Clear();

			for (int i = 0; i < 9; i++)
			{
				line1.Values.Add(Math.Sin(0.6 * i) + 0.5 * Random.NextDouble());
				line2.Values.Add(Math.Cos(0.6 * i) + 0.5 * Random.NextDouble());
			}

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
