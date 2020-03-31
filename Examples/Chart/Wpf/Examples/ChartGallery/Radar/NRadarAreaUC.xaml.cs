using Nevron.Chart;
using Nevron.GraphicsCore;
using System.Drawing;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NRadarAreaUC : NExampleBaseUC
	{
		private NRadarChart m_Chart;
		private NRadarSeries m_RadarArea1;
		private NRadarSeries m_RadarArea2;

		public NRadarAreaUC()
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
				return "Radar Area";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return	"The example demonstrates a Radar Area chart.\r\n" + 
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
			NLabel title = nChartControl1.Labels.AddHeader("Radar Area");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// configure the chart
			m_Chart = new NRadarChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(m_Chart);
			m_Chart.Wall(ChartWallType.Radar).BorderStyle.Color = Color.White;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			m_Chart.DisplayOnLegend = nChartControl1.Legends[0];

			AddAxis("Vitamin A");
			AddAxis("Vitamin B1");
			AddAxis("Vitamin B2");
			AddAxis("Vitamin B6");
			AddAxis("Vitamin B12");
			AddAxis("Vitamin C");
			AddAxis("Vitamin D");
			AddAxis("Vitamin E");

			// create the radar series
			m_RadarArea1 = new NRadarAreaSeries();
			m_Chart.Series.Add(m_RadarArea1);
			m_RadarArea1.Name = "Series 1";
			m_RadarArea1.Values.FillRandomRange(Random, 8, 50, 90);
			m_RadarArea1.DataLabelStyle.Visible = false;
			m_RadarArea1.DataLabelStyle.Format = "<value>";
			m_RadarArea1.MarkerStyle.AutoDepth = true;
			m_RadarArea1.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			m_RadarArea1.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);

			m_RadarArea2 = new NRadarAreaSeries();
			m_Chart.Series.Add(m_RadarArea2);
			m_RadarArea2.Name = "Series 2";
			m_RadarArea2.Values.FillRandomRange(Random, 8, 0, 100);
			m_RadarArea2.DataLabelStyle.Visible = false;
			m_RadarArea2.DataLabelStyle.Format = "<value>";
			m_RadarArea2.MarkerStyle.AutoDepth = true;
			m_RadarArea2.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			m_RadarArea2.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Bright);
			styleSheet.Apply(nChartControl1.Charts[0].Series);

			m_RadarArea1.FillStyle.SetTransparencyPercent(50);
			m_RadarArea2.FillStyle.SetTransparencyPercent(60);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

			// init form controls
			BeginAngleScrollBar.Value = 90 / 360.0;
			NExampleHelpers.FillComboWithEnumValues(TitleAngleModeComboBox, typeof(ScaleLabelAngleMode));
			TitleAngleModeComboBox.SelectedIndex = (int)ScaleLabelAngleMode.Scale;
		}

		private void AddAxis(string title)
		{
			NRadarAxis axis = new NRadarAxis();

			// set title
			axis.Title = title;

			// setup scale
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)axis.ScaleConfigurator;

			linearScale.RulerStyle.BorderStyle.Color = Color.Silver;
			linearScale.InnerMajorTickStyle.LineStyle.Color = Color.Silver;
			linearScale.OuterMajorTickStyle.LineStyle.Color = Color.Silver;
			linearScale.InnerMajorTickStyle.Length = new NLength(2, NGraphicsUnit.Point);
			linearScale.OuterMajorTickStyle.Length = new NLength(2, NGraphicsUnit.Point);

			if (m_Chart.Axes.Count == 0)
			{
				// if the first axis then configure grid style and stripes
				linearScale.MajorGridStyle.LineStyle.Color = Color.Gainsboro;
				linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
				linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Radar, true);

				// add interlaced stripe
				NScaleStripStyle strip = new NScaleStripStyle();
				strip.FillStyle = new NColorFillStyle(Color.FromArgb(64, 200, 200, 200));
				strip.Interlaced = true;
				strip.SetShowAtWall(ChartWallType.Radar, true);
				linearScale.StripStyles.Add(strip);
			}
			else
			{
				// hide labels
				linearScale.AutoLabels = false;
			}

			m_Chart.Axes.Add(axis);
		}

		private void UpdateTitleLabels()
		{
			ScaleLabelAngleMode mode = (ScaleLabelAngleMode)TitleAngleModeComboBox.SelectedIndex;
			float angle = (float)TitleAngleScrollBar.Value * 360.0f;

			for (int i = 0; i < m_Chart.Axes.Count; i++)
			{
				NRadarAxis axis = (NRadarAxis)m_Chart.Axes[i];
				axis.TitleAngle = new NScaleLabelAngle(mode, angle);
			}

			nChartControl1.Refresh();
		}

		private void BeginAngleScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			m_Chart.BeginAngle = (float)BeginAngleScrollBar.Value * 360.0f;
			nChartControl1.Refresh();
		}

		private void TitleAngleScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			UpdateTitleLabels();
		}

		private void TitleAngleModeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			UpdateTitleLabels();
		}
	}
}
