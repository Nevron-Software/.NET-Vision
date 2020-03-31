Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Imports Nevron.Dom
Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Diagram
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NCustomPointsUC.
	''' </summary>
	Public Class NCustomPointsUC
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
			Me.selectedPointGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.customShapeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.selectedPointGroup.SuspendLayout()
			Me.SuspendLayout()
			' 
			' commonControlsPanel
			' 
			Me.commonControlsPanel.Name = "commonControlsPanel"
			Me.commonControlsPanel.Size = New System.Drawing.Size(250, 80)
			' 
			' selectedPointGroup
			' 
			Me.selectedPointGroup.Controls.Add(Me.label2)
			Me.selectedPointGroup.Controls.Add(Me.customShapeComboBox)
			Me.selectedPointGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.selectedPointGroup.Enabled = False
			Me.selectedPointGroup.ImageIndex = 0
			Me.selectedPointGroup.Location = New System.Drawing.Point(0, 0)
			Me.selectedPointGroup.Name = "selectedPointGroup"
			Me.selectedPointGroup.Size = New System.Drawing.Size(250, 120)
			Me.selectedPointGroup.TabIndex = 0
			Me.selectedPointGroup.TabStop = False
			Me.selectedPointGroup.Text = "Apply Custom Point Shape"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 24)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(152, 23)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Port shape:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' customShapeComboBox
			' 
			Me.customShapeComboBox.Location = New System.Drawing.Point(8, 48)
			Me.customShapeComboBox.Name = "customShapeComboBox"
			Me.customShapeComboBox.Size = New System.Drawing.Size(232, 22)
			Me.customShapeComboBox.TabIndex = 1
			Me.customShapeComboBox.Text = "nComboBox1"
'			Me.customShapeComboBox.SelectedIndexChanged += New System.EventHandler(Me.customShapeComboBox_SelectedIndexChanged);
			' 
			' NCustomPointsUC
			' 
			Me.Controls.Add(Me.selectedPointGroup)
			Me.Name = "NCustomPointsUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.commonControlsPanel, 0)
			Me.Controls.SetChildIndex(Me.selectedPointGroup, 0)
			Me.selectedPointGroup.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			view.Grid.Visible = False
			view.Selection.Mode = DiagramSelectionMode.Single

			' init document
			document.BeginInit()

			CreateTrianglePointShape()
			CreateStarPointShape()
			CreateCompositePointShape()
			CreatePoints()

			document.EndInit()

			' init form controls
			InitFormControls()

			' end view init
			view.EndInit()
		End Sub

		Protected Overrides Sub AttachToEvents()
			AddHandler view.EventSinkService.NodeSelected, AddressOf EventSinkService_NodeSelected
			AddHandler view.EventSinkService.NodeDeselected, AddressOf EventSinkService_NodeDeselected

			MyBase.AttachToEvents()
		End Sub

		Protected Overrides Sub DetachFromEvents()
			RemoveHandler view.EventSinkService.NodeSelected, AddressOf EventSinkService_NodeSelected
			RemoveHandler view.EventSinkService.NodeDeselected, AddressOf EventSinkService_NodeDeselected

			MyBase.DetachFromEvents()
		End Sub


		#End Region

		#Region "Implementation"

		Private Sub InitFormControls()
			PauseEventsHandling()

			customShapeComboBox.Items.Clear()
			customShapeComboBox.Items.Add("Triangle")
			customShapeComboBox.Items.Add("Star")
			customShapeComboBox.Items.Add("Composite Point")

			ResumeEventsHandling()
		End Sub

		Private Sub CreateTrianglePointShape()
			' create the graphics path representing the point shape
			Dim modelBounds As NRectangleF = New NRectangleF(-1, -1, 2, 2)
			Dim path As GraphicsPath = New GraphicsPath()
			CreateNGonPath(path, modelBounds, 3, - CSng(Math.PI) / 2)

			' wrap it in a model and name it
			Dim customPath As NCustomPath = New NCustomPath(path, PathType.ClosedFigure)
			customPath.Name = "Triangle"

			' add it to the stencil
			document.PointShapeStencil.AddChild(customPath)
		End Sub

		Private Sub CreateStarPointShape()
			' create the graphics path representing the point shape
			Dim modelBounds As NRectangleF = New NRectangleF(-1, -1, 2, 2)
			Dim path As GraphicsPath = New GraphicsPath()
			CreateNGramPath(path, modelBounds, 5, -CSng(Math.PI) / 2, 0.5f)

			' wrap it in amodel and name it
			Dim customPath As NCustomPath = New NCustomPath(path, PathType.ClosedFigure)
			customPath.Name = "Star"

			' add it to the stencil
			document.PointShapeStencil.AddChild(customPath)
		End Sub

		Private Sub CreateCompositePointShape()
			Dim modelBounds As NRectangleF = New NRectangleF(-1, -1, 2, 2)
			Dim centerX As Single = 0

			' create composite geometry model
			Dim composite As NCompositeGeometry = New NCompositeGeometry()
			composite.Name = "Composite Point"

			' add ellipse
			composite.AddChild(New NEllipsePath(New NRectangleF(modelBounds.X, modelBounds.Y, modelBounds.Width / 2, modelBounds.Height)))

			' add cross
			Dim path As GraphicsPath = New GraphicsPath()
			path.AddLine(centerX, modelBounds.Y, modelBounds.Right, modelBounds.Bottom)
			path.StartFigure()
			path.AddLine(modelBounds.Right, modelBounds.Y, centerX, modelBounds.Bottom)
			composite.AddChild(New NCustomPath(path, PathType.OpenFigure))

			' update the model bounds of the composite
			composite.UpdateModelBounds()

			' add it to the point shape stencil
			document.PointShapeStencil.AddChild(composite)
		End Sub

		Private Sub CreatePoints()
			Dim row As Integer = 0, col As Integer = 0

			Dim i As Integer = 0
			Do While i < document.PointShapeStencil.ChildrenCount(Nothing)
				If col > 3 Then
					col = 0
					row += 1
				End If

				Dim cell As NRectangleF = MyBase.GetGridCell(row, col)
				Dim location As NPointF = New NPointF(cell.X + cell.Width / 2, cell.Y + cell.Height / 2)
				Dim customShapeName As String = (TryCast(document.PointShapeStencil.GetChildAt(i), INDiagramElement)).Name

				Dim point As NPointElement = New NPointElement(location, New NSizeF(30, 30), PointShape.Custom, customShapeName)
				document.ActiveLayer.AddChild(point)

				col += 1
				i += 1
			Loop
		End Sub


		Private Sub CreateNGonPath(ByVal path As GraphicsPath, ByVal rect As NRectangleF, ByVal edgeCount As Integer, ByVal startAngle As Single)
			Dim angle As Single
			Dim fRadiusX As Single = rect.Width / 2.0f
			Dim fRadiusY As Single = rect.Height / 2.0f
			Dim centerX As Single = rect.X + fRadiusX
			Dim centerY As Single = rect.Y + fRadiusY
			Dim incAngle As Single = CSng((2 * Math.PI) / edgeCount)

			Dim pnt As PointF() = New PointF(edgeCount - 1){}

			Dim i As Integer = 0
			Do While i < edgeCount
				angle = startAngle + i * incAngle
				pnt(i).X = centerX + CSng(Math.Cos(angle)) * fRadiusX
				pnt(i).Y = centerY + CSng(Math.Sin(angle)) * fRadiusY
				i += 1
			Loop

			path.AddLines(pnt)
			path.CloseAllFigures()
		End Sub

		Private Sub CreateNGramPath(ByVal path As GraphicsPath, ByVal rect As NRectangleF, ByVal edgeCount As Integer, ByVal startAngle As Single, ByVal innerRadius As Single)
			Dim i As Integer
			Dim angle As Single
			Dim halfWidth As Single = rect.Width / 2.0f
			Dim halfHeight As Single = rect.Height / 2.0f
			Dim centerX As Single = rect.X + halfWidth
			Dim centerY As Single = rect.Y + halfHeight
			Dim incAngle As Single = CSng(2 * Math.PI / edgeCount)
			Dim innerOffsetAngle As Single = CSng(Math.PI / edgeCount)

			Dim outer As PointF() = New PointF(edgeCount - 1){}
			Dim inner As PointF() = New PointF(edgeCount - 1){}

			i = 0
			Do While i < edgeCount
				angle = startAngle + i * incAngle
				outer(i).X = CSng(Math.Round(centerX + Math.Cos(angle) * halfWidth, 1))
				outer(i).Y = CSng(Math.Round(centerY + Math.Sin(angle) * halfHeight, 1))

				angle += innerOffsetAngle
				inner(i).X = CSng(Math.Round(centerX + Math.Cos(angle) * innerRadius, 1))
				inner(i).Y = CSng(Math.Round(centerY + Math.Sin(angle) * innerRadius, 1))
				i += 1
			Loop

			i = 0
			Do While i < (edgeCount - 1)
				path.AddLine(outer(i), inner(i))
				path.AddLine(inner(i), outer(i + 1))
				i += 1
			Loop

			path.AddLine(outer(i), inner(i))
			path.CloseAllFigures()
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub customShapeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles customShapeComboBox.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			If customShapeComboBox.SelectedIndex = -1 Then
				Return
			End If

			' get the selected point
			Dim point As NPointElement = (TryCast(view.Selection.AnchorNode, NPointElement))
			If point Is Nothing Then
				Return
			End If

			PauseEventsHandling()

			' change the point custom shape name
			point.CustomShapeName = customShapeComboBox.SelectedItem.ToString()

			ResumeEventsHandling()
			document.SmartRefreshAllViews()
		End Sub

		Private Sub EventSinkService_NodeSelected(ByVal args As NNodeEventArgs)
			' get the selected point
			Dim point As NPointElement = (TryCast(args.Node, NPointElement))
			If point Is Nothing Then
				selectedPointGroup.Enabled = False
				Return
			End If

			PauseEventsHandling()

			' update the point shape combo index
			selectedPointGroup.Enabled = True
			customShapeComboBox.SelectedItem = point.CustomShapeName

			ResumeEventsHandling()
		End Sub

		Private Sub EventSinkService_NodeDeselected(ByVal args As NNodeEventArgs)
			selectedPointGroup.Enabled = False
		End Sub


		#End Region

		#Region "Designer Fields"

		Private WithEvents customShapeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private selectedPointGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private label2 As System.Windows.Forms.Label

		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace