Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI
Imports Nevron.GraphicsCore
Imports Nevron.UI.WinForm
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Diagram
Imports Nevron.Diagram.Templates
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.WinForm
Imports Nevron.Diagram.WinForm.Commands

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NContextMenusUC.
	''' </summary>
	Public Class NContextMenusUC
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
			Me.SuspendLayout()
			' 
			' commonControlsPanel
			' 
			Me.commonControlsPanel.Location = New System.Drawing.Point(0, 424)
			Me.commonControlsPanel.Name = "commonControlsPanel"
			Me.commonControlsPanel.Size = New System.Drawing.Size(248, 80)
			' 
			' NContextMenusUC
			' 
			Me.Name = "NContextMenusUC"
			Me.Size = New System.Drawing.Size(248, 504)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Component Overrides"

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				Try
					NControlHelper.BeginUpdate(Form.CommandBarsManager.ParentControl)

					Form.CommandBarsManager.Commander.Commands.Remove(customDiagramButtonCommand)
					Form.CommandBarsManager.ContextMenuBuilder = originalDiagramContextMenuBuilder

					NControlHelper.EndUpdate(Form.CommandBarsManager.ParentControl, True)
				Catch ex As Exception
					Debug.WriteLine(ex.Message)
				End Try

				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub


		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' store a reference to the original toolbar builder
			If originalDiagramContextMenuBuilder Is Nothing Then
				originalDiagramContextMenuBuilder = Form.CommandBarsManager.ContextMenuBuilder
			End If

			' create the custom buttom command if not already craated
			If customDiagramButtonCommand Is Nothing Then
				customDiagramButtonCommand = New NCustomContextMenuDiagramButtonCommand()
				Form.CommandBarsManager.Commander.Commands.Add(customDiagramButtonCommand)
			End If

			NControlHelper.BeginUpdate(Form.CommandBarsManager.ParentControl)

			' replace the context menu builder with a custom one
			Form.CommandBarsManager.ContextMenuBuilder = New NCustomDiagramContextMenuBuilder()

			' recreate the command bars. This is needed because custom commands 
			' need to be exported to Nevron UI command contexts also
			Form.CommandBarsManager.Recreate()

			NControlHelper.EndUpdate(Form.CommandBarsManager.ParentControl, True)
		End Sub


		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing

		#End Region

		#Region "Fields"

		Public customDiagramButtonCommand As NCustomContextMenuDiagramButtonCommand = Nothing
		Public originalDiagramContextMenuBuilder As NDiagramContextMenuBuilder = Nothing

		#End Region
	End Class

	''' <summary>
	''' Summary description for NCustomDiagramContextMenuBuilder.
	''' </summary>
	Public Class NCustomDiagramContextMenuBuilder
		Inherits NDiagramContextMenuBuilder
		#Region "Constructor"

		Public Sub New()
		End Sub


		#End Region

		#Region "Overrides"

		Public Overrides Function BuildContextMenu(ByVal obj As Object) As NContextMenu
			Dim menu As NContextMenu = MyBase.BuildContextMenu(obj)
			menu.Commands.Add(CreateCommand(CInt(Fix(DiagramCommand.LastCommandId)) + 1, True))
			Return menu
		End Function


		#End Region

		#Region "Fields"

		Private customCommandIds As ArrayList = Nothing

		#End Region
	End Class

	''' <summary>
	''' Summary description for NCustomContextMenuDiagramButtonCommand.
	''' </summary>
	Public Class NCustomContextMenuDiagramButtonCommand
		Inherits NDiagramButtonCommand
		#Region "Constructors"

		Shared Sub New()
			Dim thisType As Type = GetType(NCustomDiagramButtonCommand)
			ImageListCustom = New NCustomImageList(NResourceHelper.BitmapFromResource(thisType, "CustomCommandbarImageList.png", "Nevron.Examples.Diagram.WinForm.Resources"), New NSize(16, 16))
		End Sub

		Public Sub New()
			MyBase.New(CInt(Fix(DiagramCommandRange.Misc)), CInt(Fix(DiagramCommand.LastCommandId)) + 1, "Custom command", "Custom button command in context menu.")
		End Sub


		#End Region

		#Region "Overrides"

		Public Overrides Sub Execute()
			MessageBox.Show("NCustomDiagramButtonCommand was executed.")
		End Sub

		Public Overrides Function GetImageInfo(<System.Runtime.InteropServices.Out()> ByRef imageList As NCustomImageList, <System.Runtime.InteropServices.Out()> ByRef imageIndex As Integer) As Boolean
			imageList = ImageListCustom
			imageIndex = 0
			Return True
		End Function


		#End Region

		#Region "Static Fields"

		Public Shared ImageListCustom As NCustomImageList = Nothing

		#End Region
	End Class
End Namespace