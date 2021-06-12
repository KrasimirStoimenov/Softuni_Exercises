using HandmadeHttpServer.Http;

namespace HandmadeHttpServer.Responses
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string text) 
            : base(text, HttpContentType.PlainText)
        {
        }
    }
}
