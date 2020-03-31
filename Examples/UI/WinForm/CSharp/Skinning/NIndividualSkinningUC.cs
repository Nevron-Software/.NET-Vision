using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Nevron.UI;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
    public partial class NIndividualSkinningUC : NExampleUserControl
    {
        #region Constructor

        public NIndividualSkinningUC()
        {
            InitializeComponent();
        }
        public NIndividualSkinningUC(MainForm f) : base(f)
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides

        public override void Initialize()
        {
            base.Initialize();

            this.nButton1.TransparentBackground = true;

			this.nCommandContext1.Properties.ImageInfo.Image = NResourceHelper.BitmapFromResource(this.GetType(), "JournalSmall.png", "Nevron.Examples.UI.WinForm.Resources.Images.NavigationPane");
			this.nCommand1.Properties.ImageInfo.Image = NResourceHelper.BitmapFromResource(this.GetType(), "JournalSmall.png", "Nevron.Examples.UI.WinForm.Resources.Images.NavigationPane");

            nCommandBarsManager1.ApplyPalette(NUIManager.Palette);

            NSkinResource resource = new NSkinResource(SkinResourceType.EntryAssembly, "ButtonsSkin");
            m_ButtonsSkin1 = new NSkin();
            m_ButtonsSkin1.Load(resource);

            resource.SkinName = "ScrollbarsSkin";
            m_ScrollbarsSkin1 = new NSkin();
            m_ScrollbarsSkin1.Load(resource);

            FillSkinCombo(buttonsSkinCombo);
            FillSkinCombo(scrollSkinCombo);
            FillSkinCombo(commandBarsSkinCombo);

            buttonsSkinCombo.SelectedIndex = 1;
            scrollSkinCombo.SelectedIndex = 4;
            commandBarsSkinCombo.SelectedIndex = 5;
        }

        #endregion

        #region Implementation

        internal void FillSkinCombo(NComboBox combo)
        {
            // global skin
			NListBoxItem item = new NListBoxItem();
            item.Text = "Global Skin";
            combo.Items.Add(item);

			NSkinResourceInfo[] arrSkinInfo = m_MainForm.Config.AvailableSkins;
			if (arrSkinInfo == null)
				return;

			int length = arrSkinInfo.Length;

            for (int i = 0; i < length; i++)
            {
				item = new NListBoxItem();
				item.Text = arrSkinInfo[i].SkinDisplayName;
                item.Tag = arrSkinInfo[i].SkinResourceName;
                combo.Items.Add(item);
            }
        }
		internal void OnSkinComboSelectedIndexChanged(NComboBox combo, int code)
		{
			string skinResourceName = combo.SelectedItem as string;

			NSkinResource res = new NSkinResource(SkinResourceType.GlobalAssembly, skinResourceName);
			res.AssemblyName = "Nevron.UI.WinForm.Skins";

			NSkin skin = new NSkin();
			if(!skin.Load(res))
				return;

			switch (code)
			{
				case 0:
					this.nButton1.Skin = skin;
					this.nCheckBox1.Skin = skin;
					this.nRadioButton1.Skin = skin;
					break;
				case 1:
					this.nhScrollBar1.Skin = skin;
					this.nhScrollBar2.Skin = skin;
					this.nvScrollBar1.Skin = skin;
					break;
				case 2:
					this.nCommandBarsManager1.Skin = skin;
					break;
			}
		}

        #endregion

        #region Event Handlers

        private void buttonsSkinCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSkinComboSelectedIndexChanged(buttonsSkinCombo, 0);
        }
        private void scrollSkinCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSkinComboSelectedIndexChanged(scrollSkinCombo, 1);
        }
        private void commandBarsSkinCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSkinComboSelectedIndexChanged(commandBarsSkinCombo, 2);
        }

        #endregion

        #region Fields

        internal NSkin m_ButtonsSkin1;
        internal NSkin m_ScrollbarsSkin1;

        #endregion
    }
}
