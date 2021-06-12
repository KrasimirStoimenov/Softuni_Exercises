using HandmadeHttpServer.Http.HttpResponse;

namespace HandmadeHttpServer.Responses
{
    public class NotFoundResponse : HttpResponse
    {
        public NotFoundResponse()
            : base(HttpStatusCode.NotFound)
        {
        }
    }
}
