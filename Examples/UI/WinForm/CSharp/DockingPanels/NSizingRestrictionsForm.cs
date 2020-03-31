using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.UI.WinForm.Docking;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NSizingRestrictionsForm.
	/// </summary>
	public class NSizingRestrictionsForm : NForm
	{
		#region Constructor

		public NSizingRestrictionsForm()
		{
			InitializeComponent();
		}


		#endregion

		#region Overrides

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}

				if(nDockManager1 != null)
				{
					nDockManager1.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#endregion

		#region Implementation

		internal void UpdateContainer()
		{
			NDockingPanelContainer container = nDockingPanel1.ContainerPanel;
			if(container == null || container.DockState != DockState.Floating)
			{
				return;
			}

			int maxWidth = (int)widthNumeric.Value;
			int maxHeight = (int)heightNumeric.Value;
			int minWidth = (int)minWidthNumeric.Value;
			int minHeight = (int)minHeightNumeric.Value;

			container.MinimumSize = new Size(minWidth, minHeight);
			container.MaximumSize = new Size(maxWidth, maxHeight);

			container.Sizable = nCheckBox1.Checked;
		}


		#endregion

		#region Event Handlers

		private void nDockManager1_AfterPanelFloat(object sender, Nevron.UI.WinForm.Docking.PanelEventArgs e)
		{
			UpdateContainer();
		}
		private void widthNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateContainer();
		}

		private void heightNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateContainer();
		}

		private void nCheckBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateContainer();
		}


		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			Nevron.UI.WinForm.Docking.NDockingPanelHost nDockZone1 = new Nevron.UI.WinForm.Docking.NDockingPanelHost();
			this.nDockManager1 = new Nevron.UI.WinForm.Docking.NDockManager();
			this.nDockingPanel1 = new Nevron.UI.WinForm.Docking.NDockingPanel();
			this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.minHeightNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.minWidthNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.heightNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.widthNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.nCheckBox1 = new Nevron.UI.WinForm.Controls.NCheckBox();
			((System.ComponentModel.ISupportInitialize)(this.nDockManager1)).BeginInit();
			this.nDockingPanel1.SuspendLayout();
			this.nGroupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.minHeightNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.minWidthNumeric)).BeginInit();
			this.nGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.heightNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.widthNumeric)).BeginInit();
			// 
			// nDockManager1
			// 
			this.nDockManager1.Form = this;
			this.nDockManager1.RootContainerZIndex = 0;
			this.nDockManager1.AfterPanelFloat += new Nevron.UI.WinForm.Docking.PanelEventHandler(this.nDockManager1_AfterPanelFloat);
			//  
			// Root Zone
			//  
			this.nDockManager1.RootContainer.RootZone.AddChild(nDockZone1);
			this.nDockManager1.RootContainer.RootZone.Orientation = System.Windows.Forms.Orientation.Horizontal;
			//  
			// nDockZone1
			//  
			nDockZone1.AddChild(this.nDockingPanel1);
			nDockZone1.Name = "nDockZone1";
			nDockZone1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			nDockZone1.Index = 0;
			nDockZone1.SizeInfo.PrefferedSize = new System.Drawing.Size(250, 200);
			// 
			// nDockingPanel1
			// 
			this.nDockingPanel1.Controls.Add(this.nGroupBox2);
			this.nDockingPanel1.Controls.Add(this.nGroupBox1);
			this.nDockingPanel1.Controls.Add(this.nCheckBox1);
			this.nDockingPanel1.Name = "nDockingPanel1";
			this.nDockingPanel1.Permissions.AllowHide = false;
			this.nDockingPanel1.SizeInfo.PrefferedSize = new System.Drawing.Size(250, 200);
			this.nDockingPanel1.TabIndex = 1;
			this.nDockingPanel1.Text = "Docking Panel";
			// 
			// nGroupBox2
			// 
			this.nGroupBox2.Controls.Add(this.minHeightNumeric);
			this.nGroupBox2.Controls.Add(this.minWidthNumeric);
			this.nGroupBox2.Controls.Add(this.label3);
			this.nGroupBox2.Controls.Add(this.label4);
			this.nGroupBox2.ImageIndex = 0;
			this.nGroupBox2.Location = new System.Drawing.Point(8, 120);
			this.nGroupBox2.Name = "nGroupBox2";
			this.nGroupBox2.Size = new System.Drawing.Size(224, 96);
			this.nGroupBox2.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default;
			this.nGroupBox2.TabIndex = 2;
			this.nGroupBox2.TabStop = false;
			this.nGroupBox2.Text = "Min Floating Size";
			// 
			// minHeightNumeric
			// 
			this.minHeightNumeric.Increment = new System.Decimal(new int[] {
																			   10,
																			   0,
																			   0,
																			   0});
			this.minHeightNumeric.Location = new System.Drawing.Point(80, 48);
			this.minHeightNumeric.Maximum = new System.Decimal(new int[] {
																			 1000,
																			 0,
																			 0,
																			 0});
			this.minHeightNumeric.Name = "minHeightNumeric";
			this.minHeightNumeric.Size = new System.Drawing.Size(72, 20);
			this.minHeightNumeric.TabIndex = 3;
			this.minHeightNumeric.Value = new System.Decimal(new int[] {
																		   150,
																		   0,
																		   0,
																		   0});
			// 
			// minWidthNumeric
			// 
			this.minWidthNumeric.Increment = new System.Decimal(new int[] {
																			  10,
																			  0,
																			  0,
																			  0});
			this.minWidthNumeric.Location = new System.Drawing.Point(80, 24);
			this.minWidthNumeric.Maximum = new System.Decimal(new int[] {
																			1000,
																			0,
																			0,
																			0});
			this.minWidthNumeric.Name = "minWidthNumeric";
			this.minWidthNumeric.Size = new System.Drawing.Size(72, 20);
			this.minWidthNumeric.TabIndex = 2;
			this.minWidthNumeric.Value = new System.Decimal(new int[] {
																		  150,
																		  0,
																		  0,
																		  0});
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 1;
			this.label3.Text = "Height:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "Width:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.heightNumeric);
			this.nGroupBox1.Controls.Add(this.widthNumeric);
			this.nGroupBox1.Controls.Add(this.label2);
			this.nGroupBox1.Controls.Add(this.label1);
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(8, 16);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(224, 96);
			this.nGroupBox1.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default;
			this.nGroupBox1.TabIndex = 1;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Max Floating Size";
			// 
			// heightNumeric
			// 
			this.heightNumeric.Increment = new System.Decimal(new int[] {
																			10,
																			0,
																			0,
																			0});
			this.heightNumeric.Location = new System.Drawing.Point(80, 48);
			this.heightNumeric.Maximum = new System.Decimal(new int[] {
																		  1000,
																		  0,
																		  0,
																		  0});
			this.heightNumeric.Name = "heightNumeric";
			this.heightNumeric.Size = new System.Drawing.Size(72, 20);
			this.heightNumeric.TabIndex = 3;
			this.heightNumeric.Value = new System.Decimal(new int[] {
																		200,
																		0,
																		0,
																		0});
			this.heightNumeric.ValueChanged += new System.EventHandler(this.heightNumeric_ValueChanged);
			// 
			// widthNumeric
			// 
			this.widthNumeric.Increment = new System.Decimal(new int[] {
																		   10,
																		   0,
																		   0,
																		   0});
			this.widthNumeric.Location = new System.Drawing.Point(80, 24);
			this.widthNumeric.Maximum = new System.Decimal(new int[] {
																		 1000,
																		 0,
																		 0,
																		 0});
			this.widthNumeric.Name = "widthNumeric";
			this.widthNumeric.Size = new System.Drawing.Size(72, 20);
			this.widthNumeric.TabIndex = 2;
			this.widthNumeric.Value = new System.Decimal(new int[] {
																	   200,
																	   0,
																	   0,
																	   0});
			this.widthNumeric.ValueChanged += new System.EventHandler(this.widthNumeric_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Height:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Width:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nCheckBox1
			// 
			this.nCheckBox1.ButtonProperties.BorderOffset = 2;
			this.nCheckBox1.Checked = true;
			this.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.nCheckBox1.Location = new System.Drawing.Point(8, 224);
			this.nCheckBox1.Name = "nCheckBox1";
			this.nCheckBox1.Size = new System.Drawing.Size(176, 24);
			this.nCheckBox1.TabIndex = 0;
			this.nCheckBox1.Text = "Allow sizing in floating state";
			this.nCheckBox1.CheckedChanged += new System.EventHandler(this.nCheckBox1_CheckedChanged);
			// 
			// NSizingRestrictionsForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(773, 552);
			this.Name = "NSizingRestrictionsForm";
			this.Text = "Docking Panels - Sizing Restrictions Example";
			((System.ComponentModel.ISupportInitialize)(this.nDockManager1)).EndInit();
			this.nDockingPanel1.ResumeLayout(false);
			this.nGroupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.minHeightNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.minWidthNumeric)).EndInit();
			this.nGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.heightNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.widthNumeric)).EndInit();

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Docking.NDockManager nDockManager1;
		private Nevron.UI.WinForm.Docking.NDockingPanel nDockingPanel1;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NNumericUpDown widthNumeric;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
		private Nevron.UI.WinForm.Controls.NNumericUpDown minWidthNumeric;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NNumericUpDown minHeightNumeric;
		private Nevron.UI.WinForm.Controls.NNumericUpDown heightNumeric;

		#endregion
	}
}
