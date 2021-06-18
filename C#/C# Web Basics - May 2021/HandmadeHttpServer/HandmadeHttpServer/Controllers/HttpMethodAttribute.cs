using HandmadeHttpServer.Http.HttpRequest;
using System;

namespace HandmadeHttpServer.Controllers
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HttpMethodAttribute : Attribute
    {
        protected HttpMethodAttribute(HttpMethod httpMethod)
            => this.HttpMethod = httpMethod;

        public HttpMethod HttpMethod { get; }
    }
}
