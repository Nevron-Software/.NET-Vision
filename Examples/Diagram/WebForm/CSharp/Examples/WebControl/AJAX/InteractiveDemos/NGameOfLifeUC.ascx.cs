using System;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

using Nevron.Dom;
using Nevron.Diagram;
using Nevron.Diagram.Batches;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.WebForm;
using Nevron.UI.WebForm.Controls;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///		Summary description for NGameOfLifeUC.
	/// </summary>
	public partial class NGameOfLifeUC : NDiagramExampleUC
	{
		public enum CellState
		{
			Alive,
			Dead,
			JustBorn,
			Dying,

			PinnedAlive,
			PinnedDead,
		}

		#region Static Configuration Fields and Methods

		protected static int imagePixelWidth;
		protected static int imagePixelHeight;
		protected static int imagePadding;
		protected static int shadowOffset;

		protected static int cellPixelWidth;
		protected static int cellPixelHeight;
		protected static int boardCellCountWidth;
		protected static int boardCellCountHeight;

		protected static int boardPixelWidth;
		protected static int boardPixelHeight;
		protected static int boardMarginLeft;
		protected static int boardMarginTop;

		protected static int centerCellCountX;
		protected static int centerCellCountY;

		protected static int[][] initialConfigurationCoordinates;

		protected static NFillStyle emptyCellFillStyle;
		protected static NFillStyle fullCellFillStyle;
		protected static NFillStyle emptyPinnedCellFillStyle;
		protected static NFillStyle fullPinnedCellFillStyle;

		protected static NStrokeStyle normalCellStrokeStyle;
		protected static NStrokeStyle highliteCellStrokeStyle;

		protected static void InitializeConfigurationFields()
		{
			//	initialize sizes
			imagePixelWidth = 420;
			imagePixelHeight = 320;
			imagePadding = 10;
			shadowOffset = 5;

			cellPixelWidth = 20;
			cellPixelHeight = 20;

			//	calculate additional sizes
			boardCellCountWidth = (int)(Math.Floor((double)(imagePixelWidth - 2 * imagePadding) / cellPixelWidth));
			boardCellCountHeight = (int)(Math.Floor((double)(imagePixelHeight - 2 * imagePadding) / cellPixelHeight));

			boardPixelWidth = boardCellCountWidth * cellPixelWidth;
			boardPixelHeight = boardCellCountHeight * cellPixelHeight;
			boardMarginLeft = (int)Math.Floor((double)(imagePixelWidth - boardPixelWidth) / 2) - (int)Math.Floor((double)(shadowOffset / 2));
			boardMarginTop = (int)Math.Floor((double)(imagePixelHeight - boardPixelHeight) / 2) - (int)Math.Floor((double)(shadowOffset / 2));

			centerCellCountX = (int)Math.Floor((double)boardCellCountWidth / 2);
			centerCellCountY = (int)Math.Floor((double)boardCellCountHeight / 2);

			//	an r-pentamino configuration
			initialConfigurationCoordinates = new int[][]
			{
				new int[]{centerCellCountX, centerCellCountY - 1},
				new int[]{centerCellCountX + 1, centerCellCountY - 1},
				new int[]{centerCellCountX - 1, centerCellCountY},
				new int[]{centerCellCountX, centerCellCountY},
				new int[]{centerCellCountX, centerCellCountY + 1},
			};

			//	precache styles
			emptyCellFillStyle = new NColorFillStyle(Color.White);
			fullCellFillStyle = new NColorFillStyle(Color.Red);
			emptyPinnedCellFillStyle = new NColorFillStyle(Color.LightGray);
			fullPinnedCellFillStyle = new NColorFillStyle(Color.Brown);
			
			normalCellStrokeStyle = new NStrokeStyle(new NLength(1f, NGraphicsUnit.Pixel), Color.Black);
			highliteCellStrokeStyle = new NStrokeStyle(new NLength(2f, NGraphicsUnit.Pixel), Color.Blue);
		}

		#endregion

		#region Fields

		protected NBasicShapesFactory factory;

		#endregion

		#region Event Handlers

		protected void NDrawingView1_QueryAjaxTools(object sender, EventArgs e)
		{
			//	configure the client side tools
			NDrawingView1.AjaxTools.Add(new NAjaxMouseClickCallbackTool(true));
			NDrawingView1.AjaxTools.Add(new NAjaxMouseDoubleClickCallbackTool(true));
			NDrawingView1.AjaxTools.Add(new NAjaxMouseMoveCallbackTool(true));
			NDrawingView1.AjaxTools.Add(new NAjaxMouseDownCallbackTool(false));
			NDrawingView1.AjaxTools.Add(new NAjaxMouseUpCallbackTool(false));
		}

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// init configuration
			InitializeConfigurationFields();

			NDrawingView1.HttpHandlerCallback = new CustomHttpHandlerCallback();

			if (NDrawingView1.RequiresInitialization)
			{
				factory = new NBasicShapesFactory(NDrawingView1.Document);

				// begin view init
				NDrawingView1.ViewLayout = CanvasLayout.Normal;
				NDrawingView1.ScaleX = 1;
				NDrawingView1.ScaleY = 1;
				NDrawingView1.ViewportOrigin = new NPointF();

				// init document
				NDrawingView1.Document.HistoryService.Stop();
				NDrawingView1.Document.BeginInit();
				InitDocument();
				NDrawingView1.Document.EndInit();
			}
		}

		#endregion

		#region Nested Classes

		[Serializable]
		public class CustomHttpHandlerCallback : NHttpHandlerCallback
		{
			#region INHttpHandlerCallback Members

			public override void OnAsyncClick(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				// init configuration
				InitializeConfigurationFields();

				//	toggle the underlying cell
				NRectangleShape cell = HitTestCell(state, args);
				if (cell == null)
					return;

				if ((CellState)cell.Tag == CellState.Alive)
					cell.Tag = CellState.Dead;
				else if ((CellState)cell.Tag == CellState.Dead)
					cell.Tag = CellState.Alive;
				else
					return;

				UpdateStyles(state);
			}

            public override void OnAsyncDoubleClick(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				// init configuration
				InitializeConfigurationFields();

				//	clear the board
				Clear(state);
			}

            public override void OnAsyncMouseDown(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				// init configuration
				InitializeConfigurationFields();

				//	toggle the underlying cell
				NRectangleShape cell = HitTestCell(state, args);
				if (cell == null)
					return;

				if ((CellState)cell.Tag == CellState.Alive)
					cell.Tag = CellState.PinnedAlive;
				else if ((CellState)cell.Tag == CellState.Dead)
					cell.Tag = CellState.PinnedDead;
				else
					return;

				UpdateStyles(state);
			}

            public override void OnAsyncMouseUp(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				// init configuration
				InitializeConfigurationFields();

				//	toggle the underlying cell
				NRectangleShape cell = HitTestCell(state, args);
				if (cell == null)
					return;

				if ((CellState)cell.Tag == CellState.PinnedAlive)
					cell.Tag = CellState.Alive;
				else if ((CellState)cell.Tag == CellState.PinnedDead)
					cell.Tag = CellState.Dead;
				else
					return;

				UpdateStyles(state);
			}

            public override void OnAsyncMouseMove(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				// init configuration
				InitializeConfigurationFields();

				//	highlight underlying cell
				NRectangleShape cell = HitTestCell(state, args);
				if (cell == null)
					return;

				HighliteCell(state, cell);
			}

            public override void OnAsyncRefresh(string webControlId, System.Web.HttpContext context, NStateObject state, EventArgs args)
			{
				// init configuration
				InitializeConfigurationFields();

				IterateOneTurn(state);
			}

			#endregion

			#region Implementation

			protected NRectangleShape HitTestCell(NStateObject state, NCallbackMouseEventArgs args)
			{
				NDiagramSessionStateObject diagramState = state as NDiagramSessionStateObject;
				NNodeList nodes = diagramState.HitTest(args);
				NNodeList shapes = nodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D);
				foreach (NShape node in shapes)
				{
					if (!(node.Tag is CellState))
						continue;
					return node as NRectangleShape;
				}

				return null;
			}

			protected void IterateOneTurn(NStateObject state)
			{
				NDiagramSessionStateObject diagramState = state as NDiagramSessionStateObject;

				//	obtain/cache life map, create an initial configuration when accessed for the first time
				NRectangleShape[,] map = GetLifeMap(state);
				if (m_HasReinitialized)
				{
					//	remove the mouse move highlight
					ClearHighlitsHormatting(map);

					//	reflect life state to rectangle styles
					UpdateStyles(state);
					return;
				}

				//	mark dying cells and cells to be born
				for(int x = 0; x < boardCellCountWidth; x++)
				{
					for(int y = 0; y < boardCellCountHeight; y++)
					{
						int neighboursCount = CountLiveNeighbours(x, y, map);
						switch ((CellState)map[x, y].Tag)
						{
							case CellState.Dead:
								if (neighboursCount == 3)
									map[x, y].Tag = CellState.JustBorn;
								break;

							case CellState.Alive:
								if (neighboursCount < 2 || neighboursCount > 3)
									map[x, y].Tag = CellState.Dying;
								break;
						}
					}
				}

				//	commit death/birth actions
				for (int x = 0; x < boardCellCountWidth; x++)
				{
					for (int y = 0; y < boardCellCountHeight; y++)
					{
						switch ((CellState)map[x, y].Tag)
						{
							case CellState.Dying:
								map[x, y].Tag = CellState.Dead;
								break;

							case CellState.JustBorn:
								map[x, y].Tag = CellState.Alive;
								break;
						}
					}
				}

				//	remove the mouse move highlight
				ClearHighlitsHormatting(map);

				//	reflect life state to rectangle styles
				UpdateStyles(state);
			}

			protected void UpdateStyles(NStateObject state)
			{
				NDiagramSessionStateObject diagramState = state as NDiagramSessionStateObject;

				//	obtain/cache life map, create an initial configuration when accessed for the first time
				NRectangleShape[,] map = GetLifeMap(state);

				//	reflect life state to rectangle styles
				for (int x = 0; x < boardCellCountWidth; x++)
				{
					for (int y = 0; y < boardCellCountHeight; y++)
					{
						switch ((CellState)map[x, y].Tag)
						{
							case CellState.Dead:
								map[x, y].Style.FillStyle = emptyCellFillStyle;
								break;

							case CellState.Alive:
								map[x, y].Style.FillStyle = fullCellFillStyle;
								break;
							case CellState.PinnedDead:
								map[x, y].Style.FillStyle = emptyPinnedCellFillStyle;
								break;

							case CellState.PinnedAlive:
								map[x, y].Style.FillStyle = fullPinnedCellFillStyle;
								break;
							default:
								System.Diagnostics.Debug.Fail("No intermediate cell states expected");
								break;
						}
					}
				}

				diagramState.Document.RefreshAllViews();
			}

			protected void Clear(NStateObject state)
			{
				NDiagramSessionStateObject diagramState = state as NDiagramSessionStateObject;

				//	obtain/cache life map, create an initial configuration when accessed for the first time
				NRectangleShape[,] map = GetLifeMap(state);

				//	clear all live cells
				ClearBoard(map);

				//	reflect life state to rectangle styles
				UpdateStyles(state);
			}

			protected int CountLiveNeighbours(int x, int y, NRectangleShape[,] map)
			{
				//	define a perpetual board
				int col0 = x - 1, col1 = x, col2 = x + 1;
				int row0 = y - 1, row1 = y, row2 = y + 1;
				if (col0 < 0)
					col0 = boardCellCountWidth - 1;
				if (col2 >= boardCellCountWidth)
					col2 = 0;
				if (row0 < 0)
					row0 = boardCellCountHeight - 1;
				if (row2 >= boardCellCountHeight)
					row2 = 0;

				int result = 0;
				result += CellAliveAsInt(col0, row0, map);
				result += CellAliveAsInt(col1, row0, map);
				result += CellAliveAsInt(col2, row0, map);

				result += CellAliveAsInt(col0, row1, map);
				result += CellAliveAsInt(col2, row1, map);

				result += CellAliveAsInt(col0, row2, map);
				result += CellAliveAsInt(col1, row2, map);
				result += CellAliveAsInt(col2, row2, map);

				return result;
			}

			protected int CellAliveAsInt(int x, int y, NRectangleShape[,] map)
			{
				return ((CellState)map[x, y].Tag == CellState.Alive || (CellState)map[x, y].Tag == CellState.Dying || (CellState)map[x, y].Tag == CellState.PinnedAlive) ? 1 : 0;
			}

			protected NRectangleShape[,] GetLifeMap(NStateObject state)
			{
				NDiagramSessionStateObject diagramState = state as NDiagramSessionStateObject;
				m_Map = new NRectangleShape[boardCellCountWidth, boardCellCountHeight];
				NGroup cellsGroup = diagramState.Document.ActiveLayer.GetChildByName("cellsGroup", 0) as NGroup;
				NShapeCollection children = cellsGroup.Shapes;
				if (m_MapShapeIds != null)
				{
					m_HasReinitialized = false;
					for (int x = 0; x < boardCellCountWidth; x++)
					{
						for (int y = 0; y < boardCellCountHeight; y++)
						{
							m_Map[x, y] = children.GetChildFromUniqueId(m_MapShapeIds[x, y]) as NRectangleShape;
						}
					}
					return m_Map;
				}

				m_MapShapeIds = new Guid[boardCellCountWidth, boardCellCountHeight];
				foreach (NRectangleShape cell in children)
				{
					string[] tokens = cell.Name.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
					int x = int.Parse(tokens[0]);
					int y = int.Parse(tokens[1]);
					m_Map[x, y] = cell;
					m_MapShapeIds[x, y] = cell.UniqueId;
				}
				ApplyConfigurationCoordinates(m_Map, initialConfigurationCoordinates);
				m_HasReinitialized = true;
				return m_Map;
			}

			protected void ApplyConfigurationCoordinates(NRectangleShape[,] map, int[][] configurationCoordinates)
			{
				ClearBoard(map);
				for (int i = 0; i < configurationCoordinates.Length; i++)
				{
					int[] coords = configurationCoordinates[i];
					map[coords[0], coords[1]].Tag = CellState.Alive;
				}
			}

			protected void ClearBoard(NRectangleShape[,] map)
			{
				for (int x = 0; x < boardCellCountWidth; x++)
					for (int y = 0; y < boardCellCountHeight; y++)
						map[x, y].Tag = CellState.Dead;
			}

			protected void HighliteCell(NStateObject state, NRectangleShape cell)
			{
				NDiagramSessionStateObject diagramState = state as NDiagramSessionStateObject;

				//	obtain/cache life map, create an initial configuration when accessed for the first time
				NRectangleShape[,] map = GetLifeMap(state);

				ClearHighlitsHormatting(map);
				cell.Style.StrokeStyle = highliteCellStrokeStyle;

				diagramState.Document.RefreshAllViews();
			}

			protected void ClearHighlitsHormatting(NRectangleShape[,] map)
			{
				for (int x = 0; x < boardCellCountWidth; x++)
					for (int y = 0; y < boardCellCountHeight; y++)
						map[x, y].Style.StrokeStyle = normalCellStrokeStyle;
			}

			#endregion

			#region Fields

			public bool m_HasReinitialized = false;

			[NonSerialized]
			public NRectangleShape[,] m_Map = null;

			public Guid[,] m_MapShapeIds = null;

			#endregion
		}

		#endregion

		#region Implementation

		private void InitDocument()
		{
			// configure the document
			NDrawingView1.Document.Bounds = new NRectangleF(0, 0, imagePixelWidth, imagePixelHeight);
			NDrawingView1.Document.ShadowsZOrder = ShadowsZOrder.BehindElement;
			NDrawingView1.Document.GraphicsSettings.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
			NDrawingView1.Document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			NDrawingView1.Document.GraphicsSettings.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
			NDrawingView1.Document.MeasurementUnit = NGraphicsUnit.Pixel;
			NDrawingView1.Document.DrawingScaleMode = DrawingScaleMode.NoScale;

			NDrawingView1.Document.BackgroundStyle.FrameStyle.Visible = false;

			//	shapes
			NRectangleShape backgroundFrame = factory.CreateShape((int)BasicShapes.Rectangle) as NRectangleShape;
			backgroundFrame.Bounds = new NRectangleF(boardMarginLeft, boardMarginTop, boardPixelWidth, boardPixelHeight);
			backgroundFrame.Style.StrokeStyle = new NStrokeStyle(new NLength(1f, NGraphicsUnit.Pixel), Color.Black);
			backgroundFrame.Style.FillStyle = new NColorFillStyle(Color.White);
			backgroundFrame.Style.ShadowStyle = new NShadowStyle(ShadowType.GaussianBlur, Color.FromArgb(65, Color.Black), new NPointL(shadowOffset, shadowOffset), 1, new NLength(shadowOffset*2));
			backgroundFrame.Name = "background";

			NDrawingView1.Document.ActiveLayer.AddChild(backgroundFrame);

			NNodeList cells = new NNodeList();
			for (int x = 0; x < boardCellCountWidth; x++)
				for (int y = 0; y < boardCellCountHeight; y++)
					cells.Add(CreateEmptyCell(x, y));

			NGroup cellsGroup;
			NBatchGroup batchGroup = new NBatchGroup(NDrawingView1.Document);
			batchGroup.Build(cells);
			NTransactionResult result = batchGroup.Group(NDrawingView1.Document.ActiveLayer, true, out cellsGroup);
			
			cellsGroup.Name = "cellsGroup";
		}

		protected NRectangleShape CreateEmptyCell(int x, int y)
		{
			NRectangleShape cell = factory.CreateShape((int)BasicShapes.Rectangle) as NRectangleShape;
			cell.Bounds = new NRectangleF(boardMarginLeft + cellPixelWidth * x, boardMarginTop + cellPixelWidth * y, cellPixelWidth, cellPixelHeight);
			cell.Style.StrokeStyle = normalCellStrokeStyle;
			cell.Style.FillStyle = emptyCellFillStyle;
			cell.Style.ShadowStyle = null;
			cell.Name = string.Format("{0}, {1}", x, y);
			cell.Tag = CellState.Dead;

			NDrawingView1.Document.ActiveLayer.AddChild(cell);
			return cell;
		}

		#endregion
	}
}
