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
	public class NAxisViewRangeInflateUC : NExampleBaseUC
	{
		private bool m_Updating;
		private Nevron.UI.WinForm.Controls.NGroupBox LogicalInflateGroupBox;
		private Nevron.UI.WinForm.Controls.NGroupBox AbsoluteInflateGroupBox;
		private Nevron.UI.WinForm.Controls.NNumericUpDown LogicalInflateMaxNumericUpDown;
		private Label label1;
		private Nevron.UI.WinForm.Controls.NNumericUpDown LogicalInflateMinNumericUpDown;
		private Label label6;
		private Label label5;
		private Label label4;
		private Nevron.UI.WinForm.Controls.NNumericUpDown AbsoluteInflateMaxNumericUpDown;
		private Label label2;
		private Label label3;
		private Nevron.UI.WinForm.Controls.NNumericUpDown AbsoluteInflateMinNumericUpDown;
		private Nevron.UI.WinForm.Controls.NCheckBox InflateViewRangeMinCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox InflateViewRangeMaxCheckBox;
		private Label label7;
		private Nevron.UI.WinForm.Controls.NComboBox ViewRangeInflateModeComboBox;
		private System.ComponentModel.Container components = null;

		public NAxisViewRangeInflateUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
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
			this.LogicalInflateGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.LogicalInflateMaxNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.LogicalInflateMinNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.AbsoluteInflateGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.AbsoluteInflateMaxNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.AbsoluteInflateMinNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.InflateViewRangeMinCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.InflateViewRangeMaxCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.ViewRangeInflateModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.LogicalInflateGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LogicalInflateMaxNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LogicalInflateMinNumericUpDown)).BeginInit();
			this.AbsoluteInflateGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.AbsoluteInflateMaxNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.AbsoluteInflateMinNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// LogicalInflateGroupBox
			// 
			this.LogicalInflateGroupBox.Controls.Add(this.LogicalInflateMaxNumericUpDown);
			this.LogicalInflateGroupBox.Controls.Add(this.label1);
			this.LogicalInflateGroupBox.Controls.Add(this.LogicalInflateMinNumericUpDown);
			this.LogicalInflateGroupBox.Controls.Add(this.label6);
			this.LogicalInflateGroupBox.ImageIndex = 0;
			this.LogicalInflateGroupBox.Location = new System.Drawing.Point(3, 116);
			this.LogicalInflateGroupBox.Name = "LogicalInflateGroupBox";
			this.LogicalInflateGroupBox.Size = new System.Drawing.Size(176, 74);
			this.LogicalInflateGroupBox.TabIndex = 4;
			this.LogicalInflateGroupBox.TabStop = false;
			this.LogicalInflateGroupBox.Text = "Logical Inflate";
			// 
			// LogicalInflateMaxNumericUpDown
			// 
			this.LogicalInflateMaxNumericUpDown.Location = new System.Drawing.Point(74, 43);
			this.LogicalInflateMaxNumericUpDown.Name = "LogicalInflateMaxNumericUpDown";
			this.LogicalInflateMaxNumericUpDown.Size = new System.Drawing.Size(65, 20);
			this.LogicalInflateMaxNumericUpDown.TabIndex = 3;
			this.LogicalInflateMaxNumericUpDown.ValueChanged += new System.EventHandler(this.LogicalInflateMaxNumericUpDown_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 50);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Inflate Max:";
			// 
			// LogicalInflateMinNumericUpDown
			// 
			this.LogicalInflateMinNumericUpDown.Location = new System.Drawing.Point(74, 17);
			this.LogicalInflateMinNumericUpDown.Name = "LogicalInflateMinNumericUpDown";
			this.LogicalInflateMinNumericUpDown.Size = new System.Drawing.Size(65, 20);
			this.LogicalInflateMinNumericUpDown.TabIndex = 1;
			this.LogicalInflateMinNumericUpDown.ValueChanged += new System.EventHandler(this.LogicalInflateMinNumericUpDown_ValueChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(9, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(59, 13);
			this.label6.TabIndex = 0;
			this.label6.Text = "Inflate Min:";
			// 
			// AbsoluteInflateGroupBox
			// 
			this.AbsoluteInflateGroupBox.Controls.Add(this.label5);
			this.AbsoluteInflateGroupBox.Controls.Add(this.label4);
			this.AbsoluteInflateGroupBox.Controls.Add(this.AbsoluteInflateMaxNumericUpDown);
			this.AbsoluteInflateGroupBox.Controls.Add(this.label2);
			this.AbsoluteInflateGroupBox.Controls.Add(this.label3);
			this.AbsoluteInflateGroupBox.Controls.Add(this.AbsoluteInflateMinNumericUpDown);
			this.AbsoluteInflateGroupBox.ImageIndex = 0;
			this.AbsoluteInflateGroupBox.Location = new System.Drawing.Point(3, 196);
			this.AbsoluteInflateGroupBox.Name = "AbsoluteInflateGroupBox";
			this.AbsoluteInflateGroupBox.Size = new System.Drawing.Size(176, 81);
			this.AbsoluteInflateGroupBox.TabIndex = 5;
			this.AbsoluteInflateGroupBox.TabStop = false;
			this.AbsoluteInflateGroupBox.Text = "Absolute Inflate";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(145, 53);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(16, 13);
			this.label5.TabIndex = 5;
			this.label5.Text = "pt";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(145, 27);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(16, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "pt";
			// 
			// AbsoluteInflateMaxNumericUpDown
			// 
			this.AbsoluteInflateMaxNumericUpDown.Location = new System.Drawing.Point(74, 46);
			this.AbsoluteInflateMaxNumericUpDown.Name = "AbsoluteInflateMaxNumericUpDown";
			this.AbsoluteInflateMaxNumericUpDown.Size = new System.Drawing.Size(65, 20);
			this.AbsoluteInflateMaxNumericUpDown.TabIndex = 4;
			this.AbsoluteInflateMaxNumericUpDown.ValueChanged += new System.EventHandler(this.AbsoluteInflateMaxNumericUpDown_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Inflate Max:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 27);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Inflate Min:";
			// 
			// AbsoluteInflateMinNumericUpDown
			// 
			this.AbsoluteInflateMinNumericUpDown.Location = new System.Drawing.Point(74, 20);
			this.AbsoluteInflateMinNumericUpDown.Name = "AbsoluteInflateMinNumericUpDown";
			this.AbsoluteInflateMinNumericUpDown.Size = new System.Drawing.Size(65, 20);
			this.AbsoluteInflateMinNumericUpDown.TabIndex = 1;
			this.AbsoluteInflateMinNumericUpDown.ValueChanged += new System.EventHandler(this.AbsoluteInflateMinNumericUpDown_ValueChanged);
			// 
			// InflateViewRangeMinCheckBox
			// 
			this.InflateViewRangeMinCheckBox.AutoSize = true;
			this.InflateViewRangeMinCheckBox.ButtonProperties.BorderOffset = 2;
			this.InflateViewRangeMinCheckBox.Location = new System.Drawing.Point(15, 69);
			this.InflateViewRangeMinCheckBox.Name = "InflateViewRangeMinCheckBox";
			this.InflateViewRangeMinCheckBox.Size = new System.Drawing.Size(75, 17);
			this.InflateViewRangeMinCheckBox.TabIndex = 2;
			this.InflateViewRangeMinCheckBox.Text = "Inflate Min";
			this.InflateViewRangeMinCheckBox.UseVisualStyleBackColor = true;
			this.InflateViewRangeMinCheckBox.CheckedChanged += new System.EventHandler(this.InflateViewRangeMinCheckBox_CheckedChanged);
			// 
			// InflateViewRangeMaxCheckBox
			// 
			this.InflateViewRangeMaxCheckBox.AutoSize = true;
			this.InflateViewRangeMaxCheckBox.ButtonProperties.BorderOffset = 2;
			this.InflateViewRangeMaxCheckBox.Location = new System.Drawing.Point(15, 89);
			this.InflateViewRangeMaxCheckBox.Name = "InflateViewRangeMaxCheckBox";
			this.InflateViewRangeMaxCheckBox.Size = new System.Drawing.Size(78, 17);
			this.InflateViewRangeMaxCheckBox.TabIndex = 3;
			this.InflateViewRangeMaxCheckBox.Text = "Inflate Max";
			this.InflateViewRangeMaxCheckBox.UseVisualStyleBackColor = true;
			this.InflateViewRangeMaxCheckBox.CheckedChanged += new System.EventHandler(this.InflateViewRangeMaxCheckBox_CheckedChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(15, 18);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(130, 13);
			this.label7.TabIndex = 0;
			this.label7.Text = "View Range Inflate Mode:";
			// 
			// ViewRangeInflateModeComboBox
			// 
			this.ViewRangeInflateModeComboBox.Location = new System.Drawing.Point(15, 34);
			this.ViewRangeInflateModeComboBox.Name = "ViewRangeInflateModeComboBox";
			this.ViewRangeInflateModeComboBox.Size = new System.Drawing.Size(164, 21);
			this.ViewRangeInflateModeComboBox.TabIndex = 1;
			this.ViewRangeInflateModeComboBox.SelectedIndexChanged += new System.EventHandler(this.ViewRangeInflateModeComboBox_SelectedIndexChanged);
			// 
			// NAxisViewRangeInflateUC
			// 
			this.Controls.Add(this.ViewRangeInflateModeComboBox);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.InflateViewRangeMaxCheckBox);
			this.Controls.Add(this.InflateViewRangeMinCheckBox);
			this.Controls.Add(this.AbsoluteInflateGroupBox);
			this.Controls.Add(this.LogicalInflateGroupBox);
			this.Name = "NAxisViewRangeInflateUC";
			this.Size = new System.Drawing.Size(192, 394);
			this.LogicalInflateGroupBox.ResumeLayout(false);
			this.LogicalInflateGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.LogicalInflateMaxNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LogicalInflateMinNumericUpDown)).EndInit();
			this.AbsoluteInflateGroupBox.ResumeLayout(false);
			this.AbsoluteInflateGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.AbsoluteInflateMaxNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.AbsoluteInflateMinNumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion


		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = new NLabel("Bank Product and Service Volume Change vs. Last Year<br/> <font size = '9pt'>Demonstrates how to use the view range inflate mode property</font>");
			title.TextStyle.TextFormat = TextFormat.XML;
			title.DockMode = PanelDockMode.Top;
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Center;
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
			title.Margins = new NMarginsL(10, 10, 10, 10);

			nChartControl1.Panels.Add(title);

			// add some data to the control
			NCartesianChart chart = new NCartesianChart();
			chart.DockMode = PanelDockMode.Fill;
			chart.BoundsMode = BoundsMode.Stretch;

			NBarSeries bar = new NBarSeries();
			bar.DataLabelStyle.Visible = false;

			NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Fresh);

			bar.Values.Add(100);
			bar.FillStyles[0] = new NColorFillStyle(palette.SeriesColors[0]);

			bar.Values.Add(200);
			bar.FillStyles[1] = new NColorFillStyle(palette.SeriesColors[0]);

			bar.Values.Add(1100);
			bar.FillStyles[2] = new NColorFillStyle(palette.SeriesColors[0]);

			bar.Values.Add(-200);
			bar.FillStyles[3] = new NColorFillStyle(palette.SeriesColors[1]);

			bar.Values.Add(200);
			bar.FillStyles[4] = new NColorFillStyle(palette.SeriesColors[1]);

			bar.Values.Add(1800);
			bar.FillStyles[5] = new NColorFillStyle(palette.SeriesColors[1]);

			bar.Values.Add(1000);
			bar.FillStyles[6] = new NColorFillStyle(palette.SeriesColors[1]);

			bar.Values.Add(-320);
			bar.FillStyles[7] = new NColorFillStyle(palette.SeriesColors[1]);

			chart.Series.Add(bar);

			chart.Margins = new NMarginsL(10, 0, 10, 10);

			// configure y axis
			NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;

			// add interlace stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			// configure the x axis
			NHierarchicalScaleConfigurator hierarchicalScale = new NHierarchicalScaleConfigurator();
			hierarchicalScale.CreateSeparatorForEachLevel = false;

			// create utilization group
			NHierarchicalScaleNode utilization = new NHierarchicalScaleNode(0, "Cash Utilisation");

			utilization.LabelStyle.TickMode = RangeLabelTickMode.Separators;
			utilization.LabelStyle.TextStyle.FontStyle.EmSize = new NLength(13);
			utilization.LabelStyle.TextStyle.FontStyle.Style = FontStyle.Bold;

			utilization.ChildNodes.Add(CreateSubScaleNode("Cash at ATM", true, false));
			utilization.ChildNodes.Add(CreateSubScaleNode("Cash at desk", true, false));
			utilization.ChildNodes.Add(CreateSubScaleNode("Cash at other banks' ATM networks", true, false));
			hierarchicalScale.Nodes.Add(utilization);

			// create payments group
			NHierarchicalScaleNode payments = new NHierarchicalScaleNode(0, "Payments");

			payments.LabelStyle.TickMode = RangeLabelTickMode.Separators;
			payments.LabelStyle.TextStyle.FontStyle.EmSize = new NLength(13);
			payments.LabelStyle.TextStyle.FontStyle.Style = FontStyle.Bold;

			payments.ChildNodes.Add(CreateSubScaleNode("Cheque", true, false));
			payments.ChildNodes.Add(CreateSubScaleNode("Direct debit", true, false));
			payments.ChildNodes.Add(CreateSubScaleNode("External wire transfer", true, false));
			payments.ChildNodes.Add(CreateSubScaleNode("Internal wire transfer", true, false));
			payments.ChildNodes.Add(CreateSubScaleNode("Standing order ", true, true));
			hierarchicalScale.Nodes.Add(payments);

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = hierarchicalScale;
			nChartControl1.Panels.Add(chart);

			// update form controls			
			NAxis yAxis = nChartControl1.Charts[0].Axis(StandardAxis.PrimaryY);
			NNumericScaleConfigurator scale = (NNumericScaleConfigurator)yAxis.ScaleConfigurator;
			scale.Title.Text = "Volume in Thousands USD";

			m_Updating = true;

			InflateViewRangeMinCheckBox.Checked = scale.InflateViewRangeBegin;
			InflateViewRangeMaxCheckBox.Checked = scale.InflateViewRangeEnd;

			ViewRangeInflateModeComboBox.FillFromEnum(typeof(ScaleViewRangeInflateMode));
			ViewRangeInflateModeComboBox.SelectedIndex = (int)scale.ViewRangeInflateMode;

			LogicalInflateMinNumericUpDown.Value = (decimal)scale.LogicalInflate.Begin;
			LogicalInflateMaxNumericUpDown.Value = (decimal)scale.LogicalInflate.End;

			AbsoluteInflateMinNumericUpDown.Value = (decimal)scale.AbsoluteInflate.Begin.Value;
			AbsoluteInflateMaxNumericUpDown.Value = (decimal)scale.AbsoluteInflate.End.Value;

			m_Updating = false;

			UpdateScale();
		}

		private NHierarchicalScaleNode CreateSubScaleNode(string text, bool beginSeparator, bool endSeparator)
		{
			NHierarchicalScaleNode node = new NHierarchicalScaleNode(1, text);

			if (beginSeparator && endSeparator)
			{
				node.LabelStyle.TickMode = RangeLabelTickMode.Separators;
			}
			else if (beginSeparator)
			{
				node.LabelStyle.TickMode = RangeLabelTickMode.BeginSeparator;
			}
			else if (endSeparator)
			{
				node.LabelStyle.TickMode = RangeLabelTickMode.EndSeparator;
			}

			return node;
		}

		private void UpdateScale()
		{
			if (m_Updating)
				return;

			m_Updating = true;

			NAxis yAxis = nChartControl1.Charts[0].Axis(StandardAxis.PrimaryY);

			NNumericScaleConfigurator scale = (NNumericScaleConfigurator)yAxis.ScaleConfigurator;

			scale.ViewRangeInflateMode = (ScaleViewRangeInflateMode)ViewRangeInflateModeComboBox.SelectedIndex;
			scale.InflateViewRangeBegin = InflateViewRangeMinCheckBox.Checked;
			scale.InflateViewRangeEnd = InflateViewRangeMaxCheckBox.Checked;

			switch (scale.ViewRangeInflateMode)
			{
				case ScaleViewRangeInflateMode.MajorTick:
					break;
				case ScaleViewRangeInflateMode.Logical:
					scale.LogicalInflate = new NRange1DD((double)LogicalInflateMinNumericUpDown.Value,
														 (double)LogicalInflateMaxNumericUpDown.Value);
					break;
				case ScaleViewRangeInflateMode.Absolute:
					scale.AbsoluteInflate = new NRange1DL(new NLength((float)AbsoluteInflateMinNumericUpDown.Value, NGraphicsUnit.Point),
															new NLength((float)AbsoluteInflateMaxNumericUpDown.Value, NGraphicsUnit.Point));
					break;
			}

			// assign scale configurator to y axis
			yAxis.ScaleConfigurator = scale;

			// update controls state
			bool logicalInflate = scale.ViewRangeInflateMode == ScaleViewRangeInflateMode.Logical;
			LogicalInflateMinNumericUpDown.Enabled = logicalInflate;
			LogicalInflateMaxNumericUpDown.Enabled = logicalInflate;

			bool absoluteInflate = scale.ViewRangeInflateMode == ScaleViewRangeInflateMode.Absolute;
			AbsoluteInflateMinNumericUpDown.Enabled = absoluteInflate;
			AbsoluteInflateMaxNumericUpDown.Enabled = absoluteInflate;

			m_Updating = false;

			nChartControl1.Refresh();
		}

		private void ViewRangeInflateModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void InflateViewRangeMinCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void InflateViewRangeMaxCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void LogicalInflateMinNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void LogicalInflateMaxNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void AbsoluteInflateMinNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void AbsoluteInflateMaxNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}
	}
}