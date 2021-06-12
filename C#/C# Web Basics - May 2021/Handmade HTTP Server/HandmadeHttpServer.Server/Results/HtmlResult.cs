using HandmadeHttpServer.Http;
using HandmadeHttpServer.Http.HttpResponse;

namespace HandmadeHttpServer.Results
{
    public class HtmlResult : ContentResult
    {
        public HtmlResult(HttpResponse response, string html)
            : base(response, html, HttpContentType.Html)
        {
        }
    }
}
