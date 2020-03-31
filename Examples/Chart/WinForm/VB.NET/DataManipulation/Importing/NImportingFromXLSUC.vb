Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Namespace Nevron.Examples.Chart.WinForm
	Public Class NImportingFromXLSUC
		Inherits NExampleBaseUC

		#Region "Construcotrs"

		Public Sub New()
			InitializeComponent()
		End Sub

		#End Region

		#Region "Overrides"

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

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			InitTitleAndBackground()
		End Sub

		#End Region

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.ClearChart = New Nevron.UI.WinForm.Controls.NButton()
			Me.ImportFromXLS = New Nevron.UI.WinForm.Controls.NButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.nDataGridView1 = New Nevron.UI.WinForm.Controls.NDataGridView()
			Me.ImportFromXLSX = New Nevron.UI.WinForm.Controls.NButton()
			Me.nCheckBox1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			DirectCast(Me.nDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' ClearChart
			' 
			Me.ClearChart.Location = New System.Drawing.Point(8, 8)
			Me.ClearChart.Name = "ClearChart"
			Me.ClearChart.Size = New System.Drawing.Size(165, 24)
			Me.ClearChart.TabIndex = 0
			Me.ClearChart.Text = "Clear Chart"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ClearChart.Click += new System.EventHandler(this.ClearChart_Click);
			' 
			' ImportFromXLS
			' 
			Me.ImportFromXLS.Location = New System.Drawing.Point(8, 38)
			Me.ImportFromXLS.Name = "ImportFromXLS"
			Me.ImportFromXLS.Size = New System.Drawing.Size(165, 23)
			Me.ImportFromXLS.TabIndex = 1
			Me.ImportFromXLS.Text = "Import From XLS File"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ImportFromXLS.Click += new System.EventHandler(this.ImportFromXLS_Click);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(5, 126)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(85, 13)
			Me.label1.TabIndex = 4
			Me.label1.Text = "XLS file content:"
			' 
			' nDataGridView1
			' 
			Me.nDataGridView1.AllowUserToAddRows = False
			Me.nDataGridView1.AllowUserToDeleteRows = False
			Me.nDataGridView1.AllowUserToResizeRows = False
			Me.nDataGridView1.BackgroundColor = System.Drawing.Color.FromArgb((CInt((CByte(225)))), (CInt((CByte(225)))), (CInt((CByte(225)))))
			Me.nDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.nDataGridView1.GridColor = System.Drawing.Color.FromArgb((CInt((CByte(180)))), (CInt((CByte(180)))), (CInt((CByte(180)))))
			Me.nDataGridView1.Location = New System.Drawing.Point(8, 142)
			Me.nDataGridView1.Name = "nDataGridView1"
			Me.nDataGridView1.ReadOnly = True
			Me.nDataGridView1.Size = New System.Drawing.Size(165, 228)
			Me.nDataGridView1.TabIndex = 5
			' 
			' ImportFromXLSX
			' 
			Me.ImportFromXLSX.Location = New System.Drawing.Point(8, 67)
			Me.ImportFromXLSX.Name = "ImportFromXLSX"
			Me.ImportFromXLSX.Size = New System.Drawing.Size(165, 23)
			Me.ImportFromXLSX.TabIndex = 2
			Me.ImportFromXLSX.Text = "Import From XLSX File"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ImportFromXLSX.Click += new System.EventHandler(this.ImportFromXLSX_Click);
			' 
			' nCheckBox1
			' 
			Me.nCheckBox1.AutoSize = True
			Me.nCheckBox1.ButtonProperties.BorderOffset = 2
			Me.nCheckBox1.Location = New System.Drawing.Point(8, 96)
			Me.nCheckBox1.Name = "nCheckBox1"
			Me.nCheckBox1.Size = New System.Drawing.Size(141, 17)
			Me.nCheckBox1.TabIndex = 3
			Me.nCheckBox1.Text = "Load from range (A1:E3)"
			' 
			' NImportingFromXLSUC
			' 
			Me.Controls.Add(Me.ImportFromXLSX)
			Me.Controls.Add(Me.nDataGridView1)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.ImportFromXLS)
			Me.Controls.Add(Me.ClearChart)
			Me.Controls.Add(Me.nCheckBox1)
			Me.Name = "NImportingFromXLSUC"
			Me.Size = New System.Drawing.Size(180, 376)
			DirectCast(Me.nDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		#Region "Implementation"

		Private Sub InitTitleAndBackground()
			' add a title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Import from Excel File")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 20, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.Solid
			title.TextStyle.ShadowStyle.Color = Color.White
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
		End Sub

		Private Sub LoadData(ByVal fileName As String)
			nChartControl1.Clear()
			InitTitleAndBackground()

			Dim bar0 As NBarSeries = CType(nChartControl1.Charts(0).Series.Add(SeriesType.Bar), NBarSeries)
			bar0.Legend.Mode = SeriesLegendMode.DataPoints
			Dim bar1 As NBarSeries = CType(nChartControl1.Charts(0).Series.Add(SeriesType.Bar), NBarSeries)
			bar1.Legend.Mode = SeriesLegendMode.DataPoints
			bar1.MultiBarMode = MultiBarMode.Clustered

			Try
				Dim reader As New NExcelReader()
				Dim dt As DataTable

				If nCheckBox1.Checked Then
					dt = reader.ReadRange(fileName, "Sample", "A1:E3").Tables(0)
				Else
					dt = reader.ReadAll(fileName).Tables(0)

				End If

				Dim columns As DataColumnCollection = dt.Columns
				nChartControl1.DataBindingManager.AddBinding(0, 0, "Values", dt, columns(1).ColumnName)
				nChartControl1.DataBindingManager.AddBinding(0, 0, "Labels", dt, columns(0).ColumnName)
				nChartControl1.DataBindingManager.AddBinding(0, 0, "FillStyles", dt, columns(3).ColumnName)

				nChartControl1.DataBindingManager.AddBinding(0, 1, "Values", dt, columns(2).ColumnName)
				nChartControl1.DataBindingManager.AddBinding(0, 1, "Labels", dt, columns(0).ColumnName)
				nChartControl1.DataBindingManager.AddBinding(0, 1, "FillStyles", dt, columns(4).ColumnName)
				nDataGridView1.DataSource = dt

			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try

			nChartControl1.Refresh()
		End Sub

		#End Region

		#Region "Event handlres"

		Private Sub ImportFromXLS_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ImportFromXLS.Click
			Dim xlsFile As String = Application.StartupPath & "\..\..\DataManipulation\Importing\Sample.xls"
			LoadData(xlsFile)
		End Sub

		Private Sub ImportFromXLSX_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ImportFromXLSX.Click
			Dim xlsFile As String = Application.StartupPath & "\..\..\DataManipulation\Importing\Sample.xlsx"
			LoadData(xlsFile)
		End Sub

		Private Sub ClearChart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClearChart.Click
			nChartControl1.Clear()
			InitTitleAndBackground()
			nChartControl1.Refresh()
			nDataGridView1.DataSource = Nothing
		End Sub

		#End Region

		#Region "Fields"

		Private WithEvents ClearChart As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ImportFromXLS As Nevron.UI.WinForm.Controls.NButton
		Private label1 As Label
		Private nDataGridView1 As Nevron.UI.WinForm.Controls.NDataGridView
		Private WithEvents ImportFromXLSX As Nevron.UI.WinForm.Controls.NButton
		Private nCheckBox1 As Nevron.UI.WinForm.Controls.NCheckBox
		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace
