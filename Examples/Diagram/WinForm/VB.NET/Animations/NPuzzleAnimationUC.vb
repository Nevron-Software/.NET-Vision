Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms

Imports Nevron.Diagram
Imports Nevron.Diagram.Extensions
Imports Nevron.GraphicsCore
Imports Nevron.UI.WinForm.Controls

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NPuzzleAnimationUC.
	''' </summary>
	Public Class NPuzzleAnimationUC
		Inherits NDiagramExampleUC
		#Region "Constructor"

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
			Me.btnGenerateSwf = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' btnExportToFlash
			' 
			Me.btnGenerateSwf.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnGenerateSwf.Location = New System.Drawing.Point(8, 51)
			Me.btnGenerateSwf.Name = "btnGenerateSwf"
			Me.btnGenerateSwf.Size = New System.Drawing.Size(232, 23)
			Me.btnGenerateSwf.TabIndex = 4
			Me.btnGenerateSwf.Text = "Generate SWF"
			Me.btnGenerateSwf.UseVisualStyleBackColor = True
'			Me.btnGenerateSwf.Click += New System.EventHandler(Me.btnGenerateSwf_Click);
			' 
			' NPuzzleAnimationUC
			' 
			Me.Controls.Add(Me.btnGenerateSwf)
			Me.Name = "NPuzzleAnimationUC"
			Me.Size = New System.Drawing.Size(248, 160)
			Me.Controls.SetChildIndex(Me.btnGenerateSwf, 0)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()
			view.Grid.Visible = False
			view.GlobalVisibility.ShowPorts = False

			' init document
			InitDocument()

			' end view init
			view.EndInit()
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub InitDocument()
			Dim manager As NPersistencyManager = New NPersistencyManager()
			document = manager.LoadDrawingFromFile(Path.Combine(Application.StartupPath, "..\..\Resources\Data\FlowDiagram.ndx"))

			view.Document = document
			Form.Document = document

			document.BeginInit()
			CreateAnimatedGrid(5, 5, 1)
			document.EndInit()
		End Sub
		Private Sub CreateAnimatedGrid(ByVal rows As Integer, ByVal columns As Integer, ByVal cellFadeDuration As Single)
			' Create the grid layer
			Dim grid As NLayer = New NLayer()
			grid.Name = "grid"
			document.Layers.AddChild(grid)

			' Create the cells style sheet
			Dim style As NStyleSheet = New NStyleSheet("gridCell")
			NStyle.SetFillStyle(style, New NColorFillStyle(KnownArgbColorValue.White))
			NStyle.SetStrokeStyle(style, New NStrokeStyle(1, KnownArgbColorValue.Black))
			document.StyleSheets.AddChild(style)

			Dim i, j, count As Integer
			Dim x As Single, y As Single, time As Single = 0
			Dim cellWidth As Single = document.Width / rows
			Dim cellHeight As Single = document.Height / columns

			Dim fade As NFadeAnimation
			Dim rect As NRectangleShape
			Dim cells As List(Of NRectangleShape) = New List(Of NRectangleShape)()

			' Create the shapes
			i = 0
			y = 0
			Do While i < rows
				j = 0
				x = 0
				Do While j < columns
					rect = New NRectangleShape(x, y, cellWidth, cellHeight)
					cells.Add(rect)
					grid.AddChild(rect)
					rect.StyleSheetName = style.Name
					j += 1
					x += cellWidth
				Loop
				i += 1
				y += cellHeight
			Loop

			' Create the fade animations
			count = cells.Count
			Dim random As Random = New Random()

			Dim counter As Integer = 1
			Do While count > 0
				i = random.Next(count)
				rect = cells(i)
				rect.Style.AnimationsStyle = New NAnimationsStyle()

				If time > 0 Then
					fade = New NFadeAnimation(0, time)
					fade.StartAlpha = 1
					fade.EndAlpha = 1
					rect.Style.AnimationsStyle.AddAnimation(fade)
				End If

				fade = New NFadeAnimation(time, cellFadeDuration)
				fade.StartAlpha = 1
				fade.EndAlpha = 0
				rect.Style.AnimationsStyle.AddAnimation(fade)

				If counter = 3 Then
					' Show 3 cells at a time
					time += cellFadeDuration
					counter = 1
				Else
					counter += 1
				End If

				cells.RemoveAt(i)
				count -= 1
			Loop
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub btnGenerateSwf_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerateSwf.Click
			Dim flashExporter As NFlashExporter = New NFlashExporter(document)
			Dim fileName As String = Path.Combine(Application.StartupPath, "test.swf")
			flashExporter.SaveToFile(fileName)
			Process.Start(fileName)
		End Sub

		#End Region

		#Region "Designer Fields"

		Private WithEvents btnGenerateSwf As NButton

		#End Region
	End Class
End Namespace