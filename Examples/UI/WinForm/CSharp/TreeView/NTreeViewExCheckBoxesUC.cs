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
    public partial class NTreeViewExCheckBoxesUC : NExampleUserControl
    {
        #region Constructor

        public NTreeViewExCheckBoxesUC()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides

        public override void Initialize()
        {
            base.Initialize();

            nTreeViewEx1.ItemCheckStyle = ItemCheckStyle.CheckBox;
            checkStyleCombo.FillFromEnum(typeof(ItemCheckStyle));
            checkStyleCombo.SelectedItem = nTreeViewEx1.ItemCheckStyle;
            autoCheck.Checked = nTreeViewEx1.AutoUpdateCheckState;

            NTreeViewExUC.AddTestNodes(nTreeViewEx1, 10, 3);
        }

        #endregion

        #region Event Handlers

        private void checkStyleCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            nTreeViewEx1.ItemCheckStyle = (ItemCheckStyle)checkStyleCombo.SelectedItem;
        }
        private void autoCheck_CheckedChanged(object sender, EventArgs e)
        {
            nTreeViewEx1.AutoUpdateCheckState = autoCheck.Checked;
        }
        private void checkedItemsBtn_Click(object sender, EventArgs e)
        {
            NLightUIItem[] checkedItems = nTreeViewEx1.Nodes.GetItemsByCheckState(ItemCheckState.Checked, true);

            NForm form = new NForm();
            NListBox lb = new NListBox();
            lb.Dock = DockStyle.Fill;
            lb.Parent = form;
            lb.Items.AddRange(checkedItems);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog(nTreeViewEx1);

            form.Dispose();
        }
        private void indeterminateBtn_Click(object sender, EventArgs e)
        {
            NLightUIItem[] checkedItems = nTreeViewEx1.Nodes.GetItemsByCheckState(ItemCheckState.Indeterminate, true);

            NForm form = new NForm();
            NListBox lb = new NListBox();
            lb.Dock = DockStyle.Fill;
            lb.Parent = form;
            lb.Items.AddRange(checkedItems);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog(nTreeViewEx1);

            form.Dispose();
        }

        #endregion
    }
}
