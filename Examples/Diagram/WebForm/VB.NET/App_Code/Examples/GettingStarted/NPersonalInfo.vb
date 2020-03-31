Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	''' Summary description for NPersonalInfo.
	''' </summary>
	Public Class NPersonalInfo
'INSTANT VB NOTE: The parameter id was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter level was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter name was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter position was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter picture was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter biography was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter bounds was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter bottomPortAlignment was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
		Public Sub New(ByVal id_Renamed As Integer, ByVal level_Renamed As Integer, ByVal name_Renamed As String, ByVal position_Renamed As String, ByVal picture_Renamed As String, ByVal biography_Renamed As String, ByVal bounds_Renamed As NRectangleF, ByVal bottomPortAlignment_Renamed As Single)
			Me.Id = id_Renamed
			Me.Level = level_Renamed
			Me.Name = name_Renamed
			Me.Position = position_Renamed
			Me.Picture = picture_Renamed
			Me.Biography = biography_Renamed

			Me.Bounds = bounds_Renamed
			Me.BottomPortAlignment = bottomPortAlignment_Renamed
		End Sub

		' person related
		Public Id As Integer
		Public Level As Integer
		Public Name As String
		Public Position As String
		Public Picture As String
		Public Biography As String

		' diagram related
		Public Bounds As NRectangleF
		Public BottomPortAlignment As Single

		Public Shared Function CreateCompanyInfo() As NPersonalInfo()
			Dim personalInfo As NPersonalInfo() = New NPersonalInfo(9){}

			Dim biograhy As String = "William Smith graduated from NYC with a BSC degree in 1990.  He founded the company in 1998.  Mr. Smith business skills quickly made the company profitable. He speaks fluently French and German."
			personalInfo(0) = New NPersonalInfo(0, 0, "William Smith", "President", "~\Images\man2.jpg", biograhy, New NRectangleF(305, 70, 190, 110), -8)

			biograhy = "Charlie Good graduated from Washington university with a BSC degree in 1995.  He joined the company in 2001 and his skills in marketing were quickly recognized."
			personalInfo(1) = New NPersonalInfo(1, 1, "Charlie Good", "VP Marketing", "~\Images\man1.jpg", biograhy, New NRectangleF(60, 220, 190, 110), -45)

			biograhy = "Kevin Taylor graduated from Colorado university with a BSC degree in 1990.  He joined the company in 1999. Kevin likes to ski and surf when he's not working overtime."
			personalInfo(2) = New NPersonalInfo(2, 1, "Kevin Tylor", "VP Sales", "~\Images\man4.jpg", biograhy, New NRectangleF(290, 220, 190, 110), -45)

			biograhy = "Patricia Holgate has a BA degree from St. Lawrence College. Patricia has in depth knowledge in production. She loves music and sports."
			personalInfo(3) = New NPersonalInfo(3, 1, "Patricia Holgate", "VP Production", "~\Images\woman3.jpg", biograhy, New NRectangleF(520, 220, 190, 110), -45)

			biograhy = "Peter Marchall has a BS degree in chemistry from Boston College (1988)."
			personalInfo(4) = New NPersonalInfo(5, 2, "Peter Marshall", "Manager", "~\Images\man3.jpg", biograhy, New NRectangleF(90, 350, 190, 110), 0)

			biograhy = "Tracy Chapmann is a graduate of Sussex University (MA, economics).  She has also taken the courses 'Multi-Cultural Selling' and 'Time Management for the Sales Professional'. She is fluent in Japanese."
			personalInfo(5) = New NPersonalInfo(6, 2, "Tracy Chapmann", "Manager", "~\Images\woman1.jpg", biograhy, New NRectangleF(90, 480, 190, 110), 0)

			biograhy = "Jane Buckley has a degree in international marketing from the University of Colorado.  She joined the company as a sales representative and was promoted to sales manager."
			personalInfo(6) = New NPersonalInfo(7, 2, "Jane Buckley", "Manager", "~\Images\woman2.jpg", biograhy, New NRectangleF(320, 350, 190, 110), 0)

			biograhy = "Dave Zak joined the company after completing his military service in 1997. He has also taken the courses 'Multi-Cultural Selling' and 'Time Management for the Sales Professional'."
			personalInfo(7) = New NPersonalInfo(8, 2, "Dave Zak", "Manager", "~\Images\man5.jpg", biograhy, New NRectangleF(320, 480, 190, 110), 0)

			biograhy = "Stephen Maule has a BA degree in Marketing from St. Christopher College.  He is fluent in French and German."
			personalInfo(8) = New NPersonalInfo(9, 2, "Stephen Maule", "Manager", "~\Images\man7.jpg", biograhy, New NRectangleF(550, 350, 190, 110), 0)

			biograhy = "Steve Tucker has a BA degree in Economics from the university of London.  He is fluent in French and German."
			personalInfo(9) = New NPersonalInfo(10, 2, "Steve Tucker", "Manager", "~\Images\man6.jpg", biograhy, New NRectangleF(550, 480, 190, 110), 0)

			Return personalInfo
		End Function
	End Class
End Namespace
