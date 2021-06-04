﻿using HandmadeHTTPServer.Server.Http;
using HandmadeHTTPServer.Server.Http.HttpResponse;

namespace HandmadeHTTPServer.Server.Responses
{
    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string location)
            : base(HttpStatusCode.Found)
        {
            this.Headers.Add(new HttpHeader("Location", location));
        }
    }
}
