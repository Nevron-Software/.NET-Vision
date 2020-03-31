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
	/// Summary description for NRichTextBoxUC.
	/// </summary>
	public class NRichTextBoxUC : NExampleUserControl
	{
		#region Constructor

		public NRichTextBoxUC(MainForm f) : base(f)
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

			nCheckBox1.Checked = richTextBox1.Enabled;
		}
		

		#endregion

		#region Event Handlers

		private void nCheckBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			richTextBox1.Enabled = nCheckBox1.Checked;
		}

		private void m_BorderButton_Click(object sender, System.EventArgs e)
		{
			richTextBox1.Border.ShowEditor();
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.richTextBox1 = new Nevron.UI.WinForm.Controls.NRichTextBox();
			this.m_BorderButton = new Nevron.UI.WinForm.Controls.NButton();
			this.nCheckBox1 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox1.Location = new System.Drawing.Point(8, 8);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(288, 208);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			// 
			// m_BorderButton
			// 
			this.m_BorderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_BorderButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_BorderButton.Location = new System.Drawing.Point(88, 224);
			this.m_BorderButton.Name = "m_BorderButton";
			this.m_BorderButton.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable | Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes)));
			this.m_BorderButton.Size = new System.Drawing.Size(104, 24);
			this.m_BorderButton.TabIndex = 25;
			this.m_BorderButton.Text = "Border...";
			this.m_BorderButton.Click += new System.EventHandler(this.m_BorderButton_Click);
			// 
			// nCheckBox1
			// 
			this.nCheckBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.nCheckBox1.Checked = true;
			this.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.nCheckBox1.Location = new System.Drawing.Point(8, 224);
			this.nCheckBox1.Name = "nCheckBox1";
			this.nCheckBox1.Size = new System.Drawing.Size(72, 24);
			this.nCheckBox1.TabIndex = 24;
			this.nCheckBox1.Text = "&Enable";
			this.nCheckBox1.CheckedChanged += new System.EventHandler(this.nCheckBox1_CheckedChanged);
			// 
			// NRichTextBoxUC
			// 
			this.Controls.Add(this.m_BorderButton);
			this.Controls.Add(this.nCheckBox1);
			this.Controls.Add(this.richTextBox1);
			this.Name = "NRichTextBoxUC";
			this.Size = new System.Drawing.Size(304, 256);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NButton m_BorderButton;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox1;

		private NRichTextBox richTextBox1;

		#endregion
	}
}
