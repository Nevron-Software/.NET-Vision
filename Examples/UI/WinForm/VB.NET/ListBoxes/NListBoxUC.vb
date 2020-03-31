Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	Public Class NListBoxUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()
		End Sub
		Public Sub New()
			InitializeComponent()
		End Sub


		#End Region

		#Region "Implementation"

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		Public Overrides Sub Initialize()
			MyBase.Initialize ()

			Dim count As Integer = 10
			Dim item1, item2, item3, item4, item5 As NListBoxItem

			Dim i As Integer = 0
			Do While i < count
				item1 = New NListBoxItem(i, "Item " & i, False)
				item2 = New NListBoxItem(i, "Item " & i, False)
				item3 = New NListBoxItem(i, "Item " & i, False)
				item4 = New NListBoxItem(i, "Item " & i, False)
				item5 = New NListBoxItem(i, "Item " & i, False)

				nListBox1.Items.Add(item1)
				nListBox2.Items.Add(item2)
				nListBox3.Items.Add(item3)
				nListBox4.Items.Add(item4)
				nListBox5.Items.Add(item5)
				i += 1
			Loop

			nListBox1.ImageList = MainForm.TestImages
			nListBox2.ImageList = MainForm.TestImages
			nListBox3.ImageList = MainForm.TestImages
			nListBox4.ImageList = MainForm.TestImages
			nListBox5.ImageList = MainForm.TestImages

			m_CheckStyleCombo.ListProperties.ColumnOnLeft = False
			m_CheckStyleCombo.FillFromEnum(GetType(CheckStyle), False)
			m_CheckStyleCombo.SelectedItem = CheckStyle.Standard
			AddHandler m_CheckStyleCombo.SelectedIndexChanged, AddressOf m_CheckStyleCombo_SelectedIndexChanged
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub nCheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox1.CheckedChanged
			nCheckBox4.Enabled = nCheckBox1.Checked
			For Each c As Control In Controls
				If Not(TypeOf c Is NListBox) Then
					Continue For
				End If

				CType(c, NListBox).CheckBoxes = nCheckBox1.Checked
			Next c
		End Sub

		Private Sub nCheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox2.CheckedChanged
			For Each c As Control In Controls
				If Not(TypeOf c Is NListBox) Then
					Continue For
				End If

				CType(c, NListBox).ShowFocusRect = nCheckBox2.Checked
			Next c
		End Sub

		Private Sub nCheckBox3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox3.CheckedChanged
			For Each c As Control In Controls
				If Not(TypeOf c Is NListBox) Then
					Continue For
				End If

				CType(c, NListBox).Enabled = nCheckBox3.Checked
			Next c
		End Sub

		Private Sub nCheckBox4_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox4.CheckedChanged
			For Each c As Control In Controls
				If Not(TypeOf c Is NListBox) Then
					Continue For
				End If

				CType(c, NListBox).CheckOnClick = nCheckBox4.Checked
			Next c
		End Sub

		Private Sub m_BorderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_BorderButton.Click
			Dim border As NControlBorder = nListBox1.Border
			border.ShowEditor()

			'apply the border change to all listboxes
			Dim count As Integer = Controls.Count
			Dim list As NListBox

			Dim i As Integer = 0
			Do While i < count
				list = TryCast(Controls(i), NListBox)
				If list Is Nothing OrElse list Is nListBox1 Then
					Continue Do
				End If

				list.Border.Copy(border)
				i += 1
			Loop
		End Sub

		Private Sub m_CheckStyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim o As Object = m_CheckStyleCombo.SelectedItem
			If Not(TypeOf o Is CheckStyle) Then
				Return
			End If

			Dim style As CheckStyle = CType(o, CheckStyle)
			Dim count As Integer = Controls.Count
			Dim list As NListBox

			Dim i As Integer = 0
			Do While i < count
				list = TryCast(Controls(i), NListBox)
				If list Is Nothing Then
					Continue Do
				End If

				list.CheckStyle = style
				i += 1
			Loop
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.nListBox1 = New Nevron.UI.WinForm.Controls.NListBox()
			Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
			Me.nListBox2 = New Nevron.UI.WinForm.Controls.NListBox()
			Me.nListBox3 = New Nevron.UI.WinForm.Controls.NListBox()
			Me.nListBox4 = New Nevron.UI.WinForm.Controls.NListBox()
			Me.nListBox5 = New Nevron.UI.WinForm.Controls.NListBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.nCheckBox1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox2 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox3 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox4 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_BorderButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_CheckStyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' nListBox1
			' 
			Me.nListBox1.DefaultImageIndex = 3
			Me.nListBox1.ImageList = Me.imageList1
			Me.nListBox1.Location = New System.Drawing.Point(8, 32)
			Me.nListBox1.Name = "nListBox1"
			Me.nListBox1.Size = New System.Drawing.Size(216, 144)
			Me.nListBox1.TabIndex = 0
			' 
			' imageList1
			' 
			Me.imageList1.ImageSize = New System.Drawing.Size(16, 16)
			Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
			' 
			' nListBox2
			' 
			Me.nListBox2.DefaultImageIndex = 5
			Me.nListBox2.ImageList = Me.imageList1
			Me.nListBox2.Location = New System.Drawing.Point(232, 216)
			Me.nListBox2.MultiColumn = True
			Me.nListBox2.Name = "nListBox2"
			Me.nListBox2.Size = New System.Drawing.Size(216, 144)
			Me.nListBox2.TabIndex = 1
			' 
			' nListBox3
			' 
			Me.nListBox3.DefaultImageIndex = 1
			Me.nListBox3.HorizontalExtent = 500
			Me.nListBox3.HorizontalScrollbar = True
			Me.nListBox3.ImageList = Me.imageList1
			Me.nListBox3.Location = New System.Drawing.Point(232, 32)
			Me.nListBox3.Name = "nListBox3"
			Me.nListBox3.Size = New System.Drawing.Size(216, 141)
			Me.nListBox3.TabIndex = 2
			' 
			' nListBox4
			' 
			Me.nListBox4.DefaultImageIndex = 4
			Me.nListBox4.ImageList = Me.imageList1
			Me.nListBox4.Location = New System.Drawing.Point(8, 216)
			Me.nListBox4.Name = "nListBox4"
			Me.nListBox4.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
			Me.nListBox4.Size = New System.Drawing.Size(216, 144)
			Me.nListBox4.TabIndex = 3
			' 
			' nListBox5
			' 
			Me.nListBox5.DefaultImageIndex = 9
			Me.nListBox5.ImageList = Me.imageList1
			Me.nListBox5.Location = New System.Drawing.Point(456, 32)
			Me.nListBox5.Name = "nListBox5"
			Me.nListBox5.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
			Me.nListBox5.Size = New System.Drawing.Size(216, 144)
			Me.nListBox5.TabIndex = 4
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 0)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(128, 23)
			Me.label1.TabIndex = 5
			Me.label1.Text = "Default NListBox:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(232, 0)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(176, 23)
			Me.label2.TabIndex = 6
			Me.label2.Text = "NListBox with HorizontalScrollBar:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 184)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(216, 23)
			Me.label3.TabIndex = 7
			Me.label3.Text = "NListBox with SelectionMode.MultiSimple:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(456, 0)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(232, 23)
			Me.label4.TabIndex = 8
			Me.label4.Text = "NListBox with SelectionMode.MultiExtended:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(232, 184)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(176, 23)
			Me.label5.TabIndex = 9
			Me.label5.Text = "NListBox with MultiColumn:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' nCheckBox1
			' 
			Me.nCheckBox1.Location = New System.Drawing.Point(512, 216)
			Me.nCheckBox1.Name = "nCheckBox1"
			Me.nCheckBox1.Size = New System.Drawing.Size(96, 24)
			Me.nCheckBox1.TabIndex = 10
			Me.nCheckBox1.Text = "&CheckBoxes"
