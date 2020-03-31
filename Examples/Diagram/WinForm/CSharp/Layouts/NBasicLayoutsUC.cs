using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Nevron.GraphicsCore;
using Nevron.UI.WinForm.Controls;
using Nevron.Dom;
using Nevron.Diagram;
using Nevron.Diagram.Batches; 
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NBasicLayoutsUC.
	/// </summary>
	public class NBasicLayoutsUC : NDiagramExampleUC
	{
		#region Constructor

		public NBasicLayoutsUC(NMainForm form) : base(form)
		{
			InitializeComponent();
		}

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.alignMiddlesButton = new Nevron.UI.WinForm.Controls.NButton();
			this.alignLeftsButton = new Nevron.UI.WinForm.Controls.NButton();
			this.alignBottomsButton = new Nevron.UI.WinForm.Controls.NButton();
			this.alignToGridButton = new Nevron.UI.WinForm.Controls.NButton();
			this.alignCentersButton = new Nevron.UI.WinForm.Controls.NButton();
			this.alignTopsButton = new Nevron.UI.WinForm.Controls.NButton();
			this.alignRightsButton = new Nevron.UI.WinForm.Controls.NButton();
			this.sizeToGridButton = new Nevron.UI.WinForm.Controls.NButton();
			this.sameWidthButton = new Nevron.UI.WinForm.Controls.NButton();
			this.sameHeightButton = new Nevron.UI.WinForm.Controls.NButton();
			this.sameSizeButton = new Nevron.UI.WinForm.Controls.NButton();
			this.increaseHorizontalSpacingButton = new Nevron.UI.WinForm.Controls.NButton();
			this.decreaseHorizontalSpacingButton = new Nevron.UI.WinForm.Controls.NButton();
			this.removeHorizontalSpacingButton = new Nevron.UI.WinForm.Controls.NButton();
			this.horzontalSpacingEqualButton = new Nevron.UI.WinForm.Controls.NButton();
			this.verticalSpacingEqualButton = new Nevron.UI.WinForm.Controls.NButton();
			this.removeVerticalSpacingButton = new Nevron.UI.WinForm.Controls.NButton();
			this.decreaseVerticalSpacingButton = new Nevron.UI.WinForm.Controls.NButton();
			this.increaseVerticalSpacingButton = new Nevron.UI.WinForm.Controls.NButton();
			this.centerHorizontallyButton = new Nevron.UI.WinForm.Controls.NButton();
			this.centerVerticallyButton = new Nevron.UI.WinForm.Controls.NButton();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nGroupBox3 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.hSpacingNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.nGroupBox4 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.vSpacingNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.nGroupBox5 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nGroupBox1.SuspendLayout();
			this.nGroupBox2.SuspendLayout();
			this.nGroupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.hSpacingNumeric)).BeginInit();
			this.nGroupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.vSpacingNumeric)).BeginInit();
			this.nGroupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// alignMiddlesButton
			// 
			this.alignMiddlesButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.alignMiddlesButton.Enabled = false;
			this.alignMiddlesButton.Location = new System.Drawing.Point(128, 48);
			this.alignMiddlesButton.Name = "alignMiddlesButton";
			this.alignMiddlesButton.Size = new System.Drawing.Size(112, 24);
			this.alignMiddlesButton.TabIndex = 4;
			this.alignMiddlesButton.Text = "&Middles";
			this.alignMiddlesButton.Click += new System.EventHandler(this.alignMiddlesButton_Click);
			// 
			// alignLeftsButton
			// 
			this.alignLeftsButton.Enabled = false;
			this.alignLeftsButton.Location = new System.Drawing.Point(8, 20);
			this.alignLeftsButton.Name = "alignLeftsButton";
			this.alignLeftsButton.Size = new System.Drawing.Size(112, 24);
			this.alignLeftsButton.TabIndex = 0;
			this.alignLeftsButton.Text = "Lefts";
			this.alignLeftsButton.Click += new System.EventHandler(this.alignLeftsButton_Click);
			// 
			// alignBottomsButton
			// 
			this.alignBottomsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.alignBottomsButton.Enabled = false;
			this.alignBottomsButton.Location = new System.Drawing.Point(128, 20);
			this.alignBottomsButton.Name = "alignBottomsButton";
			this.alignBottomsButton.Size = new System.Drawing.Size(112, 24);
			this.alignBottomsButton.TabIndex = 1;
			this.alignBottomsButton.Text = "&Bottoms";
			this.alignBottomsButton.Click += new System.EventHandler(this.alignBottomsButton_Click);
			// 
			// alignToGridButton
			// 
			this.alignToGridButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.alignToGridButton.Enabled = false;
			this.alignToGridButton.Location = new System.Drawing.Point(8, 104);
			this.alignToGridButton.Name = "alignToGridButton";
			this.alignToGridButton.Size = new System.Drawing.Size(234, 24);
			this.alignToGridButton.TabIndex = 5;
			this.alignToGridButton.Text = "To Grid";
			this.alignToGridButton.Click += new System.EventHandler(this.alignToGridButton_Click);
			// 
			// alignCentersButton
			// 
			this.alignCentersButton.Enabled = false;
			this.alignCentersButton.Location = new System.Drawing.Point(8, 48);
			this.alignCentersButton.Name = "alignCentersButton";
			this.alignCentersButton.Size = new System.Drawing.Size(112, 24);
			this.alignCentersButton.TabIndex = 2;
			this.alignCentersButton.Text = "&Centers";
			this.alignCentersButton.Click += new System.EventHandler(this.alignCentersButton_Click);
			// 
			// alignTopsButton
			// 
			this.alignTopsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.alignTopsButton.Enabled = false;
			this.alignTopsButton.Location = new System.Drawing.Point(128, 76);
			this.alignTopsButton.Name = "alignTopsButton";
			this.alignTopsButton.Size = new System.Drawing.Size(112, 24);
			this.alignTopsButton.TabIndex = 4;
			this.alignTopsButton.Text = "&Tops";
			this.alignTopsButton.Click += new System.EventHandler(this.alignTopsButton_Click);
			// 
			// alignRightsButton
			// 
			this.alignRightsButton.Enabled = false;
			this.alignRightsButton.Location = new System.Drawing.Point(8, 76);
			this.alignRightsButton.Name = "alignRightsButton";
			this.alignRightsButton.Size = new System.Drawing.Size(112, 24);
			this.alignRightsButton.TabIndex = 3;
			this.alignRightsButton.Text = "&Rights";
			this.alignRightsButton.Click += new System.EventHandler(this.alignRightsButton_Click);
			// 
			// sizeToGridButton
			// 
			this.sizeToGridButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.sizeToGridButton.Enabled = false;
			this.sizeToGridButton.Location = new System.Drawing.Point(8, 104);
			this.sizeToGridButton.Name = "sizeToGridButton";
			this.sizeToGridButton.Size = new System.Drawing.Size(234, 24);
			this.sizeToGridButton.TabIndex = 3;
			this.sizeToGridButton.Text = "To &Grid";
			this.sizeToGridButton.Click += new System.EventHandler(this.sizeToGridButton_Click);
			// 
			// sameWidthButton
			// 
			this.sameWidthButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.sameWidthButton.Enabled = false;
			this.sameWidthButton.Location = new System.Drawing.Point(8, 20);
			this.sameWidthButton.Name = "sameWidthButton";
			this.sameWidthButton.Size = new System.Drawing.Size(234, 24);
			this.sameWidthButton.TabIndex = 0;
			this.sameWidthButton.Text = "Make Same Width";
			this.sameWidthButton.Click += new System.EventHandler(this.sameWidthButton_Click);
			// 
			// sameHeightButton
			// 
			this.sameHeightButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.sameHeightButton.Enabled = false;
			this.sameHeightButton.Location = new System.Drawing.Point(8, 48);
			this.sameHeightButton.Name = "sameHeightButton";
			this.sameHeightButton.Size = new System.Drawing.Size(234, 24);
			this.sameHeightButton.TabIndex = 1;
			this.sameHeightButton.Text = "Make Same Height";
			this.sameHeightButton.Click += new System.EventHandler(this.sameHeightButton_Click);
			// 
			// sameSizeButton
			// 
			this.sameSizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.sameSizeButton.Enabled = false;
			this.sameSizeButton.Location = new System.Drawing.Point(8, 76);
			this.sameSizeButton.Name = "sameSizeButton";
			this.sameSizeButton.Size = new System.Drawing.Size(234, 24);
			this.sameSizeButton.TabIndex = 2;
			this.sameSizeButton.Text = "Make Same Size";
			this.sameSizeButton.Click += new System.EventHandler(this.sameSizeButton_Click);
			// 
			// increaseHorizontalSpacingButton
			// 
			this.increaseHorizontalSpacingButton.Enabled = false;
			this.increaseHorizontalSpacingButton.Location = new System.Drawing.Point(8, 40);
			this.increaseHorizontalSpacingButton.Name = "increaseHorizontalSpacingButton";
			this.increaseHorizontalSpacingButton.Size = new System.Drawing.Size(112, 24);
			this.increaseHorizontalSpacingButton.TabIndex = 2;
			this.increaseHorizontalSpacingButton.Text = "&Increase";
			this.increaseHorizontalSpacingButton.Click += new System.EventHandler(this.increaseHorizontalSpacingButton_Click);
			// 
			// decreaseHorizontalSpacingButton
			// 
			this.decreaseHorizontalSpacingButton.Enabled = false;
			this.decreaseHorizontalSpacingButton.Location = new System.Drawing.Point(8, 72);
			this.decreaseHorizontalSpacingButton.Name = "decreaseHorizontalSpacingButton";
			this.decreaseHorizontalSpacingButton.Size = new System.Drawing.Size(112, 24);
			this.decreaseHorizontalSpacingButton.TabIndex = 3;
			this.decreaseHorizontalSpacingButton.Text = "&Decrease";
			this.decreaseHorizontalSpacingButton.Click += new System.EventHandler(this.decreaseHorizontalSpacingButton_Click);
			// 
			// removeHorizontalSpacingButton
			// 
			this.removeHorizontalSpacingButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.removeHorizontalSpacingButton.Enabled = false;
			this.removeHorizontalSpacingButton.Location = new System.Drawing.Point(128, 40);
			this.removeHorizontalSpacingButton.Name = "removeHorizontalSpacingButton";
			this.removeHorizontalSpacingButton.Size = new System.Drawing.Size(112, 24);
			this.removeHorizontalSpacingButton.TabIndex = 4;
			this.removeHorizontalSpacingButton.Text = "&Remove";
			this.removeHorizontalSpacingButton.Click += new System.EventHandler(this.removeHorizontalSpacingButton_Click);
			// 
			// horzontalSpacingEqualButton
			// 
			this.horzontalSpacingEqualButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.horzontalSpacingEqualButton.Enabled = false;
			this.horzontalSpacingEqualButton.Location = new System.Drawing.Point(128, 72);
			this.horzontalSpacingEqualButton.Name = "horzontalSpacingEqualButton";
			this.horzontalSpacingEqualButton.Size = new System.Drawing.Size(112, 24);
			this.horzontalSpacingEqualButton.TabIndex = 5;
			this.horzontalSpacingEqualButton.Text = "Make &Equal";
			this.horzontalSpacingEqualButton.Click += new System.EventHandler(this.horizontalSpacingEqualButton_Click);
			// 
			// verticalSpacingEqualButton
			// 
			this.verticalSpacingEqualButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.verticalSpacingEqualButton.Enabled = false;
			this.verticalSpacingEqualButton.Location = new System.Drawing.Point(128, 72);
			this.verticalSpacingEqualButton.Name = "verticalSpacingEqualButton";
			this.verticalSpacingEqualButton.Size = new System.Drawing.Size(112, 24);
			this.verticalSpacingEqualButton.TabIndex = 5;
			this.verticalSpacingEqualButton.Text = "Make &Equal";
			this.verticalSpacingEqualButton.Click += new System.EventHandler(this.verticalSpacingEqualButton_Click);
			// 
			// removeVerticalSpacingButton
			// 
			this.removeVerticalSpacingButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.removeVerticalSpacingButton.Enabled = false;
			this.removeVerticalSpacingButton.Location = new System.Drawing.Point(128, 40);
			this.removeVerticalSpacingButton.Name = "removeVerticalSpacingButton";
			this.removeVerticalSpacingButton.Size = new System.Drawing.Size(112, 24);
			this.removeVerticalSpacingButton.TabIndex = 3;
			this.removeVerticalSpacingButton.Text = "&Remove";
			this.removeVerticalSpacingButton.Click += new System.EventHandler(this.removeVerticalSpacingButton_Click);
			// 
			// decreaseVerticalSpacingButton
			// 
			this.decreaseVerticalSpacingButton.Enabled = false;
			this.decreaseVerticalSpacingButton.Location = new System.Drawing.Point(8, 72);
			this.decreaseVerticalSpacingButton.Name = "decreaseVerticalSpacingButton";
			this.decreaseVerticalSpacingButton.Size = new System.Drawing.Size(112, 24);
			this.decreaseVerticalSpacingButton.TabIndex = 4;
			this.decreaseVerticalSpacingButton.Text = "&Decrease";
			this.decreaseVerticalSpacingButton.Click += new System.EventHandler(this.decreaseVerticalSpacingButton_Click);
			// 
			// increaseVerticalSpacingButton
			// 
			this.increaseVerticalSpacingButton.Enabled = false;
			this.increaseVerticalSpacingButton.Location = new System.Drawing.Point(8, 40);
			this.increaseVerticalSpacingButton.Name = "increaseVerticalSpacingButton";
			this.increaseVerticalSpacingButton.Size = new System.Drawing.Size(112, 24);
			this.increaseVerticalSpacingButton.TabIndex = 2;
			this.increaseVerticalSpacingButton.Text = "&Increase";
			this.increaseVerticalSpacingButton.Click += new System.EventHandler(this.increaseVerticalSpacingButton_Click);
			// 
			// centerHorizontallyButton
			// 
			this.centerHorizontallyButton.Enabled = false;
			this.centerHorizontallyButton.Location = new System.Drawing.Point(8, 20);
			this.centerHorizontallyButton.Name = "centerHorizontallyButton";
			this.centerHorizontallyButton.Size = new System.Drawing.Size(112, 24);
			this.centerHorizontallyButton.TabIndex = 0;
			this.centerHorizontallyButton.Text = "&Horizontally";
			this.centerHorizontallyButton.Click += new System.EventHandler(this.centerHorizontallyButton_Click);
			// 
			// centerVerticallyButton
			// 
			this.centerVerticallyButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.centerVerticallyButton.Enabled = false;
			this.centerVerticallyButton.Location = new System.Drawing.Point(128, 20);
			this.centerVerticallyButton.Name = "centerVerticallyButton";
			this.centerVerticallyButton.Size = new System.Drawing.Size(112, 24);
			this.centerVerticallyButton.TabIndex = 1;
			this.centerVerticallyButton.Text = "&Vertically";
			this.centerVerticallyButton.Click += new System.EventHandler(this.centerVerticallyButton_Click);
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.alignLeftsButton);
			this.nGroupBox1.Controls.Add(this.alignCentersButton);
			this.nGroupBox1.Controls.Add(this.alignRightsButton);
			this.nGroupBox1.Controls.Add(this.alignMiddlesButton);
			this.nGroupBox1.Controls.Add(this.alignTopsButton);
			this.nGroupBox1.Controls.Add(this.alignBottomsButton);
			this.nGroupBox1.Controls.Add(this.alignToGridButton);
			this.nGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(0, 0);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(250, 136);
			this.nGroupBox1.TabIndex = 1;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Align";
			// 
			// nGroupBox2
			// 
			this.nGroupBox2.Controls.Add(this.sameHeightButton);
			this.nGroupBox2.Controls.Add(this.sizeToGridButton);
			this.nGroupBox2.Controls.Add(this.sameWidthButton);
			this.nGroupBox2.Controls.Add(this.sameSizeButton);
			this.nGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.nGroupBox2.ImageIndex = 0;
			this.nGroupBox2.Location = new System.Drawing.Point(0, 136);
			this.nGroupBox2.Name = "nGroupBox2";
			this.nGroupBox2.Size = new System.Drawing.Size(250, 136);
			this.nGroupBox2.TabIndex = 2;
			this.nGroupBox2.TabStop = false;
			this.nGroupBox2.Text = "Size";
			// 
			// nGroupBox3
			// 
			this.nGroupBox3.Controls.Add(this.hSpacingNumeric);
			this.nGroupBox3.Controls.Add(this.label1);
			this.nGroupBox3.Controls.Add(this.horzontalSpacingEqualButton);
			this.nGroupBox3.Controls.Add(this.removeHorizontalSpacingButton);
			this.nGroupBox3.Controls.Add(this.decreaseHorizontalSpacingButton);
			this.nGroupBox3.Controls.Add(this.increaseHorizontalSpacingButton);
			this.nGroupBox3.Dock = System.Windows.Forms.DockStyle.Top;
			this.nGroupBox3.ImageIndex = 0;
			this.nGroupBox3.Location = new System.Drawing.Point(0, 272);
			this.nGroupBox3.Name = "nGroupBox3";
			this.nGroupBox3.Size = new System.Drawing.Size(250, 104);
			this.nGroupBox3.TabIndex = 3;
			this.nGroupBox3.TabStop = false;
			this.nGroupBox3.Text = "Horizontal Spacing";
			// 
			// hSpacingNumeric
			// 
			this.hSpacingNumeric.Location = new System.Drawing.Point(152, 16);
			this.hSpacingNumeric.Maximum = new System.Decimal(new int[] {
																			1000,
																			0,
																			0,
																			0});
			this.hSpacingNumeric.Minimum = new System.Decimal(new int[] {
																			1,
																			0,
																			0,
																			0});
			this.hSpacingNumeric.Name = "hSpacingNumeric";
			this.hSpacingNumeric.Size = new System.Drawing.Size(64, 20);
			this.hSpacingNumeric.TabIndex = 1;
			this.hSpacingNumeric.Value = new System.Decimal(new int[] {
																		  20,
																		  0,
																		  0,
																		  0});
			this.hSpacingNumeric.ValueChanged += new System.EventHandler(this.hSpacingNumeric_ValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Horizontal spacing step:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// nGroupBox4
			// 
			this.nGroupBox4.Controls.Add(this.vSpacingNumeric);
			this.nGroupBox4.Controls.Add(this.label2);
			this.nGroupBox4.Controls.Add(this.removeVerticalSpacingButton);
			this.nGroupBox4.Controls.Add(this.verticalSpacingEqualButton);
			this.nGroupBox4.Controls.Add(this.increaseVerticalSpacingButton);
			this.nGroupBox4.Controls.Add(this.decreaseVerticalSpacingButton);
			this.nGroupBox4.Dock = System.Windows.Forms.DockStyle.Top;
			this.nGroupBox4.ImageIndex = 0;
			this.nGroupBox4.Location = new System.Drawing.Point(0, 376);
			this.nGroupBox4.Name = "nGroupBox4";
			this.nGroupBox4.Size = new System.Drawing.Size(250, 104);
			this.nGroupBox4.TabIndex = 4;
			this.nGroupBox4.TabStop = false;
			this.nGroupBox4.Text = "Vertical Spacing";
			// 
			// vSpacingNumeric
			// 
			this.vSpacingNumeric.Location = new System.Drawing.Point(152, 16);
			this.vSpacingNumeric.Maximum = new System.Decimal(new int[] {
																			1000,
																			0,
																			0,
																			0});
			this.vSpacingNumeric.Minimum = new System.Decimal(new int[] {
																			1,
																			0,
																			0,
																			0});
			this.vSpacingNumeric.Name = "vSpacingNumeric";
			this.vSpacingNumeric.Size = new System.Drawing.Size(64, 20);
			this.vSpacingNumeric.TabIndex = 1;
			this.vSpacingNumeric.Value = new System.Decimal(new int[] {
																		  20,
																		  0,
																		  0,
																		  0});
			this.vSpacingNumeric.ValueChanged += new System.EventHandler(this.vSpacingNumeric_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "Vertical spacing step:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// nGroupBox5
			// 
			this.nGroupBox5.Controls.Add(this.centerVerticallyButton);
			this.nGroupBox5.Controls.Add(this.centerHorizontallyButton);
			this.nGroupBox5.Dock = System.Windows.Forms.DockStyle.Top;
			this.nGroupBox5.ImageIndex = 0;
			this.nGroupBox5.Location = new System.Drawing.Point(0, 480);
			this.nGroupBox5.Name = "nGroupBox5";
			this.nGroupBox5.Size = new System.Drawing.Size(250, 56);
			this.nGroupBox5.TabIndex = 5;
			this.nGroupBox5.TabStop = false;
			this.nGroupBox5.Text = "Center";
			// 
			// NBasicLayoutsUC
			// 
			this.Controls.Add(this.nGroupBox5);
			this.Controls.Add(this.nGroupBox4);
			this.Controls.Add(this.nGroupBox3);
			this.Controls.Add(this.nGroupBox2);
			this.Controls.Add(this.nGroupBox1);
			this.Name = "NBasicLayoutsUC";
			this.Size = new System.Drawing.Size(250, 700);
			this.Controls.SetChildIndex(this.nGroupBox1, 0);
			this.Controls.SetChildIndex(this.nGroupBox2, 0);
			this.Controls.SetChildIndex(this.nGroupBox3, 0);
			this.Controls.SetChildIndex(this.nGroupBox4, 0);
			this.Controls.SetChildIndex(this.nGroupBox5, 0);
			this.nGroupBox1.ResumeLayout(false);
			this.nGroupBox2.ResumeLayout(false);
			this.nGroupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.hSpacingNumeric)).EndInit();
			this.nGroupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.vSpacingNumeric)).EndInit();
			this.nGroupBox5.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// init form fields
			batchLayout = new NBatchLayout(document);
			grid = view.Grid;

			view.BeginInit();
			
			view.Grid.Visible = true;

			// init document
			document.BeginInit();
			InitDocument();
			document.EndInit();

			// init form controls
			InitFormControls();
			
			// end view init
			view.EndInit();
		}

		protected override void AttachToEvents()
		{
			view.EventSinkService.NodeSelected += new NodeEventHandler(EventSinkService_NodeSelected);
			view.EventSinkService.NodeDeselected += new NodeEventHandler(EventSinkService_NodeDeselected);

			base.AttachToEvents();
		}

		protected override void DetachFromEvents()
		{
			view.EventSinkService.NodeSelected -= new NodeEventHandler(EventSinkService_NodeSelected);
			view.EventSinkService.NodeDeselected -= new NodeEventHandler(EventSinkService_NodeDeselected);

			base.DetachFromEvents();
		}

		#endregion

		#region Implementation

		private void InitFormControls()
		{
			PauseEventsHandling();

			hSpacingNumeric.Value = (decimal)document.Settings.HorizontalSpacingStep;
			vSpacingNumeric.Value = (decimal)document.Settings.VerticalSpacingStep;

			ResumeEventsHandling();
		}
		
		private void InitDocument()
		{
			NRectangleShape rect1 = new NRectangleShape(new NRectangleF(310, 10, 100, 80));
			NRectangleShape rect2 = new NRectangleShape(new NRectangleF(10, 200, 150, 75));
			NRectangleShape rect3 = new NRectangleShape(new NRectangleF(200, 300, 200, 100));

			document.ActiveLayer.AddChild(rect1);
			document.ActiveLayer.AddChild(rect2);
			document.ActiveLayer.AddChild(rect3);
		}

		protected bool Build()
		{
			masterNode = null;
			int count = view.Selection.Nodes.Count;
			if (count == 0)
				return false;

			masterNode = view.Selection.LastNode;
			batchLayout.Build(view.Selection.Nodes);
			return true;
		}

		private void UpdateUserControlsState()
		{
			bool canAlignVertically = view.Selection.BatchLayout.CanAlignVertically(
				view.Selection.AnchorNode,
				false
				);
		
			bool canAlignHorizontally = view.Selection.BatchLayout.CanAlignHorizontally(
				view.Selection.AnchorNode,
				false
				);

			alignLeftsButton.Enabled = canAlignVertically;
			alignRightsButton.Enabled = canAlignVertically;
			alignCentersButton.Enabled = canAlignVertically;

			alignTopsButton.Enabled = canAlignHorizontally;
			alignBottomsButton.Enabled = canAlignHorizontally;
			alignMiddlesButton.Enabled = canAlignHorizontally;

			decreaseHorizontalSpacingButton.Enabled = view.Selection.BatchLayout.CanDecreaseHorizontalSpacing(
				view.Selection.AnchorNode,
				document.Settings.HorizontalSpacingStep
				);

			decreaseVerticalSpacingButton.Enabled = view.Selection.BatchLayout.CanDecreaseVerticalSpacing(
				view.Selection.AnchorNode,
				document.Settings.VerticalSpacingStep
				);

			increaseHorizontalSpacingButton.Enabled = view.Selection.BatchLayout.CanIncreaseHorizontalSpacing(
				view.Selection.AnchorNode,
				document.Settings.HorizontalSpacingStep
				);

			increaseVerticalSpacingButton.Enabled = view.Selection.BatchLayout.CanIncreaseVerticalSpacing(
				view.Selection.AnchorNode,
				document.Settings.VerticalSpacingStep
				);

			horzontalSpacingEqualButton.Enabled = view.Selection.BatchLayout.CanMakeHorizontalSpacingEqual();
			verticalSpacingEqualButton.Enabled = view.Selection.BatchLayout.CanMakeVerticalSpacingEqual();
			centerHorizontallyButton.Enabled = view.Selection.BatchLayout.CanCenterInDocumentHorizontally(false);
			centerVerticallyButton.Enabled = view.Selection.BatchLayout.CanCenterInDocumentVertically(false);
			
			sameHeightButton.Enabled = view.Selection.BatchLayout.CanMakeSameHeight(
				view.Selection.AnchorNode,
				false
				);

			sameWidthButton.Enabled = view.Selection.BatchLayout.CanMakeSameWidth(
				view.Selection.AnchorNode,
				false
				);

			sameSizeButton.Enabled = view.Selection.BatchLayout.CanMakeSameSize(
				view.Selection.AnchorNode,
				false
				);

			removeHorizontalSpacingButton.Enabled = view.Selection.BatchLayout.CanRemoveHorizontalSpacing(
				view.Selection.AnchorNode
				);

			removeVerticalSpacingButton.Enabled = view.Selection.BatchLayout.CanRemoveVerticalSpacing(
				view.Selection.AnchorNode
				);

			alignToGridButton.Enabled = view.Selection.BatchLayout.CanAlignToGrid(
				view.Grid.Origin,
				view.Grid.GetUsedCellSize(),
				false
				);

			sizeToGridButton.Enabled = view.Selection.BatchLayout.CanSizeToGrid(
				view.Grid.Origin,
				view.Grid.GetUsedCellSize(),
				false
				);
		}

		#endregion

		#region Event Handlers

		private void alignLeftsButton_Click(object sender, System.EventArgs e)
		{
			if (!Build())
				return;

			batchLayout.AlignHorizontally(masterNode, HorzAlign.Left, false);
			view.Refresh();
		}

		private void alignToGridButton_Click(object sender, System.EventArgs e)
		{
			if (!Build())
				return;

			batchLayout.AlignToGrid(grid.Origin, view.Grid.GetUsedCellSize(), false);
			view.Refresh();
		}

		private void alignCentersButton_Click(object sender, System.EventArgs e)
		{
			if (!Build())
				return;

			batchLayout.AlignHorizontally(masterNode, HorzAlign.Center, false);
			view.Refresh();
		}

		private void alignTopsButton_Click(object sender, System.EventArgs e)
		{
			if (!Build())
				return;

			batchLayout.AlignVertically(masterNode, VertAlign.Top, false);
			view.Refresh();
		}

		private void alignMiddlesButton_Click(object sender, System.EventArgs e)
		{
			if (!Build())
				return;

			batchLayout.AlignVertically(masterNode, VertAlign.Center, false);
			view.Refresh();
		}

		private void alignRightsButton_Click(object sender, System.EventArgs e)
		{
			if (!Build())
				return;

			batchLayout.AlignHorizontally(masterNode, HorzAlign.Right, false);
			view.Refresh();
		}

		private void alignBottomsButton_Click(object sender, System.EventArgs e)
		{
			if (!Build())
				return;

			batchLayout.AlignVertically(masterNode, VertAlign.Bottom, false);
			view.Refresh();
		}


		private void sameSizeButton_Click(object sender, System.EventArgs e)
		{
			if (!Build())
				return;

			batchLayout.MakeSameSize(masterNode, false);
			view.Refresh();
		}

		private void sizeToGridButton_Click(object sender, System.EventArgs e)
		{
			if (!Build())
				return;

			batchLayout.SizeToGrid(grid.Origin, grid.GetUsedCellSize(), false);
			view.Refresh();
		}

		private void sameWidthButton_Click(object sender, System.EventArgs e)
		{
			if (!Build())
				return;

			batchLayout.MakeSameWidth(masterNode, false);
			view.Refresh();
		}

		private void sameHeightButton_Click(object sender, System.EventArgs e)
		{
			if (!Build())
				return;

			batchLayout.MakeSameHeight(masterNode, false);
			view.Refresh();
		}


		private void horizontalSpacingEqualButton_Click(object sender, System.EventArgs e)
		{
			if (!Build())
				return;

			batchLayout.MakeHorizontalSpacingEqual();
			view.Refresh();
		}

		private void increaseHorizontalSpacingButton_Click(object sender, System.EventArgs e)
		{
			if (!Build())
				return;

			batchLayout.IncreaseHorizontalSpacing(masterNode, document.Settings.HorizontalSpacingStep);
			view.Refresh();
		}

		private void decreaseHorizontalSpacingButton_Click(object sender, System.EventArgs e)
		{
			if (!Build())
				return;

			batchLayout.DecreaseHorizontalSpacing(masterNode, document.Settings.HorizontalSpacingStep);
			view.Refresh();
		}

		private void removeHorizontalSpacingButton_Click(object sender, System.EventArgs e)
		{
			if (!Build())
				return;

			batchLayout.RemoveHorizontalSpacing(masterNode);
			view.Refresh();
		}


		private void increaseVerticalSpacingButton_Click(object sender, System.EventArgs e)
		{
			if (!Build())
				return;

			batchLayout.IncreaseVerticalSpacing(masterNode, document.Settings.VerticalSpacingStep);
			view.Refresh();
		}

		private void verticalSpacingEqualButton_Click(object sender, System.EventArgs e)
		{
			if (!Build())
				return;

			batchLayout.MakeVerticalSpacingEqual();
			view.Refresh();
		}

		private void removeVerticalSpacingButton_Click(object sender, System.EventArgs e)
		{
			if (!Build())
				return;

			batchLayout.RemoveVerticalSpacing(masterNode);
			view.Refresh();
		}

		private void decreaseVerticalSpacingButton_Click(object sender, System.EventArgs e)
		{
			if (!Build())
				return;

			batchLayout.DecreaseVerticalSpacing(masterNode, document.Settings.VerticalSpacingStep);
			view.Refresh();
		}


		private void centerHorizontallyButton_Click(object sender, System.EventArgs e)
		{
			if (!Build())
				return;

			batchLayout.CenterInDocumentHorizontally(false);
			view.Refresh();
		}

		private void centerVerticallyButton_Click(object sender, System.EventArgs e)
		{
			if (!Build())
				return;

			batchLayout.CenterInDocumentVertically(false);
			view.Refresh();
		}


		private void hSpacingNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			document.Settings.HorizontalSpacingStep = (float) hSpacingNumeric.Value;
		}

		private void vSpacingNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			document.Settings.VerticalSpacingStep = (float) vSpacingNumeric.Value;
		}

		private void EventSinkService_NodeSelected(NNodeEventArgs args)
		{
			UpdateUserControlsState();
		}

		private void EventSinkService_NodeDeselected(NNodeEventArgs args)
		{
			UpdateUserControlsState();
		}

		#endregion

		#region Designer Fields

		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NNumericUpDown hSpacingNumeric;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NNumericUpDown vSpacingNumeric;
		private Nevron.UI.WinForm.Controls.NButton increaseHorizontalSpacingButton;
		private Nevron.UI.WinForm.Controls.NButton decreaseHorizontalSpacingButton;
		private Nevron.UI.WinForm.Controls.NButton removeHorizontalSpacingButton;
		private Nevron.UI.WinForm.Controls.NButton horzontalSpacingEqualButton;
		private Nevron.UI.WinForm.Controls.NButton verticalSpacingEqualButton;
		private Nevron.UI.WinForm.Controls.NButton removeVerticalSpacingButton;
		private Nevron.UI.WinForm.Controls.NButton decreaseVerticalSpacingButton;
		private Nevron.UI.WinForm.Controls.NButton increaseVerticalSpacingButton;
		private Nevron.UI.WinForm.Controls.NButton centerHorizontallyButton;
		private Nevron.UI.WinForm.Controls.NButton centerVerticallyButton;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox3;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox4;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox5;

		private Nevron.UI.WinForm.Controls.NButton alignMiddlesButton;
		private Nevron.UI.WinForm.Controls.NButton alignLeftsButton;
		private Nevron.UI.WinForm.Controls.NButton alignBottomsButton;
		private Nevron.UI.WinForm.Controls.NButton alignToGridButton;
		private Nevron.UI.WinForm.Controls.NButton alignCentersButton;
		private Nevron.UI.WinForm.Controls.NButton alignTopsButton;
		private Nevron.UI.WinForm.Controls.NButton alignRightsButton;
		private Nevron.UI.WinForm.Controls.NButton sameWidthButton;
		private Nevron.UI.WinForm.Controls.NButton sizeToGridButton;
		private Nevron.UI.WinForm.Controls.NButton sameHeightButton;
		private Nevron.UI.WinForm.Controls.NButton sameSizeButton;

		private System.ComponentModel.Container components = null;

		#endregion

		#region Fields
		
		private NGrid grid;
		private NBatchLayout batchLayout;
		private INNode masterNode;

		#endregion
	}
}
