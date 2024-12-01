using System.Text;

namespace Glass.Htmx
{
    public class HtmxTriggerBuilder
    {
        StringBuilder _parameters = new StringBuilder();

        public HtmxTriggerBuilder(Triggers trigger)
        {

            Append(trigger.ToString());
        }

        public HtmxTriggerBuilder(string trigger)
        {
            Append(trigger);
        }

        public HtmxTriggerBuilder Delay(int milliSeconds)
        {
            Append(Parameters.Delay, $"{milliSeconds}ms");
            return this;
        }

        public HtmxTriggerBuilder Throttle(int milliSeconds)
        {
            Append(Parameters.Throttle, $"{milliSeconds}ms");
            return this;
        }

        public HtmxTriggerBuilder From(string selector)
        {
            Append(Parameters.From, selector);
            return this;
        }

        public HtmxTriggerBuilder FromDocument()
        {
            Append(Parameters.From, Parameters.FromDocument);
            return this;
        }

        public HtmxTriggerBuilder FromWindow()
        {
            Append(Parameters.From, Parameters.FromWindow);
            return this;
        }

        public HtmxTriggerBuilder Target(string selector)
        {
            Append(Parameters.Target, selector);
            return this;
        }

        public HtmxTriggerBuilder Consume()
        {
            Append(Parameters.Consume);
            return this;
        }

        public HtmxTriggerBuilder Queue(Queue queue)
        {
            Append(Parameters.Queue, queue.ToString());
            return this;
        }

        public string Build()
        {
            return _parameters.ToString();
        }

        private void Append(string key)
        {
            _parameters.Append(key);
        }

        private void Append(string key, string value)
        {
            _parameters.Append($"{key}:{value} ");
        }

        public class Parameters
        {
            public const string Delay = "delay";
            public const string Throttle = "throttle";
            public const string From = "from";
            public const string FromDocument = "document";
            public const string FromWindow = "document";
            public const string FromClosest = "closest";
            public const string Target = "target";
            public const string Consume = "consume";
            public const string Queue = "queue";
        }
    }
}
