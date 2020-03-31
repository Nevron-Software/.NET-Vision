using System;
using System.Diagnostics;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NPolarVectorUC : NExampleBaseUC
	{
        public NPolarVectorUC()
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
				return "Polar Area";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "The example demonstrates a Polar Vector chart\r\n" + 
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
			NLabel title = nChartControl1.Labels.AddHeader("Polar Vector");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // setup polar chart
            NPolarChart chart = new NPolarChart();
            nChartControl1.Charts.Clear();
            nChartControl1.Charts.Add(chart);

            // setup polar axis
            NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.Polar).ScaleConfigurator;
            linearScale.ViewRangeInflateMode = ScaleViewRangeInflateMode.MajorTick;
            linearScale.InflateViewRangeBegin = true;
            linearScale.InflateViewRangeEnd = true;

            NScaleStripStyle strip = new NScaleStripStyle();
            strip.FillStyle = new NColorFillStyle(Color.FromArgb(125, Color.Beige));
            strip.Interlaced = true;
            strip.SetShowAtWall(ChartWallType.Polar, true);
            linearScale.StripStyles.Add(strip);

            // setup polar angle axis
            NAngularScaleConfigurator angularScale = (NAngularScaleConfigurator)chart.Axis(StandardAxis.PolarAngle).ScaleConfigurator;
            strip = new NScaleStripStyle();
            strip.FillStyle = new NColorFillStyle(Color.FromArgb(125, 192, 192, 192));
            strip.Interlaced = true;
            strip.SetShowAtWall(ChartWallType.Polar, true);
            angularScale.StripStyles.Add(strip);

            // create a polar line series
            NPolarVectorSeries vectorSeries = new NPolarVectorSeries();
            chart.Series.Add(vectorSeries);
            vectorSeries.Name = "Series 1";
            vectorSeries.DataLabelStyle.Visible = false;
            vectorSeries.ShadowStyle.Type = ShadowType.LinearBlur;
            vectorSeries.ShadowStyle.Color = Color.Red;

            int dataPointIndex = 0;

            for (int i = 0; i < 360; i += 30)
            {
                for (int j = 10; j <= 100; j += 10)
                {
                    vectorSeries.Angles.Add(i);
                    vectorSeries.Values.Add(j);

                    vectorSeries.X2Values.Add(i + j / 10);
                    vectorSeries.Y2Values.Add(j);

                    vectorSeries.BorderStyles[dataPointIndex] = new NStrokeStyle(1.0f, ColorFromValue(j));
                    dataPointIndex++;
                }
            }

			// init form controls
			BeginAngleScrollBar.Value = 0.0f;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static Color ColorFromValue(double value)
        {
            Color color1 = Color.Red;
            Color color2 = Color.Blue;

            double factor = value / 100.0;
            double oneMinusFactor = 1 - factor;

            return Color.FromArgb(
                (byte)(color1.A * oneMinusFactor + color2.A * factor),
                (byte)(color1.R * oneMinusFactor + color2.R * factor),
                (byte)(color1.G * oneMinusFactor + color2.G * factor),
                (byte)(color1.B * oneMinusFactor + color2.B * factor));
        }

		private void BeginAngleScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			NPolarChart polarChart = nChartControl1.Charts[0] as NPolarChart;
			if (polarChart != null)
			{
				polarChart.BeginAngle = (float)BeginAngleScrollBar.Value * 360.0f;
				nChartControl1.Refresh();
			}
		}
	}
}
