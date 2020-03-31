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
	Public Class NOptionButtonUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()
		End Sub


		#End Region

		#Region "Overrides"

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

		Private Sub OnOptionButton2ShowDialog(ByVal sender As Object, ByVal e As EventArgs) Handles nOptionButton2.ArrowClick, nOptionButton4.ArrowClick, nOptionButton5.ArrowClick, nOptionButton6.ArrowClick, nOptionButton7.ArrowClick, nOptionButton8.ArrowClick, nOptionButton9.ArrowClick, nOptionButton10.ArrowClick, nOptionButton11.ArrowClick
			Dim f As Form = New Form()
			f.Text = "Modal NOptionButton Dialog"
			f.ShowDialog()
		End Sub

		Private Sub nCheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox1.CheckedChanged
			For Each c As Control In Controls
				If Not(TypeOf c Is NButton) Then
					Continue For
				End If
				c.Enabled = nCheckBox1.Checked
			Next c
		End Sub
		Private Sub nCheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox2.CheckedChanged
			For Each c As Control In Controls
				If Not(TypeOf c Is NButton) Then
					Continue For
				End If
				CType(c, NButton).ButtonProperties.ShowFocusRect = nCheckBox2.Checked
			Next c
		End Sub
		Private Sub nCheckBox3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox3.CheckedChanged
			For Each c As Control In Controls
				If Not(TypeOf c Is NOptionButton) Then
					Continue For
				End If
				CType(c, NOptionButton).ShowArrow = nCheckBox3.Checked
			Next c
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nOptionButton2 = New Nevron.UI.WinForm.Controls.NOptionButton()
			Me.nOptionButton4 = New Nevron.UI.WinForm.Controls.NOptionButton()
			Me.nOptionButton5 = New Nevron.UI.WinForm.Controls.NOptionButton()
			Me.nOptionButton6 = New Nevron.UI.WinForm.Controls.NOptionButton()
			Me.nOptionButton7 = New Nevron.UI.WinForm.Controls.NOptionButton()
			Me.nOptionButton8 = New Nevron.UI.WinForm.Controls.NOptionButton()
			Me.nOptionButton9 = New Nevron.UI.WinForm.Controls.NOptionButton()
			Me.nOptionButton10 = New Nevron.UI.WinForm.Controls.NOptionButton()
			Me.nOptionButton11 = New Nevron.UI.WinForm.Controls.NOptionButton()
			Me.nOptionButton1 = New Nevron.UI.WinForm.Controls.NOptionButton()
			Me.nCommand1 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand2 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nOptionButton3 = New Nevron.UI.WinForm.Controls.NOptionButton()
			Me.nCommand3 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand4 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nOptionButton12 = New Nevron.UI.WinForm.Controls.NOptionButton()
			Me.nCommand5 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand6 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nOptionButton13 = New Nevron.UI.WinForm.Controls.NOptionButton()
			Me.nCommand7 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand8 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand9 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand10 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nOptionButton14 = New Nevron.UI.WinForm.Controls.NOptionButton()
			Me.nCommand11 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand12 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand13 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand14 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand15 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand16 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nOptionButton15 = New Nevron.UI.WinForm.Controls.NOptionButton()
			Me.nCommand17 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand18 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand19 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand20 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand21 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand22 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand23 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nOptionButton16 = New Nevron.UI.WinForm.Controls.NOptionButton()
			Me.nCommand24 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand25 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand26 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand27 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nOptionButton17 = New Nevron.UI.WinForm.Controls.NOptionButton()
			Me.nCommand28 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand29 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand30 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand31 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand32 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nOptionButton18 = New Nevron.UI.WinForm.Controls.NOptionButton()
			Me.nCommand33 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand34 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand35 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand36 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand37 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand38 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCheckBox2 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox3 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' nOptionButton2
			' 
			Me.nOptionButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nOptionButton2.Location = New System.Drawing.Point(192, 8)
			Me.nOptionButton2.Mode = Nevron.UI.WinForm.Controls.OptionButtonMode.Modal
			Me.nOptionButton2.Name = "nOptionButton2"
			Me.nOptionButton2.Size = New System.Drawing.Size(136, 24)
			Me.nOptionButton2.TabIndex = 1
			Me.nOptionButton2.Text = "Modal option button"
