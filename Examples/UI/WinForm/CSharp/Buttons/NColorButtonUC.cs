using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	public class NColorButtonUC : NExampleUserControl
	{
		#region Constructor

		public NColorButtonUC(MainForm f) : base(f)
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

		#region Event Handlers

		private void nCheckBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			foreach(Control c in Controls)
			{
				foreach(Control c1 in c.Controls)
				{
					if(!(c1 is NButton))
						continue;
					c1.Enabled = nCheckBox1.Checked;
				}
			}
		}
		private void nCheckBox2_CheckedChanged(object sender, System.EventArgs e)
		{
			foreach(Control c in Controls)
			{
				foreach(Control c1 in c.Controls)
				{
					if(!(c1 is NButton))
						continue;
					((NButton)c1).ButtonProperties.ShowFocusRect = nCheckBox2.Checked;
				}
			}
		}

		private void nCheckBox3_CheckedChanged(object sender, System.EventArgs e)
		{
			foreach(Control c in Controls)
			{
				foreach(Control c1 in c.Controls)
				{
					if(!(c1 is NOptionButton))
						continue;
					((NOptionButton)c1).ShowArrow = nCheckBox3.Checked;
				}
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
			this.nColorButton1 = new Nevron.UI.WinForm.Controls.NColorButton();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nColorButton5 = new Nevron.UI.WinForm.Controls.NColorButton();
			this.nColorButton4 = new Nevron.UI.WinForm.Controls.NColorButton();
			this.nColorButton3 = new Nevron.UI.WinForm.Controls.NColorButton();
			this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nColorButton13 = new Nevron.UI.WinForm.Controls.NColorButton();
			this.nColorButton14 = new Nevron.UI.WinForm.Controls.NColorButton();
			this.nColorButton15 = new Nevron.UI.WinForm.Controls.NColorButton();
			this.nColorButton16 = new Nevron.UI.WinForm.Controls.NColorButton();
			this.nCheckBox2 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox1 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox3 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nGroupBox1.SuspendLayout();
			this.nGroupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// nColorButton1
			// 
			this.nColorButton1.ArrowClickOptions = false;
			this.nColorButton1.Color = System.Drawing.Color.White;
			this.nColorButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nColorButton1.Location = new System.Drawing.Point(8, 24);
			this.nColorButton1.Name = "nColorButton1";
			this.nColorButton1.Size = new System.Drawing.Size(80, 24);
			this.nColorButton1.TabIndex = 0;
			this.nColorButton1.Text = "nColorButton1";
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.nColorButton5);
			this.nGroupBox1.Controls.Add(this.nColorButton4);
			this.nGroupBox1.Controls.Add(this.nColorButton3);
			this.nGroupBox1.Controls.Add(this.nColorButton1);
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(8, 8);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(200, 96);
			this.nGroupBox1.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default;
			this.nGroupBox1.TabIndex = 4;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Drop-down Color Buttons";
			// 
			// nColorButton5
			// 
			this.nColorButton5.ArrowClickOptions = false;
			this.nColorButton5.Color = System.Drawing.Color.White;
			this.nColorButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nColorButton5.Location = new System.Drawing.Point(96, 56);
			this.nColorButton5.Name = "nColorButton5";
			this.nColorButton5.Size = new System.Drawing.Size(80, 24);
			this.nColorButton5.TabIndex = 3;
			this.nColorButton5.Text = "nColorButton5";
			// 
			// nColorButton4
			// 
			this.nColorButton4.ArrowClickOptions = false;
			this.nColorButton4.Color = System.Drawing.Color.White;
			this.nColorButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nColorButton4.Location = new System.Drawing.Point(8, 56);
			this.nColorButton4.Name = "nColorButton4";
			this.nColorButton4.Size = new System.Drawing.Size(80, 24);
			this.nColorButton4.TabIndex = 2;
			this.nColorButton4.Text = "nColorButton4";
			// 
			// nColorButton3
			// 
			this.nColorButton3.ArrowClickOptions = false;
			this.nColorButton3.Color = System.Drawing.Color.White;
			this.nColorButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nColorButton3.Location = new System.Drawing.Point(96, 24);
			this.nColorButton3.Name = "nColorButton3";
			this.nColorButton3.Size = new System.Drawing.Size(80, 24);
			this.nColorButton3.TabIndex = 1;
			this.nColorButton3.Text = "nColorButton3";
			// 
			// nGroupBox2
			// 
			this.nGroupBox2.Controls.Add(this.nColorButton13);
			this.nGroupBox2.Controls.Add(this.nColorButton14);
			this.nGroupBox2.Controls.Add(this.nColorButton15);
			this.nGroupBox2.Controls.Add(this.nColorButton16);
			this.nGroupBox2.ImageIndex = 0;
			this.nGroupBox2.Location = new System.Drawing.Point(8, 112);
			this.nGroupBox2.Name = "nGroupBox2";
			this.nGroupBox2.Size = new System.Drawing.Size(200, 96);
			this.nGroupBox2.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default;
			this.nGroupBox2.TabIndex = 5;
			this.nGroupBox2.TabStop = false;
			this.nGroupBox2.Text = "Modal Color Buttons";
			// 
			// nColorButton13
			// 
			this.nColorButton13.ArrowClickOptions = false;
			this.nColorButton13.Color = System.Drawing.Color.White;
			this.nColorButton13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nColorButton13.Location = new System.Drawing.Point(96, 56);
			this.nColorButton13.Mode = Nevron.UI.WinForm.Controls.OptionButtonMode.Modal;
			this.nColorButton13.Name = "nColorButton13";
			this.nColorButton13.Size = new System.Drawing.Size(80, 24);
			this.nColorButton13.TabIndex = 3;
			this.nColorButton13.Text = "nColorButton5";
			// 
			// nColorButton14
			// 
			this.nColorButton14.ArrowClickOptions = false;
			this.nColorButton14.Color = System.Drawing.Color.White;
			this.nColorButton14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nColorButton14.Location = new System.Drawing.Point(8, 56);
			this.nColorButton14.Mode = Nevron.UI.WinForm.Controls.OptionButtonMode.Modal;
			this.nColorButton14.Name = "nColorButton14";
			this.nColorButton14.Size = new System.Drawing.Size(80, 24);
			this.nColorButton14.TabIndex = 2;
			this.nColorButton14.Text = "nColorButton4";
			// 
			// nColorButton15
			// 
			this.nColorButton15.ArrowClickOptions = false;
			this.nColorButton15.Color = System.Drawing.Color.White;
			this.nColorButton15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nColorButton15.Location = new System.Drawing.Point(96, 24);
			this.nColorButton15.Mode = Nevron.UI.WinForm.Controls.OptionButtonMode.Modal;
			this.nColorButton15.Name = "nColorButton15";
			this.nColorButton15.Size = new System.Drawing.Size(80, 24);
			this.nColorButton15.TabIndex = 1;
			this.nColorButton15.Text = "nColorButton3";
			// 
			// nColorButton16
			// 
			this.nColorButton16.ArrowClickOptions = false;
			this.nColorButton16.Color = System.Drawing.Color.White;
			this.nColorButton16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nColorButton16.Location = new System.Drawing.Point(8, 24);
			this.nColorButton16.Mode = Nevron.UI.WinForm.Controls.OptionButtonMode.Modal;
			this.nColorButton16.Name = "nColorButton16";
			this.nColorButton16.Size = new System.Drawing.Size(80, 24);
			this.nColorButton16.TabIndex = 0;
			this.nColorButton16.Text = "nColorButton1";
			// 
			// nCheckBox2
			// 
			this.nCheckBox2.Location = new System.Drawing.Point(8, 240);
			this.nCheckBox2.Name = "nCheckBox2";
			this.nCheckBox2.Size = new System.Drawing.Size(128, 24);
			this.nCheckBox2.TabIndex = 19;
			this.nCheckBox2.Text = "Show &Focus Rect";
			this.nCheckBox2.CheckedChanged += new System.EventHandler(this.nCheckBox2_CheckedChanged);
			// 
			// nCheckBox1
			// 
			this.nCheckBox1.Checked = true;
			this.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.nCheckBox1.Location = new System.Drawing.Point(8, 216);
			this.nCheckBox1.Name = "nCheckBox1";
			this.nCheckBox1.TabIndex = 18;
			this.nCheckBox1.Text = "&Enable";
			this.nCheckBox1.CheckedChanged += new System.EventHandler(this.nCheckBox1_CheckedChanged);
			// 
			// nCheckBox3
			// 
			this.nCheckBox3.Checked = true;
			this.nCheckBox3.CheckState = System.Windows.Forms.CheckState.Checked;
			this.nCheckBox3.Location = new System.Drawing.Point(8, 264);
			this.nCheckBox3.Name = "nCheckBox3";
			this.nCheckBox3.TabIndex = 23;
			this.nCheckBox3.Text = "Show &Arrow";
			this.nCheckBox3.CheckedChanged += new System.EventHandler(this.nCheckBox3_CheckedChanged);
			// 
			// NColorButtonUC
			// 
			this.Controls.Add(this.nCheckBox3);
			this.Controls.Add(this.nCheckBox2);
			this.Controls.Add(this.nCheckBox1);
			this.Controls.Add(this.nGroupBox2);
			this.Controls.Add(this.nGroupBox1);
			this.Name = "NColorButtonUC";
			this.Size = new System.Drawing.Size(224, 296);
			this.nGroupBox1.ResumeLayout(false);
			this.nGroupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NColorButton nColorButton3;
		private Nevron.UI.WinForm.Controls.NColorButton nColorButton4;
		private Nevron.UI.WinForm.Controls.NColorButton nColorButton5;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
		private Nevron.UI.WinForm.Controls.NColorButton nColorButton13;
		private Nevron.UI.WinForm.Controls.NColorButton nColorButton14;
		private Nevron.UI.WinForm.Controls.NColorButton nColorButton15;
		private Nevron.UI.WinForm.Controls.NColorButton nColorButton16;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox2;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox1;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox3;

		private Nevron.UI.WinForm.Controls.NColorButton nColorButton1;

		#endregion
	}
}
