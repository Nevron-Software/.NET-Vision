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
	public class NRadioButtonUC : NExampleUserControl
	{
		#region Constructor

		public NRadioButtonUC(MainForm f) : base(f)
		{
			InitializeComponent();
		}


		#endregion

		#region Implementation

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
			}
			base.Dispose( disposing );
		}
		public override void Initialize()
		{
			base.Initialize();
		}


		#endregion

		#region Event Handlers

		private void nCheckBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			foreach(NRadioButton b in this.nGroupBox1.Controls)
				b.Enabled = this.nCheckBox1.Checked;
			foreach(NRadioButton b in this.nGroupBox2.Controls)
				b.Enabled = this.nCheckBox1.Checked;
		}

		private void nCheckBox2_CheckedChanged(object sender, System.EventArgs e)
		{
			foreach(NRadioButton b in this.nGroupBox1.Controls)
				b.ButtonProperties.ShowFocusRect = this.nCheckBox2.Checked;
			foreach(NRadioButton b in this.nGroupBox2.Controls)
				b.ButtonProperties.ShowFocusRect = this.nCheckBox2.Checked;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.nRadioButton1 = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.nRadioButton2 = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.nRadioButton3 = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.nRadioButton4 = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.nRadioButton5 = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.nRadioButton6 = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.nRadioButton7 = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.nRadioButton8 = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.nRadioButton9 = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.nRadioButton10 = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.nRadioButton11 = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.nRadioButton12 = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.nRadioButton13 = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nRadioButton15 = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.nRadioButton14 = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.nCheckBox1 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox2 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nGroupBox1.SuspendLayout();
			this.nGroupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// nRadioButton1
			// 
			this.nRadioButton1.Location = new System.Drawing.Point(16, 24);
			this.nRadioButton1.Name = "nRadioButton1";
			this.nRadioButton1.TabIndex = 0;
			this.nRadioButton1.Text = "nRadioButton1";
			// 
			// nRadioButton2
			// 
			this.nRadioButton2.Location = new System.Drawing.Point(16, 56);
			this.nRadioButton2.Name = "nRadioButton2";
			this.nRadioButton2.TabIndex = 1;
			this.nRadioButton2.Text = "nRadioButton2";
			// 
			// nRadioButton3
			// 
			this.nRadioButton3.Location = new System.Drawing.Point(16, 88);
			this.nRadioButton3.Name = "nRadioButton3";
			this.nRadioButton3.TabIndex = 2;
			this.nRadioButton3.Text = "nRadioButton3";
			// 
			// nRadioButton4
			// 
			this.nRadioButton4.Location = new System.Drawing.Point(16, 120);
			this.nRadioButton4.Name = "nRadioButton4";
			this.nRadioButton4.TabIndex = 3;
			this.nRadioButton4.Text = "nRadioButton4";
			// 
			// nRadioButton5
			// 
			this.nRadioButton5.Location = new System.Drawing.Point(16, 152);
			this.nRadioButton5.Name = "nRadioButton5";
			this.nRadioButton5.TabIndex = 7;
			this.nRadioButton5.Text = "nRadioButton5";
			// 
			// nRadioButton6
			// 
			this.nRadioButton6.Location = new System.Drawing.Point(16, 184);
			this.nRadioButton6.Name = "nRadioButton6";
			this.nRadioButton6.TabIndex = 6;
			this.nRadioButton6.Text = "nRadioButton6";
			// 
			// nRadioButton7
			// 
			this.nRadioButton7.Location = new System.Drawing.Point(16, 216);
			this.nRadioButton7.Name = "nRadioButton7";
			this.nRadioButton7.TabIndex = 5;
			this.nRadioButton7.Text = "nRadioButton7";
			// 
			// nRadioButton8
			// 
			this.nRadioButton8.Location = new System.Drawing.Point(16, 248);
			this.nRadioButton8.Name = "nRadioButton8";
			this.nRadioButton8.TabIndex = 4;
			this.nRadioButton8.Text = "nRadioButton8";
			// 
			// nRadioButton9
			// 
			this.nRadioButton9.Appearance = System.Windows.Forms.Appearance.Button;
			this.nRadioButton9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nRadioButton9.ImageIndex = 0;
			this.nRadioButton9.Location = new System.Drawing.Point(16, 24);
			this.nRadioButton9.Name = "nRadioButton9";
			this.nRadioButton9.Size = new System.Drawing.Size(112, 24);
			this.nRadioButton9.TabIndex = 8;
			this.nRadioButton9.Text = "nRadioButton9";
			this.nRadioButton9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nRadioButton10
			// 
			this.nRadioButton10.Appearance = System.Windows.Forms.Appearance.Button;
			this.nRadioButton10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nRadioButton10.ImageIndex = 1;
			this.nRadioButton10.Location = new System.Drawing.Point(16, 56);
			this.nRadioButton10.Name = "nRadioButton10";
			this.nRadioButton10.Size = new System.Drawing.Size(112, 24);
			this.nRadioButton10.TabIndex = 9;
			this.nRadioButton10.Text = "nRadioButton10";
			this.nRadioButton10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nRadioButton11
			// 
			this.nRadioButton11.Appearance = System.Windows.Forms.Appearance.Button;
			this.nRadioButton11.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.nRadioButton11.ImageIndex = 3;
			this.nRadioButton11.Location = new System.Drawing.Point(16, 88);
			this.nRadioButton11.Name = "nRadioButton11";
			this.nRadioButton11.Size = new System.Drawing.Size(112, 48);
			this.nRadioButton11.TabIndex = 10;
			this.nRadioButton11.Text = "nRadioButton11";
			this.nRadioButton11.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// nRadioButton12
			// 
			this.nRadioButton12.Appearance = System.Windows.Forms.Appearance.Button;
			this.nRadioButton12.Location = new System.Drawing.Point(16, 144);
			this.nRadioButton12.Name = "nRadioButton12";
			this.nRadioButton12.Size = new System.Drawing.Size(112, 24);
			this.nRadioButton12.TabIndex = 11;
			this.nRadioButton12.Text = "nRadioButton12";
			this.nRadioButton12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nRadioButton13
			// 
			this.nRadioButton13.Appearance = System.Windows.Forms.Appearance.Button;
			this.nRadioButton13.Location = new System.Drawing.Point(16, 176);
			this.nRadioButton13.Name = "nRadioButton13";
			this.nRadioButton13.Size = new System.Drawing.Size(112, 24);
			this.nRadioButton13.TabIndex = 12;
			this.nRadioButton13.Text = "nRadioButton13";
			this.nRadioButton13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.nRadioButton3);
			this.nGroupBox1.Controls.Add(this.nRadioButton4);
			this.nGroupBox1.Controls.Add(this.nRadioButton1);
			this.nGroupBox1.Controls.Add(this.nRadioButton5);
			this.nGroupBox1.Controls.Add(this.nRadioButton6);
			this.nGroupBox1.Controls.Add(this.nRadioButton7);
			this.nGroupBox1.Controls.Add(this.nRadioButton8);
			this.nGroupBox1.Controls.Add(this.nRadioButton2);
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(8, 8);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(144, 280);
			this.nGroupBox1.TabIndex = 16;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Standard Appearance";
			// 
			// nGroupBox2
			// 
			this.nGroupBox2.Controls.Add(this.nRadioButton15);
			this.nGroupBox2.Controls.Add(this.nRadioButton14);
			this.nGroupBox2.Controls.Add(this.nRadioButton13);
			this.nGroupBox2.Controls.Add(this.nRadioButton9);
			this.nGroupBox2.Controls.Add(this.nRadioButton10);
			this.nGroupBox2.Controls.Add(this.nRadioButton11);
			this.nGroupBox2.Controls.Add(this.nRadioButton12);
			this.nGroupBox2.ImageIndex = 0;
			this.nGroupBox2.Location = new System.Drawing.Point(160, 8);
			this.nGroupBox2.Name = "nGroupBox2";
			this.nGroupBox2.Size = new System.Drawing.Size(144, 280);
			this.nGroupBox2.TabIndex = 17;
			this.nGroupBox2.TabStop = false;
			this.nGroupBox2.Text = "Button Appearance";
			// 
			// nRadioButton15
			// 
			this.nRadioButton15.Appearance = System.Windows.Forms.Appearance.Button;
			this.nRadioButton15.Location = new System.Drawing.Point(16, 240);
			this.nRadioButton15.Name = "nRadioButton15";
			this.nRadioButton15.Size = new System.Drawing.Size(112, 24);
			this.nRadioButton15.TabIndex = 14;
			this.nRadioButton15.Text = "nRadioButton15";
			this.nRadioButton15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nRadioButton14
			// 
			this.nRadioButton14.Appearance = System.Windows.Forms.Appearance.Button;
			this.nRadioButton14.Location = new System.Drawing.Point(16, 208);
			this.nRadioButton14.Name = "nRadioButton14";
			this.nRadioButton14.Size = new System.Drawing.Size(112, 24);
			this.nRadioButton14.TabIndex = 13;
			this.nRadioButton14.Text = "nRadioButton14";
			this.nRadioButton14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nCheckBox1
			// 
			this.nCheckBox1.Checked = true;
			this.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.nCheckBox1.Location = new System.Drawing.Point(8, 296);
			this.nCheckBox1.Name = "nCheckBox1";
			this.nCheckBox1.TabIndex = 18;
			this.nCheckBox1.Text = "&Enable";
			this.nCheckBox1.CheckedChanged += new System.EventHandler(this.nCheckBox1_CheckedChanged);
			// 
			// nCheckBox2
			// 
			this.nCheckBox2.Location = new System.Drawing.Point(120, 296);
			this.nCheckBox2.Name = "nCheckBox2";
			this.nCheckBox2.Size = new System.Drawing.Size(120, 24);
			this.nCheckBox2.TabIndex = 19;
			this.nCheckBox2.Text = "Show &Focus Rect";
			this.nCheckBox2.CheckedChanged += new System.EventHandler(this.nCheckBox2_CheckedChanged);
			// 
			// NRadioButtonUC
			// 
			this.Controls.Add(this.nCheckBox2);
			this.Controls.Add(this.nCheckBox1);
			this.Controls.Add(this.nGroupBox2);
			this.Controls.Add(this.nGroupBox1);
			this.Name = "NRadioButtonUC";
			this.Size = new System.Drawing.Size(320, 328);
			this.nGroupBox1.ResumeLayout(false);
			this.nGroupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private Nevron.UI.WinForm.Controls.NRadioButton nRadioButton1;
		private Nevron.UI.WinForm.Controls.NRadioButton nRadioButton2;
		private Nevron.UI.WinForm.Controls.NRadioButton nRadioButton3;
		private Nevron.UI.WinForm.Controls.NRadioButton nRadioButton4;
		private Nevron.UI.WinForm.Controls.NRadioButton nRadioButton5;
		private Nevron.UI.WinForm.Controls.NRadioButton nRadioButton6;
		private Nevron.UI.WinForm.Controls.NRadioButton nRadioButton7;
		private Nevron.UI.WinForm.Controls.NRadioButton nRadioButton8;
		private Nevron.UI.WinForm.Controls.NRadioButton nRadioButton9;
		private Nevron.UI.WinForm.Controls.NRadioButton nRadioButton10;
		private Nevron.UI.WinForm.Controls.NRadioButton nRadioButton11;
		private Nevron.UI.WinForm.Controls.NRadioButton nRadioButton12;
		private Nevron.UI.WinForm.Controls.NRadioButton nRadioButton13;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox1;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox2;
		private Nevron.UI.WinForm.Controls.NRadioButton nRadioButton14;
		private Nevron.UI.WinForm.Controls.NRadioButton nRadioButton15;

		#endregion
	}
}
