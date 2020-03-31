using System;
using System.Windows.Forms;

using Nevron.Diagram;
using Nevron.Diagram.WinForm;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
    /// Summary description for NClickomaniaUC.
	/// </summary>
	public class NClickomaniaUC : NDiagramExampleUC
	{
		#region Constructors

        public NClickomaniaUC(NMainForm form)
            : base(form)
		{
			InitializeComponent();
		}

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NClickomaniaUC));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.AliceBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = "Clickomania";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.LemonChiffon;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(4, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 181);
            this.label2.TabIndex = 2;
            this.label2.Text = resources.GetString("label2.Text");
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NTableShapeEventsUC
            // 
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NTableShapeEventsUC";
            this.Size = new System.Drawing.Size(248, 384);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// begin view init
			view.BeginInit();

			// init view
			view.ViewLayout = ViewLayout.Fit;
			view.DocumentPadding = new Nevron.Diagram.NMargins(10);
			view.Grid.Visible = false;
			view.GlobalVisibility.ShowPorts = false;
            view.HorizontalRuler.Visible = false;
            view.VerticalRuler.Visible = false;
            view.Controller.Tools.DisableTools(new string[] { NDWFR.ToolSelector });

			// init document
			document.BeginInit();
			InitDocument();
			document.EndInit();

            // end view init
            view.EndInit();
		}

        protected override void AttachToEvents()
        {
            document.EventSinkService.NodeMouseDown += new NodeMouseEventHandler(EventSinkService_NodeMouseDown);

            base.AttachToEvents();
        }

        protected override void DetachFromEvents()
        {
            document.EventSinkService.NodeMouseDown -= new NodeMouseEventHandler(EventSinkService_NodeMouseDown);

            base.DetachFromEvents();
        }

		#endregion

		#region Implementation

		private void InitDocument()
		{
            // Create the stylesheets
            int i = 0, count = GradientSchemes.Length;
            cells = new int[count];

            for (i = 0; i < count; i++)
            {
                NStyleSheet styleSheet = new NStyleSheet(GradientSchemes[i].ToString());
                NStyle.SetFillStyle(styleSheet, new NAdvancedGradientFillStyle(GradientSchemes[i], 4));
                document.StyleSheets.AddChild(styleSheet);
                cells[i] = 0;
            }

            // Create the table
            score = 0;            
            table = CreateTableShape();
            info = CreateInfoShape();
            table.Location = new NPointF(info.Bounds.Right + info.Width / 2, table.Location.Y);

            // Resize the document to fit all shapes
            document.SizeToContent();
		}
        private void ApplyProtections(NShape shape)
        {
            NAbilities protection = shape.Protection;
            protection.MoveX = true;
            protection.MoveY = true;
            protection.InplaceEdit = true;
            protection.Select = true;
            shape.Protection = protection;
        }
        private NTableShape CreateTableShape()
		{
            NTableShape shape = new NTableShape();
            document.ActiveLayer.AddChild(shape);

            shape.InitTable(ColCount, RowCount);
            shape.BeginUpdate();

            int i, j, index;
            int colorCount = GradientSchemes.Length;
            Random random = new Random();

            for (i = 0; i < RowCount; i++)
            {
                for (j = 0; j < ColCount; j++)
                {
                    shape[j, i].Text = CellText;
                    index = random.Next(colorCount);
                    cells[index]++;
                    shape[j, i].StyleSheetName = GradientSchemes[index].ToString();
                }
            }

            shape.EndUpdate();
            ApplyProtections(shape);

            return shape;
		}
        private NTableShape CreateInfoShape()
        {
            NTableShape shape = new NTableShape();
            document.ActiveLayer.AddChild(shape);

            int i, count = GradientSchemes.Length;
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
                shape[0, i + 1].StyleSheetName = GradientSchemes[i].ToString();
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
            ApplyProtections(shape);

            return shape;
        }
        private void UpdateInfo()
        {
            int i, count = GradientSchemes.Length;
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
				if (IsEmptyToTop(j, rowCount - 1))
				{
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
					if (cell.StyleSheetName != string.Empty)
					{
						if (Test(j, i, cell.StyleSheetName))
							return false;
					}
                }
            }

            return true;
        }
        private int IndexOf(string color)
        {
            int i, count = GradientSchemes.Length;
            for (i = 0; i < count; i++)
            {
                if (GradientSchemes[i].ToString() == color)
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

        private void EventSinkService_NodeMouseDown(NNodeMouseEventArgs args)
        {
            NTableCell cell = args.Node as NTableCell;
            if (cell == null)
                return;

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
                        status = "Congratulations you've cleared all cells !!!" + Environment.NewLine;
                    }

                    if (status == string.Empty && GameOver())
                    {
                        status = "Game Over !" + Environment.NewLine;
                    }

                    if (status != string.Empty)
                    {
                        status += "Your score is " + score.ToString();
                        MessageBox.Show(status);
                    }
                }
            }

            args.Handled = true;
        }

        #endregion

        #region Designer Fields

        private System.ComponentModel.Container components = null;
        private Label label1;
        private Label label2;

		#endregion

		#region Fields

        private NTableShape table;
        private NTableShape info;
        private int score;
        private int[] cells;

		#endregion

        #region Constants

        private const int RowCount = 20;
        private const int ColCount = 15;
        private const string CellText = " ";

        private static readonly AdvancedGradientScheme[] GradientSchemes = new AdvancedGradientScheme[] {
            AdvancedGradientScheme.Red,
            AdvancedGradientScheme.Blue,
            AdvancedGradientScheme.Green,
            AdvancedGradientScheme.Sunset };

        #endregion
    }
}