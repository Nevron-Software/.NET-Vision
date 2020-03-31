using Nevron.Chart;
using Nevron.Dom;
using Nevron.GraphicsCore;
using System.Drawing;
using System.Windows.Controls;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NStackedBarUC : NExampleBaseUC
	{
		private const int categoriesCount = 6;
		private NChart m_Chart;
		private NBarSeries m_Bar1;
		private NBarSeries m_Bar2;
		private NBarSeries m_Bar3;

		public NStackedBarUC()
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
				return "Stacked Bar";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates stacked bar chart. Two types of stacking are supported - Stacked and Stacked Percent." +
					" In the regular stack mode the bars are simply piled on top of each other. The stacked percent mode displays the contribution of each individual stack to the overall sum.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Stacked Bar Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.Width = 65;
			m_Chart.Height = 40;
			m_Chart.Axis(StandardAxis.Depth).Visible = false;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight);

			// add interlace stripe
			NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			// add the first bar
			m_Bar1 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar1.Name = "Bar1";
			m_Bar1.MultiBarMode = MultiBarMode.Series;

			// add the second bar
			m_Bar2 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar2.Name = "Bar2";
			m_Bar2.MultiBarMode = MultiBarMode.Stacked;

			// add the third bar
			m_Bar3 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar3.Name = "Bar3";
			m_Bar3.MultiBarMode = MultiBarMode.Stacked;

			// setup value formatting
			m_Bar1.Values.ValueFormatter = new NNumericValueFormatter("0.###");
			m_Bar2.Values.ValueFormatter = new NNumericValueFormatter("0.###");
			m_Bar3.Values.ValueFormatter = new NNumericValueFormatter("0.###");

			// position data labels in the center of the bars
			m_Bar1.DataLabelStyle.VertAlign = VertAlign.Center;
			m_Bar2.DataLabelStyle.VertAlign = VertAlign.Center;
			m_Bar3.DataLabelStyle.VertAlign = VertAlign.Center;

			m_Bar1.DataLabelStyle.ArrowLength = new NLength(0);
			m_Bar2.DataLabelStyle.ArrowLength = new NLength(0);
			m_Bar3.DataLabelStyle.ArrowLength = new NLength(0);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// init form controls
			InitLabelsCombo(FirstAreaDataLabelsComboBox);
			InitLabelsCombo(SecondAreaDataLabelsComboBox);
			InitLabelsCombo(ThirdAreaDataLabelsComboBox);

			StackModeComboBox.Items.Add("Stacked");
			StackModeComboBox.Items.Add("Stacked %");
			StackModeComboBox.SelectedIndex = 0;

			NExampleHelpers.FillComboWithEnumValues(BarShapeComboBox, typeof(BarShape));
			BarShapeComboBox.SelectedIndex = 0;

			PositiveDataButton_Click(null, null);
			ShowDataLabelsCheckBox_Checked(null, null);
		}

		private string GetFormatStringFromIndex(int index)
		{
			switch (index)
			{
				case 0:
					return "<value>";

				case 1:
					return "<total>";

				case 2:
					return "<cumulative>";

				case 3:
					return "<percent>";

				default:
					return "";
			}
		}

		private void StackModeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			switch (StackModeComboBox.SelectedIndex)
			{
				case 0:
					m_Bar2.MultiBarMode = MultiBarMode.Stacked;
					m_Bar3.MultiBarMode = MultiBarMode.Stacked;
					scale.LabelValueFormatter = new NNumericValueFormatter(NumericValueFormat.General);
					break;

				case 1:
					m_Bar2.MultiBarMode = MultiBarMode.StackedPercent;
					m_Bar3.MultiBarMode = MultiBarMode.StackedPercent;
					scale.LabelValueFormatter = new NNumericValueFormatter(NumericValueFormat.Percentage);
					break;
			}

			nChartControl1.Refresh();

		}

		private void BarShapeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			m_Bar1.BarShape = (BarShape)BarShapeComboBox.SelectedIndex;
			m_Bar2.BarShape = (BarShape)BarShapeComboBox.SelectedIndex;
			m_Bar3.BarShape = (BarShape)BarShapeComboBox.SelectedIndex;

			nChartControl1.Refresh();
		}

		private void PositiveDataButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			m_Bar1.Values.FillRandomRange(Random, categoriesCount, 10, 100);
			m_Bar2.Values.FillRandomRange(Random, categoriesCount, 10, 100);
			m_Bar3.Values.FillRandomRange(Random, categoriesCount, 10, 100);

			nChartControl1.Refresh();
		}

		private void PositiveAndNegativeDataButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			m_Bar1.Values.FillRandomRange(Random, categoriesCount, -100, 100);
			m_Bar2.Values.FillRandomRange(Random, categoriesCount, -100, 100);
			m_Bar3.Values.FillRandomRange(Random, categoriesCount, -100, 100);
			nChartControl1.Refresh();
		}

		private void ShowDataLabelsCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NSeries s0 = (NSeries)chart.Series[0];
			NSeries s1 = (NSeries)chart.Series[1];
			NSeries s2 = (NSeries)chart.Series[2];

			s0.DataLabelStyle.Visible = (bool)ShowDataLabelsCheckBox.IsChecked;
			s1.DataLabelStyle.Visible = (bool)ShowDataLabelsCheckBox.IsChecked;
			s2.DataLabelStyle.Visible = (bool)ShowDataLabelsCheckBox.IsChecked;

			FirstAreaDataLabelsComboBox.IsEnabled = (bool)ShowDataLabelsCheckBox.IsChecked;
			FirstAreaDataLabelsComboBox.IsEnabled = (bool)ShowDataLabelsCheckBox.IsChecked;
			FirstAreaDataLabelsComboBox.IsEnabled = (bool)ShowDataLabelsCheckBox.IsChecked;

			nChartControl1.Refresh();
		}

		private void FirstAreaDataLabelsComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			m_Bar1.DataLabelStyle.Format = GetFormatStringFromIndex(FirstAreaDataLabelsComboBox.SelectedIndex);
			nChartControl1.Refresh();
		}

		private void SecondAreaDataLabelsComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			m_Bar2.DataLabelStyle.Format = GetFormatStringFromIndex(SecondAreaDataLabelsComboBox.SelectedIndex);
			nChartControl1.Refresh();
		}

		private void ThirdAreaDataLabelsComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			m_Bar3.DataLabelStyle.Format = GetFormatStringFromIndex(ThirdAreaDataLabelsComboBox.SelectedIndex);
			nChartControl1.Refresh();
		}
		private void InitLabelsCombo(ComboBox comboBox)
		{
			comboBox.Items.Add("Value");
			comboBox.Items.Add("Total");
			comboBox.Items.Add("Cumulative");
			comboBox.Items.Add("Percent");
			comboBox.SelectedIndex = 0;
		}
	}
}
