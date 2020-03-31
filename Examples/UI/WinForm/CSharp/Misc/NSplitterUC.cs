using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NSplitterUC.
	/// </summary>
	public class NSplitterUC : NExampleUserControl
	{
		#region Constructor

		public NSplitterUC(MainForm f) : base(f)
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.nSplitter1 = new Nevron.UI.WinForm.Controls.NSplitter();
			this.panel2 = new System.Windows.Forms.Panel();
			this.nSplitter2 = new Nevron.UI.WinForm.Controls.NSplitter();
			this.panel3 = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(152, 240);
			this.panel1.TabIndex = 0;
			// 
			// nSplitter1
			// 
			this.nSplitter1.Location = new System.Drawing.Point(152, 0);
			this.nSplitter1.Name = "nSplitter1";
			this.nSplitter1.Size = new System.Drawing.Size(5, 240);
			this.nSplitter1.TabIndex = 1;
			this.nSplitter1.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(158, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(138, 100);
			this.panel2.TabIndex = 2;
			// 
			// nSplitter2
			// 
			this.nSplitter2.Dock = System.Windows.Forms.DockStyle.Top;
			this.nSplitter2.Location = new System.Drawing.Point(158, 100);
			this.nSplitter2.Name = "nSplitter2";
			this.nSplitter2.Size = new System.Drawing.Size(138, 5);
			this.nSplitter2.TabIndex = 3;
			this.nSplitter2.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(158, 108);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(138, 132);
			this.panel3.TabIndex = 4;
			// 
			// NSplitterUC
			// 
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.nSplitter2);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.nSplitter1);
			this.Controls.Add(this.panel1);
			this.Name = "NSplitterUC";
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		private System.Windows.Forms.Panel panel1;
		private Nevron.UI.WinForm.Controls.NSplitter nSplitter1;
		private System.Windows.Forms.Panel panel2;
		private Nevron.UI.WinForm.Controls.NSplitter nSplitter2;
		private System.Windows.Forms.Panel panel3;

		#endregion
	}
}
