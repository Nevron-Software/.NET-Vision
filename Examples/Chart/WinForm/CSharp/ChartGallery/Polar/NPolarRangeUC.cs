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
	public class NPolarRangeUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NNumericUpDown BeginAngleUpDown;
        private Label label6;
		private System.ComponentModel.Container components = null;

		public NPolarRangeUC()
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
            // NPolarRangeUC
            // 
            this.Controls.Add(this.BeginAngleUpDown);
            this.Controls.Add(this.label6);
            this.Name = "NPolarRangeUC";
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
			NLabel title = nChartControl1.Labels.AddHeader("Polar Range");
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