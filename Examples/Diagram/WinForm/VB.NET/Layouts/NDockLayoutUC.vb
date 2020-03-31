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

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NSpringLayoutUC.
	''' </summary>
	Public Class NDockLayoutUC
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
			Me.label1 = New System.Windows.Forms.Label()
			Me.widthScrollbar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.heightScrollbar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label2 = New System.Windows.Forms.Label()
			Me.ShowDesiredSizeCheckBox = New System.Windows.Forms.CheckBox()
			Me.SuspendLayout()
			' 
			' propertyGrid1
			' 
			Me.propertyGrid1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.propertyGrid1.Location = New System.Drawing.Point(8, 3)
			Me.propertyGrid1.Name = "propertyGrid1"
			Me.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical
			Me.propertyGrid1.Size = New System.Drawing.Size(244, 362)
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
			' label1
			' 
			Me.label1.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.label1.Location = New System.Drawing.Point(3, 397)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(100, 18)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Drawing width:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' widthScrollbar
			' 
			Me.widthScrollbar.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.widthScrollbar.Location = New System.Drawing.Point(8, 415)
			Me.widthScrollbar.Maximum = 1000
			Me.widthScrollbar.Minimum = 200
			Me.widthScrollbar.MinimumSize = New System.Drawing.Size(34, 17)
			Me.widthScrollbar.Name = "widthScrollbar"
			Me.widthScrollbar.Size = New System.Drawing.Size(244, 17)
			Me.widthScrollbar.TabIndex = 4
			Me.widthScrollbar.Value = 400
'			Me.widthScrollbar.ValueChanged += New Nevron.UI.WinForm.Controls.ScrollBarEventHandler(Me.WidthScrollbar_Scroll);
			' 
			' heightScrollbar
			' 
			Me.heightScrollbar.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.heightScrollbar.Location = New System.Drawing.Point(8, 457)
			Me.heightScrollbar.Maximum = 1000
			Me.heightScrollbar.Minimum = 200
			Me.heightScrollbar.MinimumSize = New System.Drawing.Size(34, 17)
			Me.heightScrollbar.Name = "heightScrollbar"
			Me.heightScrollbar.Size = New System.Drawing.Size(244, 17)
			Me.heightScrollbar.TabIndex = 6
			Me.heightScrollbar.Value = 200
'			Me.heightScrollbar.ValueChanged += New Nevron.UI.WinForm.Controls.ScrollBarEventHandler(Me.HeightScrollbar_Scroll);
			' 
			' label2
			' 
			Me.label2.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.label2.Location = New System.Drawing.Point(3, 439)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(100, 18)
			Me.label2.TabIndex = 5
			Me.label2.Text = "Drawing height:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' ShowDesiredSizeCheckBox
			' 
			Me.ShowDesiredSizeCheckBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.ShowDesiredSizeCheckBox.Location = New System.Drawing.Point(8, 371)
			Me.ShowDesiredSizeCheckBox.Name = "ShowDesiredSizeCheckBox"
			Me.ShowDesiredSizeCheckBox.Size = New System.Drawing.Size(244, 17)
			Me.ShowDesiredSizeCheckBox.TabIndex = 8
			Me.ShowDesiredSizeCheckBox.Text = "Show desired size"
			Me.ShowDesiredSizeCheckBox.UseVisualStyleBackColor = True
'			Me.ShowDesiredSizeCheckBox.CheckedChanged += New System.EventHandler(Me.ShowDesiredSizeCheckBox_CheckedChanged);
			' 
			' NDockLayoutUC
			' 
			Me.Controls.Add(Me.ShowDesiredSizeCheckBox)
			Me.Controls.Add(Me.heightScrollbar)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.widthScrollbar)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.LayoutButton)
			Me.Controls.Add(Me.propertyGrid1)
			Me.Name = "NDockLayoutUC"
			Me.Controls.SetChildIndex(Me.propertyGrid1, 0)
			Me.Controls.SetChildIndex(Me.LayoutButton, 0)
			Me.Controls.SetChildIndex(Me.label1, 0)
			Me.Controls.SetChildIndex(Me.widthScrollbar, 0)
			Me.Controls.SetChildIndex(Me.label2, 0)
			Me.Controls.SetChildIndex(Me.heightScrollbar, 0)
			Me.Controls.SetChildIndex(Me.ShowDesiredSizeCheckBox, 0)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' init layout
			m_Layout = New NDockLayout()

			' by default shapes are resized to fit the cell 
			' both horizontally and vertically
			m_Layout.HorizontalContentPlacement = ContentPlacement.Fit
			m_Layout.VerticalContentPlacement = ContentPlacement.Fit

			' show layout properties in the property grid
			propertyGrid1.SelectedObject = m_Layout

			' init view
			view.BeginInit()
			view.Grid.Visible = False
			view.GlobalVisibility.ShowPorts = False
			view.ViewLayout = ViewLayout.Fit

			' init document
			document.BeginInit()
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
			Dim min As Integer = 100
			Dim max As Integer = 200

			Dim shape As NShape
			Dim random As Random = New Random()
			Dim basicShapeFactory As NBasicShapesFactory = New NBasicShapesFactory(document)

			For i As Integer = 0 To 4
				shape = basicShapeFactory.CreateShape(CInt(Fix(BasicShapes.Rectangle)))

				Dim shapeLightColors As Color() = New Color() {Color.FromArgb(236, 97, 49), Color.FromArgb(247, 150, 56), Color.FromArgb(68, 90, 108), Color.FromArgb(129, 133, 133), Color.FromArgb(255, 165, 109)}

				Dim shapeDarkColors As Color() = New Color() {Color.FromArgb(246, 176, 152), Color.FromArgb(251, 203, 156), Color.FromArgb(162, 173, 182), Color.FromArgb(192, 194, 194), Color.FromArgb(255, 210, 182)}

				shape.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, shapeLightColors(i), shapeDarkColors(i))
				shape.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))


				' generate random width and height
				Dim width As Single = random.Next(min, max)
				Dim height As Single = random.Next(min, max)

				' instruct the layouts to use fixed, uses specified desired width and desired height
				shape.LayoutData.UseShapeWidth = False
				shape.LayoutData.DesiredWidth = width

				shape.LayoutData.UseShapeHeight = False
				shape.LayoutData.DesiredHeight = height

				Select Case i
					Case 0
						shape.LayoutData.DockArea = DockArea.Top
						shape.Text = "Top (" & i.ToString() & ")"

					Case 1
						shape.LayoutData.DockArea = DockArea.Bottom
						shape.Text = "Bottom (" & i.ToString() & ")"

					Case 2
						shape.LayoutData.DockArea = DockArea.Left
						shape.Text = "Left (" & i.ToString() & ")"

					Case 3
						shape.LayoutData.DockArea = DockArea.Right
						shape.Text = "Right (" & i.ToString() & ")"

					Case 4
						shape.LayoutData.DockArea = DockArea.Center
						shape.Text = "Center (" & i.ToString() & ")"
				End Select

				'shape.Style.FillStyle = new NColorFillStyle(GetPredefinedColor(i));
				shape.Bounds = New NRectangleF(0, 0, width, height)
				document.ActiveLayer.AddChild(shape)
			Next i
		End Sub

		Private Sub InitFormControls()
			PauseEventsHandling()

			widthScrollbar.Value = CInt(Fix(document.Width))
			heightScrollbar.Value = CInt(Fix(document.Height))

			ResumeEventsHandling()
		End Sub

		Private Sub InitDocument()
			' we do not need history for this example
			document.HistoryService.Pause()

			' create a layer which to host the desired size rect shape
			Dim layer As NLayer = New NLayer()
			document.Layers.AddChild(layer)

			' create the desired size rect shape
			m_DesiredSizeShape = New NRectangleShape(0, 0, 1, 1)
			m_DesiredSizeShape.Style.FillStyle = New NColorFillStyle(System.Drawing.Color.FromArgb(200, 128, 128, 128))
			m_DesiredSizeShape.Style.StrokeStyle = New NStrokeStyle(1, KnownArgbColorValue.Red)
			m_DesiredSizeShape.Visible = ShowDesiredSizeCheckBox.Checked
			layer.AddChild(m_DesiredSizeShape)

			' create a sample diagram
			CreateDiagram()

			' layout it
			LayoutButton.PerformClick()
		End Sub

		Private Sub LayoutButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LayoutButton.Click
			' get the shapes to layout
			Dim shapes As NNodeList = document.ActiveLayer.Children(NFilters.Shape2D)

			' create a layout context
			Dim layoutContext As NLayoutContext = New NLayoutContext()
			layoutContext.GraphAdapter = New NShapeGraphAdapter()
			layoutContext.BodyAdapter = New NShapeBodyAdapter(document)
			layoutContext.BodyContainerAdapter = New NDrawingBodyContainerAdapter(document)

			If Not m_Layout Is Nothing Then
				' update the desired size
				Dim desiredSize As NSizeF = m_Layout.GetDesiredLayoutSize(shapes, layoutContext)
				Dim desiredLayoutArea As NRectangleF = New NRectangleF(layoutContext.BodyContainerAdapter.GetLayoutArea().Location, desiredSize)
				m_DesiredSizeShape.Bounds = desiredLayoutArea

				' layout the shapes
				m_Layout.Layout(shapes, layoutContext)
			End If
		End Sub

		Private Sub WidthScrollbar_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles widthScrollbar.ValueChanged
			If EventsHandlingPaused Then
				Return
			End If

			document.Width = widthScrollbar.Value
			LayoutButton.PerformClick()
		End Sub

		Private Sub HeightScrollbar_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles heightScrollbar.ValueChanged
			If EventsHandlingPaused Then
				Return
			End If

			document.Height = heightScrollbar.Value
			LayoutButton.PerformClick()
		End Sub

		Private Sub ShowDesiredSizeCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowDesiredSizeCheckBox.CheckedChanged
			If m_DesiredSizeShape Is Nothing Then
				Return
			End If

			m_DesiredSizeShape.Visible = ShowDesiredSizeCheckBox.Checked
			document.SmartRefreshAllViews()
		End Sub

		#End Region

		#Region "Designer Fields"

		Private propertyGrid1 As System.Windows.Forms.PropertyGrid
		Private WithEvents ShowDesiredSizeCheckBox As System.Windows.Forms.CheckBox
		Private label2 As System.Windows.Forms.Label
		Private WithEvents LayoutButton As Nevron.UI.WinForm.Controls.NButton
		Private label1 As System.Windows.Forms.Label
		Private WithEvents widthScrollbar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents heightScrollbar As Nevron.UI.WinForm.Controls.NHScrollBar

		#End Region

		#Region "Fields"

		Private m_Layout As NDockLayout
		Private m_DesiredSizeShape As NRectangleShape

		#End Region
	End Class
End Namespace