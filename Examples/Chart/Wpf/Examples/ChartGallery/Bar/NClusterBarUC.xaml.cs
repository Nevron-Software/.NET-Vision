using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.Dom;
using Nevron.GraphicsCore;
using System.Drawing;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NClusterBarUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBarSeries m_Bar1;
		private NBarSeries m_Bar2;

		public NClusterBarUC()
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
				return "Cluster Bar";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a clustered bar chart with controllable cluster width and gap. The separate bar series in a cluster can be scaled on different Y axes.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Cluster Bar Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHalf);
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			// add interlace stripe
			NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			// add a bar series
			m_Bar1 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar1.Name = "Bar1";
			m_Bar1.MultiBarMode = MultiBarMode.Series;
			m_Bar1.DataLabelStyle.Format = "<value>";
			m_Bar1.Values.ValueFormatter = new NNumericValueFormatter("0.###");

			// add another bar series
			m_Bar2 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar2.Name = "Bar2";
			m_Bar2.MultiBarMode = MultiBarMode.Clustered;
			m_Bar2.DataLabelStyle.Format = "<value>";
			m_Bar2.Values.ValueFormatter = new NNumericValueFormatter("0.###");

			// fill with random data
			m_Bar1.Values.FillRandomRange(Random, 5, 10, 100);
			m_Bar2.Values.FillRandomRange(Random, 5, 10, 500);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			NExampleHelpers.FillComboWithEnumValues(BarStyleComboBox, typeof(BarShape));
			BarStyleComboBox.SelectedIndex = 0;
		}

		private void BarStyleComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			m_Bar1.BarShape = (BarShape)BarStyleComboBox.SelectedIndex;
			m_Bar2.BarShape = (BarShape)BarStyleComboBox.SelectedIndex;

			nChartControl1.Refresh();
		}

		private void GapPercentScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			m_Bar1.GapPercent = (float)GapPercentScrollBar.Value * 100.0f;
			m_Bar2.GapPercent = (float)GapPercentScrollBar.Value * 100.0f;
			nChartControl1.Refresh();
		}

		private void WidthPercentScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			m_Bar1.WidthPercent = (float)WidthPercentScrollBar.Value * 100.0f;
			m_Bar2.WidthPercent = (float)WidthPercentScrollBar.Value * 100.0f;
			nChartControl1.Refresh();
		}

		private void ShowDataLabelsCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			if (ScaleSecondaryClusterCheckBox.IsChecked == true)
			{
				m_Bar2.DisplayOnAxis(StandardAxis.PrimaryY, false);
				m_Bar2.DisplayOnAxis(StandardAxis.SecondaryY, true);

				m_Chart.Axis(StandardAxis.SecondaryY).Visible = true;
			}
			else
			{
				m_Bar2.DisplayOnAxis(StandardAxis.PrimaryY, true);
				m_Bar2.DisplayOnAxis(StandardAxis.SecondaryY, false);

				m_Chart.Axis(StandardAxis.SecondaryY).Visible = false;
			}

			nChartControl1.Refresh();
		}

		private void PositiveDataButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			m_Bar1.Values.FillRandomRange(Random, 5, 10, 100);
			m_Bar2.Values.FillRandomRange(Random, 5, 10, 500);
			nChartControl1.Refresh();
		}

		private void PositiveAndNegativeDataButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			m_Bar1.Values.FillRandomRange(Random, 5, -100, 100);
			m_Bar2.Values.FillRandomRange(Random, 5, -100, 100);
			nChartControl1.Refresh();
		}

		private void Enable3DCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			m_Chart.Enable3D = (bool)Enable3DCheckBox.IsChecked;
			if (m_Chart.Enable3D)
			{
				m_Chart.BoundsMode = GraphicsCore.BoundsMode.Fit;
			}
			else
			{
				m_Chart.BoundsMode = GraphicsCore.BoundsMode.Stretch;
			}

			nChartControl1.Refresh();
		}

/*		private void Bar1FillStyle_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_Bar1.FillStyle, out fillStyleResult))
			{
				m_Bar1.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void Bar2FillStyle_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_Bar2.FillStyle, out fillStyleResult))
			{
				m_Bar2.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
*/
	}
}
