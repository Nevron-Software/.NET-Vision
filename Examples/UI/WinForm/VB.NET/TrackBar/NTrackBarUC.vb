Imports Microsoft.VisualBasic
Imports System
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
	''' Summary description for NTrackBarUC.
	''' </summary>
	Public Class NTrackBarUC
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

			m_PropertyGrid.SelectedObject = nTrackBar1
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nTrackBar1 = New Nevron.UI.WinForm.Controls.NTrackBar()
			Me.m_PropertyGrid = New System.Windows.Forms.PropertyGrid()
			CType(Me.nTrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' nTrackBar1
			' 
			Me.nTrackBar1.Location = New System.Drawing.Point(8, 8)
			Me.nTrackBar1.Name = "nTrackBar1"
			Me.nTrackBar1.Size = New System.Drawing.Size(282, 39)
			Me.nTrackBar1.TabIndex = 0
			Me.nTrackBar1.Text = "nTrackBar1"
			' 
			' m_PropertyGrid
			' 
			Me.m_PropertyGrid.CommandsVisibleIfAvailable = True
			Me.m_PropertyGrid.LargeButtons = False
			Me.m_PropertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar
			Me.m_PropertyGrid.Location = New System.Drawing.Point(312, 0)
			Me.m_PropertyGrid.Name = "m_PropertyGrid"
			Me.m_PropertyGrid.Size = New System.Drawing.Size(248, 312)
			Me.m_PropertyGrid.TabIndex = 1
			Me.m_PropertyGrid.Text = "propertyGrid1"
			Me.m_PropertyGrid.ToolbarVisible = False
			Me.m_PropertyGrid.ViewBackColor = System.Drawing.SystemColors.Window
			Me.m_PropertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText
			' 
			' NTrackBarUC
			' 
			Me.Controls.Add(Me.m_PropertyGrid)
			Me.Controls.Add(Me.nTrackBar1)
			Me.Name = "NTrackBarUC"
			Me.Size = New System.Drawing.Size(560, 312)
			CType(Me.nTrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private m_PropertyGrid As System.Windows.Forms.PropertyGrid

		Private nTrackBar1 As Nevron.UI.WinForm.Controls.NTrackBar

		#End Region
	End Class
End Namespace
