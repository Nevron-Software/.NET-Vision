using System;
using Nevron.Chart;
using Nevron.Dom;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NAdvancedHighLow2DUC : NExampleBaseUC
	{
		NHighLowSeries m_HighLow;
		NChart m_Chart;

		public NAdvancedHighLow2DUC()
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
				return "Advanced High Low";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a High Low chart with custom X positions for the data points.\n You can change the data displayed by the chart by pressing the 'Change Values' and 'Change X Values' buttons.";

			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Advanced High Low Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHalf);
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// create the series
			m_HighLow = (NHighLowSeries)m_Chart.Series.Add(SeriesType.HighLow);
			m_HighLow.Name = "High-Low Series";
			m_HighLow.HighFillStyle = new NColorFillStyle(GreyBlue);
			m_HighLow.LowFillStyle = new NColorFillStyle(DarkOrange);
			m_HighLow.UseXValues = true;
			m_HighLow.DataLabelStyle.Format = "<high_label><low_label>";
			m_HighLow.Legend.Mode = SeriesLegendMode.SeriesLogic;

			// fill with values
			GenerateValuesY(8);
			GenerateValuesX(8);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);
		}
		private void GenerateValuesY(int nCount)
		{
			double dPhase1 = Random.Next(5);
			double dPhase2 = dPhase1 + 1;

			m_HighLow.HighValues.Clear();
			m_HighLow.LowValues.Clear();

			for (int i = 0; i < nCount; i++)
			{
				double d1 = 10 + Math.Sin(dPhase1 + 0.8 * i) + 0.5 * Random.NextDouble();
				double d2 = 10 + Math.Cos(dPhase2 + 0.8 * i) + 0.5 * Random.NextDouble();

				m_HighLow.HighValues.Add(d1);
				m_HighLow.LowValues.Add(d2);
			}
		}
		private void GenerateValuesX(int nCount)
		{
			m_HighLow.XValues.Clear();

			double dValue = (double)Random.Next(100);

			for (int i = 0; i < nCount; i++)
			{
				m_HighLow.XValues.Add(dValue);

				dValue = dValue + Random.Next(5, 10);
			}
		}

		private void ChangeValuesButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			GenerateValuesY(8);

			nChartControl1.Refresh();
		}

		private void ChangeXValuesButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			GenerateValuesX(8);

			nChartControl1.Refresh();
		}
	}
}
