using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NDesktopToolbarContentUC.
	/// </summary>
	public class NDesktopToolbarContentUC : System.Windows.Forms.UserControl
	{
		private Nevron.UI.WinForm.Controls.NExplorerBar nExplorerBar1;
		private Nevron.UI.WinForm.Controls.NExpander nExpander1;
		private Nevron.UI.WinForm.Controls.NExpander nExpander2;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NDesktopToolbarContentUC()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

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
			this.nExplorerBar1 = new Nevron.UI.WinForm.Controls.NExplorerBar();
			this.nExpander1 = new Nevron.UI.WinForm.Controls.NExpander();
			this.nExpander2 = new Nevron.UI.WinForm.Controls.NExpander();
			((System.ComponentModel.ISupportInitialize)(this.nExplorerBar1)).BeginInit();
			this.nExplorerBar1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nExpander1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nExpander2)).BeginInit();
			this.SuspendLayout();
			// 
			// nExplorerBar1
			// 
			this.nExplorerBar1.ClientPadding = new Nevron.UI.NPadding(8);
			this.nExplorerBar1.Controls.Add(this.nExpander1);
			this.nExplorerBar1.Controls.Add(this.nExpander2);
			this.nExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nExplorerBar1.Location = new System.Drawing.Point(0, 0);
			this.nExplorerBar1.Name = "nExplorerBar1";
			this.nExplorerBar1.Size = new System.Drawing.Size(248, 344);
			this.nExplorerBar1.TabIndex = 0;
			this.nExplorerBar1.Text = "nExplorerBar1";
			// 
			// nExpander1
			// 
			this.nExpander1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.nExpander1.Location = new System.Drawing.Point(8, 8);
			this.nExpander1.Name = "nExpander1";
			this.nExpander1.Size = new System.Drawing.Size(232, 160);
			this.nExpander1.TabIndex = 1;
			this.nExpander1.Text = "nExpander1";
			// 
			// nExpander2
			// 
			this.nExpander2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.nExpander2.Location = new System.Drawing.Point(8, 176);
			this.nExpander2.Name = "nExpander2";
			this.nExpander2.Size = new System.Drawing.Size(232, 136);
			this.nExpander2.TabIndex = 2;
			this.nExpander2.Text = "nExpander2";
			// 
			// NDesktopToolbarContentUC
			// 
			this.Controls.Add(this.nExplorerBar1);
			this.Name = "NDesktopToolbarContentUC";
			this.Size = new System.Drawing.Size(248, 344);
			((System.ComponentModel.ISupportInitialize)(this.nExplorerBar1)).EndInit();
			this.nExplorerBar1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nExpander1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nExpander2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	}
}
