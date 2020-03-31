Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing

Imports Nevron.Diagram
Imports Nevron.Diagram.Batches
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.Dom
Imports Nevron.Filters
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''	Summary description for NExpandCollapseDecoratorUC.
	''' </summary>
	Public Partial Class NExpandCollapseDecoratorUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			' begin view init
			MyBase.DefaultGridOrigin = New NPointF(30, 30)
			MyBase.DefaultGridCellSize = New NSizeF(100, 50)
			MyBase.DefaultGridSpacing = New NSizeF(50, 40)

			' begin view init
			NDrawingView1.ViewLayout = CanvasLayout.Fit

			' init document
			NDrawingView1.Document.BeginInit()
			InitDocument()
			NDrawingView1.Document.EndInit()
		End Sub

		#Region "Implementation"

		Private Sub InitDocument()
			Dim document As NDrawingDocument = NDrawingView1.Document

			Dim networkShapes As NSimpleNetworkShapesFactory = New NSimpleNetworkShapesFactory()
			networkShapes.DefaultSize = New NSizeF(50, 50)
			Dim i As Integer

			' create computers
			For i = 0 To 8
				Dim computer As NShape = networkShapes.CreateShape(SimpleNetworkShapes.Computer)
				Select Case i Mod 3
					Case 0
						computer.Location = New NPointF(10, 10)
					Case 1
						computer.Location = New NPointF(110, 10)
					Case 2
						computer.Location = New NPointF(75, 110)
				End Select

				document.ActiveLayer.AddChild(computer)
			Next i

			' link the computers
			For i = 0 To 2
				Dim link As NLineShape = New NLineShape()
				link.StyleSheetName = NDR.NameConnectorsStyleSheet
				document.ActiveLayer.AddChild(link)

				If i = 0 Then
					link.FromShape = CType(document.ActiveLayer.GetChildAt(8), NShape)
					link.ToShape = CType(document.ActiveLayer.GetChildAt(0), NShape)
				Else
					link.FromShape = CType(document.ActiveLayer.GetChildAt(i * 3 - 1), NShape)
					link.ToShape = CType(document.ActiveLayer.GetChildAt(i * 3), NShape)
				End If
			Next i

			' create three groups
			Dim groupNodes1 As NNodeList = New NNodeList()
			Dim batchGroup1 As NBatchGroup = New NBatchGroup(document)
			groupNodes1.Add(document.ActiveLayer.GetChildAt(0))
			groupNodes1.Add(document.ActiveLayer.GetChildAt(1))
			groupNodes1.Add(document.ActiveLayer.GetChildAt(2))
			batchGroup1.Build(groupNodes1)

			Dim groupNodes2 As NNodeList = New NNodeList()
			Dim batchGroup2 As NBatchGroup = New NBatchGroup(document)
			groupNodes2.Add(document.ActiveLayer.GetChildAt(3))
			groupNodes2.Add(document.ActiveLayer.GetChildAt(4))
			groupNodes2.Add(document.ActiveLayer.GetChildAt(5))
			batchGroup2.Build(groupNodes2)

			Dim groupNodes3 As NNodeList = New NNodeList()
			Dim batchGroup3 As NBatchGroup = New NBatchGroup(document)
			groupNodes3.Add(document.ActiveLayer.GetChildAt(6))
			groupNodes3.Add(document.ActiveLayer.GetChildAt(7))
			groupNodes3.Add(document.ActiveLayer.GetChildAt(8))
			batchGroup3.Build(groupNodes3)

			Dim groups As NGroup() = New NGroup(2){}
			batchGroup1.Group(document.ActiveLayer, False, groups(0))
			batchGroup2.Group(document.ActiveLayer, False, groups(1))
			batchGroup3.Group(document.ActiveLayer, False, groups(2))

			' add expand-collapse decorator and frame decorator to each group
			i = 0
			Do While i < groups.Length
				Dim group As NGroup = groups(i)

				' because groups are created after the link we want to ensure
				' that they are behind so that the links are not obscured
				group.SendToBack()

				' create the decorators collection
				group.CreateShapeElements(ShapeElementsMask.Decorators)

				' create a frame decorator
				' we want the user to be able to select the shape when the frame is hit
				Dim frameDecorator As NFrameDecorator = New NFrameDecorator()
				frameDecorator.ShapeHitTestable = True
				frameDecorator.Header.Text = "Network " & i.ToString()
				group.Decorators.AddChild(frameDecorator)

				' create an expand collapse decorator
				Dim expandCollapseDecorator As NExpandCollapseDecorator = New NExpandCollapseDecorator()
				group.Decorators.AddChild(expandCollapseDecorator)

				' update the model bounds so that the computeres 
				' are inside the specified padding
				group.Padding = New Nevron.Diagram.NMargins(5, 5, 30, 5)
				group.UpdateModelBounds()
				group.AutoUpdateModelBounds = True
				i += 1
			Loop

			' layout them with a table layout
			Dim context As NLayoutContext = New NLayoutContext()
			context.GraphAdapter = New NShapeGraphAdapter()
			context.BodyAdapter = New NShapeBodyAdapter(document)
			context.BodyContainerAdapter = New NDrawingBodyContainerAdapter(document)

			Dim layout As NTableLayout = New NTableLayout()
			layout.ConstrainMode = CellConstrainMode.Ordinal
			layout.MaxOrdinal = 2
			layout.HorizontalSpacing = 50
			layout.VerticalSpacing = 50
			layout.Layout(document.ActiveLayer.Children(Nothing), context)

			document.SizeToContent(NSizeF.Empty, document.AutoBoundsPadding)
			document.AutoBoundsMode = AutoBoundsMode.AutoSizeToContent
		End Sub

		#End Region

		#Region "Event Handlers"

		Protected Sub NDrawingView1_QueryAjaxTools(ByVal sender As Object, ByVal e As EventArgs)
			' Configure the client side tools
			NDrawingView1.AjaxTools.Add(New NAjaxMouseClickCallbackTool(True))
		End Sub
		Protected Sub NDrawingView1_AsyncClick(ByVal sender As Object, ByVal e As EventArgs)
			Dim args As NCallbackMouseEventArgs = TryCast(e, NCallbackMouseEventArgs)

			Dim nodes As NNodeList = NDrawingView1.HitTest(args)
			Dim decorators As NNodeList = nodes.Filter(DecoratorFilter)
			If decorators.Count > 0 Then
				CType(decorators(0), NExpandCollapseDecorator).ToggleState()
			End If

			NDrawingView1.Document.SmartRefreshAllViews()
		End Sub
		Protected Sub NDrawingView1_AsyncCustomCommand(ByVal sender As Object, ByVal e As EventArgs)
			Dim args As NCallbackCustomCommandArgs = TryCast(e, NCallbackCustomCommandArgs)
			Dim command As NCallbackCommand = args.Command
			Dim value As String = command.Arguments("value").ToString()

			Dim decorators As NNodeList = NDrawingView1.Document.ActiveLayer.Descendants(DecoratorFilter, -1)
			Dim i As Integer, count As Integer = decorators.Count

			Select Case command.Name
				Case "background"
					Dim background As ToggleDecoratorBackgroundShape = CType(System.Enum.Parse(GetType(ToggleDecoratorBackgroundShape), value), ToggleDecoratorBackgroundShape)
					i = 0
					Do While i < count
						CType(decorators(i), NToggleDecorator).Background.Shape = background
						i += 1
					Loop

					m_bClientSideRedrawRequired = True

				Case "symbol"
					Dim symbol As ToggleDecoratorSymbolShape = CType(System.Enum.Parse(GetType(ToggleDecoratorSymbolShape), value), ToggleDecoratorSymbolShape)
					i = 0
					Do While i < count
						CType(decorators(i), NToggleDecorator).Symbol.Shape = symbol
						i += 1
					Loop

					m_bClientSideRedrawRequired = True

				Case "position"
					Dim alignment As NContentAlignment
					Dim offset As NSizeF

					If value = "Left" Then
						alignment = New NContentAlignment(ContentAlignment.TopLeft)
						offset = New NSizeF(11, 11)
					Else
						alignment = New NContentAlignment(ContentAlignment.TopRight)
						offset = New NSizeF(-11, 11)
					End If

					i = 0
					Do While i < count
						Dim decorator As NToggleDecorator = CType(decorators(i), NToggleDecorator)
						decorator.Alignment = alignment
						decorator.Offset = offset
						i += 1
					Loop

					m_bClientSideRedrawRequired = True
			End Select
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

		#Region "Constants"

		Private Shared ReadOnly DecoratorFilter As NFilter = New NInstanceOfTypeFilter(GetType(NExpandCollapseDecorator))

		#End Region
	End Class
End Namespace