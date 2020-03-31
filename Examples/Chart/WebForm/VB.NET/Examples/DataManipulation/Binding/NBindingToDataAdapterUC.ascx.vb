Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Data.OleDb
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm


Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NBindingToDataAdapterUC
		Inherits NExampleUC
		Protected oleDbDataAdapter1 As System.Data.OleDb.OleDbDataAdapter
		Protected oleDbSelectCommand1 As System.Data.OleDb.OleDbCommand
		Protected oleDbInsertCommand1 As System.Data.OleDb.OleDbCommand
		Protected oleDbUpdateCommand1 As System.Data.OleDb.OleDbCommand
		Protected oleDbDeleteCommand1 As System.Data.OleDb.OleDbCommand
		Protected oleDbConnection1 As System.Data.OleDb.OleDbConnection
		Protected dsTable1 As Nevron.Examples.Chart.WebForm.dsTable

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' add header
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Bind to Data Adapter")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			nChartControl1.DataBindingManager.EnableDataBinding = CheckBoxEnableDatabindig.Checked

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Width = 100.0f
			chart.Height = 65.0f
			chart.BoundsMode = BoundsMode.Stretch
			chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

			' add the bar series
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Bar"
			bar.Legend.Format = "<label>"
			bar.DataLabelStyle.Format = "<label>"
			bar.BarShape = BarShape.SmoothEdgeBar
			bar.Legend.Mode = SeriesLegendMode.DataPoints



			' binding chart
			BindingChartToData()

			' fill data set
			oleDbDataAdapter1.Fill(dsTable1)

			' if not post back bind data grid
			If (Not IsPostBack) Then
				DataGrid1.DataBind()
			End If

			' set "id" column as read-only
			dsTable1.MyTable.columnid.ReadOnly = True


		End Sub

		Private Sub BindingChartToData()
			' connection string with relative path
			Dim fileName As String = Me.MapPathSecure(Me.TemplateSourceDirectory & "\Data.mdb")
			Me.oleDbConnection1.ConnectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" & fileName

			' add data source to chart control
			nChartControl1.DataBindingManager.AddBinding(0, 0, "Values", oleDbDataAdapter1, "values")
			nChartControl1.DataBindingManager.AddBinding(0, 0, "Labels", oleDbDataAdapter1, "colors")
			nChartControl1.DataBindingManager.AddBinding(0, 0, "FillStyles", oleDbDataAdapter1, "colors")

			nChartControl1.DataBindingManager.UpdateChartControl()
		End Sub


		#Region "Web Form Designer generated code"
		Overrides Protected Sub OnInit(ByVal e As EventArgs)
			'
			' CODEGEN: This call is required by the ASP.NET Web Form Designer.
			'
			InitializeComponent()
			MyBase.OnInit(e)
		End Sub

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.oleDbDataAdapter1 = New System.Data.OleDb.OleDbDataAdapter()
			Me.oleDbDeleteCommand1 = New System.Data.OleDb.OleDbCommand()
			Me.oleDbConnection1 = New System.Data.OleDb.OleDbConnection()
			Me.oleDbInsertCommand1 = New System.Data.OleDb.OleDbCommand()
			Me.oleDbSelectCommand1 = New System.Data.OleDb.OleDbCommand()
			Me.oleDbUpdateCommand1 = New System.Data.OleDb.OleDbCommand()
			Me.dsTable1 = New Nevron.Examples.Chart.WebForm.dsTable()
			CType(Me.dsTable1, System.ComponentModel.ISupportInitialize).BeginInit()
