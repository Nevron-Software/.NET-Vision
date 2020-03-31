using System;

using Nevron.Diagram;
using Nevron.Diagram.Filters;
using Nevron.Dom;
using Nevron.Examples.Diagram.Webform;
using Nevron.Filters;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;
using System.Windows.Forms;
using System.Drawing;

namespace Nevron.Examples.Diagram.Webform
{
    public partial class NClickomaniaGameDiagramUC : NDiagramExampleUC
    {
        #region Properties

        public NDrawingDocument document
        {
            get
            {
                return NDrawingView1.Document;
            }
        }
        public NTableShape table
        {
            get
            {
                if (m_Table == null)
                {
                    m_Table = document.ActiveLayer.GetChildByName("Table") as NTableShape;
                }

                return m_Table;
            }
        }
        public NTableShape info
        {
            get
            {
                if (m_Info == null)
                {
                    m_Info = document.ActiveLayer.GetChildByName("Info") as NTableShape;
                }

                return m_Info;
            }
        }
        public int[] cells
        {
            get
            {
                if (m_Cells == null)
                {
                    m_Cells = document.Tag as int[];
                }

                return m_Cells;
            }
        }
        public int score
        {
            get
            {
                if (m_Score == 0)
                {
                    m_Score = (int)document.ActiveLayer.Tag;
                }

                return m_Score;
            }
            set
            {
                m_Score = value;
                document.ActiveLayer.Tag = m_Score;
            }
        }

        #endregion

        #region Implementation
        
        private void InitDocument()
        {
            // Set up visual formatting
            document.BackgroundStyle.FrameStyle.Visible = false;

            // Create the stylesheets
            int i = 0, count = COLORS.Length;
            m_Cells = new int[count];
            for (i = 0; i < count; i++)
            {
                NStyleSheet styleSheet = new NStyleSheet(COLORS[i].ToString());
                NStyle.SetFillStyle(styleSheet, new NAdvancedGradientFillStyle(COLORS[i], 4));
                document.StyleSheets.AddChild(styleSheet);
                cells[i] = 0;
            }

            // Create the table
            score = 0;
            CreateTableShape();
            CreateInfoShape();
            table.Location = new NPointF(info.Bounds.Right + info.Width / 2, table.Location.Y);

            // Resize the document to fit all shapes
            document.SizeToContent();
            document.Tag = m_Cells;
            document.ActiveLayer.Tag = m_Score;
        }
        private NTableShape CreateTableShape()
        {
            NTableShape shape = new NTableShape();
            shape.Name = "Table";
            document.ActiveLayer.AddChild(shape);

            shape.InitTable(TABLE_COLS, TABLE_ROWS);
            shape.BeginUpdate();

            int i, j, index;
            int colorCount = COLORS.Length;
            Random random = new Random();

            for (i = 0; i < TABLE_ROWS; i++)
            {
                for (j = 0; j < TABLE_COLS; j++)
                {
                    shape[j, i].Text = CELL_TEXT;
                    index = random.Next(colorCount);
                    cells[index]++;
                    shape[j, i].StyleSheetName = COLORS[index].ToString();
                }
            }

            shape.EndUpdate();
            return shape;
        }
        private NTableShape CreateInfoShape()
        {
            NTableShape shape = new NTableShape();
            shape.Name = "Info";
            document.ActiveLayer.AddChild(shape);

            int i, count = COLORS.Length;
            shape.InitTable(2, count + 2);
            shape.BeginUpdate();

            shape.ShowGrid = false;
            ((NTableColumn)shape.Columns.GetChildAt(0)).SizeMode = TableColumnSizeMode.Fixed;

            shape[0, 0].ColumnSpan = 2;
            shape[0, 0].Padding = new Nevron.Diagram.NMargins(2, 2, 2, 0);
            shape[0, 0].Borders = TableCellBorder.Bottom;
            shape[0, 0].Text = "Cells:";

            for (i = 0; i < count; i++)
            {
                shape[0, i + 1].Text = " ";
                shape[0, i + 1].StyleSheetName = COLORS[i].ToString();
                shape[0, i + 1].Margins = new Nevron.Diagram.NMargins(2, 2, 5, 5);
                shape[0, i + 1].Borders = TableCellBorder.All;
                shape[1, i + 1].Text = cells[i].ToString();
                shape[1, i + 1].Padding = new Nevron.Diagram.NMargins(0, 0, 1, 0);
            }

            shape[0, i + 1].ColumnSpan = 2;
            shape[0, i + 1].Padding = new Nevron.Diagram.NMargins(2, 2, 2, 0);
            shape[0, i + 1].Borders = TableCellBorder.Top;
            shape[0, i + 1].Text = string.Format("Score:{0}{1}", Environment.NewLine, score);

            shape.EndUpdate();
            return shape;
        }
        private void UpdateInfo()
        {
            int i, count = COLORS.Length;
            info.BeginUpdate();

            for (i = 0; i < count; i++)
            {
                info[1, i + 1].Text = cells[i].ToString();
            }

            // Update the score
            info[0, i + 1].Text = string.Format("Score:{0}{1}", Environment.NewLine, score);
            info.EndUpdate();
        }
       
