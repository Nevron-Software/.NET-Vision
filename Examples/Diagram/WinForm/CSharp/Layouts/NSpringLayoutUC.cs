using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

using Nevron.Diagram.Layout;
using Nevron.Diagram;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.Filters;

namespace Nevron.Examples.Diagram.WinForm
{
    /// <summary>
    /// Summary description for NSpringLayoutUC.
    /// </summary>
    public class NSpringLayoutUC : NDiagramExampleUC
    {
        #region Constructor

        public NSpringLayoutUC(NMainForm form)
            : base(form)
		{
			InitializeComponent();
		}

		#endregion

        #region Component Designer Generated Code

        private void InitializeComponent()
        {
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.LayoutButton = new Nevron.UI.WinForm.Controls.NButton();
            this.UpdateDrawingWhileLayouting = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(8, 3);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.propertyGrid1.Size = new System.Drawing.Size(244, 387);
            this.propertyGrid1.TabIndex = 1;
            // 
            // LayoutButton
            // 
            this.LayoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LayoutButton.Location = new System.Drawing.Point(8, 491);
            this.LayoutButton.Name = "LayoutButton";
            this.LayoutButton.Size = new System.Drawing.Size(244, 23);
            this.LayoutButton.TabIndex = 2;
            this.LayoutButton.Text = "Layout";
            this.LayoutButton.UseVisualStyleBackColor = true;
            this.LayoutButton.Click += new System.EventHandler(this.LayoutButton_Click);
            // 
            // UpdateDrawingWhileLayouting
            // 
            this.UpdateDrawingWhileLayouting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateDrawingWhileLayouting.Location = new System.Drawing.Point(8, 453);
            this.UpdateDrawingWhileLayouting.Name = "UpdateDrawingWhileLayouting";
            this.UpdateDrawingWhileLayouting.Size = new System.Drawing.Size(244, 17);
            this.UpdateDrawingWhileLayouting.TabIndex = 8;
            this.UpdateDrawingWhileLayouting.Text = "Update drawing while layouting";
            this.UpdateDrawingWhileLayouting.UseVisualStyleBackColor = true;
            // 
            // NSpringLayoutUC
            // 
            this.Controls.Add(this.UpdateDrawingWhileLayouting);
            this.Controls.Add(this.LayoutButton);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "NSpringLayoutUC";
            this.Controls.SetChildIndex(this.propertyGrid1, 0);
            this.Controls.SetChildIndex(this.LayoutButton, 0);
            this.Controls.SetChildIndex(this.UpdateDrawingWhileLayouting, 0);
            this.ResumeLayout(false);

        }

        #endregion

        #region NDiagramExampleUC Overrides

