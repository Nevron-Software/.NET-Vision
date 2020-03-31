using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	public class NHScrollBarUC : NExampleUserControl
	{
		#region Constructor

		public NHScrollBarUC(MainForm f) : base(f)
		{
			InitializeComponent();

			Dock = DockStyle.Fill;
		}


		#endregion

		#region Implementation

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


		#endregion

		#region Event Handlers

		private void nhScrollBar1_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
		}

		private void nCheckBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			foreach(Control c in Controls)
			{
				if(c is NScrollBar)
					c.Enabled = nCheckBox1.Checked;
			}
		}

		private void nCheckBox2_CheckedChanged(object sender, System.EventArgs e)
		{
			foreach(Control c in Controls)
			{
				if(c is NScrollBar)
					((NScrollBar)c).HotTrack = this.nCheckBox2.Checked;
			}
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.nhScrollBar4 = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.nhScrollBar3 = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.nhScrollBar2 = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.nhScrollBar1 = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.nCheckBox1 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox2 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// nhScrollBar4
			// 
			this.nhScrollBar4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.nhScrollBar4.Location = new System.Drawing.Point(8, 72);
			this.nhScrollBar4.Name = "nhScrollBar4";
			this.nhScrollBar4.Size = new System.Drawing.Size(408, 56);
			this.nhScrollBar4.TabIndex = 3;
			this.nhScrollBar4.Text = "nhScrollBar4";
			// 
			// nhScrollBar3
			// 
			this.nhScrollBar3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.nhScrollBar3.Location = new System.Drawing.Point(8, 136);
			this.nhScrollBar3.Name = "nhScrollBar3";
			this.nhScrollBar3.Size = new System.Drawing.Size(408, 136);
			this.nhScrollBar3.TabIndex = 2;
			this.nhScrollBar3.Text = "nhScrollBar3";
			// 
			// nhScrollBar2
			// 
			this.nhScrollBar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.nhScrollBar2.Location = new System.Drawing.Point(8, 32);
			this.nhScrollBar2.Name = "nhScrollBar2";
			this.nhScrollBar2.Size = new System.Drawing.Size(408, 32);
			this.nhScrollBar2.TabIndex = 1;
			this.nhScrollBar2.Text = "nhScrollBar2";
			// 
			// nhScrollBar1
			// 
			this.nhScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.nhScrollBar1.LargeChange = 5;
			this.nhScrollBar1.Location = new System.Drawing.Point(8, 5);
			this.nhScrollBar1.Maximum = 255;
			this.nhScrollBar1.Name = "nhScrollBar1";
			this.nhScrollBar1.Size = new System.Drawing.Size(408, 17);
			this.nhScrollBar1.TabIndex = 0;
			this.nhScrollBar1.Text = "nhScrollBar1";
			this.nhScrollBar1.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.nhScrollBar1_ValueChanged);
			// 
			// nCheckBox1
			// 
			this.nCheckBox1.Checked = true;
			this.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.nCheckBox1.Location = new System.Drawing.Point(8, 280);
			this.nCheckBox1.Name = "nCheckBox1";
			this.nCheckBox1.Size = new System.Drawing.Size(80, 24);
			this.nCheckBox1.TabIndex = 4;
			this.nCheckBox1.Text = "&Enable";
			this.nCheckBox1.CheckedChanged += new System.EventHandler(this.nCheckBox1_CheckedChanged);
			// 
			// nCheckBox2
			// 
			this.nCheckBox2.Checked = true;
			this.nCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.nCheckBox2.Location = new System.Drawing.Point(96, 280);
			this.nCheckBox2.Name = "nCheckBox2";
			this.nCheckBox2.Size = new System.Drawing.Size(88, 24);
			this.nCheckBox2.TabIndex = 5;
			this.nCheckBox2.Text = "&Hot Track";
			this.nCheckBox2.CheckedChanged += new System.EventHandler(this.nCheckBox2_CheckedChanged);
			// 
			// NHScrollBarUC
			// 
			this.Controls.Add(this.nCheckBox2);
			this.Controls.Add(this.nCheckBox1);
			this.Controls.Add(this.nhScrollBar4);
			this.Controls.Add(this.nhScrollBar3);
			this.Controls.Add(this.nhScrollBar2);
			this.Controls.Add(this.nhScrollBar1);
			this.DockPadding.All = 5;
			this.Name = "NHScrollBarUC";
			this.Size = new System.Drawing.Size(424, 312);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NHScrollBar nhScrollBar1;
		private Nevron.UI.WinForm.Controls.NHScrollBar nhScrollBar2;
		private Nevron.UI.WinForm.Controls.NHScrollBar nhScrollBar3;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox1;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox2;
		private Nevron.UI.WinForm.Controls.NHScrollBar nhScrollBar4;

		#endregion
	}
}
