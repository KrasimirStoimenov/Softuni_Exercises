using HandmadeHttpServer.Http.HttpRequest;

namespace HandmadeHttpServer.Controllers
{
    public class HttpGetAttribute : HttpMethodAttribute
    {
        public HttpGetAttribute()
            : base(HttpMethod.GET)
        {
        }
    }
}
