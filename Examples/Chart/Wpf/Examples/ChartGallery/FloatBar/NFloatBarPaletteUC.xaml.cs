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
	public partial class NFloatBarPaletteUC : NExampleBaseUC
	{
        private NChart m_Chart;
        private NFloatBarSeries m_FloatBar;

		public NFloatBarPaletteUC()
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
				return "Float Bar Palette";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
                return "This example demonstrates how to apply palette to a float bar series.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Float Bar Palette");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

            // no legend
            nChartControl1.Legends.Clear();

            // configure the chart
            m_Chart = nChartControl1.Charts[0];
            m_Chart.Enable3D = true;
            m_Chart.Axis(StandardAxis.Depth).Visible = false;

            // setup X axis
            NOrdinalScaleConfigurator scaleX = m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
            scaleX.AutoLabels = false;
            scaleX.MajorTickMode = MajorTickMode.AutoMaxCount;
            scaleX.DisplayDataPointsBetweenTicks = false;
            for (int i = 0; i < monthLetters.Length; i++)
            {
                scaleX.CustomLabels.Add(new NCustomValueLabel(i, monthLetters[i]));
            }

            // add interlaced stripe to the Y axis
            NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };
            stripStyle.Interlaced = true;
            linearScale.StripStyles.Add(stripStyle);

            // create the float bar series
            m_FloatBar = (NFloatBarSeries)m_Chart.Series.Add(SeriesType.FloatBar);
            m_FloatBar.DataLabelStyle.Visible = false;
            m_FloatBar.DataLabelStyle.VertAlign = VertAlign.Center;
            m_FloatBar.DataLabelStyle.Format = "<begin> - <end>";

            // add bars
            m_FloatBar.AddDataPoint(new NFloatBarDataPoint(2, 10));
            m_FloatBar.AddDataPoint(new NFloatBarDataPoint(5, 16));
            m_FloatBar.AddDataPoint(new NFloatBarDataPoint(9, 17));
            m_FloatBar.AddDataPoint(new NFloatBarDataPoint(12, 21));
            m_FloatBar.AddDataPoint(new NFloatBarDataPoint(8, 18));
            m_FloatBar.AddDataPoint(new NFloatBarDataPoint(7, 18));
            m_FloatBar.AddDataPoint(new NFloatBarDataPoint(3, 11));
            m_FloatBar.AddDataPoint(new NFloatBarDataPoint(5, 12));
            m_FloatBar.AddDataPoint(new NFloatBarDataPoint(8, 17));
            m_FloatBar.AddDataPoint(new NFloatBarDataPoint(6, 15));
            m_FloatBar.AddDataPoint(new NFloatBarDataPoint(3, 10));
            m_FloatBar.AddDataPoint(new NFloatBarDataPoint(1, 7));

            NPalette palette = new NPalette();
            palette.SmoothPalette = true;
            palette.Clear();
            palette.Mode = PaletteMode.Custom;
            palette.Add(0, Color.Green);
            palette.Add(10, Color.Yellow);
            palette.Add(20, Color.Red);

            m_FloatBar.Palette = palette;

            // apply layout
            ConfigureStandardLayout(m_Chart, title, null);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

            SmoothPaletteCheckBox.IsChecked = true;
            Enable3DCheckBox.IsChecked = true;
		}
        private void GenerateYValues(int nCount)
        {
            NChart chart = nChartControl1.Charts[0];
            NSeries series = (NSeries)chart.Series[0];

            series.Values.Clear();

            for (int i = 0; i < nCount; i++)
            {
                series.Values.Add(5 + Random.NextDouble() * 10);
            }
        }
        private void GenerateXValues(int nCount)
        {
            NChart chart = nChartControl1.Charts[0];
            NXYScatterSeries series = (NXYScatterSeries)chart.Series[0];

            series.XValues.Clear();

            double x = 120;

            for (int i = 0; i < nCount; i++)
            {
                x += 10 + Random.NextDouble() * 10;

                series.XValues.Add(x);
            }
        }

        private void InvertAxisCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.Invert = (bool)InvertAxisCheckBox.IsChecked;
            nChartControl1.Refresh();
        }

        private void SmoothPaletteCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            m_FloatBar.Palette.SmoothPalette = (bool)SmoothPaletteCheckBox.IsChecked;
            nChartControl1.Refresh();
        }

        private void Enable3DCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            m_Chart.Enable3D = (bool)Enable3DCheckBox.IsChecked;
            nChartControl1.Refresh();
        }
	}
}
