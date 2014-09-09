using System.Web;
using System.Web.Mvc;
using VDABMovies.Filters;

namespace VDABMovies
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new VDABAuthorizationFilterAttribute());
        }
    }
}
