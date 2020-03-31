using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
    public partial class NTreeViewExUC : NExampleUserControl
    {
        #region Constructor

        public NTreeViewExUC()
        {
            InitializeComponent();

            Dock = DockStyle.Fill;
        }

        #endregion

        #region Overrides

        public override void Initialize()
        {
            base.Initialize();

            Padding = new Padding(2);
            propertyGrid1.SelectedObject = nTreeViewEx1;

            AddTestNodes(nTreeViewEx1, 10, 3);
        }

        #endregion

        #region Event Handlers

        private void addChildBtn_Click(object sender, EventArgs e)
        {
            NTreeNode focused = nTreeViewEx1.FocusedItem as NTreeNode;
            if (focused == null)
            {
                return;
            }

            nTreeViewEx1.Suspend();

            NTreeNode child = new NTreeNode();
            child.Text = "Child Node " + focused.Nodes.Count;
            focused.Nodes.Add(child);
            child.Selected = true;

            nTreeViewEx1.Resume(true);
        }
        private void addSiblingBtn_Click(object sender, EventArgs e)
        {
            NTreeNode focused = nTreeViewEx1.FocusedItem as NTreeNode;
            if (focused == null)
            {
                return;
            }

            NTreeNodeCollection ownerNodes = focused.OwnerCollection as NTreeNodeCollection;
            if (ownerNodes == null)
            {
                return;
            }

            NTreeNode sibling = new NTreeNode();
            sibling.Text = "Sibling " + ownerNodes.Count;
            ownerNodes.Insert(focused.Index + 1, sibling);
            sibling.Selected = true;
        }
        private void addTestNodesBtn_Click(object sender, EventArgs e)
        {
            AddTestNodes(nTreeViewEx1, 10, 3);
        }
        private void removeNodeBtn_Click(object sender, EventArgs e)
        {
            nTreeViewEx1.Suspend();

            NTreeNode[] selected = nTreeViewEx1.SelectedNodes;
            NTreeNodeCollection owner;

            int length = selected.Length;
            NTreeNode current;

            for (int i = 0; i < length; i++)
            {
                current = selected[i];
                owner = current.OwnerCollection as NTreeNodeCollection;

                if (owner == null)
                {
                    continue;
                }

                owner.Remove(current);
            }

            nTreeViewEx1.Resume(true);
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

        #region Static

        internal static void AddTestNodes(NTreeViewEx tree, int siblingCount, int depth)
        {
            tree.Suspend();
            tree.Nodes.Clear();

            NTreeNode node;
            int currDepth = 0;
            NTreeNodeCollection currCollection = tree.Nodes;

            for (int i = 0; i < siblingCount; i++)
            {
                node = new NTreeNode();
                node.Text = "Sample Tree Node " + i + "; Depth: " + currDepth;

                currDepth++;
                AddChildNodes(node.Nodes, siblingCount, ref currDepth, depth);
                currDepth--;

                currCollection.Add(node);
            }

            tree.Resume(true);
        }
        internal static void AddChildNodes(NTreeNodeCollection collection, int siblingCount, ref int currDepth, int depth)
        {
            NTreeNode node;

            for (int i = 0; i < siblingCount; i++)
            {
                node = new NTreeNode();
                node.Text = "Sample Tree Node " + i + "; Depth: " + currDepth;
                collection.Add(node);

                if (currDepth < depth)
                {
                    currDepth++;
                    AddChildNodes(node.Nodes, siblingCount, ref currDepth, depth);
                    currDepth--;
                }
            }
        }

        #endregion
    }
}
