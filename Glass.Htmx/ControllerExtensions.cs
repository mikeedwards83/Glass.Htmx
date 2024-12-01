using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;

namespace Glass.Htmx
{
    public static class ControllerExtensions
    {
        public static IActionResult View<T>(this T controller, Action<HtmxResponseBuilder> htmxResponseBuild) where T : Controller
        {
            var htmxResponseBuilder = new HtmxResponseBuilder(controller.Response);
            htmxResponseBuild(htmxResponseBuilder);

            return controller.View();
        }

        public static IActionResult View<T>(this T controller, string viewName, Action<HtmxResponseBuilder> htmxResponseBuild) where T : Controller
        { 
            var htmxResponseBuilder = new HtmxResponseBuilder(controller.Response);
            htmxResponseBuild(htmxResponseBuilder);

            return controller.View(viewName);
        }

        public static IActionResult View<T>(this T controller, object? model, Action<HtmxResponseBuilder> htmxResponseBuild) where T : Controller
        {
            var htmxResponseBuilder = new HtmxResponseBuilder(controller.Response);
            htmxResponseBuild(htmxResponseBuilder);

            return controller.View(model);
        }

        public static IActionResult View<T>(this T controller, string viewName, object? model, Action<HtmxResponseBuilder> htmxResponseBuild) where T : Controller
        {
            var htmxResponseBuilder = new HtmxResponseBuilder(controller.Response);
            htmxResponseBuild(htmxResponseBuilder);

            return controller.View(viewName, model);
        }
    }
}
