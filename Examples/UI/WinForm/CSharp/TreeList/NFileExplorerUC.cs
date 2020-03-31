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
    public partial class NFileExplorerUC : NExampleUserControl
    {
        #region Constructor

        public NFileExplorerUC()
        {
            InitializeComponent();
        }
        public NFileExplorerUC(MainForm f) : base(f)
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides

        public override void Initialize()
        {
            base.Initialize();

            Dock = DockStyle.Fill;

            m_FileExplorer = new NFileExplorer();
            m_FileExplorer.AutoSizeColumns = false;
            m_FileExplorer.Dock = DockStyle.Fill;

            m_FileExplorer.Populate();

            m_FileExplorer.Parent = this;
        }

        #endregion

        #region Fields

        internal NFileExplorer m_FileExplorer;

        #endregion
    }
}
