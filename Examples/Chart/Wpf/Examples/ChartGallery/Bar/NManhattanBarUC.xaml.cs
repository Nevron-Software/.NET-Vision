using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using System.Drawing;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NManhattanBarUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBarSeries m_Bar1;
		private NBarSeries m_Bar2;
		private NBarSeries m_Bar3;
		private NBarSeries m_Bar4;
		private const int m_nBarsCount = 7;

		public NManhattanBarUC()
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
				return "Manhattan Bar";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a Manhattan bar chart. This type of chart is created with several bar series displayed with MultiBarMode set to Series.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Manhattan Bar Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.Width = 60;
			m_Chart.Height = 25;
			m_Chart.Depth = 45;
			m_Chart.BoundsMode = BoundsMode.Fit;
			m_Chart.ContentAlignment = ContentAlignment.BottomRight;
			m_Chart.Location = new NPointL(new NLength(15, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(new NLength(70, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));

			// apply predefined projection and lighting
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight);

			// add axis labels
			NOrdinalScaleConfigurator ordinalScale = m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator as NOrdinalScaleConfigurator;
			ordinalScale.AutoLabels = false;
			ordinalScale.Labels.Add("Miami");
			ordinalScale.Labels.Add("Chicago");
			ordinalScale.Labels.Add("Los Angeles");
			ordinalScale.Labels.Add("New York");
			ordinalScale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);

			ordinalScale = m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

			// add interlace stripe to the Y axis
			NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			// add the first bar
			m_Bar1 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar1.MultiBarMode = MultiBarMode.Series;
			m_Bar1.Name = "Bar1";
			m_Bar1.DataLabelStyle.Visible = false;
			m_Bar1.BorderStyle.Color = Color.FromArgb(210, 210, 255);

			// add the second bar
			m_Bar2 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar2.MultiBarMode = MultiBarMode.Series;
			m_Bar2.Name = "Bar2";
			m_Bar2.DataLabelStyle.Visible = false;
			m_Bar2.BorderStyle.Color = Color.FromArgb(210, 255, 210);

			// add the third bar
			m_Bar3 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar3.MultiBarMode = MultiBarMode.Series;
			m_Bar3.Name = "Bar3";
			m_Bar3.DataLabelStyle.Visible = false;
			m_Bar3.BorderStyle.Color = Color.FromArgb(255, 255, 210);

			// add the second bar
			m_Bar4 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar4.MultiBarMode = MultiBarMode.Series;
			m_Bar4.Name = "Bar4";
			m_Bar4.DataLabelStyle.Visible = false;
			m_Bar4.BorderStyle.Color = Color.FromArgb(255, 210, 210);

			// fill with random data
			m_Bar1.Values.FillRandomRange(Random, m_nBarsCount, 10, 40);
			m_Bar2.Values.FillRandomRange(Random, m_nBarsCount, 30, 60);
			m_Bar3.Values.FillRandomRange(Random, m_nBarsCount, 50, 80);
			m_Bar4.Values.FillRandomRange(Random, m_nBarsCount, 70, 100);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);
		}

		private void PositiveDataButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			m_Bar1.Values.FillRandomRange(Random, m_nBarsCount, 10, 100);
			m_Bar2.Values.FillRandomRange(Random, m_nBarsCount, 10, 100);
			m_Bar3.Values.FillRandomRange(Random, m_nBarsCount, 10, 100);
			m_Bar4.Values.FillRandomRange(Random, m_nBarsCount, 10, 100);
			nChartControl1.Refresh();
		}

		private void PositiveAndNegativeDataButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			m_Bar1.Values.FillRandomRange(Random, m_nBarsCount, -100, 100);
			m_Bar2.Values.FillRandomRange(Random, m_nBarsCount, -100, 100);
			m_Bar3.Values.FillRandomRange(Random, m_nBarsCount, -100, 100);
			m_Bar4.Values.FillRandomRange(Random, m_nBarsCount, -100, 100);
			nChartControl1.Refresh();
		}
	}
}
