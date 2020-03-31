Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing

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
	''' Summary description for NOrthogonalLayoutUC.
	''' </summary>
	Public Class NRadialGraphLayoutUC
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
			Me.SuspendLayout()
			' 
			' propertyGrid1
			' 
			Me.propertyGrid1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.propertyGrid1.Location = New System.Drawing.Point(8, 3)
			Me.propertyGrid1.Name = "propertyGrid1"
			Me.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical
			Me.propertyGrid1.Size = New System.Drawing.Size(244, 482)
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
			' NOrthogonalLayoutUC
			' 
			Me.Controls.Add(Me.LayoutButton)
			Me.Controls.Add(Me.propertyGrid1)
			Me.Name = "NOrthogonalLayoutUC"
			Me.Controls.SetChildIndex(Me.propertyGrid1, 0)
			Me.Controls.SetChildIndex(Me.LayoutButton, 0)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' init form fields
			m_Layout = New NRadialGraphLayout()
			propertyGrid1.SelectedObject = m_Layout

			view.BeginInit()
			view.Grid.Visible = False
			view.GlobalVisibility.ShowPorts = False
			view.GlobalVisibility.ShowArrowheads = False
			view.ViewLayout = ViewLayout.Fit

			' init document
			document.BeginInit()
			document.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(251, 203, 156), Color.FromArgb(247, 150, 56))
			document.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))

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

		Private Sub InitFormControls()
			PauseEventsHandling()

			ResumeEventsHandling()
		End Sub

		Private Sub InitDocument()
			' create a tree
			Dim tree As NGenericTreeTemplate = New NGenericTreeTemplate()
			tree.Levels = 4
			tree.BranchNodes = 4
			tree.HorizontalSpacing = 10
			tree.VerticalSpacing = 10
			tree.LayoutScheme = TreeLayoutScheme.None
			tree.ConnectorType = ConnectorType.Line
			tree.VerticesShape = BasicShapes.Circle
			tree.VerticesSize = New NSizeF(40, 40)
			tree.EdgesStyle.StartArrowheadStyle = New NArrowheadStyle(ArrowheadShape.Circle, "CustomConnectorStart", New NSizeL(6, 6), New NColorFillStyle(Color.FromArgb(129, 133, 133)), New NStrokeStyle(1, Color.FromArgb(68, 90, 108)))
			tree.EdgesStyle.EndArrowheadStyle = New NArrowheadStyle(ArrowheadShape.Arrow, "CustomConnectorStart", New NSizeL(6, 6), New NColorFillStyle(Color.FromArgb(129, 133, 133)), New NStrokeStyle(1, Color.FromArgb(68, 90, 108)))
			tree.Create(document)

			' resize document to fit all shapes
			LayoutButton.PerformClick()
			document.SizeToContent()
		End Sub

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

		#End Region

		#Region "Designer Fields"

		Private propertyGrid1 As System.Windows.Forms.PropertyGrid
		Private WithEvents LayoutButton As Nevron.UI.WinForm.Controls.NButton

		#End Region

		#Region "Fields"

		Private m_Layout As NRadialGraphLayout

		#End Region
	End Class
End Namespace