using System;
using Nevron.Chart;
using Nevron.Dom;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NStandardHighLow3DUC : NExampleBaseUC
	{
		public NStandardHighLow3DUC()
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
				return "High Low 3D";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a standard 3D high low chart.\r\n" +
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
			NLabel title = nChartControl1.Labels.AddHeader("3D High Low Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 65;
			chart.Height = 40;
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			NHighLowSeries highLow = (NHighLowSeries)chart.Series.Add(SeriesType.HighLow);
			highLow.Name = "High-Low Series";
			highLow.HighFillStyle = new NColorFillStyle(GreyBlue);
			highLow.LowFillStyle = new NColorFillStyle(DarkOrange);
			highLow.HighBorderStyle = new NStrokeStyle(GreyBlue);
			highLow.LowBorderStyle = new NStrokeStyle(DarkOrange);
			highLow.Legend.Mode = SeriesLegendMode.SeriesLogic;
			highLow.DataLabelStyle.Visible = false;
			highLow.DataLabelStyle.Format = "<high_value>:<low_value>";
			highLow.LowValues.ValueFormatter = new NNumericValueFormatter("0.#");
			highLow.HighValues.ValueFormatter = new NNumericValueFormatter("0.#");

			GenerateData(highLow);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			nChartControl1.Refresh();
		}

		private void GenerateData(NHighLowSeries highLow)
		{
			highLow.ClearDataPoints();
			Random random = new Random();

			for (int i = 0; i < 20; i++)
			{
				double d1 = Math.Log(i + 1) + 0.1 * random.NextDouble();
				double d2 = d1 + Math.Cos(0.33 * i) + 0.1 * random.NextDouble();

				highLow.HighValues.Add(d1);
				highLow.LowValues.Add(d2);
			}
		}

		private void DropLinesCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NHighLowSeries highLow = (NHighLowSeries)nChartControl1.Charts[0].Series[0];

			highLow.DropLines = (bool)DropLinesCheckBox.IsChecked;
			nChartControl1.Refresh();
		}
	}
}
