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
    public partial class NMaskedTextBoxUC : NExampleUserControl
    {
        #region Constructor

        public NMaskedTextBoxUC()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        private void borderBtn_Click(object sender, EventArgs e)
        {
            this.nMaskedTextBox1.Border.ShowEditor();
        }
        private void paletteBtn_Click(object sender, EventArgs e)
        {
            this.nMaskedTextBox1.Palette.ShowEditor();
        }
        private void enableSkinningCheck_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = enableSkinningCheck.Checked;

            this.borderBtn.Enabled = isChecked == false;
            this.paletteBtn.Enabled = isChecked == false;
            this.nMaskedTextBox1.EnableSkinning = isChecked;
        }

        #endregion
    }
}
