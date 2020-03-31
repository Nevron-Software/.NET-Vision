Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Chart.CSVReader

Namespace Nevron.Examples.Chart.WinForm
	Public Class NImportingFromCSVUC
		Inherits NExampleBaseUC

		Private WithEvents ClearChart As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ImportFromCSV As Nevron.UI.WinForm.Controls.NButton
		Private label1 As Label
		Private nDataGridView1 As Nevron.UI.WinForm.Controls.NDataGridView
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
			Me.ClearChart = New Nevron.UI.WinForm.Controls.NButton()
			Me.ImportFromCSV = New Nevron.UI.WinForm.Controls.NButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.nDataGridView1 = New Nevron.UI.WinForm.Controls.NDataGridView()
			DirectCast(Me.nDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' ClearChart
			' 
			Me.ClearChart.Location = New System.Drawing.Point(8, 8)
			Me.ClearChart.Name = "ClearChart"
			Me.ClearChart.Size = New System.Drawing.Size(151, 24)
			Me.ClearChart.TabIndex = 0
			Me.ClearChart.Text = "Clear Chart"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ClearChart.Click += new System.EventHandler(this.ClearChart_Click);
			' 
			' ImportFromCSV
			' 
			Me.ImportFromCSV.Location = New System.Drawing.Point(8, 40)
			Me.ImportFromCSV.Name = "ImportFromCSV"
			Me.ImportFromCSV.Size = New System.Drawing.Size(151, 23)
			Me.ImportFromCSV.TabIndex = 1
			Me.ImportFromCSV.Text = "Import From CSV File"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ImportFromCSV.Click += new System.EventHandler(this.ImportFromCSV_Click);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(5, 76)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(86, 13)
			Me.label1.TabIndex = 3
			Me.label1.Text = "CSV file content:"
			' 
			' nDataGridView1
			' 
			Me.nDataGridView1.AllowUserToAddRows = False
			Me.nDataGridView1.AllowUserToDeleteRows = False
			Me.nDataGridView1.AllowUserToResizeRows = False
			Me.nDataGridView1.ReadOnly = True
			Me.nDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.nDataGridView1.Location = New System.Drawing.Point(8, 93)
			Me.nDataGridView1.Name = "nDataGridView1"
			Me.nDataGridView1.Size = New System.Drawing.Size(199, 228)
			Me.nDataGridView1.TabIndex = 4
			' 
			' NImportingFromCSVUC
			' 
			Me.Controls.Add(Me.nDataGridView1)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.ImportFromCSV)
			Me.Controls.Add(Me.ClearChart)
			Me.Name = "NImportingFromCSVUC"
			Me.Size = New System.Drawing.Size(210, 400)
			DirectCast(Me.nDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			InitTitleAndBackground()
		End Sub

		Private Sub InitTitleAndBackground()
			' add a title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Import from CSV File")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 20, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.Solid
			title.TextStyle.ShadowStyle.Color = Color.White
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
		End Sub

		Private Sub ImportFromCSV_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ImportFromCSV.Click
			nChartControl1.Clear()
			InitTitleAndBackground()

			Dim bar0 As NBarSeries = CType(nChartControl1.Charts(0).Series.Add(SeriesType.Bar), NBarSeries)
			bar0.Legend.Mode = SeriesLegendMode.DataPoints
			'bar0.FillStyle = new NColorFillStyle(Color.Aquamarine);
			Dim bar1 As NBarSeries = CType(nChartControl1.Charts(0).Series.Add(SeriesType.Bar), NBarSeries)
			bar1.Legend.Mode = SeriesLegendMode.DataPoints
			'bar0.FillStyle = new NColorFillStyle(Color.BurlyWood);
			bar1.MultiBarMode = MultiBarMode.Clustered

			Dim csvFile As String = Application.StartupPath & "\..\..\DataManipulation\Importing\Sample.csv"

			Dim reader As New NCsvReader()
			reader.CellSeparator = ","c
			reader.LineSeparators = New Char() { ControlChars.Cr, ControlChars.Lf }
			reader.HasHeader = False
			reader.EscapeCharacter = "\"c
			reader.TrimCell = True

			reader.Columns.Add(New NStringCsvColumn("String Column"))
			reader.Columns.Add(New NDoubleCsvColumn("Double Column"))
			reader.Columns.Add(New NDecimalCsvColumn("Decimal Column"))
			reader.Columns.Add(New NColorCsvColumn("Color0 Column"))
			reader.Columns.Add(New NColorCsvColumn("Color1 Column"))

			Try
				Dim dt As DataTable = reader.LoadDataTableFromFile(csvFile)
				nChartControl1.DataBindingManager.AddBinding(0, 0, "Values", dt, "Double Column")
				nChartControl1.DataBindingManager.AddBinding(0, 0, "Labels", dt, "String Column")
				nChartControl1.DataBindingManager.AddBinding(0, 0, "FillStyles", dt, "Color0 Column")

				nChartControl1.DataBindingManager.AddBinding(0, 1, "Values", dt, "Decimal Column")
				nChartControl1.DataBindingManager.AddBinding(0, 1, "Labels", dt, "String Column")
				nChartControl1.DataBindingManager.AddBinding(0, 1, "FillStyles", dt, "Color1 Column")

				nDataGridView1.DataSource = dt
				nDataGridView1.AutoResizeColumns()
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try

			nChartControl1.Refresh()
		End Sub

		Private Sub ClearChart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClearChart.Click
			nChartControl1.Clear()
			InitTitleAndBackground()
			nChartControl1.Refresh()
			nDataGridView1.DataSource = Nothing
		End Sub
	End Class
End Namespace
