using System;
using Nevron.Chart;
using Nevron.Dom;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NStandardHighLow2DUC : NExampleBaseUC
	{
		NHighLowSeries m_HighLow;
		NChart m_Chart;

		public NStandardHighLow2DUC()
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
				return "High Low 2D";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a standard 2D high low chart.\r\n" +
						"Use the controls on the right to modify some commonly used properties.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("2D High Low Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			// add a High-Low series
			m_HighLow = (NHighLowSeries)m_Chart.Series.Add(SeriesType.HighLow);
			m_HighLow.Name = "High-Low Series";
			m_HighLow.Legend.Mode = SeriesLegendMode.SeriesLogic;
			m_HighLow.HighFillStyle = new NColorFillStyle(GreyBlue);
			m_HighLow.LowFillStyle = new NColorFillStyle(DarkOrange);
			m_HighLow.DataLabelStyle.Visible = false;
			m_HighLow.DataLabelStyle.Format = "<high_value>:<low_value>";
			m_HighLow.LowValues.ValueFormatter = new NNumericValueFormatter("0.#");
			m_HighLow.HighValues.ValueFormatter = new NNumericValueFormatter("0.#");

			GenerateData();

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			nChartControl1.Refresh();
		}

		private void GenerateData()
		{
			m_HighLow.ClearDataPoints();
			Random random = new Random();

			for (int i = 0; i < 20; i++)
			{
				double d1 = Math.Log(i + 1) + 0.1 * random.NextDouble();
				double d2 = d1 + Math.Cos(0.33 * i) + 0.1 * random.NextDouble();

				m_HighLow.HighValues.Add(d1);
				m_HighLow.LowValues.Add(d2);
			}
		}

		private void DropLinesCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			m_HighLow.DropLines = (bool)DropLinesCheckBox.IsChecked;
			nChartControl1.Refresh();
		}
	}
}
