Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Imports Nevron.Diagram.Layout
Imports Nevron.Editors
Imports Nevron.Dom
Imports Nevron.Diagram.Batches
Imports Nevron.GraphicsCore
Imports Nevron.Diagram
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NWinFormControlHostingUC.
	''' </summary>
	Public Class NWinFormControlHostingUC
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


		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			' init view
			view.Grid.Visible = False
			view.Selection.Mode = DiagramSelectionMode.Single
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
			' create a button
			Dim button As Button = CreateButton()
			Dim buttonShape As NWinFormControlHostShape = New NWinFormControlHostShape(button)
			buttonShape.DeactiveOnLostFocus = False
			document.ActiveLayer.AddChild(buttonShape)

			' create a check box
			Dim check As CheckBox = CreateCheckBox()
			Dim checkShape As NWinFormControlHostShape = New NWinFormControlHostShape(check)
			checkShape.DeactiveOnLostFocus = False
			document.ActiveLayer.AddChild(checkShape)

			' create a combo box
			Dim combo As ComboBox = CreateComboBox()
			Dim comboShape As NWinFormControlHostShape = New NWinFormControlHostShape(combo)
			comboShape.DeactiveOnLostFocus = False
			document.ActiveLayer.AddChild(comboShape)

			' create a list box
			Dim listBox As ListBox = CreateListBox()
			Dim listShape As NWinFormControlHostShape = New NWinFormControlHostShape(listBox)
			listShape.DeactiveOnLostFocus = False
			document.ActiveLayer.AddChild(listShape)

			' create a tree view
			Dim treeView As TreeView = CreateTreeView()
			Dim treeViewShape As NWinFormControlHostShape = New NWinFormControlHostShape(treeView)
			treeViewShape.DeactiveOnLostFocus = False
			document.ActiveLayer.AddChild(treeViewShape)

			' layout the shapes
			buttonShape.Location = New NPointF(10, 10)
			comboShape.Location = New NPointF(210, 10)
			checkShape.Location = New NPointF(410, 10)
			listShape.Location = New NPointF(10, 210)
			treeViewShape.Location = New NPointF(210, 210)

			' create ports on all shapes
			For Each shape As NShape In document.ActiveLayer.Children(Nothing)
				shape.CreateShapeElements(ShapeElementsMask.Ports)
				shape.Ports.AddChild(New NDynamicPort(New NContentAlignment(0, 0), DynamicPortGlueMode.GlueToContour))
			Next shape

			' activate all shapes
			For Each shape As NShape In document.ActiveLayer.Children(Nothing)
				view.StartInplaceEditing(shape)
			Next shape

			' link some of the shapes
			Dim connector1 As NRoutableConnector = New NRoutableConnector()
			connector1.StyleSheetName = "Connectors"
			document.ActiveLayer.AddChild(connector1)
			connector1.FromShape = buttonShape
			connector1.ToShape = comboShape
			connector1.Reroute()

			Dim connector2 As NRoutableConnector = New NRoutableConnector()
			connector2.StyleSheetName = "Connectors"
			document.ActiveLayer.AddChild(connector2)
			connector2.FromShape = buttonShape
			connector2.ToShape = treeViewShape
			connector2.Reroute()

			' mimic default control background
			document.BackgroundStyle.FillStyle = New NColorFillStyle(SystemColors.Control)
		End Sub

		Private Function CreateButton() As Button
			Dim button As Button = New Button()

			button.Text = "Click Me"
			button.Width = 100
			button.Height = 50
			AddHandler button.Click, AddressOf button_Click

			Return button
		End Function
		Private Function CreateCheckBox() As CheckBox
			Dim checkBox As CheckBox = New CheckBox()
			checkBox.Text = "Check"
			Return checkBox
		End Function
		Private Function CreateComboBox() As ComboBox
			Dim comboBox As ComboBox = New ComboBox()
			comboBox.Items.Add("Item1")
			comboBox.Items.Add("Item2")
			comboBox.Items.Add("Item3")
			Return comboBox
		End Function
		Private Function CreateListBox() As ListBox
			Dim listBox As ListBox = New ListBox()
			listBox.IntegralHeight = False
			listBox.Items.Add("Item1")
			listBox.Items.Add("Item2")
			listBox.Items.Add("Item3")
			Return listBox
		End Function
		Private Function CreateTreeView() As TreeView
			Dim treeView As TreeView = New TreeView()
			treeView.Width = 100
			treeView.Height = 100

			Dim node1 As TreeNode = New TreeNode("Node1")
			treeView.Nodes.Add(node1)
			node1.Nodes.Add("Node11")
			node1.Nodes.Add("Node12")

			Dim node2 As TreeNode = New TreeNode("Node2")
			treeView.Nodes.Add(node1)
			node2.Nodes.Add("Node21")
			node2.Nodes.Add("Node22")

			treeView.ExpandAll()
			Return treeView
		End Function

		Private Sub button_Click(ByVal sender As Object, ByVal e As EventArgs)
			MessageBox.Show("Button was clicked")
		End Sub

		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace