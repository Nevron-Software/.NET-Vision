using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Data;
using System.Windows.Forms;

using Nevron.GraphicsCore;
using Nevron.UI;
using Nevron.UI.WinForm;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
    public partial class NTreeViewExDragDropUC : NExampleUserControl
    {
        #region Constructor

        public NTreeViewExDragDropUC()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides

        public override void Initialize()
        {
            base.Initialize();

            Dock = DockStyle.Fill;

            NTreeViewExUC.AddTestNodes(nTreeViewEx1, 5, 3);

            this.enableDragCheck.Checked = true;
            this.showHintsCheck.Checked = true;
            this.autoScrollCheck.Checked = true;
            this.expandNodeCheck.Checked = true;
        }

        #endregion

        #region Event Handlers

        private void enableDragCheck_CheckedChanged(object sender, EventArgs e)
        {
            nTreeViewEx1.ItemDragDropMode = enableDragCheck.Checked ? ItemDragDropMode.Local : ItemDragDropMode.None;
        }
        private void showHintsCheck_CheckedChanged(object sender, EventArgs e)
        {
            nTreeViewEx1.ShowDragDropHints = showHintsCheck.Checked;
        }
        private void autoScrollCheck_CheckedChanged(object sender, EventArgs e)
        {
            nTreeViewEx1.EnableDragDropAutoScroll = autoScrollCheck.Checked;
        }
        private void expandNodeCheck_CheckedChanged(object sender, EventArgs e)
        {
            nTreeViewEx1.ExpandNodeOnDragOver = expandNodeCheck.Checked;
        }
        private void expandAllBtn_Click(object sender, EventArgs e)
        {
            nTreeViewEx1.ExpandAll();
        }
        private void collapseAllBtn_Click(object sender, EventArgs e)
        {
            nTreeViewEx1.CollapseAll();
        }

        #endregion
    }
}
