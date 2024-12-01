using Glass.Htmx;
using Microsoft.AspNetCore.Http;

namespace Glass.Htmx
{
    public  static class HttpRequestExtensionMethods
    {
        public static HtmxRequest IsHtmx(this HttpRequest httpRequest)
        {
            return new HtmxRequest(httpRequest);
        }

    }
}