'			Me.nCheckBox1.CheckedChanged += New System.EventHandler(Me.nCheckBox1_CheckedChanged);
			' 
			' nCheckBox2
			' 
			Me.nCheckBox2.Location = New System.Drawing.Point(512, 320)
			Me.nCheckBox2.Name = "nCheckBox2"
			Me.nCheckBox2.Size = New System.Drawing.Size(120, 24)
			Me.nCheckBox2.TabIndex = 11
			Me.nCheckBox2.Text = "Show &Focus Rect"
'			Me.nCheckBox2.CheckedChanged += New System.EventHandler(Me.nCheckBox2_CheckedChanged);
			' 
			' nCheckBox3
			' 
			Me.nCheckBox3.Checked = True
			Me.nCheckBox3.CheckState = System.Windows.Forms.CheckState.Checked
			Me.nCheckBox3.Location = New System.Drawing.Point(512, 344)
			Me.nCheckBox3.Name = "nCheckBox3"
			Me.nCheckBox3.TabIndex = 12
			Me.nCheckBox3.Text = "&Enable"
'			Me.nCheckBox3.CheckedChanged += New System.EventHandler(Me.nCheckBox3_CheckedChanged);
			' 
			' nCheckBox4
			' 
			Me.nCheckBox4.Enabled = False
			Me.nCheckBox4.Location = New System.Drawing.Point(512, 240)
			Me.nCheckBox4.Name = "nCheckBox4"
			Me.nCheckBox4.TabIndex = 13
			Me.nCheckBox4.Text = "Check On &Click"