        #endregion

        #region Clickomania Game

        /// <summary>
        /// Returns the address of the given cell in the table.
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private NPoint GetCellAddress(NTableCell cell)
        {
            int i, j;
            int rowCount = table.RowCount;
            int columnCount = table.ColumnCount;

            for (i = 0; i < rowCount; i++)
            {
                for (j = 0; j < columnCount; j++)
                {
                    if (table[j, i] == cell)
                        return new NPoint(j, i);
                }
            }

            return new NPoint(-1, -1);
        }
        /// <summary>
        /// Tests if a region of at least 2 cells with the same color is clicked.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        private bool Test(int x, int y, string color)
        {
            if (x > 0 && table[x - 1, y].StyleSheetName == color)
                return true;

            if (x < table.ColumnCount - 1 && table[x + 1, y].StyleSheetName == color)
                return true;

            if (y > 0 && table[x, y - 1].StyleSheetName == color)
                return true;

            if (y < table.RowCount - 1 && table[x, y + 1].StyleSheetName == color)
                return true;

            return false;
        }
        /// <summary>
        /// Clears recursively the whole region, starting with the specified cell.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        /// <param name="total"></param>
        private void ClearCell(int x, int y, string color, ref int total)
        {
            total++;
            table[x, y].StyleSheetName = string.Empty;

            if (x > 0 && table[x - 1, y].StyleSheetName == color)
                ClearCell(x - 1, y, color, ref total);

            if (x < table.ColumnCount - 1 && table[x + 1, y].StyleSheetName == color)
                ClearCell(x + 1, y, color, ref total);

            if (y > 0 && table[x, y - 1].StyleSheetName == color)
                ClearCell(x, y - 1, color, ref total);

            if (y < table.RowCount - 1 && table[x, y + 1].StyleSheetName == color)
                ClearCell(x, y + 1, color, ref total);
        }
        /// <summary>
        /// Checks if a column is empty from the given row index to the top.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool IsEmptyToTop(int x, int y)
        {
            for (int i = y; i >= 0; i--)
            {
                if (table[x, i].StyleSheetName != string.Empty)
                    return false;
            }

            return true;
        }
        /// <summary>
        /// Applies top to bottom and right to left gravity forces to the table.
        /// </summary>
        private void ApplyGravity()
        {
            int i, j, z;
            int rowCount = table.RowCount;
            int columnCount = table.ColumnCount;

            // Top to bottom gravity force
            for (j = 0; j < columnCount; j++)
            {
                for (i = rowCount - 1; i > 0; i--)
                {
                    if (table[j, i].StyleSheetName == string.Empty)
                    {   // Shift the column down by 1 cell
                        if (IsEmptyToTop(j, i - 1))
                            break;

                        for (z = i; z > 0; z--)
                        {
                            table[j, z].StyleSheetName = table[j, z - 1].StyleSheetName;
                        }

                        table[j, 0].StyleSheetName = string.Empty;
                        i++;
                    }
                }
            }

            // Right to left gravity force
            for (j = columnCount - 2; j >= 0; j--)
            {
                if (!IsEmptyToTop(j, rowCount - 1))
                    continue;

                // Shift columns to the left
                for (i = 0; i < rowCount; i++)
                {
                    for (z = j; z < columnCount - 1; z++)
                    {
                        table[z, i].StyleSheetName = table[z + 1, i].StyleSheetName;
                    }

                    table[z, i].StyleSheetName = string.Empty;
                }
            }
        }
        /// <summary>
        /// Returns true if all cells are cleared.
        /// </summary>
        /// <returns></returns>
        private bool AllClear()
        {
            int i, count = cells.Length;
            for (i = 0; i < count; i++)
            {
                if (cells[i] != 0)
                    return false;
            }

            return true;
        }
        /// <summary>
        /// Returns true if there are no more regions to remove.
        /// </summary>
        /// <returns></returns>
        private bool GameOver()
        {
            int i, j;
            int rowCount = table.RowCount;
            int columnCount = table.ColumnCount;
            NTableCell cell;

            for (i = rowCount - 1; i >= 0; i--)
            {
                for (j = 0; j < columnCount; j++)
                {
                    cell = table[j, i];
                    if (cell.StyleSheetName == string.Empty)
                        continue;

                    if (Test(j, i, cell.StyleSheetName))
                        return false;
                }
            }

            return true;
        }
        private int IndexOf(string color)
        {
            int i, count = COLORS.Length;
            for (i = 0; i < count; i++)
            {
                if (COLORS[i].ToString() == color)
                    return i;
            }

            return -1;
        }
        /// <summary>
        /// Handles a cell click. Returns true if the player clicked on a region.
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private bool CellClicked(NTableCell cell)
        {
            NPoint p = GetCellAddress(cell);
            string color = cell.StyleSheetName;

            if (!Test(p.X, p.Y, color))
                return false;

            int cellsCleared = 0;
            ClearCell(p.X, p.Y, color, ref cellsCleared);

            cells[IndexOf(color)] -= cellsCleared;
            cellsCleared--;
            score += cellsCleared * cellsCleared;

            ApplyGravity();
            return true;
        }

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (NDrawingView1.RequiresInitialization)
            {
                base.DefaultGridOrigin = new NPointF(30, 30);
                base.DefaultGridCellSize = new NSizeF(100, 50);
                base.DefaultGridSpacing = new NSizeF(50, 40);

                // begin view init
                NDrawingView1.ViewLayout = CanvasLayout.Fit;

                if (!IsPostBack)
                {
                    // init document
                    document.BeginInit();
                    InitDocument();
                    document.EndInit();
                }
            }
        }
        protected void NDrawingView1_QueryAjaxTools(object sender, EventArgs e)
        {
            NDrawingView1.AjaxTools.Add(new NAjaxMouseClickCallbackTool(true, true));
            NDrawingView1.AjaxTools.Add(new NAjaxTooltipTool(true));
            NDrawingView1.AjaxTools.Add(new NAjaxDynamicCursorTool(true));
        }
        protected void NDrawingView1_AsyncClick(object sender, EventArgs e)
        {
            NCallbackMouseEventArgs args = e as NCallbackMouseEventArgs;

            NNodeList nodes = NDrawingView1.HitTest(args);
            NNodeList shapes = nodes.Filter(CELL_FILTER);

            if (shapes.Count == 0)
                return;

            NTableCell cell = (NTableCell)shapes[0];
            if (cell.ParentNode.ParentNode != table)
                return;

            if (cell.StyleSheetName != null && cell.StyleSheetName != string.Empty)
            {
                if (CellClicked(cell))
                {
                    UpdateInfo();

                    // Check for end of the game
                    string status = string.Empty;
                    if (AllClear())
                    {
                        score *= 2;
                        status = "You've cleared all cells !!!" + Environment.NewLine;
                    }

                    if (status == string.Empty && GameOver())
                    {
                        status = "Game Over !" + Environment.NewLine;
                    }

                    if (status != string.Empty)
                    {
                        status += "Your score is " + score.ToString();
                        NTableShape gameOver = new NTableShape();
                        document.ActiveLayer.AddChild(gameOver);

                        gameOver.BeginUpdate();
                        gameOver.CellPadding = new Nevron.Diagram.NMargins(2, 2, 8, 8);
                        gameOver[0, 0].Text = status;

                        NStyle.SetFillStyle(gameOver, new NAdvancedGradientFillStyle(AdvancedGradientScheme.Ocean1, 0));
                        NStyle.SetStrokeStyle(gameOver, new NStrokeStyle(Color.DarkBlue));

                        NTextStyle textStyle = (NTextStyle)table.ComposeTextStyle().Clone();
                        textStyle.FillStyle = new NColorFillStyle(Color.DarkBlue);
                        NStyle.SetTextStyle(gameOver, textStyle);

                        gameOver.EndUpdate();
                        gameOver.Center = table.Center;
                    }
                }
            }
        }

        #endregion

        #region Fields

        private NTableShape m_Table;
        private NTableShape m_Info;
        private int m_Score;
        private int[] m_Cells;

        #endregion

        #region Static

        private const int TABLE_ROWS = 20;
        private const int TABLE_COLS = 15;
        private const string CELL_TEXT = " ";
        private static readonly NFilter CELL_FILTER = new NInstanceOfTypeFilter(typeof(NTableCell));

        private static readonly AdvancedGradientScheme[] COLORS = new AdvancedGradientScheme[] {
            AdvancedGradientScheme.Red,
            AdvancedGradientScheme.Blue,
            AdvancedGradientScheme.Green,
            AdvancedGradientScheme.Sunset };

        #endregion
    }
}