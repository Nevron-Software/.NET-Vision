Imports Microsoft.VisualBasic
Imports System
Imports System.Reflection
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.Dom
Imports Nevron.Editors
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.WinForm
Imports Nevron.UI.WinForm.Controls

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NAbilitiesProtectionAndPermissionsUC.
	''' </summary>
	Public Class NAbilitiesProtectionAndPermissionsUC
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
			Me.addShapeButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.protectionListBox = New Nevron.UI.WinForm.Controls.NListBox()
			Me.allButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.protectionGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.noneButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.protectionGroupBox.SuspendLayout()
			Me.SuspendLayout()
			' 
			' addShapeButton
			' 
			Me.addShapeButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.addShapeButton.Location = New System.Drawing.Point(8, 472)
			Me.addShapeButton.Name = "addShapeButton"
			Me.addShapeButton.Size = New System.Drawing.Size(232, 23)
			Me.addShapeButton.TabIndex = 1
			Me.addShapeButton.Text = "Add random shape"
'			Me.addShapeButton.Click += New System.EventHandler(Me.addShapeButton_Click);
			' 
			' protectionListBox
			' 
			Me.protectionListBox.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.protectionListBox.CheckBoxes = True
			Me.protectionListBox.CheckOnClick = True
			Me.protectionListBox.ColumnOnLeft = False
			Me.protectionListBox.Location = New System.Drawing.Point(8, 48)
			Me.protectionListBox.Name = "protectionListBox"
			Me.protectionListBox.Size = New System.Drawing.Size(234, 406)
			Me.protectionListBox.TabIndex = 2
'			Me.protectionListBox.CheckedChanged += New Nevron.UI.WinForm.Controls.NListBoxItemCheckedEventHandler(Me.protectionListBox_CheckedChanged);
			' 
			' allButton
			' 
			Me.allButton.Location = New System.Drawing.Point(8, 16)
			Me.allButton.Name = "allButton"
			Me.allButton.Size = New System.Drawing.Size(104, 23)
			Me.allButton.TabIndex = 0
			Me.allButton.Text = "All"
'			Me.allButton.Click += New System.EventHandler(Me.allButton_Click);
			' 
			' protectionGroupBox
			' 
			Me.protectionGroupBox.Controls.Add(Me.allButton)
			Me.protectionGroupBox.Controls.Add(Me.protectionListBox)
			Me.protectionGroupBox.Controls.Add(Me.noneButton)
			Me.protectionGroupBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.protectionGroupBox.Enabled = False
			Me.protectionGroupBox.ImageIndex = 0
			Me.protectionGroupBox.Location = New System.Drawing.Point(0, 0)
			Me.protectionGroupBox.Name = "protectionGroupBox"
			Me.protectionGroupBox.Size = New System.Drawing.Size(250, 464)
			Me.protectionGroupBox.TabIndex = 0
			Me.protectionGroupBox.TabStop = False
			Me.protectionGroupBox.Text = "Selected shape protection"
			' 
			' noneButton
			' 
			Me.noneButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.noneButton.Location = New System.Drawing.Point(120, 16)
			Me.noneButton.Name = "noneButton"
			Me.noneButton.Size = New System.Drawing.Size(122, 23)
			Me.noneButton.TabIndex = 1
			Me.noneButton.Text = "None"
'			Me.noneButton.Click += New System.EventHandler(Me.noneButton_Click);
			' 
			' NAbilitiesProtectionAndPermissionsUC
			' 
			Me.Controls.Add(Me.protectionGroupBox)
			Me.Controls.Add(Me.addShapeButton)
			Me.Name = "NAbilitiesProtectionAndPermissionsUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.addShapeButton, 0)
			Me.Controls.SetChildIndex(Me.protectionGroupBox, 0)
			Me.protectionGroupBox.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			' init view
			view.Grid.Visible = False
			view.GlobalVisibility.ShowPorts = False

			' init document
			document.BeginInit()
			InitDocument()
			document.EndInit()

			' end view init
			view.EndInit()

			InitFormControls()
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

			protectionListBox.Items.Clear()

			For Each obj As Object In System.Enum.GetValues(GetType(AbilitiesMask))
				Dim cur As AbilitiesMask = CType(obj, AbilitiesMask)

				If (Not cur.Equals(AbilitiesMask.All)) AndAlso (Not cur.Equals(AbilitiesMask.None)) Then
					protectionListBox.Items.Add(cur)
				End If
			Next obj

			ResumeEventsHandling()
		End Sub

		Private Sub InitDocument()
			document.Style.TextStyle = New NTextStyle(New Font("Arial Narrow", 8.75f))
			document.Style.FillStyle = New NColorFillStyle(Color.MintCream)

			Dim row As Integer = 0
			Dim col As Integer = 0

			Dim values As Array = System.Enum.GetValues(GetType(AbilitiesMask))

			Dim i As Integer = 0
			Do While i < values.Length
				Dim cur As AbilitiesMask = CType(values.GetValue(i), AbilitiesMask)

				If (Not cur.Equals(AbilitiesMask.All)) AndAlso (Not cur.Equals(AbilitiesMask.None)) Then
					If col >= 4 Then
						col = 0
						row += 1
					End If

					If cur.Equals(AbilitiesMask.Ungroup) Then
						CreateGroup(row, col, cur)
					ElseIf cur.Equals(AbilitiesMask.Group) OrElse cur.Equals(AbilitiesMask.Compose) Then
						CreateTwoRectangles(row, col, cur)
					ElseIf cur.Equals(AbilitiesMask.Decompose) Then
						CreateCompositeShape(row, col, cur)
					ElseIf cur.Equals(AbilitiesMask.ChangeStartPoint) OrElse cur.Equals(AbilitiesMask.ChangeEndPoint) Then
						CreateLine(row, col, cur)
					Else
						CreateRectangle(row, col, cur)
					End If

					col += 1
				End If
				i += 1
			Loop

			document.SizeToContent()
		End Sub

		Private Sub CreateGroup(ByVal row As Integer, ByVal col As Integer, ByVal protection As AbilitiesMask)
			' create a group
			Dim group As NGroup = New NGroup()
			group.Protection = New NAbilities(protection)

			' add two rectangle shapes in it
			group.Shapes.AddChild(New NRectangleShape(New NRectangleF(0, 0, 1, 1)))
			group.Shapes.AddChild(New NRectangleShape(New NRectangleF(2, 2, 1, 1)))

			' update the group model bounds to fit the shapes
			group.UpdateModelBounds()

			' transform the group to fit in the specified bounds
			group.Bounds = MyBase.GetGridCell(row, col)

			' create the labels shape element
			group.CreateShapeElements(ShapeElementsMask.Labels)

			' create the default label
			Dim label As NRotatedBoundsLabel = New NRotatedBoundsLabel("", group.UniqueId, New Nevron.Diagram.NMargins(0))
			group.Labels.AddChild(label)
			group.Labels.DefaultLabelUniqueId = label.UniqueId

			' assign text to the group
			group.Text = "Protected from: " & protection.ToString()

			' add the group to the active layer
			document.ActiveLayer.AddChild(group)
		End Sub

		Private Sub CreateTwoRectangles(ByVal row As Integer, ByVal col As Integer, ByVal protection As AbilitiesMask)
			' create the first rectangle shape
			Dim rect As NRectangleF = MyBase.GetGridCell(row, col)
			rect = New NRectangleF(rect.X, rect.Y, rect.Width / 2, rect.Height / 2)

			Dim rect1 As NRectangleShape = New NRectangleShape(rect)
			rect1.Protection = New NAbilities(protection)
			rect1.Text = "Protected from: " & protection.ToString()
			document.ActiveLayer.AddChild(rect1)

			' create the second rectangle shape
			rect = MyBase.GetGridCell(row, col)
			rect = New NRectangleF(rect.X + rect.Width / 2, rect.Y + rect.Height / 2, rect.Width / 2, rect.Height / 2)

			Dim rect2 As NRectangleShape = New NRectangleShape(rect)
			rect2.Protection = New NAbilities(protection)
			rect2.Text = "Protected from: " & protection.ToString()
			document.ActiveLayer.AddChild(rect2)
		End Sub

		Private Sub CreateRectangle(ByVal row As Integer, ByVal col As Integer, ByVal protection As AbilitiesMask)
			' create a rectangle 
			Dim rect As NRectangleShape = New NRectangleShape(MyBase.GetGridCell(row, col))

			rect.Protection = New NAbilities(protection)
			rect.Text = "Protected from: " & protection.ToString()

			document.ActiveLayer.AddChild(rect)
		End Sub

		Private Sub CreateLine(ByVal row As Integer, ByVal col As Integer, ByVal protection As AbilitiesMask)
			' create a line
			Dim rect As NRectangleF = MyBase.GetGridCell(row, col)
			Dim line As NLineShape = New NLineShape(rect.X, rect.Y, rect.Right, rect.Bottom)

			line.Protection = New NAbilities(protection)
			line.Text = "Protected from: " & protection.ToString()

			document.ActiveLayer.AddChild(line)
		End Sub

		Private Sub CreateCompositeShape(ByVal row As Integer, ByVal col As Integer, ByVal protection As AbilitiesMask)
			' create a composite shape 
			Dim shape As NCompositeShape = New NCompositeShape()

			shape.Protection = New NAbilities(protection)
			shape.Text = "Protected from: " & protection.ToString()

			shape.Primitives.AddChild(New NRectanglePath(New NRectangleF(0, 0, 1, 1)))
			shape.Primitives.AddChild(New NRectanglePath(New NRectangleF(2, 2, 1, 1)))

			shape.UpdateModelBounds()
			shape.Bounds = MyBase.GetGridCell(row, col)

			document.ActiveLayer.AddChild(shape)
		End Sub

		Private Sub AddRandomShape()
			Dim values As Array = System.Enum.GetValues(GetType(BasicShapes))

			Dim factory As NBasicShapesFactory = New NBasicShapesFactory(document)
			Dim shape As NShape = factory.CreateShape(CInt(Fix(values.GetValue(Random.Next(values.Length)))))

			Dim size As NSizeF = New NSizeF(Random.Next(10) + 30, Random.Next(10) + 30)
			shape.Bounds = New NRectangleF(MyBase.GetRandomPoint(view.Viewport), size)
			shape.Style.FillStyle = New NColorFillStyle(Color.GreenYellow)

			document.ActiveLayer.AddChild(shape)
		End Sub

		Private Sub UpdateProtectionListBox()
			Dim shape As NShape = (TryCast(view.Selection.AnchorNode, NShape))
			If shape Is Nothing Then
				protectionGroupBox.Enabled = False
				Return
			End If

			protectionGroupBox.Enabled = True

			Dim i As Integer = 0
			Do While i < protectionListBox.Items.Count
				Dim item As NListBoxItem = protectionListBox.Items(i)
				item.Checked = shape.Protection.Contains(CType(item.Tag, AbilitiesMask))
				i += 1
			Loop
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub protectionListBox_CheckedChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.NListBoxItemCheckEventArgs) Handles protectionListBox.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim shape As NShape = (TryCast(view.Selection.AnchorNode, NShape))
			If shape Is Nothing Then
				Return
			End If

			PauseEventsHandling()

			Dim i As Integer = 0
			Do While i < protectionListBox.Items.Count
				Dim item As NListBoxItem = protectionListBox.Items(i)

				Dim protection As NAbilities = shape.Protection
				If item.Checked Then
					protection.Mask = protection.Mask Or CType(item.Tag, AbilitiesMask)
				Else
					protection.Mask = protection.Mask And Not CType(item.Tag, AbilitiesMask)
				End If
				shape.Protection = protection
				i += 1
			Loop

			document.SmartRefreshAllViews()
			ResumeEventsHandling()
		End Sub

		Private Sub allButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles allButton.Click
			If EventsHandlingPaused Then
				Return
			End If

			Dim shape As NShape = (TryCast(view.Selection.AnchorNode, NShape))
			If shape Is Nothing Then
				Return
			End If

			PauseEventsHandling()

			shape.Protection = New NAbilities(AbilitiesMask.All)
			UpdateProtectionListBox()

			document.SmartRefreshAllViews()
			ResumeEventsHandling()
		End Sub

		Private Sub noneButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles noneButton.Click
			If EventsHandlingPaused Then
				Return
			End If

			Dim shape As NShape = (TryCast(view.Selection.AnchorNode, NShape))
			If shape Is Nothing Then
				Return
			End If

			PauseEventsHandling()

			shape.Protection = New NAbilities(AbilitiesMask.None)
			UpdateProtectionListBox()

			document.SmartRefreshAllViews()
			ResumeEventsHandling()
		End Sub

		Private Sub addShapeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles addShapeButton.Click
			AddRandomShape()
			document.SmartRefreshAllViews()
		End Sub


		Private Sub EventSinkService_NodeSelected(ByVal args As NNodeEventArgs)
			If EventsHandlingPaused Then
				Return
			End If

			PauseEventsHandling()
			UpdateProtectionListBox()
			ResumeEventsHandling()
		End Sub

		Private Sub EventSinkService_NodeDeselected(ByVal args As NNodeEventArgs)
			If EventsHandlingPaused Then
				Return
			End If

			PauseEventsHandling()
			UpdateProtectionListBox()
			ResumeEventsHandling()
		End Sub


		#End Region

		#Region "Designer Fields"

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents addShapeButton As Nevron.UI.WinForm.Controls.NButton
		Private protectionGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents allButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents noneButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents protectionListBox As Nevron.UI.WinForm.Controls.NListBox

		#End Region
	End Class
End Namespace