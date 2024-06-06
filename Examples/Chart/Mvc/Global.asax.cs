using System.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Nevron.Examples.Chart.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			// Nevron.NLicenseManager.Instance.SetLicense(new Nevron.NLicense("licensekey1, licensekey2"));

			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			// Code that runs on application startup
			string theme = ConfigurationManager.AppSettings.Get("defaultTheme");
			Application.Add("themeName", theme);
		}
	}
}
