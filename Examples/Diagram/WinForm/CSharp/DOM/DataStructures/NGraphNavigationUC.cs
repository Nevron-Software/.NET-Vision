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
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.WinForm;
using Nevron.Diagram.Templates;
using Nevron.Diagram.Layout;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NGraphNavigationUC.
	/// </summary>
	public class NGraphNavigationUC: NDiagramExampleUC
	{
		#region Constructor

		public NGraphNavigationUC(NMainForm form) : base(form)
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
			this.vertexHighlightsGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.successorVerticesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.predecessorVerticesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.accessibleVerticesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.destinationVerticesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.sourceVerticesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.neighbourVerticesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.allEdgesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.outgoingEdgesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.incommingEdgesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.edgeHighlightsGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.toVertexCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.fromVertexCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.graphPartCheck = new System.Windows.Forms.CheckBox();
			this.vertexHighlightsGroup.SuspendLayout();
			this.edgeHighlightsGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// vertexHighlightsGroup
			// 
			this.vertexHighlightsGroup.Controls.Add(this.successorVerticesCheck);
			this.vertexHighlightsGroup.Controls.Add(this.predecessorVerticesCheck);
			this.vertexHighlightsGroup.Controls.Add(this.accessibleVerticesCheck);
			this.vertexHighlightsGroup.Controls.Add(this.destinationVerticesCheck);
			this.vertexHighlightsGroup.Controls.Add(this.sourceVerticesCheck);
			this.vertexHighlightsGroup.Controls.Add(this.neighbourVerticesCheck);
			this.vertexHighlightsGroup.Controls.Add(this.allEdgesCheck);
			this.vertexHighlightsGroup.Controls.Add(this.outgoingEdgesCheck);
			this.vertexHighlightsGroup.Controls.Add(this.incommingEdgesCheck);
			this.vertexHighlightsGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.vertexHighlightsGroup.ImageIndex = 0;
			this.vertexHighlightsGroup.Location = new System.Drawing.Point(0, 0);
			this.vertexHighlightsGroup.Name = "vertexHighlightsGroup";
			this.vertexHighlightsGroup.Size = new System.Drawing.Size(248, 256);
			this.vertexHighlightsGroup.TabIndex = 30;
			this.vertexHighlightsGroup.TabStop = false;
			this.vertexHighlightsGroup.Text = "Selected vertex highlighs";
			// 
			// successorVerticesCheck
			// 
			this.successorVerticesCheck.Location = new System.Drawing.Point(48, 216);
			this.successorVerticesCheck.Name = "successorVerticesCheck";
			this.successorVerticesCheck.Size = new System.Drawing.Size(152, 16);
			this.successorVerticesCheck.TabIndex = 8;
			this.successorVerticesCheck.Text = "Successor vertices";
			this.successorVerticesCheck.CheckedChanged += new System.EventHandler(this.successorVerticesCheck_CheckedChanged);
			// 
			// predecessorVerticesCheck
			// 
			this.predecessorVerticesCheck.Location = new System.Drawing.Point(48, 192);
			this.predecessorVerticesCheck.Name = "predecessorVerticesCheck";
			this.predecessorVerticesCheck.Size = new System.Drawing.Size(152, 16);
			this.predecessorVerticesCheck.TabIndex = 7;
			this.predecessorVerticesCheck.Text = "Predecessor vertices";
			this.predecessorVerticesCheck.CheckedChanged += new System.EventHandler(this.predecessorVerticesCheck_CheckedChanged);
			// 
			// accessibleVerticesCheck
			// 
			this.accessibleVerticesCheck.Location = new System.Drawing.Point(8, 168);
			this.accessibleVerticesCheck.Name = "accessibleVerticesCheck";
			this.accessibleVerticesCheck.Size = new System.Drawing.Size(152, 16);
			this.accessibleVerticesCheck.TabIndex = 6;
			this.accessibleVerticesCheck.Text = "Accessible vertices";
			this.accessibleVerticesCheck.CheckedChanged += new System.EventHandler(this.accessibleVerticesCheck_CheckedChanged);
			// 
			// destinationVerticesCheck
			// 
			this.destinationVerticesCheck.Location = new System.Drawing.Point(48, 144);
			this.destinationVerticesCheck.Name = "destinationVerticesCheck";
			this.destinationVerticesCheck.Size = new System.Drawing.Size(152, 16);
			this.destinationVerticesCheck.TabIndex = 5;
			this.destinationVerticesCheck.Text = "Destination vertices";
			this.destinationVerticesCheck.CheckedChanged += new System.EventHandler(this.destinationVerticesCheck_CheckedChanged);
			// 
			// sourceVerticesCheck
			// 
			this.sourceVerticesCheck.Location = new System.Drawing.Point(48, 120);
			this.sourceVerticesCheck.Name = "sourceVerticesCheck";
			this.sourceVerticesCheck.Size = new System.Drawing.Size(152, 16);
			this.sourceVerticesCheck.TabIndex = 4;
			this.sourceVerticesCheck.Text = "Source vertices";
			this.sourceVerticesCheck.CheckedChanged += new System.EventHandler(this.sourceVerticesCheck_CheckedChanged);
			// 
			// neighbourVerticesCheck
			// 
			this.neighbourVerticesCheck.Location = new System.Drawing.Point(8, 96);
			this.neighbourVerticesCheck.Name = "neighbourVerticesCheck";
			this.neighbourVerticesCheck.Size = new System.Drawing.Size(152, 16);
			this.neighbourVerticesCheck.TabIndex = 3;
			this.neighbourVerticesCheck.Text = "Neighbour vertices";
			this.neighbourVerticesCheck.CheckedChanged += new System.EventHandler(this.neighbourVerticesCheck_CheckedChanged);
			// 
			// allEdgesCheck
			// 
			this.allEdgesCheck.Location = new System.Drawing.Point(8, 24);
			this.allEdgesCheck.Name = "allEdgesCheck";
			this.allEdgesCheck.Size = new System.Drawing.Size(152, 16);
			this.allEdgesCheck.TabIndex = 2;
			this.allEdgesCheck.Text = "All edges";
			this.allEdgesCheck.CheckedChanged += new System.EventHandler(this.allEdgesCheck_CheckedChanged);
			// 
			// outgoingEdgesCheck
			// 
			this.outgoingEdgesCheck.Location = new System.Drawing.Point(48, 72);
			this.outgoingEdgesCheck.Name = "outgoingEdgesCheck";
			this.outgoingEdgesCheck.Size = new System.Drawing.Size(152, 16);
			this.outgoingEdgesCheck.TabIndex = 1;
			this.outgoingEdgesCheck.Text = "Outgoing edges";
			this.outgoingEdgesCheck.CheckedChanged += new System.EventHandler(this.outgoingEdgesCheck_CheckedChanged);
			// 
			// incommingEdgesCheck
			// 
			this.incommingEdgesCheck.Location = new System.Drawing.Point(48, 48);
			this.incommingEdgesCheck.Name = "incommingEdgesCheck";
			this.incommingEdgesCheck.Size = new System.Drawing.Size(152, 16);
			this.incommingEdgesCheck.TabIndex = 0;
			this.incommingEdgesCheck.Text = "Incomming edges";
			this.incommingEdgesCheck.CheckedChanged += new System.EventHandler(this.incommingEdgesCheck_CheckedChanged);
			// 
			// edgeHighlightsGroup
			// 
			this.edgeHighlightsGroup.Controls.Add(this.toVertexCheck);
			this.edgeHighlightsGroup.Controls.Add(this.fromVertexCheck);
			this.edgeHighlightsGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.edgeHighlightsGroup.ImageIndex = 0;
			this.edgeHighlightsGroup.Location = new System.Drawing.Point(0, 256);
			this.edgeHighlightsGroup.Name = "edgeHighlightsGroup";
			this.edgeHighlightsGroup.Size = new System.Drawing.Size(248, 80);
			this.edgeHighlightsGroup.TabIndex = 31;
			this.edgeHighlightsGroup.TabStop = false;
			this.edgeHighlightsGroup.Text = "Selected edge highlighs";
			// 
			// toVertexCheck
			// 
			this.toVertexCheck.Location = new System.Drawing.Point(8, 48);
			this.toVertexCheck.Name = "toVertexCheck";
			this.toVertexCheck.Size = new System.Drawing.Size(152, 16);
			this.toVertexCheck.TabIndex = 10;
			this.toVertexCheck.Text = "To vertex";
			this.toVertexCheck.CheckedChanged += new System.EventHandler(this.toVertexCheck_CheckedChanged);
			// 
			// fromVertexCheck
			// 
			this.fromVertexCheck.Location = new System.Drawing.Point(8, 24);
			this.fromVertexCheck.Name = "fromVertexCheck";
			this.fromVertexCheck.Size = new System.Drawing.Size(152, 16);
			this.fromVertexCheck.TabIndex = 9;
			this.fromVertexCheck.Text = "From vertex";
			this.fromVertexCheck.CheckedChanged += new System.EventHandler(this.fromVertexCheck_CheckedChanged);
			// 
			// graphPartCheck
			// 
			this.graphPartCheck.Location = new System.Drawing.Point(8, 352);
			this.graphPartCheck.Name = "graphPartCheck";
			this.graphPartCheck.Size = new System.Drawing.Size(216, 24);
			this.graphPartCheck.TabIndex = 32;
			this.graphPartCheck.Text = "Graph part";
			this.graphPartCheck.CheckedChanged += new System.EventHandler(this.graphPartCheck_CheckedChanged);
			// 
			// NGraphNavigationUC
			// 
			this.Controls.Add(this.graphPartCheck);
			this.Controls.Add(this.edgeHighlightsGroup);
			this.Controls.Add(this.vertexHighlightsGroup);
			this.Name = "NGraphNavigationUC";
			this.Size = new System.Drawing.Size(248, 560);
			this.Controls.SetChildIndex(this.vertexHighlightsGroup, 0);
			this.Controls.SetChildIndex(this.edgeHighlightsGroup, 0);
			this.Controls.SetChildIndex(this.graphPartCheck, 0);
			this.vertexHighlightsGroup.ResumeLayout(false);
			this.edgeHighlightsGroup.ResumeLayout(false);
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

			document.Style.TextStyle = new NTextStyle(new Font("Arial", 9), Color.Black);
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

            view.GlobalVisibility.ShowPorts = false;
			incommingEdgesCheck.Checked = false;
			outgoingEdgesCheck.Checked = false;
			allEdgesCheck.Checked = false;
			neighbourVerticesCheck.Checked = false;
			sourceVerticesCheck.Checked = false;
			destinationVerticesCheck.Checked = false;
			accessibleVerticesCheck.Checked = false;
			predecessorVerticesCheck.Checked = false;
			successorVerticesCheck.Checked = false;
			fromVertexCheck.Checked = false;
			toVertexCheck.Checked = false;
			graphPartCheck.Checked = true;
			
			ResumeEventsHandling();
		}
				
		private void InitDocument()
		{
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
		}

        private NNodeList GetShapesList(NGraphEdgeList edges, NObjectGraphPartMap map)
        {
            NNodeList list = new NNodeList();
            int i, edgeCount = edges.Count;
            for(i = 0; i < edgeCount; i++)
            {
                list.Add((NShape)map.GetObjectFromPart(edges[i]));
            }

            return list;
        }

        private NNodeList GetShapesList(NGraphVertexList vertices, NObjectGraphPartMap map)
        {
            NNodeList list = new NNodeList();
            int i, vertexCount = vertices.Count;
            for(i = 0; i < vertexCount; i++)
            {
                list.Add((NShape)map.GetObjectFromPart(vertices[i]));
            }

            return list;
        }

        private void UpdateHighlights()
		{
			ClearHighlights();

			// get the selected shape
			NShape shape = (view.Selection.AnchorNode as NShape);
			if (shape == null)
			{
				document.SmartRefreshAllViews();
				return;
			}

			// build the graph in which the shape resides
            NGraphBuilder graphBuilder = new NGraphBuilder(new NShapeGraphAdapter(), new NGraphPartFactory());
            
            NObjectGraphPartMap map;
			NGraph graph = graphBuilder.BuildGraph(shape, out map);
			
            if (graph == null)
			{
				document.SmartRefreshAllViews();
				return;
			}

			NNodeList shapesToHighlight = new NNodeList();
			switch (shape.ShapeType)
			{
				case ShapeType.Shape2D:
						
		            // 2D shapes are treated as graph vertices, so we must find the vertex in the graph, which 
					// represents the shape
					NGraphVertex vertex = (map.GetPartFromObject(shape) as NGraphVertex);
					if (vertex != null)
					{
						// add edges
						if (allEdgesCheck.Checked)
						{
							shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.Edges, map));  
						}
						else
						{
							if (incommingEdgesCheck.Checked)
								shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.IncomingEdges, map));  

							if (outgoingEdgesCheck.Checked)
								shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.OutgoingEdges, map));  
						}
			
						// add neighbour vertices
						if (neighbourVerticesCheck.Checked)
						{
							shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.NeighbourVertices, map));  
						}
						else
						{
							if (sourceVerticesCheck.Checked)
								shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.SourceVertices, map));  
						
							if (destinationVerticesCheck.Checked)
								shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.DestinationVertices, map));  
						}

						// add accessible vertices
						if (accessibleVerticesCheck.Checked)
						{
							shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.AccessibleVertices, map));  
						}
						else
						{
							if (predecessorVerticesCheck.Checked)
								shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.PredecessorVertices, map));  

							if (successorVerticesCheck.Checked)
								shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.SuccessorVertices, map));  
						}
					}
					break;
					
				case ShapeType.Shape1D:

					// 1D shapes are treated as graph edges, so we must find the edge in the graph, which 
					// represents the shape
					NGraphEdge edge = (map.GetPartFromObject(shape) as NGraphEdge);
					if (edge != null)
					{
						if (fromVertexCheck.Checked)
						{
							shapesToHighlight.AddNoDuplicates((NShape)map.GetObjectFromPart(edge.FromVertex));  
						}

						if (toVertexCheck.Checked)
						{
							shapesToHighlight.AddNoDuplicates((NShape)map.GetObjectFromPart(edge.ToVertex));  
						}
					}
					break;
			}

			// highlight the shapes
			foreach (NShape cur in shapesToHighlight)
			{
				cur.Style.FillStyle = (highlightFillStyle.Clone() as NFillStyle);
				cur.Style.StrokeStyle = (highlightStrokeStyle.Clone() as NStrokeStyle);
			}

			// smart refresh all views
			document.SmartRefreshAllViews();
		}

		private void ClearHighlights()
		{
			NNodeEnumerator en = document.ActiveLayer.GetEnumerator(null);
			while (en.MoveNext())
			{
				NShape shape = (en.Current as NShape);
				if (shape != null)
				{
					shape.Style.FillStyle = null;
					shape.Style.StrokeStyle = null;
				}
			}
		}


		#endregion

		#region Event Handlers

		private void EventSinkService_OnNodeSelected(NNodeEventArgs args)
		{
			NShape shape = (args.Node as NShape);
			if (shape != null)
			{
				base.PauseEventsHandling();

				graphPartCheck.Enabled = true;
				graphPartCheck.Checked = shape.GraphPart;

				base.ResumeEventsHandling();
			}

			UpdateHighlights();
		}

		private void EventSinkService_OnNodeDeselected(NNodeEventArgs args)
		{
			ClearHighlights();
			graphPartCheck.Enabled = false;

			document.SmartRefreshAllViews();
		}

		
		private void allEdgesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

            PauseEventsHandling();

			incommingEdgesCheck.Checked = allEdgesCheck.Checked;
			outgoingEdgesCheck.Checked = allEdgesCheck.Checked;

			ResumeEventsHandling();

			UpdateHighlights();
		}

		private void incommingEdgesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			UpdateHighlights();
		}

		private void outgoingEdgesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			UpdateHighlights();
		}

		private void neighbourVerticesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			PauseEventsHandling();

			sourceVerticesCheck.Checked = neighbourVerticesCheck.Checked;
			destinationVerticesCheck.Checked = neighbourVerticesCheck.Checked;

			ResumeEventsHandling();

			UpdateHighlights();
		}

		private void sourceVerticesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			UpdateHighlights();
		}

		private void destinationVerticesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			UpdateHighlights();
		}

		private void accessibleVerticesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			PauseEventsHandling();

			successorVerticesCheck.Checked = accessibleVerticesCheck.Checked;
			predecessorVerticesCheck.Checked = accessibleVerticesCheck.Checked;

			ResumeEventsHandling();

			UpdateHighlights();
		}

		private void predecessorVerticesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			UpdateHighlights();
		}

		private void successorVerticesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			UpdateHighlights();
		}

		private void fromVertexCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			UpdateHighlights();
		}

		private void toVertexCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			UpdateHighlights();
		}

		private void graphPartCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			NShape shape = (view.Selection.AnchorNode as NShape);
			if (shape == null)
				return;

			shape.GraphPart = graphPartCheck.Checked;
			if (shape.GraphPart == false)
			{
				shape.Text = "No";
			}
			else
			{
				shape.Text = "";
			}

			UpdateHighlights();
		}


		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;

		#endregion

		#region Fields

		private NColorFillStyle highlightFillStyle = null;
		private NStrokeStyle highlightStrokeStyle = null;
		
		private Nevron.UI.WinForm.Controls.NGroupBox vertexHighlightsGroup;
		private Nevron.UI.WinForm.Controls.NGroupBox edgeHighlightsGroup;
		private Nevron.UI.WinForm.Controls.NCheckBox incommingEdgesCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox outgoingEdgesCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox allEdgesCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox neighbourVerticesCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox sourceVerticesCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox destinationVerticesCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox accessibleVerticesCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox predecessorVerticesCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox successorVerticesCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox fromVertexCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox toVertexCheck;
		private System.Windows.Forms.CheckBox graphPartCheck;
		private NStrokeStyle selectedStrokeStyle = null;

		#endregion
	}
}