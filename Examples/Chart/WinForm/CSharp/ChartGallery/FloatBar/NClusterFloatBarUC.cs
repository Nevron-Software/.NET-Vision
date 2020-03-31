using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WinForm;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NClusterFloatBarUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NHScrollBar BarGapScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar BarWidthScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar BarDepthScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar FloatbarDepthScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar FloatbarGapScroll;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.ComponentModel.IContainer components = null;

		public NClusterFloatBarUC()
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
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.BarGapScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.BarWidthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.BarDepthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.FloatbarDepthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.FloatbarGapScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label1 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// BarGapScroll
			// 
			this.BarGapScroll.Location = new System.Drawing.Point(8, 40);
			this.BarGapScroll.Maximum = 110;
			this.BarGapScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.BarGapScroll.Name = "BarGapScroll";
			this.BarGapScroll.Size = new System.Drawing.Size(163, 16);
			this.BarGapScroll.TabIndex = 0;
			this.BarGapScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BarGapScroll_Scroll);
			// 
			// BarWidthScroll
			// 
			this.BarWidthScroll.Location = new System.Drawing.Point(8, 96);
			this.BarWidthScroll.Maximum = 110;
			this.BarWidthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.BarWidthScroll.Name = "BarWidthScroll";
			this.BarWidthScroll.Size = new System.Drawing.Size(163, 16);
			this.BarWidthScroll.TabIndex = 1;
			this.BarWidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BarWidthScroll_Scroll);
			// 
			// BarDepthScroll
			// 
			this.BarDepthScroll.Location = new System.Drawing.Point(8, 152);
			this.BarDepthScroll.Maximum = 110;
			this.BarDepthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.BarDepthScroll.Name = "BarDepthScroll";
			this.BarDepthScroll.Size = new System.Drawing.Size(163, 16);
			this.BarDepthScroll.TabIndex = 2;
			this.BarDepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BarDepthScroll_Scroll);
			// 
			// FloatbarDepthScroll
			// 
			this.FloatbarDepthScroll.Location = new System.Drawing.Point(8, 264);
			this.FloatbarDepthScroll.Maximum = 110;
			this.FloatbarDepthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.FloatbarDepthScroll.Name = "FloatbarDepthScroll";
			this.FloatbarDepthScroll.Size = new System.Drawing.Size(163, 16);
			this.FloatbarDepthScroll.TabIndex = 3;
			this.FloatbarDepthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.FloatbarDepthScroll_Scroll);
			// 
			// FloatbarGapScroll
			// 
			this.FloatbarGapScroll.Location = new System.Drawing.Point(8, 208);
			this.FloatbarGapScroll.Maximum = 110;
			this.FloatbarGapScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.FloatbarGapScroll.Name = "FloatbarGapScroll";
			this.FloatbarGapScroll.Size = new System.Drawing.Size(163, 16);
			this.FloatbarGapScroll.TabIndex = 4;
			this.FloatbarGapScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.FloatbarGapScroll_Scroll);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(163, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "Bar Gap Percent:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 240);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(163, 16);
			this.label5.TabIndex = 6;
			this.label5.Text = "Floatbar Depth Percent:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 184);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(163, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "Floatbar Gap Percent:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 128);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(163, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "Bar Depth Percent:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(163, 16);
			this.label2.TabIndex = 9;
			this.label2.Text = "Bar Width Percent:";
			// 
			// NClusterFloatBarUC
			// 
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.FloatbarGapScroll);
			this.Controls.Add(this.FloatbarDepthScroll);
			this.Controls.Add(this.BarDepthScroll);
			this.Controls.Add(this.BarWidthScroll);
			this.Controls.Add(this.BarGapScroll);
			this.Controls.Add(this.label1);
			this.Name = "NClusterFloatBarUC";
			this.Size = new System.Drawing.Size(180, 320);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = new NLabel("Cluster Float Bar");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 65;
			chart.Height = 40;
			chart.Axis(StandardAxis.Depth).Visible = false;
            chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

            // add interlaced stripe to the Y axis
            NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
			scaleY.StripStyles.Add(stripStyle);

            chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

			// setup the bar series
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Name = "Bar series";
			bar.DataLabelStyle.Visible = false;
			bar.Values.FillRandomRange(Random, 8, 7, 15);

			// setup the floatbar series
			NFloatBarSeries floatbar = (NFloatBarSeries)chart.Series.Add(SeriesType.FloatBar);
			floatbar.MultiFloatBarMode = MultiFloatBarMode.Clustered;
			floatbar.Name = "Floatbar series";
			floatbar.DataLabelStyle.Visible = false;

			floatbar.AddDataPoint(new NFloatBarDataPoint(3.1, 5.2));
			floatbar.AddDataPoint(new NFloatBarDataPoint(4.0, 6.1));
			floatbar.AddDataPoint(new NFloatBarDataPoint(2.0, 6.4));
			floatbar.AddDataPoint(new NFloatBarDataPoint(5.3, 7.3));
			floatbar.AddDataPoint(new NFloatBarDataPoint(3.8, 8.4));
			floatbar.AddDataPoint(new NFloatBarDataPoint(4.0, 7.7));
			floatbar.AddDataPoint(new NFloatBarDataPoint(2.9, 4.1));
			floatbar.AddDataPoint(new NFloatBarDataPoint(5.0, 7.2));

			// init form controls
			BarGapScroll.Value = (int)bar.GapPercent;
			BarWidthScroll.Value = (int)bar.WidthPercent;
			BarDepthScroll.Value = (int)bar.DepthPercent;
			FloatbarGapScroll.Value = (int)floatbar.GapPercent;
			FloatbarDepthScroll.Value = (int)floatbar.DepthPercent;

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);
		}

		private void BarGapScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
			bar.GapPercent = BarGapScroll.Value;
			nChartControl1.Refresh();
		}
		private void BarWidthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
			bar.WidthPercent = BarWidthScroll.Value;
			nChartControl1.Refresh();
		}
		private void BarDepthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
			bar.DepthPercent = BarDepthScroll.Value;
			nChartControl1.Refresh();
		}
		private void FloatbarGapScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NFloatBarSeries floatbar = (NFloatBarSeries)nChartControl1.Charts[0].Series[1];
			floatbar.GapPercent = FloatbarGapScroll.Value;
			nChartControl1.Refresh();
		}
		private void FloatbarDepthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NFloatBarSeries floatbar = (NFloatBarSeries)nChartControl1.Charts[0].Series[1];
			floatbar.DepthPercent =	FloatbarDepthScroll.Value;
			nChartControl1.Refresh();
		}
	}
}

