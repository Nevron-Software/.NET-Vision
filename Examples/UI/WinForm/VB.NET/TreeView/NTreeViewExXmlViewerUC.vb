Imports Microsoft.VisualBasic
Imports System
Imports System.Xml
Imports System.Reflection
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.UI
Imports Nevron.UI.WinForm
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NTreeViewExXmlViewerUC
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

			embeddedFileBtn_Click(Nothing, Nothing)
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub embeddedFileBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles embeddedFileBtn.Click
			Dim [assembly] As System.Reflection.Assembly = Me.GetType().Assembly

			Dim xml As String = NResourceHelper.ReadTextResource([assembly], "ExamplesTree.xml", "Nevron.Examples.UI.WinForm.Resources")
			Dim doc As XmlDocument = New XmlDocument()
			doc.LoadXml(xml)
			nTreeViewEx1.DisplayXml(doc)

			'this.nTreeViewEx1.SaveToXml(@"C:\Test.xml");
		End Sub
		Private Sub loadFileBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadFileBtn.Click
			Dim ofd As OpenFileDialog = New OpenFileDialog()
			ofd.Title = "Select XML file:"
			ofd.Multiselect = False

			If ofd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				nTreeViewEx1.DisplayXml(ofd.FileName)
			End If

			ofd.Dispose()
		End Sub
		Private Sub expandAllBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles expandAllBtn.Click
			nTreeViewEx1.ExpandAll()
		End Sub
		Private Sub collapseAllBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles collapseAllBtn.Click
			nTreeViewEx1.CollapseAll()
		End Sub

		#End Region
	End Class
End Namespace
