using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using Nevron.Editors;
using Nevron.GraphicsCore;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NAxisInterlacedStripesUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private Nevron.UI.WinForm.Controls.NCheckBox YAxisInterlacedStripesCheckBox;
		private Nevron.UI.WinForm.Controls.NButton YAxisInterlacedStripeFillStyleButton;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox0;
		private Nevron.UI.WinForm.Controls.NNumericUpDown YAxisInterlacedStripesEnd;
		private Nevron.UI.WinForm.Controls.NNumericUpDown YAxisInterlacedStripesBegin;
		private Nevron.UI.WinForm.Controls.NCheckBox YAxisInterlacedStripesInfinite;
		private Nevron.UI.WinForm.Controls.NNumericUpDown YAxisInterlacedStripesLength;
		private Nevron.UI.WinForm.Controls.NNumericUpDown YAxisInterlacedStripeInterval;
		private Nevron.UI.WinForm.Controls.NNumericUpDown XAxisInterlacedStripesBegin;
		private Nevron.UI.WinForm.Controls.NButton XAxisInterlacedStripeFillStyleButton;
		private Nevron.UI.WinForm.Controls.NCheckBox XAxisInterlacedStripesCheckBox;
		private Nevron.UI.WinForm.Controls.NNumericUpDown XAxisInterlacedStripesEnd;
		private Nevron.UI.WinForm.Controls.NCheckBox XAxisInterlacedStripesInfinite;
		private Nevron.UI.WinForm.Controls.NNumericUpDown XAxisInterlacedStripesLength;
		private Nevron.UI.WinForm.Controls.NNumericUpDown XAxisInterlacedStripeInterval;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private NScaleStripStyle m_YAxisInterlaceStyle;
		private NScaleStripStyle m_XAxisInterlaceStyle;
		private NCartesianChart m_Chart;
		private bool m_Updating;

		public NAxisInterlacedStripesUC()
		{
			m_Updating = true;
			// This call is required by the Windows.Forms Form Designer.
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
			this.XAxisInterlacedStripeInterval = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.XAxisInterlacedStripesLength = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.XAxisInterlacedStripesEnd = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.XAxisInterlacedStripesInfinite = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.XAxisInterlacedStripesBegin = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.XAxisInterlacedStripeFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.XAxisInterlacedStripesCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.groupBox0 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.YAxisInterlacedStripeInterval = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.YAxisInterlacedStripesLength = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label9 = new System.Windows.Forms.Label();
			this.YAxisInterlacedStripesEnd = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label10 = new System.Windows.Forms.Label();
			this.YAxisInterlacedStripesInfinite = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.YAxisInterlacedStripesBegin = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label11 = new System.Windows.Forms.Label();
			this.YAxisInterlacedStripeFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.YAxisInterlacedStripesCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.XAxisInterlacedStripeInterval)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.XAxisInterlacedStripesLength)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.XAxisInterlacedStripesEnd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.XAxisInterlacedStripesBegin)).BeginInit();
			this.groupBox0.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.YAxisInterlacedStripeInterval)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.YAxisInterlacedStripesLength)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.YAxisInterlacedStripesEnd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.YAxisInterlacedStripesBegin)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.XAxisInterlacedStripeInterval);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.XAxisInterlacedStripesLength);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.XAxisInterlacedStripesEnd);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.XAxisInterlacedStripesInfinite);
			this.groupBox1.Controls.Add(this.XAxisInterlacedStripesBegin);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.XAxisInterlacedStripeFillStyleButton);
			this.groupBox1.Controls.Add(this.XAxisInterlacedStripesCheckBox);
			this.groupBox1.ImageIndex = 0;
			this.groupBox1.Location = new System.Drawing.Point(8, 240);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(168, 232);
			this.groupBox1.TabIndex = 58;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Horizontal interlacing";
			// 
			// XAxisInterlacedStripeInterval
			// 
			this.XAxisInterlacedStripeInterval.Location = new System.Drawing.Point(80, 200);
			this.XAxisInterlacedStripeInterval.Name = "XAxisInterlacedStripeInterval";
			this.XAxisInterlacedStripeInterval.Size = new System.Drawing.Size(72, 20);
			this.XAxisInterlacedStripeInterval.TabIndex = 10;
			this.XAxisInterlacedStripeInterval.ValueChanged += new System.EventHandler(this.XAxisInterlacedStripeInterval_ValueChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 200);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(48, 20);
			this.label7.TabIndex = 9;
			this.label7.Text = "Interval:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// XAxisInterlacedStripesLength
			// 
			this.XAxisInterlacedStripesLength.Location = new System.Drawing.Point(80, 168);
			this.XAxisInterlacedStripesLength.Name = "XAxisInterlacedStripesLength";
			this.XAxisInterlacedStripesLength.Size = new System.Drawing.Size(72, 20);
			this.XAxisInterlacedStripesLength.TabIndex = 8;
			this.XAxisInterlacedStripesLength.ValueChanged += new System.EventHandler(this.XAxisInterlacedStripesLength_ValueChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 168);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 20);
			this.label3.TabIndex = 7;
			this.label3.Text = "Length:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// XAxisInterlacedStripesEnd
			// 
			this.XAxisInterlacedStripesEnd.Location = new System.Drawing.Point(80, 112);
			this.XAxisInterlacedStripesEnd.Name = "XAxisInterlacedStripesEnd";
			this.XAxisInterlacedStripesEnd.Size = new System.Drawing.Size(72, 20);
			this.XAxisInterlacedStripesEnd.TabIndex = 6;
			this.XAxisInterlacedStripesEnd.ValueChanged += new System.EventHandler(this.XAxisInterlacedStripesEnd_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 112);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 20);
			this.label2.TabIndex = 5;
			this.label2.Text = "End:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// XAxisInterlacedStripesInfinite
			// 
			this.XAxisInterlacedStripesInfinite.Location = new System.Drawing.Point(80, 136);
			this.XAxisInterlacedStripesInfinite.Name = "XAxisInterlacedStripesInfinite";
			this.XAxisInterlacedStripesInfinite.Size = new System.Drawing.Size(72, 20);
			this.XAxisInterlacedStripesInfinite.TabIndex = 4;
			this.XAxisInterlacedStripesInfinite.Text = "Infinite";
			this.XAxisInterlacedStripesInfinite.CheckedChanged += new System.EventHandler(this.XAxisInterlacedStripesInfinite_CheckedChanged);
			// 
			// XAxisInterlacedStripesBegin
			// 
			this.XAxisInterlacedStripesBegin.Location = new System.Drawing.Point(80, 80);
			this.XAxisInterlacedStripesBegin.Name = "XAxisInterlacedStripesBegin";
			this.XAxisInterlacedStripesBegin.Size = new System.Drawing.Size(72, 20);
			this.XAxisInterlacedStripesBegin.TabIndex = 3;
			this.XAxisInterlacedStripesBegin.ValueChanged += new System.EventHandler(this.XAxisInterlacedStripesBegin_ValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 20);
			this.label1.TabIndex = 2;
			this.label1.Text = "Begin:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// XAxisInterlacedStripeFillStyleButton
			// 
			this.XAxisInterlacedStripeFillStyleButton.Location = new System.Drawing.Point(8, 48);
			this.XAxisInterlacedStripeFillStyleButton.Name = "XAxisInterlacedStripeFillStyleButton";
			this.XAxisInterlacedStripeFillStyleButton.Size = new System.Drawing.Size(152, 24);
			this.XAxisInterlacedStripeFillStyleButton.TabIndex = 1;
			this.XAxisInterlacedStripeFillStyleButton.Text = "Fill Style...";
			this.XAxisInterlacedStripeFillStyleButton.Click += new System.EventHandler(this.XAxisInterlacedStripeFillStyleButton_Click);
			// 
			// XAxisInterlacedStripesCheckBox
			// 
			this.XAxisInterlacedStripesCheckBox.Location = new System.Drawing.Point(8, 16);
			this.XAxisInterlacedStripesCheckBox.Name = "XAxisInterlacedStripesCheckBox";
			this.XAxisInterlacedStripesCheckBox.Size = new System.Drawing.Size(152, 24);
			this.XAxisInterlacedStripesCheckBox.TabIndex = 0;
			this.XAxisInterlacedStripesCheckBox.Text = "Enable";
			this.XAxisInterlacedStripesCheckBox.CheckedChanged += new System.EventHandler(this.XAxisInterlacedStripesCheckBox_CheckedChanged);
			// 
			// groupBox0
			// 
			this.groupBox0.Controls.Add(this.YAxisInterlacedStripeInterval);
			this.groupBox0.Controls.Add(this.label8);
			this.groupBox0.Controls.Add(this.YAxisInterlacedStripesLength);
			this.groupBox0.Controls.Add(this.label9);
			this.groupBox0.Controls.Add(this.YAxisInterlacedStripesEnd);
			this.groupBox0.Controls.Add(this.label10);
			this.groupBox0.Controls.Add(this.YAxisInterlacedStripesInfinite);
			this.groupBox0.Controls.Add(this.YAxisInterlacedStripesBegin);
			this.groupBox0.Controls.Add(this.label11);
			this.groupBox0.Controls.Add(this.YAxisInterlacedStripeFillStyleButton);
			this.groupBox0.Controls.Add(this.YAxisInterlacedStripesCheckBox);
			this.groupBox0.ImageIndex = 0;
			this.groupBox0.Location = new System.Drawing.Point(8, 8);
			this.groupBox0.Name = "groupBox0";
			this.groupBox0.Size = new System.Drawing.Size(168, 232);
			this.groupBox0.TabIndex = 59;
			this.groupBox0.TabStop = false;
			this.groupBox0.Text = "Vertical interlacing";
			// 
			// YAxisInterlacedStripeInterval
			// 
			this.YAxisInterlacedStripeInterval.Location = new System.Drawing.Point(80, 200);
			this.YAxisInterlacedStripeInterval.Name = "YAxisInterlacedStripeInterval";
			this.YAxisInterlacedStripeInterval.Size = new System.Drawing.Size(72, 20);
			this.YAxisInterlacedStripeInterval.TabIndex = 10;
			this.YAxisInterlacedStripeInterval.ValueChanged += new System.EventHandler(this.YAxisInterlacedStripeInterval_ValueChanged);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 200);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(48, 20);
			this.label8.TabIndex = 9;
			this.label8.Text = "Interval:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// YAxisInterlacedStripesLength
			// 
			this.YAxisInterlacedStripesLength.Location = new System.Drawing.Point(80, 168);
			this.YAxisInterlacedStripesLength.Name = "YAxisInterlacedStripesLength";
			this.YAxisInterlacedStripesLength.Size = new System.Drawing.Size(72, 20);
			this.YAxisInterlacedStripesLength.TabIndex = 8;
			this.YAxisInterlacedStripesLength.ValueChanged += new System.EventHandler(this.YAxisInterlacedStripesLength_ValueChanged);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 168);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(48, 20);
			this.label9.TabIndex = 7;
			this.label9.Text = "Length:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// YAxisInterlacedStripesEnd
			// 
			this.YAxisInterlacedStripesEnd.Location = new System.Drawing.Point(80, 112);
			this.YAxisInterlacedStripesEnd.Name = "YAxisInterlacedStripesEnd";
			this.YAxisInterlacedStripesEnd.Size = new System.Drawing.Size(72, 20);
			this.YAxisInterlacedStripesEnd.TabIndex = 6;
			this.YAxisInterlacedStripesEnd.ValueChanged += new System.EventHandler(this.YAxisInterlacedStripesEnd_ValueChanged);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(8, 112);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(48, 20);
			this.label10.TabIndex = 5;
			this.label10.Text = "End:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// YAxisInterlacedStripesInfinite
			// 
			this.YAxisInterlacedStripesInfinite.Location = new System.Drawing.Point(80, 136);
			this.YAxisInterlacedStripesInfinite.Name = "YAxisInterlacedStripesInfinite";
			this.YAxisInterlacedStripesInfinite.Size = new System.Drawing.Size(72, 20);
			this.YAxisInterlacedStripesInfinite.TabIndex = 4;
			this.YAxisInterlacedStripesInfinite.Text = "Infinite";
			this.YAxisInterlacedStripesInfinite.CheckedChanged += new System.EventHandler(this.YAxisInterlacedStripesInfinite_CheckedChanged);
			// 
			// YAxisInterlacedStripesBegin
			// 
			this.YAxisInterlacedStripesBegin.Location = new System.Drawing.Point(80, 80);
			this.YAxisInterlacedStripesBegin.Name = "YAxisInterlacedStripesBegin";
			this.YAxisInterlacedStripesBegin.Size = new System.Drawing.Size(72, 20);
			this.YAxisInterlacedStripesBegin.TabIndex = 3;
			this.YAxisInterlacedStripesBegin.Value = new System.Decimal(new int[] {
																					  2,
																					  0,
																					  0,
																					  0});
			this.YAxisInterlacedStripesBegin.ValueChanged += new System.EventHandler(this.YAxisInterlacedStripesBegin_ValueChanged);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(8, 80);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(48, 20);
			this.label11.TabIndex = 2;
			this.label11.Text = "Begin:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// YAxisInterlacedStripeFillStyleButton
			// 
			this.YAxisInterlacedStripeFillStyleButton.Location = new System.Drawing.Point(8, 48);
			this.YAxisInterlacedStripeFillStyleButton.Name = "YAxisInterlacedStripeFillStyleButton";
			this.YAxisInterlacedStripeFillStyleButton.Size = new System.Drawing.Size(152, 24);
			this.YAxisInterlacedStripeFillStyleButton.TabIndex = 1;
			this.YAxisInterlacedStripeFillStyleButton.Text = "Fill Style...";
			this.YAxisInterlacedStripeFillStyleButton.Click += new System.EventHandler(this.YAxisInterlacedStripeFillStyleButton_Click);
			// 
			// YAxisInterlacedStripesCheckBox
			// 
			this.YAxisInterlacedStripesCheckBox.Location = new System.Drawing.Point(8, 16);
			this.YAxisInterlacedStripesCheckBox.Name = "YAxisInterlacedStripesCheckBox";
			this.YAxisInterlacedStripesCheckBox.Size = new System.Drawing.Size(152, 24);
			this.YAxisInterlacedStripesCheckBox.TabIndex = 0;
			this.YAxisInterlacedStripesCheckBox.Text = "Enable";
			this.YAxisInterlacedStripesCheckBox.CheckedChanged += new System.EventHandler(this.YAxisInterlacedStripesCheckBox_CheckedChanged);
			// 
			// NAxisInterlacedStripesUC
			// 
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox0);
			this.Name = "NAxisInterlacedStripesUC";
			this.Size = new System.Drawing.Size(184, 528);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.XAxisInterlacedStripeInterval)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.XAxisInterlacedStripesLength)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.XAxisInterlacedStripesEnd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.XAxisInterlacedStripesBegin)).EndInit();
			this.groupBox0.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.YAxisInterlacedStripeInterval)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.YAxisInterlacedStripesLength)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.YAxisInterlacedStripesEnd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.YAxisInterlacedStripesBegin)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Interlaced Stripes");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			m_Chart = (NCartesianChart)nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;

			NLineSeries line = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			line.Name = "Line Series";
			line.DataLabelStyle.Format = "<value>";
			line.MarkerStyle.Visible = true;
			line.MarkerStyle.PointShape = PointShape.Sphere;
			line.LineSegmentShape = LineSegmentShape.Tape;
			line.BorderStyle.Width = new NLength(2, NGraphicsUnit.Point);
			line.DataLabelStyle.Visible = false;
			line.Values.FillRandom(Random, 20);
			line.ShadowStyle.Type = ShadowType.GaussianBlur;
			line.ShadowStyle.Offset = new NPointL(3, 3);
			line.ShadowStyle.FadeLength = new NLength(5);
			line.ShadowStyle.Color = Color.FromArgb(55, 0, 0, 0);

			m_YAxisInterlaceStyle = new NScaleStripStyle();
			m_YAxisInterlaceStyle.SetShowAtWall(ChartWallType.Back, true);
			m_YAxisInterlaceStyle.SetShowAtWall(ChartWallType.Left, true);
			m_YAxisInterlaceStyle.Interlaced = true;
			m_YAxisInterlaceStyle.FillStyle = new NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant1, Color.Beige, Color.FromArgb(254, 237, 226));
			m_YAxisInterlaceStyle.Begin = 0;
			m_YAxisInterlaceStyle.End = 10;
			m_YAxisInterlaceStyle.Infinite = true;
			m_YAxisInterlaceStyle.Interval = 1;
			m_YAxisInterlaceStyle.Length = 1;

			m_XAxisInterlaceStyle = new NScaleStripStyle();
			m_XAxisInterlaceStyle.FillStyle = new NGradientFillStyle(Color.FromArgb(125, 166, 166, 166), Color.FromArgb(125, 211, 211, 211));
			m_XAxisInterlaceStyle.SetShowAtWall(ChartWallType.Back, true);
			m_XAxisInterlaceStyle.SetShowAtWall(ChartWallType.Floor, true);
			m_XAxisInterlaceStyle.Interlaced = true;
			m_XAxisInterlaceStyle.Begin = 0;
			m_XAxisInterlaceStyle.End = 10;
			m_XAxisInterlaceStyle.Infinite = true;
			m_XAxisInterlaceStyle.Interval = 1;
			m_XAxisInterlaceStyle.Length = 1;

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// update controls
			YAxisInterlacedStripesBegin.Value = m_YAxisInterlaceStyle.Begin;
			YAxisInterlacedStripesEnd.Value = m_YAxisInterlaceStyle.End;
			YAxisInterlacedStripesInfinite.Checked = m_YAxisInterlaceStyle.Infinite;
			YAxisInterlacedStripesLength.Value = m_YAxisInterlaceStyle.Length;
			YAxisInterlacedStripeInterval.Value = m_YAxisInterlaceStyle.Interval;
			
			XAxisInterlacedStripesBegin.Value = m_XAxisInterlaceStyle.Begin;
			XAxisInterlacedStripesEnd.Value = m_XAxisInterlaceStyle.End;
			XAxisInterlacedStripesInfinite.Checked = m_XAxisInterlaceStyle.Infinite;
			XAxisInterlacedStripesLength.Value = m_XAxisInterlaceStyle.Length;
			XAxisInterlacedStripeInterval.Value = m_XAxisInterlaceStyle.Interval;

			m_Updating = false;

			YAxisInterlacedStripesCheckBox.Checked = true;
		}

		private void UpdateInterlaceStirpes()
		{
			if (m_Updating)
				return;

			NStandardScaleConfigurator standardScale = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			standardScale.StripStyles.Clear();
			if (YAxisInterlacedStripesCheckBox.Checked)
			{
				standardScale.StripStyles.Add(m_YAxisInterlaceStyle);
			}

			m_YAxisInterlaceStyle.Begin = (int)YAxisInterlacedStripesBegin.Value;
			m_YAxisInterlaceStyle.End = (int)YAxisInterlacedStripesEnd.Value;
			m_YAxisInterlaceStyle.Infinite = YAxisInterlacedStripesInfinite.Checked;
			m_YAxisInterlaceStyle.Length = (int)YAxisInterlacedStripesLength.Value;
			m_YAxisInterlaceStyle.Interval = (int)YAxisInterlacedStripeInterval.Value;
			
			standardScale = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;

			standardScale.StripStyles.Clear();
			if (XAxisInterlacedStripesCheckBox.Checked)
			{
				standardScale.StripStyles.Add(m_XAxisInterlaceStyle);
			}

			m_XAxisInterlaceStyle.Begin = (int)XAxisInterlacedStripesBegin.Value;
			m_XAxisInterlaceStyle.End = (int)XAxisInterlacedStripesEnd.Value;
			m_XAxisInterlaceStyle.Infinite = XAxisInterlacedStripesInfinite.Checked;
			m_XAxisInterlaceStyle.Length = (int)XAxisInterlacedStripesLength.Value;
			m_XAxisInterlaceStyle.Interval = (int)XAxisInterlacedStripeInterval.Value;

			nChartControl1.Refresh();
		}

		private void YAxisInterlacedStripesCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateInterlaceStirpes();
		}

		private void YAxisInterlacedStripeFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyle = null;

			if (NFillStyleTypeEditorNoAutomatic.Edit(m_YAxisInterlaceStyle.FillStyle, false, out fillStyle))
			{
				m_YAxisInterlaceStyle.FillStyle = fillStyle;
				nChartControl1.Refresh();
			}
		}

		private void YAxisInterlacedStripesBegin_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateInterlaceStirpes();
		}

		private void YAxisInterlacedStripesEnd_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateInterlaceStirpes();
		}

		private void YAxisInterlacedStripesInfinite_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateInterlaceStirpes();
		}

		private void YAxisInterlacedStripesLength_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateInterlaceStirpes();
		}

		private void YAxisInterlacedStripeInterval_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateInterlaceStirpes();
		}

		private void XAxisInterlacedStripesCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateInterlaceStirpes();
		}

		private void XAxisInterlacedStripeFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyle = null;

			if (NFillStyleTypeEditorNoAutomatic.Edit(m_XAxisInterlaceStyle.FillStyle, false, out fillStyle))
			{
				m_XAxisInterlaceStyle.FillStyle = fillStyle;
				nChartControl1.Refresh();
			}
		}

		private void XAxisInterlacedStripesBegin_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateInterlaceStirpes();
		}

		private void XAxisInterlacedStripesEnd_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateInterlaceStirpes();
		}

		private void XAxisInterlacedStripesInfinite_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateInterlaceStirpes();
		}

		private void XAxisInterlacedStripesLength_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateInterlaceStirpes();
		}

		private void XAxisInterlacedStripeInterval_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateInterlaceStirpes();
		}
	}
}
