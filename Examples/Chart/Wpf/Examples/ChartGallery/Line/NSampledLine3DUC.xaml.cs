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
	public partial class NSampledLine3DUC : NExampleBaseUC
	{
		NLineSeries m_Line;

		public NSampledLine3DUC()
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
				return "Sampled Line 3D";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates how to enable sampling for the line series.\nWhen using sampling the line will ignore settings for markers and data labels and will also automatically resample the data storage depending on the size of the chart on the screen.This allows for the visualization of massive amounts of data.\nThe sample distance scroll bar on the right allows you to modify the sampling distance \n Click on the 'Add 20, 000 Data Points' or 'Add 40, 000 Data Points' to add some more new random data.\n The data point counter below shows the current number of data points in thousands.\n Press the 'Clear Data' button to clear all data points and start over.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("3D Sampled Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 70;
			chart.Height = 70;
			chart.Depth = 70;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = new NLinearScaleConfigurator();

			// add interlaced stripe to the Y axis
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			stripStyle.Interlaced = true;
			((NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator).StripStyles.Add(stripStyle);

			// add a line series
			m_Line = (NLineSeries)chart.Series.Add(SeriesType.Line);
			m_Line.Name = "Line Series";
			m_Line.InflateMargins = true;
			m_Line.DataLabelStyle.Visible = false;
			m_Line.MarkerStyle.Visible = false;
			m_Line.UseXValues = true;
			m_Line.UseZValues = true;
			m_Line.SamplingMode = SeriesSamplingMode.Enabled;

			SampleDistanceScrollBar.Value = (int)m_Line.SampleDistance.Value;

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			Add40KDataButton_Click(null, null);
		}

		private void SampleDistanceScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			m_Line.SampleDistance = new NLength((float)SampleDistanceScrollBar.Value * 100.0f);
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
			double prevZVal = 0;

			double angle = 0;
			double phase = (Math.PI * 2 * rand.NextDouble()) / count + 0.0001;
			double magnitude = rand.NextDouble() * 5;

			double[] xValues = new double[count];
			double[] yValues = new double[count];
			double[] zValues = new double[count];

			int valueCount = m_Line.Values.Count;
			if (valueCount > 0)
			{
				prevYVal = (double)m_Line.Values[valueCount - 1];
				prevXVal = (double)m_Line.XValues[valueCount - 1];
				prevZVal = (double)m_Line.ZValues[valueCount - 1];
			}

			for (int i = 0; i < count; i++)
			{
				double yStep = Math.Cos(angle) + Math.Sin(angle) * magnitude;
				double xStep = Math.Cos(angle) * magnitude;
				double zStep = Math.Sin(angle) * magnitude;

				if (xStep < 0)
				{
					xStep = 0;
				}

				angle += phase;

				yValues[i] = prevYVal + yStep;
				xValues[i] = prevXVal + xStep;
				zValues[i] = prevZVal + zStep;

				prevXVal = xValues[i];
				prevYVal = yValues[i];
				prevZVal = zValues[i];
			}

			m_Line.Values.AddRange(yValues);
			m_Line.XValues.AddRange(xValues);
			m_Line.ZValues.AddRange(zValues);

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
