using HandmadeHTTPServer.Server.Http;

namespace HandmadeHTTPServer.Server.Responses
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string text) 
            : base(text, HttpContentType.PlainText)
        {
        }
    }
}
