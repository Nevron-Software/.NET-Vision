using Nevron.Chart;
using Nevron.Dom;
using Nevron.GraphicsCore;
using System.Drawing;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NStackedRadarAreaUC : NExampleBaseUC
	{
		private NRadarChart m_Chart;

		public NStackedRadarAreaUC()
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
				return "Stacked Radar Area";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "The example demonstrates a Stacked Radar Area chart. Use the \"Stack Mode\" combo to switch between Regular Stack and Percent Stack mode.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Stacked Radar Area");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// configure the chart
			m_Chart = new NRadarChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(m_Chart);
			m_Chart.Wall(ChartWallType.Radar).BorderStyle.Color = Color.White;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			m_Chart.DisplayOnLegend = nChartControl1.Legends[0];

			AddAxis("Category A");
			AddAxis("Category B");
			AddAxis("Category C");
			AddAxis("Category D");
			AddAxis("Category E");

			// create the radar series
			NRadarAreaSeries radarArea0 = new NRadarAreaSeries();
			m_Chart.Series.Add(radarArea0);
			radarArea0.Name = "Series 1";
			radarArea0.Values.FillRandomRange(Random, 5, 50, 90);
			radarArea0.DataLabelStyle.Visible = false;
			radarArea0.DataLabelStyle.Format = "<value>";
			radarArea0.MarkerStyle.AutoDepth = true;
			radarArea0.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			radarArea0.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);

			NRadarAreaSeries radarArea1 = new NRadarAreaSeries();
			m_Chart.Series.Add(radarArea1);
			radarArea1.Name = "Series 2";
			radarArea1.Values.FillRandomRange(Random, 5, 0, 100);
			radarArea1.DataLabelStyle.Visible = false;
			radarArea1.DataLabelStyle.Format = "<value>";
			radarArea1.MarkerStyle.AutoDepth = true;
			radarArea1.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			radarArea1.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			// stack the second radar area series
			radarArea1.MultiAreaMode = MultiAreaMode.Stacked;

			NRadarAreaSeries radarArea2 = new NRadarAreaSeries();
			m_Chart.Series.Add(radarArea2);
			radarArea2.Name = "Series 3";
			radarArea2.Values.FillRandomRange(Random, 5, 0, 100);
			radarArea2.DataLabelStyle.Visible = false;
			radarArea2.DataLabelStyle.Format = "<value>";
			radarArea2.MarkerStyle.AutoDepth = true;
			radarArea2.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			radarArea2.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			// stack the third radar area series
			radarArea2.MultiAreaMode = MultiAreaMode.Stacked;

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Bright);
			styleSheet.Apply(nChartControl1.Charts[0].Series);

			radarArea0.FillStyle.SetTransparencyPercent(20);
			radarArea1.FillStyle.SetTransparencyPercent(20);
			radarArea2.FillStyle.SetTransparencyPercent(20);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

			// init form controls
			BeginAngleScrollBar.Value = 90 / 360.0;
			NExampleHelpers.FillComboWithEnumValues(TitleAngleModeComboBox, typeof(ScaleLabelAngleMode));
			TitleAngleModeComboBox.SelectedIndex = (int)ScaleLabelAngleMode.Scale;

			StackModeComboBox.Items.Add("Stacked");
			StackModeComboBox.Items.Add("Stacked %");
			StackModeComboBox.SelectedIndex = 0;
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

		private void StackModeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NRadarChart chart = (NRadarChart)nChartControl1.Charts[0];
			NRadarAreaSeries series1 = (NRadarAreaSeries)chart.Series[1];
			NRadarAreaSeries series2 = (NRadarAreaSeries)chart.Series[2];
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.Radar).ScaleConfigurator;

			switch (StackModeComboBox.SelectedIndex)
			{
				case 0:
					series1.MultiAreaMode = MultiAreaMode.Stacked;
					series2.MultiAreaMode = MultiAreaMode.Stacked;
					scale.LabelValueFormatter = new NNumericValueFormatter(NumericValueFormat.General);
					break;

				case 1:
					series1.MultiAreaMode = MultiAreaMode.StackedPercent;
					series2.MultiAreaMode = MultiAreaMode.StackedPercent;
					scale.LabelValueFormatter = new NNumericValueFormatter(NumericValueFormat.Percentage);
					break;
			}

			nChartControl1.Refresh();
		}
	}
}
