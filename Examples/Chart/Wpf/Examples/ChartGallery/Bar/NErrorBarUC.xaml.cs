using Nevron.Chart;
using Nevron.GraphicsCore;
using System.Drawing;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NErrorBarUC : NExampleBaseUC
	{
		NBarSeries m_BarSeries;
		NChart m_Chart;

		public NErrorBarUC()
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
				return "Error Bar";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "The example shows how to add errors bars to the standard bar series.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// create a title
			NLabel title = new NLabel("Error Bar Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// configure chart
			NChart chart = nChartControl1.Charts[0];
			m_Chart = chart;
			chart.Axis(StandardAxis.Depth).Visible = false;

			// add interlace stripe
			NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			// setup a bar series
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Name = "Bar Series";
			bar.DataLabelStyle.Visible = false;
			bar.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			bar.ShadowStyle.Type = ShadowType.GaussianBlur;
			bar.ShadowStyle.Offset = new NPointL(2, 2);
			bar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0);
			bar.ShadowStyle.FadeLength = new NLength(5);
			bar.HasBottomEdge = false;

			// add some data to the bar series
			bar.Values.Add(15);
			bar.UpperErrors.Add(2);
			bar.LowerErrors.Add(1);

			bar.Values.Add(21);
			bar.UpperErrors.Add(2.4);
			bar.LowerErrors.Add(1.3);

			bar.Values.Add(23);
			bar.UpperErrors.Add(3.2);
			bar.LowerErrors.Add(1.7);

			bar.Values.Add(27);
			bar.UpperErrors.Add(1.4);
			bar.LowerErrors.Add(2.5);

			bar.Values.Add(29);
			bar.UpperErrors.Add(4.0);
			bar.LowerErrors.Add(2.0);

			bar.Values.Add(26);
			bar.UpperErrors.Add(2.1);
			bar.LowerErrors.Add(1.6);

			m_BarSeries = bar;
			m_BarSeries.ShowUpperError = true;
			m_BarSeries.ShowLowerError = true;

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			ShowUpperErrorCheckBox.IsChecked = true;
			ShowLowerErrorCheckBox.IsChecked = true;
		}

		private void ShowUpperErrorCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			m_BarSeries.ShowUpperError = ShowUpperErrorCheckBox.IsChecked.Value;
			nChartControl1.Refresh();
		}
		private void ShowLowerErrorCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			m_BarSeries.ShowLowerError = ShowLowerErrorCheckBox.IsChecked.Value;
			nChartControl1.Refresh();
		}
		private void Enable3DCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			m_Chart.Enable3D = Enable3DCheckBox.IsChecked.Value;
			nChartControl1.Refresh();
		}
	}
}
