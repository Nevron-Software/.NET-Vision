using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using Nevron.Dom;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NXYZScatterBubbleUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBubbleSeries m_Bubble;

		public NXYZScatterBubbleUC()
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
				return "XYZ Bubble";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "XYZ Scatter bubble charts are created by instructing the bubble series to use custom x and z values for the bubble data points.<br/>The Change Data button changes the X, Y and Z values and the Sizes of the bubble series.";
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
			NLabel title = new NLabel("XYZ Bubble Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.Width = 50;
			m_Chart.Depth = 50;
			m_Chart.Height = 50;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			NLinearScaleConfigurator depthScale = new NLinearScaleConfigurator();
			depthScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			depthScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			depthScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = depthScale;

			NLinearScaleConfigurator yScale = new NLinearScaleConfigurator();
			yScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);

			// add interlace style
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(new NArgbColor(Color.Beige)), null, true, 0, 0, 1, 1);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			stripStyle.Interlaced = true;
			yScale.StripStyles.Add(stripStyle);
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = yScale;

			// switch the x axis in linear mode
			NLinearScaleConfigurator xScale = new NLinearScaleConfigurator();
			xScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScale;

			m_Bubble = (NBubbleSeries)m_Chart.Series.Add(SeriesType.Bubble);
			m_Bubble.InflateMargins = true;
			m_Bubble.DataLabelStyle.Visible = false;
			m_Bubble.BubbleShape = PointShape.Sphere;
			m_Bubble.Legend.Format = "x:<xvalue> y:<value> z:<zvalue> sz:<size>";
			m_Bubble.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Bubble.MinSize = new NLength(10.0f, NRelativeUnit.ParentPercentage);
			m_Bubble.MaxSize = new NLength(20.0f, NRelativeUnit.ParentPercentage);
			m_Bubble.UseXValues = true;
			m_Bubble.UseZValues = true;
			m_Bubble.Values.ValueFormatter = new NNumericValueFormatter("0.#");
			m_Bubble.XValues.ValueFormatter = new NNumericValueFormatter("0.#");
			m_Bubble.ZValues.ValueFormatter = new NNumericValueFormatter("0.#");
			m_Bubble.Sizes.ValueFormatter = new NNumericValueFormatter("0.#");

			GenerateData();

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
			styleSheet.Apply(nChartControl1.Document);

		}

		void GenerateData()
		{
			m_Bubble.Values.Clear();
			m_Bubble.XValues.Clear();
			m_Bubble.ZValues.Clear();
			m_Bubble.Sizes.Clear();

			for (int i = 0; i < 4; i++)
			{
				m_Bubble.Values.Add(Random.NextDouble() * 5);
				m_Bubble.XValues.Add(Random.NextDouble() * 5);
				m_Bubble.ZValues.Add(Random.NextDouble() * 5);
				m_Bubble.Sizes.Add(Random.NextDouble());
			}
		}

		private void ChangeData_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			m_Bubble.XValues.FillRandom(Random, 4);
			m_Bubble.XValues[0] = -10;
			nChartControl1.Refresh();
		}
	}
}
