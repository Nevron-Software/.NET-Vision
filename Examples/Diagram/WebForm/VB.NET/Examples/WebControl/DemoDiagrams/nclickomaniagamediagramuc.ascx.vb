Imports Microsoft.VisualBasic
Imports System

Imports Nevron.Diagram
Imports Nevron.Diagram.Filters
Imports Nevron.Dom
Imports Nevron.Examples.Diagram.Webform
Imports Nevron.Filters
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls
Imports System.Windows.Forms
Imports System.Drawing

Namespace Nevron.Examples.Diagram.Webform
	Public Partial Class NClickomaniaGameDiagramUC
		Inherits NDiagramExampleUC
		#Region "Properties"

		Public ReadOnly Property document() As NDrawingDocument
			Get
				Return NDrawingView1.Document
			End Get
		End Property
		Public ReadOnly Property table() As NTableShape
			Get
				If m_Table Is Nothing Then
					m_Table = TryCast(document.ActiveLayer.GetChildByName("Table"), NTableShape)
				End If

				Return m_Table
			End Get
		End Property
		Public ReadOnly Property info() As NTableShape
			Get
				If m_Info Is Nothing Then
					m_Info = TryCast(document.ActiveLayer.GetChildByName("Info"), NTableShape)
				End If

				Return m_Info
			End Get
		End Property
		Public ReadOnly Property cells() As Integer()
			Get
				If m_Cells Is Nothing Then
					m_Cells = TryCast(document.Tag, Integer() )
				End If

				Return m_Cells
			End Get
		End Property
		Public Property score() As Integer
			Get
				If m_Score = 0 Then
					m_Score = CInt(Fix(document.ActiveLayer.Tag))
				End If

				Return m_Score
			End Get
			Set
				m_Score = Value
				document.ActiveLayer.Tag = m_Score
			End Set
		End Property

		#End Region

		#Region "Implementation"

		Private Sub InitDocument()
			' Set up visual formatting
			document.BackgroundStyle.FrameStyle.Visible = False

			' Create the stylesheets
			Dim i As Integer = 0, count As Integer = COLORS.Length
			m_Cells = New Integer(count - 1){}
			i = 0
			Do While i < count
				Dim styleSheet As NStyleSheet = New NStyleSheet(COLORS(i).ToString())
				NStyle.SetFillStyle(styleSheet, New NAdvancedGradientFillStyle(COLORS(i), 4))
				document.StyleSheets.AddChild(styleSheet)
				cells(i) = 0
				i += 1
			Loop

			' Create the table
			score = 0
			CreateTableShape()
			CreateInfoShape()
			table.Location = New NPointF(info.Bounds.Right + info.Width / 2, table.Location.Y)

			' Resize the document to fit all shapes
			document.SizeToContent()
			document.Tag = m_Cells
			document.ActiveLayer.Tag = m_Score
		End Sub
		Private Function CreateTableShape() As NTableShape
			Dim shape As NTableShape = New NTableShape()
			shape.Name = "Table"
			document.ActiveLayer.AddChild(shape)

			shape.InitTable(TABLE_COLS, TABLE_ROWS)
			shape.BeginUpdate()

			Dim i, j, index As Integer
			Dim colorCount As Integer = COLORS.Length
			Dim random As Random = New Random()

			For i = 0 To TABLE_ROWS - 1
				For j = 0 To TABLE_COLS - 1
					shape(j, i).Text = CELL_TEXT
					index = random.Next(colorCount)
					cells(index) += 1
					shape(j, i).StyleSheetName = COLORS(index).ToString()
				Next j
			Next i

			shape.EndUpdate()
			Return shape
		End Function
		Private Function CreateInfoShape() As NTableShape
			Dim shape As NTableShape = New NTableShape()
			shape.Name = "Info"
			document.ActiveLayer.AddChild(shape)

			Dim i As Integer, count As Integer = COLORS.Length
			shape.InitTable(2, count + 2)
			shape.BeginUpdate()

			shape.ShowGrid = False
			CType(shape.Columns.GetChildAt(0), NTableColumn).SizeMode = TableColumnSizeMode.Fixed

			shape(0, 0).ColumnSpan = 2
			shape(0, 0).Padding = New Nevron.Diagram.NMargins(2, 2, 2, 0)
			shape(0, 0).Borders = TableCellBorder.Bottom
			shape(0, 0).Text = "Cells:"

			i = 0
			Do While i < count
				shape(0, i + 1).Text = " "
				shape(0, i + 1).StyleSheetName = COLORS(i).ToString()
				shape(0, i + 1).Margins = New Nevron.Diagram.NMargins(2, 2, 5, 5)
				shape(0, i + 1).Borders = TableCellBorder.All
				shape(1, i + 1).Text = cells(i).ToString()
				shape(1, i + 1).Padding = New Nevron.Diagram.NMargins(0, 0, 1, 0)
				i += 1
			Loop

			shape(0, i + 1).ColumnSpan = 2
			shape(0, i + 1).Padding = New Nevron.Diagram.NMargins(2, 2, 2, 0)
			shape(0, i + 1).Borders = TableCellBorder.Top
			shape(0, i + 1).Text = String.Format("Score:{0}{1}", Environment.NewLine, score)

			shape.EndUpdate()
			Return shape
		End Function
		Private Sub UpdateInfo()
			Dim i As Integer, count As Integer = COLORS.Length
			info.BeginUpdate()

			i = 0
			Do While i < count
				info(1, i + 1).Text = cells(i).ToString()
				i += 1
			Loop

			' Update the score
			info(0, i + 1).Text = String.Format("Score:{0}{1}", Environment.NewLine, score)
			info.EndUpdate()
		End Sub

		#End Region

		#Region "Clickomania Game"

		''' <summary>
		''' Returns the address of the given cell in the table.
		''' </summary>
		''' <param name="cell"></param>
		''' <returns></returns>
		Private Function GetCellAddress(ByVal cell As NTableCell) As NPoint
			Dim i, j As Integer
			Dim rowCount As Integer = table.RowCount
			Dim columnCount As Integer = table.ColumnCount

			i = 0
			Do While i < rowCount
				j = 0
				Do While j < columnCount
					If table(j, i) Is cell Then
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
			If x > 0 AndAlso table(x - 1, y).StyleSheetName = color Then
				Return True
			End If

			If x < table.ColumnCount - 1 AndAlso table(x + 1, y).StyleSheetName = color Then
				Return True
			End If

			If y > 0 AndAlso table(x, y - 1).StyleSheetName = color Then
				Return True
			End If

			If y < table.RowCount - 1 AndAlso table(x, y + 1).StyleSheetName = color Then
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
		Private Sub ClearCell(ByVal x As Integer, ByVal y As Integer, ByVal color As String, ByRef total As Integer)
			total += 1
			table(x, y).StyleSheetName = String.Empty

			If x > 0 AndAlso table(x - 1, y).StyleSheetName = color Then
				ClearCell(x - 1, y, color, total)
			End If

			If x < table.ColumnCount - 1 AndAlso table(x + 1, y).StyleSheetName = color Then
				ClearCell(x + 1, y, color, total)
			End If

			If y > 0 AndAlso table(x, y - 1).StyleSheetName = color Then
				ClearCell(x, y - 1, color, total)
			End If

			If y < table.RowCount - 1 AndAlso table(x, y + 1).StyleSheetName = color Then
				ClearCell(x, y + 1, color, total)
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
				If table(x, i).StyleSheetName <> String.Empty Then
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
			Dim rowCount As Integer = table.RowCount
			Dim columnCount As Integer = table.ColumnCount

			' Top to bottom gravity force
			j = 0
			Do While j < columnCount
				For i = rowCount - 1 To 1 Step -1
					If table(j, i).StyleSheetName = String.Empty Then
						If IsEmptyToTop(j, i - 1) Then
							Exit For
						End If

						For z = i To 1 Step -1
							table(j, z).StyleSheetName = table(j, z - 1).StyleSheetName
						Next z

						table(j, 0).StyleSheetName = String.Empty
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
						table(z, i).StyleSheetName = table(z + 1, i).StyleSheetName
						z += 1
					Loop

					table(z, i).StyleSheetName = String.Empty
					i += 1
				Loop
			Next j
		End Sub
		''' <summary>
		''' Returns true if all cells are cleared.
		''' </summary>
		''' <returns></returns>
		Private Function AllClear() As Boolean
			Dim i As Integer, count As Integer = cells.Length
			i = 0
			Do While i < count
				If cells(i) <> 0 Then
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
			Dim rowCount As Integer = table.RowCount
			Dim columnCount As Integer = table.ColumnCount
			Dim cell As NTableCell

			For i = rowCount - 1 To 0 Step -1
				j = 0
				Do While j < columnCount
					cell = table(j, i)
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
		Private Function IndexOf(ByVal color As String) As Integer
			Dim i As Integer, count As Integer = COLORS.Length
			i = 0
			Do While i < count
				If COLORS(i).ToString() = color Then
					Return i
				End If
				i += 1
			Loop

			Return -1
		End Function
		''' <summary>
		''' Handles a cell click. Returns true if the player clicked on a region.
		''' </summary>
		''' <param name="cell"></param>
		''' <returns></returns>
		Private Function CellClicked(ByVal cell As NTableCell) As Boolean
			Dim p As NPoint = GetCellAddress(cell)
			Dim color As String = cell.StyleSheetName

			If (Not Test(p.X, p.Y, color)) Then
				Return False
			End If

			Dim cellsCleared As Integer = 0
			ClearCell(p.X, p.Y, color, cellsCleared)

			cells(IndexOf(color)) -= cellsCleared
			cellsCleared -= 1
			score += cellsCleared * cellsCleared

			ApplyGravity()
			Return True
		End Function

		#End Region

		#Region "Event Handlers"

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If NDrawingView1.RequiresInitialization Then
				MyBase.DefaultGridOrigin = New NPointF(30, 30)
				MyBase.DefaultGridCellSize = New NSizeF(100, 50)
				MyBase.DefaultGridSpacing = New NSizeF(50, 40)

				' begin view init
				NDrawingView1.ViewLayout = CanvasLayout.Fit

				If (Not IsPostBack) Then
					' init document
					document.BeginInit()
					InitDocument()
					document.EndInit()
				End If
			End If
		End Sub
		Protected Sub NDrawingView1_QueryAjaxTools(ByVal sender As Object, ByVal e As EventArgs)
			NDrawingView1.AjaxTools.Add(New NAjaxMouseClickCallbackTool(True, True))
			NDrawingView1.AjaxTools.Add(New NAjaxTooltipTool(True))
			NDrawingView1.AjaxTools.Add(New NAjaxDynamicCursorTool(True))
		End Sub
		Protected Sub NDrawingView1_AsyncClick(ByVal sender As Object, ByVal e As EventArgs)
			Dim args As NCallbackMouseEventArgs = TryCast(e, NCallbackMouseEventArgs)

			Dim nodes As NNodeList = NDrawingView1.HitTest(args)
			Dim shapes As NNodeList = nodes.Filter(CELL_FILTER)

			If shapes.Count = 0 Then
				Return
			End If

			Dim cell As NTableCell = CType(shapes(0), NTableCell)
			If Not cell.ParentNode.ParentNode Is table Then
				Return
			End If

			If Not cell.StyleSheetName Is Nothing AndAlso cell.StyleSheetName <> String.Empty Then
				If CellClicked(cell) Then
					UpdateInfo()

					' Check for end of the game
					Dim status As String = String.Empty
					If AllClear() Then
						score *= 2
						status = "You've cleared all cells !!!" & Environment.NewLine
					End If

					If status = String.Empty AndAlso GameOver() Then
						status = "Game Over !" & Environment.NewLine
					End If

					If status <> String.Empty Then
						status &= "Your score is " & score.ToString()
