Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.IO
Imports System.Windows.Forms

Imports Nevron.UI
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NVS2005UC.
	''' </summary>
	Public Class NIDELoadUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()
		End Sub
		Shared Sub New()
			Dim t As Type = GetType(NIDELoadUC)
			Dim path As String = "Nevron.Examples.UI.WinForm.SampleIDEs.Bitmaps"
			StandardImageList = NResourceHelper.ImageListFromBitmap(t, New Size(16, 16), Color.Magenta, "IDEStandard.bmp", path)
			SolutionExplorerImageList = NResourceHelper.ImageListFromBitmap(t, New Size(16, 16), Color.Magenta, "SolutionExplorer.bmp", path)
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

		#Region "Implementation"

		Friend Shared Function IsFileBrowsable(ByVal info As FileInfo) As Boolean
			Dim name As String = info.Extension.ToLower()
			Dim length As Integer = m_arrBrowsableFiles.Length

			Dim i As Integer = 0
			Do While i < length
				If name = m_arrBrowsableFiles(i) Then
					Return True
				End If
				i += 1
			Loop

			Return False
		End Function

		Friend Shared Function IsDirectoryBrowsable(ByVal info As DirectoryInfo) As Boolean
			Dim name As String = info.Name
			Dim length As Integer = m_arrNonBrowsableDirectories.Length

			Dim i As Integer = 0
			Do While i < length
				If name = m_arrNonBrowsableDirectories(i) Then
					Return False
				End If
				i += 1
			Loop

			Return True
		End Function


		#End Region

		#Region "Event Handlers"

		Private Sub m_LoadButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_LoadButton.Click
			Dim node As TreeNode = m_MainForm.NavigationTreeControl.NavigationTree.SelectedNode
			If node Is Nothing Then
				Return
			End If

			'System.Windows.Forms.Cursor c = System.Windows.Forms.Cursor.Current;
			'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

			Dim f As Form = Nothing

			Select Case node.Text
				Case "Visual Studio"
					f = New NVisualStudioIDE(Me)
			End Select

			f.Show()

			'System.Windows.Forms.Cursor.Current = c;
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.m_LoadButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' m_LoadButton
			' 
			Me.m_LoadButton.Location = New System.Drawing.Point(8, 16)
			Me.m_LoadButton.Name = "m_LoadButton"
			Me.m_LoadButton.Size = New System.Drawing.Size(184, 24)
			Me.m_LoadButton.TabIndex = 0
			Me.m_LoadButton.Text = "Load Sample IDE"
'			Me.m_LoadButton.Click += New System.EventHandler(Me.m_LoadButton_Click);
			' 
			' NIDELoadUC
			' 
			Me.Controls.Add(Me.m_LoadButton)
			Me.Name = "NIDELoadUC"
			Me.Size = New System.Drawing.Size(200, 56)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		Private WithEvents m_LoadButton As NButton

		Friend Shared StandardImageList As ImageList
		Friend Shared SolutionExplorerImageList As ImageList

		Friend Shared m_arrBrowsableFiles As String() = New String(){".cs", ".ico", ".bmp"}
		Friend Shared m_arrNonBrowsableDirectories As String() = New String(){"bin", "obj", "HTML", "CustomPalettes"}

		#End Region

		Friend Enum RangeID
			Standard
			MenuBar
		End Enum
		Friend Enum CommandID
			'standard ids
			NewProject
			NewBlankSolution
			AddNewItem
			AddExistingItem
			AddWindowsForm
			AddInheritedForm
			AddUsercontrol
			AddInheritedControl
			AddComponent
			AddClass
			Open
			Save
			SaveAll
			Cut
			Copy
			Paste
			Undo
			Redo
			NavigateBackward
			NavigateForward
			StartContinue
			SolutionConfigurations
			SolutionExplorer
			Properties
			ObjectBrowser
			Toolbox
			ClassView
			ServerExplorer
			ResourceView
			TaskList
			Output
			CommandWindow
			FindSymbolResults
			[Exit]
			SelectAll
		End Enum
	End Class
End Namespace
