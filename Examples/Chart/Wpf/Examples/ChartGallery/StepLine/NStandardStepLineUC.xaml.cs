using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NStandardStepLineUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NStepLineSeries m_Line;

		public NStandardStepLineUC()
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
				return "Step Line 3D";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a 3D step line chart.\r\n" +
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
			NLabel title = new NLabel("3D Step Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.Width = 65;
			m_Chart.Height = 40;
			m_Chart.Axis(StandardAxis.Depth).Visible = false;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;

			// add interlace stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			m_Line = (NStepLineSeries)m_Chart.Series.Add(SeriesType.StepLine);
			m_Line.Name = "Series 1";
			m_Line.DepthPercent = 50;
			m_Line.LineSize = 2;
			m_Line.DataLabelStyle.Visible = false;
			m_Line.DataLabelStyle.Format = "<value>";
			m_Line.MarkerStyle.Visible = true;
			m_Line.Values.FillRandom(Random, 8);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);

		   	// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// configure interactivity
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			NExampleHelpers.FillComboWithEnumValues(LineStyleComboBox, typeof(LineSegmentShape));
			LineStyleComboBox.SelectedIndex = 1;
			LeftAxisRoundToTickCheckBox.IsChecked = true;
			InflateMarginsCheckBox.IsChecked = true;

			LineDepthScrollBar.Value = m_Line.DepthPercent / 100.0f;
			LineSizeScrollBar.Value = m_Line.LineSize / 10.0f;
		}

		private void SetupTapeMarkers(NMarkerStyle marker)
		{
			marker.PointShape = PointShape.Cylinder;
			marker.AutoDepth = true;
			marker.Width = new NLength(1.2f, NRelativeUnit.ParentPercentage);
			marker.Height = new NLength(1.2f, NRelativeUnit.ParentPercentage);
		}

		private void SetupTubeMarkers(NMarkerStyle marker)
		{
			marker.PointShape = PointShape.Sphere;
			marker.AutoDepth = false;
			marker.Width = new NLength(3.5f, NRelativeUnit.ParentPercentage);
			marker.Height = new NLength(3.5f, NRelativeUnit.ParentPercentage);
			marker.Depth = new NLength(3.5f, NRelativeUnit.ParentPercentage);
		}

		private void InflateMarginsCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			m_Line.InflateMargins = (bool)InflateMarginsCheckBox.IsChecked;
			nChartControl1.Refresh();
		}

		private void LeftAxisRoundToTickCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NStandardScaleConfigurator standardScale = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			standardScale.RoundToTickMax = (bool)LeftAxisRoundToTickCheckBox.IsChecked;
			standardScale.RoundToTickMin = (bool)LeftAxisRoundToTickCheckBox.IsChecked;

			nChartControl1.Refresh();
		}

		private void LineStyleComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			switch (LineStyleComboBox.SelectedIndex)
			{
				case 0: // simple line
					m_Line.LineSegmentShape = LineSegmentShape.Line;
					LineDepthScrollBar.IsEnabled = false;
					LineSizeScrollBar.IsEnabled = false;
					SetupTapeMarkers(m_Line.MarkerStyle);
					break;

				case 1: // tape
					m_Line.LineSegmentShape = LineSegmentShape.Tape;
					LineDepthScrollBar.IsEnabled = true;
					LineSizeScrollBar.IsEnabled = false;
					SetupTapeMarkers(m_Line.MarkerStyle);
					break;

				case 2: // tube
					m_Line.LineSegmentShape = LineSegmentShape.Tube;
					LineDepthScrollBar.IsEnabled = false;
					LineSizeScrollBar.IsEnabled = true;
					SetupTubeMarkers(m_Line.MarkerStyle);
					break;

				case 3: // elipsoid
					m_Line.LineSegmentShape = LineSegmentShape.Ellipsoid;
					LineDepthScrollBar.IsEnabled = false;
					LineSizeScrollBar.IsEnabled = true;
					SetupTubeMarkers(m_Line.MarkerStyle);
					break;
			}

			nChartControl1.Refresh();
		}

		private void LineDepthScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			m_Line.DepthPercent = (float)LineDepthScrollBar.Value * 100.0f;
			nChartControl1.Refresh();
		}

		private void LineSizeScrollBar_ValueChanged_1(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			m_Line.LineSize = (float)LineSizeScrollBar.Value * 10.0f;
			nChartControl1.Refresh();	
		}
	}
}
