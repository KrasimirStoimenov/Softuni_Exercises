﻿using System;
using HandmadeHttpServer.Common;
using HandmadeHttpServer.Http.HttpRequest;
using HandmadeHttpServer.Http.HttpResponse;

namespace HandmadeHttpServer.Routing
{
    public interface IRoutingTable
    {
        IRoutingTable MapStaticFiles(string folder = Settings.StaticFilesRootFolder);
        IRoutingTable Map(HttpMethod method, string path, HttpResponse response);
        IRoutingTable Map(HttpMethod method, string path, Func<HttpRequest, HttpResponse> responseFunction);
        IRoutingTable MapGet(string path, HttpResponse response);
        IRoutingTable MapGet(string path, Func<HttpRequest, HttpResponse> responseFunction);
        IRoutingTable MapPost(string path, HttpResponse response);
        IRoutingTable MapPost(string path, Func<HttpRequest, HttpResponse> responseFunction);
    }
}
