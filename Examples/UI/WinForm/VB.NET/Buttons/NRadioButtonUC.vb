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
	Public Class NRadioButtonUC
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
		Public Overrides Sub Initialize()
			MyBase.Initialize()
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub nCheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox1.CheckedChanged
			For Each b As NRadioButton In Me.nGroupBox1.Controls
				b.Enabled = Me.nCheckBox1.Checked
			Next b
			For Each b As NRadioButton In Me.nGroupBox2.Controls
				b.Enabled = Me.nCheckBox1.Checked
			Next b
		End Sub

		Private Sub nCheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox2.CheckedChanged
			For Each b As NRadioButton In Me.nGroupBox1.Controls
				b.ButtonProperties.ShowFocusRect = Me.nCheckBox2.Checked
			Next b
			For Each b As NRadioButton In Me.nGroupBox2.Controls
				b.ButtonProperties.ShowFocusRect = Me.nCheckBox2.Checked
			Next b
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nRadioButton1 = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nRadioButton2 = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nRadioButton3 = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nRadioButton4 = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nRadioButton5 = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nRadioButton6 = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nRadioButton7 = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nRadioButton8 = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nRadioButton9 = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nRadioButton10 = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nRadioButton11 = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nRadioButton12 = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nRadioButton13 = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nRadioButton15 = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nRadioButton14 = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nCheckBox1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox2 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nGroupBox1.SuspendLayout()
			Me.nGroupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nRadioButton1
			' 
			Me.nRadioButton1.Location = New System.Drawing.Point(16, 24)
			Me.nRadioButton1.Name = "nRadioButton1"
			Me.nRadioButton1.TabIndex = 0
			Me.nRadioButton1.Text = "nRadioButton1"
			' 
			' nRadioButton2
			' 
			Me.nRadioButton2.Location = New System.Drawing.Point(16, 56)
			Me.nRadioButton2.Name = "nRadioButton2"
			Me.nRadioButton2.TabIndex = 1
			Me.nRadioButton2.Text = "nRadioButton2"
			' 
			' nRadioButton3
			' 
			Me.nRadioButton3.Location = New System.Drawing.Point(16, 88)
			Me.nRadioButton3.Name = "nRadioButton3"
			Me.nRadioButton3.TabIndex = 2
			Me.nRadioButton3.Text = "nRadioButton3"
			' 
			' nRadioButton4
			' 
			Me.nRadioButton4.Location = New System.Drawing.Point(16, 120)
			Me.nRadioButton4.Name = "nRadioButton4"
			Me.nRadioButton4.TabIndex = 3
			Me.nRadioButton4.Text = "nRadioButton4"
			' 
			' nRadioButton5
			' 
			Me.nRadioButton5.Location = New System.Drawing.Point(16, 152)
			Me.nRadioButton5.Name = "nRadioButton5"
			Me.nRadioButton5.TabIndex = 7
			Me.nRadioButton5.Text = "nRadioButton5"
			' 
			' nRadioButton6
			' 
			Me.nRadioButton6.Location = New System.Drawing.Point(16, 184)
			Me.nRadioButton6.Name = "nRadioButton6"
			Me.nRadioButton6.TabIndex = 6
			Me.nRadioButton6.Text = "nRadioButton6"
			' 
			' nRadioButton7
			' 
			Me.nRadioButton7.Location = New System.Drawing.Point(16, 216)
			Me.nRadioButton7.Name = "nRadioButton7"
			Me.nRadioButton7.TabIndex = 5
			Me.nRadioButton7.Text = "nRadioButton7"
			' 
			' nRadioButton8
			' 
			Me.nRadioButton8.Location = New System.Drawing.Point(16, 248)
			Me.nRadioButton8.Name = "nRadioButton8"
			Me.nRadioButton8.TabIndex = 4
			Me.nRadioButton8.Text = "nRadioButton8"
			' 
			' nRadioButton9
			' 
			Me.nRadioButton9.Appearance = System.Windows.Forms.Appearance.Button
			Me.nRadioButton9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nRadioButton9.ImageIndex = 0
			Me.nRadioButton9.Location = New System.Drawing.Point(16, 24)
			Me.nRadioButton9.Name = "nRadioButton9"
			Me.nRadioButton9.Size = New System.Drawing.Size(112, 24)
			Me.nRadioButton9.TabIndex = 8
			Me.nRadioButton9.Text = "nRadioButton9"
			Me.nRadioButton9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' nRadioButton10
			' 
			Me.nRadioButton10.Appearance = System.Windows.Forms.Appearance.Button
			Me.nRadioButton10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nRadioButton10.ImageIndex = 1
			Me.nRadioButton10.Location = New System.Drawing.Point(16, 56)
			Me.nRadioButton10.Name = "nRadioButton10"
			Me.nRadioButton10.Size = New System.Drawing.Size(112, 24)
			Me.nRadioButton10.TabIndex = 9
			Me.nRadioButton10.Text = "nRadioButton10"
			Me.nRadioButton10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' nRadioButton11
			' 
			Me.nRadioButton11.Appearance = System.Windows.Forms.Appearance.Button
			Me.nRadioButton11.ImageAlign = System.Drawing.ContentAlignment.TopCenter
			Me.nRadioButton11.ImageIndex = 3
			Me.nRadioButton11.Location = New System.Drawing.Point(16, 88)
			Me.nRadioButton11.Name = "nRadioButton11"
			Me.nRadioButton11.Size = New System.Drawing.Size(112, 48)
			Me.nRadioButton11.TabIndex = 10
			Me.nRadioButton11.Text = "nRadioButton11"
			Me.nRadioButton11.TextAlign = System.Drawing.ContentAlignment.BottomCenter
			' 
			' nRadioButton12
			' 
			Me.nRadioButton12.Appearance = System.Windows.Forms.Appearance.Button
			Me.nRadioButton12.Location = New System.Drawing.Point(16, 144)
			Me.nRadioButton12.Name = "nRadioButton12"
			Me.nRadioButton12.Size = New System.Drawing.Size(112, 24)
			Me.nRadioButton12.TabIndex = 11
			Me.nRadioButton12.Text = "nRadioButton12"
			Me.nRadioButton12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' nRadioButton13
			' 
			Me.nRadioButton13.Appearance = System.Windows.Forms.Appearance.Button
			Me.nRadioButton13.Location = New System.Drawing.Point(16, 176)
			Me.nRadioButton13.Name = "nRadioButton13"
			Me.nRadioButton13.Size = New System.Drawing.Size(112, 24)
			Me.nRadioButton13.TabIndex = 12
			Me.nRadioButton13.Text = "nRadioButton13"
			Me.nRadioButton13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.nRadioButton3)
			Me.nGroupBox1.Controls.Add(Me.nRadioButton4)
			Me.nGroupBox1.Controls.Add(Me.nRadioButton1)
			Me.nGroupBox1.Controls.Add(Me.nRadioButton5)
			Me.nGroupBox1.Controls.Add(Me.nRadioButton6)
			Me.nGroupBox1.Controls.Add(Me.nRadioButton7)
			Me.nGroupBox1.Controls.Add(Me.nRadioButton8)
			Me.nGroupBox1.Controls.Add(Me.nRadioButton2)
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(8, 8)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(144, 280)
			Me.nGroupBox1.TabIndex = 16
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Standard Appearance"
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Controls.Add(Me.nRadioButton15)
			Me.nGroupBox2.Controls.Add(Me.nRadioButton14)
			Me.nGroupBox2.Controls.Add(Me.nRadioButton13)
			Me.nGroupBox2.Controls.Add(Me.nRadioButton9)
			Me.nGroupBox2.Controls.Add(Me.nRadioButton10)
			Me.nGroupBox2.Controls.Add(Me.nRadioButton11)
			Me.nGroupBox2.Controls.Add(Me.nRadioButton12)
			Me.nGroupBox2.ImageIndex = 0
			Me.nGroupBox2.Location = New System.Drawing.Point(160, 8)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(144, 280)
			Me.nGroupBox2.TabIndex = 17
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "Button Appearance"
			' 
			' nRadioButton15
			' 
			Me.nRadioButton15.Appearance = System.Windows.Forms.Appearance.Button
			Me.nRadioButton15.Location = New System.Drawing.Point(16, 240)
			Me.nRadioButton15.Name = "nRadioButton15"
			Me.nRadioButton15.Size = New System.Drawing.Size(112, 24)
			Me.nRadioButton15.TabIndex = 14
			Me.nRadioButton15.Text = "nRadioButton15"
			Me.nRadioButton15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' nRadioButton14
			' 
			Me.nRadioButton14.Appearance = System.Windows.Forms.Appearance.Button
			Me.nRadioButton14.Location = New System.Drawing.Point(16, 208)
			Me.nRadioButton14.Name = "nRadioButton14"
			Me.nRadioButton14.Size = New System.Drawing.Size(112, 24)
			Me.nRadioButton14.TabIndex = 13
			Me.nRadioButton14.Text = "nRadioButton14"
			Me.nRadioButton14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' nCheckBox1
			' 
			Me.nCheckBox1.Checked = True
			Me.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
			Me.nCheckBox1.Location = New System.Drawing.Point(8, 296)
			Me.nCheckBox1.Name = "nCheckBox1"
			Me.nCheckBox1.TabIndex = 18
			Me.nCheckBox1.Text = "&Enable"
