using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI;
using Nevron.UI.WinForm;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NPopupDropDownUC.
	/// </summary>
	public class NPopupDropDownUC : NExampleUserControl
	{
		#region Constructor

		public NPopupDropDownUC()
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

		public override void Initialize()
		{
			base.Initialize ();

			FillCombos();

			m_DropDownControl = GetDropDownControl();
			if(m_DropDownControl == null)
				return;

			InitFromDropDown();
		}


		#endregion

		#region Internal Implementation

		internal virtual NPopupDropDownControl GetDropDownControl()
		{
			return null;
		}
		internal void FillCombos()
		{
			sizeStyleCombo.FillFromEnum(typeof(PopupSizeStyle));
			directionCombo.FillFromEnum(typeof(Direction));
			halignCombo.FillFromEnum(typeof(PopupHAlignment));
			valignCombo.FillFromEnum(typeof(PopupVAlignment));
		}
		internal void InitFromDropDown()
		{
			NPopup p = m_DropDownControl.Popup;

			directionCombo.SelectedItem = m_DropDownControl.DropDownDirection;
			sizeStyleCombo.SelectedItem = p.SizeStyle;
			halignCombo.SelectedItem = p.PlacementInfo.HAlign;
			valignCombo.SelectedItem = p.PlacementInfo.VAlign;

			useDefPlacementCheck.Checked = m_DropDownControl.UseDefaultPopupPlacement;
			fadeInCheck.Checked = p.AnimationInfo.FadeIn;
			fadeOutCheck.Checked = p.AnimationInfo.FadeOut;
		}


		#endregion

		#region Event Handlers

		private void directionCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_DropDownControl == null)
				return;

			m_DropDownControl.DropDownDirection = (Direction)directionCombo.SelectedItem;
		}
		private void sizeStyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_DropDownControl == null)
				return;

			m_DropDownControl.Popup.SizeStyle = (PopupSizeStyle)sizeStyleCombo.SelectedItem;
		}
		private void halignCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_DropDownControl == null)
				return;

			m_DropDownControl.Popup.PlacementInfo.HAlign = (PopupHAlignment)halignCombo.SelectedItem;
		}
		private void valignCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_DropDownControl == null)
				return;

			m_DropDownControl.Popup.PlacementInfo.VAlign = (PopupVAlignment)valignCombo.SelectedItem;
		}
		private void useDefPlacementCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if(m_DropDownControl == null)
				return;

			bool isChecked = useDefPlacementCheck.Checked;
			m_DropDownControl.UseDefaultPopupPlacement = isChecked;

			bool enable = !isChecked;

			nEntryContainer2.Enabled = enable;
			nEntryContainer3.Enabled = enable;

			if(!enable)
				return;

			m_DropDownControl.Popup.PlacementInfo.HAlign = (PopupHAlignment)halignCombo.SelectedItem;
			m_DropDownControl.Popup.PlacementInfo.VAlign = (PopupVAlignment)valignCombo.SelectedItem;
		}
		private void fadeInCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if(m_DropDownControl == null)
				return;

			NPopupAnimationInfo info = m_DropDownControl.Popup.AnimationInfo;
			info.FadeIn = fadeInCheck.Checked;

			m_DropDownControl.Popup.AnimationInfo = info;
		}
		private void fadeOutCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if(m_DropDownControl == null)
				return;

			NPopupAnimationInfo info = m_DropDownControl.Popup.AnimationInfo;
			info.FadeOut = fadeOutCheck.Checked;

			m_DropDownControl.Popup.AnimationInfo = info;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.popupInstancePanel = new System.Windows.Forms.Panel();
			this.propertiesPanel = new System.Windows.Forms.Panel();
			this.nEntryContainer4 = new Nevron.UI.WinForm.Controls.NEntryContainer();
			this.sizeStyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.fadeOutCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.fadeInCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.useDefPlacementCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nEntryContainer3 = new Nevron.UI.WinForm.Controls.NEntryContainer();
			this.valignCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nEntryContainer2 = new Nevron.UI.WinForm.Controls.NEntryContainer();
			this.halignCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nEntryContainer1 = new Nevron.UI.WinForm.Controls.NEntryContainer();
			this.directionCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.propertiesPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer4)).BeginInit();
			this.nEntryContainer4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer3)).BeginInit();
			this.nEntryContainer3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer2)).BeginInit();
			this.nEntryContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer1)).BeginInit();
			this.nEntryContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// popupInstancePanel
			// 
			this.popupInstancePanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.popupInstancePanel.Location = new System.Drawing.Point(0, 0);
			this.popupInstancePanel.Name = "popupInstancePanel";
			this.popupInstancePanel.Size = new System.Drawing.Size(336, 40);
			this.popupInstancePanel.TabIndex = 2;
			// 
			// propertiesPanel
			// 
			this.propertiesPanel.Controls.Add(this.nEntryContainer4);
			this.propertiesPanel.Controls.Add(this.fadeOutCheck);
			this.propertiesPanel.Controls.Add(this.fadeInCheck);
			this.propertiesPanel.Controls.Add(this.useDefPlacementCheck);
			this.propertiesPanel.Controls.Add(this.nEntryContainer3);
			this.propertiesPanel.Controls.Add(this.nEntryContainer2);
			this.propertiesPanel.Controls.Add(this.nEntryContainer1);
			this.propertiesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertiesPanel.Location = new System.Drawing.Point(0, 40);
			this.propertiesPanel.Name = "propertiesPanel";
			this.propertiesPanel.Size = new System.Drawing.Size(336, 224);
			this.propertiesPanel.TabIndex = 1;
			// 
			// nEntryContainer4
			// 
			this.nEntryContainer4.ClientPadding = new Nevron.UI.NPadding(2);
			this.nEntryContainer4.EntryControl = this.sizeStyleCombo;
			this.nEntryContainer4.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.nEntryContainer4.LabelSize = new System.Drawing.Size(120, 0);
			this.nEntryContainer4.Location = new System.Drawing.Point(8, 40);
			this.nEntryContainer4.Name = "nEntryContainer4";
			this.nEntryContainer4.Size = new System.Drawing.Size(320, 32);
			this.nEntryContainer4.TabIndex = 6;
			this.nEntryContainer4.Text = "Size style:";
			// 
			// sizeStyleCombo
			// 
			this.sizeStyleCombo.Location = new System.Drawing.Point(129, 3);
			this.sizeStyleCombo.Name = "sizeStyleCombo";
			this.sizeStyleCombo.Size = new System.Drawing.Size(183, 21);
			this.sizeStyleCombo.TabIndex = 1;
			this.sizeStyleCombo.Text = "nComboBox1";
			this.sizeStyleCombo.SelectedIndexChanged += new System.EventHandler(this.sizeStyleCombo_SelectedIndexChanged);
			// 
			// fadeOutCheck
			// 
			this.fadeOutCheck.ButtonProperties.BorderOffset = 2;
			this.fadeOutCheck.Checked = true;
			this.fadeOutCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.fadeOutCheck.Location = new System.Drawing.Point(136, 192);
			this.fadeOutCheck.Name = "fadeOutCheck";
			this.fadeOutCheck.Size = new System.Drawing.Size(192, 24);
			this.fadeOutCheck.TabIndex = 5;
			this.fadeOutCheck.Text = "Fade out";
			this.fadeOutCheck.CheckedChanged += new System.EventHandler(this.fadeOutCheck_CheckedChanged);
			// 
			// fadeInCheck
			// 
			this.fadeInCheck.ButtonProperties.BorderOffset = 2;
			this.fadeInCheck.Checked = true;
			this.fadeInCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.fadeInCheck.Location = new System.Drawing.Point(136, 168);
			this.fadeInCheck.Name = "fadeInCheck";
			this.fadeInCheck.Size = new System.Drawing.Size(192, 24);
			this.fadeInCheck.TabIndex = 4;
			this.fadeInCheck.Text = "Fade in";
			this.fadeInCheck.CheckedChanged += new System.EventHandler(this.fadeInCheck_CheckedChanged);
			// 
			// useDefPlacementCheck
			// 
			this.useDefPlacementCheck.ButtonProperties.BorderOffset = 2;
			this.useDefPlacementCheck.Checked = true;
			this.useDefPlacementCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.useDefPlacementCheck.Location = new System.Drawing.Point(136, 144);
			this.useDefPlacementCheck.Name = "useDefPlacementCheck";
			this.useDefPlacementCheck.Size = new System.Drawing.Size(192, 24);
			this.useDefPlacementCheck.TabIndex = 3;
			this.useDefPlacementCheck.Text = "Use default placement";
			this.useDefPlacementCheck.CheckedChanged += new System.EventHandler(this.useDefPlacementCheck_CheckedChanged);
			// 
			// nEntryContainer3
			// 
			this.nEntryContainer3.ClientPadding = new Nevron.UI.NPadding(2);
			this.nEntryContainer3.Enabled = false;
			this.nEntryContainer3.EntryControl = this.valignCombo;
			this.nEntryContainer3.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.nEntryContainer3.LabelSize = new System.Drawing.Size(120, 0);
			this.nEntryContainer3.Location = new System.Drawing.Point(8, 104);
			this.nEntryContainer3.Name = "nEntryContainer3";
			this.nEntryContainer3.Size = new System.Drawing.Size(320, 32);
			this.nEntryContainer3.TabIndex = 2;
			this.nEntryContainer3.Text = "VAlign:";
			// 
			// valignCombo
			// 
			this.valignCombo.Location = new System.Drawing.Point(129, 3);
			this.valignCombo.Name = "valignCombo";
			this.valignCombo.Size = new System.Drawing.Size(183, 21);
			this.valignCombo.TabIndex = 1;
			this.valignCombo.Text = "nComboBox1";
			this.valignCombo.SelectedIndexChanged += new System.EventHandler(this.valignCombo_SelectedIndexChanged);
			// 
			// nEntryContainer2
			// 
			this.nEntryContainer2.ClientPadding = new Nevron.UI.NPadding(2);
			this.nEntryContainer2.Enabled = false;
			this.nEntryContainer2.EntryControl = this.halignCombo;
			this.nEntryContainer2.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.nEntryContainer2.LabelSize = new System.Drawing.Size(120, 0);
			this.nEntryContainer2.Location = new System.Drawing.Point(8, 72);
			this.nEntryContainer2.Name = "nEntryContainer2";
			this.nEntryContainer2.Size = new System.Drawing.Size(320, 32);
			this.nEntryContainer2.TabIndex = 1;
			this.nEntryContainer2.Text = "HAlign:";
			// 
			// halignCombo
			// 
			this.halignCombo.Location = new System.Drawing.Point(129, 3);
			this.halignCombo.Name = "halignCombo";
			this.halignCombo.Size = new System.Drawing.Size(183, 21);
			this.halignCombo.TabIndex = 1;
			this.halignCombo.Text = "nComboBox1";
			this.halignCombo.SelectedIndexChanged += new System.EventHandler(this.halignCombo_SelectedIndexChanged);
			// 
			// nEntryContainer1
			// 
			this.nEntryContainer1.ClientPadding = new Nevron.UI.NPadding(2);
			this.nEntryContainer1.EntryControl = this.directionCombo;
			this.nEntryContainer1.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.nEntryContainer1.LabelSize = new System.Drawing.Size(120, 0);
			this.nEntryContainer1.Location = new System.Drawing.Point(8, 8);
			this.nEntryContainer1.Name = "nEntryContainer1";
			this.nEntryContainer1.Size = new System.Drawing.Size(320, 32);
			this.nEntryContainer1.TabIndex = 0;
			this.nEntryContainer1.Text = "Drop-down direction:";
			// 
			// directionCombo
			// 
			this.directionCombo.Location = new System.Drawing.Point(129, 3);
			this.directionCombo.Name = "directionCombo";
			this.directionCombo.Size = new System.Drawing.Size(183, 21);
			this.directionCombo.TabIndex = 1;
			this.directionCombo.Text = "nComboBox1";
			this.directionCombo.SelectedIndexChanged += new System.EventHandler(this.directionCombo_SelectedIndexChanged);
			// 
			// NPopupDropDownUC
			// 
			this.Controls.Add(this.propertiesPanel);
			this.Controls.Add(this.popupInstancePanel);
			this.Name = "NPopupDropDownUC";
			this.Size = new System.Drawing.Size(336, 264);
			this.propertiesPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer4)).EndInit();
			this.nEntryContainer4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer3)).EndInit();
			this.nEntryContainer3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer2)).EndInit();
			this.nEntryContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nEntryContainer1)).EndInit();
			this.nEntryContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		internal NPopupDropDownControl m_DropDownControl;

		private System.ComponentModel.Container components = null;
		protected System.Windows.Forms.Panel popupInstancePanel;
		private System.Windows.Forms.Panel propertiesPanel;
		private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer1;
		private Nevron.UI.WinForm.Controls.NComboBox directionCombo;
		private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer2;
		private Nevron.UI.WinForm.Controls.NComboBox halignCombo;
		private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer3;
		private Nevron.UI.WinForm.Controls.NCheckBox fadeOutCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox fadeInCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox useDefPlacementCheck;
		private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer4;
		private Nevron.UI.WinForm.Controls.NComboBox sizeStyleCombo;
		private Nevron.UI.WinForm.Controls.NComboBox valignCombo;

		#endregion
	}
}
