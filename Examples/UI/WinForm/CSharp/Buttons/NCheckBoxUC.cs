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
	public class NCheckBoxUC : NExampleUserControl
	{
		#region Constructor

		public NCheckBoxUC(MainForm f) : base(f)
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


		#endregion

		#region Event Handlers

		private void nCheckBox27_CheckedChanged(object sender, System.EventArgs e)
		{
			foreach(Control c in Controls)
			{
				foreach(Control c1 in c.Controls)
				{
					if(!(c1 is NCheckBox))
						continue;
					c1.Enabled = nCheckBox27.Checked;
				}
			}
		}
		private void nCheckBox26_CheckedChanged(object sender, System.EventArgs e)
		{
			foreach(Control c in Controls)
			{
				foreach(Control c1 in c.Controls)
				{
					if(!(c1 is NCheckBox))
						continue;
					((NCheckBox)c1).ButtonProperties.ShowFocusRect = nCheckBox26.Checked;
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
			this.nCheckBox1 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nCheckBox13 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox12 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox11 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox10 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox9 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox8 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox7 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox6 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox5 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox2 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox4 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox3 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox23 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nCheckBox14 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox15 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox16 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox17 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox18 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox19 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox20 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox21 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox22 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox24 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox25 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox26 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox27 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nGroupBox1.SuspendLayout();
			this.nGroupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// nCheckBox1
			// 
			this.nCheckBox1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nCheckBox1.Location = new System.Drawing.Point(16, 24);
			this.nCheckBox1.Name = "nCheckBox1";
			this.nCheckBox1.Size = new System.Drawing.Size(103, 24);
			this.nCheckBox1.TabIndex = 0;
			this.nCheckBox1.Text = "nCheckBox";
			this.nCheckBox1.ThreeState = true;
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.nCheckBox13);
			this.nGroupBox1.Controls.Add(this.nCheckBox12);
			this.nGroupBox1.Controls.Add(this.nCheckBox11);
			this.nGroupBox1.Controls.Add(this.nCheckBox10);
			this.nGroupBox1.Controls.Add(this.nCheckBox9);
			this.nGroupBox1.Controls.Add(this.nCheckBox8);
			this.nGroupBox1.Controls.Add(this.nCheckBox7);
			this.nGroupBox1.Controls.Add(this.nCheckBox6);
			this.nGroupBox1.Controls.Add(this.nCheckBox5);
			this.nGroupBox1.Controls.Add(this.nCheckBox2);
			this.nGroupBox1.Controls.Add(this.nCheckBox1);
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(8, 8);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(136, 376);
			this.nGroupBox1.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default;
			this.nGroupBox1.TabIndex = 6;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Standard CheckBoxes";
			// 
			// nCheckBox13
			// 
			this.nCheckBox13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nCheckBox13.Location = new System.Drawing.Point(16, 344);
			this.nCheckBox13.Name = "nCheckBox13";
			this.nCheckBox13.Size = new System.Drawing.Size(103, 24);
			this.nCheckBox13.TabIndex = 10;
			this.nCheckBox13.Text = "nCheckBox";
			this.nCheckBox13.ThreeState = true;
			// 
			// nCheckBox12
			// 
			this.nCheckBox12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nCheckBox12.Location = new System.Drawing.Point(16, 312);
			this.nCheckBox12.Name = "nCheckBox12";
			this.nCheckBox12.Size = new System.Drawing.Size(103, 24);
			this.nCheckBox12.TabIndex = 9;
			this.nCheckBox12.Text = "nCheckBox";
			this.nCheckBox12.ThreeState = true;
			// 
			// nCheckBox11
			// 
			this.nCheckBox11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nCheckBox11.Location = new System.Drawing.Point(16, 280);
			this.nCheckBox11.Name = "nCheckBox11";
			this.nCheckBox11.Size = new System.Drawing.Size(103, 24);
			this.nCheckBox11.TabIndex = 8;
			this.nCheckBox11.Text = "nCheckBox";
			this.nCheckBox11.ThreeState = true;
			// 
			// nCheckBox10
			// 
			this.nCheckBox10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nCheckBox10.Location = new System.Drawing.Point(16, 248);
			this.nCheckBox10.Name = "nCheckBox10";
			this.nCheckBox10.Size = new System.Drawing.Size(103, 24);
			this.nCheckBox10.TabIndex = 7;
			this.nCheckBox10.Text = "nCheckBox";
			this.nCheckBox10.ThreeState = true;
			// 
			// nCheckBox9
			// 
			this.nCheckBox9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nCheckBox9.Location = new System.Drawing.Point(16, 216);
			this.nCheckBox9.Name = "nCheckBox9";
			this.nCheckBox9.Size = new System.Drawing.Size(103, 24);
			this.nCheckBox9.TabIndex = 6;
			this.nCheckBox9.Text = "nCheckBox";
			this.nCheckBox9.ThreeState = true;
			// 
			// nCheckBox8
			// 
			this.nCheckBox8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nCheckBox8.Location = new System.Drawing.Point(16, 184);
			this.nCheckBox8.Name = "nCheckBox8";
			this.nCheckBox8.Size = new System.Drawing.Size(103, 24);
			this.nCheckBox8.TabIndex = 5;
			this.nCheckBox8.Text = "nCheckBox";
			this.nCheckBox8.ThreeState = true;
			// 
			// nCheckBox7
			// 
			this.nCheckBox7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nCheckBox7.Location = new System.Drawing.Point(16, 152);
			this.nCheckBox7.Name = "nCheckBox7";
			this.nCheckBox7.Size = new System.Drawing.Size(103, 24);
			this.nCheckBox7.TabIndex = 4;
			this.nCheckBox7.Text = "nCheckBox";
			this.nCheckBox7.ThreeState = true;
			// 
			// nCheckBox6
			// 
			this.nCheckBox6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nCheckBox6.Location = new System.Drawing.Point(16, 120);
			this.nCheckBox6.Name = "nCheckBox6";
			this.nCheckBox6.Size = new System.Drawing.Size(103, 24);
			this.nCheckBox6.TabIndex = 3;
			this.nCheckBox6.Text = "nCheckBox";
			this.nCheckBox6.ThreeState = true;
			// 
			// nCheckBox5
			// 
			this.nCheckBox5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nCheckBox5.Location = new System.Drawing.Point(16, 88);
			this.nCheckBox5.Name = "nCheckBox5";
			this.nCheckBox5.Size = new System.Drawing.Size(103, 24);
			this.nCheckBox5.TabIndex = 2;
			this.nCheckBox5.Text = "nCheckBox";
			this.nCheckBox5.ThreeState = true;
			// 
			// nCheckBox2
			// 
			this.nCheckBox2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nCheckBox2.Location = new System.Drawing.Point(16, 56);
			this.nCheckBox2.Name = "nCheckBox2";
			this.nCheckBox2.Size = new System.Drawing.Size(103, 24);
			this.nCheckBox2.TabIndex = 1;
			this.nCheckBox2.Text = "nCheckBox";
			this.nCheckBox2.ThreeState = true;
			// 
			// nCheckBox4
			// 
			this.nCheckBox4.Location = new System.Drawing.Point(0, 0);
			this.nCheckBox4.Name = "nCheckBox4";
			this.nCheckBox4.TabIndex = 0;
			// 
			// nCheckBox3
			// 
			this.nCheckBox3.Location = new System.Drawing.Point(0, 0);
			this.nCheckBox3.Name = "nCheckBox3";
			this.nCheckBox3.TabIndex = 0;
			// 
			// nCheckBox23
			// 
			this.nCheckBox23.Location = new System.Drawing.Point(0, 0);
			this.nCheckBox23.Name = "nCheckBox23";
			this.nCheckBox23.TabIndex = 0;
			// 
			// nGroupBox2
			// 
			this.nGroupBox2.Controls.Add(this.nCheckBox14);
			this.nGroupBox2.Controls.Add(this.nCheckBox15);
			this.nGroupBox2.Controls.Add(this.nCheckBox16);
			this.nGroupBox2.Controls.Add(this.nCheckBox17);
			this.nGroupBox2.Controls.Add(this.nCheckBox18);
			this.nGroupBox2.Controls.Add(this.nCheckBox19);
			this.nGroupBox2.Controls.Add(this.nCheckBox20);
			this.nGroupBox2.Controls.Add(this.nCheckBox21);
			this.nGroupBox2.Controls.Add(this.nCheckBox22);
			this.nGroupBox2.Controls.Add(this.nCheckBox24);
			this.nGroupBox2.Controls.Add(this.nCheckBox25);
			this.nGroupBox2.ImageIndex = 0;
			this.nGroupBox2.Location = new System.Drawing.Point(160, 8);
			this.nGroupBox2.Name = "nGroupBox2";
			this.nGroupBox2.Size = new System.Drawing.Size(184, 376);
			this.nGroupBox2.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default;
			this.nGroupBox2.TabIndex = 11;
			this.nGroupBox2.TabStop = false;
			this.nGroupBox2.Text = "Button CheckBoxes";
			// 
			// nCheckBox14
			// 
			this.nCheckBox14.Appearance = System.Windows.Forms.Appearance.Button;
			this.nCheckBox14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nCheckBox14.Location = new System.Drawing.Point(16, 344);
			this.nCheckBox14.Name = "nCheckBox14";
			this.nCheckBox14.Size = new System.Drawing.Size(144, 24);
			this.nCheckBox14.TabIndex = 10;
			this.nCheckBox14.Text = "nCheckBox";
			this.nCheckBox14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.nCheckBox14.ThreeState = true;
			// 
			// nCheckBox15
			// 
			this.nCheckBox15.Appearance = System.Windows.Forms.Appearance.Button;
			this.nCheckBox15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nCheckBox15.Location = new System.Drawing.Point(16, 312);
			this.nCheckBox15.Name = "nCheckBox15";
			this.nCheckBox15.Size = new System.Drawing.Size(144, 24);
			this.nCheckBox15.TabIndex = 9;
			this.nCheckBox15.Text = "nCheckBox";
			this.nCheckBox15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.nCheckBox15.ThreeState = true;
			// 
			// nCheckBox16
			// 
			this.nCheckBox16.Appearance = System.Windows.Forms.Appearance.Button;
			this.nCheckBox16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nCheckBox16.Location = new System.Drawing.Point(16, 280);
			this.nCheckBox16.Name = "nCheckBox16";
			this.nCheckBox16.Size = new System.Drawing.Size(144, 24);
			this.nCheckBox16.TabIndex = 8;
			this.nCheckBox16.Text = "nCheckBox";
			this.nCheckBox16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.nCheckBox16.ThreeState = true;
			// 
			// nCheckBox17
			// 
			this.nCheckBox17.Appearance = System.Windows.Forms.Appearance.Button;
			this.nCheckBox17.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nCheckBox17.Location = new System.Drawing.Point(16, 248);
			this.nCheckBox17.Name = "nCheckBox17";
			this.nCheckBox17.Size = new System.Drawing.Size(144, 24);
			this.nCheckBox17.TabIndex = 7;
			this.nCheckBox17.Text = "nCheckBox";
			this.nCheckBox17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.nCheckBox17.ThreeState = true;
			// 
			// nCheckBox18
			// 
			this.nCheckBox18.Appearance = System.Windows.Forms.Appearance.Button;
			this.nCheckBox18.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nCheckBox18.Location = new System.Drawing.Point(16, 216);
			this.nCheckBox18.Name = "nCheckBox18";
			this.nCheckBox18.Size = new System.Drawing.Size(144, 24);
			this.nCheckBox18.TabIndex = 6;
			this.nCheckBox18.Text = "nCheckBox";
			this.nCheckBox18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.nCheckBox18.ThreeState = true;
			// 
			// nCheckBox19
			// 
			this.nCheckBox19.Appearance = System.Windows.Forms.Appearance.Button;
			this.nCheckBox19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nCheckBox19.Location = new System.Drawing.Point(16, 184);
			this.nCheckBox19.Name = "nCheckBox19";
			this.nCheckBox19.Size = new System.Drawing.Size(144, 24);
			this.nCheckBox19.TabIndex = 5;
			this.nCheckBox19.Text = "nCheckBox";
			this.nCheckBox19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.nCheckBox19.ThreeState = true;
			// 
			// nCheckBox20
			// 
			this.nCheckBox20.Appearance = System.Windows.Forms.Appearance.Button;
			this.nCheckBox20.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nCheckBox20.Location = new System.Drawing.Point(16, 152);
			this.nCheckBox20.Name = "nCheckBox20";
			this.nCheckBox20.Size = new System.Drawing.Size(144, 24);
			this.nCheckBox20.TabIndex = 4;
			this.nCheckBox20.Text = "nCheckBox";
			this.nCheckBox20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.nCheckBox20.ThreeState = true;
			// 
			// nCheckBox21
			// 
			this.nCheckBox21.Appearance = System.Windows.Forms.Appearance.Button;
			this.nCheckBox21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nCheckBox21.Location = new System.Drawing.Point(16, 120);
			this.nCheckBox21.Name = "nCheckBox21";
			this.nCheckBox21.Size = new System.Drawing.Size(144, 24);
			this.nCheckBox21.TabIndex = 3;
			this.nCheckBox21.Text = "nCheckBox";
			this.nCheckBox21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.nCheckBox21.ThreeState = true;
			// 
			// nCheckBox22
			// 
			this.nCheckBox22.Appearance = System.Windows.Forms.Appearance.Button;
			this.nCheckBox22.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nCheckBox22.Location = new System.Drawing.Point(16, 88);
			this.nCheckBox22.Name = "nCheckBox22";
			this.nCheckBox22.Size = new System.Drawing.Size(144, 24);
			this.nCheckBox22.TabIndex = 2;
			this.nCheckBox22.Text = "nCheckBox";
			this.nCheckBox22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.nCheckBox22.ThreeState = true;
			// 
			// nCheckBox24
			// 
			this.nCheckBox24.Appearance = System.Windows.Forms.Appearance.Button;
			this.nCheckBox24.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nCheckBox24.Location = new System.Drawing.Point(16, 56);
			this.nCheckBox24.Name = "nCheckBox24";
			this.nCheckBox24.Size = new System.Drawing.Size(144, 24);
			this.nCheckBox24.TabIndex = 1;
			this.nCheckBox24.Text = "nCheckBox";
			this.nCheckBox24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.nCheckBox24.ThreeState = true;
			// 
			// nCheckBox25
			// 
			this.nCheckBox25.Appearance = System.Windows.Forms.Appearance.Button;
			this.nCheckBox25.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nCheckBox25.Location = new System.Drawing.Point(16, 24);
			this.nCheckBox25.Name = "nCheckBox25";
			this.nCheckBox25.Size = new System.Drawing.Size(144, 24);
			this.nCheckBox25.TabIndex = 0;
			this.nCheckBox25.Text = "nCheckBox";
			this.nCheckBox25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.nCheckBox25.ThreeState = true;
			// 
			// nCheckBox26
			// 
			this.nCheckBox26.Location = new System.Drawing.Point(120, 392);
			this.nCheckBox26.Name = "nCheckBox26";
			this.nCheckBox26.Size = new System.Drawing.Size(128, 24);
			this.nCheckBox26.TabIndex = 23;
			this.nCheckBox26.Text = "Show &Focus Rect";
			this.nCheckBox26.CheckedChanged += new System.EventHandler(this.nCheckBox26_CheckedChanged);
			// 
			// nCheckBox27
			// 
			this.nCheckBox27.Checked = true;
			this.nCheckBox27.CheckState = System.Windows.Forms.CheckState.Checked;
			this.nCheckBox27.Location = new System.Drawing.Point(8, 392);
			this.nCheckBox27.Name = "nCheckBox27";
			this.nCheckBox27.TabIndex = 22;
			this.nCheckBox27.Text = "&Enable";
			this.nCheckBox27.CheckedChanged += new System.EventHandler(this.nCheckBox27_CheckedChanged);
			// 
			// NCheckBoxUC
			// 
			this.Controls.Add(this.nCheckBox26);
			this.Controls.Add(this.nCheckBox27);
			this.Controls.Add(this.nGroupBox1);
			this.Controls.Add(this.nGroupBox2);
			this.Name = "NCheckBoxUC";
			this.Size = new System.Drawing.Size(352, 424);
			this.nGroupBox1.ResumeLayout(false);
			this.nGroupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox1;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox23;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox3;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox4;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox2;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox5;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox6;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox7;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox8;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox9;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox10;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox11;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox12;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox13;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox14;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox15;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox16;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox17;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox18;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox19;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox20;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox21;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox22;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox24;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox25;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox26;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox27;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;

		#endregion
	}
}
