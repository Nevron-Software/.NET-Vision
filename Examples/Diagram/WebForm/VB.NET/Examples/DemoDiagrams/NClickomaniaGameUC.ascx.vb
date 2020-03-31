Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.Diagram
Imports Nevron.Diagram.ThinWeb
Imports Nevron.Dom
Imports Nevron.Filters
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Diagram.Webform
	Partial Public Class NClickomaniaGameUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If NThinDiagramControl1.Initialized = False Then
				' Configure the thin diagram control
				NThinDiagramControl1.AutoUpdateCallback = New NAutoUpdateCallback()
				NThinDiagramControl1.ServerSettings.AutoUpdateInterval = 300
				NThinDiagramControl1.ServerSettings.EnableAutoUpdate = False

				' Init view
				NThinDiagramControl1.View.Layout = CanvasLayout.Normal

				' Configure the controller
				Dim serverMouseEventTool As NServerMouseEventTool = New NServerMouseEventTool()
				NThinDiagramControl1.Controller.Tools.Add(serverMouseEventTool)
				serverMouseEventTool.MouseDown = New NMouseDownEventCallback()

				' Init document
				Dim document As NDrawingDocument = NThinDiagramControl1.Document
				document.BeginInit()
				InitDocument(document)
				document.EndInit()
			End If
		End Sub

#Region "Implementation"

		Private Sub InitDocument(ByVal document As NDrawingDocument)
			' Set up visual formatting
			document.BackgroundStyle.FrameStyle.Visible = False
			document.Style.TextStyle.FontStyle = New NFontStyle(document.Style.TextStyle.FontStyle.Name, 14)

			' Create the stylesheets
			Dim i As Integer = 0, count As Integer = GradientSchemes.Length
			i = 0
			Do While i < count
				Dim scheme As AdvancedGradientScheme = GradientSchemes(i)
				Dim styleSheet As NStyleSheet = New NStyleSheet(scheme.ToString())
				Dim fill As NAdvancedGradientFillStyle = New NAdvancedGradientFillStyle(scheme, 4)
				If scheme.Equals(AdvancedGradientScheme.Green) Then
					' Make the green color dark
					CType(fill.Points(0), NAdvancedGradientPoint).Color = Color.FromArgb(0, 128, 0)
				End If
				NStyle.SetFillStyle(styleSheet, fill)
				document.StyleSheets.AddChild(styleSheet)

				Dim highlightedFill As NAdvancedGradientFillStyle = CType(fill.Clone(), NAdvancedGradientFillStyle)
				CType(highlightedFill.Points(0), NAdvancedGradientPoint).Color = ControlPaint.LightLight((CType(fill.Points(0), NAdvancedGradientPoint)).Color)
				Dim highlightedStyleSheet As NStyleSheet = New NStyleSheet(styleSheet.Name & HighlightedSuffix)
				NStyle.SetFillStyle(highlightedStyleSheet, highlightedFill)
				document.StyleSheets.AddChild(highlightedStyleSheet)
				i += 1
			Loop

			' Create the board and info shapes
			Dim game As NClickomaniaGame = New NClickomaniaGame()
			CreateBoardShape(document, game)
			CreateInfoShape(document, game)
			game.BoardShape.Location = New NPointF(game.InfoShape.Bounds.Right + game.InfoShape.Width / 2, game.BoardShape.Location.Y)

			' Resize the document to fit all shapes
			document.SizeToContent()
			game.InfoShape.Location = New NPointF(game.InfoShape.Location.X, game.BoardShape.Location.Y)
			document.Tag = game
		End Sub
		Private Function CreateBoardShape(ByVal document As NDrawingDocument, ByVal game As NClickomaniaGame) As NTableShape
			Dim shape As NTableShape = New NTableShape()
			shape.Name = "Table"

			shape.InitTable(TableColumns, TableRows)
			shape.BeginUpdate()

			Dim i, j, index As Integer
			Dim colorCount As Integer = GradientSchemes.Length
			Dim random As Random = New Random()

			For i = 0 To TableRows - 1
				For j = 0 To TableColumns - 1
					shape(j, i).Text = CellText
					index = random.Next(colorCount)
					game.CellCount(index) += 1
					shape(j, i).StyleSheetName = GradientSchemes(index).ToString()
				Next j
			Next i

			game.BoardShape = shape
			document.ActiveLayer.AddChild(shape)

			shape.EndUpdate()
			Return shape
		End Function
		Private Function CreateInfoShape(ByVal document As NDrawingDocument, ByVal game As NClickomaniaGame) As NTableShape
			Dim shape As NTableShape = New NTableShape()
			shape.Name = "Info"

			Dim i As Integer, count As Integer = GradientSchemes.Length
			shape.InitTable(2, count + 2)
			shape.BeginUpdate()

			shape.ShowGrid = False

			Dim headerCell As NTableCell = shape(0, 0)
			headerCell.ColumnSpan = 2
			headerCell.Padding = New Nevron.Diagram.NMargins(2, 2, 2, 0)
			headerCell.Borders = TableCellBorder.Bottom
			headerCell.Text = "Cells:"

			i = 0
			Do While i < count
				Dim colorCell As NTableCell = shape(0, i + 1)
				colorCell.Text = CellText
				colorCell.StyleSheetName = GradientSchemes(i).ToString()
				colorCell.Margins = New Nevron.Diagram.NMargins(4, 4, 4, 4)
				colorCell.Borders = TableCellBorder.All

				Dim countCell As NTableCell = shape(1, i + 1)
				countCell.Text = game.CellCount(i).ToString()
				i += 1
			Loop

			Dim scoreCell As NTableCell = shape(0, i + 1)
			scoreCell.ColumnSpan = 2
			scoreCell.Padding = New Nevron.Diagram.NMargins(2, 2, 2, 0)
			scoreCell.Borders = TableCellBorder.Top
			scoreCell.Text = String.Format("Score:{0}{1}", Environment.NewLine, game.Score)

			game.InfoShape = shape
			document.ActiveLayer.AddChild(shape)

			shape.EndUpdate()
			Return shape
		End Function

