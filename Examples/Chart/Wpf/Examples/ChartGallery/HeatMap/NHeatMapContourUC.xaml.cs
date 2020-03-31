using System;
using System.Collections.Generic;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.UI;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NHeatMapContourUC : NExampleBaseUC
	{
		NHeatMapSeries m_HeatMap;

		public NHeatMapContourUC()
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
				return "Heat Map Contour";
			}
		}
		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
                return "The example demonstrates the capabilities of the heat map series to render contour lines.";
			}
		}
		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
            NLabel title = new NLabel("Heat Map Contour");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

            NChart chart = nChartControl1.Charts[0];

            chart.BoundsMode = BoundsMode.Stretch;

            // create the heat map 
            m_HeatMap = new NHeatMapSeries();
            chart.Series.Add(m_HeatMap);

            m_HeatMap.Palette.Add(0.0, Color.Purple);
            m_HeatMap.Palette.Add(1.5, Color.MediumSlateBlue);
            m_HeatMap.Palette.Add(3.0, Color.CornflowerBlue);
            m_HeatMap.Palette.Add(4.5, Color.LimeGreen);
            m_HeatMap.Palette.Add(6.0, Color.LightGreen);
            m_HeatMap.Palette.Add(7.5, Color.Yellow);
            m_HeatMap.Palette.Add(9.0, Color.Orange);
            m_HeatMap.Palette.Add(10.5, Color.Red);
            m_HeatMap.XValuesMode = HeatMapValuesMode.OriginAndStep;
            m_HeatMap.YValuesMode = HeatMapValuesMode.OriginAndStep;

            m_HeatMap.ContourDisplayMode = ContourDisplayMode.Contour;
            m_HeatMap.Legend.Mode = SeriesLegendMode.SeriesLogic;
            m_HeatMap.Legend.Format = "<zone_value>";

            GenerateData();

            ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

            // init form controls
            NExampleHelpers.FillComboWithEnumValues(ContourDisplayModeCombo, typeof(ContourDisplayMode));
            NExampleHelpers.FillComboWithEnumValues(ContourColorModeCombo, typeof(ContourColorMode));

            ContourDisplayModeCombo.SelectedIndex = (int)ContourDisplayMode.Contour;
            ContourColorModeCombo.SelectedIndex = (int)ContourColorMode.Uniform;

            ShowFillCheckBox.IsChecked = true;
            SmoothPaletteCheckBox.IsChecked = true;

            UpdateHeatMapSeries();
		}

        private void GenerateData()
        {
            NHeatMapData data = m_HeatMap.Data;

            int GridStepX = 300;
            int GridStepY = 300;
            data.SetGridSize(GridStepX, GridStepY);

            const double dIntervalX = 10.0;
            const double dIntervalZ = 10.0;
            double dIncrementX = (dIntervalX / GridStepX);
            double dIncrementZ = (dIntervalZ / GridStepY);

            double y, x, z;

            z = -(dIntervalZ / 2);

            for (int col = 0; col < GridStepX; col++, z += dIncrementZ)
            {
                x = -(dIntervalX / 2);

                for (int row = 0; row < GridStepY; row++, x += dIncrementX)
                {
                    y = 10 - Math.Sqrt((x * x) + (z * z) + 2);
                    y += 3.0 * Math.Sin(x) * Math.Cos(z);

                    double value = y;

                    data.SetValue(row, col, value);
                }
            }
        }

        private void UpdateHeatMapSeries()
        {
            m_HeatMap.ContourDisplayMode = (ContourDisplayMode)ContourDisplayModeCombo.SelectedIndex;
            m_HeatMap.ContourColorMode = (ContourColorMode)ContourColorModeCombo.SelectedIndex;
            m_HeatMap.ShowFill = (bool)ShowFillCheckBox.IsChecked;
            m_HeatMap.Palette.SmoothPalette = (bool)SmoothPaletteCheckBox.IsChecked;

            if (m_HeatMap.Palette.SmoothPalette)
            {
                m_HeatMap.Legend.Format = "<zone_value>";
            }
            else
            {
                m_HeatMap.Legend.Format = "<zone_begin> - <zone_end>";
            }

            nChartControl1.Refresh();
        }

        private void ContourDisplayModeCombo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            UpdateHeatMapSeries();
        }

        private void ContourColorModeCombo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            UpdateHeatMapSeries();
        }

        private void ShowFillCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdateHeatMapSeries();
        }

        private void SmoothPaletteCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdateHeatMapSeries();
        }
	}
}
