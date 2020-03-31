Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.Filters
Imports Nevron.GraphicsCore
Imports Nevron.UI
Imports Nevron.UI.WinForm
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NTreeViewExFilteringUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()

			Dock = DockStyle.Fill
		End Sub

		#End Region

		#Region "Overrides"

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			NTreeViewExUC.AddTestNodes(nTreeViewEx1, 10, 3)

			'init sample filters
			Dim simpleFilter As NFilter = New NTreeNodeTextFilter("Sample Tree Node 1", CommonStringOptions.Contains, True)

			Dim compositeFilter As NAndFilter = New NAndFilter()
			compositeFilter.Add(New NTreeNodeTextFilter("Sample Tree Node 1", CommonStringOptions.Contains, True))
			compositeFilter.Add(New NTreeNodeTextFilter("Depth: 0", CommonStringOptions.Contains, True))

			Dim item As NListBoxItem = New NListBoxItem()
			item.Text = "No Filter"
			filterCombo.Items.Add(item)

			item = New NListBoxItem(simpleFilter)
			item.Text = "Simple Text Filter"
			filterCombo.Items.Add(item)

			item = New NListBoxItem(compositeFilter)
			item.Text = "Composite 'And' Filter"
			filterCombo.Items.Add(item)

			filterCombo.SelectedIndex = 0
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub filterCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles filterCombo.SelectedIndexChanged
			Select Case filterCombo.SelectedIndex
				Case 0
					nTreeViewEx1.VisibleFilter = Nothing
				Case 1
					nTreeViewEx1.VisibleFilter = CType(filterCombo.SelectedItem, INFilter)
					descriptionLabel.Text = "Simple NTreeNodeTextFilter with string options set to 'Contains' and text to examine set to 'Sample Tree Node 1'."
				Case 2
					nTreeViewEx1.VisibleFilter = CType(filterCombo.SelectedItem, INFilter)
					descriptionLabel.Text = "Composite NAndFilter which contains two NTreeNodeTextFilter instances - one to check for the 'Sample Tree Node 1' and the other for the 'Depth: 0' text."
			End Select
		End Sub

		#End Region
	End Class
End Namespace
