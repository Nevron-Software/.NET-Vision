using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NPolarVectorUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NNumericUpDown BeginAngleUpDown;
        private Label label6;
		private System.ComponentModel.Container components = null;

		public NPolarVectorUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.BeginAngleUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BeginAngleUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // BeginAngleUpDown
            // 
            this.BeginAngleUpDown.Location = new System.Drawing.Point(9, 30);
            this.BeginAngleUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.BeginAngleUpDown.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.BeginAngleUpDown.Name = "BeginAngleUpDown";
            this.BeginAngleUpDown.Size = new System.Drawing.Size(161, 20);
            this.BeginAngleUpDown.TabIndex = 19;
            this.BeginAngleUpDown.ValueChanged += new System.EventHandler(this.BeginAngleUpDown_ValueChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(9, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Begin Angle:";
            // 
            // NPolarVectorUC
            // 
            this.Controls.Add(this.BeginAngleUpDown);
            this.Controls.Add(this.label6);
            this.Name = "NPolarVectorUC";
            this.Size = new System.Drawing.Size(180, 222);
            ((System.ComponentModel.ISupportInitialize)(this.BeginAngleUpDown)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

            // configure chart
            nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Polar Vector");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // setup polar chart
            NPolarChart chart = new NPolarChart();
            nChartControl1.Panels.Add(chart);

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

		private void BeginAngleUpDown_ValueChanged(object sender, EventArgs e)
		{
			NPolarChart polarChart = nChartControl1.Charts[0] as NPolarChart;
			if (polarChart != null)
			{
				polarChart.BeginAngle = (float)BeginAngleUpDown.Value;
				nChartControl1.Refresh();
			}
		}
	}
}