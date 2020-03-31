
using Nevron.Chart;
using Nevron.GraphicsCore;
using System.Drawing;
using System;
using Nevron.Dom;
namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NRealTimeLineUC : NRealTimeExampleBaseUC
	{
		public NRealTimeLineUC()
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
				return "Real Time Line";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "The example demonstrates how to create realtime line charts with hardware acceleration. This allows for realtime visualization of massive amounts of data. This example shows 75000 data points with a target rate of 20fps..";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader(this.Title);
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			NCartesianChart chart = new NCartesianChart();

			nChartControl1.Panels.Add(chart);
			chart.BoundsMode = BoundsMode.Stretch;

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Black);
			//			styleSheet.Apply(m_ChartControl.Document);

			NAxis axis1 = chart.Axis(StandardAxis.PrimaryY);
			ConfigureAxis(axis1, 0, 30, "Signal 1");

			NAxis axis2 = chart.Axis(StandardAxis.SecondaryY);
			ConfigureAxis(axis2, 35, 65, "Signal 2");

			NAxis axis3 = ((NCartesianAxisCollection)chart.Axes).AddCustomAxis(AxisOrientation.Vertical, AxisDockZone.FrontRight);
			ConfigureAxis(axis3, 70, 100, "Signal 3");

			m_Line1 = CreateLineSeries();
			chart.Series.Add(m_Line1);

			m_Line2 = CreateLineSeries();
			chart.Series.Add(m_Line2);
			m_Line2.DisplayOnAxis(StandardAxis.PrimaryY, false);
			m_Line2.DisplayOnAxis(StandardAxis.SecondaryY, true);

			m_Line3 = CreateLineSeries();
			chart.Series.Add(m_Line3);
			m_Line3.DisplayOnAxis(StandardAxis.PrimaryY, false);
			m_Line3.DisplayOnAxis(axis3.AxisId, true);

			m_ValueArray1 = new double[m_NewDataPointsPerTick];
			m_ValueArray2 = new double[m_NewDataPointsPerTick];
			m_ValueArray3 = new double[m_NewDataPointsPerTick];

			UseHardwareAccelerationCheckBox.IsChecked = true;
			nChartControl1.Settings.RenderSurface = RenderSurface.Window;
			StartTimer();

			ConfigureStandardLayout(chart, title, null);
		}

		private void ConfigureAxis(NAxis axis, float beginPercent, float endPercent, string title)
		{
			NLinearScaleConfigurator scale = new NLinearScaleConfigurator();
			scale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			axis.ScaleConfigurator = scale;
			axis.View = new NRangeAxisView(new NRange1DD(-1.5, 1.5), true, true);
			axis.ScaleConfigurator.Title.Text = title;
			axis.Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, false);
			axis.Anchor.BeginPercent = beginPercent;
			axis.Anchor.EndPercent = endPercent;
			axis.Visible = true;
		}

		private NLineSeries CreateLineSeries()
		{
			NLineSeries lineSeries = new NLineSeries();

			lineSeries.Values.Capacity = m_MaxCount;
			lineSeries.XValues.Capacity = m_MaxCount;
			lineSeries.DataLabelStyle.Visible = false;
			lineSeries.SamplingMode = SeriesSamplingMode.Enabled;
			lineSeries.SampleDistance = new NLength(1, NGraphicsUnit.Pixel);

			return lineSeries;
		}

		private void UseHardwareAccelerationCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			nChartControl1.Settings.RenderSurface = (bool)UseHardwareAccelerationCheckBox.IsChecked ? RenderSurface.Window : RenderSurface.Bitmap;
		}

		private void StartStopTimerButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			if (m_Timer.IsEnabled)
			{
				m_Timer.Stop();
				StartStopTimerButton.Content = "Start Timer";
			}
			else
			{
				m_Timer.Start();
				StartStopTimerButton.Content = "Stop Timer";
			}
		}

		protected override void OnTimerTick(object sender, EventArgs e)
		{
			base.OnTimerTick(sender, e);

			// first accumulate the new data in arrays for faster processing
			int newDataPoints = m_NewDataPointsPerTick;

			double frequency1 = 1;
			double frequency2 = 4;
			double frequency3 = 16;

			double amplitude1 = 0.3;
			double amplitude2 = 0.5;
			double amplitude3 = 0.7;

			double angleStep1 = (Math.PI * 2 / m_MaxCount) * frequency1;
			double angleStep2 = (Math.PI * 2 / m_MaxCount) * frequency2;
			double angleStep3 = (Math.PI * 2 / m_MaxCount) * frequency3;

			double noise1 = amplitude1 * 2;
			double noise2 = amplitude2 * 2;
			double noise3 = amplitude3 * 2;

			// generate new data
			Random random = m_Random;
			double[] valueArray1 = m_ValueArray1;
			double[] valueArray2 = m_ValueArray2;
			double[] valueArray3 = m_ValueArray3;

			for (int i = 0; i < newDataPoints; i++)
			{
				valueArray1[i] = (Math.Sin(m_Angle1) + (random.NextDouble() - 0.5) * noise1) * amplitude1;
				valueArray2[i] = (Math.Sin(m_Angle2) + (random.NextDouble() - 0.5) * noise2) * amplitude2;
				valueArray3[i] = (Math.Sin(m_Angle3) + (random.NextDouble() - 0.5) * noise3) * amplitude3;

				m_Angle1 += angleStep1;
				m_Angle2 += angleStep2;
				m_Angle3 += angleStep3;
			}

			int valueIndex = 0;
			int itemsToAdd = newDataPoints;
			int originShift = newDataPoints;

			// then add the new data
			if (m_Line1.Values.Count < m_MaxCount)
			{
				// the line series can accumulate the new data
				int valueCount = Math.Min(m_MaxCount - m_Line1.Values.Count, newDataPoints);

				m_Line1.Values.AddRange(m_ValueArray1, valueIndex, valueCount);
				m_Line2.Values.AddRange(m_ValueArray2, valueIndex, valueCount);
				m_Line3.Values.AddRange(m_ValueArray3, valueIndex, valueCount);

				valueIndex += valueCount;
				itemsToAdd -= valueCount;
				originShift -= valueCount;
			}

			if (itemsToAdd > 0)
			{
				// capacity reached
				int count = m_Line1.Values.Count - m_Line1.DataPointOriginIndex;
				int valueCount = Math.Min(count, itemsToAdd);

				m_Line1.Values.SetRange(m_Line1.DataPointOriginIndex, m_ValueArray1, valueIndex, valueCount);
				m_Line2.Values.SetRange(m_Line2.DataPointOriginIndex, m_ValueArray2, valueIndex, valueCount);
				m_Line3.Values.SetRange(m_Line3.DataPointOriginIndex, m_ValueArray3, valueIndex, valueCount);

				itemsToAdd -= valueCount;

				if (itemsToAdd > 0)
				{
					valueIndex += valueCount;

					m_Line1.Values.SetRange(0, m_ValueArray1, valueIndex, itemsToAdd);
					m_Line2.Values.SetRange(0, m_ValueArray2, valueIndex, itemsToAdd);
					m_Line3.Values.SetRange(0, m_ValueArray3, valueIndex, itemsToAdd);
				}
			}

			m_Line1.DataPointOriginIndex += originShift;
			m_Line2.DataPointOriginIndex += originShift;
			m_Line3.DataPointOriginIndex += originShift;

			m_Line1.DataPointOriginIndex %= m_MaxCount;
			m_Line2.DataPointOriginIndex %= m_MaxCount;
			m_Line3.DataPointOriginIndex %= m_MaxCount;

			nChartControl1.Refresh();
		}

		protected override void UpdateTitle(bool working, float cpuUsage)
		{
			string title = this.Title;

			if (working)
			{
				title += " [CPU Usage - " + cpuUsage.ToString("0.") + "%]";
			}

			nChartControl1.Labels[0].Text = title;
		}

		NLineSeries m_Line1;
		NLineSeries m_Line2;
		NLineSeries m_Line3;
		Random m_Random = new Random();

		double[] m_ValueArray1;
		double[] m_ValueArray2;
		double[] m_ValueArray3;

		int m_MaxCount = 25000;
		int m_NewDataPointsPerTick = 4000;
		double m_Angle1;
		double m_Angle2;
		double m_Angle3;
	}
}
