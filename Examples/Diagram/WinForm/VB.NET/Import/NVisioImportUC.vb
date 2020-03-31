Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Windows.Forms

Imports Nevron.Diagram
Imports Nevron.Diagram.Visio
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NVisioImportUC.
	''' </summary>
	Public Class NVisioImportUC
		Inherits NDiagramExampleUC
		#Region "Constructor"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			InitializeComponent()
		End Sub

		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.btnImport = New Nevron.UI.WinForm.Controls.NButton()
			Me.pLibrary = New System.Windows.Forms.Panel()
			Me.chkPreserveHierarchy = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.dlgOpen = New System.Windows.Forms.OpenFileDialog()
			Me.SuspendLayout()
			' 
			' btnImport
			' 
			Me.btnImport.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnImport.Location = New System.Drawing.Point(8, 475)
			Me.btnImport.Name = "btnImport"
			Me.btnImport.Size = New System.Drawing.Size(234, 23)
			Me.btnImport.TabIndex = 5
			Me.btnImport.Text = "Import Visio Stencil..."
			Me.btnImport.UseVisualStyleBackColor = True
'			Me.btnImport.Click += New System.EventHandler(Me.btnImport_Click);
			' 
			' pLibrary
			' 
			Me.pLibrary.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.pLibrary.Location = New System.Drawing.Point(8, 3)
			Me.pLibrary.Name = "pLibrary"
			Me.pLibrary.Size = New System.Drawing.Size(234, 424)
			Me.pLibrary.TabIndex = 6
			' 
			' chkPreserveHierarchy
			' 
			Me.chkPreserveHierarchy.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.chkPreserveHierarchy.AutoSize = True
			Me.chkPreserveHierarchy.ButtonProperties.BorderOffset = 2
			Me.chkPreserveHierarchy.Location = New System.Drawing.Point(8, 443)
			Me.chkPreserveHierarchy.Name = "chkPreserveHierarchy"
			Me.chkPreserveHierarchy.Size = New System.Drawing.Size(146, 17)
			Me.chkPreserveHierarchy.TabIndex = 7
			Me.chkPreserveHierarchy.Text = "Preserve shape hierarchy"
			Me.chkPreserveHierarchy.UseVisualStyleBackColor = True
			' 
			' dlgOpen
			' 
			Me.dlgOpen.Filter = "Visio XML stencil (*.vsx)|*.vsx"
			Me.dlgOpen.Title = "Select Visio XML Stencil"
			' 
			' NVisioImportUC
			' 
			Me.Controls.Add(Me.chkPreserveHierarchy)
			Me.Controls.Add(Me.pLibrary)
			Me.Controls.Add(Me.btnImport)
			Me.Name = "NVisioImportUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.btnImport, 0)
			Me.Controls.SetChildIndex(Me.pLibrary, 0)
			Me.Controls.SetChildIndex(Me.chkPreserveHierarchy, 0)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			view.Grid.Visible = False
			view.GlobalVisibility.ShowPorts = False

			' end view init
			view.EndInit()

			InitFormControls()

			' import a sample visio stencil
			Dim visioImporter As NVisioImporter = New NVisioImporter(libDocument)
			visioImporter.Import(Path.Combine(Application.StartupPath, "..\..\Resources\Data\Computers.vsx"))
		End Sub
		Private Sub InitFormControls()
			libDocument = New NLibraryDocument()

			libView = New NLibraryView()
			pLibrary.Controls.Add(libView)
			libView.Dock = DockStyle.Fill
			libView.Document = libDocument

			Dim directory As DirectoryInfo = New DirectoryInfo(Path.Combine(Application.StartupPath, "..\..\Resources\Data"))
			dlgOpen.InitialDirectory = directory.FullName
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub btnImport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnImport.Click
			If dlgOpen.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				libDocument.RemoveAllChildren()
				Dim visioImporter As NVisioImporter = New NVisioImporter(libDocument)
				visioImporter.PreserveShapeHierarchy = chkPreserveHierarchy.Checked
				visioImporter.Import(dlgOpen.FileName)
			End If
		End Sub

		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private pLibrary As System.Windows.Forms.Panel
		Private WithEvents btnImport As Nevron.UI.WinForm.Controls.NButton
		Private chkPreserveHierarchy As Nevron.UI.WinForm.Controls.NCheckBox

		#End Region

		#Region "Fields"

		Private libView As NLibraryView
		Private dlgOpen As OpenFileDialog
		Private libDocument As NLibraryDocument

		#End Region
	End Class
End Namespace