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
	Public Class NImportingFromDataReaderUC
		Inherits NExampleBaseUC

		Private WithEvents ClearChart As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ImportFromDatabase As Nevron.UI.WinForm.Controls.NButton
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
			Me.ImportFromDatabase = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' ClearChart
			' 
			Me.ClearChart.Location = New System.Drawing.Point(3, 8)
			Me.ClearChart.Name = "ClearChart"
			Me.ClearChart.Size = New System.Drawing.Size(174, 24)
			Me.ClearChart.TabIndex = 0
			Me.ClearChart.Text = "Clear Chart"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ClearChart.Click += new System.EventHandler(this.ClearChart_Click);
			' 
			' ImportFromDatabase
			' 
			Me.ImportFromDatabase.Location = New System.Drawing.Point(3, 40)
			Me.ImportFromDatabase.Name = "ImportFromDatabase"
			Me.ImportFromDatabase.Size = New System.Drawing.Size(174, 23)
			Me.ImportFromDatabase.TabIndex = 1
			Me.ImportFromDatabase.Text = "Import From Database"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ImportFromDatabase.Click += new System.EventHandler(this.ImportFromDatabase_Click);
			' 
			' NImportingFromDataReaderUC
			' 
			Me.Controls.Add(Me.ImportFromDatabase)
			Me.Controls.Add(Me.ClearChart)
			Me.Name = "NImportingFromDataReaderUC"
			Me.Size = New System.Drawing.Size(180, 112)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			InitTitleAndBackground()
		End Sub

		Private Sub InitTitleAndBackground()
			' add a title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Import from Data Reader")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 20, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.Solid
			title.TextStyle.ShadowStyle.Color = Color.White
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
		End Sub

		Private Sub ImportFromDatabase_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImportFromDatabase.Click
			nChartControl1.Clear()

			InitTitleAndBackground()

			Dim myConnection As OleDbConnection = Nothing
			Dim myReader As OleDbDataReader = Nothing

			Try
				' create a database connection object using the connection string 
				myConnection = New OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\..\..\DataManipulation\Importing\DataBinding.mdb")

				' create a database command on the connection using query 
				Dim myCommand As New OleDbCommand("select * from Sales", myConnection)

				' create a bar chart
				Dim chart As NChart = nChartControl1.Charts(0)
				Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
				bar.Legend.Mode = SeriesLegendMode.DataPoints

				' import the SalesAmount and ProductName into the bar Values and Labels
				myCommand.Connection.Open()
				myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)

				Dim arrSeries As NDataSeriesCollection = bar.GetDataSeries(DataSeriesMask.Values Or DataSeriesMask.Labels, DataSeriesMask.None, False)
				Dim arrCollumns() As String = { "SalesAmount", "ProductName" }

				arrSeries.FillFromDataReader(myReader, arrCollumns)
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			Finally
				If myReader IsNot Nothing Then
					myReader.Close()
				End If

				If myConnection IsNot Nothing Then
					myConnection.Close()
				End If
			End Try

			nChartControl1.Refresh()
		End Sub

		Private Sub ClearChart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClearChart.Click
			nChartControl1.Clear()
			InitTitleAndBackground()
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
