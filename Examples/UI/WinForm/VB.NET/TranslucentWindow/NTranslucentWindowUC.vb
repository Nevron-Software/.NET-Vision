Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NTranslucentWindowUC.
	''' </summary>
	Public Class NTranslucentWindowUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()

			m_PictureBox.Image = f.Config.SplashImage
		End Sub


		#End Region

		#Region "Overrides"

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If

				If Not m_LayeredWindow Is Nothing Then
					m_LayeredWindow.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub m_LoadImageButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_LoadImageButton.Click
			Dim ofd As OpenFileDialog = New OpenFileDialog()
			ofd.Title = "Select Image:"
			ofd.Filter = NUIManager.AllImageFilesFilter

			If ofd.ShowDialog() <> System.Windows.Forms.DialogResult.OK Then
				Return
			End If

			m_PictureBox.Image = Image.FromFile(ofd.FileName)
		End Sub

		Private Sub m_ShowWindowButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ShowWindowButton.Click
			If m_PictureBox.Image Is Nothing OrElse Not m_LayeredWindow Is Nothing Then
				Return
			End If

			m_LayeredWindow = New NLayeredWindow()
			m_LayeredWindow.Moveable = m_MoveableCheckBox.Checked
			m_LayeredWindow.BackgroundImage = m_PictureBox.Image
			m_LayeredWindow.ShowWindow(NUISystem.GetCenterScreenLocation(m_LayeredWindow.BackgroundImage.Size))
		End Sub

		Private Sub m_CloseWindowButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_CloseWindowButton.Click
			If m_LayeredWindow Is Nothing Then
				Return
			End If

			m_LayeredWindow.Dispose()
			m_LayeredWindow = Nothing
		End Sub

		Private Sub m_MoveableCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_MoveableCheckBox.CheckedChanged
			If Not m_LayeredWindow Is Nothing Then
				m_LayeredWindow.Moveable = m_MoveableCheckBox.Checked
			End If
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.m_ShowWindowButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_LoadImageButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_PictureBox = New System.Windows.Forms.PictureBox()
			Me.m_CloseWindowButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_MoveableCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' m_ShowWindowButton
			' 
			Me.m_ShowWindowButton.Location = New System.Drawing.Point(8, 248)
			Me.m_ShowWindowButton.Name = "m_ShowWindowButton"
			Me.m_ShowWindowButton.Size = New System.Drawing.Size(112, 24)
			Me.m_ShowWindowButton.TabIndex = 0
			Me.m_ShowWindowButton.Text = "Show Window"
'			Me.m_ShowWindowButton.Click += New System.EventHandler(Me.m_ShowWindowButton_Click);
			' 
			' m_LoadImageButton
			' 
			Me.m_LoadImageButton.Location = New System.Drawing.Point(8, 208)
			Me.m_LoadImageButton.Name = "m_LoadImageButton"
			Me.m_LoadImageButton.Size = New System.Drawing.Size(112, 24)
			Me.m_LoadImageButton.TabIndex = 1
			Me.m_LoadImageButton.Text = "Load Image..."
'			Me.m_LoadImageButton.Click += New System.EventHandler(Me.m_LoadImageButton_Click);
			' 
			' m_PictureBox
			' 
			Me.m_PictureBox.BackColor = System.Drawing.Color.White
			Me.m_PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.m_PictureBox.Location = New System.Drawing.Point(8, 8)
			Me.m_PictureBox.Name = "m_PictureBox"
			Me.m_PictureBox.Size = New System.Drawing.Size(232, 192)
			Me.m_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.m_PictureBox.TabIndex = 2
			Me.m_PictureBox.TabStop = False
			' 
			' m_CloseWindowButton
			' 
			Me.m_CloseWindowButton.Location = New System.Drawing.Point(128, 248)
			Me.m_CloseWindowButton.Name = "m_CloseWindowButton"
			Me.m_CloseWindowButton.Size = New System.Drawing.Size(112, 24)
			Me.m_CloseWindowButton.TabIndex = 3
			Me.m_CloseWindowButton.Text = "Close Window"
'			Me.m_CloseWindowButton.Click += New System.EventHandler(Me.m_CloseWindowButton_Click);
			' 
			' m_MoveableCheckBox
			' 
			Me.m_MoveableCheckBox.Checked = True
			Me.m_MoveableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_MoveableCheckBox.Location = New System.Drawing.Point(8, 280)
			Me.m_MoveableCheckBox.Name = "m_MoveableCheckBox"
			Me.m_MoveableCheckBox.TabIndex = 4
			Me.m_MoveableCheckBox.Text = "Moveable"
'			Me.m_MoveableCheckBox.CheckedChanged += New System.EventHandler(Me.m_MoveableCheckBox_CheckedChanged);
			' 
			' NTranslucentWindowUC
			' 
			Me.Controls.Add(Me.m_MoveableCheckBox)
			Me.Controls.Add(Me.m_CloseWindowButton)
			Me.Controls.Add(Me.m_PictureBox)
			Me.Controls.Add(Me.m_LoadImageButton)
			Me.Controls.Add(Me.m_ShowWindowButton)
			Me.Name = "NTranslucentWindowUC"
			Me.Size = New System.Drawing.Size(248, 312)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		Friend m_LayeredWindow As NLayeredWindow

		Private WithEvents m_ShowWindowButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_LoadImageButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_CloseWindowButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_MoveableCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private m_PictureBox As System.Windows.Forms.PictureBox

		#End Region
	End Class
End Namespace
