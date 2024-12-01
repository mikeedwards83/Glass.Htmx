using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass.Htmx.Response.Headers
{
    public class HtmxTriggerHeader
    {
        public string? Target { get; set; }
        public HtmxTriggerHeader() { }
        public HtmxTriggerHeader(string target)
        {
            Target = target;
        }
    }
}
