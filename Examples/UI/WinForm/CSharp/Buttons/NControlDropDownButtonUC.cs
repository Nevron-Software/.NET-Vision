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
	/// <summary>
	/// Summary description for NControlDropDownButtonUC.
	/// </summary>
	public class NControlDropDownButtonUC : NExampleUserControl
	{
		#region Constructor

		public NControlDropDownButtonUC(MainForm f) : base(f)
		{
			InitializeComponent();
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.nControlDropDownButton1 = new Nevron.UI.WinForm.Controls.NControlDropDownButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.hScrollBar1 = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.textBox1 = new Nevron.UI.WinForm.Controls.NTextBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.button1 = new Nevron.UI.WinForm.Controls.NButton();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// nControlDropDownButton1
			// 
			this.nControlDropDownButton1.DialogResult = System.Windows.Forms.DialogResult.No;
			this.nControlDropDownButton1.DropDownControl = this.panel1;
			this.nControlDropDownButton1.Location = new System.Drawing.Point(8, 8);
			this.nControlDropDownButton1.Name = "nControlDropDownButton1";
			this.nControlDropDownButton1.Size = new System.Drawing.Size(176, 23);
			this.nControlDropDownButton1.TabIndex = 0;
			this.nControlDropDownButton1.Text = "nControlDropDownButton1";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.hScrollBar1);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.linkLabel1);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Location = new System.Drawing.Point(8, 40);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(232, 200);
			this.panel1.TabIndex = 1;
			// 
			// hScrollBar1
			// 
			this.hScrollBar1.Location = new System.Drawing.Point(112, 32);
			this.hScrollBar1.Name = "hScrollBar1";
			this.hScrollBar1.Size = new System.Drawing.Size(104, 17);
			this.hScrollBar1.TabIndex = 3;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(56, 136);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 22);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "textBox1";
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(48, 80);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.TabIndex = 1;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "linkLabel1";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(24, 24);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			// 
			// NControlDropDownButtonUC
			// 
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.nControlDropDownButton1);
			this.Name = "NControlDropDownButtonUC";
			this.Size = new System.Drawing.Size(256, 248);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		private Nevron.UI.WinForm.Controls.NControlDropDownButton nControlDropDownButton1;
		private System.Windows.Forms.Panel panel1;
		private NButton button1;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private NTextBox textBox1;
		private NHScrollBar hScrollBar1;

		#endregion
	}
}
