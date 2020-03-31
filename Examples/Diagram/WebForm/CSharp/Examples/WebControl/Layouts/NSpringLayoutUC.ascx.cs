using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

using Nevron.Diagram.Layout;
using Nevron.Diagram;
using Nevron.Diagram.Batches;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.Filters;
using Nevron.Diagram.WebForm;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///	Summary description for NSpringLayoutUC.
	/// </summary>
	public partial class NSpringLayoutUC : NDiagramExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (NDrawingView1.RequiresInitialization)
            {
                // begin view init
                NDrawingView1.ViewLayout = CanvasLayout.Fit;

                // init document
                NDrawingView1.Document.HistoryService.Stop();
                NDrawingView1.Document.BeginInit();
                InitDocument();
                NDrawingView1.Document.EndInit();

                PerformLayout(null);
            }
        }

        #region Implementation

        private void InitDocument()
		{
            NDrawingDocument document = NDrawingView1.Document;

            // remove the standard frame
            document.BackgroundStyle.FrameStyle.Visible = false;

            // adjust the graphics quality
            document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // set up visual formatting
            document.Style.FillStyle = new NColorFillStyle(Color.Linen);
            document.Style.StartArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);
            document.Style.EndArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);

			// adjust the text properties
			NDrawingView1.Document.Style.TextStyle.FontStyle = new NFontStyle("arial", 15f);

            // create the initial diagram
            CreatePredefinedGraph();
            PerformLayout(null);

            // resize document to fit all shapes
            document.SizeToContent();
        }
		private void PerformLayout(Hashtable args)
		{
			// create a layout
			NSpringLayout layout = new NSpringLayout();

			// configure the optional forces
			layout.BounceBackForce.Padding = 100f;
			layout.GravityForce.AttractionCoefficient = 0.2f;

            // configure the layout
            if (args != null)
            {
                layout.BounceBackForce.Enabled = Boolean.Parse(args["BounceBackForce"].ToString());
                layout.GravityForce.Enabled = Boolean.Parse(args["GravityForce"].ToString());
                layout.ElectricalForce.NominalDistance = Single.Parse(args["NominalDistance"].ToString());
                layout.SpringForce.LogBase = NLayoutsHelper.ParseFloat(args["LogBase"]);
                layout.SpringForce.SpringForceLaw = (SpringForceLaw)Enum.Parse(typeof(SpringForceLaw), args["SpringForceLaw"].ToString());
            }

			// get the shapes to layout
			NNodeList shapes = NDrawingView1.Document.ActiveLayer.Children(NFilters.Shape2D);

			// layout the shapes
			layout.Layout(shapes, new NDrawingLayoutContext(NDrawingView1.Document));

			// resize document to fit all shapes
			NDrawingView1.Document.SizeToContent();
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
				NDrawingView1.Document.ActiveLayer.AddChild(persons[i].m_Shape);
			}

			// creeate the family relations
			for (int i = 0; i < persons.Count; i++)
			{
				NPerson currentPerson = persons[i];

				if (currentPerson.m_Family != null)
				{
					NLineShape connector = new NLineShape();
					NDrawingView1.Document.ActiveLayer.AddChild(connector);

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
					NDrawingView1.Document.ActiveLayer.AddChild(connector);

					connector.FromShape = currentPerson.m_Shape;
					connector.ToShape = currentPerson.m_Friends[j].m_Shape;

					connector.LayoutData.SpringStiffness = 1;
					connector.LayoutData.SpringLength = 200;
					connector.Style.StrokeStyle = new NStrokeStyle(2, Color.Green);
				}
			}
		}

        #endregion

        #region Event Handlers

        protected void NDrawingView1_AsyncCustomCommand(object sender, EventArgs e)
        {
            NCallbackCustomCommandArgs args = e as NCallbackCustomCommandArgs;
            PerformLayout(args.Command.Arguments);
            m_bClientSideRedrawRequired = true;
        }
        protected void NDrawingView1_AsyncQueryCommandResult(object sender, EventArgs e)
        {
            NCallbackQueryCommandResultArgs args = e as NCallbackQueryCommandResultArgs;
            NAjaxXmlTransportBuilder resultBuilder = args.ResultBuilder;
            if (m_bClientSideRedrawRequired && !resultBuilder.ContainsRedrawDataSection())
            {
                resultBuilder.AddRedrawDataSection(NDrawingView1);
            }
        }

        #endregion

        #region Fields

        private bool m_bClientSideRedrawRequired = false;

        #endregion

        #region Nested Types

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

        #endregion
	}
}