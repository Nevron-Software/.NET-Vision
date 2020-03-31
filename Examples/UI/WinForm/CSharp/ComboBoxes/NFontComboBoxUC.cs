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
	/// Summary description for NFontComboBoxUC.
	/// </summary>
	public class NFontComboBoxUC : NExampleUserControl
	{
		#region Constructor

		public NFontComboBoxUC(MainForm f) : base(f)
		{
			InitializeComponent();

			Dock = DockStyle.Fill;
		}


		#endregion

		#region Overrides

		public override void Initialize()
		{
			base.Initialize ();

			m_FontCombo = new NFontComboBox();
			m_FontCombo.Width = 200;
			m_FontCombo.Location = new Point(m_ComboStyleList.Left, 8);
			m_FontCombo.Parent = this;

			m_ComboStyleList.FillFromEnum(typeof(FontDisplayStyle));
			m_ComboStyleList.SelectedItem = m_FontCombo.DisplayStyle;

			m_AutoSizeCheck.Checked = m_FontCombo.AutoSizeDropDown;
		}


		#endregion

		#region Event Handlers

		private void m_ComboStyleList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_FontCombo.DisplayStyle = (FontDisplayStyle)m_ComboStyleList.SelectedItem;
		}
		private void m_AutoSizeCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			m_FontCombo.AutoSizeDropDown = m_AutoSizeCheck.Checked;
		}


		#endregion

		#region Generated Code
        private void InitializeComponent()
		{
			this.m_ComboStyleList = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_AutoSizeCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// m_ComboStyleList
			// 
			this.m_ComboStyleList.Location = new System.Drawing.Point(80, 56);
			this.m_ComboStyleList.Name = "m_ComboStyleList";
			this.m_ComboStyleList.Size = new System.Drawing.Size(200, 22);
			this.m_ComboStyleList.TabIndex = 0;
			this.m_ComboStyleList.Text = "nComboBox1";
			this.m_ComboStyleList.SelectedIndexChanged += new System.EventHandler(this.m_ComboStyleList_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Style:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_AutoSizeCheck
			// 
			this.m_AutoSizeCheck.Location = new System.Drawing.Point(80, 88);
			this.m_AutoSizeCheck.Name = "m_AutoSizeCheck";
			this.m_AutoSizeCheck.Size = new System.Drawing.Size(200, 24);
			this.m_AutoSizeCheck.TabIndex = 2;
			this.m_AutoSizeCheck.Text = "AutoSize DropDown";
			this.m_AutoSizeCheck.CheckedChanged += new System.EventHandler(this.m_AutoSizeCheck_CheckedChanged);
			// 
			// NFontComboBoxUC
			// 
			this.Controls.Add(this.m_AutoSizeCheck);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_ComboStyleList);
			this.Name = "NFontComboBoxUC";
			this.Size = new System.Drawing.Size(512, 216);
			this.ResumeLayout(false);

		}

		#endregion

		#region Fields

		private Nevron.UI.WinForm.Controls.NComboBox m_ComboStyleList;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NCheckBox m_AutoSizeCheck;
		NFontComboBox m_FontCombo;

		#endregion
	}
}
