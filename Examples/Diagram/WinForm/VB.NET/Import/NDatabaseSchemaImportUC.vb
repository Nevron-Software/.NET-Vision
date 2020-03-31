Imports Microsoft.VisualBasic
Imports System.Windows.Forms

Imports Nevron.Diagram
Imports Nevron.Diagram.Extensions
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NTreeDataImportUC.
	''' </summary>
	Public Class NDatabaseSchemaImportUC
		Inherits NDiagramExampleUC
		#Region "Constructors"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			' configure the view
			view.Grid.Visible = False
			view.GlobalVisibility.ShowPorts = False
			view.HorizontalRuler.Visible = False
			view.VerticalRuler.Visible = False

			document.BeginInit()

			document.AutoBoundsMode = AutoBoundsMode.AutoSizeToContent
			Dim importer As NDatabaseImporter = New NDatabaseImporter(document)
			importer.ImportInActiveLayer = True
			importer.ImportOleDb(String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}\..\..\Resources\Data\Northwind.mdb", Application.StartupPath))
			document.SizeToContent()

			document.EndInit()

			' end view init
			view.EndInit()
		End Sub

		#End Region
	End Class
End Namespace