using System;
using System.Collections;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

using Nevron.Dom;
using Nevron.Diagram;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.Batches;
using Nevron.Diagram.WebForm;
using Nevron.UI.WebForm.Controls;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///		Summary description for NNumberPuzzleUC.
	/// </summary>
	public partial class NNumberPuzzleUC : NDiagramExampleUC
	{
		#region Static Configuration Fields and Methods

		protected static int imagePadding;
		protected static int imagePixelWidth;
		protected static int imagePixelHeight;
		protected static int shadowOffset;

		protected static int cellPixelWidth;
		protected static int cellPixelHeight;

		protected static int boardPadding;
		protected static int boardPixelWidth;
		protected static int boardPixelHeight;
		protected static int boardMarginLeft;
		protected static int boardMarginTop;

		protected static NFillStyle emptyCellFillStyle;
		protected static NFillStyle completeCellFillStyle;
		protected static NFillStyle hoverAllowedCellFillStyle;
		protected static NFillStyle hoverDeniedCellFillStyle;
		protected static NStrokeStyle normalCellStrokeStyle;

		protected static void InitializeConfigurationFields(int boardCellCount)
		{
			//	initialize sizes
			imagePadding = 10;
			imagePixelWidth = 420;
			imagePixelHeight = 320;

			shadowOffset = 4;
			boardPadding = 10;

			//	calculate additional sizes
			boardPixelWidth = (int)Math.Floor((double)((imagePixelWidth - imagePadding - 2 * boardPadding)));
			boardPixelHeight = (int)Math.Floor((double)((imagePixelHeight - imagePadding - 2 * boardPadding)));

			boardPixelWidth = Math.Min(boardPixelWidth, boardPixelHeight);
			boardPixelHeight = Math.Min(boardPixelWidth, boardPixelHeight);

			cellPixelWidth = (int)Math.Floor((double)(boardPixelWidth / boardCellCount));
			cellPixelHeight = (int)Math.Floor((double)(boardPixelHeight / boardCellCount));

			boardPixelWidth = cellPixelWidth * boardCellCount + 2 * boardPadding;
			boardPixelHeight = cellPixelHeight * boardCellCount + 2 * boardPadding;

			boardMarginLeft = (int)Math.Floor((double)(imagePixelWidth - boardPixelWidth) / 2);
			boardMarginTop = (int)Math.Floor((double)(imagePixelHeight - boardPixelHeight) / 2);

			//	precache styles
			emptyCellFillStyle = new NColorFillStyle(Color.WhiteSmoke);
			completeCellFillStyle = new NColorFillStyle(Color.PeachPuff);

			hoverDeniedCellFillStyle = new NGradientFillStyle(GradientStyle.FromCenter, GradientVariant.Variant1, Color.Navy, Color.White);
			hoverAllowedCellFillStyle = new NGradientFillStyle(GradientStyle.FromCenter, GradientVariant.Variant1, Color.LimeGreen, Color.White);

			normalCellStrokeStyle = new NStrokeStyle(new NLength(1f, NGraphicsUnit.Pixel), Color.White);
		}

		#endregion

		#region Properties

		public int BoardCellCount
		{
			get
			{
				if (Session[NDrawingView1.InstanceGuid.ToString() + "-boardCellCount"] == null)
					return 0;
				return (int)Session[NDrawingView1.InstanceGuid.ToString() + "-boardCellCount"];
			}
			set
			{
				Session[NDrawingView1.InstanceGuid.ToString() + "-boardCellCount"] = value;
			}
		}

		#endregion

		#region Event Handlers

		protected void NDrawingView1_QueryAjaxTools(object sender, EventArgs e)
		{
			//	configure the client side tools
			NDrawingView1.AjaxTools.Add(new NAjaxMouseClickCallbackTool(true));
			NDrawingView1.AjaxTools.Add(new NAjaxMouseDoubleClickCallbackTool(false));
			NDrawingView1.AjaxTools.Add(new NAjaxMouseMoveCallbackTool(true));
			NDrawingView1.AjaxTools.Add(new NAjaxMouseDownCallbackTool(false));
			NDrawingView1.AjaxTools.Add(new NAjaxMouseUpCallbackTool(false));
		}

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (BoardCellCount == 0)
				BoardCellCount = 5;
			
			// init configuration
			InitializeConfigurationFields(BoardCellCount);

			NDrawingView1.HttpHandlerCallback = new CustomHttpHandlerCallback();

			if (NDrawingView1.RequiresInitialization)
			{
				// configure advanced AJAX oproperties
				// enqueue 3 subseqent clicks for better usability
				NDrawingView1.AsyncClickEventQueueLength = 3;

				// begin view init
				NDrawingView1.ViewLayout = CanvasLayout.Normal;
				NDrawingView1.ScaleX = 1;
				NDrawingView1.ScaleY = 1;
				NDrawingView1.ViewportOrigin = new NPointF();

				// init document
				NDrawingView1.Document.HistoryService.Stop();
				NDrawingView1.Document.BeginInit();
				InitDocument(NDrawingView1.Document, NDrawingView1.InstanceGuid.ToString(), BoardCellCount);
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
				InitializeConfigurationFields(GetBoardCellCount(state));

				// get the shape under the cursor
				NRectangleShape cell = HitTestCell(state, args);
				if (cell == null)
					return;

				Point clickedCoords = GetClickedCellCoords(state, cell);
				Point emptyCoords = GetEmptyCellCoords(state);

				bool canSwap = TestCanSwap(clickedCoords, emptyCoords);
				if (!canSwap)
					return;

				MoveCell(state, cell, clickedCoords);

				UpdateStyles(state, null);
			}

            public override void OnAsyncDoubleClick(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				// init configuration
				InitializeConfigurationFields(GetBoardCellCount(state));

				// reinitialize the configuration and the scene
				InitializeConfigurationFields(GetBoardCellCount(state));
				NDiagramSessionStateObject diagramState = state as NDiagramSessionStateObject;
				InitDocument(diagramState.Document, diagramState.StateId, GetBoardCellCount(state));
				UpdateStyles(state, null);
			}

            public override void OnAsyncMouseDown(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				// init configuration
				InitializeConfigurationFields(GetBoardCellCount(state));

				// increase board cells count
				int curentBoardCellCount = GetBoardCellCount(state);
				if (curentBoardCellCount >= 7)
					return;

				curentBoardCellCount++;
				SetBoardCellCount(state, curentBoardCellCount);

				// reinitialize the configuration and the scene
				InitializeConfigurationFields(curentBoardCellCount);
				NDiagramSessionStateObject diagramState = state as NDiagramSessionStateObject;
				InitDocument(diagramState.Document, diagramState.StateId, GetBoardCellCount(state));
				UpdateStyles(state, null);
			}

            public override void OnAsyncMouseMove(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				// init configuration
				InitializeConfigurationFields(GetBoardCellCount(state));

				NRectangleShape cell = HitTestCell(state, args);
				if (cell == null)
					return;

				UpdateStyles(state, cell);
			}

            public override void OnAsyncMouseUp(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				// init configuration
				InitializeConfigurationFields(GetBoardCellCount(state));

				// decrease board cells count
				int curentBoardCellCount = GetBoardCellCount(state);
				if (curentBoardCellCount <= 2)
					return;

				curentBoardCellCount--;
				SetBoardCellCount(state, curentBoardCellCount);

				// reinitialize the configuration and the scene
				InitializeConfigurationFields(curentBoardCellCount);
				NDiagramSessionStateObject diagramState = state as NDiagramSessionStateObject;
				InitDocument(diagramState.Document, diagramState.StateId, GetBoardCellCount(state));
				UpdateStyles(state, null);
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
					if (!(node.Tag is int))
						continue;
					return node as NRectangleShape;
				}

				return null;
			}

			protected Point GetClickedCellCoords(NStateObject state, NRectangleShape cell)
			{
				return (Point)GetGrid(state)[new Point((int)cell.Bounds.X, (int)cell.Bounds.Y)];
			}

			protected NNodeList GetAllCells(NStateObject state)
			{
				NDiagramSessionStateObject diagramState = state as NDiagramSessionStateObject;

				NNodeList list = new NNodeList();
				NGroup cellsGroup = diagramState.Document.ActiveLayer.GetChildByName("cellsGroup", 0) as NGroup;
				foreach (INNode node in cellsGroup.Shapes)
					list.Add(node);

				return list;
			}

			protected bool TestCanSwap(Point clickedCoords, Point emptyCoords)
			{
				return
					(
						(clickedCoords.X == emptyCoords.X - 1 && clickedCoords.Y == emptyCoords.Y) ||
						(clickedCoords.X == emptyCoords.X + 1 && clickedCoords.Y == emptyCoords.Y) ||
						(clickedCoords.X == emptyCoords.X && clickedCoords.Y == emptyCoords.Y - 1) ||
						(clickedCoords.X == emptyCoords.X && clickedCoords.Y == emptyCoords.Y + 1)
					);
			}

			protected bool TestComplete(NStateObject state)
			{
				Hashtable grid = GetGrid(state);

				NNodeList allCells = GetAllCells(state);
				for (int i = 0; i < allCells.Count; i++)
				{
					NRectangleShape cell = allCells[i] as NRectangleShape;
					Point coords = (Point)grid[new Point((int)cell.Bounds.X, (int)cell.Bounds.Y)];
					int expectedNumber = coords.X + coords.Y * GetBoardCellCount(state) + 1;
					if(expectedNumber != (int)cell.Tag)
						return false;
				}
				return true;
			}

			protected void MoveCell(NStateObject state, NRectangleShape cell, Point clickedCoords)
			{
				Point emptyCellPixelCoords = GetEmptyCellPixelCoords(state);
				
				//	move the empty cell
				SetEmptyCellPixelCoords(state, new Point((int)cell.Bounds.X, (int)cell.Bounds.Y));
				SetEmptyCellCoords(state, clickedCoords);

				//	move the clicked cell
				cell.Bounds = new NRectangleF(emptyCellPixelCoords.X, emptyCellPixelCoords.Y, cell.Bounds.Width, cell.Bounds.Height);
			}

			protected void UpdateStyles(NStateObject state, NRectangleShape hoverCell)
			{
				bool isCompleted = TestComplete(state);

				NDiagramSessionStateObject diagramState = state as NDiagramSessionStateObject;

				NNodeList allCells = GetAllCells(state);
				for (int i = 0; i < allCells.Count; i++)
				{
					NRectangleShape cell = allCells[i] as NRectangleShape;
					if (isCompleted)
					{
						cell.Style.FillStyle = completeCellFillStyle;
					}
					else
					{
						if (hoverCell == null || hoverCell.UniqueId != cell.UniqueId)
						{
							cell.Style.FillStyle = emptyCellFillStyle;
						}
						else if (TestCanSwap(GetClickedCellCoords(state, cell), GetEmptyCellCoords(state)))
						{
							cell.Style.FillStyle = hoverAllowedCellFillStyle;
						}
						else
						{
							cell.Style.FillStyle = hoverDeniedCellFillStyle;
						}
					}
				}

				diagramState.Document.RefreshAllViews();
			}


			protected Point GetEmptyCellCoords(NStateObject state)
			{
				return (Point)System.Web.HttpContext.Current.Session[state.StateId + "-emptyCellCoords"];
			}
			
			protected void SetEmptyCellCoords(NStateObject state, Point value)
			{
				System.Web.HttpContext.Current.Session[state.StateId + "-emptyCellCoords"] = value;
			}

			protected Point GetEmptyCellPixelCoords(NStateObject state)
			{
				return (Point)System.Web.HttpContext.Current.Session[state.StateId + "-emptyCellPixelCoords"];
			}
			
			protected void SetEmptyCellPixelCoords(NStateObject state, Point value)
			{
				System.Web.HttpContext.Current.Session[state.StateId + "-emptyCellPixelCoords"] = value;
			}

			protected Hashtable GetGrid(NStateObject state)
			{
				return System.Web.HttpContext.Current.Session[state.StateId + "-grid"] as Hashtable;
			}

			protected int GetBoardCellCount(NStateObject state)
			{
				return (int)System.Web.HttpContext.Current.Session[state.StateId + "-boardCellCount"];
			}

			protected void SetBoardCellCount(NStateObject state, int value)
			{
				System.Web.HttpContext.Current.Session[state.StateId + "-boardCellCount"] = value;
			}

			#endregion
		}

		#endregion

		#region Implementation

		protected static void InitDocument(NDrawingDocument document, string stateId, int boardCellCount)
		{
			// clean up existing layers
			document.Layers.RemoveAllChildren();

			// modify the connectors style sheet
			document.Style.TextStyle = new NTextStyle();
			document.Style.TextStyle.FontStyle = new NFontStyle("Arial", 20f, FontStyle.Bold);
			document.Style.TextStyle.FillStyle = new NColorFillStyle(Color.SteelBlue);
			document.Style.TextStyle.BorderStyle = new NStrokeStyle(1f, Color.White);

			// configure the document
			document.Bounds = new NRectangleF(0, 0, imagePixelWidth, imagePixelHeight);
			document.ShadowsZOrder = ShadowsZOrder.BehindLayer;
			document.GraphicsSettings.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			document.GraphicsSettings.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
			document.MeasurementUnit = NGraphicsUnit.Pixel;
			document.DrawingScaleMode = DrawingScaleMode.NoScale;

			document.BackgroundStyle.FrameStyle.Visible = false;

			NLayer backgroundLayer = new NLayer();
			NLayer gridLayer = new NLayer();
			document.Layers.AddChild(gridLayer);
			document.ActiveLayerUniqueId = gridLayer.UniqueId;

			//	frame
			NBasicShapesFactory factory = new NBasicShapesFactory(document);

			//	grid
			ArrayList randomizedNumbers = CreateRandomizedNumbersArray(boardCellCount);

			Hashtable grid = new Hashtable();
			NNodeList cells = new NNodeList();
			for (int x = 0; x < boardCellCount; x++)
			{
				for (int y = 0; y < boardCellCount; y++)
				{
					if (x == boardCellCount - 1 && y == boardCellCount - 1)
						break;
					NRectangleShape cell = CreateCell(document, x, y, (int)randomizedNumbers[y + x * boardCellCount]);
					cells.Add(cell);
					grid[new Point((int)cell.Bounds.X, (int)cell.Bounds.Y)] = new Point(x, y);
				}
			}

			NGroup cellsGroup;
			NBatchGroup batchGroup = new NBatchGroup(document);
			batchGroup.Build(cells);
			NTransactionResult result = batchGroup.Group(document.ActiveLayer, true, out cellsGroup);

			cellsGroup.Name = "cellsGroup";

			//	save the default empty cell coordinates
			Point emptyCellCoords = new Point(boardCellCount - 1, boardCellCount - 1);
			Point emptyCellPixelCoords = new Point(boardMarginLeft + cellPixelWidth * (boardCellCount - 1) + boardPadding, boardMarginTop + cellPixelWidth * (boardCellCount - 1) + boardPadding);

			HttpContext.Current.Session[stateId.ToString() + "-emptyCellCoords"] = emptyCellCoords;
			HttpContext.Current.Session[stateId.ToString() + "-emptyCellPixelCoords"] = emptyCellPixelCoords;
			
			//	save the default cells grid
			grid[new Point(emptyCellPixelCoords.X, emptyCellPixelCoords.Y)] = new Point(emptyCellCoords.X, emptyCellCoords.Y);
			HttpContext.Current.Session[stateId.ToString() + "-grid"] = grid;

			// clean up any other related session state
			HttpContext.Current.Session.Remove(stateId.ToString() + "-cellsList");
		}

		protected static NRectangleShape CreateCell(NDrawingDocument document, int x, int y, int number)
		{
			NBasicShapesFactory factory = new NBasicShapesFactory(document);

			NRectangleShape cell = factory.CreateShape((int)BasicShapes.Rectangle) as NRectangleShape;
			cell.Bounds = new NRectangleF(boardMarginLeft + cellPixelWidth * x + boardPadding, boardMarginTop + cellPixelWidth * y + boardPadding, cellPixelWidth, cellPixelHeight);
			cell.Style.StrokeStyle = normalCellStrokeStyle;
			cell.Style.FillStyle = emptyCellFillStyle;
			cell.Style.ShadowStyle = new NShadowStyle(ShadowType.GaussianBlur, Color.FromArgb(65, Color.Black), new NPointL(shadowOffset, shadowOffset), 1, new NLength(shadowOffset*2));
			cell.Name = string.Format("{0}, {1}", x, y);
			cell.Tag = number;
			cell.Text = number.ToString();

			document.ActiveLayer.AddChild(cell);
			return cell;
		}

		protected static ArrayList CreateRandomizedNumbersArray(int boardCellCount)
		{
			Random rnd = new Random(DateTime.Now.Millisecond);
			int maxNumber = boardCellCount * boardCellCount;

			ArrayList intermediate = new ArrayList(maxNumber);
			for (int i = 1; i < maxNumber; i++)
				intermediate.Add(i);

			ArrayList result = new ArrayList(maxNumber);
			for (int i = 1; i < maxNumber; i++)
			{
				int index = rnd.Next(intermediate.Count - 1);
				result.Add(intermediate[index]);
				intermediate.RemoveAt(index);
			}

			return result;
		}

		#endregion
	}
}
