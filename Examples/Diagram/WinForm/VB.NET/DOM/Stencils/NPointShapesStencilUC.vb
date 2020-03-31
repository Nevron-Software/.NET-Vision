Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Diagram
Imports Nevron.Diagram.WinForm
Imports Nevron.Examples.Framework.WinForm


Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NPointShapeStencilUC.
	''' </summary>
	Public Class NPointShapesStencilUC
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
			Me.SuspendLayout()
			' 
			' commonControlsPanel
			' 
			Me.commonControlsPanel.Name = "commonControlsPanel"
			Me.commonControlsPanel.Size = New System.Drawing.Size(250, 80)
			' 
			' NPointShapesStencilUC
			' 
			Me.Name = "NPointShapesStencilUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			Me.DefaultGridCellSize = New NSizeF(50, 50)

			' begin view init
			view.BeginInit()

			view.Grid.Visible = False

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
			document.Style.StartArrowheadStyle.Shape = ArrowheadShape.None
			document.Style.EndArrowheadStyle.Shape = ArrowheadShape.None

			Dim row As Integer = 0
			Dim col As Integer = 0
			Dim maxColCount As Integer = 5
			Dim index As Integer = 0

			For Each pointShape As NPointShape In document.PointShapeStencil.PredefinedPointShapes
				' create the path representing the arrow head shape
				Dim path As NCustomPath
				If pointShape.Closed Then
					path = New NCustomPath(CType(pointShape.Path.Clone(), GraphicsPath),PathType.ClosedFigure)
				Else
					path = New NCustomPath(CType(pointShape.Path.Clone(), GraphicsPath),PathType.OpenFigure)
				End If

				' create a shape to host the path
				Dim shape As NCompositeShape = New NCompositeShape()
				shape.Primitives.AddChild(path)
				shape.UpdateModelBounds()

				' reposition the shape and add to active layer
				shape.Bounds = MyBase.GetGridCell(row, col)
				document.ActiveLayer.AddChild(shape)

				' describe it
				Dim str As String = NExamplesHelper.InsertSpacesBeforeUppers((CType(index + 2, PointShape)).ToString())
				Dim text As NTextShape = New NTextShape(str, MyBase.GetGridCell(row + 1, col))
				document.ActiveLayer.AddChild(text)

				col += 1
				index += 1

				If col > maxColCount Then
					row += 2
					col = 0
				End If
			Next pointShape
		End Sub


		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace