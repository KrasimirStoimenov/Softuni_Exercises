using HandmadeHTTPServer.Server.Http.HttpResponse;

namespace HandmadeHTTPServer.Server.Responses
{
    public class BadRequestResponse : HttpResponse
    {
        public BadRequestResponse() 
            : base(HttpStatusCode.BadRequest)
        {
        }
    }
}
