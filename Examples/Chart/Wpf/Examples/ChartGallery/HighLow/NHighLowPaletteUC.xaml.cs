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
	public partial class NHighLowPaletteUC : NExampleBaseUC
	{
        private NChart m_Chart;
        private NHighLowSeries m_HighLow;

        public NHighLowPaletteUC()
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
				return "High Low Palette";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
                return "This example demonstrates how to apply palette to a high low series.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("High Low Palette");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
            title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

            // configure the chart
            m_Chart = nChartControl1.Charts[0];
            m_Chart.Enable3D = true;
            m_Chart.Axis(StandardAxis.Depth).Visible = false;

            // add a High-Low series
            m_HighLow = (NHighLowSeries)m_Chart.Series.Add(SeriesType.HighLow);
            m_HighLow.Legend.Mode = SeriesLegendMode.None;
            m_HighLow.DataLabelStyle.Visible = false;

            GenerateData();

            NPalette palette = new NPalette();
            palette.Clear();
            palette.SmoothPalette = true;
            palette.Mode = PaletteMode.Custom;
            palette.Add(0, Color.Green);
            palette.Add(1.5, Color.Yellow);
            palette.Add(3, Color.Red);

            m_HighLow.Palette = palette;

            // apply layout
            ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

            SmoothPaletteCheckBox.IsChecked = true;
            Enable3DCheckBox.IsChecked = true;
		}

        private void GenerateData()
        {
            m_HighLow.ClearDataPoints();

            for (int i = 0; i < 20; i++)
            {
                double d1 = Math.Log(i + 1) + 0.1 * Random.NextDouble();
                double d2 = d1 + Math.Cos(0.33 * i) + 0.1 * Random.NextDouble();

                m_HighLow.HighValues.Add(d1);
                m_HighLow.LowValues.Add(d2);
            }
        }

        private void InvertAxisCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.Invert = (bool)InvertAxisCheckBox.IsChecked;
            nChartControl1.Refresh();
        }

        private void SmoothPaletteCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            m_HighLow.Palette.SmoothPalette = (bool)SmoothPaletteCheckBox.IsChecked;
            nChartControl1.Refresh();
        }

        private void Enable3DCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            m_Chart.Enable3D = (bool)Enable3DCheckBox.IsChecked;
            nChartControl1.Refresh();
        }
	}
}
