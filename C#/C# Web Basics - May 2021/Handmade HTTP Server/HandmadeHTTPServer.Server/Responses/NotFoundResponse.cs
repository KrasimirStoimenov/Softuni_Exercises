using HandmadeHTTPServer.Server.Http.HttpResponse;

namespace HandmadeHTTPServer.Server.Responses
{
    public class NotFoundResponse : HttpResponse
    {
        public NotFoundResponse()
            : base(HttpStatusCode.NotFound)
        {
        }
    }
}
