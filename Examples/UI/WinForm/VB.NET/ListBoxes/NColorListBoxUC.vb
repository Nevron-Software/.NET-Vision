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
	Public Class NColorListBoxUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
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
		Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad (e)

			nColorListBox1.PopulateKnownColors()
			nColorListBox2.PopulateWebColors()
			nColorListBox3.PopulateSystemColors()

			Dim c As Color
			Dim item As NListBoxItem

			nColorListBox4.BeginUpdate()
			For i As Integer = 0 To 255 Step 30
				For j As Integer = 0 To 255 Step 30
					For k As Integer = 0 To 255 Step 30
						c = Color.FromArgb(i, j, k)
						item = New NListBoxItem(c)
						item.Text = ColorTranslator.ToHtml(c)

						nColorListBox4.Items.Add(item)
					Next k
				Next j
			Next i
			nColorListBox4.EndUpdate()
		End Sub

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nColorListBox1.PopulateKnownColors()
			nColorListBox2.PopulateWebColors()
			nColorListBox3.PopulateSystemColors()

			Dim c As Color
			Dim item As NListBoxItem

			nColorListBox4.BeginUpdate()

			For i As Integer = 0 To 255 Step 30
				For j As Integer = 0 To 255 Step 30
					For k As Integer = 0 To 255 Step 30
						c = Color.FromArgb(i, j, k)
						item = New NListBoxItem(c)
						item.Text = ColorTranslator.ToHtml(c)

						nColorListBox4.Items.Add(item)
					Next k
				Next j
			Next i

			nColorListBox4.EndUpdate()
		End Sub



		#End Region

		#Region "Event Handlers"

		Private Sub nCheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox1.CheckedChanged
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


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nColorListBox1 = New Nevron.UI.WinForm.Controls.NColorListBox()
			Me.nColorListBox2 = New Nevron.UI.WinForm.Controls.NColorListBox()
			Me.nColorListBox3 = New Nevron.UI.WinForm.Controls.NColorListBox()
			Me.nColorListBox4 = New Nevron.UI.WinForm.Controls.NColorListBox()
			Me.nCheckBox3 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox2 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' nColorListBox1
			' 
			Me.nColorListBox1.Location = New System.Drawing.Point(8, 8)
			Me.nColorListBox1.Name = "nColorListBox1"
			Me.nColorListBox1.Size = New System.Drawing.Size(200, 144)
			Me.nColorListBox1.TabIndex = 0
			Me.nColorListBox1.Items.AddRange(New Nevron.UI.WinForm.Controls.NListBoxItem(){})
			' 
			' nColorListBox2
			' 
			Me.nColorListBox2.Location = New System.Drawing.Point(8, 160)
			Me.nColorListBox2.Name = "nColorListBox2"
			Me.nColorListBox2.Size = New System.Drawing.Size(200, 144)
			Me.nColorListBox2.TabIndex = 1
			Me.nColorListBox2.Items.AddRange(New Nevron.UI.WinForm.Controls.NListBoxItem(){})
			' 
			' nColorListBox3
			' 
			Me.nColorListBox3.Location = New System.Drawing.Point(216, 8)
			Me.nColorListBox3.Name = "nColorListBox3"
			Me.nColorListBox3.Size = New System.Drawing.Size(200, 144)
			Me.nColorListBox3.TabIndex = 2
			Me.nColorListBox3.Items.AddRange(New Nevron.UI.WinForm.Controls.NListBoxItem(){})
			' 
			' nColorListBox4
			' 
			Me.nColorListBox4.Location = New System.Drawing.Point(216, 160)
			Me.nColorListBox4.Name = "nColorListBox4"
			Me.nColorListBox4.Size = New System.Drawing.Size(200, 144)
			Me.nColorListBox4.TabIndex = 3
			Me.nColorListBox4.Items.AddRange(New Nevron.UI.WinForm.Controls.NListBoxItem(){})
			' 
			' nCheckBox3
			' 
			Me.nCheckBox3.Checked = True
			Me.nCheckBox3.CheckState = System.Windows.Forms.CheckState.Checked
			Me.nCheckBox3.Location = New System.Drawing.Point(256, 312)
			Me.nCheckBox3.Name = "nCheckBox3"
			Me.nCheckBox3.TabIndex = 15
			Me.nCheckBox3.Text = "&Enable"
'			Me.nCheckBox3.CheckedChanged += New System.EventHandler(Me.nCheckBox3_CheckedChanged);
			' 
			' nCheckBox2
			' 
			Me.nCheckBox2.Location = New System.Drawing.Point(112, 312)
			Me.nCheckBox2.Name = "nCheckBox2"
			Me.nCheckBox2.Size = New System.Drawing.Size(136, 24)
			Me.nCheckBox2.TabIndex = 14
			Me.nCheckBox2.Text = "Show &Focus Rect"
'			Me.nCheckBox2.CheckedChanged += New System.EventHandler(Me.nCheckBox2_CheckedChanged);
			' 
			' nCheckBox1
			' 
			Me.nCheckBox1.Location = New System.Drawing.Point(8, 312)
			Me.nCheckBox1.Name = "nCheckBox1"
			Me.nCheckBox1.Size = New System.Drawing.Size(96, 24)
			Me.nCheckBox1.TabIndex = 13
			Me.nCheckBox1.Text = "&CheckBoxes"
'			Me.nCheckBox1.CheckedChanged += New System.EventHandler(Me.nCheckBox1_CheckedChanged);
			' 
			' NColorListBoxUC
			' 
			Me.Controls.Add(Me.nCheckBox3)
			Me.Controls.Add(Me.nCheckBox2)
			Me.Controls.Add(Me.nCheckBox1)
			Me.Controls.Add(Me.nColorListBox4)
			Me.Controls.Add(Me.nColorListBox3)
			Me.Controls.Add(Me.nColorListBox2)
			Me.Controls.Add(Me.nColorListBox1)
			Me.Name = "NColorListBoxUC"
			Me.Size = New System.Drawing.Size(424, 344)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		Private nColorListBox1 As Nevron.UI.WinForm.Controls.NColorListBox
		Private nColorListBox2 As Nevron.UI.WinForm.Controls.NColorListBox
		Private nColorListBox3 As Nevron.UI.WinForm.Controls.NColorListBox
		Private nColorListBox4 As Nevron.UI.WinForm.Controls.NColorListBox
		Private WithEvents nCheckBox3 As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents nCheckBox2 As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents nCheckBox1 As Nevron.UI.WinForm.Controls.NCheckBox

		#End Region
	End Class
End Namespace
