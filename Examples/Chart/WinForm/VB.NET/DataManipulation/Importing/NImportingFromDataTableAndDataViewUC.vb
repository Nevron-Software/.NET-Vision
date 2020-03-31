Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NImportingFromDataTableAndDataViewUC
		Inherits NExampleBaseUC

		Private WithEvents ClearChart As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ImportFromDataTable As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ImportFromDataView As Nevron.UI.WinForm.Controls.NButton
		Private dataView1 As System.Data.DataView
		Private WithEvents DataGrid As System.Windows.Forms.DataGrid
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
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
			Me.dataView1 = New System.Data.DataView()
			Me.DataGrid = New System.Windows.Forms.DataGrid()
			Me.ClearChart = New Nevron.UI.WinForm.Controls.NButton()
			Me.ImportFromDataTable = New Nevron.UI.WinForm.Controls.NButton()
			Me.ImportFromDataView = New Nevron.UI.WinForm.Controls.NButton()
			DirectCast(Me.dataView1, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.DataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' DataGrid
			' 
			Me.DataGrid.DataMember = ""
			Me.DataGrid.DataSource = Me.dataView1
			Me.DataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
			Me.DataGrid.Location = New System.Drawing.Point(9, 8)
			Me.DataGrid.Name = "DataGrid"
			Me.DataGrid.Size = New System.Drawing.Size(193, 160)
			Me.DataGrid.TabIndex = 0
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DataGrid.TextChanged += new System.EventHandler(this.DataGrid_TextChanged);
			' 
			' ClearChart
			' 
			Me.ClearChart.Location = New System.Drawing.Point(9, 178)
			Me.ClearChart.Name = "ClearChart"
			Me.ClearChart.Size = New System.Drawing.Size(193, 23)
			Me.ClearChart.TabIndex = 4
			Me.ClearChart.Text = "Clear Chart"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ClearChart.Click += new System.EventHandler(this.ClearChart_Click);
			' 
			' ImportFromDataTable
			' 
			Me.ImportFromDataTable.Location = New System.Drawing.Point(9, 210)
			Me.ImportFromDataTable.Name = "ImportFromDataTable"
			Me.ImportFromDataTable.Size = New System.Drawing.Size(193, 23)
			Me.ImportFromDataTable.TabIndex = 5
			Me.ImportFromDataTable.Text = "Import From Data Table"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ImportFromDataTable.Click += new System.EventHandler(this.ImportFromDataTable_Click);
			' 
			' ImportFromDataView
			' 
			Me.ImportFromDataView.Location = New System.Drawing.Point(9, 242)
			Me.ImportFromDataView.Name = "ImportFromDataView"
			Me.ImportFromDataView.Size = New System.Drawing.Size(193, 23)
			Me.ImportFromDataView.TabIndex = 6
			Me.ImportFromDataView.Text = "Import From Data View"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ImportFromDataView.Click += new System.EventHandler(this.ImportFromDataView_Click);
			' 
			' NImportingFromDataTableAndDataViewUC
			' 
			Me.Controls.Add(Me.ImportFromDataView)
			Me.Controls.Add(Me.ImportFromDataTable)
			Me.Controls.Add(Me.ClearChart)
			Me.Controls.Add(Me.DataGrid)
			Me.Name = "NImportingFromDataTableAndDataViewUC"
			Me.Size = New System.Drawing.Size(211, 284)
			DirectCast(Me.dataView1, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.DataGrid, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			SetupChartTitle()

			' create a data table and bind it to the view
			Dim table As New DataTable("MyTable")
			dataView1.Table = table

			table.Columns.Add("Values", GetType(Double))
			table.Columns.Add("Labels", GetType(String))

			table.Rows.Add(New Object() { 31, "Item1" })
			table.Rows.Add(New Object() { 24, "Item2" })
			table.Rows.Add(New Object() { 43, "Item3" })
			table.Rows.Add(New Object() { 34, "Item4" })

			dataView1.Table = table
		End Sub

		Private Sub SetupChartTitle()
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Import from Data View")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 20, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.Solid
			title.TextStyle.ShadowStyle.Color = Color.White
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
		End Sub

		Private Sub DataGrid_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid.TextChanged
			nChartControl1.Refresh()
		End Sub

		Private Sub ClearChart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClearChart.Click
			nChartControl1.Clear()
			SetupChartTitle()
			nChartControl1.Refresh()
		End Sub

		Private Sub ImportFromDataTable_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImportFromDataTable.Click
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Series.Clear()

			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)

			Dim arrSeries As New NDataSeriesCollection()
			arrSeries.Add(bar.Values, DataSeriesMask.Values)
			arrSeries.Add(bar.Labels, DataSeriesMask.Labels)

			Dim arrCollumns() As String = { "Values", "Labels" }
			arrSeries.FillFromDataTable(dataView1.Table, arrCollumns)

			nChartControl1.Refresh()
		End Sub

		Private Sub ImportFromDataView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImportFromDataView.Click
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Series.Clear()

			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)

			Dim arrSeries As New NDataSeriesCollection()
			arrSeries.Add(bar.Values, DataSeriesMask.Values)
			arrSeries.Add(bar.Labels, DataSeriesMask.Labels)

			Dim arrCollumns() As String = { "Values", "Labels" }
			arrSeries.FillFromDataView(dataView1, arrCollumns)

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
