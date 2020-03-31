using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NCustomRangeLabelsUC : NExampleBaseUC
	{
		NBarSeries m_Bar1;
		NBarSeries m_Bar2;
		private Nevron.UI.WinForm.Controls.NComboBox LabelTickModeComboBox;
		private Label label1;
		private Label label2;
		private Nevron.UI.WinForm.Controls.NNumericUpDown LabelAngleNumericUpDown;
		private Nevron.UI.WinForm.Controls.NCheckBox NorthAmericaCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox EuropeCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox AsiaCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox SouthAmericaCheckBox;
		private Label label3;
		private Nevron.UI.WinForm.Controls.NComboBox LabelVisibilityModeComboBox;
		private Nevron.UI.WinForm.Controls.NNumericUpDown TextPaddingNumericUpDown;
		private Label label4;
		private Nevron.UI.WinForm.Controls.NNumericUpDown TextOffsetNumericUpDown;
		private Label label5;
		private Label label6;
		private Nevron.UI.WinForm.Controls.NNumericUpDown TickPaddingNumericUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown TickOffsetNumericUpDown;
		private Label label7;
		private Label label8;
		private Nevron.UI.WinForm.Controls.NComboBox LabelFitModeComboBox;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox3;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public NCustomRangeLabelsUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.LabelTickModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.LabelAngleNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.NorthAmericaCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.EuropeCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.AsiaCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SouthAmericaCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.LabelVisibilityModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.TextPaddingNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.TextOffsetNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.TickPaddingNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.TickOffsetNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.LabelFitModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nGroupBox3 = new Nevron.UI.WinForm.Controls.NGroupBox();
			((System.ComponentModel.ISupportInitialize)(this.LabelAngleNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextPaddingNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextOffsetNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TickPaddingNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TickOffsetNumericUpDown)).BeginInit();
			this.nGroupBox2.SuspendLayout();
			this.nGroupBox1.SuspendLayout();
			this.nGroupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// LabelTickModeComboBox
			// 
			this.LabelTickModeComboBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.LabelTickModeComboBox.Location = new System.Drawing.Point(3, 81);
			this.LabelTickModeComboBox.Name = "LabelTickModeComboBox";
			this.LabelTickModeComboBox.Size = new System.Drawing.Size(173, 21);
			this.LabelTickModeComboBox.TabIndex = 3;
			this.LabelTickModeComboBox.SelectedIndexChanged += new System.EventHandler(this.LabelTickModeComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(3, 59);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(173, 22);
			this.label1.TabIndex = 2;
			this.label1.Text = "Label Tick Mode:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Location = new System.Drawing.Point(3, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(173, 22);
			this.label2.TabIndex = 5;
			this.label2.Text = "Angle: ";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// LabelAngleNumericUpDown
			// 
			this.LabelAngleNumericUpDown.Dock = System.Windows.Forms.DockStyle.Top;
			this.LabelAngleNumericUpDown.Location = new System.Drawing.Point(3, 38);
			this.LabelAngleNumericUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.LabelAngleNumericUpDown.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
			this.LabelAngleNumericUpDown.Name = "LabelAngleNumericUpDown";
			this.LabelAngleNumericUpDown.Size = new System.Drawing.Size(173, 20);
			this.LabelAngleNumericUpDown.TabIndex = 6;
			this.LabelAngleNumericUpDown.ValueChanged += new System.EventHandler(this.LabelAngleNumericUpDown_ValueChanged);
			// 
			// NorthAmericaCheckBox
			// 
			this.NorthAmericaCheckBox.AutoSize = true;
			this.NorthAmericaCheckBox.ButtonProperties.BorderOffset = 2;
			this.NorthAmericaCheckBox.Location = new System.Drawing.Point(3, 425);
			this.NorthAmericaCheckBox.Name = "NorthAmericaCheckBox";
			this.NorthAmericaCheckBox.Size = new System.Drawing.Size(93, 17);
			this.NorthAmericaCheckBox.TabIndex = 15;
			this.NorthAmericaCheckBox.Text = "North America";
			this.NorthAmericaCheckBox.UseVisualStyleBackColor = true;
			this.NorthAmericaCheckBox.CheckedChanged += new System.EventHandler(this.NorthAmericaCheckBox_CheckedChanged);
			// 
			// EuropeCheckBox
			// 
			this.EuropeCheckBox.AutoSize = true;
			this.EuropeCheckBox.ButtonProperties.BorderOffset = 2;
			this.EuropeCheckBox.Location = new System.Drawing.Point(3, 448);
			this.EuropeCheckBox.Name = "EuropeCheckBox";
			this.EuropeCheckBox.Size = new System.Drawing.Size(60, 17);
			this.EuropeCheckBox.TabIndex = 16;
			this.EuropeCheckBox.Text = "Europe";
			this.EuropeCheckBox.UseVisualStyleBackColor = true;
			this.EuropeCheckBox.CheckedChanged += new System.EventHandler(this.EuropeCheckBox_CheckedChanged);
			// 
			// AsiaCheckBox
			// 
			this.AsiaCheckBox.AutoSize = true;
			this.AsiaCheckBox.ButtonProperties.BorderOffset = 2;
			this.AsiaCheckBox.Location = new System.Drawing.Point(3, 471);
			this.AsiaCheckBox.Name = "AsiaCheckBox";
			this.AsiaCheckBox.Size = new System.Drawing.Size(46, 17);
			this.AsiaCheckBox.TabIndex = 17;
			this.AsiaCheckBox.Text = "Asia";
			this.AsiaCheckBox.UseVisualStyleBackColor = true;
			this.AsiaCheckBox.CheckedChanged += new System.EventHandler(this.AsiaCheckBox_CheckedChanged);
			// 
			// SouthAmericaCheckBox
			// 
			this.SouthAmericaCheckBox.AutoSize = true;
			this.SouthAmericaCheckBox.ButtonProperties.BorderOffset = 2;
			this.SouthAmericaCheckBox.Location = new System.Drawing.Point(3, 493);
			this.SouthAmericaCheckBox.Name = "SouthAmericaCheckBox";
			this.SouthAmericaCheckBox.Size = new System.Drawing.Size(95, 17);
			this.SouthAmericaCheckBox.TabIndex = 18;
			this.SouthAmericaCheckBox.Text = "South America";
			this.SouthAmericaCheckBox.UseVisualStyleBackColor = true;
			this.SouthAmericaCheckBox.CheckedChanged += new System.EventHandler(this.SouthAmericaCheckBox_CheckedChanged);
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Top;
			this.label3.Location = new System.Drawing.Point(3, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(173, 22);
			this.label3.TabIndex = 0;
			this.label3.Text = "Label Visibility Mode:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// LabelVisibilityModeComboBox
			// 
			this.LabelVisibilityModeComboBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.LabelVisibilityModeComboBox.Location = new System.Drawing.Point(3, 38);
			this.LabelVisibilityModeComboBox.Name = "LabelVisibilityModeComboBox";
			this.LabelVisibilityModeComboBox.Size = new System.Drawing.Size(173, 21);
			this.LabelVisibilityModeComboBox.TabIndex = 1;
			this.LabelVisibilityModeComboBox.SelectedIndexChanged += new System.EventHandler(this.LabelVisibilityModeComboBox_SelectedIndexChanged);
			// 
			// TextPaddingNumericUpDown
			// 
			this.TextPaddingNumericUpDown.Dock = System.Windows.Forms.DockStyle.Top;
			this.TextPaddingNumericUpDown.Location = new System.Drawing.Point(3, 122);
			this.TextPaddingNumericUpDown.Name = "TextPaddingNumericUpDown";
			this.TextPaddingNumericUpDown.Size = new System.Drawing.Size(173, 20);
			this.TextPaddingNumericUpDown.TabIndex = 14;
			this.TextPaddingNumericUpDown.ValueChanged += new System.EventHandler(this.TextPaddingNumericUpDown_ValueChanged);
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Top;
			this.label4.Location = new System.Drawing.Point(3, 100);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(173, 22);
			this.label4.TabIndex = 13;
			this.label4.Text = "Text Padding: ";
			this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// TextOffsetNumericUpDown
			// 
			this.TextOffsetNumericUpDown.Dock = System.Windows.Forms.DockStyle.Top;
			this.TextOffsetNumericUpDown.Location = new System.Drawing.Point(3, 80);
			this.TextOffsetNumericUpDown.Name = "TextOffsetNumericUpDown";
			this.TextOffsetNumericUpDown.Size = new System.Drawing.Size(173, 20);
			this.TextOffsetNumericUpDown.TabIndex = 10;
			this.TextOffsetNumericUpDown.ValueChanged += new System.EventHandler(this.TextOffsetNumericUpDown_ValueChanged);
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Top;
			this.label5.Location = new System.Drawing.Point(3, 58);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(173, 22);
			this.label5.TabIndex = 9;
			this.label5.Text = "Text Offset: ";
			this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label6
			// 
			this.label6.Dock = System.Windows.Forms.DockStyle.Top;
			this.label6.Location = new System.Drawing.Point(3, 58);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(173, 22);
			this.label6.TabIndex = 11;
			this.label6.Text = "Tick Padding:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// TickPaddingNumericUpDown
			// 
			this.TickPaddingNumericUpDown.Dock = System.Windows.Forms.DockStyle.Top;
			this.TickPaddingNumericUpDown.Location = new System.Drawing.Point(3, 80);
			this.TickPaddingNumericUpDown.Name = "TickPaddingNumericUpDown";
			this.TickPaddingNumericUpDown.Size = new System.Drawing.Size(173, 20);
			this.TickPaddingNumericUpDown.TabIndex = 12;
			this.TickPaddingNumericUpDown.ValueChanged += new System.EventHandler(this.TickPaddingNumericUpDown_ValueChanged);
			// 
			// TickOffsetNumericUpDown
			// 
			this.TickOffsetNumericUpDown.Dock = System.Windows.Forms.DockStyle.Top;
			this.TickOffsetNumericUpDown.Location = new System.Drawing.Point(3, 38);
			this.TickOffsetNumericUpDown.Name = "TickOffsetNumericUpDown";
			this.TickOffsetNumericUpDown.Size = new System.Drawing.Size(173, 20);
			this.TickOffsetNumericUpDown.TabIndex = 8;
			this.TickOffsetNumericUpDown.ValueChanged += new System.EventHandler(this.TickOffsetNumericUpDown_ValueChanged);
			// 
			// label7
			// 
			this.label7.Dock = System.Windows.Forms.DockStyle.Top;
			this.label7.Location = new System.Drawing.Point(3, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(173, 22);
			this.label7.TabIndex = 7;
			this.label7.Text = "Tick Offset:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label8
			// 
			this.label8.Dock = System.Windows.Forms.DockStyle.Top;
			this.label8.Location = new System.Drawing.Point(3, 102);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(173, 22);
			this.label8.TabIndex = 19;
			this.label8.Text = "Label Fit Mode:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// LabelFitModeComboBox
			// 
			this.LabelFitModeComboBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.LabelFitModeComboBox.Location = new System.Drawing.Point(3, 124);
			this.LabelFitModeComboBox.Name = "LabelFitModeComboBox";
			this.LabelFitModeComboBox.Size = new System.Drawing.Size(173, 21);
			this.LabelFitModeComboBox.TabIndex = 20;
			this.LabelFitModeComboBox.SelectedIndexChanged += new System.EventHandler(this.LabelFitModeComboBox_SelectedIndexChanged);
			// 
			// nGroupBox2
			// 
			this.nGroupBox2.Controls.Add(this.LabelFitModeComboBox);
			this.nGroupBox2.Controls.Add(this.label8);
			this.nGroupBox2.Controls.Add(this.LabelTickModeComboBox);
			this.nGroupBox2.Controls.Add(this.label1);
			this.nGroupBox2.Controls.Add(this.LabelVisibilityModeComboBox);
			this.nGroupBox2.Controls.Add(this.label3);
			this.nGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.nGroupBox2.ImageIndex = 0;
			this.nGroupBox2.Location = new System.Drawing.Point(0, 0);
			this.nGroupBox2.Name = "nGroupBox2";
			this.nGroupBox2.Size = new System.Drawing.Size(179, 152);
			this.nGroupBox2.TabIndex = 24;
			this.nGroupBox2.TabStop = false;
			this.nGroupBox2.Text = "Label Modes";
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.TextPaddingNumericUpDown);
			this.nGroupBox1.Controls.Add(this.label4);
			this.nGroupBox1.Controls.Add(this.TextOffsetNumericUpDown);
			this.nGroupBox1.Controls.Add(this.label5);
			this.nGroupBox1.Controls.Add(this.LabelAngleNumericUpDown);
			this.nGroupBox1.Controls.Add(this.label2);
			this.nGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(0, 152);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(179, 152);
			this.nGroupBox1.TabIndex = 25;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Label Text";
			// 
			// nGroupBox3
			// 
			this.nGroupBox3.Controls.Add(this.TickPaddingNumericUpDown);
			this.nGroupBox3.Controls.Add(this.label6);
			this.nGroupBox3.Controls.Add(this.TickOffsetNumericUpDown);
			this.nGroupBox3.Controls.Add(this.label7);
			this.nGroupBox3.Dock = System.Windows.Forms.DockStyle.Top;
			this.nGroupBox3.ImageIndex = 0;
			this.nGroupBox3.Location = new System.Drawing.Point(0, 304);
			this.nGroupBox3.Name = "nGroupBox3";
			this.nGroupBox3.Size = new System.Drawing.Size(179, 115);
			this.nGroupBox3.TabIndex = 26;
			this.nGroupBox3.TabStop = false;
			this.nGroupBox3.Text = "Label Ticks";
			// 
			// NCustomRangeLabelsUC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.nGroupBox3);
			this.Controls.Add(this.nGroupBox1);
			this.Controls.Add(this.nGroupBox2);
			this.Controls.Add(this.SouthAmericaCheckBox);
			this.Controls.Add(this.AsiaCheckBox);
			this.Controls.Add(this.EuropeCheckBox);
			this.Controls.Add(this.NorthAmericaCheckBox);
			this.Name = "NCustomRangeLabelsUC";
			this.Size = new System.Drawing.Size(179, 666);
			((System.ComponentModel.ISupportInitialize)(this.LabelAngleNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextPaddingNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextOffsetNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TickPaddingNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TickOffsetNumericUpDown)).EndInit();
			this.nGroupBox2.ResumeLayout(false);
			this.nGroupBox1.ResumeLayout(false);
			this.nGroupBox3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Company Sales by Region<br/><font size = '9pt'>Demonstrates how to use custom range labels to denote ranges on a scale</font>");
			header.DockMode = PanelDockMode.Top;
			header.Margins = new NMarginsL(0, 10, 0, 10);
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			header.TextStyle.TextFormat = TextFormat.XML;
			header.ContentAlignment = ContentAlignment.BottomRight;
			header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
			nChartControl1.Panels.Add(header);

			NLegend legend = new NLegend();
			legend.Margins = new NMarginsL(10, 0, 10, 0);
			legend.DockMode = PanelDockMode.Right;
			legend.FitAlignment = ContentAlignment.TopCenter;
			nChartControl1.Panels.Add(legend);

			NCartesianChart chart = new NCartesianChart();
			nChartControl1.Panels.Add(chart);

			chart.DisplayOnLegend = legend;
			chart.DockMode = PanelDockMode.Fill;
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Margins = new NMarginsL(10, 0, 0, 10);
			chart.Axis(StandardAxis.Depth).Visible = false;

			// add range selection
			NRangeSelection rangeSelection = new NRangeSelection();
			rangeSelection.VerticalValueSnapper = new NAxisRulerMinMaxSnapper();
			chart.RangeSelections.Add(rangeSelection);

			// add the first bar
			m_Bar1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			m_Bar1.Name = "Coca Cola";
			m_Bar1.MultiBarMode = MultiBarMode.Series;
			m_Bar1.DataLabelStyle.Format = "<value>";

			// add the second bar
			m_Bar2 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			m_Bar2.Name = "Pepsi";
			m_Bar2.MultiBarMode = MultiBarMode.Clustered;
			m_Bar2.DataLabelStyle.Format = "<value>";

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// add custom labels to the X axis
			NAxis xAxis = chart.Axis(StandardAxis.PrimaryX);
			xAxis.ScrollBar.Visible = true;
			NOrdinalScaleConfigurator ordinalScale = xAxis.ScaleConfigurator as NOrdinalScaleConfigurator;

			ordinalScale.AutoLabels = false;
			ordinalScale.OuterMajorTickStyle.Visible = false;
			ordinalScale.InnerMajorTickStyle.Visible = false;

			// add custom labels to the Y axis
			chart.Axis(StandardAxis.PrimaryY).View = new NRangeAxisView(new NRange1DD(0, 320));
			NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			linearScale.RoundToTickMax = false;
			NCustomRangeLabel rangeLabel = new NCustomRangeLabel(new NRange1DD(240, 320), "Target Volume");
			rangeLabel.Style.TickMode = RangeLabelTickMode.Center;
			rangeLabel.Style.WrapText = true;
			rangeLabel.Style.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);
			linearScale.CustomLabels.Add(rangeLabel);

			// add interlace stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			// configure interactivity
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NAxisScrollTool());
			nChartControl1.Controller.Tools.Add(new NDataZoomTool());

			// init form controls
			LabelTickModeComboBox.FillFromEnum(typeof(RangeLabelTickMode));
			LabelVisibilityModeComboBox.FillFromEnum(typeof(ScaleLabelVisibilityMode));
			LabelFitModeComboBox.FillFromEnum(typeof(RangeLabelFitMode));

			NRangeScaleLabelStyle defaultStyle = new NRangeScaleLabelStyle();

			LabelTickModeComboBox.SelectedIndex = (int)defaultStyle.TickMode;
			LabelVisibilityModeComboBox.SelectedIndex = (int)defaultStyle.VisibilityMode;
			LabelFitModeComboBox.SelectedIndex = (int)defaultStyle.FitMode;
			LabelAngleNumericUpDown.Value = (decimal)defaultStyle.Angle.CustomAngle;
			TickPaddingNumericUpDown.Value = (decimal)defaultStyle.TickPadding.Value;
			TickOffsetNumericUpDown.Value = (decimal)defaultStyle.TickOffset.Value;
			TextOffsetNumericUpDown.Value = (decimal)defaultStyle.Offset.Value;
			TextPaddingNumericUpDown.Value = (decimal)defaultStyle.TextPadding.Value;

			// add some data
			NorthAmericaCheckBox.Checked = true;
			EuropeCheckBox.Checked = true;
			AsiaCheckBox.Checked = true;
			SouthAmericaCheckBox.Checked = true;
		}

		private void ChangeDataButton_Click(object sender, EventArgs e)
		{
			// fill with random data
			m_Bar1.Values.FillRandomRange(Random, 6, 10, 200);
			m_Bar2.Values.FillRandomRange(Random, 6, 10, 300);
//			m_Bar2.Values[3] = 299.0;

			nChartControl1.Refresh();
		}

		private void UpdateRegions()
		{
			m_Bar1.Values.Clear();
			m_Bar2.Values.Clear();

			// add custom labels to the X axis
			NChart chart = nChartControl1.Charts[0];
			NOrdinalScaleConfigurator ordinalScale = chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			ordinalScale.Labels.Clear();
			ordinalScale.CustomLabels.Clear();

			if (NorthAmericaCheckBox.Checked)
			{
				ordinalScale.Labels.Add("USA");
				ordinalScale.Labels.Add("Canada");
				ordinalScale.Labels.Add("Mexico");

				NCustomRangeLabel rangeLabel = new NCustomRangeLabel();
				rangeLabel.Text = "Sales for North America";
				rangeLabel.Range = new NRange1DD(0, 2);
				ordinalScale.CustomLabels.Add(rangeLabel);

				m_Bar1.Values.Add(Random.Next(10, 300));
				m_Bar1.Values.Add(Random.Next(10, 300));
				m_Bar1.Values.Add(Random.Next(10, 300));

				m_Bar2.Values.Add(Random.Next(10, 300));
				m_Bar2.Values.Add(Random.Next(10, 300));
				m_Bar2.Values.Add(Random.Next(10, 300));
			}

			if (EuropeCheckBox.Checked)
			{
				ordinalScale.Labels.Add("Germany");
				ordinalScale.Labels.Add("UK");
				ordinalScale.Labels.Add("France");

				NCustomRangeLabel rangeLabel = new NCustomRangeLabel();
				rangeLabel.Text = "Sales for Europe";
				rangeLabel.Range = new NRange1DD(m_Bar1.Values.Count, m_Bar1.Values.Count + 2);
				ordinalScale.CustomLabels.Add(rangeLabel);

				m_Bar1.Values.Add(Random.Next(10, 300));
				m_Bar1.Values.Add(Random.Next(10, 300));
				m_Bar1.Values.Add(Random.Next(10, 300));

				m_Bar2.Values.Add(Random.Next(10, 300));
				m_Bar2.Values.Add(Random.Next(10, 300));
				m_Bar2.Values.Add(Random.Next(10, 300));

			}

			if (AsiaCheckBox.Checked)
			{
				ordinalScale.Labels.Add("Japan");
				ordinalScale.Labels.Add("China");
				ordinalScale.Labels.Add("South Korea");

				NCustomRangeLabel rangeLabel = new NCustomRangeLabel();
				rangeLabel.Text = "Sales for Asia";
				rangeLabel.Range = new NRange1DD(m_Bar1.Values.Count, m_Bar1.Values.Count + 2);
				ordinalScale.CustomLabels.Add(rangeLabel);

				m_Bar1.Values.Add(Random.Next(10, 300));
				m_Bar1.Values.Add(Random.Next(10, 300));
				m_Bar1.Values.Add(Random.Next(10, 300));

				m_Bar2.Values.Add(Random.Next(10, 300));
				m_Bar2.Values.Add(Random.Next(10, 300));
				m_Bar2.Values.Add(Random.Next(10, 300));
			}

			if (SouthAmericaCheckBox.Checked)
			{
				ordinalScale.Labels.Add("Brazil");
				ordinalScale.Labels.Add("Argentina");
				ordinalScale.Labels.Add("Venezuela");

				NCustomRangeLabel rangeLabel = new NCustomRangeLabel();
				rangeLabel.Text = "Sales for South America";
				rangeLabel.Range = new NRange1DD(m_Bar1.Values.Count, m_Bar1.Values.Count + 2);
				ordinalScale.CustomLabels.Add(rangeLabel);

				m_Bar1.Values.Add(Random.Next(10, 300));
				m_Bar1.Values.Add(Random.Next(10, 300));
				m_Bar1.Values.Add(Random.Next(10, 300));

				m_Bar2.Values.Add(Random.Next(10, 300));
				m_Bar2.Values.Add(Random.Next(10, 300));
				m_Bar2.Values.Add(Random.Next(10, 300));
			}

			UpdateLabels();
			nChartControl1.Refresh();
		}

		private void UpdateLabels()
		{
			// add custom labels to the Y axis
			NChart chart = nChartControl1.Charts[0];
			NOrdinalScaleConfigurator scale = chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;

			for (int i = 0; i < scale.CustomLabels.Count; i++)
			{
				NCustomRangeLabel rangeLabel = (NCustomRangeLabel)scale.CustomLabels[i];

				rangeLabel.Style.TickMode = (RangeLabelTickMode)LabelTickModeComboBox.SelectedIndex;
				rangeLabel.Style.VisibilityMode = (ScaleLabelVisibilityMode)LabelVisibilityModeComboBox.SelectedIndex;
				rangeLabel.Style.FitMode = FitModeFromIndex(LabelFitModeComboBox.SelectedIndex);
				rangeLabel.Style.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, (float)LabelAngleNumericUpDown.Value);
				rangeLabel.Style.TickPadding = new NLength((float)TickPaddingNumericUpDown.Value, NGraphicsUnit.Point);
				rangeLabel.Style.TickOffset = new NLength((float)TickOffsetNumericUpDown.Value, NGraphicsUnit.Point);
				rangeLabel.Style.Offset = new NLength((float)TextOffsetNumericUpDown.Value, NGraphicsUnit.Point);
				rangeLabel.Style.TextPadding = new NLength((float)TextPaddingNumericUpDown.Value, NGraphicsUnit.Point);
			}

			nChartControl1.Refresh();
		}

		private RangeLabelFitMode FitModeFromIndex(int index)
		{
			switch (index)
			{
				case 0: // None
					return RangeLabelFitMode.None;
				case 1: // Wrap
					return RangeLabelFitMode.Wrap;
				case 2: // Clip
					return RangeLabelFitMode.Clip;
				case 3:
					return RangeLabelFitMode.AutoFlip;
				case 4:
					return RangeLabelFitMode.AutoScale;
			}

			return RangeLabelFitMode.None;
		}

		private void NorthAmericaCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateRegions();
		}

		private void EuropeCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateRegions();
		}

		private void AsiaCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateRegions();
		}

		private void SouthAmericaCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateRegions();
		}

		private void LabelVisibilityModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateLabels();
		}

		private void LabelTickModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateLabels();
		}

		private void WrapTextCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateLabels();
		}

		private void LabelAngleNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateLabels();
		}

		private void TickOffsetNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateLabels();
		}

		private void TextOffsetNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateLabels();
		}

		private void TickPaddingNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateLabels();
		}

		private void TextPaddingNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateLabels();
		}

		private void LabelFitModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateLabels();
		}
	}
}