using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Nevron.Examples.Diagram.Webform.GettingStarted
{
	/// <summary>
	/// Summary description for NPersonalInfoPage.
	/// </summary>
	public partial class NPersonalInfoPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			int id = Int32.Parse(HttpContext.Current.Request.QueryString.Get(0));

			NPersonalInfo[] personalInfos =  NPersonalInfo.CreateCompanyInfo();
			NPersonalInfo personalInfo = null;

			// find the personal info by id

			for (int i = 0; i < personalInfos.Length; i++)
			{
				if (personalInfos[i].Id == id)
				{
					personalInfo = personalInfos[i];
					break;
				}
			}

			if (personalInfo != null)
			{
				NameLabel.Text = "This is the personal page of: " + personalInfo.Name;
				PositionLabel.Text = "Position in company: " + personalInfo.Position;
				BiographyLabel.Text = "Bigoraphy: " + personalInfo.Biography;
				PersonPicture.ImageUrl = personalInfo.Picture;
			}
		}
	}
}
