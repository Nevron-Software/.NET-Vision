using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NStandardFunnel2DUC : NExampleBaseUC
	{
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private Nevron.UI.WinForm.Controls.NHScrollBar ArrowLengthScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar NeckWidthScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar NeckHeightScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar FunnelGapScroll;
		private Nevron.UI.WinForm.Controls.NComboBox LabelModeCombo;
		private System.ComponentModel.Container components = null;

		public NStandardFunnel2DUC()
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
			this.label4 = new System.Windows.Forms.Label();
			this.NeckWidthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label5 = new System.Windows.Forms.Label();
			this.NeckHeightScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label6 = new System.Windows.Forms.Label();
			this.LabelModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.ArrowLengthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label2 = new System.Windows.Forms.Label();
			this.FunnelGapScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.SuspendLayout();
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 46);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(169, 16);
			this.label4.TabIndex = 4;
			this.label4.Text = "Neck Width:";
			// 
			// NeckWidthScroll
			// 
			this.NeckWidthScroll.Location = new System.Drawing.Point(6, 61);
			this.NeckWidthScroll.Maximum = 50;
			this.NeckWidthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.NeckWidthScroll.Name = "NeckWidthScroll";
			this.NeckWidthScroll.Size = new System.Drawing.Size(169, 16);
			this.NeckWidthScroll.TabIndex = 5;
			this.NeckWidthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.NeckWidthScroll_Scroll);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 87);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(169, 15);
			this.label5.TabIndex = 6;
			this.label5.Text = "Neck Height:";
			// 
			// NeckHeightScroll
			// 
			this.NeckHeightScroll.Location = new System.Drawing.Point(6, 103);
			this.NeckHeightScroll.Maximum = 50;
			this.NeckHeightScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.NeckHeightScroll.Name = "NeckHeightScroll";
			this.NeckHeightScroll.Size = new System.Drawing.Size(169, 16);
			this.NeckHeightScroll.TabIndex = 7;
			this.NeckHeightScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.NeckHeightScroll_Scroll);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(6, 158);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(169, 16);
			this.label6.TabIndex = 8;
			this.label6.Text = "Funnel Label Mode:";
			// 
			// LabelModeCombo
			// 
			this.LabelModeCombo.ListProperties.CheckBoxDataMember = "";
			this.LabelModeCombo.ListProperties.DataSource = null;
			this.LabelModeCombo.ListProperties.DisplayMember = "";
			this.LabelModeCombo.Location = new System.Drawing.Point(6, 176);
			this.LabelModeCombo.Name = "LabelModeCombo";
			this.LabelModeCombo.Size = new System.Drawing.Size(169, 21);
			this.LabelModeCombo.TabIndex = 9;
			this.LabelModeCombo.SelectedIndexChanged += new System.EventHandler(this.LabelModeCombo_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(6, 210);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(169, 16);
			this.label7.TabIndex = 10;
			this.label7.Text = "Label Arrow Length:";
			// 
			// ArrowLengthScroll
			// 
			this.ArrowLengthScroll.LargeChange = 1;
			this.ArrowLengthScroll.Location = new System.Drawing.Point(6, 228);
			this.ArrowLengthScroll.Maximum = 20;
			this.ArrowLengthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.ArrowLengthScroll.Name = "ArrowLengthScroll";
			this.ArrowLengthScroll.Size = new System.Drawing.Size(169, 16);
			this.ArrowLengthScroll.TabIndex = 11;
			this.ArrowLengthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.ArrowLengthScroll_Scroll);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(169, 15);
			this.label2.TabIndex = 2;
			this.label2.Text = "Funnel Point Gap:";
			// 
			// FunnelGapScroll
			// 
			this.FunnelGapScroll.Location = new System.Drawing.Point(6, 23);
			this.FunnelGapScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.FunnelGapScroll.Name = "FunnelGapScroll";
			this.FunnelGapScroll.Size = new System.Drawing.Size(169, 16);
			this.FunnelGapScroll.TabIndex = 3;
			this.FunnelGapScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.FunnelGapScroll_Scroll);
			// 
			// NStandardFunnel2DUC
			// 
			this.Controls.Add(this.FunnelGapScroll);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.ArrowLengthScroll);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.LabelModeCombo);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.NeckHeightScroll);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.NeckWidthScroll);
			this.Controls.Add(this.label4);
			this.Name = "NStandardFunnel2DUC";
			this.Size = new System.Drawing.Size(180, 285);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("2D Funnel Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			NLegend legend = nChartControl1.Legends[0];
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.BottomRight);

			NFunnelChart chart = new NFunnelChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(chart);

			NFunnelSeries funnel = (NFunnelSeries)chart.Series.Add(SeriesType.Funnel);
			funnel.BorderStyle.Color = Color.LemonChiffon;
			funnel.Legend.DisplayOnLegend = legend;
			funnel.Legend.Mode = SeriesLegendMode.DataPoints;
			funnel.DataLabelStyle.Format = "<percent>";
			funnel.ShadowStyle.Type = ShadowType.GaussianBlur;
			funnel.ShadowStyle.Color = Color.FromArgb(50, 0, 0, 0);
			funnel.ShadowStyle.Offset = new NPointL(5, 5);
			funnel.ShadowStyle.FadeLength = new NLength(6);

			funnel.Values.Add(20.0);
			funnel.Values.Add(10.0);
			funnel.Values.Add(15.0);
			funnel.Values.Add(7.0);
			funnel.Values.Add(28.0);

			funnel.Labels.Add("Awareness");
			funnel.Labels.Add("First Hear");
			funnel.Labels.Add("Further Learn");
			funnel.Labels.Add("Liking");
			funnel.Labels.Add("Decision");

            // apply palette to funnel segments
			NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Fresh);
            for (int i = 0; i < funnel.Values.Count; i++)
            {
                funnel.FillStyles[i] = new NColorFillStyle(palette.SeriesColors[i % palette.SeriesColors.Count]);
            }

			// init form controls
			LabelModeCombo.FillFromEnum(typeof(FunnelLabelMode));
			LabelModeCombo.SelectedIndex = 0;

			FunnelGapScroll.Value = (int)funnel.FunnelPointGap;
			NeckWidthScroll.Value = (int)funnel.NeckWidthPercent;
			NeckHeightScroll.Value = (int)funnel.NeckHeightPercent;
			ArrowLengthScroll.Value = (int)funnel.DataLabelStyle.ArrowLength.Value;
		}

		private void LabelModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NFunnelSeries funnel = (NFunnelSeries)nChartControl1.Charts[0].Series[0];

			funnel.LabelMode = (FunnelLabelMode)LabelModeCombo.SelectedIndex;

			HorzAlign ha = HorzAlign.Center;

			switch(funnel.LabelMode)
			{
				case FunnelLabelMode.Left:
				case FunnelLabelMode.LeftAligned:
					ha = HorzAlign.Right;
					break;

				case FunnelLabelMode.Right:
				case FunnelLabelMode.RightAligned:
					ha = HorzAlign.Left;
					break;
			}

			funnel.DataLabelStyle.TextStyle.StringFormatStyle.HorzAlign = ha;

			nChartControl1.Refresh();
		}

		private void ArrowLengthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NFunnelSeries funnel = (NFunnelSeries)nChartControl1.Charts[0].Series[0];

			funnel.DataLabelStyle.ArrowLength = new NLength(ArrowLengthScroll.Value, NRelativeUnit.ParentPercentage);

			nChartControl1.Refresh();
		}

		private void FunnelGapScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NFunnelSeries funnel = (NFunnelSeries)nChartControl1.Charts[0].Series[0];

			funnel.FunnelPointGap = FunnelGapScroll.Value / 10.0f;

			nChartControl1.Refresh();
		}

		private void NeckWidthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NFunnelSeries funnel = (NFunnelSeries)nChartControl1.Charts[0].Series[0];

			funnel.NeckWidthPercent = NeckWidthScroll.Value;

			nChartControl1.Refresh();
		}

		private void NeckHeightScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NFunnelSeries funnel = (NFunnelSeries)nChartControl1.Charts[0].Series[0];

			funnel.NeckHeightPercent = NeckHeightScroll.Value;

			nChartControl1.Refresh();
		}

	}
}