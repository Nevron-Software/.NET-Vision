using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using System;
using System.Drawing;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NXYScatterSmoothLineUC : NExampleBaseUC
	{
		public NXYScatterSmoothLineUC()
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
				return "XY Smooth Line";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a XY-scatter Smooth Line chart.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			NChart chart = nChartControl1.Charts[0];

			nChartControl1.Controller.Selection.Add(chart);
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = new NLabel("XY Smooth Line");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			chart.Enable3D = true;
			chart.Width = 70;
			chart.Height = 70;
			chart.Depth = 15;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			// configure axes
			chart.Axis(StandardAxis.Depth).Visible = false;

			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// add interlaced stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			// add the line
			NSmoothLineSeries line = (NSmoothLineSeries)chart.Series.Add(SeriesType.SmoothLine);
			line.Name = "Smooth Line";
			line.InflateMargins = true;
			line.Legend.Mode = SeriesLegendMode.Series;
			line.DataLabelStyle.Visible = false;
			line.MarkerStyle.Visible = true;
			line.MarkerStyle.PointShape = PointShape.Cylinder;
			line.MarkerStyle.AutoDepth = false;
			line.MarkerStyle.Width = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Height = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Depth = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			line.UseXValues = true;
			line.UseZValues = false;
			line.Use1DInterpolationForXYScatter = false;

			ChangeData();

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);
		}

		private void ChangeData()
		{
			NChart chart = nChartControl1.Charts[0];
			NSmoothLineSeries line = (NSmoothLineSeries)chart.Series[0];

			line.Values.Clear();
			line.XValues.Clear();
			line.ZValues.Clear();

			double r = 5;

			for (int i = 0; i < 10; i++)
			{
				double dY = r * Math.Sin(i) + Random.NextDouble();
				double dX = r * Math.Cos(i) + Random.NextDouble(); ;

				line.Values.Add(dY);
				line.XValues.Add(dX);

				r -= 0.3;
			}
		}

		private void ChangeDataButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			ChangeData();
			nChartControl1.Refresh();
		}

	}
}
