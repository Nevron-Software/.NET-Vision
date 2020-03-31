Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Drawing
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Windows.Forms

Imports Nevron.Dom
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.Batches
Imports Nevron.Diagram.WebForm
Imports Nevron.UI.WebForm.Controls
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''		Summary description for NNumberPuzzleUC.
	''' </summary>
	Public Partial Class NNumberPuzzleUC
		Inherits NDiagramExampleUC
		#Region "Static Configuration Fields and Methods"

		Protected Shared imagePadding As Integer
		Protected Shared imagePixelWidth As Integer
		Protected Shared imagePixelHeight As Integer
		Protected Shared shadowOffset As Integer

		Protected Shared cellPixelWidth As Integer
		Protected Shared cellPixelHeight As Integer

		Protected Shared boardPadding As Integer
		Protected Shared boardPixelWidth As Integer
		Protected Shared boardPixelHeight As Integer
		Protected Shared boardMarginLeft As Integer
		Protected Shared boardMarginTop As Integer

		Protected Shared emptyCellFillStyle As NFillStyle
		Protected Shared completeCellFillStyle As NFillStyle
		Protected Shared hoverAllowedCellFillStyle As NFillStyle
		Protected Shared hoverDeniedCellFillStyle As NFillStyle
		Protected Shared normalCellStrokeStyle As NStrokeStyle

'INSTANT VB NOTE: The parameter boardCellCount was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
		Protected Shared Sub InitializeConfigurationFields(ByVal boardCellCount_Renamed As Integer)
			'	initialize sizes
			imagePadding = 10
			imagePixelWidth = 420
			imagePixelHeight = 320

			shadowOffset = 4
			boardPadding = 10

			'	calculate additional sizes
			boardPixelWidth = CInt(Fix(Math.Floor(CDbl((imagePixelWidth - imagePadding - 2 * boardPadding)))))
			boardPixelHeight = CInt(Fix(Math.Floor(CDbl((imagePixelHeight - imagePadding - 2 * boardPadding)))))

			boardPixelWidth = Math.Min(boardPixelWidth, boardPixelHeight)
			boardPixelHeight = Math.Min(boardPixelWidth, boardPixelHeight)

			cellPixelWidth = CInt(Fix(Math.Floor(CDbl(boardPixelWidth / boardCellCount_Renamed))))
			cellPixelHeight = CInt(Fix(Math.Floor(CDbl(boardPixelHeight / boardCellCount_Renamed))))

			boardPixelWidth = cellPixelWidth * boardCellCount_Renamed + 2 * boardPadding
			boardPixelHeight = cellPixelHeight * boardCellCount_Renamed + 2 * boardPadding

			boardMarginLeft = CInt(Fix(Math.Floor(CDbl(imagePixelWidth - boardPixelWidth) / 2)))
			boardMarginTop = CInt(Fix(Math.Floor(CDbl(imagePixelHeight - boardPixelHeight) / 2)))

			'	precache styles
			emptyCellFillStyle = New NColorFillStyle(Color.WhiteSmoke)
			completeCellFillStyle = New NColorFillStyle(Color.PeachPuff)

			hoverDeniedCellFillStyle = New NGradientFillStyle(GradientStyle.FromCenter, GradientVariant.Variant1, Color.Navy, Color.White)
			hoverAllowedCellFillStyle = New NGradientFillStyle(GradientStyle.FromCenter, GradientVariant.Variant1, Color.LimeGreen, Color.White)

			normalCellStrokeStyle = New NStrokeStyle(New NLength(1f, NGraphicsUnit.Pixel), Color.White)
		End Sub

		#End Region

		#Region "Properties"

		Public Property BoardCellCount() As Integer
			Get
				If Session(NDrawingView1.InstanceGuid.ToString() & "-boardCellCount") Is Nothing Then
					Return 0
				End If
				Return CInt(Fix(Session(NDrawingView1.InstanceGuid.ToString() & "-boardCellCount")))
			End Get
			Set
				Session(NDrawingView1.InstanceGuid.ToString() & "-boardCellCount") = Value
			End Set
		End Property

		#End Region

		#Region "Event Handlers"

		Protected Sub NDrawingView1_QueryAjaxTools(ByVal sender As Object, ByVal e As EventArgs)
			'	configure the client side tools
			NDrawingView1.AjaxTools.Add(New NAjaxMouseClickCallbackTool(True))
			NDrawingView1.AjaxTools.Add(New NAjaxMouseDoubleClickCallbackTool(False))
			NDrawingView1.AjaxTools.Add(New NAjaxMouseMoveCallbackTool(True))
			NDrawingView1.AjaxTools.Add(New NAjaxMouseDownCallbackTool(False))
			NDrawingView1.AjaxTools.Add(New NAjaxMouseUpCallbackTool(False))
		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If BoardCellCount = 0 Then
				BoardCellCount = 5
			End If

			' init configuration
			InitializeConfigurationFields(BoardCellCount)

			NDrawingView1.HttpHandlerCallback = New CustomHttpHandlerCallback()

			If NDrawingView1.RequiresInitialization Then
				' configure advanced AJAX oproperties
				' enqueue 3 subseqent clicks for better usability
				NDrawingView1.AsyncClickEventQueueLength = 3

				' begin view init
				NDrawingView1.ViewLayout = CanvasLayout.Normal
				NDrawingView1.ScaleX = 1
				NDrawingView1.ScaleY = 1
				NDrawingView1.ViewportOrigin = New NPointF()

				' init document
				NDrawingView1.Document.HistoryService.Stop()
				NDrawingView1.Document.BeginInit()
				InitDocument(NDrawingView1.Document, NDrawingView1.InstanceGuid.ToString(), BoardCellCount)
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
				InitializeConfigurationFields(GetBoardCellCount(state))

				' get the shape under the cursor
				Dim cell As NRectangleShape = HitTestCell(state, args)
				If cell Is Nothing Then
					Return
				End If

				Dim clickedCoords As Point = GetClickedCellCoords(state, cell)
				Dim emptyCoords As Point = GetEmptyCellCoords(state)

				Dim canSwap As Boolean = TestCanSwap(clickedCoords, emptyCoords)
				If (Not canSwap) Then
					Return
				End If

				MoveCell(state, cell, clickedCoords)

				UpdateStyles(state, Nothing)
			End Sub

			Public Overrides Sub OnAsyncDoubleClick(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				' init configuration
				InitializeConfigurationFields(GetBoardCellCount(state))

				' reinitialize the configuration and the scene
				InitializeConfigurationFields(GetBoardCellCount(state))
				Dim diagramState As NDiagramSessionStateObject = TryCast(state, NDiagramSessionStateObject)
				InitDocument(diagramState.Document, diagramState.StateId, GetBoardCellCount(state))
				UpdateStyles(state, Nothing)
			End Sub

			Public Overrides Sub OnAsyncMouseDown(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				' init configuration
				InitializeConfigurationFields(GetBoardCellCount(state))

				' increase board cells count
				Dim curentBoardCellCount As Integer = GetBoardCellCount(state)
				If curentBoardCellCount >= 7 Then
					Return
				End If

				curentBoardCellCount += 1
				SetBoardCellCount(state, curentBoardCellCount)

				' reinitialize the configuration and the scene
				InitializeConfigurationFields(curentBoardCellCount)
				Dim diagramState As NDiagramSessionStateObject = TryCast(state, NDiagramSessionStateObject)
				InitDocument(diagramState.Document, diagramState.StateId, GetBoardCellCount(state))
				UpdateStyles(state, Nothing)
			End Sub

			Public Overrides Sub OnAsyncMouseMove(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				' init configuration
				InitializeConfigurationFields(GetBoardCellCount(state))

				Dim cell As NRectangleShape = HitTestCell(state, args)
				If cell Is Nothing Then
					Return
				End If

				UpdateStyles(state, cell)
			End Sub

			Public Overrides Sub OnAsyncMouseUp(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs)
				' init configuration
				InitializeConfigurationFields(GetBoardCellCount(state))

				' decrease board cells count
				Dim curentBoardCellCount As Integer = GetBoardCellCount(state)
				If curentBoardCellCount <= 2 Then
					Return
				End If

				curentBoardCellCount -= 1
				SetBoardCellCount(state, curentBoardCellCount)

				' reinitialize the configuration and the scene
				InitializeConfigurationFields(curentBoardCellCount)
				Dim diagramState As NDiagramSessionStateObject = TryCast(state, NDiagramSessionStateObject)
				InitDocument(diagramState.Document, diagramState.StateId, GetBoardCellCount(state))
				UpdateStyles(state, Nothing)
			End Sub

			#End Region

			#Region "Implementation"

			Protected Function HitTestCell(ByVal state As NStateObject, ByVal args As NCallbackMouseEventArgs) As NRectangleShape
				Dim diagramState As NDiagramSessionStateObject = TryCast(state, NDiagramSessionStateObject)
				Dim nodes As NNodeList = diagramState.HitTest(args)
				Dim shapes As NNodeList = nodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D)
				For Each node As NShape In shapes
					If Not(TypeOf node.Tag Is Integer) Then
						Continue For
					End If
					Return TryCast(node, NRectangleShape)
				Next node

				Return Nothing
			End Function

			Protected Function GetClickedCellCoords(ByVal state As NStateObject, ByVal cell As NRectangleShape) As Point
				Return CType(GetGrid(state)(New Point(CInt(Fix(cell.Bounds.X)), CInt(Fix(cell.Bounds.Y)))), Point)
			End Function

			Protected Function GetAllCells(ByVal state As NStateObject) As NNodeList
				Dim diagramState As NDiagramSessionStateObject = TryCast(state, NDiagramSessionStateObject)

				Dim list As NNodeList = New NNodeList()
				Dim cellsGroup As NGroup = TryCast(diagramState.Document.ActiveLayer.GetChildByName("cellsGroup", 0), NGroup)
				For Each node As INNode In cellsGroup.Shapes
					list.Add(node)
				Next node

				Return list
			End Function

			Protected Function TestCanSwap(ByVal clickedCoords As Point, ByVal emptyCoords As Point) As Boolean
				Return ((clickedCoords.X = emptyCoords.X - 1 AndAlso clickedCoords.Y = emptyCoords.Y) OrElse (clickedCoords.X = emptyCoords.X + 1 AndAlso clickedCoords.Y = emptyCoords.Y) OrElse (clickedCoords.X = emptyCoords.X AndAlso clickedCoords.Y = emptyCoords.Y - 1) OrElse (clickedCoords.X = emptyCoords.X AndAlso clickedCoords.Y = emptyCoords.Y + 1))
			End Function

			Protected Function TestComplete(ByVal state As NStateObject) As Boolean
				Dim grid As Hashtable = GetGrid(state)

				Dim allCells As NNodeList = GetAllCells(state)
				Dim i As Integer = 0
				Do While i < allCells.Count
					Dim cell As NRectangleShape = TryCast(allCells(i), NRectangleShape)
					Dim coords As Point = CType(grid(New Point(CInt(Fix(cell.Bounds.X)), CInt(Fix(cell.Bounds.Y)))), Point)
					Dim expectedNumber As Integer = coords.X + coords.Y * GetBoardCellCount(state) + 1
					If expectedNumber <> CInt(Fix(cell.Tag)) Then
						Return False
					End If
					i += 1
				Loop
				Return True
			End Function

			Protected Sub MoveCell(ByVal state As NStateObject, ByVal cell As NRectangleShape, ByVal clickedCoords As Point)
				Dim emptyCellPixelCoords As Point = GetEmptyCellPixelCoords(state)

				'	move the empty cell
				SetEmptyCellPixelCoords(state, New Point(CInt(Fix(cell.Bounds.X)), CInt(Fix(cell.Bounds.Y))))
				SetEmptyCellCoords(state, clickedCoords)

				'	move the clicked cell
				cell.Bounds = New NRectangleF(emptyCellPixelCoords.X, emptyCellPixelCoords.Y, cell.Bounds.Width, cell.Bounds.Height)
			End Sub

			Protected Sub UpdateStyles(ByVal state As NStateObject, ByVal hoverCell As NRectangleShape)
				Dim isCompleted As Boolean = TestComplete(state)

				Dim diagramState As NDiagramSessionStateObject = TryCast(state, NDiagramSessionStateObject)

				Dim allCells As NNodeList = GetAllCells(state)
				Dim i As Integer = 0
				Do While i < allCells.Count
					Dim cell As NRectangleShape = TryCast(allCells(i), NRectangleShape)
					If isCompleted Then
						cell.Style.FillStyle = completeCellFillStyle
					Else
						If hoverCell Is Nothing OrElse hoverCell.UniqueId <> cell.UniqueId Then
							cell.Style.FillStyle = emptyCellFillStyle
						ElseIf TestCanSwap(GetClickedCellCoords(state, cell), GetEmptyCellCoords(state)) Then
							cell.Style.FillStyle = hoverAllowedCellFillStyle
						Else
							cell.Style.FillStyle = hoverDeniedCellFillStyle
						End If
					End If
					i += 1
				Loop

				diagramState.Document.RefreshAllViews()
			End Sub


			Protected Function GetEmptyCellCoords(ByVal state As NStateObject) As Point
				Return CType(System.Web.HttpContext.Current.Session(state.StateId & "-emptyCellCoords"), Point)
			End Function

			Protected Sub SetEmptyCellCoords(ByVal state As NStateObject, ByVal value As Point)
				System.Web.HttpContext.Current.Session(state.StateId & "-emptyCellCoords") = value
			End Sub

			Protected Function GetEmptyCellPixelCoords(ByVal state As NStateObject) As Point
				Return CType(System.Web.HttpContext.Current.Session(state.StateId & "-emptyCellPixelCoords"), Point)
			End Function

			Protected Sub SetEmptyCellPixelCoords(ByVal state As NStateObject, ByVal value As Point)
				System.Web.HttpContext.Current.Session(state.StateId & "-emptyCellPixelCoords") = value
			End Sub

			Protected Function GetGrid(ByVal state As NStateObject) As Hashtable
				Return TryCast(System.Web.HttpContext.Current.Session(state.StateId & "-grid"), Hashtable)
			End Function

			Protected Function GetBoardCellCount(ByVal state As NStateObject) As Integer
				Return CInt(Fix(System.Web.HttpContext.Current.Session(state.StateId & "-boardCellCount")))
			End Function

			Protected Sub SetBoardCellCount(ByVal state As NStateObject, ByVal value As Integer)
				System.Web.HttpContext.Current.Session(state.StateId & "-boardCellCount") = value
			End Sub

			#End Region
		End Class

		#End Region

		#Region "Implementation"

'INSTANT VB NOTE: The parameter boardCellCount was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
		Protected Shared Sub InitDocument(ByVal document As NDrawingDocument, ByVal stateId As String, ByVal boardCellCount_Renamed As Integer)
			' clean up existing layers
			document.Layers.RemoveAllChildren()

			' modify the connectors style sheet
			document.Style.TextStyle = New NTextStyle()
			document.Style.TextStyle.FontStyle = New NFontStyle("Arial", 20f, FontStyle.Bold)
			document.Style.TextStyle.FillStyle = New NColorFillStyle(Color.SteelBlue)
			document.Style.TextStyle.BorderStyle = New NStrokeStyle(1f, Color.White)

			' configure the document
			document.Bounds = New NRectangleF(0, 0, imagePixelWidth, imagePixelHeight)
			document.ShadowsZOrder = ShadowsZOrder.BehindLayer
			document.GraphicsSettings.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
			document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
			document.GraphicsSettings.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None
			document.MeasurementUnit = NGraphicsUnit.Pixel
			document.DrawingScaleMode = DrawingScaleMode.NoScale

			document.BackgroundStyle.FrameStyle.Visible = False

			Dim backgroundLayer As NLayer = New NLayer()
			Dim gridLayer As NLayer = New NLayer()
			document.Layers.AddChild(gridLayer)
			document.ActiveLayerUniqueId = gridLayer.UniqueId

			'	frame
			Dim factory As NBasicShapesFactory = New NBasicShapesFactory(document)

			'	grid
			Dim randomizedNumbers As ArrayList = CreateRandomizedNumbersArray(boardCellCount_Renamed)

			Dim grid As Hashtable = New Hashtable()
			Dim cells As NNodeList = New NNodeList()
			Dim x As Integer = 0
			Do While x < boardCellCount_Renamed
				Dim y As Integer = 0
				Do While y < boardCellCount_Renamed
					If x = boardCellCount_Renamed - 1 AndAlso y = boardCellCount_Renamed - 1 Then
						Exit Do
					End If
					Dim cell As NRectangleShape = CreateCell(document, x, y, CInt(Fix(randomizedNumbers(y + x * boardCellCount_Renamed))))
					cells.Add(cell)
					grid(New Point(CInt(Fix(cell.Bounds.X)), CInt(Fix(cell.Bounds.Y)))) = New Point(x, y)
					y += 1
				Loop
				x += 1
			Loop

			Dim cellsGroup As NGroup
			Dim batchGroup As NBatchGroup = New NBatchGroup(document)
			batchGroup.Build(cells)
			Dim result As NTransactionResult = batchGroup.Group(document.ActiveLayer, True, cellsGroup)

			cellsGroup.Name = "cellsGroup"

			'	save the default empty cell coordinates
			Dim emptyCellCoords As Point = New Point(boardCellCount_Renamed - 1, boardCellCount_Renamed - 1)
			Dim emptyCellPixelCoords As Point = New Point(boardMarginLeft + cellPixelWidth * (boardCellCount_Renamed - 1) + boardPadding, boardMarginTop + cellPixelWidth * (boardCellCount_Renamed - 1) + boardPadding)

			HttpContext.Current.Session(stateId.ToString() & "-emptyCellCoords") = emptyCellCoords
			HttpContext.Current.Session(stateId.ToString() & "-emptyCellPixelCoords") = emptyCellPixelCoords

			'	save the default cells grid
			grid(New Point(emptyCellPixelCoords.X, emptyCellPixelCoords.Y)) = New Point(emptyCellCoords.X, emptyCellCoords.Y)
			HttpContext.Current.Session(stateId.ToString() & "-grid") = grid

			' clean up any other related session state
			HttpContext.Current.Session.Remove(stateId.ToString() & "-cellsList")
		End Sub

		Protected Shared Function CreateCell(ByVal document As NDrawingDocument, ByVal x As Integer, ByVal y As Integer, ByVal number As Integer) As NRectangleShape
			Dim factory As NBasicShapesFactory = New NBasicShapesFactory(document)

			Dim cell As NRectangleShape = TryCast(factory.CreateShape(CInt(Fix(BasicShapes.Rectangle))), NRectangleShape)
			cell.Bounds = New NRectangleF(boardMarginLeft + cellPixelWidth * x + boardPadding, boardMarginTop + cellPixelWidth * y + boardPadding, cellPixelWidth, cellPixelHeight)
			cell.Style.StrokeStyle = normalCellStrokeStyle
			cell.Style.FillStyle = emptyCellFillStyle
			cell.Style.ShadowStyle = New NShadowStyle(ShadowType.GaussianBlur, Color.FromArgb(65, Color.Black), New NPointL(shadowOffset, shadowOffset), 1, New NLength(shadowOffset*2))
			cell.Name = String.Format("{0}, {1}", x, y)
			cell.Tag = number
			cell.Text = number.ToString()

			document.ActiveLayer.AddChild(cell)
			Return cell
		End Function

'INSTANT VB NOTE: The parameter boardCellCount was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
		Protected Shared Function CreateRandomizedNumbersArray(ByVal boardCellCount_Renamed As Integer) As ArrayList
			Dim rnd As Random = New Random(DateTime.Now.Millisecond)
			Dim maxNumber As Integer = boardCellCount_Renamed * boardCellCount_Renamed

			Dim intermediate As ArrayList = New ArrayList(maxNumber)
			Dim i As Integer = 1
			Do While i < maxNumber
				intermediate.Add(i)
				i += 1
			Loop

			Dim result As ArrayList = New ArrayList(maxNumber)
			i = 1
			Do While i < maxNumber
				Dim index As Integer = rnd.Next(intermediate.Count - 1)
				result.Add(intermediate(index))
				intermediate.RemoveAt(index)
				i += 1
			Loop

			Return result
		End Function

		#End Region
	End Class
End Namespace
