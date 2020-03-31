Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	Public Class NColorButtonUC
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


		#End Region

		#Region "Event Handlers"

		Private Sub nCheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox1.CheckedChanged
			For Each c As Control In Controls
				For Each c1 As Control In c.Controls
					If Not(TypeOf c1 Is NButton) Then
						Continue For
					End If
					c1.Enabled = nCheckBox1.Checked
				Next c1
			Next c
		End Sub
		Private Sub nCheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox2.CheckedChanged
			For Each c As Control In Controls
				For Each c1 As Control In c.Controls
					If Not(TypeOf c1 Is NButton) Then
						Continue For
					End If
					CType(c1, NButton).ButtonProperties.ShowFocusRect = nCheckBox2.Checked
				Next c1
			Next c
		End Sub

		Private Sub nCheckBox3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox3.CheckedChanged
			For Each c As Control In Controls
				For Each c1 As Control In c.Controls
					If Not(TypeOf c1 Is NOptionButton) Then
						Continue For
					End If
					CType(c1, NOptionButton).ShowArrow = nCheckBox3.Checked
				Next c1
			Next c
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nColorButton1 = New Nevron.UI.WinForm.Controls.NColorButton()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nColorButton5 = New Nevron.UI.WinForm.Controls.NColorButton()
			Me.nColorButton4 = New Nevron.UI.WinForm.Controls.NColorButton()
			Me.nColorButton3 = New Nevron.UI.WinForm.Controls.NColorButton()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nColorButton13 = New Nevron.UI.WinForm.Controls.NColorButton()
			Me.nColorButton14 = New Nevron.UI.WinForm.Controls.NColorButton()
			Me.nColorButton15 = New Nevron.UI.WinForm.Controls.NColorButton()
			Me.nColorButton16 = New Nevron.UI.WinForm.Controls.NColorButton()
			Me.nCheckBox2 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox3 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nGroupBox1.SuspendLayout()
			Me.nGroupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nColorButton1
			' 
			Me.nColorButton1.ArrowClickOptions = False
			Me.nColorButton1.Color = System.Drawing.Color.White
			Me.nColorButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nColorButton1.Location = New System.Drawing.Point(8, 24)
			Me.nColorButton1.Name = "nColorButton1"
			Me.nColorButton1.Size = New System.Drawing.Size(80, 24)
			Me.nColorButton1.TabIndex = 0
			Me.nColorButton1.Text = "nColorButton1"
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.nColorButton5)
			Me.nGroupBox1.Controls.Add(Me.nColorButton4)
			Me.nGroupBox1.Controls.Add(Me.nColorButton3)
			Me.nGroupBox1.Controls.Add(Me.nColorButton1)
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(8, 8)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(200, 96)
			Me.nGroupBox1.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default
			Me.nGroupBox1.TabIndex = 4
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Drop-down Color Buttons"
			' 
			' nColorButton5
			' 
			Me.nColorButton5.ArrowClickOptions = False
			Me.nColorButton5.Color = System.Drawing.Color.White
			Me.nColorButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nColorButton5.Location = New System.Drawing.Point(96, 56)
			Me.nColorButton5.Name = "nColorButton5"
			Me.nColorButton5.Size = New System.Drawing.Size(80, 24)
			Me.nColorButton5.TabIndex = 3
			Me.nColorButton5.Text = "nColorButton5"
			' 
			' nColorButton4
			' 
			Me.nColorButton4.ArrowClickOptions = False
			Me.nColorButton4.Color = System.Drawing.Color.White
			Me.nColorButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nColorButton4.Location = New System.Drawing.Point(8, 56)
			Me.nColorButton4.Name = "nColorButton4"
			Me.nColorButton4.Size = New System.Drawing.Size(80, 24)
			Me.nColorButton4.TabIndex = 2
			Me.nColorButton4.Text = "nColorButton4"
			' 
			' nColorButton3
			' 
			Me.nColorButton3.ArrowClickOptions = False
			Me.nColorButton3.Color = System.Drawing.Color.White
			Me.nColorButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nColorButton3.Location = New System.Drawing.Point(96, 24)
			Me.nColorButton3.Name = "nColorButton3"
			Me.nColorButton3.Size = New System.Drawing.Size(80, 24)
			Me.nColorButton3.TabIndex = 1
			Me.nColorButton3.Text = "nColorButton3"
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Controls.Add(Me.nColorButton13)
			Me.nGroupBox2.Controls.Add(Me.nColorButton14)
			Me.nGroupBox2.Controls.Add(Me.nColorButton15)
			Me.nGroupBox2.Controls.Add(Me.nColorButton16)
			Me.nGroupBox2.ImageIndex = 0
			Me.nGroupBox2.Location = New System.Drawing.Point(8, 112)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(200, 96)
			Me.nGroupBox2.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default
			Me.nGroupBox2.TabIndex = 5
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "Modal Color Buttons"
			' 
			' nColorButton13
			' 
			Me.nColorButton13.ArrowClickOptions = False
			Me.nColorButton13.Color = System.Drawing.Color.White
			Me.nColorButton13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nColorButton13.Location = New System.Drawing.Point(96, 56)
			Me.nColorButton13.Mode = Nevron.UI.WinForm.Controls.OptionButtonMode.Modal
			Me.nColorButton13.Name = "nColorButton13"
			Me.nColorButton13.Size = New System.Drawing.Size(80, 24)
			Me.nColorButton13.TabIndex = 3
			Me.nColorButton13.Text = "nColorButton5"
			' 
			' nColorButton14
			' 
			Me.nColorButton14.ArrowClickOptions = False
			Me.nColorButton14.Color = System.Drawing.Color.White
			Me.nColorButton14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nColorButton14.Location = New System.Drawing.Point(8, 56)
			Me.nColorButton14.Mode = Nevron.UI.WinForm.Controls.OptionButtonMode.Modal
			Me.nColorButton14.Name = "nColorButton14"
			Me.nColorButton14.Size = New System.Drawing.Size(80, 24)
			Me.nColorButton14.TabIndex = 2
			Me.nColorButton14.Text = "nColorButton4"
			' 
			' nColorButton15
			' 
			Me.nColorButton15.ArrowClickOptions = False
			Me.nColorButton15.Color = System.Drawing.Color.White
			Me.nColorButton15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nColorButton15.Location = New System.Drawing.Point(96, 24)
			Me.nColorButton15.Mode = Nevron.UI.WinForm.Controls.OptionButtonMode.Modal
			Me.nColorButton15.Name = "nColorButton15"
			Me.nColorButton15.Size = New System.Drawing.Size(80, 24)
			Me.nColorButton15.TabIndex = 1
			Me.nColorButton15.Text = "nColorButton3"
			' 
			' nColorButton16
			' 
			Me.nColorButton16.ArrowClickOptions = False
			Me.nColorButton16.Color = System.Drawing.Color.White
			Me.nColorButton16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nColorButton16.Location = New System.Drawing.Point(8, 24)
			Me.nColorButton16.Mode = Nevron.UI.WinForm.Controls.OptionButtonMode.Modal
			Me.nColorButton16.Name = "nColorButton16"
			Me.nColorButton16.Size = New System.Drawing.Size(80, 24)
			Me.nColorButton16.TabIndex = 0
			Me.nColorButton16.Text = "nColorButton1"
			' 
			' nCheckBox2
			' 
			Me.nCheckBox2.Location = New System.Drawing.Point(8, 240)
			Me.nCheckBox2.Name = "nCheckBox2"
			Me.nCheckBox2.Size = New System.Drawing.Size(128, 24)
			Me.nCheckBox2.TabIndex = 19
			Me.nCheckBox2.Text = "Show &Focus Rect"
