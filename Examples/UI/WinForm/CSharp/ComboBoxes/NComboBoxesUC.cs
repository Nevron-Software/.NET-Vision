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
	/// <summary>
	/// Summary description for ComboBoxExample.
	/// </summary>
	public class NComboBoxesUC : NExampleUserControl
	{
		#region Constructor

		public NComboBoxesUC(MainForm f) : base(f)
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

			nComboBox1.KeyPress += new KeyPressEventHandler(nComboBox1_KeyPress);

			m_ColorMode.Items.Add("Known Colors");
			m_ColorMode.Items.Add("Web Colors");
			m_ColorMode.Items.Add("System Colors");

			m_ColorMode.SelectedIndex = 0;

			//init some items
			NListBoxItem item;

			for(int i = 0; i < 10; i++)
			{
				item = new NListBoxItem();
				item.Text = "List item " + (i + 1).ToString();
				item.ImageIndex = i;

				nComboBox1.Items.Add(item);
				nComboBox2.Items.Add(item);
				nComboBox4.Items.Add(item);
			}

			nComboBox2.Editable = true;

			m_PropertyGrid.PropertyValueChanged += new PropertyValueChangedEventHandler(m_PropertyGrid_PropertyValueChanged);
			m_PropertyGrid.SelectedObject = nComboBox1.ListProperties;
		}



		#endregion

		#region Event Handlers

		private void m_ColorMode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int index = m_ColorMode.SelectedIndex;
			switch(index)
			{
				case 0:
					m_Colors.PopulateKnownColors();
					break;
				case 1:
					m_Colors.PopulateWebColors();
					break;
				case 2:
					m_Colors.PopulateSystemColors();
					break;
			}

			m_Colors.SelectedIndex = 0;
		}
		private void nCheckBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			bool enabled = nCheckBox1.Checked;
			nComboBox1.Enabled = enabled;
            nComboBox2.Enabled = enabled;
			nComboBox4.Enabled = enabled;
			m_Colors.Enabled = enabled;
			m_ColorMode.Enabled = enabled;
		}

		private void nCheckBox2_CheckedChanged(object sender, System.EventArgs e)
		{
			bool interactive = nCheckBox2.Checked;
			nComboBox1.InteractiveBorder = interactive;
            nComboBox2.InteractiveBorder = interactive;
			nComboBox4.InteractiveBorder = interactive;
			m_Colors.InteractiveBorder = interactive;
			m_ColorMode.InteractiveBorder = interactive;
		}

		private void m_PropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
		{
			NListBoxProperties props = nComboBox1.ListProperties;

			nComboBox2.ListProperties.Copy(props);
			nComboBox4.ListProperties.Copy(props);

			Invalidate(true);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NComboBoxesUC));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.m_Colors = new Nevron.UI.WinForm.Controls.NColorComboBox();
			this.m_ColorMode = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nComboBox4 = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nComboBox1 = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nComboBox2 = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nCheckBox1 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCheckBox2 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_PropertyGrid = new System.Windows.Forms.PropertyGrid();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.nGroupBox3 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nGroupBox1.SuspendLayout();
			this.nGroupBox2.SuspendLayout();
			this.nGroupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_Colors
			// 
			this.m_Colors.Location = new System.Drawing.Point(16, 24);
			this.m_Colors.Name = "m_Colors";
			this.m_Colors.Size = new System.Drawing.Size(192, 22);
			this.m_Colors.TabIndex = 6;
			this.m_Colors.Text = "nColorComboBox1";
			// 
			// m_ColorMode
			// 
			this.m_ColorMode.Location = new System.Drawing.Point(80, 56);
			this.m_ColorMode.Name = "m_ColorMode";
			this.m_ColorMode.Size = new System.Drawing.Size(128, 22);
			this.m_ColorMode.TabIndex = 8;
			this.m_ColorMode.Text = "nComboBox4";
			this.m_ColorMode.SelectedIndexChanged += new System.EventHandler(this.m_ColorMode_SelectedIndexChanged);
			// 
			// nComboBox4
			// 
			this.nComboBox4.ImageList = this.imageList1;
			this.nComboBox4.Location = new System.Drawing.Point(16, 88);
			this.nComboBox4.Name = "nComboBox4";
			this.nComboBox4.Size = new System.Drawing.Size(192, 40);
			this.nComboBox4.TabIndex = 10;
			this.nComboBox4.Text = "nComboBox4";
			// 
			// nComboBox1
			// 
			this.nComboBox1.ImageList = this.imageList1;
			this.nComboBox1.Location = new System.Drawing.Point(16, 24);
			this.nComboBox1.Name = "nComboBox1";
			this.nComboBox1.Size = new System.Drawing.Size(192, 22);
			this.nComboBox1.TabIndex = 0;
			// 
			// nComboBox2
			// 
			this.nComboBox2.ImageList = this.imageList1;
			this.nComboBox2.Location = new System.Drawing.Point(16, 56);
			this.nComboBox2.Name = "nComboBox2";
			this.nComboBox2.Size = new System.Drawing.Size(192, 22);
			this.nComboBox2.TabIndex = 1;
			this.nComboBox2.Text = "nComboBox2";
			// 
			// nCheckBox1
			// 
			this.nCheckBox1.Checked = true;
			this.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.nCheckBox1.Location = new System.Drawing.Point(8, 256);
			this.nCheckBox1.Name = "nCheckBox1";
			this.nCheckBox1.Size = new System.Drawing.Size(72, 24);
			this.nCheckBox1.TabIndex = 20;
			this.nCheckBox1.Text = "&Enable";
			this.nCheckBox1.CheckedChanged += new System.EventHandler(this.nCheckBox1_CheckedChanged);
			// 
			// nCheckBox2
			// 
			this.nCheckBox2.Location = new System.Drawing.Point(88, 256);
			this.nCheckBox2.Name = "nCheckBox2";
			this.nCheckBox2.Size = new System.Drawing.Size(120, 24);
			this.nCheckBox2.TabIndex = 21;
			this.nCheckBox2.Text = "&Interactive Border";
			this.nCheckBox2.CheckedChanged += new System.EventHandler(this.nCheckBox2_CheckedChanged);
			// 
			// m_PropertyGrid
			// 
			this.m_PropertyGrid.CommandsVisibleIfAvailable = true;
			this.m_PropertyGrid.LargeButtons = false;
			this.m_PropertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.m_PropertyGrid.Location = new System.Drawing.Point(8, 24);
			this.m_PropertyGrid.Name = "m_PropertyGrid";
			this.m_PropertyGrid.Size = new System.Drawing.Size(328, 240);
			this.m_PropertyGrid.TabIndex = 22;
			this.m_PropertyGrid.Text = "propertyGrid1";
			this.m_PropertyGrid.ViewBackColor = System.Drawing.SystemColors.Window;
			this.m_PropertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.nComboBox1);
			this.nGroupBox1.Controls.Add(this.nComboBox2);
			this.nGroupBox1.Controls.Add(this.nComboBox4);
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(8, 8);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(224, 136);
			this.nGroupBox1.TabIndex = 24;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Standard Comboboxes";
			// 
			// nGroupBox2
			// 
			this.nGroupBox2.Controls.Add(this.label2);
			this.nGroupBox2.Controls.Add(this.m_Colors);
			this.nGroupBox2.Controls.Add(this.m_ColorMode);
			this.nGroupBox2.ImageIndex = 0;
			this.nGroupBox2.Location = new System.Drawing.Point(8, 152);
			this.nGroupBox2.Name = "nGroupBox2";
			this.nGroupBox2.Size = new System.Drawing.Size(224, 88);
			this.nGroupBox2.TabIndex = 25;
			this.nGroupBox2.TabStop = false;
			this.nGroupBox2.Text = "Color Combobox";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 23);
			this.label2.TabIndex = 9;
			this.label2.Text = "Colors:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nGroupBox3
			// 
			this.nGroupBox3.Controls.Add(this.m_PropertyGrid);
			this.nGroupBox3.ImageIndex = 0;
			this.nGroupBox3.Location = new System.Drawing.Point(240, 8);
			this.nGroupBox3.Name = "nGroupBox3";
			this.nGroupBox3.Size = new System.Drawing.Size(344, 272);
			this.nGroupBox3.TabIndex = 26;
			this.nGroupBox3.TabStop = false;
			this.nGroupBox3.Text = "List Properties";
			// 
			// NComboBoxesUC
			// 
			this.Controls.Add(this.nGroupBox3);
			this.Controls.Add(this.nGroupBox2);
			this.Controls.Add(this.nGroupBox1);
			this.Controls.Add(this.nCheckBox2);
			this.Controls.Add(this.nCheckBox1);
			this.Name = "NComboBoxesUC";
			this.Size = new System.Drawing.Size(592, 288);
			this.nGroupBox1.ResumeLayout(false);
			this.nGroupBox2.ResumeLayout(false);
			this.nGroupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		
		#region Fields

		private Nevron.UI.WinForm.Controls.NColorComboBox m_Colors;
		private Nevron.UI.WinForm.Controls.NComboBox m_ColorMode;
		private System.Windows.Forms.ImageList imageList1;
		private Nevron.UI.WinForm.Controls.NComboBox nComboBox4;
		private Nevron.UI.WinForm.Controls.NComboBox nComboBox1;
		private Nevron.UI.WinForm.Controls.NComboBox nComboBox2;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox1;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox2;
		private System.Windows.Forms.PropertyGrid m_PropertyGrid;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox3;

		private System.ComponentModel.IContainer components;

		#endregion

		private void nComboBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			Debug.WriteLine("Key press...");
		}
	}
}
