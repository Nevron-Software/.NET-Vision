Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls


Namespace Nevron.Examples.Diagram.Webform
	Public Class NCustomToolsData
		#Region "Nested Classes"

		Public Class NBookEntry
'INSTANT VB NOTE: The parameter id was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter title was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter author was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter price was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter rating was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter thumbnailFile was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter imageFile was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
			Public Sub New(ByVal id_Renamed As Integer, ByVal title_Renamed As String, ByVal author_Renamed As String, ByVal price_Renamed As Single, ByVal rating_Renamed As Integer, ByVal thumbnailFile_Renamed As String, ByVal imageFile_Renamed As String)
				Id = id_Renamed
				Title = title_Renamed
				Author = author_Renamed
				Price = price_Renamed
				Rating = rating_Renamed
				ThumbnailFile = thumbnailFile_Renamed
				ImageFile = imageFile_Renamed
			End Sub

			Public Id As Integer
			Public Title As String
			Public Author As String
			Public Price As Single
			Public Rating As Integer
			Public ThumbnailFile As String
			Public ImageFile As String
		End Class

		#End Region

		Public Shared Function CreateBooks() As NBookEntry()
			Dim books As NBookEntry() = { New NBookEntry(0, "The Lord of the Rings", "J.R.R. Tolkien", 19.80f, 5, "tolkien_the_lord_of_the_rings.jpg", "tolkien_the_lord_of_the_rings1.jpg"), New NBookEntry(1, "The History of the Hobbit", "John D. Rateliff", 59.85f, 5, "John_Rateliff_the_history_of_the_hobbit.jpg", "John_Rateliff_the_history_of_the_hobbit1.jpg"), New NBookEntry(2, "J.R.R. Tolkien Boxed Set", "J.R.R. Tolkien", 19.77f, 4, "tokien_box_set.jpg", "tokien_box_set1.jpg"), New NBookEntry(3, "The Hobbit", "J.R.R. Tolkien", 8.00f, 4, "tokien_the_hobbit.jpg", "tokien_the_hobbit1.jpg"), New NBookEntry(4, "The Annotated Hobbit", "J.R.R. Tolkien", 19.80f, 4, "tolkien_The_Annotated_Hobbit.jpg", "tolkien_The_Annotated_Hobbit1.jpg"), New NBookEntry(5, "The Complete Guide to Middle-Earth", "Robert Foster", 10.17f, 4, "robert_foster_the_complete_guide_to_middle_earth.jpg", "robert_foster_the_complete_guide_to_middle_earth1.jpg"), New NBookEntry(6, "Unfinished Tales: The Lost Lore of Middle-earth", "J.R.R. Tolkien", 7.99f, 4, "tokien_unfinished_tails.jpg", "tokien_unfinished_tails1.jpg"), New NBookEntry(7, "The Children of Hu'rin", "J.R.R. Tolkien", 9.08f, 4, "tokien_children_of_hurin.jpg", "tokien_children_of_hurin1.jpg"), New NBookEntry(8, "Sir Gawain and the Green Knight, Pearl, Sir Orfeo", "J.R.R. Tolkien", 6.99f, 4, "tokien_Sir_Gawain_and_the_Green_Knight.jpg", "tokien_Sir_Gawain_and_the_Green_Knight1.jpg"), New NBookEntry(9, "The Tolkien Reader", "J.R.R. Tolkien", 7.99f, 4, "tokien_the_tolkien_reader.jpg", "tokien_the_tolkien_reader1.jpg"), New NBookEntry(10, "Roverandom", "J.R.R. Tolkien", 12.69f, 4, "tolkien_roverandom.jpg", "tolkien_roverandom1.jpg"), New NBookEntry(11, "The Lost Road and Other Writings", "J.R.R. Tolkien", 19.80f, 4, "tolkien_The_Lost_Road.jpg", "tolkien_The_Lost_Road1.jpg") }

			Return books
		End Function
	End Class
End Namespace
