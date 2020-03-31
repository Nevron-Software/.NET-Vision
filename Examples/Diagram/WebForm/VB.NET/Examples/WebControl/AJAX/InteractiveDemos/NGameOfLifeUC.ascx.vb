Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Windows.Forms

Imports Nevron.Dom
Imports Nevron.Diagram
Imports Nevron.Diagram.Batches
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.WebForm
Imports Nevron.UI.WebForm.Controls
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''		Summary description for NGameOfLifeUC.
	''' </summary>
	Public Partial Class NGameOfLifeUC
		Inherits NDiagramExampleUC
		Public Enum CellState
			Alive
			Dead
			JustBorn
			Dying

			PinnedAlive
			PinnedDead
		End Enum

		#Region "Static Configuration Fields and Methods"

		Protected Shared imagePixelWidth As Integer
		Protected Shared imagePixelHeight As Integer
		Protected Shared imagePadding As Integer
		Protected Shared shadowOffset As Integer

		Protected Shared cellPixelWidth As Integer
		Protected Shared cellPixelHeight As Integer
		Protected Shared boardCellCountWidth As Integer
		Protected Shared boardCellCountHeight As Integer

		Protected Shared boardPixelWidth As Integer
		Protected Shared boardPixelHeight As Integer
		Protected Shared boardMarginLeft As Integer
		Protected Shared boardMarginTop As Integer

		Protected Shared centerCellCountX As Integer
		Protected Shared centerCellCountY As Integer

		Protected Shared initialConfigurationCoordinates As Integer()()

		Protected Shared emptyCellFillStyle As NFillStyle
		Protected Shared fullCellFillStyle As NFillStyle
		Protected Shared emptyPinnedCellFillStyle As NFillStyle
		Protected Shared fullPinnedCellFillStyle As NFillStyle

		Protected Shared normalCellStrokeStyle As NStrokeStyle
		Protected Shared highliteCellStrokeStyle As NStrokeStyle

		Protected Shared Sub InitializeConfigurationFields()
			'	initialize sizes
			imagePixelWidth = 420
			imagePixelHeight = 320
			imagePadding = 10
			shadowOffset = 5

			cellPixelWidth = 20
			cellPixelHeight = 20

			'	calculate additional sizes
			boardCellCountWidth = CInt(Fix(Math.Floor(CDbl(imagePixelWidth - 2 * imagePadding) / cellPixelWidth)))
			boardCellCountHeight = CInt(Fix(Math.Floor(CDbl(imagePixelHeight - 2 * imagePadding) / cellPixelHeight)))

			boardPixelWidth = boardCellCountWidth * cellPixelWidth
			boardPixelHeight = boardCellCountHeight * cellPixelHeight
			boardMarginLeft = CInt(Fix(Math.Floor(CDbl(imagePixelWidth - boardPixelWidth) / 2))) - CInt(Fix(Math.Floor(CDbl(shadowOffset / 2))))
			boardMarginTop = CInt(Fix(Math.Floor(CDbl(imagePixelHeight - boardPixelHeight) / 2))) - CInt(Fix(Math.Floor(CDbl(shadowOffset / 2))))

			centerCellCountX = CInt(Fix(Math.Floor(CDbl(boardCellCountWidth) / 2)))
			centerCellCountY = CInt(Fix(Math.Floor(CDbl(boardCellCountHeight) / 2)))

			'	an r-pentamino configuration
			initialConfigurationCoordinates = New Integer()() { New Integer(){centerCellCountX, centerCellCountY - 1}, New Integer(){centerCellCountX + 1, centerCellCountY - 1}, New Integer(){centerCellCountX - 1, centerCellCountY}, New Integer(){centerCellCountX, centerCellCountY}, New Integer(){centerCellCountX, centerCellCountY + 1} }

			'	precache styles
			emptyCellFillStyle = New NColorFillStyle(Color.White)
			fullCellFillStyle = New NColorFillStyle(Color.Red)
			emptyPinnedCellFillStyle = New NColorFillStyle(Color.LightGray)
			fullPinnedCellFillStyle = New NColorFillStyle(Color.Brown)

			normalCellStrokeStyle = New NStrokeStyle(New NLength(1f, NGraphicsUnit.Pixel), Color.Black)
			highliteCellStrokeStyle = New NStrokeStyle(New NLength(2f, NGraphicsUnit.Pixel), Color.Blue)
		End Sub

		#End Region

		#Region "Fields"

		Protected factory As NBasicShapesFactory

		#End Region

		#Region "Event Handlers"

		Protected Sub NDrawingView1_QueryAjaxTools(ByVal sender As Object, ByVal e As EventArgs)
			'	configure the client side tools
			NDrawingView1.AjaxTools.Add(New NAjaxMouseClickCallbackTool(True))
			NDrawingView1.AjaxTools.Add(New NAjaxMouseDoubleClickCallbackTool(True))
			NDrawingView1.AjaxTools.Add(New NAjaxMouseMoveCallbackTool(True))
			NDrawingView1.AjaxTools.Add(New NAjaxMouseDownCallbackTool(False))
			NDrawingView1.AjaxTools.Add(New NAjaxMouseUpCallbackTool(False))
		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			' init configuration
			InitializeConfigurationFields()

			NDrawingView1.HttpHandlerCallback = New CustomHttpHandlerCallback()

			If NDrawingView1.RequiresInitialization Then
				factory = New NBasicShapesFactory(NDrawingView1.Document)

				' begin view init
				NDrawingView1.ViewLayout = CanvasLayout.Normal
				NDrawingView1.ScaleX = 1
				NDrawingView1.ScaleY = 1
				NDrawingView1.ViewportOrigin = New NPointF()

				' init document
				NDrawingView1.Document.HistoryService.Stop()
				NDrawingView1.Document.BeginInit()
				InitDocument()
				NDrawingView1.Document.EndInit()
			End If
		End Sub

		#End Region

		#Region "Nested Classes"

		<Serializable> _
		Public Class CustomHttpHandlerCallback
			Inherits NHttpHandlerCallback
			#Region "INHttpHandlerCallback Members"

			Public Overrides Sub OnAsyncClick(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				' init configuration
				InitializeConfigurationFields()

				'	toggle the underlying cell
				Dim cell As NRectangleShape = HitTestCell(state, args)
				If cell Is Nothing Then
					Return
				End If

				If CType(cell.Tag, CellState) = CellState.Alive Then
					cell.Tag = CellState.Dead
				ElseIf CType(cell.Tag, CellState) = CellState.Dead Then
					cell.Tag = CellState.Alive
				Else
					Return
				End If

				UpdateStyles(state)
			End Sub

			Public Overrides Sub OnAsyncDoubleClick(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				' init configuration
				InitializeConfigurationFields()

				'	clear the board
				Clear(state)
			End Sub

			Public Overrides Sub OnAsyncMouseDown(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				' init configuration
				InitializeConfigurationFields()

				'	toggle the underlying cell
				Dim cell As NRectangleShape = HitTestCell(state, args)
				If cell Is Nothing Then
					Return
				End If

				If CType(cell.Tag, CellState) = CellState.Alive Then
					cell.Tag = CellState.PinnedAlive
				ElseIf CType(cell.Tag, CellState) = CellState.Dead Then
					cell.Tag = CellState.PinnedDead
				Else
					Return
				End If

				UpdateStyles(state)
			End Sub

			Public Overrides Sub OnAsyncMouseUp(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				' init configuration
				InitializeConfigurationFields()

				'	toggle the underlying cell
				Dim cell As NRectangleShape = HitTestCell(state, args)
				If cell Is Nothing Then
					Return
				End If

				If CType(cell.Tag, CellState) = CellState.PinnedAlive Then
					cell.Tag = CellState.Alive
				ElseIf CType(cell.Tag, CellState) = CellState.PinnedDead Then
					cell.Tag = CellState.Dead
				Else
					Return
				End If

				UpdateStyles(state)
			End Sub

			Public Overrides Sub OnAsyncMouseMove(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				' init configuration
				InitializeConfigurationFields()

				'	highlight underlying cell
				Dim cell As NRectangleShape = HitTestCell(state, args)
				If cell Is Nothing Then
					Return
				End If

				HighliteCell(state, cell)
			End Sub

			Public Overrides Sub OnAsyncRefresh(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As EventArgs)
				' init configuration
				InitializeConfigurationFields()

				IterateOneTurn(state)
			End Sub

			#End Region

			#Region "Implementation"

			Protected Function HitTestCell(ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs) As NRectangleShape
				Dim diagramState As NDiagramSessionStateObject = TryCast(state, NDiagramSessionStateObject)
				Dim nodes As NNodeList = diagramState.HitTest(args)
				Dim shapes As NNodeList = nodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D)
				For Each node As NShape In shapes
					If Not(TypeOf node.Tag Is CellState) Then
						Continue For
					End If
					Return TryCast(node, NRectangleShape)
				Next node

				Return Nothing
			End Function

			Protected Sub IterateOneTurn(ByVal state As NStateObject)
				Dim diagramState As NDiagramSessionStateObject = TryCast(state, NDiagramSessionStateObject)

				'	obtain/cache life map, create an initial configuration when accessed for the first time
				Dim map As NRectangleShape(,) = GetLifeMap(state)
				If m_HasReinitialized Then
					'	remove the mouse move highlight
					ClearHighlitsHormatting(map)

					'	reflect life state to rectangle styles
					UpdateStyles(state)
					Return
				End If

				'	mark dying cells and cells to be born
				Dim x As Integer = 0
				Do While x < boardCellCountWidth
					Dim y As Integer = 0
					Do While y < boardCellCountHeight
						Dim neighboursCount As Integer = CountLiveNeighbours(x, y, map)
						Select Case CType(map(x, y).Tag, CellState)
							Case CellState.Dead
								If neighboursCount = 3 Then
									map(x, y).Tag = CellState.JustBorn
								End If

							Case CellState.Alive
								If neighboursCount < 2 OrElse neighboursCount > 3 Then
									map(x, y).Tag = CellState.Dying
								End If
						End Select
						y += 1
					Loop
					x += 1
				Loop

				'	commit death/birth actions
				x = 0
				Do While x < boardCellCountWidth
					Dim y As Integer = 0
					Do While y < boardCellCountHeight
						Select Case CType(map(x, y).Tag, CellState)
							Case CellState.Dying
								map(x, y).Tag = CellState.Dead

							Case CellState.JustBorn
								map(x, y).Tag = CellState.Alive
						End Select
						y += 1
					Loop
					x += 1
				Loop

				'	remove the mouse move highlight
				ClearHighlitsHormatting(map)

				'	reflect life state to rectangle styles
				UpdateStyles(state)
			End Sub

			Protected Sub UpdateStyles(ByVal state As NStateObject)
				Dim diagramState As NDiagramSessionStateObject = TryCast(state, NDiagramSessionStateObject)

				'	obtain/cache life map, create an initial configuration when accessed for the first time
				Dim map As NRectangleShape(,) = GetLifeMap(state)

				'	reflect life state to rectangle styles
				Dim x As Integer = 0
				Do While x < boardCellCountWidth
					Dim y As Integer = 0
					Do While y < boardCellCountHeight
						Select Case CType(map(x, y).Tag, CellState)
							Case CellState.Dead
								map(x, y).Style.FillStyle = emptyCellFillStyle

							Case CellState.Alive
								map(x, y).Style.FillStyle = fullCellFillStyle
							Case CellState.PinnedDead
								map(x, y).Style.FillStyle = emptyPinnedCellFillStyle

							Case CellState.PinnedAlive
								map(x, y).Style.FillStyle = fullPinnedCellFillStyle
							Case Else
								System.Diagnostics.Debug.Fail("No intermediate cell states expected")
						End Select
						y += 1
					Loop
					x += 1
				Loop

				diagramState.Document.RefreshAllViews()
			End Sub

			Protected Sub Clear(ByVal state As NStateObject)
				Dim diagramState As NDiagramSessionStateObject = TryCast(state, NDiagramSessionStateObject)

				'	obtain/cache life map, create an initial configuration when accessed for the first time
				Dim map As NRectangleShape(,) = GetLifeMap(state)

				'	clear all live cells
				ClearBoard(map)

				'	reflect life state to rectangle styles
				UpdateStyles(state)
			End Sub

			Protected Function CountLiveNeighbours(ByVal x As Integer, ByVal y As Integer, ByVal map As NRectangleShape(,)) As Integer
				'	define a perpetual board
				Dim col0 As Integer = x - 1, col1 As Integer = x, col2 As Integer = x + 1
				Dim row0 As Integer = y - 1, row1 As Integer = y, row2 As Integer = y + 1
				If col0 < 0 Then
					col0 = boardCellCountWidth - 1
				End If
				If col2 >= boardCellCountWidth Then
					col2 = 0
				End If
				If row0 < 0 Then
					row0 = boardCellCountHeight - 1
				End If
				If row2 >= boardCellCountHeight Then
					row2 = 0
				End If

				Dim result As Integer = 0
				result += CellAliveAsInt(col0, row0, map)
				result += CellAliveAsInt(col1, row0, map)
				result += CellAliveAsInt(col2, row0, map)

				result += CellAliveAsInt(col0, row1, map)
				result += CellAliveAsInt(col2, row1, map)

				result += CellAliveAsInt(col0, row2, map)
				result += CellAliveAsInt(col1, row2, map)
				result += CellAliveAsInt(col2, row2, map)

				Return result
			End Function

			Protected Function CellAliveAsInt(ByVal x As Integer, ByVal y As Integer, ByVal map As NRectangleShape(,)) As Integer
				If (CType(map(x, y).Tag, CellState) = CellState.Alive OrElse CType(map(x, y).Tag, CellState) = CellState.Dying OrElse CType(map(x, y).Tag, CellState) = CellState.PinnedAlive) Then
					Return 1
				Else
					Return 0
				End If
			End Function

			Protected Function GetLifeMap(ByVal state As NStateObject) As NRectangleShape(,)
				Dim diagramState As NDiagramSessionStateObject = TryCast(state, NDiagramSessionStateObject)
				m_Map = New NRectangleShape(boardCellCountWidth - 1, boardCellCountHeight - 1){}
				Dim cellsGroup As NGroup = TryCast(diagramState.Document.ActiveLayer.GetChildByName("cellsGroup", 0), NGroup)
				Dim children As NShapeCollection = cellsGroup.Shapes
				If Not m_MapShapeIds Is Nothing Then
					m_HasReinitialized = False
					Dim x As Integer = 0
					Do While x < boardCellCountWidth
						Dim y As Integer = 0
						Do While y < boardCellCountHeight
							m_Map(x, y) = TryCast(children.GetChildFromUniqueId(m_MapShapeIds(x, y)), NRectangleShape)
							y += 1
						Loop
						x += 1
					Loop
					Return m_Map
				End If

				m_MapShapeIds = New Guid(boardCellCountWidth - 1, boardCellCountHeight - 1){}
				For Each cell As NRectangleShape In children
					Dim tokens As String() = cell.Name.Split(New Char() { " "c, ","c }, StringSplitOptions.RemoveEmptyEntries)
					Dim x As Integer = Integer.Parse(tokens(0))
					Dim y As Integer = Integer.Parse(tokens(1))
					m_Map(x, y) = cell
					m_MapShapeIds(x, y) = cell.UniqueId
				Next cell
				ApplyConfigurationCoordinates(m_Map, initialConfigurationCoordinates)
				m_HasReinitialized = True
				Return m_Map
			End Function

			Protected Sub ApplyConfigurationCoordinates(ByVal map As NRectangleShape(,), ByVal configurationCoordinates As Integer()())
				ClearBoard(map)
				Dim i As Integer = 0
				Do While i < configurationCoordinates.Length
					Dim coords As Integer() = configurationCoordinates(i)
					map(coords(0), coords(1)).Tag = CellState.Alive
					i += 1
				Loop
			End Sub

			Protected Sub ClearBoard(ByVal map As NRectangleShape(,))
				For x As Integer = 0 To boardCellCountWidth - 1
					Dim y As Integer = 0
					Do While y < boardCellCountHeight
						map(x, y).Tag = CellState.Dead

						y += 1
					Loop
				Next x
			End Sub

			Protected Sub HighliteCell(ByVal state As NStateObject, ByVal cell As NRectangleShape)
				Dim diagramState As NDiagramSessionStateObject = TryCast(state, NDiagramSessionStateObject)

				'	obtain/cache life map, create an initial configuration when accessed for the first time
				Dim map As NRectangleShape(,) = GetLifeMap(state)

				ClearHighlitsHormatting(map)
				cell.Style.StrokeStyle = highliteCellStrokeStyle

				diagramState.Document.RefreshAllViews()
			End Sub

			Protected Sub ClearHighlitsHormatting(ByVal map As NRectangleShape(,))
				For x As Integer = 0 To boardCellCountWidth - 1
					Dim y As Integer = 0
					Do While y < boardCellCountHeight
						map(x, y).Style.StrokeStyle = normalCellStrokeStyle

						y += 1
					Loop
				Next x
			End Sub

			#End Region

			#Region "Fields"

			Public m_HasReinitialized As Boolean = False

			<NonSerialized> _
			Public m_Map As NRectangleShape(,) = Nothing

			Public m_MapShapeIds As Guid(,) = Nothing

			#End Region
		End Class

		#End Region

		#Region "Implementation"

		Private Sub InitDocument()
			' configure the document
			NDrawingView1.Document.Bounds = New NRectangleF(0, 0, imagePixelWidth, imagePixelHeight)
			NDrawingView1.Document.ShadowsZOrder = ShadowsZOrder.BehindElement
			NDrawingView1.Document.GraphicsSettings.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias
			NDrawingView1.Document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
			NDrawingView1.Document.GraphicsSettings.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None
			NDrawingView1.Document.MeasurementUnit = NGraphicsUnit.Pixel
			NDrawingView1.Document.DrawingScaleMode = DrawingScaleMode.NoScale

			NDrawingView1.Document.BackgroundStyle.FrameStyle.Visible = False

			'	shapes
			Dim backgroundFrame As NRectangleShape = TryCast(factory.CreateShape(CInt(Fix(BasicShapes.Rectangle))), NRectangleShape)
			backgroundFrame.Bounds = New NRectangleF(boardMarginLeft, boardMarginTop, boardPixelWidth, boardPixelHeight)
			backgroundFrame.Style.StrokeStyle = New NStrokeStyle(New NLength(1f, NGraphicsUnit.Pixel), Color.Black)
			backgroundFrame.Style.FillStyle = New NColorFillStyle(Color.White)
			backgroundFrame.Style.ShadowStyle = New NShadowStyle(ShadowType.GaussianBlur, Color.FromArgb(65, Color.Black), New NPointL(shadowOffset, shadowOffset), 1, New NLength(shadowOffset*2))
			backgroundFrame.Name = "background"

			NDrawingView1.Document.ActiveLayer.AddChild(backgroundFrame)

			Dim cells As NNodeList = New NNodeList()
			For x As Integer = 0 To boardCellCountWidth - 1
				Dim y As Integer = 0
				Do While y < boardCellCountHeight
					cells.Add(CreateEmptyCell(x, y))

					y += 1
				Loop
			Next x

			Dim cellsGroup As NGroup
			Dim batchGroup As NBatchGroup = New NBatchGroup(NDrawingView1.Document)
			batchGroup.Build(cells)
			Dim result As NTransactionResult = batchGroup.Group(NDrawingView1.Document.ActiveLayer, True, cellsGroup)

			cellsGroup.Name = "cellsGroup"
		End Sub

		Protected Function CreateEmptyCell(ByVal x As Integer, ByVal y As Integer) As NRectangleShape
			Dim cell As NRectangleShape = TryCast(factory.CreateShape(CInt(Fix(BasicShapes.Rectangle))), NRectangleShape)
			cell.Bounds = New NRectangleF(boardMarginLeft + cellPixelWidth * x, boardMarginTop + cellPixelWidth * y, cellPixelWidth, cellPixelHeight)
			cell.Style.StrokeStyle = normalCellStrokeStyle
			cell.Style.FillStyle = emptyCellFillStyle
			cell.Style.ShadowStyle = Nothing
			cell.Name = String.Format("{0}, {1}", x, y)
			cell.Tag = CellState.Dead

			NDrawingView1.Document.ActiveLayer.AddChild(cell)
			Return cell
		End Function

		#End Region
	End Class
End Namespace
