Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections.Generic

Imports Nevron.Diagram.Layout
Imports Nevron.Diagram
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.Filters

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NSpringLayoutUC.
	''' </summary>
	Public Class NSpringLayoutUC
		Inherits NDiagramExampleUC
		#Region "Constructor"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			InitializeComponent()
		End Sub

		#End Region

		#Region "Component Designer Generated Code"

		Private Sub InitializeComponent()
			Me.propertyGrid1 = New System.Windows.Forms.PropertyGrid()
			Me.LayoutButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.UpdateDrawingWhileLayouting = New System.Windows.Forms.CheckBox()
			Me.SuspendLayout()
			' 
			' propertyGrid1
			' 
			Me.propertyGrid1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.propertyGrid1.Location = New System.Drawing.Point(8, 3)
			Me.propertyGrid1.Name = "propertyGrid1"
			Me.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical
			Me.propertyGrid1.Size = New System.Drawing.Size(244, 387)
			Me.propertyGrid1.TabIndex = 1
			' 
			' LayoutButton
			' 
			Me.LayoutButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.LayoutButton.Location = New System.Drawing.Point(8, 491)
			Me.LayoutButton.Name = "LayoutButton"
			Me.LayoutButton.Size = New System.Drawing.Size(244, 23)
			Me.LayoutButton.TabIndex = 2
			Me.LayoutButton.Text = "Layout"
			Me.LayoutButton.UseVisualStyleBackColor = True
'			Me.LayoutButton.Click += New System.EventHandler(Me.LayoutButton_Click);
			' 
			' UpdateDrawingWhileLayouting
			' 
			Me.UpdateDrawingWhileLayouting.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.UpdateDrawingWhileLayouting.Location = New System.Drawing.Point(8, 453)
			Me.UpdateDrawingWhileLayouting.Name = "UpdateDrawingWhileLayouting"
			Me.UpdateDrawingWhileLayouting.Size = New System.Drawing.Size(244, 17)
			Me.UpdateDrawingWhileLayouting.TabIndex = 8
			Me.UpdateDrawingWhileLayouting.Text = "Update drawing while layouting"
			Me.UpdateDrawingWhileLayouting.UseVisualStyleBackColor = True
			' 
			' NSpringLayoutUC
			' 
			Me.Controls.Add(Me.UpdateDrawingWhileLayouting)
			Me.Controls.Add(Me.LayoutButton)
			Me.Controls.Add(Me.propertyGrid1)
			Me.Name = "NSpringLayoutUC"
			Me.Controls.SetChildIndex(Me.propertyGrid1, 0)
			Me.Controls.SetChildIndex(Me.LayoutButton, 0)
			Me.Controls.SetChildIndex(Me.UpdateDrawingWhileLayouting, 0)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' create and configure the spring layout
			m_Layout = New NSpringLayout()

			' hook the iteration completed event
			AddHandler m_Layout.IterationCompleted, AddressOf layout_IterationCompleted

			' select it in the property grid
			propertyGrid1.SelectedObject = m_Layout

			view.BeginInit()
			view.Grid.Visible = False
			view.GlobalVisibility.ShowPorts = False
			view.GlobalVisibility.ShowArrowheads = False
			view.ViewLayout = ViewLayout.Fit

			' init document
			document.BeginInit()
			InitDocument()
			document.EndInit()

			' end view init
			view.EndInit()
		End Sub

		#End Region

		#Region "Event Handlers"

		''' <summary>
		''' Invoked on each successfully completed iteration of the layout
		''' </summary>
		''' <param name="args"></param>
		Private Sub layout_IterationCompleted(ByVal args As NGraphLayoutCancelEventArguments)
			If UpdateDrawingWhileLayouting.Checked Then
				Dim refreshLocked As Boolean = view.LockRefresh
				If refreshLocked Then
					view.LockRefresh = False
				End If

				Dim shapeBodyAdaptor As NShapeBodyAdapter = New NShapeBodyAdapter(document)

				Dim en As IEnumerator(Of NGraphPart) = args.Graph.GetPartsEnumerator()
				Do While en.MoveNext()
					Dim vertex As NGraphVertex = TryCast(en.Current, NGraphVertex)
					If Not vertex Is Nothing Then
						Dim body As NBody2D = TryCast(vertex.Tag, NBody2D)
						shapeBodyAdaptor.UpdateObjectFromBody2D(body)
					End If
				Loop

				document.SizeToContent()

				view.Invalidate()
				view.Update()

				If refreshLocked Then
					view.LockRefresh = True
				End If

				Application.DoEvents()
			End If
		End Sub

		#End Region

		#Region "Implementation"

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


			' layout
			LayoutButton.PerformClick()
		End Sub

		Private Sub InitDocument()
			' we do not need history for this example
			document.HistoryService.Pause()

			CreatePredefinedGraph()

			' resize document to fit all shapes
			LayoutButton.PerformClick()
			document.SizeToContent()
		End Sub

		Private Sub LayoutButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LayoutButton.Click
			' get the shapes to layout
			Dim shapes As NNodeList = document.ActiveLayer.Children(NFilters.Shape2D)

			' create a layout context
			Dim layoutContext As NLayoutContext = New NLayoutContext()
			layoutContext.GraphAdapter = New NShapeGraphAdapter()
			layoutContext.BodyAdapter = New NShapeBodyAdapter(document)
			layoutContext.BodyContainerAdapter = New NDrawingBodyContainerAdapter(document)

			' layout the shapes
			If Not m_Layout Is Nothing Then
				m_Layout.Layout(shapes, layoutContext)
			End If

			' resize document to fit all shapes
			document.SizeToContent()
		End Sub

		#End Region

		#Region "Designer Fields"

		Private propertyGrid1 As System.Windows.Forms.PropertyGrid
		Private WithEvents LayoutButton As Nevron.UI.WinForm.Controls.NButton
		Private UpdateDrawingWhileLayouting As System.Windows.Forms.CheckBox

		#End Region

		#Region "Fields"

		Private m_Layout As NSpringLayout

		#End Region
	End Class
End Namespace