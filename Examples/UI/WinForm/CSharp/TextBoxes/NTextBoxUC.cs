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
	public class NTextBoxUC : NExampleUserControl
	{
		#region Constructor

		public NTextBoxUC(MainForm f) : base(f)
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

			m_InputModeCombo.FillFromEnum(typeof(TextBoxInputMode), false);
			m_InputModeCombo.SelectedItem = TextBoxInputMode.Default;

			m_ShowErrorMessage.Checked = false;
		}

		

		#endregion

		#region Event Handlers

		private void nCheckBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			foreach(Control c in Controls)
			{
				if(c is NTextBox)
					c.Enabled = this.nCheckBox1.Checked;
			}
		}
		private void nCheckBox2_CheckedChanged(object sender, System.EventArgs e)
		{
		}
		private void nCheckBox3_CheckedChanged(object sender, System.EventArgs e)
		{
		}


		private void m_BorderButton_Click(object sender, System.EventArgs e)
		{
			nTextBox1.Border.ShowEditor();
			nTextBox2.Border.Copy(nTextBox1.Border);
			nTextBox3.Border.Copy(nTextBox1.Border);
		}

		private void m_InputModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NTextBox tb;
			int count = Controls.Count;

			for(int i = 0; i < count; i++)
			{
				tb = Controls[i] as NTextBox;
                if (tb != null)
                {
                    tb.InputMode = (TextBoxInputMode)m_InputModeCombo.SelectedItem;
                }
			}
		}

		private void m_ShowErrorMessage_CheckedChanged(object sender, System.EventArgs e)
		{
			NTextBox tb;
			int count = Controls.Count;

			for(int i = 0; i < count; i++)
			{
				tb = Controls[i] as NTextBox;
                if (tb != null)
                {
                    tb.DisplayErrorMessage = m_ShowErrorMessage.Checked;
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
			this.nTextBox1 = new Nevron.UI.WinForm.Controls.NTextBox();
			this.nTextBox2 = new Nevron.UI.WinForm.Controls.NTextBox();
			this.nCheckBox1 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_BorderButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label1 = new System.Windows.Forms.Label();
			this.m_InputModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nTextBox3 = new Nevron.UI.WinForm.Controls.NTextBox();
			this.m_ShowErrorMessage = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// nTextBox1
			// 
			this.nTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.nTextBox1.Location = new System.Drawing.Point(8, 8);
			this.nTextBox1.Name = "nTextBox1";
			this.nTextBox1.Size = new System.Drawing.Size(320, 20);
			this.nTextBox1.TabIndex = 0;
			this.nTextBox1.Text = "";
			// 
			// nTextBox2
			// 
			this.nTextBox2.AcceptsReturn = true;
			this.nTextBox2.AcceptsTab = true;
			this.nTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.nTextBox2.Location = new System.Drawing.Point(8, 72);
			this.nTextBox2.Multiline = true;
			this.nTextBox2.Name = "nTextBox2";
			this.nTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.nTextBox2.Size = new System.Drawing.Size(320, 216);
			this.nTextBox2.TabIndex = 1;
			this.nTextBox2.Text = "Multi-line text box. Right-click to see the custom context menu.";
			// 
			// nCheckBox1
			// 
			this.nCheckBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.nCheckBox1.Checked = true;
			this.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.nCheckBox1.Location = new System.Drawing.Point(8, 304);
			this.nCheckBox1.Name = "nCheckBox1";
			this.nCheckBox1.Size = new System.Drawing.Size(72, 24);
			this.nCheckBox1.TabIndex = 22;
			this.nCheckBox1.Text = "&Enable";
			this.nCheckBox1.CheckedChanged += new System.EventHandler(this.nCheckBox1_CheckedChanged);
			// 
			// m_BorderButton
			// 
			this.m_BorderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_BorderButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_BorderButton.Location = new System.Drawing.Point(184, 304);
			this.m_BorderButton.Name = "m_BorderButton";
			this.m_BorderButton.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable | Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes)));
			this.m_BorderButton.Size = new System.Drawing.Size(104, 24);
			this.m_BorderButton.TabIndex = 23;
			this.m_BorderButton.Text = "Border...";
			this.m_BorderButton.Click += new System.EventHandler(this.m_BorderButton_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.Location = new System.Drawing.Point(8, 336);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 25;
			this.label1.Text = "Input Mode:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_InputModeCombo
			// 
			this.m_InputModeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_InputModeCombo.ListProperties.ColumnOnLeft = false;
			this.m_InputModeCombo.Location = new System.Drawing.Point(88, 336);
			this.m_InputModeCombo.Name = "m_InputModeCombo";
			this.m_InputModeCombo.Size = new System.Drawing.Size(200, 21);
			this.m_InputModeCombo.TabIndex = 26;
			this.m_InputModeCombo.SelectedIndexChanged += new System.EventHandler(this.m_InputModeCombo_SelectedIndexChanged);
			// 
			// nTextBox3
			// 
			this.nTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.nTextBox3.Location = new System.Drawing.Point(8, 40);
			this.nTextBox3.Name = "nTextBox3";
			this.nTextBox3.Size = new System.Drawing.Size(320, 20);
			this.nTextBox3.TabIndex = 24;
			this.nTextBox3.Text = "";
			// 
			// m_ShowErrorMessage
			// 
			this.m_ShowErrorMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_ShowErrorMessage.Checked = true;
			this.m_ShowErrorMessage.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_ShowErrorMessage.Location = new System.Drawing.Point(80, 304);
			this.m_ShowErrorMessage.Name = "m_ShowErrorMessage";
			this.m_ShowErrorMessage.Size = new System.Drawing.Size(96, 24);
			this.m_ShowErrorMessage.TabIndex = 27;
			this.m_ShowErrorMessage.Text = "Error Message";
			this.m_ShowErrorMessage.CheckedChanged += new System.EventHandler(this.m_ShowErrorMessage_CheckedChanged);
			// 
			// NTextBoxUC
			// 
			this.Controls.Add(this.m_ShowErrorMessage);
			this.Controls.Add(this.m_InputModeCombo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.nTextBox3);
			this.Controls.Add(this.m_BorderButton);
			this.Controls.Add(this.nCheckBox1);
			this.Controls.Add(this.nTextBox2);
			this.Controls.Add(this.nTextBox1);
			this.Name = "NTextBoxUC";
			this.Size = new System.Drawing.Size(336, 368);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		private Nevron.UI.WinForm.Controls.NTextBox nTextBox1;
		private Nevron.UI.WinForm.Controls.NTextBox nTextBox2;
		private Nevron.UI.WinForm.Controls.NButton m_BorderButton;
		private System.Windows.Forms.Label label1;
		private NComboBox m_InputModeCombo;
		private Nevron.UI.WinForm.Controls.NTextBox nTextBox3;
		private Nevron.UI.WinForm.Controls.NCheckBox m_ShowErrorMessage;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox1;

		#endregion
	}
}