'			Me.nCheckBox2.CheckedChanged += New System.EventHandler(Me.nCheckBox2_CheckedChanged);
			' 
			' nCheckBox1
			' 
			Me.nCheckBox1.Checked = True
			Me.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
			Me.nCheckBox1.Location = New System.Drawing.Point(8, 216)
			Me.nCheckBox1.Name = "nCheckBox1"
			Me.nCheckBox1.TabIndex = 18
			Me.nCheckBox1.Text = "&Enable"
'			Me.nCheckBox1.CheckedChanged += New System.EventHandler(Me.nCheckBox1_CheckedChanged);
			' 
			' nCheckBox3
			' 
			Me.nCheckBox3.Checked = True
			Me.nCheckBox3.CheckState = System.Windows.Forms.CheckState.Checked
			Me.nCheckBox3.Location = New System.Drawing.Point(8, 264)
			Me.nCheckBox3.Name = "nCheckBox3"
			Me.nCheckBox3.TabIndex = 23
			Me.nCheckBox3.Text = "Show &Arrow"
'			Me.nCheckBox3.CheckedChanged += New System.EventHandler(Me.nCheckBox3_CheckedChanged);
			' 
			' NColorButtonUC
			' 
			Me.Controls.Add(Me.nCheckBox3)
			Me.Controls.Add(Me.nCheckBox2)
			Me.Controls.Add(Me.nCheckBox1)
			Me.Controls.Add(Me.nGroupBox2)
			Me.Controls.Add(Me.nGroupBox1)
			Me.Name = "NColorButtonUC"
			Me.Size = New System.Drawing.Size(224, 296)
			Me.nGroupBox1.ResumeLayout(False)
			Me.nGroupBox2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nColorButton3 As Nevron.UI.WinForm.Controls.NColorButton
		Private nColorButton4 As Nevron.UI.WinForm.Controls.NColorButton
		Private nColorButton5 As Nevron.UI.WinForm.Controls.NColorButton
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nColorButton13 As Nevron.UI.WinForm.Controls.NColorButton
		Private nColorButton14 As Nevron.UI.WinForm.Controls.NColorButton
		Private nColorButton15 As Nevron.UI.WinForm.Controls.NColorButton
		Private nColorButton16 As Nevron.UI.WinForm.Controls.NColorButton
		Private WithEvents nCheckBox2 As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents nCheckBox1 As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents nCheckBox3 As Nevron.UI.WinForm.Controls.NCheckBox

		Private nColorButton1 As Nevron.UI.WinForm.Controls.NColorButton

		#End Region
	End Class
End Namespace
