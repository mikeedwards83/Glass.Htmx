using System.Text.Json;
using System.Text.Json.Serialization;
using Glass.Htmx.Response.Headers;
using Glass.Htmx.Serialization;
using Microsoft.AspNetCore.Http;

namespace Glass.Htmx
{
    public class HtmxResponseBuilder
    {
        private HttpResponse _response;

        private Dictionary<string, HtmxTriggerHeader> _triggers = new();

        public string? Triggers => GetHeader(Headers.HxTrigger);
        public string? TriggerAfterSettle => GetHeader(Headers.HxTriggerAfterSettle);
        public string? TriggerAfterSwap => GetHeader(Headers.HxTriggerAfterSwap);
        public string? Location => GetHeader(Headers.HxLocation);

        public HtmxResponseBuilder(HttpResponse response)
        {
            _response = response;
        }

        private string GetHeader(string key)
        {
            return _response.Headers.TryGetValue(key, out var header) ? header : default(string);
        }

        /// <summary>
        /// https://htmx.org/headers/hx-trigger/
        /// </summary>
        /// <param name="trigger"></param>
        /// <returns></returns>
        public HtmxResponseBuilder WithTrigger(string trigger, Action<HtmxTriggerHeaderBuilder> builder = null)
        {
            WriteTrigger(Headers.HxTrigger, trigger, builder);
            return this;
        }

        /// <summary>
        /// https://htmx.org/headers/hx-trigger/
        /// </summary>
        /// <param name="trigger"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public HtmxResponseBuilder WithTriggerAfterSettle(string trigger, Action<HtmxTriggerHeaderBuilder> builder = null)
        {
            WriteTrigger(Headers.HxTriggerAfterSettle, trigger, builder);
            return this;
        }

        /// <summary>
        /// https://htmx.org/headers/hx-trigger/
        /// </summary>
        /// <param name="trigger"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public HtmxResponseBuilder WithTriggerAfterSwap(string trigger, Action<HtmxTriggerHeaderBuilder> builder = null)
        {
            WriteTrigger(Headers.HxTriggerAfterSwap, trigger, builder);
            return this;
        }

        /// <summary>
        /// https://htmx.org/headers/hx-location/
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public HtmxResponseBuilder WithLocation(string path, Action<HtmxLocationHeaderBuilder> builder = null)
        {
            if (builder == null)
            {
                _response.Headers[Headers.HxLocation] = path;
            }
            else
            {
                var builderInst = new HtmxLocationHeaderBuilder(path);
                builder(builderInst);
                _response.Headers[Headers.HxLocation] = Serializer.Serialize(builderInst.Header);
            }

            return this;
        }

        /// <summary>
        /// https://htmx.org/headers/hx-push-url/
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public HtmxResponseBuilder WithPushUrl(string url)
        {
            _response.Headers[Headers.HXPushUrl] = url;
            return this;
        }

        /// <summary>
        /// https://htmx.org/headers/hx-redirect/
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public HtmxResponseBuilder WithRedirect(string url)
        {
            _response.Headers[Headers.HXRedirect] = url;
            return this;
        }

        /// <summary>
        /// https://htmx.org/reference/
        /// </summary>
        /// <returns></returns>
        public HtmxResponseBuilder WithRefresh()
        {
            _response.Headers[Headers.HXRefresh] = Constants.True;
            return this;
        }

        /// <summary>
        /// https://htmx.org/headers/hx-replace-url/
        /// </summary>
        /// <returns></returns>
        public HtmxResponseBuilder WithReplaceUrl(string url)
        {
            _response.Headers[Headers.HXRefresh] = Constants.True;
            return this;
        }

        /// <summary>
        /// https://htmx.org/reference/
        /// </summary>
        /// <param name="swap"></param>
        /// <returns></returns>
        public HtmxResponseBuilder WithReswap(Swap swap)
        {
            switch (swap)
            {
                case Swap.NotSet:
                    break;
                default:
                    _response.Headers[Headers.HXReswap] = swap.ToString();
                    break;
            }

            return this;
        }

        /// <summary>
        /// https://htmx.org/reference/
        /// </summary>
        /// <returns></returns>
        public HtmxResponseBuilder WithRetarget(string target)
        {
            _response.Headers[Headers.HXRetarget] =target;
            return this;
        }

        /// <summary>
        /// https://htmx.org/reference/
        /// </summary>
        /// <returns></returns>
        public HtmxResponseBuilder WithReselect(string select)
        {
            _response.Headers[Headers.HXReselect] = select;
            return this;
        }

        private void WriteTrigger(string headerKey, string trigger, Action<HtmxTriggerHeaderBuilder> builder)
        {
            if (builder == null)
            {
                _triggers[trigger] = new();
            }
            else
            {
                var builderInst = new HtmxTriggerHeaderBuilder(trigger);
                builder(builderInst);
                _triggers[trigger] = builderInst.Header;
            }

            _response.Headers[headerKey] = Serializer.Serialize(_triggers);
        }

        public class Headers
        {
            public const string HxLocation = "HX-Location";
            public const string HxTrigger = "HX-Trigger";
            public const string HxTriggerAfterSettle = "HX-Trigger-After-Settle";
            public const string HxTriggerAfterSwap = "HX-Trigger-After-Swap";
            public const string HXPushUrl = "HX-Push-Url";
            public const string HXRedirect = "HX-Redirect";
            public const string HXRefresh = "HX-Refresh";
            public const string HXReplaceUrl = "HX-Replace-Url";
            public const string HXReswap = "HX-Reswap";
            public const string HXRetarget = "HX-Retarget";
            public const string HXReselect = "HX-Reselect";
        }
    }
}
