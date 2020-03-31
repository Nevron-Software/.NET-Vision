Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	Public Class NButtonUC
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
			MyBase.Dispose (disposing)
		End Sub

		Public Overrides Sub Initialize()
			MyBase.Initialize ()
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
		Private Sub m_BorderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_BorderButton.Click
			nButton6.Border.ShowEditor()
		End Sub


		#End Region

		#Region "Component Designer generated code"

		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NButtonUC))
			Me.m_ImageList = New System.Windows.Forms.ImageList(Me.components)
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nButton5 = New Nevron.UI.WinForm.Controls.NButton()
			Me.nButton2 = New Nevron.UI.WinForm.Controls.NButton()
			Me.nButton4 = New Nevron.UI.WinForm.Controls.NButton()
			Me.nButton3 = New Nevron.UI.WinForm.Controls.NButton()
			Me.nButton1 = New Nevron.UI.WinForm.Controls.NButton()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nButton6 = New Nevron.UI.WinForm.Controls.NButton()
			Me.nButton7 = New Nevron.UI.WinForm.Controls.NButton()
			Me.nButton8 = New Nevron.UI.WinForm.Controls.NButton()
			Me.nButton9 = New Nevron.UI.WinForm.Controls.NButton()
			Me.nButton10 = New Nevron.UI.WinForm.Controls.NButton()
			Me.nCheckBox1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox2 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_BorderButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.nGroupBox1.SuspendLayout()
			Me.nGroupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' m_ImageList
			' 
			Me.m_ImageList.ImageSize = New System.Drawing.Size(16, 16)
			Me.m_ImageList.TransparentColor = System.Drawing.Color.Transparent
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.nButton5)
			Me.nGroupBox1.Controls.Add(Me.nButton2)
			Me.nGroupBox1.Controls.Add(Me.nButton4)
			Me.nGroupBox1.Controls.Add(Me.nButton3)
			Me.nGroupBox1.Controls.Add(Me.nButton1)
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(8, 8)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(160, 264)
			Me.nGroupBox1.TabIndex = 14
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Flat Buttons"
			' 
			' nButton5
			' 
			Me.nButton5.Location = New System.Drawing.Point(16, 192)
			Me.nButton5.Name = "nButton5"
			Me.nButton5.PaletteInheritance = (CType((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable Or Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes), Nevron.UI.WinForm.Controls.PaletteInheritance))
			Me.nButton5.Size = New System.Drawing.Size(104, 56)
			Me.nButton5.TabIndex = 4
			Me.nButton5.Text = "nButton5"
			' 
			' nButton2
			' 
			Me.nButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nButton2.ImageIndex = 5
			Me.nButton2.ImageList = Me.m_ImageList
			Me.nButton2.Location = New System.Drawing.Point(32, 152)
			Me.nButton2.Name = "nButton2"
			Me.nButton2.PaletteInheritance = (CType((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable Or Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes), Nevron.UI.WinForm.Controls.PaletteInheritance))
			Me.nButton2.Size = New System.Drawing.Size(72, 23)
			Me.nButton2.TabIndex = 3
			Me.nButton2.Text = "nButton2"
			Me.nButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' nButton4
			' 
			Me.nButton4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
			Me.nButton4.ImageList = Me.m_ImageList
			Me.nButton4.Location = New System.Drawing.Point(32, 120)
			Me.nButton4.Name = "nButton4"
			Me.nButton4.PaletteInheritance = (CType((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable Or Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes), Nevron.UI.WinForm.Controls.PaletteInheritance))
			Me.nButton4.Size = New System.Drawing.Size(72, 24)
			Me.nButton4.TabIndex = 2
			Me.nButton4.Text = "nButton4"
			' 
			' nButton3
			' 
			Me.nButton3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
			Me.nButton3.ImageIndex = 3
			Me.nButton3.ImageList = Me.m_ImageList
			Me.nButton3.Location = New System.Drawing.Point(32, 72)
			Me.nButton3.Name = "nButton3"
			Me.nButton3.PaletteInheritance = (CType((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable Or Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes), Nevron.UI.WinForm.Controls.PaletteInheritance))
			Me.nButton3.Size = New System.Drawing.Size(72, 40)
			Me.nButton3.TabIndex = 1
			Me.nButton3.Text = "nButton3"
			Me.nButton3.TextAlign = System.Drawing.ContentAlignment.TopCenter
			' 
			' nButton1
			' 
			Me.nButton1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
			Me.nButton1.ImageIndex = 1
			Me.nButton1.ImageList = Me.m_ImageList
			Me.nButton1.Location = New System.Drawing.Point(32, 24)
			Me.nButton1.Name = "nButton1"
			Me.nButton1.PaletteInheritance = (CType((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable Or Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes), Nevron.UI.WinForm.Controls.PaletteInheritance))
			Me.nButton1.Size = New System.Drawing.Size(72, 40)
			Me.nButton1.TabIndex = 0
			Me.nButton1.Text = "nButton1"
			Me.nButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Controls.Add(Me.nButton6)
			Me.nGroupBox2.Controls.Add(Me.nButton7)
			Me.nGroupBox2.Controls.Add(Me.nButton8)
			Me.nGroupBox2.Controls.Add(Me.nButton9)
			Me.nGroupBox2.Controls.Add(Me.nButton10)
			Me.nGroupBox2.ImageIndex = 0
			Me.nGroupBox2.Location = New System.Drawing.Point(184, 8)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(160, 264)
			Me.nGroupBox2.TabIndex = 15
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "Light3D Buttons"
			' 
			' nButton6
			' 
			Me.nButton6.Location = New System.Drawing.Point(24, 192)
			Me.nButton6.Name = "nButton6"
			Me.nButton6.PaletteInheritance = (CType((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable Or Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes), Nevron.UI.WinForm.Controls.PaletteInheritance))
			Me.nButton6.Size = New System.Drawing.Size(104, 56)
			Me.nButton6.TabIndex = 9
			Me.nButton6.Text = "nButton6"
			' 
			' nButton7
			' 
			Me.nButton7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nButton7.ImageIndex = 5
			Me.nButton7.ImageList = Me.m_ImageList
			Me.nButton7.Location = New System.Drawing.Point(40, 152)
			Me.nButton7.Name = "nButton7"
			Me.nButton7.PaletteInheritance = (CType((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable Or Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes), Nevron.UI.WinForm.Controls.PaletteInheritance))
			Me.nButton7.Size = New System.Drawing.Size(72, 23)
			Me.nButton7.TabIndex = 8
			Me.nButton7.Text = "nButton7"
			Me.nButton7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' nButton8
			' 
			Me.nButton8.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
			Me.nButton8.ImageList = Me.m_ImageList
			Me.nButton8.Location = New System.Drawing.Point(40, 120)
			Me.nButton8.Name = "nButton8"
			Me.nButton8.PaletteInheritance = (CType((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable Or Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes), Nevron.UI.WinForm.Controls.PaletteInheritance))
			Me.nButton8.Size = New System.Drawing.Size(72, 24)
			Me.nButton8.TabIndex = 7
			Me.nButton8.Text = "nButton8"
			' 
			' nButton9
			' 
			Me.nButton9.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
			Me.nButton9.ImageIndex = 3
			Me.nButton9.ImageList = Me.m_ImageList
			Me.nButton9.Location = New System.Drawing.Point(40, 72)
			Me.nButton9.Name = "nButton9"
			Me.nButton9.PaletteInheritance = (CType((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable Or Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes), Nevron.UI.WinForm.Controls.PaletteInheritance))
			Me.nButton9.Size = New System.Drawing.Size(72, 40)
			Me.nButton9.TabIndex = 6
			Me.nButton9.Text = "nButton9"
			Me.nButton9.TextAlign = System.Drawing.ContentAlignment.TopCenter
			' 
			' nButton10
			' 
			Me.nButton10.ImageAlign = System.Drawing.ContentAlignment.TopCenter
			Me.nButton10.ImageIndex = 1
			Me.nButton10.ImageList = Me.m_ImageList
			Me.nButton10.Location = New System.Drawing.Point(40, 24)
			Me.nButton10.Name = "nButton10"
			Me.nButton10.PaletteInheritance = (CType((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable Or Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes), Nevron.UI.WinForm.Controls.PaletteInheritance))
			Me.nButton10.Size = New System.Drawing.Size(72, 40)
			Me.nButton10.TabIndex = 5
			Me.nButton10.Text = "nButton10"
			Me.nButton10.TextAlign = System.Drawing.ContentAlignment.BottomCenter
			' 
			' nCheckBox1
			' 
			Me.nCheckBox1.Checked = True
			Me.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
			Me.nCheckBox1.Location = New System.Drawing.Point(8, 304)
			Me.nCheckBox1.Name = "nCheckBox1"
			Me.nCheckBox1.TabIndex = 16
			Me.nCheckBox1.Text = "&Enable"
