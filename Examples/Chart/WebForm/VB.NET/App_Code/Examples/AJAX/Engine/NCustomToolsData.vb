Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Collections
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Namespace Nevron.Examples.Chart.WebForm
	Public Class NCustomToolsData
		#Region "Nested Classes"

		Public Class NData
			Public Sub ImportAgeRanges(ByVal rows As ArrayList)
				Dim length As Integer = rows.Count
				Dim i As Integer = 0
				Do While i < length
					Dim row As Dictionary(Of String, Integer) = TryCast(rows(i), Dictionary(Of String, Integer))
					Dim title As String
					Dim startAge As Integer = row("start age")
					Dim endAge As Integer = row("end age")

					If startAge = 0 Then
						title = String.Format("under {0}", endAge)
					ElseIf endAge >= 99 Then
						title = String.Format("{0}+", startAge)
					ElseIf startAge + 1 = endAge Then
						title = String.Format("{0}, {1}", startAge, endAge)
					Else
						title = String.Format("{0} to {1}", startAge, endAge)
					End If

					Dim ageRange As NAgeRange = New NAgeRange(i, title, startAge, endAge)
					AgeRanges.Add(ageRange)
					i += 1
				Loop
			End Sub

			Public Sub ImportRaces(ByVal rows As ArrayList)
				'	import all races
				Dim caucasian As NRace = New NRace(0, "Caucasian")
				Races.Add(caucasian)
				caucasian.MaleData.Import(AgeRanges, rows, "white male pop", "white male err")
				caucasian.FemaleData.Import(AgeRanges, rows, "white female pop", "white female err")

				Dim black As NRace = New NRace(1, "Black")
				Races.Add(black)
				black.MaleData.Import(AgeRanges, rows, "black male pop", "black male err")
				black.FemaleData.Import(AgeRanges, rows, "black female pop", "black female err")

				Dim nativeAmerican As NRace = New NRace(2, "Native American")
				Races.Add(nativeAmerican)
				nativeAmerican.MaleData.Import(AgeRanges, rows, "indian + alaska male pop", "indian + alaska male err")
				nativeAmerican.FemaleData.Import(AgeRanges, rows, "indian + alaska female pop", "indian + alaska female err")

				Dim asian As NRace = New NRace(3, "Asian")
				Races.Add(asian)
				asian.MaleData.Import(AgeRanges, rows, "asian male pop", "asian male err")
				asian.FemaleData.Import(AgeRanges, rows, "asian female pop", "asian female err")

				Dim pacificNatvies As NRace = New NRace(4, "Pacific Natives")
				Races.Add(pacificNatvies)
				pacificNatvies.MaleData.Import(AgeRanges, rows, "pacific male pop", "pacific male err")
				pacificNatvies.FemaleData.Import(AgeRanges, rows, "pacific female pop", "pacific female err")

				Dim otherSomeRace As NRace = New NRace(5, "Other Some Race")
				Races.Add(otherSomeRace)
				otherSomeRace.MaleData.Import(AgeRanges, rows, "race male pop", "race male err")
				otherSomeRace.FemaleData.Import(AgeRanges, rows, "race female pop", "race female err")

				Dim twoOrMoreRaces As NRace = New NRace(6, "Two or More Races")
				Races.Add(twoOrMoreRaces)
				twoOrMoreRaces.MaleData.Import(AgeRanges, rows, "mixed male pop", "mixed male err")
				twoOrMoreRaces.FemaleData.Import(AgeRanges, rows, "mixed female pop", "mixed female err")

				'	calculate the totals
				Dim rowsLength As Integer = rows.Count
				Dim j As Integer = 0
				Do While j < rowsLength
					Dim totalMalePopulation As Integer = 0
					Dim totalFemalePopulation As Integer = 0
					Dim totalMaleError As Integer = 0
					Dim totalFemaleError As Integer = 0

					Dim racesLength As Integer = Races.Count
					Dim i As Integer = 0
					Do While i < racesLength
						totalMalePopulation += Races(i).MaleData.Rows(j).Value
						totalFemalePopulation += Races(i).FemaleData.Rows(j).Value
						totalMaleError += Races(i).MaleData.Rows(j).Error
						totalFemaleError += Races(i).FemaleData.Rows(j).Error
						i += 1
					Loop

					TotalMaleData.Rows.Add(New NPopulationDataEntry(AgeRanges(j), totalMalePopulation, totalMaleError))
					TotalFemaleData.Rows.Add(New NPopulationDataEntry(AgeRanges(j), totalFemalePopulation, totalFemaleError))
					j += 1
				Loop
			End Sub

			Public AgeRanges As List(Of NAgeRange) = New List(Of NAgeRange)()
			Public Races As List(Of NRace) = New List(Of NRace)()

			Public TotalMaleData As NPopulationData = New NPopulationData(0, "Male")
			Public TotalFemaleData As NPopulationData = New NPopulationData(1, "Female")
		End Class

		Public Class NRace
'INSTANT VB NOTE: The parameter id was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter title was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
			Public Sub New(ByVal id_Renamed As Integer, ByVal title_Renamed As String)
				Id = id_Renamed
				Title = title_Renamed
			End Sub

			Public Id As Integer
			Public Title As String

			Public MaleData As NPopulationData = New NPopulationData(0, "Male")
			Public FemaleData As NPopulationData = New NPopulationData(1, "Female")
		End Class

		Public Class NPopulationData
'INSTANT VB NOTE: The parameter id was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter title was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
			Public Sub New(ByVal id_Renamed As Integer, ByVal title_Renamed As String)
				Id = id_Renamed
				Title = title_Renamed
			End Sub

