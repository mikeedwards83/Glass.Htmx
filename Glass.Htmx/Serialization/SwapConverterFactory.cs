using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Glass.Htmx.Serialization
{
    public class SwapConverterFactory : JsonConverterFactory
    {
        public SwapConverterFactory()
        {
        }

        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsEnum;
        }

        /// <inheritdoc />
        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            if (!typeToConvert.IsEnum)
            {
                throw new NotSupportedException(string.Format("Type {0} must be an enum", typeToConvert.FullName));
            }

            return new SwapConverter();
        }

        public class SwapConverter : JsonConverter<Swap>
        {
            public override Swap Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var value = reader.GetString();
                return Enum.Parse<Swap>(value);
            }

            public override void Write(Utf8JsonWriter writer, Swap value, JsonSerializerOptions options)
            {
                if(value == Swap.NotSet)
                {
                    return;
                }

                switch (value)
                {
                    case Swap.NotSet:
                        writer.WriteNullValue();
                        break;
                    default:
                        writer.WriteStringValue(value.ToString());
                        break;
                }
            }
        }
    }
}
