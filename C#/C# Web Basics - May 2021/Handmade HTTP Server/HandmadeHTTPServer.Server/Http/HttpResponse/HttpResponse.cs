using System;
using System.Collections.Generic;
using System.Text;

namespace HandmadeHTTPServer.Server.Http.HttpResponse
{
    public class HttpResponse
    {
        public HttpResponse(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;

            this.Headers.Add(new HttpHeader("Server", "My Web Server"));
            this.Headers.Add(new HttpHeader("Date", $"{DateTime.UtcNow:r}"));
        }

        public HttpStatusCode StatusCode { get; init; }

        public string Content { get; init; }

        public List<HttpHeader> Headers { get; private set; } = new List<HttpHeader>();

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode}");

            foreach (var header in this.Headers)
            {
                result.AppendLine(header.ToString());
            }

            if (!string.IsNullOrEmpty(this.Content))
            {
                result.AppendLine();

                result.Append(this.Content);
            }

            return result.ToString();
        }
    }
}
