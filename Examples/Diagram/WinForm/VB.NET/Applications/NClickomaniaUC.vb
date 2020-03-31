Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms

Imports Nevron.Diagram
Imports Nevron.Diagram.WinForm
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NClickomaniaUC.
	''' </summary>
	Public Class NClickomaniaUC
		Inherits NDiagramExampleUC
		#Region "Constructors"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			InitializeComponent()
		End Sub

		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NClickomaniaUC))
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.label1.BackColor = System.Drawing.Color.AliceBlue
			Me.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.label1.ForeColor = System.Drawing.Color.Red
			Me.label1.Location = New System.Drawing.Point(5, 10)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(235, 43)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Clickomania"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' label2
			' 
			Me.label2.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.label2.BackColor = System.Drawing.Color.LemonChiffon
			Me.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.label2.Location = New System.Drawing.Point(4, 64)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(236, 181)
			Me.label2.TabIndex = 2
			Me.label2.Text = resources.GetString("label2.Text")
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' NTableShapeEventsUC
			' 
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Name = "NTableShapeEventsUC"
			Me.Size = New System.Drawing.Size(248, 384)
			Me.Controls.SetChildIndex(Me.label1, 0)
			Me.Controls.SetChildIndex(Me.label2, 0)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			' init view
			view.ViewLayout = ViewLayout.Fit
			view.DocumentPadding = New Nevron.Diagram.NMargins(10)
			view.Grid.Visible = False
			view.GlobalVisibility.ShowPorts = False
			view.HorizontalRuler.Visible = False
			view.VerticalRuler.Visible = False
			view.Controller.Tools.DisableTools(New String() { NDWFR.ToolSelector })

			' init document
			document.BeginInit()
			InitDocument()
			document.EndInit()

			' end view init
			view.EndInit()
		End Sub

		Protected Overrides Sub AttachToEvents()
			AddHandler document.EventSinkService.NodeMouseDown, AddressOf EventSinkService_NodeMouseDown

			MyBase.AttachToEvents()
		End Sub

		Protected Overrides Sub DetachFromEvents()
			RemoveHandler document.EventSinkService.NodeMouseDown, AddressOf EventSinkService_NodeMouseDown

			MyBase.DetachFromEvents()
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub InitDocument()
			' Create the stylesheets
			Dim i As Integer = 0, count As Integer = GradientSchemes.Length
			cells = New Integer(count - 1){}
			i = 0
			Do While i < count
				Dim styleSheet As NStyleSheet = New NStyleSheet(GradientSchemes(i).ToString())
				NStyle.SetFillStyle(styleSheet, New NAdvancedGradientFillStyle(GradientSchemes(i), 4))
				document.StyleSheets.AddChild(styleSheet)
				cells(i) = 0
				i += 1
			Loop

			' Create the table
			score = 0
			table = CreateTableShape()
			info = CreateInfoShape()
			table.Location = New NPointF(info.Bounds.Right + info.Width / 2, table.Location.Y)

			' Resize the document to fit all shapes
			document.SizeToContent()
		End Sub
		Private Sub ApplyProtections(ByVal shape As NShape)
			Dim protection As NAbilities = shape.Protection
			protection.MoveX = True
			protection.MoveY = True
			protection.InplaceEdit = True
			protection.Select = True
			shape.Protection = protection
		End Sub
		Private Function CreateTableShape() As NTableShape
			Dim shape As NTableShape = New NTableShape()
			document.ActiveLayer.AddChild(shape)

			shape.InitTable(ColCount, RowCount)
			shape.BeginUpdate()

			Dim i, j, index As Integer
			Dim colorCount As Integer = GradientSchemes.Length
			Dim random As Random = New Random()

			For i = 0 To RowCount - 1
				For j = 0 To ColCount - 1
					shape(j, i).Text = CellText
					index = random.Next(colorCount)
					cells(index) += 1
					shape(j, i).StyleSheetName = GradientSchemes(index).ToString()
				Next j
			Next i

			shape.EndUpdate()
			ApplyProtections(shape)

			Return shape
		End Function
		Private Function CreateInfoShape() As NTableShape
			Dim shape As NTableShape = New NTableShape()
			document.ActiveLayer.AddChild(shape)

			Dim i As Integer, count As Integer = GradientSchemes.Length
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
				shape(0, i + 1).StyleSheetName = GradientSchemes(i).ToString()
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
			ApplyProtections(shape)

			Return shape
		End Function
		Private Sub UpdateInfo()
			Dim i As Integer, count As Integer = GradientSchemes.Length
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
'INSTANT VB NOTE: The local variable rowCount was renamed since Visual Basic will not uniquely identify class members when local variables have the same name:
			Dim rowCount_Renamed As Integer = table.RowCount
			Dim columnCount As Integer = table.ColumnCount

			i = 0
			Do While i < rowCount_Renamed
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
'INSTANT VB NOTE: The local variable rowCount was renamed since Visual Basic will not uniquely identify class members when local variables have the same name:
			Dim rowCount_Renamed As Integer = table.RowCount
			Dim columnCount As Integer = table.ColumnCount

			' Top to bottom gravity force
			j = 0
			Do While j < columnCount
				For i = rowCount_Renamed - 1 To 1 Step -1
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
				If IsEmptyToTop(j, rowCount_Renamed - 1) Then
					' Shift columns to the left
					i = 0
					Do While i < rowCount_Renamed
						z = j
						Do While z < columnCount - 1
							table(z, i).StyleSheetName = table(z + 1, i).StyleSheetName
							z += 1
						Loop

						table(z, i).StyleSheetName = String.Empty
						i += 1
					Loop
				End If
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
'INSTANT VB NOTE: The local variable rowCount was renamed since Visual Basic will not uniquely identify class members when local variables have the same name:
			Dim rowCount_Renamed As Integer = table.RowCount
			Dim columnCount As Integer = table.ColumnCount
			Dim cell As NTableCell

			For i = rowCount_Renamed - 1 To 0 Step -1
				j = 0
				Do While j < columnCount
					cell = table(j, i)
					If cell.StyleSheetName <> String.Empty Then
						If Test(j, i, cell.StyleSheetName) Then
							Return False
						End If
					End If
					j += 1
				Loop
			Next i

			Return True
		End Function
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

		Private Sub EventSinkService_NodeMouseDown(ByVal args As NNodeMouseEventArgs)
			Dim cell As NTableCell = TryCast(args.Node, NTableCell)
			If cell Is Nothing Then
				Return
			End If

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
						status = "Congratulations you've cleared all cells !!!" & Environment.NewLine
					End If

					If status = String.Empty AndAlso GameOver() Then
						status = "Game Over !" & Environment.NewLine
					End If

					If status <> String.Empty Then
						status &= "Your score is " & score.ToString()
						MessageBox.Show(status)
					End If
				End If
			End If

			args.Handled = True
		End Sub

		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private label1 As Label
		Private label2 As Label

		#End Region

		#Region "Fields"

		Private table As NTableShape
		Private info As NTableShape
		Private score As Integer
		Private cells As Integer()

		#End Region

		#Region "Constants"

		Private Const RowCount As Integer = 20
		Private Const ColCount As Integer = 15
		Private Const CellText As String = " "

		Private Shared ReadOnly GradientSchemes As AdvancedGradientScheme() = New AdvancedGradientScheme() { AdvancedGradientScheme.Red, AdvancedGradientScheme.Blue, AdvancedGradientScheme.Green, AdvancedGradientScheme.Sunset }

		#End Region
	End Class
End Namespace