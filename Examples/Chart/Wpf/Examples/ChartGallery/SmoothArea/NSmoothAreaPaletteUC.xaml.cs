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
	public partial class NSmoothAreaPaletteUC : NExampleBaseUC
	{
        private NChart m_Chart;
        private NSmoothAreaSeries m_SmoothArea;

		public NSmoothAreaPaletteUC()
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
				return "Smooth Area Palette";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
                return "This example demonstrates how to apply palette to a smooth area series.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Smooth Area Palette");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

            // no legends
            nChartControl1.Legends.Clear();

            // setup chart
            m_Chart = nChartControl1.Charts[0];
            m_Chart.Enable3D = true;
            m_Chart.Width = 65;
            m_Chart.Height = 40;
            m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective);
            m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
            m_Chart.Axis(StandardAxis.Depth).Visible = false;

            // setup axes
            NLinearScaleConfigurator linearScaleX = new NLinearScaleConfigurator();
            m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleX;

            NLinearScaleConfigurator linearScaleY = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
            linearScaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
            linearScaleY.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

            // add interlaced stripe
            NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScaleY.StripStyles.Add(stripStyle);

            // add the area series
            m_SmoothArea = new NSmoothAreaSeries();
            m_Chart.Series.Add(m_SmoothArea);

            m_SmoothArea.DataLabelStyle.Visible = false;
            m_SmoothArea.MarkerStyle.Visible = false;
            m_SmoothArea.UseXValues = true;

            NPalette palette = new NPalette();
            palette.Clear();
            palette.Mode = PaletteMode.Custom;
            palette.Add(0, Color.Green);
            palette.Add(5, Color.Yellow);
            palette.Add(10, Color.Red);

            m_SmoothArea.Palette = palette;

            int nValuesCount = 6;

            GenerateYValues(nValuesCount);
            GenerateXValues(nValuesCount);

            // apply layout
            ConfigureStandardLayout(m_Chart, title, null);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);
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
            m_SmoothArea.Palette.SmoothPalette = (bool)SmoothPaletteCheckBox.IsChecked;
            nChartControl1.Refresh();
        }

        private void Enable3DCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            m_Chart.Enable3D = (bool)Enable3DCheckBox.IsChecked;
            nChartControl1.Refresh();
        }
	}
}
