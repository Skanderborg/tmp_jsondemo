using System;
using System.Net;


namespace Lib_kalenda.Service
{
    public class WebClientExtension : WebClient
    {
        public int Timeout { get; set; }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            request.Timeout = 900000;
            return request;
        }
    }
}
