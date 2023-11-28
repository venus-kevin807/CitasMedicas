using System.Web;
using System.Web.Mvc;

namespace PAGINA_SUCURSAL_MEDICA
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
