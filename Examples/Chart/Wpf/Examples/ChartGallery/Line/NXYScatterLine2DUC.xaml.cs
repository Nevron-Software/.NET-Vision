using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NXYScatterLine2DUC : NExampleBaseUC
	{
		NChart m_Chart;
		NLineSeries m_Line;

		public NXYScatterLine2DUC()
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
				return "XY Scatter Line 2D";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "XY Scatter line charts are created by instructing the line series to use custom x values for the line data points. Use the controls on the right to modify commonly used properties";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XY Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			// add interlaced stripe to the Y axis
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			stripStyle.Interlaced = true;
			linearScale.StripStyles.Add(stripStyle);

			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

			// add the line
			m_Line = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_Line.LineSegmentShape = LineSegmentShape.Line;
			m_Line.DataLabelStyle.Visible = false;
			m_Line.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Line.InflateMargins = true;
			m_Line.MarkerStyle.Visible = true;
			m_Line.MarkerStyle.PointShape = PointShape.Cylinder;
			m_Line.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			m_Line.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			m_Line.Name = "Line Series";
			m_Line.UseXValues = true;

			// add xy values
			m_Line.AddDataPoint(new NDataPoint(15, 10));
			m_Line.AddDataPoint(new NDataPoint(25, 23));
			m_Line.AddDataPoint(new NDataPoint(45, 12));
			m_Line.AddDataPoint(new NDataPoint(55, 21));
			m_Line.AddDataPoint(new NDataPoint(61, 16));
			m_Line.AddDataPoint(new NDataPoint(67, 19));
			m_Line.AddDataPoint(new NDataPoint(72, 11));

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);
		}

		private void ChangeXValuesButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			m_Line.XValues[0] = (double)Random.Next(10);

			for (int i = 1; i < m_Line.XValues.Count; i++)
			{
				m_Line.XValues[i] = (double)m_Line.XValues[i - 1] + Random.Next(1, 10);
			}

			nChartControl1.Refresh();
		}
	}
}
