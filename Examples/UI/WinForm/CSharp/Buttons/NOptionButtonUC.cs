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
	public class NOptionButtonUC : NExampleUserControl
	{
		#region Constructor

		public NOptionButtonUC(MainForm f) : base(f)
		{
			InitializeComponent();
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


		#endregion

		#region Event Handlers

		private void OnOptionButton2ShowDialog(object sender, EventArgs e)
		{
			Form f = new Form();
			f.Text = "Modal NOptionButton Dialog";
			f.ShowDialog();
		}

		private void nCheckBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			foreach(Control c in Controls)
			{
				if(!(c is NButton))
					continue;
				c.Enabled = nCheckBox1.Checked;
			}
		}
		private void nCheckBox2_CheckedChanged(object sender, System.EventArgs e)
		{
			foreach(Control c in Controls)
			{
				if(!(c is NButton))
					continue;
				((NButton)c).ButtonProperties.ShowFocusRect = nCheckBox2.Checked;
			}
		}
		private void nCheckBox3_CheckedChanged(object sender, System.EventArgs e)
		{
			foreach(Control c in Controls)
			{
				if(!(c is NOptionButton))
					continue;
				((NOptionButton)c).ShowArrow = nCheckBox3.Checked;
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
			this.nOptionButton2 = new Nevron.UI.WinForm.Controls.NOptionButton();
			this.nOptionButton4 = new Nevron.UI.WinForm.Controls.NOptionButton();
			this.nOptionButton5 = new Nevron.UI.WinForm.Controls.NOptionButton();
			this.nOptionButton6 = new Nevron.UI.WinForm.Controls.NOptionButton();
			this.nOptionButton7 = new Nevron.UI.WinForm.Controls.NOptionButton();
			this.nOptionButton8 = new Nevron.UI.WinForm.Controls.NOptionButton();
			this.nOptionButton9 = new Nevron.UI.WinForm.Controls.NOptionButton();
			this.nOptionButton10 = new Nevron.UI.WinForm.Controls.NOptionButton();
			this.nOptionButton11 = new Nevron.UI.WinForm.Controls.NOptionButton();
			this.nOptionButton1 = new Nevron.UI.WinForm.Controls.NOptionButton();
			this.nCommand1 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand2 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nOptionButton3 = new Nevron.UI.WinForm.Controls.NOptionButton();
			this.nCommand3 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand4 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nOptionButton12 = new Nevron.UI.WinForm.Controls.NOptionButton();
			this.nCommand5 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand6 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nOptionButton13 = new Nevron.UI.WinForm.Controls.NOptionButton();
			this.nCommand7 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand8 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand9 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand10 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nOptionButton14 = new Nevron.UI.WinForm.Controls.NOptionButton();
			this.nCommand11 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand12 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand13 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand14 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand15 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand16 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nOptionButton15 = new Nevron.UI.WinForm.Controls.NOptionButton();
			this.nCommand17 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand18 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand19 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand20 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand21 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand22 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand23 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nOptionButton16 = new Nevron.UI.WinForm.Controls.NOptionButton();
			this.nCommand24 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand25 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand26 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand27 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nOptionButton17 = new Nevron.UI.WinForm.Controls.NOptionButton();
			this.nCommand28 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand29 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand30 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand31 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand32 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nOptionButton18 = new Nevron.UI.WinForm.Controls.NOptionButton();
			this.nCommand33 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand34 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand35 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand36 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand37 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand38 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCheckBox2 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox1 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox3 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// nOptionButton2
			// 
			this.nOptionButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nOptionButton2.Location = new System.Drawing.Point(192, 8);
			this.nOptionButton2.Mode = Nevron.UI.WinForm.Controls.OptionButtonMode.Modal;
			this.nOptionButton2.Name = "nOptionButton2";
			this.nOptionButton2.Size = new System.Drawing.Size(136, 24);
			this.nOptionButton2.TabIndex = 1;
			this.nOptionButton2.Text = "Modal option button";
			this.nOptionButton2.ArrowClick += new System.EventHandler(this.OnOptionButton2ShowDialog);
			// 
			// nOptionButton4
			// 
			this.nOptionButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nOptionButton4.Location = new System.Drawing.Point(192, 40);
			this.nOptionButton4.Mode = Nevron.UI.WinForm.Controls.OptionButtonMode.Modal;
			this.nOptionButton4.Name = "nOptionButton4";
			this.nOptionButton4.Size = new System.Drawing.Size(136, 24);
			this.nOptionButton4.TabIndex = 3;
			this.nOptionButton4.Text = "Modal option button";
			this.nOptionButton4.ArrowClick += new System.EventHandler(this.OnOptionButton2ShowDialog);
			// 
			// nOptionButton5
			// 
			this.nOptionButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nOptionButton5.Location = new System.Drawing.Point(192, 72);
			this.nOptionButton5.Mode = Nevron.UI.WinForm.Controls.OptionButtonMode.Modal;
			this.nOptionButton5.Name = "nOptionButton5";
			this.nOptionButton5.Size = new System.Drawing.Size(136, 24);
			this.nOptionButton5.TabIndex = 4;
			this.nOptionButton5.Text = "Modal option button";
			this.nOptionButton5.ArrowClick += new System.EventHandler(this.OnOptionButton2ShowDialog);
			// 
			// nOptionButton6
			// 
			this.nOptionButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nOptionButton6.Location = new System.Drawing.Point(192, 104);
			this.nOptionButton6.Mode = Nevron.UI.WinForm.Controls.OptionButtonMode.Modal;
			this.nOptionButton6.Name = "nOptionButton6";
			this.nOptionButton6.Size = new System.Drawing.Size(136, 24);
			this.nOptionButton6.TabIndex = 5;
			this.nOptionButton6.Text = "Modal option button";
			this.nOptionButton6.ArrowClick += new System.EventHandler(this.OnOptionButton2ShowDialog);
			// 
			// nOptionButton7
			// 
			this.nOptionButton7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nOptionButton7.Location = new System.Drawing.Point(192, 136);
			this.nOptionButton7.Mode = Nevron.UI.WinForm.Controls.OptionButtonMode.Modal;
			this.nOptionButton7.Name = "nOptionButton7";
			this.nOptionButton7.Size = new System.Drawing.Size(136, 24);
			this.nOptionButton7.TabIndex = 6;
			this.nOptionButton7.Text = "Modal option button";
			this.nOptionButton7.ArrowClick += new System.EventHandler(this.OnOptionButton2ShowDialog);
			// 
			// nOptionButton8
			// 
			this.nOptionButton8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nOptionButton8.Location = new System.Drawing.Point(192, 168);
			this.nOptionButton8.Mode = Nevron.UI.WinForm.Controls.OptionButtonMode.Modal;
			this.nOptionButton8.Name = "nOptionButton8";
			this.nOptionButton8.Size = new System.Drawing.Size(136, 24);
			this.nOptionButton8.TabIndex = 7;
			this.nOptionButton8.Text = "Modal option button";
			this.nOptionButton8.ArrowClick += new System.EventHandler(this.OnOptionButton2ShowDialog);
			// 
			// nOptionButton9
			// 
			this.nOptionButton9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nOptionButton9.Location = new System.Drawing.Point(192, 200);
			this.nOptionButton9.Mode = Nevron.UI.WinForm.Controls.OptionButtonMode.Modal;
			this.nOptionButton9.Name = "nOptionButton9";
			this.nOptionButton9.Size = new System.Drawing.Size(136, 24);
			this.nOptionButton9.TabIndex = 8;
			this.nOptionButton9.Text = "Modal option button";
			this.nOptionButton9.ArrowClick += new System.EventHandler(this.OnOptionButton2ShowDialog);
			// 
			// nOptionButton10
			// 
			this.nOptionButton10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nOptionButton10.Location = new System.Drawing.Point(192, 232);
			this.nOptionButton10.Mode = Nevron.UI.WinForm.Controls.OptionButtonMode.Modal;
			this.nOptionButton10.Name = "nOptionButton10";
			this.nOptionButton10.Size = new System.Drawing.Size(136, 24);
			this.nOptionButton10.TabIndex = 9;
			this.nOptionButton10.Text = "Modal option button";
			this.nOptionButton10.ArrowClick += new System.EventHandler(this.OnOptionButton2ShowDialog);
			// 
			// nOptionButton11
			// 
			this.nOptionButton11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nOptionButton11.Location = new System.Drawing.Point(192, 264);
			this.nOptionButton11.Mode = Nevron.UI.WinForm.Controls.OptionButtonMode.Modal;
			this.nOptionButton11.Name = "nOptionButton11";
			this.nOptionButton11.Size = new System.Drawing.Size(136, 24);
			this.nOptionButton11.TabIndex = 10;
			this.nOptionButton11.Text = "Modal option button";
			this.nOptionButton11.ArrowClick += new System.EventHandler(this.OnOptionButton2ShowDialog);
			// 
			// nOptionButton1
			// 
			this.nOptionButton1.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																					   this.nCommand1,
																					   this.nCommand2});
			this.nOptionButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nOptionButton1.Location = new System.Drawing.Point(8, 8);
			this.nOptionButton1.Name = "nOptionButton1";
			this.nOptionButton1.Size = new System.Drawing.Size(176, 23);
			this.nOptionButton1.TabIndex = 11;
			this.nOptionButton1.Text = "Drop-Down Option Button";
			// 
			// nCommand1
			// 
			this.nCommand1.Properties.Text = "nCommand1";
			// 
			// nCommand2
			// 
			this.nCommand2.Properties.Text = "nCommand2";
			// 
			// nOptionButton3
			// 
			this.nOptionButton3.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																					   this.nCommand3,
																					   this.nCommand4});
			this.nOptionButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nOptionButton3.Location = new System.Drawing.Point(8, 40);
			this.nOptionButton3.Name = "nOptionButton3";
			this.nOptionButton3.Size = new System.Drawing.Size(176, 23);
			this.nOptionButton3.TabIndex = 12;
			this.nOptionButton3.Text = "Drop-Down Option Button";
			// 
			// nCommand3
			// 
			this.nCommand3.Properties.Text = "nCommand3";
			// 
			// nCommand4
			// 
			this.nCommand4.Properties.Text = "nCommand4";
			// 
			// nOptionButton12
			// 
			this.nOptionButton12.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																						this.nCommand5,
																						this.nCommand6});
			this.nOptionButton12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nOptionButton12.Location = new System.Drawing.Point(8, 72);
			this.nOptionButton12.Name = "nOptionButton12";
			this.nOptionButton12.Size = new System.Drawing.Size(176, 23);
			this.nOptionButton12.TabIndex = 13;
			this.nOptionButton12.Text = "Drop-Down Option Button";
			// 
			// nCommand5
			// 
			this.nCommand5.Properties.Text = "nCommand5";
			// 
			// nCommand6
			// 
			this.nCommand6.Properties.Text = "nCommand6";
			// 
			// nOptionButton13
			// 
			this.nOptionButton13.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																						this.nCommand7,
																						this.nCommand8,
																						this.nCommand9,
																						this.nCommand10});
			this.nOptionButton13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nOptionButton13.Location = new System.Drawing.Point(8, 104);
			this.nOptionButton13.Name = "nOptionButton13";
			this.nOptionButton13.Size = new System.Drawing.Size(176, 23);
			this.nOptionButton13.TabIndex = 14;
			this.nOptionButton13.Text = "Drop-Down Option Button";
			// 
			// nCommand7
			// 
			this.nCommand7.Properties.Text = "nCommand7";
			// 
			// nCommand8
			// 
			this.nCommand8.Properties.Text = "nCommand8";
			// 
			// nCommand9
			// 
			this.nCommand9.Properties.Text = "nCommand9";
			// 
			// nCommand10
			// 
			this.nCommand10.Properties.Text = "nCommand10";
			// 
			// nOptionButton14
			// 
			this.nOptionButton14.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																						this.nCommand11,
																						this.nCommand12,
																						this.nCommand13,
																						this.nCommand14,
																						this.nCommand15,
																						this.nCommand16});
			this.nOptionButton14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nOptionButton14.Location = new System.Drawing.Point(8, 136);
			this.nOptionButton14.Name = "nOptionButton14";
			this.nOptionButton14.Size = new System.Drawing.Size(176, 23);
			this.nOptionButton14.TabIndex = 15;
			this.nOptionButton14.Text = "Drop-Down Option Button";
			// 
			// nCommand11
			// 
			this.nCommand11.Properties.Text = "nCommand11";
			// 
			// nCommand12
			// 
			this.nCommand12.Properties.Text = "nCommand12";
			// 
			// nCommand13
			// 
			this.nCommand13.Properties.Text = "nCommand13";
			// 
			// nCommand14
			// 
			this.nCommand14.Properties.Text = "nCommand14";
			// 
			// nCommand15
			// 
			this.nCommand15.Properties.Text = "nCommand15";
			// 
			// nCommand16
			// 
			this.nCommand16.Properties.Text = "nCommand16";
			// 
			// nOptionButton15
			// 
			this.nOptionButton15.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																						this.nCommand17,
																						this.nCommand18,
																						this.nCommand19,
																						this.nCommand20,
																						this.nCommand21,
																						this.nCommand22,
																						this.nCommand23});
			this.nOptionButton15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nOptionButton15.Location = new System.Drawing.Point(8, 168);
			this.nOptionButton15.Name = "nOptionButton15";
			this.nOptionButton15.Size = new System.Drawing.Size(176, 23);
			this.nOptionButton15.TabIndex = 16;
			this.nOptionButton15.Text = "Drop-Down Option Button";
			// 
			// nCommand17
			// 
			this.nCommand17.Properties.Text = "nCommand17";
			// 
			// nCommand18
			// 
			this.nCommand18.Properties.Text = "nCommand18";
			// 
			// nCommand19
			// 
			this.nCommand19.Properties.Text = "nCommand19";
			// 
			// nCommand20
			// 
			this.nCommand20.Properties.Text = "nCommand20";
			// 
			// nCommand21
			// 
			this.nCommand21.Properties.Text = "nCommand21";
			// 
			// nCommand22
			// 
			this.nCommand22.Properties.Text = "nCommand22";
			// 
			// nCommand23
			// 
			this.nCommand23.Properties.Text = "nCommand23";
			// 
			// nOptionButton16
			// 
			this.nOptionButton16.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																						this.nCommand24,
																						this.nCommand25,
																						this.nCommand26,
																						this.nCommand27});
			this.nOptionButton16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nOptionButton16.Location = new System.Drawing.Point(8, 200);
			this.nOptionButton16.Name = "nOptionButton16";
			this.nOptionButton16.Size = new System.Drawing.Size(176, 23);
			this.nOptionButton16.TabIndex = 17;
			this.nOptionButton16.Text = "Drop-Down Option Button";
			// 
			// nCommand24
			// 
			this.nCommand24.Properties.Text = "nCommand24";
			// 
			// nCommand25
			// 
			this.nCommand25.Properties.Text = "nCommand25";
			// 
			// nCommand26
			// 
			this.nCommand26.Properties.Text = "nCommand26";
			// 
			// nCommand27
			// 
			this.nCommand27.Properties.Text = "nCommand27";
			// 
			// nOptionButton17
			// 
			this.nOptionButton17.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																						this.nCommand28,
																						this.nCommand29,
																						this.nCommand30,
																						this.nCommand31,
																						this.nCommand32});
			this.nOptionButton17.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nOptionButton17.Location = new System.Drawing.Point(8, 232);
			this.nOptionButton17.Name = "nOptionButton17";
			this.nOptionButton17.Size = new System.Drawing.Size(176, 23);
			this.nOptionButton17.TabIndex = 18;
			this.nOptionButton17.Text = "Drop-Down Option Button";
			// 
			// nCommand28
			// 
			this.nCommand28.Properties.Text = "nCommand28";
			// 
			// nCommand29
			// 
			this.nCommand29.Properties.Text = "nCommand29";
			// 
			// nCommand30
			// 
			this.nCommand30.Properties.Text = "nCommand30";
			// 
			// nCommand31
			// 
			this.nCommand31.Properties.Text = "nCommand31";
			// 
			// nCommand32
			// 
			this.nCommand32.Properties.Text = "nCommand32";
			// 
			// nOptionButton18
			// 
			this.nOptionButton18.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																						this.nCommand33,
																						this.nCommand34,
																						this.nCommand35,
																						this.nCommand36,
																						this.nCommand37,
																						this.nCommand38});
			this.nOptionButton18.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nOptionButton18.Location = new System.Drawing.Point(8, 264);
			this.nOptionButton18.Name = "nOptionButton18";
			this.nOptionButton18.Size = new System.Drawing.Size(176, 23);
			this.nOptionButton18.TabIndex = 19;
			this.nOptionButton18.Text = "Drop-Down Option Button";
			// 
			// nCommand33
			// 
			this.nCommand33.Properties.Text = "nCommand33";
			// 
			// nCommand34
			// 
			this.nCommand34.Properties.Text = "nCommand34";
			// 
			// nCommand35
			// 
			this.nCommand35.Properties.Text = "nCommand35";
			// 
			// nCommand36
			// 
			this.nCommand36.Properties.Text = "nCommand36";
			// 
			// nCommand37
			// 
			this.nCommand37.Properties.Text = "nCommand37";
			// 
			// nCommand38
			// 
			this.nCommand38.Properties.Text = "nCommand38";
			// 
			// nCheckBox2
			// 
			this.nCheckBox2.Checked = true;
			this.nCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.nCheckBox2.Location = new System.Drawing.Point(112, 296);
			this.nCheckBox2.Name = "nCheckBox2";
			this.nCheckBox2.Size = new System.Drawing.Size(128, 24);
			this.nCheckBox2.TabIndex = 21;
			this.nCheckBox2.Text = "Show &Focus Rect";
			this.nCheckBox2.CheckedChanged += new System.EventHandler(this.nCheckBox2_CheckedChanged);
			// 
			// nCheckBox1
			// 
			this.nCheckBox1.Checked = true;
			this.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.nCheckBox1.Location = new System.Drawing.Point(8, 296);
			this.nCheckBox1.Name = "nCheckBox1";
			this.nCheckBox1.TabIndex = 20;
			this.nCheckBox1.Text = "&Enable";
			this.nCheckBox1.CheckedChanged += new System.EventHandler(this.nCheckBox1_CheckedChanged);
			// 
			// nCheckBox3
			// 
			this.nCheckBox3.Checked = true;
			this.nCheckBox3.CheckState = System.Windows.Forms.CheckState.Checked;
			this.nCheckBox3.Location = new System.Drawing.Point(240, 296);
			this.nCheckBox3.Name = "nCheckBox3";
			this.nCheckBox3.TabIndex = 22;
			this.nCheckBox3.Text = "Show &Arrow";
			this.nCheckBox3.CheckedChanged += new System.EventHandler(this.nCheckBox3_CheckedChanged);
			// 
			// NOptionButtonUC
			// 
			this.Controls.Add(this.nCheckBox3);
			this.Controls.Add(this.nCheckBox2);
			this.Controls.Add(this.nCheckBox1);
			this.Controls.Add(this.nOptionButton18);
			this.Controls.Add(this.nOptionButton17);
			this.Controls.Add(this.nOptionButton16);
			this.Controls.Add(this.nOptionButton15);
			this.Controls.Add(this.nOptionButton14);
			this.Controls.Add(this.nOptionButton13);
			this.Controls.Add(this.nOptionButton12);
			this.Controls.Add(this.nOptionButton3);
			this.Controls.Add(this.nOptionButton1);
			this.Controls.Add(this.nOptionButton11);
			this.Controls.Add(this.nOptionButton10);
			this.Controls.Add(this.nOptionButton9);
			this.Controls.Add(this.nOptionButton8);
			this.Controls.Add(this.nOptionButton7);
			this.Controls.Add(this.nOptionButton6);
			this.Controls.Add(this.nOptionButton5);
			this.Controls.Add(this.nOptionButton4);
			this.Controls.Add(this.nOptionButton2);
			this.Name = "NOptionButtonUC";
			this.Size = new System.Drawing.Size(504, 328);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NOptionButton nOptionButton4;
		private Nevron.UI.WinForm.Controls.NOptionButton nOptionButton5;
		private Nevron.UI.WinForm.Controls.NOptionButton nOptionButton6;
		private Nevron.UI.WinForm.Controls.NOptionButton nOptionButton7;
		private Nevron.UI.WinForm.Controls.NOptionButton nOptionButton8;
		private Nevron.UI.WinForm.Controls.NOptionButton nOptionButton9;
		private Nevron.UI.WinForm.Controls.NOptionButton nOptionButton10;
		private Nevron.UI.WinForm.Controls.NOptionButton nOptionButton11;
		private Nevron.UI.WinForm.Controls.NOptionButton nOptionButton1;
		private Nevron.UI.WinForm.Controls.NOptionButton nOptionButton3;
		private Nevron.UI.WinForm.Controls.NOptionButton nOptionButton12;
		private Nevron.UI.WinForm.Controls.NOptionButton nOptionButton13;
		private Nevron.UI.WinForm.Controls.NOptionButton nOptionButton14;
		private Nevron.UI.WinForm.Controls.NOptionButton nOptionButton15;
		private Nevron.UI.WinForm.Controls.NOptionButton nOptionButton16;
		private Nevron.UI.WinForm.Controls.NOptionButton nOptionButton17;
		private Nevron.UI.WinForm.Controls.NOptionButton nOptionButton18;
		private Nevron.UI.WinForm.Controls.NCommand nCommand1;
		private Nevron.UI.WinForm.Controls.NCommand nCommand2;
		private Nevron.UI.WinForm.Controls.NCommand nCommand3;
		private Nevron.UI.WinForm.Controls.NCommand nCommand4;
		private Nevron.UI.WinForm.Controls.NCommand nCommand5;
		private Nevron.UI.WinForm.Controls.NCommand nCommand6;
		private Nevron.UI.WinForm.Controls.NCommand nCommand7;
		private Nevron.UI.WinForm.Controls.NCommand nCommand8;
		private Nevron.UI.WinForm.Controls.NCommand nCommand9;
		private Nevron.UI.WinForm.Controls.NCommand nCommand10;
		private Nevron.UI.WinForm.Controls.NCommand nCommand11;
		private Nevron.UI.WinForm.Controls.NCommand nCommand12;
		private Nevron.UI.WinForm.Controls.NCommand nCommand13;
		private Nevron.UI.WinForm.Controls.NCommand nCommand14;
		private Nevron.UI.WinForm.Controls.NCommand nCommand15;
		private Nevron.UI.WinForm.Controls.NCommand nCommand16;
		private Nevron.UI.WinForm.Controls.NCommand nCommand17;
		private Nevron.UI.WinForm.Controls.NCommand nCommand18;
		private Nevron.UI.WinForm.Controls.NCommand nCommand19;
		private Nevron.UI.WinForm.Controls.NCommand nCommand20;
		private Nevron.UI.WinForm.Controls.NCommand nCommand21;
		private Nevron.UI.WinForm.Controls.NCommand nCommand22;
		private Nevron.UI.WinForm.Controls.NCommand nCommand23;
		private Nevron.UI.WinForm.Controls.NCommand nCommand24;
		private Nevron.UI.WinForm.Controls.NCommand nCommand25;
		private Nevron.UI.WinForm.Controls.NCommand nCommand26;
		private Nevron.UI.WinForm.Controls.NCommand nCommand27;
		private Nevron.UI.WinForm.Controls.NCommand nCommand28;
		private Nevron.UI.WinForm.Controls.NCommand nCommand29;
		private Nevron.UI.WinForm.Controls.NCommand nCommand30;
		private Nevron.UI.WinForm.Controls.NCommand nCommand31;
		private Nevron.UI.WinForm.Controls.NCommand nCommand32;
		private Nevron.UI.WinForm.Controls.NCommand nCommand33;
		private Nevron.UI.WinForm.Controls.NCommand nCommand34;
		private Nevron.UI.WinForm.Controls.NCommand nCommand35;
		private Nevron.UI.WinForm.Controls.NCommand nCommand36;
		private Nevron.UI.WinForm.Controls.NCommand nCommand37;
		private Nevron.UI.WinForm.Controls.NCommand nCommand38;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox2;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox1;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox3;
		private Nevron.UI.WinForm.Controls.NOptionButton nOptionButton2;

		#endregion
	}
}
