using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NTranslucentWindowUC.
	/// </summary>
	public class NTranslucentWindowUC : NExampleUserControl
	{
		#region Constructor

		public NTranslucentWindowUC(MainForm f) : base(f)
		{
			InitializeComponent();

			m_PictureBox.Image = f.Config.SplashImage;
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

				if(m_LayeredWindow != null)
					m_LayeredWindow.Dispose();
			}
			base.Dispose( disposing );
		}


		#endregion

		#region Event Handlers

		private void m_LoadImageButton_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select Image:";
			ofd.Filter = NUIManager.AllImageFilesFilter;

			if(ofd.ShowDialog() != DialogResult.OK)
				return;

			m_PictureBox.Image = Image.FromFile(ofd.FileName);
		}

		private void m_ShowWindowButton_Click(object sender, System.EventArgs e)
		{
			if(m_PictureBox.Image == null || m_LayeredWindow != null)
				return;

			m_LayeredWindow = new NLayeredWindow();
			m_LayeredWindow.Moveable = m_MoveableCheckBox.Checked;
			m_LayeredWindow.BackgroundImage = m_PictureBox.Image;
			m_LayeredWindow.ShowWindow(NUISystem.GetCenterScreenLocation(m_LayeredWindow.BackgroundImage.Size));
		}

		private void m_CloseWindowButton_Click(object sender, System.EventArgs e)
		{
			if(m_LayeredWindow == null)
				return;

			m_LayeredWindow.Dispose();
			m_LayeredWindow = null;
		}

		private void m_MoveableCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if(m_LayeredWindow != null)
				m_LayeredWindow.Moveable = m_MoveableCheckBox.Checked;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_ShowWindowButton = new Nevron.UI.WinForm.Controls.NButton();
			this.m_LoadImageButton = new Nevron.UI.WinForm.Controls.NButton();
			this.m_PictureBox = new System.Windows.Forms.PictureBox();
			this.m_CloseWindowButton = new Nevron.UI.WinForm.Controls.NButton();
			this.m_MoveableCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// m_ShowWindowButton
			// 
			this.m_ShowWindowButton.Location = new System.Drawing.Point(8, 248);
			this.m_ShowWindowButton.Name = "m_ShowWindowButton";
			this.m_ShowWindowButton.Size = new System.Drawing.Size(112, 24);
			this.m_ShowWindowButton.TabIndex = 0;
			this.m_ShowWindowButton.Text = "Show Window";
			this.m_ShowWindowButton.Click += new System.EventHandler(this.m_ShowWindowButton_Click);
			// 
			// m_LoadImageButton
			// 
			this.m_LoadImageButton.Location = new System.Drawing.Point(8, 208);
			this.m_LoadImageButton.Name = "m_LoadImageButton";
			this.m_LoadImageButton.Size = new System.Drawing.Size(112, 24);
			this.m_LoadImageButton.TabIndex = 1;
			this.m_LoadImageButton.Text = "Load Image...";
			this.m_LoadImageButton.Click += new System.EventHandler(this.m_LoadImageButton_Click);
			// 
			// m_PictureBox
			// 
			this.m_PictureBox.BackColor = System.Drawing.Color.White;
			this.m_PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_PictureBox.Location = new System.Drawing.Point(8, 8);
			this.m_PictureBox.Name = "m_PictureBox";
			this.m_PictureBox.Size = new System.Drawing.Size(232, 192);
			this.m_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_PictureBox.TabIndex = 2;
			this.m_PictureBox.TabStop = false;
			// 
			// m_CloseWindowButton
			// 
			this.m_CloseWindowButton.Location = new System.Drawing.Point(128, 248);
			this.m_CloseWindowButton.Name = "m_CloseWindowButton";
			this.m_CloseWindowButton.Size = new System.Drawing.Size(112, 24);
			this.m_CloseWindowButton.TabIndex = 3;
			this.m_CloseWindowButton.Text = "Close Window";
			this.m_CloseWindowButton.Click += new System.EventHandler(this.m_CloseWindowButton_Click);
			// 
			// m_MoveableCheckBox
			// 
			this.m_MoveableCheckBox.Checked = true;
			this.m_MoveableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_MoveableCheckBox.Location = new System.Drawing.Point(8, 280);
			this.m_MoveableCheckBox.Name = "m_MoveableCheckBox";
			this.m_MoveableCheckBox.TabIndex = 4;
			this.m_MoveableCheckBox.Text = "Moveable";
			this.m_MoveableCheckBox.CheckedChanged += new System.EventHandler(this.m_MoveableCheckBox_CheckedChanged);
			// 
			// NTranslucentWindowUC
			// 
			this.Controls.Add(this.m_MoveableCheckBox);
			this.Controls.Add(this.m_CloseWindowButton);
			this.Controls.Add(this.m_PictureBox);
			this.Controls.Add(this.m_LoadImageButton);
			this.Controls.Add(this.m_ShowWindowButton);
			this.Name = "NTranslucentWindowUC";
			this.Size = new System.Drawing.Size(248, 312);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		internal NLayeredWindow m_LayeredWindow;

		private Nevron.UI.WinForm.Controls.NButton m_ShowWindowButton;
		private Nevron.UI.WinForm.Controls.NButton m_LoadImageButton;
		private Nevron.UI.WinForm.Controls.NButton m_CloseWindowButton;
		private Nevron.UI.WinForm.Controls.NCheckBox m_MoveableCheckBox;
		private System.Windows.Forms.PictureBox m_PictureBox;

		#endregion
	}
}
