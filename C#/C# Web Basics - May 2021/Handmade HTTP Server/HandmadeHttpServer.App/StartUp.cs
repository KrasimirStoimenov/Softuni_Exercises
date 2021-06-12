using System.Threading.Tasks;
using HandmadeHttpServer.Controllers;
using HandmadeHttpServer.App.Controllers;

namespace HandmadeHttpServer.App
{
    class StartUp
    {
        static async Task Main(string[] args)
        {
            await new HttpServer(routes => routes
                 .MapGet<HomeController>("/", c => c.Index())
                 .MapGet<HomeController>("/ToCats", c => c.LocalRedirect())
                 .MapGet<HomeController>("/Google", c => c.ToGoogle())
                 .MapGet<AccountController>("/Cookies", c => c.ActionWithCookies())
                 .MapGet<AnimalsController>("/Cats", c => c.Cats())
                 .MapGet<AnimalsController>("/Dogs", c => c.Dogs())
                 .MapGet<AnimalsController>("/Bunnies", c => c.Bunnies())
                 .MapGet<AnimalsController>("/Turtles", c => c.Turtles())
                 .MapGet<CatsController>("/Cats/Create", c => c.Create())
                 .MapPost<CatsController>("/Cats/Save", c => c.Save()))
             .Start();
        }
    }
}
