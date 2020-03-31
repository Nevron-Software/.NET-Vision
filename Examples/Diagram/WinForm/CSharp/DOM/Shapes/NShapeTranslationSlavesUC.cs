using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.Editors;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Diagram;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.Filters;
using Nevron.Diagram.WinForm;
using Nevron.Diagram.Templates;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NShapeTranslationSlavesUC.
	/// </summary>
	public class NShapeTranslationSlavesUC : NDiagramExampleUC
	{
		#region Constructor

		public NShapeTranslationSlavesUC(NMainForm form) : base(form)
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
			this.shapeTranslationSlavesGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.reflexiveShapesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.successorShapesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.predecessorShapesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.accessibleShapesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.destinationShapesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.sourceShapesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.neighbourShapesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.connectedShapesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.outgoingShapesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.incommingShapesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.toShapeCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.fromShapeCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.shapeTranslationSlavesGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// shapeTranslationSlavesGroup
			// 
			this.shapeTranslationSlavesGroup.Controls.Add(this.reflexiveShapesCheck);
			this.shapeTranslationSlavesGroup.Controls.Add(this.successorShapesCheck);
			this.shapeTranslationSlavesGroup.Controls.Add(this.predecessorShapesCheck);
			this.shapeTranslationSlavesGroup.Controls.Add(this.accessibleShapesCheck);
			this.shapeTranslationSlavesGroup.Controls.Add(this.destinationShapesCheck);
			this.shapeTranslationSlavesGroup.Controls.Add(this.sourceShapesCheck);
			this.shapeTranslationSlavesGroup.Controls.Add(this.neighbourShapesCheck);
			this.shapeTranslationSlavesGroup.Controls.Add(this.connectedShapesCheck);
			this.shapeTranslationSlavesGroup.Controls.Add(this.outgoingShapesCheck);
			this.shapeTranslationSlavesGroup.Controls.Add(this.incommingShapesCheck);
			this.shapeTranslationSlavesGroup.Controls.Add(this.toShapeCheck);
			this.shapeTranslationSlavesGroup.Controls.Add(this.fromShapeCheck);
			this.shapeTranslationSlavesGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.shapeTranslationSlavesGroup.Enabled = false;
			this.shapeTranslationSlavesGroup.ImageIndex = 0;
			this.shapeTranslationSlavesGroup.Location = new System.Drawing.Point(0, 0);
			this.shapeTranslationSlavesGroup.Name = "shapeTranslationSlavesGroup";
			this.shapeTranslationSlavesGroup.Size = new System.Drawing.Size(248, 424);
			this.shapeTranslationSlavesGroup.TabIndex = 0;
			this.shapeTranslationSlavesGroup.TabStop = false;
			this.shapeTranslationSlavesGroup.Text = "Selected shape translation slaves";
			// 
			// reflexiveShapesCheck
			// 
			this.reflexiveShapesCheck.Location = new System.Drawing.Point(40, 48);
			this.reflexiveShapesCheck.Name = "reflexiveShapesCheck";
			this.reflexiveShapesCheck.Size = new System.Drawing.Size(152, 16);
			this.reflexiveShapesCheck.TabIndex = 1;
			this.reflexiveShapesCheck.Text = "Reflexive shapes";
			this.reflexiveShapesCheck.CheckedChanged += new System.EventHandler(this.reflexiveShapesCheck_CheckedChanged);
			// 
			// successorShapesCheck
			// 
			this.successorShapesCheck.Location = new System.Drawing.Point(40, 264);
			this.successorShapesCheck.Name = "successorShapesCheck";
			this.successorShapesCheck.Size = new System.Drawing.Size(152, 16);
			this.successorShapesCheck.TabIndex = 10;
			this.successorShapesCheck.Text = "Successor shapes";
			this.successorShapesCheck.CheckedChanged += new System.EventHandler(this.successorShapesCheck_CheckedChanged);
			// 
			// predecessorShapesCheck
			// 
			this.predecessorShapesCheck.Location = new System.Drawing.Point(40, 288);
			this.predecessorShapesCheck.Name = "predecessorShapesCheck";
			this.predecessorShapesCheck.Size = new System.Drawing.Size(152, 16);
			this.predecessorShapesCheck.TabIndex = 11;
			this.predecessorShapesCheck.Text = "Predecessor shapes";
			this.predecessorShapesCheck.CheckedChanged += new System.EventHandler(this.predecessorShapesCheck_CheckedChanged);
			// 
			// accessibleShapesCheck
			// 
			this.accessibleShapesCheck.Location = new System.Drawing.Point(8, 240);
			this.accessibleShapesCheck.Name = "accessibleShapesCheck";
			this.accessibleShapesCheck.Size = new System.Drawing.Size(152, 16);
			this.accessibleShapesCheck.TabIndex = 9;
			this.accessibleShapesCheck.Text = "Accessible shapes";
			this.accessibleShapesCheck.CheckedChanged += new System.EventHandler(this.accessibleShapesCheck_CheckedChanged);
			// 
			// destinationShapesCheck
			// 
			this.destinationShapesCheck.Location = new System.Drawing.Point(40, 192);
			this.destinationShapesCheck.Name = "destinationShapesCheck";
			this.destinationShapesCheck.Size = new System.Drawing.Size(152, 16);
			this.destinationShapesCheck.TabIndex = 7;
			this.destinationShapesCheck.Text = "Destination shapes";
			this.destinationShapesCheck.CheckedChanged += new System.EventHandler(this.destinationShapesCheck_CheckedChanged);
			// 
			// sourceShapesCheck
			// 
			this.sourceShapesCheck.Location = new System.Drawing.Point(40, 216);
			this.sourceShapesCheck.Name = "sourceShapesCheck";
			this.sourceShapesCheck.Size = new System.Drawing.Size(152, 16);
			this.sourceShapesCheck.TabIndex = 8;
			this.sourceShapesCheck.Text = "Source shapes";
			this.sourceShapesCheck.CheckedChanged += new System.EventHandler(this.sourceShapesCheck_CheckedChanged);
			// 
			// neighbourShapesCheck
			// 
			this.neighbourShapesCheck.Location = new System.Drawing.Point(8, 168);
			this.neighbourShapesCheck.Name = "neighbourShapesCheck";
			this.neighbourShapesCheck.Size = new System.Drawing.Size(152, 16);
			this.neighbourShapesCheck.TabIndex = 6;
			this.neighbourShapesCheck.Text = "Neighbour shapes";
			this.neighbourShapesCheck.CheckedChanged += new System.EventHandler(this.neighbourShapesCheck_CheckedChanged);
			// 
			// connectedShapesCheck
			// 
			this.connectedShapesCheck.Location = new System.Drawing.Point(8, 24);
			this.connectedShapesCheck.Name = "connectedShapesCheck";
			this.connectedShapesCheck.Size = new System.Drawing.Size(152, 16);
			this.connectedShapesCheck.TabIndex = 0;
			this.connectedShapesCheck.Text = "Connected shapes";
			this.connectedShapesCheck.CheckedChanged += new System.EventHandler(this.connectedShapesCheck_CheckedChanged);
			// 
			// outgoingShapesCheck
			// 
			this.outgoingShapesCheck.Location = new System.Drawing.Point(40, 96);
			this.outgoingShapesCheck.Name = "outgoingShapesCheck";
			this.outgoingShapesCheck.Size = new System.Drawing.Size(152, 16);
			this.outgoingShapesCheck.TabIndex = 3;
			this.outgoingShapesCheck.Text = "Outgoing shapes";
			this.outgoingShapesCheck.CheckedChanged += new System.EventHandler(this.outgoingShapesCheck_CheckedChanged);
			// 
			// incommingShapesCheck
			// 
			this.incommingShapesCheck.Location = new System.Drawing.Point(40, 72);
			this.incommingShapesCheck.Name = "incommingShapesCheck";
			this.incommingShapesCheck.Size = new System.Drawing.Size(152, 16);
			this.incommingShapesCheck.TabIndex = 2;
			this.incommingShapesCheck.Text = "Incomming shapes";
			this.incommingShapesCheck.CheckedChanged += new System.EventHandler(this.incommingShapesCheck_CheckedChanged);
			// 
			// toShapeCheck
			// 
			this.toShapeCheck.Location = new System.Drawing.Point(40, 144);
			this.toShapeCheck.Name = "toShapeCheck";
			this.toShapeCheck.Size = new System.Drawing.Size(152, 16);
			this.toShapeCheck.TabIndex = 5;
			this.toShapeCheck.Text = "To shape";
			this.toShapeCheck.CheckedChanged += new System.EventHandler(this.toShapeCheck_CheckedChanged);
			// 
			// fromShapeCheck
			// 
			this.fromShapeCheck.Location = new System.Drawing.Point(40, 120);
			this.fromShapeCheck.Name = "fromShapeCheck";
			this.fromShapeCheck.Size = new System.Drawing.Size(152, 16);
			this.fromShapeCheck.TabIndex = 4;
			this.fromShapeCheck.Text = "From shape";
			this.fromShapeCheck.CheckedChanged += new System.EventHandler(this.fromShapeCheck_CheckedChanged);
			// 
			// NShapeTranslationSlavesUC
			// 
			this.Controls.Add(this.shapeTranslationSlavesGroup);
			this.Name = "NShapeTranslationSlavesUC";
			this.Size = new System.Drawing.Size(248, 560);
			this.Controls.SetChildIndex(this.shapeTranslationSlavesGroup, 0);
			this.shapeTranslationSlavesGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// init form members
			highlightFillStyle = new NColorFillStyle(Color.FromArgb(80, Color.Red));
			highlightStrokeStyle = new NStrokeStyle(2, Color.Red);

			// begin view init
			view.BeginInit();

			view.Grid.Visible = false;
			view.Selection.Mode = DiagramSelectionMode.Single;
			view.InteractiveAppearance.SelectedStrokeStyle = new NStrokeStyle(2, Color.Blue);
			view.InteractiveAppearance.SelectedFillStyle = new NColorFillStyle(Color.FromArgb(80, Color.Blue));

			// init document
			document.BeginInit();
			InitDocument();
			document.EndInit();
            
			// init form controls
			InitFormControls();

			// end view init
			view.EndInit();
		}

		protected override void AttachToEvents()
		{
			view.EventSinkService.NodeSelected += new NodeEventHandler(EventSinkService_OnNodeSelected);
			view.EventSinkService.NodeDeselected += new NodeEventHandler(EventSinkService_OnNodeDeselected);

			base.AttachToEvents();
		}
		
		protected override void DetachFromEvents()
		{
			view.EventSinkService.NodeSelected -= new NodeEventHandler(EventSinkService_OnNodeSelected);
			view.EventSinkService.NodeDeselected -= new NodeEventHandler(EventSinkService_OnNodeDeselected);
		
			base.DetachFromEvents();
		}


		#endregion

		#region Implementation

		private void InitFormControls()
		{
			PauseEventsHandling();

			incommingShapesCheck.Checked = false;
			outgoingShapesCheck.Checked = false;
			connectedShapesCheck.Checked = false;
			neighbourShapesCheck.Checked = false;
			sourceShapesCheck.Checked = false;
			destinationShapesCheck.Checked = false;
			accessibleShapesCheck.Checked = false;
			predecessorShapesCheck.Checked = false;
			successorShapesCheck.Checked = false;
			fromShapeCheck.Checked = false;
			toShapeCheck.Checked = false;
			
			ResumeEventsHandling();
		}
				
		private void InitDocument()
		{
			document.Style.TextStyle = new NTextStyle(new Font("Arial", 9), Color.Black);

			NGraphTemplate template;

			// create rectangular grid template
			template = new NRectangularGridTemplate();
			template.Origin = new NPointF(10, 23);
			template.VerticesShape = BasicShapes.Rectangle;
			template.Create(document);

			// create tree template
			template = new NGenericTreeTemplate();
			template.Origin = new NPointF(250, 23);
			template.VerticesShape = BasicShapes.Triangle;
			template.Create(document);

			// create elliptical grid template
			template = new NEllipticalGridTemplate();
			template.Origin = new NPointF(10, 250);
			template.VerticesShape = BasicShapes.Ellipse;
			template.Create(document);

			// create a shape with a 1D shape which reflexes it
			NBasicShapesFactory factory = new NBasicShapesFactory(document);
			NShape shape = factory.CreateShape((int)BasicShapes.Rectangle);
			shape.Bounds = new NRectangleF(350, 350, 100, 100);
			document.ActiveLayer.AddChild(shape);

			NBezierCurveShape bezier = new NBezierCurveShape();
			bezier.StyleSheetName = NDR.NameConnectorsStyleSheet;
			document.ActiveLayer.AddChild(bezier);

			bezier.FromShape = shape;
			bezier.ToShape = shape;
			bezier.Reflex();
		}

		private void UpdateTranslationSlaves()
		{
			NShape shape = (view.Selection.AnchorNode as NShape);
			if (shape == null)
				return;

			NTranslationSlaves slaves = shape.TranslationSlaves; 

			slaves.ConnectedShapes = connectedShapesCheck.Checked;
			slaves.IncomingShapes = incommingShapesCheck.Checked;
			slaves.OutgoingShapes = outgoingShapesCheck.Checked;
			slaves.ReflexiveShapes = reflexiveShapesCheck.Checked;
			slaves.FromShape = fromShapeCheck.Checked;
			slaves.ToShape = toShapeCheck.Checked;
			
			slaves.NeighbourShapes = neighbourShapesCheck.Checked;
			slaves.SourceShapes = sourceShapesCheck.Checked;
			slaves.DestinationShapes = destinationShapesCheck.Checked;

			slaves.AccessibleShapes = accessibleShapesCheck.Checked;
			slaves.PredecessorShapes = predecessorShapesCheck.Checked;
			slaves.SuccessorShapes = successorShapesCheck.Checked;

			shape.TranslationSlaves = slaves;
		}

		private void UpdateHighlights()
		{
			ClearHighlights();

			NShape shape = (view.Selection.AnchorNode as NShape);
			if (shape == null)
				return;

            NNodeList nodes = new NNodeList();
            shape.AccumulateTranslationSlaves(nodes, null, false);

            foreach (NShape slave in nodes)
			{
				slave.Style.FillStyle = (NFillStyle)highlightFillStyle.Clone();
				slave.Style.StrokeStyle = (NStrokeStyle)highlightStrokeStyle.Clone() ;
			}
		}

		private void ClearHighlights()
		{
			NNodeEnumerator en = document.ActiveLayer.GetEnumerator(NFilters.TypeNShape);
			while (en.MoveNext())
			{
				NShape shape = (en.Current as NShape);
				
				shape.Style.FillStyle = null;
				shape.Style.StrokeStyle = null;
			}
		}

		
		#endregion

		#region Event Handlers

		private void EventSinkService_OnNodeSelected(NNodeEventArgs args)
		{
			PauseEventsHandling();

			NShape shape = (args.Node as NShape);
			if (shape == null)
			{
				shapeTranslationSlavesGroup.Enabled = false;
				return;
			}

			// update form controls
			shapeTranslationSlavesGroup.Enabled = true;
		
			NTranslationSlaves slaves = shape.TranslationSlaves;

 			connectedShapesCheck.Checked = slaves.ConnectedShapes;
			incommingShapesCheck.Checked = slaves.IncomingShapes;
			outgoingShapesCheck.Checked = slaves.OutgoingShapes;
			reflexiveShapesCheck.Checked = slaves.ReflexiveShapes;
			
			neighbourShapesCheck.Checked = slaves.NeighbourShapes;
			sourceShapesCheck.Checked = slaves.NeighbourShapes;
			destinationShapesCheck.Checked = slaves.DestinationShapes;

			accessibleShapesCheck.Checked = slaves.AccessibleShapes;
			predecessorShapesCheck.Checked = slaves.PredecessorShapes;
			successorShapesCheck.Checked = slaves.SuccessorShapes;

			fromShapeCheck.Checked = slaves.FromShape;
			toShapeCheck.Checked = slaves.ToShape;

			ResumeEventsHandling();

			// update highligts
			UpdateHighlights();
			document.SmartRefreshAllViews();
		}

        private void EventSinkService_OnNodeDeselected(NNodeEventArgs args)
		{
			shapeTranslationSlavesGroup.Enabled = false;

			// clear highligts
			ClearHighlights();
			document.SmartRefreshAllViews();
		}


		private void connectedShapesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			PauseEventsHandling();

			incommingShapesCheck.Checked = connectedShapesCheck.Checked;
			outgoingShapesCheck.Checked = connectedShapesCheck.Checked;
			reflexiveShapesCheck.Checked = connectedShapesCheck.Checked;
			fromShapeCheck.Checked = connectedShapesCheck.Checked;
			toShapeCheck.Checked = connectedShapesCheck.Checked;

			ResumeEventsHandling();

			UpdateTranslationSlaves();
			UpdateHighlights();

			document.SmartRefreshAllViews();
		}

		private void reflexiveShapesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			UpdateTranslationSlaves();
			UpdateHighlights();

			document.SmartRefreshAllViews();
		}

		private void incommingShapesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			UpdateTranslationSlaves();
			UpdateHighlights();

			document.SmartRefreshAllViews();
		}

		private void outgoingShapesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			UpdateTranslationSlaves();
			UpdateHighlights();

			document.SmartRefreshAllViews();
		}

		private void neighbourShapesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			PauseEventsHandling();

			sourceShapesCheck.Checked = neighbourShapesCheck.Checked;
			destinationShapesCheck.Checked = neighbourShapesCheck.Checked;

			ResumeEventsHandling();

			UpdateTranslationSlaves();
			UpdateHighlights();

			document.SmartRefreshAllViews();
		}

		private void sourceShapesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			UpdateTranslationSlaves();
			UpdateHighlights();

			document.SmartRefreshAllViews();
		}

		private void destinationShapesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			UpdateTranslationSlaves();
			UpdateHighlights();

			document.SmartRefreshAllViews();
		}

		private void accessibleShapesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			PauseEventsHandling();

			successorShapesCheck.Checked = accessibleShapesCheck.Checked;
			predecessorShapesCheck.Checked = accessibleShapesCheck.Checked;

			ResumeEventsHandling();

			UpdateTranslationSlaves();
			UpdateHighlights();

			document.SmartRefreshAllViews();
		}

		private void predecessorShapesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			UpdateTranslationSlaves();
			UpdateHighlights();

			document.SmartRefreshAllViews();
		}

		private void successorShapesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			UpdateTranslationSlaves();
			UpdateHighlights();

			document.SmartRefreshAllViews();
		}

		private void fromShapeCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			UpdateTranslationSlaves();
			UpdateHighlights();

			document.SmartRefreshAllViews();
		}

		private void toShapeCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			UpdateTranslationSlaves();
			UpdateHighlights();

			document.SmartRefreshAllViews();
		}


		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;

		#endregion

		#region Fields

		private NColorFillStyle highlightFillStyle = null;
		private NStrokeStyle highlightStrokeStyle = null;
		private Nevron.UI.WinForm.Controls.NCheckBox incommingShapesCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox outgoingShapesCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox connectedShapesCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox neighbourShapesCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox sourceShapesCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox destinationShapesCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox accessibleShapesCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox predecessorShapesCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox successorShapesCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox fromShapeCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox toShapeCheck;
		private Nevron.UI.WinForm.Controls.NGroupBox shapeTranslationSlavesGroup;
		private Nevron.UI.WinForm.Controls.NCheckBox reflexiveShapesCheck;
		private NStrokeStyle selectedStrokeStyle = null;

		#endregion
	}
}
