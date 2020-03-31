using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NXYZErrorBarUC : NExampleBaseUC
	{
		private NChart m_Chart;

		public NXYZErrorBarUC()
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
				return "XYZ Error Bar";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a XYZ Error Bar chart. XYZ Errors bars indicate the uncertainty in the X, Y and Z values.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XYZ Error Bar");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// remove the legend
			nChartControl1.Legends.Clear();

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			m_Chart.BoundsMode = BoundsMode.Fit;
			m_Chart.ContentAlignment = ContentAlignment.BottomRight;
			m_Chart.Location = new NPointL(new NLength(8, NRelativeUnit.ParentPercentage), new NLength(8, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(new NLength(84, NRelativeUnit.ParentPercentage), new NLength(84, NRelativeUnit.ParentPercentage));
			m_Chart.Depth = 55.0f;
			m_Chart.Width = 55.0f;
			m_Chart.Height = 55.0f;

			// setup the x axis
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);

			// setup the y axis
			linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

			// add interlace stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			// setup the z axis
			linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale;

			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);

			// add an error bar series
			NErrorBarSeries series = (NErrorBarSeries)m_Chart.Series.Add(SeriesType.ErrorBar);
			series.DataLabelStyle.Visible = false;
			series.BorderStyle = new NStrokeStyle(GreyBlue);
			series.MarkerStyle.Visible = true;
			series.MarkerStyle.AutoDepth = false;
			series.MarkerStyle.FillStyle = new NColorFillStyle(DarkOrange);
			series.MarkerStyle.BorderStyle = new NStrokeStyle(GreyBlue);
			series.MarkerStyle.Width = new NLength(1.2f, NRelativeUnit.ParentPercentage);
			series.MarkerStyle.Height = new NLength(1.2f, NRelativeUnit.ParentPercentage);
			series.MarkerStyle.Depth = new NLength(1.2f, NRelativeUnit.ParentPercentage);
			series.UseXValues = true;
			series.UseZValues = true;
			series.ShowLowerErrorX = true;
			series.ShowLowerErrorY = true;
			series.ShowLowerErrorZ = true;
			series.ShowUpperErrorX = true;
			series.ShowUpperErrorY = true;
			series.ShowUpperErrorZ = true;

			GenerateData(series);

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);
		}
		private void GenerateData(NErrorBarSeries series)
		{
			series.ClearDataPoints();

			NVector3DF v = new NVector3DF();

			for (int i = 0; i < 15; i++)
			{
				v.X = (float)(0.5 - Random.NextDouble());
				v.Y = (float)(0.5 - Random.NextDouble());
				v.Z = (float)(0.5 - Random.NextDouble());

				v.Normalize(40.0f);

				series.Values.Add(v.X);
				series.XValues.Add(v.Y);
				series.ZValues.Add(v.Z);

				series.LowerErrorsX.Add(2 + 5 * Random.NextDouble());
				series.UpperErrorsX.Add(2 + 5 * Random.NextDouble());
				series.LowerErrorsY.Add(2 + 5 * Random.NextDouble());
				series.UpperErrorsY.Add(2 + 5 * Random.NextDouble());
				series.LowerErrorsZ.Add(2 + 5 * Random.NextDouble());
				series.UpperErrorsZ.Add(2 + 5 * Random.NextDouble());
			}
		}

		private void GenerateDataButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			NErrorBarSeries series = (NErrorBarSeries)m_Chart.Series[0];
			GenerateData(series);
			nChartControl1.Refresh();
		}
	}
}
