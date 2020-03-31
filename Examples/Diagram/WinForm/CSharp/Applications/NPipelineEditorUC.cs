using System;
using System.Drawing;
using System.Windows.Forms;

using Nevron.Diagram;
using Nevron.Diagram.WinForm;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.WinForm
{
    public class NPipelineEditorUC : NDiagramExampleUC
    {
        #region Constructors

        public NPipelineEditorUC(NMainForm form)
            : base(form)
        {
        }

        #endregion

        #region NDiagramExampleUC Overrides

        protected override void LoadExample()
        {
            // Init view and document
            view.BeginInit();
            view.HorizontalRuler.Visible = false;
            view.VerticalRuler.Visible = false;
            view.EndInit();

            // Init controls
            NLibraryView libView = CreateLibrary();
            libView.SetBounds(0, 0, this.Width, this.commonControlsPanel.Top);
            libView.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Controls.Add(libView);
        }
        protected override void AttachToEvents()
        {
            base.AttachToEvents();

            document.EventSinkService.Connecting += OnNodesConnecting;
        }
        protected override void DetachFromEvents()
        {
            base.DetachFromEvents();

            document.EventSinkService.Connecting -= OnNodesConnecting;
        }

        #endregion

        #region Implementation - Masters

        private void SetProtections(NShape shape)
        {
            NAbilities protection = shape.Protection;
            protection.ResizeX = true;
            protection.ResizeY = true;
            protection.Rotate = true;
            protection.InplaceEdit = true;
            protection.TrackersEdit = true;
            shape.Protection = protection;
        }
        private NCompositeShape CreateHorizontalPipe()
        {
            NDynamicPort port;
            NCompositeShape shape = new NCompositeShape();
            NRectanglePath rect = new NRectanglePath(0, SIZE, 3 * SIZE, SIZE);
            NStyle.SetStrokeStyle(rect, new NStrokeStyle(0, Color.White));

            shape.Primitives.AddChild(rect);
            shape.Primitives.AddChild(new NLinePath(0, SIZE, 3 * SIZE, SIZE));
            shape.Primitives.AddChild(new NLinePath(0, 2 * SIZE, 3 * SIZE, 2 * SIZE));
            shape.UpdateModelBounds();

            if (shape.Ports == null)
                shape.CreateShapeElements(ShapeElementsMask.Ports);

            port = new NDynamicPort(shape.UniqueId, LEFT, DynamicPortGlueMode.GlueToContour);
            port.Type = PortType.InwardAndOutward;
            shape.Ports.AddChild(port);

            port = new NDynamicPort(shape.UniqueId, RIGHT, DynamicPortGlueMode.GlueToContour);
            port.Type = PortType.InwardAndOutward;
            shape.Ports.AddChild(port);

            SetProtections(shape);
            return shape;
        }
        private NCompositeShape CreateVerticalPipe()
        {
            NDynamicPort port;
            NCompositeShape shape = new NCompositeShape();
            NRectanglePath rect = new NRectanglePath(SIZE, 0, SIZE, 3 * SIZE);
            NStyle.SetStrokeStyle(rect, new NStrokeStyle(0, Color.White));

            shape.Primitives.AddChild(rect);
            shape.Primitives.AddChild(new NLinePath(SIZE, 0, SIZE, 3 * SIZE));
            shape.Primitives.AddChild(new NLinePath(2 * SIZE, 0, 2 * SIZE, 3 * SIZE));
            shape.UpdateModelBounds();

            if (shape.Ports == null)
                shape.CreateShapeElements(ShapeElementsMask.Ports);

            port = new NDynamicPort(shape.UniqueId, TOP, DynamicPortGlueMode.GlueToContour);
            port.Type = PortType.InwardAndOutward;
            shape.Ports.AddChild(port);

            port = new NDynamicPort(shape.UniqueId, BOTTOM, DynamicPortGlueMode.GlueToContour);
            port.Type = PortType.InwardAndOutward;
            shape.Ports.AddChild(port);

            SetProtections(shape);
            return shape;
        }
        private NCompositeShape CreateCrossPipe()
        {
            NDynamicPort port;
            NCompositeShape shape = new NCompositeShape();
            NPolygonPath polygon = new NPolygonPath(new NPointF[]{
                new NPointF(0, SIZE),
                new NPointF(SIZE, SIZE),
                new NPointF(SIZE, 0),
                new NPointF(2 * SIZE, 0),
                new NPointF(2 * SIZE, SIZE),
                new NPointF(3 * SIZE, SIZE),
                new NPointF(3 * SIZE, 2 * SIZE),
                new NPointF(2 * SIZE, 2 * SIZE),
                new NPointF(2 * SIZE, 3 * SIZE),
                new NPointF(SIZE, 3 * SIZE),
                new NPointF(SIZE, 2 * SIZE),
                new NPointF(0, 2 * SIZE)
            });

            NStyle.SetStrokeStyle(polygon, new NStrokeStyle(0, Color.White));
            shape.Primitives.AddChild(polygon);
            shape.Primitives.AddChild(new NLinePath(0, SIZE, SIZE, SIZE));
            shape.Primitives.AddChild(new NLinePath(SIZE, SIZE, SIZE, 0));
            shape.Primitives.AddChild(new NLinePath(2 * SIZE, 0, 2 * SIZE, SIZE));
            shape.Primitives.AddChild(new NLinePath(2 * SIZE, SIZE, 3 * SIZE, SIZE));
            shape.Primitives.AddChild(new NLinePath(3 * SIZE, 2 * SIZE, 2 * SIZE, 2 * SIZE));
            shape.Primitives.AddChild(new NLinePath(2 * SIZE, 2 * SIZE, 2 * SIZE, 3 * SIZE));
            shape.Primitives.AddChild(new NLinePath(SIZE, 3 * SIZE, SIZE, 2 * SIZE));
            shape.Primitives.AddChild(new NLinePath(SIZE, 2 * SIZE, 0, 2 * SIZE));
            shape.UpdateModelBounds();

            if (shape.Ports == null)
                shape.CreateShapeElements(ShapeElementsMask.Ports);

            port = new NDynamicPort(shape.UniqueId, LEFT, DynamicPortGlueMode.GlueToContour);
            port.Type = PortType.InwardAndOutward;
            shape.Ports.AddChild(port);

            port = new NDynamicPort(shape.UniqueId, TOP, DynamicPortGlueMode.GlueToContour);
            port.Type = PortType.InwardAndOutward;
            shape.Ports.AddChild(port);

            port = new NDynamicPort(shape.UniqueId, RIGHT, DynamicPortGlueMode.GlueToContour);
            port.Type = PortType.InwardAndOutward;
            shape.Ports.AddChild(port);

            port = new NDynamicPort(shape.UniqueId, BOTTOM, DynamicPortGlueMode.GlueToContour);
            port.Type = PortType.InwardAndOutward;
            shape.Ports.AddChild(port);

            SetProtections(shape);
            return shape;
        }
        private NCompositeShape CreateElbowPipe(string type)
        {
            NDynamicPort port;
            NCompositeShape shape = new NCompositeShape();
            NPolygonPath polygon;
            NContentAlignment ca1, ca2;

            switch (type)
            {
                case "NW":
                    polygon = new NPolygonPath(new NPointF[]{
                        new NPointF(0, SIZE),
                        new NPointF(SIZE, SIZE),
                        new NPointF(SIZE, 0),
                        new NPointF(2 * SIZE, 0),
                        new NPointF(2 * SIZE, 2 * SIZE),
                        new NPointF(0, 2 * SIZE)
                    });

                    ca1 = TOP;
                    ca2 = LEFT;
                    break;

                case "NE":
                    polygon = new NPolygonPath(new NPointF[]{
                        new NPointF(3 * SIZE, SIZE),
                        new NPointF(2 * SIZE, SIZE),
                        new NPointF(2 * SIZE, 0),
                        new NPointF(SIZE, 0),
                        new NPointF(SIZE, 2 * SIZE),
                        new NPointF(3 * SIZE, 2 * SIZE)
                    });

                    ca1 = TOP;
                    ca2 = RIGHT;
                    break;

                case "SW":
                    polygon = new NPolygonPath(new NPointF[]{
                        new NPointF(0, 2 * SIZE),
                        new NPointF(SIZE, 2 * SIZE),
                        new NPointF(SIZE, 3 * SIZE),
                        new NPointF(2 * SIZE, 3 * SIZE),
                        new NPointF(2 * SIZE, SIZE),
                        new NPointF(0, SIZE)
                    });

                    ca1 = BOTTOM;
                    ca2 = LEFT;
                    break;

                case "SE":
                    polygon = new NPolygonPath(new NPointF[]{
                        new NPointF(3 * SIZE, 2 * SIZE),
                        new NPointF(2 * SIZE, 2 * SIZE),
                        new NPointF(2 * SIZE, 3 * SIZE),
                        new NPointF(SIZE, 3 * SIZE),
                        new NPointF(SIZE, SIZE),
                        new NPointF(3 * SIZE, SIZE)
                    });

                    ca1 = BOTTOM;
                    ca2 = RIGHT;
                    break;

                default:
                    throw new ArgumentException("Unsupported elbow pipe type");
            }

            NStyle.SetStrokeStyle(polygon, new NStrokeStyle(0, Color.White));
            shape.Primitives.AddChild(polygon);
            shape.Primitives.AddChild(new NLinePath(polygon.Points[0], polygon.Points[1]));
            shape.Primitives.AddChild(new NLinePath(polygon.Points[1], polygon.Points[2]));
            shape.Primitives.AddChild(new NLinePath(polygon.Points[3], polygon.Points[4]));
            shape.Primitives.AddChild(new NLinePath(polygon.Points[4], polygon.Points[5]));
            shape.UpdateModelBounds(new NRectangleF(0, 0, 3 * SIZE, 3 * SIZE));

            if (shape.Ports == null)
                shape.CreateShapeElements(ShapeElementsMask.Ports);

            port = new NDynamicPort(shape.UniqueId, ca1, DynamicPortGlueMode.GlueToContour);
            port.Type = PortType.InwardAndOutward;
            shape.Ports.AddChild(port);

            port = new NDynamicPort(shape.UniqueId, ca2, DynamicPortGlueMode.GlueToContour);
            port.Type = PortType.InwardAndOutward;
            shape.Ports.AddChild(port);

            SetProtections(shape);
            return shape;
        }
        private NCompositeShape CreateTPipe(string type)
        {
            NDynamicPort port;
            NCompositeShape shape = new NCompositeShape();
            NPolygonPath polygon;
            NContentAlignment ca1, ca2, ca3;

            switch (type)
            {
                case "NEW":
                    polygon = new NPolygonPath(new NPointF[]{
                        new NPointF(0, SIZE),
                        new NPointF(SIZE, SIZE),
                        new NPointF(SIZE, 0),
                        new NPointF(2 * SIZE, 0),
                        new NPointF(2 * SIZE, SIZE),
                        new NPointF(3 * SIZE, SIZE),
                        new NPointF(3 * SIZE, 2 * SIZE),
                        new NPointF(0, 2 * SIZE)
                    });

                    ca1 = TOP;
                    ca2 = LEFT;
                    ca3 = RIGHT;
                    break;

                case "NES":
                    polygon = new NPolygonPath(new NPointF[]{
                        new NPointF(3 * SIZE, SIZE),
                        new NPointF(2 * SIZE, SIZE),
                        new NPointF(2 * SIZE, 0),
                        new NPointF(SIZE, 0),
                        new NPointF(SIZE, 3 * SIZE),
                        new NPointF(2 * SIZE, 3 * SIZE),
                        new NPointF(2 * SIZE, 2 * SIZE),
                        new NPointF(3 * SIZE, 2 * SIZE)
                    });

                    ca1 = TOP;
                    ca2 = RIGHT;
                    ca3 = BOTTOM;
                    break;

                case "NWS":
                    polygon = new NPolygonPath(new NPointF[]{
                        new NPointF(0, SIZE),
                        new NPointF(SIZE, SIZE),
                        new NPointF(SIZE, 0),
                        new NPointF(2 * SIZE, 0),
                        new NPointF(2 * SIZE, 3 * SIZE),
                        new NPointF(SIZE, 3 * SIZE),
                        new NPointF(SIZE, 2 * SIZE),
                        new NPointF(0, 2 * SIZE)
                    });

                    ca1 = TOP;
                    ca2 = LEFT;
                    ca3 = BOTTOM;
                    break;

                case "SEW":
                    polygon = new NPolygonPath(new NPointF[]{
                        new NPointF(3 * SIZE, 2 * SIZE),
                        new NPointF(2 * SIZE, 2 * SIZE),
                        new NPointF(2 * SIZE, 3 * SIZE),
                        new NPointF(SIZE, 3 * SIZE),
                        new NPointF(SIZE, 2 * SIZE),
                        new NPointF(0, 2 * SIZE),
                        new NPointF(0, SIZE),
                        new NPointF(3 * SIZE, SIZE)
                    });

                    ca1 = BOTTOM;
                    ca2 = RIGHT;
                    ca3 = LEFT;
                    break;

                default:
                    throw new ArgumentException("Unsupported elbow pipe type");
            }

            NStyle.SetStrokeStyle(polygon, new NStrokeStyle(0, Color.White));
            shape.Primitives.AddChild(polygon);
            shape.Primitives.AddChild(new NLinePath(polygon.Points[0], polygon.Points[1]));
            shape.Primitives.AddChild(new NLinePath(polygon.Points[1], polygon.Points[2]));
            shape.Primitives.AddChild(new NLinePath(polygon.Points[3], polygon.Points[4]));
            if (type.Contains("S") && type.Contains("N"))
                shape.Primitives.AddChild(new NLinePath(polygon.Points[5], polygon.Points[6]));
            else
                shape.Primitives.AddChild(new NLinePath(polygon.Points[4], polygon.Points[5]));

            shape.Primitives.AddChild(new NLinePath(polygon.Points[6], polygon.Points[7]));
            shape.UpdateModelBounds(new NRectangleF(0, 0, 3 * SIZE, 3 * SIZE));

            if (shape.Ports == null)
                shape.CreateShapeElements(ShapeElementsMask.Ports);

            port = new NDynamicPort(shape.UniqueId, ca1, DynamicPortGlueMode.GlueToContour);
            port.Type = PortType.InwardAndOutward;
            shape.Ports.AddChild(port);

            port = new NDynamicPort(shape.UniqueId, ca2, DynamicPortGlueMode.GlueToContour);
            port.Type = PortType.InwardAndOutward;
            shape.Ports.AddChild(port);

            port = new NDynamicPort(shape.UniqueId, ca3, DynamicPortGlueMode.GlueToContour);
            port.Type = PortType.InwardAndOutward;
            shape.Ports.AddChild(port);

            SetProtections(shape);
            return shape;
        }
        private NCompositeShape CreateEndPipe(string type)
        {
            NDynamicPort port;
            NCompositeShape shape = new NCompositeShape();
            NPolygonPath polygon;
            NContentAlignment ca;

            switch (type)
            {
                case "W":
                    polygon = new NPolygonPath(new NPointF[]{
                        new NPointF(3 * SIZE, SIZE),
                        new NPointF(2 * SIZE, 1.5f * SIZE),
                        new NPointF(3 * SIZE, 2 * SIZE)
                    });

                    ca = RIGHT;
                    break;

                case "N":
                    polygon = new NPolygonPath(new NPointF[]{
                        new NPointF(SIZE, 3 * SIZE),
                        new NPointF(1.5f * SIZE , 2 * SIZE),
                        new NPointF(2 * SIZE, 3 * SIZE)
                    });

                    ca = BOTTOM;
                    break;

                case "E":
                    polygon = new NPolygonPath(new NPointF[]{
                        new NPointF(0, SIZE),
                        new NPointF(SIZE, 1.5f * SIZE),
                        new NPointF(0, 2 * SIZE)
                    });

                    ca = LEFT;
                    break;

                case "S":
                    polygon = new NPolygonPath(new NPointF[]{
                        new NPointF(SIZE, 0),
                        new NPointF(1.5f * SIZE, SIZE),
                        new NPointF(2 * SIZE, 0)
                    });

                    ca = TOP;
                    break;

                default:
                    throw new ArgumentException("Unsupported elbow pipe type");
            }

            NStyle.SetStrokeStyle(polygon, new NStrokeStyle(0, Color.White));
            shape.Primitives.AddChild(polygon);
            shape.Primitives.AddChild(new NLinePath(polygon.Points[0], polygon.Points[1]));
            shape.Primitives.AddChild(new NLinePath(polygon.Points[1], polygon.Points[2]));
            shape.UpdateModelBounds(new NRectangleF(0, 0, 3 * SIZE, 3 * SIZE));

            if (shape.Ports == null)
                shape.CreateShapeElements(ShapeElementsMask.Ports);

            port = new NDynamicPort(shape.UniqueId, ca, DynamicPortGlueMode.GlueToContour);
            port.Type = PortType.InwardAndOutward;
            shape.Ports.AddChild(port);

            SetProtections(shape);
            return shape;
        }

        #endregion

        #region Implemenetation - Library

        private int GetSideIndex(NDynamicPort port)
        {
            if (port.Alignment == LEFT)
                return 0;
            else if (port.Alignment == TOP)
                return 1;
            else if (port.Alignment == RIGHT)
                return 2;
            else if (port.Alignment == BOTTOM)
                return 3;
            else
                throw new Exception("Invalid port side");
        }
        private NLibraryView CreateLibrary()
        {
            NLibraryView libView = new NLibraryView();
            libView.ScrollBars = ScrollBars.Vertical;
            libView.Selection.Mode = DiagramSelectionMode.Single;

            NLibraryDocument libDoc = new NLibraryDocument();
            libView.Document = libDoc;
            libDoc.BackgroundStyle = new NBackgroundStyle();
            libDoc.BackgroundStyle.FillStyle = new NGradientFillStyle(Nevron.GraphicsCore.GradientStyle.Vertical, GradientVariant.Variant1,
                Color.RoyalBlue, Color.LightSkyBlue);

            // Horizontal Pipe
            NCompositeShape shape = CreateHorizontalPipe();
            NMaster master = new NMaster(shape, NGraphicsUnit.Pixel, "Horizontal Pipe", "Drag me on the drawing");
            libDoc.AddChild(master);

            // Vertical Pipe
            shape = CreateVerticalPipe();
            master = new NMaster(shape, NGraphicsUnit.Pixel, "Vertical Pipe", "Drag me on the drawing");
            libDoc.AddChild(master);

            // Cross Pipe
            shape = CreateCrossPipe();
            master = new NMaster(shape, NGraphicsUnit.Pixel, "Cross Pipe", "Drag me on the drawing");
            libDoc.AddChild(master);

            // North-West Pipe
            shape = CreateElbowPipe("NW");
            master = new NMaster(shape, NGraphicsUnit.Pixel, "North-West Pipe", "Drag me on the drawing");
            libDoc.AddChild(master);

            // North-East Pipe
            shape = CreateElbowPipe("NE");
            master = new NMaster(shape, NGraphicsUnit.Pixel, "North-East Pipe", "Drag me on the drawing");
            libDoc.AddChild(master);

            // South-West Pipe
            shape = CreateElbowPipe("SW");
            master = new NMaster(shape, NGraphicsUnit.Pixel, "South-West Pipe", "Drag me on the drawing");
            libDoc.AddChild(master);

            // South-East Pipe
            shape = CreateElbowPipe("SE");
            master = new NMaster(shape, NGraphicsUnit.Pixel, "South-East Pipe", "Drag me on the drawing");
            libDoc.AddChild(master);

            // North-East-West Pipe
            shape = CreateTPipe("NEW");
            master = new NMaster(shape, NGraphicsUnit.Pixel, "North-East-West Pipe", "Drag me on the drawing");
            libDoc.AddChild(master);

            // North-East-South Pipe
            shape = CreateTPipe("NES");
            master = new NMaster(shape, NGraphicsUnit.Pixel, "North-East-South Pipe", "Drag me on the drawing");
            libDoc.AddChild(master);

            // North-West-South Pipe
            shape = CreateTPipe("NWS");
            master = new NMaster(shape, NGraphicsUnit.Pixel, "North-West-South Pipe", "Drag me on the drawing");
            libDoc.AddChild(master);

            // South-East-West Pipe
            shape = CreateTPipe("SEW");
            master = new NMaster(shape, NGraphicsUnit.Pixel, "South-East-West Pipe", "Drag me on the drawing");
            libDoc.AddChild(master);

            // West-End Pipe
            shape = CreateEndPipe("W");
            master = new NMaster(shape, NGraphicsUnit.Pixel, "West-End Pipe", "Drag me on the drawing");
            libDoc.AddChild(master);

            // North-End Pipe
            shape = CreateEndPipe("N");
            master = new NMaster(shape, NGraphicsUnit.Pixel, "North-End Pipe", "Drag me on the drawing");
            libDoc.AddChild(master);

            // East-End Pipe
            shape = CreateEndPipe("E");
            master = new NMaster(shape, NGraphicsUnit.Pixel, "East-End Pipe", "Drag me on the drawing");
            libDoc.AddChild(master);

            // South-End Pipe
            shape = CreateEndPipe("S");
            master = new NMaster(shape, NGraphicsUnit.Pixel, "South-End Pipe", "Drag me on the drawing");
            libDoc.AddChild(master);

            return libView;
        }

        #endregion

        #region Event Handlers

        private void OnNodesConnecting(NConnectionCancelEventArgs args)
        {
            NDynamicPort port1 = (NDynamicPort)document.GetElementFromUniqueId(args.UniqueId1);
            NDynamicPort port2 = (NDynamicPort)document.GetElementFromUniqueId(args.UniqueId2);

            int side1 = GetSideIndex(port1);
            int side2 = GetSideIndex(port2);

            bool sidesFail = side1 % 2 != side2 % 2;
            bool alreadyConnected = port1.ConnectedPoints != null || port2.ConnectedPoints != null;

            if (sidesFail || alreadyConnected)
            {   
                // The ports cannot be connected, so cancel the connection and apply a bounce back force
                NPoint offset = new NPoint(0, 0);
                bool even = side1 % 2 == 0;
                if (sidesFail)
                {
                    if (even)
                    {
                        offset.X = (1 - side1) * SIZE;
                    }
                    else
                    {
                        offset.Y = (2 - side1) * SIZE;
                    }
                }
                else
                {
                    if (!even)
                    {
                        offset.X = (2 - side1) * SIZE;
                    }
                    else
                    {
                        offset.Y = (1 - side1) * SIZE;
                    }
                }

                port1.Shape.Location = new NPointF(port1.Shape.Location.X + offset.X, port1.Shape.Location.Y + offset.Y);
                args.Cancel = true;
            }
        }

        #endregion

        #region Constants

        private const int SIZE = 25;
        private static readonly NContentAlignment LEFT = new NContentAlignment(ContentAlignment.MiddleLeft);
        private static readonly NContentAlignment RIGHT = new NContentAlignment(ContentAlignment.MiddleRight);
        private static readonly NContentAlignment TOP = new NContentAlignment(ContentAlignment.TopCenter);
        private static readonly NContentAlignment BOTTOM = new NContentAlignment(ContentAlignment.BottomCenter);

        #endregion

        #region Nested Types

        private enum Side
        {
            None = -1,
            Left,
            Top,
            Right,
            Bottom
        }

        #endregion
    }
}