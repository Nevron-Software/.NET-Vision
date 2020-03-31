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
	public partial class NPolarRangeUC : NExampleBaseUC
	{
        public NPolarRangeUC()
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
				return "The example demonstrates a Polar Range chart\r\n" + 
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
			NLabel title = nChartControl1.Labels.AddHeader("Polar Range");
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
            strip.FillStyle = new NColorFillStyle(Color.FromArgb(100, Color.Gray));
            strip.Interlaced = true;
            strip.SetShowAtWall(ChartWallType.Polar, true);
            linearScale.StripStyles.Add(strip);
            linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, true);

            // setup polar angle axis			
            NPolarAxis angleAxis = (NPolarAxis)chart.Axis(StandardAxis.PolarAngle);

            NOrdinalScaleConfigurator ordinalScale = new NOrdinalScaleConfigurator();

            strip = new NScaleStripStyle();
            strip.FillStyle = new NColorFillStyle(Color.FromArgb(100, Color.DarkGray));
            strip.Interlaced = true;
            strip.SetShowAtWall(ChartWallType.Polar, true);
            ordinalScale.StripStyles.Add(strip);
            ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, true);

            ordinalScale.InflateContentRange = false;
            ordinalScale.MajorTickMode = MajorTickMode.CustomTicks;
            ordinalScale.DisplayDataPointsBetweenTicks = false;

            ordinalScale.MajorTickMode = MajorTickMode.CustomStep;
            ordinalScale.CustomStep = 1;
            string[] labels = new string[] { "E", "NE", "N", "NW", "W", "SW", "S", "SE" };

            ordinalScale.AutoLabels = false;
            ordinalScale.Labels.AddRange(labels);
            ordinalScale.DisplayLastLabel = false;

            angleAxis.ScaleConfigurator = ordinalScale;
            angleAxis.View = new NRangeAxisView(new NRange1DD(0, 8));

            NPolarRangeSeries polarRange = new NPolarRangeSeries();
            polarRange.DataLabelStyle.Visible = false;
            chart.Series.Add(polarRange);

            Random rand = new Random();

            for (int i = 0; i < 8; i++)
            {
                polarRange.Values.Add(0);
                polarRange.Angles.Add(i - 0.4);

                polarRange.Y2Values.Add(rand.Next(80) + 20.0);
                polarRange.X2Values.Add(i + 0.4);
            }

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// init form controls
			BeginAngleScrollBar.Value = 0.0f;
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
