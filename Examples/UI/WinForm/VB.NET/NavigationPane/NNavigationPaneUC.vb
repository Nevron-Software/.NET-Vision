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
	''' Summary description for NNavigationPaneUC.
	''' </summary>
	Public Class NNavigationPaneUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()

			DockPadding.All = 4

			Dock = DockStyle.Fill

			m_ContextMenu = New NContextMenu()
			Dim comm As Nevron.UI.WinForm.Controls.NCommand

			For i As Integer = 1 To 4
				comm = New Nevron.UI.WinForm.Controls.NCommand()
				comm.Properties.Text = "Context Menu Command " & i.ToString()
				m_ContextMenu.Commands.Add(comm)
			Next i
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

		Public Overrides Sub Initialize()
			MyBase.Initialize ()

			m_arrImages = New Image(7){}
			m_arrSmallImages = New Image(7){}
			m_arrTexts = New String(7){}

			Dim lb As Label

			Dim t As Type = Me.GetType()
			Dim path As String = "Nevron.Examples.UI.WinForm.Resources.Images.NavigationPane"

			m_arrImages(0) = NResourceHelper.BitmapFromResource(t, "Mail.png", path)
			m_arrImages(1) = NResourceHelper.BitmapFromResource(t, "Calendar.png", path)
			m_arrImages(2) = NResourceHelper.BitmapFromResource(t, "Contacts.png", path)
			m_arrImages(3) = NResourceHelper.BitmapFromResource(t, "Tasks.png", path)
			m_arrImages(4) = NResourceHelper.BitmapFromResource(t, "Notes.png", path)
			m_arrImages(5) = NResourceHelper.BitmapFromResource(t, "Folders.png", path)
			m_arrImages(6) = NResourceHelper.BitmapFromResource(t, "Shortcuts.png", path)
			m_arrImages(7) = NResourceHelper.BitmapFromResource(t, "Journal.png", path)

			m_arrSmallImages(0) = NResourceHelper.BitmapFromResource(t, "MailSmall.png", path)
			m_arrSmallImages(1) = NResourceHelper.BitmapFromResource(t, "CalendarSmall.png", path)
			m_arrSmallImages(2) = NResourceHelper.BitmapFromResource(t, "ContactsSmall.png", path)
			m_arrSmallImages(3) = NResourceHelper.BitmapFromResource(t, "TasksSmall.png", path)
			m_arrSmallImages(4) = NResourceHelper.BitmapFromResource(t, "NotesSmall.png", path)
			m_arrSmallImages(5) = NResourceHelper.BitmapFromResource(t, "FoldersSmall.png", path)
			m_arrSmallImages(6) = NResourceHelper.BitmapFromResource(t, "ShortcutsSmall.png", path)
			m_arrSmallImages(7) = NResourceHelper.BitmapFromResource(t, "JournalSmall.png", path)

			m_arrTexts(0) = "Mail"
			m_arrTexts(1) = "Calendar"
			m_arrTexts(2) = "Contacts"
			m_arrTexts(3) = "Tasks"
			m_arrTexts(4) = "Notes"
			m_arrTexts(5) = "Folders List"
			m_arrTexts(6) = "Shortcuts"
			m_arrTexts(7) = "Journal"

			m_Pane = New NNavigationPane()
			m_Pane.Dock = DockStyle.Left

			For i As Integer = 0 To 7
				Dim band As NNavigationPaneBand = New NNavigationPaneBand()
				band.ContextMenu = m_ContextMenu
				lb = New Label()
				lb.Text = m_arrTexts(i)
				band.TooltipText = "Sample tooltip for '" & m_arrTexts(i) & "' band"
				lb.Dock = DockStyle.Fill
				lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
				lb.Parent = band

				band.Image = m_arrImages(i)
				band.SmallImage = m_arrSmallImages(i)

				m_Pane.Controls.Add(band)

				band.Text = m_arrTexts(i)
			Next i

			m_Pane.Parent = Me
			m_Pane.ButtonsPreferredHeight = 96

			Dim splitter As NSplitter = New NSplitter()
			splitter.Dock = DockStyle.Left
			splitter.Parent = Me
			splitter.BringToFront()

			Me.optionsCommandCheck.Checked = True
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub optionsCommandCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optionsCommandCheck.CheckedChanged
			m_Pane.DisplayOptionsCommand = optionsCommandCheck.Checked
		End Sub

		Private Sub nCheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox1.CheckedChanged
			If m_Pane Is Nothing Then
				Return
			End If

			m_Pane.AllowStackResize = nCheckBox1.Checked
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.optionsCommandCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' optionsCommandCheck
			' 
			Me.optionsCommandCheck.ButtonProperties.BorderOffset = 2
			Me.optionsCommandCheck.Location = New System.Drawing.Point(312, 0)
			Me.optionsCommandCheck.Name = "optionsCommandCheck"
			Me.optionsCommandCheck.Size = New System.Drawing.Size(168, 24)
			Me.optionsCommandCheck.TabIndex = 1
			Me.optionsCommandCheck.Text = "Display Options Command"
'			Me.optionsCommandCheck.CheckedChanged += New System.EventHandler(Me.optionsCommandCheck_CheckedChanged);
			' 
			' nCheckBox1
			' 
			Me.nCheckBox1.ButtonProperties.BorderOffset = 2
			Me.nCheckBox1.Checked = True
			Me.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
			Me.nCheckBox1.Location = New System.Drawing.Point(312, 24)
			Me.nCheckBox1.Name = "nCheckBox1"
			Me.nCheckBox1.Size = New System.Drawing.Size(168, 24)
			Me.nCheckBox1.TabIndex = 2
			Me.nCheckBox1.Text = "Allow Stack Resize"
'			Me.nCheckBox1.CheckedChanged += New System.EventHandler(Me.nCheckBox1_CheckedChanged);
			' 
			' NNavigationPaneUC
			' 
			Me.Controls.Add(Me.nCheckBox1)
			Me.Controls.Add(Me.optionsCommandCheck)
			Me.Name = "NNavigationPaneUC"
			Me.Size = New System.Drawing.Size(480, 408)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Friend m_Pane As NNavigationPane
		Friend m_arrImages As Image()
		Friend m_arrSmallImages As Image()
		Friend m_arrTexts As String()
		Friend m_ContextMenu As NContextMenu
		Private WithEvents optionsCommandCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents nCheckBox1 As Nevron.UI.WinForm.Controls.NCheckBox
		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace
