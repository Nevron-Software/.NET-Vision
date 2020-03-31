Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NDesktopToolbarUC.
	''' </summary>
	Public Class NDesktopToolbarUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()
		End Sub


		#End Region

		#Region "Overrides"

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If

				If Not m_Toolbar Is Nothing Then
					m_Toolbar.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		Public Overrides Sub Initialize()
			MyBase.Initialize ()

			m_Toolbar = New NDesktopToolbar()
			m_Toolbar.Text = "Desktop Toolbar Demo"
			Dim content As NDesktopToolbarContentUC = New NDesktopToolbarContentUC()

			content.Dock = DockStyle.Fill
			content.Parent = m_Toolbar

			m_DockStyleCombo.FillFromEnum(GetType(DockStyle))
			m_DockStyleCombo.Items.Remove(DockStyle.Fill)
			m_DockStyleCombo.SelectedItem = DockStyle.Right
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub m_DockStyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_DockStyleCombo.SelectedIndexChanged
		End Sub
		Private Sub m_ApplyButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ApplyButton.Click
			Dim dockStyle As DockStyle = CType(m_DockStyleCombo.SelectedItem, DockStyle)
			If dockStyle = DockStyle.None Then
				m_Toolbar.Owner = m_MainForm
			Else
				m_Toolbar.Owner = Nothing
			End If

			m_Toolbar.Dock = dockStyle

			If m_bToolbarShown Then
				Return
			End If

			m_Toolbar.Palette.Copy(NUIManager.Palette)
			m_Toolbar.Show()
			m_bToolbarShown = True
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.m_DockStyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.m_ApplyButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' m_DockStyleCombo
			' 
			Me.m_DockStyleCombo.Location = New System.Drawing.Point(16, 32)
			Me.m_DockStyleCombo.Name = "m_DockStyleCombo"
			Me.m_DockStyleCombo.Size = New System.Drawing.Size(232, 22)
			Me.m_DockStyleCombo.TabIndex = 0
			Me.m_DockStyleCombo.Text = "nComboBox1"
'			Me.m_DockStyleCombo.SelectedIndexChanged += New System.EventHandler(Me.m_DockStyleCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(16, 8)
			Me.label1.Name = "label1"
			Me.label1.TabIndex = 1
			Me.label1.Text = "Select Dock Edge:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' m_ApplyButton
			' 
			Me.m_ApplyButton.Location = New System.Drawing.Point(16, 64)
			Me.m_ApplyButton.Name = "m_ApplyButton"
			Me.m_ApplyButton.Size = New System.Drawing.Size(80, 24)
			Me.m_ApplyButton.TabIndex = 2
			Me.m_ApplyButton.Text = "Apply"
'			Me.m_ApplyButton.Click += New System.EventHandler(Me.m_ApplyButton_Click);
			' 
			' NDesktopToolbarUC
			' 
			Me.Controls.Add(Me.m_ApplyButton)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.m_DockStyleCombo)
			Me.Name = "NDesktopToolbarUC"
			Me.Size = New System.Drawing.Size(360, 240)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Friend m_Toolbar As NDesktopToolbar
		Friend m_bToolbarShown As Boolean
		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents m_DockStyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents m_ApplyButton As Nevron.UI.WinForm.Controls.NButton
		Private label1 As System.Windows.Forms.Label

		#End Region
	End Class
End Namespace
