using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Nevron.Editors;
using Nevron.Filters;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Diagram;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NShapeOutwardPortsUC.
	/// </summary>
	public class NShapeOutwardPortsUC : NDiagramExampleUC
	{
		#region Constructor

		public NShapeOutwardPortsUC(NMainForm form) : base(form)
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
            // NShapeOutwardPortsUC
            // 
            this.Name = "NShapeOutwardPortsUC";
            this.Size = new System.Drawing.Size(250, 600);
            this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			base.DefaultGridOrigin = new NPointF(30, 30);
			base.DefaultGridCellSize = new NSizeF(70, 70);
			base.DefaultGridSpacing = new NSizeF(50, 10);

			// begin view init
			view.BeginInit();

			// init view
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
			// change the document style
			NStyle style = document.Style;
			style.FillStyle = new NColorFillStyle(Color.FromArgb(50, 0x66, 0x66, 0));
			style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(0x11, 0x11, 0));
			style.TextStyle.FontStyle = new NFontStyle(new Font("Arial", 9));
			style.TextStyle.FillStyle = new NColorFillStyle(Color.FromArgb(0x2a, 0x20, 0x00));
			style.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left;
			style.StartArrowheadStyle.StrokeStyle = document.Style.StrokeStyle.Clone() as NStrokeStyle;
			style.EndArrowheadStyle.StrokeStyle = document.Style.StrokeStyle.Clone() as NStrokeStyle;

			// create the shapes
			CreateMoveMeShape();
			CreateShapeWithAutoSideDirection();
			CreateShapeWithAutoCenterDirection();
			CreateShapeWithCustomDirection();
            CreateShapeWithAutoNextPort();
            CreateShapeWithAutoPrevPort();
            CreateShapeWithAutoLinePort();
		}

		private void CreateMoveMeShape()
		{
			// create the center shape to which all other shapes connect
			NRectangleF cell = base.GetGridCell(3, 0);
			cell.Inflate(-5, -5);

			NRectangleShape shape = new NRectangleShape(cell);
			shape.Name = "Move Me";
            shape.Text = "Move Me Close to Another Shape";
			
			shape.Style.FillStyle = new NColorFillStyle(Color.FromArgb(247, 150, 56));
			shape.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));

            // create an outward port
			shape.CreateShapeElements(ShapeElementsMask.Ports);
            NRotatedBoundsPort port = new NRotatedBoundsPort(shape.UniqueId, ContentAlignment.TopCenter);
            port.Type = PortType.Outward;  
			shape.Ports.AddChild(port);
			shape.Ports.DefaultOutwardPortUniqueId = port.UniqueId;

			// add it to the active layer and store for reuse
			document.ActiveLayer.AddChild(shape);
			centerShape = shape;
		}

		private void CreateShapeWithAutoSideDirection()
		{
            NRectangleShape shape = new NRectangleShape(base.GetGridCell(0, 1));
			shape.Name = "Port with Auto Side direction";
            shape.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133));
            shape.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));

            shape.CreateShapeElements(ShapeElementsMask.Ports);
            NRotatedBoundsPort port = new NRotatedBoundsPort(new NContentAlignment(50, 30));
            port.DirectionMode = BoundsPortDirectionMode.AutoSide;
            shape.Ports.AddChild(port);

            document.ActiveLayer.AddChild(shape);

			// describe it
            NTextShape text = new NTextShape("Port with Auto Side direction", base.GetGridCell(0, 2, 0, 1));
			document.ActiveLayer.AddChild(text);
		}

		private void CreateShapeWithAutoCenterDirection()
		{
            NRectangleShape shape = new NRectangleShape(base.GetGridCell(1, 1));
            shape.Name = "Port with Auto Center direction";
            shape.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133));
            shape.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));

            shape.CreateShapeElements(ShapeElementsMask.Ports);
            NRotatedBoundsPort port = new NRotatedBoundsPort(new NContentAlignment(50, 30));
            port.DirectionMode = BoundsPortDirectionMode.AutoCenter;
            shape.Ports.AddChild(port);

            document.ActiveLayer.AddChild(shape);

            // describe it
            NTextShape text = new NTextShape("Port with Auto Center direction", base.GetGridCell(1, 2, 0, 1));
            document.ActiveLayer.AddChild(text);
		}

		private void CreateShapeWithCustomDirection()
		{
            NRectangleShape shape = new NRectangleShape(base.GetGridCell(2, 1));
            shape.Name = "Port with Custom direction";
            shape.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133));
            shape.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));

            shape.CreateShapeElements(ShapeElementsMask.Ports);
            NRotatedBoundsPort port = new NRotatedBoundsPort(new NContentAlignment(50, 30));
            port.DirectionMode = BoundsPortDirectionMode.Custom;
            port.CustomDirectionAngle = -30;
            shape.Ports.AddChild(port);

            document.ActiveLayer.AddChild(shape);

            // describe it
            NTextShape text = new NTextShape("Port with Custom direction", base.GetGridCell(2, 2, 0, 1));
            document.ActiveLayer.AddChild(text);
		}

		private void CreateShapeWithAutoNextPort()
		{
			NBasicShapesFactory factory = new NBasicShapesFactory(document);
			NShape shape = factory.CreateShape((int)BasicShapes.Triangle);
            shape.Name = "Point Port with AutoNext direction";
            shape.Bounds = base.GetGridCell(3, 1);
            shape.Style.FillStyle = new NGradientFillStyle(GradientStyle.DiagonalUp, GradientVariant.Variant4, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133));
            shape.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
			
			NPointPort port = new NPointPort(shape.UniqueId, PointIndexMode.Second, -1);
            port.DirectionMode = PointPortDirectionMode.AutoNext; 
            shape.Ports.RemoveAllChildren();
			shape.Ports.AddChild(port);
			
			document.ActiveLayer.AddChild(shape);

			// describe it
            NTextShape text = new NTextShape("Point Port with AutoNext direction", base.GetGridCell(3, 2, 0, 1));
			document.ActiveLayer.AddChild(text);
		}

        private void CreateShapeWithAutoPrevPort()
        {
            NBasicShapesFactory factory = new NBasicShapesFactory(document);
            NShape shape = factory.CreateShape((int)BasicShapes.Triangle);
            shape.Name = "Point Port with AutoPrev direction";
            shape.Bounds = base.GetGridCell(4, 1);
            shape.Style.FillStyle = new NGradientFillStyle(GradientStyle.DiagonalUp, GradientVariant.Variant4, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133));
            shape.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));

            NPointPort port = new NPointPort(shape.UniqueId, PointIndexMode.Second, -1);
            port.DirectionMode = PointPortDirectionMode.AutoPrev;
            shape.Ports.RemoveAllChildren();
            shape.Ports.AddChild(port);

            document.ActiveLayer.AddChild(shape);

            // describe it
            NTextShape text = new NTextShape("Point Port with AutoPrev direction", base.GetGridCell(4, 2, 0, 1));
            document.ActiveLayer.AddChild(text);
        }

		private void CreateShapeWithAutoLinePort()
		{
            NBezierCurveShape shape = new NBezierCurveShape(new NPointF(0, 0), new NPointF(1, 0), new NPointF(1, 2), new NPointF(2, 2));
            shape.Name = "Line Port with AutoLine direction";
            shape.Bounds = base.GetGridCell(5, 1);
            shape.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));

            shape.CreateShapeElements(ShapeElementsMask.Ports);
            NLogicalLinePort port = new NLogicalLinePort(shape.UniqueId, 50);
            port.DirectionMode = LogicalLinePortDirectionMode.AutoLine;
            shape.Ports.AddChild(port);

            document.ActiveLayer.AddChild(shape);

            // describe it
            NTextShape text = new NTextShape("Line Port with AutoLine direction", base.GetGridCell(5, 2, 0, 1));
            document.ActiveLayer.AddChild(text);
		}

	    #endregion

		#region Designer Fields

        private System.ComponentModel.Container components = null;

		#endregion
		
		#region Fields

		private NShape centerShape = null;

		#endregion
	}
}