'INSTANT VB NOTE: The local variable gameOver was renamed since Visual Basic will not uniquely identify class members when local variables have the same name:
						Dim gameOver_Renamed As NTableShape = New NTableShape()
						document.ActiveLayer.AddChild(gameOver_Renamed)

						gameOver_Renamed.BeginUpdate()
						gameOver_Renamed.CellPadding = New Nevron.Diagram.NMargins(2, 2, 8, 8)
						gameOver_Renamed(0, 0).Text = status

						NStyle.SetFillStyle(gameOver_Renamed, New NAdvancedGradientFillStyle(AdvancedGradientScheme.Ocean1, 0))
						NStyle.SetStrokeStyle(gameOver_Renamed, New NStrokeStyle(Color.DarkBlue))

						Dim textStyle As NTextStyle = CType(table.ComposeTextStyle().Clone(), NTextStyle)
						textStyle.FillStyle = New NColorFillStyle(Color.DarkBlue)
						NStyle.SetTextStyle(gameOver_Renamed, textStyle)

						gameOver_Renamed.EndUpdate()
						gameOver_Renamed.Center = table.Center
					End If
				End If
			End If
		End Sub

		#End Region

		#Region "Fields"

		Private m_Table As NTableShape
		Private m_Info As NTableShape
		Private m_Score As Integer
		Private m_Cells As Integer()

		#End Region

		#Region "Static"

		Private Const TABLE_ROWS As Integer = 20
		Private Const TABLE_COLS As Integer = 15
		Private Const CELL_TEXT As String = " "
		Private Shared ReadOnly CELL_FILTER As NFilter = New NInstanceOfTypeFilter(GetType(NTableCell))

		Private Shared ReadOnly COLORS As AdvancedGradientScheme() = New AdvancedGradientScheme() { AdvancedGradientScheme.Red, AdvancedGradientScheme.Blue, AdvancedGradientScheme.Green, AdvancedGradientScheme.Sunset }

		#End Region
	End Class
End Namespace