using System;
using System.Drawing;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	public class NButtonUC : NExampleUserControl
	{
		#region Constructor

		public NButtonUC(MainForm f) : base(f)
		{
			InitializeComponent();
		}


		#endregion

		#region Implementation

		protected override void Dispose(bool disposing)
		{
			if(disposing)
			{
			}
			base.Dispose (disposing);
		}

		public override void Initialize()
		{
			base.Initialize ();
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
		private void m_BorderButton_Click(object sender, System.EventArgs e)
		{
			nButton6.Border.ShowEditor();
		}


		#endregion

		#region Component Designer generated code

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NButtonUC));
			this.m_ImageList = new System.Windows.Forms.ImageList(this.components);
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nButton5 = new Nevron.UI.WinForm.Controls.NButton();
			this.nButton2 = new Nevron.UI.WinForm.Controls.NButton();
			this.nButton4 = new Nevron.UI.WinForm.Controls.NButton();
			this.nButton3 = new Nevron.UI.WinForm.Controls.NButton();
			this.nButton1 = new Nevron.UI.WinForm.Controls.NButton();
			this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nButton6 = new Nevron.UI.WinForm.Controls.NButton();
			this.nButton7 = new Nevron.UI.WinForm.Controls.NButton();
			this.nButton8 = new Nevron.UI.WinForm.Controls.NButton();
			this.nButton9 = new Nevron.UI.WinForm.Controls.NButton();
			this.nButton10 = new Nevron.UI.WinForm.Controls.NButton();
			this.nCheckBox1 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox2 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_BorderButton = new Nevron.UI.WinForm.Controls.NButton();
			this.nGroupBox1.SuspendLayout();
			this.nGroupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_ImageList
			// 
			this.m_ImageList.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ImageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.nButton5);
			this.nGroupBox1.Controls.Add(this.nButton2);
			this.nGroupBox1.Controls.Add(this.nButton4);
			this.nGroupBox1.Controls.Add(this.nButton3);
			this.nGroupBox1.Controls.Add(this.nButton1);
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(8, 8);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(160, 264);
			this.nGroupBox1.TabIndex = 14;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Flat Buttons";
			// 
			// nButton5
			// 
			this.nButton5.Location = new System.Drawing.Point(16, 192);
			this.nButton5.Name = "nButton5";
			this.nButton5.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable | Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes)));
			this.nButton5.Size = new System.Drawing.Size(104, 56);
			this.nButton5.TabIndex = 4;
			this.nButton5.Text = "nButton5";
			// 
			// nButton2
			// 
			this.nButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nButton2.ImageIndex = 5;
			this.nButton2.ImageList = this.m_ImageList;
			this.nButton2.Location = new System.Drawing.Point(32, 152);
			this.nButton2.Name = "nButton2";
			this.nButton2.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable | Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes)));
			this.nButton2.Size = new System.Drawing.Size(72, 23);
			this.nButton2.TabIndex = 3;
			this.nButton2.Text = "nButton2";
			this.nButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nButton4
			// 
			this.nButton4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.nButton4.ImageList = this.m_ImageList;
			this.nButton4.Location = new System.Drawing.Point(32, 120);
			this.nButton4.Name = "nButton4";
			this.nButton4.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable | Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes)));
			this.nButton4.Size = new System.Drawing.Size(72, 24);
			this.nButton4.TabIndex = 2;
			this.nButton4.Text = "nButton4";
			// 
			// nButton3
			// 
			this.nButton3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.nButton3.ImageIndex = 3;
			this.nButton3.ImageList = this.m_ImageList;
			this.nButton3.Location = new System.Drawing.Point(32, 72);
			this.nButton3.Name = "nButton3";
			this.nButton3.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable | Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes)));
			this.nButton3.Size = new System.Drawing.Size(72, 40);
			this.nButton3.TabIndex = 1;
			this.nButton3.Text = "nButton3";
			this.nButton3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// nButton1
			// 
			this.nButton1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.nButton1.ImageIndex = 1;
			this.nButton1.ImageList = this.m_ImageList;
			this.nButton1.Location = new System.Drawing.Point(32, 24);
			this.nButton1.Name = "nButton1";
			this.nButton1.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable | Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes)));
			this.nButton1.Size = new System.Drawing.Size(72, 40);
			this.nButton1.TabIndex = 0;
			this.nButton1.Text = "nButton1";
			this.nButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// nGroupBox2
			// 
			this.nGroupBox2.Controls.Add(this.nButton6);
			this.nGroupBox2.Controls.Add(this.nButton7);
			this.nGroupBox2.Controls.Add(this.nButton8);
			this.nGroupBox2.Controls.Add(this.nButton9);
			this.nGroupBox2.Controls.Add(this.nButton10);
			this.nGroupBox2.ImageIndex = 0;
			this.nGroupBox2.Location = new System.Drawing.Point(184, 8);
			this.nGroupBox2.Name = "nGroupBox2";
			this.nGroupBox2.Size = new System.Drawing.Size(160, 264);
			this.nGroupBox2.TabIndex = 15;
			this.nGroupBox2.TabStop = false;
			this.nGroupBox2.Text = "Light3D Buttons";
			// 
			// nButton6
			// 
			this.nButton6.Location = new System.Drawing.Point(24, 192);
			this.nButton6.Name = "nButton6";
			this.nButton6.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable | Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes)));
			this.nButton6.Size = new System.Drawing.Size(104, 56);
			this.nButton6.TabIndex = 9;
			this.nButton6.Text = "nButton6";
			// 
			// nButton7
			// 
			this.nButton7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nButton7.ImageIndex = 5;
			this.nButton7.ImageList = this.m_ImageList;
			this.nButton7.Location = new System.Drawing.Point(40, 152);
			this.nButton7.Name = "nButton7";
			this.nButton7.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable | Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes)));
			this.nButton7.Size = new System.Drawing.Size(72, 23);
			this.nButton7.TabIndex = 8;
			this.nButton7.Text = "nButton7";
			this.nButton7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nButton8
			// 
			this.nButton8.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.nButton8.ImageList = this.m_ImageList;
			this.nButton8.Location = new System.Drawing.Point(40, 120);
			this.nButton8.Name = "nButton8";
			this.nButton8.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable | Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes)));
			this.nButton8.Size = new System.Drawing.Size(72, 24);
			this.nButton8.TabIndex = 7;
			this.nButton8.Text = "nButton8";
			// 
			// nButton9
			// 
			this.nButton9.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.nButton9.ImageIndex = 3;
			this.nButton9.ImageList = this.m_ImageList;
			this.nButton9.Location = new System.Drawing.Point(40, 72);
			this.nButton9.Name = "nButton9";
			this.nButton9.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable | Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes)));
			this.nButton9.Size = new System.Drawing.Size(72, 40);
			this.nButton9.TabIndex = 6;
			this.nButton9.Text = "nButton9";
			this.nButton9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// nButton10
			// 
			this.nButton10.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.nButton10.ImageIndex = 1;
			this.nButton10.ImageList = this.m_ImageList;
			this.nButton10.Location = new System.Drawing.Point(40, 24);
			this.nButton10.Name = "nButton10";
			this.nButton10.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable | Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes)));
			this.nButton10.Size = new System.Drawing.Size(72, 40);
			this.nButton10.TabIndex = 5;
			this.nButton10.Text = "nButton10";
			this.nButton10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// nCheckBox1
			// 
			this.nCheckBox1.Checked = true;
			this.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.nCheckBox1.Location = new System.Drawing.Point(8, 304);
			this.nCheckBox1.Name = "nCheckBox1";
			this.nCheckBox1.TabIndex = 16;
			this.nCheckBox1.Text = "&Enable";
			this.nCheckBox1.CheckedChanged += new System.EventHandler(this.nCheckBox1_CheckedChanged);
			// 
			// nCheckBox2
			// 
			this.nCheckBox2.Checked = true;
			this.nCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.nCheckBox2.Location = new System.Drawing.Point(120, 304);
			this.nCheckBox2.Name = "nCheckBox2";
			this.nCheckBox2.Size = new System.Drawing.Size(128, 24);
			this.nCheckBox2.TabIndex = 17;
			this.nCheckBox2.Text = "Show &Focus Rect";
			this.nCheckBox2.CheckedChanged += new System.EventHandler(this.nCheckBox2_CheckedChanged);
			// 
			// m_BorderButton
			// 
			this.m_BorderButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_BorderButton.ImageList = this.m_ImageList;
			this.m_BorderButton.Location = new System.Drawing.Point(248, 304);
			this.m_BorderButton.Name = "m_BorderButton";
			this.m_BorderButton.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable | Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes)));
			this.m_BorderButton.Size = new System.Drawing.Size(72, 24);
			this.m_BorderButton.TabIndex = 18;
			this.m_BorderButton.Text = "Border...";
			this.m_BorderButton.Click += new System.EventHandler(this.m_BorderButton_Click);
			// 
			// NButtonUC
			// 
			this.Controls.Add(this.m_BorderButton);
			this.Controls.Add(this.nCheckBox2);
			this.Controls.Add(this.nCheckBox1);
			this.Controls.Add(this.nGroupBox1);
			this.Controls.Add(this.nGroupBox2);
			this.Name = "NButtonUC";
			this.Size = new System.Drawing.Size(352, 336);
			this.nGroupBox1.ResumeLayout(false);
			this.nGroupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	


		#endregion

		#region Fields

		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
		internal System.Windows.Forms.ImageList m_ImageList;
		private System.ComponentModel.IContainer components;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox1;

		private Nevron.UI.WinForm.Controls.NButton nButton1;
		private Nevron.UI.WinForm.Controls.NButton nButton3;
		private Nevron.UI.WinForm.Controls.NButton nButton4;
		private Nevron.UI.WinForm.Controls.NButton nButton2;
		private Nevron.UI.WinForm.Controls.NButton nButton5;
		private Nevron.UI.WinForm.Controls.NButton nButton6;
		private Nevron.UI.WinForm.Controls.NButton nButton7;
		private Nevron.UI.WinForm.Controls.NButton nButton8;
		private Nevron.UI.WinForm.Controls.NButton nButton9;
		private Nevron.UI.WinForm.Controls.NButton nButton10;
		private Nevron.UI.WinForm.Controls.NButton m_BorderButton;

		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox2;

		#endregion
	}
}
