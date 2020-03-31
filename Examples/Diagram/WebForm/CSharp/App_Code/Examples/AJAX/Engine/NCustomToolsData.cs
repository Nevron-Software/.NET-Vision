using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


namespace Nevron.Examples.Diagram.Webform
{
	public class NCustomToolsData
	{
		#region Nested Classes

		public class NBookEntry
		{
			public NBookEntry(int id, string title, string author, float price, int rating, string thumbnailFile, string imageFile)
			{
				Id = id;
				Title = title;
				Author = author;
				Price = price;
				Rating = rating;
				ThumbnailFile = thumbnailFile;
				ImageFile = imageFile;
			}

			public int Id;
			public string Title;
			public string Author;
			public float Price;
			public int Rating;
			public string ThumbnailFile;
			public string ImageFile;
		}

		#endregion

		public static NBookEntry[] CreateBooks()
		{
			NBookEntry[] books = 
			{
				new NBookEntry(0, "The Lord of the Rings", "J.R.R. Tolkien", 19.80f, 5, "tolkien_the_lord_of_the_rings.jpg", "tolkien_the_lord_of_the_rings1.jpg"),
				new NBookEntry(1, "The History of the Hobbit", "John D. Rateliff", 59.85f, 5, "John_Rateliff_the_history_of_the_hobbit.jpg", "John_Rateliff_the_history_of_the_hobbit1.jpg"),
				new NBookEntry(2, "J.R.R. Tolkien Boxed Set", "J.R.R. Tolkien", 19.77f, 4, "tokien_box_set.jpg", "tokien_box_set1.jpg"),
				new NBookEntry(3, "The Hobbit", "J.R.R. Tolkien", 8.00f, 4, "tokien_the_hobbit.jpg", "tokien_the_hobbit1.jpg"),
				new NBookEntry(4, "The Annotated Hobbit", "J.R.R. Tolkien", 19.80f, 4, "tolkien_The_Annotated_Hobbit.jpg", "tolkien_The_Annotated_Hobbit1.jpg"),
				new NBookEntry(5, "The Complete Guide to Middle-Earth", "Robert Foster", 10.17f, 4, "robert_foster_the_complete_guide_to_middle_earth.jpg", "robert_foster_the_complete_guide_to_middle_earth1.jpg"),
				new NBookEntry(6, "Unfinished Tales: The Lost Lore of Middle-earth", "J.R.R. Tolkien", 7.99f, 4, "tokien_unfinished_tails.jpg", "tokien_unfinished_tails1.jpg"),
				new NBookEntry(7, "The Children of Hu'rin", "J.R.R. Tolkien", 9.08f, 4, "tokien_children_of_hurin.jpg", "tokien_children_of_hurin1.jpg"),
				new NBookEntry(8, "Sir Gawain and the Green Knight, Pearl, Sir Orfeo", "J.R.R. Tolkien", 6.99f, 4, "tokien_Sir_Gawain_and_the_Green_Knight.jpg", "tokien_Sir_Gawain_and_the_Green_Knight1.jpg"),
				new NBookEntry(9, "The Tolkien Reader", "J.R.R. Tolkien", 7.99f, 4, "tokien_the_tolkien_reader.jpg", "tokien_the_tolkien_reader1.jpg"),
				new NBookEntry(10, "Roverandom", "J.R.R. Tolkien", 12.69f, 4, "tolkien_roverandom.jpg", "tolkien_roverandom1.jpg"),
				new NBookEntry(11, "The Lost Road and Other Writings", "J.R.R. Tolkien", 19.80f, 4, "tolkien_The_Lost_Road.jpg", "tolkien_The_Lost_Road1.jpg"),
			};

			return books;
		}
	}
}
