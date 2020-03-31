using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Data;
using System.Windows.Forms;

using Nevron.Filters;
using Nevron.GraphicsCore;
using Nevron.UI;
using Nevron.UI.WinForm;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
    public partial class NTreeViewExSortingUC : NExampleUserControl
    {
        #region Constructor

        public NTreeViewExSortingUC()
        {
            InitializeComponent();
        }
        public NTreeViewExSortingUC(MainForm f) : base(f)
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides

        public override void Initialize()
        {
            base.Initialize();

            Dock = DockStyle.Fill;

            m_Tree = new NTreeViewEx();
            m_Tree.Dock = DockStyle.Fill;

            NTreeViewExUC.AddTestNodes(m_Tree, 5, 2);

            m_Tree.ExpandAll();

            m_Tree.Parent = containerPanel;
        }

        #endregion

        #region Event Handlers

        private void sortAscendingBtn_Click(object sender, EventArgs e)
        {
            m_Tree.Nodes.Sort(true, this.recursiveSortCheck.Checked);
        }
        private void sortDescendingBtn_Click(object sender, EventArgs e)
        {
            m_Tree.Nodes.Sort(false, this.recursiveSortCheck.Checked);
        }

        #endregion

        #region Fields

        internal NTreeViewEx m_Tree;

        #endregion
    }
}
