Imports Microsoft.VisualBasic
Imports System

Imports Nevron.Diagram
Imports Nevron.Diagram.Extensions
Imports Nevron.Diagram.Layout
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NDiagramClassHierarchyUC.
	''' </summary>
	Public Class NDiagramClassHierarchyUC
		Inherits NDiagramExampleUC
		#Region "Constructor"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			InitializeComponent()
		End Sub
		Shared Sub New()
			TYPES = New Type() { GetType(NLayout), GetType(NPrimitiveShape), GetType(NShapePoint) }
		End Sub

		#End Region

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.label1 = New System.Windows.Forms.Label()
			Me.cbBaseClass = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.cbFormatStyle = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(5, 7)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(62, 13)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Base Class:"
			' 
			' cbBaseClass
			' 
			Me.cbBaseClass.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.cbBaseClass.ListProperties.ColumnOnLeft = False
			Me.cbBaseClass.Location = New System.Drawing.Point(73, 4)
			Me.cbBaseClass.Name = "cbBaseClass"
			Me.cbBaseClass.Size = New System.Drawing.Size(179, 21)
			Me.cbBaseClass.TabIndex = 2
			' 
			' cbFormatStyle
			' 
			Me.cbFormatStyle.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.cbFormatStyle.ListProperties.ColumnOnLeft = False
			Me.cbFormatStyle.Location = New System.Drawing.Point(73, 37)
			Me.cbFormatStyle.Name = "cbFormatStyle"
			Me.cbFormatStyle.Size = New System.Drawing.Size(179, 21)
			Me.cbFormatStyle.TabIndex = 4
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(5, 40)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(68, 13)
			Me.label2.TabIndex = 3
			Me.label2.Text = "Format Style:"
			' 
			' NClassImporterUC
			' 
			Me.Controls.Add(Me.cbFormatStyle)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.cbBaseClass)
			Me.Controls.Add(Me.label1)
			Me.Name = "NClassImporterUC"
			Me.Controls.SetChildIndex(Me.label1, 0)
			Me.Controls.SetChildIndex(Me.cbBaseClass, 0)
			Me.Controls.SetChildIndex(Me.label2, 0)
			Me.Controls.SetChildIndex(Me.cbFormatStyle, 0)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			view.Grid.Visible = False
			view.GlobalVisibility.ShowPorts = False

			' init form controls
			InitFormControls()

			' end view init
			view.EndInit()
		End Sub
		Protected Overrides Sub AttachToEvents()
			MyBase.AttachToEvents()

			AddHandler cbFormatStyle.SelectedIndexChanged, AddressOf cbFormatStyle_SelectedIndexChanged
			AddHandler cbBaseClass.SelectedIndexChanged, AddressOf cbBaseClass_SelectedIndexChanged
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub CreateDiagram(ByVal type As Type)
			document.BeginInit()

			document.Layers.RemoveAllChildren()
			Dim importer As NClassImporter = New NClassImporter(document)
			If cbFormatStyle.SelectedIndex <> -1 Then
				importer.MemberFormatStyle = CType(cbFormatStyle.SelectedItem, MemberFormatStyle)
			End If

			Dim layer As NLayer = importer.Import(type)
			document.ActiveLayerUniqueId = layer.UniqueId
			document.SizeToContent()

			document.EndInit()

			Dim shape As NShape = CType(layer.GetChildByName(type.Name), NShape)
			view.ViewportOrigin = New NPointF(shape.Center.X - view.ViewportSize.Width / 2, 0)
		End Sub
		Private Sub InitFormControls()
			cbFormatStyle.Items.Add(MemberFormatStyle.NameOnly)
			cbFormatStyle.Items.Add(MemberFormatStyle.CSharp)
			cbFormatStyle.Items.Add(MemberFormatStyle.CSharp_Short)
			cbFormatStyle.Items.Add(MemberFormatStyle.Pascal)
			cbFormatStyle.Items.Add(MemberFormatStyle.Pascal_Short)

			Dim i As Integer, count As Integer = TYPES.Length
			i = 0
			Do While i < count
				cbBaseClass.Items.Add(TYPES(i).Name)
				i += 1
			Loop

			cbFormatStyle.SelectedIndex = 0
			cbBaseClass.SelectedIndex = 1

			CreateDiagram(TYPES(cbBaseClass.SelectedIndex))
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub cbBaseClass_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			If cbBaseClass.SelectedIndex = -1 Then
				Return
			End If

			CreateDiagram(TYPES(cbBaseClass.SelectedIndex))
		End Sub
		Private Sub cbFormatStyle_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			If cbFormatStyle.SelectedIndex = -1 Then
				Return
			End If

			CreateDiagram(TYPES(cbBaseClass.SelectedIndex))
		End Sub

		#End Region

		#Region "Designer Fields"

		Private cbBaseClass As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
		Private cbFormatStyle As Nevron.UI.WinForm.Controls.NComboBox
		Private label2 As System.Windows.Forms.Label

		#End Region

		#Region "Fields"

		Private Shared ReadOnly TYPES As Type()

		#End Region
	End Class
End Namespace