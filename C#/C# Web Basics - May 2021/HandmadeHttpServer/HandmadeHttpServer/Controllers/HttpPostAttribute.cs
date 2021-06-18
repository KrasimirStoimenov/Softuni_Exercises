using HandmadeHttpServer.Http.HttpRequest;

namespace HandmadeHttpServer.Controllers
{
    public class HttpPostAttribute : HttpMethodAttribute
    {
        public HttpPostAttribute()
            : base(HttpMethod.POST)
        {
        }
    }
}
