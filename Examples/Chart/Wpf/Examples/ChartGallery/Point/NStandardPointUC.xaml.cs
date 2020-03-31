using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NStandardPointUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NPointSeries m_Point;

		public NStandardPointUC()
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
				return "Point";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a standard point chart.\r\n" + 
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
			NLabel title = nChartControl1.Labels.AddHeader("2D Point Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			// add interlace stripe
			NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			// setup point series
			m_Point = (NPointSeries)m_Chart.Series.Add(SeriesType.Point);
			m_Point.Name = "Point Series";
			m_Point.InflateMargins = true;

			m_Point.AddDataPoint(new NDataPoint(23, "Item1"));
			m_Point.AddDataPoint(new NDataPoint(67, "Item2"));
			m_Point.AddDataPoint(new NDataPoint(78, "Item3"));
			m_Point.AddDataPoint(new NDataPoint(12, "Item4"));
			m_Point.AddDataPoint(new NDataPoint(56, "Item5"));
			m_Point.AddDataPoint(new NDataPoint(43, "Item6"));
			m_Point.AddDataPoint(new NDataPoint(37, "Item7"));
			m_Point.AddDataPoint(new NDataPoint(51, "Item8"));

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

			// init form controls
			NExampleHelpers.FillComboWithEnumValues(PointShapeComboBox, typeof(PointShape));
			PointShapeComboBox.SelectedIndex = 0;
			InflateMarginsCheckBox.IsChecked = true;
			LeftAxisRoundToTickCheckBox.IsChecked = true;
			DifferentColorsCheckBox.IsChecked = true;
			PointSizeScrollBar.Value = m_Point.Size.Value / 20.0f;

			DifferentColorsCheckBox_Checked(null, null);
		}

		private void PointShapeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			m_Point.PointShape = (PointShape)PointShapeComboBox.SelectedIndex;
			nChartControl1.Refresh();
		}

		private void PointSizeScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			m_Point.Size = new NLength((float)PointSizeScrollBar.Value * 20.0f, NRelativeUnit.ParentPercentage);
			nChartControl1.Refresh();

		}

		private void InflateMarginsCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			if ((bool)InflateMarginsCheckBox.IsChecked)
			{
				m_Point.InflateMargins = true;
			}
			else
			{
				m_Point.InflateMargins = false;
			}

			nChartControl1.Refresh();

		}

		private void LeftAxisRoundToTickCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NStandardScaleConfigurator standardScale = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			standardScale.RoundToTickMin = (bool)LeftAxisRoundToTickCheckBox.IsChecked;
			standardScale.RoundToTickMax = (bool)LeftAxisRoundToTickCheckBox.IsChecked;

			nChartControl1.Refresh();
		}

		private void DifferentColorsCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			if ((bool)DifferentColorsCheckBox.IsChecked)
			{
				m_Point.Legend.Mode = SeriesLegendMode.DataPoints;

				// apply style sheet
				NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
				styleSheet.Apply(nChartControl1.Document);
			}
			else
			{
				m_Point.Legend.Mode = SeriesLegendMode.Series;

				// apply style sheet
				NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
				styleSheet.Apply(nChartControl1.Document);
			}

			nChartControl1.Refresh();
		}
	}
}
