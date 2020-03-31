using System;
using System.Drawing;
using Nevron.Diagram;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.ThinWeb;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///	Summary description for NThinWebGeneral.
	/// </summary>
	public partial class NServerSideEventsToolUC : NDiagramExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// begin view init
			base.DefaultGridOrigin = new NPointF(30, 30);
			base.DefaultGridCellSize = new NSizeF(100, 50);
			base.DefaultGridSpacing = new NSizeF(50, 40);

            NServerMouseEventTool serverMouseEventTool;

            if (!NThinDiagramControl1.Initialized)
            {
                // begin view init
                NDrawingDocument document = NThinDiagramControl1.Document;

                // init NThinDiagramControl1.Document.
                document.BeginInit();
                InitDocument(document);
                document.EndInit();

                NThinDiagramControl1.View.Layout = CanvasLayout.Fit;
                NThinDiagramControl1.Toolbar.Visible = true;
                NThinDiagramControl1.Toolbar.Items.Add(new NToolbarButton(new NZoomInAction()));
                NThinDiagramControl1.Toolbar.Items.Add(new NToolbarButton(new NZoomOutAction()));

                // configure the controller
                serverMouseEventTool = new NServerMouseEventTool();
                NThinDiagramControl1.Controller.Tools.Add(serverMouseEventTool);
            }
            else
            {
                serverMouseEventTool = NThinDiagramControl1.Controller.Tools[0] as NServerMouseEventTool;
            }

            // subscribe / unsubscribe to mouse down
            if (MouseDownCheckBox.Checked)
            {
                serverMouseEventTool.MouseDown = new NMouseEventCallback();
            }
            else
            {
                serverMouseEventTool.MouseDown = null;
            }

            // subscribe / unsubscribe to mouse move
            if (MouseMoveCheckBox.Checked)
            {
                serverMouseEventTool.MouseMove = new NMouseEventCallback();
            }
            else
            {
                serverMouseEventTool.MouseMove = null;
            }

            // subscribe / unsubscribe to mouse up
            if (MouseUpCheckBox.Checked)
            {
                serverMouseEventTool.MouseUp = new NMouseEventCallback();
            }
            else
            {
                serverMouseEventTool.MouseUp = null;
            }

            /// // subscribe / unsubscribe to mouse hover
            if (MouseOverCheckBox.Checked)
            {
                serverMouseEventTool.MouseOver = new NMouseEventCallback();
            }
            else
            {
                serverMouseEventTool.MouseOver = null;
            }

            // subscribe / unsubscribe to mouse leave
            if (MouseLeaveCheckBox.Checked)
            {
                serverMouseEventTool.MouseLeave = new NMouseEventCallback();
            }
            else
            {
                serverMouseEventTool.MouseLeave = null;
            }

            // subscribe / unsubscribe to mouse enter
            if (MouseEnterCheckBox.Checked)
            {
                serverMouseEventTool.MouseEnter = new NMouseEventCallback();
            }
            else
            {
                serverMouseEventTool.MouseEnter = null;
            }

			// subscribe / unsubscribe to mouse click
			if (MouseClickCheckBox.Checked)
			{
				serverMouseEventTool.MouseClick = new NMouseEventCallback();
			}
			else
			{
				serverMouseEventTool.MouseClick = null;
			}

			// subscribe / unsubscribe to mouse click
			if (MouseDoubleClickCheckBox.Checked)
			{
				serverMouseEventTool.MouseDoubleClick = new NMouseEventCallback();
			}
			else
			{
				serverMouseEventTool.MouseDoubleClick = null;
			}

		}

        [Serializable]
        class NMouseEventCallback : INMouseEventCallback
        {
			#region INMouseEventCallback Members

			void INMouseEventCallback.OnMouseEvent(NAspNetThinWebControl control, NBrowserMouseEventArgs e)
			{
				NThinDiagramControl diagramControl = (NThinDiagramControl)control;
				NNodeList allShapes = diagramControl.Document.ActiveLayer.Children(Nevron.Diagram.Filters.NFilters.Shape2D);

				NNodeList affectedNodes = diagramControl.HitTest(new NPointF(e.X, e.Y));
				NNodeList affectedShapes = affectedNodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D);

				int length;
				bool fillChanged = false;

				length = allShapes.Count;
				for (int i = 0; i < length; i++)
				{
					NShape shape = allShapes[i] as NShape;
					shape.Style.ShadowStyle = null;
					if (shape.Tag != null)
					{
						NColorFillStyle newFill = new NColorFillStyle((Color)shape.Tag);
						fillChanged = fillChanged || !shape.Style.FillStyle.Equals(newFill);
						shape.Style.FillStyle = newFill;
					}
				}

				length = affectedShapes.Count;
				for (int i = 0; i < length; i++)
				{
					NShape shape = affectedShapes[i] as NShape;
					shape.Style.ShadowStyle = new NShadowStyle(ShadowType.GaussianBlur, Color.FromArgb(96, Color.Black), new NPointL(3, 3), 1, new NLength(10));

					NColorFillStyle fs = shape.Style.FillStyle as NColorFillStyle;
					if (fs != null && fs.Color != Color.White)
					{
						shape.Tag = fs.Color;
						NColorFillStyle newFill = new NColorFillStyle(Color.YellowGreen);
						fillChanged = fillChanged || !shape.Style.FillStyle.Equals(newFill);

						shape.Style.FillStyle = newFill;
					}
				}

				if (fillChanged)
				{
					diagramControl.UpdateView();
				}
				else
				{
					diagramControl.ClearResponse();
				}
			}

			#endregion
		}

        #region Implementation

        protected void InitDocument(NDrawingDocument document)
        {
            document.BackgroundStyle.FrameStyle.Visible = false;
            document.AutoBoundsPadding = new Nevron.Diagram.NMargins(10f, 10f, 10f, 10f);
            document.Style.FillStyle = new NColorFillStyle(Color.White);

            NBasicShapesFactory factory = new NBasicShapesFactory(document);

            NShape outerCircle = factory.CreateShape(BasicShapes.Circle);
            outerCircle.Bounds = new NRectangleF(0f, 0f, 200f, 200f);
            document.ActiveLayer.AddChild(outerCircle);

            NShape rect = factory.CreateShape(BasicShapes.Rectangle);
            rect.Bounds = new NRectangleF(42f, 42f, 50f, 50f);
            rect.Style.FillStyle = new NColorFillStyle(Color.Orange);
            document.ActiveLayer.AddChild(rect);

            NShape triangle = factory.CreateShape(BasicShapes.Triangle);
            triangle.Bounds = new NRectangleF(121f, 57f, 60f, 55f);
            triangle.Style.FillStyle = new NColorFillStyle(Color.LightGray);
            document.ActiveLayer.AddChild(triangle);

            NShape pentagon = factory.CreateShape(BasicShapes.Pentagon);
            pentagon.Bounds = new NRectangleF(60f, 120f, 54f, 50f);
            pentagon.Style.FillStyle = new NColorFillStyle(Color.WhiteSmoke);
            document.ActiveLayer.AddChild(pentagon);

            document.SizeToContent();
        }

        #endregion
	}
}