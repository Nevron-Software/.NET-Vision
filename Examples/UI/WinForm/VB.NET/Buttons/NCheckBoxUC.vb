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
	Public Class NCheckBoxUC
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
			End If
			MyBase.Dispose(disposing)
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub nCheckBox27_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox27.CheckedChanged
			For Each c As Control In Controls
				For Each c1 As Control In c.Controls
					If Not(TypeOf c1 Is NCheckBox) Then
						Continue For
					End If
					c1.Enabled = nCheckBox27.Checked
				Next c1
			Next c
		End Sub
		Private Sub nCheckBox26_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox26.CheckedChanged
			For Each c As Control In Controls
				For Each c1 As Control In c.Controls
					If Not(TypeOf c1 Is NCheckBox) Then
						Continue For
					End If
					CType(c1, NCheckBox).ButtonProperties.ShowFocusRect = nCheckBox26.Checked
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
			Me.nCheckBox1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nCheckBox13 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox12 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox11 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox10 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox9 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox8 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox7 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox6 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox5 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox2 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox4 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox3 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox23 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nCheckBox14 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox15 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox16 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox17 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox18 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox19 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox20 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox21 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox22 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox24 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox25 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox26 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox27 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nGroupBox1.SuspendLayout()
			Me.nGroupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nCheckBox1
			' 
			Me.nCheckBox1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nCheckBox1.Location = New System.Drawing.Point(16, 24)
			Me.nCheckBox1.Name = "nCheckBox1"
			Me.nCheckBox1.Size = New System.Drawing.Size(103, 24)
			Me.nCheckBox1.TabIndex = 0
			Me.nCheckBox1.Text = "nCheckBox"
			Me.nCheckBox1.ThreeState = True
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.nCheckBox13)
			Me.nGroupBox1.Controls.Add(Me.nCheckBox12)
			Me.nGroupBox1.Controls.Add(Me.nCheckBox11)
			Me.nGroupBox1.Controls.Add(Me.nCheckBox10)
			Me.nGroupBox1.Controls.Add(Me.nCheckBox9)
			Me.nGroupBox1.Controls.Add(Me.nCheckBox8)
			Me.nGroupBox1.Controls.Add(Me.nCheckBox7)
			Me.nGroupBox1.Controls.Add(Me.nCheckBox6)
			Me.nGroupBox1.Controls.Add(Me.nCheckBox5)
			Me.nGroupBox1.Controls.Add(Me.nCheckBox2)
			Me.nGroupBox1.Controls.Add(Me.nCheckBox1)
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(8, 8)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(136, 376)
			Me.nGroupBox1.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default
			Me.nGroupBox1.TabIndex = 6
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Standard CheckBoxes"
			' 
			' nCheckBox13
			' 
			Me.nCheckBox13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nCheckBox13.Location = New System.Drawing.Point(16, 344)
			Me.nCheckBox13.Name = "nCheckBox13"
			Me.nCheckBox13.Size = New System.Drawing.Size(103, 24)
			Me.nCheckBox13.TabIndex = 10
			Me.nCheckBox13.Text = "nCheckBox"
			Me.nCheckBox13.ThreeState = True
			' 
			' nCheckBox12
			' 
			Me.nCheckBox12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nCheckBox12.Location = New System.Drawing.Point(16, 312)
			Me.nCheckBox12.Name = "nCheckBox12"
			Me.nCheckBox12.Size = New System.Drawing.Size(103, 24)
			Me.nCheckBox12.TabIndex = 9
			Me.nCheckBox12.Text = "nCheckBox"
			Me.nCheckBox12.ThreeState = True
			' 
			' nCheckBox11
			' 
			Me.nCheckBox11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nCheckBox11.Location = New System.Drawing.Point(16, 280)
			Me.nCheckBox11.Name = "nCheckBox11"
			Me.nCheckBox11.Size = New System.Drawing.Size(103, 24)
			Me.nCheckBox11.TabIndex = 8
			Me.nCheckBox11.Text = "nCheckBox"
			Me.nCheckBox11.ThreeState = True
			' 
			' nCheckBox10
			' 
			Me.nCheckBox10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nCheckBox10.Location = New System.Drawing.Point(16, 248)
			Me.nCheckBox10.Name = "nCheckBox10"
			Me.nCheckBox10.Size = New System.Drawing.Size(103, 24)
			Me.nCheckBox10.TabIndex = 7
			Me.nCheckBox10.Text = "nCheckBox"
			Me.nCheckBox10.ThreeState = True
			' 
			' nCheckBox9
			' 
			Me.nCheckBox9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nCheckBox9.Location = New System.Drawing.Point(16, 216)
			Me.nCheckBox9.Name = "nCheckBox9"
			Me.nCheckBox9.Size = New System.Drawing.Size(103, 24)
			Me.nCheckBox9.TabIndex = 6
			Me.nCheckBox9.Text = "nCheckBox"
			Me.nCheckBox9.ThreeState = True
			' 
			' nCheckBox8
			' 
			Me.nCheckBox8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nCheckBox8.Location = New System.Drawing.Point(16, 184)
			Me.nCheckBox8.Name = "nCheckBox8"
			Me.nCheckBox8.Size = New System.Drawing.Size(103, 24)
			Me.nCheckBox8.TabIndex = 5
			Me.nCheckBox8.Text = "nCheckBox"
			Me.nCheckBox8.ThreeState = True
			' 
			' nCheckBox7
			' 
			Me.nCheckBox7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nCheckBox7.Location = New System.Drawing.Point(16, 152)
			Me.nCheckBox7.Name = "nCheckBox7"
			Me.nCheckBox7.Size = New System.Drawing.Size(103, 24)
			Me.nCheckBox7.TabIndex = 4
			Me.nCheckBox7.Text = "nCheckBox"
			Me.nCheckBox7.ThreeState = True
			' 
			' nCheckBox6
			' 
			Me.nCheckBox6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nCheckBox6.Location = New System.Drawing.Point(16, 120)
			Me.nCheckBox6.Name = "nCheckBox6"
			Me.nCheckBox6.Size = New System.Drawing.Size(103, 24)
			Me.nCheckBox6.TabIndex = 3
			Me.nCheckBox6.Text = "nCheckBox"
			Me.nCheckBox6.ThreeState = True
			' 
			' nCheckBox5
			' 
			Me.nCheckBox5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nCheckBox5.Location = New System.Drawing.Point(16, 88)
			Me.nCheckBox5.Name = "nCheckBox5"
			Me.nCheckBox5.Size = New System.Drawing.Size(103, 24)
			Me.nCheckBox5.TabIndex = 2
			Me.nCheckBox5.Text = "nCheckBox"
			Me.nCheckBox5.ThreeState = True
			' 
			' nCheckBox2
			' 
			Me.nCheckBox2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nCheckBox2.Location = New System.Drawing.Point(16, 56)
			Me.nCheckBox2.Name = "nCheckBox2"
			Me.nCheckBox2.Size = New System.Drawing.Size(103, 24)
			Me.nCheckBox2.TabIndex = 1
			Me.nCheckBox2.Text = "nCheckBox"
			Me.nCheckBox2.ThreeState = True
			' 
			' nCheckBox4
			' 
			Me.nCheckBox4.Location = New System.Drawing.Point(0, 0)
			Me.nCheckBox4.Name = "nCheckBox4"
			Me.nCheckBox4.TabIndex = 0
			' 
			' nCheckBox3
			' 
			Me.nCheckBox3.Location = New System.Drawing.Point(0, 0)
			Me.nCheckBox3.Name = "nCheckBox3"
			Me.nCheckBox3.TabIndex = 0
			' 
			' nCheckBox23
			' 
			Me.nCheckBox23.Location = New System.Drawing.Point(0, 0)
			Me.nCheckBox23.Name = "nCheckBox23"
			Me.nCheckBox23.TabIndex = 0
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Controls.Add(Me.nCheckBox14)
			Me.nGroupBox2.Controls.Add(Me.nCheckBox15)
			Me.nGroupBox2.Controls.Add(Me.nCheckBox16)
			Me.nGroupBox2.Controls.Add(Me.nCheckBox17)
			Me.nGroupBox2.Controls.Add(Me.nCheckBox18)
			Me.nGroupBox2.Controls.Add(Me.nCheckBox19)
			Me.nGroupBox2.Controls.Add(Me.nCheckBox20)
			Me.nGroupBox2.Controls.Add(Me.nCheckBox21)
			Me.nGroupBox2.Controls.Add(Me.nCheckBox22)
			Me.nGroupBox2.Controls.Add(Me.nCheckBox24)
			Me.nGroupBox2.Controls.Add(Me.nCheckBox25)
			Me.nGroupBox2.ImageIndex = 0
			Me.nGroupBox2.Location = New System.Drawing.Point(160, 8)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(184, 376)
			Me.nGroupBox2.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default
			Me.nGroupBox2.TabIndex = 11
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "Button CheckBoxes"
			' 
			' nCheckBox14
			' 
			Me.nCheckBox14.Appearance = System.Windows.Forms.Appearance.Button
			Me.nCheckBox14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nCheckBox14.Location = New System.Drawing.Point(16, 344)
			Me.nCheckBox14.Name = "nCheckBox14"
			Me.nCheckBox14.Size = New System.Drawing.Size(144, 24)
			Me.nCheckBox14.TabIndex = 10
			Me.nCheckBox14.Text = "nCheckBox"
			Me.nCheckBox14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			Me.nCheckBox14.ThreeState = True
			' 
			' nCheckBox15
			' 
			Me.nCheckBox15.Appearance = System.Windows.Forms.Appearance.Button
			Me.nCheckBox15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nCheckBox15.Location = New System.Drawing.Point(16, 312)
			Me.nCheckBox15.Name = "nCheckBox15"
			Me.nCheckBox15.Size = New System.Drawing.Size(144, 24)
			Me.nCheckBox15.TabIndex = 9
			Me.nCheckBox15.Text = "nCheckBox"
			Me.nCheckBox15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			Me.nCheckBox15.ThreeState = True
			' 
			' nCheckBox16
			' 
			Me.nCheckBox16.Appearance = System.Windows.Forms.Appearance.Button
			Me.nCheckBox16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nCheckBox16.Location = New System.Drawing.Point(16, 280)
			Me.nCheckBox16.Name = "nCheckBox16"
			Me.nCheckBox16.Size = New System.Drawing.Size(144, 24)
			Me.nCheckBox16.TabIndex = 8
			Me.nCheckBox16.Text = "nCheckBox"
			Me.nCheckBox16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			Me.nCheckBox16.ThreeState = True
			' 
			' nCheckBox17
			' 
			Me.nCheckBox17.Appearance = System.Windows.Forms.Appearance.Button
			Me.nCheckBox17.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nCheckBox17.Location = New System.Drawing.Point(16, 248)
			Me.nCheckBox17.Name = "nCheckBox17"
			Me.nCheckBox17.Size = New System.Drawing.Size(144, 24)
			Me.nCheckBox17.TabIndex = 7
			Me.nCheckBox17.Text = "nCheckBox"
			Me.nCheckBox17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			Me.nCheckBox17.ThreeState = True
			' 
			' nCheckBox18
			' 
			Me.nCheckBox18.Appearance = System.Windows.Forms.Appearance.Button
			Me.nCheckBox18.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nCheckBox18.Location = New System.Drawing.Point(16, 216)
			Me.nCheckBox18.Name = "nCheckBox18"
			Me.nCheckBox18.Size = New System.Drawing.Size(144, 24)
			Me.nCheckBox18.TabIndex = 6
			Me.nCheckBox18.Text = "nCheckBox"
			Me.nCheckBox18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			Me.nCheckBox18.ThreeState = True
			' 
			' nCheckBox19
			' 
			Me.nCheckBox19.Appearance = System.Windows.Forms.Appearance.Button
			Me.nCheckBox19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nCheckBox19.Location = New System.Drawing.Point(16, 184)
			Me.nCheckBox19.Name = "nCheckBox19"
			Me.nCheckBox19.Size = New System.Drawing.Size(144, 24)
			Me.nCheckBox19.TabIndex = 5
			Me.nCheckBox19.Text = "nCheckBox"
			Me.nCheckBox19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			Me.nCheckBox19.ThreeState = True
			' 
			' nCheckBox20
			' 
			Me.nCheckBox20.Appearance = System.Windows.Forms.Appearance.Button
			Me.nCheckBox20.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nCheckBox20.Location = New System.Drawing.Point(16, 152)
			Me.nCheckBox20.Name = "nCheckBox20"
			Me.nCheckBox20.Size = New System.Drawing.Size(144, 24)
			Me.nCheckBox20.TabIndex = 4
			Me.nCheckBox20.Text = "nCheckBox"
			Me.nCheckBox20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			Me.nCheckBox20.ThreeState = True
			' 
			' nCheckBox21
			' 
			Me.nCheckBox21.Appearance = System.Windows.Forms.Appearance.Button
			Me.nCheckBox21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nCheckBox21.Location = New System.Drawing.Point(16, 120)
			Me.nCheckBox21.Name = "nCheckBox21"
			Me.nCheckBox21.Size = New System.Drawing.Size(144, 24)
			Me.nCheckBox21.TabIndex = 3
			Me.nCheckBox21.Text = "nCheckBox"
			Me.nCheckBox21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			Me.nCheckBox21.ThreeState = True
			' 
			' nCheckBox22
			' 
			Me.nCheckBox22.Appearance = System.Windows.Forms.Appearance.Button
			Me.nCheckBox22.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nCheckBox22.Location = New System.Drawing.Point(16, 88)
			Me.nCheckBox22.Name = "nCheckBox22"
			Me.nCheckBox22.Size = New System.Drawing.Size(144, 24)
			Me.nCheckBox22.TabIndex = 2
			Me.nCheckBox22.Text = "nCheckBox"
			Me.nCheckBox22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			Me.nCheckBox22.ThreeState = True
			' 
			' nCheckBox24
			' 
			Me.nCheckBox24.Appearance = System.Windows.Forms.Appearance.Button
			Me.nCheckBox24.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nCheckBox24.Location = New System.Drawing.Point(16, 56)
			Me.nCheckBox24.Name = "nCheckBox24"
			Me.nCheckBox24.Size = New System.Drawing.Size(144, 24)
			Me.nCheckBox24.TabIndex = 1
			Me.nCheckBox24.Text = "nCheckBox"
			Me.nCheckBox24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			Me.nCheckBox24.ThreeState = True
			' 
			' nCheckBox25
			' 
			Me.nCheckBox25.Appearance = System.Windows.Forms.Appearance.Button
			Me.nCheckBox25.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nCheckBox25.Location = New System.Drawing.Point(16, 24)
			Me.nCheckBox25.Name = "nCheckBox25"
			Me.nCheckBox25.Size = New System.Drawing.Size(144, 24)
			Me.nCheckBox25.TabIndex = 0
			Me.nCheckBox25.Text = "nCheckBox"
			Me.nCheckBox25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			Me.nCheckBox25.ThreeState = True
			' 
			' nCheckBox26
			' 
			Me.nCheckBox26.Location = New System.Drawing.Point(120, 392)
			Me.nCheckBox26.Name = "nCheckBox26"
			Me.nCheckBox26.Size = New System.Drawing.Size(128, 24)
			Me.nCheckBox26.TabIndex = 23
			Me.nCheckBox26.Text = "Show &Focus Rect"
