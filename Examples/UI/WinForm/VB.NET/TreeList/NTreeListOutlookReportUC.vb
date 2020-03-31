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
	Public Partial Class NTreeListOutlookReportUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()

			Dock = DockStyle.Fill

			m_List = New NTreeList()
			m_List.Dock = DockStyle.Fill
			m_List.ShowGroupByBox = True
			m_List.Parent = containerPanel
		End Sub

		#End Region

		#Region "Overrides"

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			m_Helper = New NTreeListUCHelper()
			m_Helper.Populate(m_List)
		End Sub

		#End Region

		#Region "Fields"

		Friend m_List As NTreeList
		Friend m_Helper As NTreeListUCHelper

		#End Region
	End Class
End Namespace