'			Me.nCheckBox1.CheckedChanged += New System.EventHandler(Me.nCheckBox1_CheckedChanged);
			' 
			' nCheckBox2
			' 
			Me.nCheckBox2.Location = New System.Drawing.Point(120, 296)
			Me.nCheckBox2.Name = "nCheckBox2"
			Me.nCheckBox2.Size = New System.Drawing.Size(120, 24)
			Me.nCheckBox2.TabIndex = 19
			Me.nCheckBox2.Text = "Show &Focus Rect"
'			Me.nCheckBox2.CheckedChanged += New System.EventHandler(Me.nCheckBox2_CheckedChanged);
			' 
			' NRadioButtonUC
			' 
			Me.Controls.Add(Me.nCheckBox2)
			Me.Controls.Add(Me.nCheckBox1)
			Me.Controls.Add(Me.nGroupBox2)
			Me.Controls.Add(Me.nGroupBox1)
			Me.Name = "NRadioButtonUC"
			Me.Size = New System.Drawing.Size(320, 328)
			Me.nGroupBox1.ResumeLayout(False)
			Me.nGroupBox2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private nRadioButton1 As Nevron.UI.WinForm.Controls.NRadioButton
		Private nRadioButton2 As Nevron.UI.WinForm.Controls.NRadioButton
		Private nRadioButton3 As Nevron.UI.WinForm.Controls.NRadioButton
		Private nRadioButton4 As Nevron.UI.WinForm.Controls.NRadioButton
		Private nRadioButton5 As Nevron.UI.WinForm.Controls.NRadioButton
		Private nRadioButton6 As Nevron.UI.WinForm.Controls.NRadioButton
		Private nRadioButton7 As Nevron.UI.WinForm.Controls.NRadioButton
		Private nRadioButton8 As Nevron.UI.WinForm.Controls.NRadioButton
		Private nRadioButton9 As Nevron.UI.WinForm.Controls.NRadioButton
		Private nRadioButton10 As Nevron.UI.WinForm.Controls.NRadioButton
		Private nRadioButton11 As Nevron.UI.WinForm.Controls.NRadioButton
		Private nRadioButton12 As Nevron.UI.WinForm.Controls.NRadioButton
		Private nRadioButton13 As Nevron.UI.WinForm.Controls.NRadioButton
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents nCheckBox1 As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents nCheckBox2 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nRadioButton14 As Nevron.UI.WinForm.Controls.NRadioButton
		Private nRadioButton15 As Nevron.UI.WinForm.Controls.NRadioButton

		#End Region
	End Class
End Namespace
