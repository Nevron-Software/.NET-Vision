using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

using Nevron.UI;
using Nevron.UI.WinForm;
using Nevron.GraphicsCore;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NGalleryPanelUC.
	/// </summary>
	public class NGalleryPanelUC : NExampleUserControl
	{
		#region Constructor

		public NGalleryPanelUC()
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

			Dock = DockStyle.Fill;
			DockPadding.All = 10;

			m_Panel = new NGalleryPanel();
			m_Panel.Location = new Point(8, 8);
			m_Panel.ClientPadding = new NPadding(1);
			m_Panel.Parent = this;

			m_iSuspendUpdate++;

			layoutCombo.FillFromEnum(typeof(GalleryPanelLayout));
			layoutCombo.SelectedItem = m_Panel.ItemLayout;

			selectionModeCombo.FillFromEnum(typeof(GalleryPanelSelectionMode));
			selectionModeCombo.SelectedItem = m_Panel.SelectionMode;

			NSize sz = m_Panel.ItemSize;
			itemSizeWidthNumeric.Value = sz.Width;
			itemSizeHeightNumeric.Value = sz.Height;

			hScrollVisibilityCombo.FillFromEnum(typeof(ScrollVisibility));
			hScrollVisibilityCombo.SelectedItem = m_Panel.HScrollVisibility;

			vScrollVisibilityCombo.FillFromEnum(typeof(ScrollVisibility));
			vScrollVisibilityCombo.SelectedItem = m_Panel.VScrollVisibility;

			hideSelCheck.Checked = m_Panel.HideSelection;
			nCheckBox1.Checked = m_Panel.EnableElementTooltips;
			skinBodyCheck.Checked = m_Panel.UseBodySkinning;
			showFocusCheck.Checked = m_Panel.ShowFocusRect;

			m_iSuspendUpdate--;

			InitItems();
		}


		#endregion

		#region Implementation

		internal void InitItems()
		{
			m_Panel.Suspend();

			NGalleryItem item;
			NLabelElement label;

			for(int i = 1; i < 51; i++)
			{
				item = new NGalleryItem();
				label = item.Label;

				label.Suspend();

				label.ImageSize = new NSize(32, 32);
				label.Image = NSystemImages.Warning;
				label.ContentAlign = ContentAlignment.MiddleCenter;
				label.TreatAsOneEntity = false;
				label.ImageAlign = ContentAlignment.MiddleLeft;
				label.TextAlign = ContentAlignment.MiddleCenter;
				label.Text = "<b>Item " + i + "</b><br/><font size='7' face='Tahoma' color='Navy'>Second text line</font>";
				label.TooltipText = "Tooltip over item " + i;

				label.Resume(false);
				m_Panel.Items.Add(item);
			}

			m_Panel.Resume(false);
		}


		#endregion

		#region Event Handlers

		private void layoutCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (m_Panel == null)
            {
                return;
            }

			m_Panel.ItemLayout = (GalleryPanelLayout)layoutCombo.SelectedItem;
		}
		private void selectionModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (m_Panel == null)
            {
                return;
            }
			m_Panel.SelectionMode = (GalleryPanelSelectionMode)selectionModeCombo.SelectedItem;
		}
		private void itemSizeWidthNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if(m_iSuspendUpdate > 0 || m_Panel == null)
			{
				return;
			}

			int width = (int)itemSizeWidthNumeric.Value;
			int height = (int)itemSizeHeightNumeric.Value;

			m_Panel.ItemSize = new NSize(width, height);
		}
		private void itemSizeHeightNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if(m_iSuspendUpdate > 0 || m_Panel == null)
			{
				return;
			}

			int width = (int)itemSizeWidthNumeric.Value;
			int height = (int)itemSizeHeightNumeric.Value;

			m_Panel.ItemSize = new NSize(width, height);
		}

		private void hideSelCheck_CheckedChanged(object sender, System.EventArgs e)
		{
            if (m_Panel == null)
            {
                return;
            }
			m_Panel.HideSelection = hideSelCheck.Checked;
		}
		private void nCheckBox1_CheckedChanged(object sender, System.EventArgs e)
		{
            if (m_Panel == null)
            {
                return;
            }
			m_Panel.EnableElementTooltips = nCheckBox1.Checked;
		}
        private void customScrollsCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Panel == null)
            {
                return;
            }
            m_Panel.UseCustomScrollbars = customScrollsCheck.Checked;
        }
		private void showFocusCheck_CheckedChanged(object sender, System.EventArgs e)
		{
            if (m_Panel == null)
            {
                return;
            }
			m_Panel.ShowFocusRect = showFocusCheck.Checked;
		}
		private void skinBodyCheck_CheckedChanged(object sender, System.EventArgs e)
		{
            if (m_Panel == null)
            {
                return;
            }
			m_Panel.UseBodySkinning = skinBodyCheck.Checked;
		}
		private void hScrollVisibilityCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (m_Panel == null)
            {
                return;
            }
			m_Panel.HScrollVisibility = (ScrollVisibility)hScrollVisibilityCombo.SelectedItem;
		}
		private void vScrollVisibilityCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (m_Panel == null)
            {
                return;
            }
			m_Panel.VScrollVisibility = (ScrollVisibility)vScrollVisibilityCombo.SelectedItem;
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label2 = new System.Windows.Forms.Label();
            this.layoutCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.selectionModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.itemSizeHeightNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.itemSizeWidthNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.hideSelCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.nCheckBox1 = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.hScrollVisibilityCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.vScrollVisibilityCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.showFocusCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.skinBodyCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.customScrollsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.nGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemSizeHeightNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemSizeWidthNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(312, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Layout:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // layoutCombo
            // 
            this.layoutCombo.Location = new System.Drawing.Point(312, 32);
            this.layoutCombo.Name = "layoutCombo";
            this.layoutCombo.Size = new System.Drawing.Size(200, 22);
            this.layoutCombo.TabIndex = 1;
            this.layoutCombo.Text = "nComboBox1";
            this.layoutCombo.SelectedIndexChanged += new System.EventHandler(this.layoutCombo_SelectedIndexChanged);
            // 
            // selectionModeCombo
            // 
            this.selectionModeCombo.Location = new System.Drawing.Point(312, 80);
            this.selectionModeCombo.Name = "selectionModeCombo";
            this.selectionModeCombo.Size = new System.Drawing.Size(200, 22);
            this.selectionModeCombo.TabIndex = 3;
            this.selectionModeCombo.Text = "nComboBox1";
            this.selectionModeCombo.SelectedIndexChanged += new System.EventHandler(this.selectionModeCombo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(312, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Selection Mode:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nGroupBox1
            // 
            this.nGroupBox1.Controls.Add(this.itemSizeHeightNumeric);
            this.nGroupBox1.Controls.Add(this.label5);
            this.nGroupBox1.Controls.Add(this.itemSizeWidthNumeric);
            this.nGroupBox1.Controls.Add(this.label4);
            this.nGroupBox1.ImageIndex = 0;
            this.nGroupBox1.Location = new System.Drawing.Point(312, 208);
            this.nGroupBox1.Name = "nGroupBox1";
            this.nGroupBox1.Size = new System.Drawing.Size(200, 80);
            this.nGroupBox1.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default;
            this.nGroupBox1.TabIndex = 8;
            this.nGroupBox1.TabStop = false;
            this.nGroupBox1.Text = "Item Size";
            // 
            // itemSizeHeightNumeric
            // 
            this.itemSizeHeightNumeric.Location = new System.Drawing.Point(72, 48);
            this.itemSizeHeightNumeric.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.itemSizeHeightNumeric.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.itemSizeHeightNumeric.Name = "itemSizeHeightNumeric";
            this.itemSizeHeightNumeric.Size = new System.Drawing.Size(80, 20);
            this.itemSizeHeightNumeric.TabIndex = 3;
            this.itemSizeHeightNumeric.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.itemSizeHeightNumeric.ValueChanged += new System.EventHandler(this.itemSizeHeightNumeric_ValueChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Height:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // itemSizeWidthNumeric
            // 
            this.itemSizeWidthNumeric.Location = new System.Drawing.Point(72, 24);
            this.itemSizeWidthNumeric.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.itemSizeWidthNumeric.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.itemSizeWidthNumeric.Name = "itemSizeWidthNumeric";
            this.itemSizeWidthNumeric.Size = new System.Drawing.Size(80, 20);
            this.itemSizeWidthNumeric.TabIndex = 1;
            this.itemSizeWidthNumeric.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.itemSizeWidthNumeric.ValueChanged += new System.EventHandler(this.itemSizeWidthNumeric_ValueChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Width:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hideSelCheck
            // 
            this.hideSelCheck.ButtonProperties.BorderOffset = 2;
            this.hideSelCheck.Location = new System.Drawing.Point(312, 320);
            this.hideSelCheck.Name = "hideSelCheck";
            this.hideSelCheck.Size = new System.Drawing.Size(200, 24);
            this.hideSelCheck.TabIndex = 9;
            this.hideSelCheck.Text = "Hide Selection";
            this.hideSelCheck.CheckedChanged += new System.EventHandler(this.hideSelCheck_CheckedChanged);
            // 
            // nCheckBox1
            // 
            this.nCheckBox1.ButtonProperties.BorderOffset = 2;
            this.nCheckBox1.Location = new System.Drawing.Point(312, 368);
            this.nCheckBox1.Name = "nCheckBox1";
            this.nCheckBox1.Size = new System.Drawing.Size(200, 24);
            this.nCheckBox1.TabIndex = 10;
            this.nCheckBox1.Text = "Enable Item Tooltips";
            this.nCheckBox1.CheckedChanged += new System.EventHandler(this.nCheckBox1_CheckedChanged);
            // 
            // hScrollVisibilityCombo
            // 
            this.hScrollVisibilityCombo.Location = new System.Drawing.Point(312, 128);
            this.hScrollVisibilityCombo.Name = "hScrollVisibilityCombo";
            this.hScrollVisibilityCombo.Size = new System.Drawing.Size(200, 22);
            this.hScrollVisibilityCombo.TabIndex = 5;
            this.hScrollVisibilityCombo.Text = "nComboBox1";
            this.hScrollVisibilityCombo.SelectedIndexChanged += new System.EventHandler(this.hScrollVisibilityCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(312, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "HScroll Visibility:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // vScrollVisibilityCombo
            // 
            this.vScrollVisibilityCombo.Location = new System.Drawing.Point(312, 176);
            this.vScrollVisibilityCombo.Name = "vScrollVisibilityCombo";
            this.vScrollVisibilityCombo.Size = new System.Drawing.Size(200, 22);
            this.vScrollVisibilityCombo.TabIndex = 7;
            this.vScrollVisibilityCombo.Text = "nComboBox1";
            this.vScrollVisibilityCombo.SelectedIndexChanged += new System.EventHandler(this.vScrollVisibilityCombo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(312, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "VScroll Visibility:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // showFocusCheck
            // 
            this.showFocusCheck.ButtonProperties.BorderOffset = 2;
            this.showFocusCheck.Location = new System.Drawing.Point(312, 344);
            this.showFocusCheck.Name = "showFocusCheck";
            this.showFocusCheck.Size = new System.Drawing.Size(200, 24);
            this.showFocusCheck.TabIndex = 11;
            this.showFocusCheck.Text = "Show Focus Rect";
            this.showFocusCheck.CheckedChanged += new System.EventHandler(this.showFocusCheck_CheckedChanged);
            // 
            // skinBodyCheck
            // 
            this.skinBodyCheck.ButtonProperties.BorderOffset = 2;
            this.skinBodyCheck.Location = new System.Drawing.Point(312, 296);
            this.skinBodyCheck.Name = "skinBodyCheck";
            this.skinBodyCheck.Size = new System.Drawing.Size(200, 24);
            this.skinBodyCheck.TabIndex = 12;
            this.skinBodyCheck.Text = "Use Body Skinning";
            this.skinBodyCheck.CheckedChanged += new System.EventHandler(this.skinBodyCheck_CheckedChanged);
            // 
            // customScrollsCheck
            // 
            this.customScrollsCheck.ButtonProperties.BorderOffset = 2;
            this.customScrollsCheck.Checked = true;
            this.customScrollsCheck.Location = new System.Drawing.Point(312, 392);
            this.customScrollsCheck.Name = "customScrollsCheck";
            this.customScrollsCheck.Size = new System.Drawing.Size(200, 24);
            this.customScrollsCheck.TabIndex = 13;
            this.customScrollsCheck.Text = "Use Custom Scrollbars";
            this.customScrollsCheck.CheckedChanged += new System.EventHandler(this.customScrollsCheck_CheckedChanged);
            // 
            // NGalleryPanelUC
            // 
            this.Controls.Add(this.customScrollsCheck);
            this.Controls.Add(this.skinBodyCheck);
            this.Controls.Add(this.showFocusCheck);
            this.Controls.Add(this.vScrollVisibilityCombo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.hScrollVisibilityCombo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nCheckBox1);
            this.Controls.Add(this.hideSelCheck);
            this.Controls.Add(this.nGroupBox1);
            this.Controls.Add(this.selectionModeCombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.layoutCombo);
            this.Controls.Add(this.label2);
            this.Name = "NGalleryPanelUC";
            this.Size = new System.Drawing.Size(528, 424);
            this.nGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemSizeHeightNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemSizeWidthNumeric)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		internal NGalleryPanel m_Panel;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NComboBox layoutCombo;
		private Nevron.UI.WinForm.Controls.NComboBox selectionModeCombo;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NNumericUpDown itemSizeWidthNumeric;
		private Nevron.UI.WinForm.Controls.NNumericUpDown itemSizeHeightNumeric;
		private Nevron.UI.WinForm.Controls.NCheckBox hideSelCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox1;
		private Nevron.UI.WinForm.Controls.NComboBox hScrollVisibilityCombo;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox vScrollVisibilityCombo;
		private System.Windows.Forms.Label label6;
		private Nevron.UI.WinForm.Controls.NCheckBox showFocusCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox skinBodyCheck;
        private NCheckBox customScrollsCheck;
		private System.Windows.Forms.Label label5;

		#endregion
	}
}
