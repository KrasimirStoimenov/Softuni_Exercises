using System.Collections.Generic;

namespace HandmadeHTTPServer.Server.Http.HttpRequest
{
    public class HttpRequest
    {
        private Dictionary<string, HttpHeader> headers;

        public HttpRequest()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public HttpMethod Method { get; private set; }

        public string Url { get; private set; }

        public string Body { get; set; }


    }
}
