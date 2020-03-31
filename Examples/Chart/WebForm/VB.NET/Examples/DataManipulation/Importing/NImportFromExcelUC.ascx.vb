Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.Web.UI
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NImportFromDatabaseUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				ExcelFormatDropDown.Items.Add("XLS")
				ExcelFormatDropDown.Items.Add("XLSX")
			End If


			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Import from Excel File")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.ContentAlignment = ContentAlignment.BottomRight
			title.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			Dim chart As NCartesianChart = New NCartesianChart()

			Dim bar0 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar0.Legend.Mode = SeriesLegendMode.DataPoints
			Dim bar1 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar1.Legend.Mode = SeriesLegendMode.DataPoints
			bar1.MultiBarMode = MultiBarMode.Clustered

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)

			Dim fileName As String

			If ExcelFormatDropDown.SelectedIndex = 0 Then
				' Import from XLS
				fileName = Me.MapPathSecure(Me.TemplateSourceDirectory & "\Sample.xls")
			Else
				' Import from XLSX
				fileName = Me.MapPathSecure(Me.TemplateSourceDirectory & "\Sample.xlsx")
			End If

			Try
				Dim reader As NExcelReader = New NExcelReader()
				Dim dt As DataTable

				If ImportFromRangeCheckBox.Checked Then
					' Import range
					dt = reader.ReadRange(fileName, "Sample", "A1:E3").Tables(0)
				Else
					' Import whole sheet
					dt = reader.ReadAll(fileName).Tables(0)

				End If

				Dim columns As DataColumnCollection = dt.Columns
				nChartControl1.DataBindingManager.AddBinding(0, 0, "Values", dt, columns(1).ColumnName)
				nChartControl1.DataBindingManager.AddBinding(0, 0, "Labels", dt, columns(0).ColumnName)
				nChartControl1.DataBindingManager.AddBinding(0, 0, "FillStyles", dt, columns(3).ColumnName)

				nChartControl1.DataBindingManager.AddBinding(0, 1, "Values", dt, columns(2).ColumnName)
				nChartControl1.DataBindingManager.AddBinding(0, 1, "Labels", dt, columns(0).ColumnName)
				nChartControl1.DataBindingManager.AddBinding(0, 1, "FillStyles", dt, columns(4).ColumnName)
			Catch e1 As Exception
			End Try
		End Sub
	End Class
End Namespace