'			Me.nOptionButton2.ArrowClick += New System.EventHandler(Me.OnOptionButton2ShowDialog);
			' 
			' nOptionButton4
			' 
			Me.nOptionButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nOptionButton4.Location = New System.Drawing.Point(192, 40)
			Me.nOptionButton4.Mode = Nevron.UI.WinForm.Controls.OptionButtonMode.Modal
			Me.nOptionButton4.Name = "nOptionButton4"
			Me.nOptionButton4.Size = New System.Drawing.Size(136, 24)
			Me.nOptionButton4.TabIndex = 3
			Me.nOptionButton4.Text = "Modal option button"
'			Me.nOptionButton4.ArrowClick += New System.EventHandler(Me.OnOptionButton2ShowDialog);
			' 
			' nOptionButton5
			' 
			Me.nOptionButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nOptionButton5.Location = New System.Drawing.Point(192, 72)
			Me.nOptionButton5.Mode = Nevron.UI.WinForm.Controls.OptionButtonMode.Modal
			Me.nOptionButton5.Name = "nOptionButton5"
			Me.nOptionButton5.Size = New System.Drawing.Size(136, 24)
			Me.nOptionButton5.TabIndex = 4
			Me.nOptionButton5.Text = "Modal option button"
'			Me.nOptionButton5.ArrowClick += New System.EventHandler(Me.OnOptionButton2ShowDialog);
			' 
			' nOptionButton6
			' 
			Me.nOptionButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nOptionButton6.Location = New System.Drawing.Point(192, 104)
			Me.nOptionButton6.Mode = Nevron.UI.WinForm.Controls.OptionButtonMode.Modal
			Me.nOptionButton6.Name = "nOptionButton6"
			Me.nOptionButton6.Size = New System.Drawing.Size(136, 24)
			Me.nOptionButton6.TabIndex = 5
			Me.nOptionButton6.Text = "Modal option button"
'			Me.nOptionButton6.ArrowClick += New System.EventHandler(Me.OnOptionButton2ShowDialog);
			' 
			' nOptionButton7
			' 
			Me.nOptionButton7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nOptionButton7.Location = New System.Drawing.Point(192, 136)
			Me.nOptionButton7.Mode = Nevron.UI.WinForm.Controls.OptionButtonMode.Modal
			Me.nOptionButton7.Name = "nOptionButton7"
			Me.nOptionButton7.Size = New System.Drawing.Size(136, 24)
			Me.nOptionButton7.TabIndex = 6
			Me.nOptionButton7.Text = "Modal option button"
'			Me.nOptionButton7.ArrowClick += New System.EventHandler(Me.OnOptionButton2ShowDialog);
			' 
			' nOptionButton8
			' 
			Me.nOptionButton8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nOptionButton8.Location = New System.Drawing.Point(192, 168)
			Me.nOptionButton8.Mode = Nevron.UI.WinForm.Controls.OptionButtonMode.Modal
			Me.nOptionButton8.Name = "nOptionButton8"
			Me.nOptionButton8.Size = New System.Drawing.Size(136, 24)
			Me.nOptionButton8.TabIndex = 7
			Me.nOptionButton8.Text = "Modal option button"
'			Me.nOptionButton8.ArrowClick += New System.EventHandler(Me.OnOptionButton2ShowDialog);
			' 
			' nOptionButton9
			' 
			Me.nOptionButton9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nOptionButton9.Location = New System.Drawing.Point(192, 200)
			Me.nOptionButton9.Mode = Nevron.UI.WinForm.Controls.OptionButtonMode.Modal
			Me.nOptionButton9.Name = "nOptionButton9"
			Me.nOptionButton9.Size = New System.Drawing.Size(136, 24)
			Me.nOptionButton9.TabIndex = 8
			Me.nOptionButton9.Text = "Modal option button"
