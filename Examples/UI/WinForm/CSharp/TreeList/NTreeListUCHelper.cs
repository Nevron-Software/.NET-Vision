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
    internal class NTreeListUCHelper
    {
        #region Constructor

        internal NTreeListUCHelper()
        {
            m_Images = NResourceHelper.ImageListFromBitmap(GetType(), new Size(16, 16), Color.Transparent, "Outlook.jpg", "Nevron.Examples.UI.WinForm.TreeList.Images");
            m_arrNames = new string[] { "John Doe", "support@nevron.com", "sales@nevron.com", "mail@nevron.com" };
            m_arrSubjects = new string[] { "NTreeList Question", "Re: Help Needed", "Licensing Question", "Nevron UI General Support" };
        }

        #endregion

        #region Implementation

        internal void Dispose()
        {
            m_Images.Dispose();
        }
        internal void Populate(NTreeList list)
        {
            m_List = list;
            m_List.Suspend();

            InitData();

            m_List.GroupBy(m_List.Columns["Received"]);
            m_List.SortColumn(m_List.Columns["Received"], TreeListSortMode.Descending);
            m_List.SortColumn(m_List.Columns["From"], TreeListSortMode.Ascending);

            m_List.ExpandAll();
            m_List.BestFitAllColumns();
            m_List.BestFitAllNodes();


            m_List.Resume(true);
        }

        internal void InitData()
        {
            InitColumns();
            InitRows();
        }
        internal void InitColumns()
        {
            NTreeListColumn col;

            //importance columns
            col = new NTreeListColumn();
            col.Name = "Importance";
            col.Header.Image = m_Images.Images[1];
            col.Header.ImageAlign = ContentAlignment.MiddleCenter;
            col.ContentAlign = ContentAlignment.MiddleCenter;
            col.AutoSizable = false;
            col.Header.TooltipInfo.ContentText = "Importance";
            m_List.Columns.Add(col);

            //icon column
            col = new NTreeListColumn();
            col.Name = "Icon";
            col.Header.TooltipInfo.ContentText = "Message Class";
            col.Header.Image = m_Images.Images[0];
            col.Header.ImageAlign = ContentAlignment.MiddleCenter;
            col.AutoSizable = false;
            m_List.Columns.Add(col);

            //from column
            col = new NTreeListColumn();
            col.Name = "From";
            col.Header.Text = "From";
            col.Header.TooltipInfo.ContentText = "From";
            m_List.Columns.Add(col);

            //subject column
            col = new NTreeListColumn();
            col.Name = "Subject";
            col.Header.Text = "Subject";
            col.Header.TooltipInfo.ContentText = "Subject";
            m_List.Columns.Add(col);

            //received column
            col = new NTreeListColumn();
            col.Name = "Received";
            col.Header.Text = "Received";
            col.Header.TooltipInfo.ContentText = "Received";
            m_List.Columns.Add(col);

            //follow-up column
            col = new NTreeListColumn();
            col.AutoSizable = false;
            col.Header.Image = m_Images.Images[2];
            col.Header.ImageAlign = ContentAlignment.MiddleCenter;
            col.Name = "FollowUp";
            col.Header.Text = "Follow-up";
            col.Header.TooltipInfo.ContentText = "Follow-up";
            m_List.Columns.Add(col);

            //test column
            col = new NTreeListColumn();
            col.AutoSizable = false;
            col.Width = 150;
            col.Name = "PurchaseAmount";
            col.Header.Text = "Purchase Amount";
            col.Header.TooltipInfo.ContentText = "Purchase Amount";
            m_List.Columns.Add(col);
        }
        internal void InitRows()
        {
            NTreeListNode node;
            DateTime date1 = new DateTime(2007, 11, 12);
            DateTime date2 = new DateTime(2007, 11, 13);

            Font testFont = new Font("Segoe UI", 9, FontStyle.Italic | FontStyle.Bold);
            Font testFont1 = new Font("Calibri", 8, FontStyle.Italic | FontStyle.Underline);
            NFillInfo testFill = new NFillInfo();
            testFill.Gradient1 = Color.OrangeRed;
            testFill.Gradient2 = Color.Yellow;
            testFill.GradientStyle = GradientStyle.SigmaBell;

            NFillInfo testTextFill = new NFillInfo();
            testTextFill.FillStyle = FillStyle.Solid;
            testTextFill.Color = Color.Navy;

            for (int i = 1; i < 201; i++)
            {
                node = new NTreeListNode();

                //init items
                //importance sub-item
                NTreeListNodeImageSubItem importanceItem = new NTreeListNodeImageSubItem();
                importanceItem.Image = (i % 2 == 0) ? m_Images.Images[6] : m_Images.Images[1];
                importanceItem.Column = m_List.Columns["Importance"];
                importanceItem.CompareData = i % 2;
                importanceItem.GroupByData = i % 2;
                if (i % 2 == 0)
                {
                    importanceItem.GroupByTitle = "Importance: High";
                }
                else
                {
                    importanceItem.GroupByTitle = "Importance: Normal";
                }
                node.SubItems.Add(importanceItem);

                //icon sub-item
                NTreeListNodeImageSubItem iconItem = new NTreeListNodeImageSubItem();
                iconItem.Image = m_Images.Images[3 + (i % 2)];
                iconItem.Column = m_List.Columns["Icon"];
                iconItem.CompareData = i % 2;
                iconItem.GroupByData = i % 2;
                if (i % 2 == 0)
                {
                    iconItem.GroupByTitle = "Message class: New Message";
                }
                else
                {
                    iconItem.GroupByTitle = "Message class: Message";
                }
                node.SubItems.Add(iconItem);

                //from sub-item
                NTreeListNodeStringSubItem fromItem = new NTreeListNodeStringSubItem();
                fromItem.Text = m_arrNames[i % 4];
                fromItem.Column = m_List.Columns["From"];
                fromItem.Font = testFont;
                //fromItem.FillInfo = testFill;
                fromItem.TextFillInfo = testTextFill;
                node.SubItems.Add(fromItem);

                //subject sub-item
                NTreeListNodeStringSubItem subjectItem = new NTreeListNodeStringSubItem();
                subjectItem.Text = m_arrSubjects[i % 4];
                subjectItem.Column = m_List.Columns["Subject"];
                node.SubItems.Add(subjectItem);

                //received sub-item
                NTreeListNodeDateTimeSubItem receivedItem = new NTreeListNodeDateTimeSubItem();
                if (i % 2 == 0)
                {
                    receivedItem.Value = date1;
                    receivedItem.GroupByTitle = "Date: Yesterday";
                }
                else
                {
                    receivedItem.Value = date2;
                    receivedItem.GroupByTitle = "Date: Today";
                }
                receivedItem.FormatString = "F";
                receivedItem.Column = m_List.Columns["Received"];
                receivedItem.Font = testFont1;
                node.SubItems.Add(receivedItem);

                //follow-up sub-item
                NTreeListNodeBooleanSubItem followItem = new NTreeListNodeBooleanSubItem();
                if (i % 2 == 0)
                {
                    followItem.Value = false;
                    followItem.GroupByTitle = "Follow-up: No";
                }
                else
                {
                    followItem.Value = true;
                    followItem.GroupByTitle = "Follow-up: Yes";
                }
                followItem.Column = m_List.Columns["FollowUp"];
                node.SubItems.Add(followItem);

                //numeric sub-item
                NTreeListNodeNumericSubItem numItem = new NTreeListNodeNumericSubItem();
                numItem.Value = i * 10;
                numItem.FormatString = "$#,###0.00";
                numItem.Column = m_List.Columns["PurchaseAmount"];
                node.SubItems.Add(numItem);

                m_List.Nodes.Add(node);
            }
        }

        #endregion

        #region Fields

        internal NTreeList m_List;
        internal ImageList m_Images;
        internal string[] m_arrNames;
        internal string[] m_arrSubjects;

        #endregion
    }
}
