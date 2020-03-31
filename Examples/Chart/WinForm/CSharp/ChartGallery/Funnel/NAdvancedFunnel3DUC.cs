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
	public class NAdvancedFunnel3DUC : NExampleBaseUC
	{
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private Nevron.UI.WinForm.Controls.NHScrollBar ArrowLengthScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar FunnelGapScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar FunnelRadiusScroll;
		private Nevron.UI.WinForm.Controls.NComboBox LabelModeCombo;
		private Nevron.UI.WinForm.Controls.NButton NewDataButton;
		private System.ComponentModel.Container components = null;

		public NAdvancedFunnel3DUC()
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
			this.FunnelRadiusScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label9 = new System.Windows.Forms.Label();
			this.NewDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(7, 112);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(164, 16);
			this.label6.TabIndex = 4;
			this.label6.Text = "Funnel Label Mode:";
			// 
			// LabelModeCombo
			// 
			this.LabelModeCombo.ListProperties.CheckBoxDataMember = "";
			this.LabelModeCombo.ListProperties.DataSource = null;
			this.LabelModeCombo.ListProperties.DisplayMember = "";
			this.LabelModeCombo.Location = new System.Drawing.Point(7, 130);
			this.LabelModeCombo.Name = "LabelModeCombo";
			this.LabelModeCombo.Size = new System.Drawing.Size(164, 21);
			this.LabelModeCombo.TabIndex = 5;
			this.LabelModeCombo.SelectedIndexChanged += new System.EventHandler(this.LabelModeCombo_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(7, 164);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(164, 16);
			this.label7.TabIndex = 6;
			this.label7.Text = "Label Arrow Length:";
			// 
			// ArrowLengthScroll
			// 
			this.ArrowLengthScroll.LargeChange = 1;
			this.ArrowLengthScroll.Location = new System.Drawing.Point(7, 182);
			this.ArrowLengthScroll.Maximum = 20;
			this.ArrowLengthScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.ArrowLengthScroll.Name = "ArrowLengthScroll";
			this.ArrowLengthScroll.Size = new System.Drawing.Size(164, 16);
			this.ArrowLengthScroll.TabIndex = 7;
			this.ArrowLengthScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.ArrowLengthScroll_Scroll);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(164, 15);
			this.label2.TabIndex = 2;
			this.label2.Text = "Funnel Point Gap:";
			// 
			// FunnelGapScroll
			// 
			this.FunnelGapScroll.Location = new System.Drawing.Point(7, 66);
			this.FunnelGapScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.FunnelGapScroll.Name = "FunnelGapScroll";
			this.FunnelGapScroll.Size = new System.Drawing.Size(164, 16);
			this.FunnelGapScroll.TabIndex = 3;
			this.FunnelGapScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.FunnelGapScroll_Scroll);
			// 
			// FunnelRadiusScroll
			// 
			this.FunnelRadiusScroll.Location = new System.Drawing.Point(7, 27);
			this.FunnelRadiusScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.FunnelRadiusScroll.Name = "FunnelRadiusScroll";
			this.FunnelRadiusScroll.Size = new System.Drawing.Size(164, 16);
			this.FunnelRadiusScroll.TabIndex = 1;
			this.FunnelRadiusScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.FunnelRadiusScroll_Scroll);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(7, 9);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(164, 15);
			this.label9.TabIndex = 0;
			this.label9.Text = "Funnel Radius:";
			// 
			// NewDataButton
			// 
			this.NewDataButton.Location = new System.Drawing.Point(7, 240);
			this.NewDataButton.Name = "NewDataButton";
			this.NewDataButton.Size = new System.Drawing.Size(164, 28);
			this.NewDataButton.TabIndex = 8;
			this.NewDataButton.Text = "New Data";
			this.NewDataButton.Click += new System.EventHandler(this.NewDataButton_Click);
			// 
			// NAdvancedFunnel3DUC
			// 
			this.Controls.Add(this.NewDataButton);
			this.Controls.Add(this.FunnelRadiusScroll);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.FunnelGapScroll);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.ArrowLengthScroll);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.LabelModeCombo);
			this.Controls.Add(this.label6);
			this.Name = "NAdvancedFunnel3DUC";
			this.Size = new System.Drawing.Size(180, 290);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("3D Funnel Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			NLegend legend = nChartControl1.Legends[0];
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.BottomRight);

			NFunnelChart chart = new NFunnelChart();
			chart.Enable3D = true;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight);
			chart.Projection.Elevation = 15;

			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(chart);

			NFunnelSeries funnel = (NFunnelSeries)chart.Series.Add(SeriesType.Funnel);
			funnel.BorderStyle.Color = Color.LemonChiffon;
			funnel.Legend.DisplayOnLegend = legend;
			funnel.Legend.Format = "<percent>";
			funnel.Legend.Mode = SeriesLegendMode.DataPoints;
			funnel.DataLabelStyle.Format = "<value> [<xsize>]";
			funnel.UseXSizes = true;
			funnel.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			funnel.XSizes.ValueFormatter = new NNumericValueFormatter("0.00");

			GenerateData(funnel);

			// init form controls
			LabelModeCombo.FillFromEnum(typeof(FunnelLabelMode));
			LabelModeCombo.SelectedIndex = 4;

			FunnelGapScroll.Value = 6;
			FunnelRadiusScroll.Value = (int)chart.Width;
			ArrowLengthScroll.Value = (int)funnel.DataLabelStyle.ArrowLength.Value;
		}


		private void GenerateData(NFunnelSeries funnel)
		{
			funnel.ClearDataPoints();

			double dSizeX = 100;
            NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Fresh);

			for(int i = 0; i < 10; i++)
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

			funnel.DataLabelStyle.ArrowLength = new NLength(ArrowLengthScroll.Value, NRelativeUnit.ParentPercentage);

			nChartControl1.Refresh();
		}

		private void FunnelRadiusScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			nChartControl1.Charts[0].Width = FunnelRadiusScroll.Value;
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