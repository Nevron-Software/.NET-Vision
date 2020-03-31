using Nevron.Chart;
using Nevron.Dom;
using Nevron.GraphicsCore;
using System;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NAreaPaletteUC : NExampleBaseUC
	{
		private NChart m_Chart;
        private NAreaSeries m_Area;
        private NRange1DD m_AxisRange;
        private DispatcherTimer m_Timer;
        private double[] m_IndicatorPhase;

		public NAreaPaletteUC()
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
				return "Area Palette";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
                return "This example demonstrates how to apply palette to an area series.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Area Palette");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

            // configure the chart
            m_Chart = nChartControl1.Charts[0];
            m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHalf);
            m_Chart.Axis(StandardAxis.Depth).Visible = false;

            // add interlace stripe
            NAxis yAxis = m_Chart.Axis(StandardAxis.PrimaryY);
            NLinearScaleConfigurator linearScale = yAxis.ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle strip = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            strip.Interlaced = true;
            //linearScale.Strips.Add(strip);

            // setup a area series
            m_Area = new NAreaSeries();
            m_Area.InflateMargins = true;
            m_Area.DataLabelStyle.Visible = false;
            m_Area.BorderStyle.Width = new NLength(0);
            m_Area.Legend.Mode = SeriesLegendMode.None;

            NPalette palette = new NPalette();
            palette.SmoothPalette = true;
            palette.Clear();
            palette.Mode = PaletteMode.Custom;
            palette.Add(0, Color.Green);
            palette.Add(60, Color.Yellow);
            palette.Add(120, Color.Red);

            m_Area.Palette = palette;

            m_AxisRange = new NRange1DD(0, 130);

            // limit the axis range to 0, 130
            yAxis.View = new NRangeAxisView(m_AxisRange, true, true);
            m_Chart.Series.Add(m_Area);

            int indicatorCount = 10;
            m_IndicatorPhase = new double[indicatorCount];

            // add some data to the area series
            for (int i = 0; i < indicatorCount; i++)
            {
                m_IndicatorPhase[i] = i * 30;
                m_Area.Values.Add(0);
            }

            m_Timer = new System.Windows.Threading.DispatcherTimer();
            m_Timer.Tick += new EventHandler(OnTimerTick);
            m_Timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            m_Timer.Start();
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnTimerTick(object sender, EventArgs e)
        {
            Random random = new Random();

            for (int i = 0; i < m_Area.Values.Count; i++)
            {
                double value = (m_AxisRange.Begin + m_AxisRange.End) / 2.0 + Math.Sin(m_IndicatorPhase[i] * NMath.Degree2Rad) * m_AxisRange.GetLength() / 2 + random.Next(20);
                value = m_AxisRange.GetValueInRange(value);

                m_Area.Values[i] = value;
                m_IndicatorPhase[i] += 10;
            }

            nChartControl1.Refresh();
        }

        private void InvertAxisCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.Invert = (bool)InvertAxisCheckBox.IsChecked;
            nChartControl1.Refresh();
        }

        private void SmoothPaletteCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            m_Area.Palette.SmoothPalette = (bool)SmoothPaletteCheckBox.IsChecked;
            nChartControl1.Refresh();
        }

        private void Enable3DCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            m_Chart.Enable3D = (bool)Enable3DCheckBox.IsChecked;
            nChartControl1.Refresh();
        }

        private void StartStopTimerButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (StartStopTimerButton.Content.ToString().StartsWith("Stop"))
            {
                StartStopTimerButton.Content = "Start Timer";
                m_Timer.Stop();
            }
            else
            {
                m_Timer.Start();
                StartStopTimerButton.Content = "Stop Timer";
            }
        }
	}
}
