using System.Threading.Tasks;
using Handmade_HTTP_Server.Controllers;
using HandmadeHttpServer.Server;
using HandmadeHTTPServer.Server.Controllers;

namespace HandmadeHttpServer
{
    class StartUp
    {
        static async Task Main(string[] args)
        {
            await new HttpServer(routes => routes
                 .MapGet<HomeController>("/", c => c.Index())
                 .MapGet<HomeController>("/ToCats", c => c.LocalRedirect())
                 .MapGet<HomeController>("/Softuni", c => c.ToGoogle())
                 .MapGet<AnimalsController>("/Cats", c => c.Cats())
                 .MapGet<AnimalsController>("/Dogs", c => c.Dogs()))
             .Start();
        }
    }
}