#End Region

#Region "Constants"

		Private Const TableRows As Integer = 20
		Private Const TableColumns As Integer = 15
		Private Const CellText As String = " "
		Private Const HighlightedSuffix As String = "Highlighted"
		Private Shared ReadOnly CellFilter As NFilter = New NInstanceOfTypeFilter(GetType(NTableCell))

		Private Shared ReadOnly GradientSchemes As AdvancedGradientScheme() = New AdvancedGradientScheme() {AdvancedGradientScheme.Red, AdvancedGradientScheme.Blue, AdvancedGradientScheme.Green, AdvancedGradientScheme.Sunset}

#End Region

#Region "Nested Types"

		<Serializable()> _
		Private Class NMouseDownEventCallback
			Implements INMouseEventCallback
#Region "INMouseEventCallback Members"

			Private Sub OnMouseEvent(ByVal control As NAspNetThinWebControl, ByVal e As NBrowserMouseEventArgs) Implements INMouseEventCallback.OnMouseEvent
				Dim diagramControl As NThinDiagramControl = CType(control, NThinDiagramControl)
				Dim nodes As NNodeList = diagramControl.HitTest(New NPointF(e.X, e.Y))
				Dim shapes As NNodeList = nodes.Filter(CellFilter)

				If shapes.Count = 0 Then
					Return
				End If

				Dim game As NClickomaniaGame = CType(diagramControl.Document.Tag, NClickomaniaGame)
				Dim cell As NTableCell = CType(shapes(0), NTableCell)
				If Not cell.ParentNode.ParentNode Is game.BoardShape Then
					Return
				End If

				If String.IsNullOrEmpty(cell.StyleSheetName) Then
					Return
				End If

				If game.OnCellClicked(cell) = False Then
					Return
				End If

				' The user has clicked on a cell that is part of a region
				diagramControl.ServerSettings.EnableAutoUpdate = True
				diagramControl.Update()
			End Sub