'			Me.nCheckBox1.CheckedChanged += New System.EventHandler(Me.nCheckBox1_CheckedChanged);
			' 
			' nCheckBox2
			' 
			Me.nCheckBox2.Checked = True
			Me.nCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
			Me.nCheckBox2.Location = New System.Drawing.Point(120, 304)
			Me.nCheckBox2.Name = "nCheckBox2"
			Me.nCheckBox2.Size = New System.Drawing.Size(128, 24)
			Me.nCheckBox2.TabIndex = 17
			Me.nCheckBox2.Text = "Show &Focus Rect"
'			Me.nCheckBox2.CheckedChanged += New System.EventHandler(Me.nCheckBox2_CheckedChanged);
			' 
			' m_BorderButton
			' 
			Me.m_BorderButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
			Me.m_BorderButton.ImageList = Me.m_ImageList
			Me.m_BorderButton.Location = New System.Drawing.Point(248, 304)
			Me.m_BorderButton.Name = "m_BorderButton"
			Me.m_BorderButton.PaletteInheritance = (CType((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable Or Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes), Nevron.UI.WinForm.Controls.PaletteInheritance))
			Me.m_BorderButton.Size = New System.Drawing.Size(72, 24)
			Me.m_BorderButton.TabIndex = 18
			Me.m_BorderButton.Text = "Border..."
