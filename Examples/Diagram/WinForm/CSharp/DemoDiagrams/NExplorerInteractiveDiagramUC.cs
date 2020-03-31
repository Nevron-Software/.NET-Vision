using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Nevron.GraphicsCore;
using Nevron.Dom;
using Nevron.Editors;
using Nevron.Diagram;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.Layout;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// The NExpandCollapseCheck class is a composite shape which displays a framed plus or minus sign
	/// </summary>
	public class NExpandCollapseCheck : NCompositeShape
	{
		public NExpandCollapseCheck()
		{
			// base
			Primitives.AddChild(new NRectanglePath(-1, -1, 2, 2));

			// plus
			GraphicsPath path = new GraphicsPath();
			path.AddLine(new PointF(-1, 0), new PointF(1, 0));
			path.StartFigure();
			path.AddLine(new PointF(0, 1), new PointF(0, -1));
			Primitives.AddChild(new NCustomPath(path, PathType.OpenFigure));

			// minus
			Primitives.AddChild(new NLinePath(-1, 0, 1, 0));

			// update the model bounds to fit the primitives
			UpdateModelBounds();

			// destory all optional shape elements
			DestroyShapeElements(ShapeElementsMask.All);

			// add tooltip
			Style.InteractivityStyle = new NInteractivityStyle("Click to expand/collapse subtree", CursorType.Hand);
		}
	}
	/// <summary>
	/// The NExpandableShape class is a group, which contains a frame rectangle shape and an expand-collapse check shape
	/// </summary>
	public class NExpandableShape : NGroup
	{
		public NExpandableShape()
		{
			// add a rectangle shape as base
			NRectangleShape rect = new NRectangleShape(new NRectangleF(0, 0, 100, 100));
			rect.DestroyShapeElements(ShapeElementsMask.All);
			rect.Protection = new NAbilities(AbilitiesMask.Select | AbilitiesMask.InplaceEdit);
			Shapes.AddChild(rect);

			// add an expand collapse shape
			NExpandCollapseCheck check = new NExpandCollapseCheck();
			check.Bounds = new NRectangleF(105, 0, 10, 10);
			check.Protection = new NAbilities(AbilitiesMask.Select | AbilitiesMask.InplaceEdit);
			check.ResizeInAggregate = ResizeInAggregate.RepositionOnly;
			Shapes.AddChild(check);

			// update the model bounds with the rectangle bounds
			UpdateModelBounds(rect.Transform.TransformBounds(rect.ModelBounds));

			// initially it is expanded
			m_bExpanded = true;

			// by default the group has one dynamic port anchored to the rectangle
			CreateShapeElements(ShapeElementsMask.Ports);
			NDynamicPort port = new NDynamicPort(rect.UniqueId, ContentAlignment.MiddleCenter, DynamicPortGlueMode.GlueToContour);

			Ports.AddChild(port);  
			Ports.DefaultInwardPortUniqueId = port.UniqueId;

			// by default the group has one rotated bounds port anchored to the rectangle
			CreateShapeElements(ShapeElementsMask.Labels);
			NRotatedBoundsLabel label = new NRotatedBoundsLabel("", rect.UniqueId, new Nevron.Diagram.NMargins(10));

			Labels.AddChild(label);
			Labels.DefaultLabelUniqueId = label.UniqueId;
		}

		#region Overrides

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		public override void OnMouseDown(NMouseEventArgs e)
		{
			// handle only the left mouse down single click on the check box
			if (e.Button == MouseButtons.Left || e.Clicks == 1)
			{
				NExpandCollapseCheck check = GetExpandCollapseCheck();

				// check to see if the hit was on some of the check box children
				if (NSceneTree.IsAncestorOfNode(check, e.HitNode))
				{
					Expand(!Expanded);
					
					// mark as processed and return (stops event bubbling)
					e.Processed = true;
					return;
				}
			}

			// bubble event to previous mouse event handler
			base.OnMouseDown(e);
		}


		#endregion

		#region Properties

		/// <summary>
		/// 
		/// </summary>
		public bool Expanded
		{
			get
			{
				return m_bExpanded;
			}
			set
			{
				if (m_bExpanded == value)
					return;

				if (OnPropertyChanging("Expanded", value) == false)
					return;

				RecordProperty("Expanded");
				m_bExpanded = value;
                
				OnPropertyChanged("Expanded");
			}
		}


		#endregion

		#region Methods

		/// <summary>
		/// 
		/// </summary>
		/// <param name="expandState"></param>
		public void Expand(bool expandState)
		{
			// expand or collapse in a single transation
			StartTransaction(expandState? "Expand Tree": "Collapse Tree");

			// mark shape as expanded
			Expanded = expandState;

			// show/hide the plus or minus 
			NExpandCollapseCheck check = GetExpandCollapseCheck();
			((NPathPrimitive)check.Primitives.GetChildAt(1)).Visible = !expandState;
			((NPathPrimitive)check.Primitives.GetChildAt(2)).Visible = expandState;

			// show/hide all outgoing shapes
			NNodeList nodes = GetOutgoingShapes();
			for (int i = 0; i < nodes.Count; i++)
			{
				NShape shape = (nodes[i] as NShape);
				shape.Visible = expandState;
			}

			// show/hide all destination shapes
			nodes = GetDestinationShapes();
			for (int i = 0; i < nodes.Count; i++)
			{
				NShape shape = (nodes[i] as NShape);
				shape.Visible = expandState;
			}

			// expand/collapse the destination shapes
			for (int i = 0; i < nodes.Count; i++)
			{
				NExpandableShape expandableShape = (nodes[i] as NExpandableShape);
				if (expandableShape != null)
					expandableShape.Expand(expandState);
			}
			
			// commit the transaction
			Commit();
		}


		#endregion

		#region Protected

		/// <summary>
		/// Gets the expand/collapse check from the geometry
		/// </summary>
		/// <returns></returns>
		protected NExpandCollapseCheck GetExpandCollapseCheck()
		{
			return (Shapes.GetChildAt(1) as NExpandCollapseCheck);
		}


		#endregion

		#region Fields

		private bool m_bExpanded;

		#endregion
	}
	/// <summary>
	/// Summary description for NExplorerInteractiveDiagramUC.
	/// </summary>
	public class NExplorerInteractiveDiagramUC : NDiagramExampleUC
	{
		#region Constructor

		public NExplorerInteractiveDiagramUC(NMainForm form) : base(form)
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
			this.SuspendLayout();
			// 
			// commonControlsPanel
			// 
			this.commonControlsPanel.Location = new System.Drawing.Point(0, 304);
			this.commonControlsPanel.Name = "commonControlsPanel";
			this.commonControlsPanel.Size = new System.Drawing.Size(248, 80);
			// 
			// NExplorerInteractiveDiagramUC
			// 
			this.Name = "NExplorerInteractiveDiagramUC";
			this.Size = new System.Drawing.Size(248, 384);
			this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// begin view init
			view.BeginInit();

			view.GlobalVisibility.ShowPorts = false;
			view.Grid.Visible = false;
            view.HorizontalRuler.Visible = false;
            view.VerticalRuler.Visible = false;

			// init document
			document.BeginInit();
			InitDocument();
			document.EndInit();

			// fit document in designer
			view.DocumentPadding = new Nevron.Diagram.NMargins(10);
			view.Fit();

			// end view init
			view.EndInit();
		}


		#endregion

		#region Implementation

		private void InitDocument()
		{
			// all shapes will have shadow dropped below document content
			document.Style.ShadowStyle.Type = ShadowType.GaussianBlur;
			document.Style.ShadowStyle.Offset = new NPointL(5, 5);
			document.Style.ShadowStyle.FadeLength = new NLength(5);
			document.ShadowsZOrder = ShadowsZOrder.BehindDocument;

			// root 
			NExpandableShape company = CreateVertex("The Company");

			// products branch
			NExpandableShape products = CreateVertex("Products and Services");
			ConnectShapes(company, products);

			NExpandableShape product1 = this.CreateVertex("Product1");
			ConnectShapes(products, product1);

			NExpandableShape product2 = this.CreateVertex("Product2");
			ConnectShapes(products, product2);

			// how to reach
			NExpandableShape reach = CreateVertex("How to reach");
			ConnectShapes(company, reach);

			NExpandableShape phone = this.CreateVertex("Phone");
			ConnectShapes(reach, phone);

			NExpandableShape fax = this.CreateVertex("Fax");
			ConnectShapes(reach, fax);

			NExpandableShape website = this.CreateVertex("Website");
			ConnectShapes(reach, website);

			// research
			NExpandableShape research = CreateVertex("Research");
			ConnectShapes(company, research);

			NExpandableShape tech = this.CreateVertex("Techinical");
			ConnectShapes(research, tech);

			NExpandableShape marketing = this.CreateVertex("Marketing");
			ConnectShapes(research, marketing);

			NExpandableShape newTech = this.CreateVertex("New Tech");
			ConnectShapes(research, newTech);

			NNodeList nodes = new NNodeList();
			nodes.Add(company);

            // create a layout context
            NLayoutContext layoutContext = new NLayoutContext();
            layoutContext.BodyAdapter = new NShapeBodyAdapter(document);
            layoutContext.BodyContainerAdapter = new NDrawingBodyContainerAdapter(document);
            layoutContext.GraphAdapter = new NShapeGraphAdapter();

			// first apply a layered tree layout 
            // to set a start position of the shapes as a simple tree
			NTreeLayout treeLayout = new NLayeredTreeLayout();
            treeLayout.Layout(nodes, layoutContext);

            // then apply a symmetrical layout to layout them in a ring fasion
            NSymmetricalLayout symmetricalLayout = new NSymmetricalLayout();
            symmetricalLayout.DesiredDistanceForce.DesiredDistance = 100;
            symmetricalLayout.Layout(nodes, layoutContext);

			// size the document to the content (note that we use irregular margins)
			document.SizeToContent(new NSizeF(100, 100), new Nevron.Diagram.NMargins(20, 20, 50, 20));

			// add title spanning the entire document width
			NTextShape text = new NTextShape("Company Structure", new NRectangleF(document.Bounds.X + 5, document.Bounds.Y + 5, document.Width - 10, 50));
			text.Style.TextStyle = new NTextStyle(new Font("Times New Roman", 23, FontStyle.Bold));
			document.ActiveLayer.AddChild(text);
		}

		protected NExpandableShape CreateVertex(string text)
		{
			NExpandableShape vertex = new NExpandableShape();
			vertex.Width = 75;
			vertex.Height = 75;
			vertex.Text = text;
			document.ActiveLayer.AddChild(vertex);
			return vertex;
		}

		private void ConnectShapes(NExpandableShape fromShape, NExpandableShape toShape)
		{
			NLineShape connector = new NLineShape();
			connector.StyleSheetName = NDR.NameConnectorsStyleSheet;
			
			document.ActiveLayer.AddChild(connector);
			connector.FromShape = fromShape; 
			connector.ToShape = toShape;
		}


		#endregion

		#region Designer Fields
		
		private System.ComponentModel.Container components = null;

		#endregion
	}
}