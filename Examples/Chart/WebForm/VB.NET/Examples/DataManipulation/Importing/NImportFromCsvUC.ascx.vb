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
Imports Nevron.Chart.CSVReader

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NImportFromDatabaseUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Import from CSV File")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.ContentAlignment = ContentAlignment.BottomRight
			title.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			Dim chart As NCartesianChart = New NCartesianChart()

			Dim bar0 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar0.Legend.Mode = SeriesLegendMode.DataPoints
			'bar0.FillStyle = new NColorFillStyle(Color.Aquamarine);
			Dim bar1 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar1.Legend.Mode = SeriesLegendMode.DataPoints
			'bar0.FillStyle = new NColorFillStyle(Color.BurlyWood);
			bar1.MultiBarMode = MultiBarMode.Clustered

			Dim csvFile As String = Me.MapPathSecure(Me.TemplateSourceDirectory & "\Sample.csv")

			Dim reader As NCsvReader = New NCsvReader()
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

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)

			' import
			Try
				Dim dt As DataTable = reader.LoadDataTableFromFile(csvFile)
				nChartControl1.DataBindingManager.AddBinding(0, 0, "Values", dt, "Double Column")
				nChartControl1.DataBindingManager.AddBinding(0, 0, "Labels", dt, "String Column")
				nChartControl1.DataBindingManager.AddBinding(0, 0, "FillStyles", dt, "Color0 Column")

				nChartControl1.DataBindingManager.AddBinding(0, 1, "Values", dt, "Decimal Column")
				nChartControl1.DataBindingManager.AddBinding(0, 1, "Labels", dt, "String Column")
				nChartControl1.DataBindingManager.AddBinding(0, 1, "FillStyles", dt, "Color1 Column")
			Catch e1 As Exception

			End Try
		End Sub
	End Class
End Namespace
