using System.Dynamic;
using System.Text;
using Microsoft.AspNetCore.Html;

namespace Glass.Htmx
{
    public class HtmxAttributeBuilder
    {
        Dictionary<string, string> _attributes = new Dictionary<string, string>();

        /// <summary>
        /// https://htmx.org/attributes/hx-get/
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended Get(string url)
        {
            _attributes.Add(Attributes.HxGet, url);
            return new HtmxAttributeBuilderExtended(_attributes);
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-post/
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended Post(string url)
        {
            _attributes.Add(Attributes.HxPost, url);
            return new HtmxAttributeBuilderExtended(_attributes);
        }
        public HtmxAttributeBuilderExtended Delete(string url)
        {
            _attributes.Add(Attributes.HxDelete, url);
            return new HtmxAttributeBuilderExtended(_attributes);
        }

        public HtmxAttributeBuilderExtended Patch(string url)
        {
            _attributes.Add(Attributes.HxPatch, url);
            return new HtmxAttributeBuilderExtended(_attributes);
        }
        public HtmxAttributeBuilderExtended Put(string url)
        {
            _attributes.Add(Attributes.HxPut, url);
            return new HtmxAttributeBuilderExtended(_attributes);
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-boost/
        /// </summary>
        /// <param name="boost"></param>
        /// <returns></returns>
        public HtmxAttributeBuilder Boost(bool boost = true)
        {
            _attributes.Add(Attributes.HxBoost, boost ? Constants.True : Constants.False);
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-disable/
        /// </summary>
        /// <returns></returns>
        public HtmxAttributeBuilder Disable()
        {
            _attributes.Add(Attributes.HxDisabled, Constants.True);
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-history/
        /// </summary>
        /// <param name="enabled"></param>
        /// <returns></returns>
        public HtmxAttributeBuilder History(bool enabled)
        {
            _attributes.Add(HtmxAttributeBuilder.Attributes.HxHistory, enabled ? Constants.True : Constants.False);
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-preserve/
        /// </summary>
        /// <returns></returns>
        public HtmxAttributeBuilder Preserve()
        {
            _attributes.Add(Attributes.HxValidate, Constants.True);
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-validate/
        /// </summary>
        /// <returns></returns>
        public HtmxAttributeBuilder Validate(bool validate)
        {
            _attributes.Add(Attributes.HxValidate, validate ? Constants.True : Constants.False);
            return this;
        }


        public string Build()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var key in _attributes.Keys)
            {
                sb.Append($"{key}='{_attributes[key]}' ");
            }

            return sb.ToString();
        }


        public static class Attributes
        {
            public const string HxBoost = "hx-boost";
            public const string HxConfirm = "hx-confirm";
            public const string HxGet = "hx-get";
            public const string HxPost = "hx-post";
            public const string HxPut = "hx-put";
            public const string HxDelete = "hx-delete";
            public const string HxPatch = "hx-patch";
            public const string HxOn = "hx-on";
            public const string HxPushUrl = "hx-push-url";
            public const string HxSelect = "hx-select";
            public const string HxSelectOob = "hx-select-oob";
            public const string HxSwap = "hx-swap";
            public const string HxSwapOob = "hx-swap-oob";
            public const string HxTarget = "hx-target";
            public const string HxTrigger = "hx-trigger";
            public const string HxVals = "hx-vals";
            public const string HxDisabled = "hx-disable";
            public const string HxDisabledElt = "hx-disabled-elt";
            public const string HxDisinherit = "hx-disinherit";
            public const string HxEncoding = "hx-encoding";
            public const string HxHeaders = "hx-headers";
            public const string HxHistory = "hx-history";
            public const string HxInclude = "hx-include";
            public const string HxIndicator = "hx-indicator";
            public const string HxInherit = "hx-inherit";
            public const string HxParams = "hx-params";
            public const string HxValidate = "hx-validate";
            public const string HxPrompt = "hx-prompt";
            public const string HxReplaceUrl = "hx-replace-url";
        }


    }
}
