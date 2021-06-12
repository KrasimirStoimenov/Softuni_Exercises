using HandmadeHttpServer.Http;
using HandmadeHttpServer.Http.HttpResponse;

namespace HandmadeHttpServer.Results
{
    public class TextResult : ContentResult
    {
        public TextResult(HttpResponse response, string text)
            : base(response, text, HttpContentType.PlainText)
        {
        }
    }
}
