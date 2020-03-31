using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NRadarLineUC : NExampleBaseUC
	{
		private NRadarSeries m_Radar1;
		private NRadarSeries m_Radar2;
		private NRadarChart m_Chart;

		public NRadarLineUC()
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
				return "Radar Line";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "The example demonstrates a Radar Line chart\r\n" +
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
			NLabel title = nChartControl1.Labels.AddHeader("Radar Line");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// configure the chart
			m_Chart = new NRadarChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(m_Chart);
			m_Chart.Wall(ChartWallType.Radar).BorderStyle.Color = Color.White;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			m_Chart.DisplayOnLegend = nChartControl1.Legends[0];

			// set some axis labels
			AddAxis("Vitamin A");
			AddAxis("Vitamin B1");
			AddAxis("Vitamin B2");
			AddAxis("Vitamin B6");
			AddAxis("Vitamin B12");
			AddAxis("Vitamin C");
			AddAxis("Vitamin D");
			AddAxis("Vitamin E");

			m_Radar1 = new NRadarLineSeries();
			m_Chart.Series.Add(m_Radar1);
			m_Radar1.Name = "Series 1";
			m_Radar1.Values.FillRandomRange(Random, 8, 50, 90);
			m_Radar1.DataLabelStyle.Visible = false;
			m_Radar1.DataLabelStyle.Format = "<value>";
			m_Radar1.MarkerStyle.Visible = true;
			m_Radar1.MarkerStyle.PointShape = PointShape.Cylinder;
			m_Radar1.MarkerStyle.Width = new NLength(1.6f, NRelativeUnit.ParentPercentage);
			m_Radar1.MarkerStyle.Height = new NLength(1.6f, NRelativeUnit.ParentPercentage);

			m_Radar2 = new NRadarLineSeries();
			m_Chart.Series.Add(m_Radar2);
			m_Radar2.Name = "Series 2";
			m_Radar2.Values.FillRandomRange(Random, 8, 0, 100);
			m_Radar2.DataLabelStyle.Visible = false;
			m_Radar2.DataLabelStyle.Format = "<value>";
			m_Radar2.MarkerStyle.Visible = true;
			m_Radar2.MarkerStyle.PointShape = PointShape.Cylinder;
			m_Radar2.MarkerStyle.Width = new NLength(1.6f, NRelativeUnit.ParentPercentage);
			m_Radar2.MarkerStyle.Height = new NLength(1.6f, NRelativeUnit.ParentPercentage);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Bright);
			styleSheet.Apply(nChartControl1.Charts[0].Series);

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
