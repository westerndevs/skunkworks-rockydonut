using System.Web;
using System.Web.Mvc;

namespace WesternDevs.RockyDonut.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
