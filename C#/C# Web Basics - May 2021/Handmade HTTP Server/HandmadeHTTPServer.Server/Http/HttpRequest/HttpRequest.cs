using System;
using System.Collections.Generic;
using System.Linq;

namespace HandmadeHTTPServer.Server.Http.HttpRequest
{
    public class HttpRequest
    {
        private const string newLine = "\r\n";

        public HttpRequest()
        {
            this.Headers = new List<HttpHeader>();
        }

        public HttpMethod Method { get; private set; }

        public List<HttpHeader> Headers { get; private set; }

        public string Url { get; private set; }

        public string Body { get; set; }

        public static HttpRequest ParseHttpRequest(string request)
        {
            var lines = request.Split(newLine);

            var firstLineSplitted = lines[0].Split(" ");

            var method = ParseMethod(firstLineSplitted[0]);

            var url = firstLineSplitted[1];

            var headers = ParseHeaders(lines.Skip(1));

            var bodyLines = lines.Skip(headers.Count + 2).ToArray();

            return new HttpRequest
            {
                Method = method,
                Url = url,
                Headers = headers,
                Body = string.Join(newLine, bodyLines)
            };

    }

        private static List<HttpHeader> ParseHeaders(IEnumerable<string> headers)
        {
            var currentHeaders = new List<HttpHeader>();
            foreach (var header in headers)
            {
                if (header == string.Empty)
                {
                    break;
                }

                var headerParts = header.Split(":", 2);

                var currentHeader = new HttpHeader()
                {
                    Name = headerParts[0],
                    Value = headerParts[1]
                };

                currentHeaders.Add(currentHeader);
            }

            return currentHeaders;
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
    }
}
