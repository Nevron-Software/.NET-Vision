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
	Public Partial Class NTreeListCustomRenderingUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New()
			m_List = New NTreeList()
			InitializeComponent()

			Dock = DockStyle.Fill

			m_List.Dock = DockStyle.Fill
			'm_List.AutoSizeColumns = false;
			m_List.EnableGroupBy = False

			m_HeaderRenderer = New NTreeListCustomHeaderRenderer()
			m_SubItemRenderer = New NTreeListCustomSubItemRenderer()

			m_List.HeaderRenderer = m_HeaderRenderer
			m_List.SubItemRenderer = m_SubItemRenderer

			m_List.Parent = containerPanel
		End Sub

		#End Region

		#Region "Overrides"

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			m_List.Suspend()

			NTreeListUC.InitDefaultList(m_List, 31)

			'm_List.BestFitAllColumns();
			m_List.BestFitAllNodes()

			m_List.Resume(True)
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub headerRendererCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles headerRendererCheck.CheckedChanged
			If headerRendererCheck.Checked Then
				m_List.HeaderRenderer = m_HeaderRenderer
			Else
				m_List.HeaderRenderer = Nothing
			End If
		End Sub
		Private Sub subItemRendererCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles subItemRendererCheck.CheckedChanged
			If subItemRendererCheck.Checked Then
				m_List.SubItemRenderer = m_SubItemRenderer
			Else
				m_List.SubItemRenderer = Nothing
			End If
		End Sub
		Private Sub autoSizeCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles autoSizeCheck.CheckedChanged
			m_List.AutoSizeColumns = autoSizeCheck.Checked
		End Sub

		#End Region

		#Region "Fields"

		Friend m_List As NTreeList
		Friend m_HeaderRenderer As NTreeListCustomHeaderRenderer
		Friend m_SubItemRenderer As NTreeListCustomSubItemRenderer

		#End Region
	End Class
End Namespace
