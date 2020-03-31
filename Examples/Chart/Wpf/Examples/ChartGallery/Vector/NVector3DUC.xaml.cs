using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using System;
using System.Drawing;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NVector3DUC : NExampleBaseUC
	{
		public NVector3DUC()
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
				return "Vector 3D";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a 3D Vector Field implemented with the Vector Series.\r\n" + 
						"Each arrow represents a data point that is defined by 6 coordinates:\r\n" +
						"Begin X, Begin Y, Begin Z, End X, End Y, End Z.\r\n" + 
						"Individual stroke styles are assigned for each arrow.";
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
			NLabel title = new NLabel("3D Vector Field");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Projection.Type = ProjectionType.Perspective;
			chart.Projection.Rotation = -18;
			chart.Projection.Elevation = 13;
			chart.Depth = 55.0f;
			chart.Width = 55.0f;
			chart.Height = 55.0f;

			// setup X axis
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.RoundToTickMin = false;
			linearScale.RoundToTickMax = false;
			linearScale.MajorGridStyle.ShowAtWalls = new ChartWallType[] { };

			// setup Y axis
			linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			linearScale.RoundToTickMin = false;
			linearScale.RoundToTickMax = false;
			linearScale.MajorGridStyle.ShowAtWalls = new ChartWallType[] { };

			// setup Z axis
			linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale;
			linearScale.RoundToTickMin = false;
			linearScale.RoundToTickMax = false;
			linearScale.MajorGridStyle.ShowAtWalls = new ChartWallType[] { };

			// setup shape series
			NVectorSeries vectorSeries = (NVectorSeries)chart.Series.Add(SeriesType.Vector);
			vectorSeries.FillStyle = new NColorFillStyle(Color.Red);
			vectorSeries.BorderStyle.Color = Color.DarkRed;
			vectorSeries.Legend.Mode = SeriesLegendMode.None;
			vectorSeries.DataLabelStyle.Visible = false;
			vectorSeries.InflateMargins = true;
			vectorSeries.UseXValues = true;
			vectorSeries.UseZValues = true;

			vectorSeries.MinArrowHeadSize = new NSizeL(2, 3);
			vectorSeries.MaxArrowHeadSize = new NSizeL(4, 6);

			// fill data
			FillData(vectorSeries);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			nChartControl1.Refresh();
		}

		private void FillData(NVectorSeries vectorSeries)
		{
			double x = 0, y = 0, z = 0;
			int k = 0;

			for (int w = 0; w < 5; w++)
			{
				y = 0;
				z += 1;

				for (int i = 0; i < 5; i++)
				{
					x = 0;
					y += 1;

					for (int j = 0; j < 5; j++)
					{
						x += 1;

						double dx = Math.Sin(x / 4.0) * Math.Sin(x / 4.0);
						double dy = Math.Cos(y / 8.0) * Math.Cos(w / 4.0);

						vectorSeries.XValues.Add(x);
						vectorSeries.Values.Add(y);
						vectorSeries.ZValues.Add(z);
						vectorSeries.X2Values.Add(x + dx);
						vectorSeries.Y2Values.Add(y + dy);
						vectorSeries.Z2Values.Add(z - 0.5);

						vectorSeries.BorderStyles[k] = new NStrokeStyle(1, ColorFromVector(dx, dy));
						k++;
					}
				}
			}
		}
		private Color ColorFromVector(double dx, double dy)
		{
			double length = Math.Sqrt(dx * dx + dy * dy);

			double sq2 = Math.Sqrt(2);

			int r = (int)((255 / sq2) * length);
			int g = 20;
			int b = (int)((255 / sq2) * (sq2 - length));

			return Color.FromArgb(r, g, b);
		}

	}
}
