using System.Web.Mvc;

namespace Nevron.Examples.Chart.Mvc
{
    public class ExamplesController : Controller
    {
        public ExamplesController()
        {

        }

        protected override void Execute(System.Web.Routing.RequestContext requestContext)
        {
            base.Execute(requestContext);
        }

        /// <summary>
        /// Renders the initial content of the chart on the page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View("Home");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public ActionResult Example(string url, string title)
        {
            if (url != null && url.Length > 0)
            {
                return View(url);
            }
            else
            {
                return View("Home");
            }

//            return Redirect(this."/Views/Examples/" + url + ".aspx");
        }
    }
}