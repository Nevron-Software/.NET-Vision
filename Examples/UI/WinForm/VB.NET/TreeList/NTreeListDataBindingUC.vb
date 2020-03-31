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
	Public Partial Class NTreeListDataBindingUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()

			Dock = DockStyle.Fill

			m_List = New NTreeList()
			m_List.Dock = DockStyle.Fill
			m_List.GroupNodeDefaultState.Font = New Font("Trebuchet MS", 9, FontStyle.Bold)
			m_List.Parent = containerPanel
			m_List.AutoSizeColumns = False
			m_List.ShowGroupByBox = True
		End Sub

		#End Region

		#Region "Overrides"

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			Dim data As NTreeListTableData = New NTreeListTableData()
			data.Table = NRptSampleDataSet.GetDataTable("Customers")
			data.Bind(m_List)

			Dim col As NTreeListColumn = m_List.Columns("Country")
			m_List.GroupBy(col)
			m_List.SortColumn(col, TreeListSortMode.Ascending)
			m_List.SortColumn(m_List.Columns("CompanyName"), TreeListSortMode.Ascending)

			m_List.BestFitAllColumns()
			m_List.BestFitAllNodes()

			m_List.ExpandAll()
		End Sub

		#End Region

		#Region "Implementation"
		#End Region

		#Region "Fields"

		Friend m_List As NTreeList

		#End Region
	End Class
End Namespace
