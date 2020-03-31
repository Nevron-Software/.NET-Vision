using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Nevron.Editors;
using Nevron.GraphicsCore;
using Nevron.Diagram;
using Nevron.Diagram.WinForm;
using Nevron.Examples.Framework.WinForm; 

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NArrowheadShapesStencilUC.
	/// </summary>
	public class NArrowheadShapesStencilUC : NDiagramExampleUC
	{
		#region Constructor

		public NArrowheadShapesStencilUC(NMainForm form) : base(form)
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
			this.commonControlsPanel.Name = "commonControlsPanel";
			this.commonControlsPanel.Size = new System.Drawing.Size(250, 80);
			// 
			// NArrowheadShapesStencilUC
			// 
			this.Name = "NArrowheadShapesStencilUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			this.DefaultGridCellSize = new NSizeF(50, 50);

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
			document.Style.StartArrowheadStyle.Shape = ArrowheadShape.None;
			document.Style.EndArrowheadStyle.Shape = ArrowheadShape.None;

            int row = 0;
			int col = 0;
			int maxColCount = 5;
			int index = 0;

			foreach (NArrowheadShape arrowheadShape in document.ArrowheadShapeStencil.PredefinedArrowheadShapes)
			{
				// create the path representing the arrow head shape
				NCustomPath path = new NCustomPath((GraphicsPath)arrowheadShape.Path.Clone(), arrowheadShape.Closed? PathType.ClosedFigure: PathType.OpenFigure);
				
				// create a shape to host the path
				NCompositeShape shape = new NCompositeShape();
				shape.Primitives.AddChild(path); 
				shape.UpdateModelBounds();
				
				// reposition the shape and add to active layer
				shape.Bounds = base.GetGridCell(row, col);
				document.ActiveLayer.AddChild(shape);

				// describe it
				string str = NExamplesHelper.InsertSpacesBeforeUppers(((ArrowheadShape)(index + 2)).ToString());
				NTextShape text = new NTextShape(str, base.GetGridCell(row + 1, col));
				document.ActiveLayer.AddChild(text);
				
				col++;
				index++;

				if (col > maxColCount)
				{
					row += 2;
					col = 0;
				}
			}
		}


		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;

		#endregion
	}
}