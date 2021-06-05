using System;
using HandmadeHTTPServer.Server.Http.HttpRequest;
using HandmadeHTTPServer.Server.Http.HttpResponse;

namespace HandmadeHTTPServer.Server.Routing
{
    public interface IRoutingTable
    {
        IRoutingTable Map(HttpMethod method, string path, HttpResponse response);
        IRoutingTable Map(HttpMethod method, string path, Func<HttpRequest, HttpResponse> responseFunction);
        IRoutingTable MapGet(string path, HttpResponse response);
        IRoutingTable MapGet(string path, Func<HttpRequest, HttpResponse> responseFunction);
        IRoutingTable MapPost(string path, HttpResponse response);
        IRoutingTable MapPost(string path, Func<HttpRequest, HttpResponse> responseFunction);
    }
}
