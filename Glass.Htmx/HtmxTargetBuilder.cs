using System.Text;

namespace Glass.Htmx
{
    public class HtmxTargetBuilder : IHtmxSelectBuilder
    {
        public StringBuilder _properties = new StringBuilder();

        public HtmxTargetBuilder() :base()
        {

        }

        public void Append(string value)
        {
            _properties.Append(value);
        }

        public string Build()
        {
            return _properties.ToString();
        }
    }
}
