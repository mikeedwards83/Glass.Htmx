using Glass.Htmx.Demo.Mvc.Views.Shared.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Glass.Htmx.Demo.Mvc.Views.Shared
{
    public class Shared
    {
        private readonly IHtmlHelper _htmlHelper;

        public Shared(IHtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }

        public Task<IHtmlContent> PageHeader(PageHeaderView view)
        {
            return _htmlHelper.PartialAsync("_PageHeader", view);
        }

        public Task<IHtmlContent> Indicator()
        {
            return _htmlHelper.PartialAsync("_Indicator");
        }
    }
}
