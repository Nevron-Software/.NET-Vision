using System;
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
    public partial class NTreeViewExFilteringUC : NExampleUserControl
    {
        #region Constructor

        public NTreeViewExFilteringUC()
        {
            InitializeComponent();

            Dock = DockStyle.Fill;
        }

        #endregion

        #region Overrides

        public override void Initialize()
        {
            base.Initialize();

            NTreeViewExUC.AddTestNodes(nTreeViewEx1, 10, 3);

            //init sample filters
            NFilter simpleFilter = new NTreeNodeTextFilter("Sample Tree Node 1", CommonStringOptions.Contains, true);

            NAndFilter compositeFilter = new NAndFilter();
            compositeFilter.Add(new NTreeNodeTextFilter("Sample Tree Node 1", CommonStringOptions.Contains, true));
            compositeFilter.Add(new NTreeNodeTextFilter("Depth: 0", CommonStringOptions.Contains, true));

            NListBoxItem item = new NListBoxItem();
            item.Text = "No Filter";
            filterCombo.Items.Add(item);

            item = new NListBoxItem(simpleFilter);
            item.Text = "Simple Text Filter";
            filterCombo.Items.Add(item);

            item = new NListBoxItem(compositeFilter);
            item.Text = "Composite 'And' Filter";
            filterCombo.Items.Add(item);

            filterCombo.SelectedIndex = 0;
        }

        #endregion

        #region Event Handlers

        private void filterCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (filterCombo.SelectedIndex)
            {
                case 0:
                    nTreeViewEx1.VisibleFilter = null;
                    break;
                case 1:
                    nTreeViewEx1.VisibleFilter = (INFilter)filterCombo.SelectedItem;
                    descriptionLabel.Text = "Simple NTreeNodeTextFilter with string options set to 'Contains' and text to examine set to 'Sample Tree Node 1'.";
                    break;
                case 2:
                    nTreeViewEx1.VisibleFilter = (INFilter)filterCombo.SelectedItem;
                    descriptionLabel.Text = "Composite NAndFilter which contains two NTreeNodeTextFilter instances - one to check for the 'Sample Tree Node 1' and the other for the 'Depth: 0' text.";
                    break;
            }
        }

        #endregion
    }
}
