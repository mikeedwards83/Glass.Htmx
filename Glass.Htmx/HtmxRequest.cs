using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Glass.Htmx
{
    public class HtmxRequest 
    {
        private HttpRequest _request;

        public HtmxRequest(HttpRequest request) 
        {

            _request = request;
        }

        /// <summary>
        /// https://htmx.org/reference/#request_headers
        /// </summary>
        /// <returns></returns>
        public bool IsHtmxRequest()
        {
            return _request.Headers.ContainsKey(Headers.HxRequest);
        }

        /// <summary>
        /// https://htmx.org/reference/#request_headers
        /// </summary>
        /// <returns></returns>
        public bool IsBoosted()
        {
            return _request.Headers.ContainsKey(Headers.HxBoosted);
        }

        /// <summary>
        /// https://htmx.org/reference/#request_headers        
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool HasCurrentUrl(out string value)
        {
            StringValues headerValues;
            
            if(_request.Headers.TryGetValue(Headers.HxCurrentUrl, out headerValues))
            {
                value = headerValues.Single(); 
                return true;
            }

            value = null;
            return false;
        }

        /// <summary>
        /// https://htmx.org/reference/#request_headers1        
        /// </summary>
        /// <returns></returns>
        public bool IsHistoryRestore()
        {
            StringValues headerValues;

            if (_request.Headers.TryGetValue(Headers.HXHistoryRestoreRequest, out headerValues))
            {
                var value = headerValues.Single();
                return value == Constants.True;
            }

            return false;
        }

        /// <summary>
        /// https://htmx.org/reference/#request_headers        
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool HasPrompt(out string value)
        {
            StringValues headerValues;

            if (_request.Headers.TryGetValue(Headers.HXPrompt, out headerValues))
            {
                value = headerValues.Single();
                return true;
            }

            value = null;
            return false;
        }

        /// <summary>
        /// https://htmx.org/reference/#request_headers        
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool HasTarget(out string value)
        {
            StringValues headerValues;

            if (_request.Headers.TryGetValue(Headers.HXTarget, out headerValues))
            {
                value = headerValues.Single();
                return true;
            }

            value = null;
            return false;
        }

        /// <summary>
        /// https://htmx.org/reference/#request_headers        
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool HasTriggerName(out string value)
        {
            StringValues headerValues;

            if (_request.Headers.TryGetValue(Headers.HXTriggerName, out headerValues))
            {
                value = headerValues.Single();
                return true;
            }

            value = null;
            return false;
        }

        /// <summary>
        /// https://htmx.org/reference/#request_headers        
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool HasTrigger(out string value)
        {
            StringValues headerValues;

            if (_request.Headers.TryGetValue(Headers.HXTrigger, out headerValues))
            {
                value = headerValues.Single();
                return true;
            }

            value = null;
            return false;
        }

        public static class Headers
        {
            public const string HxRequest = "HX-Request";
            public const string HxBoosted = "HX-Boosted";
            public const string HxCurrentUrl = "HX-Current-URL";
            public const string HXHistoryRestoreRequest = "HX-History-Restore-Request";
            public const string HXPrompt = "HX-Prompt";
            public const string HXTarget = "HX-Target";
            public const string HXTriggerName = "HX-Trigger-Name";
            public const string HXTrigger = "HX-Trigger";
        }
    }
}
