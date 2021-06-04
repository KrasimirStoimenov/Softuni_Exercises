using HandmadeHTTPServer.Server.Common;
using HandmadeHTTPServer.Server.Http;
using HandmadeHTTPServer.Server.Http.HttpResponse;
using System.Text;

namespace HandmadeHTTPServer.Server.Responses
{
    public class ContentResponse : HttpResponse
    {
        public ContentResponse(string text, string contentType)
            : base(HttpStatusCode.OK)
        {
            Guard.AgainstNull(text);

            var contentLength = Encoding.UTF8.GetByteCount(text).ToString();

            this.Headers.Add(new HttpHeader("Content-Type", contentType));
            this.Headers.Add(new HttpHeader("Content-Length", contentLength));

            this.Content = text;
        }
    }
}
