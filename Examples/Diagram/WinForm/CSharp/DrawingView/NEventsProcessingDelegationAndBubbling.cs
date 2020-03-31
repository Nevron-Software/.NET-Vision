using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.GraphicsCore;
using Nevron.Dom;
using Nevron.Diagram;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Enumerates the currently supported tool configurations
	/// </summary>
	public enum ToolsConfiguration
	{
		/// <summary>
		/// Enabled are only EventDelagators tools
		/// </summary>
		OnlyEventDelagators,
		/// <summary>
		/// Enabled are only Pointer tools
		/// </summary>
		OnlyPointer,
		/// <summary>
		/// Pointer tools are with higher priority than event delegators
		/// </summary>
		PointerBeforeEventDelagators,
		/// <summary>
		/// Event delegator tools are with higher priority than pointer tools
		/// </summary>
		EventDelagatorsBeforePointer
	}

	/// <summary>
	/// Summary description for NEventsProcessingDelegationAndBubbling.
	/// </summary>
	public class NEventsProcessingDelegationAndBubbling : NDiagramExampleUC
	{
		#region Constructor

		public NEventsProcessingDelegationAndBubbling(NMainForm form) : base(form)
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
			this.toolsConfigCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.markEventsAsProcessedCheck = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// toolsConfigCombo
			// 
			this.toolsConfigCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.toolsConfigCombo.Location = new System.Drawing.Point(8, 40);
			this.toolsConfigCombo.Name = "toolsConfigCombo";
			this.toolsConfigCombo.Size = new System.Drawing.Size(240, 21);
			this.toolsConfigCombo.TabIndex = 1;
			this.toolsConfigCombo.Text = "comboBox1";
			this.toolsConfigCombo.SelectedIndexChanged += new System.EventHandler(this.toolsConfigCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Tools configuration:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// markEventsAsProcessedCheck
			// 
			this.markEventsAsProcessedCheck.Location = new System.Drawing.Point(8, 72);
			this.markEventsAsProcessedCheck.Name = "markEventsAsProcessedCheck";
			this.markEventsAsProcessedCheck.Size = new System.Drawing.Size(232, 24);
			this.markEventsAsProcessedCheck.TabIndex = 3;
			this.markEventsAsProcessedCheck.Text = "Mark events as processed";
			// 
			// NEventsProcessingDelegationAndBubbling
			// 
			this.Controls.Add(this.markEventsAsProcessedCheck);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.toolsConfigCombo);
			this.Name = "NEventsProcessingDelegationAndBubbling";
			this.Size = new System.Drawing.Size(256, 576);
			this.Controls.SetChildIndex(this.toolsConfigCombo, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.markEventsAsProcessedCheck, 0);
			this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			base.DefaultGridCellSize = new NSizeF(100, 100);

			// init view
			view.BeginInit();
			view.GlobalVisibility.ShowPorts = false;

			// init document
			document.BeginInit();
			InitDocument();
			document.EndInit();

			// initial config
			InitFormControls();
			ConfigureTools(ToolsConfiguration.PointerBeforeEventDelagators); 

			// end desinger init
			view.EndInit();
		}

		protected override void AttachToEvents()
		{
			document.EventSinkService.NodeMouseDown += new NodeMouseEventHandler(EventSinkService_NodeMouseDown);
			document.EventSinkService.NodeMouseEnter += new NodeViewEventHandler(EventSinkService_NodeMouseEnter);
			document.EventSinkService.NodeMouseLeave += new NodeViewEventHandler(EventSinkService_NodeMouseLeave);
			document.EventSinkService.NodeMouseUp += new NodeMouseEventHandler(EventSinkService_NodeMouseUp);
			document.EventSinkService.NodeKeyUp += new NodeKeyEventHandler(EventSinkService_NodeKeyUp);
			document.EventSinkService.NodeKeyPress += new NodeKeyPressEventHandler(EventSinkService_NodeKeyPress);

			Debug.WriteLineIf(document.EventSinkService.IsInputChar != null, "document.DelegateIsInputChar has been already assigned.");
			Debug.WriteLineIf(document.EventSinkService.IsInputKey != null, "document.DelegateIsInputKey has been already assigned.");
				
			document.EventSinkService.IsInputChar = new IsInputChar(document_IsInputChar);
			document.EventSinkService.IsInputKey = new IsInputKey(document_IsInputKey);
			
			base.AttachToEvents();
		}

		protected override void DetachFromEvents()
		{
			document.EventSinkService.NodeMouseDown -= new NodeMouseEventHandler(EventSinkService_NodeMouseDown);
			document.EventSinkService.NodeMouseEnter -= new NodeViewEventHandler(EventSinkService_NodeMouseEnter);
			document.EventSinkService.NodeMouseLeave -= new NodeViewEventHandler(EventSinkService_NodeMouseLeave);
			document.EventSinkService.NodeMouseUp -= new NodeMouseEventHandler(EventSinkService_NodeMouseUp);
			document.EventSinkService.NodeKeyUp -= new NodeKeyEventHandler(EventSinkService_NodeKeyUp);
			document.EventSinkService.NodeKeyPress -= new NodeKeyPressEventHandler(EventSinkService_NodeKeyPress);

			document.EventSinkService.IsInputChar = null;
			document.EventSinkService.IsInputKey = null;

			base.DetachFromEvents();
		}


		#endregion

		#region Implementation

		private void InitDocument()
		{
			NBasicShapesFactory factory = new NBasicShapesFactory(document);

			// create interactive rect
			NShape rect = factory.CreateShape((int)BasicShapes.Rectangle);
			rect.Bounds = base.GetGridCell(0, 0);
			rect.Text = InitialShapeText;
			rect.Name = "Interactive Rectangle";
			rect.Style.InteractivityStyle = new NInteractivityStyle("I am a rectangle with hand cursor", CursorType.Hand);  
			document.ActiveLayer.AddChild(rect);

			// create interactive ellipse
			NShape ellipse = factory.CreateShape((int)BasicShapes.Ellipse);
			ellipse.Bounds = base.GetGridCell(0, 1);
			ellipse.Text = InitialShapeText;
			ellipse.Name = "Interactive Ellipse";
			ellipse.Style.InteractivityStyle = new NInteractivityStyle("I am an ellipse with wait cursor", CursorType.WaitCursor);  
			document.ActiveLayer.AddChild(ellipse);

			// create interactive rounded rect
			NShape roundedRect = factory.CreateShape((int)BasicShapes.RoundedRectangle);
			roundedRect.Bounds = base.GetGridCell(1, 0);
			roundedRect.Text = InitialShapeText;
			roundedRect.Name = "Interactive Rounded Rectangle";
			roundedRect.Style.InteractivityStyle = new NInteractivityStyle("I am a rounded rectangle with cross cursor", CursorType.Cross);  
			document.ActiveLayer.AddChild(roundedRect);

			// create interactive hexagram
			NShape hexagram = factory.CreateShape((int)BasicShapes.Hexagram);
			hexagram.Bounds = base.GetGridCell(1, 1);
			hexagram.Text = InitialShapeText;
			hexagram.Name = "Interactive Hexagram";
			hexagram.Style.InteractivityStyle = new NInteractivityStyle("I am a hexagram with help cursor", CursorType.Help);  
			document.ActiveLayer.AddChild(hexagram);

			// initially focus the rect
			FocusShape(rect);
		}
		
		private void InitFormControls()
		{
			PauseEventsHandling();		

			markEventsAsProcessedCheck.Checked = true;

			toolsConfigCombo.FillFromEnum(typeof(ToolsConfiguration));
			toolsConfigCombo.SelectedIndex = (int)ToolsConfiguration.PointerBeforeEventDelagators;

			ResumeEventsHandling();
		}
		

		private void ProcessDocumentKey(NNodeKeyEventArgs args)
		{
			// the only key the document processes is the tab
			if (args.KeyCode != Keys.Tab)
				return;
			
			NShape newFocusedShape = null;
			NShape curFocusedShape = (document.FocusedElement as NShape);

			// if there is no currently focused shape
			if (curFocusedShape == null)
			{
				curFocusedShape = (document.ActiveLayer.GetChildAt(0) as NShape);
			}
			else
			{
				// get focused shape index
				int index = document.ActiveLayer.IndexOfChild(curFocusedShape);

				// increase or decrease depending on whether the shift was pressed
				if (args.Shift)
				{
					index--;
				}
				else
				{
					index++;
				}

				// clamp to valid index
				if (index < 0)
				{
					index = document.ActiveLayer.ChildrenCount(null) - 1;
				}
				else if (index >= document.ActiveLayer.ChildrenCount(null))
				{
					index = 0;
				}

				// get new focused node
				newFocusedShape = (document.ActiveLayer.GetChildAt(index) as NShape);
			}

			// focus the new node
			FocusShape(newFocusedShape);
			
			// mark event as handled and processed
			args.Handled = true;
			args.Processed = markEventsAsProcessedCheck.Checked;
		}

		private void ProcessShapeKey(NNodeKeyEventArgs args)
		{
			if (args.KeyData != Keys.Left &&
				args.KeyData != Keys.Right &&
				args.KeyData != Keys.Up &&
				args.KeyData != Keys.Down)
				return;

			NShape shape = (args.Node as NShape);
			NRectangleF bounds = shape.Bounds;
			
			switch (args.KeyData)
			{
				case Keys.Left:
					bounds.Translate(-5, 0);
					break;
				case Keys.Right:
					bounds.Translate(5, 0);
					break;
				case Keys.Up:
					bounds.Translate(0, -5);
					break;
				case Keys.Down:
					bounds.Translate(0, 5);
					break;
			}

			shape.Bounds = bounds;
			document.SmartRefreshAllViews();

			// mark event as handled and processed
			args.Handled = true;
			args.Processed = markEventsAsProcessedCheck.Checked;
		}

		private void ProcessShapeChar(NNodeKeyPressEventArgs args)
		{
			if (!char.IsLetterOrDigit(args.KeyChar) && 
				!char.IsWhiteSpace(args.KeyChar) && 
				!char.IsPunctuation(args.KeyChar))
				return;

			// the shape processes all chars and adds them to the shape text
			NShape shape = (args.Node as NShape);

			if (shape.Text == InitialShapeText)
				shape.Text = "";

			shape.Text += args.KeyChar;

			// mark as handled and processed to stop bubbling and processing
			args.Handled = true;
			args.Processed = markEventsAsProcessedCheck.Checked;
		}


		private void FocusShape(NShape newFocusedShape)
		{
			// force current focused shape to use default stroke style
			NShape curFocusedShape = (document.FocusedElement as NShape);
			if (curFocusedShape != null)
			{
				curFocusedShape.Style.StrokeStyle = null;
			}

			// if null -> remove any focus
			if (newFocusedShape == null)
			{
				document.FocusedElementUniqueId = Guid.Empty;
				return;
			}

			// focus the new element
			document.FocusedElementUniqueId = newFocusedShape.UniqueId;
			newFocusedShape.Style.StrokeStyle = new NStrokeStyle(2, Color.Red);

			document.SmartRefreshAllViews();
		}

		private void ConfigureTools(ToolsConfiguration config)
		{
			// initially remove all tools from the view tools collection
			view.Controller.Tools.Clear();

			// determine which tools must be created and in what order
			bool createPointer = false;
			bool createDelegators = false;
			bool pointerBeforeDelegator = false;

			switch (config)
			{
				case ToolsConfiguration.OnlyEventDelagators:
					createPointer = false;
					createDelegators = true;
					break;
		
				case ToolsConfiguration.OnlyPointer:
					createPointer = true;
					createDelegators = false;
					break;
				
				case ToolsConfiguration.PointerBeforeEventDelagators:
					createPointer = true;
					createDelegators = true;
					pointerBeforeDelegator = true;
					break;
				
				case ToolsConfiguration.EventDelagatorsBeforePointer:
					createPointer = true;
					createDelegators = true;
					pointerBeforeDelegator = false;
					break;

				default:
					Debug.Assert(false, "New tools config?");
					break;
			}

			// create the needed tools
			NTool[] pointerTools = null, delegatorTools = null;
			if (createPointer)
			{
				pointerTools = new NTool[] {	new NCreateGuidelineTool(),
												new NHandleTool(),
												new NMoveTool(),
												new NSelectorTool(),
												new NContextMenuTool(),
												new NKeyboardTool(),
												new NInplaceEditTool()};
			}

			if (createDelegators)
			{
				delegatorTools = new NTool[] {	new NMouseEventDelegatorTool(),
												new NKeyboardEventDelegatorTool(),
												new NDragDropEventDelegatorTool()};
			}
			
			// add them in the proper order
			if (pointerBeforeDelegator)
			{
				if (pointerTools != null)
				{
					foreach (NTool tool in pointerTools)
						view.Controller.Tools.Add(tool);
				}

				if (delegatorTools != null)
				{
					foreach (NTool tool in delegatorTools)
						view.Controller.Tools.Add(tool);
				}
			}
			else
			{
				if (delegatorTools != null)
				{
					foreach (NTool tool in delegatorTools)
						view.Controller.Tools.Add(tool);
				}

				if (pointerTools != null)
				{
					foreach (NTool tool in pointerTools)
						view.Controller.Tools.Add(tool);
				}
			}
            
			// enable all tools
			view.Controller.Tools.EnableAllTools();
		}


		#endregion

		#region Delegate Handlers
		
		protected bool document_IsInputChar(INNode node, char inputChar)
		{
			// in this example we have no special characters we want to process
			return false;
		}

		protected bool document_IsInputKey(INNode node, Keys keyData)
		{
			// the document wants to process the TAB key
			if (node is NDrawingDocument)
			{
				return (keyData & Keys.Tab) == Keys.Tab;
			}
			
			// focused shapes want to process the ARROW Keys
			if (node is NShape)
			{
				if (keyData == Keys.Left ||
					keyData == Keys.Right ||
					keyData == Keys.Up ||
					keyData == Keys.Down)
					return true;
			}
		
			return false;
		}


		#endregion
		
		#region Event Handlers
		
		private void EventSinkService_NodeMouseDown(NNodeMouseEventArgs args)
		{
			// if left mouse down and node is shape -> focus it and stop bubbling and processing
			if (args.Button == MouseButtons.Left && (args.Node is NShape))
			{
				FocusShape(args.Node as NShape);

				// mark as handled and processed to stop bubbling and processing
				args.Handled = true;
				args.Processed = markEventsAsProcessedCheck.Checked;
			}
		}

		private void EventSinkService_NodeMouseUp(NNodeMouseEventArgs args)
		{
			// if right mouse up and node is active layer child -> show message box and stop bubbling and processing
			if (args.Button == MouseButtons.Right && (args.Node.ParentNode == document.ActiveLayer))
			{
				PointF viewCoordinates = new PointF(args.X, args.Y);
				PointF sceneCoordinates = view.SceneToWorld.InvertPoint(viewCoordinates);
			
				MessageBox.Show(string.Format(
					"Mouse up event data\nNode: {0};\nView coordinates: (in px) {1};\nScene coordinates: (in {2}) {3};\nMouse Button: {4}.",
					(args.Node as INDiagramElement).Name,
					viewCoordinates.ToString(),
					document.MeasurementUnit.Abbreviation,
					sceneCoordinates.ToString(),
					args.Button.ToString()
					));

				// mark as handled and processed to stop bubbling and processing
				args.Handled = true;
				args.Processed = markEventsAsProcessedCheck.Checked;
			}
		}

		private void EventSinkService_NodeMouseEnter(NNodeViewEventArgs args)
		{
			// highlight shapes on mouse enter
			NShape shape = (args.Node as NShape);
			if (shape == null)
				return;

			shape.Style.FillStyle = new NColorFillStyle(SystemColors.HotTrack); 

			// mark as handled and processed to stop bubbling and processing
			args.Handled = true;
			args.Processed = markEventsAsProcessedCheck.Checked;
		}

		private void EventSinkService_NodeMouseLeave(NNodeViewEventArgs args)
		{
			// remove highlighting on mouse leave 
			NShape shape = (args.Node as NShape);
			if (shape == null)
				return;

			shape.Style.FillStyle = null; 

			// mark as handled and processed to stop bubbling and processing
			args.Handled = true;
			args.Processed = markEventsAsProcessedCheck.Checked;
		}

		private void EventSinkService_NodeKeyUp(NNodeKeyEventArgs args)
		{
			// process document key
			if (args.Node is NDrawingDocument)
			{
				ProcessDocumentKey(args);
				document.SmartRefreshAllViews();
				return;
			}
			
			// process shape key
			if (args.Node is NShape)
			{
				ProcessShapeKey(args);
				document.SmartRefreshAllViews();
				return;
			}
		}

		private void EventSinkService_NodeKeyPress(NNodeKeyPressEventArgs args)
		{
			// process shape char
			if (args.Node is NShape)
			{
				ProcessShapeChar(args);
				document.SmartRefreshAllViews();
				return;
			}
		}

		private void toolsConfigCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			ToolsConfiguration config = (ToolsConfiguration)toolsConfigCombo.SelectedIndex; 
			ConfigureTools(config);
		}


		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NComboBox toolsConfigCombo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox markEventsAsProcessedCheck;

		#endregion		
		
		#region Fields

		private const string InitialShapeText = "Click me and type. Use Tab/Shift-Tab to move to next/prev shape.";

		#endregion
	}
}