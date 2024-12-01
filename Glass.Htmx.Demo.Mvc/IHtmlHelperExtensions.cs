using Glass.Htmx.Demo.Mvc.Views.Shared;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Glass.Htmx.Demo.Mvc
{
    public static class IHtmlHelperExtensions
    {
        public static Shared Shared(this IHtmlHelper helper)
        {
            return new Shared(helper);
        }
    }
}
