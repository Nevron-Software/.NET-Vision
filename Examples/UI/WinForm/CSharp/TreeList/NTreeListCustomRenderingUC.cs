using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI;
using Nevron.UI.WinForm;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
    public partial class NTreeListCustomRenderingUC : NExampleUserControl
    {
        #region Constructor

        public NTreeListCustomRenderingUC()
        {
			m_List = new NTreeList();
			InitializeComponent();

			Dock = DockStyle.Fill;
			
			m_List.Dock = DockStyle.Fill;
			//m_List.AutoSizeColumns = false;
			m_List.EnableGroupBy = false;

			m_HeaderRenderer = new NTreeListCustomHeaderRenderer();
			m_SubItemRenderer = new NTreeListCustomSubItemRenderer();

			m_List.HeaderRenderer = m_HeaderRenderer;
			m_List.SubItemRenderer = m_SubItemRenderer;

			m_List.Parent = containerPanel;
        }

        #endregion

        #region Overrides

        public override void Initialize()
        {
            base.Initialize();

            m_List.Suspend();

            NTreeListUC.InitDefaultList(m_List, 31);

            //m_List.BestFitAllColumns();
            m_List.BestFitAllNodes();

            m_List.Resume(true);
        }

        #endregion

        #region Event Handlers

        private void headerRendererCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (headerRendererCheck.Checked)
            {
                m_List.HeaderRenderer = m_HeaderRenderer;
            }
            else
            {
                m_List.HeaderRenderer = null;
            }
        }
        private void subItemRendererCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (subItemRendererCheck.Checked)
            {
                m_List.SubItemRenderer = m_SubItemRenderer;
            }
            else
            {
                m_List.SubItemRenderer = null;
            }
        }
        private void autoSizeCheck_CheckedChanged(object sender, EventArgs e)
        {
            m_List.AutoSizeColumns = autoSizeCheck.Checked;
        }

        #endregion

        #region Fields

        internal NTreeList m_List;
        internal NTreeListCustomHeaderRenderer m_HeaderRenderer;
        internal NTreeListCustomSubItemRenderer m_SubItemRenderer;

        #endregion
    }
}
