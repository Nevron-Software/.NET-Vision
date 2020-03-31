Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for UIAboutDlg.
	''' </summary>
	Public Class UIAboutDlg
		Inherits System.Windows.Forms.Form
		#Region "Constructor"

		Public Sub New()
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

		Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad (e)

			SetAboutText()

			NUIManager.ApplyPalette(Me)
			BackColor = Color.White
		End Sub


		#End Region

		#Region "Implementation"

		Friend Sub SetAboutText()
			textBox1.Text = "Nevron User Interface Suite 4.0" & Constants.vbCrLf & "Copyright 1998-2005 Nevron. All Rights Reserved." & Constants.vbCrLf & Constants.vbCrLf & "***Compatible Frameworks:***" & Constants.vbCrLf & "--------------------" & Constants.vbCrLf & ".NET Framework v.1.0" & Constants.vbCrLf & ".NET Framework v.1.1" & Constants.vbCrLf & "--------------------" & Constants.vbCrLf & "***Compatible Platforms:***" & Constants.vbCrLf & "--------------------" & Constants.vbCrLf & "Microsoft Windows NT" & Constants.vbCrLf & "Microsoft Windows 2000" & Constants.vbCrLf & "Microsoft Windows XP" & Constants.vbCrLf & "--------------------" & Constants.vbCrLf & "***Compatible Environments***" & Constants.vbCrLf & "--------------------" & Constants.vbCrLf & "Microsoft Visual Studio .NET" & Constants.vbCrLf & "Microsoft Visual C# .NET" & Constants.vbCrLf & "Microsoft Visual C++ .NET" & Constants.vbCrLf & "Microsoft Visual Basic .NET"

			textBox1.SelectionLength = 0
		End Sub


		#End Region

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(UIAboutDlg))
			Me.textBox1 = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.m_OKButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.pictureBox1 = New System.Windows.Forms.PictureBox()
			Me.SuspendLayout()
			' 
			' textBox1
			' 
			Me.textBox1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.textBox1.Location = New System.Drawing.Point(8, 120)
			Me.textBox1.Multiline = True
			Me.textBox1.Name = "textBox1"
			Me.textBox1.ReadOnly = True
			Me.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
			Me.textBox1.Size = New System.Drawing.Size(304, 168)
			Me.textBox1.TabIndex = 1
			Me.textBox1.Text = ""
			' 
			' m_OKButton
			' 
			Me.m_OKButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.m_OKButton.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.m_OKButton.Location = New System.Drawing.Point(232, 296)
			Me.m_OKButton.Name = "m_OKButton"
			Me.m_OKButton.Size = New System.Drawing.Size(80, 23)
			Me.m_OKButton.TabIndex = 0
			Me.m_OKButton.Text = "&OK"
			' 
			' pictureBox1
			' 
			Me.pictureBox1.Image = (CType(resources.GetObject("pictureBox1.Image"), System.Drawing.Image))
			Me.pictureBox1.Location = New System.Drawing.Point(8, 8)
			Me.pictureBox1.Name = "pictureBox1"
			Me.pictureBox1.Size = New System.Drawing.Size(200, 98)
			Me.pictureBox1.TabIndex = 2
			Me.pictureBox1.TabStop = False
			' 
			' UIAboutDlg
			' 
			Me.AcceptButton = Me.m_OKButton
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.BackColor = System.Drawing.SystemColors.Window
			Me.ClientSize = New System.Drawing.Size(322, 328)
			Me.Controls.Add(Me.pictureBox1)
			Me.Controls.Add(Me.m_OKButton)
			Me.Controls.Add(Me.textBox1)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "UIAboutDlg"
			Me.ShowInTaskbar = False
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Nevron User Interface Suite 4.0"
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		Private textBox1 As NTextBox
		Private pictureBox1 As System.Windows.Forms.PictureBox
		Private m_OKButton As NButton

		#End Region
	End Class
End Namespace
