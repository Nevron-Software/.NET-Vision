using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NXYScatterBubbleUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBubbleSeries m_Bubble;

		public NXYScatterBubbleUC()
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
				return "XY Bubble";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "XY Scatter bubble charts are created by instructing the bubble series to use custom x values for the bubble data points. The X Zxis is in numeric scale mode.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XY Bubble Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// setup chart
			m_Chart = nChartControl1.Charts[0];

			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// add interlace style
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(new NArgbColor(Color.Beige)), null, true, 0, 0, 1, 1);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			stripStyle.Interlaced = true;
			linearScale.StripStyles.Add(stripStyle);

			linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

			m_Bubble = (NBubbleSeries)m_Chart.Series.Add(SeriesType.Bubble);
			m_Bubble.DataLabelStyle.Visible = false;
			m_Bubble.Legend.Format = "<label>";
			m_Bubble.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Bubble.ShadowStyle.Type = ShadowType.Solid;
			m_Bubble.ShadowStyle.Offset = new NPointL(1.2f, 1.2f);
			m_Bubble.ShadowStyle.Color = Color.FromArgb(60, 0, 0, 0);
			m_Bubble.UseXValues = true;

			m_Bubble.AddDataPoint(new NBubbleDataPoint(27, 51, 1147995904, "India"));
			m_Bubble.AddDataPoint(new NBubbleDataPoint(50, 67, 1321851888, "China"));
			m_Bubble.AddDataPoint(new NBubbleDataPoint(76, 22, 109955400, "Mexico"));
			m_Bubble.AddDataPoint(new NBubbleDataPoint(210, 9, 142008838, "Russia"));
			m_Bubble.AddDataPoint(new NBubbleDataPoint(360, 4, 305843000, "USA"));
			m_Bubble.AddDataPoint(new NBubbleDataPoint(470, 5, 33560000, "Canada"));

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
			styleSheet.Apply(nChartControl1.Document);

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

		private void ChangeXValues_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			m_Bubble.XValues.FillRandom(Random, 4);
			m_Bubble.XValues[0] = -10;
			nChartControl1.Refresh();
		}

		private void ChangeYValues_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			m_Bubble.Values.FillRandom(Random, 4);
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
