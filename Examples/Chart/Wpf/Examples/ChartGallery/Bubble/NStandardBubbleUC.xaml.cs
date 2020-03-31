using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NStandardBubbleUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBubbleSeries m_Bubble;

		public NStandardBubbleUC()
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
				return "Bubble";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a standard Bubble chart with controllable shape, size and styling of the bubbles.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("2D Bubble Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// add interlace stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			NOrdinalScaleConfigurator ordinalScale = m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			ordinalScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

			// add a bubble series
			m_Bubble = (NBubbleSeries)m_Chart.Series.Add(SeriesType.Bubble);
			m_Bubble.DataLabelStyle.VertAlign = VertAlign.Center;
			m_Bubble.DataLabelStyle.Visible = false;
			m_Bubble.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Bubble.MinSize = new NLength(7.0f, NRelativeUnit.ParentPercentage);
			m_Bubble.MaxSize = new NLength(16.0f, NRelativeUnit.ParentPercentage);

			m_Bubble.AddDataPoint(new NBubbleDataPoint(10, 10, "Company 1"));
			m_Bubble.AddDataPoint(new NBubbleDataPoint(15, 20, "Company 2"));
			m_Bubble.AddDataPoint(new NBubbleDataPoint(12, 25, "Company 3"));
			m_Bubble.AddDataPoint(new NBubbleDataPoint(8, 15, "Company 4"));
			m_Bubble.AddDataPoint(new NBubbleDataPoint(14, 17, "Company 5"));
			m_Bubble.AddDataPoint(new NBubbleDataPoint(11, 12, "Company 6"));

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// init form controls
			NExampleHelpers.FillComboWithEnumValues(BubbleShapeComboBox, typeof(PointShape));
			BubbleShapeComboBox.SelectedIndex = 6;

			LegendFormatComboBox.Items.Add("Value and Label");
			LegendFormatComboBox.Items.Add("Value");
			LegendFormatComboBox.Items.Add("Label");
			LegendFormatComboBox.Items.Add("Size");
			LegendFormatComboBox.SelectedIndex = 2;

			InflateMarginsCheckBox.IsChecked = true;
			DifferentColorsCheckBox.IsChecked = true;

			MaxBubbleSizeScrollBar.Value = m_Bubble.MaxSize.Value / 100.0f;
			MinBubbleSizeScrollBar.Value = m_Bubble.MinSize.Value / 100.0f;

			InflateMarginsCheckBox_Checked(null, null);
			DifferentColorsCheckBox_Checked(null, null);
		}

		private void BubbleShapeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_Bubble.BubbleShape = (PointShape)BubbleShapeComboBox.SelectedIndex;
			nChartControl1.Refresh();
		}

		private void MinBubbleSizeScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			if (nChartControl1 == null)
				return;

			m_Bubble.MinSize = new NLength((float)MinBubbleSizeScrollBar.Value * 100.0f, NRelativeUnit.ParentPercentage);
			nChartControl1.Refresh();
		}

		private void MaxBubbleSizeScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			if (nChartControl1 == null)
				return;

			m_Bubble.MaxSize = new NLength((float)MaxBubbleSizeScrollBar.Value * 100.0f, NRelativeUnit.ParentPercentage);
			nChartControl1.Refresh();
		}

		private void LegendFormatComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (nChartControl1 == null)
				return;

			string sFormat = "";
			switch (LegendFormatComboBox.SelectedIndex)
			{
				case 0:
					sFormat = "<value> <label>";
					break;
				case 1:
					sFormat = "<value>";
					break;
				case 2:
					sFormat = "<label>";
					break;
				case 3:
					sFormat = "<size>";
					break;
			}
			m_Bubble.Legend.Format = sFormat;
			nChartControl1.Refresh();
		}

		private void InflateMarginsCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_Bubble.InflateMargins = (bool)InflateMarginsCheckBox.IsChecked;
			nChartControl1.Refresh();
		}

		private void InvertYAxisCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			if (nChartControl1 == null)
				return;

			NStandardScaleConfigurator scaleConfigurator = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleConfigurator.Invert = (bool)InvertYAxisCheckBox.IsChecked;

			nChartControl1.Refresh();
		}

		private void DifferentColorsCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			if (nChartControl1 == null)
				return;

			if ((bool)DifferentColorsCheckBox.IsChecked)
			{
				NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
				styleSheet.Apply(nChartControl1.Document);
			}
			else
			{
				NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
				styleSheet.Apply(nChartControl1.Document);
			}

			nChartControl1.Refresh();
		}

		private void Enable3DCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			m_Chart.Enable3D = (bool)Enable3DCheckBox.IsChecked;
			if (m_Chart.Enable3D)
			{
				m_Chart.BoundsMode = GraphicsCore.BoundsMode.Fit;
			}
			else
			{
				m_Chart.BoundsMode = GraphicsCore.BoundsMode.Stretch;
			}

			nChartControl1.Refresh();
		}
	}
}
