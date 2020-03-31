using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Nevron.Dom;
using Nevron.UI.WebForm.Controls;
using Nevron.GraphicsCore;
using Nevron.Diagram;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.WebForm;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///	Summary description for NExplorerInteractiveDiagramUC.
	/// </summary>
	public partial class NExplorerInteractiveDiagramUC : NDiagramExampleUC
	{
		/// <summary>
		/// The NExpandCollapseCheck class is a composite shape which displays a framed plus or minus sign
		/// </summary>
		[Serializable]
		public class NExpandCollapseCheck : NCompositeShape
		{
			#region Constructors

			public NExpandCollapseCheck()
			{
				// base
				Primitives.AddChild(new NRectanglePath(-1, -1, 2, 2));

				// plus
				GraphicsPath path = new GraphicsPath();
				path.AddLine(new PointF(-0.5f, 0), new PointF(0.5f, 0));
				path.StartFigure();
				path.AddLine(new PointF(0, 0.5f), new PointF(0, -0.5f));

                NCustomPath customPath = new NCustomPath(path, PathType.OpenFigure);
                customPath.Visible = false;

                Primitives.AddChild(customPath);

				// minus
				NLinePath linePath = new NLinePath(-0.5f, 0, 0.5f, 0);

				Primitives.AddChild(linePath);

				// update the model bounds to fit the primitives
				UpdateModelBounds();

				// destory all optional shape elements
				DestroyShapeElements(ShapeElementsMask.All);

				// add interactivity
				Style.InteractivityStyle = new NInteractivityStyle(true, string.Empty, "Click to expand/collapse subtree", CursorType.Hand);
				linePath.Style = linePath.ComposeStyle();
				linePath.Style.InteractivityStyle = new NInteractivityStyle(true, string.Empty, "Click to expand/collapse subtree", CursorType.Hand);
				customPath.Style = customPath.ComposeStyle();
				customPath.Style.InteractivityStyle = new NInteractivityStyle(true, string.Empty, "Click to expand/collapse subtree", CursorType.Hand);
			}

			#endregion
		}

		/// <summary>
		/// The NExpandableShape class is a group, which contains a frame rectangle shape and an expand-collapse check shape
		/// </summary>
		[Serializable]
		public class NExpandableShape : NGroup
		{
			#region Constructors

			public NExpandableShape()
			{
				// add a rectangle shape as base
				NRectangleShape rect = new NRectangleShape(new NRectangleF(0, 0, 75, 75));
				rect.DestroyShapeElements(ShapeElementsMask.All);
				rect.Protection = new NAbilities(AbilitiesMask.Select | AbilitiesMask.InplaceEdit);
				Shapes.AddChild(rect);

				// add an expand collapse shape
				NExpandCollapseCheck check = new NExpandCollapseCheck();
				check.Bounds = new NRectangleF(80, 0, 12, 12);
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
            /// <param name="expandShape"></param>
			public void Expand(bool expandShape)
			{
				// expand or collapse in a single transation
                StartTransaction(expandShape ? "Expand Tree" : "Collapse Tree");

				// mark shape as expanded
                Expanded = expandShape;

				// show/hide the plus or minus 
				NExpandCollapseCheck check = GetExpandCollapseCheck();

                NPathPrimitive pathPrimitive;
                pathPrimitive = check.Primitives.GetChildAt(1) as NPathPrimitive;
                pathPrimitive.Visible = !expandShape;

                pathPrimitive = check.Primitives.GetChildAt(2) as NPathPrimitive;
                pathPrimitive.Visible = expandShape;

				// show/hide all outgoing shapes
				NNodeList nodes = GetOutgoingShapes();
				for (int i = 0; i < nodes.Count; i++)
				{
					NShape shape = (nodes[i] as NShape);
                    shape.Visible = expandShape;
				}

				// show/hide all destination shapes
				nodes = GetDestinationShapes();
				for (int i = 0; i < nodes.Count; i++)
				{
					NShape shape = (nodes[i] as NShape);
                    shape.Visible = expandShape;
				}

				// expand/collapse the destination shapes
				for (int i = 0; i < nodes.Count; i++)
				{
					NExpandableShape expandableShape = (nodes[i] as NExpandableShape);
					if (expandableShape != null)
                        expandableShape.Expand(expandShape);
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
			public NExpandCollapseCheck GetExpandCollapseCheck()
			{
				return (Shapes.GetChildAt(1) as NExpandCollapseCheck);
			}

			#endregion

			#region Fields

			private bool m_bExpanded;

			#endregion
		}


		protected void Page_Load(object sender, System.EventArgs e)
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
					NDrawingView1.Document.BeginInit();
					InitDocument();
					NDrawingView1.Document.EndInit();
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
			NNodeList shapes = nodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D);
			NExpandCollapseCheck check = null;
			int length = shapes.Count;
			for (int i = 0; i < length; i++)
			{
				if (shapes[i] is NExpandCollapseCheck)
				{
					check = shapes[i] as NExpandCollapseCheck;
					break;
				}
			}
			if (check == null)
			{
				return;
			}

			NExpandableShape shape = check.ParentNode.ParentNode as NExpandableShape;
			shape.Expand(!shape.Expanded);
		}

		#region Implementation

		protected void InitDocument()
		{
			NDrawingView1.Document.GraphicsSettings.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			NDrawingView1.Document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
			NDrawingView1.Document.GraphicsSettings.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

			// set up visual formatting
			NDrawingView1.Document.Style.FillStyle = new NColorFillStyle(Color.Linen);

			NDrawingView1.Document.BackgroundStyle.FrameStyle.Visible = false;
			
			// all shapes will have shadow dropped below document content
			NDrawingView1.Document.Style.ShadowStyle.Type = ShadowType.GaussianBlur;
			NDrawingView1.Document.Style.ShadowStyle.Offset = new NPointL(5, 5);
			NDrawingView1.Document.Style.ShadowStyle.FadeLength = new NLength(5);
			NDrawingView1.Document.ShadowsZOrder = ShadowsZOrder.BehindDocument;

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
			layoutContext.BodyAdapter = new NShapeBodyAdapter(NDrawingView1.Document);
			layoutContext.BodyContainerAdapter = new NDrawingBodyContainerAdapter(NDrawingView1.Document);
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
			NDrawingView1.Document.SizeToContent(new NSizeF(100, 100), new Nevron.Diagram.NMargins(20, 20, 100, 20));

			// add title spanning the entire document width
			NTextShape text = new NTextShape("Company Structure", new NRectangleF(5, -50, NDrawingView1.Document.Width - 5, 50));
			text.Style.TextStyle = new NTextStyle(new Font("Times New Roman", 23, FontStyle.Bold));
			text.Style.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Center;
			NDrawingView1.Document.ActiveLayer.AddChild(text);
		}

		protected NExpandableShape CreateVertex(string text)
		{
			NExpandableShape vertex = new NExpandableShape();
			vertex.Text = text;
			NDrawingView1.Document.ActiveLayer.AddChild(vertex);
			return vertex;
		}

		protected void ConnectShapes(NExpandableShape fromShape, NExpandableShape toShape)
		{
			NLineShape connector = new NLineShape();
			connector.StyleSheetName = NDR.NameConnectorsStyleSheet;
			
			NDrawingView1.Document.ActiveLayer.AddChild(connector);
			connector.FromShape = fromShape; 
			connector.ToShape = toShape;
		}

		#endregion
	}
}
