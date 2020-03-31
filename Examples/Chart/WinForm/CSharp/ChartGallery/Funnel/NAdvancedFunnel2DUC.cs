using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NAdvancedFunnel2DUC : NExampleBaseUC
	{
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private Nevron.UI.WinForm.Controls.NHScrollBar ArrowLengthScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar FunnelGapScroll;
		private Nevron.UI.WinForm.Controls.NComboBox LabelModeCombo;
		private Nevron.UI.WinForm.Controls.NButton NewDataButton;
		private System.ComponentModel.Container components = null;

		public NAdvancedFunnel2DUC()
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
			this.label6 = new System.Windows.Forms.Label();
			this.LabelModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.ArrowLengthScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label2 = new System.Windows.Forms.Label();
			this.FunnelGapScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.NewDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(11, 74);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(158, 16);
			this.label6.TabIndex = 2;
			this.label6.Text = "Funnel Label Mode:";
			// 
			// LabelModeCombo
			// 
			this.LabelModeCombo.ListProperties.CheckBoxDataMember = "";
			this.LabelModeCombo.ListProperties.DataSource = null;
			this.LabelModeCombo.ListProperties.DisplayMember = "";
			this.LabelModeCombo.Location = new System.Drawing.Point(11, 92);
			this.LabelModeCombo.Name = "LabelModeCombo";
			this.LabelModeCombo.Size = new System.Drawing.Size(158, 21);
			this.LabelModeCombo.TabIndex = 3;
			this.LabelModeCombo.SelectedIndexChanged += new System.EventHandler(this.LabelModeCombo_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(11, 126);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(158, 16);
			this.label7.TabIndex = 4;
			this.label7.Text = "Label Arrow Length:";
			// 
			// ArrowLengthScroll
			// 
			this.ArrowLengthScroll.LargeChange = 1;
			this.ArrowLengthScroll.Location = new System.Drawing.Point(11, 144);
			this.ArrowLengthScroll.Maximum = 20;
			this.ArrowLengthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.ArrowLengthScroll.Name = "ArrowLengthScroll";
			this.ArrowLengthScroll.Size = new System.Drawing.Size(158, 16);
			this.ArrowLengthScroll.TabIndex = 5;
			this.ArrowLengthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.ArrowLengthScroll_Scroll);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(11, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(158, 15);
			this.label2.TabIndex = 0;
			this.label2.Text = "Funnel Point Gap:";
			// 
			// FunnelGapScroll
			// 
			this.FunnelGapScroll.Location = new System.Drawing.Point(11, 28);
			this.FunnelGapScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.FunnelGapScroll.Name = "FunnelGapScroll";
			this.FunnelGapScroll.Size = new System.Drawing.Size(158, 16);
			this.FunnelGapScroll.TabIndex = 1;
			this.FunnelGapScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.FunnelGapScroll_Scroll);
			// 
			// NewDataButton
			// 
			this.NewDataButton.Location = new System.Drawing.Point(11, 202);
			this.NewDataButton.Name = "NewDataButton";
			this.NewDataButton.Size = new System.Drawing.Size(158, 28);
			this.NewDataButton.TabIndex = 6;
			this.NewDataButton.Text = "New Data";
			this.NewDataButton.Click += new System.EventHandler(this.NewDataButton_Click);
			// 
			// NAdvancedFunnel2DUC
			// 
			this.Controls.Add(this.NewDataButton);
			this.Controls.Add(this.FunnelGapScroll);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.ArrowLengthScroll);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.LabelModeCombo);
			this.Controls.Add(this.label6);
			this.Name = "NAdvancedFunnel2DUC";
			this.Size = new System.Drawing.Size(180, 249);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("2D Funnel Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Offset = new NPointL(1.5f, 1.5f);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			NLegend legend = nChartControl1.Legends[0];
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.BottomRight);

            NFunnelChart chart = new NFunnelChart();
            chart.Location = new NPointL(new NLength(20, NRelativeUnit.ParentPercentage), new NLength(10, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(new NLength(60, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
			chart.BoundsMode = BoundsMode.Stretch;
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(chart);

			// configure funnel series
			NFunnelSeries funnel = (NFunnelSeries)chart.Series.Add(SeriesType.Funnel);
			funnel.BorderStyle.Color = Color.LemonChiffon;
			funnel.Legend.DisplayOnLegend = legend;
			funnel.Legend.Format = "<percent>";
			funnel.Legend.Mode = SeriesLegendMode.DataPoints;
			funnel.DataLabelStyle.Format = "<value> [<xsize>]";
			funnel.UseXSizes = true;
			funnel.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			funnel.XSizes.ValueFormatter = new NNumericValueFormatter("0.00");

			// configure shadow
			funnel.ShadowStyle.Type = ShadowType.GaussianBlur;
			funnel.ShadowStyle.Color = Color.FromArgb(50, 0, 0, 0);
			funnel.ShadowStyle.Offset = new NPointL(5, 5);
			funnel.ShadowStyle.FadeLength = new NLength(6);

			GenerateData(funnel);

			// init form controls
			LabelModeCombo.FillFromEnum(typeof(FunnelLabelMode));
			LabelModeCombo.SelectedIndex = 4;

			FunnelGapScroll.Value = 6;
			ArrowLengthScroll.Value = (int)funnel.DataLabelStyle.ArrowLength.Value;
		}

		private void GenerateData(NFunnelSeries funnel)
		{
			funnel.ClearDataPoints();

			double dSizeX = 100;

            NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Fresh);
            for (int i = 0; i < 10; i++)
            {
                funnel.Values.Add(Random.NextDouble() + 1);
                funnel.XSizes.Add(dSizeX);
                funnel.FillStyles[i] = new NColorFillStyle(palette.SeriesColors[i % palette.SeriesColors.Count]);

				dSizeX -= Random.NextDouble() * 9;
			}

			funnel.Values.Add(0.0);
			funnel.XSizes.Add(dSizeX);
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

			funnel.DataLabelStyle.ArrowLength = new NLength(ArrowLengthScroll.Value, NGraphicsUnit.Point);

			nChartControl1.Refresh();
		}

		private void FunnelGapScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NFunnelSeries funnel = (NFunnelSeries)nChartControl1.Charts[0].Series[0];

			funnel.FunnelPointGap = FunnelGapScroll.Value / 10.0f;

			nChartControl1.Refresh();
		}

		private void NewDataButton_Click(object sender, System.EventArgs e)
		{
			NFunnelSeries funnel = (NFunnelSeries)nChartControl1.Charts[0].Series[0];

			GenerateData(funnel);

			nChartControl1.Refresh();
		}
	}
}