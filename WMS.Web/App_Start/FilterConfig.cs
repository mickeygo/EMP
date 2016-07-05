using System.Web.Mvc;

namespace WMS
{
    /// <summary>
    /// 筛选器配置，注册全局筛选器
    /// </summary>
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
