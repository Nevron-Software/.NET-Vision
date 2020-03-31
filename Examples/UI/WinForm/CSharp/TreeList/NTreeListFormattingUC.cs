using System;
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
    public partial class NTreeListFormattingUC : NExampleUserControl
    {
        #region Constructor

        public NTreeListFormattingUC()
        {
            InitializeComponent();

            Dock = DockStyle.Fill;

            m_List = new NTreeList();
            m_List.Dock = DockStyle.Fill;
            m_List.AutoSizeColumns = false;
            //m_List.EnableGroupBy = false;

            m_List.Parent = this;
        }

        #endregion

        #region Overrides

        public override void Initialize()
        {
            base.Initialize();

            m_List.Suspend();

            InitColumns();
            InitNodes();

            //m_List.BestFitAllColumns();
            m_List.BestFitAllNodes();
            m_List.BestFitColumnHeaderHeight();

            m_List.Resume(true);
        }

        #endregion

        #region Implementation

        internal void InitColumns()
        {
            NTreeListColumn column;
            m_List.HeaderNormalState.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            m_List.HeaderHotState.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            m_List.HeaderPressedState.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            //text column
            column = new NTreeListColumn();
            column.Name = "StringColumn";
            column.Header.Text = "<font color='Red'><b>String Column</b></font><br/><font size='7'>Displays strings.</font>";
            column.Header.TextProcessMode = ItemTextProcessMode.RichText;
            column.ContentAlign = ContentAlignment.MiddleCenter;
            column.Width = 160;
            m_List.Columns.Add(column);

            //image column
            column = new NTreeListColumn();
            column.Name = "ImageColumn";
            column.Header.Text = "<font color='Navy'><b>Image Column</b></font><br/><font size='7'>Displays images.</font>";
            column.Header.TextProcessMode = ItemTextProcessMode.RichText;
            column.ContentAlign = ContentAlignment.MiddleCenter;
            column.Width = 120;
            m_List.Columns.Add(column);

            //numeric column
            column = new NTreeListColumn();
            column.Name = "NumColumn";
            column.Header.Text = "<font color='Brown'><b>Numeric Column</b></font><br/><font size='7'>Displays numbers.</font>";
            column.Header.TextProcessMode = ItemTextProcessMode.RichText;
            column.ContentAlign = ContentAlignment.MiddleCenter;
            column.Width = 120;
            m_List.Columns.Add(column);

            //date-time column
            column = new NTreeListColumn();
            column.Name = "DateColumn";
            column.Header.Text = "<font color='Orange'><b>DateTime Column</b></font><br/><font size='7'>Displays DateTime values.</font>";
            column.Header.TextProcessMode = ItemTextProcessMode.RichText;
            column.ContentAlign = ContentAlignment.MiddleCenter;
            column.Width = 220;
            m_List.Columns.Add(column);

            //boolean column
            column = new NTreeListColumn();
            column.Name = "BoolColumn";
            column.Header.Text = "<font color='Violet'><b>Boolen Column</b></font><br/><font size='7'>Displays Boolean values.</font>"; ;
            column.Header.TextProcessMode = ItemTextProcessMode.RichText;
            column.ContentAlign = ContentAlignment.MiddleCenter;
            column.Width = 140;
            m_List.Columns.Add(column);
        }
        internal void InitNodes()
        {
            NTreeListNode node;
            Font boldFont = new Font("Trebuchet MS", 10F, FontStyle.Bold);
            Font dateFont = new Font("Verdana", 8F, FontStyle.Underline);
            NFillInfo textFill = new NFillInfo();
            textFill.Gradient1 = Color.WhiteSmoke;
            textFill.Gradient2 = Color.YellowGreen;
            textFill.GradientAngle = 0F;

            NFillInfo numFill = new NFillInfo();
            numFill.Gradient1 = Color.Yellow;
            numFill.Gradient2 = Color.OrangeRed;
            numFill.GradientAngle = 45F;

            NFillInfo boolFill = new NFillInfo();
            boolFill.Gradient2 = Color.Yellow;
            boolFill.Gradient1 = Color.Green;
            boolFill.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.Vista;
            boolFill.GradientAngle = 135F;

            long ticks = DateTime.Now.Ticks;

            for (int i = 1; i < 31; i++)
            {
                node = new NTreeListNode();

                //text sub-item
                NTreeListNodeStringSubItem stringItem = new NTreeListNodeStringSubItem();
                stringItem.Text = "String SubItem " + i;
                stringItem.Font = boldFont;
                stringItem.FillInfo = textFill;
                stringItem.Column = m_List.Columns[0];
                node.SubItems.Add(stringItem);

                //image sub-item
                NTreeListNodeImageSubItem imageItem = new NTreeListNodeImageSubItem();
                imageItem.Image = NSystemImages.Information;
                imageItem.Column = m_List.Columns[1];
                imageItem.ImageSize = new NSize(32, 32);
                node.SubItems.Add(imageItem);

                //numeric sub-item
                NTreeListNodeNumericSubItem numItem = new NTreeListNodeNumericSubItem();
                numItem.Value = i * 10;
                numItem.FormatString = "$#,###0.00";
                numItem.Column = m_List.Columns[2];
                numItem.FillInfo = numFill;
                node.SubItems.Add(numItem);

                //date sub-item
                NTreeListNodeDateTimeSubItem dateItem = new NTreeListNodeDateTimeSubItem();
                dateItem.Value = new DateTime(ticks + i * 10000000);
                dateItem.FormatString = "F";
                dateItem.Font = dateFont;
                dateItem.RenderingHint = TextRenderingHint.ClearTypeGridFit;
                dateItem.Column = m_List.Columns[3];
                node.SubItems.Add(dateItem);

                //bool sub-item
                NTreeListNodeBooleanSubItem boolItem = new NTreeListNodeBooleanSubItem();
                boolItem.Value = (i % 2) == 0;
                boolItem.Column = m_List.Columns[4];
                boolItem.FillInfo = boolFill;
                node.SubItems.Add(boolItem);

                m_List.Nodes.Add(node);
            }
        }

        #endregion

        #region Fields

        internal NTreeList m_List;

        #endregion
    }
}
