using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NStandardFunnel2DUC : NExampleBaseUC
	{
		public NStandardFunnel2DUC()
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
				return "Funnel 2D";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a standard 2D Funnel Chart. Use the controls to  modify different parameters of the funnel like radius, neck width, neckheight and gap size. You can also change the placement of the funnel data point labels.";
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
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			NLegend legend = nChartControl1.Legends[0];
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.BottomRight);

			NFunnelChart chart = new NFunnelChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(chart);

			NFunnelSeries funnel = (NFunnelSeries)chart.Series.Add(SeriesType.Funnel);
			funnel.BorderStyle.Color = Color.LemonChiffon;
			funnel.Legend.DisplayOnLegend = legend;
			funnel.Legend.Mode = SeriesLegendMode.DataPoints;
			funnel.DataLabelStyle.Format = "<percent>";
			funnel.ShadowStyle.Type = ShadowType.GaussianBlur;
			funnel.ShadowStyle.Color = Color.FromArgb(50, 0, 0, 0);
			funnel.ShadowStyle.Offset = new NPointL(5, 5);
			funnel.ShadowStyle.FadeLength = new NLength(6);

			funnel.Values.Add(20.0);
			funnel.Values.Add(10.0);
			funnel.Values.Add(15.0);
			funnel.Values.Add(7.0);
			funnel.Values.Add(28.0);

			funnel.Labels.Add("Awareness");
			funnel.Labels.Add("First Hear");
			funnel.Labels.Add("Further Learn");
			funnel.Labels.Add("Liking");
			funnel.Labels.Add("Decision");

			// apply palette to funnel segments
			NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Fresh);
			for (int i = 0; i < funnel.Values.Count; i++)
			{
				funnel.FillStyles[i] = new NColorFillStyle(palette.SeriesColors[i % palette.SeriesColors.Count]);
			}

			// init form controls
			NExampleHelpers.FillComboWithEnumValues(FunnelLabelModeComboBox, typeof(FunnelLabelMode));
			FunnelLabelModeComboBox.SelectedIndex = 0;

			FunnelPointGapScrollBar.Value = funnel.FunnelPointGap / 100.0f;
			NeckWidthScrollBar.Value = funnel.NeckWidthPercent / 100.0f;
			NeckHeightScrollBar.Value = funnel.NeckHeightPercent / 100.0f;
			LabelArrowLengthScrollBar.Value = funnel.DataLabelStyle.ArrowLength.Value / 100.0f;
		}

		private void FunnelPointGapScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			NFunnelSeries funnel = (NFunnelSeries)nChartControl1.Charts[0].Series[0];

			funnel.FunnelPointGap = (float)FunnelPointGapScrollBar.Value * 100.0f;

			nChartControl1.Refresh();
		}

		private void NeckWidthScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			NFunnelSeries funnel = (NFunnelSeries)nChartControl1.Charts[0].Series[0];

			funnel.NeckWidthPercent = (float)NeckWidthScrollBar.Value * 100.0f;

			nChartControl1.Refresh();
		}

		private void NeckHeightScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			NFunnelSeries funnel = (NFunnelSeries)nChartControl1.Charts[0].Series[0];

			funnel.NeckHeightPercent = (float)NeckHeightScrollBar.Value * 100.0f;

			nChartControl1.Refresh();
		}

		private void FunnelLabelModeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NFunnelSeries funnel = (NFunnelSeries)nChartControl1.Charts[0].Series[0];

			funnel.LabelMode = (FunnelLabelMode)FunnelLabelModeComboBox.SelectedIndex;

			HorzAlign ha = HorzAlign.Center;

			switch (funnel.LabelMode)
			{
				case FunnelLabelMode.Left:
				case FunnelLabelMode.LeftAligned:
					ha = HorzAlign.Right;
					break;

				case FunnelLabelMode.Right:
				case FunnelLabelMode.RightAligned:
					ha = HorzAlign.Left;
					break;
			}

			funnel.DataLabelStyle.TextStyle.StringFormatStyle.HorzAlign = ha;

			nChartControl1.Refresh();
		}

		private void LabelArrowLengthScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			NFunnelSeries funnel = (NFunnelSeries)nChartControl1.Charts[0].Series[0];

			funnel.DataLabelStyle.ArrowLength = new NLength((float)LabelArrowLengthScrollBar.Value * 100.0f, NRelativeUnit.ParentPercentage);

			nChartControl1.Refresh();
		}
	}
}
