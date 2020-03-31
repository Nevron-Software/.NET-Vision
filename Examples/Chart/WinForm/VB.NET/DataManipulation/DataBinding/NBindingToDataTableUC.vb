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
	Public Class NBindingToDataTableUC
		Inherits NExampleBaseUC

		Private dataGrid1 As System.Windows.Forms.DataGrid
		Private components As System.ComponentModel.IContainer = Nothing
		Private dataTable As DataTable

		Public Sub New()
			InitializeComponent()

			' create the data table
			dataTable = New DataTable("Table")
			dataTable.Columns.Add("ValueY1", GetType(Double))
			dataTable.Columns.Add("ValueY2", GetType(Double))
			dataTable.Rows.Add(New Object(){ 10.1, 5.33 })
			dataTable.Rows.Add(New Object(){ 7.2, 6.55 })
			dataTable.Rows.Add(New Object(){ 9.6, 8.97 })
			dataTable.Rows.Add(New Object(){ 11.2, 9.48 })
			dataTable.Rows.Add(New Object(){ 4.9, 11.17 })
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

		#Region "Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.dataGrid1 = New System.Windows.Forms.DataGrid()
			DirectCast(Me.dataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' dataGrid1
			' 
			Me.dataGrid1.DataMember = ""
			Me.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
			Me.dataGrid1.Location = New System.Drawing.Point(8, 8)
			Me.dataGrid1.Name = "dataGrid1"
			Me.dataGrid1.Size = New System.Drawing.Size(232, 376)
			Me.dataGrid1.TabIndex = 0
			' 
			' NBindingToDataTableUC
			' 
			Me.Controls.Add(Me.dataGrid1)
			Me.Name = "NBindingToDataTableUC"
			Me.Size = New System.Drawing.Size(248, 400)
			DirectCast(Me.dataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' setup background

			' add a label
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Binding to DataTable")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))


			Dim chart As NChart = nChartControl1.Charts(0)

			' add bar series 1
			Dim bar1 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar1.Name = "Bar 1"
			bar1.DataLabelStyle.Format = "<value>"

			' add bar series 2
			Dim bar2 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar2.MultiBarMode = MultiBarMode.Clustered
			bar2.FillStyle = New NColorFillStyle(Color.Violet)
			bar2.Name = "Bar 2"
			bar2.DataLabelStyle.Format = "<value>"

			Dim dataBindingManager As NDataBindingManager = nChartControl1.DataBindingManager

			dataBindingManager.AddBinding(0, 0, "Values", dataTable, "ValueY1")
			dataBindingManager.AddBinding(0, 1, "Values", dataTable, "ValueY2")

			dataGrid1.SetDataBinding(dataTable, Nothing)
		End Sub
	End Class
End Namespace

