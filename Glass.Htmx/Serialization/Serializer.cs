using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Glass.Htmx.Serialization
{
    public static class Serializer
    {
        static JsonSerializerOptions _options;

        static Serializer()
        {
            _options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,

            };

            _options.Converters.Add(new SwapConverterFactory());
        }

        public static string Serialize<T>(T obj) where T : class
        {
            return JsonSerializer.Serialize(obj, _options);
        }
    }
}