'			Me.nOptionButton9.ArrowClick += New System.EventHandler(Me.OnOptionButton2ShowDialog);
			' 
			' nOptionButton10
			' 
			Me.nOptionButton10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nOptionButton10.Location = New System.Drawing.Point(192, 232)
			Me.nOptionButton10.Mode = Nevron.UI.WinForm.Controls.OptionButtonMode.Modal
			Me.nOptionButton10.Name = "nOptionButton10"
			Me.nOptionButton10.Size = New System.Drawing.Size(136, 24)
			Me.nOptionButton10.TabIndex = 9
			Me.nOptionButton10.Text = "Modal option button"
'			Me.nOptionButton10.ArrowClick += New System.EventHandler(Me.OnOptionButton2ShowDialog);
			' 
			' nOptionButton11
			' 
			Me.nOptionButton11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nOptionButton11.Location = New System.Drawing.Point(192, 264)
			Me.nOptionButton11.Mode = Nevron.UI.WinForm.Controls.OptionButtonMode.Modal
			Me.nOptionButton11.Name = "nOptionButton11"
			Me.nOptionButton11.Size = New System.Drawing.Size(136, 24)
			Me.nOptionButton11.TabIndex = 10
			Me.nOptionButton11.Text = "Modal option button"
'			Me.nOptionButton11.ArrowClick += New System.EventHandler(Me.OnOptionButton2ShowDialog);
			' 
			' nOptionButton1
			' 
			Me.nOptionButton1.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand1, Me.nCommand2})
			Me.nOptionButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nOptionButton1.Location = New System.Drawing.Point(8, 8)
			Me.nOptionButton1.Name = "nOptionButton1"
			Me.nOptionButton1.Size = New System.Drawing.Size(176, 23)
			Me.nOptionButton1.TabIndex = 11
			Me.nOptionButton1.Text = "Drop-Down Option Button"
			' 
			' nCommand1
			' 
			Me.nCommand1.Properties.Text = "nCommand1"
			' 
			' nCommand2
			' 
			Me.nCommand2.Properties.Text = "nCommand2"
			' 
			' nOptionButton3
			' 
			Me.nOptionButton3.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand3, Me.nCommand4})
			Me.nOptionButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nOptionButton3.Location = New System.Drawing.Point(8, 40)
			Me.nOptionButton3.Name = "nOptionButton3"
			Me.nOptionButton3.Size = New System.Drawing.Size(176, 23)
			Me.nOptionButton3.TabIndex = 12
			Me.nOptionButton3.Text = "Drop-Down Option Button"
			' 
			' nCommand3
			' 
			Me.nCommand3.Properties.Text = "nCommand3"
			' 
			' nCommand4
			' 
			Me.nCommand4.Properties.Text = "nCommand4"
			' 
			' nOptionButton12
			' 
			Me.nOptionButton12.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand5, Me.nCommand6})
			Me.nOptionButton12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nOptionButton12.Location = New System.Drawing.Point(8, 72)
			Me.nOptionButton12.Name = "nOptionButton12"
			Me.nOptionButton12.Size = New System.Drawing.Size(176, 23)
			Me.nOptionButton12.TabIndex = 13
			Me.nOptionButton12.Text = "Drop-Down Option Button"
			' 
			' nCommand5
			' 
			Me.nCommand5.Properties.Text = "nCommand5"
			' 
			' nCommand6
			' 
			Me.nCommand6.Properties.Text = "nCommand6"
			' 
			' nOptionButton13
			' 
			Me.nOptionButton13.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand7, Me.nCommand8, Me.nCommand9, Me.nCommand10})
			Me.nOptionButton13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nOptionButton13.Location = New System.Drawing.Point(8, 104)
			Me.nOptionButton13.Name = "nOptionButton13"
			Me.nOptionButton13.Size = New System.Drawing.Size(176, 23)
			Me.nOptionButton13.TabIndex = 14
			Me.nOptionButton13.Text = "Drop-Down Option Button"
			' 
			' nCommand7
			' 
			Me.nCommand7.Properties.Text = "nCommand7"
			' 
			' nCommand8
			' 
			Me.nCommand8.Properties.Text = "nCommand8"
			' 
			' nCommand9
			' 
			Me.nCommand9.Properties.Text = "nCommand9"
			' 
			' nCommand10
			' 
			Me.nCommand10.Properties.Text = "nCommand10"
			' 
			' nOptionButton14
			' 
			Me.nOptionButton14.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand11, Me.nCommand12, Me.nCommand13, Me.nCommand14, Me.nCommand15, Me.nCommand16})
			Me.nOptionButton14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nOptionButton14.Location = New System.Drawing.Point(8, 136)
			Me.nOptionButton14.Name = "nOptionButton14"
			Me.nOptionButton14.Size = New System.Drawing.Size(176, 23)
			Me.nOptionButton14.TabIndex = 15
			Me.nOptionButton14.Text = "Drop-Down Option Button"
			' 
			' nCommand11
			' 
			Me.nCommand11.Properties.Text = "nCommand11"
			' 
			' nCommand12
			' 
			Me.nCommand12.Properties.Text = "nCommand12"
			' 
			' nCommand13
			' 
			Me.nCommand13.Properties.Text = "nCommand13"
			' 
			' nCommand14
			' 
			Me.nCommand14.Properties.Text = "nCommand14"
			' 
			' nCommand15
			' 
			Me.nCommand15.Properties.Text = "nCommand15"
			' 
			' nCommand16
			' 
			Me.nCommand16.Properties.Text = "nCommand16"
			' 
			' nOptionButton15
			' 
			Me.nOptionButton15.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand17, Me.nCommand18, Me.nCommand19, Me.nCommand20, Me.nCommand21, Me.nCommand22, Me.nCommand23})
			Me.nOptionButton15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nOptionButton15.Location = New System.Drawing.Point(8, 168)
			Me.nOptionButton15.Name = "nOptionButton15"
			Me.nOptionButton15.Size = New System.Drawing.Size(176, 23)
			Me.nOptionButton15.TabIndex = 16
			Me.nOptionButton15.Text = "Drop-Down Option Button"
			' 
			' nCommand17
			' 
			Me.nCommand17.Properties.Text = "nCommand17"
			' 
			' nCommand18
			' 
			Me.nCommand18.Properties.Text = "nCommand18"
			' 
			' nCommand19
			' 
			Me.nCommand19.Properties.Text = "nCommand19"
			' 
			' nCommand20
			' 
			Me.nCommand20.Properties.Text = "nCommand20"
			' 
			' nCommand21
			' 
			Me.nCommand21.Properties.Text = "nCommand21"
			' 
			' nCommand22
			' 
			Me.nCommand22.Properties.Text = "nCommand22"
			' 
			' nCommand23
			' 
			Me.nCommand23.Properties.Text = "nCommand23"
			' 
			' nOptionButton16
			' 
			Me.nOptionButton16.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand24, Me.nCommand25, Me.nCommand26, Me.nCommand27})
			Me.nOptionButton16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nOptionButton16.Location = New System.Drawing.Point(8, 200)
			Me.nOptionButton16.Name = "nOptionButton16"
			Me.nOptionButton16.Size = New System.Drawing.Size(176, 23)
			Me.nOptionButton16.TabIndex = 17
			Me.nOptionButton16.Text = "Drop-Down Option Button"
			' 
			' nCommand24
			' 
			Me.nCommand24.Properties.Text = "nCommand24"
			' 
			' nCommand25
			' 
			Me.nCommand25.Properties.Text = "nCommand25"
			' 
			' nCommand26
			' 
			Me.nCommand26.Properties.Text = "nCommand26"
			' 
			' nCommand27
			' 
			Me.nCommand27.Properties.Text = "nCommand27"
			' 
			' nOptionButton17
			' 
			Me.nOptionButton17.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand28, Me.nCommand29, Me.nCommand30, Me.nCommand31, Me.nCommand32})
			Me.nOptionButton17.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nOptionButton17.Location = New System.Drawing.Point(8, 232)
			Me.nOptionButton17.Name = "nOptionButton17"
			Me.nOptionButton17.Size = New System.Drawing.Size(176, 23)
			Me.nOptionButton17.TabIndex = 18
			Me.nOptionButton17.Text = "Drop-Down Option Button"
			' 
			' nCommand28
			' 
			Me.nCommand28.Properties.Text = "nCommand28"
			' 
			' nCommand29
			' 
			Me.nCommand29.Properties.Text = "nCommand29"
			' 
			' nCommand30
			' 
			Me.nCommand30.Properties.Text = "nCommand30"
			' 
			' nCommand31
			' 
			Me.nCommand31.Properties.Text = "nCommand31"
			' 
			' nCommand32
			' 
			Me.nCommand32.Properties.Text = "nCommand32"
			' 
			' nOptionButton18
			' 
			Me.nOptionButton18.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand33, Me.nCommand34, Me.nCommand35, Me.nCommand36, Me.nCommand37, Me.nCommand38})
			Me.nOptionButton18.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nOptionButton18.Location = New System.Drawing.Point(8, 264)
			Me.nOptionButton18.Name = "nOptionButton18"
			Me.nOptionButton18.Size = New System.Drawing.Size(176, 23)
			Me.nOptionButton18.TabIndex = 19
			Me.nOptionButton18.Text = "Drop-Down Option Button"
			' 
			' nCommand33
			' 
			Me.nCommand33.Properties.Text = "nCommand33"
			' 
			' nCommand34
			' 
			Me.nCommand34.Properties.Text = "nCommand34"
			' 
			' nCommand35
			' 
			Me.nCommand35.Properties.Text = "nCommand35"
			' 
			' nCommand36
			' 
			Me.nCommand36.Properties.Text = "nCommand36"
			' 
			' nCommand37
			' 
			Me.nCommand37.Properties.Text = "nCommand37"
			' 
			' nCommand38
			' 
			Me.nCommand38.Properties.Text = "nCommand38"
			' 
			' nCheckBox2
			' 
			Me.nCheckBox2.Checked = True
			Me.nCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
			Me.nCheckBox2.Location = New System.Drawing.Point(112, 296)
			Me.nCheckBox2.Name = "nCheckBox2"
			Me.nCheckBox2.Size = New System.Drawing.Size(128, 24)
			Me.nCheckBox2.TabIndex = 21
			Me.nCheckBox2.Text = "Show &Focus Rect"