        protected override void LoadExample()
        {
            // create and configure the spring layout
            m_Layout = new NSpringLayout();

            // hook the iteration completed event
            m_Layout.IterationCompleted += new GraphLayoutCancelEventHandler(layout_IterationCompleted);

            // select it in the property grid
            propertyGrid1.SelectedObject = m_Layout;

            view.BeginInit();
            view.Grid.Visible = false;
            view.GlobalVisibility.ShowPorts = false;
            view.GlobalVisibility.ShowArrowheads = false; 
            view.ViewLayout = ViewLayout.Fit;

            // init document
            document.BeginInit();
            InitDocument();
            document.EndInit();

            // end view init
            view.EndInit();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Invoked on each successfully completed iteration of the layout
        /// </summary>
        /// <param name="args"></param>
        private void layout_IterationCompleted(NGraphLayoutCancelEventArguments args)
        {
            if (UpdateDrawingWhileLayouting.Checked)
            {
                bool refreshLocked = view.LockRefresh;
                if (refreshLocked)
                {
                    view.LockRefresh = false;
                }

                NShapeBodyAdapter shapeBodyAdaptor = new NShapeBodyAdapter(document);

                IEnumerator<NGraphPart> en = args.Graph.GetPartsEnumerator();
                while (en.MoveNext())
                {
                    NGraphVertex vertex = en.Current as NGraphVertex;
                    if (vertex != null)
                    {
                        NBody2D body = vertex.Tag as NBody2D;
                        shapeBodyAdaptor.UpdateObjectFromBody2D(body);
                    }
                }

                document.SizeToContent();

                view.Invalidate();
                view.Update();

                if (refreshLocked)
                {
                    view.LockRefresh = true;
                }

                Application.DoEvents();
            }
        }

        #endregion

        #region Implementation

		public class NPerson
		{
			public NPerson(string name, NShape shape)
			{
				m_Shape = shape;
				m_Shape.Text = name;
				m_Name = name;
				m_Friends = new List<NPerson>();
				m_Family = null;
			}

			public NShape m_Shape;
			public string m_Name;
			public List<NPerson> m_Friends;
			public NPerson m_Family;
		}

        private void CreatePredefinedGraph()
        {
			// we will be using basic shapes for this example
			NBasicShapesFactory basicShapesFactory = new NBasicShapesFactory();
			basicShapesFactory.DefaultSize = new NSizeF(80, 80);

			List<NPerson> persons = new List<NPerson>();

			// create persons
			NPerson personEmil = new NPerson("Emil Moore", basicShapesFactory.CreateShape(BasicShapes.Circle));
			NPerson personAndre = new NPerson("Andre Smith", basicShapesFactory.CreateShape(BasicShapes.Circle));
			NPerson personRobert = new NPerson("Robert Johnson", basicShapesFactory.CreateShape(BasicShapes.Circle));
			NPerson personBob = new NPerson("Bob Williams", basicShapesFactory.CreateShape(BasicShapes.Circle));
			NPerson personPeter = new NPerson("Peter Brown", basicShapesFactory.CreateShape(BasicShapes.Circle));
			NPerson personSilvia = new NPerson("Silvia Moore", basicShapesFactory.CreateShape(BasicShapes.Circle));
			NPerson personEmily = new NPerson("Emily Smith", basicShapesFactory.CreateShape(BasicShapes.Circle));
			NPerson personMonica = new NPerson("Monica Johnson", basicShapesFactory.CreateShape(BasicShapes.Circle)); 
			NPerson personSamantha = new NPerson("Samantha Miller", basicShapesFactory.CreateShape(BasicShapes.Circle));
			NPerson personIsabella  = new NPerson("Isabella Davis", basicShapesFactory.CreateShape(BasicShapes.Circle));

			persons.Add(personEmil);
			persons.Add(personAndre);
			persons.Add(personRobert);
			persons.Add(personBob);
			persons.Add(personPeter);
			persons.Add(personSilvia);
			persons.Add(personEmily);
			persons.Add(personMonica);
			persons.Add(personSamantha);
			persons.Add(personIsabella);

			// create family relashionships
			personEmil.m_Family = personSilvia;
			personAndre.m_Family = personEmily;
			personRobert.m_Family = personMonica;

			// create friend relationships
			personEmily.m_Friends.Add(personBob);
			personEmily.m_Friends.Add(personMonica);

			personAndre.m_Friends.Add(personPeter);
			personAndre.m_Friends.Add(personIsabella);

			personSilvia.m_Friends.Add(personBob);
			personSilvia.m_Friends.Add(personSamantha);
			personSilvia.m_Friends.Add(personIsabella);

			personEmily.m_Friends.Add(personIsabella);
			personEmily.m_Friends.Add(personPeter);

			personPeter.m_Friends.Add(personRobert);

			// create the person vertices
			for (int i = 0; i < persons.Count; i++)
			{
				document.ActiveLayer.AddChild(persons[i].m_Shape);
			}

			// creeate the family relations
			for (int i = 0; i < persons.Count; i++)
			{
				NPerson currentPerson = persons[i];

				if (currentPerson.m_Family != null)
				{
					NLineShape connector = new NLineShape();
					document.ActiveLayer.AddChild(connector);

					connector.FromShape = currentPerson.m_Shape;
					connector.ToShape = currentPerson.m_Family.m_Shape;

					connector.LayoutData.SpringStiffness = 2;
					connector.LayoutData.SpringLength = 100;
					connector.Style.StrokeStyle = new NStrokeStyle(2, Color.Coral);
				}
			}

			for (int i = 0; i < persons.Count; i++)
			{
				NPerson currentPerson = persons[i];
				for (int j = 0; j < currentPerson.m_Friends.Count; j++)
				{
					NLineShape connector = new NLineShape();
					document.ActiveLayer.AddChild(connector);

					connector.FromShape = currentPerson.m_Shape;
					connector.ToShape = currentPerson.m_Friends[j].m_Shape;

					connector.LayoutData.SpringStiffness = 1;
					connector.LayoutData.SpringLength = 200;
					connector.Style.StrokeStyle = new NStrokeStyle(2, Color.Green);
				}
			}


            // layout
            LayoutButton.PerformClick();
        }

        private void InitDocument()
        {
            // we do not need history for this example
            document.HistoryService.Pause();

            CreatePredefinedGraph();

            // resize document to fit all shapes
            LayoutButton.PerformClick();
            document.SizeToContent();
        }

        private void LayoutButton_Click(object sender, EventArgs e)
        {
            // get the shapes to layout
            NNodeList shapes = document.ActiveLayer.Children(NFilters.Shape2D);

            // create a layout context
            NLayoutContext layoutContext = new NLayoutContext();
            layoutContext.GraphAdapter = new NShapeGraphAdapter();
            layoutContext.BodyAdapter = new NShapeBodyAdapter(document);
            layoutContext.BodyContainerAdapter = new NDrawingBodyContainerAdapter(document);

            // layout the shapes
            if(m_Layout != null)
                m_Layout.Layout(shapes, layoutContext);

            // resize document to fit all shapes
            document.SizeToContent();
        }

        #endregion

        #region Designer Fields

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private Nevron.UI.WinForm.Controls.NButton LayoutButton;
        private System.Windows.Forms.CheckBox UpdateDrawingWhileLayouting;

        #endregion
        
        #region Fields

        private NSpringLayout m_Layout;

        #endregion
    }
}