'			Me.m_BorderButton.Click += New System.EventHandler(Me.m_BorderButton_Click);
			' 
			' NButtonUC
			' 
			Me.Controls.Add(Me.m_BorderButton)
			Me.Controls.Add(Me.nCheckBox2)
			Me.Controls.Add(Me.nCheckBox1)
			Me.Controls.Add(Me.nGroupBox1)
			Me.Controls.Add(Me.nGroupBox2)
			Me.Name = "NButtonUC"
			Me.Size = New System.Drawing.Size(352, 336)
			Me.nGroupBox1.ResumeLayout(False)
			Me.nGroupBox2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub



		#End Region

		#Region "Fields"

		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Friend m_ImageList As System.Windows.Forms.ImageList
		Private components As System.ComponentModel.IContainer
		Private WithEvents nCheckBox1 As Nevron.UI.WinForm.Controls.NCheckBox

		Private nButton1 As Nevron.UI.WinForm.Controls.NButton
		Private nButton3 As Nevron.UI.WinForm.Controls.NButton
		Private nButton4 As Nevron.UI.WinForm.Controls.NButton
		Private nButton2 As Nevron.UI.WinForm.Controls.NButton
		Private nButton5 As Nevron.UI.WinForm.Controls.NButton
		Private nButton6 As Nevron.UI.WinForm.Controls.NButton
		Private nButton7 As Nevron.UI.WinForm.Controls.NButton
		Private nButton8 As Nevron.UI.WinForm.Controls.NButton
		Private nButton9 As Nevron.UI.WinForm.Controls.NButton
		Private nButton10 As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_BorderButton As Nevron.UI.WinForm.Controls.NButton

		Private WithEvents nCheckBox2 As Nevron.UI.WinForm.Controls.NCheckBox

		#End Region
	End Class
End Namespace
