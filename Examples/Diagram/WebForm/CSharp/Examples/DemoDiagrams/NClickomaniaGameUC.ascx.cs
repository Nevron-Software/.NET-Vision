using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Nevron.Diagram;
using Nevron.Diagram.ThinWeb;
using Nevron.Dom;
using Nevron.Filters;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Diagram.Webform
{
    public partial class NClickomaniaGameUC : NDiagramExampleUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (NThinDiagramControl1.Initialized == false)
			{
				// Configure the thin diagram control
				NThinDiagramControl1.AutoUpdateCallback = new NAutoUpdateCallback();
				NThinDiagramControl1.ServerSettings.AutoUpdateInterval = 300;
				NThinDiagramControl1.ServerSettings.EnableAutoUpdate = false;

				// Init view
				NThinDiagramControl1.View.Layout = CanvasLayout.Normal;

				// Configure the controller
				NServerMouseEventTool serverMouseEventTool = new NServerMouseEventTool();
				NThinDiagramControl1.Controller.Tools.Add(serverMouseEventTool);
				serverMouseEventTool.MouseDown = new NMouseDownEventCallback();

				// Init document
				NDrawingDocument document = NThinDiagramControl1.Document;
				document.BeginInit();
				InitDocument(document);
				document.EndInit();
			}
        }

        #region Implementation
        
        private void InitDocument(NDrawingDocument document)
        {
            // Set up visual formatting
			document.BackgroundStyle.FrameStyle.Visible = false;
			document.Style.TextStyle.FontStyle = new NFontStyle(document.Style.TextStyle.FontStyle.Name, 14);

            // Create the stylesheets
            int i = 0;
			int count = GradientSchemes.Length;

            for (i = 0; i < count; i++)
            {
				AdvancedGradientScheme scheme = GradientSchemes[i];
                NStyleSheet styleSheet = new NStyleSheet(scheme.ToString());
				NAdvancedGradientFillStyle fill = new NAdvancedGradientFillStyle(scheme, 4);
				if (scheme.Equals(AdvancedGradientScheme.Green))
				{
					// Make the green color dark
					((NAdvancedGradientPoint)fill.Points[0]).Color = Color.FromArgb(0, 128, 0);
				}
                NStyle.SetFillStyle(styleSheet, fill);
                document.StyleSheets.AddChild(styleSheet);
				
				NAdvancedGradientFillStyle highlightedFill = (NAdvancedGradientFillStyle)fill.Clone();
				((NAdvancedGradientPoint)highlightedFill.Points[0]).Color = ControlPaint.LightLight(((NAdvancedGradientPoint)fill.Points[0]).Color);
				NStyleSheet highlightedStyleSheet = new NStyleSheet(styleSheet.Name + HighlightedSuffix);
				NStyle.SetFillStyle(highlightedStyleSheet, highlightedFill);
				document.StyleSheets.AddChild(highlightedStyleSheet);
            }

            // Create the board and info shapes
			NClickomaniaGame game = new NClickomaniaGame();
			CreateBoardShape(document, game);
			CreateInfoShape(document, game);
			game.BoardShape.Location = new NPointF(game.InfoShape.Bounds.Right + game.InfoShape.Width / 2, game.BoardShape.Location.Y);

            // Resize the document to fit all shapes
			document.SizeToContent();
			game.InfoShape.Location = new NPointF(game.InfoShape.Location.X, game.BoardShape.Location.Y);
			document.Tag = game;
        }
        private NTableShape CreateBoardShape(NDrawingDocument document, NClickomaniaGame game)
        {
            NTableShape shape = new NTableShape();
            shape.Name = "Table";

            shape.InitTable(TableColumns, TableRows);
            shape.BeginUpdate();

            int i, j, index;
            int colorCount = GradientSchemes.Length;
            Random random = new Random();

            for (i = 0; i < TableRows; i++)
            {
                for (j = 0; j < TableColumns; j++)
                {
                    shape[j, i].Text = CellText;
                    index = random.Next(colorCount);
                    game.CellCount[index]++;
                    shape[j, i].StyleSheetName = GradientSchemes[index].ToString();
                }
            }

			game.BoardShape = shape;
			document.ActiveLayer.AddChild(shape);

            shape.EndUpdate();
            return shape;
        }
        private NTableShape CreateInfoShape(NDrawingDocument document, NClickomaniaGame game)
        {
            NTableShape shape = new NTableShape();
            shape.Name = "Info";

			int i;
			int count = GradientSchemes.Length;
            shape.InitTable(2, count + 2);
            shape.BeginUpdate();

            shape.ShowGrid = false;

			NTableCell headerCell = shape[0, 0];
			headerCell.ColumnSpan = 2;
			headerCell.Padding = new Nevron.Diagram.NMargins(2, 2, 2, 0);
			headerCell.Borders = TableCellBorder.Bottom;
			headerCell.Text = "Cells:";

            for (i = 0; i < count; i++)
            {
				NTableCell colorCell = shape[0, i + 1];
				colorCell.Text = CellText;
				colorCell.StyleSheetName = GradientSchemes[i].ToString();
				colorCell.Margins = new Nevron.Diagram.NMargins(4, 4, 4, 4);
				colorCell.Borders = TableCellBorder.All;

				NTableCell countCell = shape[1, i + 1];
                countCell.Text = game.CellCount[i].ToString();
            }

			NTableCell scoreCell = shape[0, i + 1];
			scoreCell.ColumnSpan = 2;
			scoreCell.Padding = new Nevron.Diagram.NMargins(2, 2, 2, 0);
			scoreCell.Borders = TableCellBorder.Top;
			scoreCell.Text = String.Format("Score:{0}{1}", Environment.NewLine, game.Score);

			game.InfoShape = shape;
			document.ActiveLayer.AddChild(shape);

            shape.EndUpdate();
            return shape;
        }
       
        #endregion

        #region Constants

        private const int TableRows = 20;
        private const int TableColumns = 15;
        private const string CellText = " ";
		private const string HighlightedSuffix = "Highlighted";
        private static readonly NFilter CellFilter = new NInstanceOfTypeFilter(typeof(NTableCell));

        private static readonly AdvancedGradientScheme[] GradientSchemes = new AdvancedGradientScheme[] {
            AdvancedGradientScheme.Red,
            AdvancedGradientScheme.Blue,
            AdvancedGradientScheme.Green,
            AdvancedGradientScheme.Sunset };

        #endregion

		#region Nested Types

		[Serializable]
		class NMouseDownEventCallback : INMouseEventCallback
		{
			#region INMouseEventCallback Members

			void INMouseEventCallback.OnMouseEvent(NAspNetThinWebControl control, NBrowserMouseEventArgs e)
			{
				NThinDiagramControl diagramControl = (NThinDiagramControl)control;
				NNodeList nodes = diagramControl.HitTest(new NPointF(e.X, e.Y));
				NNodeList shapes = nodes.Filter(CellFilter);

				if (shapes.Count == 0)
					return;

				NClickomaniaGame game = (NClickomaniaGame)diagramControl.Document.Tag;
				NTableCell cell = (NTableCell)shapes[0];
				if (cell.ParentNode.ParentNode != game.BoardShape)
					return;

				if (String.IsNullOrEmpty(cell.StyleSheetName))
					return;

				if (game.OnCellClicked(cell) == false)
					return;

				// The user has clicked on a cell that is part of a region
				diagramControl.ServerSettings.EnableAutoUpdate = true;
				diagramControl.Update();
			}

			#endregion
		}

		[Serializable]
		class NAutoUpdateCallback : INAutoUpdateCallback
		{
			#region INAutoUpdateCallback Members

			void INAutoUpdateCallback.OnAutoUpdate(NAspNetThinWebControl control)
			{
				NThinDiagramControl diagramControl = (NThinDiagramControl)control;
				NClickomaniaGame game = (NClickomaniaGame)diagramControl.Document.Tag;
				game.ClearHighlightedCells();

				diagramControl.ServerSettings.EnableAutoUpdate = false;
				diagramControl.Update();
			}

			void INAutoUpdateCallback.OnAutoUpdateStateChanged(NAspNetThinWebControl control)
			{
				
			}

			#endregion
		}

		[Serializable]
		class NClickomaniaGame
		{
			#region Constructors

			public NClickomaniaGame()
			{
				CellCount = new int[GradientSchemes.Length];
				m_CellsToClear = new List<NPoint>();
				Score = 0;
			}

			#endregion

			#region Public Methods

			/// <summary>
			/// Handles a cell click event highlighting all cells that form a
			/// region with the clicked cell. If the clicked cell is not part
			/// of a region this method returns false.
			/// </summary>
			/// <param name="cell"></param>
			public bool OnCellClicked(NTableCell cell)
			{
				if (m_CellsToClear.Count > 0)
					return false;

				NPoint p = GetCellAddress(cell);
				string color = cell.StyleSheetName;

				if (Test(p.X, p.Y, color) == false)
					return false;

				HighlightCell(p.X, p.Y, color);
				return true;
			}
			/// <summary>
			/// Clears all highlighted cells.
			/// </summary>
			public void ClearHighlightedCells()
			{
				int cellCount = m_CellsToClear.Count;
				if(cellCount == 0)
					return;

				string colorString = BoardShape[m_CellsToClear[0].X, m_CellsToClear[0].Y].StyleSheetName;
				colorString = colorString.Remove(colorString.Length - HighlightedSuffix.Length);
				CellCount[IndexOf(colorString)] -= cellCount;
				Score += cellCount * cellCount;

				for (int i = 0; i < cellCount; i++)
				{
					NPoint p = m_CellsToClear[i];
					BoardShape[p.X, p.Y].StyleSheetName = String.Empty;
				}

				// Apply gravity
				ApplyGravity();

				// Update the cell count info
				UpdateInfo();
				
				// Clear the cells to clear list
				m_CellsToClear.Clear();

				// Check for end of the game
				string status = String.Empty;
				if (AllClear())
				{
					Score *= 2;
					status = "You've cleared all cells !!!" + Environment.NewLine;
				}

				if (status == String.Empty && GameOver())
				{
					status = "Game Over !" + Environment.NewLine;
				}

				if (status != String.Empty)
				{
					status += "Your score is " + Score.ToString();
					NTableShape gameOver = new NTableShape();
					((NDrawingDocument)BoardShape.Document).ActiveLayer.AddChild(gameOver);

					gameOver.BeginUpdate();
					gameOver.CellPadding = new Nevron.Diagram.NMargins(2, 2, 8, 8);
					gameOver[0, 0].Text = status;

					NStyle.SetFillStyle(gameOver, new NAdvancedGradientFillStyle(AdvancedGradientScheme.Mahogany2, 5));
					NTextStyle textStyle = (NTextStyle)InfoShape.ComposeTextStyle().Clone();
					textStyle.FillStyle = new NColorFillStyle(Color.White);
					NStyle.SetTextStyle(gameOver, textStyle);

					gameOver.EndUpdate();
					gameOver.Center = BoardShape.Center;
				}
			}

			#endregion

			#region Implementation

			/// <summary>
			/// Returns the address of the given cell in the table.
			/// </summary>
			/// <param name="cell"></param>
			/// <returns></returns>
			private NPoint GetCellAddress(NTableCell cell)
			{
				int i, j;
				int rowCount = BoardShape.RowCount;
				int columnCount = BoardShape.ColumnCount;

				for (i = 0; i < rowCount; i++)
				{
					for (j = 0; j < columnCount; j++)
					{
						if (BoardShape[j, i] == cell)
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
				if (x > 0 && BoardShape[x - 1, y].StyleSheetName == color)
					return true;

				if (x < BoardShape.ColumnCount - 1 && BoardShape[x + 1, y].StyleSheetName == color)
					return true;

				if (y > 0 && BoardShape[x, y - 1].StyleSheetName == color)
					return true;

				if (y < BoardShape.RowCount - 1 && BoardShape[x, y + 1].StyleSheetName == color)
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
			private void HighlightCell(int x, int y, string color)
			{
				BoardShape[x, y].StyleSheetName = BoardShape[x, y].StyleSheetName + HighlightedSuffix;
				m_CellsToClear.Add(new NPoint(x, y));

				if (x > 0 && BoardShape[x - 1, y].StyleSheetName == color)
					HighlightCell(x - 1, y, color);

				if (x < BoardShape.ColumnCount - 1 && BoardShape[x + 1, y].StyleSheetName == color)
					HighlightCell(x + 1, y, color);

				if (y > 0 && BoardShape[x, y - 1].StyleSheetName == color)
					HighlightCell(x, y - 1, color);

				if (y < BoardShape.RowCount - 1 && BoardShape[x, y + 1].StyleSheetName == color)
					HighlightCell(x, y + 1, color);
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
					if (BoardShape[x, i].StyleSheetName != string.Empty)
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
				int rowCount = BoardShape.RowCount;
				int columnCount = BoardShape.ColumnCount;

				// Top to bottom gravity force
				for (j = 0; j < columnCount; j++)
				{
					for (i = rowCount - 1; i > 0; i--)
					{
						if (BoardShape[j, i].StyleSheetName == string.Empty)
						{   // Shift the column down by 1 cell
							if (IsEmptyToTop(j, i - 1))
								break;

							for (z = i; z > 0; z--)
							{
								BoardShape[j, z].StyleSheetName = BoardShape[j, z - 1].StyleSheetName;
							}

							BoardShape[j, 0].StyleSheetName = string.Empty;
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
							BoardShape[z, i].StyleSheetName = BoardShape[z + 1, i].StyleSheetName;
						}

						BoardShape[z, i].StyleSheetName = string.Empty;
					}
				}
			}
			/// <summary>
			/// Returns true if all cells are cleared.
			/// </summary>
			/// <returns></returns>
			private bool AllClear()
			{
				int i, count = CellCount.Length;
				for (i = 0; i < count; i++)
				{
					if (CellCount[i] != 0)
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
				int rowCount = BoardShape.RowCount;
				int columnCount = BoardShape.ColumnCount;
				NTableCell cell;

				for (i = rowCount - 1; i >= 0; i--)
				{
					for (j = 0; j < columnCount; j++)
					{
						cell = BoardShape[j, i];
						if (cell.StyleSheetName == string.Empty)
							continue;

						if (Test(j, i, cell.StyleSheetName))
							return false;
					}
				}

				return true;
			}
			/// <summary>
			/// Gets the index of given color in the array of colors.
			/// </summary>
			/// <param name="color"></param>
			/// <returns></returns>
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
			/// Update the info shape.
			/// </summary>
			private void UpdateInfo()
			{
				int i, count = GradientSchemes.Length;
				InfoShape.BeginUpdate();

				for (i = 0; i < count; i++)
				{
					InfoShape[1, i + 1].Text = CellCount[i].ToString();
				}

				// Update the score
				InfoShape[0, i + 1].Text = string.Format("Score:{0}{1}", Environment.NewLine, Score);
				InfoShape.EndUpdate();
			}

			#endregion

			#region Fields

			public NTableShape BoardShape;
			public NTableShape InfoShape;
			public int Score;
			public int[] CellCount;

			private List<NPoint> m_CellsToClear;

			#endregion
		}

		#endregion
	}
}