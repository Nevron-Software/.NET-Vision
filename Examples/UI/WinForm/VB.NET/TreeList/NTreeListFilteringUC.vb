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
	Public Partial Class NTreeListFilteringUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()

			Dock = DockStyle.Fill

			m_List = New NTreeList()
			m_List.Dock = DockStyle.Fill
			m_List.Parent = containerPanel
			m_List.ShowGroupByBox = True
		End Sub

		#End Region

		#Region "Overrides"

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			stringOptionsCombo.FillFromEnum(GetType(CommonStringOptions))
			stringOptionsCombo.SelectedItem = CommonStringOptions.Contains

			numericOptionsCombo.FillFromEnum(GetType(CommonNumericOptions))
			numericOptionsCombo.SelectedItem = CommonNumericOptions.Equals

			m_Helper = New NTreeListUCHelper()
			m_Helper.Populate(m_List)
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub stringOptionsCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles stringOptionsCombo.SelectedIndexChanged
		End Sub
		Private Sub numericOptionsCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles numericOptionsCombo.SelectedIndexChanged
		End Sub
		Private Sub enableFromFilterBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles enableFromFilterBtn.Click
			Dim txt As String = fromColumnFilterText1.Text

			Dim filter As NTreeListColumnStringFilter = New NTreeListColumnStringFilter(txt, True, CType(Me.stringOptionsCombo.SelectedItem, CommonStringOptions))
			m_List.Columns("From").VisibleFilter = filter
		End Sub
		Private Sub disableFromFilterBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles disableFromFilterBtn.Click
			m_List.Columns("From").VisibleFilter = Nothing
		End Sub
		Private Sub applyNumericFilterBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles applyNumericFilterBtn.Click
			Dim val1 As Decimal = CInt(Fix(amountFilterNum1.Value))
			Dim val2 As Decimal = CInt(Fix(amountFilterNum2.Value))

			Dim filter As NTreeListColumnNumericFilter = New NTreeListColumnNumericFilter(val1, val2, CType(Me.numericOptionsCombo.SelectedItem, CommonNumericOptions))
			m_List.Columns("PurchaseAmount").VisibleFilter = filter
		End Sub
		Private Sub removeNumericFilterBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles removeNumericFilterBtn.Click
			m_List.Columns("PurchaseAmount").VisibleFilter = Nothing
		End Sub

		#End Region

		#Region "Fields"

		Friend m_List As NTreeList
		Friend m_Helper As NTreeListUCHelper

		#End Region
	End Class
End Namespace
