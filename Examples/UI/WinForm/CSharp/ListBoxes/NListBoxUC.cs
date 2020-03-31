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
	public class NListBoxUC : NExampleUserControl
	{
		#region Constructor

		public NListBoxUC(MainForm f) : base(f)
		{
			InitializeComponent();
		}
		public NListBoxUC()
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

			int count = 10;
			NListBoxItem item1, item2, item3, item4, item5;

			for(int i = 0; i < count; i++)
			{
				item1 = new NListBoxItem(i, "Item "+i, false);
				item2 = new NListBoxItem(i, "Item "+i, false);
				item3 = new NListBoxItem(i, "Item "+i, false);
				item4 = new NListBoxItem(i, "Item "+i, false);
				item5 = new NListBoxItem(i, "Item "+i, false);

				nListBox1.Items.Add(item1);
				nListBox2.Items.Add(item2);
				nListBox3.Items.Add(item3);
				nListBox4.Items.Add(item4);
				nListBox5.Items.Add(item5);
			}

			nListBox1.ImageList = MainForm.TestImages;
			nListBox2.ImageList = MainForm.TestImages;
			nListBox3.ImageList = MainForm.TestImages;
			nListBox4.ImageList = MainForm.TestImages;
			nListBox5.ImageList = MainForm.TestImages;

			m_CheckStyleCombo.ListProperties.ColumnOnLeft = false;
			m_CheckStyleCombo.FillFromEnum(typeof(CheckStyle), false);
			m_CheckStyleCombo.SelectedItem = CheckStyle.Standard;
			m_CheckStyleCombo.SelectedIndexChanged += new EventHandler(m_CheckStyleCombo_SelectedIndexChanged);
		}


		#endregion

		#region Event Handlers

		private void nCheckBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			nCheckBox4.Enabled = nCheckBox1.Checked;
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

		private void nCheckBox4_CheckedChanged(object sender, System.EventArgs e)
		{
			foreach(Control c in Controls)
			{
				if(!(c is NListBox))
					continue;

				((NListBox)c).CheckOnClick = nCheckBox4.Checked;
			}
		}

		private void m_BorderButton_Click(object sender, System.EventArgs e)
		{
			NControlBorder border = nListBox1.Border;
			border.ShowEditor();

			//apply the border change to all listboxes
			int count = Controls.Count;
			NListBox list;

			for(int i = 0; i < count; i++)
			{
				list = Controls[i] as NListBox;
				if(list == null || list == nListBox1)
					continue;

				list.Border.Copy(border);
			}
		}

		private void m_CheckStyleCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			object o = m_CheckStyleCombo.SelectedItem;
			if(!(o is CheckStyle))
				return;

			CheckStyle style = (CheckStyle)o;
			int count = Controls.Count;
			NListBox list;

			for(int i = 0; i < count; i++)
			{
				list = Controls[i] as NListBox;
				if(list == null)
					continue;

				list.CheckStyle = style;
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
			this.nListBox1 = new Nevron.UI.WinForm.Controls.NListBox();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.nListBox2 = new Nevron.UI.WinForm.Controls.NListBox();
			this.nListBox3 = new Nevron.UI.WinForm.Controls.NListBox();
			this.nListBox4 = new Nevron.UI.WinForm.Controls.NListBox();
			this.nListBox5 = new Nevron.UI.WinForm.Controls.NListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.nCheckBox1 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox2 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox3 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox4 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_BorderButton = new Nevron.UI.WinForm.Controls.NButton();
			this.m_CheckStyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// nListBox1
			// 
			this.nListBox1.DefaultImageIndex = 3;
			this.nListBox1.ImageList = this.imageList1;
			this.nListBox1.Location = new System.Drawing.Point(8, 32);
			this.nListBox1.Name = "nListBox1";
			this.nListBox1.Size = new System.Drawing.Size(216, 144);
			this.nListBox1.TabIndex = 0;
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// nListBox2
			// 
			this.nListBox2.DefaultImageIndex = 5;
			this.nListBox2.ImageList = this.imageList1;
			this.nListBox2.Location = new System.Drawing.Point(232, 216);
			this.nListBox2.MultiColumn = true;
			this.nListBox2.Name = "nListBox2";
			this.nListBox2.Size = new System.Drawing.Size(216, 144);
			this.nListBox2.TabIndex = 1;
			// 
			// nListBox3
			// 
			this.nListBox3.DefaultImageIndex = 1;
			this.nListBox3.HorizontalExtent = 500;
			this.nListBox3.HorizontalScrollbar = true;
			this.nListBox3.ImageList = this.imageList1;
			this.nListBox3.Location = new System.Drawing.Point(232, 32);
			this.nListBox3.Name = "nListBox3";
			this.nListBox3.Size = new System.Drawing.Size(216, 141);
			this.nListBox3.TabIndex = 2;
			// 
			// nListBox4
			// 
			this.nListBox4.DefaultImageIndex = 4;
			this.nListBox4.ImageList = this.imageList1;
			this.nListBox4.Location = new System.Drawing.Point(8, 216);
			this.nListBox4.Name = "nListBox4";
			this.nListBox4.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.nListBox4.Size = new System.Drawing.Size(216, 144);
			this.nListBox4.TabIndex = 3;
			// 
			// nListBox5
			// 
			this.nListBox5.DefaultImageIndex = 9;
			this.nListBox5.ImageList = this.imageList1;
			this.nListBox5.Location = new System.Drawing.Point(456, 32);
			this.nListBox5.Name = "nListBox5";
			this.nListBox5.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.nListBox5.Size = new System.Drawing.Size(216, 144);
			this.nListBox5.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "Default NListBox:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(232, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(176, 23);
			this.label2.TabIndex = 6;
			this.label2.Text = "NListBox with HorizontalScrollBar:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 184);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(216, 23);
			this.label3.TabIndex = 7;
			this.label3.Text = "NListBox with SelectionMode.MultiSimple:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(456, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(232, 23);
			this.label4.TabIndex = 8;
			this.label4.Text = "NListBox with SelectionMode.MultiExtended:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(232, 184);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(176, 23);
			this.label5.TabIndex = 9;
			this.label5.Text = "NListBox with MultiColumn:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// nCheckBox1
			// 
			this.nCheckBox1.Location = new System.Drawing.Point(512, 216);
			this.nCheckBox1.Name = "nCheckBox1";
			this.nCheckBox1.Size = new System.Drawing.Size(96, 24);
			this.nCheckBox1.TabIndex = 10;
			this.nCheckBox1.Text = "&CheckBoxes";
			this.nCheckBox1.CheckedChanged += new System.EventHandler(this.nCheckBox1_CheckedChanged);
			// 
			// nCheckBox2
			// 
			this.nCheckBox2.Location = new System.Drawing.Point(512, 320);
			this.nCheckBox2.Name = "nCheckBox2";
			this.nCheckBox2.Size = new System.Drawing.Size(120, 24);
			this.nCheckBox2.TabIndex = 11;
			this.nCheckBox2.Text = "Show &Focus Rect";
			this.nCheckBox2.CheckedChanged += new System.EventHandler(this.nCheckBox2_CheckedChanged);
			// 
			// nCheckBox3
			// 
			this.nCheckBox3.Checked = true;
			this.nCheckBox3.CheckState = System.Windows.Forms.CheckState.Checked;
			this.nCheckBox3.Location = new System.Drawing.Point(512, 344);
			this.nCheckBox3.Name = "nCheckBox3";
			this.nCheckBox3.TabIndex = 12;
			this.nCheckBox3.Text = "&Enable";
			this.nCheckBox3.CheckedChanged += new System.EventHandler(this.nCheckBox3_CheckedChanged);
			// 
			// nCheckBox4
			// 
			this.nCheckBox4.Enabled = false;
			this.nCheckBox4.Location = new System.Drawing.Point(512, 240);
			this.nCheckBox4.Name = "nCheckBox4";
			this.nCheckBox4.TabIndex = 13;
			this.nCheckBox4.Text = "Check On &Click";
			this.nCheckBox4.CheckedChanged += new System.EventHandler(this.nCheckBox4_CheckedChanged);
			// 
			// m_BorderButton
			// 
			this.m_BorderButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_BorderButton.Location = new System.Drawing.Point(512, 376);
			this.m_BorderButton.Name = "m_BorderButton";
			this.m_BorderButton.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable | Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes)));
			this.m_BorderButton.Size = new System.Drawing.Size(104, 24);
			this.m_BorderButton.TabIndex = 14;
			this.m_BorderButton.Text = "Border...";
			this.m_BorderButton.Click += new System.EventHandler(this.m_BorderButton_Click);
			// 
			// m_CheckStyleCombo
			// 
			this.m_CheckStyleCombo.Location = new System.Drawing.Point(512, 288);
			this.m_CheckStyleCombo.Name = "m_CheckStyleCombo";
			this.m_CheckStyleCombo.Size = new System.Drawing.Size(160, 21);
			this.m_CheckStyleCombo.TabIndex = 15;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(512, 264);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 23);
			this.label6.TabIndex = 16;
			this.label6.Text = "Check Style:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NListBoxUC
			// 
			this.Controls.Add(this.label6);
			this.Controls.Add(this.m_CheckStyleCombo);
			this.Controls.Add(this.m_BorderButton);
			this.Controls.Add(this.nCheckBox4);
			this.Controls.Add(this.nCheckBox3);
			this.Controls.Add(this.nCheckBox2);
			this.Controls.Add(this.nCheckBox1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.nListBox5);
			this.Controls.Add(this.nListBox4);
			this.Controls.Add(this.nListBox3);
			this.Controls.Add(this.nListBox2);
			this.Controls.Add(this.nListBox1);
			this.Name = "NListBoxUC";
			this.Size = new System.Drawing.Size(680, 408);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private Nevron.UI.WinForm.Controls.NListBox nListBox1;
		private Nevron.UI.WinForm.Controls.NListBox nListBox2;
		private Nevron.UI.WinForm.Controls.NListBox nListBox3;
		private Nevron.UI.WinForm.Controls.NListBox nListBox4;
		private Nevron.UI.WinForm.Controls.NListBox nListBox5;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox1;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox2;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox3;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox4;
		private Nevron.UI.WinForm.Controls.NButton m_BorderButton;
		private NComboBox m_CheckStyleCombo;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label label6;
		private System.ComponentModel.IContainer components;

		#endregion
	}
}
