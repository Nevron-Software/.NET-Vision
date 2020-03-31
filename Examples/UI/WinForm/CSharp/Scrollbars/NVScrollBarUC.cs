using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	public class NVScrollBarUC : NExampleUserControl
	{
		#region Constructor

		public NVScrollBarUC(MainForm f) : base(f)
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
			this.nvScrollBar1 = new Nevron.UI.WinForm.Controls.NVScrollBar();
			this.nvScrollBar2 = new Nevron.UI.WinForm.Controls.NVScrollBar();
			this.nvScrollBar3 = new Nevron.UI.WinForm.Controls.NVScrollBar();
			this.nvScrollBar4 = new Nevron.UI.WinForm.Controls.NVScrollBar();
			this.nCheckBox2 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox1 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// nvScrollBar1
			// 
			this.nvScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.nvScrollBar1.Location = new System.Drawing.Point(8, 8);
			this.nvScrollBar1.Name = "nvScrollBar1";
			this.nvScrollBar1.Size = new System.Drawing.Size(17, 320);
			this.nvScrollBar1.TabIndex = 0;
			this.nvScrollBar1.Text = "nvScrollBar1";
			// 
			// nvScrollBar2
			// 
			this.nvScrollBar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.nvScrollBar2.Location = new System.Drawing.Point(32, 8);
			this.nvScrollBar2.Name = "nvScrollBar2";
			this.nvScrollBar2.Size = new System.Drawing.Size(32, 320);
			this.nvScrollBar2.TabIndex = 1;
			this.nvScrollBar2.Text = "nvScrollBar2";
			// 
			// nvScrollBar3
			// 
			this.nvScrollBar3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.nvScrollBar3.Location = new System.Drawing.Point(72, 8);
			this.nvScrollBar3.Name = "nvScrollBar3";
			this.nvScrollBar3.Size = new System.Drawing.Size(96, 320);
			this.nvScrollBar3.TabIndex = 2;
			this.nvScrollBar3.Text = "nvScrollBar3";
			// 
			// nvScrollBar4
			// 
			this.nvScrollBar4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.nvScrollBar4.Location = new System.Drawing.Point(176, 8);
			this.nvScrollBar4.Name = "nvScrollBar4";
			this.nvScrollBar4.Size = new System.Drawing.Size(200, 320);
			this.nvScrollBar4.TabIndex = 3;
			this.nvScrollBar4.Text = "nvScrollBar4";
			// 
			// nCheckBox2
			// 
			this.nCheckBox2.Checked = true;
			this.nCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.nCheckBox2.Location = new System.Drawing.Point(384, 32);
			this.nCheckBox2.Name = "nCheckBox2";
			this.nCheckBox2.Size = new System.Drawing.Size(88, 24);
			this.nCheckBox2.TabIndex = 7;
			this.nCheckBox2.Text = "&Hot Track";
			this.nCheckBox2.CheckedChanged += new System.EventHandler(this.nCheckBox2_CheckedChanged);
			// 
			// nCheckBox1
			// 
			this.nCheckBox1.Checked = true;
			this.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.nCheckBox1.Location = new System.Drawing.Point(384, 8);
			this.nCheckBox1.Name = "nCheckBox1";
			this.nCheckBox1.Size = new System.Drawing.Size(80, 24);
			this.nCheckBox1.TabIndex = 6;
			this.nCheckBox1.Text = "&Enable";
			this.nCheckBox1.CheckedChanged += new System.EventHandler(this.nCheckBox1_CheckedChanged);
			// 
			// NVScrollBarUC
			// 
			this.Controls.Add(this.nCheckBox2);
			this.Controls.Add(this.nCheckBox1);
			this.Controls.Add(this.nvScrollBar4);
			this.Controls.Add(this.nvScrollBar3);
			this.Controls.Add(this.nvScrollBar2);
			this.Controls.Add(this.nvScrollBar1);
			this.Name = "NVScrollBarUC";
			this.Size = new System.Drawing.Size(472, 336);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NVScrollBar nvScrollBar1;
		private Nevron.UI.WinForm.Controls.NVScrollBar nvScrollBar2;
		private Nevron.UI.WinForm.Controls.NVScrollBar nvScrollBar3;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox2;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox1;
		private Nevron.UI.WinForm.Controls.NVScrollBar nvScrollBar4;

		#endregion
	}
}