#End Region
		End Class

		<Serializable()> _
		Private Class NAutoUpdateCallback
			Implements INAutoUpdateCallback
#Region "INAutoUpdateCallback Members"

			Private Sub OnAutoUpdate(ByVal control As NAspNetThinWebControl) Implements INAutoUpdateCallback.OnAutoUpdate
				Dim diagramControl As NThinDiagramControl = CType(control, NThinDiagramControl)
				Dim game As NClickomaniaGame = CType(diagramControl.Document.Tag, NClickomaniaGame)
				game.ClearHighlightedCells()

				diagramControl.ServerSettings.EnableAutoUpdate = False
				diagramControl.Update()
			End Sub

			Private Sub OnAutoUpdateStateChanged(ByVal control As NAspNetThinWebControl) Implements INAutoUpdateCallback.OnAutoUpdateStateChanged

			End Sub

#End Region
		End Class

		<Serializable()> _
		Private Class NClickomaniaGame
#Region "Constructors"

			Public Sub New()
				CellCount = New Integer(GradientSchemes.Length - 1) {}
				m_CellsToClear = New List(Of NPoint)()
				Score = 0
			End Sub

#End Region

#Region "Public Methods"

			''' <summary>
			''' Handles a cell click event highlighting all cells that form a
			''' region with the clicked cell. If the clicked cell is not part
			''' of a region this method returns false.
			''' </summary>
			''' <param name="cell"></param>
			Public Function OnCellClicked(ByVal cell As NTableCell) As Boolean
				If m_CellsToClear.Count > 0 Then
					Return False
				End If

				Dim p As NPoint = GetCellAddress(cell)
				Dim color As String = cell.StyleSheetName

				If Test(p.X, p.Y, color) = False Then
					Return False
				End If

				HighlightCell(p.X, p.Y, color)
				Return True
			End Function
			''' <summary>
			''' Clears all highlighted cells.
			''' </summary>
			Public Sub ClearHighlightedCells()
				'INSTANT VB NOTE: The local variable cellCount was renamed since Visual Basic will not uniquely identify class members when local variables have the same name:
				Dim cellCount_Renamed As Integer = m_CellsToClear.Count
				If cellCount_Renamed = 0 Then
					Return
				End If

				Dim color As String = BoardShape(m_CellsToClear(0).X, m_CellsToClear(0).Y).StyleSheetName
				color = color.Remove(color.Length - HighlightedSuffix.Length)
				CellCount(IndexOf(color)) -= cellCount_Renamed
				Score += cellCount_Renamed * cellCount_Renamed

				Dim i As Integer = 0
				Do While i < cellCount_Renamed
					Dim p As NPoint = m_CellsToClear(i)
					BoardShape(p.X, p.Y).StyleSheetName = String.Empty
					i += 1
				Loop

				' Apply gravity
				ApplyGravity()

				' Update the cell count info
				UpdateInfo()

				' Clear the cells to clear list
				m_CellsToClear.Clear()

				' Check for end of the game
				Dim status As String = String.Empty
				If AllClear() Then
					Score *= 2
					status = "You've cleared all cells !!!" & Environment.NewLine
				End If

				If status = String.Empty AndAlso GameOver() Then
					status = "Game Over !" & Environment.NewLine
				End If

				If status <> String.Empty Then
					status &= "Your score is " & Score.ToString()
					'INSTANT VB NOTE: The local variable gameOver was renamed since Visual Basic will not uniquely identify class members when local variables have the same name:
					Dim gameOver_Renamed As NTableShape = New NTableShape()
					CType(BoardShape.Document, NDrawingDocument).ActiveLayer.AddChild(gameOver_Renamed)

					gameOver_Renamed.BeginUpdate()
					gameOver_Renamed.CellPadding = New Nevron.Diagram.NMargins(2, 2, 8, 8)
					gameOver_Renamed(0, 0).Text = status

					NStyle.SetFillStyle(gameOver_Renamed, New NAdvancedGradientFillStyle(AdvancedGradientScheme.Mahogany2, 5))
					Dim textStyle As NTextStyle = CType(InfoShape.ComposeTextStyle().Clone(), NTextStyle)
					textStyle.FillStyle = New NColorFillStyle(Drawing.Color.White)
					NStyle.SetTextStyle(gameOver_Renamed, textStyle)

					gameOver_Renamed.EndUpdate()
					gameOver_Renamed.Center = BoardShape.Center
				End If
			End Sub

#End Region

#Region "Implementation"

			''' <summary>
			''' Returns the address of the given cell in the table.
			''' </summary>
			''' <param name="cell"></param>
			''' <returns></returns>
			Private Function GetCellAddress(ByVal cell As NTableCell) As NPoint
				Dim i, j As Integer
				Dim rowCount As Integer = BoardShape.RowCount
				Dim columnCount As Integer = BoardShape.ColumnCount

				i = 0
				Do While i < rowCount
					j = 0
					Do While j < columnCount
						If BoardShape(j, i) Is cell Then
							Return New NPoint(j, i)
						End If
						j += 1
					Loop
					i += 1
				Loop

				Return New NPoint(-1, -1)
			End Function
			''' <summary>
			''' Tests if a region of at least 2 cells with the same color is clicked.
			''' </summary>
			''' <param name="x"></param>
			''' <param name="y"></param>
			''' <param name="color"></param>
			''' <returns></returns>
			Private Function Test(ByVal x As Integer, ByVal y As Integer, ByVal color As String) As Boolean
				If x > 0 AndAlso BoardShape(x - 1, y).StyleSheetName = color Then
					Return True
				End If

				If x < BoardShape.ColumnCount - 1 AndAlso BoardShape(x + 1, y).StyleSheetName = color Then
					Return True
				End If

				If y > 0 AndAlso BoardShape(x, y - 1).StyleSheetName = color Then
					Return True
				End If

				If y < BoardShape.RowCount - 1 AndAlso BoardShape(x, y + 1).StyleSheetName = color Then
					Return True
				End If

				Return False
			End Function
			''' <summary>
			''' Clears recursively the whole region, starting with the specified cell.
			''' </summary>
			''' <param name="x"></param>
			''' <param name="y"></param>
			''' <param name="color"></param>
			''' <param name="total"></param>
			Private Sub HighlightCell(ByVal x As Integer, ByVal y As Integer, ByVal color As String)
				BoardShape(x, y).StyleSheetName = BoardShape(x, y).StyleSheetName + HighlightedSuffix
				m_CellsToClear.Add(New NPoint(x, y))

				If x > 0 AndAlso BoardShape(x - 1, y).StyleSheetName = color Then
					HighlightCell(x - 1, y, color)
				End If

				If x < BoardShape.ColumnCount - 1 AndAlso BoardShape(x + 1, y).StyleSheetName = color Then
					HighlightCell(x + 1, y, color)
				End If

				If y > 0 AndAlso BoardShape(x, y - 1).StyleSheetName = color Then
					HighlightCell(x, y - 1, color)
				End If

				If y < BoardShape.RowCount - 1 AndAlso BoardShape(x, y + 1).StyleSheetName = color Then
					HighlightCell(x, y + 1, color)
				End If
			End Sub
			''' <summary>
			''' Checks if a column is empty from the given row index to the top.
			''' </summary>
			''' <param name="x"></param>
			''' <param name="y"></param>
			''' <returns></returns>
			Private Function IsEmptyToTop(ByVal x As Integer, ByVal y As Integer) As Boolean
				For i As Integer = y To 0 Step -1
					If BoardShape(x, i).StyleSheetName <> String.Empty Then
						Return False
					End If
				Next i

				Return True
			End Function
			''' <summary>
			''' Applies top to bottom and right to left gravity forces to the table.
			''' </summary>
			Private Sub ApplyGravity()
				Dim i, j, z As Integer
				Dim rowCount As Integer = BoardShape.RowCount
				Dim columnCount As Integer = BoardShape.ColumnCount

				' Top to bottom gravity force
				j = 0
				Do While j < columnCount
					For i = rowCount - 1 To 1 Step -1
						If BoardShape(j, i).StyleSheetName = String.Empty Then
							If IsEmptyToTop(j, i - 1) Then
								Exit For
							End If

							For z = i To 1 Step -1
								BoardShape(j, z).StyleSheetName = BoardShape(j, z - 1).StyleSheetName
							Next z

							BoardShape(j, 0).StyleSheetName = String.Empty
							i += 1
						End If
					Next i
					j += 1
				Loop

				' Right to left gravity force
				For j = columnCount - 2 To 0 Step -1
					If (Not IsEmptyToTop(j, rowCount - 1)) Then
						Continue For
					End If

					' Shift columns to the left
					i = 0
					Do While i < rowCount
						z = j
						Do While z < columnCount - 1
							BoardShape(z, i).StyleSheetName = BoardShape(z + 1, i).StyleSheetName
							z += 1
						Loop

						BoardShape(z, i).StyleSheetName = String.Empty
						i += 1
					Loop
				Next j
			End Sub
			''' <summary>
			''' Returns true if all cells are cleared.
			''' </summary>
			''' <returns></returns>
			Private Function AllClear() As Boolean
				Dim i As Integer, count As Integer = CellCount.Length
				i = 0
				Do While i < count
					If CellCount(i) <> 0 Then
						Return False
					End If
					i += 1
				Loop

				Return True
			End Function
			''' <summary>
			''' Returns true if there are no more regions to remove.
			''' </summary>
			''' <returns></returns>
			Private Function GameOver() As Boolean
				Dim i, j As Integer
				Dim rowCount As Integer = BoardShape.RowCount
				Dim columnCount As Integer = BoardShape.ColumnCount
				Dim cell As NTableCell

				For i = rowCount - 1 To 0 Step -1
					j = 0
					Do While j < columnCount
						cell = BoardShape(j, i)
						If cell.StyleSheetName = String.Empty Then
							Continue Do
						End If

						If Test(j, i, cell.StyleSheetName) Then
							Return False
						End If
						j += 1
					Loop
				Next i

				Return True
			End Function
			''' <summary>
			''' Gets the index of given color in the array of colors.
			''' </summary>
			''' <param name="color"></param>
			''' <returns></returns>
			Private Function IndexOf(ByVal color As String) As Integer
				Dim i As Integer, count As Integer = GradientSchemes.Length
				i = 0
				Do While i < count
					If GradientSchemes(i).ToString() = color Then
						Return i
					End If
					i += 1
				Loop

				Return -1
			End Function
			''' <summary>
			''' Update the info shape.
			''' </summary>
			Private Sub UpdateInfo()
				Dim i As Integer, count As Integer = GradientSchemes.Length
				InfoShape.BeginUpdate()

				i = 0
				Do While i < count
					InfoShape(1, i + 1).Text = CellCount(i).ToString()
					i += 1
				Loop

				' Update the score
				InfoShape(0, i + 1).Text = String.Format("Score:{0}{1}", Environment.NewLine, Score)
				InfoShape.EndUpdate()
			End Sub

#End Region

#Region "Fields"

			Public BoardShape As NTableShape
			Public InfoShape As NTableShape
			Public Score As Integer
			Public CellCount As Integer()

			Private m_CellsToClear As List(Of NPoint)

#End Region
		End Class

#End Region
	End Class
End Namespace