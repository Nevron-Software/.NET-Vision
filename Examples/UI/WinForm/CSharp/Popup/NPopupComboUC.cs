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
	/// Summary description for NPopupComboUC.
	/// </summary>
	public class NPopupComboUC : NPopupDropDownUC
	{
		#region Constructor

		public NPopupComboUC()
		{
			InitializeComponent();

            nPopupCombo2.Text = "Drop-down explorer bar";
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


		#endregion

		#region Internal Implementation

		internal override NPopupDropDownControl GetDropDownControl()
		{
			return nPopupCombo2;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NPopupComboUC));
			this.nPopupCombo2 = new Nevron.UI.WinForm.Controls.NPopupCombo();
			this.nPopup1 = new Nevron.UI.WinForm.Controls.NPopup();
			this.nExplorerBar1 = new Nevron.UI.WinForm.Controls.NExplorerBar();
			this.nExpander5 = new Nevron.UI.WinForm.Controls.NExpander();
			this.nRichTextLabel10 = new Nevron.UI.WinForm.Controls.NRichTextLabel();
			this.nRichTextLabel11 = new Nevron.UI.WinForm.Controls.NRichTextLabel();
			this.nRichTextLabel12 = new Nevron.UI.WinForm.Controls.NRichTextLabel();
			this.nExpander4 = new Nevron.UI.WinForm.Controls.NExpander();
			this.nRichTextLabel7 = new Nevron.UI.WinForm.Controls.NRichTextLabel();
			this.nRichTextLabel8 = new Nevron.UI.WinForm.Controls.NRichTextLabel();
			this.nRichTextLabel9 = new Nevron.UI.WinForm.Controls.NRichTextLabel();
			this.nExpander6 = new Nevron.UI.WinForm.Controls.NExpander();
			this.nRichTextLabel13 = new Nevron.UI.WinForm.Controls.NRichTextLabel();
			this.popupInstancePanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nExplorerBar1)).BeginInit();
			this.nExplorerBar1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nExpander5)).BeginInit();
			this.nExpander5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel10)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel11)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel12)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nExpander4)).BeginInit();
			this.nExpander4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel8)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel9)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nExpander6)).BeginInit();
			this.nExpander6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel13)).BeginInit();
			this.SuspendLayout();
			// 
			// popupInstancePanel
			// 
			this.popupInstancePanel.Controls.Add(this.nExplorerBar1);
			this.popupInstancePanel.Controls.Add(this.nPopupCombo2);
			this.popupInstancePanel.Name = "popupInstancePanel";
			// 
			// nPopupCombo2
			// 
			this.nPopupCombo2.Location = new System.Drawing.Point(8, 8);
			this.nPopupCombo2.Name = "nPopupCombo2";
			this.nPopupCombo2.Popup = this.nPopup1;
			this.nPopupCombo2.Size = new System.Drawing.Size(312, 24);
			this.nPopupCombo2.TabIndex = 0;
			this.nPopupCombo2.Text = "nPopupCombo2";
			// 
			// nPopup1
			// 
			this.nPopup1.HostedControl = this.nExplorerBar1;
			this.nPopup1.Size = new Nevron.GraphicsCore.NSize(204, 316);
			this.nPopup1.SizeStyle = Nevron.UI.PopupSizeStyle.Bottom;
			// 
			// nExplorerBar1
			// 
			this.nExplorerBar1.ClientPadding = new Nevron.UI.NPadding(8);
			this.nExplorerBar1.Controls.Add(this.nExpander5);
			this.nExplorerBar1.Controls.Add(this.nExpander4);
			this.nExplorerBar1.Controls.Add(this.nExpander6);
			this.nExplorerBar1.Location = new System.Drawing.Point(8, 32);
			this.nExplorerBar1.Name = "nExplorerBar1";
			this.nExplorerBar1.Size = new System.Drawing.Size(200, 300);
			this.nExplorerBar1.TabIndex = 8;
			this.nExplorerBar1.Text = "nExplorerBar1";
			this.nExplorerBar1.Visible = false;
			// 
			// nExpander5
			// 
			this.nExpander5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(214)), ((System.Byte)(223)), ((System.Byte)(247)));
			this.nExpander5.Controls.Add(this.nRichTextLabel10);
			this.nExpander5.Controls.Add(this.nRichTextLabel11);
			this.nExpander5.Controls.Add(this.nRichTextLabel12);
			this.nExpander5.Location = new System.Drawing.Point(8, 8);
			this.nExpander5.Name = "nExpander5";
			this.nExpander5.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
			this.nExpander5.Size = new System.Drawing.Size(184, 104);
			this.nExpander5.TabIndex = 6;
			this.nExpander5.Text = "Other Places";
			// 
			// nRichTextLabel10
			// 
			this.nRichTextLabel10.BackColor = System.Drawing.Color.Transparent;
			this.nRichTextLabel10.FillInfo.Draw = false;
			this.nRichTextLabel10.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(33)), ((System.Byte)(93)), ((System.Byte)(198)));
			this.nRichTextLabel10.Item.Image = ((System.Drawing.Image)(resources.GetObject("nRichTextLabel10.Item.Image")));
			this.nRichTextLabel10.Item.ImageTextSpacing = 8;
			this.nRichTextLabel10.Location = new System.Drawing.Point(8, 75);
			this.nRichTextLabel10.Name = "nRichTextLabel10";
			this.nRichTextLabel10.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
			this.nRichTextLabel10.ShadowInfo.Draw = false;
			this.nRichTextLabel10.Size = new System.Drawing.Size(128, 24);
			this.nRichTextLabel10.StrokeInfo.Draw = false;
			this.nRichTextLabel10.TabIndex = 5;
			this.nRichTextLabel10.Text = "Control Panel";
			// 
			// nRichTextLabel11
			// 
			this.nRichTextLabel11.BackColor = System.Drawing.Color.Transparent;
			this.nRichTextLabel11.FillInfo.Draw = false;
			this.nRichTextLabel11.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(33)), ((System.Byte)(93)), ((System.Byte)(198)));
			this.nRichTextLabel11.Item.Image = ((System.Drawing.Image)(resources.GetObject("nRichTextLabel11.Item.Image")));
			this.nRichTextLabel11.Item.ImageTextSpacing = 8;
			this.nRichTextLabel11.Location = new System.Drawing.Point(8, 51);
			this.nRichTextLabel11.Name = "nRichTextLabel11";
			this.nRichTextLabel11.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
			this.nRichTextLabel11.ShadowInfo.Draw = false;
			this.nRichTextLabel11.Size = new System.Drawing.Size(128, 24);
			this.nRichTextLabel11.StrokeInfo.Draw = false;
			this.nRichTextLabel11.TabIndex = 4;
			this.nRichTextLabel11.Text = "My documents";
			// 
			// nRichTextLabel12
			// 
			this.nRichTextLabel12.BackColor = System.Drawing.Color.Transparent;
			this.nRichTextLabel12.FillInfo.Draw = false;
			this.nRichTextLabel12.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(33)), ((System.Byte)(93)), ((System.Byte)(198)));
			this.nRichTextLabel12.Item.Image = ((System.Drawing.Image)(resources.GetObject("nRichTextLabel12.Item.Image")));
			this.nRichTextLabel12.Item.ImageTextSpacing = 8;
			this.nRichTextLabel12.Location = new System.Drawing.Point(8, 27);
			this.nRichTextLabel12.Name = "nRichTextLabel12";
			this.nRichTextLabel12.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
			this.nRichTextLabel12.ShadowInfo.Draw = false;
			this.nRichTextLabel12.Size = new System.Drawing.Size(128, 24);
			this.nRichTextLabel12.StrokeInfo.Draw = false;
			this.nRichTextLabel12.TabIndex = 3;
			this.nRichTextLabel12.Text = "My network places";
			// 
			// nExpander4
			// 
			this.nExpander4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(214)), ((System.Byte)(223)), ((System.Byte)(247)));
			this.nExpander4.Controls.Add(this.nRichTextLabel7);
			this.nExpander4.Controls.Add(this.nRichTextLabel8);
			this.nExpander4.Controls.Add(this.nRichTextLabel9);
			this.nExpander4.Location = new System.Drawing.Point(8, 120);
			this.nExpander4.Name = "nExpander4";
			this.nExpander4.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
			this.nExpander4.Size = new System.Drawing.Size(184, 104);
			this.nExpander4.TabIndex = 4;
			this.nExpander4.Text = "System Tasks";
			// 
			// nRichTextLabel7
			// 
			this.nRichTextLabel7.BackColor = System.Drawing.Color.Transparent;
			this.nRichTextLabel7.FillInfo.Draw = false;
			this.nRichTextLabel7.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(33)), ((System.Byte)(93)), ((System.Byte)(198)));
			this.nRichTextLabel7.Item.Image = ((System.Drawing.Image)(resources.GetObject("nRichTextLabel7.Item.Image")));
			this.nRichTextLabel7.Item.ImageTextSpacing = 8;
			this.nRichTextLabel7.Location = new System.Drawing.Point(8, 74);
			this.nRichTextLabel7.Name = "nRichTextLabel7";
			this.nRichTextLabel7.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
			this.nRichTextLabel7.ShadowInfo.Draw = false;
			this.nRichTextLabel7.Size = new System.Drawing.Size(152, 24);
			this.nRichTextLabel7.StrokeInfo.Draw = false;
			this.nRichTextLabel7.TabIndex = 2;
			this.nRichTextLabel7.Text = "Change a setting";
			// 
			// nRichTextLabel8
			// 
			this.nRichTextLabel8.BackColor = System.Drawing.Color.Transparent;
			this.nRichTextLabel8.FillInfo.Draw = false;
			this.nRichTextLabel8.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(33)), ((System.Byte)(93)), ((System.Byte)(198)));
			this.nRichTextLabel8.Item.Image = ((System.Drawing.Image)(resources.GetObject("nRichTextLabel8.Item.Image")));
			this.nRichTextLabel8.Item.ImageTextSpacing = 8;
			this.nRichTextLabel8.Location = new System.Drawing.Point(8, 50);
			this.nRichTextLabel8.Name = "nRichTextLabel8";
			this.nRichTextLabel8.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
			this.nRichTextLabel8.ShadowInfo.Draw = false;
			this.nRichTextLabel8.Size = new System.Drawing.Size(152, 24);
			this.nRichTextLabel8.StrokeInfo.Draw = false;
			this.nRichTextLabel8.TabIndex = 1;
			this.nRichTextLabel8.Text = "Add or remove programs";
			// 
			// nRichTextLabel9
			// 
			this.nRichTextLabel9.BackColor = System.Drawing.Color.Transparent;
			this.nRichTextLabel9.FillInfo.Draw = false;
			this.nRichTextLabel9.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(33)), ((System.Byte)(93)), ((System.Byte)(198)));
			this.nRichTextLabel9.Item.Image = ((System.Drawing.Image)(resources.GetObject("nRichTextLabel9.Item.Image")));
			this.nRichTextLabel9.Item.ImageTextSpacing = 8;
			this.nRichTextLabel9.Location = new System.Drawing.Point(8, 26);
			this.nRichTextLabel9.Name = "nRichTextLabel9";
			this.nRichTextLabel9.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
			this.nRichTextLabel9.ShadowInfo.Draw = false;
			this.nRichTextLabel9.Size = new System.Drawing.Size(152, 24);
			this.nRichTextLabel9.StrokeInfo.Draw = false;
			this.nRichTextLabel9.TabIndex = 0;
			this.nRichTextLabel9.Text = "View system information";
			// 
			// nExpander6
			// 
			this.nExpander6.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(214)), ((System.Byte)(223)), ((System.Byte)(247)));
			this.nExpander6.Controls.Add(this.nRichTextLabel13);
			this.nExpander6.Location = new System.Drawing.Point(8, 232);
			this.nExpander6.Name = "nExpander6";
			this.nExpander6.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
			this.nExpander6.Size = new System.Drawing.Size(184, 56);
			this.nExpander6.TabIndex = 7;
			this.nExpander6.Text = "Details";
			// 
			// nRichTextLabel13
			// 
			this.nRichTextLabel13.BackColor = System.Drawing.Color.Transparent;
			this.nRichTextLabel13.FillInfo.Draw = false;
			this.nRichTextLabel13.Item.Image = ((System.Drawing.Image)(resources.GetObject("nRichTextLabel13.Item.Image")));
			this.nRichTextLabel13.Item.ImageTextSpacing = 8;
			this.nRichTextLabel13.Item.ItemStyle = Nevron.UI.ItemStyle.Text;
			this.nRichTextLabel13.Location = new System.Drawing.Point(8, 24);
			this.nRichTextLabel13.Name = "nRichTextLabel13";
			this.nRichTextLabel13.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
			this.nRichTextLabel13.ShadowInfo.Draw = false;
			this.nRichTextLabel13.Size = new System.Drawing.Size(112, 32);
			this.nRichTextLabel13.StrokeInfo.Draw = false;
			this.nRichTextLabel13.TabIndex = 6;
			this.nRichTextLabel13.Text = "<b>My Computer</b><br/>System Folder";
			// 
			// NPopupComboUC
			// 
			this.Name = "NPopupComboUC";
			this.popupInstancePanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nExplorerBar1)).EndInit();
			this.nExplorerBar1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nExpander5)).EndInit();
			this.nExpander5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel10)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel11)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel12)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nExpander4)).EndInit();
			this.nExpander4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel8)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel9)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nExpander6)).EndInit();
			this.nExpander6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel13)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NPopup nPopup1;
		private Nevron.UI.WinForm.Controls.NExplorerBar nExplorerBar1;
		private Nevron.UI.WinForm.Controls.NExpander nExpander5;
		private Nevron.UI.WinForm.Controls.NRichTextLabel nRichTextLabel10;
		private Nevron.UI.WinForm.Controls.NRichTextLabel nRichTextLabel11;
		private Nevron.UI.WinForm.Controls.NRichTextLabel nRichTextLabel12;
		private Nevron.UI.WinForm.Controls.NExpander nExpander4;
		private Nevron.UI.WinForm.Controls.NRichTextLabel nRichTextLabel7;
		private Nevron.UI.WinForm.Controls.NRichTextLabel nRichTextLabel8;
		private Nevron.UI.WinForm.Controls.NRichTextLabel nRichTextLabel9;
		private Nevron.UI.WinForm.Controls.NExpander nExpander6;
		private Nevron.UI.WinForm.Controls.NRichTextLabel nRichTextLabel13;
		private Nevron.UI.WinForm.Controls.NPopupCombo nPopupCombo2;

		#endregion
	}
}
