Imports Microsoft.VisualBasic
Imports System
Imports System.Reflection
Imports System.Diagnostics
Imports System.Drawing
Imports System.Collections
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.IO

Imports Nevron.Globalization
Imports Nevron.UI
Imports Nevron.UI.WinForm
Imports Nevron.UI.WinForm.Controls
Imports Nevron.UI.WinForm.Docking
Imports Nevron.Examples.Framework.WinForm
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for MainForm.
	''' </summary>
	Public Class MainForm
		Inherits NExamplesForm
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()

			InitFromConfig(New NUIExamplesConfig())

			CaptionImage = Config.m_FormCaptionImage
			Size = New Size(800, 600)
		End Sub

		Shared Sub New()
			Dim t As Type = GetType(MainForm)
			Dim path As String = "Nevron.Examples.UI.WinForm.Resources"

			StandardImages = NResourceHelper.ImageListFromBitmap(GetType(MainForm), New Size(16, 16), Color.Silver, "Standard.bmp", path)
			ActionImages = NResourceHelper.ImageListFromBitmap(GetType(MainForm), New Size(16, 16), Color.Magenta, "Action.bmp", path)
			LayoutImages = NResourceHelper.ImageListFromBitmap(GetType(MainForm), New Size(16, 16), Color.Magenta, "Layout.bmp", path)
			ToolsImages = NResourceHelper.ImageListFromBitmap(GetType(MainForm), New Size(16, 16), Color.Magenta, "Tools.bmp", path)
			ViewImages = NResourceHelper.ImageListFromBitmap(GetType(MainForm), New Size(16, 16), Color.Magenta, "View.bmp", path)
			TestImages = NResourceHelper.ImageListFromBitmap(GetType(MainForm), New Size(16, 16), Color.Magenta, "Test.bmp", path)
			FormatImages = NResourceHelper.ImageListFromBitmap(GetType(MainForm), New Size(16, 16), Color.Magenta, "Format.bmp", path)
			MiscImages = NResourceHelper.ImageListFromBitmap(GetType(MainForm), New Size(16, 16), Color.Magenta, "Misc.bmp", path)
			DockingImages = NResourceHelper.ImageListFromBitmap(GetType(MainForm), New Size(16, 16), Color.Magenta, "Docking.bmp", path)
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

		Public Overrides Sub LoadNavigationTree()
			Dim tree As TreeView = NavigationTreeControl.NavigationTree
			tree.Nodes.Clear()

			Dim rootFolder As NExampleFolderEntity = NExamplesHelper.LoadExamplesTree(Config.EmbeddedResourcesAssembly, Config.TreeResource, Config.TreeResourcePath)
			tree.Nodes.Add(LoadTreeFolder(String.Empty, rootFolder))
		End Sub


		#End Region

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			' 
			' MainForm
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
			Me.ClientSize = New System.Drawing.Size(792, 566)
			Me.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.Name = "MainForm"
			Me.Text = "MainForm"

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		Friend Shared StandardImages As ImageList
		Friend Shared ActionImages As ImageList
		Friend Shared LayoutImages As ImageList
		Friend Shared ToolsImages As ImageList
		Friend Shared ViewImages As ImageList
		Friend Shared FormatImages As ImageList
		Friend Shared MiscImages As ImageList
		Friend Shared DockingImages As ImageList
		Friend Shared TestImages As ImageList

		#End Region

		#Region "Main"

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread> _
		Shared Sub Main()
			Application.EnableVisualStyles()
			Application.DoEvents()
			Dim form As MainForm = New MainForm()

			'try
			'{
				Application.Run(form)
			'}
			'catch
'{
'}
		End Sub

		#End Region
	End Class
End Namespace
