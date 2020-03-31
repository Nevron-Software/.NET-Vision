using Nevron.Chart;
using Nevron.GraphicsCore;
using System.Drawing;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NStandardStepLine2DUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NStepLineSeries m_StepLine;

		public NStandardStepLine2DUC()
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
				return "Step Line 2D";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a 2D step line chart. When you check the Inflate Margins check the axis scales are adjusted to fit the entire chart including the series markers. The Left Axis Round to tick check controls whether the left axis should automatically round its min and max values to end on exact ticks.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = new NLabel("2D Step Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;

			// add interlace stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			m_StepLine = (NStepLineSeries)m_Chart.Series.Add(SeriesType.StepLine);
			m_StepLine.Name = "Series 1";
			m_StepLine.BorderStyle.Color = Color.SlateBlue;
			m_StepLine.BorderStyle.Width = new NLength(2);
			m_StepLine.DataLabelStyle.VertAlign = VertAlign.Center;
			m_StepLine.DataLabelStyle.Format = "<value>";
			m_StepLine.DataLabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);
			m_StepLine.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(1.4f, NRelativeUnit.RootPercentage);
			m_StepLine.DataLabelStyle.TextStyle.BackplaneStyle.Visible = false;
			m_StepLine.MarkerStyle.Visible = true;
			m_StepLine.MarkerStyle.PointShape = PointShape.Cylinder;
			m_StepLine.MarkerStyle.BorderStyle.Color = Color.SlateBlue;
			m_StepLine.ShadowStyle.Type = ShadowType.GaussianBlur;
			m_StepLine.ShadowStyle.Offset = new NPointL(3, 3);
			m_StepLine.ShadowStyle.FadeLength = new NLength(5);
			m_StepLine.ShadowStyle.Color = Color.FromArgb(55, 0, 0, 0);
			m_StepLine.Values.FillRandom(Random, 8);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			LeftAxisRoundToTickCheckBox.IsChecked = true;
			InflateMarginsCheckBox.IsChecked = true;
		}

		private void InflateMarginsCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			m_StepLine.InflateMargins = (bool)InflateMarginsCheckBox.IsChecked;
			nChartControl1.Refresh();
		}

		private void LeftAxisRoundToTickCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NStandardScaleConfigurator standardScale = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			standardScale.RoundToTickMax = (bool)LeftAxisRoundToTickCheckBox.IsChecked;
			standardScale.RoundToTickMin = (bool)LeftAxisRoundToTickCheckBox.IsChecked;

			nChartControl1.Refresh();
		}
	}
}
