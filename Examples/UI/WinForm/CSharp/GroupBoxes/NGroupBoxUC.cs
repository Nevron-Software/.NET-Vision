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
	public class NGroupBoxUC : NExampleUserControl
	{
		#region Constructor

		public NGroupBoxUC(MainForm f) : base(f)
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
		public override void Initialize()
		{
			base.Initialize ();

			int counter = 0;
			foreach(NGroupBox box in Controls)
			{
				box.ImageList = m_ImageList;
				box.ImageIndex = counter;
				counter++;
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NGroupBoxUC));
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nLuminanceBar1 = new Nevron.UI.WinForm.Controls.NLuminanceBar();
			this.nColorBar1 = new Nevron.UI.WinForm.Controls.NColorBar();
			this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nColorPool1 = new Nevron.UI.WinForm.Controls.NColorPool();
			this.nColorButton1 = new Nevron.UI.WinForm.Controls.NColorButton();
			this.nButton1 = new Nevron.UI.WinForm.Controls.NButton();
			this.nGroupBox3 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nRadioButton2 = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.nRadioButton1 = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.nhScrollBar1 = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.nGroupBox4 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nOptionButton1 = new Nevron.UI.WinForm.Controls.NOptionButton();
			this.nComboBoxCommand1 = new Nevron.UI.WinForm.Controls.NComboBoxCommand();
			this.m_ImageList = new System.Windows.Forms.ImageList(this.components);
			this.nCommand1 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nComboBoxCommand2 = new Nevron.UI.WinForm.Controls.NComboBoxCommand();
			this.nCommand2 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nTextBox1 = new Nevron.UI.WinForm.Controls.NTextBox();
			this.nGroupBox1.SuspendLayout();
			this.nGroupBox2.SuspendLayout();
			this.nGroupBox3.SuspendLayout();
			this.nGroupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.nLuminanceBar1);
			this.nGroupBox1.Controls.Add(this.nColorBar1);
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(8, 8);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(240, 96);
			this.nGroupBox1.TabIndex = 0;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Group Box with Style LineAtTop";
			// 
			// nLuminanceBar1
			// 
			this.nLuminanceBar1.Color = System.Drawing.Color.Red;
			this.nLuminanceBar1.Location = new System.Drawing.Point(16, 56);
			this.nLuminanceBar1.Mode = Nevron.UI.WinForm.Controls.ColorBarMode.Custom;
			this.nLuminanceBar1.Name = "nLuminanceBar1";
			this.nLuminanceBar1.Size = new System.Drawing.Size(200, 25);
			this.nLuminanceBar1.TabIndex = 1;
			this.nLuminanceBar1.Text = "nLuminanceBar1";
			// 
			// nColorBar1
			// 
			this.nColorBar1.Location = new System.Drawing.Point(16, 24);
			this.nColorBar1.Name = "nColorBar1";
			this.nColorBar1.Size = new System.Drawing.Size(200, 24);
			this.nColorBar1.TabIndex = 0;
			this.nColorBar1.Text = "nColorBar1";
			this.nColorBar1.Value = 50;
			// 
			// nGroupBox2
			// 
			this.nGroupBox2.Controls.Add(this.nColorPool1);
			this.nGroupBox2.Controls.Add(this.nColorButton1);
			this.nGroupBox2.Controls.Add(this.nButton1);
			this.nGroupBox2.ImageIndex = 0;
			this.nGroupBox2.Location = new System.Drawing.Point(8, 112);
			this.nGroupBox2.Name = "nGroupBox2";
			this.nGroupBox2.Size = new System.Drawing.Size(240, 96);
			this.nGroupBox2.TabIndex = 1;
			this.nGroupBox2.TabStop = false;
			this.nGroupBox2.Text = "Group Box with Style LineAtTop";
			this.nGroupBox2.TextOrigin = 50;
			// 
			// nColorPool1
			// 
			this.nColorPool1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.nColorPool1.Color = System.Drawing.Color.Empty;
			this.nColorPool1.Location = new System.Drawing.Point(120, 16);
			this.nColorPool1.Name = "nColorPool1";
			this.nColorPool1.Size = new System.Drawing.Size(112, 72);
			this.nColorPool1.TabIndex = 2;
			// 
			// nColorButton1
			// 
			this.nColorButton1.ArrowClickOptions = false;
			this.nColorButton1.Color = System.Drawing.Color.White;
			this.nColorButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nColorButton1.Location = new System.Drawing.Point(16, 56);
			this.nColorButton1.Name = "nColorButton1";
			this.nColorButton1.TabIndex = 1;
			this.nColorButton1.Text = "nColorButton1";
			// 
			// nButton1
			// 
			this.nButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nButton1.Location = new System.Drawing.Point(16, 24);
			this.nButton1.Name = "nButton1";
			this.nButton1.TabIndex = 0;
			this.nButton1.Text = "nButton1";
			// 
			// nGroupBox3
			// 
			this.nGroupBox3.Controls.Add(this.nRadioButton2);
			this.nGroupBox3.Controls.Add(this.nRadioButton1);
			this.nGroupBox3.Controls.Add(this.nhScrollBar1);
			this.nGroupBox3.ImageIndex = 0;
			this.nGroupBox3.Location = new System.Drawing.Point(8, 216);
			this.nGroupBox3.Name = "nGroupBox3";
			this.nGroupBox3.Size = new System.Drawing.Size(240, 96);
			this.nGroupBox3.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default;
			this.nGroupBox3.TabIndex = 2;
			this.nGroupBox3.TabStop = false;
			this.nGroupBox3.Text = "nGroupBox3";
			// 
			// nRadioButton2
			// 
			this.nRadioButton2.Location = new System.Drawing.Point(120, 56);
			this.nRadioButton2.Name = "nRadioButton2";
			this.nRadioButton2.TabIndex = 2;
			this.nRadioButton2.Text = "nRadioButton2";
			// 
			// nRadioButton1
			// 
			this.nRadioButton1.Location = new System.Drawing.Point(8, 56);
			this.nRadioButton1.Name = "nRadioButton1";
			this.nRadioButton1.TabIndex = 1;
			this.nRadioButton1.Text = "nRadioButton1";
			// 
			// nhScrollBar1
			// 
			this.nhScrollBar1.Location = new System.Drawing.Point(8, 24);
			this.nhScrollBar1.Name = "nhScrollBar1";
			this.nhScrollBar1.Size = new System.Drawing.Size(216, 17);
			this.nhScrollBar1.TabIndex = 0;
			this.nhScrollBar1.Text = "nhScrollBar1";
			// 
			// nGroupBox4
			// 
			this.nGroupBox4.Controls.Add(this.nOptionButton1);
			this.nGroupBox4.Controls.Add(this.nTextBox1);
			this.nGroupBox4.ImageIndex = 0;
			this.nGroupBox4.Location = new System.Drawing.Point(8, 328);
			this.nGroupBox4.Name = "nGroupBox4";
			this.nGroupBox4.Size = new System.Drawing.Size(240, 96);
			this.nGroupBox4.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default;
			this.nGroupBox4.TabIndex = 3;
			this.nGroupBox4.TabStop = false;
			this.nGroupBox4.Text = "nGroupBox4";
			this.nGroupBox4.TextOrigin = 50;
			// 
			// nOptionButton1
			// 
			this.nOptionButton1.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																					   this.nComboBoxCommand1,
																					   this.nCommand1});
			this.nOptionButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nOptionButton1.ImageIndex = 16;
			this.nOptionButton1.ImageList = this.m_ImageList;
			this.nOptionButton1.Location = new System.Drawing.Point(8, 56);
			this.nOptionButton1.Name = "nOptionButton1";
			this.nOptionButton1.Size = new System.Drawing.Size(160, 23);
			this.nOptionButton1.TabIndex = 1;
			this.nOptionButton1.Text = "nOptionButton1";
			// 
			// nComboBoxCommand1
			// 
			this.nComboBoxCommand1.ControlText = "";
			this.nComboBoxCommand1.Properties.ImageList = this.m_ImageList;
			this.nComboBoxCommand1.Properties.Text = "nComboBoxCommand1";
			this.nComboBoxCommand1.Items.AddRange(new Nevron.UI.WinForm.Controls.NListBoxItem[] {
																						   new Nevron.UI.WinForm.Controls.NListBoxItem(0, null, false),
																						   new Nevron.UI.WinForm.Controls.NListBoxItem(1, null, false),
																						   new Nevron.UI.WinForm.Controls.NListBoxItem(2, null, false)});
			// 
			// m_ImageList
			// 
			this.m_ImageList.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ImageList.ImageStream")));
			this.m_ImageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// nCommand1
			// 
			this.nCommand1.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																				  this.nComboBoxCommand2,
																				  this.nCommand2});
			this.nCommand1.Properties.Text = "nCommand1";
			// 
			// nComboBoxCommand2
			// 
			this.nComboBoxCommand2.ControlText = "";
			this.nComboBoxCommand2.Editable = true;
			this.nComboBoxCommand2.Properties.ImageList = this.m_ImageList;
			this.nComboBoxCommand2.Properties.Text = "nComboBoxCommand2";
			this.nComboBoxCommand2.Items.AddRange(new Nevron.UI.WinForm.Controls.NListBoxItem[] {
																						   new Nevron.UI.WinForm.Controls.NListBoxItem(3, null, false),
																						   new Nevron.UI.WinForm.Controls.NListBoxItem(4, null, false),
																						   new Nevron.UI.WinForm.Controls.NListBoxItem(5, null, false)});
			// 
			// nCommand2
			// 
			this.nCommand2.Properties.ImageIndex = 0;
			this.nCommand2.Properties.ImageList = this.m_ImageList;
			this.nCommand2.Properties.Text = "nCommand2";
			// 
			// nTextBox1
			// 
			this.nTextBox1.Location = new System.Drawing.Point(8, 24);
			this.nTextBox1.Name = "nTextBox1";
			this.nTextBox1.TabIndex = 0;
			this.nTextBox1.Text = "nTextBox1";
			// 
			// NGroupBoxUC
			// 
			this.Controls.Add(this.nGroupBox4);
			this.Controls.Add(this.nGroupBox3);
			this.Controls.Add(this.nGroupBox1);
			this.Controls.Add(this.nGroupBox2);
			this.Name = "NGroupBoxUC";
			this.Size = new System.Drawing.Size(264, 440);
			this.nGroupBox1.ResumeLayout(false);
			this.nGroupBox2.ResumeLayout(false);
			this.nGroupBox3.ResumeLayout(false);
			this.nGroupBox4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox3;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox4;
		internal System.Windows.Forms.ImageList m_ImageList;
		private Nevron.UI.WinForm.Controls.NHScrollBar nhScrollBar1;
		private Nevron.UI.WinForm.Controls.NRadioButton nRadioButton1;
		private Nevron.UI.WinForm.Controls.NRadioButton nRadioButton2;
		private Nevron.UI.WinForm.Controls.NTextBox nTextBox1;
		private Nevron.UI.WinForm.Controls.NOptionButton nOptionButton1;
		private Nevron.UI.WinForm.Controls.NComboBoxCommand nComboBoxCommand1;
		private Nevron.UI.WinForm.Controls.NCommand nCommand1;
		private Nevron.UI.WinForm.Controls.NComboBoxCommand nComboBoxCommand2;
		private Nevron.UI.WinForm.Controls.NColorBar nColorBar1;
		private Nevron.UI.WinForm.Controls.NButton nButton1;
		private Nevron.UI.WinForm.Controls.NColorButton nColorButton1;
		private Nevron.UI.WinForm.Controls.NColorPool nColorPool1;
		private Nevron.UI.WinForm.Controls.NCommand nCommand2;
		private Nevron.UI.WinForm.Controls.NLuminanceBar nLuminanceBar1;
		private System.ComponentModel.IContainer components;

		#endregion
	}
}

