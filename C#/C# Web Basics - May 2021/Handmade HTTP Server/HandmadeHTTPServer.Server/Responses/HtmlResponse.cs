using HandmadeHttpServer.Http;

namespace HandmadeHttpServer.Responses
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string html)
            : base(html, HttpContentType.Html)
        {
        }
    }
}