'INSTANT VB NOTE: The parameter rows was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
			Public Sub Import(ByVal ageRanges As List(Of NAgeRange), ByVal rows_Renamed As ArrayList, ByVal valueColumn As String, ByVal errorColumn As String)
				Dim length As Integer = rows_Renamed.Count
				Dim i As Integer = 0
				Do While i < length
					Dim ageRange As NAgeRange = ageRanges(i)
					Dim row As Dictionary(Of String, Integer) = TryCast(rows_Renamed(i), Dictionary(Of String, Integer))

					Rows.Add(New NPopulationDataEntry(ageRange, row(valueColumn), row(errorColumn)))
					i += 1
				Loop
			End Sub

			Public Id As Integer
			Public Title As String

			Public Rows As List(Of NPopulationDataEntry) = New List(Of NPopulationDataEntry)()
		End Class

		Public Class NAgeRange
'INSTANT VB NOTE: The parameter id was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter title was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter start was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter end was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
			Public Sub New(ByVal id_Renamed As Integer, ByVal title_Renamed As String, ByVal start_Renamed As Integer, ByVal end_Renamed As Integer)
				Id = id_Renamed
				Title = title_Renamed
				Start = start_Renamed
				[End] = end_Renamed
			End Sub

			Public Id As Integer
			Public Title As String
			Public Start As Integer
			Public [End] As Integer
		End Class

		Public Class NPopulationDataEntry
'INSTANT VB NOTE: The parameter ageRange was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter value was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter error was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
			Public Sub New(ByVal ageRange_Renamed As NAgeRange, ByVal value_Renamed As Integer, ByVal error_Renamed As Integer)
				AgeRange = ageRange_Renamed
				Value = value_Renamed
				[Error] = error_Renamed
			End Sub

			Public AgeRange As NAgeRange
			Public Value As Integer
			Public [Error] As Integer
		End Class

		#End Region

		Public Shared Function Read() As NData
			' setup ole db connection
			Dim connectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & HttpContext.Current.Server.MapPath("~\App_Data\demographicData.xls") & ";Extended Properties=Excel 8.0;"

			Dim oleDbConnection1 As OleDbConnection = New OleDbConnection(connectionString)

			Dim oleDbCommand1 As OleDbCommand = New OleDbCommand("SELECT * From [SHEET$]", oleDbConnection1)
			Dim oleDbDataReader1 As OleDbDataReader = Nothing

			Dim rows As ArrayList = New ArrayList()
			Try
				' execute the select command
				oleDbConnection1.Open()
				oleDbDataReader1 = oleDbCommand1.ExecuteReader()

				Do While oleDbDataReader1.Read()
					If oleDbDataReader1("start age") Is DBNull.Value Then
						Exit Do
					End If

					Dim row As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)()
					rows.Add(row)

					ReadField(oleDbDataReader1, row, "start age")
					ReadField(oleDbDataReader1, row, "end age")
					ReadField(oleDbDataReader1, row, "white male pop")
					ReadField(oleDbDataReader1, row, "white male err")
					ReadField(oleDbDataReader1, row, "white female pop")
					ReadField(oleDbDataReader1, row, "white female err")
					ReadField(oleDbDataReader1, row, "black male pop")
					ReadField(oleDbDataReader1, row, "black male err")
					ReadField(oleDbDataReader1, row, "black female pop")
					ReadField(oleDbDataReader1, row, "black female err")
					ReadField(oleDbDataReader1, row, "indian + alaska male pop")
					ReadField(oleDbDataReader1, row, "indian + alaska male err")
					ReadField(oleDbDataReader1, row, "indian + alaska female pop")
					ReadField(oleDbDataReader1, row, "indian + alaska female err")
					ReadField(oleDbDataReader1, row, "asian male pop")
					ReadField(oleDbDataReader1, row, "asian male err")
					ReadField(oleDbDataReader1, row, "asian female pop")
					ReadField(oleDbDataReader1, row, "asian female err")
					ReadField(oleDbDataReader1, row, "pacific male pop")
					ReadField(oleDbDataReader1, row, "pacific male err")
					ReadField(oleDbDataReader1, row, "pacific female pop")
					ReadField(oleDbDataReader1, row, "pacific female err")
					ReadField(oleDbDataReader1, row, "race male pop")
					ReadField(oleDbDataReader1, row, "race male err")
					ReadField(oleDbDataReader1, row, "race female pop")
					ReadField(oleDbDataReader1, row, "race female err")
					ReadField(oleDbDataReader1, row, "mixed male pop")
					ReadField(oleDbDataReader1, row, "mixed male err")
					ReadField(oleDbDataReader1, row, "mixed female pop")
					ReadField(oleDbDataReader1, row, "mixed female err")
				Loop
			Finally
				If Not oleDbDataReader1 Is Nothing Then
					oleDbDataReader1.Close()
				End If

				If Not oleDbConnection1 Is Nothing Then
					oleDbConnection1.Close()
				End If
			End Try

			'	build the data structures
			Dim data As NData = New NData()
			data.ImportAgeRanges(rows)
			data.ImportRaces(rows)

			Return data
		End Function

		Private Shared Sub ReadField(ByVal oleDbDataReader As OleDbDataReader, ByVal row As Dictionary(Of String, Integer), ByVal columnName As String)
			Dim obj As Object = oleDbDataReader(columnName)
			If obj Is DBNull.Value Then
				row.Add(columnName, -1)
			Else
				row.Add(columnName, Integer.Parse(obj.ToString()))
			End If
		End Sub
	End Class
End Namespace