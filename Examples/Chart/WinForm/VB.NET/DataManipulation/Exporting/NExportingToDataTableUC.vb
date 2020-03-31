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
	Public Class NExportingToDataTableUC
		Inherits NExampleBaseUC

		Private DataGrid As System.Windows.Forms.DataGrid
		Private WithEvents ChartCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents ExportToDataTable As Nevron.UI.WinForm.Controls.NButton
		Private dataView1 As System.Data.DataView
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			ChartCombo.Items.Add("Bar Chart")
			ChartCombo.Items.Add("Line Chart with X Values")
			ChartCombo.Items.Add("Pie Chart with Detachments")
			ChartCombo.Items.Add("Open High Low Close")
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
			Me.DataGrid = New System.Windows.Forms.DataGrid()
			Me.dataView1 = New System.Data.DataView()
			Me.ChartCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.ExportToDataTable = New Nevron.UI.WinForm.Controls.NButton()
			DirectCast(Me.DataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.dataView1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' DataGrid
			' 
			Me.DataGrid.AllowSorting = False
			Me.DataGrid.CaptionVisible = False
			Me.DataGrid.DataMember = ""
			Me.DataGrid.DataSource = Me.dataView1
			Me.DataGrid.FlatMode = True
			Me.DataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
			Me.DataGrid.Location = New System.Drawing.Point(8, 8)
			Me.DataGrid.Name = "DataGrid"
			Me.DataGrid.ReadOnly = True
			Me.DataGrid.Size = New System.Drawing.Size(345, 160)
			Me.DataGrid.TabIndex = 1
			' 
			' ChartCombo
			' 
			Me.ChartCombo.Location = New System.Drawing.Point(360, 28)
			Me.ChartCombo.Name = "ChartCombo"
			Me.ChartCombo.Size = New System.Drawing.Size(160, 21)
			Me.ChartCombo.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChartCombo.SelectedIndexChanged += new System.EventHandler(this.ChartCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(360, 9)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(160, 16)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Predefined Chart:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' ExportToDataTable
			' 
			Me.ExportToDataTable.Location = New System.Drawing.Point(360, 65)
			Me.ExportToDataTable.Name = "ExportToDataTable"
			Me.ExportToDataTable.Size = New System.Drawing.Size(160, 23)
			Me.ExportToDataTable.TabIndex = 4
			Me.ExportToDataTable.Text = "Export To Data Table"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ExportToDataTable.Click += new System.EventHandler(this.ExportToDataTable_Click);
			' 
			' NExportingToDataTableUC
			' 
			Me.Controls.Add(Me.ExportToDataTable)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.ChartCombo)
			Me.Controls.Add(Me.DataGrid)
			Me.Name = "NExportingToDataTableUC"
			Me.Size = New System.Drawing.Size(528, 186)
			DirectCast(Me.DataGrid, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.dataView1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Export to Data Table")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 20, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.Solid
			title.TextStyle.ShadowStyle.Color = Color.White
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			ChartCombo.SelectedIndex = 0
		End Sub

		Private Sub ChartCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChartCombo.SelectedIndexChanged
			Dim chart As NChart = Nothing
			nChartControl1.Charts.Clear()

			Select Case ChartCombo.SelectedIndex
				Case 0 ' Bar Chart
					chart = New NCartesianChart()
					chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NOrdinalScaleConfigurator()

					Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
					bar.Values.FillRandom(Random, 10)
					bar.Labels.FillRandom(Random, 10)
					Exit Select

				Case 1 ' Line Chart With X Values
					chart = New NCartesianChart()
					chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()

					Dim line As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
					line.UseXValues = True
					line.Values.FillRandom(Random, 10)
					line.Labels.FillRandom(Random, 10)

					Dim x As Double = 1
					For i As Integer = 0 To 9
						line.XValues.Add(x)
						x += Random.NextDouble() * 2 + 0.2
					Next i

					Exit Select

				Case 2 ' Pie Chart with detachments
					chart = New NPieChart()
					Dim pie As NPieSeries = CType(chart.Series.Add(SeriesType.Pie), NPieSeries)
					pie.Values.FillRandom(Random, 10)
					pie.Labels.FillRandom(Random, 10)

					For i As Integer = 0 To 9
						pie.FillStyles(i) = New NColorFillStyle(RandomColor())
						pie.Detachments.Add(5 + CDbl(Random.Next(20)))
					Next i

					Exit Select

				Case 3 ' Open - High - Low - Close
					chart = New NCartesianChart()
					chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NOrdinalScaleConfigurator()

					Dim stock As NStockSeries = CType(chart.Series.Add(SeriesType.Stock), NStockSeries)
					stock.DataLabelStyle.Visible = False
					GenerateOHLCData(stock, 300, 20)
					Exit Select
			End Select

			If TypeOf chart Is NCartesianChart Then
				CType(chart, NCartesianChart).BoundsMode = BoundsMode.Stretch
			End If

			chart.Location = New NPointL(New NLength(15, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage))
			nChartControl1.Panels.Add(chart)
			chart.DisplayOnLegend = nChartControl1.Legends(0)

			nChartControl1.Refresh()
		End Sub

		Private Sub ExportToDataTable_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExportToDataTable.Click
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim arrSeries As New NDataSeriesCollection()
			Dim sTableName As String = ""

			Select Case ChartCombo.SelectedIndex
				Case 0 ' Bar Chart
					Dim bar As NBarSeries = CType(chart.Series(0), NBarSeries)
					sTableName = "Bar Chart"

					arrSeries.Add(bar.Values, DataSeriesMask.Values)
					arrSeries.Add(bar.Labels, DataSeriesMask.Labels)

				Case 1 ' Line Chart With X Values
					Dim line As NLineSeries = CType(chart.Series(0), NLineSeries)
					sTableName = "Line Chart"

					arrSeries.Add(line.Values, DataSeriesMask.Values)
					arrSeries.Add(line.XValues, DataSeriesMask.XValues)
					arrSeries.Add(line.Labels, DataSeriesMask.Labels)

				Case 2 ' Pie Chart with detachments
					Dim pie As NPieSeries = CType(chart.Series(0), NPieSeries)
					sTableName = "Pie Chart"

					arrSeries.Add(pie.Values, DataSeriesMask.Values)
					arrSeries.Add(pie.Detachments, DataSeriesMask.PieDetachments)
					arrSeries.Add(pie.Labels, DataSeriesMask.Labels)

				Case 3 ' Open - High - Low - Close
					Dim stock As NStockSeries = CType(chart.Series(0), NStockSeries)
					sTableName = "Stock Chart"

					arrSeries.Add(stock.OpenValues, DataSeriesMask.StockOpenValues)
					arrSeries.Add(stock.HighValues, DataSeriesMask.StockHighValues)
					arrSeries.Add(stock.LowValues, DataSeriesMask.StockLowValues)
					arrSeries.Add(stock.CloseValues, DataSeriesMask.StockCloseValues)
			End Select

			dataView1.Table = arrSeries.ExportToDataTable(sTableName)

			nChartControl1.Refresh()
		End Sub

	End Class
End Namespace
