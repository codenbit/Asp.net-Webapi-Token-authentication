using System.Web.Http.Controllers;
using System.Web.Mvc;


namespace OWinTokenAuth
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
    public class CustomAuthorizationFilterAttribute : System.Web.Http.AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var incomingPrincipal = actionContext.RequestContext.Principal;
            return false;
        }
    }
}
