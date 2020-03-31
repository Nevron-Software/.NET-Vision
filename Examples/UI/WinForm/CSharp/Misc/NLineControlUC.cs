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
	/// Summary description for NLineControlUC.
	/// </summary>
	public class NLineControlUC : NExampleUserControl
	{
		#region Constructor

		public NLineControlUC(MainForm f) : base(f)
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
			this.nLineControl1 = new Nevron.UI.WinForm.Controls.NLineControl();
			this.nLineControl2 = new Nevron.UI.WinForm.Controls.NLineControl();
			this.nLineControl3 = new Nevron.UI.WinForm.Controls.NLineControl();
			this.nLineControl4 = new Nevron.UI.WinForm.Controls.NLineControl();
			this.SuspendLayout();
			// 
			// nLineControl1
			// 
			this.nLineControl1.Location = new System.Drawing.Point(8, 8);
			this.nLineControl1.Name = "nLineControl1";
			this.nLineControl1.Size = new System.Drawing.Size(280, 2);
			this.nLineControl1.Text = "nLineControl1";
			// 
			// nLineControl2
			// 
			this.nLineControl2.Location = new System.Drawing.Point(8, 16);
			this.nLineControl2.Name = "nLineControl2";
			this.nLineControl2.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.nLineControl2.Size = new System.Drawing.Size(2, 216);
			this.nLineControl2.Text = "nLineControl2";
			// 
			// nLineControl3
			// 
			this.nLineControl3.Location = new System.Drawing.Point(24, 32);
			this.nLineControl3.Name = "nLineControl3";
			this.nLineControl3.Size = new System.Drawing.Size(256, 2);
			this.nLineControl3.Text = "nLineControl3";
			// 
			// nLineControl4
			// 
			this.nLineControl4.Location = new System.Drawing.Point(24, 40);
			this.nLineControl4.Name = "nLineControl4";
			this.nLineControl4.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.nLineControl4.Size = new System.Drawing.Size(2, 192);
			this.nLineControl4.Text = "nLineControl4";
			// 
			// NLineControlUC
			// 
			this.Controls.Add(this.nLineControl4);
			this.Controls.Add(this.nLineControl3);
			this.Controls.Add(this.nLineControl2);
			this.Controls.Add(this.nLineControl1);
			this.Name = "NLineControlUC";
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		private Nevron.UI.WinForm.Controls.NLineControl nLineControl1;
		private Nevron.UI.WinForm.Controls.NLineControl nLineControl2;
		private Nevron.UI.WinForm.Controls.NLineControl nLineControl3;
		private Nevron.UI.WinForm.Controls.NLineControl nLineControl4;

		#endregion
	}
}
