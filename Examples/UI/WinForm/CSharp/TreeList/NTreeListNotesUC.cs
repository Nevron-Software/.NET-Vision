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
    public partial class NTreeListNotesUC : NExampleUserControl
    {
        #region Constructor

        public NTreeListNotesUC()
        {
            InitializeComponent();
        }
        public NTreeListNotesUC(MainForm f) : base(f)
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides

        public override void Initialize()
        {
            base.Initialize();

            Dock = DockStyle.Fill;

            m_List = new NTreeList();
            m_List.Dock = DockStyle.Fill;
            m_List.NotesStyle = TreeListNodeNotesStyle.Show;

            InitColumns();
            InitNodes();

            m_List.BestFitAllNodes();

            m_List.Parent = this;
        }

        #endregion

        #region Implementation

        internal void InitColumns()
        {
            NTreeListColumn column;

            for (int i = 1; i < 4; i++)
            {
                column = new NTreeListColumn();
                column.Name = "Col" + i;
                column.Header.Text = "Column " + i;

                m_List.Columns.Add(column);
            }
        }
        internal void InitNodes()
        {
            NTreeListNode node;
            NTreeListNodeStringSubItem item;

            int nodeCount = 1;

            NFillInfo customFill1 = new NFillInfo();
            customFill1.Gradient1 = NUIManager.Palette.ControlLight;
            customFill1.Gradient2 = NUIManager.Palette.ControlDark;
            customFill1.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.Vista;

            NFillInfo customTextFill1 = new NFillInfo();
            customTextFill1.Gradient1 = Color.Orange;
            customTextFill1.Gradient2 = Color.Black;
            customTextFill1.GradientAngle = 0F;

            Font customFont = new Font("Trebuchet MS", 9, FontStyle.Bold);

            for (int i = 1; i < 21; i++)
            {
                node = new NTreeListNode();

                if (i % 2 == 0)
                {
                    node.NotesFillInfo = customFill1;
                    node.NotesTextFillInfo = customTextFill1;
                    node.NotesFont = customFont;
                    node.NotesFormat = new NGdiPlusTextFormat(StringAlignment.Near, StringAlignment.Center, HotkeyPrefix.Hide, StringTrimming.EllipsisCharacter, StringFormatFlags.NoWrap);
                    node.Notes = "Customized node's notes. You may specify custom back fill, text fill and font for a note.\nYou may also control the text formatting of the notes using the 'NotesFormat' property - the notes of this node do not wrap.";
                }
                else
                {
                    node.Notes = "Each NTreeListNode may be assigned notes. Notes are treated as a 'non-client' area and do not participate in the node's layout logic.";
                }

                for (int j = 1; j < 6; j++)
                {
                    item = new NTreeListNodeStringSubItem();
                    item.Text = "SubItem; Col: " + j + ", Row: " + nodeCount;
                    item.Column = m_List.Columns["Col" + j];

                    node.SubItems.Add(item);
                }

                nodeCount++;
                m_List.Nodes.Add(node);
            }
        }

        #endregion

        #region Fields

        internal NTreeList m_List;

        #endregion
    }
}
