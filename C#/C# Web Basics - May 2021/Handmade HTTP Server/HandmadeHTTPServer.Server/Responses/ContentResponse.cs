using HandmadeHTTPServer.Server.Common;
using HandmadeHTTPServer.Server.Http;
using HandmadeHTTPServer.Server.Http.HttpResponse;
using System.Text;

namespace HandmadeHTTPServer.Server.Responses
{
    public class ContentResponse : HttpResponse
    {
        public ContentResponse(string content, string contentType)
            : base(HttpStatusCode.OK)
        {
            this.PrepareContent(content, contentType);
        }
    }
}
