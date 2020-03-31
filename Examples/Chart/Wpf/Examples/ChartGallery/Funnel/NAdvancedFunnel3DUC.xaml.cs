using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.Dom;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NAdvancedFunnel3DUC : NExampleBaseUC
	{
		public NAdvancedFunnel3DUC()
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
				return "Advanced Funnel 3D";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a 2D Funnel Chart with custom X sizes of the funnel data items. ";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("3D Funnel Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			NLegend legend = nChartControl1.Legends[0];
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.BottomRight);

			NFunnelChart chart = new NFunnelChart();
			chart.Enable3D = true;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight);
			chart.Projection.Elevation = 15;

			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(chart);

			NFunnelSeries funnel = (NFunnelSeries)chart.Series.Add(SeriesType.Funnel);
			funnel.BorderStyle.Color = Color.LemonChiffon;
			funnel.Legend.DisplayOnLegend = legend;
			funnel.Legend.Format = "<percent>";
			funnel.Legend.Mode = SeriesLegendMode.DataPoints;
			funnel.DataLabelStyle.Format = "<value> [<xsize>]";
			funnel.UseXSizes = true;
			funnel.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			funnel.XSizes.ValueFormatter = new NNumericValueFormatter("0.00");

			GenerateData(funnel);
		}

		private void GenerateData(NFunnelSeries funnel)
		{
			funnel.ClearDataPoints();

			double dSizeX = 100;

			NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Fresh);
			for (int i = 0; i < 10; i++)
			{
				funnel.Values.Add(Random.NextDouble() + 1);
				funnel.XSizes.Add(dSizeX);
				funnel.FillStyles[i] = new NColorFillStyle(palette.SeriesColors[i % palette.SeriesColors.Count]);

				dSizeX -= Random.NextDouble() * 9;
			}

			funnel.Values.Add(0.0);
			funnel.XSizes.Add(dSizeX);
		}

		private void GenerateDataButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			NFunnelSeries funnel = (NFunnelSeries)nChartControl1.Charts[0].Series[0];

			GenerateData(funnel);

			nChartControl1.Refresh();
		}
	}
}
