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
	public partial class NRealTimeAreaUC : NRealTimeExampleBaseUC
	{
		public NRealTimeAreaUC()
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
				return "Real Time Area";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "The example demonstrates how to create realtime area charts with hardware acceleration. It also shows how to take advantage of the DataPointOriginIndex which allows you to create cyclic data storage and avoid data shifts.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader(this.Title);
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// do not update automatic legends
			nChartControl1.ServiceManager.LegendUpdateService.UpdateAutoLegends();
			nChartControl1.ServiceManager.LegendUpdateService.Stop();

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			chart.BoundsMode = BoundsMode.Stretch;

			// configure the y axis
			NAxis yAxis = chart.Axis(StandardAxis.PrimaryY);
			yAxis.View = new NRangeAxisView(new NRange1DD(0, 100));

			NLinearScaleConfigurator linearScale = yAxis.ScaleConfigurator as NLinearScaleConfigurator;

			// add interlace stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			linearScale.MajorGridStyle.LineStyle.Color = Color.LightSteelBlue;
			linearScale.InnerMinorTickStyle.Visible = false;
			linearScale.InnerMajorTickStyle.Visible = false;
			linearScale.LabelFitModes = new LabelFitMode[0];

			// configure the x axis
			NAxis xAxis = chart.Axis(StandardAxis.PrimaryX);
			linearScale = new NLinearScaleConfigurator();
			linearScale.LabelFitModes = new LabelFitMode[0];
			xAxis.ScaleConfigurator = linearScale;
			linearScale.RoundToTickMax = false;
			linearScale.RoundToTickMin = false;
			linearScale.InnerMinorTickStyle.Visible = false;
			linearScale.InnerMajorTickStyle.Visible = false;

			chart.Axis(StandardAxis.Depth).Visible = false;

			// add the first line
			NAreaSeries area = new NAreaSeries();
			chart.Series.Add(area);
			area.SamplingMode = SeriesSamplingMode.Enabled;
			area.UseXValues = true;
			area.DataLabelStyle.Visible = false;
			area.Values.ValueFormatter = new NNumericValueFormatter("0.0");
			area.Values.EmptyDataPoints.ValueMode = EmptyDataPointsValueMode.Skip;

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// turn off area border to improve performance after you apply the style sheet
			area.BorderStyle.Width = new NLength(0);

			NumberOfDataPointsComboBox.Items.Add("1000");
			NumberOfDataPointsComboBox.Items.Add("5000");
			NumberOfDataPointsComboBox.Items.Add("10000");
			NumberOfDataPointsComboBox.SelectedIndex = 0;

			NewDataPointsPerTickComboBox.Items.Add("10");
			NewDataPointsPerTickComboBox.Items.Add("50");
			NewDataPointsPerTickComboBox.Items.Add("100");
			NewDataPointsPerTickComboBox.SelectedIndex = 1;

			UseHardwareAccelerationCheckBox.IsChecked = true;
			nChartControl1.Settings.RenderSurface = RenderSurface.Window;
			StartTimer();


			ConfigureStandardLayout(chart, title, null);
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
		protected override void UpdateTitle(bool working, float cpuUsage)
		{
			string title = this.Title;

			if (working)
			{
				title += " [CPU Usage - " + cpuUsage.ToString("0.") + "%]";
			}

			nChartControl1.Labels[0].Text = title;
		}

		private int GetNewDataPointsPerTick()
		{
			switch (NewDataPointsPerTickComboBox.SelectedIndex)
			{
				case 0:
					return 10;
				case 1:
					return 50;
				case 2:
					return 100;
				default:
					return 10;
			}
		}

		private int GetNumberOfDataPoints()
		{
			switch (NumberOfDataPointsComboBox.SelectedIndex)
			{
				case 0:
					return 1000;
				case 1:
					return 5000;
				case 2:
					return 10000;
				default:
					return 1000;
			}
		}

		private double GetXAxisCustomMax()
		{
			return (double)(GetNumberOfDataPoints() - 1);
		}

		protected override void OnTimerTick(object sender, EventArgs e)
		{
			base.OnTimerTick(sender, e);

			int nMaxCount = GetNumberOfDataPoints();

			if (nMaxCount == 0)
				return;

			int newDataPoints = GetNewDataPointsPerTick();

			double dValueX = 0;
			NChart chart = nChartControl1.Charts[0];
			NAreaSeries area = (NAreaSeries)chart.Series[0];
			NAxis axisX = chart.Axis(StandardAxis.PrimaryX);

			double minValue = 0;
			double maxValue = 100;

			// add 100 new random points
			for (int i = 0; i < newDataPoints; i++)
			{
				if (m_nDirectionChangeCounter == 0)
				{
					m_nDirectionChangeCounter = 100;
					m_Direction = (m_Direction + m_Random.NextDouble() - 0.5) / 4.0;
				}

				m_nDirectionChangeCounter--;

				if (m_Value + m_Direction > maxValue)
				{
					m_Value = maxValue;
					m_Direction = 0;
					m_nDirectionChangeCounter = 0;
				}
				else if (m_Value + m_Direction < minValue)
				{
					m_Value = minValue;
					m_Direction = 0;
					m_nDirectionChangeCounter = 0;
				}
				else
				{
					m_Value += m_Direction;
				}

				double dValueY = m_Value;

				int nIndex = m_nCounter % nMaxCount;
				dValueX = m_nCounter;

				if (nIndex >= area.Values.Count)
				{
					area.Values.Add(dValueY);
					area.XValues.Add(dValueX);
				}
				else
				{
					area.Values[area.DataPointOriginIndex] = dValueY;
					area.XValues[area.DataPointOriginIndex] = dValueX;
					area.DataPointOriginIndex++;

					if (area.DataPointOriginIndex >= area.Values.Count)
					{
						area.DataPointOriginIndex = 0;
					}
				}

				m_nCounter++;
			}

			nChartControl1.Refresh();
		}


		private int m_nCounter;
		private int m_nDirectionChangeCounter;
		private double m_Direction;
		private double m_Value;
		private Random m_Random = new Random();

		private void ResetButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			if (nChartControl1 == null)
				return;

			int nMaxCount = GetNumberOfDataPoints();

			NChart chart = nChartControl1.Charts[0];
			NAreaSeries area = (NAreaSeries)chart.Series[0];
			area.Values.Clear();
			area.XValues.Clear();
			area.DataPointOriginIndex = 0;

			m_nCounter = 0;
			m_nDirectionChangeCounter = 0;
			m_Direction = 0;
			m_Value = 0;

			nChartControl1.Refresh();
		}


		private void NewDataPointsPerTickComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			ResetButton_Click(null, null);
		}

		private void NumberOfDataPointsComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			ResetButton_Click(null, null);
		}
	}
}
