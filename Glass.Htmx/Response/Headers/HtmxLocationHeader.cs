using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Glass.Htmx.Response.Headers
{
    public class HtmxLocationHeader(string path)
    {
        public string Path => path;
        public string Target { get; set; }
        public string Source { get; set; }
        public string Handler { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Swap Swap { get; set; }
        public string Values { get; set; }
        public string Headers { get; set; }
        public string Select { get; set; }
    }
}
