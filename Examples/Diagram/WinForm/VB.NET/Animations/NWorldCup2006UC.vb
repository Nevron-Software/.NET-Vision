Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms

Imports Nevron.Diagram
Imports Nevron.Diagram.Extensions
Imports Nevron.Diagram.Layout
Imports Nevron.Dom
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.WinForm
	Public Class NWorldCup2006UC
		Inherits NDiagramExampleUC
		#Region "Constructors"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			InitializeComponent()
		End Sub
		Shared Sub New()
									' Quarter finals
									' Semi finals
									' Final
			MATCHES = New Match(){ New Match("Germany", "Sweden", 2, 0), New Match("Argentina", "Mexico", 2, 1), New Match("Italy", "Australia", 1, 0), New Match("Switzerland", "Ukraine", 0, 3), New Match("England", "Ecuador", 1, 0), New Match("Portugal", "Netherlands", 1, 0), New Match("Brazil", "Ghana", 3, 0), New Match("Spain", "France", 1, 3), New Match("Argentina", "Germany", 2, 4), New Match("Italy", "Ukraine", 3, 0), New Match("England", "Portugal", 1, 3), New Match("Brazil", "France", 0, 1), New Match("Italy", "Germany", 2, 0), New Match("Portugal", "France", 0, 1), New Match("France", "Italy", 3, 5) }

			FLAGS = New Dictionary(Of String, Bitmap)()
			Dim flag As Bitmap
			Dim flagBounds As Rectangle = New Rectangle(0, 0, 24, 16)
			Using allFlags As Bitmap = Nevron.UI.NResourceHelper.BitmapFromResource(GetType(NWorldCup2006UC), "Flags.bmp", "Nevron.Examples.Diagram.WinForm.Resources")
				Dim x As Integer = 0, y As Integer = 0

				For i As Integer = 0 To 7
					' create flag for team1
					CreateFlagForTeam(allFlags, x, y, MATCHES(i).team1)

					' advance coordinates
					y += 16

					' create flag for team2
					CreateFlagForTeam(allFlags, x, y, MATCHES(i).team2)
					y += 16

					If i = 3 Then
						x = 24
						y = 0
					End If
				Next i
			End Using
		End Sub

		Private Shared Sub CreateFlagForTeam(ByVal allFlags As Bitmap, ByVal x As Integer, ByVal y As Integer, ByVal name As String)
			Dim flag As Bitmap = New Bitmap(24, 16)

			Using gr As Graphics = Graphics.FromImage(flag)
				gr.Clear(Color.White)
				gr.DrawImage(allFlags, New Rectangle(0, 0, 24, 16), x, y, 24, 16, GraphicsUnit.Pixel)
			End Using

			FLAGS.Add(name, flag)
		End Sub

		#End Region

		#Region "Component Designer Generated Code"

		Private Sub InitializeComponent()
			Me.btnGenerateSwf = New Nevron.UI.WinForm.Controls.NButton()
			Me.btnGenerateXaml = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' btnGenerateSwf
			' 
			Me.btnGenerateSwf.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnGenerateSwf.Location = New System.Drawing.Point(8, 491)
			Me.btnGenerateSwf.Name = "btnGenerateSwf"
			Me.btnGenerateSwf.Size = New System.Drawing.Size(244, 23)
			Me.btnGenerateSwf.TabIndex = 3
			Me.btnGenerateSwf.Text = "Generate SWF"
			Me.btnGenerateSwf.UseVisualStyleBackColor = True
'			Me.btnGenerateSwf.Click += New System.EventHandler(Me.btnGenerateSwf_Click);
			' 
			' btnGenerateXaml
			' 
			Me.btnGenerateXaml.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnGenerateXaml.Location = New System.Drawing.Point(8, 460)
			Me.btnGenerateXaml.Name = "btnGenerateXaml"
			Me.btnGenerateXaml.Size = New System.Drawing.Size(244, 23)
			Me.btnGenerateXaml.TabIndex = 6
			Me.btnGenerateXaml.Text = "Generate XAML"
			Me.btnGenerateXaml.UseVisualStyleBackColor = True
