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
	public class NColorListBoxUC : NExampleUserControl
	{
		#region Constructor

		public NColorListBoxUC(MainForm f) : base(f)
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
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			nColorListBox1.PopulateKnownColors();
			nColorListBox2.PopulateWebColors();
			nColorListBox3.PopulateSystemColors();

			Color c;
			NListBoxItem item;

			nColorListBox4.BeginUpdate();
			for(int i = 0; i < 256; i += 30)
			{
				for(int j = 0; j < 256; j += 30)
				{
					for(int k = 0; k < 256; k += 30)
					{
						c = Color.FromArgb(i, j, k);
						item = new NListBoxItem(c);
						item.Text = ColorTranslator.ToHtml(c);

						nColorListBox4.Items.Add(item);
					}
				}
			}
			nColorListBox4.EndUpdate();
		}

		public override void Initialize()
		{
			base.Initialize();

			nColorListBox1.PopulateKnownColors();
			nColorListBox2.PopulateWebColors();
			nColorListBox3.PopulateSystemColors();

			Color c;
			NListBoxItem item;

			nColorListBox4.BeginUpdate();

			for(int i = 0; i < 256; i += 30)
			{
				for(int j = 0; j < 256; j += 30)
				{
					for(int k = 0; k < 256; k += 30)
					{
						c = Color.FromArgb(i, j, k);
						item = new NListBoxItem(c);
						item.Text = ColorTranslator.ToHtml(c);

						nColorListBox4.Items.Add(item);
					}
				}
			}

			nColorListBox4.EndUpdate();
		}



		#endregion

		#region Event Handlers

		private void nCheckBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			foreach(Control c in Controls)
			{
				if(!(c is NListBox))
					continue;

				((NListBox)c).CheckBoxes = nCheckBox1.Checked;
			}
		}

		private void nCheckBox2_CheckedChanged(object sender, System.EventArgs e)
		{
			foreach(Control c in Controls)
			{
				if(!(c is NListBox))
					continue;

				((NListBox)c).ShowFocusRect = nCheckBox2.Checked;
			}
		}

		private void nCheckBox3_CheckedChanged(object sender, System.EventArgs e)
		{
			foreach(Control c in Controls)
			{
				if(!(c is NListBox))
					continue;

				((NListBox)c).Enabled = nCheckBox3.Checked;
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
			this.nColorListBox1 = new Nevron.UI.WinForm.Controls.NColorListBox();
			this.nColorListBox2 = new Nevron.UI.WinForm.Controls.NColorListBox();
			this.nColorListBox3 = new Nevron.UI.WinForm.Controls.NColorListBox();
			this.nColorListBox4 = new Nevron.UI.WinForm.Controls.NColorListBox();
			this.nCheckBox3 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox2 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox1 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// nColorListBox1
			// 
			this.nColorListBox1.Location = new System.Drawing.Point(8, 8);
			this.nColorListBox1.Name = "nColorListBox1";
			this.nColorListBox1.Size = new System.Drawing.Size(200, 144);
			this.nColorListBox1.TabIndex = 0;
			this.nColorListBox1.Items.AddRange(new Nevron.UI.WinForm.Controls.NListBoxItem[0]);
			// 
			// nColorListBox2
			// 
			this.nColorListBox2.Location = new System.Drawing.Point(8, 160);
			this.nColorListBox2.Name = "nColorListBox2";
			this.nColorListBox2.Size = new System.Drawing.Size(200, 144);
			this.nColorListBox2.TabIndex = 1;
			this.nColorListBox2.Items.AddRange(new Nevron.UI.WinForm.Controls.NListBoxItem[0]);
			// 
			// nColorListBox3
			// 
			this.nColorListBox3.Location = new System.Drawing.Point(216, 8);
			this.nColorListBox3.Name = "nColorListBox3";
			this.nColorListBox3.Size = new System.Drawing.Size(200, 144);
			this.nColorListBox3.TabIndex = 2;
			this.nColorListBox3.Items.AddRange(new Nevron.UI.WinForm.Controls.NListBoxItem[0]);
			// 
			// nColorListBox4
			// 
			this.nColorListBox4.Location = new System.Drawing.Point(216, 160);
			this.nColorListBox4.Name = "nColorListBox4";
			this.nColorListBox4.Size = new System.Drawing.Size(200, 144);
			this.nColorListBox4.TabIndex = 3;
			this.nColorListBox4.Items.AddRange(new Nevron.UI.WinForm.Controls.NListBoxItem[0]);
			// 
			// nCheckBox3
			// 
			this.nCheckBox3.Checked = true;
			this.nCheckBox3.CheckState = System.Windows.Forms.CheckState.Checked;
			this.nCheckBox3.Location = new System.Drawing.Point(256, 312);
			this.nCheckBox3.Name = "nCheckBox3";
			this.nCheckBox3.TabIndex = 15;
			this.nCheckBox3.Text = "&Enable";
			this.nCheckBox3.CheckedChanged += new System.EventHandler(this.nCheckBox3_CheckedChanged);
			// 
			// nCheckBox2
			// 
			this.nCheckBox2.Location = new System.Drawing.Point(112, 312);
			this.nCheckBox2.Name = "nCheckBox2";
			this.nCheckBox2.Size = new System.Drawing.Size(136, 24);
			this.nCheckBox2.TabIndex = 14;
			this.nCheckBox2.Text = "Show &Focus Rect";
			this.nCheckBox2.CheckedChanged += new System.EventHandler(this.nCheckBox2_CheckedChanged);
			// 
			// nCheckBox1
			// 
			this.nCheckBox1.Location = new System.Drawing.Point(8, 312);
			this.nCheckBox1.Name = "nCheckBox1";
			this.nCheckBox1.Size = new System.Drawing.Size(96, 24);
			this.nCheckBox1.TabIndex = 13;
			this.nCheckBox1.Text = "&CheckBoxes";
			this.nCheckBox1.CheckedChanged += new System.EventHandler(this.nCheckBox1_CheckedChanged);
			// 
			// NColorListBoxUC
			// 
			this.Controls.Add(this.nCheckBox3);
			this.Controls.Add(this.nCheckBox2);
			this.Controls.Add(this.nCheckBox1);
			this.Controls.Add(this.nColorListBox4);
			this.Controls.Add(this.nColorListBox3);
			this.Controls.Add(this.nColorListBox2);
			this.Controls.Add(this.nColorListBox1);
			this.Name = "NColorListBoxUC";
			this.Size = new System.Drawing.Size(424, 344);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		private Nevron.UI.WinForm.Controls.NColorListBox nColorListBox1;
		private Nevron.UI.WinForm.Controls.NColorListBox nColorListBox2;
		private Nevron.UI.WinForm.Controls.NColorListBox nColorListBox3;
		private Nevron.UI.WinForm.Controls.NColorListBox nColorListBox4;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox3;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox2;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox1;

		#endregion
	}
}
