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
    public partial class NTreeListDataBindingUC : NExampleUserControl
    {
        #region Constructor

        public NTreeListDataBindingUC()
        {
            InitializeComponent();

            Dock = DockStyle.Fill;

            m_List = new NTreeList();
            m_List.Dock = DockStyle.Fill;
            m_List.GroupNodeDefaultState.Font = new Font("Trebuchet MS", 9, FontStyle.Bold);
            m_List.Parent = containerPanel;
            m_List.AutoSizeColumns = false;
            m_List.ShowGroupByBox = true;
        }

        #endregion

        #region Overrides

        public override void Initialize()
        {
            base.Initialize();

            NTreeListTableData data = new NTreeListTableData();
			data.Table = NRptSampleDataSet.GetDataTable("Customers");
            data.Bind(m_List);

            NTreeListColumn col = m_List.Columns["Country"];
            m_List.GroupBy(col);
            m_List.SortColumn(col, TreeListSortMode.Ascending);
            m_List.SortColumn(m_List.Columns["CompanyName"], TreeListSortMode.Ascending);

            m_List.BestFitAllColumns();
            m_List.BestFitAllNodes();

            m_List.ExpandAll();
        }

        #endregion

        #region Implementation
        #endregion

        #region Fields

        internal NTreeList m_List;

        #endregion
    }
}
