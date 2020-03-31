using System.Drawing;

using Nevron.Diagram;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.Dom;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NBasicShapesUC.
	/// </summary>
	public class NBasicShapesUC : NDiagramExampleUC
	{
		#region Constructor

		public NBasicShapesUC(NMainForm form) : base(form)
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
			// NBasicShapesUC
			// 
			this.Name = "NBasicShapesUC";
			this.Size = new System.Drawing.Size(248, 160);

		}

		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// begin view init
			view.BeginInit();
			view.Grid.Visible = false;

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

			NBasicShapesFactory factory = new NBasicShapesFactory(document);
			factory.DefaultSize = new NSizeF(80, 60);
			
			int count = factory.ShapesCount;
			NShape shape = null;
			for (int i = 0; i < count; i++)
			{
				// create a basic shape
				shape = factory.CreateShape(i); 
				shape.Text = shape.Name;

				// add it to the active layer
				document.ActiveLayer.AddChild(shape);
			}

			// Add some content to the table shape
			NTableShape table = (NTableShape)shape;
			table.InitTable(2, 2);
			table.BeginUpdate();
			table.CellMargins = new Nevron.Diagram.NMargins(8);
			table[0, 0].Text = "Cell 1";
			table[1, 0].Text = "Cell 2";
			table[0, 1].Text = "Cell 3";
			table[1, 1].Text = "Cell 4";
			table.PortDistributionMode = TablePortDistributionMode.CellBased;
			table.EndUpdate();

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

            // layout the shapes
            layout.Layout(shapes, new NDrawingLayoutContext(document));

			// resize document to fit all shapes
			document.SizeToContent();
		}

		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;

		#endregion
	}
}
