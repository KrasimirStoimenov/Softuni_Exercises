using HandmadeHttpServer.Http.HttpResponse;

namespace HandmadeHttpServer.Results
{
    public class ContentResult : ActionResult
    {
        public ContentResult(HttpResponse response, string content, string contentType)
            : base(response)
            => this.SetContent(content, contentType);
    }
}
