﻿using System;
using System.Collections.Generic;
using System.IO;
using HandmadeHttpServer.Common;
using HandmadeHttpServer.Http;
using HandmadeHttpServer.Http.HttpRequest;
using HandmadeHttpServer.Http.HttpResponse;
using HandmadeHttpServer.Results;

namespace HandmadeHttpServer.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<HttpMethod, Dictionary<string, Func<HttpRequest, HttpResponse>>> routes;

        public RoutingTable()
        {
            this.routes = new()
            {
                [HttpMethod.GET] = new(),
                [HttpMethod.POST] = new(),
                [HttpMethod.PUT] = new(),
                [HttpMethod.DELETE] = new(),
            };
        }

        public IRoutingTable Map(HttpMethod method, string path, HttpResponse response)
        {
            return this.Map(method, path, request => response);
        }

        public IRoutingTable Map(HttpMethod method, string path, Func<HttpRequest, HttpResponse> responseFunction)
        {
            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(responseFunction, nameof(responseFunction));

            this.routes[method][path.ToLower()] = responseFunction;

            return this;
        }

        public IRoutingTable MapGet(string path, HttpResponse response)
        {
            return this.MapGet(path, request => response);
        }

        public IRoutingTable MapGet(string path, Func<HttpRequest, HttpResponse> responseFunction)
        {
            return this.Map(HttpMethod.GET, path, responseFunction);
        }

        public IRoutingTable MapPost(string path, HttpResponse response)
        {
            return this.MapPost(path, request => response);
        }

        public IRoutingTable MapPost(string path, Func<HttpRequest, HttpResponse> responseFunction)
        {
            return this.Map(HttpMethod.POST, path, responseFunction);
        }

        public IRoutingTable MapStaticFiles(string folder = Settings.StaticFilesRootFolder)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var staticFilesFolder = Path.Combine(currentDirectory, folder);
            var staticFiles = Directory.GetFiles(staticFilesFolder, "*.*", SearchOption.AllDirectories);

            foreach (var file in staticFiles)
            {
                var relativePath = Path.GetRelativePath(staticFilesFolder, file);

                var urlPath = "/" + relativePath.Replace("\\", "/");

                this.MapGet(urlPath, request =>
                {
                    var content = File.ReadAllBytes(file);
                    var fileExtension = Path.GetExtension(file).Trim('.');
                    var contentType = HttpContentType.GetByFileExtension(fileExtension);

                    return new HttpResponse(HttpStatusCode.OK)
                        .SetContent(content, contentType);
                });

            }
            return this;
        }

        public HttpResponse ExecuteRequest(HttpRequest request)
        {
            var requestMethod = request.Method;
            var requestPath = request.Path.ToLower();

            if (!this.routes.ContainsKey(requestMethod) || !this.routes[requestMethod].ContainsKey(requestPath))
            {
                return new HttpResponse(HttpStatusCode.NotFound);
            }

            var responseFunction = this.routes[requestMethod][requestPath];

            return responseFunction(request);
        }
    }
}