'			Me.DataGrid1.CancelCommand += New System.Web.UI.WebControls.DataGridCommandEventHandler(Me.DataGrid1_CancelCommand);
'			Me.DataGrid1.EditCommand += New System.Web.UI.WebControls.DataGridCommandEventHandler(Me.DataGrid1_EditCommand);
'			Me.DataGrid1.UpdateCommand += New System.Web.UI.WebControls.DataGridCommandEventHandler(Me.DataGrid1_UpdateCommand);
'			Me.DataGrid1.ItemDataBound += New System.Web.UI.WebControls.DataGridItemEventHandler(Me.DataGrid1_ItemDataBound);
			' 
			' oleDbDataAdapter1
			' 
			Me.oleDbDataAdapter1.DeleteCommand = Me.oleDbDeleteCommand1
			Me.oleDbDataAdapter1.InsertCommand = Me.oleDbInsertCommand1
			Me.oleDbDataAdapter1.SelectCommand = Me.oleDbSelectCommand1
			Me.oleDbDataAdapter1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() { New System.Data.Common.DataTableMapping("Table", "MyTable", New System.Data.Common.DataColumnMapping() { New System.Data.Common.DataColumnMapping("colors", "colors"), New System.Data.Common.DataColumnMapping("id", "id"), New System.Data.Common.DataColumnMapping("values", "values")})})
			Me.oleDbDataAdapter1.UpdateCommand = Me.oleDbUpdateCommand1
			' 
			' oleDbDeleteCommand1
			' 
			Me.oleDbDeleteCommand1.CommandText = "DELETE FROM MyTable WHERE (id = ?) AND (colors = ? OR ? IS NULL AND colors IS NUL" & "L) AND ([values] = ? OR ? IS NULL AND [values] IS NULL)"
			Me.oleDbDeleteCommand1.Connection = Me.oleDbConnection1
			Me.oleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "id", System.Data.DataRowVersion.Original, Nothing))
			Me.oleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_colors", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "colors", System.Data.DataRowVersion.Original, Nothing))
			Me.oleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_colors1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "colors", System.Data.DataRowVersion.Original, Nothing))
			Me.oleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_values", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "values", System.Data.DataRowVersion.Original, Nothing))
			Me.oleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_values1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "values", System.Data.DataRowVersion.Original, Nothing))
			' 
			' oleDbConnection1
			' 
			Me.oleDbConnection1.ConnectionString = "Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Data Source=""D:\Inetpub\wwwroot\NChartServerExamples\DataManipulation\Binding\Data.mdb"";Jet OLEDB:Engine Type=5;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1"
			' 
			' oleDbInsertCommand1
			' 
			Me.oleDbInsertCommand1.CommandText = "INSERT INTO MyTable(colors, [values]) VALUES (?, ?)"
			Me.oleDbInsertCommand1.Connection = Me.oleDbConnection1
			Me.oleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("colors", System.Data.OleDb.OleDbType.VarWChar, 50, "colors"))
			Me.oleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("values", System.Data.OleDb.OleDbType.Integer, 0, "values"))
			' 
			' oleDbSelectCommand1
			' 
			Me.oleDbSelectCommand1.CommandText = "SELECT colors, id, [values] FROM MyTable"
			Me.oleDbSelectCommand1.Connection = Me.oleDbConnection1
			' 
			' oleDbUpdateCommand1
			' 
			Me.oleDbUpdateCommand1.CommandText = "UPDATE MyTable SET colors = ?, [values] = ? WHERE (id = ?) AND (colors = ? OR ? I" & "S NULL AND colors IS NULL) AND ([values] = ? OR ? IS NULL AND [values] IS NULL)"
			Me.oleDbUpdateCommand1.Connection = Me.oleDbConnection1
			Me.oleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("colors", System.Data.OleDb.OleDbType.VarWChar, 50, "colors"))
			Me.oleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("values", System.Data.OleDb.OleDbType.Integer, 0, "values"))
			Me.oleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "id", System.Data.DataRowVersion.Original, Nothing))
			Me.oleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_colors", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "colors", System.Data.DataRowVersion.Original, Nothing))
			Me.oleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_colors1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "colors", System.Data.DataRowVersion.Original, Nothing))
			Me.oleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_values", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "values", System.Data.DataRowVersion.Original, Nothing))
			Me.oleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_values1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "values", System.Data.DataRowVersion.Original, Nothing))
			' 
			' dsTable1
			' 
			Me.dsTable1.DataSetName = "dsCategories"
			Me.dsTable1.Locale = New System.Globalization.CultureInfo("bg-BG")
			CType(Me.dsTable1, System.ComponentModel.ISupportInitialize).EndInit()

		End Sub
		#End Region

		Private Sub DataGrid1_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.EditCommand
			DataGrid1.EditItemIndex = e.Item.ItemIndex
			DataGrid1.DataBind()
		End Sub

		Private Sub DataGrid1_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.CancelCommand
			DataGrid1.EditItemIndex = -1
			DataGrid1.DataBind()
		End Sub

		Private Sub DataGrid1_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.UpdateCommand
			Dim color, sValue As String

			' Gets the value of the key field of the row being updated
			Dim key As String = DataGrid1.DataKeys(e.Item.ItemIndex).ToString()

			' Gets get the value of the controls (textboxes) that the user
			' updated. The DataGrid columns are exposed as the Cells collection.
			' Each cell has a collection of controls. In this case, there is only    one 
			' control in each cell -- a TextBox control. To get its value,
			' you copy the TextBox to a local instance (which requires casting)
			' and extract its Text property.
			'
			' The first column -- Cells(0) -- contains the Update and Cancel buttons.
			Dim tb As TextBox

			' Gets the value
			tb = CType(e.Item.Cells(2).Controls(0), TextBox)
			color = tb.Text

			' Gets the value
			tb = CType(e.Item.Cells(3).Controls(0), TextBox)
			sValue = tb.Text

			' Finds the row in the dataset table that matches the 
			' one the user updated in the grid. This example uses a 
			' special Find method defined for the typed dataset, which
			' returns a reference to the row.
			Dim r As dsTable.MyTableRow
			r = dsTable1.MyTable.FindByid(Integer.Parse(key))

			' Updates the dataset table.
			r.colors = color
			r.values = Integer.Parse(sValue)

			' Calls a SQL statement to update the database from the dataset
			oleDbDataAdapter1.Update(dsTable1)

			' Takes the DataGrid row out of editing mode
			DataGrid1.EditItemIndex = -1

			' Refreshes the grid
			DataGrid1.DataBind()
		End Sub

		Private Sub DataGrid1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DataGrid1.ItemDataBound
			If Not e.Item.Cells(2).Controls Is Nothing AndAlso e.Item.Cells(2).Controls.Count > 0 Then
				Dim tb As TextBox
				tb = CType(e.Item.Cells(2).Controls(0), TextBox)
				tb.Width = New Unit(100, System.Web.UI.WebControls.UnitType.Pixel)

				tb = CType(e.Item.Cells(3).Controls(0), TextBox)
				tb.Width = New Unit(50, System.Web.UI.WebControls.UnitType.Pixel)
			End If
		End Sub
	End Class
End Namespace
