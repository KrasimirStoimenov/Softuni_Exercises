using HandmadeHTTPServer.Server.Http;

namespace HandmadeHTTPServer.Server.Responses
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string html)
            : base(html, HttpContentType.Html)
        {
        }
    }
}
