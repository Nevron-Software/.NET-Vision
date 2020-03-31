Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Diagnostics
Imports System.Windows.Forms

Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Dom
Imports Nevron.Diagram
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NCustomArrowheadsUC.
	''' </summary>
	Public Class NCustomArrowheadsUC
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
			Me.selectedShapeGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.endArrowheadComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.startArrowheadComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.selectedShapeGroup.SuspendLayout()
			Me.SuspendLayout()
			' 
			' commonControlsPanel
			' 
			Me.commonControlsPanel.Name = "commonControlsPanel"
			Me.commonControlsPanel.Size = New System.Drawing.Size(250, 80)
			' 
			' selectedShapeGroup
			' 
			Me.selectedShapeGroup.Controls.Add(Me.endArrowheadComboBox)
			Me.selectedShapeGroup.Controls.Add(Me.startArrowheadComboBox)
			Me.selectedShapeGroup.Controls.Add(Me.label2)
			Me.selectedShapeGroup.Controls.Add(Me.label1)
			Me.selectedShapeGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.selectedShapeGroup.Enabled = False
			Me.selectedShapeGroup.ImageIndex = 0
			Me.selectedShapeGroup.Location = New System.Drawing.Point(0, 0)
			Me.selectedShapeGroup.Name = "selectedShapeGroup"
			Me.selectedShapeGroup.Size = New System.Drawing.Size(250, 136)
			Me.selectedShapeGroup.TabIndex = 0
			Me.selectedShapeGroup.TabStop = False
			Me.selectedShapeGroup.Text = "Apply Custom Arrowhead Shapes"
			' 
			' endArrowheadComboBox
			' 
			Me.endArrowheadComboBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.endArrowheadComboBox.Location = New System.Drawing.Point(8, 104)
			Me.endArrowheadComboBox.Name = "endArrowheadComboBox"
			Me.endArrowheadComboBox.Size = New System.Drawing.Size(232, 22)
			Me.endArrowheadComboBox.TabIndex = 3
			Me.endArrowheadComboBox.Text = "nComboBox1"
'			Me.endArrowheadComboBox.SelectedIndexChanged += New System.EventHandler(Me.endArrowheadComboBox_SelectedIndexChanged);
			' 
			' startArrowheadComboBox
			' 
			Me.startArrowheadComboBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.startArrowheadComboBox.Location = New System.Drawing.Point(8, 48)
			Me.startArrowheadComboBox.Name = "startArrowheadComboBox"
			Me.startArrowheadComboBox.Size = New System.Drawing.Size(232, 22)
			Me.startArrowheadComboBox.TabIndex = 1
			Me.startArrowheadComboBox.Text = "nComboBox1"
'			Me.startArrowheadComboBox.SelectedIndexChanged += New System.EventHandler(Me.startArrowheadComboBox_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 24)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(152, 23)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Start arrowhead shape:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 80)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(152, 23)
			Me.label1.TabIndex = 2
			Me.label1.Text = "End arrowhead shape:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' NCustomArrowheadsUC
			' 
			Me.Controls.Add(Me.selectedShapeGroup)
			Me.Name = "NCustomArrowheadsUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.selectedShapeGroup, 0)
			Me.Controls.SetChildIndex(Me.commonControlsPanel, 0)
			Me.selectedShapeGroup.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			' init view
			view.Grid.Visible = False
			view.Selection.Mode = DiagramSelectionMode.Single

			' start document initialization
			document.BeginInit()

			CreateDoubleOpenedArrowShape()
			CreateRectangleArrowShape()
			CreateCompositeArrowheadShape()
			CreateStroke()

			' end document initialization
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

			startArrowheadComboBox.Items.Clear()
			startArrowheadComboBox.Items.Add("Double Opened Arrow")
			startArrowheadComboBox.Items.Add("Rectangle")
			startArrowheadComboBox.Items.Add("Composite Arrowhead")

			endArrowheadComboBox.Items.Clear()
			endArrowheadComboBox.Items.Add("Double Opened Arrow")
			endArrowheadComboBox.Items.Add("Rectangle")
			endArrowheadComboBox.Items.Add("Composite Arrowhead")

			ResumeEventsHandling()
		End Sub


		Private Sub CreateDoubleOpenedArrowShape()
			Dim modelBounds As NRectangleF = New NRectangleF(0, -1, 2, 2)

			Dim fXCenter As Single = modelBounds.X + modelBounds.Width / 2
			Dim fYCenter As Single = modelBounds.Y + modelBounds.Height / 2

			Dim lines As PointF() = New PointF(2){}
			Dim path As GraphicsPath = New GraphicsPath()

			' arrow1
			lines(0) = New PointF(fXCenter, modelBounds.Y)
			lines(1) = New PointF(modelBounds.X, fYCenter)
			lines(2) = New PointF(fXCenter, modelBounds.Bottom)
			path.AddLines(lines)

			' arrow2
			path.StartFigure()
			lines(0) = New PointF(modelBounds.Right, modelBounds.Y)
			lines(1) = New PointF(fXCenter, fYCenter)
			lines(2) = New PointF(modelBounds.Right, modelBounds.Bottom)
			path.AddLines(lines)

			''' create a custom open figure and name it
			Dim strokePath As NCustomPath = New NCustomPath(path, PathType.OpenFigure)
			strokePath.Name = "Double Opened Arrow"

			' add it to the arrowhead shape stencil
			document.ArrowheadShapeStencil.AddChild(strokePath)
		End Sub

		Private Sub CreateRectangleArrowShape()
			''' create a simple rect and name it
			Dim modelBounds As NRectangleF = New NRectangleF(0, -1, 2, 2)
			Dim rect As NRectanglePath = New NRectanglePath(modelBounds)
			rect.Name = "Rectangle"

			' add it to the arrowhead shape stencil
			document.ArrowheadShapeStencil.AddChild(rect)
		End Sub

		Private Sub CreateCompositeArrowheadShape()
			Dim modelBounds As NRectangleF = New NRectangleF(0, -1, 2, 2)

			' create composite geometry and name it
			Dim geometry As NCompositeGeometry = New NCompositeGeometry()
			geometry.Name = "Composite Arrowhead"

			' add rect
			geometry.AddChild(New NRectanglePath(New NRectangleF(modelBounds.X, modelBounds.Y, modelBounds.Width / 2, modelBounds.Height)))

			' add slash 1
			Dim x As Single = modelBounds.X + (modelBounds.Width * 3) / 4
			geometry.AddChild(New NLinePath(New NPointF(x, modelBounds.Y), New NPointF(x, modelBounds.Bottom)))

			' add slash 2
			geometry.AddChild(New NLinePath(New NPointF(modelBounds.Right, modelBounds.Y), New NPointF(modelBounds.Right, modelBounds.Bottom)))

			geometry.UpdateModelBounds()

			' add it to the arrowhead shape stencil
			document.ArrowheadShapeStencil.AddChild(geometry)
		End Sub

		Private Sub CreateStroke()
			' create an arrow head style which uses a custom shape
			Dim defaultStyle As NArrowheadStyle = New NArrowheadStyle(ArrowheadShape.Custom, "Double Opened Arrow", New NSizeL(13, 13), New NColorFillStyle(Color.OrangeRed), New NStrokeStyle(1, Color.Black))

			' create a polyline which uses this arrowhead style
			Dim points As NPointF() = New NPointF(){ New NPointF(290, 50), New NPointF(207, 199), New NPointF(40, 50), New NPointF(234, 95), New NPointF(94, 184)}

			Dim polyline As NPolylineShape = New NPolylineShape(points)

			polyline.Style.StartArrowheadStyle = TryCast(defaultStyle.Clone(), NArrowheadStyle)
			polyline.Style.EndArrowheadStyle = TryCast(defaultStyle.Clone(), NArrowheadStyle)

			document.ActiveLayer.AddChild(polyline)
		End Sub

		Private Sub CreateNGonPath(ByVal path As GraphicsPath, ByRef rect As NRectangleF, ByVal nEdgeCount As Integer, ByVal fStartAngle As Single)
			Dim fAngle As Single
			Dim fRadiusX As Single = rect.Width / 2.0f
			Dim fRadiusY As Single = rect.Height / 2.0f
			Dim fCenterX As Single = rect.X + fRadiusX
			Dim fCenterY As Single = rect.Y + fRadiusY
			Dim fIncrementAngle As Single = CSng((2 * Math.PI) / nEdgeCount)

			Dim pnt As PointF() = New PointF(nEdgeCount - 1){}

			Dim i As Integer = 0
			Do While i < nEdgeCount
				fAngle = fStartAngle + i * fIncrementAngle
				pnt(i).X = fCenterX + CSng(Math.Cos(fAngle)) * fRadiusX
				pnt(i).Y = fCenterY + CSng(Math.Sin(fAngle)) * fRadiusY
				i += 1
			Loop

			path.AddLines(pnt)
			path.CloseAllFigures()
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub startArrowheadComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles startArrowheadComboBox.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			If startArrowheadComboBox.SelectedIndex = -1 Then
				Return
			End If

			' get the selected shape
			Dim shape As NShape = (TryCast(view.Selection.AnchorNode, NShape))
			If shape Is Nothing Then
				Return
			End If

			PauseEventsHandling()

			' change the shape start arrowhead style to use the selected custom shape
			shape.Style.StartArrowheadStyle = New NArrowheadStyle(ArrowheadShape.Custom, startArrowheadComboBox.SelectedItem.ToString(), New NSizeL(13, 13), New NColorFillStyle(Color.OrangeRed), New NStrokeStyle(1, Color.Black))

			document.SmartRefreshAllViews()
			ResumeEventsHandling()
		End Sub

		Private Sub endArrowheadComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles endArrowheadComboBox.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			If endArrowheadComboBox.SelectedIndex = -1 Then
				Return
			End If

			' get the selected shape
			Dim shape As NShape = (TryCast(view.Selection.AnchorNode, NShape))
			If shape Is Nothing Then
				Return
			End If

			PauseEventsHandling()

			' change the shape start arrowhead style to use the selected custom shape
			shape.Style.EndArrowheadStyle = New NArrowheadStyle(ArrowheadShape.Custom, endArrowheadComboBox.SelectedItem.ToString(), New NSizeL(13, 13), New NColorFillStyle(Color.OrangeRed), New NStrokeStyle(1, Color.Black))

			document.SmartRefreshAllViews()
			ResumeEventsHandling()
		End Sub


		Private Sub EventSinkService_NodeSelected(ByVal args As NNodeEventArgs)
			If EventsHandlingPaused Then
				Return
			End If

			PauseEventsHandling()

			' get the selected shape
			Dim shape As NShape = (TryCast(view.Selection.AnchorNode, NShape))

			' update the form controls
			If Not shape Is Nothing Then
				selectedShapeGroup.Enabled = True

				startArrowheadComboBox.SelectedIndex = -1
				If Not shape.Style.StartArrowheadStyle Is Nothing Then
					startArrowheadComboBox.SelectedItem = shape.Style.StartArrowheadStyle.CustomShapeName
				End If

				endArrowheadComboBox.SelectedIndex = -1
				If Not shape.Style.EndArrowheadStyle Is Nothing Then
					endArrowheadComboBox.SelectedItem = shape.Style.EndArrowheadStyle.CustomShapeName
				End If
			Else
				selectedShapeGroup.Enabled = False
			End If

			ResumeEventsHandling()
		End Sub

		Private Sub EventSinkService_NodeDeselected(ByVal args As NNodeEventArgs)
			selectedShapeGroup.Enabled = False
		End Sub


		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private selectedShapeGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private label2 As System.Windows.Forms.Label
		Private label1 As System.Windows.Forms.Label
		Private WithEvents startArrowheadComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents endArrowheadComboBox As Nevron.UI.WinForm.Controls.NComboBox

		#End Region
	End Class
End Namespace