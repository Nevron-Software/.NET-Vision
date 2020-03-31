Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic

Imports System.Drawing
Imports Nevron.Diagram
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.ThinWeb
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''	Summary description for NSpringLayoutUC.
	''' </summary>
	Public Partial Class NSpringLayoutUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If NThinDiagramControl1.Initialized Then
				Return
			End If

			' Init the diagram control
			NThinDiagramControl1.StateId = "Diagram1"
			NThinDiagramControl1.CustomRequestCallback = New CustomRequestCallback()

			' Init the view
			NThinDiagramControl1.View.Layout = CanvasLayout.Fit

			' Init the document
			Dim document As NDrawingDocument = NThinDiagramControl1.Document
			document.BeginInit()
			InitDocument(document)
			document.EndInit()
		End Sub

		#Region "Implementation"

		Private Sub InitDocument(ByVal document As NDrawingDocument)
			' Remove the standard frame
			document.BackgroundStyle.FrameStyle.Visible = False

			' Adjust the graphics quality
			document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias

			' Set up visual formatting
			document.Style.FillStyle = New NColorFillStyle(Color.Linen)
			document.Style.StartArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)
			document.Style.EndArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)

			' Adjust the text properties
			document.Style.TextStyle.FontStyle = New NFontStyle("arial", 15f)

			' Create the initial diagram
			CreatePredefinedGraph(document)

			' Create the layout
			Dim layout As NSpringLayout = New NSpringLayout()

			' Configure the optional forces
			layout.BounceBackForce.Padding = 100f
			layout.GravityForce.AttractionCoefficient = 0.2f

			' Get the shapes to layout
			Dim shapes As NNodeList = document.ActiveLayer.Children(NFilters.Shape2D)

			' Layout the shapes
			layout.Layout(shapes, New NDrawingLayoutContext(document))

			' Resize document to fit all shapes
			document.SizeToContent()
		End Sub
		Private Sub CreatePredefinedGraph(ByVal document As NDrawingDocument)
			' we will be using basic shapes for this example
			Dim basicShapesFactory As NBasicShapesFactory = New NBasicShapesFactory()
			basicShapesFactory.DefaultSize = New NSizeF(80, 80)

			Dim persons As List(Of NPerson) = New List(Of NPerson)()

			' create persons
			Dim personEmil As NPerson = New NPerson("Emil Moore", basicShapesFactory.CreateShape(BasicShapes.Circle))
			Dim personAndre As NPerson = New NPerson("Andre Smith", basicShapesFactory.CreateShape(BasicShapes.Circle))
			Dim personRobert As NPerson = New NPerson("Robert Johnson", basicShapesFactory.CreateShape(BasicShapes.Circle))
			Dim personBob As NPerson = New NPerson("Bob Williams", basicShapesFactory.CreateShape(BasicShapes.Circle))
			Dim personPeter As NPerson = New NPerson("Peter Brown", basicShapesFactory.CreateShape(BasicShapes.Circle))
			Dim personSilvia As NPerson = New NPerson("Silvia Moore", basicShapesFactory.CreateShape(BasicShapes.Circle))
			Dim personEmily As NPerson = New NPerson("Emily Smith", basicShapesFactory.CreateShape(BasicShapes.Circle))
			Dim personMonica As NPerson = New NPerson("Monica Johnson", basicShapesFactory.CreateShape(BasicShapes.Circle))
			Dim personSamantha As NPerson = New NPerson("Samantha Miller", basicShapesFactory.CreateShape(BasicShapes.Circle))
			Dim personIsabella As NPerson = New NPerson("Isabella Davis", basicShapesFactory.CreateShape(BasicShapes.Circle))

			persons.Add(personEmil)
			persons.Add(personAndre)
			persons.Add(personRobert)
			persons.Add(personBob)
			persons.Add(personPeter)
			persons.Add(personSilvia)
			persons.Add(personEmily)
			persons.Add(personMonica)
			persons.Add(personSamantha)
			persons.Add(personIsabella)

			' create family relashionships
			personEmil.m_Family = personSilvia
			personAndre.m_Family = personEmily
			personRobert.m_Family = personMonica

			' create friend relationships
			personEmily.m_Friends.Add(personBob)
			personEmily.m_Friends.Add(personMonica)

			personAndre.m_Friends.Add(personPeter)
			personAndre.m_Friends.Add(personIsabella)

			personSilvia.m_Friends.Add(personBob)
			personSilvia.m_Friends.Add(personSamantha)
			personSilvia.m_Friends.Add(personIsabella)

			personEmily.m_Friends.Add(personIsabella)
			personEmily.m_Friends.Add(personPeter)

			personPeter.m_Friends.Add(personRobert)

			' create the person vertices
			Dim i As Integer = 0
			Do While i < persons.Count
				document.ActiveLayer.AddChild(persons(i).m_Shape)
				i += 1
			Loop

			' creeate the family relations
			i = 0
			Do While i < persons.Count
				Dim currentPerson As NPerson = persons(i)

				If Not currentPerson.m_Family Is Nothing Then
					Dim connector As NLineShape = New NLineShape()
					document.ActiveLayer.AddChild(connector)

					connector.FromShape = currentPerson.m_Shape
					connector.ToShape = currentPerson.m_Family.m_Shape

					connector.LayoutData.SpringStiffness = 2
					connector.LayoutData.SpringLength = 100
					connector.Style.StrokeStyle = New NStrokeStyle(2, Color.Coral)
				End If
				i += 1
			Loop

			i = 0
			Do While i < persons.Count
				Dim currentPerson As NPerson = persons(i)
				Dim j As Integer = 0
				Do While j < currentPerson.m_Friends.Count
					Dim connector As NLineShape = New NLineShape()
					document.ActiveLayer.AddChild(connector)

					connector.FromShape = currentPerson.m_Shape
					connector.ToShape = currentPerson.m_Friends(j).m_Shape

					connector.LayoutData.SpringStiffness = 1
					connector.LayoutData.SpringLength = 200
					connector.Style.StrokeStyle = New NStrokeStyle(2, Color.Green)
					j += 1
				Loop
				i += 1
			Loop
		End Sub

		#End Region

		#Region "Nested Types"

		<Serializable> _
		Private Class CustomRequestCallback
			Implements INCustomRequestCallback
			Private Sub OnCustomRequestCallback(ByVal control As NAspNetThinWebControl, ByVal context As NRequestContext, ByVal argument As String) Implements INCustomRequestCallback.OnCustomRequestCallback
				Dim diagramControl As NThinDiagramControl = CType(control, NThinDiagramControl)
				Dim document As NDrawingDocument = diagramControl.Document

				Dim helper As NDrawingDocumentHelper = New NDrawingDocumentHelper(document)
				Dim settings As Dictionary(Of String, String) = helper.ParseSettings(argument)

				' Create and configure the layout
				Dim layout As NSpringLayout = New NSpringLayout()
				layout.BounceBackForce.Padding = 100.0F
				layout.GravityForce.AttractionCoefficient = 0.2F
				layout.BounceBackForce.Enabled = Boolean.Parse(settings("BounceBackForce"))
				layout.GravityForce.Enabled = Boolean.Parse(settings("GravityForce"))
				layout.ElectricalForce.NominalDistance = Single.Parse(settings("NominalDistance"))
				layout.SpringForce.LogBase = helper.ParseFloat(settings("LogBase"))
				layout.SpringForce.SpringForceLaw = CType(System.Enum.Parse(GetType(SpringForceLaw), settings("SpringForceLaw")), SpringForceLaw)

				' Get the shapes to layout
				Dim shapes As NNodeList = document.ActiveLayer.Children(NFilters.Shape2D)

				' Layout the shapes
				layout.Layout(shapes, New NDrawingLayoutContext(document))

				' Resize document to fit all shapes
				document.SizeToContent()

				' Update the view
				diagramControl.UpdateView()
			End Sub
		End Class

		Private Class NPerson
			Public Sub New(ByVal name As String, ByVal shape As NShape)
				m_Shape = shape
				m_Shape.Text = name
				m_Name = name
				m_Friends = New List(Of NPerson)()
				m_Family = Nothing
			End Sub

			Public m_Shape As NShape
			Public m_Name As String
			Public m_Friends As List(Of NPerson)
			Public m_Family As NPerson
		End Class

		#End Region
	End Class
End Namespace