Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NFontComboBoxUC.
	''' </summary>
	Public Class NFontComboBoxUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()

			Dock = DockStyle.Fill
		End Sub


		#End Region

		#Region "Overrides"

		Public Overrides Sub Initialize()
			MyBase.Initialize ()

			m_FontCombo = New NFontComboBox()
			m_FontCombo.Width = 200
			m_FontCombo.Location = New Point(m_ComboStyleList.Left, 8)
			m_FontCombo.Parent = Me

			m_ComboStyleList.FillFromEnum(GetType(FontDisplayStyle))
			m_ComboStyleList.SelectedItem = m_FontCombo.DisplayStyle

			m_AutoSizeCheck.Checked = m_FontCombo.AutoSizeDropDown
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub m_ComboStyleList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ComboStyleList.SelectedIndexChanged
			m_FontCombo.DisplayStyle = CType(m_ComboStyleList.SelectedItem, FontDisplayStyle)
		End Sub
		Private Sub m_AutoSizeCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_AutoSizeCheck.CheckedChanged
			m_FontCombo.AutoSizeDropDown = m_AutoSizeCheck.Checked
		End Sub


		#End Region

		#Region "Generated Code"
		Private Sub InitializeComponent()
			Me.m_ComboStyleList = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.m_AutoSizeCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' m_ComboStyleList
			' 
			Me.m_ComboStyleList.Location = New System.Drawing.Point(80, 56)
			Me.m_ComboStyleList.Name = "m_ComboStyleList"
			Me.m_ComboStyleList.Size = New System.Drawing.Size(200, 22)
			Me.m_ComboStyleList.TabIndex = 0
			Me.m_ComboStyleList.Text = "nComboBox1"
'			Me.m_ComboStyleList.SelectedIndexChanged += New System.EventHandler(Me.m_ComboStyleList_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(16, 56)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(56, 23)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Style:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_AutoSizeCheck
			' 
			Me.m_AutoSizeCheck.Location = New System.Drawing.Point(80, 88)
			Me.m_AutoSizeCheck.Name = "m_AutoSizeCheck"
			Me.m_AutoSizeCheck.Size = New System.Drawing.Size(200, 24)
			Me.m_AutoSizeCheck.TabIndex = 2
			Me.m_AutoSizeCheck.Text = "AutoSize DropDown"
'			Me.m_AutoSizeCheck.CheckedChanged += New System.EventHandler(Me.m_AutoSizeCheck_CheckedChanged);
			' 
			' NFontComboBoxUC
			' 
			Me.Controls.Add(Me.m_AutoSizeCheck)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.m_ComboStyleList)
			Me.Name = "NFontComboBoxUC"
			Me.Size = New System.Drawing.Size(512, 216)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		#Region "Fields"

		Private WithEvents m_ComboStyleList As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents m_AutoSizeCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private m_FontCombo As NFontComboBox

		#End Region
	End Class
End Namespace
