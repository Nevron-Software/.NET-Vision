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
	/// Summary description for NFontListBoxUC.
	/// </summary>
	public class NFontListBoxUC : NExampleUserControl
	{
		#region Constructor

		public NFontListBoxUC(MainForm f) : base(f)
		{
			InitializeComponent();

			Dock = DockStyle.Fill;
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
			}
			base.Dispose( disposing );
		}

		public override void Initialize()
		{
			base.Initialize ();

			nListBox1.DisplayStyle = FontDisplayStyle.Name;
			nListBox2.DisplayStyle = FontDisplayStyle.NameInFont;
			nListBox3.DisplayStyle = FontDisplayStyle.NameAndSample;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.nListBox1 = new NFontListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.nListBox2 = new NFontListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.nListBox3 = new NFontListBox();
			this.SuspendLayout();
			// 
			// nListBox1
			// 
			this.nListBox1.Location = new System.Drawing.Point(16, 32);
			this.nListBox1.Name = "nListBox1";
			this.nListBox1.Size = new System.Drawing.Size(224, 184);
			this.nListBox1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(224, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Name only:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(256, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(256, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Name in font:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// nListBox2
			// 
			this.nListBox2.Location = new System.Drawing.Point(256, 32);
			this.nListBox2.Name = "nListBox2";
			this.nListBox2.Size = new System.Drawing.Size(256, 184);
			this.nListBox2.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 224);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(264, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Name and sample:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// nListBox3
			// 
			this.nListBox3.Location = new System.Drawing.Point(16, 248);
			this.nListBox3.Name = "nListBox3";
			this.nListBox3.Size = new System.Drawing.Size(496, 184);
			this.nListBox3.TabIndex = 4;
			// 
			// NFontListBoxUC
			// 
			this.AutoScroll = true;
			this.Controls.Add(this.label3);
			this.Controls.Add(this.nListBox3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.nListBox2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.nListBox1);
			this.Name = "NFontListBoxUC";
			this.Size = new System.Drawing.Size(528, 456);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NFontListBox nListBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NFontListBox nListBox2;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NFontListBox nListBox3;

		#endregion
	}
}
