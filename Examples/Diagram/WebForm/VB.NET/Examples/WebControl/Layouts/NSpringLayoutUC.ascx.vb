Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Threading
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Windows.Forms

Imports Nevron.Diagram.Layout
Imports Nevron.Diagram
Imports Nevron.Diagram.Batches
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.WebForm
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''	Summary description for NSpringLayoutUC.
	''' </summary>
	Public Partial Class NSpringLayoutUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If NDrawingView1.RequiresInitialization Then
				' begin view init
				NDrawingView1.ViewLayout = CanvasLayout.Fit

				' init document
				NDrawingView1.Document.HistoryService.Stop()
				NDrawingView1.Document.BeginInit()
				InitDocument()
				NDrawingView1.Document.EndInit()

				PerformLayout(Nothing)
			End If
		End Sub

		#Region "Implementation"

		Private Sub InitDocument()
			Dim document As NDrawingDocument = NDrawingView1.Document

			' remove the standard frame
			document.BackgroundStyle.FrameStyle.Visible = False

			' adjust the graphics quality
			document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias

			' set up visual formatting
			document.Style.FillStyle = New NColorFillStyle(Color.Linen)
			document.Style.StartArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)
			document.Style.EndArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)

			' adjust the text properties
			NDrawingView1.Document.Style.TextStyle.FontStyle = New NFontStyle("arial", 15f)

			' create the initial diagram
			CreatePredefinedGraph()
			PerformLayout(Nothing)

			' resize document to fit all shapes
			document.SizeToContent()
		End Sub
		Private Sub PerformLayout(ByVal args As Hashtable)
			' create a layout
			Dim layout As NSpringLayout = New NSpringLayout()

			' configure the optional forces
			layout.BounceBackForce.Padding = 100f
			layout.GravityForce.AttractionCoefficient = 0.2f

			' configure the layout
			If Not args Is Nothing Then
				layout.BounceBackForce.Enabled = Boolean.Parse(args("BounceBackForce").ToString())
				layout.GravityForce.Enabled = Boolean.Parse(args("GravityForce").ToString())
				layout.ElectricalForce.NominalDistance = Single.Parse(args("NominalDistance").ToString())
				layout.SpringForce.LogBase = NLayoutsHelper.ParseFloat(args("LogBase"))
				layout.SpringForce.SpringForceLaw = CType(System.Enum.Parse(GetType(SpringForceLaw), args("SpringForceLaw").ToString()), SpringForceLaw)
			End If

			' get the shapes to layout
			Dim shapes As NNodeList = NDrawingView1.Document.ActiveLayer.Children(NFilters.Shape2D)

			' layout the shapes
			layout.Layout(shapes, New NDrawingLayoutContext(NDrawingView1.Document))

			' resize document to fit all shapes
			NDrawingView1.Document.SizeToContent()
		End Sub
		Private Sub CreatePredefinedGraph()
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
				NDrawingView1.Document.ActiveLayer.AddChild(persons(i).m_Shape)
				i += 1
			Loop

			' creeate the family relations
			i = 0
			Do While i < persons.Count
				Dim currentPerson As NPerson = persons(i)

				If Not currentPerson.m_Family Is Nothing Then
					Dim connector As NLineShape = New NLineShape()
					NDrawingView1.Document.ActiveLayer.AddChild(connector)

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
					NDrawingView1.Document.ActiveLayer.AddChild(connector)

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

		#Region "Event Handlers"

		Protected Sub NDrawingView1_AsyncCustomCommand(ByVal sender As Object, ByVal e As EventArgs)
			Dim args As NCallbackCustomCommandArgs = TryCast(e, NCallbackCustomCommandArgs)
			PerformLayout(args.Command.Arguments)
			m_bClientSideRedrawRequired = True
		End Sub
		Protected Sub NDrawingView1_AsyncQueryCommandResult(ByVal sender As Object, ByVal e As EventArgs)
			Dim args As NCallbackQueryCommandResultArgs = TryCast(e, NCallbackQueryCommandResultArgs)
			Dim resultBuilder As NAjaxXmlTransportBuilder = args.ResultBuilder
			If m_bClientSideRedrawRequired AndAlso (Not resultBuilder.ContainsRedrawDataSection()) Then
				resultBuilder.AddRedrawDataSection(NDrawingView1)
			End If
		End Sub

		#End Region

		#Region "Fields"

		Private m_bClientSideRedrawRequired As Boolean = False

		#End Region

		#Region "Nested Types"

		Public Class NPerson
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