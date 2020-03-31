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
    public partial class NTreeListOutlookReportUC : NExampleUserControl
    {
        #region Constructor

        public NTreeListOutlookReportUC()
        {
            InitializeComponent();

            Dock = DockStyle.Fill;

            m_List = new NTreeList();
            m_List.Dock = DockStyle.Fill;
            m_List.ShowGroupByBox = true;
            m_List.Parent = containerPanel;
        }

        #endregion

        #region Overrides

        public override void Initialize()
        {
            base.Initialize();

            m_Helper = new NTreeListUCHelper();
            m_Helper.Populate(m_List);
        }

        #endregion

        #region Fields

        internal NTreeList m_List;
        internal NTreeListUCHelper m_Helper;

        #endregion
    }
}
