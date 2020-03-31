Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Reflection
Imports System.IO

Imports Nevron.UI
Imports Nevron.UI.WinForm.Controls
Imports Nevron.UI.WinForm.Docking
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NVSNET2003.
	''' </summary>
	Public Class NVisualStudioIDE
		Inherits NForm
		#Region "Constructor"

		Public Sub New(ByVal loader As NIDELoadUC)
			InitializeComponent()

			m_Loader = loader
			m_SolutionExplorer.HideSelection = False

			ResizeRedraw = False

			m_SolutionExplorer.Dock = DockStyle.Fill

			LoadDockingFramework()

			PopulateSolutionExplorer()
			LoadCommandBars()

			nStatusBar1.SendToBack()

			NUIManager.ApplyPalette(Me)
		End Sub


		#End Region

		#Region "Overrides"

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If

				m_CommandBarsManager.Dispose()
				m_DockManager.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub


		#End Region

		#Region "Implementation"

		Friend Sub AddDocument(ByVal fi As FileInfo, ByVal node As TreeNode)
		End Sub
		Friend Function GetDocument() As NWebBrowser
			Dim document As NWebBrowser = New NWebBrowser()
			document.Dock = DockStyle.Fill

			Return document
		End Function

		Friend Sub PopulateSolutionExplorer()
			Try
				m_SolutionExplorer.Font = m_DockManager.CaptionStyle.Font
				m_SolutionExplorer.ImageList = NIDELoadUC.SolutionExplorerImageList
				m_SolutionExplorer.ImageIndex = -1
				m_SolutionExplorer.SelectedImageIndex = -1

				AddHandler m_SolutionExplorer.BeforeExpand, AddressOf m_SolutionExplorer_BeforeExpand
				AddHandler m_SolutionExplorer.BeforeCollapse, AddressOf m_SolutionExplorer_BeforeCollapse
				AddHandler m_SolutionExplorer.DoubleClick, AddressOf m_SolutionExplorer_DoubleClick

				Dim project As TreeNode = m_SolutionExplorer.Nodes.Add("UserInterfaceExamples")
				project.ImageIndex = 5
				project.SelectedImageIndex = 5

				'references
				Dim references As TreeNode = project.Nodes.Add("References")
				references.ImageIndex = 2
				references.SelectedImageIndex = 2
				PopulateReferences(references)

				'DirectoryInfo dirInfo = new DirectoryInfo(Path.GetFullPath("../../"));
				'PopulateDirectory(project, dirInfo);
			Catch
			End Try
		End Sub

		Friend Sub PopulateReferences(ByVal parent As TreeNode)
			Dim [assembly] As System.Reflection.Assembly = Me.GetType().Assembly

			Dim references As AssemblyName() = [assembly].GetReferencedAssemblies()
			Dim length As Integer = references.Length

			Dim keys As String() = New String(length - 1){}
			Dim i As Integer = 0
			Do While i < length
				keys(i) = references(i).Name
				i += 1
			Loop

			Array.Sort(keys, references)

			Dim name As AssemblyName
			Dim node As TreeNode

			i = 0
			Do While i < length
				name = references(i)
				node = parent.Nodes.Add(name.Name)
				node.ImageIndex = 4
				node.SelectedImageIndex = 4
				i += 1
			Loop
		End Sub

		Friend Sub PopulateDirectory(ByVal parent As TreeNode, ByVal dirInfo As DirectoryInfo)
			Dim infos As DirectoryInfo() = dirInfo.GetDirectories()

			Dim length As Integer = infos.Length
			Dim info As DirectoryInfo
			Dim node As TreeNode
			Dim name As String

			Dim i As Integer = 0
			Do While i < length
				info = infos(i)
				If (Not NIDELoadUC.IsDirectoryBrowsable(info)) Then
					Continue Do
				End If

				name = info.Name

				node = parent.Nodes.Add(info.Name)
				node.ImageIndex = 0
				node.SelectedImageIndex = 0

				PopulateDirectory(node, info)
				i += 1
			Loop

			Dim fileInfos As FileInfo() = dirInfo.GetFiles()
			Dim fi As FileInfo
			length = fileInfos.Length

			i = 0
			Do While i < length
				fi = fileInfos(i)
				If (Not NIDELoadUC.IsFileBrowsable(fi)) Then
					Continue Do
				End If

				name = fi.Name
				node = parent.Nodes.Add(fi.Name)
				node.Tag = fi

				name = name.Replace(fi.Extension, "")

				If fi.Extension = ".cs" Then
					If name.EndsWith("UC") Then
						node.ImageIndex = 6
						node.SelectedImageIndex = 6
					Else
						node.ImageIndex = 8
						node.SelectedImageIndex = 8
					End If
					Continue Do
				End If

				If fi.Extension.EndsWith("ico") Then
					node.ImageIndex = 9
					node.SelectedImageIndex = 9
				End If

				If fi.Extension.EndsWith("bmp") Then
					node.ImageIndex = 10
					node.SelectedImageIndex = 10
				End If
				i += 1
			Loop
		End Sub


		#End Region

		#Region "Command Bars Initialization"

		Friend Sub LoadCommandBars()
			InitCommandBarsManager()

			'ranges
			InitRanges()

			'contexts
			InitStandardContexts()
			InitMenuContexts()

			'command bars
			InitMainMenu()
			InitStandardCommandBar()
		End Sub
		Friend Sub InitCommandBarsManager()
			m_CommandBarsManager = New NCommandBarsManager(Me)
			m_CommandBarsManager.Contexts.UniqueIDOnly = False
			m_CommandBarsManager.Palette.Copy(NUIManager.Palette)
		End Sub

		Friend Sub SetFadeImageAndImageShadow(ByVal commands As ArrayList, ByVal fade As Boolean, ByVal shadow As Boolean)
			Dim comm As Nevron.UI.WinForm.Controls.NCommand
			Dim count As Integer = commands.Count

			Dim i As Integer = 0
			Do While i < count
				comm = CType(commands(i), Nevron.UI.WinForm.Controls.NCommand)
				comm.Properties.FadeImage = fade
				comm.Properties.ImageShadow = shadow
				i += 1
			Loop
		End Sub
		Friend Sub SetFadeImageAndImageShadow(ByVal parent As NCommandContext, ByVal fade As Boolean, ByVal shadow As Boolean)
			Dim context As NCommandContext
			Dim count As Integer = parent.Contexts.Count

			Dim i As Integer = 0
			Do While i < count
				context = parent.Contexts(i)
				context.Properties.FadeImage = fade
				context.Properties.ImageShadow = shadow

				SetFadeImageAndImageShadow(context, fade, shadow)
				i += 1
			Loop
		End Sub


		#Region "Command Ranges"

		Friend Sub InitRanges()
			Dim r As NRange = New NRange()
			r.Name = "Standard"
			r.ID = CInt(Fix(NIDELoadUC.RangeID.Standard))
			m_CommandBarsManager.Ranges.Add(r)

			r = New NRange()
			r.Name = "Menu Bar"
			r.ID = CInt(Fix(NIDELoadUC.RangeID.MenuBar))
			m_CommandBarsManager.Ranges.Add(r)
		End Sub


		#End Region

		#Region "Command Contexts"

		Friend Sub InitStandardContexts()
			Dim context1, context2 As NCommandContext

			'new project context
			context1 = NCommandContext.CreateContext("New Project...", -1, NIDELoadUC.StandardImageList, 0, CInt(Fix(NIDELoadUC.RangeID.Standard)), Nothing, False)
			m_CommandBarsManager.Contexts.Add(context1)

			context2 = NCommandContext.CreateContext("New Project...", CInt(Fix(NIDELoadUC.CommandID.NewProject)), NIDELoadUC.StandardImageList, 0, CInt(Fix(NIDELoadUC.RangeID.Standard)), New NShortcut(Keys.N, Keys.Control Or Keys.Shift), False)
			context1.Contexts.Add(context2)
			m_CommandBarsManager.Contexts.Add(context2)

			context2 = NCommandContext.CreateContext("New Blank Solution...", CInt(Fix(NIDELoadUC.CommandID.NewBlankSolution)), NIDELoadUC.StandardImageList, 1, CInt(Fix(NIDELoadUC.RangeID.Standard)), Nothing, False)
			context1.Contexts.Add(context2)
			m_CommandBarsManager.Contexts.Add(context2)

			'add new item context
			context1 = NCommandContext.CreateContext("Add Ne&w Item...", -1, NIDELoadUC.StandardImageList, 2, CInt(Fix(NIDELoadUC.RangeID.Standard)), New NShortcut(Keys.A, Keys.Control Or Keys.Shift), False)
			m_CommandBarsManager.Contexts.Add(context1)

			context2 = NCommandContext.CreateContext("Add Ne&w Item...", CInt(Fix(NIDELoadUC.CommandID.AddNewItem)), NIDELoadUC.StandardImageList, 2, CInt(Fix(NIDELoadUC.RangeID.Standard)), New NShortcut(Keys.A, Keys.Control Or Keys.Shift), False)
			context1.Contexts.Add(context2)
			m_CommandBarsManager.Contexts.Add(context2)

			context2 = NCommandContext.CreateContext("Add Existin&g Item...", CInt(Fix(NIDELoadUC.CommandID.AddExistingItem)), NIDELoadUC.StandardImageList, 3, CInt(Fix(NIDELoadUC.RangeID.Standard)), New NShortcut(Keys.A, Keys.Alt Or Keys.Shift), False)
			context1.Contexts.Add(context2)
			m_CommandBarsManager.Contexts.Add(context2)

			context2 = NCommandContext.CreateContext("Add Windows &Form", CInt(Fix(NIDELoadUC.CommandID.AddWindowsForm)), NIDELoadUC.StandardImageList, 4, CInt(Fix(NIDELoadUC.RangeID.Standard)), Nothing, True)
			context1.Contexts.Add(context2)
			m_CommandBarsManager.Contexts.Add(context2)

			context2 = NCommandContext.CreateContext("Add &Inherited Form", CInt(Fix(NIDELoadUC.CommandID.AddInheritedForm)), NIDELoadUC.StandardImageList, 4, CInt(Fix(NIDELoadUC.RangeID.Standard)), Nothing, False)
			context1.Contexts.Add(context2)
			m_CommandBarsManager.Contexts.Add(context2)

			context2 = NCommandContext.CreateContext("Add &User Control", CInt(Fix(NIDELoadUC.CommandID.AddUsercontrol)), NIDELoadUC.StandardImageList, 5, CInt(Fix(NIDELoadUC.RangeID.Standard)), Nothing, False)
			context1.Contexts.Add(context2)
			m_CommandBarsManager.Contexts.Add(context2)

			context2 = NCommandContext.CreateContext("Add Inherited Con&trol", CInt(Fix(NIDELoadUC.CommandID.AddInheritedControl)), NIDELoadUC.StandardImageList, 5, CInt(Fix(NIDELoadUC.RangeID.Standard)), Nothing, False)
			context1.Contexts.Add(context2)
			m_CommandBarsManager.Contexts.Add(context2)

			context2 = NCommandContext.CreateContext("Add Compo&nent", CInt(Fix(NIDELoadUC.CommandID.AddComponent)), NIDELoadUC.StandardImageList, 6, CInt(Fix(NIDELoadUC.RangeID.Standard)), Nothing, False)
			context1.Contexts.Add(context2)
			m_CommandBarsManager.Contexts.Add(context2)

			context2 = NCommandContext.CreateContext("Add &Class...", CInt(Fix(NIDELoadUC.CommandID.AddClass)), NIDELoadUC.StandardImageList, 7, CInt(Fix(NIDELoadUC.RangeID.Standard)), Nothing, False)
			context1.Contexts.Add(context2)
			m_CommandBarsManager.Contexts.Add(context2)

			'open context
			context1 = NCommandContext.CreateContext("&Open...", CInt(Fix(NIDELoadUC.CommandID.Open)), NIDELoadUC.StandardImageList, 8, CInt(Fix(NIDELoadUC.RangeID.Standard)), New NShortcut(Keys.O, Keys.Control), True)
			m_CommandBarsManager.Contexts.Add(context1)

			'save context
			context1 = NCommandContext.CreateContext("Sa&ve", CInt(Fix(NIDELoadUC.CommandID.Save)), NIDELoadUC.StandardImageList, 9, CInt(Fix(NIDELoadUC.RangeID.Standard)), New NShortcut(Keys.S, Keys.Control), False)
			m_CommandBarsManager.Contexts.Add(context1)

			'save all context
			context1 = NCommandContext.CreateContext("Save A&ll", CInt(Fix(NIDELoadUC.CommandID.SaveAll)), NIDELoadUC.StandardImageList, 10, CInt(Fix(NIDELoadUC.RangeID.Standard)), New NShortcut(Keys.S, Keys.Control Or Keys.Shift), False)
			m_CommandBarsManager.Contexts.Add(context1)

			'cut context
			context1 = NCommandContext.CreateContext("Cu&t", CInt(Fix(NIDELoadUC.CommandID.Cut)), NIDELoadUC.StandardImageList, 11, CInt(Fix(NIDELoadUC.RangeID.Standard)), New NShortcut(Keys.X, Keys.Control), True)
			m_CommandBarsManager.Contexts.Add(context1)

			'copy context
			context1 = NCommandContext.CreateContext("&Copy", CInt(Fix(NIDELoadUC.CommandID.Copy)), NIDELoadUC.StandardImageList, 12, CInt(Fix(NIDELoadUC.RangeID.Standard)), New NShortcut(Keys.C, Keys.Control), False)
			m_CommandBarsManager.Contexts.Add(context1)

			'paste context
			context1 = NCommandContext.CreateContext("&Paste", CInt(Fix(NIDELoadUC.CommandID.Paste)), NIDELoadUC.StandardImageList, 13, CInt(Fix(NIDELoadUC.RangeID.Standard)), New NShortcut(Keys.V, Keys.Control), False)
			m_CommandBarsManager.Contexts.Add(context1)

			'undo context
			context1 = New NUndoRedoCommandContext()
			context1.Properties.ImageIndex = 14
			context1.Properties.ID = CInt(Fix(NIDELoadUC.CommandID.Undo))
			context1.Properties.Text = "&Undo"
			context1.Properties.ImageList = NIDELoadUC.StandardImageList
			context1.Properties.Shortcut = New NShortcut(Keys.Z, Keys.Control)
			context1.Properties.BeginGroup = True
			context1.RangeID = CInt(Fix(NIDELoadUC.RangeID.Standard))
			m_CommandBarsManager.Contexts.Add(context1)

			'redo context
			context1 = New NUndoRedoCommandContext()
			context1.Properties.ImageIndex = 15
			context1.Properties.Text = "&Redo"
			context1.Properties.ID = CInt(Fix(NIDELoadUC.CommandID.Redo))
			context1.Properties.ImageList = NIDELoadUC.StandardImageList
			context1.Properties.Shortcut = New NShortcut(Keys.Y, Keys.Control)
			context1.RangeID = CInt(Fix(NIDELoadUC.RangeID.Standard))
			m_CommandBarsManager.Contexts.Add(context1)

			'navigate backward context
			context1 = NCommandContext.CreateContext("N&avigate Backward", CInt(Fix(NIDELoadUC.CommandID.NavigateBackward)), NIDELoadUC.StandardImageList, 16, CInt(Fix(NIDELoadUC.RangeID.Standard)), New NShortcut(Keys.OemMinus, Keys.Control), False)
			m_CommandBarsManager.Contexts.Add(context1)

			'navigate forward context
			context1 = NCommandContext.CreateContext("Navigate &Forward", CInt(Fix(NIDELoadUC.CommandID.NavigateForward)), NIDELoadUC.StandardImageList, 17, CInt(Fix(NIDELoadUC.RangeID.Standard)), New NShortcut(Keys.OemMinus, Keys.Control Or Keys.Shift), False)
			m_CommandBarsManager.Contexts.Add(context1)

			'start debug context
			context1 = NCommandContext.CreateContext("Start / Continue", CInt(Fix(NIDELoadUC.CommandID.StartContinue)), NIDELoadUC.StandardImageList, 18, CInt(Fix(NIDELoadUC.RangeID.Standard)), Nothing, True)
			m_CommandBarsManager.Contexts.Add(context1)

			'solution configuration context
			Dim context3 As NComboBoxCommandContext = New NComboBoxCommandContext()
			context3.Properties.ID = CInt(Fix(NIDELoadUC.CommandID.SolutionConfigurations))
			context3.ListProperties.ColumnOnLeft = False
			context3.ListProperties.ItemHeight = 15
			context3.ComboBox.DropDownWidth = 160
			context3.Properties.Text = "Solution Configurations"
			context3.RangeID = CInt(Fix(NIDELoadUC.RangeID.Standard))

			context3.Items.Add("Debug")
			context3.Items.Add("Release")
			context3.Items.Add("Configuration Manager...")
			context3.ComboBox.SelectedIndex = 0
			m_CommandBarsManager.Contexts.Add(context3)

			'solution explorer context
			context1 = NCommandContext.CreateContext("Solution &Explorer", CInt(Fix(NIDELoadUC.CommandID.SolutionExplorer)), NIDELoadUC.StandardImageList, 19, CInt(Fix(NIDELoadUC.RangeID.Standard)), New NShortcut(Keys.L, Keys.Control Or Keys.Alt), True)
			m_CommandBarsManager.Contexts.Add(context1)

			'properties window context
			context1 = NCommandContext.CreateContext("Properties &Window", CInt(Fix(NIDELoadUC.CommandID.Properties)), NIDELoadUC.StandardImageList, 20, CInt(Fix(NIDELoadUC.RangeID.Standard)), Nothing, False)
			m_CommandBarsManager.Contexts.Add(context1)

			'object browser context
			context1 = NCommandContext.CreateContext("Ob&ject Browser", CInt(Fix(NIDELoadUC.CommandID.ObjectBrowser)), NIDELoadUC.StandardImageList, 21, CInt(Fix(NIDELoadUC.RangeID.Standard)), New NShortcut(Keys.J, Keys.Control Or Keys.Alt), False)
			m_CommandBarsManager.Contexts.Add(context1)

			'toolbox context
			context1 = NCommandContext.CreateContext("Toolbo&x", CInt(Fix(NIDELoadUC.CommandID.Toolbox)), NIDELoadUC.StandardImageList, 22, CInt(Fix(NIDELoadUC.RangeID.Standard)), New NShortcut(Keys.X, Keys.Control Or Keys.Alt), False)
			m_CommandBarsManager.Contexts.Add(context1)

			'class view context
			context1 = NCommandContext.CreateContext("Cl&ass View", -1, NIDELoadUC.StandardImageList, 23, CInt(Fix(NIDELoadUC.RangeID.Standard)), New NShortcut(Keys.C, Keys.Control Or Keys.Shift), False)
			m_CommandBarsManager.Contexts.Add(context1)

			context2 = NCommandContext.CreateContext("Cl&ass View", CInt(Fix(NIDELoadUC.CommandID.ClassView)), NIDELoadUC.StandardImageList, 23, CInt(Fix(NIDELoadUC.RangeID.Standard)), New NShortcut(Keys.C, Keys.Control Or Keys.Shift), False)
			context1.Contexts.Add(context2)
			m_CommandBarsManager.Contexts.Add(context2)

			context2 = NCommandContext.CreateContext("Ser&ver Explorer", CInt(Fix(NIDELoadUC.CommandID.ServerExplorer)), NIDELoadUC.StandardImageList, 24, CInt(Fix(NIDELoadUC.RangeID.Standard)), New NShortcut(Keys.S, Keys.Control Or Keys.Alt), False)
			context1.Contexts.Add(context2)
			m_CommandBarsManager.Contexts.Add(context2)

			context2 = NCommandContext.CreateContext("&Resource View", CInt(Fix(NIDELoadUC.CommandID.ResourceView)), NIDELoadUC.StandardImageList, 25, CInt(Fix(NIDELoadUC.RangeID.Standard)), New NShortcut(Keys.E, Keys.Control Or Keys.Shift), False)
			context1.Contexts.Add(context2)
			m_CommandBarsManager.Contexts.Add(context2)

			context2 = NCommandContext.CreateContext("&Task List", CInt(Fix(NIDELoadUC.CommandID.TaskList)), NIDELoadUC.StandardImageList, 26, CInt(Fix(NIDELoadUC.RangeID.Standard)), New NShortcut(Keys.K, Keys.Control Or Keys.Alt), False)
			context1.Contexts.Add(context2)
			m_CommandBarsManager.Contexts.Add(context2)

			context2 = NCommandContext.CreateContext("Comma&nd Window", CInt(Fix(NIDELoadUC.CommandID.CommandWindow)), NIDELoadUC.StandardImageList, 27, CInt(Fix(NIDELoadUC.RangeID.Standard)), New NShortcut(Keys.A, Keys.Control Or Keys.Alt), False)
			context1.Contexts.Add(context2)
			m_CommandBarsManager.Contexts.Add(context2)

			context2 = NCommandContext.CreateContext("&Output", CInt(Fix(NIDELoadUC.CommandID.Output)), NIDELoadUC.StandardImageList, 28, CInt(Fix(NIDELoadUC.RangeID.Standard)), New NShortcut(Keys.O, Keys.Control Or Keys.Alt), False)
			context1.Contexts.Add(context2)
			m_CommandBarsManager.Contexts.Add(context2)

			context2 = NCommandContext.CreateContext("Find S&ymbol Results", CInt(Fix(NIDELoadUC.CommandID.FindSymbolResults)), NIDELoadUC.StandardImageList, 29, CInt(Fix(NIDELoadUC.RangeID.Standard)), New NShortcut(Keys.F12, Keys.Control Or Keys.Alt), False)
			context1.Contexts.Add(context2)
			m_CommandBarsManager.Contexts.Add(context2)
		End Sub

		Friend Sub InitMenuContexts()
			Dim context1, context2, context3 As NCommandContext

			'file 
			context1 = NCommandContext.CreateContext("&File", -1, Nothing, -1, CInt(Fix(NIDELoadUC.RangeID.MenuBar)), Nothing, False)
			m_CommandBarsManager.Contexts.Add(context1)

			context2 = NCommandContext.CreateContext("&New", -1, Nothing, -1, CInt(Fix(NIDELoadUC.RangeID.MenuBar)), Nothing, False)
			context2.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.NewProject))))
			context2.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.NewBlankSolution))))

			context1.Contexts.Add(context2)
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.AddNewItem))))
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.AddExistingItem))))

			context3 = m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.Open)))
			context1.Contexts.Add(CType(context3.Clone(), NCommandContext))
			context3 = m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.Save)))
			context1.Contexts.Add(CType(context3.Clone(), NCommandContext))
			context3 = m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.SaveAll)))
			context1.Contexts.Add(CType(context3.Clone(), NCommandContext))

			'file->exit context
			context2 = NCommandContext.CreateContext("E&xit", CInt(Fix(NIDELoadUC.CommandID.Exit)), Nothing, -1, CInt(Fix(NIDELoadUC.RangeID.MenuBar)), Nothing, True)
			m_CommandBarsManager.Contexts.Add(context2)
			context1.Contexts.Add(context2)

			'edit context
			context1 = NCommandContext.CreateContext("&Edit", -1, Nothing, -1, CInt(Fix(NIDELoadUC.RangeID.MenuBar)), Nothing, False)
			m_CommandBarsManager.Contexts.Add(context1)

			context3 = m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.Undo)))
			context1.Contexts.Add(CType(context3.Clone(), NCommandContext))
			context3 = m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.Redo)))
			context1.Contexts.Add(CType(context3.Clone(), NCommandContext))

			context3 = m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.Cut)))
			context1.Contexts.Add(CType(context3.Clone(), NCommandContext))
			context3 = m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.Copy)))
			context1.Contexts.Add(CType(context3.Clone(), NCommandContext))
			context3 = m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.Paste)))
			context1.Contexts.Add(CType(context3.Clone(), NCommandContext))

			'edit->selectall context
			context2 = NCommandContext.CreateContext("Select &All", CInt(Fix(NIDELoadUC.CommandID.SelectAll)), Nothing, -1, CInt(Fix(NIDELoadUC.RangeID.MenuBar)), Nothing, True)
			m_CommandBarsManager.Contexts.Add(context2)
			context1.Contexts.Add(context2)

			'view context
			context1 = NCommandContext.CreateContext("&View", -1, Nothing, -1, CInt(Fix(NIDELoadUC.RangeID.MenuBar)), Nothing, False)
			m_CommandBarsManager.Contexts.Add(context1)

			context3 = m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.SolutionExplorer)))
			context1.Contexts.Add(CType(context3.Clone(), NCommandContext))
			context3 = m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.Properties)))
			context1.Contexts.Add(CType(context3.Clone(), NCommandContext))
			context3 = m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.ObjectBrowser)))
			context1.Contexts.Add(CType(context3.Clone(), NCommandContext))
			context3 = m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.Toolbox)))
			context1.Contexts.Add(CType(context3.Clone(), NCommandContext))
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.ClassView))))
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.ServerExplorer))))
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.ResourceView))))
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.TaskList))))
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.CommandWindow))))
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.Output))))
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.FindSymbolResults))))

			'project context
			context1 = NCommandContext.CreateContext("&Project", -1, Nothing, -1, CInt(Fix(NIDELoadUC.RangeID.MenuBar)), Nothing, False)
			m_CommandBarsManager.Contexts.Add(context1)

			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.AddNewItem))))
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.AddExistingItem))))
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.AddWindowsForm))))
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.AddInheritedForm))))
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.AddUsercontrol))))
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.AddInheritedControl))))
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.AddComponent))))
			context1.Contexts.Add(m_CommandBarsManager.Contexts.ContextFromID(CInt(Fix(NIDELoadUC.CommandID.AddClass))))
		End Sub


		#End Region

		#Region "Command Bars"

		Friend Sub InitMainMenu()
			Dim menu As NMenuBar = New NMenuBar()
			menu.Text = "Menu Bar"
			menu.AllowRename = False
			menu.AllowHide = False
			menu.DefaultRangeID = CInt(Fix(NIDELoadUC.RangeID.MenuBar))

			m_CommandBarsManager.Toolbars.Add(menu)
			menu.Reset(False)
		End Sub

		Friend Sub InitStandardCommandBar()
			Dim tb As NDockingToolbar = New NDockingToolbar(m_CommandBarsManager)
			tb.DefaultRangeID = CInt(Fix(NIDELoadUC.RangeID.Standard))
			tb.Text = "Standard"

			m_CommandBarsManager.Toolbars.Add(tb)
			tb.Reset(False)
		End Sub


		#End Region

		#End Region

		#Region "Docking Panels Initialization"

		Friend Sub LoadDockingFramework()
			InitDockManager()
			LoadPanels()
		End Sub
		Friend Sub InitDockManager()
			m_DockManager = New NDockManager()
			m_DockManager.Palette.Copy(NUIManager.Palette)
			m_DockManager.DocumentStyle.ImageList = NIDELoadUC.SolutionExplorerImageList
			m_DockManager.Form = Me
			m_DockManager.ImageList = NIDELoadUC.StandardImageList
			AddHandler m_DockManager.Palette.PaletteChanged, AddressOf Palette_PaletteChanged
		End Sub
		Friend Sub LoadPanels()
			Dim panel As NDockingPanel

			Dim target As INDockZone
			Dim root As INDockZone = m_DockManager.RootContainer.RootZone
			Dim docHost As INDockZone = m_DockManager.DocumentManager.DocumentViewHost

			panel = New NDockingPanel()
			panel.Text = "Solution Explorer"
			panel.Controls.Add(m_SolutionExplorer)
			panel.TabInfo.ImageIndex = 19
			panel.PerformDock(root, DockStyle.Left)

			'output window
			panel = New NDockingPanel()
			panel.Text = "Output"
			'panel.Controls.Add(GetOutputWindow());
			panel.TabInfo.ImageIndex = 28
			panel.PerformDock(docHost, DockStyle.Bottom)
			target = panel.ParentZone

			'task list
			panel = New NDockingPanel()
			panel.Text = "Task List"
			panel.Controls.Add(GetTaskList())
			panel.TabInfo.ImageIndex = 26
			panel.PerformDock(target, DockStyle.Fill)

			'toolbox
			panel = New NDockingPanel()
			panel.Text = "Toolbox"
			panel.Controls.Add(GetToolbox())
			panel.TabInfo.ImageIndex = 22
			panel.PerformDock(root, DockStyle.Right)
			target = panel.ParentZone

			panel = New NDockingPanel()
			panel.Text = "Properties"
			panel.Controls.Add(GetProperties())
			panel.TabInfo.ImageIndex = 20
			panel.PerformDock(target, DockStyle.Fill)
		End Sub


		Friend Function GetToolbox() As NPanelBar
			Dim bar As NPanelBar = New NPanelBar()
			bar.Border.Style = BorderStyle3D.None
			bar.Dock = DockStyle.Fill

			Dim band As NBand

			band = New NBand()
			band.Caption = "Data"
			bar.Bands.Add(band)

			band = New NBand()
			band.Caption = "Components"
			bar.Bands.Add(band)

			band = New NBand()
			band.Caption = "Windows Forms"
			bar.Bands.Add(band)

			Return bar
		End Function

		Friend Function GetProperties() As PropertyGrid
			Dim grid As PropertyGrid = New PropertyGrid()
			grid.Dock = DockStyle.Fill
			grid.ToolbarVisible = False
			grid.SelectedObject = m_DockManager

			Return grid
		End Function
		Friend Function GetOutputWindow() As RichTextBox
			Dim tb As NRichTextBox = New NRichTextBox()
			tb.Dock = DockStyle.Fill
			tb.Multiline = True
			tb.WordWrap = False
			tb.ScrollBars = RichTextBoxScrollBars.Both

			Return tb
		End Function
		Friend Function GetTaskList() As ListView
			Dim lv As ListView = New ListView()
			lv.View = View.Details
			lv.GridLines = True
			lv.FullRowSelect = True
			lv.Dock = DockStyle.Fill

			lv.Columns.Add("!", 20, HorizontalAlignment.Center)
			lv.Columns.Add("", 20, HorizontalAlignment.Center)
			lv.Columns.Add("", 20, HorizontalAlignment.Center)
			lv.Columns.Add("Description", 100, HorizontalAlignment.Left)

			Return lv
		End Function


		#End Region

		#Region "Event Handlers"

		Private Sub m_SolutionExplorer_BeforeExpand(ByVal sender As Object, ByVal e As TreeViewCancelEventArgs)
			Dim imageIndex As Integer = e.Node.ImageIndex
			Dim newIndex As Integer = -1

			Select Case imageIndex
				Case 0
					newIndex = 1
				Case 2
					newIndex = 3
			End Select

			If newIndex = -1 Then
				Return
			End If

			e.Node.ImageIndex = newIndex
			e.Node.SelectedImageIndex = newIndex
		End Sub
		Private Sub m_SolutionExplorer_BeforeCollapse(ByVal sender As Object, ByVal e As TreeViewCancelEventArgs)
			Dim imageIndex As Integer = e.Node.ImageIndex
			Dim newIndex As Integer = -1

			Select Case imageIndex
				Case 1
					newIndex = 0
				Case 3
					newIndex = 2
			End Select

			If newIndex = -1 Then
				Return
			End If

			e.Node.ImageIndex = newIndex
			e.Node.SelectedImageIndex = newIndex
		End Sub

		Private Sub m_SolutionExplorer_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
			Dim selected As TreeNode = m_SolutionExplorer.SelectedNode
			If selected Is Nothing Then
				Return
			End If

			Dim pt As Point = m_SolutionExplorer.PointToClient(Control.MousePosition)
			If (Not selected.Bounds.Contains(pt)) Then
				Return
			End If

			Dim fi As FileInfo = TryCast(selected.Tag, FileInfo)
			If fi Is Nothing OrElse fi.Extension.ToLower() <> ".cs" Then
				Return
			End If

			AddDocument(fi, selected)
		End Sub


		Private Sub Palette_PaletteChanged(ByVal Palette As NPalette, ByVal e As PaletteChangeEventArgs)
			m_CommandBarsManager.BeginUpdate()

			Dim fade As Boolean = Palette.Scheme = ColorScheme.Standard
			SetFadeImageAndImageShadow(m_CommandBarsManager.CommandManager.GetAllCommands(False), fade, fade)

			NUIManager.ApplyPalette(Me, Palette)
			m_CommandBarsManager.Palette.Copy(Palette)

			m_CommandBarsManager.EndUpdate(True)
		End Sub


		#End Region

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.m_SolutionExplorer = New Nevron.UI.WinForm.Controls.NTreeView()
			Me.nStatusBar1 = New Nevron.UI.WinForm.Controls.NStatusBar()
			Me.nStatusBarPanel1 = New Nevron.UI.WinForm.Controls.NStatusBarPanel()
			Me.nStatusBarPanel2 = New Nevron.UI.WinForm.Controls.NStatusBarPanel()
			Me.nStatusBarPanel3 = New Nevron.UI.WinForm.Controls.NStatusBarPanel()
			Me.nStatusBarPanel4 = New Nevron.UI.WinForm.Controls.NStatusBarPanel()
			CType(Me.nStatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nStatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nStatusBarPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nStatusBarPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' m_SolutionExplorer
			' 
			Me.m_SolutionExplorer.Border.Style = Nevron.UI.BorderStyle3D.None
			Me.m_SolutionExplorer.BorderStyle = System.Windows.Forms.BorderStyle.None
			Me.m_SolutionExplorer.ImageIndex = -1
			Me.m_SolutionExplorer.Location = New System.Drawing.Point(8, 176)
			Me.m_SolutionExplorer.Name = "m_SolutionExplorer"
			Me.m_SolutionExplorer.SelectedImageIndex = -1
			Me.m_SolutionExplorer.Size = New System.Drawing.Size(200, 192)
			Me.m_SolutionExplorer.TabIndex = 1
			' 
			' nStatusBar1
			' 
			Me.nStatusBar1.Location = New System.Drawing.Point(0, 507)
			Me.nStatusBar1.Name = "nStatusBar1"
			Me.nStatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() { Me.nStatusBarPanel1, Me.nStatusBarPanel2, Me.nStatusBarPanel3, Me.nStatusBarPanel4})
			Me.nStatusBar1.Separators = True
			Me.nStatusBar1.ShowPanels = True
			Me.nStatusBar1.Size = New System.Drawing.Size(810, 20)
			Me.nStatusBar1.TabIndex = 2
			Me.nStatusBar1.Text = "nStatusBar1"
			' 
			' nStatusBarPanel1
			' 
			Me.nStatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
			Me.nStatusBarPanel1.Text = "Ready"
			Me.nStatusBarPanel1.Width = 688
			' 
			' nStatusBarPanel2
			' 
			Me.nStatusBarPanel2.Text = "INS"
			Me.nStatusBarPanel2.Width = 30
			' 
			' nStatusBarPanel3
			' 
			Me.nStatusBarPanel3.Text = "CAPS"
			Me.nStatusBarPanel3.Width = 39
			' 
			' nStatusBarPanel4
			' 
			Me.nStatusBarPanel4.Text = "NUM"
			Me.nStatusBarPanel4.Width = 37
			' 
			' NVisualStudioIDE
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(810, 527)
			Me.Controls.Add(Me.nStatusBar1)
			Me.Controls.Add(Me.m_SolutionExplorer)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
			Me.Name = "NVisualStudioIDE"
			Me.Text = "Nevron User Interface - Sample Visual Studio IDE"
			CType(Me.nStatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nStatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nStatusBarPanel3, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nStatusBarPanel4, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		Friend m_CommandBarsManager As NCommandBarsManager
		Friend m_DockManager As NDockManager
		Friend m_Loader As NIDELoadUC

		Private m_SolutionExplorer As NTreeView
		Private nStatusBar1 As Nevron.UI.WinForm.Controls.NStatusBar
		Private nStatusBarPanel1 As Nevron.UI.WinForm.Controls.NStatusBarPanel
		Private nStatusBarPanel2 As Nevron.UI.WinForm.Controls.NStatusBarPanel
		Private nStatusBarPanel3 As Nevron.UI.WinForm.Controls.NStatusBarPanel
		Private nStatusBarPanel4 As Nevron.UI.WinForm.Controls.NStatusBarPanel

		#End Region
	End Class
End Namespace
