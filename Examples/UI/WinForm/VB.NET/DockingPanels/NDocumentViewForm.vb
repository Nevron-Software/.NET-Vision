Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.UI.WinForm.Docking

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NDocumentViewForm.
	''' </summary>
	Public Class NDocumentViewForm
		Inherits NDockingPanelsExampleForm
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()

			m_PropertyGrid.SelectedObject = m_DockManager.DocumentStyle

			m_DockManager.DocumentStyle.AllowTabReorder = False
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
		Protected Overrides Sub InitPanels()
			m_DockManager.DocumentStyle.ImageList = MainForm.StandardImages
			AddHandler m_DockManager.DocumentManager.ActiveDocumentChanged, AddressOf DocumentManager_ActiveDocumentChanged

			Dim doc As NUIDocument
			Dim tb As TextBox

			Dim lb As Label = New Label()
			lb.Dock = DockStyle.Fill
			lb.BackColor = Color.SaddleBrown

			tb = GetTextBox()
			tb.BorderStyle = BorderStyle.None
			tb.Text = "Text"
			tb.ScrollBars = ScrollBars.Both
			tb.WordWrap = False
			doc = New NUIDocument("Document 1", -1, tb)
			m_DockManager.DocumentManager.AddDocument(doc)

			tb = GetTextBox()
			tb.BorderStyle = BorderStyle.None
			tb.Text = "Document 2"
			doc = New NUIDocument("Document 2", 0, tb)
			m_DockManager.DocumentManager.AddDocument(doc)

			tb = GetTextBox()
			tb.BorderStyle = BorderStyle.None
			tb.Text = "Document 3"
			doc = New NUIDocument("Document 3", 0, tb)
			m_DockManager.DocumentManager.AddDocument(doc)

			Dim panel As NDockingPanel

			panel = New NDockingPanel()
			panel.Caption.ImageIndex = 0
			panel.Caption.ImageList = MainForm.ActionImages
			panel.Caption.ImageSize = New Size(20, 20)
			panel.Controls.Add(GetTextBox())
			panel.PerformDock(m_DockManager.DocumentManager.DocumentViewHost, DockStyle.Bottom)

			panel = New NDockingPanel()
			panel.Text = "Document Style"
			panel.TabInfo.Text = "Document Style"
			m_PropertyGrid.Dock = DockStyle.Fill
			panel.Controls.Add(m_PropertyGrid)
			panel.PerformDock(m_DockManager.RootContainer.RootZone, DockStyle.Right)
		End Sub

		Protected Overrides Sub InitCommandBars()
			MyBase.InitCommandBars()

			Dim comm, comm1 As NCommand
			Dim bar As NMenuBar = nCommandBarsManager1.Toolbars.GetMenu()

			comm = New NCommand()
			comm.Properties.Text = "Document"
			bar.Commands.Add(comm)

			comm1 = New NCommand()
			comm1.Properties.Text = "&New Document"
			comm1.Properties.ID = 0
			comm.Commands.Add(comm1)

			comm1 = New NCommand()
			comm1.Properties.Text = "&Close Document"
			comm1.Properties.ID = 1
			comm.Commands.Add(comm1)

			comm1 = New NCommand()
			comm1.Properties.Text = "Close &All Documents"
			comm1.Properties.ID = 2
			comm.Commands.Add(comm1)

			comm1 = New NCommand()
			comm1.Properties.Text = "Close All &But Active"
			comm1.Properties.ID = 8
			comm.Commands.Add(comm1)

			comm1 = New NCommand()
			comm1.Properties.BeginGroup = True
			comm1.Properties.Text = "Tile &Horizontally"
			comm1.Properties.ID = 3
			comm.Commands.Add(comm1)

			comm1 = New NCommand()
			comm1.Properties.Text = "Tile &Vertically"
			comm1.Properties.ID = 4
			comm.Commands.Add(comm1)

			comm1 = New NCommand()
			comm1.Properties.Text = "Ca&scade"
			comm1.Properties.ID = 5
			comm.Commands.Add(comm1)

			comm1 = New NCommand()
			comm1.Properties.Text = "Arrange &Icons"
			comm1.Properties.ID = 6
			comm.Commands.Add(comm1)

			comm1 = New NCommand()
			comm1.Properties.BeginGroup = True
			comm1.Properties.Text = "&Documents..."
			comm1.Properties.ID = 7
			comm.Commands.Add(comm1)
		End Sub
		Protected Overrides Sub nCommandBarsManager1_CommandClicked(ByVal sender As Object, ByVal e As CommandEventArgs)
			Dim comm As NCommand = e.Command
			Dim id As Integer = comm.Properties.ID

			Dim manager As NDocumentManager = m_DockManager.DocumentManager

			Select Case id
				Case 0
					For i As Integer = 0 To 0
						Dim index As Integer = manager.Documents.Length + 1
						Dim tb As TextBox = GetTextBox()
						tb.BorderStyle = BorderStyle.None

						Dim doc As NUIDocument = New NUIDocument("Document " & index.ToString(), 0, tb)
						manager.AddDocument(doc)
					Next i
				Case 1
					manager.CloseActiveDocument()
				Case 2
					manager.CloseAllDocuments()
				Case 3
					manager.LayoutMdi(MdiLayout.TileHorizontal)
				Case 4
					manager.LayoutMdi(MdiLayout.TileVertical)
				Case 5
					manager.LayoutMdi(MdiLayout.Cascade)
				Case 6
					manager.LayoutMdi(MdiLayout.ArrangeIcons)
				Case 7
					manager.ShowDocumentsEditor()
				Case 8
					manager.CloseAllButActive()
			End Select
		End Sub

		Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad (e)

			'm_DockManager.DocumentManager.Documents[0].Activate();
		End Sub


		#End Region

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			' 
			' NDocumentViewForm
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(792, 566)
			Me.Name = "NDocumentViewForm"
			Me.Text = "Document View Example"

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		#End Region

		Private Sub DocumentManager_ActiveDocumentChanged(ByVal sender As Object, ByVal e As DocumentEventArgs)
			Debug.WriteLine("Document changed...")
		End Sub
	End Class
End Namespace
