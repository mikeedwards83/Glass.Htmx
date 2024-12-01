using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Glass.Htmx.HtmxResponseBuilder;

namespace Glass.Htmx.Response.Headers
{
    public class HtmxTriggerHeaderBuilder(string trigger)
    {
        public HtmxTriggerHeader Header { get; } = new HtmxTriggerHeader();
        public HtmxTriggerHeaderBuilder Target(string target)
        {
            Header.Target = target;
            return this;
        }
    }
}




