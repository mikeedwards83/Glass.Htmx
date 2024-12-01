using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass.Htmx.Response.Headers
{
    public class HtmxLocationHeaderBuilder(string path)
    {
        public HtmxLocationHeader Header { get; } = new HtmxLocationHeader(path);

        public HtmxLocationHeaderBuilder Source(string source)
        {
            Header.Source = source;
            return this;
        }

        public HtmxLocationHeaderBuilder Target(string target)
        {
            Header.Target = target;
            return this;
        }

        public HtmxLocationHeaderBuilder Handler(string handler)
        {
            Header.Handler = handler;
            return this;
        }

        public HtmxLocationHeaderBuilder Swap(Swap swap)
        {
            Header.Swap = swap;
            return this;
        }

        public HtmxLocationHeaderBuilder Values(string values)
        {
            Header.Values = values;
            return this;
        }

        public HtmxLocationHeaderBuilder Headers(string headers)
        {
            Header.Headers = headers;
            return this;
        }

        public HtmxLocationHeaderBuilder Select(string select)
        {
            Header.Select = select;
            return this;
        }
    }
}
