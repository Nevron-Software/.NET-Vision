using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NSampledLine2DUC : NExampleBaseUC
	{
		NLineSeries m_Line;
		NChart m_Chart;

		public NSampledLine2DUC()
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
				return "This example demonstrates how to enable sampling for the line series.\r\n" +
						"When using sampling the line will ignore settings for markers and data labels and will also automatically resample the data storage depending on the size of the chart on the screen. This allows for the visualization of massive amounts of data.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("2D Sampled Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			m_Chart = nChartControl1.Charts[0];

			// add interlaced stripe to the Y axis
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			((NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator).StripStyles.Add(stripStyle);

			// add a line series
			m_Line = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_Line.Name = "Line Series";
			m_Line.InflateMargins = true;
			m_Line.DataLabelStyle.Visible = false;
			m_Line.MarkerStyle.Visible = false;
			m_Line.SamplingMode = SeriesSamplingMode.Enabled;

			m_Line.MarkerStyle.PointShape = PointShape.Cylinder;
			m_Line.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			m_Line.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			m_Line.UseXValues = true;

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// configure interactivity
			nChartControl1.Controller.Selection.Add(m_Chart);
			nChartControl1.Controller.Tools.Add(new NAxisScrollTool());
			nChartControl1.Controller.Tools.Add(new NDataZoomTool());

			NCartesianChart chart = (NCartesianChart)nChartControl1.Charts[0];
			chart.RangeSelections.Add(new NRangeSelection());
			chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = true;
			chart.Axis(StandardAxis.PrimaryY).ScrollBar.Visible = true;

			// configure controls

			SampleDistanceScrollBar.Value = m_Line.SampleDistance.Value / 100.0f;

			GeneratorModeComboBox.Items.Add("Generator 1 (Continous Y)");
			GeneratorModeComboBox.Items.Add("Generator 2 (Random Y)");
			GeneratorModeComboBox.SelectedIndex = 0;

			UseXValuesCheckBox.IsChecked = true;

			Add40KDataButton_Click(null, null);
		}

		private void SampleDistanceScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			m_Line.SampleDistance = new NLength((float)SampleDistanceScrollBar.Value * 100.0f);
			nChartControl1.Refresh();
		}

		private void UseXValuesCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			m_Line.UseXValues = (bool)UseXValuesCheckBox.IsChecked;

			if ((bool)UseXValuesCheckBox.IsChecked)
			{
				m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NLinearScaleConfigurator();
			}
			else
			{
				m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NOrdinalScaleConfigurator();
			}

			nChartControl1.Refresh();
		}

		private void Add20KDataButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			AddNewData(20000);
			UpdateCounter();
		}

		private void Add40KDataButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			AddNewData(40000);
			UpdateCounter();
		}

		private void ClearDataButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			m_Line.Values.Clear();
			m_Line.XValues.Clear();
			UpdateCounter();

			nChartControl1.Refresh();
		}
		private void AddNewData(int count)
		{
			Random rand = new Random();

			double prevYVal = 0;
			double prevXVal = 0;

			int valueCount = m_Line.Values.Count;

			if (valueCount > 0)
			{
				prevYVal = (double)m_Line.Values[valueCount - 1];
				prevXVal = (double)m_Line.XValues[valueCount - 1];
			}

			double[] xValues = new double[count];
			double[] yValues = new double[count];

			double magnitude = 0.01 + rand.NextDouble() * 5;

			if (GeneratorModeComboBox.SelectedIndex == 0)
			{
				// continuous
				double angle = 0;
				double phase = (Math.PI * 2 * rand.NextDouble()) / count + 0.0001;

				for (int i = 0; i < count; i++)
				{
					double yStep = Math.Sin(angle) * magnitude;
					double xStep = 0.01 + rand.NextDouble() * magnitude;

					if (xStep < 0)
					{
						xStep = 0;
					}

					angle += phase;
					prevXVal += xStep;

					yValues[i] = prevYVal + yStep;
					xValues[i] = prevXVal;
				}

				m_Line.Values.AddRange(yValues);
				m_Line.XValues.AddRange(xValues);
			}
			else
			{
				// monotone X, random
				for (int i = 0; i < count; i++)
				{
					yValues[i] = rand.NextDouble() * magnitude;
					xValues[i] = prevXVal;
					prevXVal += 1;
				}

				m_Line.Values.AddRange(yValues);
				m_Line.XValues.AddRange(xValues);
			}

			UpdateCounter();

			nChartControl1.Refresh();
		}


		private void UpdateCounter()
		{
			int count = m_Line.Values.Count;
			DataPointCountTextBox.Text = (count / 1000).ToString() + "K";

			if (count > 1000000)
			{
				Add20KDataButton.IsEnabled = false;
				Add40KDataButton.IsEnabled = false;
			}
			else
			{
				Add20KDataButton.IsEnabled = true;
				Add40KDataButton.IsEnabled = true;
			}
		}
	}
}
