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
	public class NBoundsModeStretchUC : NExampleBaseUC
	{
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label BottomMarginLabel;
		private System.Windows.Forms.Label RightMarginLabel;
		private System.Windows.Forms.Label TopMarginLabel;
		private System.Windows.Forms.Label LeftMarginLabel;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NHScrollBar BottomMarginScrollBar;
		private Nevron.UI.WinForm.Controls.NHScrollBar TopMarginScrollBar;
		private Nevron.UI.WinForm.Controls.NHScrollBar RightMarginScrollBar;
		private Nevron.UI.WinForm.Controls.NHScrollBar LeftMarginScrollBar;
		private System.ComponentModel.IContainer components = null;

		public NBoundsModeStretchUC()
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
			this.groupBox1.SuspendLayout();
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
			this.groupBox1.Location = new System.Drawing.Point(7, 7);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(156, 175);
			this.groupBox1.TabIndex = 10;
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
			// NBoundsModeStretchUC
			// 
			this.Controls.Add(this.groupBox1);
			this.Name = "NBoundsModeStretchUC";
			this.Size = new System.Drawing.Size(180, 225);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// clear all panels
			nChartControl1.Panels.Clear();

			// setup chart
			NChart chart = new NCartesianChart();
			nChartControl1.Panels.Add(chart);
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(10, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
			chart.Padding = new NMarginsL(3, 7, 9, 0);
			chart.BackgroundFillStyle = new NColorFillStyle(Color.FromArgb(220, 220, 235));

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator.InnerMajorTickStyle.Visible = false;
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.InnerMajorTickStyle.Visible = false;

			// add a line series
			NLineSeries line1 = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line1.DataLabelStyle.Visible = false;
			line1.BorderStyle = new NStrokeStyle(2, Color.Peru);
			line1.FillStyle = new NColorFillStyle(Color.Peru);

			// add another line series
			NLineSeries line2 = (NLineSeries)chart.Series.Add(SeriesType.Line);
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
			TopMarginScrollBar.Value = 10;
			RightMarginScrollBar.Value = 90;
			BottomMarginScrollBar.Value = 90;
		}

		private void UpdateMargins()
		{
			int nLeft = LeftMarginScrollBar.Value;
			int nTop = TopMarginScrollBar.Value;
			int nRight = RightMarginScrollBar.Value;
			int nBottom = BottomMarginScrollBar.Value;

			if (nRight > 100)
				nRight = 100;

			if (nBottom > 100)
				nBottom = 100;

			if (nLeft > nRight)
				nLeft = nRight;

			if (nTop > nBottom)
				nTop = nBottom;

			NChart chart = nChartControl1.Charts[0];
			chart.Location = new NPointL(new NLength(nLeft, NRelativeUnit.ParentPercentage), new NLength(nTop, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(new NLength(nRight - nLeft, NRelativeUnit.ParentPercentage), new NLength(nBottom - nTop, NRelativeUnit.ParentPercentage));
			nChartControl1.Refresh();
		}
		private void UpdateMarginLabels()
		{
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
	}
}
