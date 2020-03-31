using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

using Nevron.UI;
using Nevron.UI.WinForm;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
    public partial class NToolStripSkinRendererUC : NExampleUserControl
    {
        #region Constructor

        public NToolStripSkinRendererUC()
        {
            InitializeComponent();
        }
        public NToolStripSkinRendererUC(MainForm f) : base(f)
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides

        public override void Initialize()
        {
            base.Initialize();

            FillSkinCombo();

            Dock = DockStyle.Fill;

            m_Renderer = new NToolStripSkinRenderer();
            ToolStripManager.Renderer = m_Renderer;

            this.undoToolStripMenuItem.Checked = true;
        }

        #endregion

        #region Implementation

        internal void FillSkinCombo()
        {
			NSkinResourceInfo[] arrSkinInfo = m_MainForm.Config.AvailableSkins;
			if (arrSkinInfo == null)
                return;

			//add the "Use global skin" item
			NListBoxItem item = new NListBoxItem();
            item.Text = "Use global skin";
            this.skinCombo.Items.Add(item);

			int length = arrSkinInfo.Length;

            for (int i = 0; i < length; i++)
            {
                item = new NListBoxItem();
				item.Text = arrSkinInfo[i].SkinDisplayName;
				item.Tag = arrSkinInfo[i].SkinResourceName;
                skinCombo.Items.Add(item);
            }

            skinCombo.SelectedIndex = 0;
            skinCombo.SelectedIndexChanged += new EventHandler(skinCombo_SelectedIndexChanged);
        }

        #endregion

        #region Event Handlers

        void skinCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
			string skinName = skinCombo.SelectedItem as string;

			if (skinName == null)
			{
				m_Renderer.Skin = null;
			}
			else
			{
				// load the skin
				NSkinResource res = new NSkinResource(SkinResourceType.GlobalAssembly, skinName);
				res.AssemblyName = "Nevron.UI.WinForm.Skins";

				NSkin skin = new NSkin();
				if (skin.Load(res))
				{
					m_Renderer.Skin = skin;
				}
			}            
        }

        #endregion

        #region Fields

        internal NToolStripSkinRenderer m_Renderer;

        #endregion
    }
}
