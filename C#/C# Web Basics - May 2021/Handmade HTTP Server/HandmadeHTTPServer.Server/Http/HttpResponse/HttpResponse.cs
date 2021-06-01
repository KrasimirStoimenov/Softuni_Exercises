using System.Collections.Generic;

namespace HandmadeHTTPServer.Server.Http.HttpResponse
{
    public class HttpResponse
    {
        private Dictionary<string, HttpHeader> headers;

        public HttpResponse()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public HttpStatusCode StatusCode { get; private set; }

        public string Content { get; private set; }
    }
}
