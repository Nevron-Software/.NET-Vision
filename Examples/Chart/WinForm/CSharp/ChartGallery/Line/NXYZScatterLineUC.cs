using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NXYZScatterLineUC : NExampleBaseUC
	{
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NNumericUpDown ComplexityNumericUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown WindingsNumericUpDown;

		public NXYZScatterLineUC()
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
			this.label1 = new System.Windows.Forms.Label();
			this.ComplexityNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.WindingsNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.ComplexityNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.WindingsNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(169, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Complexity:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ComplexityNumericUpDown
			// 
			this.ComplexityNumericUpDown.Location = new System.Drawing.Point(5, 24);
			this.ComplexityNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.ComplexityNumericUpDown.Name = "ComplexityNumericUpDown";
			this.ComplexityNumericUpDown.Size = new System.Drawing.Size(169, 20);
			this.ComplexityNumericUpDown.TabIndex = 1;
			this.ComplexityNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.ComplexityNumericUpDown.ValueChanged += new System.EventHandler(this.ComplexityNumericUpDown_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(5, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(169, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Windings:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// WindingsNumericUpDown
			// 
			this.WindingsNumericUpDown.Location = new System.Drawing.Point(5, 64);
			this.WindingsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.WindingsNumericUpDown.Name = "WindingsNumericUpDown";
			this.WindingsNumericUpDown.Size = new System.Drawing.Size(169, 20);
			this.WindingsNumericUpDown.TabIndex = 3;
			this.WindingsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.WindingsNumericUpDown.ValueChanged += new System.EventHandler(this.WindingsNumericUpDown_ValueChanged);
			// 
			// NXYZScatterLineUC
			// 
			this.Controls.Add(this.WindingsNumericUpDown);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.ComplexityNumericUpDown);
			this.Controls.Add(this.label1);
			this.Name = "NXYZScatterLineUC";
			this.Size = new System.Drawing.Size(180, 224);
			((System.ComponentModel.ISupportInitialize)(this.ComplexityNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.WindingsNumericUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XYZ Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

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

			ComplexityNumericUpDown.Value = 20;
			WindingsNumericUpDown.Value = 5;

			ChangeData();

			// apply layout
			ConfigureStandardLayout(chart, title, null);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);
		}

		private void ChangeData()
		{
			if (nChartControl1 == null)
				return;

			// add xy values
			float fSpringHeight = 20;
			int nWindings = (int)WindingsNumericUpDown.Value;
			int nComplexity = (int)ComplexityNumericUpDown.Value;
			
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

		private void ComplexityNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			ChangeData();
		}
		private void WindingsNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			ChangeData();
		}
	}
}
