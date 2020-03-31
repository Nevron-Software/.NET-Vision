using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Nevron.Diagram;
using Nevron.Diagram.Extensions;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.UI.WinForm.Controls;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
    /// Summary description for NSimpleNetworkUC.
	/// </summary>
	public class NSimpleNetworkUC : NDiagramExampleUC
	{
		#region Constructors

        public NSimpleNetworkUC(NMainForm form)
            : base(form)
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
            this.btnGenerateSwf = new Nevron.UI.WinForm.Controls.NButton();
            this.btnGenerateXaml = new Nevron.UI.WinForm.Controls.NButton();
            this.SuspendLayout();
            // 
            // btnGenerateSwf
            // 
            this.btnGenerateSwf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateSwf.Location = new System.Drawing.Point(8, 51);
            this.btnGenerateSwf.Name = "btnGenerateSwf";
            this.btnGenerateSwf.Size = new System.Drawing.Size(232, 23);
            this.btnGenerateSwf.TabIndex = 4;
            this.btnGenerateSwf.Text = "Generate SWF";
            this.btnGenerateSwf.UseVisualStyleBackColor = true;
            this.btnGenerateSwf.Click += new System.EventHandler(this.btnGenrateSwf_Click);
            // 
            // btnGenerateXaml
            // 
            this.btnGenerateXaml.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateXaml.Location = new System.Drawing.Point(8, 20);
            this.btnGenerateXaml.Name = "btnGenerateXaml";
            this.btnGenerateXaml.Size = new System.Drawing.Size(232, 23);
            this.btnGenerateXaml.TabIndex = 5;
            this.btnGenerateXaml.Text = "Generate XAML";
            this.btnGenerateXaml.UseVisualStyleBackColor = true;
            this.btnGenerateXaml.Click += new System.EventHandler(this.btnGenerateXaml_Click);
            // 
            // NSimpleNetworkUC
            // 
            this.Controls.Add(this.btnGenerateXaml);
            this.Controls.Add(this.btnGenerateSwf);
            this.Name = "NSimpleNetworkUC";
            this.Size = new System.Drawing.Size(248, 160);
            this.Controls.SetChildIndex(this.btnGenerateSwf, 0);
            this.Controls.SetChildIndex(this.btnGenerateXaml, 0);
            this.ResumeLayout(false);

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

        #region Event Handlers

        private void btnGenrateSwf_Click(object sender, System.EventArgs e)
        {
            NFlashExporter flashExporter = new NFlashExporter(document);
            string fileName = Path.Combine(Application.StartupPath, "test.swf");
            flashExporter.SaveToFile(fileName);
            Process.Start(fileName);
        }
        private void btnGenerateXaml_Click(object sender, System.EventArgs e)
        {
            NXamlExporter flashExporter = new NXamlExporter(document);
            string fileName = Path.Combine(Application.StartupPath, "test.xaml");
            flashExporter.SaveToFile(fileName);
            Process.Start(fileName);
        }

        #endregion

        #region Designer Fields

        private NButton btnGenerateSwf;
        private NButton btnGenerateXaml;

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
                move.StartOffset = location - m_Shape.PinPoint;

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