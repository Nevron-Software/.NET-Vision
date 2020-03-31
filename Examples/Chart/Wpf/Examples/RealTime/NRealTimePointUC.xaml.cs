using Nevron.Chart;
using Nevron.GraphicsCore;
using System.Drawing;
using System;
using Nevron.Dom;
using System.Collections.Generic;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NRealTimePointUC : NRealTimeExampleBaseUC
	{
		/// <summary>
		/// Helper class that represents a random sphere
		/// </summary>
		class NSphereInfo
		{
			/// <summary>
			/// Initializer constructor
			/// </summary>
			/// <param name="factor"></param>
			public NSphereInfo(int factor)
			{
				Random rand = new System.Random();

				m_CenterX = rand.NextDouble() * 200.0 - 100.0;
				m_CenterY = rand.NextDouble() * 200.0 - 100.0;
				m_CenterZ = rand.NextDouble() * 200.0 - 100.0;

				m_BeginColor = Color.FromArgb((byte)(rand.NextDouble() * 255), (byte)(rand.NextDouble() * 255), (byte)(rand.NextDouble() * 255));
				m_EndColor = Color.FromArgb((byte)(rand.NextDouble() * 255), (byte)(rand.NextDouble() * 255), (byte)(rand.NextDouble() * 255));

				m_Radius = 1;
				m_RadiusIncrement = rand.NextDouble() * 3.0 + 0.1;

				m_MaxLongitude = 10 * (factor + 1);
				m_MaxLatitude = 10 * (factor + 1);

				int numDataPoints = 2 + (m_MaxLatitude * m_MaxLongitude);

				m_XValues = new double[numDataPoints];
				m_YValues = new double[numDataPoints];
				m_ZValues = new double[numDataPoints];
			}
			/// <summary>
			/// Adds the sphere to the specified point series
			/// </summary>
			/// <param name="point"></param>
			public void AddSphere(NPointSeries point)
			{
				m_Radius += m_RadiusIncrement;
				m_Counter++;

				double x, y, z;

				point.FillStyle = new NColorFillStyle(InterpolateColors(m_BeginColor, m_EndColor, (float)(m_Counter / 100.0)));
				point.Values.Clear();
				point.XValues.Clear();
				point.ZValues.Clear();

				int dataPointIndex = 0;

				double[] xValues = m_XValues;
				double[] yValues = m_YValues;
				double[] zValues = m_ZValues;

				// top vertex
				yValues[dataPointIndex] = (m_CenterY + m_Radius);
				xValues[dataPointIndex] = m_CenterX;
				zValues[dataPointIndex] = m_CenterZ;
				dataPointIndex++;

				// bottom vertex
				yValues[dataPointIndex] = m_CenterY - m_Radius;
				xValues[dataPointIndex] = m_CenterX;
				zValues[dataPointIndex] = m_CenterZ;
				dataPointIndex++;

				int nPitch = m_MaxLongitude + 1;

				double pitchInc = (180.0 / (double)m_MaxLongitude) * NMath.Degree2Rad;
				double rotInc = (360.0 / (double)m_MaxLatitude) * NMath.Degree2Rad;

				for (int pitch = 1; pitch <= m_MaxLongitude; pitch++)     // Generate all "intermediate vertices":
				{
					double res = m_Radius * Math.Sin((float)pitch * pitchInc);

					if (res < 0)
					{
						res = -res;
					}

					y = m_Radius * Math.Cos(pitch * pitchInc);

					for (int latitude = 0; latitude < m_MaxLatitude; latitude++)
					{
						x = res * Math.Cos(latitude * rotInc);
						z = res * Math.Sin(latitude * rotInc);

						yValues[dataPointIndex] = m_CenterY + y;
						xValues[dataPointIndex] = m_CenterX + x;
						zValues[dataPointIndex] = m_CenterZ + z;

						dataPointIndex++;
					}
				}

				if (point.XValues.Count > 0)
				{
					point.Values.SetRange(0, yValues);
					point.XValues.SetRange(0, xValues);
					point.ZValues.SetRange(0, zValues);
				}
				else
				{
					point.Values.AddRange(yValues);
					point.XValues.AddRange(xValues);
					point.ZValues.AddRange(zValues);
				}
			}

			public static Color InterpolateColors(Color color1, Color color2, float factor)
			{
				int num1 = ((int)color1.R);
				int num2 = ((int)color1.G);
				int num3 = ((int)color1.B);

				int num4 = ((int)color2.R);
				int num5 = ((int)color2.G);
				int num6 = ((int)color2.B);

				byte num7 = (byte)((((float)num1) + (((float)(num4 - num1)) * factor)));
				byte num8 = (byte)((((float)num2) + (((float)(num5 - num2)) * factor)));
				byte num9 = (byte)((((float)num3) + (((float)(num6 - num3)) * factor)));

				return Color.FromArgb(num7, num8, num9);
			}

			double m_CenterX;
			double m_CenterY;
			double m_CenterZ;
			double m_Radius;
			double m_RadiusIncrement;
			Color m_BeginColor;
			Color m_EndColor;
			public int m_Counter;

			int m_MaxLongitude;
			int m_MaxLatitude;

			double[] m_XValues;
			double[] m_YValues;
			double[] m_ZValues;
		}

		/// <summary>
		/// Default constructor
		/// </summary>
		public NRealTimePointUC()
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
				return "Real Time Point";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "The example demonstrates how to create realtime point charts with hardware acceleration.";
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
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.BoundsMode = BoundsMode.Fit;
			chart.Enable3D = true;
			chart.Width = chart.Height = chart.Depth = 50.0f; // make the aspect 1:1:1

			// configure the y axis
			NAxis yAxis = chart.Axis(StandardAxis.PrimaryY);
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

			// configure the axes
			ConfigureAxis(chart.Axis(StandardAxis.PrimaryX));
			ConfigureAxis(chart.Axis(StandardAxis.PrimaryY));
			ConfigureAxis(chart.Axis(StandardAxis.Depth));

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			DataPointsPerSphereComboBox.Items.Add("100");
			DataPointsPerSphereComboBox.Items.Add("1000");
			DataPointsPerSphereComboBox.Items.Add("10000");
			DataPointsPerSphereComboBox.SelectedIndex = 0;

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			UseHardwareAccelerationCheckBox.IsChecked = true;
			nChartControl1.Settings.RenderSurface = RenderSurface.Window;
   			StartTimer();

			ConfigureStandardLayout(chart, title, null);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="axis"></param>
		private static void ConfigureAxis(NAxis axis)
		{
			// configure the x axis
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			linearScale.LabelFitModes = new LabelFitMode[0];

			axis.ScaleConfigurator = linearScale;
			axis.View = new NRangeAxisView(new NRange1DD(-200, 200), true, true);
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

			NChart chart = nChartControl1.Charts[0];

			NAxis axisX = chart.Axis(StandardAxis.PrimaryX);

			if (m_Counter == 0)
			{
				NPointSeries point = new NPointSeries();

				point.Size = new NLength(2);
				point.EnableDepthSort = false;
				point.DataLabelStyle.Visible = false;
				point.UseXValues = true;
				point.UseZValues = true;

				// turn off point border to improve performance
				point.BorderStyle.Width = new NLength(0);
				point.PointShape = PointShape.Bar;

				point.Tag = new NSphereInfo(DataPointsPerSphereComboBox.SelectedIndex);

				chart.Series.Add(point);
				m_Counter = 10;
			}

			m_Counter--;

			int count = chart.Series.Count;

			for (int i = count - 1; i >= 0; i--)
			{
				NPointSeries point = (NPointSeries)chart.Series[i];

				NSphereInfo info = (NSphereInfo)point.Tag;

				if (info.m_Counter == 100)
				{
					chart.Series.RemoveAt(i);
				}
				else
				{
					info.AddSphere(point);
				}
			}


			nChartControl1.Refresh();
		}

		private void NumberOfDataPointsUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			ResetButton_Click(null, null);
		}


		private void ResetButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];

			chart.Series.Clear();

			nChartControl1.Refresh();
		}

		public static Color InterpolateColors(Color color1, Color color2, float factor)
		{
			int num1 = ((int)color1.R);
			int num2 = ((int)color1.G);
			int num3 = ((int)color1.B);

			int num4 = ((int)color2.R);
			int num5 = ((int)color2.G);
			int num6 = ((int)color2.B);

			byte num7 = (byte)((((float)num1) + (((float)(num4 - num1)) * factor)));
			byte num8 = (byte)((((float)num2) + (((float)(num5 - num2)) * factor)));
			byte num9 = (byte)((((float)num3) + (((float)(num6 - num3)) * factor)));

			return Color.FromArgb(num7, num8, num9);
		}


		private int m_Counter;

		private void DataPointsPerSphereComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			ResetButton_Click(null, null);
		}
	}
}
