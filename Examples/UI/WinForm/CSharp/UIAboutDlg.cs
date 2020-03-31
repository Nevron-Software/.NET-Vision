using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for UIAboutDlg.
	/// </summary>
	public class UIAboutDlg : System.Windows.Forms.Form
	{
		#region Constructor

		public UIAboutDlg()
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

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			SetAboutText();

			NUIManager.ApplyPalette(this);
			BackColor = Color.White;
		}


		#endregion

		#region Implementation

		internal void SetAboutText()
		{
			textBox1.Text = "Nevron User Interface Suite 4.0\r\n"+
				"Copyright 1998-2005 Nevron. All Rights Reserved.\r\n\r\n"+
				"***Compatible Frameworks:***\r\n"+
				"--------------------\r\n"+
				".NET Framework v.1.0\r\n"+
				".NET Framework v.1.1\r\n"+
				"--------------------\r\n"+
				"***Compatible Platforms:***\r\n"+
				"--------------------\r\n"+
				"Microsoft Windows NT\r\n"+
				"Microsoft Windows 2000\r\n"+
				"Microsoft Windows XP\r\n"+
				"--------------------\r\n"+
				"***Compatible Environments***\r\n"+
				"--------------------\r\n"+
				"Microsoft Visual Studio .NET\r\n"+
				"Microsoft Visual C# .NET\r\n"+
				"Microsoft Visual C++ .NET\r\n"+
				"Microsoft Visual Basic .NET";

			textBox1.SelectionLength = 0;
		}


		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(UIAboutDlg));
			this.textBox1 = new Nevron.UI.WinForm.Controls.NTextBox();
			this.m_OKButton = new Nevron.UI.WinForm.Controls.NButton();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(8, 120);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(304, 168);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// m_OKButton
			// 
			this.m_OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.m_OKButton.Location = new System.Drawing.Point(232, 296);
			this.m_OKButton.Name = "m_OKButton";
			this.m_OKButton.Size = new System.Drawing.Size(80, 23);
			this.m_OKButton.TabIndex = 0;
			this.m_OKButton.Text = "&OK";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(200, 98);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// UIAboutDlg
			// 
			this.AcceptButton = this.m_OKButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(322, 328);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.m_OKButton);
			this.Controls.Add(this.textBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "UIAboutDlg";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Nevron User Interface Suite 4.0";
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		private NTextBox textBox1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private NButton m_OKButton;

		#endregion
	}
}
