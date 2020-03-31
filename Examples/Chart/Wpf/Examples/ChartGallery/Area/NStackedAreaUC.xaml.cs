using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.Dom;
using Nevron.GraphicsCore;
using System.Drawing;
using System.Windows.Controls;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NStackedAreaUC : NExampleBaseUC
	{
		private const int categoriesCount = 10;

		public NStackedAreaUC()
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
				return "Stacked Area";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates stacked area chart.\r\n" +
					"The MultiAreaMode property of the first series is set to Series, while the second and third area series are displayed with MultiAreaMode set to Stacked or StackedPercent";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Stacked Area Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// setup the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 65;
			chart.Height = 40;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective2);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			// setup X axis
			NOrdinalScaleConfigurator scaleX = chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			scaleX.AutoLabels = false;
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount;
			scaleX.DisplayDataPointsBetweenTicks = false;
			for (int i = 0; i < categoriesCount; i++)
			{
				scaleX.CustomLabels.Add(new NCustomValueLabel(i, (2000 + i).ToString()));
			}

			// add interlaced stripe for Y axis
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };

			NLinearScaleConfigurator scaleY = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			scaleY.StripStyles.Add(stripStyle);

			// hide Z axis
			chart.Axis(StandardAxis.Depth).Visible = false;

			// add the first area
			NAreaSeries area0 = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			area0.MultiAreaMode = MultiAreaMode.Series;
			area0.Name = "Product A";
			SetupDataLabels(area0);

			// add the second Area
			NAreaSeries area1 = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			area1.MultiAreaMode = MultiAreaMode.Stacked;
			area1.Name = "Product B";
			SetupDataLabels(area1);

			// add the third Area
			NAreaSeries area2 = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			area2.MultiAreaMode = MultiAreaMode.Stacked;
			area2.Name = "Product C";
			SetupDataLabels(area2);

			// fill with random data
			area0.Values.FillRandomRange(Random, categoriesCount, 20, 50);
			area1.Values.FillRandomRange(Random, categoriesCount, 20, 50);
			area2.Values.FillRandomRange(Random, categoriesCount, 20, 50);

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// init form controls
			InitLabelsCombo(FirstAreaDataLabelsComboBox);
			InitLabelsCombo(SecondAreaDataLabelsComboBox);
			InitLabelsCombo(ThirdAreaDataLabelsComboBox);

			StackModeComboBox.Items.Add("Stack");
			StackModeComboBox.Items.Add("Stack 100%");
			StackModeComboBox.SelectedIndex = 0;

			ShowDataLabelsCheckBox_Checked(null, null);

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());
		}

		private void SetupDataLabels(NAreaSeries area)
		{
			NDataLabelStyle dataLabel = area.DataLabelStyle;
			dataLabel.ArrowLength = new NLength(0);
			dataLabel.VertAlign = VertAlign.Center;
			dataLabel.TextStyle.BackplaneStyle.Shape = BackplaneShape.Ellipse;
			dataLabel.TextStyle.BackplaneStyle.Inflate = new NSizeL(5, 5);
			dataLabel.TextStyle.FontStyle = new NFontStyle("Arial", new NLength(8, NGraphicsUnit.Point), System.Drawing.FontStyle.Bold);
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
			NChart chart = nChartControl1.Charts[0];
			NAreaSeries area1 = (NAreaSeries)chart.Series[1];
			NAreaSeries area2 = (NAreaSeries)chart.Series[2];
			NLinearScaleConfigurator scale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			switch (StackModeComboBox.SelectedIndex)
			{
				case 0:
					area1.MultiAreaMode = MultiAreaMode.Stacked;
					area2.MultiAreaMode = MultiAreaMode.Stacked;
					scale.LabelValueFormatter = new NNumericValueFormatter(NumericValueFormat.General);
					break;

				case 1:
					area1.MultiAreaMode = MultiAreaMode.StackedPercent;
					area2.MultiAreaMode = MultiAreaMode.StackedPercent;
					scale.LabelValueFormatter = new NNumericValueFormatter(NumericValueFormat.Percentage);
					break;
			}

			nChartControl1.Refresh();

		}

		private void ShowDataLabelsCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NAreaSeries area0 = (NAreaSeries)chart.Series[0];
			NAreaSeries area1 = (NAreaSeries)chart.Series[1];
			NAreaSeries area2 = (NAreaSeries)chart.Series[2];

			area0.DataLabelStyle.Visible = (bool)ShowDataLabelsCheckBox.IsChecked;
			area1.DataLabelStyle.Visible = (bool)ShowDataLabelsCheckBox.IsChecked;
			area2.DataLabelStyle.Visible = (bool)ShowDataLabelsCheckBox.IsChecked;

			FirstAreaDataLabelsComboBox.IsEnabled = (bool)ShowDataLabelsCheckBox.IsChecked;
			SecondAreaDataLabelsComboBox.IsEnabled = (bool)ShowDataLabelsCheckBox.IsChecked;
			ThirdAreaDataLabelsComboBox.IsEnabled = (bool)ShowDataLabelsCheckBox.IsChecked;

			nChartControl1.Refresh();
		}

		private void FirstAreaDataLabelsComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NAreaSeries area0 = (NAreaSeries)chart.Series[0];

			area0.DataLabelStyle.Format = GetFormatStringFromIndex(FirstAreaDataLabelsComboBox.SelectedIndex);

			nChartControl1.Refresh();
		}

		private void SecondAreaDataLabelsComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NAreaSeries area1 = (NAreaSeries)chart.Series[1];

			area1.DataLabelStyle.Format = GetFormatStringFromIndex(SecondAreaDataLabelsComboBox.SelectedIndex);

			nChartControl1.Refresh();
		}

		private void ThirdAreaDataLabelsComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NAreaSeries area2 = (NAreaSeries)chart.Series[2];

			area2.DataLabelStyle.Format = GetFormatStringFromIndex(ThirdAreaDataLabelsComboBox.SelectedIndex);

			nChartControl1.Refresh();
		}

		private static void InitLabelsCombo(ComboBox comboBox)
		{
			comboBox.Items.Add("Value");
			comboBox.Items.Add("Total");
			comboBox.Items.Add("Cumulative");
			comboBox.Items.Add("Percent");
			comboBox.SelectedIndex = 0;
		}
	}
}
