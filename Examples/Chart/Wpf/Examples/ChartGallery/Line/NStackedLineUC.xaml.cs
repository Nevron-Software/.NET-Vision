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
	public partial class NStackedLineUC : NExampleBaseUC
	{
		private const int categoriesCount = 12;
		private NChart m_Chart;
		private NLineSeries m_Line1;
		private NLineSeries m_Line2;
		private NLineSeries m_Line3;

		public NStackedLineUC()
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
				return "Stacked Line";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a stacked line chart. The first series MultiLineMode is set to Series, while the second and third line series are displayed with MultiBarMode set to Stacked or StackedPercent.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Stacked Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			// add interlaced stripe to the Y axis
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(System.Drawing.Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			stripStyle.Interlaced = true;
			((NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator).StripStyles.Add(stripStyle);

			// add the first line
			m_Line1 = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_Line1.Name = "Line 1";
			m_Line1.MultiLineMode = MultiLineMode.Series;
			m_Line1.DataLabelStyle.Visible = false;
			m_Line1.DataLabelStyle.ArrowLength = new NLength(0, NRelativeUnit.ParentPercentage);
			m_Line1.DataLabelStyle.ArrowStrokeStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			m_Line1.DataLabelStyle.TextStyle.BackplaneStyle.Shape = BackplaneShape.Ellipse;
			m_Line1.DataLabelStyle.TextStyle.BackplaneStyle.Inflate = new NSizeL(6, 6);
			m_Line1.DataLabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8);
			m_Line1.LineSegmentShape = LineSegmentShape.Tape;
			m_Line1.DepthPercent = 50;
			m_Line1.DataLabelStyle.Format = "<value>";

			// add the second line
			m_Line2 = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_Line2.Name = "Line 2";
			m_Line2.DataLabelStyle.Visible = false;
			m_Line2.MultiLineMode = MultiLineMode.Stacked;
			m_Line2.DataLabelStyle.ArrowLength = new NLength(0);
			m_Line2.DataLabelStyle.ArrowStrokeStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			m_Line2.DataLabelStyle.TextStyle.BackplaneStyle.Shape = BackplaneShape.Ellipse;
			m_Line2.DataLabelStyle.TextStyle.BackplaneStyle.Inflate = new NSizeL(6, 6);
			m_Line2.DataLabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8);
			m_Line2.LineSegmentShape = LineSegmentShape.Tape;
			m_Line2.DepthPercent = 50;
			m_Line2.DataLabelStyle.Format = "<value>";

			// add the third line
			m_Line3 = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_Line3.Name = "Line 3";
			m_Line3.DataLabelStyle.Visible = false;
			m_Line3.MultiLineMode = MultiLineMode.Stacked;
			m_Line3.DataLabelStyle.ArrowLength = new NLength(0);
			m_Line3.DataLabelStyle.ArrowStrokeStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			m_Line3.DataLabelStyle.TextStyle.BackplaneStyle.Shape = BackplaneShape.Ellipse;
			m_Line3.DataLabelStyle.TextStyle.BackplaneStyle.Inflate = new NSizeL(6, 6);
			m_Line3.DataLabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8);
			m_Line3.LineSegmentShape = LineSegmentShape.Tape;
			m_Line3.DepthPercent = 50;
			m_Line3.DataLabelStyle.Format = "<value>";

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Nature);
			styleSheet.Apply(nChartControl1.Document);

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			PositiveValuesButton_Click(null, null);

			StackModeComboBox.Items.Add("Stacked");
			StackModeComboBox.Items.Add("Stacked %");
			StackModeComboBox.SelectedIndex = 0;

			ShowDataLabelsCheckBox.IsChecked = false;
		}

		private void StackModeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NStandardScaleConfigurator scale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NStandardScaleConfigurator;

			switch (StackModeComboBox.SelectedIndex)
			{
				case 0:
					m_Line2.MultiLineMode = MultiLineMode.Stacked;
					m_Line3.MultiLineMode = MultiLineMode.Stacked;
					scale.LabelValueFormatter = new NNumericValueFormatter(NumericValueFormat.General);
					break;

				case 1:
					m_Line2.MultiLineMode = MultiLineMode.StackedPercent;
					m_Line3.MultiLineMode = MultiLineMode.StackedPercent;
					scale.LabelValueFormatter = new NNumericValueFormatter(NumericValueFormat.Percentage);
					break;
			}

			nChartControl1.Refresh();
		}

		private void PositiveDataButton_Click(object sender, System.EventArgs e)
		{
			m_Line1.Values.FillRandomRange(Random, categoriesCount, 10, 100);
			m_Line2.Values.FillRandomRange(Random, categoriesCount, 10, 100);
			m_Line3.Values.FillRandomRange(Random, categoriesCount, 10, 100);

			nChartControl1.Refresh();
		}
		private void PositiveAndNegativeValuesButton_Click(object sender, System.EventArgs e)
		{
			m_Line1.Values.FillRandomRange(Random, categoriesCount, -50, 50);
			m_Line2.Values.FillRandomRange(Random, categoriesCount, -50, 50);
			m_Line3.Values.FillRandomRange(Random, categoriesCount, -50, 50);

			nChartControl1.Refresh();
		}

		private void ShowDataLabelsCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NLineSeries line0 = (NLineSeries)chart.Series[0];
			NLineSeries line1 = (NLineSeries)chart.Series[1];
			NLineSeries line2 = (NLineSeries)chart.Series[2];

			bool showDataLabels = ShowDataLabelsCheckBox.IsChecked.Value;

			line0.DataLabelStyle.Visible = showDataLabels;
			line1.DataLabelStyle.Visible = showDataLabels;
			line2.DataLabelStyle.Visible = showDataLabels;


			nChartControl1.Refresh();
		}

		private void PositiveValuesButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			m_Line1.Values.FillRandomRange(Random, categoriesCount, 10, 100);
			m_Line2.Values.FillRandomRange(Random, categoriesCount, 10, 100);
			m_Line3.Values.FillRandomRange(Random, categoriesCount, 10, 100);

			nChartControl1.Refresh();
		}

		private void PositiveAndNegativeValuesButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			m_Line1.Values.FillRandomRange(Random, categoriesCount, -50, 50);
			m_Line2.Values.FillRandomRange(Random, categoriesCount, -50, 50);
			m_Line3.Values.FillRandomRange(Random, categoriesCount, -50, 50);

			nChartControl1.Refresh();
		}

		private void Enable3DCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			m_Chart.Enable3D = Enable3DCheckBox.IsChecked.Value;
			nChartControl1.Refresh();
		}
	}
}
