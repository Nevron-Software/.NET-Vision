using Nevron.Chart;
using Nevron.GraphicsCore;
using System;
using System.Drawing;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NVectorLegendScaleUC : NExampleBaseUC
	{
		NVectorSeries m_Vector;

		public NVectorLegendScaleUC()
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
				return "Vector Legend Scale";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "The example demonstrates how to display a vector lenght legend scale on the legend. This feature allows the user to have a visual representation of the vector length."; 
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = new NLabel("Vector Legend Scale");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);


			nChartControl1.Legends[0].Header.Text = "Vector Length";

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			//chart.Enable3D = true;
			chart.Width = 55.0f;
			chart.Height = 55.0f;

			// setup X axis
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.RoundToTickMin = false;
			linearScale.RoundToTickMax = false;
			linearScale.MajorGridStyle.ShowAtWalls = new ChartWallType[] { };
			linearScale.InnerMajorTickStyle.Visible = false;

			// setup Y axis
			linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			linearScale.RoundToTickMin = false;
			linearScale.RoundToTickMax = false;
			linearScale.MajorGridStyle.ShowAtWalls = new ChartWallType[] { };
			linearScale.InnerMajorTickStyle.Visible = false;

			// setup shape series
			m_Vector = (NVectorSeries)chart.Series.Add(SeriesType.Vector);
			m_Vector.FillStyle = new NColorFillStyle(Color.Red);
			m_Vector.BorderStyle.Color = Color.DarkRed;
			m_Vector.DataLabelStyle.Visible = false;
			m_Vector.InflateMargins = true;
			m_Vector.UseXValues = true;
			//m_Vector.UseZValues = true;
			m_Vector.MinArrowHeadSize = new NSizeL(2, 3);
			m_Vector.MaxArrowHeadSize = new NSizeL(4, 6);
			m_Vector.MinVectorLength = new NLength(8);
			m_Vector.MaxVectorLength = new NLength(30);
			m_Vector.Mode = VectorSeriesMode.Direction;
			m_Vector.Legend.Mode = SeriesLegendMode.SeriesLogic;

			// fill data
			FillData(m_Vector);

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);
		}

		private void FillData(NVectorSeries vectorSeries)
		{
			double x = 0, y = 0;
			int k = 0;

			for (int i = 0; i < 10; i++)
			{
				x = 1;
				y += 1;

				for (int j = 0; j < 10; j++)
				{
					x += 1;

					double dx = Math.Sin(x / 3.0) * Math.Cos((x - y) / 4.0);
					double dy = Math.Cos(y / 8.0) * Math.Cos(y / 4.0);

					vectorSeries.XValues.Add(x);
					vectorSeries.Values.Add(y);
					vectorSeries.X2Values.Add(dx);
					vectorSeries.Y2Values.Add(dy);

					vectorSeries.ZValues.Add(y);
					vectorSeries.Z2Values.Add(dy);

					vectorSeries.BorderStyles[k] = new NStrokeStyle(1, ColorFromVector(dx, dy));
					k++;
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
