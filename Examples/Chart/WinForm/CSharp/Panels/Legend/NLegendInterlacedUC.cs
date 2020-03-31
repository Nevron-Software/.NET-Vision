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
	public class NLegendInterlacedUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox LayoutGroupBox;
		private Nevron.UI.WinForm.Controls.NComboBox ExpandModeComboBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private Nevron.UI.WinForm.Controls.NNumericUpDown RowCountUpDown;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NNumericUpDown ColCountUpDown;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NCheckBox RowInterlacingInfiniteCheckBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NNumericUpDown RowInterlacingLengthNumericUpDown;
		private System.Windows.Forms.Label label7;
		private Nevron.UI.WinForm.Controls.NNumericUpDown RowInterlacingIntervalNumericUpDown;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private Nevron.UI.WinForm.Controls.NNumericUpDown ColumnInterlacingBeginNumericUpDown;
		private System.Windows.Forms.Label label11;
		private Nevron.UI.WinForm.Controls.NButton ColumnInterlacingFillStyleButton;
		private Nevron.UI.WinForm.Controls.NCheckBox ColumnInterlacingEnabledCheckBox;
		private Nevron.UI.WinForm.Controls.NNumericUpDown ColumnInterlacingIntervalNumericUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown ColumnInterlacingLengthNumericUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown ColumnInterlacingEndNumericUpDown;
		private Nevron.UI.WinForm.Controls.NCheckBox ColumnInterlacingInfiniteCheckBox;
		private Nevron.UI.WinForm.Controls.NNumericUpDown RowInterlacingBeginNumericUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown RowInterlacingEndNumericUpDown;
		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NCheckBox RowInterlacingEnabledCheckBox;
		private NLegendInterlaceStyle m_RowInterlaceStyle;
		private NLegendInterlaceStyle m_ColInterlaceStyle;
		private Nevron.UI.WinForm.Controls.NButton RowInterlacingFillStyleButton;
		private bool m_bUpdate;

		public NLegendInterlacedUC()
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
			this.RowInterlacingIntervalNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.RowInterlacingLengthNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.RowInterlacingEndNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.RowInterlacingInfiniteCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.RowInterlacingBeginNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.RowInterlacingFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.RowInterlacingEnabledCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.LayoutGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.ExpandModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.RowCountUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.ColCountUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.ColumnInterlacingIntervalNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.ColumnInterlacingLengthNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label9 = new System.Windows.Forms.Label();
			this.ColumnInterlacingEndNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label10 = new System.Windows.Forms.Label();
			this.ColumnInterlacingInfiniteCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ColumnInterlacingBeginNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label11 = new System.Windows.Forms.Label();
			this.ColumnInterlacingFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ColumnInterlacingEnabledCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.RowInterlacingIntervalNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RowInterlacingLengthNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RowInterlacingEndNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RowInterlacingBeginNumericUpDown)).BeginInit();
			this.LayoutGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.RowCountUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ColCountUpDown)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ColumnInterlacingIntervalNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ColumnInterlacingLengthNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ColumnInterlacingEndNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ColumnInterlacingBeginNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.RowInterlacingIntervalNumericUpDown);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.RowInterlacingLengthNumericUpDown);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.RowInterlacingEndNumericUpDown);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.RowInterlacingInfiniteCheckBox);
			this.groupBox1.Controls.Add(this.RowInterlacingBeginNumericUpDown);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.RowInterlacingFillStyleButton);
			this.groupBox1.Controls.Add(this.RowInterlacingEnabledCheckBox);
			this.groupBox1.ImageIndex = 0;
			this.groupBox1.Location = new System.Drawing.Point(8, 232);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(168, 232);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Horizontal interlacing";
			// 
			// RowInterlacingIntervalNumericUpDown
			// 
			this.RowInterlacingIntervalNumericUpDown.Location = new System.Drawing.Point(80, 200);
			this.RowInterlacingIntervalNumericUpDown.Name = "RowInterlacingIntervalNumericUpDown";
			this.RowInterlacingIntervalNumericUpDown.Size = new System.Drawing.Size(72, 20);
			this.RowInterlacingIntervalNumericUpDown.TabIndex = 10;
			this.RowInterlacingIntervalNumericUpDown.ValueChanged += new System.EventHandler(this.RowInterlacingIntervalNumericUpDown_ValueChanged);
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
			// RowInterlacingLengthNumericUpDown
			// 
			this.RowInterlacingLengthNumericUpDown.Location = new System.Drawing.Point(80, 168);
			this.RowInterlacingLengthNumericUpDown.Name = "RowInterlacingLengthNumericUpDown";
			this.RowInterlacingLengthNumericUpDown.Size = new System.Drawing.Size(72, 20);
			this.RowInterlacingLengthNumericUpDown.TabIndex = 8;
			this.RowInterlacingLengthNumericUpDown.ValueChanged += new System.EventHandler(this.RowInterlacingLengthNumericUpDown_ValueChanged);
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
			// RowInterlacingEndNumericUpDown
			// 
			this.RowInterlacingEndNumericUpDown.Location = new System.Drawing.Point(80, 112);
			this.RowInterlacingEndNumericUpDown.Name = "RowInterlacingEndNumericUpDown";
			this.RowInterlacingEndNumericUpDown.Size = new System.Drawing.Size(72, 20);
			this.RowInterlacingEndNumericUpDown.TabIndex = 6;
			this.RowInterlacingEndNumericUpDown.ValueChanged += new System.EventHandler(this.RowInterlacingEndNumericUpDown_ValueChanged);
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
			// RowInterlacingInfiniteCheckBox
			// 
			this.RowInterlacingInfiniteCheckBox.ButtonProperties.BorderOffset = 2;
			this.RowInterlacingInfiniteCheckBox.Location = new System.Drawing.Point(80, 136);
			this.RowInterlacingInfiniteCheckBox.Name = "RowInterlacingInfiniteCheckBox";
			this.RowInterlacingInfiniteCheckBox.Size = new System.Drawing.Size(72, 20);
			this.RowInterlacingInfiniteCheckBox.TabIndex = 4;
			this.RowInterlacingInfiniteCheckBox.Text = "Infinite";
			this.RowInterlacingInfiniteCheckBox.CheckedChanged += new System.EventHandler(this.RowInterlacingInfiniteCheckBox_CheckedChanged);
			// 
			// RowInterlacingBeginNumericUpDown
			// 
			this.RowInterlacingBeginNumericUpDown.Location = new System.Drawing.Point(80, 80);
			this.RowInterlacingBeginNumericUpDown.Name = "RowInterlacingBeginNumericUpDown";
			this.RowInterlacingBeginNumericUpDown.Size = new System.Drawing.Size(72, 20);
			this.RowInterlacingBeginNumericUpDown.TabIndex = 3;
			this.RowInterlacingBeginNumericUpDown.ValueChanged += new System.EventHandler(this.RowInterlacingBeginNumericUpDown_ValueChanged);
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
			// RowInterlacingFillStyleButton
			// 
			this.RowInterlacingFillStyleButton.Location = new System.Drawing.Point(8, 48);
			this.RowInterlacingFillStyleButton.Name = "RowInterlacingFillStyleButton";
			this.RowInterlacingFillStyleButton.Size = new System.Drawing.Size(152, 24);
			this.RowInterlacingFillStyleButton.TabIndex = 1;
			this.RowInterlacingFillStyleButton.Text = "Fill Style...";
			this.RowInterlacingFillStyleButton.Click += new System.EventHandler(this.RowInterlacingFillStyleButton_Click);
			// 
			// RowInterlacingEnabledCheckBox
			// 
			this.RowInterlacingEnabledCheckBox.ButtonProperties.BorderOffset = 2;
			this.RowInterlacingEnabledCheckBox.Location = new System.Drawing.Point(8, 16);
			this.RowInterlacingEnabledCheckBox.Name = "RowInterlacingEnabledCheckBox";
			this.RowInterlacingEnabledCheckBox.Size = new System.Drawing.Size(152, 24);
			this.RowInterlacingEnabledCheckBox.TabIndex = 0;
			this.RowInterlacingEnabledCheckBox.Text = "Enable";
			this.RowInterlacingEnabledCheckBox.CheckedChanged += new System.EventHandler(this.RowInterlacingEnabledCheckBox_CheckedChanged);
			// 
			// LayoutGroupBox
			// 
			this.LayoutGroupBox.Controls.Add(this.ExpandModeComboBox);
			this.LayoutGroupBox.Controls.Add(this.label4);
			this.LayoutGroupBox.Controls.Add(this.label6);
			this.LayoutGroupBox.Controls.Add(this.RowCountUpDown);
			this.LayoutGroupBox.Controls.Add(this.label5);
			this.LayoutGroupBox.Controls.Add(this.ColCountUpDown);
			this.LayoutGroupBox.ImageIndex = 0;
			this.LayoutGroupBox.Location = new System.Drawing.Point(8, 464);
			this.LayoutGroupBox.Name = "LayoutGroupBox";
			this.LayoutGroupBox.Size = new System.Drawing.Size(168, 168);
			this.LayoutGroupBox.TabIndex = 57;
			this.LayoutGroupBox.TabStop = false;
			this.LayoutGroupBox.Text = "Layout";
			// 
			// ExpandModeComboBox
			// 
			this.ExpandModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.ExpandModeComboBox.ListProperties.DataSource = null;
			this.ExpandModeComboBox.ListProperties.DisplayMember = "";
			this.ExpandModeComboBox.Location = new System.Drawing.Point(12, 42);
			this.ExpandModeComboBox.Name = "ExpandModeComboBox";
			this.ExpandModeComboBox.Size = new System.Drawing.Size(145, 21);
			this.ExpandModeComboBox.TabIndex = 45;
			this.ExpandModeComboBox.SelectedIndexChanged += new System.EventHandler(this.ExpandModeComboBox_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(145, 15);
			this.label4.TabIndex = 46;
			this.label4.Text = "Expand mode:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(12, 68);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(145, 15);
			this.label6.TabIndex = 51;
			this.label6.Text = "Row count:";
			// 
			// RowCountUpDown
			// 
			this.RowCountUpDown.Location = new System.Drawing.Point(12, 88);
			this.RowCountUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.RowCountUpDown.Name = "RowCountUpDown";
			this.RowCountUpDown.Size = new System.Drawing.Size(145, 20);
			this.RowCountUpDown.TabIndex = 47;
			this.RowCountUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.RowCountUpDown.ValueChanged += new System.EventHandler(this.RowCountUpDown_ValueChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(12, 113);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(145, 15);
			this.label5.TabIndex = 50;
			this.label5.Text = "Col count:";
			// 
			// ColCountUpDown
			// 
			this.ColCountUpDown.Location = new System.Drawing.Point(12, 133);
			this.ColCountUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.ColCountUpDown.Name = "ColCountUpDown";
			this.ColCountUpDown.Size = new System.Drawing.Size(145, 20);
			this.ColCountUpDown.TabIndex = 48;
			this.ColCountUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.ColCountUpDown.ValueChanged += new System.EventHandler(this.ColCountUpDown_ValueChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.ColumnInterlacingIntervalNumericUpDown);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.ColumnInterlacingLengthNumericUpDown);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.ColumnInterlacingEndNumericUpDown);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.ColumnInterlacingInfiniteCheckBox);
			this.groupBox2.Controls.Add(this.ColumnInterlacingBeginNumericUpDown);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.ColumnInterlacingFillStyleButton);
			this.groupBox2.Controls.Add(this.ColumnInterlacingEnabledCheckBox);
			this.groupBox2.ImageIndex = 0;
			this.groupBox2.Location = new System.Drawing.Point(8, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(168, 232);
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Vertical interlacing";
			// 
			// ColumnInterlacingIntervalNumericUpDown
			// 
			this.ColumnInterlacingIntervalNumericUpDown.Location = new System.Drawing.Point(80, 200);
			this.ColumnInterlacingIntervalNumericUpDown.Name = "ColumnInterlacingIntervalNumericUpDown";
			this.ColumnInterlacingIntervalNumericUpDown.Size = new System.Drawing.Size(72, 20);
			this.ColumnInterlacingIntervalNumericUpDown.TabIndex = 10;
			this.ColumnInterlacingIntervalNumericUpDown.ValueChanged += new System.EventHandler(this.ColumnInterlacingIntervalNumericUpDown_ValueChanged);
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
			// ColumnInterlacingLengthNumericUpDown
			// 
			this.ColumnInterlacingLengthNumericUpDown.Location = new System.Drawing.Point(80, 168);
			this.ColumnInterlacingLengthNumericUpDown.Name = "ColumnInterlacingLengthNumericUpDown";
			this.ColumnInterlacingLengthNumericUpDown.Size = new System.Drawing.Size(72, 20);
			this.ColumnInterlacingLengthNumericUpDown.TabIndex = 8;
			this.ColumnInterlacingLengthNumericUpDown.ValueChanged += new System.EventHandler(this.ColumnInterlacingLengthNumericUpDown_ValueChanged);
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
			// ColumnInterlacingEndNumericUpDown
			// 
			this.ColumnInterlacingEndNumericUpDown.Location = new System.Drawing.Point(80, 112);
			this.ColumnInterlacingEndNumericUpDown.Name = "ColumnInterlacingEndNumericUpDown";
			this.ColumnInterlacingEndNumericUpDown.Size = new System.Drawing.Size(72, 20);
			this.ColumnInterlacingEndNumericUpDown.TabIndex = 6;
			this.ColumnInterlacingEndNumericUpDown.ValueChanged += new System.EventHandler(this.ColumnInterlacingEndNumericUpDown_ValueChanged);
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
			// ColumnInterlacingInfiniteCheckBox
			// 
			this.ColumnInterlacingInfiniteCheckBox.ButtonProperties.BorderOffset = 2;
			this.ColumnInterlacingInfiniteCheckBox.Location = new System.Drawing.Point(80, 136);
			this.ColumnInterlacingInfiniteCheckBox.Name = "ColumnInterlacingInfiniteCheckBox";
			this.ColumnInterlacingInfiniteCheckBox.Size = new System.Drawing.Size(72, 20);
			this.ColumnInterlacingInfiniteCheckBox.TabIndex = 4;
			this.ColumnInterlacingInfiniteCheckBox.Text = "Infinite";
			this.ColumnInterlacingInfiniteCheckBox.CheckedChanged += new System.EventHandler(this.ColumnInterlacingInfiniteCheckBox_CheckedChanged);
			// 
			// ColumnInterlacingBeginNumericUpDown
			// 
			this.ColumnInterlacingBeginNumericUpDown.Location = new System.Drawing.Point(80, 80);
			this.ColumnInterlacingBeginNumericUpDown.Name = "ColumnInterlacingBeginNumericUpDown";
			this.ColumnInterlacingBeginNumericUpDown.Size = new System.Drawing.Size(72, 20);
			this.ColumnInterlacingBeginNumericUpDown.TabIndex = 3;
			this.ColumnInterlacingBeginNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.ColumnInterlacingBeginNumericUpDown.ValueChanged += new System.EventHandler(this.ColumnInterlacingBeginNumericUpDown_ValueChanged);
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
			// ColumnInterlacingFillStyleButton
			// 
			this.ColumnInterlacingFillStyleButton.Location = new System.Drawing.Point(8, 48);
			this.ColumnInterlacingFillStyleButton.Name = "ColumnInterlacingFillStyleButton";
			this.ColumnInterlacingFillStyleButton.Size = new System.Drawing.Size(152, 24);
			this.ColumnInterlacingFillStyleButton.TabIndex = 1;
			this.ColumnInterlacingFillStyleButton.Text = "Fill Style...";
			this.ColumnInterlacingFillStyleButton.Click += new System.EventHandler(this.ColumnInterlacingFillStyleButton_Click);
			// 
			// ColumnInterlacingEnabledCheckBox
			// 
			this.ColumnInterlacingEnabledCheckBox.ButtonProperties.BorderOffset = 2;
			this.ColumnInterlacingEnabledCheckBox.Location = new System.Drawing.Point(8, 16);
			this.ColumnInterlacingEnabledCheckBox.Name = "ColumnInterlacingEnabledCheckBox";
			this.ColumnInterlacingEnabledCheckBox.Size = new System.Drawing.Size(152, 24);
			this.ColumnInterlacingEnabledCheckBox.TabIndex = 0;
			this.ColumnInterlacingEnabledCheckBox.Text = "Enable";
			this.ColumnInterlacingEnabledCheckBox.CheckedChanged += new System.EventHandler(this.ColumnInterlacingEnabledCheckBox_CheckedChanged);
			// 
			// NLegendInterlacedUC
			// 
			this.Controls.Add(this.LayoutGroupBox);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Name = "NLegendInterlacedUC";
			this.Size = new System.Drawing.Size(180, 672);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.RowInterlacingIntervalNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RowInterlacingLengthNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RowInterlacingEndNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RowInterlacingBeginNumericUpDown)).EndInit();
			this.LayoutGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.RowCountUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ColCountUpDown)).EndInit();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ColumnInterlacingIntervalNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ColumnInterlacingLengthNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ColumnInterlacingEndNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ColumnInterlacingBeginNumericUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

            nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Legend Row and Column Interlacing");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			header.ContentAlignment = ContentAlignment.BottomRight;
			header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
            header.DockMode = PanelDockMode.Top;
            header.Margins = new NMarginsL(10, 10, 10, 10);
            nChartControl1.Panels.Add(header);

			m_bUpdate = false;

            // configure the legend
			NLegend legend = new NLegend();
            legend.UseAutomaticSize = true;
            legend.Margins = new NMarginsL(10, 10, 10, 10);
            nChartControl1.Panels.Add(legend);

			legend.Mode = LegendMode.Automatic;
			legend.Location = new NPointL(new NLength(90, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			legend.Data.ExpandMode = LegendExpandMode.RowsFixed;
			legend.Data.RowCount = 12;
			legend.FillStyle.SetTransparencyPercent(100);
            legend.OuterLeftBorderStyle.Width = new NLength(0);
            legend.OuterTopBorderStyle.Width = new NLength(0);
            legend.OuterRightBorderStyle.Width = new NLength(0);
            legend.OuterBottomBorderStyle.Width = new NLength(0);
            legend.HorizontalBorderStyle.Width = new NLength(0);
            legend.VerticalBorderStyle.Width = new NLength(0);

            legend.DockMode = PanelDockMode.Right;

			m_RowInterlaceStyle = new NLegendInterlaceStyle();
			m_RowInterlaceStyle.Type = LegendInterlaceStyleType.Row;
			m_RowInterlaceStyle.FillStyle = new NColorFillStyle(Color.FromArgb(125, Color.DimGray));
			legend.InterlaceStyles.Add(m_RowInterlaceStyle);

			m_ColInterlaceStyle = new NLegendInterlaceStyle();
			m_ColInterlaceStyle.Type = LegendInterlaceStyleType.Col;
            m_ColInterlaceStyle.FillStyle = new NColorFillStyle(Color.FromArgb(125, Color.Gainsboro));
			legend.InterlaceStyles.Add(m_ColInterlaceStyle);

			// init form controls depending on control style
			// configure layout
			ExpandModeComboBox.Items.Add("Rows only");
			ExpandModeComboBox.Items.Add("Cols only");
			ExpandModeComboBox.Items.Add("Rows fixed");
			ExpandModeComboBox.Items.Add("Cols fixed");
			ExpandModeComboBox.SelectedIndex = (int)legend.Data.ExpandMode;
			RowCountUpDown.Value = (decimal)legend.Data.RowCount;
			ColCountUpDown.Value = (decimal)legend.Data.ColCount;

			// configure horizontal interlacing
			legend.InterlaceStyles.Clear();

            // configure the chart
            NChart chart = new NCartesianChart();
            nChartControl1.Panels.Add(chart);
            chart.DisplayOnLegend = legend;
            chart.BoundsMode = BoundsMode.Fit;
            chart.DockMode = PanelDockMode.Fill;
            chart.Margins = new NMarginsL(10, 10, 10, 10);

            for (int i = 0; i < 4; i++)
            {
                // create bar series
                NBarSeries series = (NBarSeries)chart.Series.Add(SeriesType.Bar);
                series.Name = "Series " + i.ToString();
                series.Values.FillRandomRange(Random, 6, 50, 90);
                series.Legend.Format = series.Name + " <value>";
                series.Legend.Mode = SeriesLegendMode.DataPoints;
                series.MultiBarMode = MultiBarMode.Stacked;
                series.DataLabelStyle.Visible = false;
            }

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			RowInterlacingEnabledCheckBox.Checked = true;
			RowInterlacingBeginNumericUpDown.Value = (decimal)m_RowInterlaceStyle.Begin;
			RowInterlacingEndNumericUpDown.Value = (decimal)m_RowInterlaceStyle.End;
			RowInterlacingInfiniteCheckBox.Checked = m_RowInterlaceStyle.Infinite;
			RowInterlacingLengthNumericUpDown.Value = (decimal)m_RowInterlaceStyle.Length;
			RowInterlacingIntervalNumericUpDown.Value = (decimal)m_RowInterlaceStyle.Interval;
			
			// configure vertical interlacing
			ColumnInterlacingEnabledCheckBox.Checked = true;
			ColumnInterlacingBeginNumericUpDown.Value = (decimal)m_ColInterlaceStyle.Begin;
			ColumnInterlacingEndNumericUpDown.Value = (decimal)m_ColInterlaceStyle.End;
			ColumnInterlacingInfiniteCheckBox.Checked = m_ColInterlaceStyle.Infinite;
			ColumnInterlacingLengthNumericUpDown.Value = (decimal)m_ColInterlaceStyle.Length;
			ColumnInterlacingIntervalNumericUpDown.Value = (decimal)m_ColInterlaceStyle.Interval;

			m_bUpdate = true;

			ConfigureLegend();
		}


		private void ConfigureLegend()
		{
			if (m_bUpdate == false)
				return;

			m_bUpdate = false;

			NLegend legend = nChartControl1.Legends[0];

			// configure layout
			legend.Data.ExpandMode = (LegendExpandMode)ExpandModeComboBox.SelectedIndex;
			legend.Data.RowCount = (int)RowCountUpDown.Value;
			legend.Data.ColCount = (int)ColCountUpDown.Value;

			legend.InterlaceStyles.Clear();

			// configure horizontal interlacing
			m_RowInterlaceStyle.Begin = (int)RowInterlacingBeginNumericUpDown.Value;
			m_RowInterlaceStyle.End = (int)RowInterlacingEndNumericUpDown.Value;
			m_RowInterlaceStyle.Infinite = RowInterlacingInfiniteCheckBox.Checked;
			m_RowInterlaceStyle.Length = (int)RowInterlacingLengthNumericUpDown.Value;
			m_RowInterlaceStyle.Interval = (int)RowInterlacingIntervalNumericUpDown.Value;

			if (RowInterlacingEnabledCheckBox.Checked)
			{
				legend.InterlaceStyles.Add(m_RowInterlaceStyle);
			}
			
			// configure vertical interlacing
			m_ColInterlaceStyle.Begin = (int)ColumnInterlacingBeginNumericUpDown.Value;
			m_ColInterlaceStyle.End = (int)ColumnInterlacingEndNumericUpDown.Value;
			m_ColInterlaceStyle.Infinite = ColumnInterlacingInfiniteCheckBox.Checked;
			m_ColInterlaceStyle.Length = (int)ColumnInterlacingLengthNumericUpDown.Value;
			m_ColInterlaceStyle.Interval = (int)ColumnInterlacingIntervalNumericUpDown.Value;

			if (ColumnInterlacingEnabledCheckBox.Checked)
			{
				legend.InterlaceStyles.Add(m_ColInterlaceStyle);
			}

			bool bEnableControl = RowInterlacingEnabledCheckBox.Checked;

			RowInterlacingFillStyleButton.Enabled = bEnableControl;
			RowInterlacingBeginNumericUpDown.Enabled = bEnableControl;
			RowInterlacingEndNumericUpDown.Enabled = bEnableControl && (!RowInterlacingInfiniteCheckBox.Checked);
			RowInterlacingInfiniteCheckBox.Enabled = bEnableControl;
			RowInterlacingLengthNumericUpDown.Enabled = bEnableControl;
			RowInterlacingIntervalNumericUpDown.Enabled = bEnableControl;

			bEnableControl = ColumnInterlacingEnabledCheckBox.Checked;

			ColumnInterlacingFillStyleButton.Enabled = bEnableControl;
			ColumnInterlacingBeginNumericUpDown.Enabled = bEnableControl;
			ColumnInterlacingEndNumericUpDown.Enabled = bEnableControl && (!ColumnInterlacingInfiniteCheckBox.Checked);
			ColumnInterlacingInfiniteCheckBox.Enabled = bEnableControl;
			ColumnInterlacingLengthNumericUpDown.Enabled = bEnableControl;
			ColumnInterlacingIntervalNumericUpDown.Enabled = bEnableControl;

			m_bUpdate = true;

			nChartControl1.Refresh();
		}

		private void RowInterlacingEnabledCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			ConfigureLegend();
		}

		private void RowInterlacingFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_RowInterlaceStyle.FillStyle, out fillStyleResult))
			{
				m_RowInterlaceStyle.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void RowInterlacingBeginNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			ConfigureLegend();
		}

		private void RowInterlacingEndNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			ConfigureLegend();
		}

		private void RowInterlacingInfiniteCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			ConfigureLegend();
		}

		private void RowInterlacingLengthNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			ConfigureLegend();
		}

		private void RowInterlacingIntervalNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			ConfigureLegend();
		}

		private void ColumnInterlacingEnabledCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			ConfigureLegend();
		}

		private void ColumnInterlacingFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_ColInterlaceStyle.FillStyle, out fillStyleResult))
			{
				m_ColInterlaceStyle.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void ColumnInterlacingBeginNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			ConfigureLegend();
		}

		private void ColumnInterlacingEndNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			ConfigureLegend();
		}

		private void ColumnInterlacingInfiniteCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			ConfigureLegend();
		}

		private void ColumnInterlacingLengthNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			ConfigureLegend();
		}

		private void ColumnInterlacingIntervalNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			ConfigureLegend();
		}

		private void ExpandModeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ConfigureLegend();
		}

		private void RowCountUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			ConfigureLegend();
		}

		private void ColCountUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			ConfigureLegend();
		}
	}
}
