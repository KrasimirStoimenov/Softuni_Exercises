using HandmadeHttpServer.Http.HttpResponse;

namespace HandmadeHttpServer.Results
{
    public class NotFoundResult : ActionResult
    {
        public NotFoundResult(HttpResponse response)
            : base(response)
        {
            this.StatusCode = HttpStatusCode.NotFound;
        }
    }
}
