using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.Dom;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NAdvancedFunnel2DUC : NExampleBaseUC
	{
		public NAdvancedFunnel2DUC()
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
				return "Advanced Funnel 2D";
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
			NLabel title = nChartControl1.Labels.AddHeader("2D Funnel Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.ShadowStyle.Offset = new NPointL(1.5f, 1.5f);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			NLegend legend = nChartControl1.Legends[0];
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.BottomRight);

			NFunnelChart chart = new NFunnelChart();
			chart.Location = new NPointL(new NLength(20, NRelativeUnit.ParentPercentage), new NLength(10, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(new NLength(60, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
			chart.BoundsMode = BoundsMode.Stretch;
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(chart);

			// configure funnel series
			NFunnelSeries funnel = (NFunnelSeries)chart.Series.Add(SeriesType.Funnel);
			funnel.BorderStyle.Color = Color.LemonChiffon;
			funnel.Legend.DisplayOnLegend = legend;
			funnel.Legend.Format = "<percent>";
			funnel.Legend.Mode = SeriesLegendMode.DataPoints;
			funnel.DataLabelStyle.Format = "<value> [<xsize>]";
			funnel.UseXSizes = true;
			funnel.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			funnel.XSizes.ValueFormatter = new NNumericValueFormatter("0.00");

			// configure shadow
			funnel.ShadowStyle.Type = ShadowType.GaussianBlur;
			funnel.ShadowStyle.Color = Color.FromArgb(50, 0, 0, 0);
			funnel.ShadowStyle.Offset = new NPointL(5, 5);
			funnel.ShadowStyle.FadeLength = new NLength(6);

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
