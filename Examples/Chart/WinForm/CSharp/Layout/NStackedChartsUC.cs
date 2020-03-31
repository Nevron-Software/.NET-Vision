using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NStackedChartsUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NHScrollBar BottomMarginScrollBar;
		private Nevron.UI.WinForm.Controls.NHScrollBar TopMarginScrollBar;
		private Nevron.UI.WinForm.Controls.NHScrollBar RightMarginScrollBar;
		private Nevron.UI.WinForm.Controls.NHScrollBar LeftMarginScrollBar;
		private Nevron.UI.WinForm.Controls.NNumericUpDown GapPercentUpDown;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label BottomMarginLabel;
		private System.Windows.Forms.Label RightMarginLabel;
		private System.Windows.Forms.Label TopMarginLabel;
		private System.Windows.Forms.Label LeftMarginLabel;
		private Label label1;
		private System.ComponentModel.IContainer components;

		public NStackedChartsUC()
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
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.BottomMarginLabel = new System.Windows.Forms.Label();
			this.RightMarginLabel = new System.Windows.Forms.Label();
			this.TopMarginLabel = new System.Windows.Forms.Label();
			this.LeftMarginLabel = new System.Windows.Forms.Label();
			this.BottomMarginScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.TopMarginScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.RightMarginScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.LeftMarginScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.GapPercentUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.GapPercentUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.BottomMarginLabel);
			this.groupBox1.Controls.Add(this.RightMarginLabel);
			this.groupBox1.Controls.Add(this.TopMarginLabel);
			this.groupBox1.Controls.Add(this.LeftMarginLabel);
			this.groupBox1.Controls.Add(this.BottomMarginScrollBar);
			this.groupBox1.Controls.Add(this.TopMarginScrollBar);
			this.groupBox1.Controls.Add(this.RightMarginScrollBar);
			this.groupBox1.Controls.Add(this.LeftMarginScrollBar);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.ImageIndex = 0;
			this.groupBox1.Location = new System.Drawing.Point(7, 7);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(156, 175);
			this.groupBox1.TabIndex = 22;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Margins";
			// 
			// BottomMarginLabel
			// 
			this.BottomMarginLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BottomMarginLabel.Location = new System.Drawing.Point(116, 148);
			this.BottomMarginLabel.Name = "BottomMarginLabel";
			this.BottomMarginLabel.Size = new System.Drawing.Size(32, 16);
			this.BottomMarginLabel.TabIndex = 12;
			// 
			// RightMarginLabel
			// 
			this.RightMarginLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.RightMarginLabel.Location = new System.Drawing.Point(116, 110);
			this.RightMarginLabel.Name = "RightMarginLabel";
			this.RightMarginLabel.Size = new System.Drawing.Size(32, 16);
			this.RightMarginLabel.TabIndex = 11;
			// 
			// TopMarginLabel
			// 
			this.TopMarginLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TopMarginLabel.Location = new System.Drawing.Point(116, 72);
			this.TopMarginLabel.Name = "TopMarginLabel";
			this.TopMarginLabel.Size = new System.Drawing.Size(32, 16);
			this.TopMarginLabel.TabIndex = 10;
			// 
			// LeftMarginLabel
			// 
			this.LeftMarginLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.LeftMarginLabel.Location = new System.Drawing.Point(116, 34);
			this.LeftMarginLabel.Name = "LeftMarginLabel";
			this.LeftMarginLabel.Size = new System.Drawing.Size(32, 16);
			this.LeftMarginLabel.TabIndex = 9;
			// 
			// BottomMarginScrollBar
			// 
			this.BottomMarginScrollBar.Location = new System.Drawing.Point(8, 148);
			this.BottomMarginScrollBar.Maximum = 110;
			this.BottomMarginScrollBar.MinimumSize = new System.Drawing.Size(32, 16);
			this.BottomMarginScrollBar.Name = "BottomMarginScrollBar";
			this.BottomMarginScrollBar.Size = new System.Drawing.Size(100, 16);
			this.BottomMarginScrollBar.TabIndex = 3;
			this.BottomMarginScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BottomMarginScrollBar_Scroll);
			// 
			// TopMarginScrollBar
			// 
			this.TopMarginScrollBar.Location = new System.Drawing.Point(8, 72);
			this.TopMarginScrollBar.Maximum = 110;
			this.TopMarginScrollBar.MinimumSize = new System.Drawing.Size(32, 16);
			this.TopMarginScrollBar.Name = "TopMarginScrollBar";
			this.TopMarginScrollBar.Size = new System.Drawing.Size(100, 16);
			this.TopMarginScrollBar.TabIndex = 1;
			this.TopMarginScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.TopMarginScrollBar_Scroll);
			// 
			// RightMarginScrollBar
			// 
			this.RightMarginScrollBar.Location = new System.Drawing.Point(8, 110);
			this.RightMarginScrollBar.Maximum = 110;
			this.RightMarginScrollBar.MinimumSize = new System.Drawing.Size(32, 16);
			this.RightMarginScrollBar.Name = "RightMarginScrollBar";
			this.RightMarginScrollBar.Size = new System.Drawing.Size(100, 16);
			this.RightMarginScrollBar.TabIndex = 2;
			this.RightMarginScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.RightMarginScrollBar_Scroll);
			// 
			// LeftMarginScrollBar
			// 
			this.LeftMarginScrollBar.Location = new System.Drawing.Point(8, 34);
			this.LeftMarginScrollBar.Maximum = 110;
			this.LeftMarginScrollBar.MinimumSize = new System.Drawing.Size(32, 16);
			this.LeftMarginScrollBar.Name = "LeftMarginScrollBar";
			this.LeftMarginScrollBar.Size = new System.Drawing.Size(100, 16);
			this.LeftMarginScrollBar.TabIndex = 0;
			this.LeftMarginScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LeftMarginScrollBar_Scroll);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 132);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 16);
			this.label4.TabIndex = 8;
			this.label4.Text = "Bottom:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 94);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(47, 16);
			this.label3.TabIndex = 7;
			this.label3.Text = "Right:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "Top:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 19);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(47, 16);
			this.label5.TabIndex = 5;
			this.label5.Text = "Left:";
			// 
			// GapPercentUpDown
			// 
			this.GapPercentUpDown.Location = new System.Drawing.Point(15, 242);
			this.GapPercentUpDown.Name = "GapPercentUpDown";
			this.GapPercentUpDown.Size = new System.Drawing.Size(63, 20);
			this.GapPercentUpDown.TabIndex = 16;
			this.GapPercentUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.GapPercentUpDown.ValueChanged += new System.EventHandler(this.GapPercentUpDown_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 221);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 23;
			this.label1.Text = "Gap %";
			// 
			// NStackedChartsUC
			// 
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.GapPercentUpDown);
			this.Name = "NStackedChartsUC";
			this.Size = new System.Drawing.Size(180, 283);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.GapPercentUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Panels.Clear();

			// setup chart 1
			NChart chart1 = new NCartesianChart();
			nChartControl1.Charts.Add(chart1);
			chart1.BoundsMode = BoundsMode.Stretch;
			chart1.Wall(ChartWallType.Back).FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.FromArgb(220, 220, 235));

			// setup X axis
			NAxis axisX = chart1.Axis(StandardAxis.PrimaryX);
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.InnerMajorTickStyle.Visible = false;
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			axisX.ScaleConfigurator = scaleX;
			((NDockAxisAnchor)axisX.Anchor).AxisDockZone = AxisDockZone.FrontTop;

			// setup Y axis
			chart1.Axis(StandardAxis.PrimaryY).ScaleConfigurator.InnerMajorTickStyle.Visible = false;

			// add a line series
			NLineSeries line1 = new NLineSeries();
			chart1.Series.Add(line1);
			line1.DataLabelStyle.Visible = false;
			line1.BorderStyle = new NStrokeStyle(2, Color.Peru);
			line1.FillStyle = new NColorFillStyle(Color.Peru);

			// setup chart 2
			NChart chart2 = new NCartesianChart();
			nChartControl1.Charts.Add(chart2);
			chart2.BoundsMode = BoundsMode.Stretch;
			chart2.Wall(ChartWallType.Back).FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant2, Color.White, Color.FromArgb(220, 220, 235));

			// setup X axis
			scaleX = new NLinearScaleConfigurator();
			scaleX.InnerMajorTickStyle.Visible = false;
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			chart2.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// setup Y axis
			chart2.Axis(StandardAxis.PrimaryY).ScaleConfigurator.InnerMajorTickStyle.Visible = false;

			// add a line series
			NLineSeries line2 = new NLineSeries();
			chart2.Series.Add(line2);
			line2.DataLabelStyle.Visible = false;
			line2.BorderStyle = new NStrokeStyle(2, Color.Olive);
			line2.FillStyle = new NColorFillStyle(Color.Olive);

			// fill some data
			for (int i = 0; i < 100; i++)
			{
				line1.Values.Add(Math.Sin(i * 0.05) * (Random.NextDouble() + 1.0));
				line2.Values.Add(Math.Cos(i * 0.1) * (Random.NextDouble() + 1.0));
			}

			// init form controls
			LeftMarginScrollBar.Value = 10;
			TopMarginScrollBar.Value = 12;
			RightMarginScrollBar.Value = 90;
			BottomMarginScrollBar.Value = 88;
		}

		private void UpdateMargins()
		{
			if (nChartControl1 == null)
			{
				return;
			}

			float left = LeftMarginScrollBar.Value;
			float top = TopMarginScrollBar.Value;
			float right = RightMarginScrollBar.Value;
			float bottom = BottomMarginScrollBar.Value;
			float gapPercent = (int)GapPercentUpDown.Value;

			if (right > 100.0f)
				right = 100.0f;

			if (bottom > 100.0f)
				bottom = 100.0f;

			if (left > right)
				right = left;

			float panelHeight = (bottom - top - gapPercent) * 0.5f;

			if (panelHeight < 0.0f)
				panelHeight = 0.0f;

			NChart chart1 = nChartControl1.Charts[0];
			chart1.Location = new NPointL(
				new NLength(left, NRelativeUnit.ParentPercentage),
				new NLength(top, NRelativeUnit.ParentPercentage));
			chart1.Size = new NSizeL(
				new NLength(right - left, NRelativeUnit.ParentPercentage),
				new NLength(panelHeight, NRelativeUnit.ParentPercentage));

			NChart chart2 = nChartControl1.Charts[1];
			chart2.Location = new NPointL(
				new NLength(left, NRelativeUnit.ParentPercentage),
				new NLength(top + panelHeight + gapPercent, NRelativeUnit.ParentPercentage));
			chart2.Size = new NSizeL(
				new NLength(right - left, NRelativeUnit.ParentPercentage),
				new NLength(panelHeight, NRelativeUnit.ParentPercentage));

			nChartControl1.Refresh();
		}
		private void UpdateMarginLabels()
		{
			if (nChartControl1 == null)
			{
				return;
			}

			int nLeft = LeftMarginScrollBar.Value;
			int nTop = TopMarginScrollBar.Value;
			int nRight = RightMarginScrollBar.Value;
			int nBottom = BottomMarginScrollBar.Value;

			LeftMarginLabel.Text = System.Convert.ToString(nLeft) + "%";
			TopMarginLabel.Text = System.Convert.ToString(nTop) + "%";
			RightMarginLabel.Text = System.Convert.ToString(nRight) + "%";
			BottomMarginLabel.Text = System.Convert.ToString(nBottom) + "%";
		}

		private void LeftMarginScrollBar_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			UpdateMargins();
			UpdateMarginLabels();
		}
		private void TopMarginScrollBar_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			UpdateMargins();
			UpdateMarginLabels();
		}
		private void RightMarginScrollBar_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			UpdateMargins();
			UpdateMarginLabels();
		}
		private void BottomMarginScrollBar_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			UpdateMargins();
			UpdateMarginLabels();
		}
		private void GapPercentUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateMargins();
			UpdateMarginLabels();
		}
	}
}