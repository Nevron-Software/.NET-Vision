using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Data;
using System.Windows.Forms;

using Nevron.GraphicsCore;
using Nevron.UI.WinForm;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
    public partial class NTreeViewExEventsUC : NExampleUserControl
    {
        #region Constructor

        public NTreeViewExEventsUC()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides

        public override void Initialize()
        {
            base.Initialize();

            Dock = DockStyle.Fill;
            batchUpdatesCheck.Checked = true;
            nTreeViewEx1.EnableItemEdit = true;

            NTreeViewExUC.AddTestNodes(nTreeViewEx1, 5, 3);
            nTreeViewEx1.ItemCheckStyle = ItemCheckStyle.CheckBox;
            nTreeViewEx1.ItemNotify += new NLightUIItemNotifyEventHandler(nTreeViewEx1_ItemNotify);
            nTreeViewEx1.SelectionMode = ItemSelectionMode.MultiExtended;

            nTextBox1.WordWrap = false;
            nTextBox1.ScrollBars = ScrollBars.Both;

            PopulateEventsList(trackNotificationsList, true);
            PopulateEventsList(cancelNotificationList, false);
        }

        #endregion

        #region Implementation

        internal void PopulateEventsList(NListBox list, bool track)
        {
            list.BeginUpdate();
            list.CheckBoxes = true;
            list.CheckOnClick = true;

            NListBoxItem item;

            item = new NListBoxItem(NTreeViewEx.ItemMouseStateChangingNotifyCode);
            item.Text = "ItemMouseStateChangingNotifyCode";
            list.Items.Add(item);

            item = new NListBoxItem(NTreeViewEx.ItemMouseStateChangedNotifyCode);
            item.Text = "ItemMouseStateChangedNotifyCode";
            list.Items.Add(item);

            item = new NListBoxItem(NTreeViewEx.ItemLabelClickNotifyCode);
            item.Checked = track;
            item.Text = "ItemLabelClickNotifyCode";
            list.Items.Add(item);

            item = new NListBoxItem(NTreeViewEx.ItemLabelDoubleClickNotifyCode);
            item.Checked = track;
            item.Text = "ItemLabelDoubleClickNotifyCode";
            list.Items.Add(item);

            item = new NListBoxItem(NTreeViewEx.ItemCheckBoxClickNotifyCode);
            item.Checked = track;
            item.Text = "ItemCheckBoxClickNotifyCode";
            list.Items.Add(item);

            item = new NListBoxItem(NTreeViewEx.ItemCheckStateChangedNotifyCode);
            item.Checked = track;
            item.Text = "ItemCheckStateChangedNotifyCode";
            list.Items.Add(item);

            item = new NListBoxItem(NTreeViewEx.ItemCheckStateChangingNotifyCode);
            item.Checked = track;
            item.Text = "ItemCheckStateChangingNotifyCode";
            list.Items.Add(item);

            item = new NListBoxItem(NTreeViewEx.ItemBeginEditNotifyCode);
            item.Checked = track;
            item.Text = "ItemBeginEditNotifyCode";
            list.Items.Add(item);

            item = new NListBoxItem(NTreeViewEx.ItemEndEditNotifyCode);
            item.Checked = track;
            item.Text = "ItemEndEditNotifyCode";
            list.Items.Add(item);

            item = new NListBoxItem(NTreeViewEx.ItemSelectionRequestNotifyCode);
            item.Text = "ItemSelectionRequestNotifyCode";
            list.Items.Add(item);

            item = new NListBoxItem(NTreeViewEx.ItemSelectionChangingNotifyCode);
            item.Checked = track;
            item.Text = "ItemSelectionChangingNotifyCode";
            list.Items.Add(item);

            item = new NListBoxItem(NTreeViewEx.ItemSelectionChangedNotifyCode);
            item.Checked = track;
            item.Text = "ItemSelectionChangedNotifyCode";
            list.Items.Add(item);

            item = new NListBoxItem(NTreeViewEx.NodeCollapsedNotifyCode);
            item.Checked = track;
            item.Text = "NodeCollapsedNotifyCode";
            list.Items.Add(item);

            item = new NListBoxItem(NTreeViewEx.NodeCollapsingNotifyCode);
            item.Checked = track;
            item.Text = "NodeCollapsingNotifyCode";
            list.Items.Add(item);

            item = new NListBoxItem(NTreeViewEx.NodeExpandedNotifyCode);
            item.Checked = track;
            item.Text = "NodeExpandedNotifyCode";
            list.Items.Add(item);

            item = new NListBoxItem(NTreeViewEx.NodeExpandingNotifyCode);
            item.Checked = track;
            item.Text = "NodeExpandingNotifyCode";
            list.Items.Add(item);

            list.EndUpdate();
        }
        internal NListBoxItem GetItemByCode(NListBoxItemCollection coll, int code)
        {
            int count = coll.Count;
            NListBoxItem item;
            int itemCode;

            for (int i = 0; i < count; i++)
            {
                item = coll[i];
                itemCode = (int)item.Tag;

                if (itemCode == code)
                {
                    return item;
                }
            }

            return null;
        }

        #endregion

        #region Event Handlers

        private void clearLogBtn_Click(object sender, EventArgs e)
        {
            nTextBox1.Text = string.Empty;
        }
        private void batchUpdatesCheck_CheckedChanged(object sender, EventArgs e)
        {
            nTreeViewEx1.EnableBatchUpdates = batchUpdatesCheck.Checked;
        }
        void nTreeViewEx1_ItemNotify(object sender, NLightUIItemNotifyData data)
        {
            NListBoxItem codeItem = GetItemByCode(cancelNotificationList.Items, data.NotifyCode);
            if (codeItem != null)
            {
                data.Cancel = codeItem.Checked;
            }

            codeItem = GetItemByCode(trackNotificationsList.Items, data.NotifyCode);
            if (codeItem == null || codeItem.Checked == false)
            {
                return;
            }

            string messageLog = "Notification code: " + codeItem.Text;
            messageLog += "; sender: " + data.Sender.ToString();
            messageLog += "; canceled: " + data.Cancel.ToString();
            messageLog += "\r\n";

            this.nTextBox1.Text += messageLog;
        }

        #endregion
    }
}
