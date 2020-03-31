using System;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;

using Nevron.UI;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NSkinningUC.
	/// </summary>
	public class NSkinningUC : NExampleUserControl
	{
		#region Constructor

		public NSkinningUC(MainForm f) : base(f)
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
			base.Initialize();

			// no skin item
			NListBoxItem item = new NListBoxItem();
			item.Text = "None";
			item.Tag = null;
			skinCombo.Items.Add(item);

			try
			{
				NSkinResourceInfo[] arrSkinInfo = m_MainForm.Config.AvailableSkins;

				if(arrSkinInfo != null)
				{
					int length = arrSkinInfo.Length;
					for(int i = 0; i < length; i++)
					{
						item = new NListBoxItem();
						item.Text = arrSkinInfo[i].SkinDisplayName;
						item.Tag = arrSkinInfo[i].SkinResourceName;
						skinCombo.Items.Add(item);
					}
				}
			}
			catch
			{
			}

			m_iSuspendUpdate++;
			enableSkinManagerCheck.Checked = NSkinManager.Instance.Enabled;
			m_iSuspendUpdate--;
		}


		#endregion

		#region Event Handlers

		private void enableSkinManagerCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if(m_iSuspendUpdate > 0)
				return;

			NSkinManager.Instance.Enabled = enableSkinManagerCheck.Checked;
		}
		private void skinCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_iSuspendUpdate > 0)
				return;

			string skinName = skinCombo.SelectedItem as string;

			if (skinName == null)
			{
				NSkinManager.Instance.Skin = null;
			}
			else
			{
				// load the skin
				NSkinResource res = new NSkinResource(SkinResourceType.GlobalAssembly, skinName);
				res.AssemblyName = "Nevron.UI.WinForm.Skins";

				NSkin skin = new NSkin();
				if (skin.Load(res))
				{
					NSkinManager.Instance.Skin = skin;
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
			this.label1 = new System.Windows.Forms.Label();
			this.skinCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.enableSkinManagerCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Select skin:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// skinCombo
			// 
			this.skinCombo.Location = new System.Drawing.Point(96, 8);
			this.skinCombo.Name = "skinCombo";
			this.skinCombo.Size = new System.Drawing.Size(168, 22);
			this.skinCombo.TabIndex = 5;
			this.skinCombo.Text = "nComboBox1";
			this.skinCombo.SelectedIndexChanged += new System.EventHandler(this.skinCombo_SelectedIndexChanged);
			// 
			// enableSkinManagerCheck
			// 
			this.enableSkinManagerCheck.ButtonProperties.BorderOffset = 2;
			this.enableSkinManagerCheck.Checked = true;
			this.enableSkinManagerCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.enableSkinManagerCheck.Location = new System.Drawing.Point(96, 40);
			this.enableSkinManagerCheck.Name = "enableSkinManagerCheck";
			this.enableSkinManagerCheck.Size = new System.Drawing.Size(168, 24);
			this.enableSkinManagerCheck.TabIndex = 7;
			this.enableSkinManagerCheck.Text = "Skin manager enabled";
			this.enableSkinManagerCheck.CheckedChanged += new System.EventHandler(this.enableSkinManagerCheck_CheckedChanged);
			// 
			// NSkinningUC
			// 
			this.Controls.Add(this.enableSkinManagerCheck);
			this.Controls.Add(this.skinCombo);
			this.Controls.Add(this.label1);
			this.Name = "NSkinningUC";
			this.Size = new System.Drawing.Size(288, 96);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox skinCombo;
		private Nevron.UI.WinForm.Controls.NCheckBox enableSkinManagerCheck;

		#endregion
	}
}
