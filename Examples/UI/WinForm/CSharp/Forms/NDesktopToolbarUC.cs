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
	/// Summary description for NDesktopToolbarUC.
	/// </summary>
	public class NDesktopToolbarUC : NExampleUserControl
	{
		#region Constructor

		public NDesktopToolbarUC(MainForm f) : base(f)
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

				if(m_Toolbar != null)
					m_Toolbar.Dispose();
			}
			base.Dispose( disposing );
		}

		public override void Initialize()
		{
			base.Initialize ();

			m_Toolbar = new NDesktopToolbar();
			m_Toolbar.Text = "Desktop Toolbar Demo";
            NDesktopToolbarContentUC content = new NDesktopToolbarContentUC();

			content.Dock = DockStyle.Fill;
			content.Parent = m_Toolbar;

			m_DockStyleCombo.FillFromEnum(typeof(DockStyle));
			m_DockStyleCombo.Items.Remove(DockStyle.Fill);
			m_DockStyleCombo.SelectedItem = DockStyle.Right;
		}


		#endregion

		#region Event Handlers

		private void m_DockStyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		}
		private void m_ApplyButton_Click(object sender, System.EventArgs e)
		{
			DockStyle dockStyle = (DockStyle)m_DockStyleCombo.SelectedItem;
			m_Toolbar.Owner = dockStyle == DockStyle.None ? m_MainForm : null;

			m_Toolbar.Dock = dockStyle;

			if(m_bToolbarShown)
				return;

			m_Toolbar.Palette.Copy(NUIManager.Palette);
            m_Toolbar.Show();
			m_bToolbarShown = true;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_DockStyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_ApplyButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// m_DockStyleCombo
			// 
			this.m_DockStyleCombo.Location = new System.Drawing.Point(16, 32);
			this.m_DockStyleCombo.Name = "m_DockStyleCombo";
			this.m_DockStyleCombo.Size = new System.Drawing.Size(232, 22);
			this.m_DockStyleCombo.TabIndex = 0;
			this.m_DockStyleCombo.Text = "nComboBox1";
			this.m_DockStyleCombo.SelectedIndexChanged += new System.EventHandler(this.m_DockStyleCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.TabIndex = 1;
			this.label1.Text = "Select Dock Edge:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_ApplyButton
			// 
			this.m_ApplyButton.Location = new System.Drawing.Point(16, 64);
			this.m_ApplyButton.Name = "m_ApplyButton";
			this.m_ApplyButton.Size = new System.Drawing.Size(80, 24);
			this.m_ApplyButton.TabIndex = 2;
			this.m_ApplyButton.Text = "Apply";
			this.m_ApplyButton.Click += new System.EventHandler(this.m_ApplyButton_Click);
			// 
			// NDesktopToolbarUC
			// 
			this.Controls.Add(this.m_ApplyButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_DockStyleCombo);
			this.Name = "NDesktopToolbarUC";
			this.Size = new System.Drawing.Size(360, 240);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		internal NDesktopToolbar m_Toolbar;
		internal bool m_bToolbarShown;
		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NComboBox m_DockStyleCombo;
		private Nevron.UI.WinForm.Controls.NButton m_ApplyButton;
		private System.Windows.Forms.Label label1;

		#endregion
	}
}
