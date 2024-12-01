using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Glass.Htmx.HtmxAttributeBuilder;

namespace Glass.Htmx
{
    public class HtmxAttributeBuilderExtended
    {
        Dictionary<string, string> _attributes;

        public HtmxAttributeBuilderExtended(Dictionary<string, string> attributes)
        {
            _attributes = attributes;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-confirm/
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended Confirm(string message)
        {
            _attributes.Add(HtmxAttributeBuilder.Attributes.HxConfirm, message);
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-on/
        /// </summary>
        /// <param name="evt"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended On(string evt, string action)
        {
            _attributes.Add($"{HtmxAttributeBuilder.Attributes.HxOn}{evt}", action);
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-push-url/
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended PushUrl(string url)
        {
            _attributes.Add(HtmxAttributeBuilder.Attributes.HxPushUrl, url);
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-push-url/
        /// </summary>
        /// <param name="push"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended PushUrl(bool push)
        {
            _attributes.Add(HtmxAttributeBuilder.Attributes.HxPushUrl, push ? Constants.True : Constants.False);
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-select/
        /// </summary>
        /// <param name="select"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended Select(string select)
        {
            _attributes.Add(HtmxAttributeBuilder.Attributes.HxSelect, select);
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-select-oob/
        /// </summary>
        /// <param name="select"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended SelectOob(string select)
        {
            _attributes.Add(HtmxAttributeBuilder.Attributes.HxSelectOob, select);
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-swap/
        /// </summary>
        /// <param name="swap"></param>
        /// <param name="builder"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended Swap(Swap swap, Action<HtmxSwapBuilder> builder)
        {
            var swapBuilder = new HtmxSwapBuilder(swap);
            builder(swapBuilder);

            _attributes.Add(HtmxAttributeBuilder.Attributes.HxSwap, swapBuilder.Build());
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-swap-oob/
        /// </summary>
        /// <param name="swap"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended SwapOob(Swap swap, string selector = null)
        {
            _attributes.Add(HtmxAttributeBuilder.Attributes.HxSwapOob, $"{Swap}{(selector == null ? string.Empty : $":{selector}")}");
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-target/
        /// </summary>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended Target()
        {
            _attributes.Add(HtmxAttributeBuilder.Attributes.HxTarget, Constants.This);
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-target/
        /// </summary>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended Target(string selector)
        {
            _attributes.Add(HtmxAttributeBuilder.Attributes.HxTarget, selector);
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-target/
        /// </summary>
        /// <param name="build"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended Target(Action<HtmxTargetBuilder> build)
        {
            var builder = new HtmxTargetBuilder();
            build(builder);

            _attributes.Add(HtmxAttributeBuilder.Attributes.HxTarget, builder.Build());
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-trigger/
        /// </summary>
        /// <param name="trigger"></param>
        /// <param name="build"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended Trigger(Triggers trigger, Action<HtmxTriggerBuilder> build)
        {
            return Trigger(trigger.ToString(), build);
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-trigger/
        /// </summary>
        /// <param name="milliSeconds"></param>
        /// <param name="build"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended TriggerEvery(int milliSeconds, Action<HtmxTriggerBuilder> build)
        {
            return Trigger($"{Triggers.Every} {milliSeconds}ms", build);
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-trigger/
        /// </summary>
        /// <param name="trigger"></param>
        /// <param name="build"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended Trigger(string trigger, Action<HtmxTriggerBuilder> build)
        {
            var builder = new HtmxTriggerBuilder(trigger);
            build(builder);

            if (_attributes.ContainsKey(HtmxAttributeBuilder.Attributes.HxTrigger))
            {
                _attributes[HtmxAttributeBuilder.Attributes.HxTrigger] = $"{_attributes[HtmxAttributeBuilder.Attributes.HxTrigger]}, {builder.Build()}";
            }
            else
            {
                _attributes.Add(HtmxAttributeBuilder.Attributes.HxTrigger, builder.Build());
            }
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-vals/
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended Vals<T>(T obj)
        {
            var data = JsonSerializer.Serialize(obj);
            _attributes.Add(HtmxAttributeBuilder.Attributes.HxVals, data);
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-vals/
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended ValsJs<T>(T obj)
        {
            var data = JsonSerializer.Serialize(obj);
            _attributes.Add(HtmxAttributeBuilder.Attributes.HxVals, $"js:{data}");
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-disabled-elt/
        /// </summary>
        /// <param name="build"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended DisabledElt(Action<HtmxDisabledElt> build = null)
        {
            if (DisabledElt == null)
            {
                _attributes.Add(HtmxAttributeBuilder.Attributes.HxDisabledElt, Constants.This);
            }
            else
            {
                var builder = new HtmxDisabledElt();
                build(builder);

                _attributes.Add(HtmxAttributeBuilder.Attributes.HxDisabledElt, builder.Build());
            }

            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-disinherit/
        /// </summary>
        /// <param name="attributes"></param>
        /// <returns></returns>
        //TODO: add select 
        public HtmxAttributeBuilderExtended Disinherit(string attributes)
        {
            _attributes.Add(HtmxAttributeBuilder.Attributes.HxDisinherit, attributes);
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-encoding/
        /// </summary>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended Encoding(Encoding encoding)
        {
            switch (encoding)
            {
                case Glass.Htmx.Encoding.UrlEncoding:
                    _attributes.Add(HtmxAttributeBuilder.Attributes.HxEncoding, Constants.EncodingUrl);
                    break;
                case Glass.Htmx.Encoding.Multipart:
                    _attributes.Add(HtmxAttributeBuilder.Attributes.HxEncoding, Constants.EncodingMultipart);
                    break;
                default:
                    throw new NotSupportedException(encoding.ToString());
            }

            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-headers/
        /// </summary>
        /// <param name="headers"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended Headers(Dictionary<string, string> headers)
        {
            var data = Serialization.Serializer.Serialize(headers);
            _attributes.Add(HtmxAttributeBuilder.Attributes.HxHeaders, data);

            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-history/
        /// </summary>
        /// <param name="enabled"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended History(bool enabled)
        {
            _attributes.Add(HtmxAttributeBuilder.Attributes.HxHistory, enabled ? Constants.True : Constants.False);
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-include/
        /// </summary>
        /// <param name="enabled"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended Include(Action<HtmxIncludeBuilder> build)
        {

            var builder = new HtmxIncludeBuilder();
            build(builder);

            _attributes.Add(HtmxAttributeBuilder.Attributes.HxInclude, builder.Build());
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-indicator/
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended Indicator(string selector)
        {
            _attributes.Add(HtmxAttributeBuilder.Attributes.HxIndicator, selector);
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-inherit/
        /// </summary>
        /// <param name="attributes"></param>
        /// <returns></returns>x
        public HtmxAttributeBuilderExtended Inherit(string attributes)
        {
            _attributes.Add(HtmxAttributeBuilder.Attributes.HxInherit, attributes);
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-params/
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended Params(string parameters)
        {
            _attributes.Add(HtmxAttributeBuilder.Attributes.HxParams, parameters);
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-params/
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended Params(HtmxParams option, string parameters )
        {
            switch (option)
            {
                case HtmxParams.None:
                    _attributes.Add(HtmxAttributeBuilder.Attributes.HxParams, Constants.ParamsNone);
                    break;
                case HtmxParams.All:
                    _attributes.Add(HtmxAttributeBuilder.Attributes.HxParams, Constants.ParamsAll);
                    break;
                case HtmxParams.Not:
                    _attributes.Add(HtmxAttributeBuilder.Attributes.HxParams, $"{Constants.ParamsNot} {parameters}");
                    break;
                default:
                    throw new NotSupportedException(option.ToString());
            }

            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-prompt/
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended Prompt(string message)
        {
            _attributes.Add(HtmxAttributeBuilder.Attributes.HxPrompt, message);
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-replace-url/
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended ReplaceUrl(string url)
        {
            _attributes.Add(HtmxAttributeBuilder.Attributes.HxReplaceUrl, url);
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-replace-url/
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public HtmxAttributeBuilderExtended ReplaceUrl(bool replace)
        {
            _attributes.Add(HtmxAttributeBuilder.Attributes.HxReplaceUrl, replace ? Constants.True : Constants.False);
            return this;
        }
    }

    public enum HtmxParams
    {
        All,
        None,
        Not
    }

    public class HtmxIncludeBuilder : IHtmxSelectBuilder
    {
        StringBuilder _properties = new StringBuilder();

        public HtmxIncludeBuilder()
        {
        }

        public void Append(string value)
        {
            _properties.Append($"{value} ");
        }

        public string Build()
        {
            return _properties.ToString();
        }
    }

    public enum Encoding
    {
        Multipart,
        UrlEncoding
    }

    public class HtmxDisabledElt : IHtmxSelectBuilder
    {
        StringBuilder _properties = new StringBuilder();

        public HtmxDisabledElt() { 
        }

        public void Append(string value)
        {
            _properties.Append($"{value} ");
        }

        public string Build()
        {
            return _properties.ToString();
        }
    }
}

