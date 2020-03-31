using System;
using System.Collections.Generic;

using System.Drawing;
using Nevron.Diagram;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.ThinWeb;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///	Summary description for NSpringLayoutUC.
	/// </summary>
	public partial class NSpringLayoutUC : NDiagramExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (NThinDiagramControl1.Initialized)
				return;

			// Init the diagram control
			NThinDiagramControl1.StateId = "Diagram1";
			NThinDiagramControl1.CustomRequestCallback = new CustomRequestCallback();

			// Init the view
			NThinDiagramControl1.View.Layout = CanvasLayout.Fit;

			// Init the document
			NDrawingDocument document = NThinDiagramControl1.Document;
			document.BeginInit();
			InitDocument(document);
			document.EndInit();
		}

        #region Implementation

        private void InitDocument(NDrawingDocument document)
		{
            // Remove the standard frame
            document.BackgroundStyle.FrameStyle.Visible = false;

            // Adjust the graphics quality
            document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Set up visual formatting
            document.Style.FillStyle = new NColorFillStyle(Color.Linen);
            document.Style.StartArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);
            document.Style.EndArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);

			// Adjust the text properties
			document.Style.TextStyle.FontStyle = new NFontStyle("arial", 15f);

            // Create the initial diagram
            CreatePredefinedGraph(document);

			// Create the layout
			NSpringLayout layout = new NSpringLayout();

			// Configure the optional forces
			layout.BounceBackForce.Padding = 100f;
			layout.GravityForce.AttractionCoefficient = 0.2f;

			// Get the shapes to layout
			NNodeList shapes = document.ActiveLayer.Children(NFilters.Shape2D);

			// Layout the shapes
			layout.Layout(shapes, new NDrawingLayoutContext(document));

            // Resize document to fit all shapes
            document.SizeToContent();
        }
        private void CreatePredefinedGraph(NDrawingDocument document)
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
		}

        #endregion

        #region Nested Types

		[Serializable]
		private class CustomRequestCallback : INCustomRequestCallback
		{
			void INCustomRequestCallback.OnCustomRequestCallback(NAspNetThinWebControl control, NRequestContext context, string argument)
			{
				NThinDiagramControl diagramControl = (NThinDiagramControl)control;
				NDrawingDocument document = diagramControl.Document;

				NDrawingDocumentHelper helper = new NDrawingDocumentHelper(document);
				Dictionary<string, string> settings = helper.ParseSettings(argument);

				// Create and configure the layout
				NSpringLayout layout = new NSpringLayout();
				layout.BounceBackForce.Padding = 100f;
				layout.GravityForce.AttractionCoefficient = 0.2f;
				layout.BounceBackForce.Enabled = Boolean.Parse(settings["BounceBackForce"]);
				layout.GravityForce.Enabled = Boolean.Parse(settings["GravityForce"]);
				layout.ElectricalForce.NominalDistance = Single.Parse(settings["NominalDistance"]);
				layout.SpringForce.LogBase = helper.ParseFloat(settings["LogBase"]);
				layout.SpringForce.SpringForceLaw = (SpringForceLaw)Enum.Parse(typeof(SpringForceLaw), settings["SpringForceLaw"]);

				// Get the shapes to layout
				NNodeList shapes = document.ActiveLayer.Children(NFilters.Shape2D);

				// Layout the shapes
				layout.Layout(shapes, new NDrawingLayoutContext(document));

				// Resize document to fit all shapes
				document.SizeToContent();

				// Update the view
				diagramControl.UpdateView();
			}
		}

        private class NPerson
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