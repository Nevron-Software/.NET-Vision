using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
    public partial class NTreeListFilteringUC : NExampleUserControl
    {
        #region Constructor

        public NTreeListFilteringUC()
        {
            InitializeComponent();

            Dock = DockStyle.Fill;

            m_List = new NTreeList();
            m_List.Dock = DockStyle.Fill;
            m_List.Parent = containerPanel;
            m_List.ShowGroupByBox = true;
        }

        #endregion

        #region Overrides

        public override void Initialize()
        {
            base.Initialize();

            stringOptionsCombo.FillFromEnum(typeof(CommonStringOptions));
            stringOptionsCombo.SelectedItem = CommonStringOptions.Contains;

            numericOptionsCombo.FillFromEnum(typeof(CommonNumericOptions));
            numericOptionsCombo.SelectedItem = CommonNumericOptions.Equals;

            m_Helper = new NTreeListUCHelper();
            m_Helper.Populate(m_List);
        }

        #endregion

        #region Event Handlers

        private void stringOptionsCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void numericOptionsCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void enableFromFilterBtn_Click(object sender, EventArgs e)
        {
            string txt = fromColumnFilterText1.Text;

            NTreeListColumnStringFilter filter = new NTreeListColumnStringFilter(txt, true, (CommonStringOptions)this.stringOptionsCombo.SelectedItem);
            m_List.Columns["From"].VisibleFilter = filter;
        }
        private void disableFromFilterBtn_Click(object sender, EventArgs e)
        {
            m_List.Columns["From"].VisibleFilter = null;
        }
        private void applyNumericFilterBtn_Click(object sender, EventArgs e)
        {
            decimal val1 = (int)amountFilterNum1.Value;
            decimal val2 = (int)amountFilterNum2.Value;

            NTreeListColumnNumericFilter filter = new NTreeListColumnNumericFilter(val1, val2, (CommonNumericOptions)this.numericOptionsCombo.SelectedItem);
            m_List.Columns["PurchaseAmount"].VisibleFilter = filter;
        }
        private void removeNumericFilterBtn_Click(object sender, EventArgs e)
        {
            m_List.Columns["PurchaseAmount"].VisibleFilter = null;
        }

        #endregion

        #region Fields

        internal NTreeList m_List;
        internal NTreeListUCHelper m_Helper;

        #endregion
    }
}
