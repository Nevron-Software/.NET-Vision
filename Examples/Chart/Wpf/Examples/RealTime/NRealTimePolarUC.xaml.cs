
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
	public partial class NRealTimePolarUC : NRealTimeExampleBaseUC
	{
		NPolarPointSeries m_PolarSeries;
		NAxisConstLine[] m_RadarRay;

		public NRealTimePolarUC()
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
				return "Real Time Polar";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "The example demonstrates how to create realtime polar charts with hardware acceleration.";
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
			NPolarChart chart = new NPolarChart();

			nChartControl1.Panels.Add(chart);
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			chart.InnerRadius = new NLength(10, NGraphicsUnit.Point);
			chart.Width = 70.0f;
			chart.Height = 70.0f;

			Color gridColor = Color.Green;

			NPolarAxis polarAngleAxis = (NPolarAxis)chart.Axis(StandardAxis.PolarAngle);
			NAngularScaleConfigurator angleScale = (NAngularScaleConfigurator)polarAngleAxis.ScaleConfigurator;
			angleScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, true);
			angleScale.MajorGridStyle.LineStyle.Color = gridColor;
			angleScale.OuterMajorTickStyle.LineStyle.Color = gridColor;
			angleScale.InnerMajorTickStyle.LineStyle.Color = gridColor;
			angleScale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(gridColor);
			angleScale.RulerStyle.BorderStyle.Color = gridColor;
			angleScale.LabelFitModes = new LabelFitMode[0];

			m_RadarRay = new NAxisConstLine[10];

			for (int i = 0; i < m_RadarRay.Length; i++)
			{
				m_RadarRay[i] = new NAxisConstLine();
				m_RadarRay[i].StrokeStyle.Color = Color.FromArgb((byte)((1.0 - ((float)i / m_RadarRay.Length)) * 255), gridColor);
				polarAngleAxis.ConstLines.Add(m_RadarRay[i]);
			}

			// setup polar axis
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.Polar).ScaleConfigurator;
			linearScale.RoundToTickMax = true;
			linearScale.RoundToTickMin = true;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.AutoLabels = false;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, true);
			linearScale.MajorGridStyle.LineStyle.Color = gridColor;
			linearScale.InnerMajorTickStyle.Width = new NLength(0);
			linearScale.OuterMajorTickStyle.Width = new NLength(0);
			linearScale.RulerStyle.BorderStyle.Width = new NLength(0);

			// create three polar point series
			m_PolarSeries = new NPolarPointSeries();
			m_PolarSeries.Name = "Polar";
			m_PolarSeries.BorderStyle.Width = new NLength(0);
			m_PolarSeries.PointShape = PointShape.Bar;
			m_PolarSeries.Size = new NLength(4, NGraphicsUnit.Point);
			m_PolarSeries.Angles.ValueFormatter = new NNumericValueFormatter("0.00");
			m_PolarSeries.DataLabelStyle.Visible = false;
			m_PolarSeries.DataLabelStyle.Format = "<value> - <angle_in_degrees>";

			// change the storage type to array to increase performance
			m_PolarSeries.FillStyles.StorageType = IndexedStorageType.Array;

			Random rand = new Random();

			for (int i = 0; i < 360; i++)
			{
				m_PolarSeries.Values.Add(rand.Next(100));
				m_PolarSeries.Angles.Add(i);
				m_PolarSeries.FillStyles[i] = new NColorFillStyle(Color.FromArgb(0, Color.Green));
			}

			// add the series to the chart
			chart.Series.Add(m_PolarSeries);

			UseHardwareAccelerationCheckBox.IsChecked = true;
			nChartControl1.Settings.RenderSurface = RenderSurface.Window;
			StartTimer();

			ConfigureStandardLayout(chart, title, null);
		}

		private void UseHardwareAccelerationCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			nChartControl1.Settings.RenderSurface = (bool)UseHardwareAccelerationCheckBox.IsChecked ? RenderSurface.Window : RenderSurface.Bitmap;
		}

		protected override void OnTimerTick(object sender, EventArgs e)
		{
			base.OnTimerTick(sender, e);

			// decrease the alpha of all colors
			int count = m_PolarSeries.Values.Count;
			int speed = 5;
			NColorFillStyle colorFill;

			for (int i = 0; i < count; i++)
			{
				colorFill = (NColorFillStyle)m_PolarSeries.FillStyles[i];
				Color color = colorFill.Color;

				if (color.A > 0)
				{
					colorFill.Color = Color.FromArgb((byte)Math.Max(0, color.A - speed), color);
				}
			}

			for (int i = 0; i < speed; i++)
			{
				// first shift the value of all others
				for (int j = m_RadarRay.Length - 1; j > 0; j--)
				{
					m_RadarRay[j].Value = m_RadarRay[j - 1].Value;
				}

				m_RadarRay[0].Value++;

				if (m_RadarRay[0].Value >= 360)
				{
					m_RadarRay[0].Value = 0;
				}

				colorFill = (NColorFillStyle)m_PolarSeries.FillStyles[(int)m_RadarRay[0].Value];
				colorFill.Color = Color.FromArgb(255, colorFill.Color);
			}

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
	}
}
