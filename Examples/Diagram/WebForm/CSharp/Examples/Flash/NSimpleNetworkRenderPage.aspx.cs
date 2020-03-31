using System.Collections.Generic;
using System.Drawing;

using Nevron.Diagram;
using Nevron.Diagram.Layout;
using Nevron.Diagram.WebForm;
using Nevron.Diagram.Shapes;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;
using Nevron.Diagram.Filters;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
    /// Summary description for NSimpleNetworkRenderPage.
	/// </summary>
	public partial class NSimpleNetworkRenderPage : NDrawingViewHostPage
    {
        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public NSimpleNetworkRenderPage()
		{
			DrawingView = new NDrawingView();
			DrawingView.ViewLayout = CanvasLayout.Stretch;

            NImageResponse swfResponse = new NImageResponse();
            swfResponse.ImageFormat = new NSwfImageFormat();
            swfResponse.StreamImageToBrowser = true;
            DrawingView.ServerSettings.BrowserResponseSettings.DefaultResponse = swfResponse;

			// init document
			NDrawingDocument document = this.DrawingView.Document;
			document.BeginInit();
			CreateScene(document);
			document.EndInit();

			this.DrawingView.SizeToContent();
        }

        #endregion

        #region Private Methods

        private void CreateScene(NDrawingDocument document)
		{
            document.BackgroundStyle.FrameStyle.Visible = false;
            document.Style.TextStyle.FontStyle.InitFromFont(new Font("Arial Narrow", 8));

            NNetworkShapesFactory factory = new NNetworkShapesFactory(document);
            factory.DefaultSize = new NSizeF(240, 180);

            NShape server = factory.CreateShape(NetworkShapes.Server);
            NShape computer = factory.CreateShape(NetworkShapes.Computer);
            NShape laptop = factory.CreateShape(NetworkShapes.Laptop);

            document.ActiveLayer.AddChild(server);
            document.ActiveLayer.AddChild(computer);
            document.ActiveLayer.AddChild(laptop);

            NRoutableConnector link1 = new NRoutableConnector();
            document.ActiveLayer.AddChild(link1);
            link1.FromShape = server;
            link1.ToShape = computer;

            NRoutableConnector link2 = new NRoutableConnector();
            document.ActiveLayer.AddChild(link2);
            link2.FromShape = server;
            link2.ToShape = laptop;

            // layout the shapes in the active layer using a table layout
            NLayeredGraphLayout layout = new NLayeredGraphLayout();

            // get the shapes to layout
            NNodeList shapes = document.ActiveLayer.Children(NFilters.Shape2D);

            // layout the shapes
            layout.Layout(shapes, new NDrawingLayoutContext(document));

            // resize document to fit all shapes
            document.SizeToContent();

            // add the data shape
            const float shapeSize = 10;
            NEllipseShape data = new NEllipseShape(link2.EndPoint.X - shapeSize / 2, link2.EndPoint.Y - shapeSize, shapeSize, shapeSize);
            document.ActiveLayer.AddChild(data);
            NStyle.SetStrokeStyle(data, new NStrokeStyle(0, KnownArgbColorValue.Transparent));
            NStyle.SetFillStyle(data, new NColorFillStyle(KnownArgbColorValue.Red));

            // set the animations style
            SetAnimationsStyle(data, link1, link2);

            // resize document to fit all shapes
            document.SizeToContent();
        }
        private void SetAnimationsStyle(NShape data, NRoutableConnector link1, NRoutableConnector link2)
        {
            NPathAnimator pathAnimator = new NPathAnimator(data);
            pathAnimator.Animate(link1.Points, true);
            pathAnimator.SetPause(link1.StartPoint, 1);
            pathAnimator.SetPause(link2.StartPoint, 1);

            NPointF[] points = link2.Points;
            points[points.Length - 1] = data.PinPoint;
            pathAnimator.Animate(points, false);
        }

        #endregion

        #region Nested Types

        class NPathAnimator
        {
            #region Constructors

            public NPathAnimator(NShape shape)
            {
                m_Shape = shape;
                m_CurrentTime = 0;
                m_Speed = 50;
            }

            #endregion

            #region Properties

            /// <summary>
            /// The distance in pixels which the animated shape passes for 1 second.
            /// </summary>
            public float Speed
            {
                get
                {
                    return m_Speed;
                }
                set
                {
                    m_Speed = value;
                }
            }

            #endregion

            #region Public Methods

            public void Animate(IList<NPointF> path)
            {
                Animate(path, false);
            }
            public void Animate(IList<NPointF> path, bool reversed)
            {
                NPointF pinOffset = m_Shape.PinPoint - m_Shape.Location;
                NPointFList points = new NPointFList(path);
                if (reversed)
                {
                    points.Reverse();
                }

                int i, count = points.Count - 1;
                for (i = 0; i < count; i++)
                {
                    // Determine the start and end point
                    NPointF p1 = points[i] - pinOffset;
                    NPointF p2 = points[i + 1] - pinOffset;

                    // Create the animation
                    float distance = p1.Distance(p2);
                    float duration = distance / m_Speed;

                    NTranslateAnimation move = new NTranslateAnimation(m_CurrentTime, duration);
                    move.StartOffset = p1 - m_Shape.Location;
                    move.EndOffset = p2 - m_Shape.Location;

                    if (m_Shape.Style.AnimationsStyle == null)
                    {
                        m_Shape.Style.AnimationsStyle = new NAnimationsStyle();
                    }

                    m_Shape.Style.AnimationsStyle.Animations.Add(move);
                    m_CurrentTime += duration;
                }
            }

            public void SetPause(NPointF location, float duration)
            {
                NTranslateAnimation move = new NTranslateAnimation(m_CurrentTime, duration);

				move.EndOffset = location - m_Shape.PinPoint; 
                move.StartOffset = move.EndOffset;

                if (m_Shape.Style.AnimationsStyle == null)
                {
                    m_Shape.Style.AnimationsStyle = new NAnimationsStyle();
                }

                m_Shape.Style.AnimationsStyle.Animations.Add(move);
                m_CurrentTime += duration;
            }

            #endregion

            #region Fields

            private NShape m_Shape;
            private float m_CurrentTime;
            private float m_Speed;

            #endregion
        }

        #endregion
	}
}