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
	public partial class NBarPaletteUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBarSeries m_Bar;
        private NRange1DD m_AxisRange;
        private DispatcherTimer m_Timer;
        private double[] m_IndicatorPhase;

		public NBarPaletteUC()
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
				return "Bar Palette";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
                return "This example demonstrates how to apply palette to a bar series.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Bar Palette");
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

            // setup a bar series
            m_Bar = new NBarSeries();
            m_Bar.Name = "Bar Series";
            m_Bar.InflateMargins = true;
            m_Bar.UseXValues = false;
            m_Bar.DataLabelStyle.Visible = false;

            NPalette palette = new NPalette();
            palette.SmoothPalette = true;
            palette.Clear();
            palette.Add(0, Color.Green);
            palette.Add(60, Color.Yellow);
            palette.Add(120, Color.Red);

            m_Bar.Palette = palette;

            m_AxisRange = new NRange1DD(0, 130);

            // limit the axis range to 0, 130
            yAxis.View = new NRangeAxisView(m_AxisRange, true, true);
            m_Chart.Series.Add(m_Bar);

            int indicatorCount = 10;
            m_IndicatorPhase = new double[indicatorCount];

            // add some data to the bar series
            for (int i = 0; i < indicatorCount; i++)
            {
                m_IndicatorPhase[i] = i * 30;
                m_Bar.Values.Add(0);
            }

            NExampleHelpers.FillComboWithEnumValues(BarPaletteModeComboBox, typeof(PaletteColorMode));
            BarPaletteModeComboBox.SelectedIndex = (int)PaletteColorMode.Spread;
            SmoothPaletteCheckBox.IsChecked = true;

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

            for (int i = 0; i < m_Bar.Values.Count; i++)
            {
                double value = (m_AxisRange.Begin + m_AxisRange.End) / 2.0 + Math.Sin(m_IndicatorPhase[i] * NMath.Degree2Rad) * m_AxisRange.GetLength() / 2 + random.Next(20);
                value = m_AxisRange.GetValueInRange(value);

                m_Bar.Values[i] = value;
                m_IndicatorPhase[i] += 10;
            }

            nChartControl1.Refresh();
        }

        private void BarPaletteModeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m_Bar.PaletteColorMode = (PaletteColorMode)BarPaletteModeComboBox.SelectedIndex;
            nChartControl1.Refresh();
        }

        private void InvertAxisCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.Invert = (bool)InvertAxisCheckBox.IsChecked;
            nChartControl1.Refresh();
        }

        private void SmoothPaletteCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            m_Bar.Palette.SmoothPalette = (bool)SmoothPaletteCheckBox.IsChecked;
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