'			Me.btnGenerateXaml.Click += New System.EventHandler(Me.btnGenerateXaml_Click);
			' 
			' NWorldCup2006UC
			' 
			Me.Controls.Add(Me.btnGenerateXaml)
			Me.Controls.Add(Me.btnGenerateSwf)
			Me.Name = "NWorldCup2006UC"
			Me.Controls.SetChildIndex(Me.btnGenerateSwf, 0)
			Me.Controls.SetChildIndex(Me.btnGenerateXaml, 0)
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

			' init document
			document.BeginInit()
			InitDocument()
			document.EndInit()

			' end view init
			view.EndInit()
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub InitDocument()
			' change default document styles
			document.Style.TextStyle.TextFormat = TextFormat.XML
			document.Style.StartArrowheadStyle.Shape = ArrowheadShape.None
			document.Style.EndArrowheadStyle.Shape = ArrowheadShape.None
			document.Style.FillStyle = New NGradientFillStyle(GradientStyle.DiagonalUp, GradientVariant.Variant1, New NArgbColor(155, 184, 209), New NArgbColor(83, 138, 179))

			' the fill style for the cells
			Dim transparent As NStyleSheet = New NStyleSheet("transparent")
			NStyle.SetFillStyle(transparent, New NColorFillStyle(KnownArgbColorValue.Transparent))
			document.StyleSheets.AddChild(transparent)

			Dim shapes As NNodeList = New NNodeList()
			Dim shape1 As NShape, shape2 As NShape, winner As NShape = Nothing
			Dim i As Integer, depth As Integer = 0
			Dim count As Integer = MATCHES.Length

			i = 0
			Do While i < count
				winner = CreateShape(MATCHES(i))
				shapes.Add(winner)

				If i >= 8 Then
					If i < 12 Then
						depth = 0
						shape1 = CType(shapes((i - 8) * 2), NShape)
						shape2 = CType(shapes((i - 8) * 2 + 1), NShape)
					ElseIf i < 14 Then
						depth = 2
						shape1 = CType(shapes(8 + (i - 12) * 2), NShape)
						shape2 = CType(shapes(8 + (i - 12) * 2 + 1), NShape)
					Else
						depth = 4
						shape1 = CType(shapes(12), NShape)
						shape2 = CType(shapes(13), NShape)
					End If

					SetAnimationsStyle(shape1, depth)
					SetAnimationsStyle(shape2, depth)

					ConnectShapes(shape1, shape2, winner, depth + 1)
				End If
				i += 1
			Loop

			SetAnimationsStyle(winner, depth + 2)

			Dim layout As NLayeredGraphLayout = New NLayeredGraphLayout()
			layout.Direction = LayoutDirection.LeftToRight
			layout.Layout(shapes, New NDrawingLayoutContext(document))

			' resize document to fit all shapes
			document.SizeToContent()
		End Sub
		Private Sub ConnectShapes(ByVal shape1 As NShape, ByVal shape2 As NShape, ByVal winner As NShape, ByVal depth As Integer)
			Dim port As NPort = CType(winner.Ports.GetChildByName("Left"), NPort)

			Dim connector As NRoutableConnector = New NRoutableConnector()
			document.ActiveLayer.AddChild(connector)
			connector.FromShape = shape2
			connector.EndPlug.Connect(port)
			SetAnimationsStyle(connector, depth)

			connector = New NRoutableConnector()
			document.ActiveLayer.AddChild(connector)
			connector.FromShape = shape1
			connector.EndPlug.Connect(port)
			SetAnimationsStyle(connector, depth)
		End Sub
		Private Function CreateShape(ByVal m As Match) As NTableShape
			Dim table As NTableShape = New NTableShape()
			document.ActiveLayer.AddChild(table)

			table.InitTable(3, 2)
			table.BeginUpdate()

			table.CellPadding = New Nevron.Diagram.NMargins(2)
			table.ShowGrid = False

			Dim column As NTableColumn = CType(table.Columns.GetChildAt(1), NTableColumn)
			column.SizeMode = TableColumnSizeMode.Fixed
			column.Width = 90

			table(0, 0).Bitmap = FLAGS(m.team1)
			table(1, 0).Text = m.team1
			table(2, 0).Text = m.score1.ToString()

			table(0, 1).Bitmap = FLAGS(m.team2)
			table(1, 1).Text = m.team2
			table(2, 1).Text = m.score2.ToString()

			' write the winner in bold
			If m.score1 > m.score2 Then
				table(1, 0).Text = "<b>" & table(1, 0).Text & "</b>"
				table(2, 0).Text = "<b>" & table(2, 0).Text & "</b>"
			Else
				table(1, 1).Text = "<b>" & table(1, 1).Text & "</b>"
				table(2, 1).Text = "<b>" & table(2, 1).Text & "</b>"
			End If

			' make all cells transparent so that the background of the table is visible
			Dim i, j As Integer
			Dim rowCount As Integer = table.RowCount, colCount As Integer = table.ColumnCount
			i = 0
			Do While i < rowCount
				j = 0
				Do While j < colCount
					table(j, i).StyleSheetName = "transparent"
					j += 1
				Loop
				i += 1
			Loop

			table.EndUpdate()
			table.Ports.DefaultInwardPortUniqueId = (CType(table.Ports.GetChildByName("Right"), NPort)).UniqueId

			Return table
		End Function
		Private Sub SetAnimationsStyle(ByVal shape As NShape, ByVal depth As Integer)
			shape.Style.AnimationsStyle = New NAnimationsStyle()

			If depth > 0 Then
				Dim fade As NFadeAnimation = New NFadeAnimation(0, depth * ANIMATION_DURATION)
				fade.EndAlpha = 0
				shape.Style.AnimationsStyle.Animations.Add(fade)
			End If

			shape.Style.AnimationsStyle.Animations.Add(New NFadeAnimation(depth * ANIMATION_DURATION, ANIMATION_DURATION))
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub btnGenerateSwf_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerateSwf.Click
			Dim flashExporter As NFlashExporter = New NFlashExporter(document)
			Dim fileName As String = Path.Combine(Application.StartupPath, "test.swf")
			flashExporter.SaveToFile(fileName)
			Process.Start(fileName)
		End Sub
		Private Sub btnGenerateXaml_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerateXaml.Click
			Dim flashExporter As NXamlExporter = New NXamlExporter(document)
			Dim fileName As String = Path.Combine(Application.StartupPath, "test.xaml")
			flashExporter.SaveToFile(fileName)
			Process.Start(fileName)
		End Sub

		#End Region

		#Region "Designer Fields"

		Private WithEvents btnGenerateSwf As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents btnGenerateXaml As Nevron.UI.WinForm.Controls.NButton

		#End Region

		#Region "Static"

		Private Const ANIMATION_DURATION As Single = 1.0f
		Private Shared ReadOnly FLAG_SIZE As NSize = New NSize(48, 32)
		Private Shared ReadOnly FLAGS As Dictionary(Of String, Bitmap)
			' Round of 16
			' Quarter finals
			' Semi finals
			' Final
		Private Shared ReadOnly MATCHES As Match() = New Match(){ New Match("Germany", "Sweden", 2, 0), New Match("Argentina", "Mexico", 2, 1), New Match("Italy", "Australia", 1, 0), New Match("Switzerland", "Ukraine", 0, 3), New Match("England", "Ecuador", 1, 0), New Match("Portugal", "Netherlands", 1, 0), New Match("Brazil", "Ghana", 3, 0), New Match("Spain", "France", 1, 3), New Match("Argentina", "Germany", 2, 4), New Match("Italy", "Ukraine", 3, 0), New Match("England", "Portugal", 1, 3), New Match("Brazil", "France", 0, 1), New Match("Italy", "Germany", 2, 0), New Match("Portugal", "France", 0, 1), New Match("France", "Italy", 3, 5) }

		#End Region

		#Region "NestedTypes"

		Private Structure Match
			Public team1 As String
			Public team2 As String
			Public score1 As Integer
			Public score2 As Integer

			Public Sub New(ByVal team1 As String, ByVal team2 As String, ByVal score1 As Integer, ByVal score2 As Integer)
				Me.team1 = team1
				Me.team2 = team2
				Me.score1 = score1
				Me.score2 = score2
			End Sub
		End Structure

		#End Region
	End Class
End Namespace