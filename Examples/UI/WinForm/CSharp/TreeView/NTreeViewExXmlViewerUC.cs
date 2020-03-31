using System;
using System.Xml;
using System.Reflection;
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
    public partial class NTreeViewExXmlViewerUC : NExampleUserControl
    {
        #region Constructor

        public NTreeViewExXmlViewerUC()
        {
            InitializeComponent();

            Dock = DockStyle.Fill;
        }

        #endregion

        #region Overrides

        public override void Initialize()
        {
            base.Initialize();

            embeddedFileBtn_Click(null, null);
        }

        #endregion

        #region Event Handlers

        private void embeddedFileBtn_Click(object sender, EventArgs e)
        {
            Assembly assembly = GetType().Assembly;

            string xml = NResourceHelper.ReadTextResource(assembly, "ExamplesTree.xml", "Nevron.Examples.UI.WinForm.Resources");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            nTreeViewEx1.DisplayXml(doc);

            //this.nTreeViewEx1.SaveToXml(@"C:\Test.xml");
        }
        private void loadFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select XML file:";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                nTreeViewEx1.DisplayXml(ofd.FileName);
            }

            ofd.Dispose();
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
