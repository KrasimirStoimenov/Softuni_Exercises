using HandmadeHttpServer.Http.HttpResponse;

namespace HandmadeHttpServer.Responses
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
