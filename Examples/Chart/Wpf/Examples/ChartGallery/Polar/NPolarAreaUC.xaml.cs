using System;
using System.Diagnostics;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NPolarAreaUC : NExampleBaseUC
	{
		public NPolarAreaUC()
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
				return "Polar Area";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "The example demonstrates a Polar Area chart\r\n" + 
						"Use the controls on the right to modify some commonly used properties.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Polar Area");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			NPolarChart chart = new NPolarChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(chart);
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			chart.DisplayOnLegend = nChartControl1.Legends[0];
			chart.Width = 70.0f;
			chart.Height = 70.0f;
			chart.Depth = 5;

			// setup polar axis
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.Polar).ScaleConfigurator;
			linearScale.RoundToTickMax = true;
			linearScale.RoundToTickMin = true;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, true);

			NScaleStripStyle strip = new NScaleStripStyle();
			strip.FillStyle = new NColorFillStyle(Color.FromArgb(125, Color.Beige));
			strip.Interlaced = true;
			strip.SetShowAtWall(ChartWallType.Polar, true);
			linearScale.StripStyles.Add(strip);

			// setup polar angle axis
			NAngularScaleConfigurator angularScale = (NAngularScaleConfigurator)chart.Axis(StandardAxis.PolarAngle).ScaleConfigurator;
			angularScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, true);
			strip = new NScaleStripStyle();
			strip.FillStyle = new NColorFillStyle(Color.FromArgb(125, 192, 192, 192));
			strip.Interlaced = true;
			strip.SetShowAtWall(ChartWallType.Polar, true);
			angularScale.StripStyles.Add(strip);

			// polar area series 1
			NPolarAreaSeries series1 = new NPolarAreaSeries();
			chart.Series.Add(series1);
			series1.Name = "Theoretical";
			series1.DataLabelStyle.Visible = false;
			GenerateData(series1, 100, 15.0);

			// polar area series 2
			NPolarAreaSeries series2 = new NPolarAreaSeries();
			chart.Series.Add(series2);
			series2.Name = "Experimental";
			series2.DataLabelStyle.Visible = false;
			GenerateData(series2, 100, 10.0);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// init form controls
			RadianAngleStepComboBox.Items.Add("15");
			RadianAngleStepComboBox.Items.Add("30");
			RadianAngleStepComboBox.Items.Add("45");
			RadianAngleStepComboBox.Items.Add("90");
			RadianAngleStepComboBox.SelectedIndex = 0;
			BeginAngleScrollBar.Value = 0.0f;

		}

		private void GenerateData(NPolarSeries series, int count, double scale)
		{
			series.Values.Clear();
			series.Angles.Clear();

			double angleStep = 2 * Math.PI / count;

			for (int i = 0; i < count; i++)
			{
				double angle = i * angleStep;
				double c1 = 1.0 * Math.Sin(angle * 3);
				double c2 = 0.3 * Math.Sin(angle * 1.5);
				double c3 = 0.05 * Math.Cos(angle * 26);
				double c4 = 0.05 * (0.5 - Random.NextDouble());
				double value = scale * (Math.Abs(c1 + c2 + c3) + c4);

				if (value < 0)
					value = 0;

				series.Values.Add(value);
				series.Angles.Add(angle * 180 / Math.PI);
			}
		}

		private void BeginAngleScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			NPolarChart polarChart = nChartControl1.Charts[0] as NPolarChart;
			if (polarChart != null)
			{
				polarChart.BeginAngle = (float)BeginAngleScrollBar.Value * 360.0f;
				nChartControl1.Refresh();
			}
		}

		private void RadianAngleStepComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NPolarChart polarChart = nChartControl1.Charts[0] as NPolarChart;
			if (polarChart == null)
				return;

			NAngularScaleConfigurator angleScale = polarChart.Axis(StandardAxis.PolarAngle).ScaleConfigurator as NAngularScaleConfigurator;

			switch (RadianAngleStepComboBox.SelectedIndex)
			{
				case 0:
					angleScale.MajorTickMode = MajorTickMode.CustomStep;
					angleScale.CustomStep = new NAngle(15, NAngleUnit.Degree);
					break;

				case 1:
					angleScale.MajorTickMode = MajorTickMode.CustomStep;
					angleScale.CustomStep = new NAngle(30, NAngleUnit.Degree);
					break;

				case 2:
					angleScale.MajorTickMode = MajorTickMode.CustomStep;
					angleScale.CustomStep = new NAngle(45, NAngleUnit.Degree);
					break;

				case 3:
					angleScale.MajorTickMode = MajorTickMode.CustomStep;
					angleScale.CustomStep = new NAngle(90, NAngleUnit.Degree);
					break;

				default:
					Debug.Assert(false);
					break;
			}

			nChartControl1.Refresh();
		}
	}
}
