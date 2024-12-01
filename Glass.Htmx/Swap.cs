using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Glass.Htmx
{
    public enum Swap
    {
        NotSet = default,
        InnerHTML,
        OuterHTML,
        TextContent,
        Beforebegin,
        Afterbegin,
        Beforeend,
        Afterend,
        Delete,
        None
    }
}
