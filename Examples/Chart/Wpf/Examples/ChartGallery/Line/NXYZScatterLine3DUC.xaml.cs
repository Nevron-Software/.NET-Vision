using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using System;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NXYZScatterLine3DUC : NExampleBaseUC
	{
		public NXYZScatterLine3DUC()
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
				return "XYZ Scatter Line 3D";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "XYZ Scatter line charts are created by instructing the line series to use custom x and z values for the line data points.Note that in this case the Bottom and Depth axes are switched in numeric scale mode.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XYZ Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 70;
			chart.Height = 70;
			chart.Depth = 70;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			chart.Axis(StandardAxis.Depth).Visible = true;

			// configure the depth axis
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// configure the horz axis
			linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;

			linearScale.LabelFitModes = new LabelFitMode[0];

			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// configure the y axis
			linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;

			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// add the line
			NLineSeries line = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line.LineSegmentShape = LineSegmentShape.Line;
			line.DataLabelStyle.Visible = false;
			line.Legend.Mode = SeriesLegendMode.Series;
			line.InflateMargins = true;
			line.MarkerStyle.Visible = false;
			line.Name = "Line Series";
			line.UseXValues = true;
			line.UseZValues = true;

			ChangeData();

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());
		}

		private void ChangeData()
		{
			if (nChartControl1 == null)
				return;

			// add xy values
			float fSpringHeight = 20;
			int nWindings = 15;
			int nComplexity = 20;

			double dCurrentAngle = 0;
			double dCurrentHeight = 0;
			double dX, dY, dZ;

			float fHeightStep = fSpringHeight / (nWindings * nComplexity);
			float fAngleStepRad = (float)(((360 / nComplexity) * 3.1415926535f) / 180.0f);

			NLineSeries line = (NLineSeries)nChartControl1.Charts[0].Series[0];
			line.ClearDataPoints();

			while (nWindings > 0)
			{
				for (int i = 0; i < nComplexity; i++)
				{
					dZ = Math.Cos(dCurrentAngle) * (dCurrentHeight);
					dX = Math.Sin(dCurrentAngle) * (dCurrentHeight);
					dY = dCurrentHeight;

					line.Values.Add(dY);
					line.XValues.Add(dX);
					line.ZValues.Add(dZ);

					dCurrentAngle += fAngleStepRad;
					dCurrentHeight += fHeightStep;
				}

				nWindings--;
			}

			nChartControl1.Refresh();
		}
	}
}
