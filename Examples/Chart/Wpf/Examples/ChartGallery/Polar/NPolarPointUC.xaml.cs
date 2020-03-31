using System.Drawing;
using Nevron.Chart;
using Nevron.Dom;
using Nevron.GraphicsCore;
using System.Diagnostics;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NPolarPointUC : NExampleBaseUC
	{
		public NPolarPointUC()
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
				return "Polar Point";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return	"The example demonstrates a Polar Point chart\r\n" + 
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
			NLabel title = nChartControl1.Labels.AddHeader("Polar Point");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			NPolarChart chart = new NPolarChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(chart);
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			chart.DisplayOnLegend = nChartControl1.Legends[0];
			chart.Depth = 5;
			chart.Width = 70.0f;
			chart.Height = 70.0f;

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

			// add a const line
			NAxisConstLine line = chart.Axis(StandardAxis.Polar).ConstLines.Add();
			line.Value = 50;
			line.StrokeStyle.Color = Color.SlateBlue;
			line.StrokeStyle.Width = new NLength(1, NGraphicsUnit.Pixel);

			// create three polar point series
			NSeries s1 = CreatePolarPointSeries("Sample 1", PointShape.Sphere);
			NSeries s2 = CreatePolarPointSeries("Sample 2", PointShape.Bar);
			NSeries s3 = CreatePolarPointSeries("Sample 3", PointShape.Pyramid);

			// add the series to the chart
			chart.Series.Add(s1);
			chart.Series.Add(s2);
			chart.Series.Add(s3);

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

		private NSeries CreatePolarPointSeries(string name, PointShape shape)
		{
			NPolarPointSeries series = new NPolarPointSeries();
			series.Name = name;
			series.Angles.ValueFormatter = new NNumericValueFormatter("0.00");
			series.DataLabelStyle.Visible = false;
			series.DataLabelStyle.Format = "<value> - <angle_in_degrees>";
			series.PointShape = shape;
			series.Size = new NLength(1.5f, NRelativeUnit.ParentPercentage);

			// add data
			series.Values.FillRandomRange(Random, 10, 0, 100);
			series.Angles.FillRandomRange(Random, 10, 0, 360);

			return series;
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
