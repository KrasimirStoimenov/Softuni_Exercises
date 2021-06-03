using System.Collections.Generic;
using System.Text;

namespace HandmadeHTTPServer.Server.Http.HttpResponse
{
    public class HttpResponse
    {
        public HttpResponse()
        {
            this.Headers = new List<HttpHeader>();
        }

        public HttpStatusCode StatusCode { get; init; }

        public string Content { get; init; }

        public List<HttpHeader> Headers { get; private set; }

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
