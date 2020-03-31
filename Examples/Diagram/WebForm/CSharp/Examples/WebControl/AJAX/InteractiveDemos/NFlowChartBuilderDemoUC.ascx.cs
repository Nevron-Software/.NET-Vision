using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Nevron.UI.WebForm.Controls;
using Nevron.GraphicsCore;

using Nevron.Dom;
using Nevron.Diagram;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.Batches;
using Nevron.Diagram.WebForm;
using Nevron.Diagram.DataStructures;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///		Summary description for NFlowChartBuilderDemoUC.
	/// </summary>
	public partial class NFlowChartBuilderDemoUC : NDiagramExampleUC
	{
		static readonly Color documentBackgroundColor = Color.FromArgb(0xf4, 0xf2, 0xf4);
		static readonly Color documentSelectedShapeBorderColor = Color.LimeGreen;
		static readonly Color libraryFillColor = Color.White;
		static readonly Color libraryBorderColor = Color.FromArgb(0x44, 0x5a, 0x6c);
		static readonly Color libraryHighlightFillColor = Color.FromArgb(0xfb, 0xcb, 0x9c);
		static readonly Color libraryHighlightBorderColor = Color.FromArgb(0x44, 0x5a, 0x6c);

		static ToolbarButton[] toolbarButtons = new ToolbarButton[]
		{
			new ToolbarButton("Create Shape", "createShape", "NewShapeIcon.BMP", new NSize(14, 16), false),
			new ToolbarButton("Move/Select Shape", "moveSelect", "MoveShapeIcon.BMP", new NSize(12, 12), false),
			new ToolbarButton("Connect Two Shapes", "connect", "ConnectShapesIcon.BMP", new NSize(13, 16), false),
			new ToolbarButton("Delete Shape", "delete", "DeleteShapeIcon.BMP", new NSize(12, 12), false),
			new ToolbarButton(),
			new ToolbarButton("Change Shape Text", "text", "EditTextIcon.BMP", new NSize(12, 12), true),
			new ToolbarButton("Undo", "undo", "UndoIcon.BMP", new NSize(15, 16), true),
			new ToolbarButton("Redo", "redo", "RedoIcon.BMP", new NSize(15, 16), true),
			new ToolbarButton(),
			new ToolbarButton(),
			new ToolbarButton(),
			new ToolbarButton(),
			new ToolbarButton("Apply Fill Style", "fill:98fb98", Color.PaleGreen),
			new ToolbarButton("Apply Fill Style", "fill:b0e0b6", Color.PowderBlue),
			new ToolbarButton("Apply Fill Style", "fill:ffd700", Color.Gold),
			new ToolbarButton("Apply Fill Style", "fill:fa8072", Color.Salmon),
			new ToolbarButton("Apply Fill Style", "fill:ffb6c1", Color.LightPink),
			new ToolbarButton("Apply Fill Style", "fill:ffffff", Color.White),
			new ToolbarButton("Apply Fill Style", "fill:fbcb9c", Color.FromArgb(0xfb, 0xcb, 0x9c)),
		};

		void Page_Load(object sender, System.EventArgs e)
		{
			InitToolbar();
			InitLibrary();
			InitDocument();
		}

		#region Library

		[Serializable]
		public class LibraryHttpHandlerCallback : NHttpHandlerCallback
		{
			public override void OnAsyncClick(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				NDiagramSessionStateObject diagramState = state as NDiagramSessionStateObject;
				NNodeList clickedNodes = diagramState.HitTest(args);
				NNodeList clickedShapes = clickedNodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D);

				NNodeList shapes = diagramState.Document.ActiveLayer.Children(Nevron.Diagram.Filters.NFilters.Shape2D);
				int length = shapes.Count;
				for (int i = 0; i < length; i++)
				{
					NShape s = shapes[i] as NShape;
					s.Style.FillStyle = null;
					s.Style.StrokeStyle = null;
					s.Style.ShadowStyle = null;
					s.Tag = null;
				}

				if (clickedShapes.Count == 0)
				{
					return;
				}

				NShape clickedShape = clickedShapes[0] as NShape;
				clickedShape.Style.FillStyle = new NColorFillStyle(libraryHighlightFillColor);
				clickedShape.Style.StrokeStyle = new NStrokeStyle(libraryHighlightBorderColor);
				clickedShape.Style.ShadowStyle = new NShadowStyle(ShadowType.GaussianBlur, Color.FromArgb(90, Color.Black), new NPointL(2, 1));
				clickedShape.Tag = "selected";
			}
		}

		void InitLibrary()
		{
			nDrawingViewLibrary.HttpHandlerCallback = new LibraryHttpHandlerCallback();

			if (nDrawingViewLibrary.RequiresInitialization)
			{
				// begin view init
				nDrawingViewLibrary.ViewLayout = CanvasLayout.Normal;
				nDrawingViewLibrary.DocumentPadding = new Nevron.Diagram.NMargins(10);

				// init document
				nDrawingViewLibrary.Document.BeginInit();

				nDrawingViewLibrary.Document.GraphicsSettings.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
				nDrawingViewLibrary.Document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
				nDrawingViewLibrary.Document.GraphicsSettings.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

				// set up visual formatting
				nDrawingViewLibrary.Document.BackgroundStyle.FillStyle = new NColorFillStyle(documentBackgroundColor);
				nDrawingViewLibrary.Document.Style.FillStyle = new NColorFillStyle(libraryFillColor);
				nDrawingViewLibrary.Document.Style.StrokeStyle = new NStrokeStyle(libraryBorderColor);
				nDrawingViewLibrary.Document.Style.TextStyle.FontStyle.InitFromFont(new Font("Arial Narrow", 8));

				nDrawingViewLibrary.Document.BackgroundStyle.FrameStyle.Visible = false;

				NFlowChartingShapesFactory factory = new NFlowChartingShapesFactory(nDrawingViewLibrary.Document);
				factory.DefaultSize = new NSizeF(76, 51);
				int count = factory.ShapesCount;
				for (int i = 0; i < count; i++)
				{
					// create a basic shape
					NShape shape = factory.CreateShape(i);

					// enable interactivity
					shape.Style.InteractivityStyle = new NInteractivityStyle(true, i.ToString(), shape.Name, CursorType.Hand);

					// add it to the active layer
					nDrawingViewLibrary.Document.ActiveLayer.AddChild(shape);

					// select the first shape
					if (i == 0)
					{
						shape.Style.FillStyle = new NColorFillStyle(libraryHighlightFillColor);
						shape.Style.StrokeStyle = new NStrokeStyle(libraryHighlightBorderColor);
						shape.Style.ShadowStyle = new NShadowStyle(ShadowType.GaussianBlur, Color.FromArgb(90, Color.Black), new NPointL(2, 1));
						shape.Tag = "selected";
					}
				}

				// layout the shapes in the active layer using a table layout
				NTableLayout layout = new NTableLayout();

				// setup the table layout
				layout.Direction = LayoutDirection.LeftToRight;
				layout.ConstrainMode = CellConstrainMode.Ordinal;
				layout.MaxOrdinal = 1;
				layout.VerticalSpacing = 20;

				// create a layout context
				NLayoutContext layoutContext = new NLayoutContext();
				layoutContext.GraphAdapter = new NShapeGraphAdapter();
				layoutContext.BodyAdapter = new NShapeBodyAdapter(nDrawingViewLibrary.Document);
				layoutContext.BodyContainerAdapter = new NDrawingBodyContainerAdapter(nDrawingViewLibrary.Document);

				// layout the shapes
				layout.Layout(nDrawingViewLibrary.Document.ActiveLayer.Children(null), layoutContext);

				// resize document to fit all shapes
				nDrawingViewLibrary.SizeToContent();

				nDrawingViewLibrary.Document.EndInit();
			}
		}

		protected void nDrawingViewLibrary_QueryAjaxTools(object sender, EventArgs e)
		{
			nDrawingViewLibrary.AjaxTools.Add(new NAjaxMouseClickCallbackTool(true, true));
			nDrawingViewLibrary.AjaxTools.Add(new NAjaxDynamicCursorTool(true));
			nDrawingViewLibrary.AjaxTools.Add(new NAjaxTooltipTool(true));
		}

		#endregion

		#region Document

		void InitDocument()
		{
			if (nDrawingViewDocument.RequiresInitialization)
			{
				nDrawingViewDocument.Document.HistoryService.Stop();
				try
				{
					SelectedShapeId = Guid.Empty;

					//	configure the view
					nDrawingViewDocument.ViewLayout = CanvasLayout.Normal;
					nDrawingViewDocument.DocumentPadding = new Nevron.Diagram.NMargins(10);

					//	remove the frame border
					nDrawingViewDocument.Document.BackgroundStyle.FrameStyle.Visible = false;

					//	configure the document
					nDrawingViewDocument.Document.BackgroundStyle.FillStyle = new NColorFillStyle(documentBackgroundColor);
					nDrawingViewDocument.Width = new Unit(nDrawingViewDocument.Width.Value * 2);
					nDrawingViewDocument.Height = new Unit(nDrawingViewDocument.Height.Value * 2);
					nDrawingViewDocument.Document.Width = (float)nDrawingViewDocument.Dimensions.Width;
					nDrawingViewDocument.Document.Height = (float)nDrawingViewDocument.Dimensions.Height;

					//	configure interactivity
					nDrawingViewDocument.AsyncClickEventQueueLength = 10;
				}
				finally
				{
					nDrawingViewDocument.Document.HistoryService.Start();
				}
			}
		}

		protected void nDrawingViewDocument_QueryAjaxTools(object sender, EventArgs e)
		{
			nDrawingViewDocument.AjaxTools.Add(new NAjaxMouseClickCallbackTool(true, false));
			nDrawingViewDocument.AjaxTools.Add(new NAjaxDynamicCursorTool(true));
		}

		protected void nDrawingViewDocument_AsyncClick(object sender, EventArgs e)
		{
			NCallbackMouseEventArgs args = e as NCallbackMouseEventArgs;
			string command = ActiveCommand;
			ToolbarButton button = GetButtonByCommand(command);
			if (command.StartsWith("fill:"))
				command = "fill";

			switch (command)
			{
				case "createShape":
					CreateShape(args);
					break;
				case "moveSelect":
					MoveOrSelect(args);
					break;
				case "connect":
					Connect(args);
					break;
				case "delete":
					Delete(args);
					break;
				case "fill":
					Fill(args, button.Color);
					break;
			}
		}

		protected void nDrawingViewDocument_AsyncCustomCommand(object sender, EventArgs e)
		{
			NCallbackCustomCommandArgs args = e as NCallbackCustomCommandArgs;
			switch (args.Command.Name)
			{
				case "undo":
					try
					{
						nDrawingViewDocument.Document.HistoryService.Undo();
						nDrawingViewDocument.Document.UpdateAllViews();
					}
					catch (Exception ex)
					{
						System.Diagnostics.Debug.WriteLine("nDrawingViewDocument_AsyncCustomCommand, undo: " + ex.Message);
					}
					break;
				case "redo":
					try
					{
						nDrawingViewDocument.Document.HistoryService.Redo();
						nDrawingViewDocument.Document.UpdateAllViews();
					}
					catch (Exception ex)
					{
						System.Diagnostics.Debug.WriteLine("nDrawingViewDocument_AsyncCustomCommand, redo: " + ex.Message);
					}
					break;
				case "text":
					try
					{
						NShape selectedShape = nDrawingViewDocument.Document.ActiveLayer.GetChildFromUniqueId(SelectedShapeId) as NShape;
						if (selectedShape == null)
							break;
						string text = args.Command.Arguments["text"] as string;
						if(text == null)
							break;
						selectedShape.Text = text;
					}
					catch (Exception ex)
					{
						System.Diagnostics.Debug.WriteLine("nDrawingViewDocument_AsyncCustomCommand, redo: " + ex.Message);
					}
					break;
			}
		}

		protected void nDrawingViewDocument_AsyncQueryCommandResult(object sender, EventArgs e)
		{
			NCallbackQueryCommandResultArgs args = e as NCallbackQueryCommandResultArgs;
			NAjaxXmlTransportBuilder resultBuilder = args.ResultBuilder;

			switch (args.Command.Name)
			{
				case "undo":
				case "redo":
				case "text":
					//	add a built-in data section that will enforce full image refresh at the client
					if (!resultBuilder.ContainsRedrawDataSection())
						resultBuilder.AddRedrawDataSection(nDrawingViewDocument);
					break;
			}
		}

		void CreateShape(NCallbackMouseEventArgs args)
		{
			nDrawingViewDocument.Document.HistoryService.StartTransaction("CreateShape");
			try
			{
				//	create the new shape
				NNodeList shapes = nDrawingViewLibrary.Document.ActiveLayer.Children(Nevron.Diagram.Filters.NFilters.Shape2D);
				int length = shapes.Count;
				NShape newShape = null;
				for (int i = 0; i < length; i++)
				{
					NShape s = shapes[i] as NShape;
					if (s.Tag != null && s.Tag.ToString() == "selected")
					{
						newShape = s.CloneWithNewUniqueId(new Hashtable()) as NShape;
						newShape.Center = new NPointF(args.Point.X, args.Point.Y);
						nDrawingViewDocument.Document.ActiveLayer.AddChild(newShape);
						break;
					}
				}

				if (newShape == null)
					return;

				//	select the new shape
				NNodeList docShapes = nDrawingViewDocument.Document.ActiveLayer.Children(Nevron.Diagram.Filters.NFilters.Shape2D);
				length = docShapes.Count;
				for (int i = 0; i < length; i++)
				{
					NShape s = docShapes[i] as NShape;
					if (s.UniqueId == newShape.UniqueId)
						s.Style.StrokeStyle = new NStrokeStyle(2, documentSelectedShapeBorderColor);
					else
						s.Style.StrokeStyle = null;
				}
				SelectedShapeId = newShape.UniqueId;
			}
			finally
			{
				nDrawingViewDocument.Document.HistoryService.Commit();
			}
		}

		void MoveOrSelect(NCallbackMouseEventArgs args)
		{
			NNodeList clickedNodes = nDrawingViewDocument.HitTest(args);
			NNodeList clickedShapes = clickedNodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D);
			if (clickedShapes.Count == 0)
			{
				//	move the shape, if one is selected
				nDrawingViewDocument.Document.HistoryService.StartTransaction("Move");
				try
				{
					if (SelectedShapeId == Guid.Empty)
						return;

					NShape selectedShape = nDrawingViewDocument.Document.ActiveLayer.GetChildFromUniqueId(SelectedShapeId) as NShape;
					selectedShape.Center = new NPointF(args.Point.X, args.Point.Y);
				}
				finally
				{
					nDrawingViewDocument.Document.HistoryService.Commit();
				}
			}
			else
			{
				//	select a shape
				nDrawingViewDocument.Document.HistoryService.Pause();
				try
				{
					NShape clickedShape = clickedShapes[clickedShapes.Count - 1] as NShape;
					NShape selectedShape = nDrawingViewDocument.Document.ActiveLayer.GetChildFromUniqueId(SelectedShapeId) as NShape;
					if (clickedShape == selectedShape)
					{
						selectedShape.Style.StrokeStyle = null;
						SelectedShapeId = Guid.Empty;
						return;
					}

					NNodeList shapes = nDrawingViewDocument.Document.ActiveLayer.Children(Nevron.Diagram.Filters.NFilters.Shape2D);
					int length = shapes.Count;
					for (int i = 0; i < length; i++)
					{
						NShape s = shapes[i] as NShape;
						if (s.UniqueId == clickedShape.UniqueId)
							s.Style.StrokeStyle = new NStrokeStyle(2, documentSelectedShapeBorderColor);
						else
							s.Style.StrokeStyle = null;
					}
					SelectedShapeId = clickedShape.UniqueId;
				}
				finally
				{
					nDrawingViewDocument.Document.HistoryService.Resume();
				}
			}
		}

		void Connect(NCallbackMouseEventArgs args)
		{
			NNodeList clickedNodes = nDrawingViewDocument.HitTest(args);
			NNodeList clickedShapes = clickedNodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D);
			if (clickedShapes.Count == 0)
			{
				return;
			}
			NShape clickedShape;
			if (SelectedShapeId == Guid.Empty)
			{
				//	select a shape
				nDrawingViewDocument.Document.HistoryService.Pause();
				try
				{
					clickedShape = clickedShapes[clickedShapes.Count - 1] as NShape;
					NNodeList shapes = nDrawingViewDocument.Document.ActiveLayer.Children(Nevron.Diagram.Filters.NFilters.Shape2D);
					int length = shapes.Count;
					for (int i = 0; i < length; i++)
					{
						NShape s = shapes[i] as NShape;
						if (s.UniqueId == clickedShape.UniqueId)
							s.Style.StrokeStyle = new NStrokeStyle(2, documentSelectedShapeBorderColor);
						else
							s.Style.StrokeStyle = null;
					}
					SelectedShapeId = clickedShape.UniqueId;
					return;
				}
				finally
				{
					nDrawingViewDocument.Document.HistoryService.Resume();
				}
			}

			NShape selectedShape = nDrawingViewDocument.Document.ActiveLayer.GetChildFromUniqueId(SelectedShapeId) as NShape;

			nDrawingViewDocument.Document.HistoryService.StartTransaction("Connect");
			try
			{
				//	connect shapes
				clickedShape = clickedShapes[clickedShapes.Count - 1] as NShape;

				NRoutableConnector connector = new NRoutableConnector(RoutableConnectorType.DynamicHV);
				nDrawingViewDocument.Document.ActiveLayer.AddChild(connector);
				connector.StyleSheetName = "Connectors";
				connector.FromShape = selectedShape;
				connector.ToShape = clickedShape;
				connector.RerouteAutomatically = RerouteAutomatically.Always;

				if (connector.IsReflexive)
				{
					connector.Reflex();
				}
				else
				{
					connector.Reroute();
				}
			}
			finally
			{
				nDrawingViewDocument.Document.HistoryService.Commit();
			}

			//	deselect the shape
			nDrawingViewDocument.Document.HistoryService.Pause();
			try
			{
				selectedShape.Style.StrokeStyle = null;
				SelectedShapeId = Guid.Empty;
			}
			finally
			{
				nDrawingViewDocument.Document.HistoryService.Resume();
			}
		}

		void Delete(NCallbackMouseEventArgs args)
		{
			nDrawingViewDocument.Document.HistoryService.StartTransaction("Delete");
			try
			{
				NNodeList clickedNodes = nDrawingViewDocument.HitTest(args);
				NNodeList clickedShapes = clickedNodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D);
				if (clickedShapes.Count != 0)
				{
					NShape clickedShape = clickedShapes[clickedShapes.Count - 1] as NShape;
					nDrawingViewDocument.Document.ActiveLayer.RemoveChild(clickedShape);
				}
				else
				{
					NNodeList clickedConnectors = clickedNodes.Filter(Nevron.Diagram.Filters.NFilters.Shape1D);
					if (clickedConnectors.Count != 0)
					{
						NShape clickedConnector = clickedConnectors[clickedConnectors.Count - 1] as NShape;
						nDrawingViewDocument.Document.ActiveLayer.RemoveChild(clickedConnector);
					}
				}
			}
			finally
			{
				nDrawingViewDocument.Document.HistoryService.Commit();
			}
		}

		void Fill(NCallbackMouseEventArgs args, Color c)
		{
			nDrawingViewDocument.Document.HistoryService.StartTransaction("Fill");
			try
			{
				NNodeList clickedNodes = nDrawingViewDocument.HitTest(args);
				NNodeList clickedShapes = clickedNodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D);
				if (clickedShapes.Count == 0)
					return;
				NShape clickedShape = clickedShapes[clickedShapes.Count - 1] as NShape;
				clickedShape.Style.FillStyle = new NColorFillStyle(c);
			}
			finally
			{
				nDrawingViewDocument.Document.HistoryService.Commit();
			}
		}

		#endregion

		#region Toolbar

		[Serializable]
		public class ToolbarButton
		{
			public ToolbarButton(string title, string commandName, string iconFile, NSize iconSize, bool isClientSide)
			{
				this.Title = title;
				this.CommandName = commandName;
				this.IconFile = iconFile;
				this.IconSize = iconSize;
				this.IsColorSelector = false;
				this.IsClientSide = isClientSide;
			}

			public ToolbarButton(string title, string commandName, Color color)
			{
				this.Title = title;
				this.CommandName = commandName;
				this.Color = color;
				this.IsColorSelector = true;
				this.IsClientSide = false;

				this.IconFile = "FillBucketIcon.png";
				this.IconSize = new NSize(18, 18);
			}

			public ToolbarButton()
			{
				this.IsSeparator = true;
			}

			public string Title;
			public string CommandName;
			public string IconFile;
			public NSize IconSize;
			public Color Color;
			public bool IsColorSelector;
			public bool IsClientSide;
			public bool IsSeparator;
		}

		void InitToolbar()
		{
			if (nDrawingViewToolbar.RequiresInitialization)
			{
				ActiveCommand = toolbarButtons[0].CommandName;

				// begin view init
				nDrawingViewToolbar.ViewLayout = CanvasLayout.Normal;
				nDrawingViewToolbar.DocumentPadding = new Nevron.Diagram.NMargins(0);

				// init document
				nDrawingViewToolbar.Document.BeginInit();

				nDrawingViewToolbar.Document.AutoBoundsPadding = new Nevron.Diagram.NMargins(4);

				nDrawingViewToolbar.Document.GraphicsSettings.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
				nDrawingViewToolbar.Document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
				nDrawingViewToolbar.Document.GraphicsSettings.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

				// set up visual formatting
				nDrawingViewToolbar.Document.Style.FillStyle = new NColorFillStyle(Color.White);
				nDrawingViewToolbar.Document.Style.TextStyle.FontStyle.InitFromFont(new Font("Arial Narrow", 8));

				nDrawingViewToolbar.Document.BackgroundStyle.FrameStyle.Visible = false;

				//	set up the shape factories
				NBasicShapesFactory buttonFactory = new NBasicShapesFactory(nDrawingViewToolbar.Document);
				buttonFactory.DefaultSize = new NSizeF(24, 24);

				NBrainstormingShapesFactory iconFactory = new NBrainstormingShapesFactory(nDrawingViewToolbar.Document);
				iconFactory.DefaultSize = new NSizeF(16, 16);
				
				//	create a batch layout, which will align shapes
				NBatchLayout batchLayout = new NBatchLayout(nDrawingViewToolbar.Document);

				//	create buttons
				int count = toolbarButtons.Length;
				for (int i = 0; i < count; i++)
				{
					ToolbarButton btn = toolbarButtons[i];
					bool isActive = (this.ActiveCommand == btn.CommandName);
					NShape buttonShape = buttonFactory.CreateShape(BasicShapes.RoundedRectangle);

					//	create the button shape group
					NGroup g = new NGroup();
					NBatchGroup bgroup = new NBatchGroup(nDrawingViewToolbar.Document);
					NNodeList shapes = new NNodeList();
					if (btn.IsSeparator)
					{
						buttonShape.Width /= 2;
						buttonShape.Style.StrokeStyle = new NStrokeStyle(Color.White);
						shapes.Add(buttonShape);
					}
					else if (!btn.IsColorSelector)
					{
						shapes.Add(buttonShape);
					}
					else
					{
						buttonShape.Style.FillStyle = new NColorFillStyle(btn.Color);
						shapes.Add(buttonShape);
					}

					NRectanglePath imagePath = new NRectanglePath(0f, 0f, btn.IconSize.Width, btn.IconSize.Height);
					NImageFillStyle fs1 = new NImageFillStyle(this.MapPathSecure(@"..\..\..\Images\FlowChartBuilder\" + btn.IconFile));
					NStyle.SetFillStyle(imagePath, fs1);
					NStyle.SetStrokeStyle(imagePath, new NStrokeStyle(0, Color.White));
					NCompositeShape imageShape = new NCompositeShape();
					imageShape.Primitives.AddChild(imagePath);
					imageShape.UpdateModelBounds();
					shapes.Add(imageShape);

					NShape coverShape = buttonFactory.CreateShape(BasicShapes.RoundedRectangle);
					coverShape.Width = buttonShape.Width;
					coverShape.Name = "coverShape";
					shapes.Add(coverShape);

					if (!isActive && !btn.IsClientSide && !btn.IsSeparator)
					{
						if(btn.IsColorSelector)
							coverShape.Style.FillStyle = new NColorFillStyle(Color.FromArgb(180, Color.White));
						else
							coverShape.Style.FillStyle = new NColorFillStyle(Color.FromArgb(160, Color.White));
						coverShape.Style.StrokeStyle = new NStrokeStyle(Color.FromArgb(160, Color.White));
					}
					else
					{
						coverShape.Style.FillStyle = new NColorFillStyle(Color.FromArgb(0, Color.White));
						coverShape.Style.StrokeStyle = new NStrokeStyle(Color.FromArgb(0, Color.White));
						if(!btn.IsSeparator)
							coverShape.Style.ShadowStyle = new NShadowStyle(ShadowType.GaussianBlur, Color.FromArgb(70, Color.Black), new NPointL(1, 0));
					}

					// perform layout
					batchLayout.Build(shapes);
					batchLayout.AlignVertically(buttonShape, VertAlign.Center, false);
					batchLayout.AlignHorizontally(buttonShape, HorzAlign.Center, false);

					// group shapes
					bgroup.Build(shapes);
					bgroup.Group(null, false, out g);

					// enable interactivity
					if(!btn.IsSeparator)
						g.Style.InteractivityStyle = new NInteractivityStyle(true, btn.CommandName, btn.Title, CursorType.Hand);

					// set the command of the button
					g.Tag = btn.CommandName;

					nDrawingViewToolbar.Document.ActiveLayer.AddChild(g);
				}

				// layout the shapes in the active layer using a table layout
				NTableLayout layout = new NTableLayout();

				// setup the table layout
				layout.Direction = LayoutDirection.LeftToRight;
				layout.ConstrainMode = CellConstrainMode.Ordinal;
				layout.MaxOrdinal = toolbarButtons.Length;
				layout.HorizontalSpacing = 7;

				// create a layout context
				NLayoutContext layoutContext = new NLayoutContext();
				layoutContext.GraphAdapter = new NShapeGraphAdapter();
				layoutContext.BodyAdapter = new NShapeBodyAdapter(nDrawingViewToolbar.Document);
				layoutContext.BodyContainerAdapter = new NDrawingBodyContainerAdapter(nDrawingViewToolbar.Document);

				// layout the shapes
				layout.Layout(nDrawingViewToolbar.Document.ActiveLayer.Children(null), layoutContext);

				nDrawingViewToolbar.Document.EndInit();
			}
		}

		ToolbarButton GetButtonByCommand(string name)
		{
			int length = toolbarButtons.Length;
			for (int i = 0; i < length; i++)
			{
				if (toolbarButtons[i].CommandName == name)
					return toolbarButtons[i];
			}
			return null;
		}

		protected void nDrawingViewToolbar_QueryAjaxTools(object sender, EventArgs e)
		{
			nDrawingViewToolbar.AjaxTools.Add(new NAjaxMouseClickCallbackTool(true, true));
			nDrawingViewToolbar.AjaxTools.Add(new NAjaxDynamicCursorTool(true));
			nDrawingViewToolbar.AjaxTools.Add(new NAjaxTooltipTool(true));
		}

		protected void nDrawingViewToolbar_AsyncClick(object sender, EventArgs e)
		{
			//	get the selected command
			NCallbackMouseEventArgs args = e as NCallbackMouseEventArgs;
			NNodeList clickedNodes = nDrawingViewToolbar.HitTest(args);
			NNodeList clickedGroups = clickedNodes.Filter(Nevron.Diagram.Filters.NFilters.TypeNGroup);
			if (clickedGroups.Count == 0)
				return;
			NGroup clickedGroup = clickedGroups[0] as NGroup;
			string command = clickedGroup.Tag as string;
			if (command == null)
				return;

			//	get the selected button
			ToolbarButton selectedBtn = GetButtonByCommand(command);
			if (!selectedBtn.IsClientSide)
				this.ActiveCommand = command;
			else
				return;

			//	highlight the clicked button
			NShape selectedCoverShape = clickedGroup.Shapes.GetChildByName("coverShape", 0) as NShape;
			if (selectedCoverShape == null)
				return;
			NNodeList groups = nDrawingViewToolbar.Document.ActiveLayer.Children(Nevron.Diagram.Filters.NFilters.TypeNGroup);
			int length = groups.Count;
			for (int i = 0; i < length; i++)
			{
				NGroup group = groups[i] as NGroup;
				ToolbarButton btn = GetButtonByCommand(group.Tag as string);
				if (btn == null)
					continue;
				NShape coverShape = group.Shapes.GetChildByName("coverShape", 0) as NShape;
				if (!btn.IsSeparator)
				{
					if (!object.ReferenceEquals(selectedCoverShape, coverShape) && !btn.IsClientSide)
					{
						if (btn.IsColorSelector)
						{
							coverShape.Style.FillStyle = new NColorFillStyle(Color.FromArgb(80, Color.White));
						}
						else
						{
							coverShape.Style.FillStyle = new NColorFillStyle(Color.FromArgb(160, Color.White));
						}
						coverShape.Style.StrokeStyle = new NStrokeStyle(Color.FromArgb(160, Color.White));
						coverShape.Style.ShadowStyle = null;
					}
					else
					{
						coverShape.Style.FillStyle = new NColorFillStyle(Color.FromArgb(0, Color.White));
						coverShape.Style.StrokeStyle = new NStrokeStyle(Color.FromArgb(0, Color.White));
						coverShape.Style.ShadowStyle = new NShadowStyle(ShadowType.GaussianBlur, Color.FromArgb(70, Color.Black), new NPointL(1, 0));
					}
				}
			}
		}

		#endregion

		string ActiveCommand
		{
			get
			{
				return this.Session["ActiveCommand"] as string;
			}
			set
			{
				this.Session["ActiveCommand"] = value;
			}
		}

		Guid SelectedShapeId
		{
			get
			{
				if (this.Session["SelectedShapeId"] == null)
					return Guid.Empty;
				return (Guid)this.Session["SelectedShapeId"];
			}
			set
			{
				this.Session["SelectedShapeId"] = value;
			}
		}
	}
}
