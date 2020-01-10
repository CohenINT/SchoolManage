using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;

namespace SchoolManage
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
