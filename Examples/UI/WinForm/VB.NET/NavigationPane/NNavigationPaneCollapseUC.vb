Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
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
	''' Summary description for NNavigationPaneCollapseUC.
	''' </summary>
	Public Class NNavigationPaneCollapseUC
		Inherits NExampleUserControl
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

		Public Overrides Sub Initialize()
			MyBase.Initialize ()

			Dock = DockStyle.Fill
			DockPadding.All = 2

			Dim bands As NNavigationPaneBand() = Me.nNavigationPane1.Bands
			Debug.WriteLine(bands.Length)
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nNavigationPane1 = New Nevron.UI.WinForm.Controls.NNavigationPane()
			Me.nNavigationPaneBand1 = New Nevron.UI.WinForm.Controls.NNavigationPaneBand()
			Me.nCalculator1 = New Nevron.UI.WinForm.Controls.NCalculator()
			Me.nNavigationPaneBand2 = New Nevron.UI.WinForm.Controls.NNavigationPaneBand()
			Me.nExplorerBar1 = New Nevron.UI.WinForm.Controls.NExplorerBar()
			Me.nExpander1 = New Nevron.UI.WinForm.Controls.NExpander()
			Me.nExpander2 = New Nevron.UI.WinForm.Controls.NExpander()
			Me.nSplitter1 = New Nevron.UI.WinForm.Controls.NSplitter()
			CType(Me.nNavigationPane1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nNavigationPane1.SuspendLayout()
			Me.nNavigationPaneBand1.SuspendLayout()
			CType(Me.nCalculator1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nNavigationPaneBand2.SuspendLayout()
			CType(Me.nExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nExplorerBar1.SuspendLayout()
			CType(Me.nExpander1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nExpander2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' nNavigationPane1
			' 
			Me.nNavigationPane1.CaptionItem.Style.TextRenderMode = Nevron.UI.TextRenderMode.Gdi
			Me.nNavigationPane1.CaptionItem.Text = "Band"
			Me.nNavigationPane1.Controls.Add(Me.nNavigationPaneBand2)
			Me.nNavigationPane1.Controls.Add(Me.nNavigationPaneBand1)
			Me.nNavigationPane1.Dock = System.Windows.Forms.DockStyle.Left
			Me.nNavigationPane1.Location = New System.Drawing.Point(0, 0)
			Me.nNavigationPane1.Name = "nNavigationPane1"
			Me.nNavigationPane1.SelectedIndex = 1
			Me.nNavigationPane1.Size = New System.Drawing.Size(288, 432)
			Me.nNavigationPane1.TabIndex = 0
			Me.nNavigationPane1.Text = "nNavigationPane1"
			' 
			' nNavigationPaneBand1
			' 
			Me.nNavigationPaneBand1.Controls.Add(Me.nCalculator1)
			Me.nNavigationPaneBand1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.nNavigationPaneBand1.DockPadding.All = 2
			Me.nNavigationPaneBand1.Location = New System.Drawing.Point(1, 26)
			Me.nNavigationPaneBand1.Name = "nNavigationPaneBand1"
			Me.nNavigationPaneBand1.Size = New System.Drawing.Size(286, 303)
			Me.nNavigationPaneBand1.TabIndex = 2
			Me.nNavigationPaneBand1.Text = "Calculator Band"
			' 
			' nCalculator1
			' 
			Me.nCalculator1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.nCalculator1.Location = New System.Drawing.Point(16, 40)
			Me.nCalculator1.Name = "nCalculator1"
			Me.nCalculator1.Size = New System.Drawing.Size(248, 216)
			Me.nCalculator1.TabIndex = 0
			Me.nCalculator1.Text = "nCalculator1"
			' 
			' nNavigationPaneBand2
			' 
			Me.nNavigationPaneBand2.Controls.Add(Me.nExplorerBar1)
			Me.nNavigationPaneBand2.Dock = System.Windows.Forms.DockStyle.Fill
			Me.nNavigationPaneBand2.DockPadding.All = 2
			Me.nNavigationPaneBand2.Location = New System.Drawing.Point(1, 26)
			Me.nNavigationPaneBand2.Name = "nNavigationPaneBand2"
			Me.nNavigationPaneBand2.Size = New System.Drawing.Size(286, 303)
			Me.nNavigationPaneBand2.TabIndex = 3
			Me.nNavigationPaneBand2.Text = "ExplorerBar Band"
			' 
			' nExplorerBar1
			' 
			Me.nExplorerBar1.ClientPadding = New Nevron.UI.NPadding(8)
			Me.nExplorerBar1.Controls.Add(Me.nExpander1)
			Me.nExplorerBar1.Controls.Add(Me.nExpander2)
			Me.nExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.nExplorerBar1.Location = New System.Drawing.Point(2, 2)
			Me.nExplorerBar1.Name = "nExplorerBar1"
			Me.nExplorerBar1.Size = New System.Drawing.Size(282, 299)
			Me.nExplorerBar1.TabIndex = 0
			Me.nExplorerBar1.Text = "nExplorerBar1"
			' 
			' nExpander1
			' 
			Me.nExpander1.BackColor = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(255)))
			Me.nExpander1.Location = New System.Drawing.Point(8, 8)
			Me.nExpander1.Name = "nExpander1"
			Me.nExpander1.Size = New System.Drawing.Size(266, 112)
			Me.nExpander1.TabIndex = 1
			Me.nExpander1.Text = "nExpander1"
			' 
			' nExpander2
			' 
			Me.nExpander2.BackColor = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(255)))
			Me.nExpander2.Location = New System.Drawing.Point(8, 128)
			Me.nExpander2.Name = "nExpander2"
			Me.nExpander2.Size = New System.Drawing.Size(266, 112)
			Me.nExpander2.TabIndex = 2
			Me.nExpander2.Text = "nExpander2"
			' 
			' nSplitter1
			' 
			Me.nSplitter1.Location = New System.Drawing.Point(288, 0)
			Me.nSplitter1.Name = "nSplitter1"
			Me.nSplitter1.Size = New System.Drawing.Size(5, 432)
			Me.nSplitter1.TabIndex = 1
			Me.nSplitter1.TabStop = False
			' 
			' NNavigationPaneCollapseUC
			' 
			Me.Controls.Add(Me.nSplitter1)
			Me.Controls.Add(Me.nNavigationPane1)
			Me.Name = "NNavigationPaneCollapseUC"
			Me.Size = New System.Drawing.Size(432, 432)
			CType(Me.nNavigationPane1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nNavigationPane1.ResumeLayout(False)
			Me.nNavigationPaneBand1.ResumeLayout(False)
			CType(Me.nCalculator1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nNavigationPaneBand2.ResumeLayout(False)
			CType(Me.nExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nExplorerBar1.ResumeLayout(False)
			CType(Me.nExpander1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nExpander2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private nNavigationPaneBand1 As Nevron.UI.WinForm.Controls.NNavigationPaneBand
		Private nNavigationPaneBand2 As Nevron.UI.WinForm.Controls.NNavigationPaneBand
		Private nCalculator1 As Nevron.UI.WinForm.Controls.NCalculator
		Private nExplorerBar1 As Nevron.UI.WinForm.Controls.NExplorerBar
		Private nExpander1 As Nevron.UI.WinForm.Controls.NExpander
		Private nExpander2 As Nevron.UI.WinForm.Controls.NExpander
		Private nSplitter1 As Nevron.UI.WinForm.Controls.NSplitter
		Private nNavigationPane1 As Nevron.UI.WinForm.Controls.NNavigationPane

		#End Region
	End Class
End Namespace
