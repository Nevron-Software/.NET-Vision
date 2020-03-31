Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.UI.WinForm.Docking

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NComplexLayoutForm.
	''' </summary>
	Public Class NBorderSupportForm
		Inherits NDockingPanelsExampleForm
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()

			Size = New Size(800, 600)
			m_PropertyGrid.SelectedObject = m_DockManager.DocumentStyle
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

		Protected Overrides Sub InitCommandBars()
			MyBase.InitCommandBars ()

			Dim tb As NDockingToolbar = New NDockingToolbar()
			tb.DefaultCommandStyle = CommandStyle.Text

			Dim comm As NCommand = New NCommand()
			comm.Properties.Text = "Border..."
			comm.Properties.ID = 0
			tb.Commands.Add(comm)

			nCommandBarsManager1.Toolbars.Add(tb)
		End Sub

		Protected Overrides Sub InitPanels()
			Dim panel, panel1 As NDockingPanel

			panel1 = New NDockingPanel()
			panel1.PerformDock(m_DockManager.RootContainer.RootZone, DockStyle.Left)

			'NCaptionButton btn = new NCaptionButton();
'btn.Text = ">";
'panel1.Caption.Buttons.Add(btn);
'panel1.CaptionButtonClicked += new CaptionEventHandler(panel1_CaptionButtonClicked);

			panel = New NDockingPanel()
			panel.PerformDock(panel1.ParentZone, DockStyle.Bottom)
		End Sub

		Protected Overrides Sub nCommandBarsManager1_CommandClicked(ByVal sender As Object, ByVal e As CommandEventArgs)
			Dim comm As NCommand = e.Command
			If comm.Properties.ID <> 0 Then
				Return
			End If

			Dim panel As NDockingPanel = CType(m_DockManager.Panels(0), NDockingPanel)

			Dim border As NControlBorder = New NControlBorder()
			border.Copy(panel.Border)

			If border.ShowEditor() <> System.Windows.Forms.DialogResult.OK Then
				Return
			End If

			For Each panel1 As NDockingPanel In m_DockManager.Panels
				panel1.Border.Copy(border)
			Next panel1
		End Sub



		#End Region

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.Text = "Auto Hide Support Example"
		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		#End Region

		Private Sub panel1_CaptionButtonClicked(ByVal sender As Object, ByVal e As CaptionEventArgs)
			MessageBox.Show("My caption button...")
		End Sub
	End Class
End Namespace
