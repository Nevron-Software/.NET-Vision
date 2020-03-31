Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections.Generic

Imports Nevron.Diagram.Layout
Imports Nevron.Diagram
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Templates

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NLayeredGraphLayoutUC.
	''' </summary>
	Public Class NLayeredGraphLayoutUC
		Inherits NDiagramExampleUC
		#Region "Constructor"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			InitializeComponent()
		End Sub

		#End Region

		#Region "Component Designer Generated Code"

		Private Sub InitializeComponent()
			Me.propertyGrid1 = New System.Windows.Forms.PropertyGrid()
			Me.LayoutButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.RandomGraphButton2 = New Nevron.UI.WinForm.Controls.NButton()
			Me.RandomGraphButton1 = New Nevron.UI.WinForm.Controls.NButton()
			Me.chkRandomSizes = New System.Windows.Forms.CheckBox()
			Me.SuspendLayout()
			' 
			' propertyGrid1
			' 
			Me.propertyGrid1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.propertyGrid1.Location = New System.Drawing.Point(8, 3)
			Me.propertyGrid1.Name = "propertyGrid1"
			Me.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical
			Me.propertyGrid1.Size = New System.Drawing.Size(244, 379)
			Me.propertyGrid1.TabIndex = 1
			' 
			' LayoutButton
			' 
			Me.LayoutButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.LayoutButton.Location = New System.Drawing.Point(8, 491)
			Me.LayoutButton.Name = "LayoutButton"
			Me.LayoutButton.Size = New System.Drawing.Size(244, 23)
			Me.LayoutButton.TabIndex = 2
			Me.LayoutButton.Text = "Layout"
			Me.LayoutButton.UseVisualStyleBackColor = True
'			Me.LayoutButton.Click += New System.EventHandler(Me.LayoutButton_Click);
			' 
			' RandomGraphButton2
			' 
			Me.RandomGraphButton2.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.RandomGraphButton2.Location = New System.Drawing.Point(8, 440)
			Me.RandomGraphButton2.Name = "RandomGraphButton2"
			Me.RandomGraphButton2.Size = New System.Drawing.Size(244, 23)
			Me.RandomGraphButton2.TabIndex = 8
			Me.RandomGraphButton2.Text = "Random Graph (20 vertices, 30 edges)"
			Me.RandomGraphButton2.UseVisualStyleBackColor = True
'			Me.RandomGraphButton2.Click += New System.EventHandler(Me.RandomGraphButton2_Click);
			' 
			' RandomGraphButton1
			' 
			Me.RandomGraphButton1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.RandomGraphButton1.Location = New System.Drawing.Point(8, 411)
			Me.RandomGraphButton1.Name = "RandomGraphButton1"
			Me.RandomGraphButton1.Size = New System.Drawing.Size(244, 23)
			Me.RandomGraphButton1.TabIndex = 7
			Me.RandomGraphButton1.Text = "Random Graph (10 vertices, 15 edges)"
			Me.RandomGraphButton1.UseVisualStyleBackColor = True
'			Me.RandomGraphButton1.Click += New System.EventHandler(Me.RandomGraphButton1_Click);
			' 
			' chkRandomSizes
			' 
			Me.chkRandomSizes.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.chkRandomSizes.AutoSize = True
			Me.chkRandomSizes.Location = New System.Drawing.Point(8, 388)
			Me.chkRandomSizes.Name = "chkRandomSizes"
			Me.chkRandomSizes.Size = New System.Drawing.Size(119, 17)
			Me.chkRandomSizes.TabIndex = 9
			Me.chkRandomSizes.Text = "Random node sizes"
			Me.chkRandomSizes.UseVisualStyleBackColor = True
			' 
			' NLayeredGraphLayoutUC
			' 
			Me.Controls.Add(Me.chkRandomSizes)
			Me.Controls.Add(Me.RandomGraphButton2)
			Me.Controls.Add(Me.RandomGraphButton1)
			Me.Controls.Add(Me.LayoutButton)
			Me.Controls.Add(Me.propertyGrid1)
			Me.Name = "NLayeredGraphLayoutUC"
			Me.Controls.SetChildIndex(Me.propertyGrid1, 0)
			Me.Controls.SetChildIndex(Me.LayoutButton, 0)
			Me.Controls.SetChildIndex(Me.RandomGraphButton1, 0)
			Me.Controls.SetChildIndex(Me.RandomGraphButton2, 0)
			Me.Controls.SetChildIndex(Me.chkRandomSizes, 0)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' create a stylesheet for the CustomConnectors
			Dim styleSheet As NStyleSheet = New NStyleSheet("CustomConnectors")
			styleSheet.Style.StartArrowheadStyle = New NArrowheadStyle(ArrowheadShape.Circle, "CustomConnectorStart", New NSizeL(6, 6), New NColorFillStyle(Color.FromArgb(247, 150, 56)), New NStrokeStyle(1, Color.FromArgb(68, 90, 108)))
			styleSheet.Style.EndArrowheadStyle = New NArrowheadStyle(ArrowheadShape.Arrow, "CustomConnectorStart", New NSizeL(6, 6), New NColorFillStyle(Color.FromArgb(247, 150, 56)), New NStrokeStyle(1, Color.FromArgb(68, 90, 108)))
			styleSheet.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))
			document.StyleSheets.AddChild(styleSheet)

			' init form fields
			m_Layout = New NLayeredGraphLayout()
			propertyGrid1.SelectedObject = m_Layout

			view.BeginInit()
			view.Grid.Visible = False
			view.GlobalVisibility.ShowPorts = False
			view.ViewLayout = ViewLayout.Fit

			' init document
			document.BeginInit()
			document.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133))
			document.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))
			document.Style.EndArrowheadStyle.FillStyle = New NColorFillStyle(Color.FromArgb(247, 150, 56))
			document.Style.StartArrowheadStyle.FillStyle = New NColorFillStyle(Color.FromArgb(247, 150, 56))
			InitDocument()
			document.EndInit()

			' init form controls
			InitFormControls()

			' end view init
			view.EndInit()
		End Sub

		Protected Overrides Sub AttachToEvents()
			MyBase.AttachToEvents()
		End Sub

		Protected Overrides Sub DetachFromEvents()
			MyBase.DetachFromEvents()
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub CreateDiagram()
			Const width As Integer = 40, height As Integer = 40, distance As Integer = 80
			Dim f As NBasicShapesFactory = New NBasicShapesFactory(document)
			Dim edge As NRoutableConnector
			Dim from As Integer() = New Integer() { 1, 1, 1, 2, 2, 3, 3, 4, 4, 5, 6 }
			Dim [to] As Integer() = New Integer() { 2, 3, 4, 4, 5, 6, 7, 5, 9, 8, 9 }
			Dim shapes As NShape() = New NShape(8){}
			Dim vertexCount As Integer = shapes.Length, edgeCount As Integer = from.Length
			Dim i As Integer, j As Integer, count As Integer = vertexCount + edgeCount

			i = 0
			Do While i < count
				If i < vertexCount Then
					If vertexCount Mod 2 = 0 Then
						j = i
					Else
						j = i + 1
					End If
					shapes(i) = f.CreateShape(CInt(Fix(BasicShapes.Rectangle)))

					If vertexCount Mod 2 <> 0 AndAlso i = 0 Then
						shapes(i).Bounds = New NRectangleF(CInt(Fix(width + (distance * 1.5))) / 2, distance + (j / 2) * CInt(Fix(distance * 1.5)), width, height)
					Else
						shapes(i).Bounds = New NRectangleF(width / 2 + (j Mod 2) * CInt(Fix(distance * 1.5)), height + (j / 2) * CInt(Fix(distance * 1.5)), width, height)
					End If

					document.ActiveLayer.AddChild(shapes(i))
				Else
					edge = New NRoutableConnector()
					edge.ConnectorType = RoutableConnectorType.DynamicPolyline
					edge.StyleSheetName = "CustomConnectors"
					document.ActiveLayer.AddChild(edge)
					edge.FromShape = shapes(from(i - vertexCount) - 1)
					edge.ToShape = shapes([to](i - vertexCount) - 1)
				End If
				i += 1
			Loop
		End Sub
		Private Sub InitFormControls()
			PauseEventsHandling()

			ResumeEventsHandling()
		End Sub
		Private Sub InitDocument()
			CreateDiagram()
			LayoutButton.PerformClick()

			' resize document to fit all shapes
			document.SizeToContent()
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub LayoutButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LayoutButton.Click
			' get the shapes to layout
			Dim shapes As NNodeList = document.ActiveLayer.Children(NFilters.Shape2D)

			' layout the shapes
			If Not m_Layout Is Nothing Then
				m_Layout.Layout(shapes, New NDrawingLayoutContext(document))
			End If

			' resize document to fit all shapes
			document.SizeToContent()
		End Sub
		Private Sub RandomGraphButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RandomGraphButton1.Click
			view.LockRefresh = True
			document.ActiveLayer.RemoveAllChildren()

			Dim randomGraph As NRandomGraphTemplate = New NRandomGraphTemplate()
			randomGraph.EdgesStyleSheetName = "CustomConnectors"
			randomGraph.VertexCount = 10
			randomGraph.EdgeCount = 15
			If chkRandomSizes.Checked Then
				randomGraph.MaxVerticesSize = New NSizeF(randomGraph.MinVerticesSize.Width * 3, randomGraph.MinVerticesSize.Height * 3)
			End If

			randomGraph.Create(document)
			LayoutButton.PerformClick()

			'Layout the graph
			view.LockRefresh = False
		End Sub
		Private Sub RandomGraphButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RandomGraphButton2.Click
			view.LockRefresh = True
			document.ActiveLayer.RemoveAllChildren()

			Dim randomGraph As NRandomGraphTemplate = New NRandomGraphTemplate()
			randomGraph.EdgesStyleSheetName = "CustomConnectors"
			randomGraph.VertexCount = 20
			randomGraph.EdgeCount = 30
			If chkRandomSizes.Checked Then
				randomGraph.MaxVerticesSize = New NSizeF(randomGraph.MinVerticesSize.Width * 3, randomGraph.MinVerticesSize.Height * 3)
			End If

			randomGraph.Create(document)
			LayoutButton.PerformClick()

			'Layout the graph
			view.LockRefresh = False
		End Sub

		#End Region

		#Region "Designer Fields"

		Private propertyGrid1 As System.Windows.Forms.PropertyGrid
		Private chkRandomSizes As System.Windows.Forms.CheckBox
		Private WithEvents LayoutButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents RandomGraphButton2 As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents RandomGraphButton1 As Nevron.UI.WinForm.Controls.NButton

		#End Region

		#Region "Fields"

		Private m_Layout As NLayeredGraphLayout

		#End Region
	End Class
End Namespace