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
    public partial class NTreeListUC : NExampleUserControl
    {
        #region Constructor

        public NTreeListUC()
        {
            InitializeComponent();

            Dock = DockStyle.Fill;

            m_List = new NTreeList();
            m_List.Dock = DockStyle.Fill;
            m_List.Parent = containerPanel;
        }

        #endregion

        #region Public Overrides

        public override void Initialize()
        {
            base.Initialize();

            m_List.Suspend();

            InitColumns();
            InitNodes();

            propertyGrid1.SelectedObject = m_List;

            m_List.AutoSizeColumns = false;
            m_List.NotesStyle = TreeListNodeNotesStyle.Show;

            m_List.BestFitAllColumns();
            m_List.BestFitAllNodes();

            m_List.Resume(true);
        }

        #endregion

        #region Implementation

        internal void InitColumns()
        {
            NTreeListColumn column;

            for (int i = 1; i < 6; i++)
            {
                column = new NTreeListColumn();
                if (i == 1)
                {
                    column.PinMode = TreeListColumnPinMode.Left;
                }

                column.Name = "Col" + i;
                column.Header.Text = "Column " + i;

                m_List.Columns.Add(column);
            }
        }
        internal void InitNodes()
        {
            NTreeListNode node1;
            NTreeListNodeStringSubItem item;

            int nodeCount = 1;

            for (int i = 1; i < 101; i++)
            {
                node1 = new NTreeListNode();

                for (int j = 1; j < 6; j++)
                {
                    item = new NTreeListNodeStringSubItem();
                    item.Text = "SubItem; Col: " + j + ", Row: " + nodeCount;
                    item.Column = m_List.Columns["Col" + j];

                    node1.SubItems.Add(item);
                }

                nodeCount++;
                m_List.Nodes.Add(node1);
            }
        }

        #endregion

        #region Static

        internal static void InitDefaultColumns(NTreeList list)
        {
            NTreeListColumn column;

            //text column
            column = new NTreeListColumn();
            column.Name = "StringColumn";
            column.Header.Text = "String Column";
            column.ContentAlign = ContentAlignment.MiddleCenter;
            column.Width = 150;
            list.Columns.Add(column);

            //image column
            column = new NTreeListColumn();
            column.Name = "ImageColumn";
            column.Header.Text = "Image Column";
            column.ContentAlign = ContentAlignment.MiddleCenter;
            column.Width = 100;
            list.Columns.Add(column);

            //numeric column
            column = new NTreeListColumn();
            column.Name = "NumColumn";
            column.Header.Text = "Numeric Column";
            column.ContentAlign = ContentAlignment.MiddleCenter;
            column.Width = 100;
            list.Columns.Add(column);

            //date-time column
            column = new NTreeListColumn();
            column.Name = "DateColumn";
            column.Header.Text = "Date Column";
            column.ContentAlign = ContentAlignment.MiddleCenter;
            column.Width = 200;
            list.Columns.Add(column);

            //boolean column
            column = new NTreeListColumn();
            column.Name = "BoolColumn";
            column.Header.Text = "Boolean Column";
            column.ContentAlign = ContentAlignment.MiddleCenter;
            column.Width = 100;
            list.Columns.Add(column);
        }
        internal static void InitDefaultNodes(NTreeList list, int nodeCount)
        {
            NTreeListNode node;

            long ticks = DateTime.Now.Ticks;

            for (int i = 1; i < nodeCount; i++)
            {
                node = new NTreeListNode();

                //text sub-item
                NTreeListNodeStringSubItem stringItem = new NTreeListNodeStringSubItem();
                stringItem.Text = "String SubItem " + i;
                stringItem.Column = list.Columns[0];
                node.SubItems.Add(stringItem);

                //image sub-item
                NTreeListNodeImageSubItem imageItem = new NTreeListNodeImageSubItem();
                imageItem.Image = NSystemImages.Information;
                imageItem.Column = list.Columns[1];
                node.SubItems.Add(imageItem);

                //numeric sub-item
                NTreeListNodeNumericSubItem numItem = new NTreeListNodeNumericSubItem();
                numItem.Value = i * 10;
                numItem.FormatString = "$#,###0.00";
                numItem.Column = list.Columns[2];
                node.SubItems.Add(numItem);

                //date sub-item
                NTreeListNodeDateTimeSubItem dateItem = new NTreeListNodeDateTimeSubItem();
                dateItem.Value = new DateTime(ticks + i * 10000000);
                dateItem.FormatString = "F";
                dateItem.Column = list.Columns[3];
                node.SubItems.Add(dateItem);

                //bool sub-item
                NTreeListNodeBooleanSubItem boolItem = new NTreeListNodeBooleanSubItem();
                boolItem.Value = (i % 2) == 0;
                boolItem.Column = list.Columns[4];
                node.SubItems.Add(boolItem);

                list.Nodes.Add(node);
            }
        }
        internal static void InitDefaultList(NTreeList list, int nodeCount)
        {
            InitDefaultColumns(list);
            InitDefaultNodes(list, nodeCount);
        }

        #endregion

        #region Fields

        internal NTreeList m_List;

        #endregion
    }
}
