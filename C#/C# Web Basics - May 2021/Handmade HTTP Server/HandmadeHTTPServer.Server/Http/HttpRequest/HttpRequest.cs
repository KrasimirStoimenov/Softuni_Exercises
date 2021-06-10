﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace HandmadeHTTPServer.Server.Http.HttpRequest
{
    public class HttpRequest
    {
        private const string newLine = "\r\n";

        public HttpMethod Method { get; private set; }

        public string Path { get; private set; }

        public string Body { get; private set; }

        public IReadOnlyDictionary<string, HttpHeader> Headers { get; private set; }

        public IReadOnlyDictionary<string, string> Query { get; private set; }

        public IReadOnlyDictionary<string, string> Form { get; private set; }

        public static HttpRequest ParseHttpRequest(string request)
        {
            var lines = request.Split(newLine);

            var firstLineSplitted = lines[0].Split(" ");

            var method = ParseMethod(firstLineSplitted[0]);

            var url = firstLineSplitted[1];

            var (path, query) = ParseUrl(url);

            var headers = ParseHeaders(lines.Skip(1));

            var bodyLines = lines.Skip(headers.Count + 2).ToArray();

            var body = string.Join(newLine, bodyLines);

            var form = ParseForm(headers, body);

            return new HttpRequest
            {
                Method = method,
                Path = path,
                Query = query,
                Headers = headers,
                Body = body,
                Form = form
            };

        }

        private static HttpMethod ParseMethod(string request)
        {
            var parsed = Enum.TryParse<HttpMethod>(request, out var method);

            if (parsed)
            {
                return method;
            }

            throw new InvalidOperationException("Method is not supported!");
        }

        private static (string, Dictionary<string, string>) ParseUrl(string url)
        {
            var urlParts = url.Split("?", 2);

            var path = urlParts[0];
            var query = urlParts.Length > 1
                        ? ParseQuery(urlParts[1])
                        : new Dictionary<string, string>();

            return (path, query);
        }

        private static Dictionary<string, HttpHeader> ParseHeaders(IEnumerable<string> headers)
        {
            var currentHeaders = new Dictionary<string, HttpHeader>();
            foreach (var header in headers)
            {
                if (header == string.Empty)
                {
                    break;
                }

                var headerParts = header.Split(":", 2);

                if (headerParts.Length != 2)
                {
                    throw new InvalidOperationException("Request is not valid.");
                }

                var name = headerParts[0];
                var value = headerParts[1];

                var currentHeader = new HttpHeader(name, value);

                currentHeaders.Add(name, currentHeader);
            }

            return currentHeaders;
        }

        private static Dictionary<string, string> ParseQuery(string queryString)
        {
            return queryString
                .Split("&")
                .Select(part => part.Split("="))
                .Where(part => part.Length == 2)
                .ToDictionary(part => part[0], part => part[1]);
        }

        private static Dictionary<string, string> ParseForm(Dictionary<string, HttpHeader> headers, string body)
        {
            var result = new Dictionary<string, string>();

            if (headers.ContainsKey(HttpHeader.ContentType) && headers[HttpHeader.ContentType].Value == HttpContentType.FormUrlEncoded)
            {
                result = ParseQuery(body);
            }

            return result;
        }
    }
}
