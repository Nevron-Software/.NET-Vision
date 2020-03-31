Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NBindingToDataAdapterUC
		Inherits NExampleBaseUC
		Private dataGrid1 As System.Windows.Forms.DataGrid
		Private WithEvents checkBoxEnableDatabinding As Nevron.UI.WinForm.Controls.NCheckBox
		Private oleDbDataAdapter1 As System.Data.OleDb.OleDbDataAdapter
		Private dataSet1 As System.Data.DataSet
		Private dataView1 As System.Data.DataView
		Private label1 As System.Windows.Forms.Label
		Private oleDbSelectCommand1 As System.Data.OleDb.OleDbCommand
		Private oleDbInsertCommand1 As System.Data.OleDb.OleDbCommand
		Private oleDbUpdateCommand1 As System.Data.OleDb.OleDbCommand
		Private oleDbDeleteCommand1 As System.Data.OleDb.OleDbCommand
		Private oleDbConnection1 As System.Data.OleDb.OleDbConnection
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub


		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NBindingToDataAdapterUC))
			Me.dataGrid1 = New System.Windows.Forms.DataGrid()
			Me.dataView1 = New System.Data.DataView()
			Me.dataSet1 = New System.Data.DataSet()
			Me.checkBoxEnableDatabinding = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.oleDbDataAdapter1 = New System.Data.OleDb.OleDbDataAdapter()
			Me.oleDbDeleteCommand1 = New System.Data.OleDb.OleDbCommand()
			Me.oleDbConnection1 = New System.Data.OleDb.OleDbConnection()
			Me.oleDbInsertCommand1 = New System.Data.OleDb.OleDbCommand()
			Me.oleDbSelectCommand1 = New System.Data.OleDb.OleDbCommand()
			Me.oleDbUpdateCommand1 = New System.Data.OleDb.OleDbCommand()
			Me.label1 = New System.Windows.Forms.Label()
			CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dataView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' dataGrid1
			' 
			Me.dataGrid1.AllowSorting = False
			Me.dataGrid1.DataMember = ""
			Me.dataGrid1.DataSource = Me.dataView1
			Me.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
			Me.dataGrid1.Location = New System.Drawing.Point(8, 32)
			Me.dataGrid1.Name = "dataGrid1"
			Me.dataGrid1.RowHeadersVisible = False
			Me.dataGrid1.Size = New System.Drawing.Size(216, 264)
			Me.dataGrid1.TabIndex = 0
			' 
			' dataView1
			' 
			Me.dataView1.AllowDelete = False
			Me.dataView1.AllowNew = False
			' 
			' dataSet1
			' 
			Me.dataSet1.DataSetName = "NewDataSet"
			Me.dataSet1.Locale = New System.Globalization.CultureInfo("bg-BG")
			' 
			' checkBoxEnableDatabinding
			' 
			Me.checkBoxEnableDatabinding.ButtonProperties.BorderOffset = 2
			Me.checkBoxEnableDatabinding.Checked = True
			Me.checkBoxEnableDatabinding.CheckState = System.Windows.Forms.CheckState.Checked
			Me.checkBoxEnableDatabinding.Location = New System.Drawing.Point(8, 304)
			Me.checkBoxEnableDatabinding.Name = "checkBoxEnableDatabinding"
			Me.checkBoxEnableDatabinding.Size = New System.Drawing.Size(216, 24)
			Me.checkBoxEnableDatabinding.TabIndex = 1
			Me.checkBoxEnableDatabinding.Text = "Enable Data Binding"
'			Me.checkBoxEnableDatabinding.CheckedChanged += New System.EventHandler(Me.checkBoxEnableDatabinding_CheckedChanged);
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
			Me.oleDbDeleteCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() { New System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "id", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_colors", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "colors", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_colors1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "colors", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_values", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "values", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_values1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "values", System.Data.DataRowVersion.Original, Nothing)})
			' 
			' oleDbConnection1
			' 
			Me.oleDbConnection1.ConnectionString = resources.GetString("oleDbConnection1.ConnectionString")
			' 
			' oleDbInsertCommand1
			' 
			Me.oleDbInsertCommand1.CommandText = "INSERT INTO MyTable(colors, [values]) VALUES (?, ?)"
			Me.oleDbInsertCommand1.Connection = Me.oleDbConnection1
			Me.oleDbInsertCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() { New System.Data.OleDb.OleDbParameter("colors", System.Data.OleDb.OleDbType.VarWChar, 50, "colors"), New System.Data.OleDb.OleDbParameter("values", System.Data.OleDb.OleDbType.Integer, 0, "values")})
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
			Me.oleDbUpdateCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() { New System.Data.OleDb.OleDbParameter("colors", System.Data.OleDb.OleDbType.VarWChar, 50, "colors"), New System.Data.OleDb.OleDbParameter("values", System.Data.OleDb.OleDbType.Integer, 0, "values"), New System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "id", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_colors", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "colors", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_colors1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "colors", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_values", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "values", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_values1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, (CByte(0)), (CByte(0)), "values", System.Data.DataRowVersion.Original, Nothing)})
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 16)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(100, 16)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Data:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' NBindingToDataAdapterUC
			' 
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.checkBoxEnableDatabinding)
			Me.Controls.Add(Me.dataGrid1)
			Me.Name = "NBindingToDataAdapterUC"
			Me.Size = New System.Drawing.Size(237, 392)
			CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dataView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dataSet1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' add a label
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Binding to DataAdapter")

			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			Dim chart As NChart = nChartControl1.Charts(0)

			' add the bar series
			Dim bar As NBarSeries = New NBarSeries()
			chart.Series.Add(bar)
			bar.Name = "Bar"
			bar.Legend.Format = "<label>"
			bar.DataLabelStyle.Format = "<label>"
			bar.BarShape = BarShape.SmoothEdgeBar
			bar.Legend.Mode = SeriesLegendMode.DataPoints

			' connection string with relative path
			Me.oleDbConnection1.ConnectionString = "Data Source=""" & Application.StartupPath & "\..\..\DataManipulation\DataBinding\Data.mdb"";Provider=""Microsoft.Jet.OLEDB.4.0"";"

			Try
				Dim dataBindingManager As NDataBindingManager = nChartControl1.DataBindingManager

				dataBindingManager.AddBinding(0, 0, "Values", oleDbDataAdapter1, "values")
				dataBindingManager.AddBinding(0, 0, "Labels", oleDbDataAdapter1, "colors")
				dataBindingManager.AddBinding(0, 0, "FillStyles", oleDbDataAdapter1, "colors")
				dataBindingManager.UpdateChartControl()

				oleDbDataAdapter1.Fill(dataSet1)

				Dim dataTable As DataTable = dataSet1.Tables(0)
				dataTable.Columns("id").ReadOnly = True
				AddHandler dataTable.RowChanged, AddressOf dataTable_RowChanged

				dataView1.Table = dataTable
			Catch x As Exception
				MessageBox.Show(x.Message)
			End Try
		End Sub

		Private Sub dataTable_RowChanged(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
			Try
				oleDbDataAdapter1.Update(dataSet1)
			Catch exp As Exception
				MessageBox.Show(exp.Message)
			End Try
		End Sub

		Private Sub checkBoxEnableDatabinding_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles checkBoxEnableDatabinding.CheckedChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			Dim dataBindingManager As NDataBindingManager = nChartControl1.DataBindingManager

			dataBindingManager.EnableDataBinding = checkBoxEnableDatabinding.Checked
			dataBindingManager.UpdateChartControl()
		End Sub
	End Class
End Namespace