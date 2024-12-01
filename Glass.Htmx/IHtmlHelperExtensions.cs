using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Glass.Htmx
{
    public static  class IHtmlHelperExtensions
    {
        public static IHtmlContent Htmx(this IHtmlHelper helper, Action<HtmxAttributeBuilder> build)
        {
            var builder = new HtmxAttributeBuilder();
            build(builder);
            return new HtmlString(builder.Build());
        }
    }
}
