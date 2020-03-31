Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms

Namespace Nevron.Examples.UI.WinForm
	Friend Class NRptSampleDataSet
		Inherits DataSet
		Public Shared Function GetDataTable(ByVal tableName As String) As DataTable
			Dim dataTable As DataTable = New DataTable(tableName)
			Using conn As OleDbConnection = New OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\..\..\DataGridView\RptSampl.mdb")
				conn.Open()

				' Create the DataTable "Orders" in the Dataset and the OrdersDataAdapter
				Dim dataAdapter As OleDbDataAdapter = New OleDbDataAdapter(New OleDbCommand("SELECT * FROM " & tableName, conn))
				dataAdapter.FillSchema(dataTable, SchemaType.Source)
				dataAdapter.Fill(dataTable)
			End Using

			Return dataTable
		End Function
	End Class
End Namespace
