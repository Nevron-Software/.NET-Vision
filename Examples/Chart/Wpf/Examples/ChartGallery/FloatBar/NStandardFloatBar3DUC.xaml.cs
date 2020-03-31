using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NStandardFloatBar3DUC : NExampleBaseUC
	{
		public NStandardFloatBar3DUC()
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
				return "Floating Bar 3D";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a standard 3D Float Bar chart.\r\n" +
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
			NLabel title = nChartControl1.Labels.AddHeader("3D Floating Bars");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 65;
			chart.Height = 40;
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.SoftTopLeft);

			// setup X axis
			NOrdinalScaleConfigurator scaleX = chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			scaleX.AutoLabels = false;
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount;
			scaleX.DisplayDataPointsBetweenTicks = false;
			for (int i = 0; i < monthLetters.Length; i++)
			{
				scaleX.CustomLabels.Add(new NCustomValueLabel(i, monthLetters[i]));
			}

			// add interlaced stripe to the Y axis
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };
			stripStyle.Interlaced = true;
			linearScale.StripStyles.Add(stripStyle);

			// create the float bar series
			NFloatBarSeries floatBar = (NFloatBarSeries)chart.Series.Add(SeriesType.FloatBar);
			floatBar.DataLabelStyle.Visible = false;
			floatBar.DataLabelStyle.VertAlign = VertAlign.Center;
			floatBar.DataLabelStyle.Format = "<begin> - <end>";

			// add bars
			floatBar.AddDataPoint(new NFloatBarDataPoint(2, 10));
			floatBar.AddDataPoint(new NFloatBarDataPoint(5, 16));
			floatBar.AddDataPoint(new NFloatBarDataPoint(9, 17));
			floatBar.AddDataPoint(new NFloatBarDataPoint(12, 21));
			floatBar.AddDataPoint(new NFloatBarDataPoint(8, 18));
			floatBar.AddDataPoint(new NFloatBarDataPoint(7, 18));
			floatBar.AddDataPoint(new NFloatBarDataPoint(3, 11));
			floatBar.AddDataPoint(new NFloatBarDataPoint(5, 12));
			floatBar.AddDataPoint(new NFloatBarDataPoint(8, 17));
			floatBar.AddDataPoint(new NFloatBarDataPoint(6, 15));
			floatBar.AddDataPoint(new NFloatBarDataPoint(3, 10));
			floatBar.AddDataPoint(new NFloatBarDataPoint(1, 7));

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// enable the trackball
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// init form controls
			NExampleHelpers.FillComboWithEnumValues(BarShapeComboBox, typeof(BarShape));
			BarShapeComboBox.SelectedIndex = 0;

			DepthPercentScrollBar.Value = floatBar.DepthPercent / 100.0f;
			WidthPercentScrollBar.Value = floatBar.WidthPercent / 100.0f;
		}

		private void BarShapeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NFloatBarSeries floatBar = (NFloatBarSeries)nChartControl1.Charts[0].Series[0];
			floatBar.BarShape = (BarShape)BarShapeComboBox.SelectedIndex;
			nChartControl1.Refresh();
		}

		private void WidthPercentScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			NFloatBarSeries floatBar = (NFloatBarSeries)nChartControl1.Charts[0].Series[0];
			floatBar.WidthPercent = (float)WidthPercentScrollBar.Value * 100.0f;
			nChartControl1.Refresh();
		}

		private void DepthPercentScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			NFloatBarSeries floatBar = (NFloatBarSeries)nChartControl1.Charts[0].Series[0];
			floatBar.DepthPercent = (float)DepthPercentScrollBar.Value * 100.0f;
			nChartControl1.Refresh();
		}

		private void ShowDataLabelsCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];
			series.DataLabelStyle.Visible = (bool)ShowDataLabelsCheckBox.IsChecked;
			nChartControl1.Refresh();
		}
	}
}
