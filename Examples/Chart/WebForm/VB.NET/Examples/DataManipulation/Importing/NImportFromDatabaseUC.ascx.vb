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
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.FillStyle.SetTransparencyPercent(50)
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Bottom)
			legend.Data.ExpandMode = LegendExpandMode.RowsFixed
			legend.Data.RowCount = 2

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Import from Data Reader")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.ContentAlignment = ContentAlignment.BottomRight
			title.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Width = 100.0f
			chart.Height = 65.0f
			chart.BoundsMode = BoundsMode.Stretch
			chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(20, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(58, NRelativeUnit.ParentPercentage))

			' create a bar chart
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.DataLabelStyle.Visible = False
			bar.Legend.Mode = SeriesLegendMode.DataPoints

			Dim myConnection As OleDbConnection = Nothing
			Dim myReader As OleDbDataReader = Nothing

			Try
				' create a database connection object using the connection string 
				myConnection = New OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" & Me.MapPathSecure(Me.TemplateSourceDirectory & "\DataBinding.mdb"))

				' create a database command on the connection using query 
				Dim myCommand As OleDbCommand = New OleDbCommand("select * from Sales", myConnection)

				' import the SalesAmount and ProductName into the bar Values and Labels
				myCommand.Connection.Open()
				myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)

				Dim arrSeries As NDataSeriesCollection = bar.GetDataSeries(DataSeriesMask.Values Or DataSeriesMask.Labels, DataSeriesMask.None, False)
				Dim arrCollumns As String() = { "SalesAmount", "ProductName" }

				arrSeries.FillFromDataReader(myReader, arrCollumns)
			Finally
				If Not myReader Is Nothing Then
					myReader.Close()
				End If

				If Not myConnection Is Nothing Then
					myConnection.Close()
				End If
			End Try

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)
		End Sub
	End Class
End Namespace
