using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nevron.Examples.Framework.WebForm;

namespace Nevron.Examples.Chart.Mvc
{
	public class NTabController : Controller
	{
		/// <summary>
		/// Renders the content of a single tab 
		/// </summary>
		/// <param name="title"></param>
		/// <returns></returns>
		public ActionResult TabContent(string title)
		{
			ContentResult content = new ContentResult();

			NTabStrip tabStrip = new NTabStrip();

			NTab tab = new NTab();
			tab.TabText = title;
			tabStrip.AddTab(tab);

			content.Content = tabStrip.GetHtml();
			content.ContentType = "text/html";
			return content;
		}
	}
}