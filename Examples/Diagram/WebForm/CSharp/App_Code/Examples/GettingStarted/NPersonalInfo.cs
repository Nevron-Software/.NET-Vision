using System;
using System.Drawing;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	/// Summary description for NPersonalInfo.
	/// </summary>
	public class NPersonalInfo
	{
		public NPersonalInfo(int id, int level, string name, string position, string picture, string biography, NRectangleF bounds, float bottomPortAlignment)
		{
			this.Id = id;
			this.Level = level;
			this.Name = name;
			this.Position = position;
			this.Picture = picture;
			this.Biography = biography;

			this.Bounds = bounds;
			this.BottomPortAlignment = bottomPortAlignment;
		}

		// person related
		public int Id;
		public int Level;
		public string Name;
		public string Position;
		public string Picture;
		public string Biography;

		// diagram related
		public NRectangleF Bounds;
		public float BottomPortAlignment;

		public static NPersonalInfo[] CreateCompanyInfo()
		{
			NPersonalInfo[] personalInfo = new NPersonalInfo[10];

			string biograhy = "William Smith graduated from NYC with a BSC degree in 1990.  He founded the company in 1998.  Mr. Smith business skills quickly made the company profitable. He speaks fluently French and German.";
			personalInfo[0] = new NPersonalInfo(0, 0, "William Smith", "President", "~\\Images\\man2.jpg", biograhy, new NRectangleF(305, 70, 190, 110), -8);

			biograhy = "Charlie Good graduated from Washington university with a BSC degree in 1995.  He joined the company in 2001 and his skills in marketing were quickly recognized.";
			personalInfo[1] = new NPersonalInfo(1, 1, "Charlie Good", "VP Marketing", "~\\Images\\man1.jpg", biograhy, new NRectangleF(60, 220, 190, 110), -45);

			biograhy = "Kevin Taylor graduated from Colorado university with a BSC degree in 1990.  He joined the company in 1999. Kevin likes to ski and surf when he's not working overtime.";
			personalInfo[2] = new NPersonalInfo(2, 1, "Kevin Tylor", "VP Sales", "~\\Images\\man4.jpg", biograhy, new NRectangleF(290, 220, 190, 110), -45);

			biograhy = "Patricia Holgate has a BA degree from St. Lawrence College. Patricia has in depth knowledge in production. She loves music and sports.";
			personalInfo[3] = new NPersonalInfo(3, 1, "Patricia Holgate", "VP Production", "~\\Images\\woman3.jpg", biograhy, new NRectangleF(520, 220, 190, 110), -45);

			biograhy = "Peter Marchall has a BS degree in chemistry from Boston College (1988).";
			personalInfo[4] = new NPersonalInfo(5, 2, "Peter Marshall", "Manager", "~\\Images\\man3.jpg", biograhy, new NRectangleF(90, 350, 190, 110), 0);

			biograhy = "Tracy Chapmann is a graduate of Sussex University (MA, economics).  She has also taken the courses 'Multi-Cultural Selling' and 'Time Management for the Sales Professional'. She is fluent in Japanese.";
			personalInfo[5] = new NPersonalInfo(6, 2, "Tracy Chapmann", "Manager", "~\\Images\\woman1.jpg", biograhy, new NRectangleF(90, 480, 190, 110), 0);
				
			biograhy = "Jane Buckley has a degree in international marketing from the University of Colorado.  She joined the company as a sales representative and was promoted to sales manager.";
			personalInfo[6] = new NPersonalInfo(7, 2, "Jane Buckley", "Manager", "~\\Images\\woman2.jpg", biograhy, new NRectangleF(320, 350, 190, 110), 0);

			biograhy = "Dave Zak joined the company after completing his military service in 1997. He has also taken the courses 'Multi-Cultural Selling' and 'Time Management for the Sales Professional'.";
			personalInfo[7] = new NPersonalInfo(8, 2, "Dave Zak", "Manager", "~\\Images\\man5.jpg", biograhy, new NRectangleF(320, 480, 190, 110), 0);

			biograhy = "Stephen Maule has a BA degree in Marketing from St. Christopher College.  He is fluent in French and German.";
			personalInfo[8] = new NPersonalInfo(9, 2, "Stephen Maule", "Manager", "~\\Images\\man7.jpg", biograhy, new NRectangleF(550, 350, 190, 110), 0);

			biograhy = "Steve Tucker has a BA degree in Economics from the university of London.  He is fluent in French and German.";
			personalInfo[9] = new NPersonalInfo(10, 2, "Steve Tucker", "Manager", "~\\Images\\man6.jpg", biograhy, new NRectangleF(550, 480, 190, 110), 0);

			return personalInfo;
		}
	}
}