'			Me.nCheckBox26.CheckedChanged += New System.EventHandler(Me.nCheckBox26_CheckedChanged);
			' 
			' nCheckBox27
			' 
			Me.nCheckBox27.Checked = True
			Me.nCheckBox27.CheckState = System.Windows.Forms.CheckState.Checked
			Me.nCheckBox27.Location = New System.Drawing.Point(8, 392)
			Me.nCheckBox27.Name = "nCheckBox27"
			Me.nCheckBox27.TabIndex = 22
			Me.nCheckBox27.Text = "&Enable"
'			Me.nCheckBox27.CheckedChanged += New System.EventHandler(Me.nCheckBox27_CheckedChanged);
			' 
			' NCheckBoxUC
			' 
			Me.Controls.Add(Me.nCheckBox26)
			Me.Controls.Add(Me.nCheckBox27)
			Me.Controls.Add(Me.nGroupBox1)
			Me.Controls.Add(Me.nGroupBox2)
			Me.Name = "NCheckBoxUC"
			Me.Size = New System.Drawing.Size(352, 424)
			Me.nGroupBox1.ResumeLayout(False)
			Me.nGroupBox2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private nCheckBox1 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nCheckBox23 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nCheckBox3 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nCheckBox4 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nCheckBox2 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nCheckBox5 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nCheckBox6 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nCheckBox7 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nCheckBox8 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nCheckBox9 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nCheckBox10 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nCheckBox11 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nCheckBox12 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nCheckBox13 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nCheckBox14 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nCheckBox15 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nCheckBox16 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nCheckBox17 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nCheckBox18 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nCheckBox19 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nCheckBox20 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nCheckBox21 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nCheckBox22 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nCheckBox24 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nCheckBox25 As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents nCheckBox26 As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents nCheckBox27 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox

		#End Region
	End Class
End Namespace
