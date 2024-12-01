using System.Text;

namespace Glass.Htmx
{
    public class HtmxSwapBuilder
    {
        StringBuilder _properties = new StringBuilder();

        public HtmxSwapBuilder(Swap swap)
        {
            _properties.Append(swap.ToString());
        }


        /// <summary>
        /// https://htmx.org/attributes/hx-swap/
        /// </summary>
        /// <param name="swap"></param>
        /// <returns></returns>
        public HtmxSwapBuilder IgnoreTitle()
        {
            Append($"{Properties.IgnoreTitle}:{Constants.True}");
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-swap/
        /// </summary>
        /// <param name="swap"></param>
        /// <returns></returns>
        public HtmxSwapBuilder Swap(int milliSeconds)
        {
            Append($"{Properties.Swap}:{milliSeconds}ms");
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-swap/
        /// </summary>
        /// <param name="swap"></param>
        /// <returns></returns>
        public HtmxSwapBuilder Settle(int milliSeconds)
        {
            Append($"{Properties.Settle}:{milliSeconds}ms");
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-swap/
        /// </summary>
        /// <param name="swap"></param>
        /// <returns></returns>
        public HtmxSwapBuilder ScrollTop(string selector = null)
        {
            Append($"{Properties.Scroll}:{(selector == null ? string.Empty : $"{selector}:")}{Constants.Top}");
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-swap/
        /// </summary>
        /// <param name="swap"></param>
        /// <returns></returns>
        public HtmxSwapBuilder ScrollBottom(string selector = null)
        {
            Append($"{Properties.Scroll}:{(selector == null ? string.Empty : $"{selector}:")}{Constants.Bottom}");
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-swap/
        /// </summary>
        /// <param name="swap"></param>
        /// <returns></returns>
        public HtmxSwapBuilder ShowTop(string selector = null)
        {
            Append($"{Properties.Show}:{(selector == null ? string.Empty : $"{selector}:")}{Constants.Top}");
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-swap/
        /// </summary>
        /// <param name="swap"></param>
        /// <returns></returns>
        public HtmxSwapBuilder ShowBottom(string selector = null)
        {
            Append($"{Properties.Show}:{(selector == null ? string.Empty : $"{selector}:")}{Constants.Bottom}");
            return this;
        }

        /// <summary>
        /// https://htmx.org/attributes/hx-swap/
        /// </summary>
        /// <param name="swap"></param>
        /// <returns></returns>
        public HtmxSwapBuilder FocusScroll(bool focusScroll = true)
        {
            Append($"{Properties.FocusScroll}${(focusScroll ? Constants.True : Constants.False)}");
            return this;
        }

        public string Build()
        {
            return _properties.ToString();
        }

        private void Append(string value)
        {
            _properties.Append($"{value} ");
        }

        public class Properties
        {
            public const string IgnoreTitle = "ignoreTitle";
            public const string Swap = "swap";
            public const string Settle = "settle";
            public const string Scroll = "scroll";
            public const string Show = "show";
            public const string FocusScroll = "focus-scroll";
        }
    }
}
