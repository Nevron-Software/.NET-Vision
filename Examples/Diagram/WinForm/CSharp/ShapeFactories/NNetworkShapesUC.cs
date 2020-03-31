using System.Drawing;

using Nevron.Diagram;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.Dom;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NNetworkShapesUC.
	/// </summary>
	public class NNetworkShapesUC : NDiagramExampleUC
	{
		#region Constructor

		public NNetworkShapesUC(NMainForm form) : base(form)
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
			// 
			// NNetworkShapesUC
			// 
			this.Name = "NNetworkShapesUC";
			this.Size = new System.Drawing.Size(248, 160);

		}

		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// begin view init
			view.BeginInit();
			view.Grid.Visible = false;
			view.GlobalVisibility.ShowPorts = false;

			// init document
			document.BeginInit();
			InitDocument();
			document.EndInit();

			// end view init
			view.EndInit();
		}

		#endregion

		#region Implementation

		private void InitDocument()
		{
			document.Style.TextStyle.FontStyle.InitFromFont(new Font("Arial Narrow", 8));

			NNetworkShapesFactory factory = new NNetworkShapesFactory(document);
			factory.DefaultSize = new NSizeF(80, 60);
			
			int count = factory.ShapesCount;
			for (int i = 0; i < count; i++)
			{
				// create a shape
				NShape shape = factory.CreateShape(i); 
				shape.Style.InteractivityStyle = new NInteractivityStyle(shape.Name);

				// add it to the active layer
				document.ActiveLayer.AddChild(shape);
			}
            
            // layout the shapes in the active layer using a table layout
            NTableLayout layout = new NTableLayout();

            // setup the table layout
            layout.Direction = LayoutDirection.LeftToRight;
            layout.ConstrainMode = CellConstrainMode.Ordinal;
            layout.MaxOrdinal = 5;
            layout.HorizontalContentPlacement = ContentPlacement.Center;
            layout.VerticalContentPlacement = ContentPlacement.Center;
            layout.VerticalSpacing = 20;
            layout.HorizontalSpacing = 20;

            // get the shapes to layout
            NNodeList shapes = document.ActiveLayer.Children(NFilters.Shape2D);

            // create a layout context
            NLayoutContext layoutContext = new NLayoutContext();
            layoutContext.GraphAdapter = new NShapeGraphAdapter();
            layoutContext.BodyAdapter = new NShapeBodyAdapter(document);
            layoutContext.BodyContainerAdapter = new NDrawingBodyContainerAdapter(document);

            // layout the shapes
            layout.Layout(shapes, layoutContext);

			// resize document to fit all shapes
			document.SizeToContent();
		}

		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;

		#endregion
	}
}