'			Me.nCheckBox4.CheckedChanged += New System.EventHandler(Me.nCheckBox4_CheckedChanged);
			' 
			' m_BorderButton
			' 
			Me.m_BorderButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
			Me.m_BorderButton.Location = New System.Drawing.Point(512, 376)
			Me.m_BorderButton.Name = "m_BorderButton"
			Me.m_BorderButton.PaletteInheritance = (CType((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable Or Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes), Nevron.UI.WinForm.Controls.PaletteInheritance))
			Me.m_BorderButton.Size = New System.Drawing.Size(104, 24)
			Me.m_BorderButton.TabIndex = 14
			Me.m_BorderButton.Text = "Border..."
'			Me.m_BorderButton.Click += New System.EventHandler(Me.m_BorderButton_Click);
			' 
			' m_CheckStyleCombo
			' 
			Me.m_CheckStyleCombo.Location = New System.Drawing.Point(512, 288)
			Me.m_CheckStyleCombo.Name = "m_CheckStyleCombo"
			Me.m_CheckStyleCombo.Size = New System.Drawing.Size(160, 21)
			Me.m_CheckStyleCombo.TabIndex = 15
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(512, 264)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(80, 23)
			Me.label6.TabIndex = 16
			Me.label6.Text = "Check Style:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' NListBoxUC
			' 
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.m_CheckStyleCombo)
			Me.Controls.Add(Me.m_BorderButton)
			Me.Controls.Add(Me.nCheckBox4)
			Me.Controls.Add(Me.nCheckBox3)
			Me.Controls.Add(Me.nCheckBox2)
			Me.Controls.Add(Me.nCheckBox1)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.nListBox5)
			Me.Controls.Add(Me.nListBox4)
			Me.Controls.Add(Me.nListBox3)
			Me.Controls.Add(Me.nListBox2)
			Me.Controls.Add(Me.nListBox1)
			Me.Name = "NListBoxUC"
			Me.Size = New System.Drawing.Size(680, 408)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private nListBox1 As Nevron.UI.WinForm.Controls.NListBox
		Private nListBox2 As Nevron.UI.WinForm.Controls.NListBox
		Private nListBox3 As Nevron.UI.WinForm.Controls.NListBox
		Private nListBox4 As Nevron.UI.WinForm.Controls.NListBox
		Private nListBox5 As Nevron.UI.WinForm.Controls.NListBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private WithEvents nCheckBox1 As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents nCheckBox2 As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents nCheckBox3 As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents nCheckBox4 As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_BorderButton As Nevron.UI.WinForm.Controls.NButton
		Private m_CheckStyleCombo As NComboBox
		Private imageList1 As System.Windows.Forms.ImageList
		Private label6 As System.Windows.Forms.Label
		Private components As System.ComponentModel.IContainer

		#End Region
	End Class
End Namespace
