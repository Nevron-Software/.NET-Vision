using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using System.Drawing;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NShapeUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NShapeSeries m_Shape;

		public NShapeUC()
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
				return "Shape";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates general Shape Series functionality.\r\n" +	
						"The Shape Series is a versatile series which lets you display different shapes with user defined centers and dimensions.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Shape Series");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			m_Chart.Projection.Elevation -= 10;
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			m_Chart.Depth = 55.0f;
			m_Chart.Width = 55.0f;
			m_Chart.Height = 55.0f;

			// setup X axis
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Floor };
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// setup Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// add interlaced stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };
			stripStyle.Interlaced = true;
			scaleY.StripStyles.Add(stripStyle);

			// setup Z axis
			NLinearScaleConfigurator scaleZ = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ;
			scaleZ.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Left, ChartWallType.Floor };
			scaleZ.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// setup shape series
			m_Shape = (NShapeSeries)m_Chart.Series.Add(SeriesType.Shape);
			m_Shape.FillStyle = new NColorFillStyle(Color.Red);
			m_Shape.BorderStyle.Color = Color.DarkRed;
			m_Shape.DataLabelStyle.Visible = false;
			m_Shape.UseXValues = true;
			m_Shape.UseZValues = true;

			// populate with random data
			m_Shape.Values.FillRandomRange(Random, 10, -100, 100);
			m_Shape.XValues.FillRandomRange(Random, 10, -100, 100);
			m_Shape.ZValues.FillRandomRange(Random, 10, -100, 100);

			m_Shape.YSizes.FillRandomRange(Random, 10, 5, 20);
			m_Shape.XSizes.FillRandomRange(Random, 10, 5, 20);
			m_Shape.ZSizes.FillRandomRange(Random, 10, 5, 20);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);

			// configure interactivity
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// init form controls
			NExampleHelpers.FillComboWithEnumValues(ShapeComboBox, typeof(BarShape));
			ShapeComboBox.SelectedIndex = 0;
			UseXValuesCheckBox.IsChecked = true;
			UseZValuesCheckBox.IsChecked = true;
			DifferentColorsCheckBox.IsChecked = true;

			DifferentColorsCheckBox_Checked(null, null);
		}

		private void UseXValuesCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			m_Shape.UseXValues = (bool)UseXValuesCheckBox.IsChecked;
			nChartControl1.Refresh();
		}

		private void UseZValuesCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			m_Shape.UseZValues = (bool)UseZValuesCheckBox.IsChecked;
			nChartControl1.Refresh();
		}

		private void DifferentColorsCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			if ((bool)DifferentColorsCheckBox.IsChecked)
			{
				// apply style sheet
				NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
				styleSheet.Apply(nChartControl1.Document);
			}
			else
			{
				// apply style sheet
				NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
				styleSheet.Apply(nChartControl1.Document);
			}

			nChartControl1.Refresh();
		}

		private void ShapeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			m_Shape.Shape = (BarShape)ShapeComboBox.SelectedIndex;
			nChartControl1.Refresh();
		}
	}
}