'			Me.nCheckBox2.CheckedChanged += New System.EventHandler(Me.nCheckBox2_CheckedChanged);
			' 
			' nCheckBox1
			' 
			Me.nCheckBox1.Checked = True
			Me.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
			Me.nCheckBox1.Location = New System.Drawing.Point(8, 296)
			Me.nCheckBox1.Name = "nCheckBox1"
			Me.nCheckBox1.TabIndex = 20
			Me.nCheckBox1.Text = "&Enable"
'			Me.nCheckBox1.CheckedChanged += New System.EventHandler(Me.nCheckBox1_CheckedChanged);
			' 
			' nCheckBox3
			' 
			Me.nCheckBox3.Checked = True
			Me.nCheckBox3.CheckState = System.Windows.Forms.CheckState.Checked
			Me.nCheckBox3.Location = New System.Drawing.Point(240, 296)
			Me.nCheckBox3.Name = "nCheckBox3"
			Me.nCheckBox3.TabIndex = 22
			Me.nCheckBox3.Text = "Show &Arrow"
'			Me.nCheckBox3.CheckedChanged += New System.EventHandler(Me.nCheckBox3_CheckedChanged);
			' 
			' NOptionButtonUC
			' 
			Me.Controls.Add(Me.nCheckBox3)
			Me.Controls.Add(Me.nCheckBox2)
			Me.Controls.Add(Me.nCheckBox1)
			Me.Controls.Add(Me.nOptionButton18)
			Me.Controls.Add(Me.nOptionButton17)
			Me.Controls.Add(Me.nOptionButton16)
			Me.Controls.Add(Me.nOptionButton15)
			Me.Controls.Add(Me.nOptionButton14)
			Me.Controls.Add(Me.nOptionButton13)
			Me.Controls.Add(Me.nOptionButton12)
			Me.Controls.Add(Me.nOptionButton3)
			Me.Controls.Add(Me.nOptionButton1)
			Me.Controls.Add(Me.nOptionButton11)
			Me.Controls.Add(Me.nOptionButton10)
			Me.Controls.Add(Me.nOptionButton9)
			Me.Controls.Add(Me.nOptionButton8)
			Me.Controls.Add(Me.nOptionButton7)
			Me.Controls.Add(Me.nOptionButton6)
			Me.Controls.Add(Me.nOptionButton5)
			Me.Controls.Add(Me.nOptionButton4)
			Me.Controls.Add(Me.nOptionButton2)
			Me.Name = "NOptionButtonUC"
			Me.Size = New System.Drawing.Size(504, 328)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents nOptionButton4 As Nevron.UI.WinForm.Controls.NOptionButton
		Private WithEvents nOptionButton5 As Nevron.UI.WinForm.Controls.NOptionButton
		Private WithEvents nOptionButton6 As Nevron.UI.WinForm.Controls.NOptionButton
		Private WithEvents nOptionButton7 As Nevron.UI.WinForm.Controls.NOptionButton
		Private WithEvents nOptionButton8 As Nevron.UI.WinForm.Controls.NOptionButton
		Private WithEvents nOptionButton9 As Nevron.UI.WinForm.Controls.NOptionButton
		Private WithEvents nOptionButton10 As Nevron.UI.WinForm.Controls.NOptionButton
		Private WithEvents nOptionButton11 As Nevron.UI.WinForm.Controls.NOptionButton
		Private nOptionButton1 As Nevron.UI.WinForm.Controls.NOptionButton
		Private nOptionButton3 As Nevron.UI.WinForm.Controls.NOptionButton
		Private nOptionButton12 As Nevron.UI.WinForm.Controls.NOptionButton
		Private nOptionButton13 As Nevron.UI.WinForm.Controls.NOptionButton
		Private nOptionButton14 As Nevron.UI.WinForm.Controls.NOptionButton
		Private nOptionButton15 As Nevron.UI.WinForm.Controls.NOptionButton
		Private nOptionButton16 As Nevron.UI.WinForm.Controls.NOptionButton
		Private nOptionButton17 As Nevron.UI.WinForm.Controls.NOptionButton
		Private nOptionButton18 As Nevron.UI.WinForm.Controls.NOptionButton
		Private nCommand1 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand2 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand3 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand4 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand5 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand6 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand7 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand8 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand9 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand10 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand11 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand12 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand13 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand14 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand15 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand16 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand17 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand18 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand19 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand20 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand21 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand22 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand23 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand24 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand25 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand26 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand27 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand28 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand29 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand30 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand31 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand32 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand33 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand34 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand35 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand36 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand37 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand38 As Nevron.UI.WinForm.Controls.NCommand
		Private WithEvents nCheckBox2 As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents nCheckBox1 As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents nCheckBox3 As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents nOptionButton2 As Nevron.UI.WinForm.Controls.NOptionButton

		#End Region
	End Class
End Namespace
