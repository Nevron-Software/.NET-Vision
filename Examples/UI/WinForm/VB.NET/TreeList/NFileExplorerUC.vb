Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI
Imports Nevron.UI.WinForm
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NFileExplorerUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()
		End Sub
		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()
		End Sub

		#End Region

		#Region "Overrides"

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			Dock = DockStyle.Fill

			m_FileExplorer = New NFileExplorer()
			m_FileExplorer.AutoSizeColumns = False
			m_FileExplorer.Dock = DockStyle.Fill

			m_FileExplorer.Populate()

			m_FileExplorer.Parent = Me
		End Sub

		#End Region

		#Region "Fields"

		Friend m_FileExplorer As NFileExplorer

		#End Region
	End Class
End Namespace
