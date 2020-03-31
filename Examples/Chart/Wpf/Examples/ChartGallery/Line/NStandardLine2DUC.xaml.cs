using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NStandardLine2DUC : NExampleBaseUC
	{
		public NStandardLine2DUC()
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
				return "Line 2D";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a standard 2D line chart.\r\n" +
						"Use the controls on the right to modify commonly used properties";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("2D Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Axis(StandardAxis.Depth).Visible = false;

			// add interlaced stripe to the Y axis
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			stripStyle.Interlaced = true;
			((NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator).StripStyles.Add(stripStyle);

			NLineSeries line = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line.Name = "Line Series";
			line.InflateMargins = true;
			line.DataLabelStyle.Format = "<value>";
			line.MarkerStyle.Visible = true;
			line.MarkerStyle.PointShape = PointShape.Cylinder;
			line.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			line.ShadowStyle.Type = ShadowType.GaussianBlur;
			line.ShadowStyle.Offset = new NPointL(3, 3);
			line.ShadowStyle.FadeLength = new NLength(5);
			line.ShadowStyle.Color = Color.FromArgb(55, 0, 0, 0);
			line.Values.FillRandom(new Random(), 8);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			NExampleHelpers.FillComboWithEnumValues(LineStyleComboBox, typeof(LineSegmentShape));
			LineStyleComboBox.SelectedIndex = (int)line.LineSegmentShape;

			AxisRoundToTickCheckBox.IsChecked = true;
			InflateMarginsCheckBox.IsChecked = true;
		}

		private void LineStyleComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NLineSeries line = (NLineSeries)nChartControl1.Charts[0].Series[0];

			switch (LineStyleComboBox.SelectedIndex)
			{
				case 0: // simple line
					line.LineSegmentShape = LineSegmentShape.Line;
					line.DepthPercent = 0;
					break;

				case 1: // tape
					line.LineSegmentShape = LineSegmentShape.Tape;
					line.DepthPercent = 50;
					break;

				case 2: // tube
					line.LineSegmentShape = LineSegmentShape.Tube;
					line.DepthPercent = 10;
					break;

				case 3: // ellipsoid
					line.LineSegmentShape = LineSegmentShape.Ellipsoid;
					line.DepthPercent = 10;
					break;
			}

			nChartControl1.Refresh();

		}

		private void InflateMarginsCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];
			series.InflateMargins = (bool)InflateMarginsCheckBox.IsChecked;
			nChartControl1.Refresh();
		}

		private void AxisRoundToTickCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NStandardScaleConfigurator scaleConfigurator = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NStandardScaleConfigurator;

			if (scaleConfigurator != null)
			{
				scaleConfigurator.RoundToTickMin = (bool)AxisRoundToTickCheckBox.IsChecked;
				scaleConfigurator.RoundToTickMax = (bool)AxisRoundToTickCheckBox.IsChecked;

				nChartControl1.Refresh();
			}
		}
	}
}
