using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Resources;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.Functions;
using Nevron.Chart.WinForm;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NPieDataPointAnchorUC : NExampleBaseUC
	{
		private Label label1;
		private Label label2;
		private Nevron.UI.WinForm.Controls.NNumericUpDown DataPointIndexUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown AnchorPositionUpDown;
		private Nevron.UI.WinForm.Controls.NButton ChangeDataButton;
		private System.ComponentModel.Container components = null;

		public NPieDataPointAnchorUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
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
			this.DataPointIndexUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.AnchorPositionUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.ChangeDataButton = new Nevron.UI.WinForm.Controls.NButton();
			((System.ComponentModel.ISupportInitialize)(this.DataPointIndexUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.AnchorPositionUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 61);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(171, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Data Point Index:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DataPointIndexUpDown
			// 
			this.DataPointIndexUpDown.Location = new System.Drawing.Point(4, 84);
			this.DataPointIndexUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.DataPointIndexUpDown.Name = "DataPointIndexUpDown";
			this.DataPointIndexUpDown.Size = new System.Drawing.Size(171, 20);
			this.DataPointIndexUpDown.TabIndex = 2;
			this.DataPointIndexUpDown.ValueChanged += new System.EventHandler(this.DataPointIndexUpDown_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 127);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(171, 20);
			this.label2.TabIndex = 3;
			this.label2.Text = "Anchor Position:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AnchorPositionUpDown
			// 
			this.AnchorPositionUpDown.DecimalPlaces = 2;
			this.AnchorPositionUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.AnchorPositionUpDown.Location = new System.Drawing.Point(4, 150);
			this.AnchorPositionUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.AnchorPositionUpDown.Name = "AnchorPositionUpDown";
			this.AnchorPositionUpDown.Size = new System.Drawing.Size(171, 20);
			this.AnchorPositionUpDown.TabIndex = 4;
			this.AnchorPositionUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.AnchorPositionUpDown.ValueChanged += new System.EventHandler(this.AnchorPositionUpDown_ValueChanged);
			// 
			// ChangeDataButton
			// 
			this.ChangeDataButton.Location = new System.Drawing.Point(4, 12);
			this.ChangeDataButton.Name = "ChangeDataButton";
			this.ChangeDataButton.Size = new System.Drawing.Size(171, 24);
			this.ChangeDataButton.TabIndex = 0;
			this.ChangeDataButton.Text = "Change Data";
			this.ChangeDataButton.Click += new System.EventHandler(this.ChangeDataButton_Click);
			// 
			// NPieDataPointAnchorUC
			// 
			this.Controls.Add(this.ChangeDataButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.AnchorPositionUpDown);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.DataPointIndexUpDown);
			this.Name = "NPieDataPointAnchorUC";
			this.Size = new System.Drawing.Size(180, 262);
			((System.ComponentModel.ISupportInitialize)(this.DataPointIndexUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.AnchorPositionUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// Create title label
			NLabel title = new NLabel("Pie Data Point Anchor");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// Create a pie chart
			NPieChart chart = new NPieChart();
			chart.Enable3D = false;

			// Create a pie series with 6 data points
			NPieSeries pieSeries = new NPieSeries();
			chart.Series.Add(pieSeries);
			pieSeries.DataLabelStyle.Visible = true;
			pieSeries.LabelMode = PieLabelMode.SpiderNoOverlap;
			GenerateData(pieSeries);

			// Create a rounded rect callout
			NRoundedRectangularCallout callout = new NRoundedRectangularCallout();
			callout.ArrowLength = new NLength(20, NGraphicsUnit.Point);
			callout.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(125, Color.White), Color.FromArgb(125, Color.LightGreen));
			callout.UseAutomaticSize = true;
			callout.Orientation = 80;
			callout.ContentAlignment = ContentAlignment.TopLeft;
			callout.Text = "Annotation";
			callout.TextStyle.FontStyle.EmSize = new NLength(8);

			// Anchor the callout to pie data point #0
			NPieDataPointAnchor anchor = new NPieDataPointAnchor(pieSeries, 0, 0.8f, StringAlignment.Near);
			callout.Anchor = anchor;

			// add title and chart panels
			ConfigureStandardLayout(chart, title, null);

			// add the annotation panel
			nChartControl1.Panels.Add(callout);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
			styleSheet.Apply(nChartControl1.Document);

			// init form controla
			DataPointIndexUpDown.Value = anchor.DataPointIndex;
			AnchorPositionUpDown.Value = (decimal)anchor.RadialPosition;
		}

		private void GenerateData(NPieSeries pieSeries)
		{
			Random rand = new Random();

			pieSeries.Values.FillRandomRange(rand, 6, 1, 5);
		}

		private void ChangeDataButton_Click(object sender, EventArgs e)
		{
			NPieSeries pieSeries = (NPieSeries)nChartControl1.Charts[0].Series[0];

			GenerateData(pieSeries);

			nChartControl1.Refresh();
		}
		private void DataPointIndexUpDown_ValueChanged(object sender, EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			NRoundedRectangularCallout callout = nChartControl1.Panels[2] as NRoundedRectangularCallout;
			if (callout == null)
				return;

			NPieDataPointAnchor anchor = callout.Anchor as NPieDataPointAnchor;
			if (anchor == null)
				return;

			anchor.DataPointIndex = (int)DataPointIndexUpDown.Value;
			nChartControl1.Refresh();
		}
		private void AnchorPositionUpDown_ValueChanged(object sender, EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			NRoundedRectangularCallout callout = nChartControl1.Panels[2] as NRoundedRectangularCallout;
			if (callout == null)
				return;

			NPieDataPointAnchor anchor = callout.Anchor as NPieDataPointAnchor;
			if (anchor == null)
				return;

			anchor.RadialPosition = (float)AnchorPositionUpDown.Value;
			nChartControl1.Refresh();
		}
	}
}
