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
	''' Summary description for NCommandBarsUC.
	''' </summary>
	Public Class NCommandBarsUC
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
			' NCommandBarsUC
			' 
			Me.Name = "NCommandBarsUC"
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
					Form.CommandBarsManager.ToolbarsBuilder = originalDiagramToolbarsBuilder
					Form.CommandBarsManager.Recreate()
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
			If originalDiagramToolbarsBuilder Is Nothing Then
				originalDiagramToolbarsBuilder = Form.CommandBarsManager.ToolbarsBuilder
			End If

			' create the custom buttom command if not already craated
			If customDiagramButtonCommand Is Nothing Then
				customDiagramButtonCommand = New NCustomDiagramButtonCommand()
				Form.CommandBarsManager.Commander.Commands.Add(customDiagramButtonCommand)
			End If

			NControlHelper.BeginUpdate(Form.CommandBarsManager.ParentControl)

			' replace the toolbar builder with a custom one
			Form.CommandBarsManager.ToolbarsBuilder = New NCustomDiagramToolbarsBuilder()

			' recreate the command bars. Since we have replaced the toolbars builder,  
			' this will add the new command in the toolbars
			Form.CommandBarsManager.Recreate()

			NControlHelper.EndUpdate(Form.CommandBarsManager.ParentControl, True)
		End Sub

		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing

		#End Region

		#Region "Fields"

		Public customDiagramButtonCommand As NCustomDiagramButtonCommand = Nothing
		Public originalDiagramToolbarsBuilder As NDiagramToolbarsBuilder = Nothing

		#End Region
	End Class

	''' <summary>
	''' Summary description for NCustomDiagramToolbarsBuilder.
	''' </summary>
	Public Class NCustomDiagramToolbarsBuilder
		Inherits NDiagramToolbarsBuilder
		#Region "Constructor"

		Public Sub New()
		End Sub


		#End Region

		#Region "Overrides"

		Public Overrides Function BuildToolbars() As NDockingToolbar()
			Dim toolbars As ArrayList = New ArrayList(MyBase.BuildToolbars())
			Dim toolbarsNames As String() = New String() {"Custom Toolbar"}
			Dim commandArrays As ArrayList() = New ArrayList() {Me.customCommandIds}

			Dim commands As ArrayList
			Dim command As Nevron.UI.WinForm.Controls.NCommand
			Dim beginGroupCommandIds As ArrayList = New ArrayList(Me.BeginGroupCommandIds)

			Dim i As Integer = 0
			Do While i < commandArrays.Length
				Dim toolbar As NDockingToolbar = New NDockingToolbar()
				toolbar.Text = toolbarsNames(i)
				toolbars.Add(toolbar)

				commands = commandArrays(i)
				Dim j As Integer = 0
				Do While j < commands.Count
					Dim commandId As Integer = CInt(Fix(commands(j)))
					command = CreateCommand(commandId, beginGroupCommandIds.Contains(commandId))

					If Not command Is Nothing Then
						toolbar.Commands.Add(command)
					End If
					j += 1
				Loop
				i += 1
			Loop

			Return CType(toolbars.ToArray(GetType(NDockingToolbar)), NDockingToolbar())
		End Function

		Public Overrides Sub Reset()
			MyBase.Reset()

			customCommandIds = New ArrayList()
			customCommandIds.Add(CInt(Fix(DiagramCommand.LastCommandId)) + 1)
		End Sub

		#End Region

		#Region "Fields"

		Private customCommandIds As ArrayList

		#End Region
	End Class
	''' <summary>
	''' Summary description for NCustomDiagramButtonCommand.
	''' </summary>
	Public Class NCustomDiagramButtonCommand
		Inherits NDiagramButtonCommand
		#Region "Constructors"

		Shared Sub New()
			Dim thisType As Type = GetType(NCustomDiagramButtonCommand)
			ImageListCustom = New NCustomImageList(NResourceHelper.BitmapFromResource(thisType, "CustomCommandbarImageList.png", "Nevron.Examples.Diagram.WinForm.Resources"), New NSize(16, 16))
		End Sub

		Public Sub New()
			MyBase.New(CInt(Fix(DiagramCommandRange.Misc)), CInt(Fix(DiagramCommand.LastCommandId)) + 1, "Custom command", "Custom button command in a custom toolbar.")
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
